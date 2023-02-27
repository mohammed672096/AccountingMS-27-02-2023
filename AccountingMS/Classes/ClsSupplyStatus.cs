using System.Collections.Generic;

namespace AccountingMS
{
    public static class ClsSupplyStatus
    {
        public static string GetString(byte supStatus, byte isCash)
        {
            switch (isCash)
            {
                case 1 when (supStatus == 3 || supStatus == 7):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مشتريات نقدا" : "Purchase Invouce";
                case 1 when (supStatus == 4 || supStatus == 8):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مبيعات نقدا" : "Sale Invouce";
                case 1 when (supStatus == 9 || supStatus == 10):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات نقدا" : "Purchase Return Invouce";
                case 1 when (supStatus == 11 || supStatus == 12):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مبيعات نقدا" : "Sale Return Invouce";
                case 2 when (supStatus == 3 || supStatus == 7):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مشتريات آجل" : "Credit Purchase Invouce";
                case 2 when (supStatus == 4 || supStatus == 8):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مبيعات آجل" : "Credit Sale Invouce";
                case 2 when (supStatus == 9 || supStatus == 10):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات آجل" : "Credit Purchase Return Invouce";
                case 2 when (supStatus == 11 || supStatus == 12):
                    return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مبيعات آجل" : "Credit Sale Return Invouce";
                default:
                    return "";
            }
        }
        public static string GetMoveString(byte supStatus)
        {
            if (supStatus == 3 || supStatus == 7)
                return (!MySetting.GetPrivateSetting.LangEng) ? "مشتريات" : "Purchase";
            else if (supStatus == 4 || supStatus == 8)
                return (!MySetting.GetPrivateSetting.LangEng) ? "مبيعات" : "Sale";
            else if (supStatus == 9 || supStatus == 10)
                return (!MySetting.GetPrivateSetting.LangEng) ? "مردود مشتريات" : "Purchase Return";
            else if (supStatus == 11 || supStatus == 12)
                return (!MySetting.GetPrivateSetting.LangEng) ? "مردود مبيعات" : "Sale Return";
            return "";
        }

        public static string GetString(byte supStatus)
        {
            if (supStatus == 3 || supStatus == 7)
                return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مشتريات" : "Purchase Invouce";
            else if (supStatus == 4 || supStatus == 8)
                return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مبيعات" : "Sale Invouce";
            else if (supStatus == 9 || supStatus == 10)
                return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات" : "Purchase Return Invouce";
            else if (supStatus == 11 || supStatus == 12)
                return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مبيعات" : "Sale Return Invouce";
            else if (supStatus == 21)
                return (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات فورية" : "Direct Purchase Return Invouce";

            return "";
        }
        public static List<ValueAndID> InvoicePurTypesList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)DocType.Buy , Name  =GetString((byte)DocType.Buy) },
                new ValueAndID() { ID = (byte)DocType.BuyRtrn  , Name  =GetString((byte)DocType.BuyRtrn) },
        };
        public static List<ValueAndID> InvoiceSaleTypesList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)DocType.Sale  , Name  =GetString((byte)DocType.Sale) },
                new ValueAndID() { ID = (byte)DocType.SaleRtrn  , Name  =GetString((byte)DocType.SaleRtrn) },
        };
        public static List<ValueAndID> PayMethodsList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)PayMethods.Cash , Name  =MySetting.GetPrivateSetting.LangEng?"Cash":"نقدا" },
                new ValueAndID() { ID = (byte)PayMethods.Credit , Name  =MySetting.GetPrivateSetting.LangEng?"Credit":"اجل" },

        }; 
        public static List<ValueAndID> TarhilsList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)PhasedState.Phased , Name  =MySetting.GetPrivateSetting.LangEng?"Phased":"مرحلة" },
                new ValueAndID() { ID = (byte)PhasedState.unPhased , Name  =MySetting.GetPrivateSetting.LangEng?"Un Phased":"غير مرحلة" },
                  new ValueAndID() { ID = (byte)PhasedState.All , Name  =MySetting.GetPrivateSetting.LangEng?"All":"الكل" },
        };
        public static List<ValueAndID> ReportTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)ReportSize.General , Name  =MySetting.GetPrivateSetting.LangEng?"General":"عام" },
                new ValueAndID() { ID = (byte)ReportSize.Detailed , Name  =MySetting.GetPrivateSetting.LangEng?"Detailed":"تفصيلي" },
                //new ValueAndID() { ID = (byte)PayMethods.Carde , Name  ="شبكه" }
        };
        public static string GetPaymentString(byte? supIsCash)
        {
            if (supIsCash == 1)
                return (!MySetting.GetPrivateSetting.LangEng) ? "نقدا" : "Cash";
            else
                return (!MySetting.GetPrivateSetting.LangEng) ? "اجل" : "Credit";
        }
    }
}
