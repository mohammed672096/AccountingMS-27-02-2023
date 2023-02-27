namespace accounting_1._0
{
    class ClsEntryType
    {
        public string GetEntryType(byte type, byte val)
        {
            string entryType = null;

            if (type == 1)
            {
                if (val == 1 || val == 4)
                    entryType = "قيد يومي";
                else if (val == 2 || val == 5)
                    entryType = "سند صرف";
                else if (val == 3 || val == 6)
                    entryType = "سند قبض";
            }
            else if (type == 2)
            {
                if (val == 1 || val == 5)
                    entryType = "توريد مخزني";
                else if (val == 2 || val == 6)
                    entryType = "صرف مخزني";
                else if (val == 3 || val == 7)
                    entryType = "فاتورة مشتريات";
                else if (val == 4 || val == 8)
                    entryType = "فاتورة مبيعات";
                else if (val == 9 || val == 10)
                    entryType = "مردود مشتريات";
                else if (val == 11 || val == 12)
                    entryType = "مردود مبيعات";
            }

            return entryType;
        }
    }
}
