using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public static class ClsObjectConverter
    {
        public static tblSupplyMain OrderToSupplyMain(tblOrderMain tbOrderMain, SupplyType supplyType)
        {
            return new tblSupplyMain()
            {
                supAccNo = MySetting.DefaultSetting.defaultBox,
                supStrId = MySetting.DefaultSetting.defaultStrId,
                supRefNo = tbOrderMain.ordNo.ToString(),
                supDate = DateTime.Now,
                supIsCash = 1,
                supBrnId = tbOrderMain.ordBrnId,
                supUserId = Session.CurrentUser.id,
                supStatus = (byte)supplyType,
            };
        }

        public static IList<tblSupplySub> OrderToSupplySub(IList<tblOrderSub> tbOrderSubList, SupplyType supplyType)
        {
           bool isSale = (supplyType == SupplyType.Sales || supplyType == SupplyType.SalesRtrn);
            IList<tblSupplySub> tbSupplySubList = (from tbOrder in tbOrderSubList
                                                   join p in Session.Products on tbOrder.ordPrdId equals p.id
                                                   join m in Session.tblPrdPriceMeasurment on tbOrder.ordMsurId equals m.ppmId
                                                   join g in Session.tblGroupStr on p.prdGrpNo equals g.id
                                                   select new tblSupplySub()
                                                   {
                                                       supPrdId = p.id,
                                                       supPrdNo = p.prdNo,
                                                       supPrdName = p.prdName,
                                                       supAccNo = g.grpAccNo,
                                                       supAccName = Session.Accounts.FirstOrDefault(x => x.accNo == g.grpAccNo)?.accName,
                                                       supCurrency = (g?.grpCurrency) ?? 0,
                                                       supMsur = m.ppmId,
                                                       supPrdManufacture = m.ppmManufacture,
                                                       supPrdBarcode = Session.tblBarcode?.FirstOrDefault(x=>x.brcPrdMsurId==m.ppmId)?.brcNo,
                                                       supQuanMain = tbOrder.ordQuantity,
                                                       supPrice =tbOrder.ordPrice ??(isSale?m.ppmSalePrice: m.ppmPrice),
                                                       supSalePrice = tbOrder.ordPriceSale,
                                                       supTaxPercent = tbOrder.ordTaxPercent,
                                                       supTaxPrice = tbOrder.ordTax,
                                                       supDebit = !isSale ? tbOrder.ordTotal : null,
                                                       supCredit = isSale ? tbOrder.ordTotal : null,
                                                       supDesc = tbOrder.ordDesc,
                                                       supDate = DateTime.Now,
                                                       supBrnId = tbOrder.ordBrnId,
                                                       supUserId = Session.CurrentUser.id,
                                                       supStatus = (byte)supplyType,
                                                   }).ToList();
            //foreach (var tbOrder in tbOrderSubList)
            //{
            //    var tbProduct = clsTbProduct.GetPrdObjByPrdId(tbOrder.ordPrdId);
            //    if (tbProduct == null) continue;

            //    var tbPrdMsur = clsTbPrdMsur.GetPrdPriceMsurById(tbOrder.ordMsurId);
            //    if (tbPrdMsur == null) continue;

            //    var tbBarcode = clsTbBarcode.GetBarcodeObjByPrdMsurId(tbPrdMsur.ppmId);

            //    tbSupplySubList.Add(new tblSupplySub()
            //    {
            //        supPrdId = tbProduct.id,
            //        supPrdNo = tbProduct.prdNo,
            //        supPrdName = tbProduct.prdName,
            //        supAccNo = tbProduct.prdGrpNo,
            //        supCurrency = clsTbGroup.GetGroupCurrencyById(tbProduct.prdGrpNo),
            //        supMsur = tbPrdMsur.ppmId,
            //        supPrdManufacture = tbPrdMsur.ppmManufacture,
            //        supPrdBarcode = tbBarcode?.brcNo,
            //        supQuanMain = tbOrder.ordQuantity,
            //        supPrice = tbOrder.ordPrice ?? tbPrdMsur.ppmPrice,
            //        supSalePrice = tbOrder.ordPriceSale,
            //        supTaxPercent = tbOrder.ordTaxPercent,
            //        supTaxPrice = tbOrder.ordTax,
            //        supDebit = supplyType == SupplyType.Purchase ? tbOrder.ordTotal : null,
            //        supCredit = supplyType == SupplyType.Sales ? tbOrder.ordTotal : null,
            //        supDesc = tbOrder.ordDesc,
            //        supDate = DateTime.Now,
            //        supBrnId = tbOrder.ordBrnId,
            //        supUserId = Session.CurrentUser.id,
            //        supStatus = (byte)supplyType,
            //    });
            //}

            return tbSupplySubList;
        }

        //public static IList<formAddSupplyVoucher.TempSupplySub> OrderToSupplySubTmp(IList<tblOrderSub> tbOrderSubList, SupplyType supplyType,
        //    ClsTblProduct clsTbProduct, ClsTblGroupStr clsTbGroup, ClsTblPrdPriceMeasurment clsTbPrdMsur,
        //    ClsTblBarcode clsTbBarcode)
        //{
        //    IList<formAddSupplyVoucher.TempSupplySub> tbSupplySubList = new List<formAddSupplyVoucher.TempSupplySub>();

        //    foreach (var tbOrder in tbOrderSubList)
        //    {
        //        var tbProduct = clsTbProduct.GetPrdObjByPrdId(tbOrder.ordPrdId);
        //        if (tbProduct == null) continue;

        //        var tbPrdMsur = clsTbPrdMsur.GetPrdPriceMsurById(tbOrder.ordMsurId);
        //        if (tbPrdMsur == null) continue;

        //        var tbBarcode = clsTbBarcode.GetBarcodeObjByPrdMsurId(tbPrdMsur.ppmId);

        //        tbSupplySubList.Add(new formAddSupplyVoucher.TempSupplySub()
        //        {
        //            supPrdId = tbProduct.id,
        //            supPrdNo = tbProduct.prdNo,
        //            supPrdName = tbProduct.prdName,
        //            supAccNo = tbProduct.prdGrpNo,
        //            supCurrency = clsTbGroup.GetGroupCurrencyById(tbProduct.prdGrpNo),
        //            supMsur = tbPrdMsur.ppmId,
        //            supPrdManufacture = tbPrdMsur.ppmManufacture,
        //            supPrdBarcode = tbBarcode?.brcNo,
        //            supQuanMain = tbOrder.ordQuantity,
        //            supPrice = tbOrder.ordPrice ?? tbPrdMsur.ppmPrice,
        //            supSalePrice = tbOrder.ordPriceSale,
        //            supTaxPercent = tbOrder.ordTaxPercent,
        //            supTaxPrice = tbOrder.ordTax,
        //            supDebit = supplyType == SupplyType.Purchase ? tbOrder.ordTotal : null,
        //            supCredit = supplyType == SupplyType.Sales ? tbOrder.ordTotal : null,
        //            supDesc = tbOrder.ordDesc,
        //            supDate = DateTime.Now,
        //            supBrnId = tbOrder.ordBrnId,
        //            supUserId = Session.CurrentUser.id,
        //            supStatus = (byte)supplyType,
        //        });
        //    }

        //    return tbSupplySubList;
        //}

    }
}
