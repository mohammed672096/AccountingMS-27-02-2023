using System;
using System.ComponentModel;
using System.Linq;

namespace accounting_1._0
{
    class ClsTaxAccounts
    {
        accountingEntities2 db = new accountingEntities2();
        BindingList<tblTaxAccount> tbTaxAccountList = new BindingList<tblTaxAccount>();

        public long taxAccNo { get; set; }
        public string taxAccName { get; set; }

        public ClsTaxAccounts()
        {
            InitData();
        }

        private void InitData()
        {
            var tbTaxAccounts = db.tblTaxAccounts.ToList();
            foreach (var tTaxAccount in tbTaxAccounts)
                this.tbTaxAccountList.Add(tTaxAccount);
        }


        public void EntryTaxAcc()
        {
            foreach (var tbTaxAccount in this.tbTaxAccountList)
            {
                if (tbTaxAccount.taxStatus == 1)
                {
                    this.taxAccNo = Convert.ToInt64(tbTaxAccount.taxAccNo);
                    this.taxAccName = tbTaxAccount.taxAccName;
                    break;
                }
            }
        }

        public void PurchaseTaxAcc()
        {
            foreach (var tbTaxAccount in this.tbTaxAccountList)
            {
                if (tbTaxAccount.taxStatus == 4)
                {
                    this.taxAccNo = Convert.ToInt64(tbTaxAccount.taxAccNo);
                    this.taxAccName = tbTaxAccount.taxAccName;
                    break;
                }
            }
        }

        public void SaleTaxAcc()
        {
            foreach (var tbTaxAccount in this.tbTaxAccountList)
            {
                if (tbTaxAccount.taxStatus == 5)
                {
                    this.taxAccNo = Convert.ToInt64(tbTaxAccount.taxAccNo);
                    this.taxAccName = tbTaxAccount.taxAccName;
                    break;
                }
            }
        }
    }
}
