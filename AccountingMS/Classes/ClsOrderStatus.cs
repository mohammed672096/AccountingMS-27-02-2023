namespace AccountingMS
{
    class ClsOrderStatus
    {
        //public static string GetString(byte orderStatus) => orderStatus switch
        //{
        //    1 => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersVoucherStr)) ?  "طلب صرف" : MySetting.DefaultSetting.ordersVoucherStr,
        //    2 => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersExecuteStr)) ? "طلب تنفيذ" : MySetting.DefaultSetting.ordersExecuteStr,
        //    3 => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersReceiptStr)) ? "طلب تسليم" : MySetting.DefaultSetting.ordersReceiptStr,
        //    4 =>  "طلب مشتريات",
        //    _ => null
        //};

        public static string GetString(byte orderStatus) => GetString((OrderType)orderStatus);

        public static string GetString(OrderType orderType) => orderType switch
        {
            OrderType.Voucher => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersVoucherStr)) ? "طلب صرف" : MySetting.DefaultSetting.ordersVoucherStr,
            OrderType.Execution => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersExecuteStr)) ? "طلب تنفيذ" : MySetting.DefaultSetting.ordersExecuteStr,
            OrderType.Receipt => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersReceiptStr)) ? "طلب تسليم" : MySetting.DefaultSetting.ordersReceiptStr,
            OrderType.Purchase => "طلب مشتريات",
            OrderType.PriceOffer => "عرض سعر",
            _ => null
        };

        public static string GetStringPlural(byte orderStatus) => (OrderType)orderStatus switch
        {
            OrderType.Voucher => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersVoucherStrPlu)) ? "طلبات الصرف" : MySetting.DefaultSetting.ordersVoucherStrPlu,
            OrderType.Execution => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersExecuteStrPlu)) ? "طلبات التنفيذ" : MySetting.DefaultSetting.ordersExecuteStrPlu,
            OrderType.Receipt => (string.IsNullOrWhiteSpace(MySetting.DefaultSetting.ordersReceiptStrPlu)) ? "طلبات التسليم" : MySetting.DefaultSetting.ordersReceiptStrPlu,
            OrderType.Purchase => "طلبات المشتريات",
            OrderType.PriceOffer => "عروض الاسعر",
            _ => null
        };
    }
}
