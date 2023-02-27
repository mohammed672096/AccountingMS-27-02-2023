using System;

namespace AccountingMS
{
    public partial class tblSupplyMainDetail : ItblSupplyMainDetail
    {
        public int id { get; set; }
        public int supNo { get; set; }
        public long? supAccNo { get; set; }
        public string supAccName { get; set; }
        public int? supRefNo { get; set; }
        public string supDesc { get; set; }
        public double supTotal { get; set; }
        public double? supTotalFrgn { get; set; }
        public byte? supTaxPercent { get; set; }
        public double? supTaxPrice { get; set; }
        public byte? supCurrency { get; set; }
        public short? supCurrencyChng { get; set; }
        public DateTime? supDate { get; set; }
        public byte? supIsCash { get; set; }
        public byte? supEqfal { get; set; }
        public short supUserId { get; set; }
        public short? supBrnId { get; set; }
        public byte supStatus { get; set; }
        public int? supCustSplId { get; set; }
        public int? reprID { get; set; }
        public double supTotalFinal { get; set; }
        public double supPaidCash { set; get; }
        public double supPaidBank { set; get; }
        public double supPaidCredit { get; set; }
        public double? supDscntPercent { get; set; }
        public double? supDscntAmount { get; set; }
        public double? supBankAmount { get; set; }
        public double? paidCash { get; set; }
        public double supDiscount { get; set; }
        public double supPrdPrice { get; set; }
        public double supPrdSalePrice { get; set; }
        public double supProfit { get; set; }
        public float supProfitPercent { get; set; }
        public string PoNumber { get; set; }
        //public int? reprID { get; set; }
        public string Notes { get; set; }
        public DateTime? DueDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string PaymentTeam { get; set; }
        public string FieldNumber { get; set; }
        public DateTime? PeriodFrome { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
