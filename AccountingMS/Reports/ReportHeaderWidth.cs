using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using AccountingMS.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportHeaderWidth : XtraReport
    {
        public ReportHeaderWidth(string LabelReport)
        {
            InitializeComponent();
            BranchbindingSource.DataSource = Session.CurBranch;
            SetRTL();
            xrLabelReport.Text = LabelReport;
            try
            {
                xrPictureBoxBranch.Image = new ClsTblBranchImg().GetBitmapLogImage();
            }
            catch (Exception)
            {
                return;
            }
        }
        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
