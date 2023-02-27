using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblPrdPriceMeasurment
    {

        public double PPMConverstionRate { private set; get; }
        public ClsTblPrdPriceMeasurment()
        {
            //if (Session.tblPrdPriceMeasurment.Count <= 0)
            Session.GetDataPrdMeasurments();
        }
        public void RefreshData()
        {
            Session.GetDataPrdMeasurments();
        }

        public IList<tblPrdPriceMeasurment> GetPrdPriceMsurList => Session.tblPrdPriceMeasurment;

        public tblPrdPriceMeasurment GetPrdPriceMsurDefaultRowByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmDefault == true);
        }
        public double GetppmSalePrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea==null?0:((PriceTax ? priceMea.ppmSalePrice / 1.15 : priceMea.ppmSalePrice) ?? 0);
        public double GetppmMinSalePrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmMinSalePrice / 1.15 : priceMea.ppmMinSalePrice) ?? 0);
        public double GetppmRetailPrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmRetailPrice / 1.15 : priceMea.ppmRetailPrice) ?? 0);
        public double GetppmBatchPrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmBatchPrice / 1.15 : priceMea.ppmBatchPrice) ?? 0);
        public IList<tblPrdPriceMeasurment> GetPrdPriceMsurListByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == prdId).ToList();
        }

        public string GetPrdPriceMsurNameByPrdIdNdStatus(int prdId, byte status)
        {
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == status)?.ppmMsurName;
        }

        //public bool IsBarcodeCouponNoFound(string barcode)
        //{
        //    return Session.CouponBarcodes.Any(x => x.BarCode == barcode);
        //}
        public string GetPrdPriceMsurNameById(int ppmId)
        {
            if (ppmId == 0) return null;
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == ppmId)?.ppmMsurName;
        }

        public byte GetPrdPriceMsurStatus(int ppmId)
        {
            var tbPrdMsur = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == ppmId) ?? Session.tblPrdPriceMeasurment.FirstOrDefault();
            this.PPMConverstionRate = (tbPrdMsur?.ppmConversion) ?? 0;
            if (tbPrdMsur == null)
                return ((byte)0);
            else
                return tbPrdMsur.ppmStatus;

        }

        public bool IsBarcodeNoFound(string barcode)
        {
            return Session.tblBarcode.Any(x => x.brcNo == barcode);
        }

        public bool IsPrdIdFound(int prdId)
        {
            return Session.tblPrdPriceMeasurment.Any(x => x.ppmPrdId == prdId);
        }

        public string GetFirstBarcodeById(int ppmId)
        {
            if (ppmId == 0) return null;
            return (Session.tblBarcode.FirstOrDefault(x => x.brcPrdMsurId == ppmId)?.brcNo) ?? string.Empty;
        }
        public tblPrdPriceMeasurment GetPrdPriceMsurById(int ppmId)
        {
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == ppmId);
        }
        public tblPrdPriceMeasurment GetPrdPriceMsurObjByBarcodeNo(string barcode)
        {
            var Barcode = new ClsTblBarcode().GetBarcodeObjByNo(barcode);
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == Barcode?.brcPrdMsurId);
        }


        public tblPrdPriceMeasurment GetPrdPriceMsurObjById(int msurId)
        {
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == msurId);
        }

        public tblPrdPriceMeasurment GetPrdPriceMsurObjByBarcodeNoStore(string barcode)
        {
            return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmBarcode1 == barcode || x.ppmBarcode2 == barcode || x.ppmBarcode3 == barcode);
        }

        public double GetPrdPriceMsutPriceById(int msurId)
        {
            return (Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == msurId)?.ppmPrice) ?? 0;
        }
        public double GetPrdPriceMsurConvertionRate2ByPrdId(int prdId)
        {
            return (Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == 2)?.ppmConversion) ?? 0;
        }

        public double GetPrdPriceMsurConvertionRate3ByPrdId(int prdId)
        {
            return Convert.ToDouble(Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == prdId && x.ppmStatus == 3).Select(x => x.ppmConversion ?? 0).FirstOrDefault());
        }

        public string GetPrdPriceMsurBarcodeById(int msurId)
        {
            return Session.tblBarcode.FirstOrDefault(x => x.brcPrdMsurId == msurId)?.brcNo;
        }
        public bool DeletePrdPriceMsutByProductDataList(IList<tblProductData> tbProductDataList)
        {
            using (accountingEntities db = new accountingEntities())
            {
                foreach (var tbProductData in tbProductDataList)
                {
                    tblPrdPriceMeasurment tbPrdPriceMsur = db.tblPrdPriceMeasurments.FirstOrDefault(x => x.ppmPrdId == tbProductData.id && x.ppmStatus == 1);
                    if (tbPrdPriceMsur == null) continue;
                    db.tblPrdPriceMeasurments.Remove(tbPrdPriceMsur);

                }
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.GetDataPrdMeasurments();
                    return true;
                }
                return false;
            }
        }

        public tblPrdPriceMeasurment GetPrdPriceMsurUnit1ObjectByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == 1);
        }

        public string GetPrdPriceMsurUnitName1ByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == 1)?.ppmMsurName;
        }

        public string GetPrdPriceMsurUnitName2ByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == 2)?.ppmMsurName;
        }

        public string GetPrdPriceMsurUnitName3ByPrdId(int prdId)
        {
            return Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == 3)?.ppmMsurName;
        }

        public double GetPrdPriceMsurSalePrice(int ppmId)
        {
            var ppm = Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == ppmId);
            if (ppm == null) return 0;
            var prTax = Session.Products.FirstOrDefault(x => x.id == ppm.ppmPrdId)?.prdPriceTax ?? false;
            return GetppmSalePrice(prTax, ppm);
        }

        public double GetPrdPriceMsurMinSalePrice(int ppmId)
        {
            var ppm = Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == ppmId);
            if (ppm == null) return 0;
            var prTax = Session.Products.FirstOrDefault(x => x.id == ppm.ppmPrdId)?.prdPriceTax ?? false;
            return GetppmMinSalePrice(prTax, ppm);
        }

        public int GetPrdPriceMsurIdByPrdIdNdStatus(int prdId, byte ppmStatus)
        {
            return (Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == ppmStatus)?.ppmId) ?? 0;
        }

        public double GetPrdPriceMsurPriceByPrdIdNdStatus(int prdId, byte ppmStatus)
        {
            return (Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmPrdId == prdId && x.ppmStatus == ppmStatus).ppmPrice) ?? 0;
        }

        public bool ValidatePrdMsur(int prdId, int msurId)
        {
            return Session.tblPrdPriceMeasurment.Any(x => x.ppmPrdId == prdId && x.ppmId == msurId);
        }
    }
}
