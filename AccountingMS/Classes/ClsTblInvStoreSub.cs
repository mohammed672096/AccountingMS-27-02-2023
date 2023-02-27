using DevExpress.Utils.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblInvStoreSub
    {
        accountingEntities db = new accountingEntities();
        IList<tblInvStoreSub> tbInvStoreList;

        public ClsTblInvStoreSub()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbInvStoreList = db.tblInvStoreSubs.ToList();
        }

        public IList<tblInvStoreSub> GetInvStoreListByInvMainId(int invMainId)
        {
            return this.tbInvStoreList.Where(x => x.invMainId == invMainId).ToList();
        }

        public IList<tblInvStoreSub> GetInvStoreListByPrdId(int prdId)
        {
            return this.tbInvStoreList.Where(x => x.invPrdId == prdId).ToList();
        }

        public void Add(tblInvStoreSub tbInvSub)
        {
            db.tblInvStoreSubs.Add(tbInvSub);
        }

        public void Attach(tblInvStoreSub tbInvSub)
        {
            db.tblInvStoreSubs.Attach(tbInvSub);
        }

        public void ResetChanges(tblInvStoreSub tbInvSub)
        {
            db.Entry(tbInvSub).State = EntityState.Unchanged;
        }

        public void Modefied(tblInvStoreSub tbInvSub)
        {
            db.Entry(tbInvSub).State = EntityState.Modified;
        }

        public void ResetChanges(IList<tblInvStoreSub> tbInvSubList)
        {
            if (tbInvSubList == null) return;
            tbInvSubList.ForEach(x => db.Entry(x).State = EntityState.Unchanged);
        }

        protected internal void Remove(tblInvStoreSub tbInvSub)
        {
            db.tblInvStoreSubs.Remove(tbInvSub);
        }

        protected internal bool RemoveInvSubListByMainId(int invMainId)
        {
            var tbInvSubList = GetInvStoreListByInvMainId(invMainId);
            if (tbInvSubList == null) return true;

            db.tblInvStoreSubs.RemoveRange(tbInvSubList);
            return SaveDB;
        }

        protected internal bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
