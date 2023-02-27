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

namespace AccountingMS.Forms
{
    public partial class FrmAddAssetAccount : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAddAssetAccount()
        {
            InitializeComponent();
            using (accountingEntities db = new accountingEntities())
            {
                gridControl1.DataSource = db.AssetAccounts.ToList();
            }
            gridControl1.DoubleClick += GridControl1_DoubleClick;
            assetAccountBindingSource.DataSource = new AssetAccount();

        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            AssetAccount fa = gridView1.GetFocusedRow() as AssetAccount;
            if (fa != null)
            {
                assetAccountBindingSource.DataSource = fa;
            }

        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            using (accountingEntities db = new accountingEntities())
            {
                AssetAccount AstAcc = new AssetAccount();
                if (idTextEdit.Text != "0")
                    AstAcc = db.AssetAccounts.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));
                AstAcc.AssetName = AssetNameTextEdit.Text;
                AstAcc.AssetNameE = AssetNameETextEdit.Text;
                if (idTextEdit.Text == "0") db.AssetAccounts.Add(AstAcc);
                db.SaveChanges();
                gridControl1.DataSource = db.AssetAccounts.ToList();
                XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "Ok, Saved successfully" : "تم الحفظ بنجاح");
                assetAccountBindingSource.DataSource = new AssetAccount();
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            assetAccountBindingSource.DataSource = new AssetAccount();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (idTextEdit.Text == "") return;
            using (accountingEntities db = new accountingEntities())
            {
                AssetAccount Deprec = new AssetAccount();
                Deprec = db.AssetAccounts.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));
                if (Deprec == null) return;
                db.AssetAccounts.Remove(Deprec);
                db.SaveChanges();
                gridControl1.DataSource = db.AssetAccounts.ToList();
                assetAccountBindingSource.DataSource = new AssetAccount();
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
