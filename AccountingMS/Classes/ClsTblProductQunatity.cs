using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblProductQunatity
    {
        private IEnumerable<tblProductQunatity> QueryData => Session.ProductQunatities.AsQueryable();
        public ClsTblProductQunatity()
        {
            Session.GetDataProductQunatities();
        }
        public IEnumerable<tblProductQunatity> GetPrdQuantityListReportStore => this.QueryData;
        public IEnumerable<tblProductQunatity> GetPrdQuantityList => QueryData.ToList();

        public IEnumerable<tblProductQunatity> GetPrdQuantityListByStrId(short strId)
        {
            return QueryData.AsQueryable().Where(x => x.prdStrId == strId).OrderBy(x => x.prdId).ToList();
        }

        public IEnumerable<tblProductQunatity> GetPrdQuantityListByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prdId == prdId).ToList();
        }

        public bool IsPrdQuantityFound(int prdId)
        {
            return QueryData.AsQueryable().Any(x => x.prdId == prdId);
        }

        public tblProductQunatity GetPrdQuantityObjByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prdId == prdId).FirstOrDefault();
        }

        public tblProductQunatity GetPrdQuantityObjByPrdIdNdStrId(int prdId, short strId)
        {
            return QueryData.AsQueryable().FirstOrDefault(x => x.prdId == prdId && x.prdStrId == strId);
        }

        public tblProductQunatity GetTotalPrdQuantityByPrdId(int prdId)
        {
            return QueryData.Where(x => x.prdId == prdId).GroupBy(x => x.prdId, (key, grp) => new tblProductQunatity
            {
                prdId = key,
                prdQuantity = grp.Sum(x => x.prdQuantity),
                prdSubQuantity = grp.Sum(x => x.prdSubQuantity),
                prdSubQuantity3 = grp.Sum(x => x.prdSubQuantity3)
            }).AsQueryable().FirstOrDefault();
        }
        public double GetPrdQuantityByPrdIdNdMsurStatus(int prdId, byte msurStatus)
        {
            return msurStatus switch
            {
                1 => (QueryData.AsQueryable()?.FirstOrDefault(x => x.prdId == prdId)?.prdQuantity) ?? 0,
                2 => (QueryData.AsQueryable()?.FirstOrDefault(x => x.prdId == prdId)?.prdSubQuantity) ?? 0,
                3 => (QueryData.AsQueryable()?.FirstOrDefault(x => x.prdId == prdId)?.prdSubQuantity3) ?? 0,
                _ => 0
            };
        }
        public double GetTotalPrdQuantityByPrdINddMsurStatus(int prdId, tblPrdPriceMeasurment prdMsur, int strId)
        {
            tblProductQunatity tbPrdQty = QueryData.AsQueryable().FirstOrDefault(x => x.prdStrId == strId && x.prdId == prdId);
            if (tbPrdQty == null|| prdMsur==null) return 0;
            return (tbPrdQty.prdQuantity ?? 0) / (prdMsur.ppmConversion ?? 1);
        }
       
        //public void Attach(tblProductQunatity tbPrdQuantity)
        //{
        //    db.tblProductQunatities.Attach(tbPrdQuantity);
        //}

        //public void Add(tblProductQunatity tbPrdQuan)
        //{
        //    db.tblProductQunatities.Add(tbPrdQuan);
        //}

        //public void Add(ClsProductQuantList prdQuantity)
        //{
        //    tblProductQunatity tbPrdQuantiy = new tblProductQunatity()
        //    {
        //        prdId = prdQuantity.prdId,
        //        prdStrId = prdQuantity.prdStrId,
        //        prdBrnId = Session.CurBranch.brnId,
        //        prdStatus = 1,
        //        prdQuantity = 0,
        //        prdSubQuantity = 0,
        //        prdSubQuantity3 = 0
        //    };
        //    db.tblProductQunatities.Add(tbPrdQuantiy);
        //    if (SaveDB) Console.WriteLine("Added tbPrdQuantiy");
        //}

        public bool DeleteProductsByProductDataList(IEnumerable<tblProductData> tbProductDataList)
        {
            using (var db=new accountingEntities())
            {
                tbProductDataList.ToList().ForEach(x =>
                {
                    if (db.tblProductQunatities.Any(x=>x.prdId == x.id))
                      db.tblProductQunatities.RemoveRange(db.tblProductQunatities.Where(y=>y.prdId==x.id));
                });
                if(ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.GetDataProductQunatities();
                    return true;
                }
                return false;
            }
        }

        //public bool DeletePrdQuanByPrdId(int prdId)
        //{
        //    var tbPrdQuanList = GetPrdQuantityListByPrdId(prdId);
        //    db.tblProductQunatities.RemoveRange(tbPrdQuanList);
        //    return SaveDB;
        //}
        //public bool Save => SaveDB;

        //private bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
