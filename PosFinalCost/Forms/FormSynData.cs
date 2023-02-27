using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Net.NetworkInformation;
using PosFinalCost.Classe;

namespace PosFinalCost.Forms
{
    public partial class FormSynData : DevExpress.XtraEditors.XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        public FormSynData()
        {
            InitializeComponent();
            new ClsUserRoleValidation(this, UserControls.DataExchange);
            uploadDataToMain.OnProcess += Synchronizing_OnProcess;
         }

        private void Synchronizing_OnProcess(object sender, string e)
        {
            this.Invoke(new MethodInvoker(delegate { memoEdit1.Text += e; }));
            memoEdit1.Refresh();
        }

        UploadDataToMain uploadDataToMain = new UploadDataToMain();
        private async void btnUpLoadData_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
                memoEdit1.Text = string.Empty;
                btnPuch.Enabled = false;
                try
                {
                    await uploadDataToMain.PushAsync();
                    XtraMessageBox.Show("تم رفع البيانات بنجاح", "");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
                btnPuch.Enabled = true;
            flyDialog.WaitForm(this, 0,this);
        }
        private  void btnPull_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            memoEdit1.Text = string.Empty;
            uploadDataToMain.PullAsync(this);
            //flyDialog.WaitForm(this, 0, this);
        }

        private void FromDateTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //Program.My_Setting.UpDataFromDate = Convert.ToDateTime(FromDateTextEdit.EditValue);
            //Program.My_Setting.UpDataToDate = Convert.ToDateTime(ToDateTextEdit.EditValue);
            //MySetting.ReadWriterSettingXml();
        }
    }
}