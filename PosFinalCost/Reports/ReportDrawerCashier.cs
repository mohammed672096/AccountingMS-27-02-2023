using PosFinalCost.Classe;
using DevExpress.XtraLayout.Resizing;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Media.Animation;


namespace PosFinalCost
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
            var listDrawer = bindingSource1.List as IList<DrawerPeriod>;
            bindingSource1.DataSource = (from d in listDrawer
                                         select new
                                         {
                                             d.ActualBalance,
                                             d.AmountBank,
                                             d.ClosingBalance,
                                             d.BranchID,
                                             d.ClosingDrwerID,
                                             d.ClosingPeriodUserID,
                                             d.DrawerID,
                                             d.DifferenceAccountID,
                                             d.PeriodEnd,
                                             d.ID,
                                             d.OpeningBalance,
                                             d.PeriodStart,
                                             d.RemainingBalance,
                                             d.TransferdBalance,
                                             d.Status,
                                             d.SendToserver,
                                             d.PeriodUserID,
                                             Image=Session.CurrentBranch.Image
                                         }).ToList();
        }

   
        private void xrTableCell16_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = Session.UserTbls.FirstOrDefault(x=>x.ID==Convert.ToInt16(cell.Value))?.Name;
        }

        private void InitBranchData()
        {
           xrLabelBranchName.Text = (!Program.My_Setting.LangEng) ? Session.CurrentBranch.Name : Session.CurrentBranch.NameEn;
            if (Program.My_Setting.LangEng) xrLabelBranchName.Text += $"\n{Session.CurrentBranch.Name}";

            xrLabelBranchAddress.Text += (!Program.My_Setting.LangEng) ? Session.CurrentBranch.Address : Session.CurrentBranch.AddressEn;
            if (Program.My_Setting.LangEng) xrLabelBranchAddress.Text += $"\n{Session.CurrentBranch.Address}";

            xrTableTaxNo.Text += Session.CurrentBranch.TaxNo;
            xrTableTradNo.Text += Session.CurrentBranch.TradeNo;
          
        }

        private void SetLanguage()
        {
            if (!Program.My_Setting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
