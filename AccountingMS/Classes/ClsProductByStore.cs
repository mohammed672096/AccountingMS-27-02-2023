using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsProductByStore
    {
        IEnumerable<tblProduct> tbProductList;
        IEnumerable<tblProductQunatity> tbPrdQuantityList;

        public ClsProductByStore(IEnumerable<tblProduct> tbProductList, IEnumerable<tblProductQunatity> tbPrdQuantityList)
        {
            this.tbProductList = tbProductList;
            this.tbPrdQuantityList = tbPrdQuantityList;
        }

        public IEnumerable<tblProduct> GetProductListByStrId(short strId)
        {
            return (from prdQuantity in this.tbPrdQuantityList
                    where prdQuantity.prdStrId == strId
                    join prd in this.tbProductList
                    on prdQuantity.prdId equals prd.id
                    select prd).ToList();
        }
    }
}
