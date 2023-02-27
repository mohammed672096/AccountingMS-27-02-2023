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
    public class BarSetting
    {
        static string path = Environment.CurrentDirectory + "\\BarSetting.xml";
        public static BarSetting GetBarSetting = new BarSetting();
        public static void ReadBarSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BarSetting));
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        if (stream.Length > 0)
                           GetBarSetting = (BarSetting)serializer.Deserialize(stream);
                        stream.Close();
                    }
                }
                catch (Exception)
                {
                    File.Delete(path);
                    ReadBarSettingXml();
                    return;
                }
            }
            else
            {
                BarSetting.GetBarSetting = new BarSetting
                {
                    barcodeBarcodeNo = true,                              
                    barcodeCompanyName = true,
                    barcodeExpireDate = false,
                    barcodeHeight = 10F,
                    barcodePageWidth = 7F,
                    barcodePrdName = true,
                    barcodePrdPrice = false,
                    barcodeSymbology= (byte)DevExpress.BarCodes.Symbology.Code128,
                    barcodeWeightNo= 2,
                    barcodeWeightPrdNo=5,
                    barcodeWeightQuanNo=5,
                    barcodeWidth= 0.5F,
                    checkEditSaleTax=false
                };
                WriterBarSettingXml();
            }
        }
        public static void WriterBarSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BarSetting));
            TextWriter Filestream = new StreamWriter(path);
            serializer.Serialize(Filestream,GetBarSetting);
            Filestream.Close();
        }
        public float barcodeWidth { get; set; }
        public float barcodeHeight { get; set; }
        public bool barcodeExpireDate { get; set; }
        public byte barcodeSymbology { get; set; }
        public bool barcodePrdPrice { get; set; }
        public bool barcodeBarcodeNo { get; set; }
        public bool barcodeCompanyName { get; set; }
        public bool barcodePrdName { get; set; }
        public float barcodePageWidth { get; set; }
        public bool checkEditSaleTax { get; set; }
        public byte barcodeWeightNo { get; set; }
        public byte barcodeWeightPrdNo { get; set; }
        public byte barcodeWeightQuanNo { get; set; }
      
       
    }
}
