using System;

namespace AccountingMS
{
    public partial class tblSupplyMain : ItblSupplyMainDetail, ItblSupplyMainDetailInvoice, ItblSupplyMainCustom
    {
        public tblSupplyMain ShallowCopy()
        {
            return (tblSupplyMain)this.MemberwiseClone();
        }
        double ItblSupplyMainDetail.supTotalFinal { get; set; }
        double ItblSupplyMainDetail.supPaidCash { get; set; }
        double ItblSupplyMainDetail.supPaidCredit { get; set; }
        double ItblSupplyMainDetail.supPrdPrice { get; set; }
        double ItblSupplyMainDetail.supPrdSalePrice { get; set; }
        double ItblSupplyMainDetail.supProfit { get; set; }
        float ItblSupplyMainDetail.supProfitPercent { get; set; }
        double ItblSupplyMainCustom.paidCash { get; set; }
        //double ItblSupplyMainCustom.supBankAmount { get; set; }
        double ItblSupplyMainCustom.remin { get; set; }
        int ItblSupplyMainDetailInvoice.sclId { get; set; }
        double ItblSupplyMainDetailInvoice.supTotalFinal { get; set; }
        string ItblSupplyMainCustom.cusBuildingNo { get; set; }
        string ItblSupplyMainCustom.cusAddNo { get; set; }
        string ItblSupplyMainCustom.cusAnotherID { get; set; }
        string ItblSupplyMainCustom.cusDistrict { get; set; }
        string ItblSupplyMainCustom.cusDistrictEn { get; set; }
        string ItblSupplyMainCustom.custCity { get; set; }
        string ItblSupplyMainCustom.custCityEn { get; set; }
        double ItblSupplyMainCustom.supTotalPrice { get; set; }
        double ItblSupplyMainCustom.supTotalFinal { get; set; }
        string ItblSupplyMainCustom.supCurrencyStr { get; set; }
        string ItblSupplyMainCustom.supUserIdStr { get; set; }
        string ItblSupplyMainCustom.supIsCashStr { get; set; }
        string ItblSupplyMainCustom.supStatusStr { get; set; }
        string ItblSupplyMainCustom.custName { get; set; }
        string ItblSupplyMainCustom.repName { get; set; }
        //string ItblSupplyMain.repName { get; set; }
        int? ItblSupplyMain.reprID { get; set; }
        string ItblSupplyMainCustom.custAddress { get; set; }
        int ItblSupplyMainCustom.custNo { get; set; }
        string ItblSupplyMainCustom.custPhnNo { get; set; }
        string ItblSupplyMainCustom.custTaxNo { get; set; }
        int? ItblSupplyMainDetail.supRefNo { get; set; }
        int? ItblSupplyMain.supRefNo { get; set; }
        public string custNameEn { get; set; }
        public string custAddressEn { get; set; }
        public string CommercialRegister { get; set; }
        public string PostalCode { get; set; }

        public string CustCountry { get; set; }
        public string CustCountryEn { get; set; }
        public string NetTextAr { get; set; }
        public string NetTextEn { get; set; }
        public string TaxAsTextEn { get; set; }
        public string TaxAsTextAr { get; set; }
        public string bankName { get; set; }
        public string bankNameEn { get; set; }
        public string bankSwiftCode { get; set; }
        public string AccNoInBank { get; set; }
        public string bankAccIBAN { get; set; }


    }
}
