using DevExpress.XtraBars;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblRoleControl
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblRoleControl> tbRoleControlList;
        IEnumerable<tblRoleControl> tbRoleControlFilteredList;

        public ClsTblRoleControl()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbRoleControlList = db.tblRoleControls.OrderBy(x => x.fkucNo).ThenBy(x => x.fkControlId).ToList();
        }

        public IEnumerable<tblRoleControl> GetRoleControlList => this.tbRoleControlList;

        public IEnumerable<tblRoleControl> GetRoleControlListByRolId(short roleId)
        {
            this.tbRoleControlFilteredList = this.tbRoleControlList.Where(x => x.fkRoleId == roleId);
            return this.tbRoleControlFilteredList;
        }

        public IEnumerable<tblRoleControl> GetRoleControlListByRoleIdGroupByUCNo(short roleId)
        {
            return this.tbRoleControlFilteredList.GroupBy(x => x.fkucNo, (key, grp) => new tblRoleControl
            {
                fkucNo = key,
                fkRoleId = roleId,
            });
        }

        public bool GetCheckState(short controlId)
        {
            return this.tbRoleControlFilteredList.Any(x => x.fkControlId == controlId);
        }

        public BarItemVisibility GetButtonVisibilityByRoleIdNdControlId(short roleId, short controlId)
        {
            return (this.tbRoleControlList.Any(x => x.fkRoleId == roleId && x.fkControlId == controlId)) ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        public BarItemVisibility GetButtonVisibilityByRoleIdNducNo(short roleId, byte ucNo)
        {
            return (this.tbRoleControlList.Any(x => x.fkRoleId == roleId && x.fkucNo == ucNo)) ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        public bool CheckRoleControlIsNewByRoleId(short roleId)
        {
            return !this.tbRoleControlList.Any(x => x.fkRoleId == roleId);
        }

        public bool AddList(IEnumerable<tblRoleControl> tbRroleControlList)
        {
            AddRoleControlList(tbRroleControlList);
            return SaveDB;
        }

        private void AddRoleControlList(IEnumerable<tblRoleControl> tbRoleControlList)
        {
            foreach (var tbRoleControl in tbRoleControlList) db.tblRoleControls.Add(tbRoleControl);
        }

        public bool UpdateList(IEnumerable<tblRoleControl> tbRoleControlListOld, IEnumerable<tblRoleControl> tbRoleControlListNew)
        {
            AddNewData(tbRoleControlListOld, tbRoleControlListNew);
            RemoveOldData(tbRoleControlListOld, tbRoleControlListNew);

            return SaveDB;
        }

        private void AddNewData(IEnumerable<tblRoleControl> tbRoleControlListOld, IEnumerable<tblRoleControl> tbRoleControlListNew)
        {
            IEnumerable<tblRoleControl> tbRoleControlDistinctList = tbRoleControlListNew.Except(tbRoleControlListOld);
            AddRoleControlList(tbRoleControlDistinctList);
        }

        private void RemoveOldData(IEnumerable<tblRoleControl> tbRoleControlListOld, IEnumerable<tblRoleControl> tbRoleControlListNew)
        {
            IEnumerable<tblRoleControl> tbRoleControlDistinctList = tbRoleControlListOld.Except(tbRoleControlListNew);
            foreach (var tbRoleControl in tbRoleControlDistinctList) db.tblRoleControls.Remove(tbRoleControl);
        }

        private bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
