using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    class ClsUserTblControl
    {
        public IEnumerable<RoleControlTbl> tbRoleControlFilteredList;
        public ClsUserTblControl()
        {
        }
        public string GetRoleName(short rolId)=>Session.RoleTbls.ToList().Where(x => x.ID == rolId).Select(x => x.Name).FirstOrDefault();
        public IEnumerable<ControlTbl> GetControlListByUCNo(byte ucNo) => Session.ControlTbls.Where(x => x.No == ucNo);
        public short GetControlIdByNameNducNo(string cntName, byte ucNo) =>
           (from c in Session.ControlTbls
            join cd in Session.ControlDatas on c.ControlDataID equals cd.ID
            where c.No == ucNo && cd.Name == cntName
            select c.ID).ToList().FirstOrDefault();

        public string GetControlCaptionById(short ID)=> 
        (from c in Session.ControlTbls
         join cd in Session.ControlDatas on c.ControlDataID equals cd.ID
          where c.ID == ID select cd).Select(x => (!Program.My_Setting.LangEng) ? x.Caption : x.CaptionEn).FirstOrDefault();

        public byte GetUserControlNoByName(string ucName) => Session.UserControlTbls.Where(x => x.Name == ucName).Select(x => x.No).FirstOrDefault();
        public bool CheclBBI(string bbiName) => Session.UserControlTbls.Any(x => x.Name == bbiName);
        public string GetUserControlNameByNo(byte ucNo) => Session.UserControlTbls.Where(x => x.No == ucNo).Select(x => (!Program.My_Setting.LangEng) ? x.Caption : x.CaptionEn).FirstOrDefault();

        public IEnumerable<UserTbl> GetUserListNoAdmin => Session.UserTbls.Where(x => x.ID != 1).ToList();
        public UserTbl GetUserObjById(short userId)=> Session.UserTbls.Where(x => x.ID == userId).FirstOrDefault();
        public string GetUserNameById(short userId)=> Session.UserTbls.Where(x => x.ID == userId).Select(x => x.Name).FirstOrDefault();
        
        public IEnumerable<RoleControlTbl> GetRoleControlListByRolId(short roleId)
        {
            this.tbRoleControlFilteredList = Session.RoleControlTbls.Where(x => x.RoleId == roleId);
            return this.tbRoleControlFilteredList;
        }
        public IEnumerable<RoleControlTbl> GetRoleControlListByRoleIdGroupByUCNo(short roleId) => this.tbRoleControlFilteredList.GroupBy(x => x.No, (key, grp) => new RoleControlTbl { No = key, RoleId = roleId });
        public bool GetCheckState(short controlId) => this.tbRoleControlFilteredList.Any(x => x.ControlId == controlId);
        public bool GetButtonVisibilityByRoleIdNdControlId(short roleId, short controlId) => 
            (Session.RoleControlTbls.Any(x => x.RoleId == roleId && x.ControlId == controlId));
        public BarItemVisibility GetButtonVisibilityByRoleIdNducNo(short roleId, byte ucNo) => (Session.RoleControlTbls.Any(x => x.RoleId == roleId && x.No == ucNo)) ? BarItemVisibility.Always : BarItemVisibility.Never;
        public bool CheckRoleControlIsNewByRoleId(short roleId) => !Session.RoleControlTbls.Any(x => x.RoleId == roleId);

    }
}
