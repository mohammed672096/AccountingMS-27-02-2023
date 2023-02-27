using DevExpress.ChartRangeControlClient.Core;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using PosFinalCost.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;
using static PosFinalCost.Report.XtraFormReportsInvBuy;

namespace PosFinalCost.Classe
{
    class MyFunaction
    {
        string conStraing = "";
        public string ConnectionString_DB()
        {
            if (Program.My_Setting.Mode == "SQL")
                conStraing = "data source=" + Program.My_Setting.ServerName + ";Initial Catalog=" + Program.My_Setting.DBName + ";user id=" + Program.My_Setting.SqlUserName + ";password=" + Program.My_Setting.SqlPassword + ";";
            else if (Program.My_Setting.Mode == "Windows")
                conStraing = "data source=" + Program.My_Setting.ServerName + ";Initial Catalog=" + Program.My_Setting.DBName + ";Integrated Security=true;";
            return conStraing;
        }
        public string ConnectionString_AccDB()
        {
            if (Program.My_Setting.AccMode == "SQL")
                conStraing = "data source=" + Program.My_Setting.AccServerName + ";Initial Catalog=" + Program.My_Setting.AccDBName + ";user id=" + Program.My_Setting.AccSqlUserName + ";password=" + Program.My_Setting.AccSqlPassword + ";";
            else if (Program.My_Setting.AccMode == "Windows")
                conStraing = "data source=" + Program.My_Setting.AccServerName + ";Initial Catalog=" + Program.My_Setting.AccDBName + ";Integrated Security=true;";
            return conStraing;
        }
        public double GetSalePrice(bool PriceTax, PrdMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.SalePrice / 1.15 : priceMea.SalePrice) ?? 0);
        public double GetMinSalePrice(bool PriceTax, PrdMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.MinSalePrice / 1.15 : priceMea.MinSalePrice) ?? 0);
        public double GetBatchPrice(bool PriceTax, PrdMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.BatchPrice / 1.15 : priceMea.BatchPrice) ?? 0);
        public double GetRetailPrice(bool PriceTax, PrdMeasurment priceMea) => priceMea == null ? 0 : ((PriceTax ? priceMea.RetailPrice / 1.15 : priceMea.RetailPrice) ?? 0);
        public AccDrawerPeriod GetCopyOfCurrentDrawerPeriod(DrawerPeriod DrawerPeriod)
        {
            return new AccDrawerPeriod()
            {
                BranchID = DrawerPeriod.BranchID,
                AmountBank = DrawerPeriod.AmountBank,
                ActualBalance = DrawerPeriod.ActualBalance,
                ClosingBalance = DrawerPeriod.ClosingBalance,
                ClosingDrwerID = DrawerPeriod.ClosingDrwerID,
                ClosingPeriodUserID = DrawerPeriod.ClosingPeriodUserID,
                DifferenceAccountID = DrawerPeriod.DifferenceAccountID,
                DrawerID = DrawerPeriod.DrawerID,
                OpeningBalance = DrawerPeriod.OpeningBalance,
                PeriodEnd = DrawerPeriod.PeriodEnd,
                PeriodStart = DrawerPeriod.PeriodStart,
                PeriodUserID = DrawerPeriod.PeriodUserID,
                RefID = DrawerPeriod.ID,
                RemainingBalance = DrawerPeriod.RemainingBalance,
                Status = DrawerPeriod.Status,
                TransferdBalance = DrawerPeriod.TransferdBalance,

            };
        }
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
                ID=d.ID,
                SendToserver=d.SendToserver
                
            };
        }
        public Customer GetCopyOfCurreCustomer(Customer Customer) => new Customer
        {
            CommercialRegister = Customer.CommercialRegister,
            AddNo = Customer.AddNo,
            AnotherID = Customer.AnotherID,
            BankId = Customer.BankId,
            BuildingNo = Customer.BuildingNo,
            District = Customer.District,
            DistrictEn = Customer.DistrictEn,
            AccNo = Customer.AccNo,
            Address = Customer.Address,
            AddressEn = Customer.AddressEn,
            BrnId = Customer.BrnId,
            CellingCredit = Customer.CellingCredit,
            City = Customer.City,
            CityEn = Customer.CityEn,
            Country = Customer.Country,
            CountryEn = Customer.CountryEn,
            Currency = Customer.Currency,
            Email = Customer.Email,
            ID = Customer.ID,
            Name = Customer.Name,
            NameEn = Customer.NameEn,
            No = Customer.No,
            PhnNo = Customer.PhnNo,
            PostalCode = Customer.PostalCode,
            SalePrice = Customer.SalePrice,
            Status = Customer.Status,
            TaxNo = Customer.TaxNo
        }; 
        public SupplyMain GetCopyFromSupplyMain(SupplyMain m) => new SupplyMain
        {
            UserId=m.UserId,
            BankAmount=m.BankAmount,
            BankId=m.BankId,    
            BoxId=m.BoxId,
            BrnId=m.BrnId,
            CarType=m.CarType,
            CounterNumber=m.CounterNumber,
            Currency=m.Currency,
            CurrencyChng=m.CurrencyChng,
            CustId=m.CustId,
            Date=m.Date,    
            Desc=m.Desc,
            DscntAmount=m.DscntAmount,
            DscntPercent=m.DscntPercent,
            DueDate=m.DueDate,
            EnterDate=m.EnterDate,
            ID=m.ID,
            IsCash=m.IsCash,
            IsDelete=m.IsDelete,
            Net=m.Net,
            No=m.No,
            Notes=m.Notes,
            paidCash=m.paidCash,
            PlateNumber=m.PlateNumber,
            PoNumber=m.PoNumber,
            RefNo=m.RefNo,
            Remin=m.Remin,  
            SendToserver=m.SendToserver,
            Status=m.Status,
            StrId=m.StrId,
            TaxPercent=m.TaxPercent,
            TaxPrice=m.TaxPrice,
            Total=m.Total,
            TotalAfterDiscount=m.TotalAfterDiscount,
            TotalFrgn=m.TotalFrgn,
        };
        public PrdExpirateMain GetCopyFromPrdExpirateMain(PrdExpirateMain m) => new PrdExpirateMain
        {
            Date = m.Date,
            ID = m.ID,
            BranchID=m.BranchID,
            StorID=m.StorID,
            UserID=m.UserID,
            No=m.No,
            SendToserver=m.SendToserver
        };
        public List<SupplySub> GetCopyFromSupplySub(List<SupplySub> supplySubs) =>
            (from i in supplySubs
             select new SupplySub
             {
                 BrnId = i.BrnId,
                 BuyPrice = i.BuyPrice,
                 Currency = i.Currency,
                 Date = i.Date,
                 Desc = i.Desc,
                 DscntAmount = i.DscntAmount,
                 DscntPercent = i.DscntPercent,
                 ExpireDate = i.ExpireDate,
                 Height = i.Height,
                 ID = i.ID,
                 Msur = i.Msur,
                 NoPacks = i.NoPacks,
                 Overtime = i.Overtime,
                 ParentID = i.ParentID,
                 PrdBarcode = i.PrdBarcode,
                 PrdId = i.PrdId,
                 PrdManufacture = i.PrdManufacture,
                 QteMeter = i.QteMeter,
                 QuanMain = i.QuanMain,
                 SalePrice = i.SalePrice,
                 Status = i.Status,
                 TaxPercent = i.TaxPercent,
                 TaxPrice = i.TaxPrice,
                 Total = i.Total,
                 TotalFrgn = i.TotalFrgn,
                 UserId = i.UserId,
                 Width = i.Width,
                 Workingtime = i.Workingtime,
             }).ToList();
        public List<PrdExpirateDetail> GetCopyFromPrdExpirateDetail(List<PrdExpirateDetail> PrdExpirateDetails) =>
       (from i in PrdExpirateDetails
        select new PrdExpirateDetail
        {
           BranchID=i.BranchID,
           StoreID=i.StoreID,
           ExpDate=i.ExpDate,
           ProductID=i.ProductID,
           Price=i.Price,
           Date=i.Date,
           ID = i.ID,
           MsurID = i.MsurID,
           ParentID = i.ParentID,
           Quantity = i.Quantity,
           Status = i.Status ,
           PrdBarcode=i.PrdBarcode,
           
        }).ToList();
        public PrdExpirateDetail GetCopyForObjectPrdExpirateDetail(PrdExpirateDetail i) => new PrdExpirateDetail
        {
            BranchID = i.BranchID,
            StoreID = i.StoreID,
            ExpDate = i.ExpDate,
            ProductID = i.ProductID,
            Price = i.Price,
            Date = i.Date,
            ID = i.ID,
            MsurID = i.MsurID,
            ParentID = i.ParentID,
            Quantity = i.Quantity,
            Status = i.Status,
            PrdBarcode = i.PrdBarcode
        };

        public SupplySub GetCopyForObjectSupplySub(SupplySub i) => new SupplySub
            {
                BrnId = i.BrnId,
                BuyPrice = i.BuyPrice,
                Currency = i.Currency,
                Date = i.Date,
                Desc = i.Desc,
                DscntAmount = i.DscntAmount,
                DscntPercent = i.DscntPercent,
                ExpireDate = i.ExpireDate,
                Height = i.Height,
                ID = i.ID,
                Msur = i.Msur,
                NoPacks = i.NoPacks,
                Overtime = i.Overtime,
                ParentID = i.ParentID,
                PrdBarcode = i.PrdBarcode,
                PrdId = i.PrdId,
                PrdManufacture = i.PrdManufacture,
                QteMeter = i.QteMeter,
                QuanMain = i.QuanMain,
                SalePrice = i.SalePrice,
                Status = i.Status,
                TaxPercent = i.TaxPercent,
                TaxPrice = i.TaxPrice,
                Total = i.Total,
                TotalFrgn = i.TotalFrgn,
                UserId = i.UserId,
                Width = i.Width,
                Workingtime = i.Workingtime,
            };

        public EntryMain GetCopyFromEntryMain(EntryMain m) => new EntryMain
        {
            BranchID = m.BranchID,
            Amount = m.Amount,
            AccNo = m.AccNo,
            CurChange = m.CurChange,
            Currency = m.Currency,
            Date = m.Date,
            FromToPerson = m.FromToPerson,
            ID = m.ID,
            No=m.No,
            Notes = m.Notes,
            PayMethod = m.PayMethod,
            RefNo = m.RefNo,
            SendToserver = m.SendToserver,
            Status = m.Status,
            UserID=m.UserID,
        };
        public List<EntrySub> GetCopyFromEntrySub(List<EntrySub> EntrySubs) =>
            (from i in EntrySubs
             select new EntrySub
             {
                Status = i.Status,
                Notes = i.Notes,
                ID = i.ID,
                Date = i.Date,
                AccNo=i.AccNo,
                BranchID = i.BranchID,
                CurChange=i.CurChange,
                Currency=i.Currency,
                CustomerID=i.CustomerID,
                Dain=i.Dain,
                DainFrgn=i.DainFrgn,
                Madin=i.Madin,
                MadinFrgn=i.MadinFrgn,
                ParentID=i.ParentID,
             }).ToList();
        private XtraReport InitReportInvoice()
        {
            switch (Session.CurrSettings.DefaultPrintPaper)
            {
                case (byte)PrintPaperType.Cashier:
                    return new ReportInvoiceCasher();
                case (byte)PrintPaperType.A4:
                    return new ReportInvoiceA4();
                default:
                    return null;
            }
        }
        private List<SupplySubCustom> InitSupplySubCustom(IList<SupplySub> supplySubs)
        {
           return (from S in supplySubs
                   select new SupplySubCustom
                   {
                       NoPacks = S.NoPacks,
                       Desc = S.Desc,
                       DscntAmount = Convert.ToDouble($"{S.DscntAmount:n2}"),
                       DscntPercent = Convert.ToDouble($"{S.DscntPercent:n2}"),
                       Msur = Session.PrdMeasurments.FirstOrDefault(x => x.ID == S.Msur)?.Name,
                       Overtime = S.Overtime,
                       PrdBarcode = S.PrdBarcode,
                       PrdName = Session.Products.FirstOrDefault(x => x.ID == S.PrdId)?.Name,
                       PrdNo = Session.Products.FirstOrDefault(x => x.ID == S.PrdId)?.No,
                       BuyPrice = Convert.ToDouble($"{S.BuyPrice:n2}"),
                       QuanMain = Convert.ToDouble($"{S.QuanMain:n2}"),
                       SalePrice = Convert.ToDouble($"{S.SalePrice:n2}"),
                       TaxPercent = Convert.ToDouble($"{S.TaxPercent:n2}"),
                       TaxPrice = Convert.ToDouble($"{S.TaxPrice:n2}"),
                       Total = Convert.ToDouble($"{S.Total:n2}"),
                       Workingtime = S.Workingtime,
                   }).ToList();
        }
        public void PrintInvoice(int No, IList<SupplySub> supplySubs, SupplyMain supplyMain,PrintFileType printFileType = PrintFileType.Printer)
        {
            try
            {
                XtraReport reportSupply = InitReportInvoice();
                List<SupplySubCustom> supplySubCustom;
                if (supplySubs == null)
                    using (var db = new PosDBDataContext(Program.ConnectionString))
                    {
                        supplyMain = supplyMain == null ? db.SupplyMains.FirstOrDefault(x => x.No == No && x.Date >= Session.CurrentYear.DateStart
                                          && x.Date <= Session.CurrentYear.DateEnd && x.BrnId == Session.CurrentBranch.ID) : supplyMain;
                        if (supplyMain == null) return;
                        supplySubCustom = (from S in db.SupplySubs
                                           join P in db.Products on S.PrdId equals P.ID
                                           join U in db.PrdMeasurments on S.Msur equals U.ID
                                           where S.ParentID == supplyMain.ID && S.Date >= Session.CurrentYear.DateStart
                                           && S.Date <= Session.CurrentYear.DateEnd && S.BrnId == Session.CurrentBranch.ID
                                           select new SupplySubCustom
                                           {
                                               NoPacks = S.NoPacks,
                                               Desc = S.Desc,
                                               DscntAmount = Convert.ToDouble($"{S.DscntAmount:n2}"),
                                               DscntPercent = Convert.ToDouble($"{S.DscntPercent:n2}"),
                                               Msur = U.Name,
                                               Overtime = S.Overtime,
                                               PrdBarcode = S.PrdBarcode,
                                               PrdName = P.Name,
                                               PrdNo = P.No,
                                               BuyPrice = Convert.ToDouble($"{S.BuyPrice:n2}"),
                                               QuanMain = Convert.ToDouble($"{S.QuanMain:n2}"),
                                               SalePrice = Convert.ToDouble($"{S.SalePrice:n2}"),
                                               TaxPercent = Convert.ToDouble($"{S.TaxPercent:n2}"),
                                               TaxPrice = Convert.ToDouble($"{S.TaxPrice:n2}"),
                                               Total = Convert.ToDouble($"{S.Total:n2}"),
                                               Workingtime = S.Workingtime,
                                           }).ToList();
                    }
                else supplySubCustom = InitSupplySubCustom(supplySubs);
                InvoiceReport invoiceReport = new InvoiceReport(supplyMain);
                if (invoiceReport == null) return;
                switch (Session.CurrSettings.DefaultPrintPaper)
                {
                    case (byte)PrintPaperType.A4:
                        ((ReportInvoiceA4)reportSupply).SupplySubBindingSource.DataSource = supplySubCustom;
                        ((ReportInvoiceA4)reportSupply).SupplyMainBindingSource.DataSource = invoiceReport;
                        break;
                    default:
                        ((ReportInvoiceCasher)reportSupply).SupplySubBindingSource.DataSource = supplySubCustom;
                        ((ReportInvoiceCasher)reportSupply).SupplyMainBindingSource.DataSource = invoiceReport;
                        if (invoiceReport.CustomerData != null)
                            ((ReportInvoiceCasher)reportSupply).DetailReportCustomer.Visible = true;
                        break;
                }
                reportSupply.DisplayName = DisplayName(invoiceReport);
                PrintFile(printFileType, reportSupply);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);   
                return;
            }

        }
        public void PrintPrdExpirt(PrdExpirateMain PrdExpirateMain, PrintFileType printFileType = PrintFileType.Printer)
        {
            try
            {
                using (var db=new PosDBDataContext(Program.ConnectionString))
                {
                    IList<PrdExpirateDetail> PrdExpirateDetail = db.PrdExpirateDetails.AsNoTracking().Where(x => x.ParentID == PrdExpirateMain.ID).ToList();
                    XtraReport reportSupply = new ReportProExpirte(PrdExpirateMain, PrdExpirateDetail);
                    PrintFile(printFileType, reportSupply);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }

        }
        public void PrintFile(PrintFileType printFileType, XtraReport reportSupply)
        {
            switch (printFileType)
            {
                case PrintFileType.Printer:
                    reportSupply.PrinterName = Session.CurrSettings.DefaultSalesPrinterName;
                    if (Session.CurrSettings.InvoicePrintMode == ((byte)PrintMode.Direct))
                        reportSupply.Print();
                    else
                        new ReportForm(reportSupply).ShowDialog();
                    break;
                case PrintFileType.PDF:
                case PrintFileType.Xlsx:
                    if (Session.CurrSettings.PrintFileMode == ((byte)PrintMode.Direct))
                    {
                        if (PrintFileType.PDF == printFileType)
                            reportSupply.ExportToPdf(DomainPath + "\\" + reportSupply.DisplayName + ".pdf");
                        else if (PrintFileType.Xlsx == printFileType)
                            reportSupply.ExportToXlsx(DomainPath + "\\" + reportSupply.DisplayName + ".Xlsx");
                    }
                    else
                    {
                        XtraSaveFileDialog fileDialog = new XtraSaveFileDialog();
                        switch (printFileType)
                        {
                            case PrintFileType.PDF:
                                fileDialog.Filter = "PDF Files|*.pdf";
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                    reportSupply.ExportToPdf(fileDialog.FileName);
                                break;
                            case PrintFileType.Xlsx:
                                fileDialog.Filter = "Excel Files|*.Xlsx";
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                    reportSupply.ExportToXlsx(fileDialog.FileName);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        string DisplayName(InvoiceReport invoiceReport) => invoiceReport.SupplyMainData.Status + invoiceReport.SupplyMainData.No;
        string DomainPath =>File.Exists(Session.CurrSettings.PrintFileDefultPathe)? Session.CurrSettings.PrintFileDefultPathe: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        public void PrintEntry(int No, IList<EntrySub> EntrySubs, EntryMain EntryMain, PrintFileType printFileType = PrintFileType.Printer)
        {
            List<EntrySubCustom> EntrySubCustom;
            EntrySubCustom subCustoms = new Classe.EntrySubCustom();
            if (EntrySubs == null)
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    EntryMain = EntryMain == null ? db.EntryMains.FirstOrDefault(x => x.No == No && x.Date >= Session.CurrentYear.DateStart
                                      && x.Date <= Session.CurrentYear.DateEnd && x.BranchID == Session.CurrentBranch.ID) : EntryMain;
                    if (EntryMain == null) return;
                    EntrySubCustom = subCustoms.GetEntrySubToList(db.EntrySubs.Where(S=>S.ParentID == EntryMain.ID && S.Date >= Session.CurrentYear.DateStart
                                       && S.Date <= Session.CurrentYear.DateEnd && S.BranchID == Session.CurrentBranch.ID).ToList());
                }
            else EntrySubCustom = subCustoms.GetEntrySubToList(EntrySubs.ToList());
            EntryDataCustom entryDataCustom = new EntryDataCustom(EntryMain);
            if (entryDataCustom == null) return;
            ReportEntryCustom reportEntry = new ReportEntryCustom(entryDataCustom, EntrySubCustom, EntryMain.Status);
            reportEntry.entrySubDataBindingSource.DataSource = EntrySubCustom;
                   reportEntry.EntryMainBindingSource.DataSource = entryDataCustom;
            string DisplayName = entryDataCustom.EntryData.EntType + entryDataCustom.EntryData.No;
            reportEntry.DisplayName = DisplayName;
            switch (printFileType)
            {
                case PrintFileType.Printer:
                    reportEntry.PrinterName = Session.CurrSettings.DefaultSalesPrinterName;
                    if (Session.CurrSettings.InvoicePrintMode == ((byte)PrintMode.Direct))
                        reportEntry.Print();
                    else
                        new ReportForm(reportEntry).ShowDialog();
                    break;
                case PrintFileType.PDF:
                case PrintFileType.Xlsx:
                    if (Session.CurrSettings.PrintFileMode == ((byte)PrintMode.Direct))
                    {
                        if (PrintFileType.PDF == printFileType)
                            reportEntry.ExportToPdf(DomainPath + "\\" + reportEntry.DisplayName + ".pdf");
                        else if (PrintFileType.Xlsx == printFileType)
                            reportEntry.ExportToXlsx(DomainPath + "\\" + reportEntry.DisplayName + ".Xlsx");
                    }
                    else
                    {
                        XtraSaveFileDialog fileDialog = new XtraSaveFileDialog();
                        switch (printFileType)
                        {
                            case PrintFileType.PDF:
                                fileDialog.Filter = "PDF Files|*.pdf";
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                    reportEntry.ExportToPdf(fileDialog.FileName);
                                break;
                            case PrintFileType.Xlsx:
                                fileDialog.Filter = "Excel Files|*.Xlsx";
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                    reportEntry.ExportToXlsx(fileDialog.FileName);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public string ChickBarcodWaghit(string Barcod,out bool ProIsWaghit,out double value)
        {
            ProIsWaghit=false;
            value = 1;
            if (!Session.CurrSettings.ReadFormScaleBarcode) return Barcod;
            if (Barcod.Length != Session.CurrSettings.BarcodeLength) return Barcod;
            if (!Barcod.StartsWith(Session.CurrSettings.ScaleBarcodePrefix)) return Barcod;
            ProIsWaghit = true;
            string Readvalue = Barcod.Substring(Session.CurrSettings.ScaleBarcodePrefix.Length + Session.CurrSettings.ProductCodeLength);
            if (Session.CurrSettings.IgnoreCheckDigit) Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
            value = Convert.ToDouble(Readvalue);
            value = value / (Math.Pow(10, (short)(Session.CurrSettings.DivideValueBy.ToString().Length - 1) ));
            int.TryParse(Barcod.Substring(Session.CurrSettings.ScaleBarcodePrefix.Length, Session.CurrSettings.ProductCodeLength),out int h);
            return h.ToString();
        }
        public void GetNewORUpdateSupplySub(SupplySub row)
        {
                string Readvalue = row.PrdBarcode.Substring(Session.CurrSettings.ScaleBarcodePrefix.Length + Session.CurrSettings.ProductCodeLength);
                if (Session.CurrSettings.IgnoreCheckDigit) Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
                double value = Convert.ToDouble(Readvalue);
                value = value / (Math.Pow(10, Session.CurrSettings.DivideValueBy));
                if (Session.CurrSettings.ReadMode == 0)
                    row.QuanMain += value;
            //else if (Session.CurrSettings.ReadMode == 1)
            //{
            //    var priceAfterTax = 100 * (value / (100 + 15));
            //    value = Session.CurrSettings.TaxReadMode ? priceAfterTax : value;
            //    if (this.productData.PrdMeasurment != null)
            //    {
            //        value = (value / Convert.ToDouble(this.productData.PrdMeasurment.SalePrice ?? 1));
            //        row.QuanMain = InGrid ? row.QuanMain + value : value;
            //    }
            //}
            //return row;
        }
        public void AppearanceGridView(GridView gridView)
        {
            gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.Columns.ForEach(x => x.AppearanceHeader.BackColor = System.Drawing.Color.SteelBlue);
            gridView.OptionsBehavior.ReadOnly = true;
            gridView.Appearance.Empty.BackColor = System.Drawing.Color.AliceBlue;
        }
        public void LayoutAppearance(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator = null)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroupInvo_CustomDrawBackground;
            layoutControlGroup.AppearanceGroup.BorderColor = System.Drawing.Color.PowderBlue;
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        public void LayoutAppearanceInvo(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator, Color systemColors)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroupInvo_CustomDrawBackground;
            layoutControlGroup.AppearanceGroup.BackColor = systemColors;
            if (bindingNavigator != null)
                bindingNavigator.BackColor = systemColors;
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        private void LayoutGroupInvo_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            LayoutControlGroup controlGroup = ((LayoutControlGroup)sender);
            e.DefaultDraw();
            e.Graphics.FillRectangle(new SolidBrush(controlGroup.AppearanceGroup.BackColor), e.Bounds);
            e.Handled = true;
        }
        public void layoutAppearanceGroup(LayoutControlGroup layoutControlGroup)
        {
            LayoutAppearance(layoutControlGroup);
            //layoutControlGroup.Parent?.Items?.Where(x => x is LayoutControlGroup).ForEach(x =>
            //{
            //    LayoutAppearance((LayoutControlGroup)x);
            //});
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void layoutAppearanceGroup(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator = null)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroup_CustomDrawBackground;
            layoutControlGroup.Parent?.Items?.Where(x => x is LayoutControlGroup).ForEach(x =>
            ((LayoutControlGroup)x).AppearanceGroup.BorderColor = System.Drawing.Color.SteelBlue);
            if (bindingNavigator != null)
            {
                bindingNavigator.Font = (Font)converter.ConvertFromString(Program.My_Setting.SystemFont);
                bindingNavigator.BackColor = System.Drawing.Color.AliceBlue;
            }
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        private void LayoutGroup_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.SystemColors.GradientInactiveCaption), e.Bounds);
            e.Handled = true;
        }
        public void LayoutAppearance(LayoutControl dataLayout)
        {
            dataLayout.Items.Where(x => x is LayoutControlGroup).ToList().ForEach(x => {
                LayoutAppearance((LayoutControlGroup)x);
            });
        }
    }
}
