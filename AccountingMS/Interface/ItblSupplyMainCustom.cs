using System;

namespace AccountingMS
{
    public interface ItblSupplyMainCustom : ItblSupplyMain
    {
        double supTotalPrice { get; set; }
        double supTotalFinal { get; set; }
        string supCurrencyStr { get; set; }
        string supUserIdStr { get; set; }
        string supIsCashStr { get; set; }
        string supStatusStr { get; set; }
        string custName { get; set; }
        string custAddress { get; set; }
        int custNo { get; set; }
        string cusBuildingNo { get; set; }
        string cusAddNo { get; set; }
        string cusAnotherID { get; set; }
        string cusDistrict { get; set; }
        string cusDistrictEn { get; set; }
        string custCity { get; set; }
        string custCityEn { get; set; }
        string custPhnNo { get; set; }
        string custTaxNo { get; set; }
        string CarType { get; set; }
        public string repName { get; set; }
        string PlateNumber { get; set; }
        string CounterNumber { get; set; }
        double paidCash { get; set; }
        //double supBankAmount { get; set; }
        double remin { get; set; }
        public string custNameEn { get; set; }
        public string custAddressEn { get; set; }
        public string CommercialRegister { get; set; }
        public string PostalCode { get; set; }
        public string CustCountry { get; set; }
        public string CustCountryEn { get; set; }
        public string PoNumber { get; set; }
        //public int? reprID { get; set; }
        public string RegistrationNumber { get; set; }

        public string PaymentTeam { get; set; }
        public string FieldNumber { get; set; }
        public DateTime? PeriodFrome { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Notes { get; set; }
       
        public string NetTextAr { get; set; }
    
        public string NetTextEn { get; set; } 
        public string TaxAsTextEn { get; set; }
        
        public string TaxAsTextAr { get; set; }

        public string bankName { get; set; }
        public string bankNameEn { get; set; }
        public string bankSwiftCode { get; set; }
        public DateTime? DueDate { get; set; }
        public string AccNoInBank { get; set; }
        public string bankAccIBAN { get; set; }
    }
}