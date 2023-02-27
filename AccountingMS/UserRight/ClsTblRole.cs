using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblRole
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblRole> tbRoleList;

        public ClsTblRole()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbRoleList = db.tblRoles.ToList();
        }

        public IEnumerable<tblRole> GetRoleList => this.tbRoleList;

        public string GetRoleName(short rolId)
        {
            return this.tbRoleList.Where(x => x.rolId == rolId).Select(x => x.rolName).FirstOrDefault();
        }
    }
}
