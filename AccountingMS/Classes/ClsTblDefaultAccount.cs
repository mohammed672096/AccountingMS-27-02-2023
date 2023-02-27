using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace AccountingMS
{
    class ClsTblDefaultAccount
    {
        public static List<tblDefaultAccount> tbDefaultAccountList = new List<tblDefaultAccount>();
        public static void GetDataDefaultAccount()
        {
            using (var db = new accountingEntities())
            {
                //if (Session.CurrentUser.id == 1)
                //    tbDefaultAccountList = db.tblDefaultAccounts.AsNoTracking().ToList();
                //else
                    tbDefaultAccountList = db.tblDefaultAccounts.AsNoTracking().Where(x => x.dfltBrnId == Session.CurBranch.brnId).ToList();
                tbTaxAccountList = db.tblTaxAccounts.AsNoTracking().ToList();
            }
        }
        public ClsTblDefaultAccount()
        {
                GetDataDefaultAccount();
        }

        public bool IsDefaultAccFound(byte dflAccStatus) => tbDefaultAccountList.Any(x => x.dflStatus == dflAccStatus);

        public IList<tblDefaultAccount> GetTblDefaultAccountsList => tbDefaultAccountList;

        public bool IsDefaultAccFound(byte dflAccStatus, short branch) => tbDefaultAccountList.Any(x => x.dflStatus == dflAccStatus && x.dfltBrnId == branch);

        public tblDefaultAccount GetDefaultAccByStatus(byte status) => tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == status);

        public int GetDefaultAccIdByType(DefaultAccType defaultAccount) => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == (byte)defaultAccount)?.dflAccNo) ?? 0;

        public int GetCustomerAccNoId() => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == 1)?.dflAccNo) ?? 0;

        public int GetDefultAccNoId(byte Status, short BrnId) => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == Status && x.dfltBrnId == BrnId)?.dflAccNo) ?? 0;

        public int GetSupplierAccNoId() => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == 2)?.dflAccNo) ?? 0;
        public int GetBoxAccNoId(short BranId) => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == 3 & x.dfltBrnId == BranId)?.dflAccNo) ?? 0;

        public int GetBankAccNoId() => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == 4)?.dflAccNo) ?? 0;

        public int GetEmpAccNoId() => (tbDefaultAccountList?.FirstOrDefault(x => x.dflStatus == 5)?.dflAccNo) ?? 0;
        public static List<tblTaxAccount> tbTaxAccountList = new List<tblTaxAccount>();
    }
}
