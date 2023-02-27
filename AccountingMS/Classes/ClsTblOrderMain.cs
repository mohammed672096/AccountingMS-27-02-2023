using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblOrderMain
    {
        accountingEntities db;
        IEnumerable<tblOrderMain> tbOrderMainList;

        private readonly OrderType ordType;

        public ClsTblOrderMain() { InitData(); }

        public ClsTblOrderMain(OrderType ordType)
        {
            this.ordType = ordType;
            InitData((byte)this.ordType);
        }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbOrderMainList = (Session.CurrentUser.id == 1) ? db.tblOrderMains.Where(x =>x.ordDate >= Session.CurrentYear.fyDateStart &&
                 x.ordDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.ordDate).ToList()
                 :db.tblOrderMains.Where(x => x.ordBrnId == Session.CurBranch.brnId && x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.ordDate).ToList();
        }

        private void InitData(byte status)
        {
            db = new accountingEntities();
            this.tbOrderMainList = (Session.CurrentUser.id == 1) ? db.tblOrderMains.Where(x => x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd && x.ordStatus == status).OrderBy(x => x.ordDate).ToList():
                db.tblOrderMains.Where(x => x.ordBrnId == Session.CurBranch.brnId && x.ordDate >= Session.CurrentYear.fyDateStart &&
                x.ordDate <= Session.CurrentYear.fyDateEnd && x.ordStatus == status).OrderBy(x => x.ordDate).ToList();
        }

        public IEnumerable<tblOrderMain> GetOrderList => this.tbOrderMainList;

        public IEnumerable<tblOrderMain> GetOrderListByStatusNdDtStartEnd(byte ordStatus, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbOrderMainList.Where(x => x.ordStatus == ordStatus && x.ordDate >= dtStart && x.ordDate <= dtEnd);
        }

        public bool IsInvoicesFound(byte ordStatus, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbOrderMainList.Any(x => x.ordStatus == ordStatus && x.ordDate >= dtStart && x.ordDate <= dtEnd);
        }

        public int GetOrderNewId()
        {
            return this.tbOrderMainList.OrderByDescending(x => x.ordId).Select(x => x.ordId).FirstOrDefault();
        }

        public int GetOrderNewNo()
        {
            return this.tbOrderMainList.OrderByDescending(x => x.ordNo).Select(x => x.ordNo).FirstOrDefault() + 1;
        }

        public bool IsOrdNoFound(int ordNo)
        {
            return this.tbOrderMainList.Any(x => x.ordNo == ordNo);
        }

        public void Add(tblOrderMain tbOrderMain)
        {
            db.tblOrderMains.Add(tbOrderMain);
        }

        public void Attach(tblOrderMain tbOrderMain)
        {
            db.tblOrderMains.Attach(tbOrderMain);
        }

        public void Remove(tblOrderMain tbOrderMain)
        {
            db.tblOrderMains.Remove(tbOrderMain);
        }

        public void ResetChanges(tblOrderMain tbOrderMain)
        {
            db.Entry(tbOrderMain).State = EntityState.Unchanged;
        }

        protected internal bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
