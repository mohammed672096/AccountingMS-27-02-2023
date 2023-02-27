using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    class ClsThreadCulture
    {
        private static CultureInfo _culture = null;

        public static CultureInfo CurrentCulture
        {
            set { if (_culture == null) _culture = value; }
            get { return _culture; }
        }

        public static void ChangeCultureEn()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-En");
        }

        public static void ChangeCultureDefault()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-AR");
        }
    }
}
