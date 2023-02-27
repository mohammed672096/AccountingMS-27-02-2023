using DevExpress.XtraEditors;
using System;
using System.Data.Entity;
using System.Linq;

namespace accounting_1._0
{
    class ClsEntry
    {
        accountingEntities2 db = new accountingEntities2();

        public bool DeleteEntry(int entNo, int boxNo, byte status)
        {
            db.tblEntrySubs.Load();
            var tbEntrySub = from a in db.tblEntrySubs.Local
                             where a.entBrnId == ClsBranchId.BranchId && (a.entDate >= ClsFinancialYear.FyDtStart && a.entDate <= ClsFinancialYear.FyDtEnd) && a.entNo == entNo && a.entStatus == status
                             select a;
            bool isDelete = false;

            foreach (var entSub in tbEntrySub)
            {
                if (status == 1)
                {
                    if (entSub.entNo == entNo)
                        db.tblEntrySubs.Remove(entSub);
                }
                else
                {
                    if (entSub.entNo == entNo && entSub.entBoxNo == boxNo)
                        db.tblEntrySubs.Remove(entSub);
                }
            }

            if (SaveDB()) isDelete = true;
            return isDelete;
        }

        private bool SaveDB()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
