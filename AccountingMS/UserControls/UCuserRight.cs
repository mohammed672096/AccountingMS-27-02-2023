using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCuserRight : DevExpress.XtraEditors.XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        ClsTblUser clsTbUser;
        ClsTblRole clsTbRole;
        ClsTblControl clsTbControl;
        ClsTblUserRole clsTbUserRole;
        ClsTblRoleControl clsTbRoleControl;
        ClsTblUserControl clsTbUserControl;

        private readonly FormMain _formMain;
        private string flyDailogMssg;

        public UCuserRight(FormMain formMain)
        {
            _formMain = formMain;
            InitializeComponent();
            GetResources();
            InitData();
            new ClsUserControlValidation(this, UserControls.Users);

            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView2.CustomColumnDisplayText += GridView2_CustomColumnDisplayText;
        }

        private void InitData()
        {
            this.clsTbUser = new ClsTblUser();
            this.clsTbRole = new ClsTblRole();
            this.clsTbControl = new ClsTblControl();
            this.clsTbUserRole = new ClsTblUserRole();
            this.clsTbRoleControl = new ClsTblRoleControl();
            this.clsTbUserControl = new ClsTblUserControl();

            tblRoleBindingSource.DataSource = this.clsTbRole.GetRoleList;
            bsiRecordsCount.Caption = "RECORDS : " + tblRoleBindingSource.Count;
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetUserRolePermision();
        }

        private void GetUserRolePermision()
        {
            short roleId = Convert.ToInt16(gridView.GetFocusedRowCellValue(colrolId));
            tblRoleControlBindingSource.DataSource = this.clsTbRoleControl.GetRoleControlListByRolId(roleId);
            tblUserRoleBindingSource.DataSource = this.clsTbUserRole.GetUserRoleListByRoleId(roleId);
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colfkRoleId.FieldName)
                e.DisplayText = this.clsTbRole.GetRoleName(Convert.ToInt16(e.Value));
            else if (e.Column.FieldName == colfkucNo.FieldName)
                e.DisplayText = this.clsTbUserControl.GetUserControlNameByNo(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == colfkControlId.FieldName)
                e.DisplayText = this.clsTbControl.GetControlCaptionById(Convert.ToInt16(e.Value));
        }

        private void GridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colfkUserId.FieldName)
                e.DisplayText = this.clsTbUser.GetUserNameById(Convert.ToInt16(e.Value));
        }

        private void bbiAddRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            new formRole(this).ShowDialog();
        }

        private void bbiAddPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            using (formRoleControl frmRoleControl = new formRoleControl(this))
            {
                flyDailog.WaitForm(this, 0);
                if (frmRoleControl.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void bbiRoleUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            using (formUserRole frmUserRole = new formUserRole(this))
            {
                flyDailog.WaitForm(this, 0);
                if (frmUserRole.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void bbiUserBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (formUserBranch frm = new formUserBranch())
            {
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            new formUser(this).ShowDialog();
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
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCuserRightEn));

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }

            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView1.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView2.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
        }

        private void bbiDscntPrmsion_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClsFlyoutDialog.ShowFlyoutDialog(_formMain, new UCdscntPermission(_formMain)
            { Dock = DockStyle.Fill, Height = (this.Height / 2) + 100 }, "صلاحيات الخصم");
        }

        private void btnPrinterUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (formDefaultPrinterUser frm = new formDefaultPrinterUser())
                frm.ShowDialog();
        }
    }
}
