using System;
using DevExpress.XtraEditors;

namespace accounting_1._0
{
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
            {
                textEditPassword.Focus();
                return;
            }
            if (textEditPassword.Text != "admin@@@2486519357")
            {
                XtraMessageBox.Show("PasswordError!");
                textEditPassword.Focus();
                return;
            }
            else if (textEditPassword.Text == "admin@@@2486519357")
            {
                Properties.Settings.Default.accountingConnectionFlag = Convert.ToByte(textEditIsPurchased.EditValue);
                if (!String.IsNullOrEmpty(textEditTrailDays.Text))
                    Properties.Settings.Default.accountingConnectionVal = Convert.ToByte(textEditTrailDays.EditValue);

                Properties.Settings.Default.Save();
                this.Close();
                XtraMessageBox.Show("SettingsChangesSuccefully");
            }
        }
    }
}