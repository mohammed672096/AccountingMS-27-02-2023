using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formRole : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        CultureInfo _ci;
        ComponentResourceManager _resource;

        private readonly UCuserRight _ucUserRight;
        private bool isNew;

        public formRole(UCuserRight ucUserRight)
        {
            InitializeComponent();
            GetResources();
            InitData();
            _ucUserRight = ucUserRight;
            _ucUserRight.CloseFlydDailod();

            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void InitData()
        {
            tblRoleBindingSource.DataSource = db.tblRoles.ToList();
            tblRoleDTBindingSource.DataSource = new tblRole();
            this.isNew = true;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            tblRoleDTBindingSource.DataSource = tblRoleBindingSource.Current as tblRole;
            db.tblRoles.Attach(tblRoleDTBindingSource.Current as tblRole);
            this.isNew = false;
        }

        private void barButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            string mssg = (this.isNew) ? "تم حفظ الصلاحية: " : "تم تعديل بيانات الصلاحية: ";
            mssg += rolNameTextEdit.Text + " بنجاح.";
            gridView1.Focus();

            if (this.isNew)
                db.tblRoles.Add(tblRoleDTBindingSource.Current as tblRole);

            if (SaveDB())
            {
                flyDailog.ShowDialogFormCustomMsg(this, mssg);
                InitData();
            }
        }

        private void barButtonSaveNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            string name = rolNameTextEdit.Text;
            if (XtraMessageBox.Show("هل أنت متاكد من حذف الصلاحية: {name}" + name, "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.tblRoles.Remove(tblRoleBindingSource.Current as tblRole);
                if (SaveDB())
                {
                    tblRoleBindingSource.RemoveCurrent();
                    flyDailog.ShowDialogFormCustomMsg(this, "تم حذف الصلاحية: " + name + " بنجاح.");
                }
            }
        }

        private void barButtonRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void barButtonItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formRoleEn));

            foreach (var control in ribbonControl1.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name);
            _resource.ApplyResources(colrolName, colrolName.Name);
            _resource.ApplyResources(ItemForrolName, ItemForrolName.Name);

            this.Text = _resource.GetString("$this.Text");
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}