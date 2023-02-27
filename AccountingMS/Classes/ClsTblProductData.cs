using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblProductData
    {
        ClsTblProduct clsTbProduct = new ClsTblProduct();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblProductQunatity clsTbPrdQuant;
        ClsTblBarcode clsTblBarcode = new ClsTblBarcode();
        IList<tblProductData> tbPrdDataList;

        public ClsTblProductData()
        {
            this.clsTbPrdQuant = new ClsTblProductQunatity();
            InitProductNdQuantData();
            //InitPrdPriceMsurData();
        }

        public IEnumerable<tblProductData> GetProductDataList => this.tbPrdDataList;

        private void InitProductNdQuantData()
        {
            this.tbPrdDataList = (from product in this.clsTbProduct.GetProductList.Where(x=>x.prdBrnId==Session.CurBranch.brnId)
                                  orderby product.prdName
                                  join prdQuantity in this.clsTbPrdQuant.GetPrdQuantityList
                                  on product.id equals prdQuantity.prdId into prdQuantityGrp
                                  join prdPrice in this.clsTbPrdMsur.GetPrdPriceMsurList
                                  on product.id equals prdPrice.ppmPrdId into prdPriceGrp
                                  select new tblProductData
                                  {
                                      id = product.id,
                                      prdNo = product.prdNo,
                                      prdName = product.prdName,
                                      prdNameEng = product.prdNameEng,
                                      prdGrpNo = product.prdGrpNo,
                                      prdQuantity = prdQuantityGrp.Sum(x => x.prdQuantity),
                                      prdSubQuantity = prdQuantityGrp.Sum(x => x.prdSubQuantity),
                                      prdSubQuantity3 = prdQuantityGrp.Sum(x => x.prdSubQuantity3),
                                      ppmId1 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 1)?.ppmId)??0,
                                      ppmMsurName1 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 1)?.ppmMsurName),
                                      ppmConversion1 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)?.ppmConversion,
                                      ppmPrice1 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)?.ppmPrice,
                                      ppmSalePrice1 = clsTbPrdMsur.GetppmSalePrice(product.prdPriceTax,prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)),
                                      ppmMinSalePrice1 = clsTbPrdMsur.GetppmMinSalePrice(product.prdPriceTax,prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)),
                                      ppmRetailPrice1 =  clsTbPrdMsur.GetppmRetailPrice(product.prdPriceTax,prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)),
                                      ppmBatchPrice1 = clsTbPrdMsur.GetppmBatchPrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 1)),
                                      
                                      ppmId2 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 2)?.ppmId) ?? 0,
                                      ppmMsurName2 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 2)?.ppmMsurName),
                                      ppmConversion2 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)?.ppmConversion,
                                      ppmPrice2 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)?.ppmPrice,
                                      ppmSalePrice2 = clsTbPrdMsur.GetppmSalePrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)),
                                      ppmMinSalePrice2 = clsTbPrdMsur.GetppmMinSalePrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)),
                                      ppmRetailPrice2 = clsTbPrdMsur.GetppmRetailPrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)),
                                      ppmBatchPrice2 = clsTbPrdMsur.GetppmBatchPrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 2)),

                                      ppmId3 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 3)?.ppmId) ?? 0,
                                      ppmMsurName3 = (prdPriceGrp?.FirstOrDefault(x => x.ppmStatus == 3)?.ppmMsurName),
                                      ppmConversion3 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)?.ppmConversion,
                                      ppmPrice3 = prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)?.ppmPrice,
                                      ppmSalePrice3 = clsTbPrdMsur.GetppmSalePrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)),
                                      ppmMinSalePrice3 = clsTbPrdMsur.GetppmMinSalePrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)),
                                      ppmRetailPrice3 = clsTbPrdMsur.GetppmRetailPrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)),
                                      ppmBatchPrice3 = clsTbPrdMsur.GetppmBatchPrice(product.prdPriceTax, prdPriceGrp.FirstOrDefault(x => x.ppmStatus == 3)),
                               
                                  }).ToList();
            this.tbPrdDataList = (from product in this.tbPrdDataList
                                  orderby product.prdName
                                  join prdBarcod1 in this.clsTblBarcode.tbBarcodeList
                                  on product.ppmId1 equals prdBarcod1.brcPrdMsurId into prdBarcodGrp1
                                  join prdBarcod2 in this.clsTblBarcode.tbBarcodeList
                                  on product.ppmId2 equals prdBarcod2.brcPrdMsurId into prdBarcodGrp2
                                  join prdBarcod3 in this.clsTblBarcode.tbBarcodeList
                                  on product.ppmId3 equals prdBarcod3.brcPrdMsurId into prdBarcodGrp3
                                  select new tblProductData
                                  {
                                      id = product.id,
                                      prdNo = product.prdNo,
                                      prdName = product.prdName,
                                      prdNameEng = product.prdNameEng,
                                      prdGrpNo = product.prdGrpNo,
                                      prdQuantity = product.prdQuantity,
                                      prdSubQuantity = product.prdSubQuantity,
                                      prdSubQuantity3 = product.prdSubQuantity3,
                                      ppmId1 = product.ppmId1,
                                      ppmMsurName1 = product.ppmMsurName1,
                                      ppmConversion1 = product.ppmConversion1,
                                      ppmPrice1 = product.ppmPrice1,
                                      ppmSalePrice1 = product.ppmSalePrice1,
                                      ppmMinSalePrice1 = product.ppmMinSalePrice1,
                                      ppmRetailPrice1 = product.ppmRetailPrice1,
                                      ppmBatchPrice1 = product.ppmBatchPrice1,
                                      ppmId2 = product.ppmId2,
                                      ppmMsurName2 = product.ppmMsurName2,
                                      ppmConversion2 = product.ppmConversion2,
                                      ppmPrice2 = product.ppmPrice2,
                                      ppmSalePrice2 = product.ppmSalePrice2,
                                      ppmMinSalePrice2 = product.ppmMinSalePrice2,
                                      ppmRetailPrice2 = product.ppmRetailPrice2,
                                      ppmBatchPrice2 = product.ppmBatchPrice2,
                                      ppmId3 = product.ppmId3,
                                      ppmMsurName3 = product.ppmMsurName3,
                                      ppmConversion3 = product.ppmConversion3,
                                      ppmPrice3 = product.ppmPrice3,
                                      ppmSalePrice3 = product.ppmSalePrice3,
                                      ppmMinSalePrice3 = product.ppmMinSalePrice3,
                                      ppmRetailPrice3 = product.ppmRetailPrice3,
                                      ppmBatchPrice3 = product.ppmBatchPrice3,
                                      ppmBarcode11 = prdBarcodGrp1 != null ? GetBarCode(prdBarcodGrp1.ToList(), 0) : null,
                                      ppmBarcode12 = prdBarcodGrp1 != null ? GetBarCode(prdBarcodGrp1.ToList(), 1) : null,
                                      ppmBarcode13 = prdBarcodGrp1 != null ? GetBarCode(prdBarcodGrp1.ToList(), 2) : null,
                                      ppmBarcode21 = prdBarcodGrp2 != null ? GetBarCode(prdBarcodGrp2.ToList(), 0) : null,
                                      ppmBarcode22 = prdBarcodGrp2 != null ? GetBarCode(prdBarcodGrp2.ToList(), 1) : null,
                                      ppmBarcode23 = prdBarcodGrp2 != null ? GetBarCode(prdBarcodGrp2.ToList(), 2) : null,
                                      ppmBarcode31 = prdBarcodGrp3 != null ? GetBarCode(prdBarcodGrp3.ToList(), 0) : null,
                                      ppmBarcode32 = prdBarcodGrp3 != null ? GetBarCode(prdBarcodGrp3.ToList(), 1) : null,
                                      ppmBarcode33 = prdBarcodGrp3 != null ? GetBarCode(prdBarcodGrp3.ToList(), 2) : null,
                                      totalQuanPrice = (Convert.ToDouble(product.prdQuantity) * ((product.ppmPrice1 as double?) ?? 0)) + (Convert.ToDouble(product.prdSubQuantity) * ((product.ppmPrice2 as double?) ?? 0))
                                      + (Convert.ToDouble(product.prdSubQuantity3) * ((product.ppmPrice3 as double?) ?? 0)),
                                      totalBatchPrice = (Convert.ToDouble(product.prdQuantity) * ((product.ppmBatchPrice1 as double?) ?? 0)) + (Convert.ToDouble(product.prdSubQuantity) * ((product.ppmBatchPrice2 as double?) ?? 0))
                                      + (Convert.ToDouble(product.prdSubQuantity3) * ((product.ppmBatchPrice3 as double?) ?? 0)),
                                      totalQuanSalePrice = (Convert.ToDouble(product.prdQuantity) * ((product.ppmSalePrice1 as double?) ?? 0)) + (Convert.ToDouble(product.prdSubQuantity) * ((product.ppmSalePrice2 as double?) ?? 0))
                                      + (Convert.ToDouble(product.prdSubQuantity3) * ((product.ppmSalePrice3 as double?) ?? 0)),

                                  }).ToList();
        }
       
        string GetBarCode(List<tblBarcode> tblBarcodes, int index)
        {
            for (int i = 0; i < tblBarcodes.Count; i++)
            {
                if (i == index) return tblBarcodes[i].brcNo;
            }
            return default;
        }
    }
}
