using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Configuration;
using System.IO;
using System.Data.Common;
using System.Net;

namespace AccountingMS.Forms
{
    public partial class XtraFormConncetionAccDB : DevExpress.XtraEditors.XtraForm
    {
        //Classes.MyFunaction myfunaction = new Classes.MyFunaction();
          public XtraFormConncetionAccDB()
        {
            InitializeComponent();

        }
        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                layoutControlGroup2.Enabled = true;
                txtSqlUserName.Focus();
            }
            else
            {
                layoutControlGroup2.Enabled = false;
                txtSqlUserName.ResetText();
                txtSqlPassword.ResetText();
                btnSave.Focus();
            }
        }
        public string ConnectionString_AccDB()
        {
            string conStraing = "";
            if (ConnSetting.GetConnSetting.AccMode == "SQL")
                conStraing = "data source=" + ConnSetting.GetConnSetting.AccServerName + ";Initial Catalog=" + ConnSetting.GetConnSetting.AccDBName + ";user id=" + ConnSetting.GetConnSetting.AccSqlUserName + ";password=" + ConnSetting.GetConnSetting.AccSqlPassword + ";";
            else if (ConnSetting.GetConnSetting.AccMode == "Windows")
                conStraing = "data source=" + ConnSetting.GetConnSetting.AccServerName + ";Initial Catalog=" + ConnSetting.GetConnSetting.AccDBName + ";Integrated Security=true;";
            return conStraing;
        }
        public void SettingServer()
        {
            ConnSetting.GetConnSetting.AccServerName = txtServerName.Text.Trim();
            ConnSetting.GetConnSetting.AccDBName = txtDB_Name.Text.Trim();
            ConnSetting.GetConnSetting.AccMode = rbWindows.Checked == true ? "Windows" : "SQL";
            ConnSetting.GetConnSetting.AccSqlUserName = txtSqlUserName.Text;
            ConnSetting.GetConnSetting.AccSqlPassword = txtSqlPassword.Text;
            ConnSetting.WriterSettingXml();
            try
            {
                if (Database.Exists(ConnectionString_AccDB()))
                {
                    MessageBox.Show("تم حفظ الاعدادات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtServerName.Focus();
                txtServerName.SelectAll();
                return;
            }
        }

        private void btnSavSetting_Click(object sender, EventArgs e)
        {
            SettingServer();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
       

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}