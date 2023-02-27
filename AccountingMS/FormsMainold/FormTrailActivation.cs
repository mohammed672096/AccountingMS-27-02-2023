using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class FormTrailActivation : XtraForm
    {
        private ClsEncryption clsEncryp = new ClsEncryption();

        public FormTrailActivation()
        {
            InitializeComponent();
        }

        private void FormTrailActivation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
            ConnSetting.GetConnSetting.accountingConnectionFlag = this.clsEncryp.EncryptString(ClsHardDriveSerial.HDDSerieal() + textEditIsPurchased.Text);
            if (!String.IsNullOrEmpty(textEditTrailDays.Text))
                ConnSetting.GetConnSetting.accountingConnectionVal = this.clsEncryp.EncryptString(textEditTrailDays.Text + "-" + ClsHardDriveSerial.HDDSerieal());
            ConnSetting.WriterSettingXml();
        }

        private bool ValidateData()
        {
            if (dxValidationProvider1.Validate()) return true;
            textEditPassword.Focus();
            return false;
        }

        private bool ValidatePassword()
        {
            if (textEditPassword.Text == "btechAdmin@@@357159") return true;

            XtraMessageBox.Show("PasswordError!");
            textEditPassword.Focus();
            return false;
        }
    }
}