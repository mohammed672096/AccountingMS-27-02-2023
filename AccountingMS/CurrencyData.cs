using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_1._0
{
    class CurrencyData
    {
        accountingEntities2 db = new accountingEntities2();

        public string CurrName (Int16 currId)
        {
            var tblCurr = db.tblCurrencies.ToList();
            string name = null;

            foreach (var currency in tblCurr)
            {
                if (currency.id == currId)
                {
                    name = currency.curName;
                    break;
                }
            }
            return name;
        }

        public Int16 currChange (Int16 currNo)
        {
            var tblCurr = db.tblCurrencies.ToList();
            Int16 change = 0;
            
            foreach (var curr in tblCurr)
            {
                if (curr.id == currNo)
                {
                    change = Convert.ToInt16(curr.curChange);
                    break;
                }
            }
            return change;
        }

        public Int16 GetCurrency(Int64 accNo)
        {
            Int16 curr = 0;
            var tblAccount = db.tblAccounts.ToList();
            foreach (var currency in tblAccount)
            {
                if (currency.accNo == accNo)
                {
                    curr = Convert.ToInt16(currency.accCurrency);
                    break;
                }
            }
            return curr;
        }

        public string GetCurrencyNameByAccNo(Int64 accNo)
        {
            var tblAccunt = db.tblAccounts.ToList();
            var tblCurrency = db.tblCurrencies.ToList();
            string curNameStr = "beforeLoop";

            foreach (var account in tblAccunt)
            {
                if (account.accNo == accNo)
                {
                    foreach (var currency in tblCurrency)
                    {
                        if (currency.id == account.accCurrency)
                        {
                            curNameStr = currency.curName;
                            break;
                        }
                    }
                    break;
                }
            }
            return curNameStr;
        }

    }
}
