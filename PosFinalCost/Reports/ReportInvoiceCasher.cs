//using PosFinalCost.Classes;
using DevExpress.XtraLayout.Resizing;
using DevExpress.XtraReports.UI;
using PosFinalCost.Classe;
//using Microsoft.SqlServer.Management.Smo;
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
    public partial class ReportInvoiceCasher : XtraReport
    {
        public ReportInvoiceCasher(bool Defulte=false)
        {
            SetRTL();
            InitializeComponent();
            if (!Defulte)
            {
                string path = ClsPath.GetPathReportCustomCasher();
                if (Session.CurrSettings.UseRepInvoiceCasherCustom && File.Exists(path))
                    this.LoadLayout(path);
            }
            DetailReport.DataSource=SupplySubBindingSource;
        }
        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
