using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.IO;

namespace AccountingMS
{
    static class ClsPath
    {
        private static string _reportSupplyCustomFileName = null;
        public static string ReportSupplyCustomFile
        {
            get
            {
                _reportSupplyCustomFileName = @$"{ClsDrive.Path}:\B-Tech\Reports\ReportSupplyCustom";
                if (MySetting.DefaultSetting.rprtSupplyCustomType == 2)
                    _reportSupplyCustomFileName += "2.repx";
                else if (MySetting.DefaultSetting.rprtSupplyCustomType == 3)
                    _reportSupplyCustomFileName += "3.repx";
                else
                    _reportSupplyCustomFileName += ".repx";

                return _reportSupplyCustomFileName;
            }
        }
        public static string ReportSupplyCashierCustomFile{ get; }= @$"{ClsDrive.Path}:\B-Tech\Reports\ReportSupplyCashierCustom.repx";
        public static string ReportEntryReciptCustomFile { get; } = @$"{ClsDrive.Path}:\B-Tech\Reports\ReportEntryReciptCustom.repx";
        public static string ReportEntryVocherCustomFile { get; } = @$"{ClsDrive.Path}:\B-Tech\Reports\ReportEntryVocherCustom.repx";
        public static string ReportDailyEntryCustomFile { get; } = @$"{ClsDrive.Path}:\B-Tech\Reports\ReportDailyEntryCustom.repx"; 
        public static string ReportSupplyCustomFolder { get; } = @$"{ClsDrive.Path}:\B-Tech\Reports";

        private static readonly string DomainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "B-Tech", "LayoutToXml");
        public static void ReLodeCustomContol(this GridView view, string name)
        {
         
            var subFolderPath = Path.Combine(pathLayoutToXml, $"{name}_{view.Name}.xml");
            //var subFolderPath = Path.Combine(DomainPath, $"{name}_{view.Name}.xml");
            if (File.Exists(subFolderPath))
                view.RestoreLayoutFromXml(subFolderPath);
        }
        public static void ReLodeCustomContol(this DataLayoutControl dataLayoutControl, string name)
        {
            name += MySetting.GetPrivateSetting.LangEng.ToString();
               var subFolderPath = Path.Combine(pathLayoutToXml, $"{name}_{dataLayoutControl.Name}.xml");
            if (File.Exists(subFolderPath))
                dataLayoutControl.RestoreLayoutFromXml(subFolderPath);
        }
        public static string pathLayoutToXml = Environment.CurrentDirectory + "\\LayoutToXml";
        public static void SaveCustomContol(this DataLayoutControl dataLayoutControl, string name)
        {
            try
            {
                name += MySetting.GetPrivateSetting.LangEng.ToString();
                if (!File.Exists(pathLayoutToXml)) Directory.CreateDirectory(pathLayoutToXml);
                var subFolderPath = Path.Combine(pathLayoutToXml, $"{name}_{dataLayoutControl.Name}.xml");
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
                //if (!File.Exists(DomainPath)) Directory.CreateDirectory(DomainPath);
                if (!File.Exists(pathLayoutToXml)) Directory.CreateDirectory(pathLayoutToXml);
                var subFolderPath = Path.Combine(pathLayoutToXml, $"{name}_{view.Name}.xml");
                view.SaveLayoutToXml(subFolderPath);
            }
            catch (Exception)
            {
            }
        }
    }
}
