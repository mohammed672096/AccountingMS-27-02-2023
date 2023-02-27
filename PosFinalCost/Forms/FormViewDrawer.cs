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
using PosFinalCost.Classe;
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
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraReports.UI;
using PosFinalCost.Classe;
using PosFinalCost.Reports;

namespace PosFinalCost.Forms
{
    public partial class FormViewDrawer : DevExpress.XtraEditors.XtraForm
    {
       MyFunaction clsAppearance = new MyFunaction();
        public FormViewDrawer()
        {
            InitializeComponent();
            clsAppearance.AppearanceGridView(gridView);
            clsAppearance.LayoutAppearance(layoutControlGroup2);
            clsAppearance.LayoutAppearance(layoutControlGroup4);
            labelControl1.BackColor = layoutControlGroup4.AppearanceGroup.BorderColor;
            labelControl1.ForeColor = Color.White;
            gridView.RowClick += GridView_RowClick;
            gridView.RowStyle += GridView_RowStyle;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            dtime_Start.EditValue = Session.CurrentYear.DateStart;
            dtime_End.EditValue = Session.CurrentYear.DateEnd;
        }

        private void GridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //var row = gridView.GetRow(e.RowHandle) as DrawerPeriod;
            //FormMain formMain = new FormMain();
            //formMain.SetUserControl("barButtonCloseBoxDaily");
            //formMain.TopLevel = true;
        }

        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            var row = gridView.GetRow(e.RowHandle) as DrawerPeriod;
            if (row == null) return;
            if (row.Status == null || row.Status == false)
            //    e.Appearance.BackColor = Color.Green;
            //else
                e.Appearance.BackColor = Color.IndianRed;
            e.HighPriority = true;
        }
        DrawerPeriod drp=new DrawerPeriod();
        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) => e.RelationCount = 1;
        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e) => e.IsEmpty = false;
        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e) => e.RelationName = "Level1";
        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
            e.ChildList = db.SupplySubs.AsNoTracking().Where(x => x.ParentID == GetFoucsedSupplyMainId&& x.BrnId ==Session.CurrentBranch.ID).ToList();
        }
        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null|| e.ListSourceRowIndex<0) return;
            switch (e.Column.FieldName)
            {
                //case nameof(drp.DifferenceAccountID):
                //    if (e.Value is int acc)
                //        e.DisplayText = Session.Accounts?.FirstOrDefault(x => x.id == acc)?.accName;
                //    else e.DisplayText = "";
                //    break;
                case nameof(drp.DrawerID):
                case nameof(drp.ClosingDrwerID):
                    if (e.Value is short boxid)
                        e.DisplayText = Session.Boxes?.FirstOrDefault(x => x.ID == boxid)?.Name;
                    break;
                //case nameof(drp.supBankId) when (e.Value is short BankId):
                //    e.DisplayText = Session.Banks?.FirstOrDefault(x => x.id == BankId)?.bankName;
                //    break;
                case nameof(drp.PeriodUserID):
                case nameof(drp.ClosingPeriodUserID):
                    if (e.Value is short u)
                        e.DisplayText = Session.UserTbls?.FirstOrDefault(x => x.ID == u)?.Name;
                    break;
                case nameof(drp.BranchID) when (e.Value is short b):
                    e.DisplayText = Session.Branches?.FirstOrDefault(x => x.ID == b)?.Name;
                    break;
                default:
                    break;
            }
        }
      
        private void Print_Click(object sender, EventArgs e)
        {
            GridReportP.Print(gcDrawier, "قائمة يوميات الصناديق", "", false, true, PrintFileType.Printer);
        }
       
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
      
    public class totals
        {
            public Nullable<long> supAccNo { get; set; }
            public Nullable<double> totalPrdPrice { get; set; }
            public Nullable<double> totalPrdSalePrice { get; set; }
            public Nullable<double> totalDscntAmount { get; set; }
            public Nullable<double> totalTaxPrice { get; set; }
            public Nullable<double> totalFinal { get; set; }
            public Nullable<double> totalPaidCash { get; set; }
            public Nullable<double> totalPaidCredit { get; set; }
            public Nullable<double> totalPaidBank { get; set; }
            public Nullable<double> totalPrice { get; set; }
            public Nullable<double> totalProfit { get; set; }
        }
        private void ExportPDF_Click(object sender, EventArgs e)
        {
            GridReportP.Print(gcDrawier, "قائمة يوميات الصناديق", "",false,true,PrintFileType.PDF);
        }
        IQueryable<DrawerPeriod> AllSelectDrawerList;
        private void Refreash_Click(object sender, EventArgs e)
        {
            ResetAllFilter();
            Refresh_Acc();
        }
        void ResetAllFilter()
        {
            dtime_Start.EditValue = Session.CurrentYear.DateStart;
            dtime_End.EditValue = Session.CurrentYear.DateEnd;

            BankLookup.EditValue = BoxLookup.EditValue  =BranchLookup.EditValue = UserLookup.EditValue = null;
         
            UserLookupView.ClearSelection();
            BranchLookupView.ClearSelection();
            BoxLookupView.ClearSelection();
            BankLookupView.ClearSelection();
        }
        private void Dtime_Start_EditValueChanged(object sender, EventArgs e)
        {
            if(this.IsActive)
            Refresh_Acc();
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            GridReportP.Print(gcDrawier, "قائمة يوميات الصناديق", "", false, true, PrintFileType.Xlsx);
        }
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        public void Refresh_Acc()
        {
            flydDialog.WaitForm(this, 1);
            using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
            {
                AllSelectDrawerList = (from a in db.DrawerPeriods where a.PeriodStart >= dtime_Start.DateTime && a.PeriodStart <= dtime_End.DateTime select a).AsNoTracking().AsQueryable();
                if (BoxList.Count > 0)
                    AllSelectDrawerList = (from Box in BoxList join a in AllSelectDrawerList on Box.ID equals a.DrawerID select a).AsQueryable();
                //if (BankList.Count > 0)
                //    AllSelectDrawerList = (from Bank in BankList join a in AllSelectDrawerList on Bank.id equals a.supBankId select a).AsQueryable();
                if (Session.CurrentUser.ID != 1 && UserList.Count <= 0) UserList.Add(Session.CurrentUser);
                if (UserList.Count > 0)
                    AllSelectDrawerList = (from u in UserList join a in AllSelectDrawerList on u.ID equals a.PeriodUserID select a).AsQueryable();
                if (BranchList.Count > 0)
                    AllSelectDrawerList = (from u in BranchList join a in AllSelectDrawerList on u.ID equals a.BranchID select a).AsQueryable();
                drawerPeriodBindingSource.DataSource = AllSelectDrawerList.ToList();
            }
            flydDialog.WaitForm(this, 0,this);
        }
        public void InitClsGridLookUpEdit()
        {
            GridBox.gridEdit.Closed += GridEdit_Closed;
            GridBox.gridView.SelectionChanged += GridView_SelectionChanged;

            GridBank.gridEdit.Closed += GridEdit_Closed;
            GridBank.gridView.SelectionChanged += GridView_SelectionChanged;

            GridUser.gridEdit.Closed += GridEdit_Closed;
            GridUser.gridView.SelectionChanged += GridView_SelectionChanged;

        }

        public List<UserTbl> UserList = new List<UserTbl>();
        public List<Branch> BranchList = new List<Branch>();
        public List<Box> BoxList = new List<Box>();
        public List<Bank> BankList = new List<Bank>();
        public void GridEdit_Closed(object sender, ClosedEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            switch (gridLookUpEdit.Name)
            { 
                case "BoxLookup":
                    if (BoxList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BoxList.Select(x => x.Name).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BankLookup":
                    if (BankList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BankList.Select(x => x.Name).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "UserLookup":
                    if (UserList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", UserList.Select(x => x.Name).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BranchLookup":
                    if (BranchList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BranchList.Select(x => x.Name).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                default:
                    break;
            }
           
            Refresh_Acc();
        }
        public void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            switch (view.Name)
            {
                case "BoxLookupView":
                    BoxList = new List<Box>();
                    view.GetSelectedRows().ForEach(x => BoxList.Add(view.GetRow(x) as Box));
                    break;
                case "BankLookupView":
                    BankList = new List<Bank>();
                    view.GetSelectedRows().ForEach(x => BankList.Add(view.GetRow(x) as Bank));
                    break;
                case "UserLookupView":
                    UserList = new List<UserTbl>();
                    view.GetSelectedRows().ForEach(x => UserList.Add(view.GetRow(x) as UserTbl));
                    break;
                case "BranchLookupView":
                    BranchList = new List<Branch>();
                    view.GetSelectedRows().ForEach(x => BranchList.Add(view.GetRow(x) as Branch));
                    break;
                default:
                    break;
            }


        }

        private void XtraFormAccountsFromTo_Load(object sender, EventArgs e)
        {
            flydDialog.WaitForm(this, 1);
            bankBindingSource.DataSource = Session.Banks;
            boxBindingSource.DataSource = Session.Boxes;
            tblBranchBindingSource.DataSource = Session.Branches;
            if(Session.CurrentUser.ID!=1)
            userTblBindingSource.DataSource = Session.CurrentUser;
            else userTblBindingSource.DataSource = Session.UserTbls;
            GridBank = new ClsGridLookupEdit(BankLookup, "No", "Name", "البنك");
            GridUser = new ClsGridLookupEdit(UserLookup, "ID", "Name", "المستخدم");
            GridBranch = new ClsGridLookupEdit(BranchLookup, "ID", "Name", "الفرع");
            GridBox = new ClsGridLookupEdit(BoxLookup, "No", "Name", "الصندوق");
            flydDialog.WaitForm(this, 0,this);
            Refresh_Acc();
            InitClsGridLookUpEdit();
        }
        ClsGridLookupEdit GridBox, GridBank, GridUser, GridBranch;

        private void btnPrintCasher_Click(object sender, EventArgs e)
        {

        }
    }
}