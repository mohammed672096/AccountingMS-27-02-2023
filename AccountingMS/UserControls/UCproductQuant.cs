using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCproductQuant : DevExpress.XtraEditors.XtraUserControl
    {
        accountingEntities db = new accountingEntities();
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblProductQunatity clsTbPrdQuantity;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsProductByStore clsPrdStore;

        private short strId;

        public UCproductQuant()
        {
            InitializeComponent();
            GetResources();
            new ClsUserControlValidation(this, UserControls.ProductQuant);

            gridViewStr.FocusedRowChanged += GridViewStr_FocusedRowChanged;
            gridViewPrd.CustomUnboundColumnData += GridViewPrd_CustomUnboundColumnData;
            //gridView3.RowCellStyle += GridView3_RowCellStyle;
        }

        private void UCproductQuant_Load(object sender, EventArgs e)
        {
            InitData();
            colsupQuanMain.AppearanceCell.ForeColor = Color.WhiteSmoke;
        }

        private void InitData()
        {
            InitObjects();
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            InitPrdData();
            tblSupplySub st = new tblSupplySub();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl3, nameof(st.supBrnId));
        }

        private void InitObjects()
        {
            this.clsTbStore = new ClsTblStore();
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdQuantity = new ClsTblProductQunatity();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            this.clsPrdStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuantity.GetPrdQuantityList);
        }

        private void InitPrdData()
        {
            if (gridViewStr.GetFocusedRowCellValue(colStrId) == null) return;
            this.strId = Convert.ToInt16(gridViewStr.GetFocusedRowCellValue(colStrId));
            tblProductBindingSource.DataSource = this.clsPrdStore.GetProductListByStrId(strId);
        }

        private void GridViewStr_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitPrdData();
        }

        private void GridViewPrd_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != colprdQuantity.FieldName) return;

            int rowIndex = e.ListSourceRowIndex, prdId = Convert.ToInt32(view.GetListSourceRowCellValue(rowIndex, colprdId));
            if (prdId == 0) return;

            tblProductQunatity tbPrdQuantity = this.clsTbPrdQuantity.GetPrdQuantityObjByPrdIdNdStrId(prdId, this.strId);
            if (tbPrdQuantity == null) return;
            string totalQuantity = $"{tbPrdQuantity.prdQuantity} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName1ByPrdId(prdId)}";

            if (tbPrdQuantity.prdSubQuantity > 0) totalQuantity += $" - {tbPrdQuantity.prdSubQuantity} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName2ByPrdId(prdId)}";
            if (tbPrdQuantity.prdSubQuantity3 > 0) totalQuantity += $" - {tbPrdQuantity.prdSubQuantity3} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName3ByPrdId(prdId)}";

            e.Value = totalQuantity;
        }

        private void GridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            byte val = Convert.ToByte(gridView3.GetRowCellValue(e.RowHandle, colsupStatus));

            if (e.Column.FieldName == "supQuanMain")
            {
                if (val == 4 || val == 8 || val == 9 || val == 10)
                    e.Appearance.BackColor = Color.Red;
                else
                    e.Appearance.BackColor = Color.ForestGreen;
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl1.RightToLeft = RightToLeft.No;
            gridControl2.RightToLeft = RightToLeft.No;
            gridControl3.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCproductQuantEn));

            foreach (GridColumn c in gridViewStr.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridViewPrd.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridView3.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(bbiRefresh, bbiRefresh.Name, _ci);
            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
        }
    }
}
