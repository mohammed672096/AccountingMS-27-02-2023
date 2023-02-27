using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportCustomerSupplierInvDetail : XtraReport
    {
        ClsTblSupplier clsTbSupplier;
        ClsTblCustomer clsTbCustomer;
        ICollection<ItblSupplyMainDetailInvoice> itbSupplyMainInvoiceList = new Collection<ItblSupplyMainDetailInvoice>();
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblSupplierInvoice> tbSupplierInvoiceList;
        IEnumerable<tblCustomerInvoice> tbCustomerInvoiceList;

        private byte status;
        private double totalPrice, totalTax;

        public ReportCustomerSupplierInvDetail(byte status)
        {
            this.status = status;
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData();
            InitDefaultData();
            new ClsReportHeaderData(this);
        }

        private void InitDefaultData()
        {
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}");

            if (this.status == 2)
            {
                xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "تقرير فواتير العملاء" : "Report Customer Invoices";
                xrlTaxNo.Visible = false;
            }
        }

        private void InitSupplierData()
        {
            this.clsTbSupplier = new ClsTblSupplier();

            DynamicListLookUpSettings listLookUpSettings = new DynamicListLookUpSettings
            {
                DataSource = this.clsTbSupplier.GetSuppliersList(),
                ValueMember = "id",
                DisplayMember = "splName"
            };
            parameterSupplierCustomer.LookUpSettings = listLookUpSettings;
        }

        private void InitCustomerData()
        {
            this.clsTbCustomer = new ClsTblCustomer();

            DynamicListLookUpSettings listLookUpSettings = new DynamicListLookUpSettings
            {
                DataSource = this.clsTbCustomer.GetCustomersList(),
                ValueMember = "id",
                DisplayMember = "custName"
            };
            parameterSupplierCustomer.LookUpSettings = listLookUpSettings;
            parameterSupplierCustomer.Description = (!MySetting.GetPrivateSetting.LangEng) ? "العميل :" : "Customer :";
        }

        private void InitData()
        {
            if (status == 2)
                this.tbSupplyMainList = new ClsTblSupplyMain(1).GetSupplyMainList;
            else
                this.tbSupplyMainList = new ClsTblSupplyMain(SupplyType.PurchasePhaseAll).GetSupplyMainList;
            switch (this.status)
            {
                case 1:
                    this.tbSupplierInvoiceList = new ClsTblSupplierInvoice().GetSupplierInvoiceList;
                    InitSupplierList();
                    InitSupplierData();
                    break;
                case 2:
                    this.tbCustomerInvoiceList = new ClsTblCustomerInvoice().GetCustomerInvoiceList;
                    InitCustomerList();
                    InitCustomerData();
                    break;
            }
        }

        private void InitSupplierList()
        {
            foreach (var tbSupplierInv in this.tbSupplierInvoiceList)
                AddRecordToITblSupplyMainInvoice(tbSupplierInv.invSupId, tbSupplierInv.invSplId);
        }

        private void InitCustomerList()
        {
            foreach (var tbCustomerInv in this.tbCustomerInvoiceList)
                AddRecordToITblSupplyMainInvoice(tbCustomerInv.invSupId, tbCustomerInv.invCstId);
        }

        private void AddRecordToITblSupplyMainInvoice(int invSupId, int invSCId)
        {
            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                if (tbSupplyMain.id == invSupId)
                {
                    ItblSupplyMainDetailInvoice itbSupplyMainInvoice = tbSupplyMain as ItblSupplyMainDetailInvoice;
                    itbSupplyMainInvoice.sclId = invSCId;
                    itbSupplyMainInvoice.supTotal = tbSupplyMain.supTotal - Convert.ToDouble(tbSupplyMain.supDscntAmount);
                    itbSupplyMainInvoice.supTotalFinal = itbSupplyMainInvoice.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice);
                    //itbSupplyMainInvoice.supTotalFinal = tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice)- Convert.ToDouble(tbSupplyMain.supDscntAmount??0);
                    this.itbSupplyMainInvoiceList.Add(itbSupplyMainInvoice);
                    break;
                }
            }
        }

        private void ReportSupplierDetail_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            DateTime dtStart = Convert.ToDateTime(parameterDateStart.Value).Date, dtEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            int scId = Convert.ToInt32(parameterSupplierCustomer.Value);

            ResetTotalValues();
            SearchListData(scId, dtStart, dtEnd);
            SetTotalValues();
            SetInvoiceHeader(scId);
            SetSupplierTaxNo(scId);
        }

        private void ResetTotalValues()
        {
            this.totalPrice = 0;
            this.totalTax = 0;
        }

        private void SetSupplierTaxNo(int splId)
        {
            if (this.status != 1) return;
            xrlTaxNo.Text = (!MySetting.GetPrivateSetting.LangEng) ? "الرقم الضريبي : " : "Tax No.: ";
            xrlTaxNo.Text += this.clsTbSupplier.GetSupplierTaxDeclarationNoById(splId);
        }

        private void SearchListData(int scId, DateTime dtStart, DateTime dtEnd)
        {
            ICollection<ItblSupplyMainDetailInvoice> itblSupplyInvoiceList = new Collection<ItblSupplyMainDetailInvoice>();

            foreach (var iSupplyList in this.itbSupplyMainInvoiceList)
            {
                if (Convert.ToDateTime(iSupplyList.supDate).Date > dtEnd) continue;
                if (iSupplyList.sclId == scId && iSupplyList.supDate >= dtStart)
                {
                    itblSupplyInvoiceList.Add(iSupplyList);
                    CalculateTotalValues(iSupplyList.supStatus, iSupplyList.supTotal, Convert.ToDouble(iSupplyList.supTaxPrice));
                }
            }
            tblSupplyMainBindingSource.DataSource = itblSupplyInvoiceList;
        }

        private void CalculateTotalValues(byte supStatus, double supTotal, double supTaxPrice)
        {
            switch (this.status)
            {
                case 1 when (supStatus == 3 || supStatus == 7):
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
                case 1 when (supStatus == 9 || supStatus == 10):
                    DecreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when (supStatus == 4 || supStatus == 8):
                    IncreaseTotal(supTotal, supTaxPrice);
                    break;
                case 2 when (supStatus == 11 || supStatus == 12):
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
            xrtcTotalPrice.Text = $"{this.totalPrice:n2}";
            xrtcTotalTax.Text = $"{this.totalTax:n2}";
            xrtcTotalFinal.Text = $"{(this.totalPrice + this.totalTax):n2}";
        }

        private void SetInvoiceHeader(int scId)
        {
            switch (this.status)
            {
                case 1:
                    xrtcInvoiceName.Text = (!MySetting.GetPrivateSetting.LangEng) ? "المورد : " : "Supplier : ";
                    xrtcInvoiceName.Text += this.clsTbSupplier.GetSupplierNameById(scId);
                    xrlTaxNo.Visible = true;
                    xrlTaxNo.Text = (!MySetting.GetPrivateSetting.LangEng) ? "الرقم الضريبي : " : "Tax No.: ";
                    xrlTaxNo.Text += this.clsTbSupplier.GetSupplierTaxDeclarationNoById(scId);
                    break;
                case 2:
                    xrtcInvoiceName.Text = (!MySetting.GetPrivateSetting.LangEng) ? "العميل : " : "Customer : ";
                    xrtcInvoiceName.Text += this.clsTbCustomer.GetCustomerNameById(scId);
                    break;
            }
        }

        private void xrTableCell8_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsSupplyStatus.GetString(Convert.ToByte(cell.Value), Convert.ToByte(GetCurrentColumnValue("supIsCash")));
            if (Convert.ToByte(cell.Value) >= 9) cell.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
