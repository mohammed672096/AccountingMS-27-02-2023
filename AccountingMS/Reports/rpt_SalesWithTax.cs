using AccountingMS.ReportCustomModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace AccountingMS
{
    public partial class rpt_SalesWithTax : XtraReport
    {
        ClsTblCurrency clsCurrency = new ClsTblCurrency();
        ClsTblEntrySub clsTbEntrySub = new ClsTblEntrySub();
        ClsTblBranch ClsTblBranch = new ClsTblBranch();
        private DateTime dtStart, dtEnd;
        private short Branch;
        SupplyType type;
        SupplyType type2;
        public rpt_SalesWithTax(SupplyType _type, SupplyType _type2)
        {
            this.type = _type;
            this.type2 = _type2;
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData();
            InitText(_type);
            InitDefaultData();
            new ClsReportHeaderData(this);
        }

        private void InitDefaultData()
        {
            parameterBranch.MultiValue = false;
            if (Session.CurrentUser.id == 1)
            {
                var BranchList = ClsTblBranch.GetBranchList();
                tblBranch bra = new tblBranch { brnNo = 0, brnName = "كل الفروع" };
                BranchList.Insert(0, bra);
                bindingSource1.DataSource = BranchList;
            }
            else
            {
                parameterBranch.Visible = false;
                parameterBranch.Value = Session.CurBranch.brnId;
            }
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
        }

        private void InitText(SupplyType status)
        {
            if (status == SupplyType.SalesPhase)
            {
                xrLabel17.Visible = false;
                xrLabel3.Visible = true;
                xrTableCellMain.Text = (!MySetting.GetPrivateSetting.LangEng) ? "الكشف الضريبي لفواتير المبيعات" : "Sales Statement";
                xrTableSale.Visible = true;
                xrTableHForPur.Visible = false;
                xrTableDForPur.Visible = false;
                headerTable.Visible = true;
                xrTable2.Visible = true; 
            }

            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
        }

        private void ReportPurchases_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "parameterCurrency")
                {
                    LookUpEdit lookUpEdit = new LookUpEdit();
                    lookUpEdit.Properties.DataSource = clsCurrency.GetCurrencyList;
                    lookUpEdit.Properties.DisplayMember = "curName";
                    lookUpEdit.Properties.ValueMember = "id";
                    lookUpEdit.Properties.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("curName", 0, ""),
                    });
                    info.Editor = lookUpEdit;
                }
            }
        }

        private void ReportPurchases_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            this.Branch = Convert.ToInt16(parameterBranch.Value);
            this.dtStart = Convert.ToDateTime(parameterDateStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            InitData();
            SetBandVisibility();
        }

        private void InitData()
        {
            var tbCustomSupplyList = new List<SupplyMainWithTax>();

            var tbEntryList = this.clsTbEntrySub.GetEntrySubList().Where(x => x.entDate >= this.dtStart &&
                x.entDate <= this.dtEnd && x.entAccName != null && x.entAccName.StartsWith("ضريبة")).ToList();

            foreach (var x in tbEntryList)
            {
                if (this.type == SupplyType.SalesPhase && Convert.ToDouble(x.entCredit) > 0)
                {
                    var obj = InitObj(x, Convert.ToDouble(x.entCredit));
                    if(obj!=null)
                    tbCustomSupplyList.Add(obj);
                }
                if (this.type == SupplyType.PurchasePhase && Convert.ToDouble(x.entDebit) > 0)
                    tbCustomSupplyList.Add(InitObj(x, Convert.ToDouble(x.entDebit)));
            }

            tbCustomSupplyList.AddRange(ReportCustomModels.SupplyMainWithTax.GetSupplyList(this.dtStart, this.dtEnd, type, this.Branch));
            if (this.type2 == SupplyType.SalesPhaseRtrn)
            {
                tbCustomSupplyList.AddRange(ReportCustomModels.SupplyMainWithTax.GetSupplyList(this.dtStart, this.dtEnd, type2, this.Branch));
                xrTableSale.Visible = true;
                var ret = tbCustomSupplyList.Where(x => x.DocName == "مردود مبيعات").ToList();
                TotalReturn.Text = ret.Sum(x => x.Total).ToString("n");
                DisReturn.Text = ret.Sum(x => x.Discount).ToString("n");
                TaxReturn.Text = ret.Sum(x => x.Tax).ToString("n");
                NetReturn.Text = ret.Sum(x => x.Net).ToString("n");

                var Sale = tbCustomSupplyList.Where(x => x.DocName == "مبيعات").ToList();
                TotalSale.Text = Sale.Sum(x => x.Total).ToString("n");
                DisSale.Text = Sale.Sum(x => x.Discount).ToString("n");
                TaxSale.Text = Sale.Sum(x => x.Tax).ToString("n");
                NetSale.Text = Sale.Sum(x => x.Net).ToString("n");

                xrTableCellTotal.Text = (Sale.Sum(x => x.Total) - ret.Sum(x => x.Total)).ToString("n");
                xrTableCellTotalDiscount.Text = (Sale.Sum(x => x.Discount) - ret.Sum(x => x.Discount)).ToString("n");
                xrTableCellTotalTax.Text = (Sale.Sum(x => x.Tax) - ret.Sum(x => x.Tax)).ToString("n");
                xrTableCellTotalFinal.Text = (Sale.Sum(x => x.Net) - ret.Sum(x => x.Net)).ToString("n");
            }
            if (this.type2 == SupplyType.PurchasePhaseRtrn)
            {
                tbCustomSupplyList.AddRange(ReportCustomModels.SupplyMainWithTax.GetSupplyList(this.dtStart, this.dtEnd, type2, this.Branch));
                var ret = tbCustomSupplyList.Where(x => x.DocName == "مردود مشتريات").ToList();
                txtNameTotalSales.Text = "الإجمالي للمشتريات";
                txtNameTotalSalesReturn.Text = "الإجمالي لمردود المشتريات";
                TotalReturn.Text = ret.Sum(x => x.Total).ToString("n");
                DisReturn.Text = ret.Sum(x => x.Discount).ToString("n");
                TaxReturn.Text = ret.Sum(x => x.Tax).ToString("n");
                NetReturn.Text = ret.Sum(x => x.Net).ToString("n");

                var Sale = tbCustomSupplyList.Where(x => x.DocName == "مشتريات" | (x.DocName == "قيد يومي")).ToList();
                TotalSale.Text = Sale.Sum(x => x.Total).ToString("n");
                DisSale.Text = Sale.Sum(x => x.Discount).ToString("n");
                TaxSale.Text = Sale.Sum(x => x.Tax).ToString("n");
                NetSale.Text = Sale.Sum(x => x.Net).ToString("n");

                xrTableCellTotal.Text = (Sale.Sum(x => x.Total) - ret.Sum(x => x.Total)).ToString("n");
                xrTableCellTotalDiscount.Text = (Sale.Sum(x => x.Discount) - ret.Sum(x => x.Discount)).ToString("n");
                xrTableCellTotalTax.Text = (Sale.Sum(x => x.Tax) - ret.Sum(x => x.Tax)).ToString("n");
                xrTableCellTotalFinal.Text = (Sale.Sum(x => x.Net) - ret.Sum(x => x.Net)).ToString("n");
            }

            tblSupplyMainBindingSource.DataSource = tbCustomSupplyList.OrderBy(x => x.Number).ToList();
        }
        tblEntrySub EntryList;
        private SupplyMainWithTax InitObj(tblEntrySub x, double taxAmount)
        {
            double price = Math.Round(taxAmount /  ((double)MySetting.GetPrivateSetting.taxDefault/100), 2, MidpointRounding.AwayFromZero);
            if (this.type == SupplyType.SalesPhase && Convert.ToDouble(x.entCredit) > 0)
            {
                EntryList = this.clsTbEntrySub.GetEntrySubList().Where(y => y.entDate >= this.dtStart &&
                                 y.entDate <= this.dtEnd && y.entAccName != null && y.entNo == x.entNo && ((y.entCredit as double?) ?? 0) > 0 && y.id != x.id && y.entStatus == x.entStatus).FirstOrDefault();
                var gg= this.clsTbEntrySub.GetEntrySubList().Where(y => y.entDate >= this.dtStart &&
                                  y.entDate <= this.dtEnd && y.entAccName != null && y.entNo == x.entNo && ((y.entCredit as double?) ?? 0) > 0 && y.id != x.id && y.entStatus == x.entStatus).FirstOrDefault();
            }

            if (this.type == SupplyType.PurchasePhase && Convert.ToDouble(x.entDebit) > 0)
            {
                EntryList = this.clsTbEntrySub.GetEntrySubList().Where(y => y.entDate >= this.dtStart &&
                                 y.entDate <= this.dtEnd && y.entAccName != null && y.entNo == x.entNo && ((y.entDebit as double?) ?? 0) > 0 && y.id != x.id && y.entStatus == x.entStatus).FirstOrDefault();
            }
            if (EntryList == null) return null;
            int.TryParse((EntryList != null ? EntryList.invoNum : "0"), out int invNo);
            return new SupplyMainWithTax()
            {
                Number = EntryList != null ? EntryList.id : 0,
                Code = EntryList != null ? EntryList.entNo : 0,
                InvoiceDate = EntryList != null ? EntryList.entInvoDate : null,
                RefNumber = invNo.ToString(),
                TaxNumber = EntryList != null ? EntryList.entTaxNumber : "",
                PartName = EntryList != null ? EntryList.entAccName : "",
                DocName = EntryList != null ? EntryList.entStatus switch
                {
                    (byte)EntryType.EntryPhased => "قيد يومي",
                    (byte)EntryType.EntryVoucherPhased => "سند قبض",
                    (byte)EntryType.EntryReceiptPhased => "سند صرف",
                    (byte)EntryType.DailyEntry => "قيد يومي",
                    (byte)EntryType.EntryVoucher => "سند قبض",
                    (byte)EntryType.EntryReceipt => "سند صرف",
                    _ => "",
                } : "",
                Total = price,
                Tax = taxAmount,
                Discount = 0,
                BranchId= EntryList != null ? EntryList.entBrnId.Value : (short)0,
            };
        }
        private void SetBandVisibility()
        {
            bool visbility = (tblSupplyMainBindingSource.Count >= 1) ? true : false;

            GroupHeader1.Visible = visbility;
            Detail.Visible = visbility;
            GroupFooter1.Visible = visbility;
        }
        
        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void xrTableCell26_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.ClsTblBranch.GetBranchName(Convert.ToByte(cell.Value));
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
