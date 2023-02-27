namespace AccountingMS
{
    public class tblProductData //: ItblProductData
    {
        //tblProduct//
        public int id { get; set; }
        public string prdNo { get; set; }
        public string prdName { get; set; }
        public string prdNameEng { get; set; }
        public int prdGrpNo { get; set; }
        public string prdDesc { get; set; }
        public short? prdStrNo { get; set; }
        public short? prdBrnId { get; set; }
        public byte prdStatus { get; set; }
        //EndtblProduct//

        //tblProductQuantity//
        public double? prdQuantity { get; set; }
        public double? prdSubQuantity { get; set; }
        public double? prdSubQuantity3 { get; set; }
        //EndtblProductQuantity//

        //tblPrdPriceMeasurment//
        public int ppmId1 { get; set; }
        public string ppmMsurName1 { get; set; }
        public double? ppmConversion1 { get; set; }
        public double? ppmPrice1 { get; set; }
        public double? ppmSalePrice1 { get; set; }
        public double? ppmMinSalePrice1 { get; set; }
        public double? ppmRetailPrice1 { get; set; }
        public double? ppmBatchPrice1 { get; set; }
        public string ppmBarcode11 { get; set; }
        public string ppmBarcode12 { get; set; }
        public string ppmBarcode13 { get; set; }

        public int ppmId2 { get; set; }
        public string ppmMsurName2 { get; set; }
        public double? ppmConversion2 { get; set; }
        public double? ppmPrice2 { get; set; }
        public double? ppmSalePrice2 { get; set; }
        public double? ppmMinSalePrice2 { get; set; }
        public double? ppmRetailPrice2 { get; set; }
        public double? ppmBatchPrice2 { get; set; }
        public string ppmBarcode21 { get; set; }
        public string ppmBarcode22 { get; set; }
        public string ppmBarcode23 { get; set; }

        public int ppmId3 { get; set; }
        public string ppmMsurName3 { get; set; }
        public double? ppmConversion3 { get; set; }
        public double? ppmPrice3 { get; set; }
        public double? ppmSalePrice3 { get; set; }
        public double? ppmMinSalePrice3 { get; set; }
        public double? ppmRetailPrice3 { get; set; }
        public double? ppmBatchPrice3 { get; set; }
        public string ppmBarcode31 { get; set; }
        public string ppmBarcode32 { get; set; }
        public string ppmBarcode33 { get; set; }
        //EndtblPrdPriceMeasurment//

        //AdditonalProperties//
        public double totalQuanPrice { get; set; }
        public double totalQuanSalePrice { get; set; }
        public double totalBatchPrice { get; set; }
        //EndAdditonalProperties//
    }
}
