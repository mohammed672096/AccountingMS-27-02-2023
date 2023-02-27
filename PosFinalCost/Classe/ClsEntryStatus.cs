namespace PosFinalCost
{
    public static class ClsEntryStatus
    {
        public static string GetString(EntryType status)
        {
            switch (status)
            {
                case EntryType.DailyEntry:
                    return (!Program.My_Setting.LangEng) ? "قيد يومي" : "Daily Entry";
                case EntryType.EntryVoucher:
                    return (!Program.My_Setting.LangEng) ? "سند صرف" : "Entry Voucher";
                case EntryType.EntryReceipt:
                    return (!Program.My_Setting.LangEng) ? "سند قبض" : "Entry Receipt";
                default:
                    break;
            }
            return null;
        }
    }
}
