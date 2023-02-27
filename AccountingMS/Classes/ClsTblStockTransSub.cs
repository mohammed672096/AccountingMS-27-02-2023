using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblStockTransSub
    {
        accountingEntities db = new accountingEntities();
       public IEnumerable<tblStockTransSub> tbStockTransSubList;

        public ClsTblStockTransSub(bool initData = true)
        {
            if (!initData) return;
            InitData();
        }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbStockTransSubList = (from a in db.tblStockTransSubs
                                        where a.stcBrnId == Session.CurBranch.brnId && a.stcDate >= Session.CurrentYear.fyDateStart && a.stcDate <= Session.CurrentYear.fyDateEnd
                                        orderby a.stcDate
                                        select a).ToList();
        }

        public void RefreshData() => InitData();

        public IEnumerable<tblStockTransSub> GetStockTransListByStcMainId(int stcMainId)
        {
            return this.tbStockTransSubList.Where(x => x.stcMainId == stcMainId);
        }

        public IList GetStockTransIListByStcMainId(int stcMainId)
        {
            return this.tbStockTransSubList.Where(x => x.stcMainId == stcMainId).ToList();
        }

        public IEnumerable<tblStockTransSub> GetStockTransListByPrdId(int prdId)
        {
            return this.tbStockTransSubList.Where(x => x.stcPrdId == prdId).OrderBy(x => x.stcDate).ToList();
        }

        public void Add(tblStockTransSub tbStockTransSub)
        {
            db.tblStockTransSubs.Add(tbStockTransSub);
        }

        public void Attach(tblStockTransSub tbStockTransSub)
        {
            db.tblStockTransSubs.Attach(tbStockTransSub);
        }

        public void Delete(tblStockTransSub tbStockTransSub)
        {
            db.tblStockTransSubs.Remove(tbStockTransSub);
        }

        public bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
