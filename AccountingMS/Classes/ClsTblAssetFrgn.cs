using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblAssetFrgn
    {
        accountingEntities db = new accountingEntities();
        List<tblAssetFrgn> tbAssetFrgnList;

        public ClsTblAssetFrgn()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbAssetFrgnList = (from a in db.tblAssetFrgns
                                    where a.asBrnId == Session.CurBranch.brnId && (a.asDate >= Session.CurrentYear.fyDateStart && a.asDate <= Session.CurrentYear.fyDateEnd)
                                    select a).ToList();
        }

        public IEnumerable<tblAssetFrgn> GetAssetFrgnList => this.tbAssetFrgnList;

        public void Add(tblAssetFrgn tbAssetFrgn)
        {
            db.tblAssetFrgns.Add(tbAssetFrgn);
        }

        public void Attach(tblAssetFrgn tbAssetFrgn)
        {
            db.tblAssetFrgns.Attach(tbAssetFrgn);
        }

        public void Delete(tblAssetFrgn tbAssetFrgn)
        {
            db.tblAssetFrgns.Remove(tbAssetFrgn);
        }

        public bool Save => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
