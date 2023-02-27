namespace AccountingMS
{
    class tblPrdSaleDetail
    {
        public long grpAccNo { get; set; }
        public int prdId { get; set; }
        public string prdName { get; set; }
        public double prdQuant { get; set; }
        public double prdQuantRtrn { get; set; }
        public string prdQuanRemaining { get; set; }
        public string prdQuantString { get; set; }
        public string prdBarcode { get; set; }
        public int prdMsur { get; set; }
        public double prdPrice { get; set; }
        public double prdPriceRtrn { get; set; }
        public double prdSalePrice { get; set; }
        public double prdSalePriceRtrn { get; set; }
        public double prdDscntAmount { get; set; }
        public double prdDscntAmountRtrn { get; set; }
        public double prdTax { get; set; }
        public double prdTaxRtrn { get; set; }
        public double prdSaleTotal { get; set; }
        public double prdSaleProfit { get; set; }
        public string prdSaleProfitPercent { get; set; }
        public short userId { get; set; }
        public short BranchId { get; set; }
    }
}
