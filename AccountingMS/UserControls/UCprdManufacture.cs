using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCprdManufacture : DevExpress.XtraEditors.XtraUserControl
    {
        formAddProduct formProduct;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;

        private bool isSelectedChanged = true;

        private void UCprdManufacture_Load(object sender, EventArgs e)
        {
            InitBindingSourceData();
        }

        public UCprdManufacture(formAddProduct formProduct, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            InitializeComponent();

            this.formProduct = formProduct;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;

            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UCprdManufacture_Load;
            gridView1.SelectionChanged += GridView1_SelectionChanged;
            gridView2.FocusedRowChanged += GridView2_FocusedRowChanged;
            gridView2.CustomColumnDisplayText += GridView2_CustomColumnDisplayText;
            gridView2.CustomRowCellEditForEditing += GridView2_CustomRowCellEditForEditing;
        }

        private void InitBindingSourceData()
        {
            tblProductBindingSource.DataSource = ClsTblPrdNdMsur.GetProductsWithMsur(this.clsTbProduct.GetProductList, this.clsTbPrdMsur.GetPrdPriceMsurList);
        }

        protected internal void InitPrdManData()
        {
            if (this.formProduct.isNew) return;

            tblPrdManufactureBindingSource.DataSource = null;
            tblPrdManufactureBindingSource.DataSource = typeof(tblPrdManufacture);
            foreach (var tbPrdMan in this.formProduct.tbPrdManList) tblPrdManufactureBindingSource.Add(tbPrdMan);
        }

        protected internal void SetSelectedRows()
        {
            if (this.formProduct.tbPrdManList == null) return;
            this.isSelectedChanged = false;

            for (short i = 0; i < gridView2.DataRowCount; i++)
                gridView1.SelectRow(gridView1.GetRowHandle(gridView1.LocateByValue("id", gridView2.GetRowCellValue(i, colmanPrdSubId))));

            this.isSelectedChanged = true;
        }

        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (!this.isSelectedChanged) return;
            if (gridView1.IsRowSelected(e.ControllerRow)) AddRow(Convert.ToInt32(gridView1.GetRowCellValue(e.ControllerRow, colprdId)));
            else RemoveRow(Convert.ToInt32(gridView1.GetRowCellValue(e.ControllerRow, colprdId)));
        }

        private void GridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView2.GetFocusedRowCellValue(colmanPrdSubId)));
        }

        private void GridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colmanPrdSubId.FieldName) e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colmanPrdMsurId.FieldName) e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colmanPrdMsurId.FieldName) e.RepositoryItem = repoItemLEprdMsur;
        }

        private void AddRow(int prdId)
        {
            if (!this.clsTbPrdMsur.IsPrdIdFound(prdId)) return;

            var tbPrdMan = new tblPrdManufacture()
            {
                manPrdSubId = prdId,
                manPrdMsurId = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId).ppmId,
                manQuan = 1
            };
            tblPrdManufactureBindingSource.Add(tbPrdMan);
        }

        private void RemoveRow(int prdId)
        {
            gridView2.DeleteRow(gridView2.GetRowHandle(gridView2.LocateByValue("manPrdSubId", prdId)));
        }

        private bool SaveData()
        {
            this.formProduct.tbPrdManList = new List<tblPrdManufacture>();

            for (short i = 0; i < gridView2.DataRowCount; i++)
                this.formProduct.tbPrdManList.Add(gridView2.GetRow(i) as tblPrdManufacture);

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            if (!SaveData()) return;
            if (!ConfirmMssg()) return;

            this.formProduct.HideFlyoutPanel();
            this.formProduct.SetPrdManSalePrice();
        }

        private bool ConfirmMssg()
        {
            if (this.formProduct.isNew) return true;

            var tbPrdManListTmp = new HashSet<tblPrdManufacture>(this.formProduct.tbPrdManList);
            var isValid = tbPrdManListTmp.SetEquals(this.formProduct.tbPrdManListOld);

            if (!isValid && ClsXtraMssgBox.ShowWarningYesNo("هل أنت متاكد من حفظ تعديل مكونات الصنف؟") == DialogResult.Yes) return true;
            else this.formProduct.tbPrdManList = this.formProduct.tbPrdManListOld;

            return isValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.formProduct.HideFlyoutPanel();
        }

        private bool ValidateData()
        {
            bool isValid = (gridView2.DataRowCount >= 1) ? true : false;
            if (!isValid) ClsXtraMssgBox.ShowError("عذرا يجب إختيار مكونات الصنف أولاً!");

            return isValid;
        }
    }
}
