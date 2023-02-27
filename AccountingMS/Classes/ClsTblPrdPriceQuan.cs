using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblPrdPriceQuan
    {
        public ClsTblPrdPriceQuan(bool isInitData = true)
        {

        }
        private IEnumerable<tblPrdPriceQuan> QueryData => Session.tblPrdPriceQuan.AsQueryable()
          .Where(x => x.prdBrnId == Session.CurBranch.brnId).OrderBy(x => x.prPrdId);

        public IList<tblPrdPriceQuan> GetPrdPiceQuanList => QueryData.ToList();

        public IList<tblPrdPriceQuan> GetPrdPiceQuanActiveList()
        {
            return QueryData.AsQueryable().Where(x => x.prStatus).ToList();
        }
        public double GetCostOfNextProductTransaction(int productID,int storeID,DateTime sDate,double Factor, List<ProductTransaction> _ProductTransaction)
        {
            var query = _ProductTransaction.Where(sl => sl.ProductID == productID && sl.StoreID == storeID&& sl.Date <= sDate).OrderBy(sl => sl.Date);
            if (query.Count() == 0)
                return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == productID && x.ppmConversion == Factor)?.ppmPrice ?? 0;
            //get the total qty out 
            double TotalQtyOut = 0, TotalQtyIn = 0;
            //if (query.Any(q => q.ProTranType == ProductTransactionType.Out))
            TotalQtyOut = query.Where(q => q.ProTranType == ProductTransactionType.Out).Sum(q => q.Quantity);
            //if (query.Any(q => q.ProTranType == ProductTransactionType.In))
            TotalQtyIn = query.Where(q => q.ProTranType == ProductTransactionType.In).Sum(q => q.Quantity);
            double Balance = TotalQtyIn - TotalQtyOut;
            // if no balance where found return the defualt buy price
            if (Balance <= 0)
                return Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == productID && x.ppmConversion == Factor)?.ppmPrice ?? 0;
            // get the row  postion where there is next qty  to sell 
            var subQurey = query.Where(q =>
            query.Where(q1 => (q1.ProTranType == ProductTransactionType.In) && q1.Date <= q.Date).Sum(q1 => q1.Quantity) > TotalQtyOut
            && (q.ProTranType == ProductTransactionType.In)).ToList();
            return ((subQurey.Sum(x=>x.CostValue/x.Factor)*Factor)/ subQurey.Count)??0;
        }
        //public tblPrdPriceQuan GetPrdPriceQuanAveragePriceObj(int prdId, IList<tblPrdPriceMeasurment> tbPrdMsurList)
        //{
        //    var tbPrdPriceQuanList = GetPrdPiceQuanActiveListByPrdId(prdId).Where(x => x.prQuantity1 > 0 || x.prQuantity2 > 0 || x.prQuantity3 > 0);
        //    if (tbPrdPriceQuanList.Count() == 0) return GetPrdPriceQuanActiveObjByPrdId(prdId);
        //    var tbPrdPriceQuan = tbPrdPriceQuanList.GroupBy(x => x.prPrdId, (key, grp) => new tblPrdPriceQuan()
        //    {
        //        prPrdId = key,
        //        pr1 = grp.Sum(x => x.pr1 * Convert.ToDecimal(x.prQuantity1)),
        //        pr2 = grp.Sum(x => x.pr2 * Convert.ToDecimal(x.prQuantity2)),
        //        pr3 = grp.Sum(x => x.pr3 * Convert.ToDecimal(x.prQuantity3)),
        //        prQuantity1 = grp.Sum(x => x.prQuantity1),
        //        prQuantity2 = grp.Sum(x => x.prQuantity2),
        //        prQuantity3 = grp.Sum(x => x.prQuantity3),
        //    }).FirstOrDefault();

        //    return CalculateAveragePrice(tbPrdPriceQuan, tbPrdMsurList);
        //}

        //private tblPrdPriceQuan CalculateAveragePrice(tblPrdPriceQuan tbPrdPriceQuan, IList<tblPrdPriceMeasurment> tbPrdMsurList)
        //{
        //    switch (tbPrdMsurList.Count())
        //    {
        //        case 1:
        //            if (tbPrdPriceQuan.prQuantity1 == 0) return tbPrdPriceQuan;
        //            tbPrdPriceQuan.pr1 = Math.Round(tbPrdPriceQuan.pr1 / Convert.ToDecimal(tbPrdPriceQuan.prQuantity1), 3, MidpointRounding.AwayFromZero);
        //            return tbPrdPriceQuan;
        //        case 2:
        //            return InitPrdAverageCost2(tbPrdPriceQuan, GetPrdMsurConversionByStatus(tbPrdMsurList, 2));
        //        case 3:
        //            return InitPrdAverageCost3(tbPrdPriceQuan, tbPrdMsurList);
        //    }
        //    return tbPrdPriceQuan;
        //}

        //private tblPrdPriceQuan InitPrdAverageCost2(tblPrdPriceQuan tbPrdPriceQuan, double ppmConversion)
        //{
        //    double totalQuantity = tbPrdPriceQuan.prQuantity2 + (tbPrdPriceQuan.prQuantity1 * ppmConversion);
        //    decimal totalPrice = (totalQuantity) switch
        //    {
        //        _ when totalQuantity != 0 => Math.Round((tbPrdPriceQuan.pr1 + tbPrdPriceQuan.pr2) / Convert.ToDecimal(totalQuantity), 3, MidpointRounding.AwayFromZero),
        //        _ when totalQuantity == 0 => GetPrdPiceQuanActiveListByPrdId(tbPrdPriceQuan.prPrdId).OrderByDescending(x => x.prPrdId).Select(x => x.pr2).FirstOrDefault(),
        //    };

        //    tbPrdPriceQuan.pr2 = totalPrice;
        //    tbPrdPriceQuan.pr1 = Math.Round(totalPrice * Convert.ToDecimal(ppmConversion), 3, MidpointRounding.AwayFromZero);
        //    return tbPrdPriceQuan;
        //}

        //private tblPrdPriceQuan InitPrdAverageCost3(tblPrdPriceQuan tbPrdPriceQuan, IList<tblPrdPriceMeasurment> tbPrdMsurList)
        //{
        //    double ppmConversion2 = GetPrdMsurConversionByStatus(tbPrdMsurList, 2), ppmConversion3 = GetPrdMsurConversionByStatus(tbPrdMsurList, 3);
        //    double totalQuantity = tbPrdPriceQuan.prQuantity2 + (tbPrdPriceQuan.prQuantity1 * ppmConversion2);
        //    totalQuantity = tbPrdPriceQuan.prQuantity3 + (totalQuantity * ppmConversion3);
        //    decimal totalPrice = (totalQuantity) switch
        //    {
        //        _ when totalQuantity != 0 => Math.Round((tbPrdPriceQuan.pr1 + tbPrdPriceQuan.pr2 + tbPrdPriceQuan.pr3) / Convert.ToDecimal(totalQuantity), 3, MidpointRounding.AwayFromZero),
        //        _ when totalQuantity == 0 => GetPrdPiceQuanActiveListByPrdId(tbPrdPriceQuan.prPrdId).OrderByDescending(x => x.prPrdId).Select(x => x.pr3).FirstOrDefault(),
        //    };

        //    tbPrdPriceQuan.pr3 = totalPrice;
        //    tbPrdPriceQuan.pr2 = Math.Round(tbPrdPriceQuan.pr3 * Convert.ToDecimal(ppmConversion3), 3, MidpointRounding.AwayFromZero);
        //    tbPrdPriceQuan.pr1 = Math.Round(tbPrdPriceQuan.pr2 * Convert.ToDecimal(ppmConversion2), 3, MidpointRounding.AwayFromZero);

        //    return tbPrdPriceQuan;
        //}

        public IList<tblPrdPriceQuan> GetPrdPiceQuanActiveListByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).ToList();
        }

        private tblPrdPriceQuan GetPrdPriceQuanActiveObjByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).OrderByDescending(x => x.prId).FirstOrDefault();
        }

        private IList<tblPrdPriceQuan> GetPrdPiceQuanActiveListByPrdIdL(int prdId)
        {
            return this.QueryData.Where(x => x.prStatus && x.prPrdId == prdId).ToList();
        }

        private IList<tblPrdPriceQuan> GetPrdPiceQuanActiveListByPrdIdQ(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).ToList();
        }

        private tblPrdPriceQuan GetPrdPriceQuanActiveObjByPrdIdL(int prdId)
        {
            return this.QueryData.Where(x => x.prStatus && x.prPrdId == prdId).OrderByDescending(x => x.prId).FirstOrDefault();
        }

        private tblPrdPriceQuan GetPrdPriceQuanActiveObjByPrdIdQ(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).OrderByDescending(x => x.prId).FirstOrDefault();
        }

        public IList<tblPrdPriceQuan> GetPrdPriceQuantListByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).ToList();
        }

        public tblPrdPriceQuan GetPrdPriceQuantObjById(int prId)
        {
            return this.QueryData.Where(x => x.prId == prId).FirstOrDefault();
        }

        public tblPrdPriceQuan GetPrdPriceQuantObjByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId).FirstOrDefault();
        }

        public tblPrdPriceQuan GetPrdPriceQuantObjByPrdIdNdPrice(int prdId, double price)
        {
            return QueryData.AsQueryable().Where(x => x.prStatus && x.prPrdId == prdId && (x.pr1 == price || x.pr2 == price || x.pr3 == price)).FirstOrDefault();
        }

        public int GetPrdPriceQuantIdByPrdIdNdPrice(int prdId, double price)
        {
            return this.QueryData.Where(x => x.prStatus && x.prPrdId == prdId && (x.pr1 == price || x.pr2 == price || x.pr3 == price))
                .Select(x => x.prId).FirstOrDefault();
        }

        public bool IsPrdPriceQuanFound(int prdId, double price)
        {
            return QueryData.AsQueryable().Any(x => x.prStatus && x.prPrdId == prdId && (x.pr1 == price || x.pr2 == price || x.pr3 == price));
        }

        public double GetPrdPriceQuanTotalPriceQuan(int prdId)
        {
            var tbPrdPriceQuanList = GetPrdPiceQuanActiveListByPrdId(prdId);
            return tbPrdPriceQuanList.GroupBy(x => x.prPrdId, (key, grp) => grp.Sum(x => (x.pr1 * Convert.ToDouble(x.prQuantity1)) +
                (x.pr2 * Convert.ToDouble(x.prQuantity2)) + (x.pr3 * Convert.ToDouble(x.prQuantity3)))).FirstOrDefault();
        }
    }
}
