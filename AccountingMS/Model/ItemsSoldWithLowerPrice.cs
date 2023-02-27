using System;

namespace AccountingMS.Model
{
    public class ItemsSoldWithLowerPrice
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Invoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public double? Quantity { get; set; }
        public double CostPrice { get; set; }
        public double SellPrice { get; set; }
        public double Profit { get => SellPrice - CostPrice; }
    }
}
