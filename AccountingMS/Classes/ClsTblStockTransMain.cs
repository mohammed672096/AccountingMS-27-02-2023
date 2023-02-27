using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblStockTransMain
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblStockTransMain> tbStockTransMainList;

        public ClsTblStockTransMain(bool initData = true)
        {
            if (!initData) return;
            InitData();
        }

        private void InitData()
        {
            this.tbStockTransMainList = (Session.CurrentUser.id == 1) ?
                (from a in db.tblStockTransMains
                 where a.stcDate >= Session.CurrentYear.fyDateStart
                 && a.stcDate <= Session.CurrentYear.fyDateEnd
                 orderby a.stcDate
                 select a).ToList()
             : (from a in db.tblStockTransMains
                where a.stcBrnId == Session.CurBranch.brnId && a.stcDate >= Session.CurrentYear.fyDateStart && a.stcDate <= Session.CurrentYear.fyDateEnd
                orderby a.stcDate
                select a).ToList();
        }

        public void RefreshData() => InitData();

        public IEnumerable<tblStockTransMain> GetStockTransList => this.tbStockTransMainList;

        public int GetStockTransNewNo()
        {
            return this.tbStockTransMainList.OrderByDescending(x => x.stcNo).Select(x => x.stcNo).FirstOrDefault() + 1;
        }

        public tblStockTransMain GetStockMainObjById(int stcId)
        {
            return this.tbStockTransMainList.Where(x => x.stcId == stcId).FirstOrDefault();
        }

        public int GetNewStockTransId()
        {
            InitData();
            return this.tbStockTransMainList.OrderByDescending(x => x.stcId).Select(x => x.stcId).FirstOrDefault();
        }

        public bool ValidateStockNo(int stcNo)
        {
            return !this.tbStockTransMainList.Any(x => x.stcNo == stcNo);
        }

        public void Add(tblStockTransMain tbStockTransMain)
        {
            db.tblStockTransMains.Add(tbStockTransMain);
        }

        public void Attach(tblStockTransMain tbStockTransMain)
        {
            db.tblStockTransMains.Attach(tbStockTransMain);
        }

        public void Delete(tblStockTransMain tbStockTransMain)
        {
            db.tblStockTransMains.Remove(tbStockTransMain);
        }

        public bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
