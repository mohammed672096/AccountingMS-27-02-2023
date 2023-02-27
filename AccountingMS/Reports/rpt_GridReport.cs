using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS.Reports
{
    public partial class rpt_GridReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_GridReport()
        {
            InitializeComponent();
        }
        public static void Print(GridControl gridControl1, string ReportName, string filter, bool rtll)
        {

            GridView view = gridControl1.MainView as GridView;



            PrintableComponentLink pcLink1 = new PrintableComponentLink();
            pcLink1.Component = gridControl1;
            rpt_GridReport rpt = new rpt_GridReport();


            rpt.printableComponentContainer1.PrintableComponent = pcLink1;
            try
            {
                //   rpt.xrPictureBox1.Image = MasterClass.GetImageFromByte(CurrentSession.Company.Imge.ToArray());
            }
            catch (Exception)
            {
            }

            rpt.lbl_filter.Text = filter;
            rpt.lbl_PrinDate.Text = DateTime.Now.ToString();
            //  rpt.lbl_UserName.Text = CurrentSession.user.UserName;

            rpt.lbl_PrinDate.Text = DateTime.Now.ToString();
            // rpt.lbl_UserName.Text = CurrentSession.user.UserName;
            //  rpt.lbl_companyName.Text = CurrentSession.Company.CombanyName; 
            if (rtll)
            {
                rpt.RightToLeft = RightToLeft.Yes;
                rpt.RightToLeftLayout = RightToLeftLayout.Yes;
            }
            rpt.lbl_rptName.Text = ReportName;
            rpt.ShowRibbonPreview();
        }
    }
}
