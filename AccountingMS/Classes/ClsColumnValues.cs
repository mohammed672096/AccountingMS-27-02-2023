namespace AccountingMS
{
    class ClsColumnValues
    {
        public string CotCat(byte val)
        {
            if (val == 1)
                return "أصول";
            if (val == 2)
                return "خصوم";
            if (val == 3)
                return "مصروفات";
            if (val == 4)
                return "إرادات";

            return null;
        }

        public string ColStatus(byte val)
        {
            string s = null;
            if (val == 1)
                s = "مدين";
            if (val == 2)
                s = "دائن";

            return s;
        }
        public string ColType(byte val)
        {
            if (val == 1)
                return "رئيسي";
            if (val == 2)
                return "فرعي";

            return null;
        }

        public string CurType(byte val)
        {
            if (val == 1)
                return "رئيسي";
            if (val == 2)
                return "أجنبي";
            return null;
        }

    }

}
