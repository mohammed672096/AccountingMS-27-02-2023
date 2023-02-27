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
using AccountingMS.Classes;
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
using AccountingMS.Reports;
using System.Collections.ObjectModel;

namespace AccountingMS.Forms
{
    public partial class FormViewDrawer : DevExpress.XtraEditors.XtraForm
    {
        ClsAppearance clsAppearance = new ClsAppearance();
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
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
            radioGroupTarhil.Properties.Items.AddRange((from s in ClsSupplyStatus.TarhilsList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            
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
            using (accountingEntities db = new accountingEntities())
            e.ChildList = db.tblSupplySubs.AsNoTracking().Where(x => x.supNo == GetFoucsedSupplyMainId&& x.supBrnId ==Session.CurBranch.brnId).ToList();
        }
        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null|| e.ListSourceRowIndex<0) return;
            switch (e.Column.FieldName)
            {
                case nameof(drp.DifferenceAccountID):
                    if (e.Value is int acc)
                        e.DisplayText = Session.Accounts?.FirstOrDefault(x => x.id == acc)?.accName;
                    else e.DisplayText = "";
                    break;
                case nameof(drp.DrawerID):
                case nameof(drp.ClosingDrwerID):
                    if (e.Value is short boxid)
                        e.DisplayText = Session.Boxes?.FirstOrDefault(x => x.id == boxid)?.boxName;
                    break;
                //case nameof(drp.supBankId) when (e.Value is short BankId):
                //    e.DisplayText = Session.Banks?.FirstOrDefault(x => x.id == BankId)?.bankName;
                //    break;
                case nameof(drp.PeriodUserID):
                case nameof(drp.ClosingPeriodUserID):
                    if (e.Value is short u)
                        e.DisplayText = Session.tblUser?.FirstOrDefault(x => x.id == u)?.userName;
                    break;
                case nameof(drp.BranchID) when (e.Value is short b):
                    e.DisplayText = Session.Branches?.FirstOrDefault(x => x.brnId == b)?.brnName;
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
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
            BoxLookup.EditValue  =BranchLookup.EditValue = UserLookup.EditValue = null;
         
            UserLookupView.ClearSelection();
            BranchLookupView.ClearSelection();
            BoxLookupView.ClearSelection();
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
            using (accountingEntities db = new accountingEntities())
            {
                AllSelectDrawerList = (from a in db.DrawerPeriods where a.PeriodStart >= dtime_Start.DateTime && a.PeriodStart <= dtime_End.DateTime select a).AsNoTracking().AsQueryable();
                if (radioGroupTarhil.EditValue is byte t && t==1)
                    AllSelectDrawerList = (from a in AllSelectDrawerList where a.IsTarhil select a).AsQueryable();
                if (radioGroupTarhil.EditValue is byte t2 && t2 == 2)
                    AllSelectDrawerList = (from a in AllSelectDrawerList where !a.IsTarhil select a).AsQueryable();
                if (BoxList.Count > 0)
                    AllSelectDrawerList = (from tblAccountBox in BoxList join a in AllSelectDrawerList on tblAccountBox.id equals a.DrawerID select a).AsQueryable();
                if (Session.CurrentUser.id != 1 && UserList.Count <= 0) UserList.Add(Session.CurrentUser);
                if (UserList.Count > 0)
                    AllSelectDrawerList = (from u in UserList join a in AllSelectDrawerList on u.id equals a.PeriodUserID select a).AsQueryable();
                if (BranchList.Count > 0)
                    AllSelectDrawerList = (from u in BranchList join a in AllSelectDrawerList on u.brnId equals a.BranchID select a).AsQueryable();
                drawerPeriodBindingSource.DataSource = AllSelectDrawerList.ToList();
            }
            flydDialog.WaitForm(this, 0,this);
        }
        public void InitClsGridLookUpEdit()
        {
            GridBox.gridEdit.Closed += GridEdit_Closed;
            GridBox.gridView.SelectionChanged += GridView_SelectionChanged;

            GridUser.gridEdit.Closed += GridEdit_Closed;
            GridUser.gridView.SelectionChanged += GridView_SelectionChanged;
        }

