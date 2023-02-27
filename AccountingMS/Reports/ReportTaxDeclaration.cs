using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportTaxDeclaration : DevExpress.XtraReports.UI.XtraReport
    {
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblEntrySub> tblEntrySubList;
        List<tblTaxAccount> tbTaxAccountList = new List<tblTaxAccount>();
        private double totalPurchase = 0, totalPurchaseRtrn = 0, totalPurchaseTax = 0, totalSale = 0, totalSaleRtrn = 0, totalSaleTax = 0;

        public ReportTaxDeclaration()
        {
            InitializeComponent();
            InitData();
        }

        public async static Task<ReportTaxDeclaration> CreateAsync()
        {
            var rprt = new ReportTaxDeclaration();

            await rprt.InitObjectsAsync();

            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            await Task.WhenAll(taskList);
        }

        private void InitData()
        {
            this.tbSupplyMainList = new ClsTblSupplyMain().GetSupplyMainList;
            this.tblEntrySubList = new ClsTblEntrySub().GetEntrySubList();
            using (accountingEntities db = new accountingEntities())
            {
                tbTaxAccountList = db.tblTaxAccounts.ToList();
            }
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
        }
        private void CalculateTax()
        {
            totalPurchase = 0;
            totalPurchaseRtrn = 0;
            totalPurchaseTax = 0;
            totalSale = 0;
            totalSaleRtrn = 0;
            totalSaleTax = 0;
            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                if (Convert.ToDateTime(tbSupplyMain.supDate).Date > dateEnd) break;
                if (Convert.ToByte(tbSupplyMain.supTaxPercent) < 1) continue;

                if (tbSupplyMain.supDate >= dateStart)
                {
                    if ((tbSupplyMain.supStatus == 3 || tbSupplyMain.supStatus == 7) && tbSupplyMain.supTaxPrice > 0)
                    {
                        totalPurchase += (tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        totalPurchaseTax += (double)tbSupplyMain.supTaxPrice;
                    }
                    else if ((tbSupplyMain.supStatus == 9 || tbSupplyMain.supStatus == 10) && tbSupplyMain.supTaxPrice > 0)
                    {
                        totalPurchaseRtrn += (tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        totalPurchaseTax -= (double)tbSupplyMain.supTaxPrice;
                    }
                    else if ((tbSupplyMain.supStatus == 4 || tbSupplyMain.supStatus == 8) && tbSupplyMain.supTaxPrice > 0)
                    {
                        totalSale += (tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        totalSaleTax += (double)tbSupplyMain.supTaxPrice;
                    }
                    else if ((tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12) && tbSupplyMain.supTaxPrice > 0)
                    {
                        totalSaleRtrn += (tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        totalSaleTax -= (double)tbSupplyMain.supTaxPrice;
                    }
                }
            }

            foreach (var tblEntrySub in this.tblEntrySubList)
            {
                if (Convert.ToDateTime(tblEntrySub.entDate).Date > dateEnd) break;
                if (tbTaxAccountList == null) return;
                if (tblEntrySub.entDate >= dateStart)
                {
                    if ((tblEntrySub.entStatus == 1 || tblEntrySub.entStatus == 4) && ((tblEntrySub.entDebit as double?) ?? 0) > 0)
                    {
                        if (tbTaxAccountList.Where(c => c.taxAccNo == tblEntrySub.entAccNo).Count() > 0)
                        {
                            totalPurchase += (this.tblEntrySubList.Where(x => x.entNo == tblEntrySub.entNo & x.entStatus == tblEntrySub.entStatus & x.entDate == tblEntrySub.entDate).Sum(s => (s.entDebit as double?) ?? 0) - (double)tblEntrySub.entDebit);
                            totalPurchaseTax += (double)tblEntrySub.entDebit;
                        }
                    }
                }
            }
        }
        DateTime dateStart, dateEnd;
        private void ReportTaxDeclaration_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            dateStart = Convert.ToDateTime(parameterDateStart.Value).Date;
                dateEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            CalculateTax();
            SetData();
            ResetData();
        }
        private void SetData()
        {
            xrTableCellSale.Text = ($"{this.totalSale:n2}");
            xrTableCellSaleRtrn.Text = ($"{this.totalSaleRtrn:n2}");
            xrTableCellSaleTax.Text = ($"{this.totalSaleTax:n2}");
            xrTableCellSaleTotal.Text = ($"{this.totalSale:n2}");
            xrTableCellSaleRtrnTotal.Text = ($"{this.totalSaleRtrn:n2}");
            xrTableCellSaleTaxTotal.Text = ($"{this.totalSaleTax:n2}");

            xrTableCellPurchase.Text = ($"{this.totalPurchase:n2}");
            xrTableCellPurchaseRtrn.Text = ($"{this.totalPurchaseRtrn:n2}");
            xrTableCellPurchaseTax.Text = ($"{this.totalPurchaseTax:n2}");
            xrTableCellPurchaseTotal.Text = ($"{this.totalPurchase:n2}");
            xrTableCellPurchaseRtrnTotal.Text = ($"{this.totalPurchaseRtrn:n2}");
            xrTableCellPurchaseTaxTotal.Text = ($"{this.totalPurchaseTax:n2}");

            xrTableCellCurrentTax.Text = ($"{this.totalSaleTax - this.totalPurchaseTax:n2}");
            xrTableCellFinalTax.Text = ($"{this.totalSaleTax - this.totalPurchaseTax:n2}");
            xrTableCellDate.Text = ($"{DateTime.Now:yyyy/MM/dd}");
        }

        private void ResetData()
        {
            this.totalPurchase = 0;
            this.totalPurchaseRtrn = 0;
            this.totalPurchaseTax = 0;
            this.totalSale = 0;
            this.totalSaleRtrn = 0;
            this.totalSaleTax = 0;
        }
    }
}
