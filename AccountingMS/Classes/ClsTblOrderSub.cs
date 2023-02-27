using DevExpress.DataProcessing;
using DevExpress.Utils.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblOrderSub
    {
        accountingEntities db;
        IEnumerable<tblOrderSub> tbOrderSubList;

        private readonly OrderType ordType;

        public ClsTblOrderSub() { InitData(); }

        public ClsTblOrderSub(OrderType ordType)
        {
            this.ordType = ordType;
            InitData((byte)this.ordType);
        }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbOrderSubList =(Session.CurrentUser.id==1)? db.tblOrderSubs.Where(x => x.ordDate >= Session.CurrentYear.fyDateStart &&
                 x.ordDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.ordMainId).ToList():
                 db.tblOrderSubs.Where(x => x.ordBrnId == Session.CurBranch.brnId && x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.ordMainId).ToList();
        }

        private void InitData(byte status)
        {
            db = new accountingEntities();
            this.tbOrderSubList = (Session.CurrentUser.id == 1) ? db.tblOrderSubs.Where(x =>x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd && x.ordStatus == status).OrderBy(x => x.ordMainId).ToList():
                db.tblOrderSubs.Where(x => x.ordBrnId == Session.CurBranch.brnId && x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd && x.ordStatus == status).OrderBy(x => x.ordMainId).ToList();
        }

        public IEnumerable<tblOrderSub> GetOrderList => this.tbOrderSubList;

        public IList<tblOrderSub> GetOrderListByMainId(int ordMainId)
        {
            return this.tbOrderSubList.Where(x => x.ordMainId == ordMainId).ToList();
        }

        public void Add(tblOrderSub tbOrderSub)
        {
            db.tblOrderSubs.Add(tbOrderSub);
        }

        public void Attach(tblOrderSub tbOrderSub)
        {
            db.tblOrderSubs.Attach(tbOrderSub);
        }

        public void RemoveByMainId(int ordMainId)
        {
            db.tblOrderSubs.RemoveRange(this.tbOrderSubList.Where(x => x.ordMainId == ordMainId));
        }

        public void Remove(tblOrderSub tbOrderSub)
        {
            db.tblOrderSubs.Remove(tbOrderSub);
        }

        public void ResetChanges(IList<tblOrderSub> tbOrderSubList)
        {
            if (tbOrderSubList == null) return;
            tbOrderSubList.ForEach(x => db.Entry(x).State = EntityState.Unchanged);
        }

        protected internal bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