        public List<tblUser> UserList = new List<tblUser>();
        public List<tblBranch> BranchList = new List<tblBranch>();
        public List<tblAccountBox> BoxList = new List<tblAccountBox>();
        public void GridEdit_Closed(object sender, ClosedEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            switch (gridLookUpEdit.Name)
            { 
                case "BoxLookup":
                    if (BoxList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BoxList.Select(x => x.boxName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "UserLookup":
                    if (UserList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", UserList.Select(x => x.userName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BranchLookup":
                    if (BranchList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BranchList.Select(x => x.brnName).ToList());
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
                    BoxList = new List<tblAccountBox>();
                    view.GetSelectedRows().ForEach(x => BoxList.Add(view.GetRow(x) as tblAccountBox));
                    break;
                case "UserLookupView":
                    UserList = new List<tblUser>();
                    view.GetSelectedRows().ForEach(x => UserList.Add(view.GetRow(x) as tblUser));
                    break;
                case "BranchLookupView":
                    BranchList = new List<tblBranch>();
                    view.GetSelectedRows().ForEach(x => BranchList.Add(view.GetRow(x) as tblBranch));
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
            if(Session.CurrentUser.id!=1)
            userTblBindingSource.DataSource = Session.CurrentUser;
            else userTblBindingSource.DataSource = Session.tblUser;
            GroupStrBindingSource.DataSource=Session.tblGroupStr;
            
            GridUser = new ClsGridLookupEdit(UserLookup, "id", "userName", "المستخدم");
            GridBranch = new ClsGridLookupEdit(BranchLookup, "brnId", "brnName", "الفرع");
            GridBox = new ClsGridLookupEdit(BoxLookup, "boxNo", "boxName", "الصندوق");
            flydDialog.WaitForm(this, 0,this);
            Refresh_Acc();
            InitClsGridLookUpEdit();
            //radioGroupTarhil.EditValue = 3;
        }
        ClsGridLookupEdit GridBox, GridUser, GridBranch;

        private async void btnPheased_Click(object sender, EventArgs e)
        {
            if (gridView?.DataRowCount >= 1)
            await PhaseDataAsync();
        }
        private async Task PhaseDataAsync()
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل انت متاكد من ترحيل يوميات الصناديق؟") != DialogResult.Yes) return;
            flydDialog.WaitForm(this, 1);
            ClsDrawerPeriodTarhel clsDrawerPeriod = new ClsDrawerPeriodTarhel();
            ICollection<DrawerPeriod> tbDrawerPeriod = new Collection<DrawerPeriod>();
            for (short i = 0; i < gridView.SelectedRowsCount; i++)
                tbDrawerPeriod.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as DrawerPeriod);
            if (tbDrawerPeriod.Count == 0)
            {
                flydDialog.WaitForm(this, 0);
                return;
            }
            bool isSaved = await Task.Run(() => clsDrawerPeriod.PhaseDrawerPeriod(tbDrawerPeriod));
            flydDialog.WaitForm(this, 0);
            if (isSaved)
            {
                flydDialog.ShowDialogFormCustomMsg(this, "تم ترحيل يوميات الصناديق بنجاح");
                Refresh_Acc();
            }
            gridView.OptionsSelection.MultiSelect = false;
            if (clsDrawerPeriod.errorListTarhel.Count > 0)
            {
                if (tbDrawerPeriod.Count() == 1 || clsDrawerPeriod.errorListTarhel.Count == 1)
                {
                    string mssg = $"عذراً لم يتم ترحيل يومية الصندوق .\n";
                    clsDrawerPeriod.errorListTarhel.ForEach(x => mssg += x.Error + "\n\n");
                    XtraMessageBox.Show(mssg);
                }
                else if (tbDrawerPeriod.Count() > 1 && clsDrawerPeriod.errorListTarhel.Count > 1)
                {
                    if (DialogResult.Yes == ClsXtraMssgBox.ShowWarningYesNo("لم يتم ترحيل بعض يوميات الصناديق !!! \n هل تريد عرض اليوميات غير المرحله لمعرفة لماذا لم يتم ترحيلها؟"))
                    {
                        string mssg = $"عذراً لم يتم ترحيل يوميات الصناديق التالية .\n";
                        XtraForm xtraDialogForm = new XtraForm() { Width = this.Width / 2, Height = this.Height / 2, RightToLeft = System.Windows.Forms.RightToLeft.Yes, RightToLeftLayout = true };
                        xtraDialogForm.Text = mssg;
                        xtraDialogForm.StartPosition = FormStartPosition.CenterScreen;
                        GridControl gridControl = new GridControl() { Dock = DockStyle.Fill, DataSource = clsDrawerPeriod.errorListTarhel };
                        gridControl.Load += GridControl_Load;
                        xtraDialogForm.Controls.Add(gridControl);
                        xtraDialogForm.ShowDialog();
                    }
                }
            }
        }
        private void GridControl_Load(object sender, EventArgs e)
        {
            ((GridView)((GridControl)sender).MainView).OptionsBehavior.Editable = false;
            ((GridView)((GridControl)sender).MainView).Columns[0].Width = 100;
            ((GridView)((GridControl)sender).MainView).Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            ((GridView)((GridControl)sender).MainView).Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

        }

        private void btnUnPheased_Click(object sender, EventArgs e)
        {
            if (gridView?.DataRowCount >= 1)
                UndoPhase();
        }
        private void UndoPhase()
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل انت متاكد من الغاء ترحيل يوميات الصناديق المحدده؟") != DialogResult.Yes) return;
            flydDialog.WaitForm(this, 1);
            ICollection<DrawerPeriod> tbDrawerPeriodList = new Collection<DrawerPeriod>();
            for (short i = 0; i < gridView.SelectedRowsCount; i++)
                tbDrawerPeriodList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as DrawerPeriod);
            if (tbDrawerPeriodList.Count == 0)
            {
                flydDialog.WaitForm(this, 0);
                return;
            }
            if (new ClsDrawerPeriodTarhel().UndoPhaseDrawerPeriod(tbDrawerPeriodList))
            {
                flydDialog.WaitForm(this, 0);
                flydDialog.ShowDialogFormCustomMsg(this,"تم الغاء ترحيل يوميات الصناديق بنجاح");
                Refresh_Acc();
            }
            else flydDialog.WaitForm(this, 0);
            gridView.OptionsSelection.MultiSelect = false;
        }

