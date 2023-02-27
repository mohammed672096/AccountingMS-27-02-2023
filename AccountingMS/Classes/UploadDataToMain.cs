using DevExpress.XtraBars.ToastNotifications;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountingMS.AccDB;
using DevExpress.XtraEditors;

namespace AccountingMS.Classes
{
    class UploadDataToMain
    {
        AccMain_tblSupplyMain SupplyMainAcc;
        public static bool upDataState = false;
        ClsTblSupplyMain GetSupplyMain;
        ClsTblSupplySub GetSupplySub;
        accountingEntities Localdb;
        DataClasses1DataContext Serverdb;
        IEnumerable<tblStore> GetStores;
        IEnumerable<AccMain_tblStore> GetMainStores;
        IEnumerable<tblProduct> GetProducts;
        IEnumerable<AccMain_tblProduct> GetMainProducts;
        IEnumerable<tblBarcode> GetBarcodes;
        IEnumerable<AccMain_tblBarcode> GetMainBarcodes;
        IEnumerable<tblPrdPriceMeasurment> GetMeasurments;
        IEnumerable<AccMain_tblPrdPriceMeasurment> GetMainMeasurments;
        IEnumerable<tblProductQunatity> GetProductQunatitys;
        IEnumerable<AccMain_tblProductQunatity> GetMainProductQunatitys;
        IEnumerable<tblPrdPriceQuan> GetProductPrices;
        IEnumerable<AccMain_tblPrdPriceQuan> GetMainProductPrices;
        IEnumerable<tblGroupStr> GetGroupStr;
        IEnumerable<AccMain_tblGroupStr> GetMainGroupStr;

