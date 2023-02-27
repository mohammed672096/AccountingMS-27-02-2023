using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccountingMS
{
    class ClsPrintReport
    {
        public static void PrintSupply(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {

            if (MySetting.DefaultSetting.printA4 == 5)
            {
                if (MySetting.DefaultSetting.supplyCashierCustomRprt)
                {
                    if (!MySetting.DefaultSetting.supplyRetuA4CustomRprt && (tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12))
                        PrintCashierInvoice(tbSupplyMain, tbSupplySubList);
                    else PrintCashierCustomInvoice(tbSupplyMain, tbSupplySubList);
                }
                else PrintCashierInvoice(tbSupplyMain, tbSupplySubList);
            }
            else if (MySetting.DefaultSetting.printA4 == 4)
            {
                if (MySetting.DefaultSetting.supplyA4CustomRprt)
                {
                    if (!MySetting.DefaultSetting.supplyRetuA4CustomRprt && (tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12))
                        PrintA4Invoice(tbSupplyMain, tbSupplySubList);
                    else PrintA4CustomInvoice(tbSupplyMain, tbSupplySubList);
                }
                else PrintA4Invoice(tbSupplyMain, tbSupplySubList);
            }
        }
        private static void PrintCashierCustomInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            if (!ValidateRprtSupplyCashierCustomFile()) return;
            using DevExpress.XtraReports.UI.XtraReport report = (new ReportSupplyCashierCustom(tbSupplyMain, tbSupplySubList));
            if (Session.ListPrinter.Any(x => x == Session.CurrentUser.PrinterName))
                report.PrinterName = Session.CurrentUser.PrinterName;
            else if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterSettings))
                report.PrinterName = MySetting.DefaultSetting.defaultPrinterSettings;
            report.ShowPrintMarginsWarning = false;
            report.CreateDocument();
            report.Print();
        }

        public static void PrintOrder(tblOrderMain tbOrderMain, IEnumerable<tblOrderSub> tbOrderSubList, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            if (MySetting.DefaultSetting.rprtOrderA4CustomRpt)
                PrintOrderCustomInvoice(tbOrderMain, tbOrderSubList);
            else
            {
                using var report = new ReportOrderInvoice(tbOrderMain, tbOrderSubList);
                report.PrinterName = MySetting.DefaultSetting.ordersPrinter;
                report.ShowPrintMarginsWarning = false;
                report.CreateDocument();
                report.Print();
            }
        }
        private static void PrintOrderCustomInvoice(tblOrderMain tbOrderMain, IEnumerable<tblOrderSub> tbOrderSubList)
        {
            if (!ValidateRprtSupplyCustomFile()) return;
            using DevExpress.XtraReports.UI.XtraReport report = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
            {
                2 => new ReportSupplyCustom2(tbOrderMain, tbOrderSubList),
                3 => new ReportSupplyCustom3(tbOrderMain, tbOrderSubList),
                _ => new ReportSupplyCustom(tbOrderMain, tbOrderSubList),
            };
            if (Session.ListPrinter.Any(x => x == Session.CurrentUser.PrinterName))
                report.PrinterName = Session.CurrentUser.PrinterName;
            else if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterSettings))
                report.PrinterName = MySetting.DefaultSetting.defaultPrinterSettings;
            report.ShowPrintMarginsWarning = false;
            report.CreateDocument();
            report.Print();
        }

        public static void PrintA4Invoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            try
            {
                using var report = new ReportSupply(tbSupplyMain, tbSupplySubList);
                if (Session.ListPrinter.Any(x => x == Session.CurrentUser.PrinterName))
                    report.PrinterName = Session.CurrentUser.PrinterName;
                else if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterSettings))
                    report.PrinterName = MySetting.DefaultSetting.defaultPrinterSettings;
                report.ShowPrintMarginsWarning = false;
                report.CreateDocument();
                report.Print();
            }
            catch { }
        }

        private static void PrintCashierInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            using var report = new ReportSupplyCashier(tbSupplyMain, tbSupplySubList);
            report.ShowPrintMarginsWarning = false;
            report.DefaultPrinterSettingsUsing.UseMargins = false;
            report.CreateDocument();
            if (Session.ListPrinter.Any(x => x == Session.CurrentUser.PrinterName))
                report.Print(Session.CurrentUser.PrinterName);
            else if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterSettings))
                report.Print(MySetting.DefaultSetting.defaultPrinterSettings);
            else report.Print();
        }

        public static void PrintBarcode(DevExpress.BarCodes.BarCode barCode, IDictionary<BarcodeSettings, string> barcodeSettings, short Copies = 1)
        {
            using var report = new ReportBarcode(barCode, barcodeSettings);
            report.PrintingSystem.StartPrint += (ss, ee) => { ee.PrintDocument.PrinterSettings.Copies = Copies; };
            report.Margins.Left = 18;
            report.DefaultPrinterSettingsUsing.UseMargins = true;
            // report.ShowPrintMarginsWarning = false;
            report.DefaultPrinterSettingsUsing.UseMargins = false;
            report.PrinterName = MySetting.DefaultSetting.defaultPrinterBarcode;
            report.CreateDocument();
            report.Print();
        }

        public static void PrintBarcode(DevExpress.BarCodes.BarCode barCode, System.Windows.Forms.PictureBox picbarcode, IDictionary<BarcodeSettings, string> barcodeSettings, short Copies = 1)
        {
            using var report = new ReportBarcode(barCode, picbarcode, barcodeSettings);
            report.ShowPrintMarginsWarning = false;
            report.PrintingSystem.StartPrint += (ss, ee) => { ee.PrintDocument.PrinterSettings.Copies = Copies; };

            report.Margins.Right = 3;
            report.DefaultPrinterSettingsUsing.UseMargins = true;
            report.CreateDocument();
            if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterBarcode))
                report.Print(MySetting.DefaultSetting.defaultPrinterBarcode);
            else report.Print();
        }

        private static void PrintA4CustomInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            if (!ValidateRprtSupplyCustomFile()) return;
            using DevExpress.XtraReports.UI.XtraReport report = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
            {
                2 => new ReportSupplyCustom2(tbSupplyMain, tbSupplySubList),
                3 => new ReportSupplyCustom3(tbSupplyMain, tbSupplySubList),
                _ => new ReportSupplyCustom(tbSupplyMain, tbSupplySubList),
            };
            if (Session.ListPrinter.Any(x => x == Session.CurrentUser.PrinterName))
                report.PrinterName = Session.CurrentUser.PrinterName;
            else if (Session.ListPrinter.Any(x => x == MySetting.DefaultSetting.defaultPrinterSettings))
                report.PrinterName = MySetting.DefaultSetting.defaultPrinterSettings;
            report.ShowPrintMarginsWarning = false;
            report.CreateDocument();
            report.Print();
        }

        protected internal static bool ValidateRprtSupplyCustomFile()
        {
            if (File.Exists(ClsPath.ReportSupplyCustomFile)) return true;
            DevExpress.XtraEditors.XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا لم يتم العثور على ملف التقرير المخصص" : "Sorry could not find custom report file");
            return false;
        }
        protected internal static bool ValidateRprtSupplyCashierCustomFile()
        {
            if (File.Exists(ClsPath.ReportSupplyCashierCustomFile)) return true;
            DevExpress.XtraEditors.XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا لم يتم العثور على ملف التقرير المخصص" : "Sorry could not find custom report file");
            return false;
        }

    }
}
