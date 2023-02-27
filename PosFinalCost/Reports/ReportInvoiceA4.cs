using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using PosFinalCost.Classe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PosFinalCost
{
    public partial class ReportInvoiceA4 : XtraReport
    {
        public ReportInvoiceA4()
        {
            InitializeComponent();
            SetRTL();
            string path = ClsPath.GetPathReportCustomA4();
            CarBand.Visible= Session.CurrSettings.ShowlayoutControlCarData;
            if(Session.CurrSettings.UseRepInvoiceA4Custom&&File.Exists(path))
            this.LoadLayout(path);
        }
        private void SetRTL()
        {
            if (Program.My_Setting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
    }
}
