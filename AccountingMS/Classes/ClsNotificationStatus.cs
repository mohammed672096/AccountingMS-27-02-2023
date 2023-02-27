namespace AccountingMS
{
    public static class ClsNotificationStatus
    {
        public static string GetString(byte status)
        {
            return status switch
            {
                1 => "فاتورة مبيعات آجل",
                _ => null
            };
        }
    }
}
