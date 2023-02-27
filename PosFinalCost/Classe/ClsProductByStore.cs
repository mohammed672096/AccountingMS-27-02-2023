using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    class ClsProductByStore
    {
        public IEnumerable<Product> GetProductListByStrId(short strId)
        {
            return (from prdQuantity in Session.ProductQunatities
                    where prdQuantity.StrId == strId
                    join prd in Session.Products
                    on prdQuantity.prdId equals prd.ID
                    select prd).ToList();
        }
    }
}
