namespace AccountingMS
{
    public interface ItblSupplySub
    {
        double? supDebit { get; set; }
        string supDesc { get; set; }
        string supMsur { get; set; }
        string supPrdBarcode { get; set; }
        string supPrdName { get; set; }
        int? supPrdId { get; set; }
        string supPrdNo { get; set; }
        double? supPrice { get; set; }
        double? supQuanMain { get; set; }
        public double? supOvertime { get; set; }
        public double? supWorkingtime { get; set; }
        public double? supDscntPercent { get; set; }
        double? supDscntAmount { get; set; }
        double? supQuanMain1 { get; set; }
        double? supQuanMain2 { get; set; }
        double? supSalePrice { get; set; }
        byte? supTaxPercent { get; set; }
        double? supTaxPrice { get; set; }

        public int? subNoPacks { get; set; }
        string EquipmentNo { get; set; }
        double? NumberDays { get; set; }
    }
}