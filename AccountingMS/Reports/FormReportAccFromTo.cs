using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using System.Security.Principal;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Extensions;
using DevExpress.XtraLayout;
using DevExpress.ChartRangeControlClient.Core;
using System.Data.Entity;
using DevExpress.XtraGrid;
using AccountingMS.Classes;
using AccountingMS.Reports;

namespace AccountingMS.Report
{
    public partial class FormReportAccFromTo : DevExpress.XtraEditors.XtraForm
    {
        
        public FormReportAccFromTo()
        {
            InitializeComponent();
            MyFunaction.AppearanceGridView(gridView);
            MyFunaction.layoutAppearanceGroup(layoutControlGroup2);
            MyFunaction.layoutAppearanceGroup(layoutControlGroup4);
            //dataLayout.Items.Where(x => x is LayoutControlGroup).ToList().ForEach(x => MyFunaction.layoutAppearanceGroup((LayoutControlGroup)x));
            labelControl1.BackColor = gridView.Appearance.HeaderPanel.BackColor;
            //entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            //entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }

        ClsAppearance MyFunaction = new ClsAppearance();
        ReportAccountBillMaster ReportAccount;
        private void Print_Click(object sender, EventArgs e)
        {
            GridReportP.Print(gcInvoice, "كشف حساب", "", false, true);
            //RReportTypesFun();
            //Print(ReportAccount);
        }
        ReportForm frmReport;
        public void Print(DevExpress.XtraReports.UI.XtraReport Report)
        {
            frmReport.documentViewer1.DocumentSource = Report;
            frmReport.Show();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void RReportTypesFun()
        {
            //ReportAccount = new ReportAccountBillMaster((AllSelectAccountList.Count > 0) ? AllSelectAccountList : AllAccountList
            //    , (IList<tblAsset>)reportAssetBindingSource.List,dtime_Start.DateTime,dtime_End.DateTime);
            //frmReport = new ReportForm(ReportAccount);
        }
        private void ExportPDF_Click(object sender, EventArgs e)
        {
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "PDF Files|*.pdf";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                ReportAccount.ExportToPdf(xtraSaveFileDialog1.FileName);
        }

        private void Refreash_Click(object sender, EventArgs e)
        {
            ResetAllFilter();
            Refresh_Acc();
        }
        void ResetAllFilter()
        {
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
           
            AllAcc.EditValue=CustAcc.EditValue=SuppAcc.EditValue = null;
            AllAcc.Properties.View.ClearSelection();
            CustAcc.Properties.View.ClearSelection();
            SuppAcc.Properties.View.ClearSelection();
        }
        private void Dtime_Start_EditValueChanged(object sender, EventArgs e)
        {
            if(this.IsActive)
            Refresh_Acc();
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "Excel Files|*.Xls";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                ReportAccount.ExportToXls(xtraSaveFileDialog1.FileName);
        }
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        public List<tblAccount> AllAccountList = new List<tblAccount>();
        public List<tblAccount> AllSelectAccountList = new List<tblAccount>();
        public void Refresh_Acc()
        {
            flydDialog.WaitForm(this, 1);
            AllSelectAccountList.Clear();
            AllSelectAccountList = tbAccountList;
            AllSelectAccountList.AddRange(tbAccountListCust);
            AllSelectAccountList.AddRange(tbAccountList3);
            //RefreshData();
            using (accountingEntities db = new accountingEntities())
            {
                reportAssetBindingSource.DataSource = (from c in ((AllSelectAccountList.Count > 0) ? AllSelectAccountList : AllAccountList)
                                                       join a in db.tblAssets on c.accNo equals a.asAccNo
                                                       where a.asDate >= dtime_Start.DateTime && a.asDate <= dtime_End.DateTime
                                                       select new 
                                                       {
                                                           ID = a.id,
                                                           AccID = c.id,
                                                           BranchID = a.asBrnId,
                                                           Dain = a.asCredit,
                                                           Date = a.asDate,
                                                           DocID = a.asEntId,
                                                           DocType = a.asStatus,
                                                           Madin = a.asDebit,
                                                           Notes = a.asDesc,
                                                           UserID = a.asUserId,
                                                           DocNo = a.asEntNo,
                                                       }).AsQueryable();
            }
            flydDialog.WaitForm(this, 0,this);
        }
        public void InitClsGridLookUpEdit()
        {
            GridAllAcc.gridEdit.Closed += GridEdit_Closed;
            GridAllAcc.gridView.SelectionChanged += GridView_SelectionChanged;
            GridCustAcc.gridEdit.Closed += GridEditGridCustAcc_Closed;
            GridCustAcc.gridView.SelectionChanged += GridViewCust_SelectionChanged;
            GridSuppAcc.gridEdit.Closed += GridEdit3_Closed;
            GridSuppAcc.gridView.SelectionChanged += GridView3_SelectionChanged;
        }

        public List<tblAccount> tbAccountList = new List<tblAccount>();
        public List<tblAccount> tbAccountListCust = new List<tblAccount>();
        public List<tblAccount> tbAccountList3 = new List<tblAccount>();
        private void GridEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (this.tbAccountList.Count > 0)
                ((GridLookUpEdit)sender).EditValue = string.Join(", ", this.tbAccountList.Select(x => x.accName).ToList());
            else ((GridLookUpEdit)sender).EditValue = null;
            Refresh_Acc();
        }
        private void GridEditGridCustAcc_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (this.tbAccountListCust.Count > 0)
                ((GridLookUpEdit)sender).EditValue = string.Join(", ", this.tbAccountListCust.Select(x => x.accName).ToList());
            else ((GridLookUpEdit)sender).EditValue = null;
            Refresh_Acc();
        }
        private void GridEdit3_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (this.tbAccountList3.Count > 0)
                ((GridLookUpEdit)sender).EditValue = string.Join(", ", this.tbAccountList3.Select(x => x.accName).ToList());
            else ((GridLookUpEdit)sender).EditValue = null;
            Refresh_Acc();
        }
        private void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            this.tbAccountList = new List<tblAccount>();
            view.GetSelectedRows().ForEach(x => this.tbAccountList.Add(view.GetRow(x) as tblAccount));
        }
        private void GridViewCust_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            this.tbAccountListCust = new List<tblAccount>();
            view.GetSelectedRows().ForEach(x => this.tbAccountListCust.Add(view.GetRow(x) as tblAccount));
        }
        private void GridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            this.tbAccountList3 = new List<tblAccount>();
            view.GetSelectedRows().ForEach(x => this.tbAccountList3.Add(view.GetRow(x) as tblAccount));
        }
        ClsTblDefaultAccount defaultAccount = new ClsTblDefaultAccount();
        private void XtraFormAccountsFromTo_Load(object sender, EventArgs e)
        {
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
            AllAccountList = (from ac in Session.Accounts where ac.accType == 2 select ac).ToList();
            accountBindingSource.DataSource = AllAccountList;
            
            accountCusBindingSource.DataSource = AllAccountList.Where(x => x.ParentID == defaultAccount.GetCustomerAccNoId()).ToList();
            accountSupBindingSource.DataSource = AllAccountList.Where(x => x.ParentID == defaultAccount.GetDefaultAccIdByType(DefaultAccType.Supplier)).ToList();
        
            GridAllAcc = new ClsGridLookupEdit(AllAcc, "accNo", "accName", "الحساب");
            GridCustAcc = new ClsGridLookupEdit(CustAcc, "accNo", "accName", "الحساب");
            GridSuppAcc = new ClsGridLookupEdit(SuppAcc, "accNo", "accName", "الحساب");
            Refresh_Acc();
            repItemLookUpEditAccNameWithNo.DataSource=(from ac in Session.Accounts
             where ac.accType == 2
             select new { ID=ac.id, Number = ac.accNo, Name = ac.accNo + " - " + ac.accName }).ToList();
            InitClsGridLookUpEdit();
        }
        ClsGridLookupEdit GridAllAcc, GridCustAcc, GridSuppAcc;
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Value == null) return;
                if (e.Column.FieldName == colDocType.FieldName && e.Value is byte state)
                    e.DisplayText =ClsAssetStatus.GetString((AssetType)state);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}