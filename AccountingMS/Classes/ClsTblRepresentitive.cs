using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblRepresentitive
    {
        IList<tblRepresentative> tbRepList;

        public ClsTblRepresentitive()
        {
            InitData();
        }

        private void InitData()
        {
            using (var db = new accountingEntities())
            {
                if (Session.CurrentUser.id == 1)
                    this.tbRepList = db.tblRepresentatives.ToList();
                else this.tbRepList = db.tblRepresentatives.Where(x => x.repBrnId == Session.CurBranch.brnId//|x.repBrnId==null | x.repBrnId == 0
                ).ToList();
            }
        }

        protected internal IList<tblRepresentative> GetRepList => this.tbRepList;

        protected internal bool Delete(tblRepresentative tbRepresentative)
        {
            using (var db = new accountingEntities())
            {
                db.tblRepresentatives.Remove(tbRepresentative);
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
        }
    }
}
