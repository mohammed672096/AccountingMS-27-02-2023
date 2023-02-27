using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    public class SupplySubCustom
    {
        [DisplayName("الإجمالي")]
        public double? Total { get; set; }

        [DisplayName("البيان")]
        public string Desc { get; set; }

        [DisplayName("وحدة القياس")]
        public string Msur { get; set; }

        [DisplayName("الباركود")]
        public string PrdBarcode { get; set; }

        [DisplayName("إسم الصنف")]
        public string PrdName { get; set; }

        [DisplayName("رقم الصنف")]
        public string PrdNo { get; set; }

        [DisplayName("سعر الشراء")]
        public double? BuyPrice  { get; set; }

        [DisplayName("الخصم")]
        public double? DscntAmount { get; set; }
        [DisplayName("نسبة الخصم")]
        public double? DscntPercent { get; set; }

        [DisplayName("الكمية")]
        public double? QuanMain { get; set; }

        [DisplayName("سعر البيع")]
        public double? SalePrice { get; set; }

        [DisplayName("نسبة الضرية")]
        public double? TaxPercent { get; set; }

        [DisplayName("الضريبة")]
        public double? TaxPrice { get; set; }
        [DisplayName("عدد الكراتين")]
        public int? NoPacks { get; set; }

        [DisplayName("وقت عمل اضافي")]
        public double? Overtime { get; set; }
        [DisplayName("وقت العمل")]
        public double? Workingtime { get; set; }
    }
}
