using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblBarcode
    {
        public ClsTblBarcode()
        {
            //  if (Session.tblBarcode.Count <= 0)
            Session.GetDataBarcodes();
        }
        public List<tblBarcode> tbBarcodeList => Session.tblBarcode;
        public void RefreshData()
        {
            Session.GetDataBarcodes();
        }

        public IEnumerable<tblBarcode> GetBarcodeListByPrdMsurId(int prdMsurId)
        {
            return Session.tblBarcode.Where(x => x.brcPrdMsurId == prdMsurId).ToList();
        }
        string barcodeWeight(string barcode) => MySetting.DefaultSetting.ReadFormScaleBarcode && barcode.Length == MySetting.DefaultSetting.BarcodeLength &&
                      barcode.StartsWith(MySetting.DefaultSetting.ScaleBarcodePrefix) ?
                       Convert.ToInt32(barcode.Substring(MySetting.DefaultSetting.ScaleBarcodePrefix.Length, MySetting.DefaultSetting.ProductCodeLength)).ToString() : barcode;
        public int GetProductIDByNo(string barcode)
        {
            var obj = GetBarcodeObjByNo(barcode);
            if (obj == null) return -1;
            var tbPrdMsur = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == obj.brcPrdMsurId);
            return (tbPrdMsur?.ppmPrdId) ?? -1;
        }
        public tblBarcode GetBarcodeObjByNo(string barcode)
        {
            barcode = barcodeWeight(barcode);
            return Session.tblBarcode.FirstOrDefault(x => x.brcNo == barcode && x.brcBrnId == Session.CurBranch.brnId);
        }

        public tblBarcode GetBarcodeObjByPrdMsurId(int prdMsurId)
        {
            return Session.tblBarcode.FirstOrDefault(x => x.brcPrdMsurId == prdMsurId);
        }
        public string GetFirstBarcodeByPrdMsurId(int prdMsurId) => GetBarcodeObjByPrdMsurId(prdMsurId)?.brcNo ?? string.Empty;


        public bool IsBarcodeNoFound(string barcodeNo)
        {
            return Session.tblBarcode.Any(x => x.brcNo == barcodeNo);
        }

        public bool IsBarcodeNoFoundByNoNdMsurId(string barcodeNo, int prdMsurId)
        {
            barcodeNo = barcodeWeight(barcodeNo);
            return Session.tblBarcode.Any(x => x.brcNo == barcodeNo && x.brcPrdMsurId != prdMsurId);
        }

        public bool Remove(tblBarcode tbBarcode)
        {
            using (var db = new accountingEntities())
            {
                if (db.tblBarcode.FirstOrDefault(x => x.id == tbBarcode.id) is tblBarcode bar && bar != null)
                {
                    db.tblBarcode.Remove(bar);
                    if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                    {
                        Session.tblBarcode.Remove(bar);
                        return true;
                    }
                }
                return false;
            }
        }

        public tblProductDataRow1 GetProductDataObjByBarcodeNo(string barcode)
        {
            barcode = barcodeWeight(barcode);
            using (var db = new accountingEntities())
            {
                return (from bar in db.tblBarcode.AsNoTracking().Where(x => x.brcBrnId == Session.CurBranch.brnId)
                        join Msur in db.tblPrdPriceMeasurments.AsNoTracking().Where(x => x.ppmBrnId == Session.CurBranch.brnId) on bar.brcPrdMsurId equals Msur.ppmId
                        join product in db.tblProducts.AsNoTracking().Where(x => x.Suspended == false) on Msur.ppmPrdId equals product.id
                        where bar.brcNo == barcode
                        select new tblProductDataRow1
                        {
                            tblBarcode = bar,
                            tblProduct = product,
                            PrdMeasurment = Msur,
                        }).FirstOrDefault();
            }
        }

        public string GetBarcodeNoByPrdMsurId(int prdMsurId)
        {
            return (Session.tblBarcode.FirstOrDefault(x => x.brcPrdMsurId == prdMsurId)?.brcNo) ?? string.Empty;
        }
    }
}
