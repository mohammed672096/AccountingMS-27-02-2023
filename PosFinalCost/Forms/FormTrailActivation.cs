using DevExpress.XtraEditors;
using PosFinalCost.Classe;
using System;
using System.Windows.Forms;

namespace PosFinalCost.Forms
{
    public partial class FormTrailActivation : XtraForm
    {
        private ClsEncryption clsEncryp = new ClsEncryption();

        public FormTrailActivation()
        {
            InitializeComponent();
        }

        private void FormTrailActivation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SaveSettings();
        }

        private void SaveSettings()
        {
            if (!ValidateData()) return;
            if (!ValidatePassword()) return;

            SaveNewSettings();
            DialogResult = DialogResult.OK;
        }

        private void SaveNewSettings()
        {
            Program.My_Setting.accConFlag = this.clsEncryp.EncryptString(ClsHardDriveSerial.HDDSerieal() + textEditIsPurchased.Text);
            if (!String.IsNullOrEmpty(textEditTrailDays.Text))
                Program.My_Setting.accConVal = this.clsEncryp.EncryptString(textEditTrailDays.Text + "-" + ClsHardDriveSerial.HDDSerieal());
            MySetting.ReadWriterSettingXml();
            //Program.My_Setting.Save(); 
        }

        private bool ValidateData()
        {
            if (dxValidationProvider1.Validate()) return true;
            textEditPassword.Focus();
            return false;
        }

        private bool ValidatePassword()
        {
            if (textEditPassword.Text == "SahabSoft@+#9671076") return true;

            XtraMessageBox.Show("PasswordError!");
            textEditPassword.Focus();
            return false;
        }
    }
}