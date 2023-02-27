using System;

namespace AccountingMS
{
    public class tblPrdTracking
    {
        public int id { get; set; }
        public int? trcPrdId { get; set; }
        public int? trcPrdMsurId { get; set; }
        public string trcBarcode { get; set; }
        public string trcDesc { get; set; }
        public double? trcQuan { get; set; }
        public double? trcPrice { get; set; }
        public double? trcSalePrice { get; set; }
        public DateTime? trcDate { get; set; }
        public byte trcStatus { get; set; }
    }
}
