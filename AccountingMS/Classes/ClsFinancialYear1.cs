using System;

namespace AccountingMS
{
    class ClsFinancialYear1
    {
        private static int _fyId;
        private static DateTime _dtStart;
        private static DateTime _dtEnd;

        public static int FyId
        {
            set { if (_fyId == 0) _fyId = value; }
            get { return _fyId; }
        }

        public static DateTime FyDtStart
        {
            set { if (_dtStart == new DateTime(0001, 01, 01)) _dtStart = value; }
            get { return _dtStart; }
        }

        public static DateTime FyDtEnd
        {
            set { if (_dtEnd == new DateTime(0001, 01, 01)) _dtEnd = value; }
            get { return _dtEnd; }
        }
    }
}
