using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddPrdExpirateObj : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db;
        ClsTblPrdExpirate clsTbPrdExpirate;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;

        private readonly UCprdExpirate ucPrdExpirate;
        private string prdName;

        public formAddPrdExpirateObj(UCprdExpirate ucPrdExpirate, int expId, ClsTblPrdExpirate clsTbPrdExpirate, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            InitializeComponent();

            this.ucPrdExpirate = ucPrdExpirate;
            this.clsTbPrdExpirate = clsTbPrdExpirate;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;

            InitData(expId);
            InitDefaultData();
        }

        private void InitData(int expId)
        {
            db = new accountingEntities();
            var tbPrdExpirate = this.clsTbPrdExpirate.GetPrdExpirateObjById(expId).ShallowCopy();
            this.prdName = this.clsTbProduct.GetPrdNameById(tbPrdExpirate.expPrdId);

            tblPrdExpirateBindingSource.DataSource = tbPrdExpirate;
            db.tblPrdExpirates.Attach(tblPrdExpirateBindingSource.Current as tblPrdExpirate);
        }

        private void InitDefaultData()
        {
            this.Text += this.prdName;
            layoutControlGroupMain.Text += this.prdName;

            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList;
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurList;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ClsSaveDB.Save(db, LogHelper.GetLogger())) return;

            this.ucPrdExpirate.SetRefreshDialogList($"تاريخ إنتهاء الصنف: {this.prdName}", false);
            DialogResult = DialogResult.OK;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}