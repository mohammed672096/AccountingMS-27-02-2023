using System.ComponentModel;

namespace AccountingMS
{
    public class tblBranchCustom : ItblBranchCustom
    {
        [DisplayName("رقم الفرع")]
        public short brnNo { get; set; }

        [DisplayName("إسم الفرع")]
        public string brnName { get; set; }

        [DisplayName("إسم الفرع اجنبي")]
        public string brnNameEn { get; set; }

        [DisplayName("العنوان")]
        public string brnAddress { get; set; }

        [DisplayName("العنوان اجنبي")]
        public string brnAddressEn { get; set; }

        [DisplayName("البريد الإلكتروني")]
        public string brnEmail { get; set; }

        [DisplayName("رقم الهاتف")]
        public string brnPhnNo { get; set; }

        [DisplayName("رقم الفاكس")]
        public string brnFaxNo { get; set; }

        [DisplayName("رقم صندوق البريد")]
        public string brnMailBox { get; set; }

        [DisplayName("الرقم الضريبي")]
        public string brnTaxNo { get; set; }

        [DisplayName("رقم السجل التجاري")]
        public string brnTradeNo { get; set; }
    }
}
