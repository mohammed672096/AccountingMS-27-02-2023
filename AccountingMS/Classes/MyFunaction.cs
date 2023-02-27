using DevExpress.ChartRangeControlClient.Core;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using AccountingMS.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;
using System.Drawing;
using System.ComponentModel;

namespace AccountingMS.Classe
{
    class MyFunaction
    {
       public Font SystemFontConverter()
        {
            Font font = WindowsFormsSettings.DefaultFont;
            try
            {
                if (MySetting.GetPrivateSetting.SystemFont == null)
                {
                    MySetting.GetPrivateSetting.SystemFont = converter.ConvertToString(WindowsFormsSettings.DefaultFont);
                    MySetting.WriterSettingXml();
                }
                font = (Font)converter.ConvertFromString(MySetting.GetPrivateSetting.SystemFont);
            }
            catch (Exception)
            {
                return WindowsFormsSettings.DefaultFont;
            }
            return font;
        }
        public Font SalesFontConverter()
        {
            Font font = WindowsFormsSettings.DefaultFont;
            try
            {
                if (MySetting.GetPrivateSetting.SystemFontSales == null)
                {
                    MySetting.GetPrivateSetting.SystemFontSales = converter.ConvertToString(WindowsFormsSettings.DefaultFont);
                    MySetting.WriterSettingXml();
                }
                font = (Font)converter.ConvertFromString(MySetting.GetPrivateSetting.SystemFontSales);
            }
            catch (Exception)
            {
                return WindowsFormsSettings.DefaultFont;
            }
            return font;
        }
        public TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));

        public tblCustomer GetCopyOfCurreCustomer(tblCustomer tblCustomer) => new tblCustomer
        {
            CommercialRegister = tblCustomer.CommercialRegister,
            cusAddNo = tblCustomer.cusAddNo,
            cusAnotherID = tblCustomer.cusAnotherID,
            cusBankId = tblCustomer.cusBankId,
            cusBuildingNo = tblCustomer.cusBuildingNo,
            cusDistrict = tblCustomer.cusDistrict,
            cusDistrictEn = tblCustomer.cusDistrictEn,
            custAccNo = tblCustomer.custAccNo,
            custAddress = tblCustomer.custAddress,
            custAddressEn = tblCustomer.custAddressEn,
            custBrnId = tblCustomer.custBrnId,
            custCellingCredit = tblCustomer.custCellingCredit,
            custCity = tblCustomer.custCity,
            custCityEn = tblCustomer.custCityEn,
            custCountry = tblCustomer.custCountry,
            custCountryEn = tblCustomer.custCountryEn,
            custCurrency = tblCustomer.custCurrency,
            custEmail = tblCustomer.custEmail,
            id = tblCustomer.id,
            custName = tblCustomer.custName,
            custNameEn = tblCustomer.custNameEn,
            custNo = tblCustomer.custNo,
            custPhnNo = tblCustomer.custPhnNo,
            PostalCode = tblCustomer.PostalCode,
            custSalePrice = tblCustomer.custSalePrice,
            custStatus = tblCustomer.custStatus,
            custTaxNo = tblCustomer.custTaxNo,
            custAccName = tblCustomer.custAccName,

        };
        public DrawerPeriod GetCopyOfDrawerPeriod(DrawerPeriod d)
        {
            return new DrawerPeriod()
            {
                BranchID = d.BranchID,
                AmountBank = d.AmountBank,
                ActualBalance = d.ActualBalance,
                ClosingBalance = d.ClosingBalance,
                ClosingDrwerID = d.ClosingDrwerID,
                ClosingPeriodUserID = d.ClosingPeriodUserID,
                DifferenceAccountID = d.DifferenceAccountID,
                DrawerID = d.DrawerID,
                OpeningBalance = d.OpeningBalance,
                PeriodEnd = d.PeriodEnd,
                PeriodStart = d.PeriodStart,
                PeriodUserID = d.PeriodUserID,
                RemainingBalance = d.RemainingBalance,
                Status = d.Status,
                TransferdBalance = d.TransferdBalance,
                ID = d.ID,
                IsTarhil = d.IsTarhil,
                RefID = d.RefID,

            };
        }
        public double GetSalePrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmSalePrice / 1.15 : priceMea.ppmSalePrice) ?? 0);
        public double GetMinSalePrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmMinSalePrice / 1.15 : priceMea.ppmMinSalePrice) ?? 0);
        public double GetBatchPrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmBatchPrice / 1.15 : priceMea.ppmBatchPrice) ?? 0);
        public double GetRetailPrice(bool PriceTax, tblPrdPriceMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.ppmRetailPrice / 1.15 : priceMea.ppmRetailPrice) ?? 0);
        //public async Task InitObjects()
        //{
        //    IList<Task> taskList = new List<Task>();
        //    taskList.Add(Task.Run(() => Session.GetDataProductQtyOpn()));
        //    taskList.Add(Task.Run(() => Session.GetDataPrdExpirateQuan()));
        //    taskList.Add(Task.Run(() => Session.GetDataStockTransSub()));
        //    taskList.Add(Task.Run(() => Session.GetDataStockTransMain()));
        //    taskList.Add(Task.Run(() => Session.GetDataInvStoreMain()));
        //    taskList.Add(Task.Run(() => Session.GetDataInvStoreSub()));
        //    await Task.WhenAll(taskList);

        //}
        public void InitObjects()
        {
            Session.GetDataProductQtyOpn();
            Session.GetDataPrdExpirateQuan();
            Session.GetDataStockTransSub();
            Session.GetDataStockTransMain();
            Session.GetDataInvStoreMain();
            Session.GetDataInvStoreSub();
        }
        public List<ProductTransaction> SupplySub = new List<ProductTransaction>();
        public List<ProductTransaction> GetDataProductTransaction(int prID, short storID,DateTime date)
        {
            List<ProductTransaction> _ProductTransaction = new List<ProductTransaction>();

            using (accountingEntities db = new accountingEntities())
                SupplySub = (from m in db.tblSupplyMains.AsNoTracking().Where(x => x.supStatus <= 12 && x.supBrnId == Session.CurBranch.brnId)
                             join s in db.tblSupplySubs.AsNoTracking() on m.id equals s.supNo
                             where s.supPrdId == prID && s.StoreID == storID &&s.supDate<= date
                             select new ProductTransaction
                             {
                                 BillID = s.id,
                                 CostValue = s.supPrice,
                                 Date = m.supDate ?? s.supDate,
                                 Factor = s.Conversion,
                                 ProductID = s.supPrdId,
                                 TranType = m.supStatus,
                                 Quantity = s.supQuanMain ?? 0,
                                 StoreID = m.supStrId,
                                 UnitID = s.supMsur,
                             }).ToList();
            _ProductTransaction = (from s in SupplySub
                                   select new ProductTransaction
                                   {
                                       BillID = s.BillID,
                                       CostValue = s.CostValue,
                                       Quantity = s.Quantity * s.Factor,
                                       Date = s.Date,
                                       Factor = s.Factor,
                                       ProductID = s.ProductID,
                                       UnitID = s.UnitID,
                                       StoreID = s.StoreID,
                                       ProTranType = GetProductTransactionType(s.TranType),
                                       TranType = (byte)GetTransactionType(s.TranType)
                                   }).ToList();
            _ProductTransaction.AddRange((from s in Session.tblProductQtyOpn
                                          where s.qtyPrdId == prID && s.qtyStrId == storID && s.qtyDate <= date
                                          select new ProductTransaction
                                          {
                                              BillID = s.qtyId,
                                              CostValue = s.qtyPrice,
                                              Quantity = s.qtyQuantity * GetConversion(s.qtyPrdMsurId),
                                              Date = s.qtyDate,
                                              Factor = GetConversion(s.qtyPrdMsurId),
                                              ProductID = s.qtyPrdId,
                                              UnitID = s.qtyPrdMsurId,
                                              StoreID = s.qtyStrId,
                                              ProTranType = ProductTransactionType.In,
                                              TranType = (byte)TransactionType.OpenBalance
                                          }).ToList());
            _ProductTransaction.AddRange((from s in Session.tblPrdExpirateQuan
                                          where s.expPrdId == prID && s.expStrid == storID && s.expDate <= date
                                          select new ProductTransaction
                                          {
                                              BillID = s.expId,
                                              CostValue = s.expPrdPrice,
                                              Quantity = s.expQuan * GetConversion(s.expPrdMsurId),
                                              Date = s.expDate,
                                              Factor = GetConversion(s.expPrdMsurId),
                                              ProductID = s.expPrdId,
                                              UnitID = s.expPrdMsurId,
                                              StoreID = s.expStrid,
                                              ProTranType = ProductTransactionType.Out,
                                              TranType = (byte)TransactionType.ProductDamage
                                          }).ToList());
            _ProductTransaction.AddRange((from s in Session.tblStockTransSub
                                          join m in Session.tblStockTransMain on s.stcMainId equals m.stcId
                                          where s.stcPrdId == prID && m.stcStrIdFrom == storID && s.stcDate <= date
                                          select new ProductTransaction
                                          {
                                              BillID = s.stcId,
                                              CostValue = GetBuyPrice(s.stcMsurId),
                                              Quantity = s.stcQuantity * GetConversion(s.stcMsurId),
                                              Date = m.stcDate,
                                              Factor = GetConversion(s.stcMsurId),
                                              ProductID = s.stcPrdId,
                                              UnitID = s.stcMsurId,
                                              StoreID = m.stcStrIdFrom,
                                              ProTranType = ProductTransactionType.Out,
                                              TranType = (byte)TransactionType.StockTransfer
                                          }).ToList());

            _ProductTransaction.AddRange((from s in Session.tblStockTransSub
                                          join m in Session.tblStockTransMain on s.stcMainId equals m.stcId
                                          where s.stcPrdId == prID && m.stcStrIdTo == storID && s.stcDate <= date
                                          select new ProductTransaction
                                          {
                                              BillID = s.stcId,
                                              CostValue = GetBuyPrice(s.stcMsurId),
                                              Quantity = s.stcQuantity * GetConversion(s.stcMsurId),
                                              Date = m.stcDate,
                                              Factor = GetConversion(s.stcMsurId),
                                              ProductID = s.stcPrdId,
                                              UnitID = s.stcMsurId,
                                              StoreID = m.stcStrIdTo,
                                              ProTranType = ProductTransactionType.In,
                                              TranType = (byte)TransactionType.StockTransfer
                                          }).ToList());

            _ProductTransaction.AddRange((from s in Session.tblInvStoreSub
                                          join m in Session.tblInvStoreMain on s.invMainId equals m.id
                                          where s.invPrdId == prID && m.invStrId == storID && m.invDate <= date
                                          select new ProductTransaction
                                          {
                                              BillID = s.id,
                                              CostValue = s.invPriceDefr,
                                              Quantity = s.invQuanDefr * GetConversion(s.invPrdMsurId),
                                              Date = m.invDate,
                                              Factor = GetConversion(s.invPrdMsurId),
                                              ProductID = s.invPrdId,
                                              UnitID = s.invPrdMsurId,
                                              StoreID = m.invStrId,
                                              ProTranType = ProductTransactionType.In,
                                              TranType = (byte)TransactionType.StockBalanceCorrection
                                          }).ToList());
            return _ProductTransaction;
        }
        public tblSupplySub GetCostOfNextProductTransaction(tblSupplySub supplySub, List<ProductTransaction> _ProductTransaction)
        {
            int productID = supplySub.supPrdId ?? 0, storeID = supplySub.StoreID ?? 0;
            double qty = (supplySub.supQuanMain ?? 0) * supplySub.Conversion;
            // get all the trans that belongis to the product in the store before the trans date 
            var query = _ProductTransaction.Where(sl => sl.ProductID == productID && sl.StoreID == storeID
            && !(sl.BillID == supplySub.id && sl.TranType == (byte)TransactionType.Sales) && sl.Date <= supplySub.supDate).OrderBy(sl => sl.Date);
            // if no transactions where found retern the defualt buy price
            if (query.Count() == 0)
            {
                supplySub.supPrice = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == productID&&x.ppmConversion == supplySub.Conversion)?.ppmPrice ?? 0;
                return supplySub;
            }
            //get the total qty out 
            double TotalQtyOut = 0, TotalQtyIn = 0;
            //if (query.Any(q => q.ProTranType == ProductTransactionType.Out))
                TotalQtyOut = query.Where(q => q.ProTranType == ProductTransactionType.Out).Sum(q => q.Quantity);
            // get the balance in the trans date 
            //if (query.Any(q => q.ProTranType == ProductTransactionType.In))
                TotalQtyIn = query.Where(q => q.ProTranType == ProductTransactionType.In).Sum(q => q.Quantity);
            double Balance = TotalQtyIn - TotalQtyOut;
            // if no balance where found return the defualt buy price
            if (Balance <= 0)
            {
                supplySub.supPrice = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == productID && x.ppmConversion == supplySub.Conversion)?.ppmPrice ?? 0;
                return supplySub;
            }
            // get the row  postion where there is next qty  to sell 
            var subQurey = query.Where(q =>
            query.Where(q1 => (q1.ProTranType == ProductTransactionType.In) && q1.Date <= q.Date).Sum(q1 =>q1.Quantity) > TotalQtyOut
            && (q.ProTranType == ProductTransactionType.In)).ToList();

            //get the remainig balance
            var subQureyBalance = subQurey.Where(q => q.ProTranType == ProductTransactionType.In).Sum(q => q.Quantity)
                                - subQurey.Where(q => q.ProTranType == ProductTransactionType.Out).Sum(q => q.Quantity);
            //if this where the last row and has been taken from it substract the taken 
            if (subQureyBalance > Balance)
            {
                var diff = subQureyBalance - Balance;
                subQurey[0].Quantity -= diff;
            }
            double fifo;
            // FIFO
            if (subQurey[0].Quantity < qty && subQurey[0].Quantity > 0)
            {
                int i = 0;
                var qtyX = qty;
                double SumPrice = 0;
                while (qtyX > 0 && i < subQurey.Count())
                {
                    var row = subQurey[i];
                    double qty1 = qtyX > row.Quantity ? row.Quantity : qtyX;
                    SumPrice += (qty1 * ((row.CostValue ?? 0) / row.Factor));
                    qtyX -= qty1;
                    i++;
                }
                fifo = SumPrice / (qty - qtyX);
            }
            else
                fifo = ((subQurey.FirstOrDefault()?.CostValue ?? 0) / (subQurey.FirstOrDefault()?.Factor ?? 1));

            supplySub.supPrice = fifo;
            return supplySub;
        }
        //public double GetCostOfNextProductTransaction(tblSupplySub supplySub)
        //{
        //    int productID = supplySub.supPrdId ?? 0, storeID = supplySub.StoreID ?? 0, ExecludeRow = supplySub.id;
        //    double qty = (supplySub.supQuanMain ?? 0) * supplySub.Conversion;
        //    DateTime transDate = supplySub.supDate;
        //    double cost = 0;
        //    // get all the trans that belongis to the product in the store before the trans date 
        //    var query = Session._ProductTransaction.Where(sl => sl.ProductID == productID && sl.StoreID == storeID
        //    && !(sl.BillID == ExecludeRow && sl.TranType == (byte)TransactionType.Sales) && sl.Date <= transDate).OrderBy(sl => sl.Date);
        //    // if no transactions where found retern the defualt buy price
        //    if (query.Count() == 0)
        //        return Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == productID).OrderByDescending(x => x.ppmConversion).FirstOrDefault()?.ppmPrice ?? 0;
        //    //get the total qty out 
        //    double TotalQtyOut = 0, TotalQtyIn = 0;
        //    if (query.Any(q => q.ProTranType == ProductTransactionType.Out))
        //        TotalQtyOut = query.Where(q => q.ProTranType == ProductTransactionType.Out).Sum(q => q.Quantity);
        //    // get the balance in the trans date 
        //    if (query.Any(q => q.ProTranType == ProductTransactionType.In))
        //        TotalQtyIn = query.Where(q => q.ProTranType == ProductTransactionType.In).Sum(q => q.Quantity);
        //    double Balance = TotalQtyIn - TotalQtyOut;
        //    // if no balance where found return the defualt buy price
        //    if (Balance <= 0)
        //    {
        //        cost = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == productID).OrderByDescending(x => x.ppmConversion).FirstOrDefault()?.ppmPrice ?? 0;
        //        return cost;
        //    }
        //    // get the row  postion where there is next qty  to sell 
        //    var subQurey = query.Where(q =>
        //    query.Where(q1 => (q1.ProTranType == ProductTransactionType.In) && q1.Date <= q.Date).Sum(q1 => q1.Quantity) > TotalQtyOut
        //    && (q.ProTranType == ProductTransactionType.In)).ToList();

        //    //get the remainig balance
        //    var subQureyBalance = subQurey.Where(q => q.ProTranType == ProductTransactionType.In).Sum(q => q.Quantity)
        //                        - subQurey.Where(q => q.ProTranType == ProductTransactionType.Out).Sum(q => q.Quantity);

        //    //if this where the last row and has been taken from it substract the taken 
        //    if (subQureyBalance > Balance)
        //    {
        //        var diff = subQureyBalance - Balance;
        //        subQurey[0].Quantity -= diff;
        //    }

        //    double fifo;
        //    double lifo;
        //    double WAC;

        //    var method = CostCalculationMethod.FIFO;

        //    if (method == CostCalculationMethod.FIFO)
        //    {
        //        // FIFO
        //        if (subQurey[0].Quantity < qty)
        //        {
        //            int i = 0;
        //            var qtyX = qty;
        //            double SumPrice = 0;
        //            while (qtyX > 0 && i < subQurey.Count())
        //            {
        //                var row = subQurey[i];
        //                double qty1 = qtyX > row.Quantity ? row.Quantity : qtyX;
        //                SumPrice += qty1 * ((row.CostValue ?? 0) / row.Factor);
        //                qtyX -= qty1;
        //                i++;
        //            }
        //            fifo = SumPrice / (qty - qtyX);
        //        }
        //        else
        //            fifo = ((subQurey.FirstOrDefault()?.CostValue ?? 0) / (subQurey.FirstOrDefault()?.Factor ?? 1));
        //        cost = fifo;
        //    }
        //    else if (method == CostCalculationMethod.LIFO)
        //    {
        //        // LIFO
        //        subQurey = subQurey.OrderByDescending(q => q.Date).ToList();
        //        if (subQurey[0].Quantity < qty)
        //        {
        //            int i = 0;

        //            var qtyX = qty;
        //            double SumPrice = 0;
        //            while (qtyX > 0 && i < subQurey.Count())
        //            {
        //                var row = subQurey[i];
        //                double qty1 = qtyX > row.Quantity ? row.Quantity : qtyX;
        //                SumPrice += qty1 * ((row.CostValue ?? 0) / row.Factor);
        //                qtyX -= qty1;
        //                i++;
        //            }
        //            lifo = SumPrice / (qty - qtyX);
        //        }
        //        else
        //            lifo = ((subQurey.FirstOrDefault()?.CostValue ?? 0) / (subQurey.FirstOrDefault()?.Factor ?? 1));
        //        cost = lifo;
        //    }
        //    else if (method == CostCalculationMethod.Average)
        //    {
        //        //Average
        //        WAC = subQurey.Select(q => q.Quantity * ((q.CostValue ?? 0) / q.Factor)).Sum(q => q) / Balance;
        //        cost = WAC;
        //    }

        //    return cost;
        //}
        double GetConversion(int unitId) => Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == unitId)?.ppmConversion ?? 1;
        double GetBuyPrice(int unitId) => Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == unitId)?.ppmPrice ?? 0;
        ProductTransactionType GetProductTransactionType(byte supState) => (supState) switch
        {
            3 => ProductTransactionType.In,
            7 => ProductTransactionType.In,
            11 => ProductTransactionType.In,
            12 => ProductTransactionType.In,
            4 => ProductTransactionType.Out,
            8 => ProductTransactionType.Out,
            9 => ProductTransactionType.Out,
            10 => ProductTransactionType.Out,
            _ => 0
        };
        TransactionType GetTransactionType(byte supState) => (supState) switch
        {
            3 => TransactionType.Purchase,
            7 => TransactionType.Purchase,
            11 => TransactionType.SalesReturn,
            12 => TransactionType.SalesReturn,
            4 => TransactionType.Sales,
            8 => TransactionType.Sales,
            9 => TransactionType.PurchaseReturn,
            10 => TransactionType.PurchaseReturn,
            _=>0
        };
        //public double GetCostOfNextProduct(tblSupplySub supplySub)
        //{
        //    int productID = supplySub.supPrdId ?? 0, storeID = supplySub.StoreID ?? 0, ExecludeRow = supplySub.id;
        //    double qty = (supplySub.supQuanMain ?? 0) * supplySub.Conversion;
        //    DateTime transDate = supplySub.supDate;
        //    double cost = 0;
        //    using (var db = new accountingEntities())
        //    {
        //        var query = db.tblSupplySubs.AsNoTracking().Where(sl => sl.supPrdId == productID && sl.StoreID == storeID && sl.supDate <= transDate &&
        //          sl.id != ExecludeRow && sl.supStatus <= 12).OrderBy(sl => sl.supDate);
        //        // if no transactions where found retern the defualt buy price
        //        if (query.Count() == 0)
        //            return Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == productID).OrderByDescending(x => x.ppmConversion).FirstOrDefault()?.ppmPrice ?? 0;
        //        //get the total qty out 
        //        double TotalQtyOut = 0, TotalQtyIn = 0;
        //        if (query.Any(q => q.supStatus == 4 || q.supStatus == 8 || q.supStatus == 9 || q.supStatus == 10))
        //            TotalQtyOut = query.Where(q => q.supStatus == 4 || q.supStatus == 8 || q.supStatus == 9 || q.supStatus == 10).Sum(q => (q.supQuanMain * q.Conversion)) ?? 0;
        //        // get the balance in the trans date 
        //        if (query.Any(q => q.supStatus == 3 || q.supStatus == 7 || q.supStatus == 11 || q.supStatus == 12))
        //            TotalQtyIn = query.Where(q => q.supStatus == 3 || q.supStatus == 7 || q.supStatus == 11 || q.supStatus == 12).Sum(q => (q.supQuanMain * q.Conversion)) ?? 0;
        //        //double TotalOpenQtyIn = db.tblProductQtyOpns.Where(x => x.qtyPrdId == productID && x.qtyStrId == storeID && x.qtyDate <= transDate).Sum(x => (double?)(x.qtyQuantity * x.Conversion)) ?? 0;
        //        double Balance = TotalQtyIn - TotalQtyOut;
        //        // if no balance where found return the defualt buy price
        //        if (Balance <= 0)
        //        {
        //            cost = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == productID).OrderByDescending(x => x.ppmConversion).FirstOrDefault()?.ppmPrice ?? 0;
        //            return cost;
        //        }
        //        // get the row  postion where there is next qty  to sell 
        //        var subQurey = query.Where(q =>
        //        query.Where(q1 => (q1.supStatus == 3 || q1.supStatus == 7 || q1.supStatus == 11 || q1.supStatus == 12) && q1.supDate <= q.supDate).Sum(q1 => (q1.supQuanMain ?? 0) * q1.Conversion) > TotalQtyOut
        //        && (q.supStatus == 3 || q.supStatus == 7 || q.supStatus == 11 || q.supStatus == 12)).ToList();

        //        //get the remainig balance
        //        var subQureyBalance = subQurey.Where(q => q.supStatus == 3 || q.supStatus == 7 || q.supStatus == 11 || q.supStatus == 12).Sum(q => q.supQuanMain * q.Conversion)
        //                            - subQurey.Where(q => q.supStatus == 4 || q.supStatus == 8 || q.supStatus == 9 || q.supStatus == 10).Sum(q => q.supQuanMain * q.Conversion);

        //        //if this where the last row and has been taken from it substract the taken 
        //        subQurey.ForEach(x => x.supQuanMain = (x.supQuanMain * x.Conversion));
        //        if (subQureyBalance > Balance)
        //        {
        //            var diff = subQureyBalance - Balance;
        //            subQurey[0].supQuanMain -= diff;
        //        }

        //        double fifo;
        //        double lifo;
        //        double WAC;

        //        var method = CostCalculationMethod.FIFO;

        //        if (method == CostCalculationMethod.FIFO)
        //        {
        //            // FIFO
        //            if (subQurey[0].supQuanMain < qty)
        //            {
        //                int i = 0;
        //                var qtyX = qty;
        //                double SumPrice = 0;
        //                while (qtyX > 0 && i < subQurey.Count())
        //                {
        //                    var row = subQurey[i];
        //                    double qty1 = qtyX > (row.supQuanMain ?? 0) ? (row.supQuanMain ?? 0) : qtyX;
        //                    SumPrice += qty1 * ((row.supPrice ?? 0) / row.Conversion);
        //                    qtyX -= qty1;
        //                    i++;
        //                }
        //                fifo = SumPrice / (qty - qtyX);
        //            }
        //            else
        //                fifo = ((subQurey.FirstOrDefault()?.supPrice ?? 0) / (subQurey.FirstOrDefault()?.Conversion ?? 1));
        //            cost = fifo;
        //        }
        //        else if (method == CostCalculationMethod.LIFO)
        //        {
        //            // LIFO
        //            subQurey = subQurey.OrderByDescending(q => q.supDate).ToList();
        //            if (subQurey[0].supQuanMain < qty)
        //            {
        //                int i = 0;

        //                var qtyX = qty;
        //                double SumPrice = 0;
        //                while (qtyX > 0 && i < subQurey.Count())
        //                {
        //                    var row = subQurey[i];
        //                    double qty1 = (qtyX > (row.supQuanMain ?? 0)) ? (row.supQuanMain ?? 0) : qtyX;
        //                    SumPrice += qty1 * ((row.supPrice ?? 0) / row.Conversion);
        //                    qtyX -= qty1;
        //                    i++;
        //                }
        //                lifo = SumPrice / (qty - qtyX);
        //            }
        //            else
        //                lifo = ((subQurey.FirstOrDefault()?.supPrice ?? 0) / (subQurey.FirstOrDefault()?.Conversion ?? 1));
        //            cost = lifo;
        //        }
        //        else if (method == CostCalculationMethod.Average)
        //        {
        //            //Average
        //            WAC = subQurey.Select(q => (q.supQuanMain ?? 0) * ((q.supPrice ?? 0) / q.Conversion)).Sum(q => q) / Balance;
        //            cost = WAC;
        //        }

        //        return cost;

        //    }
        //}
        ////private XtraReport InitReportInvoice()
        //{
        //    switch (MySetting.DefaultSetting.DefaultPrintPaper)
        //    {
        //        case (byte)PrintPaperType.Cashier:
        //            return new ReportInvoiceCasher();
        //        case (byte)PrintPaperType.A4:
        //            return new ReportInvoiceA4();
        //        default:
        //            return null;
        //    }
        //}
        //private List<tblSupplySubCustom> InitSupplySubCustom(IList<tblSupplySub> supplySubs)
        //{
        //    return (from S in supplySubs
        //            select new tblSupplySubCustom
        //            {
        //                subNoPacks = S.subNoPacks,
        //                supDesc = S.supDesc,
        //                supDscntAmount = Convert.ToDouble($"{S.supDscntAmount:n2}"),
        //                supDscntPercent = Convert.ToDouble($"{S.supDscntPercent:n2}"),
        //                supMsur = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == S.supMsur)?.ppmMsurName,
        //                supOvertime = S.supOvertime,
        //                supPrdBarcode = S.supPrdBarcode,
        //                supPrdName = Session.Products.FirstOrDefault(x => x.id == S.supPrdId)?.prdName,
        //                supPrdNo = Session.Products.FirstOrDefault(x => x.id == S.supPrdId)?.prdNo,
        //                supPrice = Convert.ToDouble($"{S.supPrice:n2}"),
        //                supQuanMain = Convert.ToDouble($"{S.supQuanMain:n2}"),
        //                supSalePrice = Convert.ToDouble($"{S.supSalePrice:n2}"),
        //                supTaxPercent = Convert.ToByte(S.supTaxPercent),
        //                supTaxPrice = Convert.ToDouble($"{S.supTaxPrice:n2}"),
        //                supCredit = Convert.ToDouble($"{S.supCredit:n2}"),
        //                supWorkingtime = S.supWorkingtime,
        //                supDebit = Convert.ToDouble($"{S.supDebit:n2}"),
        //            }).ToList();
        //}
        //public void PrintInvoice(int No, IList<tblSupplySub> supplySubs, tblSupplyMain tblSupplyMain,PrintFileType printFileType = PrintFileType.Printer)
        //{
        //    try
        //    {
        //        XtraReport reportSupply = InitReportInvoice();
        //        List<tblSupplySubCustom> supplySubCustom;
        //        if (supplySubs == null)
        //            using (var db = new accountingEntities())
        //            {
        //                tblSupplyMain = tblSupplyMain == null ? db.tblSupplyMains.FirstOrDefault(x => x.supNo == No && x.supDate >= Session.CurrentYear.DateStart
        //                                  && x.supDate <= Session.CurrentYear.fyDateEnd && x.supBrnId == Session.CurBranch.brnId) : tblSupplyMain;
        //                if (tblSupplyMain == null) return;
        //                supplySubCustom = (from S in db.tblSupplySubs
        //                                   join P in db.tblProducts on S.supPrdId equals P.id
        //                                   join U in db.tblPrdPriceMeasurments on S.supMsur equals U.ppmId
        //                                   where S.supNo == tblSupplyMain.id && S.supDate >= Session.CurrentYear.fyDateStart
        //                                   && S.supDate <= Session.CurrentYear.fyDateEnd && S.supBrnId == Session.CurBranch.brnId
        //                                   select new tblSupplySubCustom
        //                                   {
        //                                       subNoPacks = S.subNoPacks,
        //                                       supDesc = S.supDesc,
        //                                       supDscntAmount = Convert.ToDouble($"{S.supDscntAmount:n2}"),
        //                                       supDscntPercent = Convert.ToDouble($"{S.supDscntPercent:n2}"),
        //                                       supMsur = U.ppmMsurName,
        //                                       supOvertime = S.supOvertime,
        //                                       supPrdBarcode = S.supPrdBarcode,
        //                                       supPrdName = P.prdName,
        //                                       supPrdNo = P.prdNo,
        //                                       supPrice = Convert.ToDouble($"{S.supPrice:n2}"),
        //                                       supQuanMain = Convert.ToDouble($"{S.supQuanMain:n2}"),
        //                                       supSalePrice = Convert.ToDouble($"{S.supSalePrice:n2}"),
        //                                       supTaxPercent = Convert.ToByte(S.supTaxPercent),
        //                                       supTaxPrice = Convert.ToDouble($"{S.supTaxPrice:n2}"),
        //                                       Total = Convert.ToDouble($"{S.Total:n2}"),
        //                                       supWorkingtime = S.supWorkingtime,
        //                                   }).ToList();
        //            }
        //        else supplySubCustom = InitSupplySubCustom(supplySubs);
        //        InvoiceReport invoiceReport = new InvoiceReport(tblSupplyMain);
        //        if (invoiceReport == null) return;
        //        switch (MySetting.DefaultSetting.DefaultPrintPaper)
        //        {
        //            case (byte)PrintPaperType.A4:
        //                ((ReportInvoiceA4)reportSupply).SupplySubBindingSource.DataSource = supplySubCustom;
        //                ((ReportInvoiceA4)reportSupply).SupplyMainBindingSource.DataSource = invoiceReport;
        //                break;
        //            default:
        //                ((ReportInvoiceCasher)reportSupply).SupplySubBindingSource.DataSource = supplySubCustom;
        //                ((ReportInvoiceCasher)reportSupply).SupplyMainBindingSource.DataSource = invoiceReport;
        //                break;
        //        }
        //        reportSupply.DisplayName = DisplayName(invoiceReport);
        //        PrintFile(printFileType, reportSupply);
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message);   
        //        return;
        //    }

        //}
        //private void PrintFile(PrintFileType printFileType, XtraReport reportSupply)
        //{
        //    //switch (printFileType)
        //    //{
        //    //    case PrintFileType.Printer:
        //    //        //reportSupply.PrinterName = MySetting.DefaultSetting.DefaultSalesPrinterName;
        //    //        if (MySetting.DefaultSetting.InvoicePrintMode == ((byte)PrintMode.Direct))
        //    //            reportSupply.Print();
        //    //        else
        //    //            new ReportForm(reportSupply).ShowDialog();
        //    //        break;
        //    //    case PrintFileType.PDF:
        //    //    case PrintFileType.Xlsx:
        //    //        if (MySetting.DefaultSetting.PrintFileMode == ((byte)PrintMode.Direct))
        //    //        {
        //    //            if (PrintFileType.PDF == printFileType)
        //    //                reportSupply.ExportToPdf(DomainPath + "\\" + reportSupply.DisplayName + ".pdf");
        //    //            else if (PrintFileType.Xlsx == printFileType)
        //    //                reportSupply.ExportToXlsx(DomainPath + "\\" + reportSupply.DisplayName + ".Xlsx");
        //    //        }
        //    //        else
        //    //        {
        //    //            XtraSaveFileDialog fileDialog = new XtraSaveFileDialog();
        //    //            switch (printFileType)
        //    //            {
        //    //                case PrintFileType.PDF:
        //    //                    fileDialog.Filter = "PDF Files|*.pdf";
        //    //                    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    //                        reportSupply.ExportToPdf(fileDialog.FileName);
        //    //                    break;
        //    //                case PrintFileType.Xlsx:
        //    //                    fileDialog.Filter = "Excel Files|*.Xlsx";
        //    //                    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    //                        reportSupply.ExportToXlsx(fileDialog.FileName);
        //    //                    break;
        //    //                default:
        //    //                    break;
        //    //            }
        //    //        }
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //}
        //string DisplayName(InvoiceReport invoiceReport) => invoiceReport.SupplyMainData.Status + invoiceReport.SupplyMainData.No;
        //string DomainPath =>File.Exists(MySetting.DefaultSetting.PrintFileDefultPathe)? MySetting.DefaultSetting.PrintFileDefultPathe: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        ////public void PrintEntry(int No, IList<tblEntrySub> EntrySubs, tblEntryMain EntryMain, PrintFileType printFileType = PrintFileType.Printer)
        //{
        //    List<EntrySubCustom> EntrySubCustom;
        //    EntrySubCustom subCustoms = new Classe.EntrySubCustom();
        //    if (EntrySubs == null)
        //        using (var db = new PosDBDataContext(Program.ConnectionString))
        //        {
        //            EntryMain = EntryMain == null ? db.EntryMains.FirstOrDefault(x => x.No == No && x.Date >= Session.CurrentYear.DateStart
        //                              && x.Date <= Session.CurrentYear.DateEnd && x.BranchID == Session.CurrentBranch.ID) : EntryMain;
        //            if (EntryMain == null) return;
        //            EntrySubCustom = subCustoms.GetEntrySubToList(db.EntrySubs.Where(S=>S.ParentID == EntryMain.ID && S.Date >= Session.CurrentYear.DateStart
        //                               && S.Date <= Session.CurrentYear.DateEnd && S.BranchID == Session.CurrentBranch.ID).ToList());
        //        }
        //    else EntrySubCustom = subCustoms.GetEntrySubToList(EntrySubs.ToList());
        //    EntryDataCustom entryDataCustom = new EntryDataCustom(EntryMain);
        //    if (entryDataCustom == null) return;
        //    ReportEntryCustom reportEntry = new ReportEntryCustom(entryDataCustom, EntrySubCustom, EntryMain.Status);
        //    reportEntry.entrySubDataBindingSource.DataSource = EntrySubCustom;
        //           reportEntry.EntryMainBindingSource.DataSource = entryDataCustom;
        //    string DisplayName = entryDataCustom.EntryData.EntType + entryDataCustom.EntryData.No;
        //    reportEntry.DisplayName = DisplayName;
        //    switch (printFileType)
        //    {
        //        case PrintFileType.Printer:
        //            reportEntry.PrinterName = MySetting.DefaultSetting.DefaultSalesPrinterName;
        //            if (MySetting.DefaultSetting.InvoicePrintMode == ((byte)PrintMode.Direct))
        //                reportEntry.Print();
        //            else
        //                new ReportForm(reportEntry).ShowDialog();
        //            break;
        //        case PrintFileType.PDF:
        //        case PrintFileType.Xlsx:
        //            if (MySetting.DefaultSetting.PrintFileMode == ((byte)PrintMode.Direct))
        //            {
        //                if (PrintFileType.PDF == printFileType)
        //                    reportEntry.ExportToPdf(DomainPath + "\\" + reportEntry.DisplayName + ".pdf");
        //                else if (PrintFileType.Xlsx == printFileType)
        //                    reportEntry.ExportToXlsx(DomainPath + "\\" + reportEntry.DisplayName + ".Xlsx");
        //            }
        //            else
        //            {
        //                XtraSaveFileDialog fileDialog = new XtraSaveFileDialog();
        //                switch (printFileType)
        //                {
        //                    case PrintFileType.PDF:
        //                        fileDialog.Filter = "PDF Files|*.pdf";
        //                        if (fileDialog.ShowDialog() == DialogResult.OK)
        //                            reportEntry.ExportToPdf(fileDialog.FileName);
        //                        break;
        //                    case PrintFileType.Xlsx:
        //                        fileDialog.Filter = "Excel Files|*.Xlsx";
        //                        if (fileDialog.ShowDialog() == DialogResult.OK)
        //                            reportEntry.ExportToXlsx(fileDialog.FileName);
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        public string ChickBarcodWaghit(string Barcod, out bool ProIsWaghit, out double value)
        {
            ProIsWaghit = false;
            value = 1;
            if (!MySetting.DefaultSetting.ReadFormScaleBarcode) return Barcod;
            if (Barcod.Length != MySetting.DefaultSetting.BarcodeLength) return Barcod;
            if (!Barcod.StartsWith(MySetting.DefaultSetting.ScaleBarcodePrefix)) return Barcod;
            ProIsWaghit = true;
            string Readvalue = Barcod.Substring(MySetting.DefaultSetting.ScaleBarcodePrefix.Length + MySetting.DefaultSetting.ProductCodeLength);
            if (MySetting.DefaultSetting.IgnoreCheckDigit) Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
            value = Convert.ToDouble(Readvalue);
            value = value / (Math.Pow(10, MySetting.DefaultSetting.DivideValueBy));
            int.TryParse(Barcod.Substring(MySetting.DefaultSetting.ScaleBarcodePrefix.Length, MySetting.DefaultSetting.ProductCodeLength), out int h);
            return h.ToString();
        }
        //public void GetNewORUpdateSupplySub(tblSupplySub row)
        //{
        //        string Readvalue = row.supPrdBarcode.Substring(MySetting.DefaultSetting.ScaleBarcodePrefix.Length + MySetting.DefaultSetting.ProductCodeLength);
        //        if (MySetting.DefaultSetting.IgnoreCheckDigit) Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
        //        double value = Convert.ToDouble(Readvalue);
        //        value = value / (Math.Pow(10, MySetting.DefaultSetting.DivideValueBy));
        //        if (MySetting.DefaultSetting.ReadMode == 0)
        //            row.supQuanMain += value;
        //    //else if (MySetting.DefaultSetting.ReadMode == 1)
        //    //{
        //    //    var priceAfterTax = 100 * (value / (100 + 15));
        //    //    value = MySetting.DefaultSetting.TaxReadMode ? priceAfterTax : value;
        //    //    if (this.productData.PrdMeasurment != null)
        //    //    {
        //    //        value = (value / Convert.ToDouble(this.productData.PrdMeasurment.SalePrice ?? 1));
        //    //        row.QuanMain = InGrid ? row.QuanMain + value : value;
        //    //    }
        //    //}
        //    //return row;
        //}
        public void AppearanceGridView(GridView gridView)
        {
            gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.Columns.ForEach(x => x.AppearanceHeader.BackColor = System.Drawing.Color.SteelBlue);
            gridView.OptionsBehavior.ReadOnly = true;
            gridView.Appearance.Empty.BackColor = System.Drawing.Color.AliceBlue;
        }
    }
}
