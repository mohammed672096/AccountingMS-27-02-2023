using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblBank
    {
        public ClsTblBank()
        {
            if (Session.Banks.Count <= 0)
                Session.GetDataBanks();
        }

        protected internal long GetBankAccNoById(int bankId)
        {
            return Session.Banks.Where(x => x.id == bankId).Select(x => x.bankAccNo).FirstOrDefault();
        }

        protected internal string GetBankAccNameById(int bankId)
        {
            return Session.Banks.Where(x => x.id == bankId).Select(x => x.bankName).FirstOrDefault();
        }
        public string GetBankNameByAccNo(long accNo)
        {
            if (accNo <= 0) return default;
            return Session.Banks.Where(x => x.bankAccNo == accNo).Select(x => x.bankName).FirstOrDefault();
        }
        public void RefreshData()
        {
            Session.GetDataBanks();
        }

        public IEnumerable<tblAccountBank> GetTblBankList => Session.Banks;

        public bool Delete(tblAccountBank tbBank)
        {
            using (var db = new accountingEntities())
            {
                var bank = db.tblAccountBanks.FirstOrDefault(x => x.id == tbBank.id);
                db.tblAccountBanks.Remove(bank);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.Banks.Remove(bank);
                    return true;
                }
                return false;
            }
        }

        public void InitBankLookupEdit(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            boxLookupEdit.Properties.Appearance.Options.UseTextOptions = true;
            boxLookupEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("bankNo", "رقم البنك", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("bankName", "إسم البنك", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Banks.Where(x => x.bankBrnId == Session.CurBranch.brnId);

            boxLookupEdit.Properties.DisplayMember = "bankName";
            boxLookupEdit.Properties.ValueMember = "id";
            boxLookupEdit.Properties.NullText = "";
        }


    }
}
