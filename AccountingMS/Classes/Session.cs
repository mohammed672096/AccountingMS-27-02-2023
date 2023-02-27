using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS
{
    static class Session
    {
        public static tblUser CurrentUser;
        public static short RoleId;
        public static List<tblAccount> Accounts = new List<tblAccount>();
        public static void GetDataAccounts(accountingEntities db = null)
        {
            if (db == null)
            {
                using (db = new accountingEntities())
                    Accounts = db.tblAccounts.AsNoTracking().ToList();
            }
            else
                Accounts = db.tblAccounts.AsNoTracking().ToList();
        }
        public static void AddClearButton(this PopupBaseEdit edit)
        {
            edit.Properties.Buttons.Clear();
            edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.DropDown), new EditorButton(ButtonPredefines.Clear) });
            edit.ButtonClick += (sender, e) =>
            {
                if (e.Button.GetType() != typeof(EditorButton))
                    return;
                if (e.Button.Kind == ButtonPredefines.Clear)
                {
                    ((BaseEdit)sender).EditValue = null;
                }
            };
        }
        public static int MaxNoSaleInv { get; set; }
        public static int MaxNoBuyInv { get; set; }
        public static int MaxNoBuyInvRetr { get; set; }
        public static void GetMaxNoInv(accountingEntities db = null, byte supplyType1 = 4,byte supplyType2=8)
        {
            int supplyMain;
            if (db == null)
                using (db = new accountingEntities())
                    supplyMain = (db.tblSupplyMains.AsNoTracking().Where(x => x.supDate >= CurrentYear.fyDateStart && x.supBrnId == CurBranch.brnId 
                    && (x.supStatus == supplyType1 || x.supStatus == supplyType2)).AsEnumerable()?.Max(x => x?.supNo)).GetValueOrDefault() + 1;
            else
                supplyMain = (db.tblSupplyMains.AsNoTracking().Where(x => x.supDate >= CurrentYear.fyDateStart && x.supBrnId == CurBranch.brnId 
                     && (x.supStatus == supplyType1 || x.supStatus == supplyType2)).AsEnumerable()?.Max(x => x?.supNo)).GetValueOrDefault() + 1;
            switch ((SupplyType)supplyType1)
            {
                case SupplyType.Purchase:
                    MaxNoBuyInv = supplyMain;
                    break;
                case SupplyType.PurchaseRtrn:
                    MaxNoBuyInvRetr = supplyMain;
                    break;
                case SupplyType.Sales:
                    MaxNoSaleInv = supplyMain;
                    break;
            }
        }
        public static void GetMaxNoInv()
        {
            using (accountingEntities db = new accountingEntities())
            {
                MaxNoBuyInv = (db.tblSupplyMains.Where(x => x.supDate >= CurrentYear.fyDateStart && x.supBrnId == CurBranch.brnId
                  && (x.supStatus == 3 || x.supStatus == 7)).AsEnumerable()?.Max(x => x?.supNo)).GetValueOrDefault() + 1;

                MaxNoBuyInvRetr = (db.tblSupplyMains.Where(x => x.supDate >= CurrentYear.fyDateStart && x.supBrnId == CurBranch.brnId
                 && (x.supStatus ==9 || x.supStatus == 10)).AsEnumerable()?.Max(x => x?.supNo)).GetValueOrDefault() + 1;

                MaxNoSaleInv = (db.tblSupplyMains.Where(x => x.supDate >= CurrentYear.fyDateStart && x.supBrnId == CurBranch.brnId
                 && (x.supStatus == 4 || x.supStatus == 8)).AsEnumerable()?.Max(x => x?.supNo)).GetValueOrDefault() + 1;
            }
        }
        public static void BindToDataSource(this LookUpEdit edit, object dataSource, string IdColumnName = "ID", string DisplayColumnName = "Name")
        {
            BindToDataSource(edit.Properties, dataSource, IdColumnName, DisplayColumnName);
        }

        public static void BindToDataSource(this RepositoryItemLookUpEdit edit, object dataSource, string IdColumnName = "ID", string DisplayColumnName = "Name")
        {
            edit.DataSource = dataSource;
            edit.ValueMember = IdColumnName;
            edit.DisplayMember = DisplayColumnName;
            edit.Columns.Clear();
            edit.Columns.Add(new LookUpColumnInfo(IdColumnName));
            edit.Columns.Add(new LookUpColumnInfo(DisplayColumnName));
            edit.BestFitMode = BestFitMode.BestFitResizePopup;
            edit.ShowHeader = false;
            edit.NullText = "";
        }
        public static List<tblSupplier> Suppliers = new List<tblSupplier>();
        public static void GetDataSuppliers()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (Session.CurrentUser.id == 1) Suppliers = db.tblSuppliers.AsNoTracking().ToList();
                else Suppliers = (from a in db.tblSuppliers.AsNoTracking() where a.splBrnId == Session.CurBranch.brnId select a).ToList();
            }
        }

        public static void RefreshAllDataForPermission(accountingEntities db = null)
        {
            //if (db == null)
            //{
            //    using (db = new accountingEntities())
            //    {
            //        RoleControlTbls = db.RoleControlTbls.AsNoTracking().ToList();
            //        RoleTbls = db.RoleTbls.AsNoTracking().ToList();
            //    }
            //}
            //else
            //{
            //    RoleControlTbls = db.RoleControlTbls.AsNoTracking().ToList();
            //    RoleTbls = db.RoleTbls.AsNoTracking().ToList();
            //}
        }
        public static tblCurrency LocalCurrency()
        {
            if (Currencies == null || Currencies.Count() == 0)
                GetDataCurrencies();
            return Currencies?.FirstOrDefault(x => x.curType == 1);
        }
        public static List<tblCustomerInvoice> tbCustomerInvoiceList = new List<tblCustomerInvoice>();
        public static void GetDatatblCustomerInvoice()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tbCustomerInvoiceList = db.tblCustomerInvoices.AsNoTracking().ToList();
                else tbCustomerInvoiceList = db.tblCustomerInvoices.AsNoTracking().Where(x => x.invBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblSupplierInvoice> tbSupplierInvoiceList = new List<tblSupplierInvoice>();
        public static void GetDatatblSupplierInvoice()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tbSupplierInvoiceList = db.tblSupplierInvoices.AsNoTracking().ToList();
                else tbSupplierInvoiceList = db.tblSupplierInvoices.AsNoTracking().Where(x => x.invBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblDscntPermission> tbDscntPermissionList = new List<tblDscntPermission>();
        public static void GetDatatblDscntPermission()
        {
            using (var db = new accountingEntities())
                tbDscntPermissionList = db.tblDscntPermissions.AsNoTracking().ToList();
        }

        public static tblBranch CurBranch;
        public static tblFinancialYear CurrentYear;

        public static List<tblControl> tblControl = new List<tblControl>();
        public static void GetDataControlTbls()
        {
            using (var db = new accountingEntities())
                tblControl = db.tblControls.AsNoTracking().ToList();
        }

        public static List<tblUserControl> UserControls = new List<tblUserControl>();
        public static void GetDataUserControlTbls()
        {
            using (var db = new accountingEntities())
                UserControls = db.tblUserControls.AsNoTracking().ToList();
        }
        public static List<tblBranch> Branches = new List<tblBranch>();
        public static void GetDataBranches()
        {
            using (var db = new accountingEntities())
                Branches = db.tblBranches.AsNoTracking().ToList();
            if (CurBranch != null)
                CurBranch = Branches.FirstOrDefault(x => x.brnId == CurBranch.brnId);
        }
        public static List<tblUser> tblUser = new List<tblUser>();
        public static void GetDataUserTbls(accountingEntities db = null)
        {
            if (db == null)
            {
                using (db = new accountingEntities())
                    tblUser = db.tblUsers.AsNoTracking().ToList();
            }
            else
                tblUser = db.tblUsers.AsNoTracking().ToList();
        }
        public static List<tblGroupStr> tblGroupStr = new List<tblGroupStr>();
        public static void GetDataGroupStr()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblGroupStr = db.tblGroupStrs.AsNoTracking().ToList();
                else
                    tblGroupStr = (from s in db.tblStores.AsNoTracking().Where(x => x.strBrnId == CurBranch.brnId)
                                   join q in db.tblProductQunatities.AsNoTracking() on s.id equals q.prdStrId
                                   join p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended) on q.prdId equals p.id
                                   join g in db.tblGroupStrs.AsNoTracking() on p.prdGrpNo equals g.id
                                   select g).Distinct().ToList();
            }
        }
        public static List<tblStore> tblStore = new List<tblStore>();
        public static void GetDataStore()
        {
            using (accountingEntities db = new accountingEntities())
            {
                //if (CurrentUser.id == 1)
                    tblStore = db.tblStores.AsNoTracking().ToList();
                //else tblStore = db.tblStores.AsNoTracking().Where(x => x.strBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblProductQtyOpn> tblProductQtyOpn = new List<tblProductQtyOpn>();
        public static void GetDataProductQtyOpn()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblProductQtyOpn = db.tblProductQtyOpns.AsNoTracking().ToList();
                else tblProductQtyOpn = db.tblProductQtyOpns.AsNoTracking().Where(x => x.qtyBranchId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblInvStoreSub> tblInvStoreSub = new List<tblInvStoreSub>();
        public static void GetDataInvStoreSub()
        {
            using (accountingEntities db = new accountingEntities())
                tblInvStoreSub = db.tblInvStoreSubs.AsNoTracking().ToList();
        }
        public static List<tblInvStoreMain> tblInvStoreMain = new List<tblInvStoreMain>();
        public static void GetDataInvStoreMain()
        {
            using (accountingEntities db = new accountingEntities())
                    tblInvStoreMain = db.tblInvStoreMains.AsNoTracking().ToList();
        }
        public static List<tblSupplySub> tblSupplySub = new List<tblSupplySub>();
        public static void GetDataSupplySub()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblSupplySub = db.tblSupplySubs.AsNoTracking().Where(x => x.supStatus <= 12).ToList();
                else tblSupplySub = db.tblSupplySubs.AsNoTracking().Where(x => x.supStatus <= 12&&x.supBrnId== CurBranch.brnId).ToList();
            }
        }
        public static List<tblStockTransMain> tblStockTransMain = new List<tblStockTransMain>();
        public static void GetDataStockTransMain()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblStockTransMain = db.tblStockTransMains.AsNoTracking().ToList();
                else tblStockTransMain = db.tblStockTransMains.AsNoTracking().Where(x => x.stcBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblStockTransSub> tblStockTransSub = new List<tblStockTransSub>();
        public static void GetDataStockTransSub()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblStockTransSub = db.tblStockTransSubs.AsNoTracking().ToList();
                else tblStockTransSub = db.tblStockTransSubs.AsNoTracking().Where(x => x.stcBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblPrdExpirateQuan> tblPrdExpirateQuan = new List<tblPrdExpirateQuan>();
        public static void GetDataPrdExpirateQuan()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblPrdExpirateQuan = db.tblPrdExpirateQuans.AsNoTracking().ToList();
                else tblPrdExpirateQuan = db.tblPrdExpirateQuans.AsNoTracking().Where(x => x.expBrnId == CurBranch.brnId).ToList();
            }
        }
        public static void IntializeData(this LookUpEdit lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "Name", "ID");
        }

        public static object GetTablName(object dataSource)
        {

            var listType = dataSource.GetType().GenericTypeArguments;
            if (listType.Any(x => x.Name == "tblBranch"))
            {
                Tablname = "الفرع";
                return ((List<tblBranch>)dataSource).Select(x => new { ID = x.brnId, Name = x.brnNo + " - " + x.brnName }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblUser"))
            {
                Tablname = "المستخدم";
                return ((List<tblUser>)dataSource).Select(x => new { ID = x.id, Name = x.userName }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblStore"))
            {
                Tablname = "المخزن";
                return ((List<tblStore>)dataSource).Select(x => new { ID = x.id, Name = x.strNo + " - " + x.strName }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblAccountBank"))
            {
                Tablname = "البنك";
                return ((List<tblAccountBank>)dataSource).Select(x => new { ID = x.id, x.bankAccNo, Name = x.bankNo + " - " + x.bankName, Currencie = x.bankCurrency }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblAccountBox"))
            {
                Tablname = "الصندوق";
                return ((List<tblAccountBox>)dataSource).Select(x => new { ID = x.id, x.boxAccNo, Name = x.boxNo + " - " + x.boxName, Currencie = x.boxCurrency }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblCustomer"))
            {
                Tablname = "العميل";
                return ((List<tblCustomer>)dataSource).Select(x => new { ID = x.id, Name = x.custNo + " - " + x.custName, Phone = x.custPhnNo, Currency = x.custCurrency }).ToList();
            }//Balance
            else if (listType.Any(x => x.Name == "GetCustomrtWhithBalance_Result"))
            {
                Tablname = "العميل";
                return ((List<GetCustomrtWhithBalance_Result>)dataSource).Select(x => new { ID = x.id, Name = x.custNo + " - " + x.custName, Phone = x.custPhnNo, Currency = x.custCurrency, Balance= GetBalanceCust(x) }).ToList();
            }//
            else if (listType.Any(x => x.Name == "tblSupplier"))
            {
                Tablname = "المورد";
                return ((List<tblSupplier>)dataSource).Select(x => new { ID = x.id, Name = x.splNo + " - " + x.splName, Phone = x.splPhnNo, Currency = x.splCurrency }).ToList();
            }
            else if (listType.Any(x => x.Name == "tblCurrency"))
            {
                Tablname = "العمله";
                return ((List<tblCurrency>)dataSource).Select(x => new { ID = x.id, Name = x.curSign + " - " + x.curName, Change = x.curChange }).ToList();
            }
            //else if (listType.Any(x => x.Name == "Country"))
            //{
            //    Tablname = "البلد";
            //    return ((List<tblCountry>)dataSource).Select(x => new { ID = x.NameEn + " - " + x.Name, Name = x.cntEnName + " - " + x.cntArName }).ToList();
            //}
            else return dataSource;
        }
        static string GetBalanceCust(GetCustomrtWhithBalance_Result x)
        {
            double Debit = (x.AssetDebit ?? 0) + (x.EntryDebit ?? 0) + (x.SupplyDebit ?? 0);
            double Credit = (x.AssetCredit ?? 0) + (x.EntryCredit ?? 0) + (x.SupplyCredit ?? 0);
            double balance = Debit - Credit;
            if (balance > 0)
                return $"{balance:n2} مدين ";
            else if (balance < 0)
                return $"{(balance * -1):n2} دائن ";
            else return balance.ToString();
        }
        static string Tablname;
        public static void IntializeData(this LookUpEdit lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.Properties.DataSource = GetTablName(dataSource);
            lkp.Properties.DisplayMember = displayMember;
            lkp.Properties.ValueMember = valueMember;
            lkp.Properties.Columns.Clear();
            lkp.Properties.Columns.AddRange(new LookUpColumnInfo[] {
            new LookUpColumnInfo("Name", Tablname)/*,new LookUpColumnInfo("Caption", Tablname)*/});
        }
        public static List<tblProduct> Products = new List<tblProduct>();
        public static void GetDataProducts()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    Products = db.tblProducts.AsNoTracking().Where(x => !x.Suspended).ToList();
                else
                    Products = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                                join q in db.tblProductQunatities.AsNoTracking() on p.id equals q.prdId
                                join s in db.tblStores.AsNoTracking() on q.prdStrId equals s.id
                                where s.strBrnId == CurBranch.brnId
                                select p).Distinct().ToList(); 
            }
        }
        public static List<string> ListPrinter=new List<string>();
        public static void GetListPrinter()
        {
            try
            {
                ListPrinter = (from p in (new ManagementObjectSearcher("SELECT * from Win32_Printer").Get().Cast<object>())
                               select ((ManagementObject)p).GetPropertyValue("Name").ToString()).ToList();
            }
            catch (Exception)
            {

                return;
            }
            
        }


        public static List<tblRoleControl> RoleControls = new List<tblRoleControl>();
        public static void GetDataRoleControlTbls()
        {
            using (var db = new accountingEntities())
                RoleControls = db.tblRoleControls.AsNoTracking().ToList();
        }

        public static List<tblRole> tblRole = new List<tblRole>();
        public static void GetDataRoleTbls()
        {
            using (var db = new accountingEntities())
                tblRole = db.tblRoles.AsNoTracking().ToList();
        }



        public static List<tblCurrency> Currencies = new List<tblCurrency>();
        public static void GetDataCurrencies()
        {
            using (var db = new accountingEntities())
                Currencies = db.tblCurrencies.AsNoTracking().ToList();
        }

        public static List<tblCountry> Countries = new List<tblCountry>();
        public static void GetDataCountries()
        {
            using (var db = new accountingEntities())
                Countries = db.tblCountries.AsNoTracking().ToList();
        }

        public static List<tblAccountBank> Banks = new List<tblAccountBank>();
        public static void GetDataBanks()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    Banks = db.tblAccountBanks.AsNoTracking().OrderBy(x => x.bankAccNo).ToList();
                else
                    Banks = db.tblAccountBanks.AsNoTracking().Where(x => x.bankBrnId == CurBranch.brnId).OrderBy(x => x.bankAccNo).ToList();
            }
        }

        public static List<tblAccountBox> Boxes = new List<tblAccountBox>();
        public static void GetDataBoxes()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    Boxes = db.tblAccountBoxes.AsNoTracking().ToList();
                else
                    Boxes = db.tblAccountBoxes.AsNoTracking().Where(x => x.boxBrnId == CurBranch.brnId).ToList();
            }
        }
        public static List<tblFinancialYear> tblFinancialYear = new List<tblFinancialYear>();
        public static void GetDataFinancialYears()
        {
            using (var db = new accountingEntities())
                tblFinancialYear = db.tblFinancialYears.AsNoTracking()/*.Where(x => x.fyBranchId == CurBranch.brnId)*/.ToList();
        }

        public static List<tblCustomer> Customers = new List<tblCustomer>();
        public static void GetDataCustomers()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (Session.CurrentUser.id == 1)
                    Customers = db.tblCustomers.AsNoTracking().ToList();
                else
                    Customers = db.tblCustomers.AsNoTracking().Where(x => x.custBrnId == CurBranch.brnId).ToList();
            }
        }

        public static List<GetCustomrtWhithBalance_Result> CustomrtWhithBalances = new List<GetCustomrtWhithBalance_Result>();
        public static void GetDataCustomrtWhithBalances()
        {
            using (accountingEntities db = new accountingEntities())
                    CustomrtWhithBalances = db.GetCustomrtWhithBalance(Session.CurrentYear.fyDateStart,Session.CurrentYear.fyDateEnd).ToList();
        }
        public static List<tblProductColor> ProductColors = new List<tblProductColor>();
        public static void GetDataProductColors()
        {
            using (var db = new accountingEntities())
                ProductColors = db.tblProductColors.AsNoTracking().ToList();
        }

        public static List<tblPrdManufacture> PrdManufactures = new List<tblPrdManufacture>();
        public static void GetDataPrdManufacture()
        {
            using (var db = new accountingEntities())
                PrdManufactures = db.tblPrdManufactures.AsNoTracking().ToList();
        }

        public static List<tblProductQunatity> ProductQunatities = new List<tblProductQunatity>();
        public static void GetDataProductQunatities()
        {
            using (accountingEntities db = new accountingEntities())
            {
                db.CalculatePrdQuan();
                if (CurrentUser.id == 1)
                    ProductQunatities = db.tblProductQunatities.AsNoTracking().Where(x => db.tblProducts.Any(y => y.id == x.prdId && !y.Suspended)).ToList();
                else ProductQunatities = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                            join q in db.tblProductQunatities.AsNoTracking() on p.id equals q.prdId
                            join s in db.tblStores.AsNoTracking() on q.prdStrId equals s.id
                            where s.strBrnId == CurBranch.brnId
                            select q).Distinct().ToList();

            }
        }
        public static void CalculatePrdQuan()
        {
            using (accountingEntities db = new accountingEntities())
                db.CalculatePrdQuan();
        }
        
        public static List<tblPrdPriceMeasurment> tblPrdPriceMeasurment = new List<tblPrdPriceMeasurment>();
        public static void GetDataPrdMeasurments()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblPrdPriceMeasurment = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                                             join m in db.tblPrdPriceMeasurments.AsNoTracking() on p.id equals m.ppmPrdId
                                             join q in db.tblProductQunatities.AsNoTracking() on p.id equals q.prdId
                                             join s in db.tblStores.AsNoTracking() on q.prdStrId equals s.id
                                             select m).Distinct().OrderBy(x => x.ppmPrdId).ToList();
                else
                    tblPrdPriceMeasurment = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                                             join m in db.tblPrdPriceMeasurments.AsNoTracking() on p.id equals m.ppmPrdId
                                             join q in db.tblProductQunatities.AsNoTracking() on p.id equals q.prdId
                                             join s in db.tblStores.AsNoTracking() on q.prdStrId equals s.id
                                             where s.strBrnId == CurBranch.brnId
                                             select m).Distinct().ToList();
            }
        }
        public static List<ProductTransaction> _ProductTransaction = new List<ProductTransaction>();
       
        public static List<tblPrdPriceQuan> tblPrdPriceQuan = new List<tblPrdPriceQuan>();
        public static void GetDataProductPrices()
        {
            using (var db = new accountingEntities())
            {
                //if (CurrentUser.id == 1)
                    tblPrdPriceQuan = db.tblPrdPriceQuans.AsNoTracking().ToList();
                //else tblPrdPriceQuan = db.tblPrdPriceQuans.AsNoTracking().Where(x => x.prdBrnId == CurBranch.brnId).ToList();
            }

        }

        public static List<tblBarcode> tblBarcode = new List<tblBarcode>();
        public static void GetDataBarcodes()
        {
            using (var db = new accountingEntities())
            {
                if (CurrentUser.id == 1)
                    tblBarcode = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                                  join m in db.tblPrdPriceMeasurments.AsNoTracking() on p.id equals m.ppmPrdId
                                  join b in db.tblBarcode.AsNoTracking() on m.ppmId equals b.brcPrdMsurId
                                  select b).Distinct().ToList();
                else tblBarcode = (from p in db.tblProducts.AsNoTracking().Where(x => !x.Suspended)
                                   join m in db.tblPrdPriceMeasurments.AsNoTracking() on p.id equals m.ppmPrdId
                                   join b in db.tblBarcode.AsNoTracking() on m.ppmId equals b.brcPrdMsurId
                                   join q in db.tblProductQunatities.AsNoTracking() on p.id equals q.prdId
                                   join s in db.tblStores.AsNoTracking() on q.prdStrId equals s.id
                                   where s.strBrnId == CurBranch.brnId
                                   select b).Distinct().ToList();
            }
        }
        public class BuyPrices
        {
            public int supMsur { get; set; }
            public int supPrdId { get; set; }
            public double supPrice { get; set; }
            public double Converion { get; set; }
            public DateTime supDate { get; set; }
        }
        public static List<BuyPrices> buyPrices = new List<BuyPrices>();

        public static void GetDataBuyPrices()
        {
            try
            {
                using (var temp = new accountingEntities())
                {
                    var p = temp.tblSupplySubs.AsNoTracking().Where(x => x.supBrnId == CurBranch.brnId && (x.supStatus == 3 || x.supStatus == 7));
                    if (p.Count() > 0)
                    {
                        buyPrices = (from price in p
                                     select new BuyPrices
                                     {
                                         supDate = price.supDate,
                                         supMsur = price.supMsur ?? 0,
                                         supPrice = price.supPrice ?? 0,
                                         supPrdId = price.supPrdId ?? 0,
                                         Converion=price.Conversion,
                                     }).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
