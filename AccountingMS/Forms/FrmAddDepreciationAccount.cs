using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AccountingMS.Forms
{
    public partial class FrmAddDepreciationAccount : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAddDepreciationAccount()
        {
            InitializeComponent();
            using (accountingEntities db = new accountingEntities())
            {
                gridControl1.DataSource = db.DepreciationAccounts.ToList();
            }
            depreciationAccountBindingSource.DataSource = new DepreciationAccount();
            //depreciationAccountBindingSource.DataSource = new DepreciationAccount();
            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DepreciationAccount fa = gridView1.GetFocusedRow() as DepreciationAccount;
            if (fa != null)
            {
                depreciationAccountBindingSource.DataSource = fa;
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            using (accountingEntities db = new accountingEntities())
            {
                DepreciationAccount Deprec = new DepreciationAccount();
                if (idTextEdit.Text != "0")
                    Deprec = db.DepreciationAccounts.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));

                Deprec.DepreciationName = DepreciationNameTextEdit.Text;
                Deprec.DepreciationNameE = DepreciationNameETextEdit.Text;
                if (idTextEdit.Text == "0") db.DepreciationAccounts.Add(Deprec);
                db.SaveChanges();
                gridControl1.DataSource = db.DepreciationAccounts.ToList();
                XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "Ok, Saved successfully" : "تم الحفظ بنجاح");
                depreciationAccountBindingSource.DataSource = new DepreciationAccount();
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            depreciationAccountBindingSource.DataSource = new DepreciationAccount();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            depreciationAccountBindingSource.DataSource = new DepreciationAccount();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (accountingEntities db = new accountingEntities())
            {
                DepreciationAccount Deprec = new DepreciationAccount();
                Deprec = db.DepreciationAccounts.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));
                if (Deprec == null) return;
                db.DepreciationAccounts.Remove(Deprec);
                db.SaveChanges();
                gridControl1.DataSource = db.DepreciationAccounts.ToList();
                depreciationAccountBindingSource.DataSource = new DepreciationAccount();
            }
        }
    }
}
