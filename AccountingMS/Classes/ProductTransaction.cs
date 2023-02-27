using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS
{
    public class ProductTransaction 
    {
        public DateTime Date { get; set; }
        public byte TranType { get; set; }
        public int BillID { get; set; }
        public int? ProductID { get; set; }
        public int? UnitID { get; set; }
        public int? StoreID { get; set; }
        public double Factor { get; set; }
        public double Quantity { get; set; }
        public double? CostValue { get; set; }
        public ProductTransactionType ProTranType { get; set; }
    }
}
