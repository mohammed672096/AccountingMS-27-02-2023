using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace AccountingMS
{
    class ClsMailError
    {
        MailAddress toMail;
        MailAddress fromMail;
        MailMessage mssg;
        SmtpClient smtpClient;

        public ClsMailError(bool isBtech = true)
        {
            InitMail(isBtech);
            InitSmtpClient();
        }

        private void InitMail(bool isBtech)
        {
            this.toMail = new MailAddress((isBtech) ? "btech.activatedsystems@gmail.com" : "futurecost.error@gmail.com");
            this.fromMail = new MailAddress((isBtech) ? "btech.activatedsystems@gmail.com" : "futurecost.error@gmail.com");
        }

        private void InitSmtpClient()
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.fromMail.Address, "2486519357"),
                Timeout = 60000
            };
        }

        protected internal void SendError(string mssg)
        {
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            this.mssg = new MailMessage(this.fromMail, this.toMail)
            {
                Subject = $@"{Session.CurBranch.brnName} Error",
                Body = $"{Session.CurBranch.brnName} \n" +
                       @$"DeviceName: {Environment.MachineName}\{Environment.UserName} {releaseId} activated" +
                       $"\nRunDate:\t {DateTime.Now:dddd dd/MM/yyyy HH:mm} \n" +
                       $"Version:\t   {ClsVersion.Current} \n" +
                       $"UserName:     {Session.CurrentUser.id}, {Session.CurrentUser.userName} \n\n" +
                       $"ErrorLog \n{mssg}",
            };
            new Thread(Mail).Start();
        }

        private void Mail()
        {
            try { this.smtpClient.Send(this.mssg); }
            catch (Exception) { return; }
        }
    }
}
