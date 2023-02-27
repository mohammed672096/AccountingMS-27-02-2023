using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblProduct
    {
        public ClsTblProduct()
        {
            //if (Session.Products.Count <= 0)
            Session.GetDataProducts();
        }
        public void RefreshData()
        {
            Session.GetDataProducts();
        }
        int groNo;
        public tblProduct ChickDataProduct(tblProduct obj, tblPrdPriceMeasurment PrdPriceMeasurment, string barcode)
        {
            if ((obj == null && PrdPriceMeasurment != null))
            {
                using (var db = new accountingEntities())
                {
                    obj = db.tblProducts.AsNoTracking().AsQueryable().FirstOrDefault(x => x.id == PrdPriceMeasurment.ppmPrdId);
                    if (obj != null) return obj;
                    var proSub = db.tblSupplySubs.FirstOrDefault(x => x.supPrdId == PrdPriceMeasurment.ppmPrdId & x.supBrnId == PrdPriceMeasurment.ppmBrnId);
                    if (proSub != null)
                    {
                        int gr = Convert.ToInt32(proSub.supPrdNo.Substring(0, proSub.supPrdNo.IndexOf("-")));
                        var gro = db.tblGroupStrs.Where(x => x.grpNo == gr & x.grpBrnId == PrdPriceMeasurment.ppmBrnId).ToList();
                        if (gro.Count > 0) groNo = gro[0].id;
                        db.InsertProduct(proSub.supPrdId.Value, proSub.supPrdNo, proSub.supPrdName, PrdPriceMeasurment.ppmBrnId, PrdPriceMeasurment.ppmStatus, groNo);
                        return db.tblProducts.FirstOrDefault(x => x.id == proSub.supPrdId.Value);
                    }
                    else
                    {
                        var pr = db.tblPrdPriceMeasurments.FirstOrDefault(x => x.ppmId == PrdPriceMeasurment.ppmId);
                        if (pr != null)
                            db.tblPrdPriceMeasurments.Remove(pr);
                        var bar = db.tblBarcode.Where(x => x.brcNo == barcode & x.brcPrdMsurId == PrdPriceMeasurment.ppmId & x.brcBrnId == PrdPriceMeasurment.ppmBrnId).ToList();
                        db.SaveChanges();
                        if (bar.Count() > 0)
                        {
                            db.tblBarcode.RemoveRange(bar);
                            bar.ForEach(x => Session.tblBarcode.Remove(Session.tblBarcode.FirstOrDefault(y => y.id == x.id)));
                        }
                        if (Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == PrdPriceMeasurment.ppmId) is tblPrdPriceMeasurment tblPrdPrice && tblPrdPrice != null)
                            Session.tblPrdPriceMeasurment.Remove(tblPrdPrice);
                        return null;
                    }
                }
            }
            return obj;
        }
        public IList<tblProduct> GetProductList => Session.Products;

        public IList<tblProduct> GetProductListByType(ProductType productType)
        {
            byte status = (byte)productType;
            return Session.Products.AsQueryable().Where(x => x.prdStatus == status).ToList();
        }

        public List<tblProduct> GetTblProductListByGrpId(int grpId)
        {
            return Session.Products.AsQueryable().Where(x => x.prdGrpNo == grpId).ToList();
        }

        public tblProduct GetPrdObjByPrdId(int prdId)
        {
            return Session.Products.AsQueryable().FirstOrDefault(x => x.id == prdId);
        }

        public string GetPrdNoById(int prdId)
        {
            return Session.Products.AsQueryable().FirstOrDefault(x => x.id == prdId)?.prdNo;
        }

        public string GetPrdNameById(int prdId)
        {
            return Session.Products.AsQueryable().FirstOrDefault(x => x.id == prdId)?.prdName;
        }
        public string GetPrdNameEnById(int prdId)
        {
            return Session.Products.AsQueryable().FirstOrDefault(x => x.id == prdId)?.prdNameEng;
        }

        public int GetPrdGroupIdByPrdId(int prdId)
        {
            return Session.Products.AsQueryable().FirstOrDefault(x => x.id == prdId)?.prdGrpNo ?? 0;
        }

        public bool IsServicePrd(int prdId)
        {
            return Session.Products.AsQueryable().Any(x => x.id == prdId && x.prdStatus == 2);
        }

        public bool ValidatePrdNo(string prdNo)
        {
            return Session.Products.AsQueryable().Any(x => x.prdNo == prdNo);
        }
        public string GetNewProductdNo(int grpId)
        {
            using (var db = new accountingEntities())
            {
                var tmpList = db.tblProducts.AsNoTracking().Where(x => x.prdBrnId == Session.CurBranch.brnId && !x.Suspended && x.prdGrpNo == grpId).ToList();
                var fg = tmpList.Select(x => x.prdNo.Substring(x.prdNo.LastIndexOf('-') + 1));
                var dd = fg.Where(x => int.TryParse(x, out int max)).Select(x => int.Parse(x)).ToList();
                return (dd.Count > 0 ? dd.Max() + 1 : 1).ToString();
            }
        }
        public bool DeleteProductsByProductDataList(IEnumerable<tblProductData> tbProductDataList)
        {
            using (var db = new accountingEntities())
            {
                foreach (var tbProductData in tbProductDataList)
                {
                    tblProduct tbProduct = db.tblProducts.FirstOrDefault(x => x.id == tbProductData.id);
                    if (tbProduct == null) continue;
                    db.tblProducts.Remove(tbProduct);
                }
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.GetDataProducts();
                    return true;
                }
                return false;
            }
        }
    }
}
