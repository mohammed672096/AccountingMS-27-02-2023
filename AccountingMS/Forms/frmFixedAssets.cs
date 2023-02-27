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
using DevExpress.XtraEditors.Controls;

namespace AccountingMS.Forms
{
    public partial class frmFixedAssets : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // accountingEntities db = new accountingEntities();
        tblAccount acount = new tblAccount();


        private byte[] imageBuffer;
        private int FAId;
        // private int faimgNo;
        public frmFixedAssets()
        {
            InitializeComponent();
            //  dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            filllookup();
            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            FixedAsset fa = gridView1.GetFocusedRow() as FixedAsset;
            if (fa != null)
            {
                fixedAssetBindingSource1.DataSource = fa;
            }
        }

        void filllookup()
        {
            using (accountingEntities db3 = new accountingEntities())
            {
                gridControl1.DataSource = db3.FixedAssets.ToList();
                originalAccountTextEdit.Properties.DataSource = db3.AssetAccounts.ToList();
                currencyTextEdit.Properties.DataSource = db3.tblCurrencies.ToList();
                DepreciationAccountTextEdit.Properties.DataSource = db3.DepreciationAccounts.ToList();
            }
        }
        bool Validation()
        {
            if (assetsNameTextEdit.Text == ""){assetsNameTextEdit.ErrorText = "This field is required"; return false;}
           // if (assetsNameETextEdit.Text == ""){ assetsNameETextEdit.ErrorText = "This field is required"; return false;}
            if (PurchaseValue.Text == ""){ PurchaseValue.ErrorText = "This field is required"; return false;}
            if (datePurchaseDateEdit.Text == ""){ datePurchaseDateEdit.ErrorText = "This field is required"; return false;}
            if (currencyTextEdit.Text == ""){ currencyTextEdit.ErrorText = "This field is required"; return false;}
            if (originalAccountTextEdit.Text == ""){ originalAccountTextEdit.ErrorText = "This field is required"; return false;}
            if (currentValueTextEdit.Text == ""){ currentValueTextEdit.ErrorText = "This field is required"; return false;}
            if (DepreciationAccountTextEdit.Text == ""){ DepreciationAccountTextEdit.ErrorText = "This field is required"; return false;}
            if (DepreciationRateTextEdit.Text == ""){ DepreciationRateTextEdit.ErrorText = "This field is required"; return false;}
            return true;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!dxValidationProvider1.Validate()) return;
            if (Validation()==false ) return;
            using (accountingEntities db2 = new accountingEntities())
            {
               // FixedAsset FixedAst2 = fixedAssetBindingSource1.Current as FixedAsset;
               // db2.FixedAssets.AddOrUpdate(FixedAst2);
                FixedAsset FixedAst2 =new FixedAsset();
                if (idTextEdit.Text != "0" )
                    FixedAst2 = db2.FixedAssets.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));

                FixedAst2.assetsName = assetsNameTextEdit.Text;
                FixedAst2.assetsNameE = assetsNameETextEdit.Text;
                FixedAst2.PurchaseValue =Convert.ToDouble( PurchaseValue.EditValue);
                FixedAst2.datePurchase = Convert.ToDateTime( datePurchaseDateEdit.EditValue);
                FixedAst2.currency =Convert.ToInt32( currencyTextEdit.EditValue);
                FixedAst2.originalAccount = Convert.ToInt32(originalAccountTextEdit.EditValue);
                FixedAst2.currentValue = Convert.ToDouble(currentValueTextEdit.EditValue);
                FixedAst2.DepreciationAccount = Convert.ToInt32(DepreciationAccountTextEdit.EditValue);
                FixedAst2.DepreciationRate = Convert.ToDouble(DepreciationRateTextEdit.EditValue);
                FixedAst2.Notes = NotetextEdit.Text;
                FixedAst2.equalizer = equalizercheckEdit.Checked;
                FixedAst2.stopAssets = stopAssetscheckEdit.Checked;
                FixedAst2.CreateImplicitSubAccount = CreateImplicitSubAccountcheckEdit.Checked;
                if (this.imageBuffer != null) FixedAst2.photo = this.imageBuffer;
                if (idTextEdit.Text == "0" )
                    db2.FixedAssets.Add(FixedAst2);

                db2.SaveChanges();
                fixedAssetBindingSource1.DataSource = new FixedAsset();
                this.imageBuffer = null;
                XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "ok, Saved successfully" : "تم الحفظ بنجاح ");
                filllookup();
            }
        }
       
      

        private void ChooseImageButton1_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }

        private void ChooseImage()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader binaryReadr = new BinaryReader(fileStream);
                this.imageBuffer = binaryReadr.ReadBytes((int)fileStream.Length);

                fileStream.Close();
                binaryReadr.Close();
                LoadImage();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadImage()
        {
            photoPictureEdit.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAddAssetAccount frm = new FrmAddAssetAccount();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            FrmAddDepreciationAccount frm = new FrmAddDepreciationAccount();
            frm.ShowDialog();
        }

        private void frmFixedAssets_Load(object sender, EventArgs e)
        {
            datePurchaseDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            fixedAssetBindingSource1.DataSource = new FixedAsset();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            filllookup();
        }

        private void barButtonItemPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fixedAssetBindingSource1.DataSource = new FixedAsset();
        }

        private void originalAccountTextEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                FrmAddAssetAccount frm = new FrmAddAssetAccount();
                frm.ShowDialog();
            }
        }

        private void DepreciationAccountTextEdit_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                FrmAddDepreciationAccount frm = new FrmAddDepreciationAccount();
                frm.ShowDialog();
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (accountingEntities db2 = new accountingEntities())
            {
                if (idTextEdit.Text == "0" || idTextEdit.Text== "") return;
                if (gridView1.RowCount > 0)
                {
                    FixedAsset FixedAst2 = new FixedAsset();
                    FixedAst2 = db2.FixedAssets.ToList().FirstOrDefault (m => m.id == Convert.ToInt32(idTextEdit.Text));
                    db2.FixedAssets.Remove(FixedAst2);
                    db2.SaveChanges();
                    fixedAssetBindingSource1.DataSource = new FixedAsset();
                    XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "ok, Saved successfully" : "تم الحذف ");
                    filllookup();
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ReportForm frmr = new ReportForm(null))
            {
                using (accountingEntities db = new accountingEntities())
                {
                    Reports.ReportFixedAssets rep = new Reports.ReportFixedAssets();
                    var fix = db.FixedAssets.ToList();
                    foreach (var item in fix)
                    {
                        int d1 = (item.datePurchase.Value.Day) + (item.datePurchase.Value.Month * 30) + (item.datePurchase.Value.Year * 12 * 30);
                        int d2 = (DateTime.Now.Day) + (DateTime.Now.Month * 30) + (DateTime.Now.Year * 12 * 30) + 1;
                        int dv = d2 - d1;
                        item.DepreciationDay = Convert.ToDouble(Math.Round(Convert.ToDecimal((item.PurchaseValue * item.DepreciationRate / 100) / 365), 4));
                        item.DepreciationYeer = item.PurchaseValue * item.DepreciationRate / 100;
                        item.DepreciationNow = Convert.ToDouble(Math.Round(Convert.ToDecimal(((item.PurchaseValue * item.DepreciationRate / 100) / 365) * dv), 4));
                        item.CountDay = dv;
                        db.SaveChanges();
                    }
                    rep.DataSource = db.View_FixedAssets.ToList();
                    rep.RequestParameters = false;
                    frmr.documentViewer1.DocumentSource = rep;
                    frmr.ShowDialog();
                }
            }
        }
    }
}
