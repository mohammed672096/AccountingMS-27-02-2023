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
using PosFinalCost.Classe;

namespace PosFinalCost.Forms
{
    public partial class FormConncetionAccDB : DevExpress.XtraEditors.XtraForm
    {
        //Classes.MyFunaction myfunaction = new Classes.MyFunaction();
          public FormConncetionAccDB()
        {
            InitializeComponent();
            mySettingBindingSource.DataSource = Program.My_Setting;
        }
       
        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlGroup2.Enabled = radioGroup1.EditValue.ToString()=="SQL";
        }
        public void SettingServer()
        {
            try
            {
                string con = new MyFunaction().ConnectionString_AccDB();
                if (Database.Exists(con))
                {
                    using (var db=new AccDBDataContext(con))
                    {
                        var m = db.tblSupplyMains.FirstOrDefault();
                    }
                    XtraMessageBox.Show("تم الاتصال بالخادم بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtServerName.Focus();
                return;
            }
        }
        
        private void btnSavSetting_Click(object sender, EventArgs e)
        {
            MySetting.ReadWriterSettingXml();
            XtraMessageBox.Show("تم حفظ الاعدادات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnCancel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormConncetionAccDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySetting.ReadWriterSettingXml(true);
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            SettingServer();
        }

       
    }
}