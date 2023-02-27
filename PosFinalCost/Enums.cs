using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace PosFinalCost
{
    
    public enum InvoiceType
    {
        Purchase = SourceTypes.Purchase,
        Sales = SourceTypes.Sales,
        PurchaseReturn = SourceTypes.PurchaseReturn,
        SalesReturn = SourceTypes.SalesReturn,
    }


    public enum SourceTypes
    {
        Purchase,
        Sales,
        PurchaseReturn,
        SalesReturn,
    }
    public enum ReportCustomType
    {
        A4 = 1,
        Chasier = 2,
        Entry = 3,
        EntryVoucher,
        EntryReceipt,
    }
    public enum CostDistributionOptions
    {
        ByPrice,
        ByQty,
    }
    public enum EntryType
    {
        DailyEntry = 1,
        EntryVoucher = 2,
        EntryReceipt = 3,
        EntryPhased = 4,
        EntryVoucherPhased = 5,
        EntryReceiptPhased = 6,
    }

    public enum EntryPhased
    {
        Entry,
        EntryEmp
    }

    public  enum SupplyType
    {
        Default = -1,
        Purchase = 3,
        PurchaseDel = 15,
        PurchaseRtrn = 9,
        PurchaseRtrnDel = 16,
        Sales = 4,
        SalesDel = 17,
        SalesRtrn = 11,
        SalesRtrnDel = 18,
    }
    public enum PrintPaperType
    {
        Cashier = 1,
        A4,
    }
    public enum PrintFileType
    {
        Printer = 1,
        PDF,
        Xlsx
    }
    public enum PayMethods
    {
        Cash = 1,
        Credit,
        Carde
    }
    public enum ReadModeType
    {
        Price = 1,
        Weight,
    }
    public enum PrintMode
    {
        Direct = 1,
        ShowPreview,
    }
    public enum UserType
    {
        Admin = 1,
        User,
    }
    public enum LanguagType
    {
        Arabic = 1,
        English,
    }
    public enum WarningLevels
    {
        DoNotEnteript = 1,
        ShowWarning = 2,
        Prevent = 3,
    }
    public enum Actions
    {
        Show = 1,
        Open,
        Add,
        Edit,
        Delete,
        Print,
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
        DefaultSettings = 1,
        PermissionManagement = 2,
        LinkingUserPermissions = 3,
        DataExchange = 4,
        Sale = 5,
        SaleRtrn = 6,
        Customers = 7,
        PrintBarcode = 8,
        ExpiredProducts = 9,
        Entries = 12,
        EntryVoucer = 13,
        EntryRcpt = 14,
        Store = 17,
        StoreProducts = 18,
        StockTrans = 19,
        ProductData = 20,
        ProductQuant = 21,
        OrderVoucher = 28,
        OrderExecution = 29,
        OrderReceipt = 30,
        TaxDecaration = 31,
        FinancialYear = 32,
        ControlPanel = 34,
        Reports = 35,
        OfferPrice = 36,
     
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
