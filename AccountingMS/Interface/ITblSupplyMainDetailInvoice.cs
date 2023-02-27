using System;

namespace AccountingMS
{
    interface ItblSupplyMainDetailInvoice
    {
        int id { get; set; }
        int sclId { get; set; }
        int supNo { get; set; }
        long? supAccNo { get; set; }
        string supAccName { get; set; }
        string supDesc { get; set; }
        byte? supTaxPercent { get; set; }
        double? supTaxPrice { get; set; }
        byte? supCurrency { get; set; }
        short? supCurrencyChng { get; set; }
        DateTime? supDate { get; set; }
        byte? supIsCash { get; set; }
        short? supBrnId { get; set; }
        byte supStatus { get; set; }
        double supTotal { get; set; }
        double? supTotalFrgn { get; set; }
        double supTotalFinal { get; set; }
    }
}
