using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblUserRole
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblUserRole> tbUserRole;

        public ClsTblUserRole()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbUserRole = db.tblUserRoles.ToList();
        }

        public IEnumerable<tblUserRole> GetUserRoleListByRoleId(short roleId)
        {
            return this.tbUserRole.Where(x => x.fkRoleId == roleId);
        }

        public short GetUserRoleIdByUserId(short userId)
        {
            return this.tbUserRole.Where(x => x.fkUserId == userId).Select(x => x.fkRoleId).FirstOrDefault();
        }
    }
}
