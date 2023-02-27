using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace AccountingMS
{
    public partial class FormLogin : XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private ClsEncryption clsEncrp = new ClsEncryption();
        //private ClsTblFinancialYear clsTbFinancialYear;
        public FormLogin()
        {
            if (Keyboard.IsKeyDown(Key.LeftShift)) new formDBConnection().ShowDialog();
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            InitializeComponent();

            textEditBranchId.EditValueChanged += TextEditBranchId_EditValueChanged;
            textEditFinancialYear.EditValueChanged += TextEditFinancialYear_EditValueChanged;
            //textEditPassword.EditValue = "admin";
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //try
            //{
                //this.clsTbFinancialYear = new ClsTblFinancialYear();
                //Program.CheckForDBUpdate();
                tblBranchBindingSource.DataSource = Session.Branches;
                InitDefaultData();
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

      
        private void InitDefaultData()
        {
            textEditUserName.EditValue = MySetting.GetPrivateSetting.defaultUserName;
            radioGroupLanguage.EditValue = MySetting.GetPrivateSetting.LangEng;
            textEditPassword.Select();
            if (MySetting.GetPrivateSetting.defaultBrnId > 0)
            {
                try
                {
                    tblFinancialYearBindingSource.DataSource = Session.tblFinancialYear?.Where(x => x.fyBranchId == MySetting.GetPrivateSetting.defaultBrnId).ToList();
                    textEditBranchId.EditValue = MySetting.GetPrivateSetting.defaultBrnId;
                    textEditFinancialYear.EditValue = MySetting.GetPrivateSetting.defaultFyId;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void TextEditBranchId_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            short brnId = Convert.ToInt16(editor.EditValue);

            if (MySetting.GetPrivateSetting.defaultBrnId != brnId)
            {
                MySetting.GetPrivateSetting.defaultBrnId = brnId;
                tblFinancialYearBindingSource.DataSource = Session.tblFinancialYear?.Where(x => x.fyBranchId == brnId).ToList();
            }
        }

        private void TextEditFinancialYear_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;
          Session.CurrentYear = editor.GetSelectedDataRow() as tblFinancialYear;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            LoginUser();
        }

       
        private void SetDefaultProperties()
        {
            MySetting.GetPrivateSetting.defaultUserName = textEditUserName.Text;
            MySetting.GetPrivateSetting.defaultFyId = Convert.ToInt32(textEditFinancialYear.EditValue);
            MySetting.GetPrivateSetting.LangEng = Convert.ToBoolean(radioGroupLanguage.EditValue);
            MySetting.WriterSettingXml();
            Program.Localization();
        }
        private void SetStaticClassData()
        {
            Session.CurBranch = Session.Branches.FirstOrDefault(x => x.brnId == Convert.ToInt16(textEditBranchId.EditValue));
            if (Session.CurrentYear == null)
                Session.CurrentYear = Session.tblFinancialYear.FirstOrDefault(x => x.fyId == Convert.ToInt32(textEditFinancialYear.EditValue));
            ClsThreadCulture.CurrentCulture = new System.Globalization.CultureInfo((MySetting.GetPrivateSetting.LangEng) ? "ar-YE" : "en-US");
        }
        private bool ValidateInstallation()
        {
            if (string.IsNullOrWhiteSpace(ConnSetting.GetConnSetting.accountingConnectionFlag) ||
                ConnSetting.GetConnSetting.accountingConnectionDt == new DateTime(0001, 1, 1))
            {
                XtraMessageBox.Show(this, "للمتابعة يرجى شراء النسخه الأصليه! \n للتواصل الإتصال على الأرقام التالية: 0535213680");
                Application.Exit();
                return false;
            }
            return true;
        }
        private void LoginUser()
        {
            bool isValid = false;
            flyDialog.WaitForm(this, 1);

            try
            {
                if (!ValidateInstallation()) return;
                using (accountingEntities db = new accountingEntities())
                {
                  Session.CurrentUser = (from a in db.tblUsers
                                   where a.userName == textEditUserName.Text && a.userPass == textEditPassword.Text
                                   select a).SingleOrDefault();
                    if (Session.CurrentUser != null)
                    {
                        isValid = true;
                        if (Session.CurrentUser.id != 1) Session.RoleId = new ClsTblUserRole().GetUserRoleIdByUserId(Session.CurrentUser.id);
                        if (!CheckTrailVersion()) return;
                    }
                    else
                    {
                        isValid = false;
                        flyDialog.WaitForm(this, 0);
                        XtraMessageBox.Show("عذرا هناك خطاء في إسم المستخدم أو كلمة المرور");
                    }
                }
            }
            catch (Exception ex)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(ex.Message);
            }
            if (!isValid) return;
            if (!ValidateUserBranch()) return;
            SetDefaultProperties();
            SetStaticClassData();
            flyDialog.WaitForm(this, 0);
            this.ShowInTaskbar = false;
            this.Opacity = 0;

            Thread str = new Thread(Start);
            str.SetApartmentState(ApartmentState.STA);
            str.Start();
            Close();
            //  ClsStopWatch stopWatch = new ClsStopWatch();
            // new FormMain().Show();

            //LogHelper.GetLogger().Info(stopWatch.Stop("StartupTime"));
            //this.Hide();
        }
        private void Start()
        {
            Application.EnableVisualStyles();
            ClsStopWatch stopWatch = new ClsStopWatch();
            FormMain form = new FormMain();
            stopWatch.Stop("========ElappsedTimeFormMainLoad");
            Application.Run(form);
        }
        private bool ValidateUserBranch()
        {
            if (Session.CurrentUser.id == 1) return true;

            bool isValid = new ClsTblUserBranch().IsUserBranchFound(Session.CurrentUser.id, Convert.ToInt16(textEditBranchId.EditValue));

            if (!isValid)
            {
                flyDialog.WaitForm(this, 0);
                ClsXtraMssgBox.ShowError("عذراً لا يتوفر للمستخدم صلاحيات لدخول هذا الفرع!");
            }

            return isValid;

        }

        private bool CheckTrailVersion()
        {
            if (Debugger.IsAttached)
                return true;
            string thisComputerSerail = ClsHardDriveSerial.HDDSerieal();
            string flagStr = this.clsEncrp.DecryptString(ConnSetting.GetConnSetting.accountingConnectionFlag);

            string serial= flagStr.Substring(0,flagStr.Length - 1);
            int flag = Convert.ToInt32(flagStr.Substring(flagStr.Length - 1, 1));
            if (serial != thisComputerSerail)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show("عذرا لقد تم انتهاء مدة النسخة التجريبية! \n" + "يرجى شراء النظام للمتابعة.");
                Application.Exit();
                return false;
            }
            if (flag == 1) return true;

            int val = SetTrailVersionRemaingDays();

            if (val <= 0)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show("عذرا لقد تم انتهاء مدة النسخة التجريبية! \n" + "يرجى شراء النظام للمتابعة.");
                Application.Exit();
                return false;
            }
            return true;
        }

        private int SetTrailVersionRemaingDays()
        {
            DateTime dtOld = ConnSetting.GetConnSetting.accountingConnectionDt;
            string conValStr = this.clsEncrp.DecryptString(ConnSetting.GetConnSetting.accountingConnectionVal);
            int conVal = Convert.ToInt32(conValStr.Substring(0, conValStr.IndexOf("-")));

            if (dtOld.Date != DateTime.Now.Date)
            {
                ConnSetting.GetConnSetting.accountingConnectionDt = DateTime.Now.Date;
                conVal -= 1;
                ConnSetting.GetConnSetting.accountingConnectionVal = this.clsEncrp.EncryptString(conVal.ToString() + "-" + ClsHardDriveSerial.HDDSerieal());
                ConnSetting.WriterSettingXml();
            }
            return conVal;
        }
       
        private void FormLogin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.B)
                if (new FormTrailActivation().ShowDialog() == DialogResult.OK)
                    XtraMessageBox.Show("SettingsChangesSuccefully");
            if (e.KeyCode == Keys.Enter)
            {
                if (!dxValidationProvider1.Validate()) return;
                LoginUser();
            }
        }

        private void radioGroupLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}