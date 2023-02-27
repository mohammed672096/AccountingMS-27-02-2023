using System;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AccountingMS
{
    class ClsPrinterSettings
    {
        //public static string ConvertSettingToString(PrinterSettings printerSettings)
        //{
        //    if (printerSettings == null)
        //        return null;

        //    var bf = new BinaryFormatter();
        //    using (var ms = new MemoryStream())
        //    {
        //        bf.Serialize(ms, printerSettings);
        //        return Convert.ToBase64String(ms.ToArray());
        //    }
        //}

        //public static PrinterSettings RetriveSettingFromString(string printerSettings)
        //{
        //    try
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        using (var ms = new MemoryStream(Convert.FromBase64String(printerSettings)))
        //        {
        //            return (PrinterSettings)bf.Deserialize(ms);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new PrinterSettings();
        //    }
        //}
    }
}
