using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblDscntPrmsion
    {
        public ClsTblDscntPrmsion()
        {
            if (Session.tbDscntPermissionList.Count <= 0)
                Session.GetDatatblDscntPermission();
        }

        public void RefreshData()
        {
            Session.GetDatatblDscntPermission();
        }
        public IList<tblDscntPermission> GetDscnPrmsionList => Session.tbDscntPermissionList;

        public bool IsDscntUserFound(short usrId)
        {
            return Session.tbDscntPermissionList.Any(x => x.dscUsrId == usrId);
        }

        public bool IsDscntUserPermission(short usrId)
        {
            return Session.tbDscntPermissionList.Where(x => x.dscUsrId == usrId).Select(x => x.dscPermission).FirstOrDefault();
        }

        public byte GetDscntAmountByUsrId(short usrId)
        {
            return Session.tbDscntPermissionList.Where(x => x.dscUsrId == usrId).Select(x => x.dscPercent).FirstOrDefault();
        }

        public bool Add(tblDscntPermission tbDscntPrmsion)
        {
            using (var db = new accountingEntities())
            {
                db.tblDscntPermissions.Add(tbDscntPrmsion);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.tbDscntPermissionList.Add(tbDscntPrmsion);
                    return true;
                }
                return false;
            }
        }
        public bool Attach(tblDscntPermission tbDscntPrmsion)
        {
            return Remove(tbDscntPrmsion) && Add(tbDscntPrmsion);
        }

        public bool Remove(tblDscntPermission tbDscntPrmsion)
        {
            using (var db = new accountingEntities())
            {
                db.tblDscntPermissions.Remove(db.tblDscntPermissions.FirstOrDefault(x => x.id == tbDscntPrmsion.id));
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.tbDscntPermissionList.Remove(tbDscntPrmsion);
                    return true;
                }
                return false;
            }
        }
    }
}
