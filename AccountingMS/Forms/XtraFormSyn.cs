using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using AccountingMS.AccDB;
using System.Net.NetworkInformation;
using AccountingMS.Classes;

namespace AccountingMS.Forms
{
    public partial class XtraFormSyn : DevExpress.XtraEditors.XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        public XtraFormSyn()
        {
            InitializeComponent();
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
            flyDialog.WaitForm(this, 1);
            memoEdit1.Text = string.Empty;
            uploadDataToMain.PullAsync();
            flyDialog.WaitForm(this, 0, this);
        }

        private void FromDateTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            ConnSetting.GetConnSetting.UpDataFromDate = Convert.ToDateTime(FromDateTextEdit.EditValue);
            ConnSetting.GetConnSetting.UpDataToDate = Convert.ToDateTime(ToDateTextEdit.EditValue);
            ConnSetting.WriterSettingXml();
        }
    }
}