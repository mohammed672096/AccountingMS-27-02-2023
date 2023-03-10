using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using System;
using System.Linq;

namespace AccountingMS.Reports
{
    public partial class InventoryBalanceingsReport : DevExpress.XtraReports.UI.XtraReport
    {
        private accountingEntities db = new accountingEntities();
        ClsTblProduct tblProduct = new ClsTblProduct();
        ClsTblPrdPriceMeasurment tblPrdPriceMeasurment = new ClsTblPrdPriceMeasurment();
        public InventoryBalanceingsReport()
        {
            InitializeComponent();
            this.ParametersRequestBeforeShow += InventoryBalanceingsReport_ParametersRequestBeforeShow;
            this.ParametersRequestSubmit += InventoryBalanceingsReport_ParametersRequestSubmit;
            this.tableCell9.BeforePrint += XrTableCell9_BeforePrint;
            this.tableCell10.BeforePrint += XrTableCell10_BeforePrint;
        }

        private void XrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cell = sender as DevExpress.XtraReports.UI.XRTableCell;
            if (cell == null) return;
            int id = 0;
            if (int.TryParse(cell.Text, out id))
                cell.Text = tblProduct.GetPrdNameById(id);
        }
        private void XrTableCell10_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cell = sender as DevExpress.XtraReports.UI.XRTableCell;
            if (cell == null) return;
            int id = 0;
            if (int.TryParse(cell.Text, out id))
                cell.Text = tblPrdPriceMeasurment.GetPrdPriceMsurNameById(id);
        }

        private void InventoryBalanceingsReport_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            xrLabel4.Text = xrLabel2.Text = xrLabel1.Text = xrLabel3.Text = "";
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "parameter1")
                {
                    GridLookUpEdit lookUpEdit = new GridLookUpEdit();
                    lookUpEdit.Properties.DataSource = db.InventoryBalanceings.Where(x => x.BranchID == Session.CurBranch.brnId).Select(x => new
                    {
                        x.ID,
                        x.Name
                    }).ToList();
                    lookUpEdit.Properties.DisplayMember = "Name";
                    lookUpEdit.Properties.ValueMember = "ID";
                    lookUpEdit.Properties.ValidateOnEnterKey = true;
                    lookUpEdit.Properties.ImmediatePopup = true;
                    lookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                    lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    lookUpEdit.Properties.View.Columns.AddRange(new GridColumn[]
                    {
                        new GridColumn {VisibleIndex=0,Visible=false, FieldName= "ID"},
                        new GridColumn {VisibleIndex=0,Visible=true, FieldName= "Name" ,Caption= (!MySetting.GetPrivateSetting.LangEng) ? "إسم الجرد" : "Name" }
                    });
                    var view = lookUpEdit.Properties.View;
                    view.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
                    view.OptionsSelection.UseIndicatorForSelection = true;
                    view.OptionsView.ShowAutoFilterRow = true;
                    view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

                    info.Editor = lookUpEdit;
                }
            }
        }
        private void InventoryBalanceingsReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            var parameter = Convert.ToInt64(parameter1.Value);
            this.DataSource = db.InventoryBalancingDetails.Where(x => x.MainID == parameter).ToList();
            var main = db.InventoryBalanceings.Find(parameter);
            xrLabel4.Text = main.Date.ToString();
            xrLabel2.Text = main.Name;
            xrLabel1.Text = main.EmployeeName;
            xrLabel3.Text = main.Notes;

            xrTableCell9.Text = main.TotalShortageValue.ToString("n2");
            xrTableCell12.Text = main.TotalSurplusValue.ToString("n2");
            xrTableCell15.Text = main.NetProfitOrLoses.ToString("n2");

            xrTableCell10.Text = main.TotalShortageValueSale.ToString("n2");
            xrTableCell13.Text = main.TotalSurplusValueSale.ToString("n2");
            xrTableCell16.Text = main.NetProfitOrLosesSale.ToString("n2");
        }
    }
}
