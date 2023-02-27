using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PosFinalCost.Classe;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosFinalCost.Session;

namespace PosFinalCost
{
    static class Session
    {
        public static UserTbl CurrentUser;

        public static List<GetColumnForTableResult> ColNameForTable = new List<GetColumnForTableResult>();
        public static void GetColNameForTable(string tableName)
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    ColNameForTable = db.GetColumnForTable(tableName).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public static int MaxNoInv { get; set; }
        public static void GetMaxNoInv(PosDBDataContext db = null)
        {
            try
            {
             
                if (Program.My_Setting.SendInvoToServerOnSave)
                {
                    string ConnectionString_AccDB = new MyFunaction().ConnectionString_AccDB();
                    if (Database.Exists(ConnectionString_AccDB))
                    {
                        using (var Accdb = new AccDBDataContext(ConnectionString_AccDB))
                        {
                            MaxNoInv = ((Accdb.tblSupplyMains.Where(x => x.supBrnId == CurrentBranch.ID &&
                                    x.supDate.Value >= CurrentYear.DateStart.Date //&& x.supDate.Value <= CurrentYear.DateEnd.Date
                                    && (x.supStatus == 4 || x.supStatus == 8))?.Max(x => x.supNo))??0) + 1;
                            return;
                        }
                    }
                }
                if (db == null)
                {
                    using (db = new PosDBDataContext(Program.ConnectionString))
                    {
                        var list = db.SupplyMains.Where(x => x.Date >= CurrentYear.DateStart/* && x.Date <= CurrentYear.DateEnd*/ && x.BrnId == CurrentBranch.ID && (x.Status == 4 || x.Status == 8));
                        MaxNoInv = list.Count() > 0 ? list.Max(x => x.No) + 1 : 1;
                    }
                }
                else
                {
                    var list = db.SupplyMains.Where(x => x.Date >= CurrentYear.DateStart /*&& x.Date <= CurrentYear.DateEnd*/ && x.BrnId == CurrentBranch.ID && (x.Status == 4 || x.Status == 8));
                    MaxNoInv = list.Count() > 0 ? list.Max(x => x.No) + 1 : 1;
                }
            }
            catch (Exception ex)
            {
                using (db = new PosDBDataContext(Program.ConnectionString))
                {
                    var list = db.SupplyMains.Where(x => x.Date >= CurrentYear.DateStart/* && x.Date <= CurrentYear.DateEnd*/ && x.BrnId == CurrentBranch.ID && (x.Status == 4 || x.Status == 8));
                    MaxNoInv = list.Count() > 0 ? list.Max(x => x.No) + 1 : 1;
                }
                XtraMessageBox.Show(ex.Message);
                return;
            }
        }
        public static Currency LocalCurrency => Currencies.FirstOrDefault(x => x.Type == 1);
        public static void RefreshAllDataForPermission(PosDBDataContext db = null)
        {
            try
            {
                if (db == null)
                {
                    using (db = new PosDBDataContext(Program.ConnectionString))
                    {
                        RoleControlTbls = db.RoleControlTbls.AsNoTracking().ToList();
                        RoleTbls = db.RoleTbls.AsNoTracking().ToList();
                    }
                }
                else
                {
                    RoleControlTbls = db.RoleControlTbls.AsNoTracking().ToList();
                    RoleTbls = db.RoleTbls.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static Branch CurrentBranch;
        public static FinancialYear CurrentYear;
        public static UserSettingsProfile CurrSettings;
        public static List<ControlTbl> ControlTbls = new List<ControlTbl>();
        public static void GetDataControlTbls()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    ControlTbls = db.ControlTbls.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<ControlData> ControlDatas = new List<ControlData>();
        public static void GetDataControlDatas()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    ControlDatas = db.ControlDatas.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<UserControlTbl> UserControlTbls = new List<UserControlTbl>();
        public static void GetDataUserControlTbls()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    UserControlTbls = db.UserControlTbls.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<UserTbl> UserTbls = new List<UserTbl>();
        public static void GetDataUserTbls(PosDBDataContext db = null)
        {
            try
            {
                if (db == null)
                {
                    using (db = new PosDBDataContext(Program.ConnectionString))
                        UserTbls = db.UserTbls.AsNoTracking().ToList();
                }
                else
                    UserTbls = db.UserTbls.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<RoleControlTbl> RoleControlTbls = new List<RoleControlTbl>();
        public static void GetDataRoleControlTbls()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    RoleControlTbls = db.RoleControlTbls.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<RoleTbl> RoleTbls = new List<RoleTbl>();
        public static void GetDataRoleTbls()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    RoleTbls = db.RoleTbls.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }


        public static List<Branch> Branches = new List<Branch>();
        public static void GetDataBranches()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    if (db.Branches.Count() == 0)
                        db.ExecuteCommand($"INSERT INTO [dbo].[Branch] ([No],[Name])VALUES({1},'{"الرئيسي"}')");
                    Branches = db.Branches.AsNoTracking().ToList();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<Currency> Currencies = new List<Currency>();
        public static void GetDataCurrencies()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Currencies = db.Currencies.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<Country> Countries = new List<Country>();
        public static void GetDataCountries()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Countries = db.Countries.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<Bank> Banks = new List<Bank>();
        public static void GetDataBanks()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Banks = db.Banks.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public class BuyPrices
        {
            public int supMsur { get; set; }
            public int supPrdId { get; set; }
            public double supPrice { get; set; }
            public DateTime supDate { get; set; }
        }
        public static List<BuyPrices> buyPrices = new List<BuyPrices>();

        public static void GetDataBuyPrices()
        {
            try
            {
                MyFunaction myFunaction = new MyFunaction();
                if (Database.Exists(myFunaction.ConnectionString_AccDB()))
                {
                    using (var temp = new AccDBDataContext(myFunaction.ConnectionString_AccDB()))
                    {
                        var p = temp.tblSupplySubs.AsNoTracking().Where(x => x.supBrnId == CurrentBranch.ID &&x.supDate >= CurrentYear.DateStart && (x.supStatus == 3 || x.supStatus == 7)).ToList();
                       if(p.Count>0)
                        {
                            buyPrices = (from price in p select new BuyPrices
                                         {
                                             supDate = price.supDate,
                                             supMsur = price.supMsur.GetValueOrDefault(),
                                             supPrice = price.supPrice.GetValueOrDefault(),
                                             supPrdId = price.supPrdId.GetValueOrDefault(),
                                         }).ToList();
                        }
                         
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public static List<Box> Boxes = new List<Box>();
        public static void GetDataBoxes()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Boxes = db.Boxes.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        //public static List<DefaultAccount> DefaultAccounts = new List<DefaultAccount>();
        //public static void GetDataDefaultAccounts()
        //{
        //    using (var db = new PosDBDataContext(Program.ConnectionString))
        //        DefaultAccounts = db.DefaultAccounts.Where(x => x.BrnId == CurrentBranch.ID).ToList();
        //}
        public static List<FinancialYear> FinancialYears = new List<FinancialYear>();
        public static void GetDataFinancialYears()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    //if (db.FinancialYears.Count() == 0)
                    //    db.ExecuteCommand($"INSERT INTO [dbo].[FinancialYear] ([Name],[DateStart],[DateEnd],[BrnId]) VALUES (YEAR(GETDATE()),N'{DateTime.Now.Date}',N'{DateTime.Now.Date}',{db.Branches?.FirstOrDefault()?.ID})");
                    FinancialYears = db.FinancialYears.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<Customer> Customers = new List<Customer>();
        public static void GetDataCustomers()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Customers = db.Customers.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<GroupStr> GroupStrs = new List<GroupStr>();
        public static void GetDataGroupStrs()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    //GroupStrs = db.GroupStrs.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
                      GroupStrs = (from s in db.StoreTbls.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID)
                                   join q in db.ProductQunatities.AsNoTracking() on s.ID equals q.StrId
                                   join p in db.Products.AsNoTracking() on q.prdId equals p.ID
                                   join g in db.GroupStrs.AsNoTracking() on p.GrpNo equals g.ID
                                   select g).Distinct().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<StoreTbl> Stores = new List<StoreTbl>();
        public static void GetDataStores()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Stores = db.StoreTbls.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<Product> Products = new List<Product>();
        public static void GetDataProducts()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    //Products = db.Products.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID).ToList();
                    Products = (from p in db.Products.AsNoTracking()
                                join q in db.ProductQunatities.AsNoTracking() on p.ID equals q.prdId
                                join s in db.StoreTbls.AsNoTracking() on q.StrId equals s.ID
                                where s.BrnId == CurrentBranch.ID &&!p.Suspended
                                select p).Distinct().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<ProductColor> ProductColors = new List<ProductColor>();
        public static void GetDataProductColors()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    ProductColors = db.ProductColors.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<UserSettingsProfile> UserSettingsProfile = new List<UserSettingsProfile>();
        public static void GetDataUserSettingsProfile(PosDBDataContext db = null)
        {
            try
            {
                if (db == null)
                {
                    using (db = new PosDBDataContext(Program.ConnectionString))
                        UserSettingsProfile = db.UserSettingsProfiles.AsNoTracking().ToList();
                }
                else UserSettingsProfile = db.UserSettingsProfiles.AsNoTracking().ToList();
                RefreshCurrSettings();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public static void RefreshCurrSettings()
        {
            try
            {
                if (CurrentUser?.ID == 1|| CurrentUser?.UsSettProfID==null)
                    CurrSettings = UserSettingsProfile?.FirstOrDefault();
                else
                    CurrSettings = UserSettingsProfile?.FirstOrDefault(x => x.ID == CurrentUser?.UsSettProfID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<DrawerPeriod> DrawerPeriod = new List<DrawerPeriod>();
        public static void GetDataBoxPeriods()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    DrawerPeriod = db.DrawerPeriods.AsNoTracking().Where(x => x.BranchID == CurrentBranch.ID).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public static List<PrdManufacture> PrdManufactures = new List<PrdManufacture>();
        public static void GetDataPrdManufacture()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    PrdManufactures = db.PrdManufactures.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }

        public static List<ProductQunatity> ProductQunatities = new List<ProductQunatity>();
        public static void GetDataProductQunatities()
        {
            try
            {
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                    ProductQunatities = (from p in db.Products.AsNoTracking()
                                         join q in db.ProductQunatities.AsNoTracking() on p.ID equals q.prdId
                                         join s in db.StoreTbls.AsNoTracking() on q.StrId equals s.ID
                                         where s.BrnId == CurrentBranch.ID && !p.Suspended
                                         select q).Distinct().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
        }
      
        public static List<PrdMeasurment> PrdMeasurments = new List<PrdMeasurment>();
        public static void GetDataPrdMeasurments()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    //PrdMeasurments = db.PrdMeasurments.AsNoTracking().ToList();
                    PrdMeasurments = (from p in db.Products.AsNoTracking()
                                      join m in db.PrdMeasurments.AsNoTracking() on p.ID equals m.PrdId
                                      join q in db.ProductQunatities.AsNoTracking() on p.ID equals q.prdId
                                      join s in db.StoreTbls.AsNoTracking() on q.StrId equals s.ID
                                      where s.BrnId == CurrentBranch.ID && !p.Suspended
                                      select m).Distinct().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
        }
       
        //public static List<ProductPrice> ProductPrices = new List<ProductPrice>();
        //public static void GetDataProductPrices()
        //{
        //    try
        //    {
        //        using (var db = new PosDBDataContext(Program.ConnectionString))
        //            ProductPrices = db.ProductPrices.AsNoTracking().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message);
        //        return;
        //    }

        //}

        public static List<Barcode> Barcodes = new List<Barcode>();
        public static void GetDataBarcodes()
        {
            try
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    Barcodes = (from p in db.Products.AsNoTracking()
                                join m in db.PrdMeasurments.AsNoTracking() on p.ID equals m.PrdId
                                join b in db.Barcodes.AsNoTracking() on m.ID equals b.MsurId
                                join q in db.ProductQunatities.AsNoTracking() on p.ID equals q.prdId
                                join s in db.StoreTbls.AsNoTracking() on q.StrId equals s.ID
                                where s.BrnId == CurrentBranch.ID && !p.Suspended
                                select b).Distinct().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
