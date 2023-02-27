using System;
using System.IO;
using System.Xml.Serialization;
namespace AccountingMS
{
    public class ConnSetting
    {
        static string path = Environment.CurrentDirectory + "\\ConnSetting.xml";
        public static ConnSetting GetConnSetting = new ConnSetting();
        public static void ReadSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnSetting));
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        if (stream.Length > 0)
                            GetConnSetting = (ConnSetting)serializer.Deserialize(stream);
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
                GetConnSetting = new ConnSetting
                {
                    accountingConnectionDt = DateTime.Now,
                    accountingConnectionFlag = "",
                    accountingConnectionVal = "",
                    DBName = "accounting",
                    Mode = "Windows",
                    ServerName = ".",
                    SqlPassword = "",
                    SqlUserName = "",
                    AccDBName = "accounting",
                    AccServerName = "",
                    AccMode = "SQL",
                    AccSqlPassword = "",
                    AccSqlUserName = "",
                    UpDataFromDate = DateTime.Now,
                    UpDataToDate = DateTime.Now,
                    AutoUploadDataInMinit = 0,
                    AutoUploadDataToMain = false,
                    SendDataToServerOnSave=false
                };
                WriterSettingXml();
            }
        }
        public static void WriterSettingXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnSetting));
            TextWriter Filestream = new StreamWriter(path);
            serializer.Serialize(Filestream, GetConnSetting);
            Filestream.Close();
        }
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
        public int AutoUploadDataInMinit { get; set; }
        public DateTime UpDataFromDate { get; set; }
        public DateTime UpDataToDate { get; set; }
        public bool AutoUploadDataToMain { get; set; }
        public bool SendDataToServerOnSave { get; set; }
        public string accountingConnectionFlag { get; set; }
        public string accountingConnectionVal { get; set; }
        public DateTime accountingConnectionDt { get; set; }
    }
}
