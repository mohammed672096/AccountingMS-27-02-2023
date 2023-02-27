using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblInvStoreMain
    {
        accountingEntities db = new accountingEntities();
        IList<tblInvStoreMain> tbInvStoreList;

        public ClsTblInvStoreMain()
        {
            InitData();
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                this.tbInvStoreList = db.tblInvStoreMains.Where(x => //x.invBrnId == Session.CurBranch.brnId
                x.invDate >= Session.CurrentYear.fyDateStart &&
                x.invDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.invDate).OrderBy(x => x.invDate).ToList();
            else this.tbInvStoreList = db.tblInvStoreMains.Where(x => x.invBrnId == Session.CurBranch.brnId
              && x.invDate >= Session.CurrentYear.fyDateStart &&
              x.invDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.invDate).OrderBy(x => x.invDate).ToList();
        }

        public IEnumerable<tblInvStoreMain> GetInvStoreList(InvType invType)
        {
            byte status = (byte)invType;
            return this.tbInvStoreList.Where(x => x.invStatus == status).ToList();
        }

        public tblInvStoreMain GetInvStoreObjById(int invId)
        {
            return this.tbInvStoreList.FirstOrDefault(x => x.id == invId);
        }

        public int GetInvStoreNewNo()
        {
            return this.tbInvStoreList.OrderByDescending(x => x.invNo).Select(x => x.invNo).FirstOrDefault() + 1;
        }

        public bool IsInvStoreNoFound(int invNo)
        {
            return this.tbInvStoreList.Any(x => x.invNo == invNo);
        }

        public bool IsInvStoreNoFound(int invNo, int invId)
        {
            return this.tbInvStoreList.Any(x => x.id != invId && x.invNo == invNo);
        }

        public void Add(tblInvStoreMain tbInvMain)
        {
            db.tblInvStoreMains.Add(tbInvMain);
        }

        public void Attach(tblInvStoreMain tbInvMain)
        {
            db.tblInvStoreMains.Attach(tbInvMain);
        }

        public void DeAttach(tblInvStoreMain tbInvMain)
        {
            db.Entry(tbInvMain).State = EntityState.Detached;
        }

        public void ResetChanges(tblInvStoreMain tbInvMain)
        {
            db.Entry(tbInvMain).State = EntityState.Unchanged;
        }

        protected internal bool Remove(tblInvStoreMain tbInvMain)
        {
            db.tblInvStoreMains.Remove(tbInvMain);
            return SaveDB;
        }

        protected internal bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
