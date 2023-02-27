using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class UCdscntPermission : XtraUserControl
    {
        ComponentFlyoutDialog flydialog = new ComponentFlyoutDialog();
        ClsTblUser clsTbUser;
        ClsTblDscntPrmsion clsTbDscntPrmsion;
        tblUser tbUser;
        tblDscntPermission tbDscntPrmsion;

        private readonly FormMain _formMain;
        private bool isNew;
        private short usrIdOld;

        private async void UCdscntPermission_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
            InitDefaultData();
        }

        public UCdscntPermission(FormMain formMain)
        {
            _formMain = formMain;
            InitializeComponent();
            InitEvents();
            SetSplitterProperties(true);
        }

        private void InitEvents()
        {
            this.Load += UCdscntPermission_Load;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            dscUsrIdTextEdit.EditValueChanged += DscUsrIdTextEdit_EditValueChanged;
            dscUsrIdTextEdit.EditValueChanging += DscUsrIdTextEdit_EditValueChanging;
        }

        private async Task InitDataAsync()
        {
            flydialog.WaitForm(this, 1);

            await InitObjectsAsync();
            InitData();

            flydialog.WaitForm(this, 0);
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbUser = new ClsTblUser()));
            taskList.Add(Task.Run(() => this.clsTbDscntPrmsion = new ClsTblDscntPrmsion()));

            await Task.WhenAll(taskList);
        }

        private void InitData()
        {
            tblDscntPermissionListBindingSource.DataSource = this.clsTbDscntPrmsion.GetDscnPrmsionList;
            bsiRecordsCount.Caption = $"العدد: {tblDscntPermissionListBindingSource.Count}";
        }

        private void InitDefaultData()
        {
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserListNoAdmin;
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == coldscPercent.FieldName) e.DisplayText = $"{e.Value}%";
            if (e.Column.FieldName == coldscUsrId.FieldName) e.DisplayText = this.clsTbUser.GetUserNameById(Convert.ToInt16(e.Value));
        }

        private void DscUsrIdTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e?.NewValue == null) return;

            e.Cancel = ValidateUserDscnt(Convert.ToInt16(e.NewValue));
        }

        private bool ValidateUserDscnt(short usrId)
        {
            if (!this.isNew && usrId == this.usrIdOld) return false;

            bool isUsrDscntFound = this.clsTbDscntPrmsion.IsDscntUserFound(usrId);

            if (isUsrDscntFound) ClsFlyoutDialog.ShowFlyoutWarningMssg(_formMain, $"عذراً لقد تم إضافة صلاحية خصم للمستخدم: {GetUserName(usrId)} مسبقاً!");

            return isUsrDscntFound;
        }

        private void DscUsrIdTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor.EditValue == null) return;

            this.tbUser = editor.GetSelectedDataRow() as tblUser;
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flydialog.WaitForm(this, 1);

            InitNewObject();
            InitText();
            SetSplitterProperties(false);

            flydialog.WaitForm(this, 0);
            dscUsrIdTextEdit.Focus();
        }

        private void Edit()
        {
            flydialog.WaitForm(this, 1);

            InitUpdateObj();
            InitText();
            SetSplitterProperties(false);

            flydialog.WaitForm(this, 0);
            dscUsrIdTextEdit.Focus();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblDscntPermissionListBindingSource)) return;
            Edit();
        }

        private async void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblDscntPermissionListBindingSource)) return;
            if (!ConfirmDelete()) return;
            if (!this.clsTbDscntPrmsion.Remove(this.tbDscntPrmsion)) return;

            flydialog.ShowDialogUCCustomdMsg(this, $"تم حذف صلاحية الخصم للمستخدم: {this.tbUser.userName} بنجاح!");
            await InitDataAsync();
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveData()) return;

            string mssg = $"صلاحية خصم للمستخدم: {this.tbUser.userName}";
            flydialog.ShowDialogUC(this, mssg, this.isNew);

            SetSplitterProperties(true);
            await InitDataAsync();

            if (this.isNew) InitNewObject();
            dscUsrIdTextEdit.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!this.isNew) this.clsTbDscntPrmsion.RefreshData();
            SetSplitterProperties(true);
        }

        private void InitNewObject()
        {
            this.isNew = true;
            this.tbDscntPrmsion = new tblDscntPermission() { dscUsrId = 0, dscPercent = 0, dscPermission = true };
            tblDscntPermissionBindingSource.DataSource = this.tbDscntPrmsion;
        }

        private void InitUpdateObj()
        {
            this.isNew = false;
            this.tbDscntPrmsion = tblDscntPermissionListBindingSource.Current as tblDscntPermission;
            this.usrIdOld = this.tbDscntPrmsion.dscUsrId;
            this.tblDscntPermissionBindingSource.DataSource = this.tbDscntPrmsion;
        }

        private void InitText()
        {
            layoutControlGroupDscntPermission.Text = this.isNew ? "إضافة خصم" : $"تعديل صلاحية الخصم للمستخدم: {GetUserName(this.tbDscntPrmsion.dscUsrId)}";
        }

        private string GetUserName(short usrId)
        {
            return this.clsTbUser.GetUserNameById(usrId);
        }

        private bool SaveData()
        {
            if (this.isNew)
                return this.clsTbDscntPrmsion.Add(this.tbDscntPrmsion);
            else
                return this.clsTbDscntPrmsion.Attach(this.tbDscntPrmsion);
        }

        private bool ConfirmDelete()
        {
            this.tbDscntPrmsion = tblDscntPermissionListBindingSource.Current as tblDscntPermission;
            this.tbUser = this.clsTbUser.GetUserObjById(this.tbDscntPrmsion.dscUsrId);
            string mssg = $"هل أنت متأكد من حذف صلاحية الخصم للمستخدم: {this.tbUser.userName}؟";

            return ClsFlyoutDialog.ShowFlyoutDialogConfirmMssg(_formMain, "حذف", mssg);
        }

        private void SetSplitterProperties(bool isCollapsed)
        {
            splitContainerControl1.SplitterPosition = Convert.ToInt32(this.Width * 0.75);
            splitContainerControl1.PanelVisibility = isCollapsed ? SplitPanelVisibility.Panel1 : SplitPanelVisibility.Both;
        }
    }
}
