using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PosFinalCost.Classe;
using PosFinalCost.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Data;
namespace PosFinalCost
{
    public partial class UCuserRight :UC_Master
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        ClsUserTblControl clsTbUserControl=new ClsUserTblControl();
        //private readonly FormMain _formMain;
        private string flyDailogMssg;
        //private bool isNew;
        private short roleId;
        PosDBDataContext db;
        public UCuserRight()
        {
            //_formMain = formMain;
            InitializeComponent();
            btnUpdatePermission.Visible = true;
            btnUpdatePermission.Enabled = true;
            bindingNavigator11.BindingSource = tblRoleBindingSource;
            GetResources();
            InitData();
            new ClsUserRoleValidation(this, UserControls.PermissionManagement);
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridControl4.Load += GridControl4_Load;
            gridViewM.MasterRowExpanded += GridViewM_MasterRowExpanded;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        public override void Save()
        {
            if (!dxValidationProvider1.Validate()) return;
            string mssg = (IsNew) ? "تم حفظ الصلاحية: " : "تم تعديل بيانات الصلاحية: ";
            mssg += RolNameTextEdit.Text + " بنجاح.";
            gridViewM.Focus();
            tblRoleBindingSource.EndEdit();
            if (IsNew)
                db.RoleTbls.InsertOnSubmit(tblRoleBindingSource.Current as RoleTbl);
            db.SubmitChanges();
            Session.RefreshAllDataForPermission(db);
            flyDailog.ShowDialogUCCustomdMsg(this, mssg);
            Reset();
            InitData();
            GetUserRolePermision();
            base.Save();
        }
        public override void New()
        {
            layoutControlGroupRole.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            base.New();
        }
        public override void Delete()
        {
            RoleTbl name = tblRoleBindingSource.Current as RoleTbl;
            if (name != null)
                if (XtraMessageBox.Show($"هل أنت متاكد من حذف الصلاحية: {name.Name}", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.RoleTbls.DeleteOnSubmit(name);
                    db.SubmitChanges();
                    tblRoleBindingSource.RemoveCurrent();
                    flyDailog.ShowDialogUCCustomdMsg(this, "تم حذف الصلاحية: " + name.Name + " بنجاح.");
                }
            base.Delete();  
        }
        public override void DataUpdate()
        {
            IsNew = false;
            layoutControlGroupRole.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            base.DataUpdate();
        }
        public override void UpdatePermissionUser()
        {
            IsNew = false;
            layoutControlGridUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGridView.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            base.UpdatePermissionUser();
        }

        public override void Refresh()
        {
            base.Refresh();
        }
        public override void Print()
        {
            dataLayoutControl1.ShowPrintPreview();
            base.Print();   
        }
        private void GridViewD_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var row = ((GridView)sender).GetRow(e.ControllerRow) as ControlTbl;
            if (row == null) return;
            bool found = db.RoleControlTbls.Any(x => x.No == row.No && x.ControlId == row.ID && x.RoleId == this.roleId);
            if (!found && e.Action==CollectionChangeAction.Add)
                db.RoleControlTbls.InsertOnSubmit(new RoleControlTbl { RoleId = roleId, ControlId = row.ID, No = row.No });
            else if(e.Action==CollectionChangeAction.Remove&& found)
                db.RoleControlTbls.DeleteAllOnSubmit(db.RoleControlTbls.Where(x=>x.RoleId== roleId&&x.ControlId==row.ID&&x.No==row.No));
        }
        public override void Reset()
        {
            IsNew = false;
            layoutControlGroupRole.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGridUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGridView.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            InitData();
            base.Reset();
        }
        private void GridControl4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewM.RowCount; i++)
            {
                gridViewM.SetMasterRowExpanded(i, false);
                gridViewM.SetMasterRowExpanded(i, true);
            }
        }

        private void GridViewM_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            gg = gridViewM.GetDetailView(e.RowHandle, 0) as GridView;
            if (gg == null) return;
            for (int y = 0; y < gg.RowCount; y++)
            {
                var row = gg.GetRow(y) as ControlTbl;
                if (row == null) continue;
                if (db.RoleControlTbls.Any(x => x.No == row.No && x.ControlId == row.ID && x.RoleId == this.roleId))
                    gg.SelectRow(y);
            }
            gg.SelectionChanged += GridViewD_SelectionChanged;
         
        }
        private void InitData()
        {
            db = new PosDBDataContext(Program.ConnectionString);
            tblRoleBindingSource.DataSource = db.RoleTbls;
            //bsiRecordsCount.Caption = "RECORDS : " + tblRoleBindingSource.Count;
            userControlTblBindingSource.DataSource = db.UserControlTbls.ToList();
            controlDataBindingSource.DataSource = db.ControlDatas.ToList();
        }
        GridView gg;
        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.roleId = Convert.ToInt16(gridView.GetFocusedRowCellValue(colrolId));
            GetUserRolePermision();
            GridControl4_Load(null,null);
        }

        private void GetUserRolePermision()
        {
            RoleControlTblBindingSource.DataSource =db.RoleControlTbls.Where(x => x.RoleId == roleId);
            tblUserBindingSource.DataSource = db.UserTbls.Where(x=>x.RoleID==roleId);
        }
        
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colfkRoleId.FieldName)
                e.DisplayText = this.clsTbUserControl.GetRoleName(Convert.ToInt16(e.Value));
            else if (e.Column.FieldName == colfkucNo.FieldName)
                e.DisplayText = this.clsTbUserControl.GetUserControlNameByNo(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == colfkControlId.FieldName)
                e.DisplayText = this.clsTbUserControl.GetControlCaptionById(Convert.ToInt16(e.Value));
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            InitData();
            flyDailog.WaitForm(this, 0);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        public void CloseFlydDailod()
        {
            flyDailog.WaitForm(this, 0);
        }

        public void RefreshListDialog()
        {
            flyDailog.ShowDialogUCCustomdMsg(this, this.flyDailogMssg);
            InitData();
            GetUserRolePermision();
        }

        public void SetRefreshListDialog(string mssg)
        {
            this.flyDailogMssg = mssg;
        }

        private void GetResources()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCuserRightEn));
            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView2.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
        }

     
    }
}
