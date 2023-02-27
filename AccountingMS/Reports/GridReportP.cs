using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using System.Linq;
using AccountingMS.Classes;
using System.Windows.Forms;

namespace AccountingMS.Reports
{
    public partial class GridReportP : XtraReport 
    {
        public GridReportP()
        {
            InitializeComponent();
            //LoadLayout();
            //objectDataSource1.DataSource   = new ReportModels.CompanyInfoReportModel();
            //SetCompanyInfo(objectDataSource1.DataSource as ReportModels.CompanyInfoReportModel);
            tblBranch branch = Session.CurBranch;
            objectDataSource2.DataSource = new tblBranchCustom
            {
                brnAddress = branch.brnAddress,
                brnEmail = branch.brnEmail,
                brnAddressEn = branch.brnAddressEn,
                brnFaxNo = branch.brnFaxNo,
                brnMailBox = branch.brnMailBox,
                brnName = branch.brnName,
                brnNameEn = branch.brnNameEn,
                brnNo = branch.brnNo,
                brnPhnNo = branch.brnPhnNo,
                brnTaxNo = branch.brnTaxNo,
                brnTradeNo = branch.brnTradeNo,
            };
        
        }

        public static void Print(GridControl gridControl1, string ReportName, string filter )
        {

            GridView view = gridControl1.MainView as GridView;
          
            Print((IBasePrintable)gridControl1, ReportName, filter);
        

        }
        public static XtraSaveFileDialog SaveFileDialog = new XtraSaveFileDialog();
        public static void Print(IBasePrintable printableComponent, string ReportName, string filter ,bool ShowInDialog = false,bool landScape=false ,PrintFileType printFile=PrintFileType.Printer)
        { 
            var g = (((GridControl)printableComponent).MainView as GridView);
            g.OptionsView.ShowViewCaption = false;
            g.OptionsView.RowAutoHeight = true;
            PrintableComponentLink pcLink1 = new PrintableComponentLink();
            
            pcLink1.Component = printableComponent;
            GridReportP rpt = new GridReportP();
            //rpt.LoadTemplete();
            rpt.printableComponentContainer1.PrintableComponent = pcLink1;

            rpt.Landscape = landScape;
            rpt.xrSubreport1.ReportSource = new ReportHeaderWidth("");
            rpt.Cell_ReportName.Text = ReportName;
            rpt.Cell_Filters.Text = filter;
          
            try
            {
                switch (printFile)
                {
                    case PrintFileType.Printer:
                        if (ShowInDialog)
                            rpt.ShowPreviewDialog();
                        else
                            rpt.ShowPreview();
                        break;
                    case PrintFileType.PDF:
                        SaveFileDialog.Filter = "PDF Files|*.pdf";
                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                            rpt.ExportToPdf(SaveFileDialog.FileName);
                        break;
                    case PrintFileType.Xlsx:
                        SaveFileDialog.Filter = "Excel Files|*.Xls";
                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                            rpt.ExportToXls(SaveFileDialog.FileName);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return ;
            }
          

        }
  
    }
}
