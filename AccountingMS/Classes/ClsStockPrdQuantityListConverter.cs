using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsStockPrdQuantityListConverter
    {
        public static IEnumerable<ClsProductQuantList> InitPrdQuantityList(IEnumerable<tblStockTransSub> tbStockSubList, short strId)
        {
            return tbStockSubList.Select(x => new ClsProductQuantList
            {
                prdId = x.stcPrdId,
                prdStrId = strId,
                prdPriceMsurId = x.stcMsurId,
                prdQuantity = x.stcQuantity
            }).ToList();
        }

        public static IEnumerable<ClsProductQuantList> InitPrdQuantityList(IEnumerable<ClsProductQuantList> tbPrdQuantityList, short strId)
        {
            return tbPrdQuantityList.Select(x => new ClsProductQuantList
            {
                prdId = x.prdId,
                prdStrId = strId,
                prdPriceMsurId = x.prdPriceMsurId,
                prdQuantity = x.prdQuantity
            }).ToList();
        }

        public static IList<ClsProductQuantList> InitPrdQuantityList(IEnumerable<tblInvStoreSub> tbPrdInvSubList, short strId)
        {
            return tbPrdInvSubList.Select(x => new ClsProductQuantList
            {
                prdId = x.invPrdId,
                prdPriceMsurId = x.invPrdMsurId,
                prdQuantity = x.invQuanDefr,
                prdStrId = strId
            }).ToList();
        }
    }
}
