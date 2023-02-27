using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Microsoft.Win32;
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
using System.Xml.Serialization;

namespace PosFinalCost.Classe
{
    public  class MySetting
    {
        static string path = Environment.CurrentDirectory + "\\My_Setting.xml";
        public static void ReadWriterSettingXml(bool isRead = false)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MySetting));
            if (!isRead)
            {
                TextWriter Filestream = new StreamWriter(path);
                serializer.Serialize(Filestream, Program.My_Setting);
                Filestream.Close();
            }
            else if (File.Exists(path))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        if (stream.Length > 0)
                            Program.My_Setting = (MySetting)serializer.Deserialize(stream);
                        stream.Close();
                    }
                }
                catch (Exception)
                {
                    File.Delete(path);
                    ReadWriterSettingXml(true);
                    return;
                }
            }
            else
            {

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                Program.My_Setting = new MySetting
                {
                    accConDt = DateTime.Now,
                    accConFlag = "",
                    accConVal = "",
                    ApplicationSkinName = "The Bezier",
                    ApplicationSkinPaletteBezier = "Twenty",
                    ApplicationSkinPaletteOffice = "Fire Brick",
                    compactMode = true,
                    DBName = "PosFinalCostDB",
                    defaultFyId = DateTime.Now.Year,
                    defaultUserName = "",
                    formSupplyMainH = 0,
                    formSupplyMainW = 0,
                    formSupplyWindState = FormWindowState.Maximized,
                    hideMenuCaption = true,
                    LangEng = false,
                    Mode = "Windows",
                    ribbonStyleSaleForm = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice,
                    ribbonStyleSaleRtrnForm = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice,
                    ServerName = ".",
                    ShowBarSideMenu = true,
                    showErrorMssg = false,
                    SqlPassword = "",
                    SqlUserName = "",
                    supplySaleExpanded = true,
                    SystemFont = converter.ConvertToString(WindowsFormsSettings.DefaultFont),
                    SystemFontSale = converter.ConvertToString(WindowsFormsSettings.DefaultFont),
                    touchScaleFactor = 2,
                    touchUI = false,
                    LogBranchID = 1,
                    AccDBName = "accounting",
                    AccServerName = "",
                    AccMode = "SQL",
                    AccSqlPassword = "",
                    AccSqlUserName = "",
                    UpDataFromDate = DateTime.Now,
                    UpDataToDate = DateTime.Now,
                    SendInvoToServerOnSave = false,
                    SendCustomerToServerOnSave = false,
                    SendPrdExpirToServerOnSave = false,
                    SendBoxDailyToServerOnSave = false,
                };
                ReadWriterSettingXml();
            }
        }


        public bool LangEng { get; set; }
        public string defaultUserName { get; set; }
        public int defaultFyId { get; set; }
        public short LogBranchID { get; set; }
        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string Mode { get; set; }
        public string SqlUserName { get; set; }
        public string SqlPassword { get; set; }

        public string AccServerName { get; set; }
        public string AccDBName { get; set; }
        public string AccMode { get; set; }
        public string AccSqlUserName { get; set; }
        public string AccSqlPassword { get; set; }

        public string accConFlag { get; set; }
        public string accConVal { get; set; }
        public DateTime accConDt { get; set; }
        public DateTime UpDataFromDate { get; set; }
        public DateTime UpDataToDate { get; set; }
        public string ApplicationSkinName { get; set; }
        public string ApplicationSkinPaletteBezier { get; set; }
        public string ApplicationSkinPaletteOffice { get; set; }

        public bool hideMenuCaption { get; set; }
        public bool compactMode { get; set; }
        public bool touchUI { get; set; }
        public float touchScaleFactor { get; set; }
        public string SystemFont { get; set; }
        public string SystemFontSale { get; set; }
        public bool ShowBarSideMenu { get; set; }
        public bool showErrorMssg { get; set; }
        public bool supplySaleExpanded { get; set; }
        public RibbonControlStyle ribbonStyleSaleForm { get; set; }
        public RibbonControlStyle ribbonStyleSaleRtrnForm { get; set; }
        public int formSupplyMainH { get; set; }
        public int formSupplyMainW { get; set; }
        public FormWindowState formSupplyWindState { get; set; }
        public bool SendInvoToServerOnSave { get; set; }
        public bool SendCustomerToServerOnSave { get; set; }
        public bool SendPrdExpirToServerOnSave { get; set; }
        public bool SendBoxDailyToServerOnSave { get; set; }
    }
}
