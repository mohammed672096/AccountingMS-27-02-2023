using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    class ClsProductQuantList
    {
        public int prdId { set; get; }
        public double prdQuantity { set; get; }
        public double prdPrice { set; get; }
        public short prdStrId { set; get; }
        public int prdPriceMsurId { set; get; }
        public bool prdIsIncrease { set; get; }
        public ClsProductQuantList ShallowCopy()
        {
            return (ClsProductQuantList)this.MemberwiseClone();
        }
    }
}
