namespace AccountingMS
{
    class tblPrdQuanPr
    {
        public int prdId { get; set; }
        public string prdNo { get; set; }
        public string prdName { get; set; }
        public string prdNQuan { get; set; }
        public double prdTotalPrice { get; set; }
        public double prdTotalSalePrice { get; set; }
    }

    class tblPrdQuanPrDetailted
    {
        public int prdId { get; set; }
        public string prdNo { get; set; }
        public string Barcode { get; set; }
        public string prdName { get; set; }
        public string prdNQuan { get; set; }
        public string prdNQuan2 { get; set; }
        public string prdNQuan3 { get; set; }
        public double prdTotalPrice { get; set; }
        public double prdTotalSalePrice { get; set; }
        public double prdAveTotalPrice { get; set; }
        
    }

}
