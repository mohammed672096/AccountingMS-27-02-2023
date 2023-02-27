using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCstockTrans : XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblStockTransMain clsTbStockTransMain = new ClsTblStockTransMain();
        ClsTblStockTransSub clsTbStockTransSub = new ClsTblStockTransSub();
        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;

        private string flyDialogMssg;
        private int stockNo;
        private bool isNew;

        public UCstockTrans()
        {
            InitializeComponent();
            InitData();
            new ClsUserControlValidation(this, UserControls.StockTrans);

            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        private void InitData()
        {
            this.clsTbStore = new ClsTblStore();
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            tblStockTransMainBindingSource.DataSource = this.clsTbStockTransMain.GetStockTransList;
            bsiRecordsCount.Caption = ((!MySetting.GetPrivateSetting.LangEng) ? "العدد : " : "RECORDS : ") + tblStockTransMainBindingSource.Count;
            tblStockTransMain st = new tblStockTransMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(st.stcBrnId));
        }

        private void RefreshData()
        {
            this.clsTbStockTransMain.RefreshData();
            this.clsTbStockTransSub.RefreshData();
        }

        private void GridView_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            e.ChildList = this.clsTbStockTransSub.GetStockTransIListByStcMainId(Convert.ToInt16(gridView.GetFocusedRowCellValue(colstcId)));
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colstcStrIdFrom.FieldName || e.Column.FieldName == colstcStrIdTo.FieldName)
            {
                e.DisplayText = this.clsTbStore.GetStoreNameById(Convert.ToInt16(e.Value));
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colstcPrdId.FieldName)
            {
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            }
            else if (e.Column.FieldName == colstcMsurId.FieldName)
            {
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void UpdateButton()
        {
            flyDialog.WaitForm(this, 1);
            using (formAddStockTrans frm = new formAddStockTrans(this, this.clsTbStockTransMain, this.clsTbStockTransSub, this.clsTbStore, this.clsTbProduct, this.clsTbPrdMsur, tblStockTransMainBindingSource.Current as tblStockTransMain))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshListDialog();
                    SetFoucesdRow();
                }
                else
                {
                    RefreshData();
                }
            }
        }

        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddStockTrans frm = new formAddStockTrans(this, this.clsTbStockTransMain, this.clsTbStockTransSub, this.clsTbStore, this.clsTbProduct, this.clsTbPrdMsur))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshListDialog();
                    SetFoucesdRow();
                }
            }
        }

        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblStockTransMainBindingSource)) return;
            UpdateButton();
        }

        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblStockTransMainBindingSource)) return;
            Delete();
        }

        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            RefreshData();
            InitData();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblStockTransMainBindingSource)) return;
            PrintInvoice();
        }

        private void PrintInvoice()
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.StockTrans, tblObject: tblStockTransMainBindingSource.Current as tblStockTransMain, tblObjectList:
              this.clsTbStockTransSub.GetStockTransListByStcMainId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colstcId))));
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void Delete()
        {
            tblStockTransMain tbStockMain = tblStockTransMainBindingSource.Current as tblStockTransMain;
            string delMssg = (!MySetting.GetPrivateSetting.LangEng) ? $"هل أنت متاكد من حذف التحويل المخزني رقم: {tbStockMain.stcNo} ؟" :
                $"Delete product stock transfer no.: {tbStockMain.stcNo}?";
            if (XtraMessageBox.Show(delMssg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            IEnumerable<tblStockTransSub> tbStockSubList = this.clsTbStockTransSub.GetStockTransListByStcMainId(tbStockMain.stcId);
            foreach (var tbStockSub in tbStockSubList)
                this.clsTbStockTransSub.Delete(tbStockSub);
            if (this.clsTbStockTransSub.SaveDB)
            {
                this.clsTbStockTransMain.Delete(tbStockMain);
                if (this.clsTbStockTransMain.SaveDB)
                {
                    string successMssg = (!MySetting.GetPrivateSetting.LangEng) ? $"تم حذف التحويل المخزني رقم: {tbStockMain.stcNo} بنجاح." :
                 $"Successfully deleted product stock transfer no.: {tbStockMain.stcNo}.";
                    tblStockTransMainBindingSource.RemoveCurrent();
                    XtraMessageBox.Show(successMssg);
                }
            }
        }

        public void SetRefreshListDialog(string mssg, int stockNo, bool isNew)
        {
            this.flyDialogMssg = mssg;
            this.stockNo = stockNo;
            this.isNew = isNew;
        }

        private void RefreshListDialog()
        {
            if (this.isNew)
                flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            RefreshData();
            InitData();
        }

        public void SetFoucesdRow()
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("stcNo", this.stockNo);
            PrintInvoiceMssg();
        }

        private void PrintInvoiceMssg()
        {
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "هل تريد طباعة الفاتورة؟" : "Print Invoice?";
            if (XtraMessageBox.Show(mssg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            PrintInvoice();
        }
    }
}
