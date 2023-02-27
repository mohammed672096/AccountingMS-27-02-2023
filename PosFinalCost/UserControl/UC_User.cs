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
using DevExpress.XtraEditors.DXErrorProvider;
using Microsoft.Win32;

namespace PosFinalCost
{
    public partial class UC_User : UC_Master
    {
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        PosDBDataContext db;
        public UC_User()
        {
            InitializeComponent();
            bindingNavigator11.BindingSource = tblUserBindingSource;
            InitData();
            btnAddNew.Visible = false;
            btnDelete.Visible = false;
            btnReset.Visible = false;
            EnableAndDisyable(false);
            new ClsUserRoleValidation(this, UserControls.LinkingUserPermissions);
            gridControlBranch.Load += GridControlBranch_Load;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView1.SelectionChanged += GridView1_SelectionChanged;
        }
        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.ControllerRow) as Branch;
            if (row == null) return;
            bool found = db.UserBranchTbls.Any(x => x.BrnId == row.ID && x.UserId == userTbl.ID);
            if (!found && e.Action == CollectionChangeAction.Add)
                db.UserBranchTbls.InsertOnSubmit(new UserBranchTbl { BrnId = row.ID, UserId = userTbl.ID });
            else if (e.Action == CollectionChangeAction.Remove && found)
                db.UserBranchTbls.DeleteAllOnSubmit(db.UserBranchTbls.Where(x => x.BrnId == row.ID && x.UserId == userTbl.ID));
            var insert=db.GetChangeSet().Inserts;

        }
        public override void Save()
        {
            flyDailog.WaitForm(this, 1);
            userTbl = tblUserBindingSource.Current as UserTbl;
            tblUserBindingSource.EndEdit();
            if (!ValidateBranchGrid()) return;
            db.SubmitChanges();
            Session.GetDataUserTbls(db);
            EnableAndDisyable(false);
            flyDailog.WaitForm(this, 0);
            string mssg = $"صلاحيات فروع المستخدم: {userTbl.Name}";
            flyDailog.ShowDialogUC(this, mssg);
            base.Save();
        }
        private void EnableAndDisyable(bool Enable)
        {
            colUsSettProfID.OptionsColumn.AllowEdit = Enable;
            colRoleID.OptionsColumn.AllowEdit = Enable;
            layoutControlForGridBranch.Enabled = Enable;
        }
        public override void Print()
        {
            dataLayoutControl2.ShowPrintPreview();
            base.Print();   
        }
        public override void DataUpdate()
        {
            EnableAndDisyable(true);
            base.DataUpdate();  
        }
        ClsUserTblControl clsTbUserControl=new ClsUserTblControl();
        private void InitData()
        {
            db = new PosDBDataContext(Program.ConnectionString);
            tblRoleBindingSource.DataSource = db.RoleTbls.ToList();
            tblUserBindingSource.DataSource = db.UserTbls.Where(x => x.ID != 1).ToList();
            branchBindingSource.DataSource = db.Branches.ToList();
            userSettingsProfileBindingSource.DataSource = db.UserSettingsProfiles;
            SetUserBranhcData(); }
        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            userTbl = tblUserBindingSource.Current as UserTbl;
            SetUserBranhcData();
        }
        private void GridControlBranch_Load(object sender, EventArgs e)
        {
            SetUserBranhcData();
        }
        UserTbl userTbl;
        private void SetUserBranhcData()
        {
            layoutControlGroup4.Text = $"صلاحيات الفروع للمستخدم ({userTbl?.Name})";
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (db.UserBranchTbls.Any(x => x.UserId == userTbl.ID && x.BrnId == Convert.ToInt16(gridView1.GetRowCellValue(i, colbrnId))))
                    gridView1.SelectRow(i);
                else
                    gridView1.UnselectRow(i);
            }
        }

        private bool ValidateBranchGrid()
        {
            bool isValid = gridView1.GetSelectedRows().Count() >= 1 ? true : false;

            if (!isValid) ClsXtraMssgBox.ShowError("عذراَ يجب إختيار صلاحيات الفروع للمستخدم أولاً");

            return isValid;
        }

        private void repositoryItemLookUpEditUsSettProf_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            userTbl = tblUserBindingSource.Current as UserTbl;
            if (userTbl == null) return;
            userTbl.UsSettProfID=e.NewValue as int?;
        }

        private void repositoryItemLookUpEditRoleID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            userTbl = tblUserBindingSource.Current as UserTbl;
            if (userTbl == null) return;
            userTbl.RoleID = e.NewValue as short?;
        }
    }
}
