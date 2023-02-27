using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class FormIncomeList : Form
    {

        ClsTblAccount clsTbAccount = new ClsTblAccount();
        ClsTblAsset clsTbAsset = new ClsTblAsset();
        ClsTblAssetFrgn clsTbAssetFrgn = new ClsTblAssetFrgn();
        IEnumerable<tblAccount> tbAccountList;
        ICollection<tblAsset> tbAssetList;
        List<tblAsset> tbAssetCalculateAmountsList;

        private double totalDebit;
        private double totalCredit;
        private bool isFound;
        private DateTime dtStart, dtEnd;

        accountingEntities db = new accountingEntities();
        public FormIncomeList()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (ReportForm frmr = new ReportForm(null))
            {
                Reports.ReportProfitsLosses rep = new Reports.ReportProfitsLosses();
                rep.xrtcName.Text = " من تاريخ"
                    + datefirt.Text
                    + " حتى تاريخ "
                    + datelast.Text
                    + " مركز التكلفة: ";
                //InitData(3);
                //InitData();

                // " مبيعات"6
                var sales = db.tblAssets.ToList().Where(x => x.asStatus == 6 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                rep.xrTableCell5.Text = Convert.ToString(sales.Sum(m => m.asDebit));
                // rep.xrTableCell27.Text = Convert.ToString(sales.Sum(s => s.asCredit));

                // "   مردود مبيعات"8
                var Salesreturn = db.tblAssets.ToList().Where(x => x.asStatus == 8 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                // rep.xrTableCell32.Text = Convert.ToString(Salesreturn.Sum(m => m.asDebit));
                rep.xrTableCell15.Text = Convert.ToString(Salesreturn.Sum(s => s.asCredit));
                // "   خصم مسموح به
                var descount = db.tblSupplyMains.ToList().Where(x => x.supStatus == 8 && x.supDate >= datefirt.DateTime.Date && x.supDate <= datelast.DateTime.Date);
                // rep.xrTableCell32.Text = Convert.ToString(Salesreturn.Sum(m => m.asDebit));
                rep.xrTableCell18.Text = Convert.ToString(descount.Sum(s => s.supDscntAmount));

                //صافى المبيعات
                rep.xrTableCell20.Text = Convert.ToString(Convert.ToDouble(rep.xrTableCell5.Text) - (Convert.ToDouble(rep.xrTableCell15.Text) + Convert.ToDouble(rep.xrTableCell18.Text)));

                // "   رصيد إفتتاحي مخازن   "10 - بضاعة أول المدة
                var store = db.tblAssets.ToList().Where(x => x.asStatus == 10 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                rep.xrTableCell24.Text = Convert.ToString(store.Sum(m => m.asDebit));
                // rep.xrTableCell39.Text = Convert.ToString(store.Sum(s => s.asCredit));

                // " مشتريات"5
                var purchases = db.tblAssets.ToList().Where(x => x.asStatus == 5 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                //  rep.xrTableCell23.Text = Convert.ToString(purchases.Sum(m => m.asDebit));
                rep.xrTableCell27.Text = Convert.ToString(purchases.Sum(s => s.asCredit));


                // " مردود مشتريات"7
                var Purchasereturns = db.tblAssets.ToList().Where(x => x.asStatus == 7 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                rep.xrTableCell29.Text = Convert.ToString(Purchasereturns.Sum(m => m.asDebit));
                // rep.xrTableCell30.Text = Convert.ToString(Purchasereturns.Sum(s => s.asCredit));

                //خصم مكتسب
                var descountb = db.tblSupplyMains.ToList().Where(x => x.supStatus == 7 && x.supDate >= datefirt.DateTime.Date && x.supDate <= datelast.DateTime.Date);
                // rep.xrTableCell32.Text = Convert.ToString(Salesreturn.Sum(m => m.asDebit));
                rep.xrTableCell32.Text = Convert.ToString(descountb.Sum(s => s.supDscntAmount));

                //صافى مشتريات
                rep.xrTableCell36.Text = Convert.ToString((Convert.ToDouble(rep.xrTableCell27.Text)  ) - (Convert.ToDouble(rep.xrTableCell29.Text) + Convert.ToDouble(rep.xrTableCell32.Text)));
               

                //بضاعة متاحة للبيع
                //       rep.xrTableCell39.Text = Convert.ToString((Convert.ToDouble(rep.xrTableCell27.Text) + Convert.ToDouble(rep.xrTableCell33.Text) + Convert.ToDouble(rep.xrTableCell36.Text) + Convert.ToDouble(rep.xrTableCell39.Text)) - (Convert.ToDouble(rep.xrTableCell29.Text)));

                //بضاعة اخر المدة
                rep.xrTableCell47.Text = rep.xrTableCell39.Text;

                //  // "   سند صرف الموظفين "9
                var emp = db.tblAssets.ToList().Where(x => x.asStatus == 9 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                // rep.xrTableCell35.Text = Convert.ToString(emp.Sum(m => m.asDebit));
                rep.xrTableCell61.Text = Convert.ToString(emp.Sum(s => s.asCredit));

                //اجمالى المصروفات
                rep.xrTableCell54.Text = Convert.ToString(Convert.ToDouble(rep.xrTableCell64.Text) + Convert.ToDouble(rep.xrTableCell61.Text));

                // صافى الخسارة
                rep.xrTableCell57.Text = Convert.ToString(Convert.ToDouble(rep.xrTableCell47.Text) - (Convert.ToDouble(rep.xrTableCell39.Text) + Convert.ToDouble(rep.xrTableCell54.Text)));


                // //"رصيد إفتتاحي"1
                // var balance = db.tblAssets.ToList().Where(x =>x.asStatus==1 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                // rep.xrTableCell5.Text = Convert.ToString(balance.Sum(m => m.asDebit));
                //// rep.xrTableCell12.Text = Convert.ToString(balance.Sum(s => s.asCredit));

                // //"قيد يومي"2
                // var entry = db.tblAssets.ToList().Where(x =>x.asStatus==2 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                // rep.xrTableCell14.Text = Convert.ToString(entry.Sum(m => m.asDebit));
                //// rep.xrTableCell15.Text = Convert.ToString(entry.Sum(s => s.asCredit));
                //"سند صرف"3
                //  var receipt = db.tblAssets.ToList().Where(x =>x.asStatus==3 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                ////  rep.xrTableCell17.Text = Convert.ToString(receipt.Sum(m => m.asDebit));
                //  rep.xrTableCell18.Text = Convert.ToString(receipt.Sum(s => s.asCredit));
                //  // "سند قبض"4
                //  var CatchReceipt = db.tblAssets.ToList().Where(x =>x.asStatus==4 && x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date);
                //  rep.xrTableCell20.Text = Convert.ToString(CatchReceipt.Sum(m => m.asDebit));
                ////  rep.xrTableCell21.Text = Convert.ToString(CatchReceipt.Sum(s => s.asCredit));



                //  rep.xrTableCell50.Text =Convert.ToString(
                //Convert.ToDouble(rep.xrTableCell5.Text) +
                //Convert.ToDouble(rep.xrTableCell14.Text) +
                //Convert.ToDouble(rep.xrTableCell17.Text) +
                //Convert.ToDouble(rep.xrTableCell20.Text) +
                //Convert.ToDouble(rep.xrTableCell23.Text) +
                //Convert.ToDouble(rep.xrTableCell26.Text) +
                //Convert.ToDouble(rep.xrTableCell29.Text) +
                //Convert.ToDouble(rep.xrTableCell32.Text) +
                //Convert.ToDouble(rep.xrTableCell35.Text) +
                //Convert.ToDouble(rep.xrTableCell38.Text));

                //rep.xrTableCell54.Text =Convert.ToString(
                //Convert.ToDouble(rep.xrTableCell12.Text) +
                //Convert.ToDouble(rep.xrTableCell15.Text) +
                //Convert.ToDouble(rep.xrTableCell18.Text) +
                //Convert.ToDouble(rep.xrTableCell21.Text) +
                //Convert.ToDouble(rep.xrTableCell24.Text) +
                //Convert.ToDouble(rep.xrTableCell27.Text) +
                //Convert.ToDouble(rep.xrTableCell30.Text) +
                //Convert.ToDouble(rep.xrTableCell33.Text) +
                //Convert.ToDouble(rep.xrTableCell36.Text) +
                //Convert.ToDouble(rep.xrTableCell39.Text));

                //  rep.xrTableCell56 .Text=Convert.ToString( Convert.ToDouble(rep.xrTableCell50.Text) - Convert.ToDouble(rep.xrTableCell54.Text));

                //rep.DataSource = this.tbAssetCalculateAmountsList;
                rep.RequestParameters = false;
                frmr.documentViewer1.DocumentSource = rep;



                frmr.ShowDialog();
            }
        }

        private void InitData(byte status)
        {
            this.tbAccountList = (status == 1) ? clsTbAccount.GetAccountListCategoery1nd2() : clsTbAccount.GetAccountListCategoery3nd4();
            this.tbAssetList = clsTbAsset.GetAssetList as ICollection<tblAsset>;

            var tbAssetFrgnList = clsTbAssetFrgn.GetAssetFrgnList;
            foreach (var tbAssetFrgn in tbAssetFrgnList)
            {
                tblAsset tbAsset = new tblAsset()
                {
                    asAccNo = tbAssetFrgn.asAccNo,
                    asAccName = tbAssetFrgn.asAccName,
                    asDebit = tbAssetFrgn.asDebit,
                    asCredit = tbAssetFrgn.asCredit,
                    asDate = tbAssetFrgn.asDate
                };
                this.tbAssetList?.Add(tbAsset);
            }
        }
        private void InitData()
        {
            this.tbAssetCalculateAmountsList = new List<tblAsset>();

            foreach (var tbAccount in this.tbAccountList)
            {
                this.totalDebit = 0; this.totalCredit = 0; this.isFound = false;

                foreach (var tbAsset in this.tbAssetList.Where(x => x.asDate >= datefirt.DateTime.Date && x.asDate <= datelast.DateTime.Date))
                {
                    if (tbAsset.asAccNo == tbAccount.accNo)
                    {
                        this.isFound = true;
                        this.totalDebit += Convert.ToDouble(tbAsset.asDebit);
                        this.totalCredit += Convert.ToDouble(tbAsset.asCredit);
                    }
                }
                if (this.isFound) AddAssetToList(tbAccount);
            }
            tblAssetBindingSource.DataSource = this.tbAssetCalculateAmountsList;
        }

        private void FormIncomeList_Load(object sender, EventArgs e)
        {
            datefirt.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            datelast.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void AddAssetToList(tblAccount tbAccount)
        {
            tblAsset tbAsset = new tblAsset()
            {
                asAccNo = tbAccount.accNo,
                asAccName = tbAccount.accName,
                asDebit = this.totalDebit,
                asCredit = this.totalCredit
            };
            this.tbAssetCalculateAmountsList.Add(tbAsset);
        }
    }
}
