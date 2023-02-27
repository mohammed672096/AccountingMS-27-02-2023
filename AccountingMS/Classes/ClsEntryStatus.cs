namespace AccountingMS
{
    public static class ClsEntryStatus
    {
        public static string GetString(byte status)
        {
            if (status == 1 || status == 4)
                return (!MySetting.GetPrivateSetting.LangEng) ? "قيد يومي" : "Daily Entry";
            else if (status == 2 || status == 5)
                return (!MySetting.GetPrivateSetting.LangEng) ? "سند صرف" : "Entry Voucher";
            else if (status == 3 || status == 6)
                return (!MySetting.GetPrivateSetting.LangEng) ? "سند قبض" : "Entry Receipt";
            else if (status == 7 || status == 8)
                return (!MySetting.GetPrivateSetting.LangEng) ? "مرتبات الموظفين" : "Employees Payement";
            else if (status == 9 || status == 10)
                return (!MySetting.GetPrivateSetting.LangEng) ? "إكراميات الموظفين" : "Employees Tip";
            else if (status == 11 || status == 12)
                return (!MySetting.GetPrivateSetting.LangEng) ? "إضافي مرتبات الموظفين" : "Employees Over Time";

            return null;
        }
    }
}
