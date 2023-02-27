using System.ComponentModel;

namespace AccountingMS
{
    public class tblSupplySubCustom2 : ItblSupplySub
    {
        [DisplayName("الإجمالي")]
        public double? supDebit { get; set; }

        [DisplayName("البيان")]
        public string supDesc { get; set; }

        [DisplayName("وحدة القياس")]
        public string supMsur { get; set; }

        [DisplayName("الباركود")]
        public string supPrdBarcode { get; set; }

        [DisplayName("إسم الصنف")]
        public string supPrdName { get; set; }

        [DisplayName("رقم الصنف")]
        public string supPrdNo { get; set; }

        [DisplayName("سعر الشراء")]
        public double? supPrice { get; set; }
        [DisplayName("الخصم")]
        public double? supDscntAmount { get; set; }
        [DisplayName("نسبة الخصم")]
        public double? supDscntPercent { get; set; }

        [DisplayName("كمية الوحدة 1")]
        public double? supQuanMain1 { get; set; }

        [DisplayName("كمية الوحدة 2")]
        public double? supQuanMain2 { get; set; }

        [DisplayName("سعر الوحدة")]
        public double? supSalePrice { get; set; }

        [DisplayName("نسبة الضرية")]
        public byte? supTaxPercent { get; set; }

        [DisplayName("الضريبة")]
        public double? supTaxPrice { get; set; }
        [DisplayName("وقت عمل اضافي")]
        public double? supOvertime { get; set; }
        [DisplayName("وقت العمل")]
        public double? supWorkingtime { get; set; }
        [DisplayName("عدد الايام")]
        public double? NumberDays { get; set; }
        [DisplayName("رقم المعدة")]
        public string EquipmentNo { get; set; }
        public int? subNoPacks { get ; set ; }
        double? ItblSupplySub.supQuanMain { get; set; }

        int? ItblSupplySub.supPrdId { get; set; }
    }
}
