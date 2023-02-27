using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace AccountingMS
{
    public partial class formAddProductTemp : XtraForm
    {
        accountingEntities db = new accountingEntities();
        tblProduct tbPrdocut = new tblProduct();
        private int prdId;

        public formAddProductTemp()
        {
            InitializeComponent();
            new ClsTblGroupStr().GroupNoLookkUpEdit(grpNoTextEdit);

            grpNoTextEdit.EditValueChanged += GrpNoTextEdit_EditValueChanged;
        }

        private void GrpNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (Convert.ToInt32(editor.EditValue) == 0) return;

            this.tbPrdocut.prdGrpNo = Convert.ToInt32(editor.EditValue);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMainProductData();
            if (SaveDB())
            {
                this.prdId = (from a in db.tblProducts
                              orderby a.id descending
                              select a.id).FirstOrDefault();
                SaveProductQuantity();
                SaveProductMsur();
                if (SaveDB())
                    XtraMessageBox.Show("SaveSuccefully");
            }
        }

        private void SaveMainProductData()
        {
            this.tbPrdocut.prdName = "أأ كندر كنتري";
            this.tbPrdocut.prdNo = "9999999";
            this.tbPrdocut.prdBrnId = Session.CurBranch.brnId;
            this.tbPrdocut.prdStatus = 1;
            db.tblProducts.Add(this.tbPrdocut);
        }

        private void SaveProductQuantity()
        {
            db.tblProductQunatities.Add(new tblProductQunatity()
            {
                prdId = this.prdId,
                prdBrnId = Session.CurBranch.brnId,
                prdQuantity = 500,
                prdSubQuantity = 15,
                prdSubQuantity3 = 5
            });
        }

        private void SaveProductMsur()
        {
            AddPrdMsur1();
            AddPrdMsur2();
            AddPrdMsur3();
        }

        private void AddPrdMsur1()
        {
            db.tblPrdPriceMeasurments.Add(new tblPrdPriceMeasurment()
            {
                ppmStatus = 1,
                ppmPrdId = this.prdId,
                ppmBrnId = Session.CurBranch.brnId,
                ppmMsurName = "حبه",
                ppmConversion = 1,
                ppmPrice = 200,
                ppmSalePrice = 250,
                ppmMinSalePrice = 220,
                ppmRetailPrice = 250,
                ppmBatchPrice = 230,
                ppmBarcode1 = "311111111",
                ppmBarcode2 = "311111112",
                ppmBarcode3 = "311111113"

            });
        }

        private void AddPrdMsur2()
        {
            db.tblPrdPriceMeasurments.Add(new tblPrdPriceMeasurment()
            {
                ppmStatus = 2,
                ppmPrdId = this.prdId,
                ppmBrnId = Session.CurBranch.brnId,
                ppmMsurName = "شدة",
                ppmConversion = 10,
                ppmPrice = 1000,
                ppmSalePrice = 1500,
                ppmMinSalePrice = 1200,
                ppmRetailPrice = 1500,
                ppmBatchPrice = 1300,
                ppmBarcode1 = "211111111",
                ppmBarcode2 = "211111112",
                ppmBarcode3 = "211111113"
            });
        }

        private void AddPrdMsur3()
        {
            db.tblPrdPriceMeasurments.Add(new tblPrdPriceMeasurment()
            {
                ppmStatus = 3,
                ppmPrdId = this.prdId,
                ppmBrnId = Session.CurBranch.brnId,
                ppmConversion = 200,
                ppmMsurName = "كرتون",
                ppmPrice = 2000,
                ppmSalePrice = 2500,
                ppmMinSalePrice = 2200,
                ppmRetailPrice = 2500,
                ppmBatchPrice = 2300,
                ppmBarcode1 = "111111111",
                ppmBarcode2 = "111111112",
                ppmBarcode3 = "111111113"
            });
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}