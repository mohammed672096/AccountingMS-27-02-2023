using System.Runtime.CompilerServices;

namespace AccountingMS
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            log4net.GlobalContext.Properties["LogFile"] = ClsDrive.LogPatth;
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
