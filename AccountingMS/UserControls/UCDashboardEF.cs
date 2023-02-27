using AccountingMS.Classe;
using AccountingMS.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCDashboardEF : XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount;
        ClsTblAsset clsTbAsset;
        ICollection<tblAsset> tbAssetList;

        private double total;

        public UCDashboardEF()
        {
            InitializeComponent();
            flyoutPanel1.ButtonClick += FlyoutPanel1_ButtonClick;
            ReCalculatCostInSales.ItemClick += ReCalculatCostInSales_ItemClick;
        }
        MyFunaction myFunaction = new MyFunaction();
        private async void ReCalculatCostInSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            myFunaction.InitObjects();
            using (var db = new accountingEntities())
            {
                db.CalculatePrdQuan();
                Session.GetDataProductQunatities();
                DateTime FromDate = barFromDate?.EditValue!=null? Convert.ToDateTime(barFromDate?.EditValue):Session.CurrentYear.fyDateStart;
                DateTime ToDate = barToDate.EditValue!=null? Convert.ToDateTime(barToDate.EditValue):Session.CurrentYear.fyDateEnd; 
                Session.tblSupplySub = (from m in db.tblSupplyMains
                                        join s in db.tblSupplySubs on m.id equals s.supNo
                                        where (m.supStatus == 4 || m.supStatus == 8||m.supStatus==11||m.supStatus==12) 
                                        && m.supBrnId == Session.CurBranch.brnId &&s.supDate>= FromDate  && s.supDate <= ToDate
                                        select s).OrderBy(x=>x.supDate).ToList();
                foreach (var sub in Session.tblSupplySub)
                { 
                    int prId= sub.supPrdId??0, storId=sub.StoreID??0;
                    bool foundBuy = await Task.Run(() => db.tblSupplySubs.AsNoTracking().Any(x => (x.supStatus == 3 || x.supStatus == 7)&& x.supBrnId == Session.CurBranch.brnId && x.supPrdId == prId && x.StoreID ==storId));
                    if (!foundBuy/* || Session.ProductQunatities.Any(x => x.prdQuantity <= 0 && x.prdId == prId && x.prdStrId == storId)*/)
                    {
                        sub.supPrice = (Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == sub.supMsur)?.ppmPrice)?? sub.supPrice;
                    }
                    else
                    {
                        var tbPrdQuan = await Task.Run(() => myFunaction.GetDataProductTransaction(sub.supPrdId ?? 0, sub.StoreID ?? 0, sub.supDate));
                        await Task.Run(() =>
                        {
                            if (sub.supStatus == 11 || sub.supStatus == 12)
                            {
                                int supMain = db.tblSupplyMains.FirstOrDefault(x => x.id == sub.supNo)?.supNo ?? 0;
                                var ss = (from m in db.tblSupplyMains
                                          join s in db.tblSupplySubs on m.id equals s.supNo
                                          where (m.supStatus == 4 || m.supStatus == 8) && m.supNo == supMain
                                          && m.supDate < sub.supDate && m.supBrnId == Session.CurBranch.brnId
                                          && s.supPrdId == sub.supPrdId
                                          select s);
                                if (ss.Count() > 0)
                                {
                                    var temp = ss.FirstOrDefault();
                                    if (sub.Conversion == temp.Conversion)
                                        sub.supPrice = temp.supPrice;
                                    else if (sub.Conversion > temp.Conversion)
                                        sub.supPrice = temp.supPrice / temp.Conversion;
                                    else if (sub.Conversion < temp.Conversion)
                                        sub.supPrice = temp.supPrice * temp.Conversion;
                                }
                            }
                            else
                            {
                                double? p = myFunaction.GetCostOfNextProductTransaction(sub, tbPrdQuan).supPrice;
                                sub.supPrice = sub.supSalePrice > p ? sub.supPrice : p;
                            }
                        });
                    }
                }
                await Task.Run(() => db.SaveChanges());
            }
            flyDialog.WaitForm(this, 0);
            XtraMessageBox.Show("تمت العملية بنجاح");
        }

        private void InitData()
        {
            this.clsTbAccount = new ClsTblAccount();
            this.clsTbAsset = new ClsTblAsset();
            this.tbAssetList = new Collection<tblAsset>();

            LoopAccounts();
        }

        private void LoopAccounts()
        {
            foreach (var tbAccount in this.clsTbAccount.GetAccountListType2())
                if (CalculateAssetBalance(tbAccount.accNo, tbAccount.accCat)) this.tbAssetList.Add(new tblAsset()
                {
                    asAccNo = tbAccount.accNo,
                    asAccName = tbAccount.accName,
                    asDebit = this.total,
                });
        }

        private bool CalculateAssetBalance(long accNo, byte? accCat)
        {
            bool isFound = false; this.total = 0;
            foreach (var tbAsset in this.clsTbAsset.GetAssetList)
            {
                if (tbAsset.asAccNo == accNo)
                {
                    if (accCat < 3)
                    {
                        this.total += Convert.ToDouble(tbAsset.asDebit);
                        this.total -= Convert.ToDouble(tbAsset.asCredit);
                    }
                    else
                    {
                        this.total -= Convert.ToDouble(tbAsset.asDebit);
                        this.total += Convert.ToDouble(tbAsset.asCredit);
                    }
                    isFound = true;
                }
            }
            return isFound;
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }

        private void BbiBackupData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyoutPanel1.ShowPopup();
        }

        private void FlyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "backup":
                    PerformBackUp();
                    break;

                case "close":
                    ((FlyoutPanel)sender).HidePopup();
                    break;
            }
        }

        private void PerformBackUp()
        {
            flyDialog.WaitForm(this, 1);

            progressBarControl1.Position = 0;
            string connectString = ConfigurationManager.ConnectionStrings["accountingConnectionString"].ToString();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
            
            DateTime date = DateTime.Now;
            string dateString = $"{date.Day}-{date.Month}-{date.Year}";
            string folderName = @$"{ClsDrive.Path}:\B-Tech\DB";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                folderName = fbd.SelectedPath;


            string pathString = System.IO.Path.Combine(folderName, dateString);
            System.IO.Directory.CreateDirectory(pathString);

            try
            {
                Server dbServer = new Server(builder.DataSource);
                dbServer.ConnectionContext.LoginSecure = true;
                dbServer.ConnectionContext.Connect();
                Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = builder.InitialCatalog};
                dbBackup.Devices.AddDevice(pathString + $@"\{builder.InitialCatalog}.bak", DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.PercentComplete += DbBackup_PercentComplete;
                dbBackup.Complete += DbBackup_Complete;
                dbBackup.SqlBackupAsync(dbServer);

                dbServer.ConnectionContext.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            flyDialog.WaitForm(this, 0);
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = e.Error.Message;
                });
            }
        }

        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl1.Invoke((MethodInvoker)delegate
            {
                progressBarControl1.Position = e.Percent;
                progressBarControl1.Update();
            });

            lblPercent.Invoke((MethodInvoker)delegate
            {
                lblPercent.Text = $"{e.Percent}%";
            });
        }

        private void ChartControl1_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Control && e.KeyCode == Keys.U)
                {
                    flyDialog.WaitForm(this, 1);
                    using (formUpdateData form = new formUpdateData())
                    {
                        flyDialog.WaitForm(this, 0);
                        if (form.ShowDialog() == DialogResult.OK)
                            XtraMessageBox.Show("تم العملية بنجاح!");
                    }
                }
                if (e.Control && e.KeyCode == Keys.P)
                {
                    flyDialog.WaitForm(this, 1);
                    using (formDeleteProducts0 form = new formDeleteProducts0(new ClsTblProduct(), new ClsTblPrdPriceMeasurment()))
                    {
                        flyDialog.WaitForm(this, 0);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            InitData();
                            XtraMessageBox.Show("تم حذف الأصناف بنجاح!");
                        }
                    }
                }
        }
        XtraFormSyn FormSyn;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSyn = new XtraFormSyn();
            FormSyn.Show();
        }
    }
}
