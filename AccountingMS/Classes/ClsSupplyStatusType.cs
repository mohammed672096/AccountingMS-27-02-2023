using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_1._0
{
    class ClsSupplyStatusType
    {
        public string StatusType(byte supStatus, byte isCash)
        {
            string strgStatusType = null;

            switch(isCash)
            {
                case 1 when (supStatus == 3 || supStatus == 7):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مشتريات نقدا" : "Purchase Invouce";
                    break;
                case 1 when (supStatus == 4 || supStatus == 8):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مبيعات نقدا" : "Sale Invouce";
                    break;
                case 1 when (supStatus == 9 || supStatus == 10):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مردود مشتريات نقدا" : "Purchase Return Invouce";
                    break;
                case 1 when (supStatus == 11 || supStatus == 12):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مردود مبيعات نقدا" : "Sale Return Invouce";
                    break;
                case 2 when (supStatus == 3 || supStatus == 7):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مشتريات آجل" : "Credit Purchase Invouce";
                    break;
                case 2 when (supStatus == 4 || supStatus == 8):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مبيعات آجل" : "Credit Sale Invouce";
                    break;
                case 2 when (supStatus == 9 || supStatus == 10):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مردود مشتريات آجل" : "Credit Purchase Return Invouce";
                    break;
                case 2 when (supStatus == 11 || supStatus == 12):
                    strgStatusType = (!Properties.Settings.Default.langEng) ? "فاتورة مردود مبيعات آجل" : "Credit Sale Return Invouce";
                    break;
            }

            return strgStatusType;
        }
    }
}
