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
    public partial class ReportHeader : XtraReport
    {
        public ReportHeader(string LabelReport)
        {
            InitializeComponent();
            BranchbindingSource.DataSource = Session.CurrentBranch;
            SetRTL();
            xrLabelReport.Text = LabelReport;
            
        }
        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
