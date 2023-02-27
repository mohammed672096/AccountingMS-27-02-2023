using System;

namespace AccountingMS
{
    public interface ItblSupplyMainDetail : ItblSupplyMain
    {
        int id { get; set; }
        int supNo { get; set; }
        long? supAccNo { get; set; }
        string supAccName { get; set; }
        int? supRefNo { get; set; }
        string supDesc { get; set; }
        double supTotal { get; set; }
        double? supTotalFrgn { get; set; }
        byte? supTaxPercent { get; set; }
        double? supTaxPrice { get; set; }
        byte? supCurrency { get; set; }
        short? supCurrencyChng { get; set; }
        DateTime? supDate { get; set; }
        double? paidCash { get; set; }
        double? supBankAmount { get; set; }
        byte? supIsCash { get; set; }
        byte? supEqfal { get; set; }
        short supUserId { get; set; }
        short? supBrnId { get; set; }
        byte supStatus { get; set; }
        double supTotalFinal { get; set; }
        double supPaidCash { set; get; }
        
        double supPaidCredit { get; set; }
        double? supDscntPercent { get; set; }
        double? supDscntAmount { get; set; }
        double supPrdPrice { get; set; }
        double supPrdSalePrice { get; set; }
        double supProfit { get; set; }
        float supProfitPercent { get; set; }
    }
}
