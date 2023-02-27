using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportSuppliers : XtraReport
    {
        accountingEntities db = new accountingEntities();
        List<ClsRprtSupplierFields> supplierList;
        List<tblSupplier> tbSupplierList;
        List<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblEntrySub> tbEntrySubList;

        private double totalDebit;
        private double totalCredt;

        public ReportSuppliers()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            IntiData();
            InitDefaultData();
            new ClsReportHeaderData(this);
        }

        private void InitDefaultData()
        {
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
        }

        private void IntiData()
        {
            this.tbSupplierList = new ClsTblSupplier().GetSuppliersList();
            this.tbSupplyMainList = new ClsTblSupplyMain().GetSupplyMainSuppliersList();
            this.tbEntrySubList = new ClsTblEntrySub().GetEntrySubList();
            xrtcDate.Text += string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}");
        }

        private void ReportSuppliers_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            DateTime dtStart = Convert.ToDateTime(parameterDateStart.Value).Date, dtEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            CalculateBalance(dtStart, dtEnd);
        }

        private void CalculateBalance(DateTime dtStart, DateTime dtEnd)
        {
            this.supplierList = new List<ClsRprtSupplierFields>();

            foreach (var tbSupplier in this.tbSupplierList)
            {
                this.totalDebit = 0; this.totalCredt = 0;
                CalculateSupplyMain(tbSupplier.splAccNo, dtStart, dtEnd);
                CalculateEntrySub(tbSupplier.splAccNo, dtStart, dtEnd);
                AddSupplierToList(tbSupplier);
            }

            RprtSupplierFieldsBindingSource.DataSource = this.supplierList;
        }

        private void CalculateSupplyMain(long splAccNo, DateTime dtStart, DateTime dtEnd)
        {
            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                if (tbSupplyMain.supDate > dtEnd) break;
                if (tbSupplyMain.supAccNo == splAccNo && tbSupplyMain.supDate >= dtStart)
                {
                    if (tbSupplyMain.supStatus == 3 || tbSupplyMain.supStatus == 7)
                        this.totalCredt += (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice));
                    else if (tbSupplyMain.supStatus == 9 || tbSupplyMain.supStatus == 10)
                        this.totalDebit += (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice));
                }
            }
        }

        private void CalculateEntrySub(long splAccNo, DateTime dtStart, DateTime dtEnd)
        {
            foreach (var tbEntSub in this.tbEntrySubList)
            {
                if (tbEntSub.entDate > dtEnd) break;
                if (tbEntSub.entAccNo == splAccNo && tbEntSub.entDate >= dtStart)
                {
                    if (tbEntSub.entStatus == 2 || tbEntSub.entStatus == 5)
                        this.totalDebit += (Convert.ToDouble(tbEntSub.entDebit) + Convert.ToDouble(tbEntSub.entTaxPrice));
                    else if (tbEntSub.entStatus == 3 || tbEntSub.entStatus == 6)
                        this.totalCredt += (Convert.ToDouble(tbEntSub.entCredit) + Convert.ToDouble(tbEntSub.entTaxPrice));
                }
            }
        }

        private void AddSupplierToList(tblSupplier tbSupplier)
        {
            ClsRprtSupplierFields supplier = new ClsRprtSupplierFields()
            {
                splName = tbSupplier.splName,
                totalDebit = this.totalDebit,
                totalCredit = this.totalCredt,
                currentBalance = this.totalDebit - this.totalCredt
            };
            this.supplierList.Add(supplier);
        }

        private void xrtcCurrentBalance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double currentBalance = Convert.ToDouble(((XRTableCell)sender).Value);

            if (currentBalance == 0)
            {
                xrtcState.Text = null;
                SetCurrentBalanceColumnColor(Color.Black, xrtcState, sender as XRTableCell);
            }
            else if (currentBalance > 0)
            {
                xrtcState.Text = (!MySetting.GetPrivateSetting.LangEng) ? "مدين" : "Debit";
                SetCurrentBalanceColumnColor(Color.Green, xrtcState, sender as XRTableCell);
            }
            else if (currentBalance < 0)
            {
                xrtcState.Text = (!MySetting.GetPrivateSetting.LangEng) ? "دائن" : "Credit";
                ((XRTableCell)sender).Text = string.Format($"{-(currentBalance):0,0.00}");
                SetCurrentBalanceColumnColor(Color.Red, xrtcState, sender as XRTableCell);
            }
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double total = Convert.ToDouble(xrtcTotalDebit.Summary.GetResult()) - Convert.ToDouble(xrtcTotalCredit.Summary.GetResult());


            if (total > 0)
            {
                xrtcTotalState.Text = (!MySetting.GetPrivateSetting.LangEng) ? "مدين" : "Debit";
                SetCurrentBalanceColumnColor(Color.Green, xrtcTotal, xrtcTotalState);
            }
            else if (total < 0)
            {
                xrtcTotalState.Text = (!MySetting.GetPrivateSetting.LangEng) ? "دائن" : "Credit";
                SetCurrentBalanceColumnColor(Color.Red, xrtcTotal, xrtcTotalState);
                total = -(total);
            }

            xrtcTotal.Text = string.Format($"{total:0,0.00}");
        }

        private void SetCurrentBalanceColumnColor(Color color, XRTableCell cell1, XRTableCell cell2)
        {
            cell1.ForeColor = color;
            cell2.ForeColor = color;
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
