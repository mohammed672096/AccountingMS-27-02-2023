using AccountingMS.Properties;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
namespace AccountingMS
{
    public class MySetting
    {
        static string path = Environment.CurrentDirectory + "\\My_Setting.xml";
        //اعدادات النظام التي يستطيع العميل تعديلها من شاشة الاعدادات الافتراضية //
        //tblSetting وهي مخزنه في قاعدة البيانات في جدول اسمه 
        public static tblSetting DefaultSetting;
        public static void GetDatatblSetting()
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (!db.tblSettings.Any(x => x.MachineName == Environment.MachineName))
                    db.Database.ExecuteSqlCommand($"INSERT INTO tblSetting (MachineName) VALUES ('{Environment.MachineName}')");
                DefaultSetting = db.tblSettings?.FirstOrDefault(x => x.MachineName == Environment.MachineName);
            }
        }
        public static void WriterSettingPublic()
        {
            using (accountingEntities db = new accountingEntities())
            {
                db.tblSettings.Remove(db.tblSettings.FirstOrDefault(x=> DefaultSetting.ID==x.ID));
                db.tblSettings.Add(DefaultSetting);
                db.SaveChanges();
                DefaultSetting = db.tblSettings?.FirstOrDefault(x => x.ID == DefaultSetting.ID);
            }
        }
        //اعدادات النظام التي لا يتم تعديلها من شاشة الاعدادات الافتراضية //
        //My_Setting وهي مخزنه في ملف من نوع اكس ام ال موجود في ملفات البرنامج باسم 
        public static MySetting GetPrivateSetting = new MySetting();
        public static void WriterSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MySetting));
            TextWriter Filestream = new StreamWriter(path);
            serializer.Serialize(Filestream, GetPrivateSetting);
            Filestream.Close();
        }
        public static void ReadSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MySetting));
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        if (stream.Length > 0)
                            MySetting.GetPrivateSetting = (MySetting)serializer.Deserialize(stream);
                        stream.Close();
                    }
                }
                catch (Exception)
                {
                    File.Delete(path);
                    ReadSettingXml();
                    return;
                }
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                MySetting.GetPrivateSetting = new MySetting
                {
                    ApplicationSkinName = "The Bezier",
                    ApplicationSkinPaletteBezier = "Twenty",
                    ApplicationSkinPaletteOffice = "Fire Brick",
                    compactMode = true,
                    defaultFyId = 0,
                    defaultUserName = "",
                    formSupplyMainH = 0,
                    formSupplyMainW = 0,
                    formSupplyWindState = FormWindowState.Maximized,
                    hideMenuCaption = true,
                    LangEng = false,
                    ribbonStyleSaleForm = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice,
                    ribbonStyleSaleRtrnForm = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice,
                    ShowBarSideMenu = true,
                    showErrorMssg = false,
                    supplySaleExpanded = true,
                    SystemFont = converter.ConvertToString(WindowsFormsSettings.DefaultFont),
                    SystemFontSales = converter.ConvertToString(WindowsFormsSettings.DefaultFont),
                    touchScaleFactor = 2,
                    touchUI = false,
                    taxDefault = 15,
                    tmpBrnId = 0,
                    checkEditTax = true,
                    defaultBrnId = 0,
                    drive = "C",
                    entryReceiptTax = false,
                    entryTax = false,
                    entryVoucherTax = false,
                    formAddCustomerH = 720,
                    formAddCustomerW = 900,
                    formAddProductH = 720,
                    formAddProductW = 900,
                    prdPriceTax = false,
                    restartForm = false,
                    supplyPurchaseExpanded = true,
                    supPrdLastPrice = false,
                    tmpBrnName = "",
                    tmpFyId = 0,
                    tmpRoleId = 0,
                    tmpUsrId = 0,
                    tmpUsrName = "",
                    bbiCustomerSLEH=0,
                    bbiCustomerSLEW=0,
                    
                };
                WriterSettingXml();
            }
        }
        public bool supplyPurchaseExpanded { get; set; }
        public bool compactMode { get; set; }
        public bool supplySaleExpanded { get; set; }
        public bool touchUI { get; set; }
        public int formSupplyMainW { get; set; }
        public int bbiCustomerSLEH { get; set; }
        public int bbiCustomerSLEW { get; set; }
        public int formSupplyMainH { get; set; }
        public FormWindowState formSupplyWindState { get; set; }
        public int formAddCustomerW { get; set; }
        public int formAddCustomerH { get; set; }
        public int formAddProductH { get; set; }
        public int formAddProductW { get; set; }
        public string ApplicationSkinName { get; set; }
        public string ApplicationSkinPaletteBezier { get; set; }
        public string ApplicationSkinPaletteOffice { get; set; }
        public float touchScaleFactor { get; set; }
        public string SystemFont { get; set; }
        public string SystemFontSales { get; set; }
        public RibbonControlStyle ribbonStyleSaleForm { get; set; }
        public RibbonControlStyle ribbonStyleSaleRtrnForm { get; set; }
        public bool hideMenuCaption { get; set; }
        public bool restartForm { get; set; }
        public bool ShowBarSideMenu { get; set; }

        public bool LangEng { get; set; }
        public byte taxDefault { get; set; }
        public bool supPrdLastPrice { get; set; }
        public bool prdPriceTax { get; set; }
        public bool checkEditTax { get; set; }
        public string defaultUserName { get; set; }
        public string drive { get; set; }
        public bool showErrorMssg { get; set; }
        public bool entryVoucherTax { get; set; }
        public bool entryReceiptTax { get; set; }
        public bool entryTax { get; set; }
        public int defaultFyId { get; set; }
        public short defaultBrnId { get; set; }
        public short tmpRoleId { get; set; }
        public short tmpBrnId { get; set; }
        public short tmpUsrId { get; set; }
        public string tmpUsrName { get; set; }
        public string tmpBrnName { get; set; }
        public short tmpFyId { get; set; }
        public DateTime tmpFyDtStart { get; set; }
        public DateTime tmpFyDtEnd { get; set; }
    }
   
}
