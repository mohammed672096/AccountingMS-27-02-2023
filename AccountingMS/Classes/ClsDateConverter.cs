using System;

namespace AccountingMS
{
    public class ClsDateConverter
    {
        internal static DateTime ConvertTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        internal static DateTime ConvertTime(object date)
        {
            DateTime dateTmp = Convert.ToDateTime(date);
            return new DateTime(dateTmp.Year, dateTmp.Month, dateTmp.Day, 23, 59, 59);
        }
    }
}
