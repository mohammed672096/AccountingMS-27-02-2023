using System;
using System.Collections;
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
    public partial class ReportMostActiveSuppliers : Form
    {
        public tblSupplier tbSupplier;
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsSupplierBalanceData clsSplBalanceData;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;
        List<sumreport> reportvalue = new List<sumreport>();


        private long splAccNo;
        public ReportMostActiveSuppliers()
        {
            InitializeComponent();

            getdata();

        }

        public class sumreport
        {
            public int CuM { get; set; }
            public string CuName { get; set; }
            public double CuQ { get; set; }
            public double CuPr { get; set; }
            public int CuNo { get; set; }
        }


        private void ReportMostActiveSuppliers_Load(object sender, EventArgs e)
        {
            fromdateEdit.DateTime = DateTime.Now;
            todateEdit.DateTime = DateTime.Now;
            daydateEdit.DateTime = DateTime.Now;
            userNametextEdit.Text = Session.CurrentUser.userName;
        }

        void getdata()
        {
            using (accountingEntities db = new accountingEntities())
            {
                tblCurrencyBindingSource.DataSource = db.tblCurrencies.ToList();
            }

        }
        void filldatgrid()
        {
            if (currencytextEdit.EditValue == null)
            {
                currencytextEdit.ErrorText = (MySetting.GetPrivateSetting.LangEng ? "Sorry, choose the currency first!" : "عذراً اختر العملة أولاً!");
                return;
            }
            reportvalue.Clear();
            currencytextEdit.ErrorText = null;
            using (accountingEntities db = new accountingEntities())
            {
                DateTime datestar = Convert.ToDateTime(fromdateEdit.EditValue);
                DateTime dateend = Convert.ToDateTime(todateEdit.EditValue);

                var custm = db.tblCustomers.ToList();
                int countM = 0;
                //اجمالى السعر
                foreach (var cu in custm)
                {
                    var submain = db.tblSupplyMains.ToList().Where(a => a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend
                                                            && (a.supStatus == 8 || a.supStatus == 4)
                                                            && a.supCurrency == Convert.ToByte(currencytextEdit.EditValue)
                                                            && a.supCustSplId == cu.id)

                                                        .GroupBy(i => new { i.supCustSplId })
                                                        .Select(s => new
                                                        {
                                                            s.Key.supCustSplId,
                                                            net = Math.Round(Convert.ToDouble(s.Sum(g => (g.net))), 2),
                                                            supno = s.Sum(g => g.supNo),
                                                        });

                    double nett = 0;
                    int supNoo = 0;
                    int Quan = 0;
                    var subn = db.tblSupplyMains.ToList().Where(a => a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend
                                                            && (a.supStatus == 8 || a.supStatus == 4)
                                                            && a.supCurrency == Convert.ToByte(currencytextEdit.EditValue)
                                                            && a.supCustSplId == cu.id);
                    supNoo = subn.Count();
                    foreach (var qn in subn)
                    {
                        var SupplySubs = db.tblSupplySubs.ToList().Where(a => a.supNo == qn.supNo).Sum(d=>d.supQuanMain);
                        Quan +=(int) SupplySubs.Value;
                    }
                    foreach (var item in submain)
                    {
                        //countM += 1;
                        nett = item.net;
                        //supNoo = item.supno;

                    }

                    //var SupplySubs = db.tblSupplySubs.ToList().Where(a => a.supDate.Date >= datestar.Date && a.supDate.Date <= dateend.Date
                    //                                  && (a.supStatus == 8 || a.supStatus == 4)
                    //                                  && a.supCurrency == Convert.ToByte(currencytextEdit.EditValue)).Sum(g => g.supQuanMain);
                    reportvalue.Add(new sumreport()
                    {
                        CuM = countM += 1,
                        CuName = cu.custName,
                        CuQ = Quan,
                        CuPr = nett,
                        CuNo = supNoo
                    });
                }

            }
            gridControl1.DataSource = reportvalue;
            gridView1.RefreshData();
        }

        private void PrintButton1_Click(object sender, EventArgs e)
        {
            filldatgrid();
            using (ReportForm frmr = new ReportForm(null))
            {
                Reports.XtraReportMostActiveSuppliers rep = new Reports.XtraReportMostActiveSuppliers();
                rep.xrTitelName.Text = "تقرير الموردين الأكثر حركة حسب القيمة "

                    + " من تاريخ "
                   + fromdateEdit.Text
                   + " الى تاريخ "
                   + todateEdit.Text;


                rep.DataSource = gridView1.DataSource;
                rep.RequestParameters = false;
                frmr.documentViewer1.DocumentSource = rep;


                frmr.ShowDialog();
            }
        }



        private void SetPeriodBalance()
        {
            double total = this.clsSplBalanceData.CreditPeriod - this.clsSplBalanceData.DebitPeriod;

            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = this.clsSplBalanceData.DebitPeriod,
                credit = this.clsSplBalanceData.CreditPeriod,
                currentBalance = total,
                dtStart = fromdateEdit.DateTime.Date,
                dtEnd = todateEdit.DateTime.Date,
            };

            //clsBalanceColumnsDataBindingSource2.Add(balanceColumnsData);
            //SetCurrentBalance2HeaderColor(total);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            filldatgrid();
         
           
        }

        private void currencytextEdit_EditValueChanged(object sender, EventArgs e)
        {
            filldatgrid();
        }
    }
}
