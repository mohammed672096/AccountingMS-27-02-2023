using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formUserRole : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        BindingList<tblUserRole> tbUserRoleList = new BindingList<tblUserRole>();
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        CultureInfo _ci;
        ComponentResourceManager _resource;
        private readonly UCuserRight _ucUserRight;
        private bool userFlag;

        public formUserRole(UCuserRight ucUserRight)
        {
            InitializeComponent();
            GetResources();
            InitData();
            _ucUserRight = ucUserRight;

            textEditRoleId.EditValueChanged += TextEditRoleId_EditValueChanged;
        }

        private void InitData()
        {
            tblRoleBindingSource.DataSource = db.tblRoles.ToList();
            var tbUserRole = db.tblUserRoles.ToList();
            foreach (var tUserRole in tbUserRole)
                this.tbUserRoleList.Add(tUserRole);
        }

        private void InitUserData()
        {
            if (!this.userFlag)
            {
                tblUserBindingSource.DataSource = db.tblUsers.Where(x => x.id != 1).ToList();
                this.userFlag = true;
            }
        }

        private void TextEditRoleId_EditValueChanged(object sender, EventArgs e)
        {
            InitUserData();
            short roleId = Convert.ToInt16(textEditRoleId.EditValue);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                foreach (var tbUserRole in this.tbUserRoleList)
                {
                    if (tbUserRole.fkRoleId == roleId && tbUserRole.fkUserId == Convert.ToInt16(gridView1.GetRowCellValue(i, coluserId)))
                    {
                        gridView1.SelectRow(i);
                        break;
                    }
                    else
                        gridView1.UnselectRow(i);
                }
            }
        }

        private bool IsUserRoleFound(short roleId, short userId, bool deleteRow = false)
        {
            bool isRowFound = false;
            foreach (var tbUserRole in this.tbUserRoleList)
            {
                if (tbUserRole.fkRoleId == roleId && tbUserRole.fkUserId == userId)
                {
                    if (deleteRow) db.tblUserRoles.Remove(tbUserRole);
                    isRowFound = true;
                    break;
                }
            }
            return isRowFound;
        }

        private void AddNewUserRole(short roleId, short userId)
        {
            tblUserRole tbUserRole = new tblUserRole();
            tbUserRole.fkRoleId = roleId;
            tbUserRole.fkUserId = userId;
            db.tblUserRoles.Add(tbUserRole);
        }

        private void ClearData()
        {
            textEditRoleId.EditValue = null;

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.UnselectRow(i);
            }
        }

        private bool SaveData()
        {
            short roleId = Convert.ToInt16(textEditRoleId.EditValue);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                short userId = Convert.ToInt16(gridView1.GetRowCellValue(i, coluserId));

                if (gridView1.IsRowSelected(i) && !IsUserRoleFound(roleId, userId))
                    AddNewUserRole(roleId, userId);
                else if (!gridView1.IsRowSelected(i))
                    IsUserRoleFound(roleId, userId, true);
            }
            return (SaveDB()) ? true : false;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (SaveData())
            {
                string mssg = "تم حفظ مستخدمين الصلاحية: ";
                mssg += textEditRoleId.Properties.GetDisplayText(textEditRoleId.EditValue) + " بنجاح.";
                _ucUserRight.SetRefreshListDialog(mssg);
                DialogResult = DialogResult.OK;
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formUserRoleEn));

            _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name);
            _resource.ApplyResources(bbiSave, bbiSave.Name);
            _resource.ApplyResources(bbiClose, bbiClose.Name);
            _resource.ApplyResources(layoutControlGroup2, layoutControlGroup2.Name);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name);
            _resource.ApplyResources(layoutControlItemRoleId, layoutControlItemRoleId.Name);
            _resource.ApplyResources(coluserName, coluserName.Name);
            textEditRoleId.Properties.Columns[0].Caption = _resource.GetString("textEditRoleId.Properties.Columns1");

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
    }
}
