using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    class ClsTblFinancialYear
    {
        public ClsTblFinancialYear()
        {
            Session.GetDataFinancialYears();
        }

        public void RefreshData() => Session.GetDataFinancialYears();
        public List<tblFinancialYear> GetFinancialYearListByBrnId(short brnId) => Session.tblFinancialYear.Where(x => x.fyBranchId == brnId).ToList();
        internal string GetFinancialYearNameById(int fyId) => Session.tblFinancialYear.Find(x => x.fyId == fyId).fyName;
        internal tblFinancialYear GetFinancialYearObjById(int fyId) => Session.tblFinancialYear?.FirstOrDefault(x => x.fyId == fyId);

        internal tblFinancialYear GetDefaultFinancialYearObj() => Session.tblFinancialYear.FirstOrDefault(x => x.fyStatus);
        internal int GetDefaultFinancialYearId() => (Session.tblFinancialYear?.FirstOrDefault(x => x.fyStatus)?.fyId) ?? 0;
        internal bool UpdateDefaultFinancialYear(tblFinancialYear tbFinancialYearNew)
        {
            using (var db = new accountingEntities())
            {
                tblFinancialYear tbFinancialYearOld = GetDefaultFinancialYearObj();
                db.tblFinancialYears.FirstOrDefault(x => x.fyId == tbFinancialYearNew.fyId).fyStatus = true;
                if(tbFinancialYearOld!=null)
                db.tblFinancialYears.FirstOrDefault(x => x.fyId == tbFinancialYearOld.fyId).fyStatus = false;
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
        }
    }
}
