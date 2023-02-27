using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblUserBranch
    {
        public static List<tblUserBranch> tblUserBranchList = new List<tblUserBranch>();
        public static void GetDataBranches()
        {
            using (var db = new accountingEntities())
                tblUserBranchList = db.tblUserBranch.ToList();
        }
        public ClsTblUserBranch()
        {
            if (tblUserBranchList.Count <= 0)
                GetDataBranches();
        }
        public IEnumerable<tblUserBranch> GetUserBranchListByUserId(short usrId) => tblUserBranchList.Where(x => x.usrId == usrId).ToList();
        public bool IsUserBranchFound(short usrId, short brnId) => tblUserBranchList.Any(x => x.usrId == usrId && x.brnId == brnId);

        public bool Save(IEnumerable<tblUserBranch> tbUserBranchList, short usrId)
        {
            using (var db = new accountingEntities())
            {
                db.tblUserBranch.RemoveRange(db.tblUserBranch.Where(x => x.usrId == usrId));
                db.tblUserBranch.AddRange(tbUserBranchList);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    tblUserBranchList = db.tblUserBranch.ToList();
                    return true;
                }
                return false;
            }
        }

    }
}
