using DevExpress.Utils.Extensions;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace PosFinalCost.Classe
{
    class UploadDataToMain
    {
        tblSupplyMain SupplyMainAcc;
        public static bool upDataState = false;
        List<SupplyMain> GetSupplyMain;
        List<SupplySub> GetSupplySub;
        List<PrdExpirateDetail> GetExpirateDetail;
        List<PrdExpirateMain> GetExpirateMain;
        List<DrawerPeriod> GetDrawerPeriod;
        PosDBDataContext Localdb;
        AccDBDataContext Serverdb;
        //IEnumerable<DefaultAccount> GetDefaultAccounts;
        //IEnumerable<tblDefaultAccount> GetMainDefaultAccounts;
        IEnumerable<FinancialYear> GetFinancialYears;
        IEnumerable<tblFinancialYear> GetMainFinancialYears;
        IEnumerable<Branch> GetBranchs;
        IEnumerable<tblBranch> GetMainBranchs;
        IEnumerable<Customer> GetCustomers;
        IEnumerable<tblCustomer> GetMainCustomers;
        IEnumerable<Currency> GetCurrencys;
        IEnumerable<tblCurrency> GetMainCurrencys;
        IEnumerable<Box> GetBoxs;
        IEnumerable<tblAccountBox> GetMainBoxs;
        IEnumerable<Bank> GetBanks;
        IEnumerable<tblAccountBank> GetMainBanks;
        IEnumerable<StoreTbl> GetStores;
        IEnumerable<tblStore> GetMainStores;
        IEnumerable<UserTbl> GetUsers;
        IEnumerable<tblUser> GetMainUsers;
        IEnumerable<Product> GetProducts;
        IEnumerable<tblProduct> GetMainProducts;
        IEnumerable<Barcode> GetBarcodes;
        IEnumerable<tblBarcode> GetMainBarcodes;
        IEnumerable<ProductColor> GetProductColors;
        IEnumerable<tblProductColor> GetMainProductColors;
        IEnumerable<PrdMeasurment> GetMeasurments;
        IEnumerable<tblPrdPriceMeasurment> GetMainMeasurments;
        IEnumerable<ProductQunatity> GetProductQunatitys;
        IEnumerable<tblProductQunatity> GetMainProductQunatitys;
        IEnumerable<GroupStr> GetGroupStr;
        IEnumerable<tblGroupStr> GetMainGroupStr;

        short BranchID = Session.CurrentBranch.ID;
        short UserID = Session.CurrentUser.ID;
        public event EventHandler<string> OnProcess;
        public event EventHandler<bool> ProcessCompleted;
        public UploadDataToMain()
        {

        }
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        Form form1;
        public void PullAsync(Form form)
        {
            form1 = form;
            flyDialog.WaitForm(form, 1);
            if (Database.Exists(ConnectionString_AccDB) == false)
            {
                OnProcess?.Invoke("Pull", $"Server Not Connect{Environment.NewLine}");
                return;
            }
            Localdb = new PosDBDataContext(Program.ConnectionString);
            Serverdb = new AccDBDataContext(ConnectionString_AccDB);
            SyncStoreData();
        }
        private async Task InitDataBaseAsync()
        {
            IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => GetDefaultAccounts = Localdb.DefaultAccounts));
            //taskList.Add(Task.Run(() => GetMainDefaultAccounts = Serverdb.tblDefaultAccounts));
            taskList.Add(Task.Run(() => GetFinancialYears = Localdb.FinancialYears));
            taskList.Add(Task.Run(() => GetMainFinancialYears = Serverdb.tblFinancialYears));
            taskList.Add(Task.Run(() => GetBranchs = Localdb.Branches));
            taskList.Add(Task.Run(() => GetMainBranchs = Serverdb.tblBranches));
            taskList.Add(Task.Run(() => GetCurrencys = Localdb.Currencies));
            taskList.Add(Task.Run(() => GetMainCurrencys = Serverdb.tblCurrencies));
            taskList.Add(Task.Run(() => GetBoxs = Localdb.Boxes));
            taskList.Add(Task.Run(() => GetMainBoxs = Serverdb.tblAccountBoxes));
            taskList.Add(Task.Run(() => GetBanks = Localdb.Banks));
            taskList.Add(Task.Run(() => GetMainBanks = Serverdb.tblAccountBanks));
            taskList.Add(Task.Run(() => GetCustomers = Localdb.Customers));
            taskList.Add(Task.Run(() => GetMainCustomers = Serverdb.tblCustomers));
            taskList.Add(Task.Run(() => GetStores = Localdb.StoreTbls));
            taskList.Add(Task.Run(() => GetMainStores = Serverdb.tblStores));
            taskList.Add(Task.Run(() => GetProducts = Localdb.Products));
            taskList.Add(Task.Run(() => GetMainProducts = Serverdb.tblProducts));
            taskList.Add(Task.Run(() => GetBarcodes = Localdb.Barcodes));
            taskList.Add(Task.Run(() => GetMainBarcodes = Serverdb.tblBarcodes));
            taskList.Add(Task.Run(() => GetProductColors = Localdb.ProductColors));
            taskList.Add(Task.Run(() => GetMainProductColors = Serverdb.tblProductColors));
            taskList.Add(Task.Run(() => GetMeasurments = Localdb.PrdMeasurments));
            taskList.Add(Task.Run(() => GetMainMeasurments = Serverdb.tblPrdPriceMeasurments));
            taskList.Add(Task.Run(() => GetProductQunatitys = Localdb.ProductQunatities));
            taskList.Add(Task.Run(() => GetMainProductQunatitys = Serverdb.tblProductQunatities));
            //taskList.Add(Task.Run(() => GetProductPrices = Localdb.ProductPrices));
            //taskList.Add(Task.Run(() => GetMainProductPrices = Serverdb.tblPrdPriceQuans));
            taskList.Add(Task.Run(() => GetGroupStr = Localdb.GroupStrs));
            taskList.Add(Task.Run(() => GetMainGroupStr = Serverdb.tblGroupStrs));
            taskList.Add(Task.Run(() => GetUsers = Localdb.UserTbls));
            taskList.Add(Task.Run(() => GetMainUsers = Serverdb.tblUsers));
            await Task.WhenAll(taskList);
        }

      
        async void SyncStoreData()
        {
            await InitDataBaseAsync();
            //SyncDefaultAccount();
            
          
          
            SyncFinancialYear();
            SyncBranch();
            SyncCurrency();
            SyncBox();
            SyncBank();
            SyncCustomer();
            SyncStore();
            SyncGroupStr();
            SyncProduct();
            SyncPrdPriceMeasurment();
            SyncProductQunatity();
            //SyncProductPrice();
            SyncBarcode();
            SyncProductColor();
            SyncUser();
            flyDialog.WaitForm(form1, 0, form1);
            XtraMessageBox.Show("تم سحب البيانات بنجاح", "");
        }
        int count;
        //void SyncDefaultAccount()
        //{
        //    OnProcess?.Invoke("Pull", $"Sync DefaultAccounts....{Environment.NewLine}");
        //    var stor = (from x in GetMainDefaultAccounts
        //                select new
        //                {
        //                    dflAccNo = x.dflAccNo,
        //                    dflId = x.dflId,
        //                    dflStatus = x.dflStatus,
        //                    dfltBrnId = x.dfltBrnId
        //                }).ToList();
        //    var stor2 = (from x in GetDefaultAccounts
        //                 select new
        //                 {
        //                     dflAccNo = x.AccNo,
        //                     dflId = x.ID,
        //                     dflStatus = x.Status,
        //                     dfltBrnId = x.BrnId
        //                 }).ToList();
        //    var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
        //    count = stNewOrUpdate.Count();
        //    if (count > 0)
        //        foreach (var s in stNewOrUpdate)
        //            Localdb.InsDefaultAccountToPos(s.dflId, s.dflAccNo, s.dflStatus, s.dfltBrnId);
        //    OnProcess?.Invoke("Pull", $"Sync {count} DefaultAccounts Done{Environment.NewLine}");
        //}
        void SyncFinancialYear()
        {
            OnProcess?.Invoke("Pull", $"Sync FinancialYears....{Environment.NewLine}");
            if (GetFinancialYears.Where(n => !GetMainFinancialYears.Any(x => x.fyId == n.ID)) is IEnumerable<FinancialYear> Year && Year != null)
            {
                Localdb.FinancialYears.DeleteAllOnSubmit(Year);
                Localdb.SubmitChanges();
            }
           
            var stor = (from x in GetMainFinancialYears
                        select new
                        {
                            fyBranchId = x.fyBranchId,
                            fyDateEnd = x.fyDateEnd,
                            fyDateStart = x.fyDateStart,
                            fyId = x.fyId,
                            fyName = x.fyName,
                        }).ToList();
            var stor2 = (from x in GetFinancialYears
                         select new
                         {
                             fyBranchId = x.BrnId,
                             fyDateEnd = x.DateEnd,
                             fyDateStart = x.DateStart,
                             fyId = x.ID,
                             fyName = x.Name,
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainFinancialYears)
                    Localdb.InsFinancialYearToPos(s.fyId, s.fyName, s.fyDateStart, s.fyDateEnd, s.fyBranchId);
            OnProcess?.Invoke("Pull", $"Sync {count} FinancialYears Done{Environment.NewLine}");
        }
        void SyncBranch()
        {
            OnProcess?.Invoke("Pull", $"Sync Branchs....{Environment.NewLine}");
            if (GetBranchs.Where(n => !GetMainBranchs.Any(x => x.brnId == n.ID)) is IEnumerable<Branch> Branch && Branch != null)
            {
                Localdb.Branches.DeleteAllOnSubmit(Branch);
                Localdb.SubmitChanges();
            }
         
            var stor = (from x in GetMainBranchs
                        select new
                        {
                            brnAddress = x.brnAddress,
                            brnAddressEn = x.brnAddressEn,
                            brnEmail = x.brnEmail,
                            brnFaxNo = x.brnFaxNo,
                            brnId = x.brnId,
                            brnMailBox = x.brnMailBox,
                            brnName = x.brnName,
                            brnNameEn = x.brnNameEn,
                            brnNo = x.brnNo,
                            brnPhnNo = x.brnPhnNo,
                            brnStatus = x.brnStatus,
                            brnTaxNo = x.brnTaxNo,
                            brnTradeNo = x.brnTradeNo
                        }).ToList();
            var stor2 = (from x in GetBranchs
                         select new
                         {
                             brnAddress = x.Address,
                             brnAddressEn = x.AddressEn,
                             brnEmail = x.Email,
                             brnFaxNo = x.FaxNo,
                             brnId = x.ID,
                             brnMailBox = x.MailBox,
                             brnName = x.Name,
                             brnNameEn = x.NameEn,
                             brnNo = x.No,
                             brnPhnNo = x.PhnNo,
                             brnStatus = x.Status,
                             brnTaxNo = x.TaxNo,
                             brnTradeNo = x.TradeNo
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainBranchs)
                {
                    Localdb.InsBranchToPos(s.brnId, s.brnNo, s.brnName, s.brnNameEn
                      , s.brnAddress, s.brnAddressEn, s.brnEmail, s.brnPhnNo, s.brnFaxNo, s.brnMailBox, s.brnTaxNo, s.brnTradeNo, s.brnStatus);
                }
            OnProcess?.Invoke("Pull", $"Sync {count} Branchs Done{Environment.NewLine}");
        }
        void SyncCurrency()
        {
            OnProcess?.Invoke("Pull", $"Sync Currencys....{Environment.NewLine}");
            if (GetCurrencys.Where(n => !GetMainCurrencys.Any(x => x.id == n.ID)) is IEnumerable<Currency> Currency && Currency != null)
            {
                Localdb.Currencies.DeleteAllOnSubmit(Currency);
                Localdb.SubmitChanges();
            }
          
            var stor = (from x in GetMainCurrencys
                        select new
                        {
                            id = x.id,
                            curName = x.curName,
                            curChange = x.curChange,
                            curSign = x.curSign,
                            curType = x.curType
                        }).ToList();
            var stor2 = (from x in GetCurrencys
                         select new
                         {
                             id = x.ID,
                             curName = x.Name,
                             curChange = x.Change,
                             curSign = x.Sign,
                             curType = x.Type
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            GetMainCurrencys.ForEach(s => Localdb.InsCurrencyToPos(s.id, s.curSign, s.curName, s.curType, s.curChange));
            foreach (var s in stNewOrUpdate)
                OnProcess?.Invoke("Pull", $"Sync {count} Currencys Done{Environment.NewLine}");
        }
        void SyncBox()
        {
            OnProcess?.Invoke("Pull", $"Sync Boxs....{Environment.NewLine}");
            if (GetBoxs.Where(n => !GetMainBoxs.Any(x => x.id == n.ID)) is IEnumerable<Box> Box && Box != null)
            {
                Localdb.Boxes.DeleteAllOnSubmit(Box);
                Localdb.SubmitChanges();
            }
           
            var stor = (from x in GetMainBoxs
                        select new
                        {
                            id = x.id,
                            boxBrnId = x.boxBrnId,
                            boxName = x.boxName,
                            boxNo = x.boxNo,
                            boxAccNo = x.boxAccNo,
                            boxCelling = x.boxCelling,
                            boxCurrency = x.boxCurrency,
                        }).ToList();
            var stor2 = (from x in GetBoxs
                         select new
                         {
                             id = x.ID,
                             boxBrnId = x.BrnId,
                             boxName = x.Name,
                             boxNo = x.No,
                             boxAccNo = x.AccNo,
                             boxCelling = x.Celling,
                             boxCurrency = x.Currency,
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainBoxs)
                Localdb.InsBoxToPos(s.id, s.boxNo, s.boxAccNo, s.boxName, s.boxCurrency
                    , s.boxCelling, s.boxBrnId);
            OnProcess?.Invoke("Pull", $"Sync {count} Boxs Done{Environment.NewLine}");
        }
        void SyncBank()
        {
            OnProcess?.Invoke("Pull", $"Sync Banks....{Environment.NewLine}");
            if (GetBanks.Where(n => !GetMainBanks.Any(x => x.id == n.ID)) is IEnumerable<Bank> bank && bank != null)
            {
                Localdb.Banks.DeleteAllOnSubmit(bank);
                Localdb.SubmitChanges();
            }
           
            var stor = (from x in GetMainBanks
                        select new
                        {
                            id = x.id,
                            bankBrnId = x.bankBrnId,
                            bankName = x.bankName,
                            bankNo = x.bankNo,
                            AccNoInBank = x.AccNoInBank,
                            bankAccIBAN = x.bankAccIBAN,
                            bankAccNo = x.bankAccNo,
                            bankCelling = x.bankCelling,
                            bankCurrency = x.bankCurrency,
                            bankNameEn = x.bankNameEn,
                            bankSwiftCode = x.bankSwiftCode
                        }).ToList();
            var stor2 = (from x in GetBanks
                         select new
                         {
                             id = x.ID,
                             bankBrnId = x.BrnId,
                             bankName = x.Name,
                             bankNo = x.No,
                             AccNoInBank = x.AccNoInBank,
                             bankAccIBAN = x.AccIBAN,
                             bankAccNo = x.AccNo,
                             bankCelling = x.Celling,
                             bankCurrency = x.Currency,
                             bankNameEn = x.NameEn,
                             bankSwiftCode = x.SwiftCode
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainBanks)
                Localdb.InsBankToPos(s.id, s.bankNo, s.bankAccNo, s.bankName, s.bankCurrency
                    , s.bankCelling, s.bankBrnId, s.bankSwiftCode, s.bankAccIBAN, s.AccNoInBank, s.bankNameEn);
            OnProcess?.Invoke("Pull", $"Sync {count} Banks Done{Environment.NewLine}");
        }
        void SyncCustomer()
        {
            OnProcess?.Invoke("Pull", $"Sync Customers....{Environment.NewLine}");
            var stor = (from x in GetMainCustomers
                        select new
                        {
                            CommercialRegister = x.CommercialRegister,
                            cusAddNo = x.cusAddNo,
                            cusAnotherID = x.cusAnotherID,
                            cusBankId = x.cusBankId.GetValueOrDefault(),
                            cusBuildingNo = x.cusBuildingNo,
                            cusDistrict = x.cusDistrict,
                            cusDistrictEn = x.cusDistrictEn,
                            custAccNo = x.custAccNo,
                            custAddress = x.custAddress,
                            custAddressEn = x.custAddressEn,
                            custBrnId = x.custBrnId.GetValueOrDefault(),
                            custCellingCredit = x.custCellingCredit.GetValueOrDefault(),
                            custCity = x.custCity,
                            custCityEn = x.custCityEn,
                            custCountry = x.custCountry,
                            custCountryEn = x.custCountryEn,
                            custCurrency = x.custCurrency.GetValueOrDefault(),
                            custEmail = x.custEmail,
                            custName = x.custName,
                            custNameEn = x.custNameEn,
                            custNo = x.custNo,
                            custPhnNo = x.custPhnNo,
                            custSalePrice = x.custSalePrice.GetValueOrDefault(),
                            custStatus = x.custStatus,
                            custTaxNo = x.custTaxNo,
                            id = x.id,
                            PostalCode = x.PostalCode,
                        }).ToList();
            var stor2 = (from x in GetCustomers
                         select new
                         {
                             CommercialRegister = x.CommercialRegister,
                             cusAddNo = x.AddNo,
                             cusAnotherID = x.AnotherID,
                             cusBankId = x.BankId.GetValueOrDefault(),
                             cusBuildingNo = x.BuildingNo,
                             cusDistrict = x.District,
                             cusDistrictEn = x.DistrictEn,
                             custAccNo = x.AccNo,
                             custAddress = x.Address,
                             custAddressEn = x.AddressEn,
                             custBrnId = x.BrnId.GetValueOrDefault(),
                             custCellingCredit = x.CellingCredit.GetValueOrDefault(),
                             custCity = x.City,
                             custCityEn = x.CityEn,
                             custCountry = x.Country,
                             custCountryEn = x.CountryEn,
                             custCurrency = x.Currency.GetValueOrDefault(),
                             custEmail = x.Email,
                             custName = x.Name,
                             custNameEn = x.NameEn,
                             custNo = x.No,
                             custPhnNo = x.PhnNo,
                             custSalePrice = x.SalePrice.GetValueOrDefault(),
                             custStatus = x.Status,
                             custTaxNo = x.TaxNo,
                             id = x.ID,
                             PostalCode = x.PostalCode,
                         }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in stNewOrUpdate)
                    Localdb.InsCustomerToPos(s.id, s.custNo, s.custAccNo, s.custName, s.custPhnNo, s.custCountry, s.custCity, s.custCityEn
                        , s.custEmail, s.custCellingCredit, s.custCurrency, s.custSalePrice, s.custTaxNo, s.custBrnId, s.custStatus, s.custNameEn,
                       s.custCountryEn, s.custCityEn, s.custAddressEn, s.CommercialRegister, s.PostalCode, s.cusBankId, s.cusAddNo, s.cusBuildingNo,
                       s.cusAnotherID, s.cusDistrict, s.cusDistrictEn);
            OnProcess?.Invoke("Pull", $"Sync {count} Customers Done{Environment.NewLine}");
        }
        void SyncStore()
        {
            OnProcess?.Invoke("Pull", $"Sync Stores....{Environment.NewLine}");
            if (GetStores.Where(n => !GetMainStores.Any(x => x.id == n.ID)) is IEnumerable<StoreTbl> st && st != null)
            {
                Localdb.StoreTbls.DeleteAllOnSubmit(st);
                Localdb.SubmitChanges();
            }
            
            var stor = (from x in GetMainStores select new { id = x.id, strBrnId = x.strBrnId, strName = x.strName, strNo = x.strNo, strPhnNo = x.strPhnNo, strStatus = x.strStatus }).ToList();
            var stor2 = (from x in GetStores select new { id = x.ID, strBrnId = x.BrnId, strName = x.Name, strNo = x.No, strPhnNo = x.PhnNo, strStatus = x.Status }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n).ToList();
            count = stNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainStores)
                Localdb.InsStoreToPos(s.id, s.strNo, s.strName, s.strPhnNo, s.strBrnId, s.strStatus);
            OnProcess?.Invoke("Pull", $"Sync {count} Stores Done{Environment.NewLine}");
        }
        void SyncUser()
        {
            OnProcess?.Invoke("Pull", $"Sync Users....{Environment.NewLine}");
            if (GetUsers.Where(n => !GetMainUsers.Any(x => x.id == n.ID)) is IEnumerable<UserTbl> user && user != null)
            {
                Localdb.UserTbls.DeleteAllOnSubmit(user);
                Localdb.SubmitChanges();
            }
            var stor = (from x in GetMainUsers select new { id = x.id, userName = x.userName, userPass = x.userPass }).ToList();
            var stor2 = (from x in GetUsers select new { id = x.ID, userName = x.Name, userPass = x.Pass }).ToList();
            var stNewOrUpdate = (from n in stor where !stor2.Contains(n) select n);
            count = stNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in GetMainUsers)
                    Localdb.InsUserToPos(s.id, s.userName, s.userPass);
            OnProcess?.Invoke("Pull", $"Sync {count} Users Done{Environment.NewLine}");
        }
        void SyncGroupStr()
        {
            OnProcess?.Invoke("Pull", $"Sync GroupStrs....{Environment.NewLine}");
            if (GetGroupStr.Where(n => !GetMainGroupStr.Any(x => x.id == n.ID)) is IEnumerable<GroupStr> GroStr && GroStr != null)
            {
                Localdb.GroupStrs.DeleteAllOnSubmit(GroStr);
                Localdb.SubmitChanges();
            }
         
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
                                 id = x.ID,
                                 grpAccNo = x.AccNo,
                                 grpBrnId = x.BrnId,
                                 grpCostAccNo = x.CostAccNo,
                                 grpCostRtrnAccNo = x.CostRtrnAccNo,
                                 grpCurrency = x.Currency,
                                 grpDscntAccNo = x.DscntAccNo,
                                 grpName = x.Name,
                                 grpNo = x.No,
                                 grpPurchaseAccNo = x.PurchaseAccNo,
                                 grpPurchaseRtrnAccNo = x.PurchaseRtrnAccNo,
                                 grpSalesAccNo = x.SalesAccNo,
                                 grpSalesRtrnAccNo = x.SalesRtrnAccNo,
                                 grpStatus = x.Status,
                             }).ToList();
            var MeasNewOrUpdate = (from n in GroupStr where !GroupStr2.Contains(n) select n);
            count = MeasNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in GetMainGroupStr)
                Localdb.InsGroupToPos(s.id, s.grpNo, s.grpName, s.grpAccNo, s.grpCurrency, s.grpSalesAccNo, s.grpCostAccNo, s.grpDscntAccNo, s.grpSalesRtrnAccNo, s.grpCostRtrnAccNo, s.grpBrnId, s.grpStatus, s.grpPurchaseAccNo, s.grpPurchaseRtrnAccNo);
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
                          id = x.ID,
                          prdBrnId = x.BrnId,
                          prdName = x.Name,
                          prdNo = x.No,
                          prdNameEng = x.NameEng,
                          MaxLevel = x.MaxLevel,
                          prdDesc = x.Desc,
                          prdStatus = x.Status,
                          prdGrpNo = x.GrpNo,
                          prdPriceTax = x.PriceTax,
                          prdPurchaseTax = x.PurchaseTax,
                          prdSaleTax = x.SaleTax,
                          ReorderLevel = x.ReorderLevel,
                          Suspended = x.Suspended
                      }).ToList();
            var proNewOrUpdate = (from n in p1 where !p2.Contains(n) select n).ToList();
            count = proNewOrUpdate.Count();
            if (count > 0)
            foreach (var x in proNewOrUpdate)
                Localdb.InsProductToPos(x.id, x.prdNo, x.prdName, x.prdNameEng, x.prdGrpNo, x.prdDesc, x.prdSaleTax, x.prdBrnId, x.prdStatus, x.prdPriceTax, x.ReorderLevel, x.MaxLevel, x.prdPurchaseTax,x.Suspended);
            p2 = (from x in Localdb.Products
                  select new
                  {
                      id = x.ID,
                      prdBrnId = x.BrnId,
                      prdName = x.Name,
                      prdNo = x.No,
                      prdNameEng = x.NameEng,
                      MaxLevel = x.MaxLevel,
                      prdDesc = x.Desc,
                      prdStatus = x.Status,
                      prdGrpNo = x.GrpNo,
                      prdPriceTax = x.PriceTax,
                      prdPurchaseTax = x.PurchaseTax,
                      prdSaleTax = x.SaleTax,
                      ReorderLevel = x.ReorderLevel,
                      Suspended = x.Suspended
                  }).ToList();
            var proNewOrUpdate2 = (from n in p2 where !p1.Contains(n) select n).ToList();
            if (proNewOrUpdate2.Count > 0)
            {
                foreach (var x in proNewOrUpdate2)
                {
                    Localdb.Products.DeleteOnSubmit(Localdb.Products.FirstOrDefault(y => y.ID == x.id));
                    Localdb.SubmitChanges();
                }
            }
            OnProcess?.Invoke("Pull", $"Sync {count} Products Done{Environment.NewLine}");
        }
        void SyncBarcode()
        {

            OnProcess?.Invoke("Pull", $"Sync Barcodes....{Environment.NewLine}");
            var Barcode = (from x in GetMainBarcodes select new { id = x.id, brcNo = x.brcNo, brcPrdMsurId = x.brcPrdMsurId, brcBrnId = x.brcBrnId }).ToList();
            var Barcode2 = (from x in GetBarcodes select new { id = x.ID, brcNo = x.MsurBarcode, brcPrdMsurId = x.MsurId, brcBrnId = x.BrnId }).ToList();
            var BarNewOrUpdate = (from n in Barcode where !Barcode2.Contains(n) select n);
            count = BarNewOrUpdate.Count();
            if (count > 0)
                foreach (var s in BarNewOrUpdate)
                    Localdb.InsBarcodeToPos(s.id, s.brcNo, s.brcPrdMsurId, s.brcBrnId);

            Barcode2 = (from x in Localdb.Barcodes select new { id = x.ID, brcNo = x.MsurBarcode, brcPrdMsurId = x.MsurId, brcBrnId = x.BrnId }).ToList();
            var proNewOrUpdate2 = (from n in Barcode2 where !Barcode.Contains(n) select n).ToList();
            if (proNewOrUpdate2.Count > 0)
            {
                foreach (var x in proNewOrUpdate2)
                {
                    Localdb.Barcodes.DeleteOnSubmit(Localdb.Barcodes.FirstOrDefault(y => y.ID == x.id));
                    Localdb.SubmitChanges();
                }
            }
            OnProcess?.Invoke("Pull", $"Sync {count} Barcodes Done{Environment.NewLine}");
        }
        void SyncProductColor()
        {
            OnProcess?.Invoke("Pull", $"Sync ProductColors....{Environment.NewLine}");
           
            var ProductColor = (from x in GetMainProductColors select new { id = x.colId, colQuan = x.colQuan, colHtml = x.colHtml }).ToList();
            var ProductColor2 = (from x in GetProductColors select new { id = x.ID, colQuan = x.Quan, colHtml = x.Html }).ToList();
            var BarNewOrUpdate = (from n in ProductColor where !ProductColor2.Contains(n) select n);
            count = BarNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in BarNewOrUpdate)
                Localdb.InsProductColorToPos(s.id, s.colQuan, s.colHtml);
            ProductColor2 = (from x in Localdb.ProductColors select new { id = x.ID, colQuan = x.Quan, colHtml = x.Html }).ToList();
            var BarNewOrUpdate2 = (from n in ProductColor2 where !ProductColor.Contains(n) select n).ToList();
            if (BarNewOrUpdate2.Count > 0)
            {
                foreach (var x in BarNewOrUpdate2)
                {
                    Localdb.ProductColors.DeleteOnSubmit(Localdb.ProductColors.FirstOrDefault(y => y.ID == x.id));
                    Localdb.SubmitChanges();
                }
            }
            OnProcess?.Invoke("Pull", $"Sync {count} ProductColors Done{Environment.NewLine}");
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
                                           ppmId = x.ID,
                                           ppmMsurName = x.Name,
                                           ppmPrice = x.Price,
                                           ppmSalePrice = x.SalePrice,
                                           ppmMinSalePrice=x.MinSalePrice,
                                           ppmRetailPrice= x.RetailPrice,
                                           ppmBatchPrice = x.BatchPrice,
                                           ppmConversion = x.Conversion,
                                           ppmDefault =    x.Default,
                                           ppmPrdId = x.PrdId,
                                           ppmWeight = x.Weight,
                                           ppmBrnId = x.BrnId,
                                           ppmStatus = x.Status,
                                           ppmManufacture = x.Manufacture,
                                       }).ToList();
            var MeasNewOrUpdate = (from n in PrdPriceMeasurment where !PrdPriceMeasurment2.Contains(n) select n);
            count = MeasNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in MeasNewOrUpdate)
                Localdb.InsProMeasurmentToPos(s.ppmId, s.ppmMsurName, s.ppmPrice, s.ppmSalePrice, s.ppmMinSalePrice, s.ppmRetailPrice, s.ppmBatchPrice, s.ppmConversion, s.ppmDefault, s.ppmPrdId, s.ppmWeight, s.ppmBrnId, s.ppmStatus, s.ppmManufacture);

            PrdPriceMeasurment2 = (from x in Localdb.PrdMeasurments
                                   select new
                                   {
                                       ppmId = x.ID,
                                       ppmMsurName = x.Name,
                                       ppmPrice =        x.Price,
                                       ppmSalePrice =    x.SalePrice,
                                       ppmMinSalePrice = x.MinSalePrice,
                                       ppmRetailPrice =  x.RetailPrice,
                                       ppmBatchPrice =   x.BatchPrice,
                                       ppmConversion =   x.Conversion,
                                       ppmDefault =      x.Default,
                                       ppmPrdId = x.PrdId,
                                       ppmWeight = x.Weight,
                                       ppmBrnId = x.BrnId,
                                       ppmStatus = x.Status,
                                       ppmManufacture = x.Manufacture,
                                   }).ToList();
            var MeasNewOrUpdate2 = (from n in PrdPriceMeasurment2 where !PrdPriceMeasurment.Contains(n) select n);
            if (MeasNewOrUpdate2.Count() > 0)
            {
                foreach (var x in MeasNewOrUpdate2)
                {
                    Localdb.PrdMeasurments.DeleteOnSubmit(Localdb.PrdMeasurments.FirstOrDefault(y => y.ID == x.ppmId));
                    Localdb.SubmitChanges();
                }
            }
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
                                        id = x.ID,
                                        prdBrnId = x.BrnId,
                                        prdId = x.prdId,
                                        prdQuantity = x.Quantity,
                                        prdStatus = x.Status,
                                        prdStrId = x.StrId,
                                        prdSubQuantity = x.SubQuantity,
                                        prdSubQuantity3 = x.SubQuantity3,
                                    }).ToList();
            var MeasNewOrUpdate = (from n in ProductQunatity where !ProductQunatity2.Contains(n) select n);
            count = MeasNewOrUpdate.Count();
            if (count > 0)
            foreach (var s in MeasNewOrUpdate)
                Localdb.InsProQuanToPos(s.id, s.prdId, s.prdQuantity, s.prdSubQuantity, s.prdSubQuantity3, s.prdStrId, s.prdBrnId, s.prdStatus);
            ProductQunatity2 = (from x in Localdb.ProductQunatities
                                select new
                                {
                                    id = x.ID,
                                    prdBrnId = x.BrnId,
                                    prdId = x.prdId,
                                    prdQuantity = x.Quantity,
                                    prdStatus = x.Status,
                                    prdStrId = x.StrId,
                                    prdSubQuantity = x.SubQuantity,
                                    prdSubQuantity3 = x.SubQuantity3,
                                }).ToList();
            var MeasNewOrUpdate2 = (from n in ProductQunatity2 where !ProductQunatity.Contains(n) select n);
            if (MeasNewOrUpdate2.Count() > 0)
            {
                foreach (var x in MeasNewOrUpdate2)
                {
                    Localdb.ProductQunatities.DeleteOnSubmit(Localdb.ProductQunatities.FirstOrDefault(y => y.ID == x.id));
                    Localdb.SubmitChanges();
                }
            }
            OnProcess?.Invoke("Pull", $"Sync {count} ProductQunatitys Done{Environment.NewLine}");
        }
        //void SyncProductPrice()
        //{
        //    OnProcess?.Invoke("Pull", $"Sync ProductPrices....{Environment.NewLine}");
        //    var ProductPrice = (from x in GetMainProductPrices
        //                        select new
        //                        {
        //                            prId = x.prId,
        //                            prdBrnId = x.prdBrnId,
        //                            pr1 = x.pr1,
        //                            pr2 = x.pr2,
        //                            pr3 = x.pr3,
        //                            prPrdId = x.prPrdId,
        //                            prQuantity1 = x.prQuantity1,
        //                            prQuantity2 = x.prQuantity2,
        //                            prQuantity3 = x.prQuantity3,
        //                            prStatus = x.prStatus,
        //                        }).ToList();
        //    var ProductPrice2 = (from x in GetProductPrices
        //                         select new
        //                         {
        //                             prId = x.ID,
        //                             prdBrnId = x.BrnId,
        //                             pr1 =x.pr1,
        //                             pr2 =x.pr2,
        //                             pr3 =x.pr3,
        //                             prPrdId = x.PrdId,
        //                             prQuantity1 = x.Quantity1,
        //                             prQuantity2 = x.Quantity2,
        //                             prQuantity3 = x.Quantity3,
        //                             prStatus = x.Status,
        //                         }).ToList();
        //    var MeasNewOrUpdate = (from n in ProductPrice where !ProductPrice2.Contains(n) select n);
        //    count = MeasNewOrUpdate.Count();
        //    if (count > 0)
        //    foreach (var s in MeasNewOrUpdate) 
        //            Localdb.InsProPriceToPos(s.prId, s.prPrdId, s.pr1, s.pr2, s.pr3, s.prQuantity1, s.prQuantity2, s.prQuantity3, s.prdBrnId, s.prStatus);
        //    ProductPrice2 = (from x in Localdb.ProductPrices
        //                     select new
        //                     {
        //                         prId = x.ID,
        //                         prdBrnId = x.BrnId,
        //                         pr1 = x.pr1,
        //                         pr2 = x.pr2,
        //                         pr3 = x.pr3,
        //                         prPrdId = x.PrdId,
        //                         prQuantity1 = x.Quantity1,
        //                         prQuantity2 = x.Quantity2,
        //                         prQuantity3 = x.Quantity3,
        //                         prStatus = x.Status,
        //                     }).ToList();
        //    var MeasNewOrUpdate2 = (from n in ProductPrice2 where !ProductPrice.Contains(n) select n);
        //    if (MeasNewOrUpdate2.Count() > 0)
        //    {
        //        foreach (var x in MeasNewOrUpdate2)
        //        {
        //            Localdb.ProductPrices.DeleteOnSubmit(Localdb.ProductPrices.FirstOrDefault(y => y.ID == x.prId));
        //            Localdb.SubmitChanges();
        //        }
        //    }
        //    OnProcess?.Invoke("Pull", $"Sync {count} ProductPrices Done{Environment.NewLine}");
        //}
        public async Task PushAsync()
        {
            OnProcess?.Invoke("Push", $"Check server is connected{Environment.NewLine}");
            if (Database.Exists(ConnectionString_AccDB) == false)
            {
                ProcessCompleted?.Invoke("Push", true);
                new Exception("server not connected");
                return;
            }
            OnProcess?.Invoke("Push", $"server is connected{Environment.NewLine}");
            OnProcess?.Invoke("Push", $"Get Local Invoices ,Customer ,Drawer Period And Expired Product{Environment.NewLine}");
            await InitObjectsAsync();
            upDataState = true;
            OnProcess?.Invoke("Push", $"Local Invoices Count:{GetSupplyMain.Count}{Environment.NewLine}");
            await Task.Run(() =>GetSupplyMain.ForEach(x =>SendInvoToServer(x,false)));
            await Task.Run(() => GetExpirateMain.ForEach(x => SendPrdExpirToServer(x, false)));
            await Task.Run(() => GetDrawerPeriod.ForEach(x => SendDrawerPeriodToServer(x, false)));
            await Task.Run(() =>
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                { 
                    GetCustomers = db.Customers.Where(x => x.No == 0).ToList();
                    GetCustomers.ForEach(x =>SendCustomerToServer(x,false));
                    if (GetCustomers.Count() > 0) db.SubmitChanges();
                }
            });
            OnProcess?.Invoke("Push", $"Doun Push {GetSupplyMain?.Count} Invoices{Environment.NewLine}");
            OnProcess?.Invoke("Push", $"Doun Push {GetExpirateMain?.Count} Expired Product{Environment.NewLine}");
            ProcessCompleted?.Invoke("Push", true);
        }
        public UploadDataToMain(SupplyMain supplyMain, IList<SupplySub> supplySubs)
        {
            try
            {
                if (supplyMain.SendToserver) return;
                GetSupplySub = supplySubs.ToList();
                SendInvoToServer(supplyMain);
            }
            catch (Exception)
            {
                return;
            }
        }
        public UploadDataToMain(PrdExpirateMain ExpirateMain, IList<PrdExpirateDetail> ExpirateDetail)
        {
            try
            {
                if (ExpirateMain.SendToserver) return;
                GetExpirateDetail = ExpirateDetail.ToList();
                SendPrdExpirToServer(ExpirateMain);
            }
            catch (Exception)
            {
                return;
            }
        }
        int? CusNo=0;
        long? CusAccNo;
        public void SendInvoToServer(SupplyMain supplyMain,bool ChcikConn=true)
        {
            try
            {
                bool save = false;
                if (ChcikConn) { if (!Database.Exists(ConnectionString_AccDB)) return; }
                using (AccDBDataContext db = new AccDBDataContext(ConnectionString_AccDB))
                {
                    tblSupplyMain tbsupplyMain1 = GetCopyOfCurrentSupplyMain(supplyMain);
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            db.tblSupplyMains.InsertOnSubmit(tbsupplyMain1);
                            if ((supplyMain?.CustId ?? 0) > 0)
                            {
                                Customer customer = supplyMain.CustId != null ? Session.Customers?.FirstOrDefault(x => x.ID == supplyMain.CustId) : null;
                                if (customer != null)
                                    tbsupplyMain1.supCustSplId = db.tblCustomers.AsNoTracking()?.FirstOrDefault(x => x.custNo == customer.No)?.id;
                            }
                            db.SubmitChanges();
                            db.tblSupplySubs.InsertAllOnSubmit(GetCopyOfCurrentSupplySub(supplyMain, tbsupplyMain1.id));
                            db.SubmitChanges();
                           
                            transaction.Complete();
                            save = true;
                        }
                        catch (Exception ex)
                        {
                            ClsXtraMssgBox.ShowError(ex.Message);
                            return;// 
                        }
                    }
                    //SupNo = supplyMain.No;
                    //Customer customer = supplyMain.CustId != null ? Session.Customers?.FirstOrDefault(x => x.ID == supplyMain.CustId) : null;
                    //db.AddInvoiceDataToAccFromPos(ref SupNo, ref SupAccNo,"", supplyMain.RefNo, supplyMain.Desc,supplyMain.Total,(supplyMain.TotalFrgn),
                    //    supplyMain.TaxPercent, supplyMain.TaxPrice, supplyMain.Currency, supplyMain.DscntPercent, supplyMain.DscntAmount, supplyMain.BankId
                    //    , (supplyMain.BankAmount), supplyMain.CurrencyChng, customer?.No, supplyMain.Date, supplyMain.IsCash
                    //    , (supplyMain.IsCash == 2) ? (byte)1 : (byte)2, supplyMain.StrId, supplyMain.UserId, supplyMain.BrnId, supplyMain.Status,0,
                    //    supplyMain.CarType, supplyMain.PlateNumber, supplyMain.CounterNumber, true, supplyMain.IsDelete, supplyMain.paidCash,
                    //    supplyMain.Remin, supplyMain.BoxId, supplyMain.PoNumber, supplyMain.Notes, supplyMain.DueDate, supplyMain.EnterDate
                    //    );

                        //db.tblSupplySubs.InsertAllOnSubmit(GetCopyOfCurrentSupplySub(supplyMain, SupNo.GetValueOrDefault()));
                        //db.SubmitChanges();
                        //UpdateSendToServerForCurInvo(supplyMain);
                }
                if (save)
                    UpdateSendToServerForCurInvo(supplyMain);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void SendPrdExpirToServer(PrdExpirateMain PrdExpirateMain, bool ChcikConn = true)
        {
            try
            {
                bool save = false;
                if (ChcikConn) { if (!Database.Exists(ConnectionString_AccDB)) return; }
                using (AccDBDataContext db = new AccDBDataContext(ConnectionString_AccDB))
                {
                    tblPrdexpirateQuanMain tbPrdExpirateMain1 = GetCopyOfCurrentPrdExpirateMain(PrdExpirateMain);
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            db.tblPrdexpirateQuanMains.InsertOnSubmit(tbPrdExpirateMain1);
                            db.SubmitChanges();
                            db.tblPrdExpirateQuans.InsertAllOnSubmit(GetCopyOfCurrentPrdExpirateDetail(PrdExpirateMain, tbPrdExpirateMain1.expMainId));
                            db.SubmitChanges();

                            transaction.Complete();
                            save = true;
                        }
                        catch (Exception ex)
                        {
                            ClsXtraMssgBox.ShowError(ex.Message);
                            return;// 
                        }
                    }
                }
                if (save)
                    UpdateSendToServerForCurExpPrd(PrdExpirateMain);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void SendDrawerPeriodToServer(DrawerPeriod DrawerPeriod, bool ChcikConn = true)
        {
            try
            {
                if (ChcikConn) { if (!Database.Exists(ConnectionString_AccDB)) return; }
                using (AccDBDataContext db = new AccDBDataContext(ConnectionString_AccDB))
                {
                    AccDrawerPeriod AccDrawerPeriod = new MyFunaction().GetCopyOfCurrentDrawerPeriod(DrawerPeriod);
                    db.AccDrawerPeriods.InsertOnSubmit(AccDrawerPeriod);
                    db.SubmitChanges();
                    UpdateSendToServerForCurDrawerPeriod(DrawerPeriod);
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
            }
        }
        public void UpdateSendToServerForCurInvo(SupplyMain supplyMain)
        {
            using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
            {
                var temp = db.SupplyMains?.FirstOrDefault(x => x.ID == supplyMain.ID);
                if (temp != null) temp.SendToserver = true;
                db.SubmitChanges();
            }
        }
        public void UpdateSendToServerForCurExpPrd(PrdExpirateMain PrdExpirateMain)
        {
            using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
            {
                var temp = db.PrdExpirateMains?.FirstOrDefault(x => x.ID == PrdExpirateMain.ID);
                if (temp != null) temp.SendToserver = true;
                db.SubmitChanges();
            }
        }
        public void UpdateSendToServerForCurDrawerPeriod(DrawerPeriod DrawerPeriod)
        {
            using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
            {
                var temp = db.DrawerPeriods?.FirstOrDefault(x => x.ID == DrawerPeriod.ID);
                if (temp != null) temp.SendToserver = true;
                db.SubmitChanges();
            }
        }
        public void SendCustomerToServer(Customer customer,bool ChcikConn=true)
        {
            try
            {
                CusNo = 0;
                if (ChcikConn) { if (!Database.Exists(ConnectionString_AccDB)) return; }
                using (AccDBDataContext db = new AccDBDataContext(ConnectionString_AccDB))
                {
                        db.AddCustDataToAccFromPos(ref CusNo, ref CusAccNo, customer.ID, customer.Name, customer.PhnNo, customer.Country, customer.City, customer.Address
                           , customer.Email, customer.CellingCredit, customer.Currency, customer.SalePrice, customer.TaxNo, customer.BrnId, customer.Status
                           , customer.NameEn, customer.CountryEn, customer.CityEn, customer.AddressEn, customer.CommercialRegister, customer.PostalCode,
                           customer.BankId, customer.AddNo, customer.BuildingNo, customer.AnotherID, customer.District, customer.DistrictEn);
                        customer.No = CusNo.GetValueOrDefault();
                        customer.AccNo = CusAccNo.GetValueOrDefault();
                        //UpdateSendToServerForCurCustomer(customer);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => 
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    this.GetSupplyMain = db.SupplyMains.AsNoTracking().Where(s => (s.Status == 11 || s.Status == 4) && s.BrnId == BranchID && !s.SendToserver).ToList();
            }));
            taskList.Add(Task.Run(() => 
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    this.GetSupplySub = (from m in db.SupplyMains.AsNoTracking()
                                         join d in db.SupplySubs.AsNoTracking() on m.ID equals d.ParentID
                                         where (m.Status == 11 || m.Status == 4) && m.BrnId == BranchID && !m.SendToserver
                                         select d).ToList();
            }));
            taskList.Add(Task.Run(() => 
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    this.GetExpirateMain = db.PrdExpirateMains.AsNoTracking().Where(s =>s.BranchID == BranchID && !s.SendToserver).ToList();
            }));
            taskList.Add(Task.Run(() => 
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    this.GetExpirateDetail = (from m in db.PrdExpirateMains.AsNoTracking() join d in db.PrdExpirateDetails.AsNoTracking() on m.ID equals d.ParentID where m.BranchID == BranchID && !m.SendToserver select d).ToList();
            }));
            taskList.Add(Task.Run(() =>
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    this.GetDrawerPeriod = db.DrawerPeriods.AsNoTracking().Where(s =>!s.SendToserver&&s.Status==true).ToList();
            }));
            await Task.WhenAll(taskList);
        }

        string ConnectionString_AccDB =>new MyFunaction().ConnectionString_AccDB();
        public tblSupplyMain GetCopyOfCurrentSupplyMain(SupplyMain supplyMain)
        {
            //GetAccNameAndNo(supplyMain);
            return new tblSupplyMain()
            {
                supNo = supplyMain.No,
                supDate = supplyMain.Date,
                supAccName = supplyMain.IsCash==1? Session.Boxes?.FirstOrDefault(x => x.ID == supplyMain.BoxId)?.Name: Session.Customers?.FirstOrDefault(x => x.ID == supplyMain.CustId)?.Name,
                supAccNo = supplyMain.IsCash == 1 ? Session.Boxes?.FirstOrDefault(x => x.ID == supplyMain.BoxId)?.AccNo : Session.Customers?.FirstOrDefault(x => x.ID == supplyMain.CustId)?.AccNo,
                supBankAmount =Convert.ToDouble(supplyMain.BankAmount),
                supBankId = supplyMain.BankId,
                supBoxId = supplyMain.BoxId,
                supBrnId = supplyMain.BrnId,
                supCurrency = supplyMain.Currency,
                supCurrencyChng = supplyMain.CurrencyChng,
                supCustSplId = supplyMain.CustId,
                supDesc = supplyMain.Desc,
                supDscntAmount = Convert.ToDouble(supplyMain.DscntAmount),
                supDscntPercent = supplyMain.DscntPercent,
                supEqfal = (supplyMain.IsCash == 2) ? (byte)1: (byte)2,
                supIsCash = (supplyMain.IsCash == 2) ? (byte)2 : (byte)1,
                supRefNo = supplyMain.RefNo,
                supStatus = supplyMain.Status,
                supStrId = supplyMain.StrId,
                supTaxPercent = supplyMain.TaxPercent,
                supTaxPrice = Convert.ToDouble(supplyMain.TaxPrice),
                supTotal = Convert.ToDouble(supplyMain.Total),
                supTotalFrgn = Convert.ToDouble(supplyMain.TotalFrgn),
                supUserId = supplyMain.UserId,
                SendToserver = true,
                CarType = supplyMain.CarType,
                CounterNumber = supplyMain.CounterNumber,
                DueDate = supplyMain.DueDate,
                EnterDate = supplyMain.EnterDate,
                IsDelete = supplyMain.IsDelete,
                Notes = supplyMain.Notes,
                paidCash = supplyMain.paidCash,
                PlateNumber = supplyMain.PlateNumber,
                PoNumber = supplyMain.PoNumber,
                remin = supplyMain.Remin,
                net=supplyMain.Net,
                TotalAfterDiscount=supplyMain.TotalAfterDiscount,
            };
        }
        public tblPrdexpirateQuanMain GetCopyOfCurrentPrdExpirateMain(PrdExpirateMain PrdExpirateMain)
        {
            return new tblPrdexpirateQuanMain()
            {
                expMainBrnId = PrdExpirateMain.BranchID,
                expMainDate= PrdExpirateMain.Date,
                expMainStrid= PrdExpirateMain.StorID,
                expMainUserId= PrdExpirateMain.UserID,
            };
        }
       
        public List<tblSupplySub> GetCopyOfCurrentSupplySub(SupplyMain supplyMain, int AccMainId)
        {
            return (from SupplySub in GetSupplySub.Where(x=>x.ParentID== supplyMain.ID)
                    join p in Session.Products on SupplySub.PrdId equals p.ID
                    join M in Session.PrdMeasurments on SupplySub.Msur equals M.ID
                    join G in Session.GroupStrs on p.GrpNo equals G.ID
                    select new tblSupplySub
                    {
                        supNo = AccMainId,
                        supDate = SupplySub.Date,
                        supBrnId = SupplySub.BrnId,
                        supUserId = SupplySub.UserId,
                        supStatus = SupplySub.Status,
                        supAccNo = G.AccNo,
                        supAccName =G.Name,
                        supDesc = SupplySub.Desc,
                        supPrdBarcode = SupplySub.PrdBarcode,
                        supPrdNo = p.No,
                        supPrdName = p.Name,
                        supPrdId = SupplySub.PrdId,
                        supMsur = SupplySub.Msur,
                        supPrdManufacture = SupplySub.PrdManufacture,
                        supCurrency = SupplySub.Currency,
                        supQuanMain = SupplySub.QuanMain,
                        supPrice = (SupplySub.BuyPrice),
                        supSalePrice =(SupplySub.SalePrice),
                        supTaxPercent = Convert.ToByte(SupplySub.TaxPercent),
                        supTaxPrice = (SupplySub.TaxPrice),
                        supDscntPercent = SupplySub.DscntPercent,
                        supDebit = SupplySub.Status ==11 || SupplySub.Status ==12? Convert.ToDouble((SupplySub.QuanMain * SupplySub.SalePrice) + (SupplySub.QuanMain * SupplySub.SalePrice * SupplySub.TaxPercent / (double)100)) : 0,
                        supCredit = SupplySub.Status==4 || SupplySub.Status == 8?  Convert.ToDouble((SupplySub.QuanMain* SupplySub.SalePrice)+(SupplySub.QuanMain * SupplySub.SalePrice* SupplySub.TaxPercent/(double)100)):0,
                        //supDebitFrgn = SupplySub.TotalFrgn,
                        //supCreditFrgn = SupplySub.CreditFrgn,
                        supDscntAmount = Convert.ToDouble(SupplySub.DscntAmount),
                        subHeight = Convert.ToDouble(SupplySub.Height),
                        subQteMeter = Convert.ToDouble(SupplySub.QteMeter),
                        subWidth = Convert.ToDouble(SupplySub.Width),
                        subNoPacks = SupplySub.NoPacks,
                        supOvertime = SupplySub.Overtime,
                        supWorkingtime = SupplySub.Workingtime,
                        StoreID= supplyMain.StrId,
                        Conversion=Session.PrdMeasurments?.FirstOrDefault(x=>x.ID== SupplySub.Msur)?.Conversion??1,
                    }).ToList();
        }
        public List<tblPrdExpirateQuan> GetCopyOfCurrentPrdExpirateDetail(PrdExpirateMain PrdExpirateMain, int AccMainId)
        {
            return (from PrdExpirateDetail in GetExpirateDetail.Where(x => x.ParentID == PrdExpirateMain.ID)
                    select new tblPrdExpirateQuan
                    {
                    expBrnId= PrdExpirateDetail.BranchID,
                    expPrdDate= PrdExpirateDetail.ExpDate,
                    expDate= PrdExpirateDetail.Date,
                    expId= PrdExpirateDetail.ID,
                    expMainId= AccMainId,
                    expPrdId= PrdExpirateDetail.ProductID,
                    expPrdMsurId= PrdExpirateDetail.MsurID,
                    expPrdMsurStatus=0,
                    expPrdPrice= PrdExpirateDetail.Price,
                    expPrdPriceQuanId=0,
                    expQuan= PrdExpirateDetail.Quantity,
                    expStatus=0,
                    expStrid= PrdExpirateDetail.StoreID
                    }).ToList();
        }
    }
}
