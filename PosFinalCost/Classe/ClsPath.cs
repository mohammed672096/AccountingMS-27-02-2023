using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    static class ClsPath
    {
        public static string ReportInvoiceA4 = "\\ReportInvoiceA4.repx";
        public static string ReportInvoiceCasher = "\\ReportInvoiceCasher.repx";
        public static string ReportSupplyCustomFolder { get; } = @"C:\Pos-FinalCost\Reports";
        public static string ReportEntryRecipt { get; } = "\\ReportEntryRecipt.repx";
        public static string ReportEntryVocher { get; } = "\\ReportEntryVocher.repx";
        public static string ReportDailyEntry { get; } = "\\ReportDailyEntry.repx";
        private static readonly string DomainPath = Program.pathLayoutToXml;
        public static void ReLodeCustomContol(this GridView view, string name)
        {
            var subFolderPath = Path.Combine(DomainPath, $"{name}_{view.Name}.xml");
            if (File.Exists(subFolderPath))
                view.RestoreLayoutFromXml(subFolderPath);
        }
        public static string GetPathReportCustomA4() => ReportSupplyCustomFolder + ReportInvoiceA4;
        public static string GetPathReportCustomCasher() => ReportSupplyCustomFolder + ReportInvoiceCasher;
        public static string GetPathReportCustom(PrintPaperType printPaper) => ReportSupplyCustomFolder + (PrintPaperType.A4 == printPaper ? ReportInvoiceA4 : ReportInvoiceCasher);
        public static void ReLodeCustomContol(this DataLayoutControl dataLayoutControl, string name)
        {
            var subFolderPath = Path.Combine(DomainPath, $"{name}_{dataLayoutControl.Name}.xml");
            if (File.Exists(subFolderPath))
                dataLayoutControl.RestoreLayoutFromXml(subFolderPath);
        }
        public static void SaveCustomContol(this DataLayoutControl dataLayoutControl, string name)
        {
            try
            {
                if (!File.Exists(DomainPath)) Directory.CreateDirectory(DomainPath);
                var subFolderPath = Path.Combine(DomainPath, $"{name}_{dataLayoutControl.Name}.xml");
                dataLayoutControl.SaveLayoutToXml(subFolderPath);
            }
            catch (Exception)
            {
                return;
            }
        }
        public static void SaveCustomContol(this GridView view, string name)
        {
            try
            {
                if (!File.Exists(DomainPath)) Directory.CreateDirectory(DomainPath);

                var subFolderPath = Path.Combine(DomainPath, $"{name}_{view.Name}.xml");
                view.SaveLayoutToXml(subFolderPath);
            }
            catch (Exception)
            {
            }
        }
    }
}
