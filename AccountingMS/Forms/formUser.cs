using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formUser : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        CultureInfo _ci;
        ComponentResourceManager _resource;
        tblUser tbUser;

        public formUser(UCuserRight ucUserRight)
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
            this.isNew = true;
            this.tbUser = new tblUser();
            tblUserBindingSource.DataSource = db.tblUsers.Where(x => x.id != 1).ToList();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            this.isNew = false;
            this.tbUser = tblUserBindingSource.Current as tblUser;
            labelUserName.Text = "تعديل بيانات المستخدم: " + gridView1.GetFocusedRowCellValue(coluserName);
            db.tblUsers.Attach(this.tbUser);
            textEditUserName.EditValue = this.tbUser.userName;
        }

        private bool ValidatePassword()
        {
            bool passwordMatch = (textEditPassword.Text == textEditConfirmPassword.Text) ? true : false;
            if (!passwordMatch)
            {
                XtraMessageBox.Show("عذرا كلمة السر التي ادخلتها غير متطابفة!");
                textEditPassword.Focus();
            }
            return passwordMatch;
        }

        private void SaveData()
        {
            this.tbUser.userName = textEditUserName.EditValue.ToString();
            this.tbUser.userPass = textEditPassword.EditValue.ToString();
        }

        private void ClearData()
        {
            labelUserName.Text = "إضافة مستخدم";
            textEditUserName.EditValue = null;
            textEditPassword.EditValue = null;
            textEditConfirmPassword.EditValue = null;
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!ValidatePassword()) return;

            string mssg = (this.isNew) ? "تم حفظ المستخدم: " : "تم تعديل بيانات المستخدم: ";
            mssg += textEditUserName.Text + " بنجاح.";
            textEditConfirmPassword.Focus();

            SaveData();
            if (this.isNew) db.tblUsers.Add(this.tbUser);

            if (SaveDB())
            {
                flyDailog.ShowDialogFormCustomMsg(this, mssg);
                InitData();
                ClearData();
                textEditUserName.Focus();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            string userName = gridView1.GetFocusedRowCellValue(coluserName).ToString();
            if (XtraMessageBox.Show("هل انت متاكد من حذف المستخدم: " + userName + " ؟", "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.tblUsers.Remove(tblUserBindingSource.Current as tblUser);
                if (SaveDB())
                {
                    tblUserBindingSource.RemoveCurrent();
                    flyDailog.ShowDialogFormCustomMsg(this, "تم حذف المستخدم: " + userName + " بنجاح.");
                }
            }
        }

        private void bbiReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
            ClearData();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formUserEn));

            foreach (var control in mainRibbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }

            foreach (LayoutControlItem item in layoutControlGroup2.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }

            _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name);
            _resource.ApplyResources(labelUserName, labelUserName.Name);
            _resource.ApplyResources(simpleLabelItem2, simpleLabelItem2.Name);

            this.Text = _resource.GetString("$this.Text");
        }

        private bool SaveDB()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }

        private readonly UCuserRight _ucUserRight;
        private bool isNew;
    }
}