        private void btnPrintCasher_Click(object sender, EventArgs e)
        {
            ReportDrawerCashier rep = new ReportDrawerCashier(gridView.GetFocusedRow() as DrawerPeriod);
            rep.RequestParameters = false;
            new ReportForm(rep, "يومية صندوق كاشير").ShowDialog();
        }

        private void btnShowUnPheased_Click(object sender, EventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private void radioGroupTarhil_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroupTarhil.EditValue == null) return;
            if (radioGroupTarhil.EditValue is byte t&&t>0)
            {
                switch ((PhasedState)t)
                {
                    case PhasedState.Phased:
                        btnShowUnPheased.Text = MySetting.GetPrivateSetting.LangEng ? "Show UnPheased" : "عرض الغاء الترحيل";
                        ItemForShowUnPheased.Enabled=ItemForUnPheased.Enabled = true;
                        ItemForPheased.Enabled = false;
                        break;
                    case PhasedState.unPhased:
                        btnShowUnPheased.Text = MySetting.GetPrivateSetting.LangEng ? "Show Pheased" : "عرض الترحيل";
                        ItemForShowUnPheased.Enabled = ItemForPheased.Enabled = true;
                        ItemForUnPheased.Enabled = false;
                        break;
                    case PhasedState.All:
                        ItemForShowUnPheased.Enabled = ItemForPheased.Enabled = ItemForUnPheased.Enabled = false;
                        break;
                    default:
                        break;
                }
                Refresh_Acc();
            }
        }
    }
}