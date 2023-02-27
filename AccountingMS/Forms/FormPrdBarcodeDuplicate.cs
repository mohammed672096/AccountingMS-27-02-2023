using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class FormPrdBarcodeDuplicate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        IEnumerable<tblPrdMsurDuplicate> duplicateList;

        private readonly UCstore _ucStore;

        public FormPrdBarcodeDuplicate(UCstore ucStore)
        {
            InitializeComponent();
            InitObjects();
            InitData();
            _ucStore = ucStore;

            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        private void InitData()
        {
            var tbPrdMsurList = new List<tblPrdMsurDuplicate>();

            foreach (var tbPrdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList.OrderBy(x => x.ppmPrdId).ThenBy(x => x.ppmStatus))
            {
                if (!string.IsNullOrWhiteSpace(tbPrdMsur.ppmBarcode1)) tbPrdMsurList.Add(ConvetObject(tbPrdMsur, tbPrdMsur.ppmBarcode1));
                if (!string.IsNullOrWhiteSpace(tbPrdMsur.ppmBarcode2)) tbPrdMsurList.Add(ConvetObject(tbPrdMsur, tbPrdMsur.ppmBarcode2));
                if (!string.IsNullOrWhiteSpace(tbPrdMsur.ppmBarcode3)) tbPrdMsurList.Add(ConvetObject(tbPrdMsur, tbPrdMsur.ppmBarcode3));
            }

            this.duplicateList = tbPrdMsurList.GroupBy(x => x.barcodeDuplicate).Where(x => x.Count() > 1).SelectMany(x => x.ToList()).ToList();
            tblPrdMsurDuplicateBindingSource.DataSource = this.duplicateList;
        }

        private tblPrdMsurDuplicate ConvetObject(tblPrdPriceMeasurment tbPrdMsur, string barcodeDup)
        {
            return new tblPrdMsurDuplicate()
            {
                ppmId = tbPrdMsur.ppmId,
                ppmPrdId = tbPrdMsur.ppmPrdId,
                ppmMsurName = tbPrdMsur.ppmMsurName,
                ppmBarcode1 = tbPrdMsur.ppmBarcode1,
                ppmBarcode2 = tbPrdMsur.ppmBarcode2,
                ppmBarcode3 = tbPrdMsur.ppmBarcode3,
                ppmPrice = tbPrdMsur.ppmPrice,
                ppmSalePrice = tbPrdMsur.ppmSalePrice,
                barcodeDuplicate = barcodeDup,
            };
        }

        private void InitObjects()
        {
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colbarcodeDuplicate.FieldName && e.IsForGroupRow)
                e.DisplayText += $" التكرار: {this.duplicateList.Where(x => x.barcodeDuplicate == e.Value.ToString()).Count()}";
            else if (e.Column.FieldName == colppmPrdId.FieldName)
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;
            _ucStore.SetRefreshListDialog("بيانات الباركود", false);
            DialogResult = DialogResult.OK;
        }

        private bool SaveData()
        {
            flydDialog.WaitForm(this, 1);
            gridView1.FocusedColumn = colppmId;
            gridView1.UpdateCurrentRow();
            using (var db = new accountingEntities())
            {
               for (short i = 0; i < gridView1.DataRowCount; i++)
                {
                    var tbPrdMsur = db.tblPrdPriceMeasurments.FirstOrDefault(x => x.ppmId == Convert.ToInt32(gridView1.GetRowCellValue(i, colppmId)) && x.ppmBrnId == Session.CurBranch.brnId);
                    tbPrdMsur.ppmBarcode1 = Convert.ToString(gridView1.GetRowCellValue(i, colppmBarcode1));
                    tbPrdMsur.ppmBarcode2 = Convert.ToString(gridView1.GetRowCellValue(i, colppmBarcode2));
                    tbPrdMsur.ppmBarcode3 = Convert.ToString(gridView1.GetRowCellValue(i, colppmBarcode3));
                }
                bool isSaved = ClsSaveDB.Save(db, LogHelper.GetLogger());
                flydDialog.WaitForm(this, 0);
                return isSaved;
            }
        }
        private void bsiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowRibbonPrintPreview();
        }
    }
}