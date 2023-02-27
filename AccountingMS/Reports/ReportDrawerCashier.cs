using AccountingMS.Classes;
using DevExpress.XtraLayout.Resizing;
using DevExpress.XtraReports.UI;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Media.Animation;


namespace AccountingMS
{
    public partial class ReportDrawerCashier : XtraReport
    {
        public ReportDrawerCashier(DrawerPeriod drawer)
        {
            SetLanguage();
            InitializeComponent();
            this.DefaultPrinterSettingsUsing.UseMargins = false;
            SetRTL();
            InitBranchData();
            bindingSource1.DataSource = drawer;
        }

   
      
        private void xrTableCell16_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = new ClsTblUser().GetUserNameById(Convert.ToInt16(cell.Value));
        }

        private void InitBranchData()
        {
           xrLabelBranchName.Text = (!MySetting.GetPrivateSetting.LangEng) ? Session.CurBranch.brnName : Session.CurBranch.brnNameEn;
            if (MySetting.GetPrivateSetting.LangEng) xrLabelBranchName.Text += $"\n{Session.CurBranch.brnName}";

            xrLabelBranchAddress.Text += (!MySetting.GetPrivateSetting.LangEng) ? Session.CurBranch.brnAddress : Session.CurBranch.brnAddressEn;
            if (MySetting.GetPrivateSetting.LangEng) xrLabelBranchAddress.Text += $"\n{Session.CurBranch.brnAddress}";

            xrTableTaxNo.Text += Session.CurBranch.brnTaxNo;
            xrTableTradNo.Text += Session.CurBranch.brnTradeNo;
            xrPictureBoxBranch.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }

      
    }
}
