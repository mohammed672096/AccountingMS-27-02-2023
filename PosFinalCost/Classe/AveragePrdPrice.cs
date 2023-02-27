using DevExpress.Xpo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PosFinalCost.Classe
{
    public class AveragePrdPrice
    {
        public AveragePrdPrice(int ProductID)
        {
            //    var tbPrdPriceQuanList = GetPrdPiceQuanActiveListByPrdId(ProductID).Where(x => x.Quantity1 > 0 || x.Quantity2 > 0 || x.Quantity3 > 0);
            //    if (tbPrdPriceQuanList.Count() == 0)
            //    {
            //        GetAverProPrice = GetPrdPriceQuanActiveObjByPrdId(ProductID);
            //        return;
            //    }

            //    var tbPrdPriceQuan = tbPrdPriceQuanList.GroupBy(x => x.PrdId, (key, grp) => new ProductPrice()
            //    {
            //        PrdId = key,
            //        pr1 = grp.Sum(x => x.pr1 * x.Quantity1),
            //        pr2 = grp.Sum(x => x.pr2 * x.Quantity2),
            //        pr3 = grp.Sum(x => x.pr3 * x.Quantity3),
            //        Quantity1 = grp.Sum(x => x.Quantity1),
            //        Quantity2 = grp.Sum(x => x.Quantity2),
            //        Quantity3 = grp.Sum(x => x.Quantity3),
            //    }).FirstOrDefault();
            //    GetAverProPrice= CalculateAveragePrice(tbPrdPriceQuan, Session.PrdMeasurments.Where(x => x.PrdId == ProductID).ToList());
            //}
            //public ProductPrice GetAverProPrice { get; set; }

            //private ProductPrice CalculateAveragePrice(ProductPrice tbPrdPriceQuan, List<PrdMeasurment> tbPrdMsurList)
            //{   
            //    switch (tbPrdMsurList.Count())
            //    {
            //        case 1:
            //            if (tbPrdPriceQuan.Quantity1 == 0) return tbPrdPriceQuan;
            //            tbPrdPriceQuan.pr1 = tbPrdPriceQuan.pr1 / tbPrdPriceQuan.Quantity1;
            //            return tbPrdPriceQuan;
            //        case 2:
            //            return InitPrdAverageCost2(tbPrdPriceQuan, GetPrdMsurConvByStatus(tbPrdMsurList, 2));
            //        case 3:
            //            return InitPrdAverageCost3(tbPrdPriceQuan, tbPrdMsurList);
            //    }
            //    return tbPrdPriceQuan;
            //}
            //private double GetPrdMsurConvByStatus(List<PrdMeasurment> tbPrdMsurList, byte status)=>tbPrdMsurList.FirstOrDefault(x => x.Status == status)?.Conversion??1;

            //public List<ProductPrice> GetPrdPiceQuanActiveListByPrdId(int prdId)=>Session.ProductPrices.Where(x => x.Status && x.PrdId == prdId).ToList();

            //private ProductPrice GetPrdPriceQuanActiveObjByPrdId(int prdId)=>Session.ProductPrices.Where(x => x.Status && x.PrdId == prdId).OrderByDescending(x => x.PrdId).FirstOrDefault();

            //private ProductPrice InitPrdAverageCost2(ProductPrice tbPrdPriceQuan, double ppmConversion)
            //{
            //    double totalQuantity = tbPrdPriceQuan.Quantity2 + (tbPrdPriceQuan.Quantity1 * ppmConversion);
            //    double totalPrice = (totalQuantity) switch
            //    {
            //        _ when totalQuantity != 0 => ((tbPrdPriceQuan.pr1 + tbPrdPriceQuan.pr2) /totalQuantity),
            //        _ when totalQuantity == 0 => GetPrdPiceQuanActiveListByPrdId(tbPrdPriceQuan.PrdId).OrderByDescending(x => x.PrdId).Select(x => x.pr2).FirstOrDefault(),
            //    };
            //    tbPrdPriceQuan.pr2 = totalPrice;
            //    tbPrdPriceQuan.pr1 = (totalPrice * ppmConversion);
            //    return tbPrdPriceQuan;
            //}

            //private ProductPrice InitPrdAverageCost3(ProductPrice tbPrdPriceQuan, List<PrdMeasurment> tbPrdMsurList)
            //{
            //    double ppmConversion2 = GetPrdMsurConvByStatus(tbPrdMsurList, 2), ppmConversion3 = GetPrdMsurConvByStatus(tbPrdMsurList, 3);
            //    double totalQuantity = tbPrdPriceQuan.Quantity2 + (tbPrdPriceQuan.Quantity1 * ppmConversion2);
            //    totalQuantity = tbPrdPriceQuan.Quantity3 + (totalQuantity * ppmConversion3);
            //    double totalPrice = (totalQuantity) switch
            //    {
            //        _ when totalQuantity != 0 => ((tbPrdPriceQuan.pr1 + tbPrdPriceQuan.pr2 + tbPrdPriceQuan.pr3) / totalQuantity),
            //        _ when totalQuantity == 0 => GetPrdPiceQuanActiveListByPrdId(tbPrdPriceQuan.PrdId).OrderByDescending(x => x.PrdId).Select(x => x.pr3).FirstOrDefault(),
            //    };

            //    tbPrdPriceQuan.pr3 = totalPrice;
            //    tbPrdPriceQuan.pr2 = (tbPrdPriceQuan.pr3 *ppmConversion3);
            //    tbPrdPriceQuan.pr1 = (tbPrdPriceQuan.pr2 *ppmConversion2);

            //    return tbPrdPriceQuan;
        }
    }
}
