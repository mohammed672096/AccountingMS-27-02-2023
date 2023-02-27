using System;
using System.Windows.Forms;

namespace AccountingMS
{
    class ExceptionLogger
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public ExceptionLogger(Exception exception)
        {
            ClsThreadCulture.ChangeCultureEn();
            LogException(exception, null);
        }

        public ExceptionLogger(Exception exception, string logger)
        {
            ClsThreadCulture.ChangeCultureEn();
            ClsXtraMssgBox.ShowError(exception.Message);
            LogException(exception, logger);
            LogMailException(exception, logger);
        }

        public ExceptionLogger(Exception exception, string logger, bool isShowErrorMssg)
        {
            ClsThreadCulture.ChangeCultureEn();
            string errorLog = $"ErrorLoger: {logger} \nStartThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n ExceptionInnerException => {exception.InnerException} \n ExceptionMessage => {exception.Message} " +
                $"\n Exception.Source => {exception.Source} \n ExceptionStackTrace =>{exception.StackTrace} \n Exception.StackTrace.ToString() => {exception.StackTrace.ToString()} \n ExceptionToString =>{exception.ToString()} " +
                $"\n ExceptionTargetSite => {exception.TargetSite} \n BaseException() => {exception.GetBaseException()} \nEndThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n";

            log.Error(errorLog);

            ClsXtraMssgBox.ShowError($"عذراً حدث خطاء في تنفيذ العملة.\n\n{errorLog}");

            new ClsMailError().SendError($"{errorLog}");
        }

        private void LogException(Exception exception, string logger)
        {
            string errorLog = $"Error logger: {logger} \nStartThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n ExceptionInnerException => {exception.InnerException} \n ExceptionMessage => {exception.Message} " +
                $"\n Exception.Source => {exception.Source} \n ExceptionStackTrace =>{exception.StackTrace} \n Exception.StackTrace.ToString() => {exception.StackTrace.ToString()} \n ExceptionToString =>{exception.ToString()} " +
                $"\n ExceptionTargetSite => {exception.TargetSite} \n BaseException() => {exception.GetBaseException()} \nEndThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n";
            log.Error(errorLog);
            SendErrorMail(errorLog);
        }

        private void SendErrorMail(string errorLog)
        {
            string mssg = "عذرا حدث خطاء في تنفيذ العملية! يرجى مراجعة قسم الصيانة.";
            mssg += "\n\nيرجى التاكد من الوصول الى شبكة الإنترنت ليتم إرسال تقرير الخطاء وإصلاح المشكلة في اقرب وقت ممكن.";
            mssg += "\nهل تريد إرسال تقرير الخطاء؟";

            var dialogResult = ClsXtraMssgBox.ShowErrorYesNo(mssg);
            if (dialogResult == DialogResult.Yes)
                while (!CheckInternetConnection())
                    if (ClsXtraMssgBox.ShowErrorYesNo("يرجى التاكد من الوصول الى شبكة الإنترنت وإعادة المحاولة") != DialogResult.Yes) break;

            SetShowErrorNotification(dialogResult);
            new ClsMailError().SendError($"DialogResult: {dialogResult} \n\n{errorLog}");
            new ClsMailError(false).SendError($"DialogResult: {dialogResult} \n\n{errorLog}");
        }

        private void LogMailException(Exception exception, string logger)
        {
            string errorLog = $"ErrorLoger: {logger} \nStartThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n ExceptionInnerException => {exception.InnerException} \n ExceptionMessage => {exception.Message} " +
                $"\n Exception.Source => {exception.Source} \n ExceptionStackTrace =>{exception.StackTrace} \n Exception.StackTrace.ToString() => {exception.StackTrace.ToString()} \n ExceptionToString =>{exception.ToString()} " +
                $"\n ExceptionTargetSite => {exception.TargetSite} \n BaseException() => {exception.GetBaseException()} \nEndThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n";
            log.Error(errorLog);
            new ClsMailError().SendError($"{errorLog}");
        }


        private void SetShowErrorNotification(DialogResult dialogResult)
        {
            if (dialogResult == DialogResult.No) return;
            MySetting.GetPrivateSetting.showErrorMssg = true;
            MySetting.WriterSettingXml();
        }


        private bool CheckInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://google.com/generate_204")) return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
