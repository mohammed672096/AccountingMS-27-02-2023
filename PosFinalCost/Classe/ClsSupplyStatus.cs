using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    public static class ClsSupplyStatus
    {
        public static string GetString(byte Status, byte isCash)
        {
            switch (isCash)
            {
                case 1 when (Status == 3 || Status == 7):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مشتريات نقدا" : "Purchase Invouce";
                case 1 when (Status == 4 || Status == 8):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مبيعات نقدا" : "Sale Invouce";
                case 1 when (Status == 9 || Status == 10):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مشتريات نقدا" : "Purchase Return Invouce";
                case 1 when (Status == 11 || Status == 12):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مبيعات نقدا" : "Sale Return Invouce";
                case 2 when (Status == 3 || Status == 7):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مشتريات آجل" : "Credit Purchase Invouce";
                case 2 when (Status == 4 || Status == 8):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مبيعات آجل" : "Credit Sale Invouce";
                case 2 when (Status == 9 || Status == 10):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مشتريات آجل" : "Credit Purchase Return Invouce";
                case 2 when (Status == 11 || Status == 12):
                    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مبيعات آجل" : "Credit Sale Return Invouce";

                //case 3 when (Status == 3 || Status == 7):
                //    return (!Program.My_Setting.LangEng) ? "فاتورة مشتريات شبكة" : "Card Purchase Invouce";
                //case 3 when (Status == 4 || Status == 8):
                //    return (!Program.My_Setting.LangEng) ? "فاتورة مبيعات شبكة" : "Card Sale Invouce";
                //case 3 when (Status == 9 || Status == 10):
                //    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مشتريات شبكة" : "Card Purchase Return Invouce";
                //case 3 when (Status == 11 || Status == 12):
                //    return (!Program.My_Setting.LangEng) ? "فاتورة مردود مبيعات شبكة" : "Card Sale Return Invouce";
                default:
                    return null;
            }
        }

        public static string GetString(byte Status,bool Simplified=false,bool report1=false)
        {
            string typeInvo = (!Program.My_Setting.LangEng) ? "فاتورة" : "Invouce";
            if (Status == 3 || Status == 7)
                typeInvo += (!Program.My_Setting.LangEng) ? " مشتريات" : "Purchase ";
            else if (Status == 4 || Status == 8)
                typeInvo += (!Program.My_Setting.LangEng) ? " ضريبية" + (Simplified ? " مبسطه" : "") : (Simplified ? "Simplified " : "") + "Tax ";
            else if (Status == 9 || Status == 10)
                typeInvo += (!Program.My_Setting.LangEng) ? " مردود مشتريات" : "Purchase Return ";
            else if (Status == 11 || Status == 12)
                typeInvo += (!Program.My_Setting.LangEng) ? " مردود مبيعات" : "Sale Return ";
            if (!Simplified && report1)
                return (!Program.My_Setting.LangEng) ? typeInvo.Replace("ضريبية", "مبيعات") : typeInvo.Replace("Tax", "Sale");
            return typeInvo;
        }
        
        public static string GetPaymentString(byte? supIsCash)
        {
            if (supIsCash == 1)
                return (!Program.My_Setting.LangEng) ? "نقدا" : "Cash";
            else if (supIsCash == 2)
                return (!Program.My_Setting.LangEng) ? "اجل" : "Credit";
            else //if (supIsCash == 3)
                return (!Program.My_Setting.LangEng) ? "شبكة" : "Card";
        }
    }
}
