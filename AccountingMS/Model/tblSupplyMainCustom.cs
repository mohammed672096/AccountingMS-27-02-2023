using System;
using System.ComponentModel;

namespace AccountingMS
{
    public class tblSupplyMainCustom : ItblSupplyMainCustom
    {
        [DisplayName("الشعار")]
        public byte[] GetBranchImg => new ClsTblBranchImg().GetBranchImg(Session.CurBranch.brnId);
        [DisplayName("رقم الفاتورة")]
        [Category("Main")]
        public int supNo { get; set; }

        [DisplayName("رقم الحساب")]
        public long? supAccNo { get; set; }

        [DisplayName("إسم الحساب")]
        public string supAccName { get; set; }

        [DisplayName("البيان")]
        public string supDesc { get; set; }

        [DisplayName("رقم المرجع")]
        public int? supRefNo { get; set; }

        [DisplayName("تاريخ الفاتورة")]
        public DateTime? supDate { get; set; }

        [DisplayName("العملة")]
        public string supCurrencyStr { get; set; }

        [DisplayName("الإجمالي قبل الخصم")]
        public double supTotalPrice { get; set; }

        [DisplayName("نسبة الضريبة")]
        public byte? supTaxPercent { get; set; }

        [DisplayName("ضريبة القيمة المضافة")]
        public double? supTaxPrice { get; set; }
        [DisplayName("المندوب")]
        public string repName { get; set; }

        [DisplayName("نسبة الخصم")]
        public double? supDscntPercent { get; set; }

        [DisplayName("الخصم")]
        public double? supDscntAmount { get; set; }

        [DisplayName("الإجمالي بعد الخصم")]
        public double supTotal { get; set; }

        [DisplayName("الإجمالي النهائي")]
        public double supTotalFinal { get; set; }
        [DisplayName("المدفوع")]
        public double paidCash { get; set; }
        [DisplayName("المدفوع شبكة")]
        public double supBankAmount { get; set; }
        [DisplayName("المتبقي")]
        public double remin { get; set; }

        [DisplayName("المستخدم")]
        public string supUserIdStr { get; set; }

        [DisplayName("طريقة الدفع")]
        public string supIsCashStr { get; set; }

        [DisplayName("نوع الفاتورة")]
        public string supStatusStr { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: إسم العميل")]
        public string custName { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: إسم العميل انجليزي")]
        public string custNameEn { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: عنوان العميل")]
        public string custAddress { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: عنوان العميل انجليزي")]
        public string custAddressEn { get; set; }
        [Category("Customer")]
        [DisplayName("العملاء: المدينة")]
        public string custCity { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: المدينة انجليزي")]
        public string custCityEn { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: رقم العميل")]
        public int custNo { get; set; }
        [Category("Customer")]
        [DisplayName("العملاء: رقم المبنى")]
        public string cusBuildingNo { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: الرقم الإضافي")]
        public string cusAddNo { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: معرف آخر")]
        public string cusAnotherID { get; set; }
        [Category("Customer")]
        [DisplayName("العملاء: الحي")]
        public string cusDistrict { get; set; }
        [DisplayName("العملاء: الحي انجليزي")]
        public string cusDistrictEn { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: رقم هاتف العميل")]
        public string custPhnNo { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: رقم العميل الضريبي")]
        public string custTaxNo { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: رقم السجل التجاري")]
        public string CommercialRegister { get; set; }

        public string CommercialRegisterEn { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: الرمز البريدي")]
        public string PostalCode { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: البلد ")]
        public string CustCountry { get; set; }

        [Category("Customer")]
        [DisplayName("العملاء: البلد انجليزي")]
        public string CustCountryEn { get; set; }

        [DisplayName("نوع السيارة/الموقع")]
        public string CarType { get; set; }

        [DisplayName("رقم اللوحة/رقم امر التوريد")]
        public string PlateNumber { get; set; }

        [DisplayName("رقم العداد/رقم التعاقد")]
        public string CounterNumber { get; set; }

        [DisplayName("رقم امر الشراء")]
        public string PoNumber { get; set; }
        [DisplayName("رقم التسجيل")]
        public string RegistrationNumber { get; set; }

        [DisplayName("شروط الدفع")]
        public string PaymentTeam { get; set; }

        [DisplayName("رقم الحقل")]
        public string FieldNumber { get; set; }
        [DisplayName("الفترة من")]
        public DateTime? PeriodFrome { get; set; }
        [DisplayName("الفترة الى")]
        public DateTime? PeriodTo { get; set; }
        [DisplayName("تاريخ الشحن")]
        public DateTime? ShippingDate { get; set; }
        [DisplayName("تاريخ التوصيل")]
        public DateTime? DeliveryDate { get; set; }
        [DisplayName("ملاحظات")]
        public string Notes { get; set; }
        [DisplayName("الصافي نصا عربي")]
        public string NetTextAr { get; set; }
        [DisplayName("الصافي نصا انجليزي")]
        public string NetTextEn { get; set; }
        [DisplayName("الضريبه نصا انجليزي")]
        public string TaxAsTextEn { get; set; }
        [DisplayName("الضريبه نصا عربي")]
        public string TaxAsTextAr { get; set; }
        [Category("Customer")]
        [DisplayName("العملاء: اسم البنك")]
        public string bankName { get; set; }
        [DisplayName("العملاء: اسم البنك انجليزي")]
        public string bankNameEn { get; set; }

        [DisplayName("العملاء: رقم الحساب البنكي")]
        public string AccNoInBank { get; set; }

        [DisplayName("العملاء: IBAN البنك")]
        public string bankAccIBAN { get; set; }

        [DisplayName("العملاء: Swift Code")]
        public string bankSwiftCode { get; set; }

        [DisplayName("تاريخ الاستحقاق")]
        public DateTime? DueDate { get; set; }
        int ItblSupplyMain.id { get; set; }
        byte? ItblSupplyMain.supCurrency { get; set; }
        short? ItblSupplyMain.supCurrencyChng { get; set; }
        double? ItblSupplyMain.supTotalFrgn { get; set; }
        short ItblSupplyMain.supUserId { get; set; }
        byte? ItblSupplyMain.supIsCash { get; set; }
        int? ItblSupplyMain.supCustSplId { get; set; }
        int? ItblSupplyMain.reprID { get; set; }
        byte? ItblSupplyMain.supEqfal { get; set; }
        short? ItblSupplyMain.supBrnId { get; set; }
        double? ItblSupplyMain.paidCash { get; set; }
        double? ItblSupplyMain.supBankAmount { get; set; }
        byte ItblSupplyMain.supStatus { get; set; }
    }
}
