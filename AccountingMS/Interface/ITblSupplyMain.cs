using System;

namespace AccountingMS
{
    public interface ItblSupplyMain
    {
        int id { get; set; }
        int supNo { get; set; }
        long? supAccNo { get; set; }
        string supAccName { get; set; }
        int? supRefNo { get; set; }
        string supDesc { get; set; }
        double supTotal { get; set; }
        double? supTotalFrgn { get; set; }
        double? supBankAmount { get; set; }
        double? paidCash { get; set; }

        double? supDscntPercent { get; set; }
        double? supDscntAmount { get; set; }
        byte? supTaxPercent { get; set; }
        double? supTaxPrice { get; set; }
        byte? supCurrency { get; set; }
        short? supCurrencyChng { get; set; }
        int? supCustSplId { get; set; }
        int? reprID { get; set; }
        DateTime? supDate { get; set; }
        byte? supIsCash { get; set; }
        byte? supEqfal { get; set; }
        short supUserId { get; set; }
        short? supBrnId { get; set; }
        byte supStatus { get; set; }
        string PoNumber { get; set; }
        //public string repName { get; set; }
        public string RegistrationNumber { get; set; }

        public string PaymentTeam { get; set; }
        public string FieldNumber { get; set; }
        public DateTime? PeriodFrome { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        string Notes { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
