using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblUser
    {
        public ClsTblUser()
        {
            Session.GetDataUserTbls();
        }

       
        public IEnumerable<tblUser> GetUserList => Session.CurrentUser.id == 1?Session.tblUser: Session.tblUser.Where(x=>x.id== Session.CurrentUser.id);
        public IEnumerable<tblUser> GetUserListNoAdmin => Session.tblUser.Where(x => x.id != 1).ToList();

        public tblUser GetUserObjById(short userId)
        {
            return Session.tblUser.Where(x => x.id == userId).FirstOrDefault();
        }

        public string GetUserNameById(short userId)
        {
            return Session.tblUser.Where(x => x.id == userId).Select(x => x.userName).FirstOrDefault();
        }
    }
}
