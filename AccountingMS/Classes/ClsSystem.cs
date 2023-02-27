using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace AccountingMS
{
    public class ClsSystem
    {
        MailAddress toMail;
        MailAddress fromMail;
        MailMessage mssg;
        SmtpClient smtpClient;

        public ClsSystem()
        {
            //if (MySetting.DefaultSetting.accountingConnectionFlag == 0) return;
            InitMail();
            InitSmtpClient();
            Send();
        }

        private void InitMail()
        {
            this.toMail = new MailAddress("btech.activatedsystems@gmail.com");
            this.fromMail = new MailAddress("btech.activatedsystems@gmail.com");
        }

        private void InitSmtpClient()
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.fromMail.Address, "2486519357"),
                Timeout = 20000
            };
        }

        private void Send()
        {
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            this.mssg = new MailMessage(this.fromMail, this.toMail)
            {
                Subject = $@"{Session.CurBranch.brnName} Activated",
                Body = $"{Session.CurBranch.brnName} \n" +
                       @$"DeviceName: {Environment.MachineName}\{Environment.UserName} {releaseId} activated" +
                       $"\nRunDate:\t {DateTime.Now:dddd dd/MM/yyyy HH:mm} \n" +
                       $"Version:\t   {ClsVersion.Current} \n" +
                       $"UserName:     {Session.CurrentUser.id}, {Session.CurrentUser.userName}",
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
