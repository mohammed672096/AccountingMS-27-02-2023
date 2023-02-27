using DevExpress.XtraEditors;
using PosFinalCost.Classe;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace PosFinalCost.Forms
{
    public partial class FormLogin : XtraForm
    {
       // ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private ClsEncryption clsEncrp = new ClsEncryption();
        public FormLogin()
        {
            if (Keyboard.IsKeyDown(Key.LeftShift)) new FormConncetionPosDB().ShowDialog();
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            InitializeComponent();
            labelControl1.Text = Program.NameProgram;
            textEditBranchId.IntializeData(Session.Branches);
            textEditBranchId.EditValueChanged += TextEditBranchId_EditValueChanged;
            textEditFinancialYear.EditValueChanged += TextEditFinancialYear_EditValueChanged;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textEditUserName.EditValue = Program.My_Setting.defaultUserName;
            radioGroupLanguage.EditValue = Program.My_Setting.LangEng;
            textEditPassword.Select();
            FinancialYearBindingSource.DataSource = Session.FinancialYears.Where(x => x.BrnId == Program.My_Setting.LogBranchID);
            textEditBranchId.EditValue = Program.My_Setting.LogBranchID;
            if (Session.FinancialYears.Any(x => x.ID == Program.My_Setting.defaultFyId))
                textEditFinancialYear.EditValue = Program.My_Setting.defaultFyId;

        }
      
        private void TextEditBranchId_EditValueChanged(object sender, EventArgs e)
        {
            short brnId = ((textEditBranchId.EditValue as short?) ?? 0);
            FinancialYearBindingSource.DataSource = Session.FinancialYears.Where(x => x.BrnId == brnId);
        }

        private void TextEditFinancialYear_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;
            Session.CurrentYear = editor.GetSelectedDataRow() as FinancialYear;
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            LoginUser();
        }
        private void LoginUser()
        {
            try
            {
                if (!CheckTrailVersion()) return;
                using (PosDBDataContext db = new PosDBDataContext(Program.ConnectionString))
                {
                    Session.CurrentUser = db.UserTbls.Where(a => a.Name == textEditUserName.Text && a.Pass == textEditPassword.Text).SingleOrDefault();
                    if (Session.CurrentUser != null)
                    {
                        if (Session.CurrentUser.ID != 1)
                        {
                            if (!db.UserBranchTbls.Any(x=>x.UserId==Session.CurrentUser.ID&&x.BrnId== Convert.ToInt16(textEditBranchId.EditValue)))
                            {
                                XtraMessageBox.Show("عذراً لا يتوفر للمستخدم صلاحيات لدخول هذا الفرع!");
                                return;
                            }
                        }
                        SetDefaultProperties();
                        SetStaticClassData();
                        Program.LogInUser = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("عذرا هناك خطاء في إسم المستخدم أو كلمة المرور");
                        return;
                    }
                     
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            Close();
        }
        private void SetDefaultProperties()
        {
            Program.My_Setting.defaultUserName = textEditUserName.Text;
            Program.My_Setting.defaultFyId = Convert.ToInt32(textEditFinancialYear.EditValue);
            Program.My_Setting.LangEng = Convert.ToBoolean(radioGroupLanguage.EditValue);
            Program.My_Setting.LogBranchID = Convert.ToInt16(textEditBranchId.EditValue);
            MySetting.ReadWriterSettingXml();
        }

        private void SetStaticClassData()
        {
            Session.CurrentBranch = Session.Branches.Where(x => x.ID == Convert.ToInt16(textEditBranchId.EditValue)).SingleOrDefault();
            if (Session.CurrentYear == null)
                Session.CurrentYear = Session.FinancialYears.FirstOrDefault(x => x.ID == Convert.ToInt32(textEditFinancialYear.EditValue));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture((!Program.My_Setting.LangEng) ? "ar" : "en");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture((!Program.My_Setting.LangEng) ? "ar" : "en");
        }
        private bool CheckTrailVersion()
        {
            if (Debugger.IsAttached)
                return true;
            if (Program.My_Setting.accConFlag == string.Empty)
            {
                XtraMessageBox.Show("عذرا لقد تم انتهاء مدة النسخة التجريبية! \n" + "يرجى شراء النظام للمتابعة.");
                return false;
            }
            else
            {
                string flagStr = this.clsEncrp.DecryptString(Program.My_Setting.accConFlag);
                int flag = flagStr.Length>0? Convert.ToInt32(flagStr.Substring(flagStr.Length - 1, 1)): -1;
                if (flag == 1) return true;
                int val = SetTrailVersionRemaingDays();

                if (val <= 0)
                {
                    XtraMessageBox.Show("عذرا لقد تم انتهاء مدة النسخة التجريبية! \n" + "يرجى شراء النظام للمتابعة.");
                    return false;
                }
            }
            return true;
        }

        private int SetTrailVersionRemaingDays()
        {
            DateTime dtOld = Program.My_Setting.accConDt;
            string conValStr = this.clsEncrp.DecryptString(Program.My_Setting.accConVal);
            int conVal = Convert.ToInt32(conValStr.Substring(0, conValStr.IndexOf("-")));

            if (dtOld.Date != DateTime.Now.Date)
            {
                Program.My_Setting.accConDt = DateTime.Now.Date;
                conVal -= 1;
                Program.My_Setting.accConVal = this.clsEncrp.EncryptString(conVal.ToString() + "-" + ClsHardDriveSerial.HDDSerieal());
                MySetting.ReadWriterSettingXml();
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
    }
}