        int BranchID = Session.CurBranch.brnId;
        public event EventHandler<string> OnProcess;
        public event EventHandler<bool> ProcessCompleted;
        public UploadDataToMain()
        {

        }
        public void PullAsync()
        {
            if (Database.Exists(ConnectionString_AccDB()) == false)
            {
                OnProcess?.Invoke("Pull", $"Server Not Connect{Environment.NewLine}");
                return;
            }
            Localdb = new accountingEntities();
            Serverdb = new DataClasses1DataContext(ConnectionString_AccDB());
            SyncStoreData();
        }
        private async Task InitDataBaseAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => GetStores = Localdb.tblStores));
            taskList.Add(Task.Run(() => GetMainStores = Serverdb.AccMain_tblStores));
            taskList.Add(Task.Run(() => GetProducts = Localdb.tblProducts));
            taskList.Add(Task.Run(() => GetMainProducts = Serverdb.AccMain_tblProducts));
            taskList.Add(Task.Run(() => GetBarcodes = Localdb.tblBarcode));
            taskList.Add(Task.Run(() => GetMainBarcodes = Serverdb.AccMain_tblBarcodes));
            taskList.Add(Task.Run(() => GetMeasurments = Localdb.tblPrdPriceMeasurments));
            taskList.Add(Task.Run(() => GetMainMeasurments = Serverdb.AccMain_tblPrdPriceMeasurments));
            taskList.Add(Task.Run(() => GetProductQunatitys = Localdb.tblProductQunatities));
            taskList.Add(Task.Run(() => GetMainProductQunatitys = Serverdb.AccMain_tblProductQunatities));
            taskList.Add(Task.Run(() => GetProductPrices = Localdb.tblPrdPriceQuans));
            taskList.Add(Task.Run(() => GetMainProductPrices = Serverdb.AccMain_tblPrdPriceQuans));
            taskList.Add(Task.Run(() => GetGroupStr = Localdb.tblGroupStrs));
            taskList.Add(Task.Run(() => GetMainGroupStr = Serverdb.AccMain_tblGroupStrs));
            await Task.WhenAll(taskList);
        }
        
        async void SyncStoreData()
        {
           await InitDataBaseAsync();
            SyncStore();
            SyncGroupStr();
            SyncProduct();
            SyncBarcode();
            SyncPrdPriceMeasurment();
            SyncProductQunatity();
            SyncProductPrice();
            XtraMessageBox.Show("تم سحب البيانات بنجاح", "");
        }
        int count;
        void SyncStore()
        {
            OnProcess?.Invoke("Pull", $"Sync Stores....{Environment.NewLine}");
            var stor = (from x in GetMainStores select new { id = x.id, strBrnId = x.strBrnId, strName = x.strName, strNo = x.strNo, strPhnNo = x.strPhnNo, strStatus = x.strStatus }).ToList();
            var stor2 = (from x in GetStores select new { id = x.id, strBrnId = x.strBrnId, strName = x.strName, strNo = x.strNo, strPhnNo = x.strPhnNo, strStatus = x.strStatus }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in stNewOrUpdate)
                    Localdb.InsStoreToPos(s.id, s.strNo, s.strName, s.strPhnNo, s.strBrnId, s.strStatus);
            OnProcess?.Invoke("Pull", $"Sync {count} Stores Done{Environment.NewLine}");
        }
        void SyncGroupStr()
        {
            OnProcess?.Invoke("Pull", $"Sync GroupStrs....{Environment.NewLine}");
            var GroupStr = (from x in GetMainGroupStr
                            select new
                            {
                                id = x.id,
                                grpAccNo = x.grpAccNo,
                                grpBrnId = x.grpBrnId,
                                grpCostAccNo = x.grpCostAccNo,
                                grpCostRtrnAccNo = x.grpCostRtrnAccNo,
                                grpCurrency = x.grpCurrency,
                                grpDscntAccNo = x.grpDscntAccNo,
                                grpName = x.grpName,
                                grpNo = x.grpNo,
                                grpPurchaseAccNo = x.grpPurchaseAccNo,
                                grpPurchaseRtrnAccNo = x.grpPurchaseRtrnAccNo,
                                grpSalesAccNo = x.grpSalesAccNo,
                                grpSalesRtrnAccNo = x.grpSalesRtrnAccNo,
                                grpStatus = x.grpStatus
                            }).ToList();
            var GroupStr2 = (from x in GetGroupStr
                                 select new
                                 {
                                     id = x.id,
                                     grpAccNo = x.grpAccNo,
                                     grpBrnId = x.grpBrnId,
                                     grpCostAccNo = x.grpCostAccNo,
                                     grpCostRtrnAccNo = x.grpCostRtrnAccNo,
                                     grpCurrency = x.grpCurrency,
                                     grpDscntAccNo = x.grpDscntAccNo,
                                     grpName = x.grpName,
                                     grpNo = x.grpNo,
                                     grpPurchaseAccNo = x.grpPurchaseAccNo,
                                     grpPurchaseRtrnAccNo = x.grpPurchaseRtrnAccNo,
                                     grpSalesAccNo = x.grpSalesAccNo,
                                     grpSalesRtrnAccNo = x.grpSalesRtrnAccNo,
                                     grpStatus = x.grpStatus,
                                 }).ToList();
            var MeasNewOrUpdate = (from n in GroupStr where !GroupStr2.Contains(n) select n);
            count = MeasNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in MeasNewOrUpdate)
                    Localdb.InsGroupToPos(s.id,s.grpNo,s.grpName,s.grpAccNo,s.grpCurrency,s.grpSalesAccNo,s.grpCostAccNo,s.grpDscntAccNo,s.grpSalesRtrnAccNo,s.grpCostRtrnAccNo,s.grpBrnId,s.grpStatus,s.grpPurchaseAccNo,s.grpPurchaseRtrnAccNo);
            OnProcess?.Invoke("Pull", $"Sync {count} GroupStrs Done{Environment.NewLine}");
        }
        void SyncProduct()
        {
            OnProcess?.Invoke("Pull", $"Sync Products....{Environment.NewLine}");
            var p1 = (from x in GetMainProducts
                      select new
                      {
                          id = x.id,
                          prdBrnId = x.prdBrnId,
                          prdName = x.prdName,
                          prdNo = x.prdNo,
                          prdNameEng = x.prdNameEng,
                          MaxLevel = x.MaxLevel,
                          prdDesc = x.prdDesc,
                          prdStatus = x.prdStatus,
                          prdGrpNo = x.prdGrpNo,
                          prdPriceTax = x.prdPriceTax,
                          prdPurchaseTax = x.prdPurchaseTax,
                          prdSaleTax = x.prdSaleTax,
                          ReorderLevel = x.ReorderLevel,
                          Suspended = x.Suspended
                      }).ToList();

            var p2 = (from x in GetProducts
                      select new
                      {
                          id = x.id,
                          prdBrnId = x.prdBrnId,
                          prdName = x.prdName,
                          prdNo = x.prdNo,
                          prdNameEng = x.prdNameEng,
                          MaxLevel = x.MaxLevel,
                          prdDesc = x.prdDesc,
                          prdStatus = x.prdStatus,
                          prdGrpNo = x.prdGrpNo,
                          prdPriceTax = x.prdPriceTax,
                          prdPurchaseTax = x.prdPurchaseTax,
                          prdSaleTax = x.prdSaleTax,
                          ReorderLevel = x.ReorderLevel,
                          Suspended = x.Suspended
                      }).ToList();
            var proNewOrUpdate = (from n in p1 where !p2.Contains(n) select n).ToList();
             count = proNewOrUpdate.Count();
            if (count > 0)
            foreach (var x in proNewOrUpdate)
                    Localdb.InsProductToPos(x.id,x.prdNo,x.prdName,x.prdNameEng,x.prdGrpNo,x.prdDesc,x.prdSaleTax,x.prdBrnId,x.prdStatus,x.prdPriceTax,x.ReorderLevel,x.MaxLevel,x.prdPurchaseTax,x.Suspended);
            OnProcess?.Invoke("Pull", $"Sync {count} Products Done{Environment.NewLine}");
        }
      
        void SyncBarcode()
        {
            OnProcess?.Invoke("Pull", $"Sync Barcodes....{Environment.NewLine}");
            var Barcode = (from x in GetMainBarcodes select new { id = x.id, brcNo = x.brcNo, brcPrdMsurId = x.brcPrdMsurId, brcBrnId = x.brcBrnId }).ToList();
            var Barcode2 = (from x in GetBarcodes select new { id = x.id, brcNo = x.brcNo, brcPrdMsurId = x.brcPrdMsurId, brcBrnId = x.brcBrnId }).ToList();
            var BarNewOrUpdate = (from n in Barcode where !Barcode2.Contains(n) select n);
             count = BarNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in BarNewOrUpdate)
                    Localdb.InsBarcodeToPos(s.id,s.brcNo,s.brcPrdMsurId,s.brcBrnId);
            OnProcess?.Invoke("Pull", $"Sync {count} Barcodes Done{Environment.NewLine}");
        }
        void SyncPrdPriceMeasurment()
        {
            OnProcess?.Invoke("Pull", $"Sync PrdPriceMeasurments....{Environment.NewLine}");
            var PrdPriceMeasurment = (from x in GetMainMeasurments
                                      select new
                                      {
                                          ppmId = x.ppmId,
                                          ppmMsurName = x.ppmMsurName,
                                          ppmPrice = x.ppmPrice,
                                          ppmSalePrice = x.ppmSalePrice,
                                          ppmMinSalePrice = x.ppmMinSalePrice,
                                          ppmRetailPrice = x.ppmRetailPrice,
                                          ppmBatchPrice = x.ppmBatchPrice,
                                          ppmBarcode1 = x.ppmBarcode1,
                                          ppmBarcode2 = x.ppmBarcode2,
                                          ppmBarcode3 = x.ppmBarcode3,
                                          ppmConversion = x.ppmConversion,
                                          ppmDefault = x.ppmDefault,
                                          ppmPrdId = x.ppmPrdId,
                                          ppmWeight = x.ppmWeight,
                                          ppmBrnId = x.ppmBrnId,
                                          ppmStatus = x.ppmStatus,
                                          ppmManufacture = x.ppmManufacture,
                                      }).ToList();
            var PrdPriceMeasurment2 = (from x in GetMeasurments
                                       select new
                                       {
                                           ppmId = x.ppmId,
                                           ppmMsurName = x.ppmMsurName,
                                           ppmPrice = x.ppmPrice,
                                           ppmSalePrice = x.ppmSalePrice,
                                           ppmMinSalePrice = x.ppmMinSalePrice,
                                           ppmRetailPrice = x.ppmRetailPrice,
                                           ppmBatchPrice = x.ppmBatchPrice,
                                           ppmBarcode1 = x.ppmBarcode1,
                                           ppmBarcode2 = x.ppmBarcode2,
                                           ppmBarcode3 = x.ppmBarcode3,
                                           ppmConversion = x.ppmConversion,
                                           ppmDefault = x.ppmDefault,
                                           ppmPrdId = x.ppmPrdId,
                                           ppmWeight = x.ppmWeight,
                                           ppmBrnId = x.ppmBrnId,
                                           ppmStatus = x.ppmStatus,
                                           ppmManufacture = x.ppmManufacture,
                                       }).ToList();
            var MeasNewOrUpdate = (from n in PrdPriceMeasurment where !PrdPriceMeasurment2.Contains(n) select n);
             count = MeasNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in MeasNewOrUpdate)
                    Localdb.InsProMeasurmentToPos(s.ppmId,s.ppmMsurName,s.ppmPrice,s.ppmSalePrice,s.ppmMinSalePrice,s.ppmRetailPrice,s.ppmBatchPrice,s.ppmBarcode1,s.ppmBarcode2,s.ppmBarcode3,s.ppmConversion,s.ppmDefault,s.ppmPrdId,s.ppmWeight,s.ppmBrnId,s.ppmStatus,s.ppmManufacture);
            OnProcess?.Invoke("Pull", $"Sync {count} PrdPriceMeasurments Done{Environment.NewLine}");
        }

        void SyncProductQunatity()
        {
            OnProcess?.Invoke("Pull", $"Sync ProductQunatitys....{Environment.NewLine}");
            var ProductQunatity = (from x in GetMainProductQunatitys 
                                      select new
                                      {
                                          id = x.id,
                                          prdBrnId = x.prdBrnId,
                                          prdId = x.prdId,
                                          prdQuantity = x.prdQuantity,
                                          prdStatus = x.prdStatus,
                                          prdStrId = x.prdStrId,
                                          prdSubQuantity = x.prdSubQuantity,
                                          prdSubQuantity3 = x.prdSubQuantity3,
                                      }).ToList();
            var ProductQunatity2 = (from x in GetProductQunatitys
                                    select new
                                    {
                                        id = x.id,
                                        prdBrnId = x.prdBrnId,
                                        prdId = x.prdId,
                                        prdQuantity = x.prdQuantity,
                                        prdStatus = x.prdStatus,
                                        prdStrId = x.prdStrId,
                                        prdSubQuantity = x.prdSubQuantity,
                                        prdSubQuantity3 = x.prdSubQuantity3,
                                    }).ToList();
            var MeasNewOrUpdate = (from n in ProductQunatity where !ProductQunatity2.Contains(n) select n);
             count = MeasNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in MeasNewOrUpdate)
                    Localdb.InsProQuanToPos(s.id, s.prdId, s.prdQuantity, s.prdSubQuantity, s.prdSubQuantity3, s.prdStrId, s.prdBrnId, s.prdStatus);
            OnProcess?.Invoke("Pull", $"Sync {count} ProductQunatitys Done{Environment.NewLine}");
        }
        void SyncProductPrice()
        {
            OnProcess?.Invoke("Pull", $"Sync ProductPrices....{Environment.NewLine}");
            var ProductPrice = (from x in GetMainProductPrices
                                   select new
                                   {
                                       prId = x.prId,
                                       prdBrnId = x.prdBrnId,
                                       pr1 = x.pr1,
                                       pr2 = x.pr2,
                                       pr3 = x.pr3,
                                       prPrdId = x.prPrdId,
                                       prQuantity1 = x.prQuantity1,
                                       prQuantity2 = x.prQuantity2,
                                       prQuantity3 = x.prQuantity3,
                                       prStatus = x.prStatus,
                                   }).ToList();
            var ProductPrice2 = (from x in GetProductPrices
                                    select new
                                    {
                                        prId = x.prId,
                                        prdBrnId = x.prdBrnId,
                                        pr1 = x.pr1,
                                        pr2 = x.pr2,
                                        pr3 = x.pr3,
                                        prPrdId = x.prPrdId,
                                        prQuantity1 = x.prQuantity1,
                                        prQuantity2 = x.prQuantity2,
                                        prQuantity3 = x.prQuantity3,
                                        prStatus = x.prStatus,
                                    }).ToList();
            var MeasNewOrUpdate = (from n in ProductPrice where !ProductPrice2.Contains(n) select n);
             count = MeasNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in MeasNewOrUpdate)
                    Localdb.InsProPriceToPos(s.prId, s.prPrdId,s.pr1,s.pr2,s.pr3,s.prQuantity1,s.prQuantity2,s.prQuantity3,s.prdBrnId,s.prStatus);
            OnProcess?.Invoke("Pull", $"Sync {count} ProductPrices Done{Environment.NewLine}");
        }
        public async Task PushAsync()
        {
            OnProcess?.Invoke("Push", $"Check server is connected{Environment.NewLine}");
            if (Database.Exists(ConnectionString_AccDB()) == false)
            {
                ProcessCompleted?.Invoke("Push", true);
                new Exception("server not connected");
                return;
            }
            OnProcess?.Invoke("Push", $"server is connected{Environment.NewLine}");

            OnProcess?.Invoke("Push", $"Get Local Invoices{Environment.NewLine}");
            if (!Database.Exists(ConnectionString_AccDB())) return;
            await InitObjectsAsync();
            upDataState = true;
            DataClasses1DataContext db = new DataClasses1DataContext(ConnectionString_AccDB());
            var SupplyMainCurrant = GetSupplyMain.GetSupplyMainList.Where(s =>(s.supStatus == 9 || s.supStatus == 11 || s.supStatus == 3 || s.supStatus == 4)
           && s.supDate >= ConnSetting.GetConnSetting.UpDataFromDate && s.supDate <= ConnSetting.GetConnSetting.UpDataToDate && s.supBrnId == BranchID && (!((s.SendToserver as bool?) ?? false))).ToList();
            int Count = 0;
            OnProcess?.Invoke("Push", $"Local Invoices Count:{SupplyMainCurrant.Count}{Environment.NewLine}");
            foreach (var item in SupplyMainCurrant)
            {
                SupplyMainAcc = GetCopyOfCurrentSupplyMain(item);
                db.AccMain_tblSupplyMains.InsertOnSubmit(SupplyMainAcc);
                db.SubmitChanges();
                db.AccMain_tblSupplySubs.InsertAllOnSubmit(GetCopyOfCurrentSupplySub(item.id, SupplyMainAcc.id));
                db.SubmitChanges();
                Count++;
                OnProcess?.Invoke("Push", $"Insered New Invoice ID:{SupplyMainAcc.id}{Environment.NewLine}");
                UpdateSendToServerForCurInvo(item);
            }
            OnProcess?.Invoke("Push", $"Doun Push {Count} Invoices{Environment.NewLine}");
            ProcessCompleted?.Invoke("Push", true);
        }
        public UploadDataToMain(tblSupplyMain supplyMain, List<tblSupplySub> supplySubs)
        {
            if ((supplyMain.SendToserver as bool?) ?? false) return;
            UpLoadData(supplyMain, supplySubs);
        }
        public void UpLoadData(tblSupplyMain supplyMain, List<tblSupplySub> supplySubs)
        {
            try
            {
               // if (!ChickNetConnection()) return;
                if (!Database.Exists(ConnectionString_AccDB())) return;
                DataClasses1DataContext db = new DataClasses1DataContext(ConnectionString_AccDB());
                SupplyMainAcc = GetCopyOfCurrentSupplyMain(supplyMain);
                db.AccMain_tblSupplyMains.InsertOnSubmit(SupplyMainAcc);
                db.SubmitChanges();
                db.AccMain_tblSupplySubs.InsertAllOnSubmit(GetCopyOfCurrentSupplySub(SupplyMainAcc, supplySubs));
                db.SubmitChanges();
                UpdateSendToServerForCurInvo(supplyMain);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void UpdateSendToServerForCurInvo(tblSupplyMain supplyMain)
        {
            try
            {
                accountingEntities db = new accountingEntities();
                supplyMain.SendToserver = true;
                var Baseitem = db.tblSupplyMains.Find(supplyMain.id);
                db.Entry(Baseitem).CurrentValues.SetValues(supplyMain);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }
        public List<AccMain_tblSupplySub> GetCopyOfCurrentSupplySub(AccMain_tblSupplyMain AccMain, List<tblSupplySub> supplySubs)
        {
            return (from tbSupplySub in supplySubs
                    select new AccMain_tblSupplySub
                    {
                        supNo = AccMain.id,
                        supDate = AccMain.supDate.Value,
                        supBrnId = AccMain.supBrnId,
                        supUserId = AccMain.supUserId,
                        supStatus = AccMain.supStatus,
                        supAccNo = tbSupplySub.supAccNo,
                        supAccName = tbSupplySub.supAccName,
                        supDesc = tbSupplySub.supDesc,
                        supPrdBarcode = tbSupplySub.supPrdBarcode,
                        supPrdNo = tbSupplySub.supPrdNo,
                        supPrdName = tbSupplySub.supPrdName,
                        supPrdId = tbSupplySub.supPrdId,
                        supMsur = tbSupplySub.supMsur,
                        supPrdManufacture = tbSupplySub.supPrdManufacture,
                        supCurrency = tbSupplySub.supCurrency,
                        supQuanMain = tbSupplySub.supQuanMain,
                        supPrice = tbSupplySub.supPrice,
                        supSalePrice = tbSupplySub.supSalePrice,
                        supTaxPercent = tbSupplySub.supTaxPercent,
                        supTaxPrice = tbSupplySub.supTaxPrice,
                        supDscntPercent = tbSupplySub.supDscntPercent,
                        supDebit = tbSupplySub.supDebit,
                        supCredit = tbSupplySub.supCredit,
                        supDebitFrgn = tbSupplySub.supDebitFrgn,
                        supCreditFrgn = tbSupplySub.supCreditFrgn,
                        supDscntAmount = tbSupplySub.supDscntAmount,
                        subHeight = tbSupplySub.subHeight,
                        subQteMeter = tbSupplySub.subQteMeter,
                        subWidth = tbSupplySub.subWidth,
                        subNoPacks = tbSupplySub.subNoPacks,
                        supOvertime = tbSupplySub.supOvertime,
                        supWorkingtime = tbSupplySub.supWorkingtime,
                    }).ToList();
        }
        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.GetSupplyMain = new ClsTblSupplyMain()));
            taskList.Add(Task.Run(() => this.GetSupplySub = new ClsTblSupplySub()));
            await Task.WhenAll(taskList);
        }

        public string ConnectionString_AccDB()
        {
            string conStraing = "";
            if (ConnSetting.GetConnSetting.AccMode == "SQL")
                conStraing = "data source=" + ConnSetting.GetConnSetting.AccServerName + ";Initial Catalog=" + ConnSetting.GetConnSetting.AccDBName + ";user id=" + ConnSetting.GetConnSetting.AccSqlUserName + ";password=" + ConnSetting.GetConnSetting.AccSqlPassword + ";";
            else if (ConnSetting.GetConnSetting.AccMode == "Windows")
                conStraing = "data source=" + ConnSetting.GetConnSetting.AccServerName + ";Initial Catalog=" + ConnSetting.GetConnSetting.AccDBName + ";Integrated Security=true;";
            return conStraing;
        }
        //private bool ChickNetConnection()
        //{
        //    Ping myping = new Ping();
        //    string host = "google.com";
        //    byte[] bufer = new byte[32];
        //    int timeOute = 1000;
        //    PingOptions pingOption = new PingOptions();
        //    PingReply Reply = myping.Send(host, timeOute, bufer, pingOption);
        //    return (Reply.Status == IPStatus.Success);
        //}
        public async void UpLoadData()
        {
            try
            {
               // if (!ChickNetConnection()) return;
                if (!Database.Exists(ConnectionString_AccDB())) return;
                await InitObjectsAsync();
                upDataState = true;
                DataClasses1DataContext db = new DataClasses1DataContext(ConnectionString_AccDB());
                var SupplyMainCurrant = GetSupplyMain.GetSupplyMainList.Where(s => (s.supStatus == 9 || s.supStatus == 11 || s.supStatus == 3 || s.supStatus == 4) 
                && s.supBrnId == BranchID && (!((s.SendToserver as bool?) ?? false))).ToList();
                foreach (var item in SupplyMainCurrant)
                {
                    SupplyMainAcc = GetCopyOfCurrentSupplyMain(item);
                    db.AccMain_tblSupplyMains.InsertOnSubmit(SupplyMainAcc);
                    db.SubmitChanges();
                    db.AccMain_tblSupplySubs.InsertAllOnSubmit(GetCopyOfCurrentSupplySub(item.id, SupplyMainAcc.id));
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {
                upDataState = false;
                return;
            }
            upDataState = false;
        }

        public AccMain_tblSupplyMain GetCopyOfCurrentSupplyMain(tblSupplyMain supplyMain)
        {
            return new AccMain_tblSupplyMain()
            {
                supNo = supplyMain.supNo,                                         
                supDate = supplyMain.supDate,
                supAccName = supplyMain.supAccName,
                supAccNo = supplyMain.supAccNo,
                supBankAmount = supplyMain.supBankAmount,
                supBankId = supplyMain.supBankId,
                supBoxId = supplyMain.supBoxId,
                supBrnId = supplyMain.supBrnId,
                supCurrency = supplyMain.supCurrency,
                supCurrencyChng = supplyMain.supCurrencyChng,
                supCustSplId = supplyMain.supCustSplId,
                supDesc = supplyMain.supDesc,
                supDscntAmount = supplyMain.supDscntAmount,
                supDscntPercent = supplyMain.supDscntPercent,
                supEqfal = supplyMain.supEqfal,
                supIsCash = supplyMain.supIsCash,
                TotalAfterDiscount = supplyMain.TotalAfterDiscount,
                supRefNo = supplyMain.supRefNo,
                supStatus = supplyMain.supStatus,
                supStrId = supplyMain.supStrId,
                supTaxPercent = supplyMain.supTaxPercent,
                supTaxPrice = supplyMain.supTaxPrice,
                supTotal = supplyMain.supTotal,
                supTotalFrgn = supplyMain.supTotalFrgn,
                supUserId = supplyMain.supUserId,
                SendToserver = true,
                CarType = supplyMain.CarType,
                CounterNumber = supplyMain.CounterNumber,
                DueDate = supplyMain.DueDate,
                EnterDate = supplyMain.EnterDate,
             //   id = supplyMain.id,
                IsDelete = supplyMain.IsDelete,
                //net1 = supplyMain.net1,
                Notes = supplyMain.Notes,
                paidCash = supplyMain.paidCash,
                PlateNumber = supplyMain.PlateNumber,
                PoNumber = supplyMain.PoNumber,
                remin = supplyMain.remin,
            };
        }
        public List<AccMain_tblSupplySub> GetCopyOfCurrentSupplySub(int Id, int AccMainId)
        {
            return (from tbSupplySub in GetSupplySub.GetSupplySubListBySupId1(Id)
                    select new AccMain_tblSupplySub
                   {
                    supNo = AccMainId,
                    supDate = tbSupplySub.supDate,
                    supBrnId = Session.CurBranch.brnId,
                    supUserId = Session.CurrentUser.id,
                    supStatus = tbSupplySub.supStatus,
                    supAccNo = tbSupplySub.supAccNo,
                    supAccName = tbSupplySub.supAccName,
                    supDesc = tbSupplySub.supDesc,
                    supPrdBarcode = tbSupplySub.supPrdBarcode,
                    supPrdNo = tbSupplySub.supPrdNo,
                    supPrdName = tbSupplySub.supPrdName,
                    supPrdId = tbSupplySub.supPrdId,
                    supMsur = tbSupplySub.supMsur,
                    supPrdManufacture = tbSupplySub.supPrdManufacture,
                    supCurrency = tbSupplySub.supCurrency,
                    supQuanMain = tbSupplySub.supQuanMain,
                    supPrice = tbSupplySub.supPrice,
                    supSalePrice = tbSupplySub.supSalePrice,
                    supTaxPercent = tbSupplySub.supTaxPercent,
                    supTaxPrice = tbSupplySub.supTaxPrice,
                    supDscntPercent = tbSupplySub.supDscntPercent,
                    supDebit = tbSupplySub.supDebit,
                    supCredit = tbSupplySub.supCredit,
                    supDebitFrgn = tbSupplySub.supDebitFrgn,
                    supCreditFrgn = tbSupplySub.supCreditFrgn,
                    supDscntAmount = tbSupplySub.supDscntAmount,
                    subHeight = tbSupplySub.subHeight,
                    subQteMeter = tbSupplySub.subQteMeter,
                    subWidth = tbSupplySub.subWidth,
                    subNoPacks = tbSupplySub.subNoPacks,
                    supOvertime = tbSupplySub.supOvertime,
                    supWorkingtime = tbSupplySub.supWorkingtime,
                }).ToList();
            }
    }
}
