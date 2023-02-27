using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace AccountingMS
{
    public partial class UCentryAll : XtraUserControl
    {
        accountingEntities db = new accountingEntities();
        BindingList<tblEntrySub> tbEntSubList = new BindingList<tblEntrySub>();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        private dynamic tbEntSub;
        private dynamic tbSupMain;
        private int balanceOld = 0;
        private int balanceNew = 0;

        public UCentryAll()
        {
            InitializeComponent();
            new ClsUserControlValidation(this, UserControls.EntryAll);

            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entStatus")
                e.DisplayText = ClsEntryStatus.GetString(Convert.ToByte(e.Value));
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void UCentryAll_Load(object sender, EventArgs e)
        {
            InitData();
            BalanceOld();
            BalanceNew();
        }

        private void InitData()
        {
            bindingSource1.Clear();

            this.tbEntSub = (from a in db.tblEntrySubs
                             where a.entBrnId == Session.CurBranch.brnId && a.entStatus != 1 || a.entStatus != 4
                             select a).ToList();
            this.tbSupMain = (from a in db.tblSupplyMains
                              where a.supBrnId == Session.CurBranch.brnId && a.supIsCash == 1
                              select a).ToList();
            string entSubDesc = null;

            foreach (var entrylist in this.tbEntSub)
            {
                if (entrylist.entView == 1)
                {
                    if (entrylist.entIsMain == 1)
                    {
                        entSubDesc = entrylist.entDesc;
                    }
                    else if (entrylist.entIsMain == 2)
                    {
                        if (entrylist.entStatus == 2 || entrylist.entStatus == 5)
                        {
                            //XtraMessageBox.Show(entSubDesc);
                            entrylist.entDesc = entSubDesc;
                            entrylist.entCredit = entrylist.entDebit;
                        }
                        else if (entrylist.entStatus == 3 || entrylist.entStatus == 6)
                        {
                            entrylist.entDesc = entSubDesc;
                            entrylist.entDebit = entrylist.entCredit;
                        }
                        this.tbEntSubList.Add(entrylist);
                    }
                    else
                        continue;
                }
                else if (entrylist.entView == 2)
                {
                    if (entrylist.entIsMain == 1)
                        this.tbEntSubList.Add(entrylist);
                    else
                        continue;
                }
            }

            foreach (var supMain in this.tbSupMain)
            {
                tblEntrySub tEntSub = new tblEntrySub();
                tEntSub.entNo = supMain.supNo;
                tEntSub.entAccName = supMain.supAccName;
                tEntSub.entDesc = supMain.supDesc;
                tEntSub.entStatus = supMain.supStatus;
                tEntSub.entDate = supMain.supDate;
                if (supMain.supStatus == 3 || supMain.supStatus == 7 || supMain.supStatus == 11 || supMain.supStatus == 12)
                    tEntSub.entCredit = supMain.supTotal;
                else if (supMain.supStatus == 4 || supMain.supStatus == 8 || supMain.supStatus == 9 || supMain.supStatus == 10)
                    tEntSub.entDebit = supMain.supTotal;

                this.tbEntSubList.Add(tEntSub);
            }
            bindingSource1.DataSource = this.tbEntSubList.OrderBy(x => x.entDate);
            bsiRecordsCount.Caption = "RECORDS : " + bindingSource1.Count;
        }

        private void BalanceOld()
        {
            //var tbBalance = (from a in db.tblBalances
            //                 orderby a.id descending
            //                 select a.balance).FirstOrDefault();
            //this.balanceOld = Convert.ToInt32(tbBalance);

            labelBalanceOld.Caption = "الرصيد المتوفر: " + this.balanceOld;
        }

        private void BalanceNew()
        {
            foreach (var tEntSub in this.tbEntSub)
            {
                if (tEntSub.entEqfal == 2)
                {
                    if (tEntSub.entStatus == 2 || tEntSub.entStatus == 5)
                    {
                        tEntSub.entEqfal = 3;
                        this.balanceNew -= tEntSub.entCredit;
                    }
                    else if (tEntSub.entStatus == 3 || tEntSub.entStatus == 6)
                    {
                        tEntSub.entEqfal = 3;
                        this.balanceNew += tEntSub.entDebit;
                    }
                }
            }

            foreach (var tSupMain in this.tbSupMain)
            {
                if (tSupMain.supEqfal == 2)
                {
                    if (tSupMain.supStatus == 3 || tSupMain.supStatus == 7 || tSupMain.supStatus == 11 || tSupMain.supStatus == 12)
                    {
                        this.balanceNew -= tSupMain.supTotal;
                        tSupMain.supEqfal = 3;
                    }
                    else if (tSupMain.supStatus == 4 || tSupMain.supStatus == 8 || tSupMain.supStatus == 9 || tSupMain.supStatus == 10)
                    {
                        this.balanceNew += tSupMain.supTotal;
                        tSupMain.supEqfal = 3;
                    }
                }
            }

            labelBalanceNew.Caption = "الرصيد الحالي: " + this.balanceNew;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.balanceNew == 0)
            {
                flyDialog.ShowDialogUCCustomdMsg(this, "لا يتوفر لديك رصيد حالي لكي يتم الإقفال!");
                return;
            }
            flyDialog.WaitForm(this, 1);

            //tblBalance tbBalance = new tblBalance();
            //DateTime date = DateTime.Now;

            //this.balanceOld += this.balanceNew;
            //tbBalance.balance = this.balanceOld;
            //tbBalance.balDate = date.Date;
            //db.tblBalances.Add(tbBalance);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

            this.balanceNew = 0;
            labelBalanceOld.Caption = "الرصيد الحالي: " + this.balanceOld;
            labelBalanceNew.Caption = "الرصيد المتوفر: 0";
            flyDialog.ShowDialogUCCustomdMsg(this, "تم إقفال الرصيد بنجاح");
            flyDialog.WaitForm(this, 0);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindingList<tblEntrySub> tbEntSubListRprt = new BindingList<tblEntrySub>();
            DateTime dt = Convert.ToDateTime(gridView.GetRowCellValue(0, colentDate)).Date;
            int debit = 0, credit = 0, total = 0;
            flyDialog.WaitForm(this, 1);

            foreach (var tEntSub in this.tbEntSubList.OrderBy(x => x.entDate))
            {
                if (tEntSub.entDate < dt)
                {
                    debit += Convert.ToInt32(tEntSub.entDebit);
                    credit += Convert.ToInt32(tEntSub.entCredit);
                }
            }
            total = debit - credit;

            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                tblEntrySub tbEntSub = new tblEntrySub();

                tbEntSub.entAccNo = Convert.ToInt64(gridView.GetRowCellValue(i, colentAccNo));
                tbEntSub.entAccName = Convert.ToString(gridView.GetRowCellValue(i, colentAccName));
                tbEntSub.entNo = Convert.ToInt32(gridView.GetRowCellValue(i, colentNo1));
                tbEntSub.entDesc = Convert.ToString(gridView.GetRowCellValue(i, colentDesc1));
                tbEntSub.entDebit = Convert.ToInt32(gridView.GetRowCellValue(i, colentDebit));
                tbEntSub.entCredit = Convert.ToInt32(gridView.GetRowCellValue(i, colentCredit));
                tbEntSub.entDate = Convert.ToDateTime(gridView.GetRowCellValue(i, colentDate));
                tbEntSub.entCusNo = total;
                tbEntSub.entCusName = this.balanceNew.ToString();
                tbEntSubListRprt.Add(tbEntSub);
            }

            var frm = new ReportForm(ReportType.DailyEntry, tbEntSubList: tbEntSubListRprt);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }
    }
}
