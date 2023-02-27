using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCprdQuanTracking : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblProductQunatity clsTbPrdQuantity;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsProductByStore clsPrdStore;

        private short strId = 0;
        private int prdId = 0;

        private async void UCprdQuanTracking_Load(object sender, EventArgs e)
        {
            await InitDataAsync();

            InitEvents();
            InitData();
        }

        public UCprdQuanTracking()
        {
            InitializeComponent();
            GetResources();

            //new ClsUserControlValidation(this, UserControls.ProductQuant);

            this.Load += UCprdQuanTracking_Load;

            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }

        private void InitEvents()
        {
            gridViewStr.FocusedRowChanged += GridViewStr_FocusedRowChanged;
            gridViewPrd.FocusedRowChanged += GridViewPrd_FocusedRowChanged;
            gridViewPrd.CustomUnboundColumnData += GridViewPrd_CustomUnboundColumnData;
            gridViewPrdTrack.AsyncCompleted += GridViewPrdTrack_AsyncCompleted;
            gridViewPrdTrack.CustomColumnDisplayText += GridViewPrdTrack_CustomColumnDisplayText;
            //gridView3.RowCellStyle += GridView3_RowCellStyle;
        }

        private void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            accountingEntities db = new accountingEntities();

            e.QueryableSource = (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supStatus <= 12 && x.supStrId == this.strId)
                .Join(db.tblSupplySubs.Where(x => x.supPrdId == this.prdId),
                    supMain => supMain.id,
                    supSub => supSub.supNo,
                    (x, y) => new tblPrdTracking()
                    {
                        id = y.id,
                        trcPrdId = y.supPrdId,
                        trcPrdMsurId = y.supMsur,
                        trcQuan = y.supQuanMain,
                        trcPrice = y.supPrice,
                        trcSalePrice = y.supSalePrice,
                        trcDate = x.supDate,
                        trcBarcode = y.supPrdBarcode,
                        trcDesc = x.supDesc + " " + y.supDesc,
                        trcStatus = y.supStatus == 3 || y.supStatus == 7 ? (byte)1 : y.supStatus == 9 || y.supStatus == 10 ? (byte)2 :
                            y.supStatus == 4 || y.supStatus == 8 ? (byte)3 : y.supStatus == 11 || y.supStatus == 12 ? (byte)4 : (byte)0
                    })
                .Concat(db.tblProductQtyOpns.Where(x => x.qtyBranchId == Session.CurBranch.brnId && x.qtyStrId == this.strId && x.qtyPrdId == this.prdId)
                    .Select(x => new tblPrdTracking()
                    {
                        id = x.qtyId,
                        trcPrdId = x.qtyPrdId,
                        trcPrdMsurId = x.qtyPrdMsurId,
                        trcQuan = x.qtyQuantity,
                        trcPrice = x.qtyPrice,
                        trcSalePrice = null,
                        trcDate = x.qtyDate,
                        trcBarcode = "101",
                        trcDesc = "رصيد إفتتاحي",
                        trcStatus = (byte)PrdTracking.Opn,
                    }))
                .Concat(db.tblPrdExpirateQuans.Where(x => x.expBrnId == Session.CurBranch.brnId && x.expStrid == this.strId && x.expPrdId == this.prdId)
                    .Select(x => new tblPrdTracking()
                    {
                        id = x.expId,
                        trcPrdId = x.expPrdId,
                        trcPrdMsurId = x.expPrdMsurId,
                        trcQuan = x.expQuan,
                        trcPrice = x.expPrdPrice,
                        trcSalePrice = null,
                        trcDate = x.expDate,
                        trcBarcode = "101",
                        trcDesc = "إتلاف",
                        trcStatus = (byte)PrdTracking.Exp,
                    }))
                .Concat(db.tblStockTransMains.Where(x => x.stcBrnId == Session.CurBranch.brnId && x.stcStrIdFrom == this.strId)
                    .Join(db.tblStockTransSubs.Where(x => x.stcPrdId == this.prdId),
                        stcMain => stcMain.stcId,
                        stcSub => stcSub.stcMainId,
                        (x, y) => new tblPrdTracking()
                        {
                            id = y.stcId,
                            trcPrdId = y.stcPrdId,
                            trcPrdMsurId = y.stcMsurId,
                            trcQuan = y.stcQuantity,
                            trcPrice = null,
                            trcSalePrice = null,
                            trcDate = x.stcDate,
                            trcBarcode = "101",
                            trcDesc = "تحويل مخزني إخراج",
                            trcStatus = (byte)PrdTracking.TransOut,
                        }))
                .Concat(db.tblStockTransMains.Where(x => x.stcBrnId == Session.CurBranch.brnId && x.stcStrIdTo == this.strId)
                    .Join(db.tblStockTransSubs.Where(x => x.stcPrdId == this.prdId),
                        stcMain => stcMain.stcId,
                        stcSub => stcSub.stcMainId,
                        (x, y) => new tblPrdTracking()
                        {
                            id = y.stcId,
                            trcPrdId = y.stcPrdId,
                            trcPrdMsurId = y.stcMsurId,
                            trcQuan = y.stcQuantity,
                            trcPrice = null,
                            trcSalePrice = null,
                            trcDate = x.stcDate,
                            trcBarcode = "101",
                            trcDesc = "تحويل مخزني إستلام",
                            trcStatus = (byte)PrdTracking.TransIn,
                        }))
                .Concat(db.tblInvStoreMains.Where(x => x.invBrnId == Session.CurBranch.brnId && x.invStrId == this.strId)
                    .Join(db.tblInvStoreSubs.Where(x => x.invPrdId == this.prdId),
                        invMain => invMain.id,
                        invSub => invSub.invMainId,
                        (x, y) => new tblPrdTracking()
                        {
                            id = y.id,
                            trcPrdId = y.invPrdId,
                            trcPrdMsurId = y.invPrdMsurId,
                            trcQuan = y.invQuanAvl,
                            trcPrice = y.invPriceAvrg,
                            trcSalePrice = null,
                            trcDate = x.invDate,
                            trcBarcode = "101",
                            trcDesc = "جرد مخزني",
                            trcStatus = (byte)PrdTracking.Inv,
                        }))
                ).AsNoTracking();

            e.Tag = db;
        }

        private void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((accountingEntities)e.Tag).Dispose();
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);

            await InitObjectsAsync();

            flyDialog.WaitForm(this, 0);
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>() {
                Task.Run(() => this.clsTbStore = new ClsTblStore()),
                Task.Run(() => this.clsTbProduct = new ClsTblProduct()),
                Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()),
                Task.Run(() => this.clsTbPrdQuantity = new ClsTblProductQunatity()),
            };

            await Task.WhenAll(taskList);

            this.clsPrdStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuantity.GetPrdQuantityList);
        }

        private void InitData()
        {
            InitStoreData();
            InitPrdData();
            InitPrdTrackData();
        }

        private void InitStoreData()
        {
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;

            labelStrCount.Text = $"عدد المخازن: {tblStoreBindingSource.Count}";
        }

        private void InitPrdData()
        {
            if (gridViewStr.GetFocusedRowCellValue(colStrId) == null) return;

            this.strId = Convert.ToInt16(gridViewStr.GetFocusedRowCellValue(colStrId));
            tblProductBindingSource.DataSource = this.clsPrdStore.GetProductListByStrId(strId);

            layoutControlGroupProducts.Text = $"أصناف {gridViewStr.GetFocusedRowCellValue(colstrName)}";
            labelPrdCount.Text = $"عدد الأصناف: {tblProductBindingSource.Count:n0}";
        }

        private void InitPrdTrackData()
        {
            this.prdId = Convert.ToInt32(gridViewPrd.GetFocusedRowCellValue(colprdId));
            entityInstantFeedbackSource1.Refresh();

            layoutControlGroupTrack.Text = $"حركة الصنف: {gridViewPrd.GetFocusedRowCellValue(colprdName)}";
        }

        private void GridViewStr_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitPrdData();
        }

        private void GridViewPrd_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitPrdTrackData();
        }

        private void GridViewPrd_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != colprdQuantity.FieldName) return;

            int rowIndex = e.ListSourceRowIndex, prdId = Convert.ToInt32(view.GetListSourceRowCellValue(rowIndex, colprdId));
            if (prdId == 0) return;

            tblProductQunatity tbPrdQuantity = this.clsTbPrdQuantity.GetPrdQuantityObjByPrdIdNdStrId(prdId, this.strId);
            string totalQuantity = $"{tbPrdQuantity.prdQuantity} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName1ByPrdId(prdId)}";

            if (tbPrdQuantity.prdSubQuantity > 0) totalQuantity += $" - {tbPrdQuantity.prdSubQuantity} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName2ByPrdId(prdId)}";
            if (tbPrdQuantity.prdSubQuantity3 > 0) totalQuantity += $" - {tbPrdQuantity.prdSubQuantity3} {this.clsTbPrdMsur.GetPrdPriceMsurUnitName3ByPrdId(prdId)}";

            e.Value = totalQuantity;
        }

        private void GridViewPrdTrack_AsyncCompleted(object sender, EventArgs e)
        {
            labelPrdTrackCount.Text = $"عدد حركة الصنف: {gridViewPrdTrack.DataRowCount:n0}";
        }

        private void GridViewPrdTrack_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == coltrcStatus.FieldName && !string.IsNullOrEmpty(e.Value.ToString()))
                e.DisplayText = ClsPrdTrackingStatus.GetString(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == coltrcPrdId.FieldName && !string.IsNullOrEmpty(e.Value.ToString()))
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == coltrcPrdMsurId.FieldName && !string.IsNullOrEmpty(e.Value.ToString()))
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            byte val = Convert.ToByte(gridViewPrdTrack.GetRowCellValue(e.RowHandle, coltrcStatus));

            if (e.Column.FieldName == "supQuanMain")
            {
                if (val == 4 || val == 8 || val == 9 || val == 10)
                    e.Appearance.BackColor = Color.Red;
                else
                    e.Appearance.BackColor = Color.ForestGreen;
            }
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
            InitData();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControlStr.RightToLeft = RightToLeft.No;
            gridControlPrd.RightToLeft = RightToLeft.No;
            gridControlPrdTrack.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCproductQuantEn));

            foreach (GridColumn c in gridViewStr.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridViewPrd.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridViewPrdTrack.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(bbiRefresh, bbiRefresh.Name, _ci);
            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
        }
    }
}
