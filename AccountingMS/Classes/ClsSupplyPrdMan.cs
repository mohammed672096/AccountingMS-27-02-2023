using System;
using System.Collections.Generic;

namespace AccountingMS
{
    public static class ClsSupplyPrdMan
    {
        public static IEnumerable<ClsProductQuantList> ConvertList(IEnumerable<tblSupplySub> tbSupplySubList, short storeId, ClsTblPrdManufacture clsTbPrdMan)
        {
            var tbPrdQuanList = new List<ClsProductQuantList>();

            foreach (var tbSupplySub in tbSupplySubList)
                if (!tbSupplySub.supPrdManufacture) tbPrdQuanList.Add(AddPrdQuanListObj(tbSupplySub, storeId));
                else foreach (var tbPrdMan in clsTbPrdMan.GetPrdManListByPrdId(Convert.ToInt32(tbSupplySub.supPrdId)))
                        tbPrdQuanList.Add(AddPrdQuanListObj(tbSupplySub, storeId, tbPrdMan.manPrdSubId, tbPrdMan.manPrdMsurId, Convert.ToDouble(tbSupplySub.supQuanMain) * Convert.ToDouble(tbPrdMan.manQuan)));

            return tbPrdQuanList;
        }

        private static ClsProductQuantList AddPrdQuanListObj(tblSupplySub tbSupplySub, short storeId, int prdId = 0, int prdMsurId = 0, double quantity = 0)
        {
            return new ClsProductQuantList()
            {
                prdId = (prdId == 0) ? Convert.ToInt32(tbSupplySub.supPrdId) : prdId,
                prdNo = Convert.ToString(tbSupplySub.supPrdNo),
                prdName = Convert.ToString(tbSupplySub.supPrdName),
                prdQuantity = (quantity == 0) ? Convert.ToDouble(tbSupplySub.supQuanMain) : quantity,
                prdPriceMsurId = (prdMsurId == 0) ? Convert.ToInt32(tbSupplySub.supMsur) : prdMsurId,
                prdStrId = storeId,
            };
        }
    }
}
