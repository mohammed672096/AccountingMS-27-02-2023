using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ReportForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();

        private ReportType reportType;
        private ArrayList listMain;
        private ArrayList listSub;
        private tblEntryMain tbEntMain;
        private BindingList<tblEntrySub> tbEntSubList;
        private tblSupplyMain tbSupplyMain;
        private IEnumerable<tblSupplySub> tbSupplySubList;
        private byte status;
        private dynamic tblObject;
        private IEnumerable tblObjectList;
        private ClsTblProduct clsTbProduct;
        private ClsTblPrdPriceMeasurment clsTbPrdMsur;
        public ReportForm(Reports.InventoryBalanceingsReport inventoryBalanceingsReport)
        {
            InitializeComponent();
            var report = new Reports.InventoryBalanceingsReport();
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportForm(DevExpress.XtraReports.UI.XtraReport report)
        {
            InitializeComponent();
            this.Text = "تقرير حركة الأصناف في المخازن";
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportForm(DevExpress.XtraReports.UI.XtraReport report,string txt)
        {
            InitializeComponent();
            this.Text = txt;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportForm(ReportType reportType, ArrayList listMain = null, ArrayList listSub = null, tblEntryMain tbEntMain = null, BindingList<tblEntrySub> tbEntSubList = null, tblSupplyMain tbSupplyMain = null, IEnumerable<tblSupplySub> tbSupplySubList = null, byte status = 0, dynamic tblObject = null, IEnumerable tblObjectList = null, ClsTblProduct clsTbProduct = null, ClsTblPrdPriceMeasurment clsTbPrdMsur = null)
        {
            InitializeComponent();
            SetDataTypes(reportType, listMain, listSub, tbEntMain, tbEntSubList, tbSupplyMain, tbSupplySubList, status, tblObject, tblObjectList, clsTbProduct, clsTbPrdMsur);

            SetRTL();
            this.Load += ReportForm_Load;
        }

        private async void ReportForm_Load(object sender, System.EventArgs e)
        {
            await InitReport();
        }

        private async Task InitReport()
        {
            switch (reportType)
            {
                case ReportType.Entry:
                    this.Text = "فاتورة قيد يومي";
                    ReportEntry rprt = new ReportEntry();
                    rprt.EntMainData(listMain);
                    rprt.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprt;
                    rprt.CreateDocument();
                    break;
                case ReportType.EntryVoucher:
                    this.Text = "فاتورة سند صرف";
                    ReportEntryVchrRcpt rprtVocher = new ReportEntryVchrRcpt();
                    rprtVocher.EntMainData(listMain, false);
                    rprtVocher.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprtVocher;
                    rprtVocher.CreateDocument();
                    break;
                case ReportType.EntryReceipt:
                    this.Text = "فاتورة سند قبض";
                    ReportEntryVchrRcpt rprtRecipt = new ReportEntryVchrRcpt();
                    rprtRecipt.EntMainData(listMain, true);
                    rprtRecipt.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprtRecipt;
                    rprtRecipt.CreateDocument();
                    break;
                case ReportType.EmpVchrExtraInv:
                    this.Text = $"سند {ClsEntryStatus.GetString(tbEntMain.entStatus)}";
                    ReportEmpVchrExtraInv rprtEmpVchrExtraInv = new ReportEmpVchrExtraInv(tbEntMain, tblObject);
                    documentViewer1.DocumentSource = rprtEmpVchrExtraInv;
                    rprtEmpVchrExtraInv.CreateDocument();
                    break;
                case ReportType.EmpVchrTip:
                    this.Text = $"تقرير {ClsEntryStatus.GetString((byte)EntryType.EmpVoucherTip)}";
                    var rprtEmpVchrExtra1 = new ReportEmpVchrExtra(ReportType.EmpVchrTip);
                    documentViewer1.DocumentSource = rprtEmpVchrExtra1;
                    rprtEmpVchrExtra1.CreateDocument();
                    break;
                case ReportType.EmpVchrOvrTm:
                    this.Text = $"تقرير {ClsEntryStatus.GetString((byte)EntryType.EmpVoucherOvrTm)}";
                    var rprtEmpVchrExtra2 = new ReportEmpVchrExtra(ReportType.EmpVchrOvrTm);
                    documentViewer1.DocumentSource = rprtEmpVchrExtra2;
                    rprtEmpVchrExtra2.CreateDocument();
                    break;
                case ReportType.SupplyA4:
                    var rprtSupply = new ReportSupply(tbSupplyMain, tbSupplySubList);
                    documentViewer1.DocumentSource = rprtSupply;
                    rprtSupply.CreateDocument();
                    break;
                case ReportType.SupplyChasier:
                    if (File.Exists(Directory.GetCurrentDirectory() + "//UseCasher2"))
                    {
                        var rprtCahser = new ReportSupplyCashier2(tbSupplyMain, tbSupplySubList);
                        documentViewer1.DocumentSource = rprtCahser;
                        rprtCahser.CreateDocument();

                    }
                    else
                    {
                        var rprtCahser = new ReportSupplyCashier(tbSupplyMain, tbSupplySubList);
                        documentViewer1.DocumentSource = rprtCahser;
                        rprtCahser.CreateDocument();

                    }


                    break;
                case ReportType.SupplyCustom:
                    if (!ClsPrintReport.ValidateRprtSupplyCustomFile()) return;
                    dynamic rprtSupplyCustom = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
                    {
                        2 => new ReportSupplyCustom2(tbSupplyMain, tbSupplySubList),
                        3 => new ReportSupplyCustom3(tbSupplyMain, tbSupplySubList),
                        _ => new ReportSupplyCustom(tbSupplyMain, tbSupplySubList),
                    };
                    //var rprtSupplyCustom = new ReportSupplyCustom(tbSupplyMain, tbSupplySubList);
                    documentViewer1.DocumentSource = rprtSupplyCustom;
                    rprtSupplyCustom.CreateDocument();
                    break;
                case ReportType.SupplyCashierCustom:
                    if (!ClsPrintReport.ValidateRprtSupplyCashierCustomFile()) return;
                    dynamic rprtSupplyCashierCustom = (new ReportSupplyCashierCustom(tbSupplyMain, tbSupplySubList));
                    documentViewer1.DocumentSource = rprtSupplyCashierCustom;
                    rprtSupplyCashierCustom.CreateDocument();
                    break;
                case ReportType.OrderCustom:
                    if (!ClsPrintReport.ValidateRprtSupplyCustomFile()) return;
                    dynamic rprtOrderCustom = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
                    {
                        2 => new ReportSupplyCustom2((tblOrderMain)tblObject, (IEnumerable<tblOrderSub>)tblObjectList),
                        3 => new ReportSupplyCustom3((tblOrderMain)tblObject, (IEnumerable<tblOrderSub>)tblObjectList),
                        _ => new ReportSupplyCustom((tblOrderMain)tblObject, (IEnumerable<tblOrderSub>)tblObjectList),
                    };
                    //var rprtSupplyCustom = new ReportSupplyCustom(tbSupplyMain, tbSupplySubList);
                    documentViewer1.DocumentSource = rprtOrderCustom;
                    rprtOrderCustom.CreateDocument();
                    break;
                case ReportType.SupplyTarhel:
                    this.Text = "تقرير فاتورة ترحيل";
                    var rprtSupplyTarhel = new ReportSupplyTarehl(tbSupplyMain);
                    documentViewer1.DocumentSource = rprtSupplyTarhel;
                    rprtSupplyTarhel.CreateDocument();
                    break;
                case ReportType.AccountBill:
                    this.Text = "كشف حساب";
                    //var rprtAccountBill = new ReportAccountBill();
                    flydDialog.WaitForm(this, 1);
                    var rprtAccountBill = await ReportAccountBillMaster.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtAccountBill;
                    rprtAccountBill.CreateDocument();
                    break;
                case ReportType.Suppliers:
                    this.Text = "تقرير الموردين";
                    var rprtSuppliers = new ReportSuppliers();
                    documentViewer1.DocumentSource = rprtSuppliers;
                    rprtSuppliers.CreateDocument();
                    break;
                case ReportType.BalanceSheet1:
                    this.Text = "الميزانية العمومية";
                    var rprtBalanceSheet = new ReportBalanceSheet(1);
                    documentViewer1.DocumentSource = rprtBalanceSheet;
                    rprtBalanceSheet.CreateDocument();
                    break;
                case ReportType.BalanceSheet2:
                    this.Text = "حساب الأرباح والخسائر";
                    var rprtBalcneSheet2 = new ReportBalanceSheet(3);
                    documentViewer1.DocumentSource = rprtBalcneSheet2;
                    rprtBalcneSheet2.CreateDocument();
                    break;
                case ReportType.DailyEntry:
                    this.Text = "تقرير الحركة اليومية";
                    var rprtDailyEntry = new ReportDailyEntry();
                    documentViewer1.DocumentSource = rprtDailyEntry;
                    rprtDailyEntry.CreateDocument();
                    break;
                case ReportType.DailyEntryDetail:
                    this.Text = "تقرير الحركة اليومية التفصيلي";
                    var rprtDailyEntryDetail = new ReportDailyEntryDetail(reportType);
                    documentViewer1.DocumentSource = rprtDailyEntryDetail;
                    rprtDailyEntryDetail.CreateDocument();
                    break;
                case ReportType.EntryVoucherInv:
                    this.Text = "تقرير سندات الصرف";
                    var rprtEntryVoucherInv = new ReportEntryVchrRcptMaster(ReportType.EntryVoucherInv);
                    await rprtEntryVoucherInv.InitRprtAsync();
                    documentViewer1.DocumentSource = rprtEntryVoucherInv;
                    rprtEntryVoucherInv.CreateDocument();
                    break;
                case ReportType.EntryReceiptInv:
                    this.Text = "تقرير سندات القبض";
                    var rprtEntryRcptInv = new ReportEntryVchrRcptMaster(ReportType.EntryReceiptInv);
                    await rprtEntryRcptInv.InitRprtAsync();
                    documentViewer1.DocumentSource = rprtEntryRcptInv;
                    rprtEntryRcptInv.CreateDocument();
                    break;
                case ReportType.EntryEmp:
                    this.Text = "تقرير سند صرف الموظفين";
                    ReportEntryVchrRcpt rprtEmpVhr = new ReportEntryVchrRcpt();
                    rprtEmpVhr.EntMainEmpVchr(tbEntMain);
                    rprtEmpVhr.EntSubEmpVchr(tbEntSubList);
                    documentViewer1.DocumentSource = rprtEmpVhr;
                    rprtEmpVhr.CreateDocument();
                    break;
                case ReportType.EmpSalary:
                    this.Text = "كشف مرتبات الموظفين";
                    var rprtEmpSalary = new ReportEmpSalary(true);
                    documentViewer1.DocumentSource = rprtEmpSalary;
                    rprtEmpSalary.CreateDocument();
                    break;
                case ReportType.EmpSalaryDetail:
                    this.Text = "تقرير مرتبات الموظفين التفصيلي";
                    var rprtEmpSalaryDetail = new ReportEmpSalaryDetail();
                    documentViewer1.DocumentSource = rprtEmpSalaryDetail;
                    rprtEmpSalaryDetail.CreateDocument();
                    break;
                case ReportType.SalePurchase:
                    this.Text = (status == 1) ? "تقرير المشتريات" : "تقرير المبيعات";
                    var rprtSalePurchase = new ReportSalePurchase(status);
                    documentViewer1.DocumentSource = rprtSalePurchase;
                    rprtSalePurchase.CreateDocument();
                    break;
                case ReportType.Orders:
                    this.Text = "تقرير الطلبات";
                    var rprtOrders = new ReportOrders();
                    documentViewer1.DocumentSource = rprtOrders;
                    rprtOrders.CreateDocument();
                    break;
                case ReportType.OrderInvoice:
                    this.Text = "فاتورة طلب";
                    var rprtOrderInv = new ReportOrderInvoice((tblOrderMain)tblObject, (IEnumerable<tblOrderSub>)tblObjectList);
                    documentViewer1.DocumentSource = rprtOrderInv;
                    rprtOrderInv.CreateDocument();
                    break;
                case ReportType.Store:
                    this.Text = "تقرير المخازن";
                    flydDialog.WaitForm(this, 1);
                    var rprtStore = await ReportStore.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtStore;
                    rprtStore.CreateDocument();
                    break;
                case ReportType.StoreProducts:
                    this.Text = "تقرير جرد المخازن";
                    flydDialog.WaitForm(this, 1);
                    var rprtStoreProducts = await ReportStoreProducts.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtStoreProducts;
                    rprtStoreProducts.CreateDocument();
                    break;
                case ReportType.Product:
                    this.Text = "تقرير حركة الأصناف";
                    var rprtProduct = new ReportProduct();
                    documentViewer1.DocumentSource = rprtProduct;
                    rprtProduct.CreateDocument();
                    break;
                case ReportType.PrdQuanTrack:
                    this.Text = "تقرير كمية حركة الأصناف";
                    flydDialog.WaitForm(this, 1);
                    var rprtPrdQuanTrack = await ReportPrdQuanTrack.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtPrdQuanTrack;
                    rprtPrdQuanTrack.CreateDocument();
                    break;
                case ReportType.ProductsData:
                    this.Text = "تقرير بيانات الأصناف التفصيلي";
                    var rprtPrdDdata = new ReportProductsData();
                    documentViewer1.DocumentSource = rprtPrdDdata;
                    rprtPrdDdata.CreateDocument();
                    break;
                case ReportType.StockTrans:
                    this.Text = "تقرير التحويل المخزني";
                    var rprtStockTrans = new ReportStockTrans(tblObject, tblObjectList as IEnumerable<tblStockTransSub>);
                    documentViewer1.DocumentSource = rprtStockTrans;
                    rprtStockTrans.CreateDocument();
                    break;
                case ReportType.PrdExpirate:
                    this.Text = "تقرير الاصناف التالفة";
                    var ReportProExpirte = new ReportProExpirte(tblObject, tblObjectList as IEnumerable<tblPrdExpirateQuan>);
                    documentViewer1.DocumentSource = ReportProExpirte;
                    ReportProExpirte.CreateDocument();
                    break;
                case ReportType.ProductQuan:
                    this.Text = "تقرير كميات الأصناف المتوفرة";
                    flydDialog.WaitForm(this, 1);
                    var rprtPrdQuanPr = await ReportProductQuan.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtPrdQuanPr;
                    rprtPrdQuanPr.CreateDocument();
                    break;
                case ReportType.ProductQuanAndAvPr:
                    this.Text = "تقرير الأصناف المتوفرة ومتوسط سعر الشراء";
                    flydDialog.WaitForm(this, 1);
                    var rprtPrdQuanPr1 = await ReportProductQuanPrice.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtPrdQuanPr1;
                    rprtPrdQuanPr1.CreateDocument();
                    break;
                case ReportType.PrdQuanOpn:
                    this.Text = "تقرير تخزين الأصناف";
                    flydDialog.WaitForm(this, 1);
                    var rprtPrdQuanOpn = await ReportPrdQuanOpn.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtPrdQuanOpn;
                    rprtPrdQuanOpn.CreateDocument();
                    break;
                case ReportType.TaxDeclaration:
                    this.Text = "تقرير الإقرار الضريبي";
                    flydDialog.WaitForm(this, 1);
                    var rprtTaxDecl = await ReportTaxDeclaration.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtTaxDecl;
                    rprtTaxDecl.CreateDocument();
                    break;
                case ReportType.SaleDetail:
                    this.Text = "تقرير المبيعات التفصيلي";
                    flydDialog.WaitForm(this, 1);
                    //var rprtSale = new ReportSaleDetailM();
                    //await rprtSale.InitObjectsAsync();
                    var rprtSale = await ReportSaleDetailM.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtSale;
                    rprtSale.CreateDocument();
                    break;
                case ReportType.AllSale:
                    this.Text = "تقرير إجمالي المبيعات";
                    flydDialog.WaitForm(this, 1);
                    var rprtAllSale = await ReportAllSaleM.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtAllSale;
                    rprtAllSale.CreateDocument();
                    break;
                case ReportType.SaleGroup:
                    this.Text = "تقرير مبيعات المجموعة";
                    var rprtSaleGrp = new ReportSaleGroup();
                    documentViewer1.DocumentSource = rprtSaleGrp;
                    rprtSaleGrp.CreateDocument();
                    break;
                case ReportType.SaleGroupWithoutProfit:
                    this.Text = "تقرير مبيعات المجموعة";
                    var rprtSaleGrpW = new ReportSaleGroupWithoutProfit();
                    documentViewer1.DocumentSource = rprtSaleGrpW;
                    rprtSaleGrpW.CreateDocument();
                    break;
                case ReportType.SaleUserWithoutProfit:
                    this.Text = "تقرير مبيعات المستخدمين";
                    var rprtSaleUspW = new ReportSaleUserWithoutProfit();
                    documentViewer1.DocumentSource = rprtSaleUspW;
                    rprtSaleUspW.CreateDocument();
                    break;
                case ReportType.SaleGroupRoll:
                    this.Text = "تقرير مبيعات المجموعة";
                    var rprtSaleGrpRoll = new ReportSaleGroupRollHead();
                    documentViewer1.DocumentSource = rprtSaleGrpRoll;
                    rprtSaleGrpRoll.CreateDocument();
                    break;
                case ReportType.SaleCashier:
                    this.Text = "تقرير المبيعات كاشير";
                    flydDialog.WaitForm(this, 1);
                    var rprtSaleCashier = await ReportSaleCashier.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtSaleCashier;
                    rprtSaleCashier.CreateDocument();
                    break;
                case ReportType.SalesWithTax:
                    this.Text = "التقرير الضريبي للمبيعات";
                    var rprtSaleTax = new rpt_SalesWithTax(SupplyType.SalesPhase, SupplyType.SalesPhaseRtrn);
                    documentViewer1.DocumentSource = rprtSaleTax;
                    rprtSaleTax.CreateDocument();
                    break;
                case ReportType.PurchaseWithTax:
                    this.Text = "التقرير الضريبي للمشتريات";
                    rprtSaleTax = new rpt_SalesWithTax(SupplyType.PurchasePhase, SupplyType.PurchasePhaseRtrn);
                    documentViewer1.DocumentSource = rprtSaleTax;
                    rprtSaleTax.CreateDocument();
                    break;
                case ReportType.CustomerDailyEntryDetail:
                    this.Text = "تقرير فواتير العملاء التفصيلي";
                    var rprtDailyEntryDetail2 = new ReportDailyEntryDetail(reportType);
                    documentViewer1.DocumentSource = rprtDailyEntryDetail2;
                    rprtDailyEntryDetail2.CreateDocument();
                    break;
                case ReportType.CustomerSupplierInvDetail:
                    this.Text = (status == 1) ? "تقرير الموردين" : "تقرير العملاء";
                    var rprtCustSuplDetail = new ReportCustomerSupplierInvDetail(status);
                    documentViewer1.DocumentSource = rprtCustSuplDetail;
                    rprtCustSuplDetail.CreateDocument();
                    break;
                case ReportType.CustomerSupplierBalance:
                    this.Text = (status == 1) ? "تقرير أرصدة العملاء" : "تقرير أرصدة الموردين";
                    var rprtCustSuplBalance = new ReportCustomerSupplierBalance(status);
                    documentViewer1.DocumentSource = rprtCustSuplBalance;
                    rprtCustSuplBalance.CreateDocument();
                    break;
                case ReportType.CustomerSupplierBalanceBatch:
                    this.Text = (status == 1) ? "تقرير أرصدة العملاء" : "تقرير أرصدة الموردين";
                    var rprtCustSuplBalanceBatch = new ReportCustomerSupplierBalanceBatch(status);
                    documentViewer1.DocumentSource = rprtCustSuplBalanceBatch;
                    rprtCustSuplBalanceBatch.CreateDocument();
                    break;
                case ReportType.CustomerSupplierBalanceBatchFy:
                    this.Text = (status == 1) ? "تقرير أرصدة العملاء" : "تقرير أرصدة الموردين";
                    var rprtCustSuplBalanceBatchFy = new ReportCustSuplAllBalanceBatch(status);
                    documentViewer1.DocumentSource = rprtCustSuplBalanceBatchFy;
                    rprtCustSuplBalanceBatchFy.CreateDocument();
                    break;
                case ReportType.InvStoreManual:
                    this.Text = "تقرير الجرد اليدوي";
                    flydDialog.WaitForm(this, 1);
                    var rprtInvMan = await ReportInvStoreManual.CreateAsync(tblObject);
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtInvMan;
                    rprtInvMan.CreateDocument();
                    break;
                case ReportType.InvStoreDirect:
                    this.Text = "تقرير الجرد الفوري";
                    flydDialog.WaitForm(this, 1);
                    var rprtInvDirect = await ReportInvStoreDirect.CreateAsync(tblObject);
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtInvDirect;
                    rprtInvDirect.CreateDocument();
                    break;
                case ReportType.InvStoreSettlement:
                    this.Text = "تقرير التسوية المخزنيه";
                    flydDialog.WaitForm(this, 1);
                    var rprtInvSetl = await ReportInvStoreSettlement.CreateAsync(tblObject);
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtInvSetl;
                    rprtInvSetl.CreateDocument();
                    break;
                case ReportType.GeneralLedger:
                    this.Text = "تقرير الأستاذ العام";
                    flydDialog.WaitForm(this, 1);
                    var rprtGnrlLedger = await ReportGeneralLedger.CreateAsync();
                    flydDialog.WaitForm(this, 0);
                    documentViewer1.DocumentSource = rprtGnrlLedger;
                    rprtGnrlLedger.CreateDocument();
                    break;
            }
        }

        private void SetDataTypes(ReportType reportType, ArrayList listMain, ArrayList listSub, tblEntryMain tbEntMain, BindingList<tblEntrySub> tbEntSubList, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList, byte status, dynamic tblObject, IEnumerable tblObjectList, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            this.reportType = reportType;
            this.listMain = listMain;
            this.listSub = listSub;
            this.tbEntMain = tbEntMain;
            this.tbEntSubList = tbEntSubList;
            this.tbSupplyMain = tbSupplyMain;
            this.tbSupplySubList = tbSupplySubList;
            this.status = status;
            this.tblObject = tblObject;
            this.tblObjectList = tblObjectList;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
        }


        /*
        private async Task InitReport(ReportType reportType, ArrayList listMain, ArrayList listSub, tblEntryMain tbEntMain, BindingList<tblEntrySub> tbEntSubList, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList, byte status, dynamic tblObject, IEnumerable tblObjectList, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            switch (reportType)
            {
                case ReportType.Entry:
                    this.Text = "فاتورة قيد يومي";
                    ReportEntry rprt = new ReportEntry();
                    rprt.EntMainData(listMain);
                    rprt.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprt;
                    break;
                case ReportType.EntryVoucher:
                    this.Text = "فاتورة سند صرف";
                    ReportEntryVchrRcpt rprtVocher = new ReportEntryVchrRcpt();
                    rprtVocher.EntMainData(listMain, false);
                    rprtVocher.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprtVocher;
                    break;
                case ReportType.EntryReceipt:
                    this.Text = "فاتورة سند قبض";
                    ReportEntryVchrRcpt rprtRecipt = new ReportEntryVchrRcpt();
                    rprtRecipt.EntMainData(listMain, true);
                    rprtRecipt.EntSubData(listSub);
                    documentViewer1.DocumentSource = rprtRecipt;
                    break;
                case ReportType.EmpVchrExtraInv:
                    this.Text = $"سند {ClsEntryStatus.GetString(tbEntMain.entStatus)}";
                    documentViewer1.DocumentSource = new ReportEmpVchrExtraInv(tbEntMain, tblObject);
                    break;
                case ReportType.EmpVchrTip:
                    this.Text = $"تقرير {ClsEntryStatus.GetString((byte)EntryType.EmpVoucherTip)}";
                    documentViewer1.DocumentSource = new ReportEmpVchrExtra(ReportType.EmpVchrTip);
                    break;
                case ReportType.EmpVchrOvrTm:
                    this.Text = $"تقرير {ClsEntryStatus.GetString((byte)EntryType.EmpVoucherOvrTm)}";
                    documentViewer1.DocumentSource = new ReportEmpVchrExtra(ReportType.EmpVchrOvrTm);
                    break;
                case ReportType.SupplyA4:
                    documentViewer1.DocumentSource = new ReportSupply(tbSupplyMain, tbSupplySubList, clsTbProduct, clsTbPrdMsur);
                    break;
                case ReportType.SupplyChasier:
                    documentViewer1.DocumentSource = new ReportSupplyCashier(tbSupplyMain, tbSupplySubList);
                    break;
                case ReportType.SupplyCustom:
                    if (!ClsPrintReport.ValidateRprtSupplyCustomFile()) return;
                    documentViewer1.DocumentSource = new ReportSupplyCustom(tbSupplyMain, tbSupplySubList);
                    break;
                case ReportType.SupplyTarhel:
                    this.Text = "تقرير فاتورة ترحيل";
                    documentViewer1.DocumentSource = new ReportSupplyTarehl(tbSupplyMain);
                    break;
                case ReportType.AccountBill:
                    this.Text = "كشف حساب";
                    documentViewer1.DocumentSource = new ReportAccountBill(); ;
                    break;
                case ReportType.Suppliers:
                    this.Text = "تقرير الموردين";
                    documentViewer1.DocumentSource = new ReportSuppliers();
                    break;
                case ReportType.BalanceSheet1:
                    this.Text = "الميزانية العمومية";
                    documentViewer1.DocumentSource = new ReportBalanceSheet(1);
                    break;
                case ReportType.BalanceSheet2:
                    this.Text = "حساب الأرباح والخسائر";
                    documentViewer1.DocumentSource = new ReportBalanceSheet(3);
                    break;
                case ReportType.DailyEntry:
                    this.Text = "تقرير الحركة اليومية";
                    documentViewer1.DocumentSource = new ReportDailyEntry();
                    break;
                case ReportType.DailyEntryDetail:
                    this.Text = "تقرير الحركة اليومية التفصيلي";
                    documentViewer1.DocumentSource = new ReportDailyEntryDetail(reportType);
                    break;
                case ReportType.EntryVoucherInv:
                    this.Text = "تقرير سندات الصرف";
                    var rprtEntryVoucherInv = new ReportEntryVchrRcptMaster(ReportType.EntryVoucherInv);
                    documentViewer1.DocumentSource = rprtEntryVoucherInv;
                    await rprtEntryVoucherInv.InitRprtAsync();
                    break;
                case ReportType.EntryReceiptInv:
                    this.Text = "تقرير سندات القبض";
                    var rprtEntryRcptInv = new ReportEntryVchrRcptMaster(ReportType.EntryReceiptInv);
                    documentViewer1.DocumentSource = rprtEntryRcptInv;
                    await rprtEntryRcptInv.InitRprtAsync();
                    break;
                case ReportType.EntryEmp:
                    this.Text = "تقرير سند صرف الموظفين";
                    ReportEntryVchrRcpt rprtEmpVhr = new ReportEntryVchrRcpt();
                    rprtEmpVhr.EntMainEmpVchr(tbEntMain);
                    rprtEmpVhr.EntSubEmpVchr(tbEntSubList);
                    documentViewer1.DocumentSource = rprtEmpVhr;
                    break;
                case ReportType.EmpSalary:
                    this.Text = "كشف مرتبات الموظفين";
                    documentViewer1.DocumentSource = new ReportEmpSalary(true);
                    break;
                case ReportType.EmpSalaryDetail:
                    this.Text = "تقرير مرتبات الموظفين التفصيلي";
                    documentViewer1.DocumentSource = new ReportEmpSalaryDetail();
                    break;
                case ReportType.SalePurchase:
                    this.Text = (status == 1) ? "تقرير المشتريات" : "تقرير المبيعات";
                    documentViewer1.DocumentSource = new ReportSalePurchase(status);
                    break;
                case ReportType.Orders:
                    this.Text = "تقرير الطلبات";
                    documentViewer1.DocumentSource = new ReportOrders();
                    break;
                case ReportType.OrderInvoice:
                    this.Text = "فاتورة طلب";
                    documentViewer1.DocumentSource = new ReportOrderInvoice((tblOrderMain)tblObject, (IEnumerable<tblOrderSub>)tblObjectList, clsTbProduct, clsTbPrdMsur);
                    break;
                case ReportType.Store:
                    this.Text = "تقرير المخازن";
                    documentViewer1.DocumentSource = new ReportStore();
                    break;
                case ReportType.Product:
                    this.Text = "تقرير حركة الأصناف";
                    documentViewer1.DocumentSource = new ReportProduct();
                    break;
                case ReportType.ProductsData:
                    this.Text = "تقرير بيانات الأصناف التفصيلي";
                    documentViewer1.DocumentSource = new ReportProductsData();
                    break;
                case ReportType.StockTrans:
                    this.Text = "تقرير التحويل المخزني";
                    documentViewer1.DocumentSource = new ReportStockTrans(tblObject, tblObjectList as IEnumerable<tblStockTransSub>);
                    break;
                case ReportType.ProductQuanPr:
                    Console.WriteLine("----------------------------InsideReportType");
                    var rprtPrdQuanPr = new ReportProductQuanPr();
                    await rprtPrdQuanPr.InitDataAsync();
                    rprtPrdQuanPr.CreateDocument();
                    documentViewer1.DocumentSource = rprtPrdQuanPr;
                    //var rprtPrdQuanPr = new ReportProductQuanPr();
                    //documentViewer1.DocumentSource = rprtPrdQuanPr;
                    //await rprtPrdQuanPr.InitDataAsync();
                    break;
                case ReportType.TaxDeclaration:
                    this.Text = "تقرير الإقرار الضريبي";
                    documentViewer1.DocumentSource = new ReportTaxDeclaration();
                    break;
                case ReportType.SaleDetail:
                    this.Text = "تقرير المبيعات التفصيلي";
                    var rprtSale = new ReportSaleDetail();
                    documentViewer1.DocumentSource = rprtSale;
                    await rprtSale.InitObjectsAsync();
                    break;
                case ReportType.SaleGroup:
                    this.Text = "تقرير مبيعات المجموعة";
                    documentViewer1.DocumentSource = new ReportSaleGroup();
                    break;
                case ReportType.CustomerDailyEntryDetail:
                    this.Text = "تقرير فواتير العملاء التفصيلي";
                    documentViewer1.DocumentSource = new ReportDailyEntryDetail(reportType);
                    break;
                case ReportType.CustomerSupplierInvDetail:
                    this.Text = (status == 1) ? "تقرير الموردين" : "تقرير العملاء";
                    documentViewer1.DocumentSource = new ReportCustomerSupplierInvDetail(status);
                    break;
                case ReportType.CustomerSupplierBalance:
                    this.Text = (status == 1) ? "تقرير أرصدة العملاء" : "تقرير أرصدة الموردين";
                    documentViewer1.DocumentSource = new ReportCustomerSupplierBalance(status);
                    break;
                case ReportType.CustomerSupplierBalanceBatch:
                    this.Text = (status == 1) ? "تقرير أرصدة العملاء" : "تقرير أرصدة الموردين";
                    documentViewer1.DocumentSource = new ReportCustomerSupplierBalanceBatch(status);
                    break;
            }
        }
        */
    }
}