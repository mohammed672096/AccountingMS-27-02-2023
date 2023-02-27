namespace AccountingMS
{
    public partial class tblProduct 
    {
        public tblProduct ShallowCopy()
        {
            return (tblProduct)this.MemberwiseClone();
        }

        //double? ItblProductQunatity.prdQuantity { get; set; }
        //double? ItblProductQunatity.prdSubQuantity { get; set; }
        //double? ItblProductQunatity.prdSubQuantity3 { get; set; }
        //double ItblProductData.totalQuanPrice { get; set; }
        //double ItblProductData.totalQuanSalePrice { get; set; }
        //double ItblProductData.totalBatchPrice { get; set; }
    }
}
