using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace AccountingMS
{
    public enum AssetType
    {
        [Description("رصيد افتتاحي")]
        OpnAccount = 1,
        [Description("قيد يومي")]
        EntDaiy = 2,
        [Description("سند قبض")]
        EntVoucher = 3,
        [Description("سند صرف")]
        EntReceipt = 4,
        [Description("فاتورة مشتريات")]
        SupPurchase = 5,
        [Description("فاتورة مبيعات")]
        SupSales = 6,
        [Description("فاتورة مردود مشتريات")]
        SupPurchaseRtrn = 7,
        [Description("فاتورة مردود مبيعات")]
        SupSalesRtrn = 8,
        EntEmpVoucher = 9,
        PrdQuanOpn = 10,
        EntEmpVchrTip = 11,
        EntEmpVchrOvrTm = 12,
        [Description("تسوية اصناف تالفة")]
        PrdExpirate = 13,
        [Description("تسوية عجز يومية صندوق")]
        InvSettlement = 14,
        [Description("قيد تسوية")]
        UnderSettlement = 15,
        [Description("اغلاق يومية صندوق")]
        CloseDailyBox = 16,
    }
    public enum PrintFileType
    {
        Printer = 1,
        PDF,
        Xlsx
    }
    public enum PrintMode
    {
        Direct = 1,
        ShowPreview,
    }
    public enum DocType
    {
        Buy = 3,
        Sale = 4,
        BuyRtrn = 9,
        SaleRtrn = 11,
    }
    public enum ReportSize
    {
        General = 1,
        Detailed
    }
    public enum PayMethods
    {
        Cash = 1,
        Credit,
    }
    public enum PhasedState
    {
        Phased = 1,
        unPhased = 2,
        All = 3,
    }
    public enum ReportSaleModel
    {
        [Description("تقرير المبيعات")]
        SaleAndPur = 1,
        [Description("تقرير المبيعات كاشير")]
        SaleCasher,
        [Description("تقرير المبيعات التفصيلية")]
        SaleDetail,
        [Description("تقرير مبيعات المجموعات المخزنية")]
        SaleGroupSt,
        [Description("تقرير مبيعات المجموعات المخزنية رول")]
        SaleGroupStRoll,
        [Description("تقرير مبيعات الفروع")]
        BranchSale,
        [Description("تقرير مبيعات المستخدمين")]
        SaleUser,
        [Description("تقرير اجمالي المبيعات")]
        SaleTotal,
    }
    public enum DefaultTaxAccType
    {
        [Description("حساب ضريبة القيود")]
        TaxEntry = 1,
        [Description("حساب ضريبة سندات الصرف")]
        TaxEntVocher,
        [Description("حساب ضريبة سندات القبض")]
        TaxEntRecipt,
        [Description("حساب ضريبة المشتريات")]
        TaxPurchase,
        [Description("حساب ضريبة المبيعات")]
        TaxSale
    }
    public enum DiscountType
    {
        OnProduct = 0,
        OnInvoice = 1,
        OnCustomer=2,
        Coupon = 3,
    }
    public enum ReportCustomType
    {
        A4 = 1,
        Chasier = 2,
        Entry = 3,
        EntryVoucher,
        EntryReceipt,
    }
    public enum WarningLevels
    {
        DoNotEnteript = 1,
        ShowWarning = 2,
        Prevent = 3,
    }
    public enum EntryType
    {
        DailyEntry = 1,
        EntryVoucher = 2,
        EntryReceipt = 3,
        EntryPhased = 4,
        EntryVoucherPhased = 5,
        EntryReceiptPhased = 6,
        EmpVoucher = 7,
        EmppVoucherPhased = 8,
        EmpVoucherTip = 9,
        EmpVoucherTipPhased = 10,
        EmpVoucherOvrTm = 11,
        EmpVoucherOvrTmPhased = 12,
        EmpVoucherPhasedAll
    }

    public enum EntryPhased
    {
        Entry,
        EntryEmp
    }
    public enum TransactionType
    {
        [Display(Name = "رصيد افتتاحي لمخزون")]
        OpenBalance =1,
        [Display(Name = "اصناف تالفة")]
        ProductDamage = 2,
        [Display(Name = "فاتوره شراء")]
        Purchase = SupplyType.Purchase,
        [Display(Name = "فاتوره مردود شراء")]
        PurchaseReturn = SupplyType.PurchaseRtrn,
        [Display(Name = "فاتوره  مبيعات")]
        Sales = SupplyType.Sales,
        [Display(Name = "فاتوره مردود مبيعات")]
        SalesReturn = SupplyType.SalesRtrn,
        [Display(Name = "تحويل مخزني")]
        StockTransfer =5,
        [Display(Name = "جرد مخزني")]
        StockBalanceCorrection = 6,

    } 
    public enum ProductTransactionType
    {
        [Display(Name = "وارد")]
        In,
        [Display(Name = "منصرف")]
        Out,
    }
    public enum CostCalculationMethod
    {
        [Display(Name = "الوارد أولاً صادر أولاً")]
        FIFO,
        [Display(Name = "الوارد أخيراً صادر أولاً")]
        LIFO,
        [Display(Name = "المتوسط المرجح")]
        Average,
    }
    public enum SupplyType
    {
        Default = -1,
        Purchase = 3,
        PurchaseDel = 15,
        PurchaseRtrn = 9,
        PurchaseRtrnDel = 16,
        PurchasePhase = 7,
        PurchasePhaseRtrn = 10,
        PurchasePhaseAll = 13,
        Sales = 4,
        SalesDel = 17,
        SalesRtrn = 11,
        SalesRtrnDel = 18,
        SalesPhase = 8,
        SalesPhaseRtrn = 12,
        SalesPhaseAll = 14,
        SalesAll = 19,
        DirectSalesRtrn,
        DirectPurchaseRtrn,
        AllSupply,
        AllPhase
    }

    public enum PrdTracking
    {
        Purchase = 1,
        PurchaseRtrn = 2,
        Sale = 3,
        SaleRtrn = 4,
        Opn = 5,
        Exp = 6,
        TransOut = 7,
        TransIn = 8,
        Inv = 9,
    }

    public enum OrderType
    {
        Voucher = 1,
        Execution = 2,
        Receipt = 3,
        Purchase = 4,
        PriceOffer = 5,
    }

    public enum DefaultAccType
    {
        Customer = 1,
        Supplier = 2,
        Box = 3,
        Bank = 4,
        Employee = 5,
        GrpAcc = 6,
        GrpAccSale = 7,
        GrpAccSaleCost = 8,
        GrpAccSaleRtrn = 9,
        GrpAccSaleRtrnCost = 10,
        GrpAccDiscount = 11,
        GrpAccPurchase = 14,
        GrpAccPurchaseRtrn = 15,
        PrdExpirateAcc = 12,
        Representative = 13
    }

    public enum InvType
    {
        Manual = 1,
        Direct = 2,
        Settlement = 3
    }

    public enum NotStatus
    {
        Sales = 1,
        EntRcpt = 2
    }

    public enum BarcodeSettings
    {
        CompanyName = 1,
        BarcodeNo = 2,
        ProductName = 3,
        Price = 4,
        ExpireDate = 5,
        PageWidth = 6,
        OtherInfo = 7,
    }

    public enum ReportType
    {
        SupplyA4 = 4,
        SupplyChasier = 5,
        Entry,
        EntryVoucher,
        EntryVoucherInv,
        EntryReceipt,
        EntryReceiptInv,
        EmpVchrExtraInv,
        EmpVchrTip,
        EmpVchrOvrTm,
        SupplyCustom,
        SupplyTarhel,
        AccountBill,
        Suppliers,
        BalanceSheet1,
        BalanceSheet2,
        Store,
        StoreProducts,
        ProductsData,
        StockTrans,
        ProductQuan,
        PrdQuanOpn,
        PrdQuanTrack,
        InvStoreManual,
        InvStoreDirect,
        InvStoreSettlement,
        DailyEntry,
        DailyEntryDetail,
        EntryEmp,
        EmpSalary,
        EmpSalaryDetail,
        SalePurchase,
        Product,
        TaxDeclaration,
        SaleDetail,
        SaleGroup,
        SaleCashier,
        Orders,
        OrderInvoice,
        CustomerDailyEntryDetail,
        CustomerSupplierInvDetail,
        CustomerSupplierBalance,
        CustomerSupplierBalanceBatch,
        SalesWithTax,
        PurchaseWithTax,
        GeneralLedger,
        SaleGroupRoll,
        SaleGroupWithoutProfit,
        SaleUserWithoutProfit,
        CustomerSupplierBalanceBatchFy,
        SupplyCashierCustom,
        ProductQuanAndAvPr,
        OrderCustom,
        AllSale,
        PrdExpirate
    }

    public enum UserControls
    {
        Branch = 1,
        Users = 2,
        Accounts = 3,
        Currency = 4,
        Box = 5,
        Bank = 6,
        Customers = 7,
        Suppliers = 8,
        OpeningAccounts = 9,
        Employees = 10,
        EmployeesVoucher = 11,
        Entries = 12,
        EntryVoucer = 13,
        EntryRcpt = 14,
        EntryPhased = 15,
        EntryAll = 16,
        Store = 17,
        StoreProducts = 18,
        StockTrans = 19,
        ProductData = 20,
        ProductQuant = 21,
        Purchase = 22,
        PurchaseRtrn = 23,
        PurchasePhased = 24,
        Sale = 25,
        SaleRtrn = 26,
        SalePhased = 27,
        OrderVoucher = 28,
        OrderExecution = 29,
        OrderReceipt = 30,
        TaxDecaration = 31,
        FinancialYear = 32,
        DefaultSettings = 33,
        ControlPanel = 34,
        Reports = 35,
        OfferPrice = 36,
        ExpiredProducts=37,
        DefaultAccount = 38,
        Representative,
        OpenBoxDaily,
        CloseBoxDaily,
        ReviewBoxDaily,
        AccountsBalance,
        EmpVchrTip,
        EmpVchrOvrTm,
        EmoVchrPhased,
        PrdQuanTracking,
        PrdExpirateQuan,
        InvStoreManual,
        InvStoreDirect,
        InvStoreSettlement,
        PurchaseDel,
        PurchaseRtrnDel,
        SaleDel,
        SaleRtrnDel,
        PurchaseOrders,
        RprtAdminReport,
        FixedAsset,
        EmpSetting = 39,
    }

    public enum ProductType
    {
        Mechinary = 1,
        Service = 2,
        WeightBarcode = 3,
        Manufacture = 4,
        ManWeight = 5
    }

    public enum SalePrice
    {
        PurchasePrice = 1,
        SalePrice = 2,
        MinSalePrice = 3,
        RetailPrice = 4,
        BatchPrice = 5
    }

    public enum SalePriceAr
    {
        [Description("سعر الشراء")]
        PurchasePrice = 1,
        [Description("سعر البيع")]
        SalePrice = 2,
        [Description("سعر البيع الأدنى")]
        MinSalePrice = 3,
        [Description("سعر التجزيئة")]
        RetailPrice = 4,
        [Description("سعر الجملة")]
        BatchPrice = 5
    }

    public enum SalePriceEn
    {
        [Description("Purchase Price")]
        PurchasePrice = 1,
        [Description("Sale Price")]
        SalePrice = 2,
        [Description("Min Sale Price")]
        MinSalePrice = 3,
        [Description("Retail Price")]
        RetailPrice = 4,
        [Description("Batch Price")]
        BatchPrice = 5
    }

    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());

            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
            }
            return GenericEnum.ToString();
        }
        public static IList ToListEnum(this Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
                list.Add(new KeyValuePair<byte, string>(Convert.ToByte(value), GetDescription(value)));

            return list;
        }
    }
}
