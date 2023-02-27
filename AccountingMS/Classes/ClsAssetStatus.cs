namespace AccountingMS
{
    public static class ClsAssetStatus
    {
        public static string GetString(AssetType asStatus)
        {
            switch (asStatus)
            {
                case AssetType.OpnAccount:
                    return "رصيد إفتتاحي";
                case AssetType.EntDaiy:
                    return "قيد يومي";
                case AssetType.EntVoucher:
                    return "سند صرف";
                case AssetType.EntReceipt:
                    return "سند قبض";
                case AssetType.SupPurchase:
                    return "فاتورة مشتريات";
                case AssetType.SupSales:
                    return "فاتورة مبيعات";
                case AssetType.SupPurchaseRtrn:
                    return "فاتورة مردود مشتريات";
                case AssetType.SupSalesRtrn:
                    return "فاتورة مردود مبيعات";
                case AssetType.EntEmpVoucher:
                    return "سند صرف الموظفين";
                case AssetType.PrdQuanOpn:
                    return "رصيد إفتتاحي مخازن";
                case AssetType.EntEmpVchrTip:
                    return "سند صرف إكراميات الموظفين";
                case AssetType.EntEmpVchrOvrTm:
                    return "سند صرف اضافي الموظفين";
                case AssetType.PrdExpirate:
                    return "تسوية اصناف تالفة";
                case AssetType.InvSettlement:
                    return "قيد مخزنية";
                case AssetType.UnderSettlement:
                    return "قيد تسوية";
                case AssetType.CloseDailyBox:
                    return "اغلاق يومية صندوق";
                default:
                    return null;
            }
        }
    }
}
