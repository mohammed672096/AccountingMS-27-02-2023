using DevExpress.Utils.Extensions;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ReportCustomerSupplierBalanceData : XtraReport
    {
        ReportCustomerData rprtCustomerData;
        ReportSupplierData rprtSupplierData;
        ReportSupplySub rprtSupplySub;
        ClsCustomerBalanceData clsCustBalanceData;
        ClsSupplierBalanceData clsSplBalanceData;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblCustomer clsTbCustomer;
        ClsTblSupplier clsTbSupplier;
        GroupField groupFiled;

        private readonly byte status;
        private long accNo;
        private int accId;
        private bool showInvoice, showEntry, isCash, showCustDetail, showInvoiceDetail, showProfit, combineSupNdEnt;
        private DateTime dtStart, dtEnd;
        private double totalPrice, totalTax, supTotal;
        private double totalProfit;

        public ReportCustomerSupplierBalanceData(byte status, ClsTblCustomer clsTbCustomer, ClsTblSupplier clsTbSupplier)
        {
            this.status = status;
            InitializeComponent();
            InitObjects(clsTbCustomer, clsTbSupplier);
            InitSubReport();
            InitSubReportSupplySub();
            InitGroupField();

            this.BeforePrint += ReportCustomerSupplierInvoices_BeforePrint;
        }

        private void InitObjects(ClsTblCustomer clsTbCustomer, ClsTblSupplier clsTbSupplier)
        {
            this.clsTbCustomer = clsTbCustomer;
            this.clsTbSupplier = clsTbSupplier;
            this.clsTbSupplySub = new ClsTblSupplySub(true);
        }

        private void InitSubReportSupplySub()
        {
            this.rprtSupplySub = new ReportSupplySub(this.clsTbSupplySub, this.status);
            xrSubreportSupplySub.ReportSource = this.rprtSupplySub;
            xrSubreportSupplySub.ParameterBindings.Add(new ParameterBinding("parameterShowProfit", parameterShowProfit));
            xrSubreportSupplySub.ParameterBindings.Add(new ParameterBinding("parameterSupId", tblSupplyMainBindingSource, "id"));
            xrSubreportSupplySub.ParameterBindings.Add(new ParameterBinding("parameterSupStatus", tblSupplyMainBindingSource, "supStatus"));
        }

        private void InitGroupField()
        {
            this.groupFiled = new GroupField("id", XRColumnSortOrder.None);
        }

        private void InitSubReport()
        {
            switch (this.status)
            {
                case 1:
                    this.rprtCustomerData = new ReportCustomerData();
                    this.clsCustBalanceData = new ClsCustomerBalanceData();
                    xrSubreportCustSuplData.ReportSource = this.rprtCustomerData;
                    break;
                case 2:
                    this.rprtSupplierData = new ReportSupplierData();
                    this.clsSplBalanceData = new ClsSupplierBalanceData();
                    xrSubreportCustSuplData.ReportSource = this.rprtSupplierData;
                    break;
            }
        }

        private void SetPropertiesData()
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);
            this.accId = Convert.ToInt32(parameterAccId.Value);
            this.accNo = Convert.ToInt32(parameterAccNo.Value);
            this.isCash = Convert.ToBoolean(parameterCash.Value);
            this.showInvoice = Convert.ToBoolean(parameterShowInvoice.Value);
            this.showCustDetail = Convert.ToBoolean(parameterShowCustDetail.Value);
            this.showInvoiceDetail = Convert.ToBoolean(parameterInvoiceDetail.Value);
            this.showProfit = Convert.ToBoolean(parameterShowProfit.Value);
            this.showEntry = Convert.ToBoolean(parameterShowEntry.Value);
            this.combineSupNdEnt = Convert.ToBoolean(parameterCombineSupNdEnt.Value);
        }

        private void ReportCustomerSupplierInvoices_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetPropertiesData();
            InitBalancenData();
            InitSupplyBand();
            InitEntryBand();
            InitSupplyNdEntBand();
            SetFooterColumns();
        }

        private void ResetTotalValues()
        {
            this.totalTax = 0;
            this.totalPrice = 0;
            this.totalProfit = 0;
        }

        private void InitBalancenData()
        {
            InitSubReportCustSupData();
            SetBalanceData();
            SetPropertiesBalance();
        }

        private void InitSubReportCustSupData()
        {
            if (this.status == 1) InitCustomerRprt();
            else InitSupplierRprt();
        }

        private void SetBalanceData()
        {
            if (this.status == 1) InitCustomerBalance();
            else InitSupplierBalance();
        }

        private void SetPropertiesBalance()
        {
            GroupHeaderBalance.Visible = this.showCustDetail;
            xrTableBalanceH.Visible = this.showCustDetail;
            xrTableBalanceV.LocationF = new PointF(0, (this.showCustDetail) ? 45 : 0);
            DetailBalance.HeightF = (this.showCustDetail) ? 110 : 65;
        }

        private void InitCustomerRprt()
        {
            this.rprtCustomerData.InitData(this.clsTbCustomer.GetCustomerObjById(Convert.ToInt32(parameterAccId.Value)));
        }

        private void InitSupplierRprt()
        {
            this.rprtSupplierData.InitData(this.clsTbSupplier.GetSupplierObjById(Convert.ToInt32(parameterAccId.Value)));
        }

        private void InitCustomerBalance()
        {
            this.clsCustBalanceData.CalculatePeriodBalance(this.accNo, this.dtStart, this.dtEnd);
            InitBalanceData(this.clsCustBalanceData.DebitPeriod, this.clsCustBalanceData.CreditPeriod);
        }

        private void InitSupplierBalance()
        {
            this.clsSplBalanceData.CalculatePeriodBalance(this.accNo, this.dtStart, this.dtEnd);
            InitBalanceData(this.clsSplBalanceData.DebitPeriod, this.clsSplBalanceData.CreditPeriod);
        }

        private void InitBalanceData(double debitPeriod, double creditPeriod)
        {
            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = debitPeriod,
                credit = creditPeriod
            };
            tblBalanceDataBindingSource.DataSource = balanceColumnsData;
            SetCurrentBalance(debitPeriod, creditPeriod);
        }

        private void InitSupplyNdEntBand()
        {
            if (!this.combineSupNdEnt) return;

            ResetTotalValues();
            InitSupplyNdEntData();
            InitSupplySubReport();
            SetTotalValues();
            SetBandVisibility(tblSupplyMainBindingSource, DetailBandInvoices);
            SetStyle();
        }

        private void InitSupplyNdEntData()
        {
            var tbSupplyMainList = (this.status == 1) ? ((this.isCash) ? this.clsCustBalanceData.GetCustomerInvoices(this.accId, this.dtStart, this.dtEnd) : this.clsCustBalanceData.TblSupplyMainPeriodList) : this.clsSplBalanceData.TblSupplyMainPeriodList;
            var tbEntryMainList = (this.status == 1) ? this.clsCustBalanceData.TblEntrySubPeriodList : this.clsSplBalanceData.TblEntrySubPeriodList;
            ICollection<tblSupplyMain> tbSupplyMainListCol = tbSupplyMainList as ICollection<tblSupplyMain>;

            tbEntryMainList.ForEach(tbEntMain => tbSupplyMainListCol.Add(new tblSupplyMain()
            {
                supNo = tbEntMain.entNo,
                supDesc = tbEntMain.entDesc,
                supDate = tbEntMain.entDate,
                supTaxPrice = tbEntMain.entTaxPrice,
                supTotal = Convert.ToDouble((tbEntMain.entStatus % 3 == 0) ? tbEntMain.entCredit : tbEntMain.entDebit),
                supStatus = (tbEntMain.entStatus % 3 != 0) ? (byte)1 : (byte)2
            }));

            foreach (var tbSupplyMain in tbSupplyMainList)
            {
                tbSupplyMain.supTotal -= Convert.ToDouble(tbSupplyMain.supDscntAmount);
                CalculateTotalSupplyNdEntry(tbSupplyMain.supStatus, tbSupplyMain.supTotal, Convert.ToDouble(tbSupplyMain.supTaxPrice));
            }

            tblSupplyMainBindingSource.DataSource = tbSupplyMainList.OrderBy(x => x.supDate).ToList();
        }

        private void InitSupplyBand()
        {
            ResetTotalValues();
            InitSupplyData();
            SetTotalValues();
            SetBandVisibility(tblSupplyMainBindingSource, DetailBandInvoices);
            SetStyle();
        }

        private void InitSupplyData()
        {
            if (!this.showInvoice || this.combineSupNdEnt)
            {
                tblSupplyMainBindingSource.DataSource = null;
                tblSupplyMainBindingSource.DataSource = typeof(tblSupplyMain);
                return;
            }
            InitSupplyMainData();
            InitSupplySubReport();
        }

        private void InitSupplySubReport()
        {
            xrSubreportSupplySub.Visible = this.showInvoiceDetail;
            xrSubreportSupplySub.ReportSource = (this.showInvoiceDetail) ? this.rprtSupplySub : null;
        }

        private void SetStyle()
        {
            SetHeaderTableStyle();
            SetDetailTableStyle();
            SetGroupFiled();
        }

        private void SetHeaderTableStyle()
        {
            if (!this.showInvoiceDetail) SetTableSizeFont(xrTableInvHeader, 30, 12);
            else SetTableSizeFont(xrTableInvHeader, 22, 10);

            SetInvColumns(xrTableRowInvHeader, xrtcProfitH, xrtcDateH);
            GroupHeaderInv2.HeightF = (!this.showInvoiceDetail) ? 30 : 22;
        }

        private void SetDetailTableStyle()
        {
            if (!this.showInvoiceDetail) SetTableSizeFont(xrTableInvDetail, 25, 9.75F);
            else SetTableSizeFont(xrTableInvDetail, 20, 9);

            SetInvColumns(xrTableRowInvDetail, xrtcProfitV, xrtcDateV);
            xrtcStatus.WidthF = 140;
            xrTableInvDetail.Styles.Style = (this.showInvoiceDetail) ? EvenStyle : null;
            xrTableInvDetail.Styles.OddStyle = (!this.showInvoiceDetail) ? OddStyle : null;
            xrTableInvDetail.Styles.EvenStyle = (!this.showInvoiceDetail) ? EvenStyle : null;

            xrSubreportSupplySub.LocationF = new PointF(140, (!this.showInvoiceDetail) ? 25 : 20);
            Detail1.HeightF = (!this.showInvoiceDetail) ? 25 : 20;
        }

        private void SetInvColumns(XRTableRow xrTableRow, XRTableCell xrtcProfit, XRTableCell xrtcDate)
        {
            xrTableRow.DeleteCell(xrtcProfit);
            if (!this.showProfit) return;

            xrTableRow.Cells.Add(xrtcProfit);
            xrTableRow.SwapCells(xrtcDate, xrtcProfit);
        }

        private void SetFooterColumns()
        {
            xrTableRowInvF.DeleteCell(xrtcProfitF);
            if (this.showProfit) xrTableRowInvF.Cells.Add(xrtcProfitF);

            xrtcTotalStrF.WidthF = xrtcStatusH.WidthF + xrtcDescH.WidthF;
            xrtcPriceF.WidthF = xrtcPriceH.WidthF;
            xrtcTaxF.WidthF = xrtcTaxH.WidthF;
            xrtcTotalF.WidthF = (this.showProfit) ? xrtcTotalH.WidthF : xrtcTotalH.WidthF + xrtcDateH.WidthF;
        }

        private void SetTableSizeFont(XRTable xrtable, float tableHeight, float fontSize)
        {
            xrtable.HeightF = tableHeight;
            xrtable.Font = new Font("Segoe UI Semibold", fontSize, FontStyle.Bold);
        }

        private void SetGroupFiled()
        {
            GroupHeaderInv2.GroupFields.Remove(this.groupFiled);
            if (this.showInvoiceDetail) GroupHeaderInv2.GroupFields.Add(this.groupFiled);
        }

        private void InitEntryBand()
        {
            InitEntrySubData();
            SetBandVisibility(tblEntrySubBindingSource, DetailBandEntries);
        }

        private void InitSupplyMainData()
        {
            var tbSupplyMainList = (this.status == 1) ? ((this.isCash) ? this.clsCustBalanceData.GetCustomerInvoices(this.accId, this.dtStart, this.dtEnd) : this.clsCustBalanceData.TblSupplyMainPeriodList) : this.clsSplBalanceData.TblSupplyMainPeriodList;
            foreach (var tbSupplyMain in tbSupplyMainList)
            {
                tbSupplyMain.supTotal -= Convert.ToDouble(tbSupplyMain.supDscntAmount);
                CalculateTotalValues(tbSupplyMain.supStatus, tbSupplyMain.supTotal, Convert.ToDouble(tbSupplyMain.supTaxPrice));
            }

            tblSupplyMainBindingSource.DataSource = tbSupplyMainList;
        }

        private void InitEntrySubData()
        {
            if (!this.showEntry || this.combineSupNdEnt)
            {
                tblEntrySubBindingSource.DataSource = null;
                tblEntrySubBindingSource.DataSource = typeof(tblEntrySub);
                return;
            }
            tblEntrySubBindingSource.DataSource = (this.status == 1) ? this.clsCustBalanceData.TblEntrySubPeriodList :
                this.clsSplBalanceData.TblEntrySubPeriodList;
        }

        private void SetBandVisibility(BindingSource bindingSource, DetailReportBand detailBand)
        {
            detailBand.Visible = (bindingSource.Count > 0) ? true : false;
        }

        private void CalculateTotalSupplyNdEntry(byte supStatus, double supTotal, double supTaxPrice)
        {
            if (supStatus > 2)
            {
                CalculateTotalValues(supStatus, supTotal, supTaxPrice);
                return;
            }

            switch (this.status)
            {
                case 1 when supStatus == 1:
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
                case 1 when supStatus == 2:
                    DecreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when supStatus == 1:
                    DecreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when supStatus == 2:
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
            }
        }

        private void CalculateTotalValues(byte supStatus, double supTotal, double supTaxPrice)
        {
            switch (this.status)
            {
                case 1 when (supStatus == 4 || supStatus == 8):
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
                case 1 when (supStatus == 11 || supStatus == 12):
                    DecreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when (supStatus == 3 || supStatus == 7):
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when (supStatus == 9 || supStatus == 10):
                    DecreaseTotal(supTotal, supTaxPrice);
                    break;
            }
        }

        private void IncreaseTotal(double supTotal, double supTaxPrice)
        {
            this.totalPrice += supTotal;
            this.totalTax += supTaxPrice;
        }

        private void DecreaseTotal(double supTotal, double supTaxPrice)
        {
            this.totalPrice -= supTotal;
            this.totalTax -= supTaxPrice;
        }

        private void SetTotalValues()
        {
            xrtcPriceF.Text = $"{this.totalPrice:n2}";
            xrtcTaxF.Text = $"{this.totalTax:n2}";
            xrtcTotalF.Text = $"{this.totalPrice + this.totalTax:n2}";
        }


        private void SetCurrentBalance(double debitPeriod, double creditPeriod)
        {
            double total = creditPeriod - debitPeriod;

            if (total > 0)
            {
                xrtcCurrentBalance.Text = $"{total:#,#.##} دائن";
                xrtcCurrentBalanceHeader.ForeColor = Color.Green;
                xrtcCurrentBalance.ForeColor = Color.Green;
                xrtcCurrentBalanceHeader.BackColor = Color.FromArgb(212, 223, 201);
                xrtcCurrentBalance.BackColor = Color.FromArgb(249, 255, 242);
            }
            else if (total < 0)
            {
                xrtcCurrentBalance.Text = $"{-total:#,#.##} مدين";
                xrtcCurrentBalanceHeader.ForeColor = Color.Red;
                xrtcCurrentBalance.ForeColor = Color.Red;
                xrtcCurrentBalanceHeader.BackColor = Color.FromArgb(240, 212, 194);
                xrtcCurrentBalance.BackColor = Color.FromArgb(255, 244, 236);
            }
            else if (total == 0)
            {
                xrtcCurrentBalance.Text = "0.00";
                xrtcCurrentBalanceHeader.ForeColor = Color.Green;
                xrtcCurrentBalance.ForeColor = Color.Green;
                xrtcCurrentBalanceHeader.BackColor = Color.FromArgb(212, 223, 201);
                xrtcCurrentBalance.BackColor = Color.FromArgb(249, 255, 242);
            }
        }

        private void xrtcStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsSupplyStatus.GetString(Convert.ToByte(cell.Value), Convert.ToByte(DetailBandInvoices.GetCurrentColumnValue("supIsCash")));
            if (Convert.ToByte(cell.Value) >= 9) cell.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);

            this.supTotal = Convert.ToDouble(DetailBandInvoices.GetCurrentColumnValue("supTotal"));
            xrtcSupTotal.Text = $"{(this.supTotal + (Convert.ToDouble(DetailBandInvoices.GetCurrentColumnValue("supTaxPrice")))):#,#.##}";

            SetProfit(Convert.ToByte(cell.Value));
            SetEntryStatus(cell);
        }

        private void SetEntryStatus(XRTableCell cell)
        {
            if (!this.combineSupNdEnt) return;
            if (Convert.ToByte(cell.Value) > 2) return;

            cell.Text = (Convert.ToByte(cell.Value) == 2) ? "سند قبض" : "سند صرف";
        }

        private void SetProfit(byte status)
        {
            if (!this.showProfit) return;
            if (status <= 2)
            {
                xrtcProfitV.Text = null;
                return;
            }

            totalProfit = this.supTotal - this.clsTbSupplySub.GetSupplyPrdTotalPurchasePrice(Convert.ToInt32(DetailBandInvoices.GetCurrentColumnValue("id")));
            xrtcProfitV.Text = $"{totalProfit:n2}";
            CalculateProfit(totalProfit);
        }

        private void CalculateProfit(double totalProfit)
        {
            byte status = Convert.ToByte(DetailBandInvoices.GetCurrentColumnValue("supStatus"));
            if (status == 4 || status == 8) this.totalProfit += totalProfit;
            else if (status == 11 || status == 12) this.totalProfit -= totalProfit;

        }

        private void ReportFooterInv_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrtcProfitF.Text = $"{this.totalProfit:n2}";
        }

        private void xrtcEntStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsEntryStatus.GetString(Convert.ToByte(cell.Value));
        }
    }
}
