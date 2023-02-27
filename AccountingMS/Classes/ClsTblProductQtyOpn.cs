using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblProductQtyOpn
    {
        public ClsTblProductQtyOpn()
        {
            if (Session.tblProductQtyOpn.Count <= 0)
                Session.GetDataProductQtyOpn();
        }
        public void RefreshData() => Session.GetDataProductQtyOpn();
        public IEnumerable<tblProductQtyOpn> GetProductQtyOpnList => Session.tblProductQtyOpn;

        public IEnumerable<tblProductQtyOpn> GetPrdQuantityOpnListByPrdId(int prdId) => Session.tblProductQtyOpn.Where(x => x.qtyPrdId == prdId).ToList();
        public tblProductQtyOpn GetPrdQuantityOpnByPrdId(int prdId) => Session.tblProductQtyOpn.FirstOrDefault(x => x.qtyPrdId == prdId);

        public bool IsPrdQuanOpnFoundByPrdId(int prdId) => Session.tblProductQtyOpn.Any(x => x.qtyPrdId == prdId);

        public bool IsPrdQuanOpnFoundByMsurId(int prdMsurId)
        {
            return Session.tblProductQtyOpn.Any(x => x.qtyPrdMsurId == prdMsurId);
        }

        public bool DeleteRow(tblProductQtyOpn tbPrdQtyOpn)
        {
            using (var db = new accountingEntities())
            {
                var proQuOp = db.tblProductQtyOpns.FirstOrDefault(x => x.qtyId == tbPrdQtyOpn.qtyId);
                db.tblProductQtyOpns.Remove(proQuOp);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.tblProductQtyOpn.Remove(proQuOp);
                    return true;
                }
                return false;
            }
        }


    }
}
