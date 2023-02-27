using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public static class ClsTblPrdNdMsur
    {
        public static IEnumerable<tblProduct> GetProductsWithMsur(IEnumerable<tblProduct> tbPrdList, IEnumerable<tblPrdPriceMeasurment> tbPrdMsurList)
        {
            return (from prd in tbPrdList
                    where prd.prdStatus != 2
                    join prdMsur in tbPrdMsurList on prd.id equals prdMsur.ppmPrdId
                    select prd).ToList().GroupBy(x => x.id).Select(x => x.First()).ToList();
        }
    }
}
