﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddStockTrans : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClsTblProductQunatity clsTbPrdQuantity = new ClsTblProductQunatity();
        List<ClsProductQuantList> tbPrdQuantityAddList = new List<ClsProductQuantList>();
        List<ClsProductQuantList> tbPrdQuantityDeductList = new List<ClsProductQuantList>();
        IDictionary<int, double> listPrdQuantity = new Dictionary<int, double>();
        tblProduct tbProduct;
        tblPrdPriceMeasurment tbPrdMsur;
        ClsTblStockTransMain clsTbStockTransMain;
        ClsTblStockTransSub clsTbStockTransSub;
        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsProductByStore clsPrdStore;
        IEnumerable<tblStockTransSub> tbStockSubListOld;
        IEnumerable<ClsProductQuantList> tbPrdQuantityStrFromListOld;
        IEnumerable<ClsProductQuantList> tbPrdQuantityStrFromListNew;
        tblBarcode tbBarcode;
        private readonly UCstockTrans _ucStockTrans;
        private tblStockTransMain tbStockMain;
        private bool isNew;
        private int stockNo;
        ClsTblBarcode clsTbBarcode;
        public formAddStockTrans(UCstockTrans ucStockTrans, ClsTblStockTransMain clsTbStockTransMain, ClsTblStockTransSub clsTbStockTransSub, ClsTblStore clsTbStore, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur, tblStockTransMain tbStockTransMain = null)
        {
            InitializeComponent();
            InitObjects(clsTbStockTransMain, clsTbStockTransSub, clsTbStore, clsTbProduct, clsTbPrdMsur);
            InitData(tbStockTransMain);
            InitBindingSourceData();
            _ucStockTrans = ucStockTrans;
            invBarcodeTextEdit.KeyDown += InvBarcodeTextEdit_KeyDown;
            gridView1.FocusedColumnChanged += GridView1_FocusedColumnChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            //gridView1.ValidatingEditor += GridView1_ValidatingEditor;
            stcDescTextEdit.EditValueChanging += StcDescTextEdit_EditValueChanging;
            stcStrIdFromTextEdit.EditValueChanged += StcStrIdFromTextEdit_EditValueChanged;
            repositoryItemSearchLookUpEditProduct.EditValueChanged += RepositoryItemSearchLookUpEditProduct_EditValueChanged;
            repositoryItemLookUpEditPrdMsur.EditValueChanged += RepositoryItemLookUpEditPrdMsur_EditValueChanged;
        }
        private void ButtnDelete()
        {
            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            gridControl1.RepositoryItems.Add(buttonDelete);
            buttonDelete.Buttons.Clear();
            buttonDelete.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonDelete.ButtonClick += ButtonDelete_ButtonClick;
            GridColumn clmnDelete = new GridColumn()
            {
                Name = "clmnDelete",
                Caption = "حذف",
                FieldName = "Delete",
                ColumnEdit = buttonDelete,
                VisibleIndex = 7,
                Width = 60

            };
            buttonDelete.TextEditStyle = TextEditStyles.HideTextEditor;
            gridView1.Columns.Add(clmnDelete);
            clmnDelete.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        }
        private void ButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView;
            if (view.FocusedRowHandle >= 0)
                view.DeleteSelectedRows();
        }
        private void InitData(tblStockTransMain tbStockTransMain)
        {
            if (tbStockTransMain == null)
            {
                this.isNew = true;

                InitStockMainObj();
                ButtnDelete();
                // this.clsTbStockTransMain.Add(tblStockTransMainBindingSource.Current as tblStockTransMain);
            }
            else
            {
                this.isNew = false;
                this.stockNo = tbStockTransMain.stcNo;
                this.tbStockMain = tbStockTransMain;
                //BindingSourceStopChanges();

                tblStockTransMainBindingSource.DataSource = this.tbStockMain;
                this.clsTbStockTransMain.Attach(tblStockTransMainBindingSource.Current as tblStockTransMain);
                InitListObjects();
                InitSubData();
                InitPrdQuantityList();
                InitPrdQuantityAvailable();
                SetGridProperties();
                SetItemProperties();
                if (!string.IsNullOrEmpty(tbStockTransMain.stcDesc)) UpdateDescProgressBarControls(tbStockTransMain.stcDesc.Length);

                gridView1.CellValueChanging += GridView1_CellValueChanging;
            }
        }
        private void InvBarcodeTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(invBarcodeTextEdit.Text)) return;
            if (string.IsNullOrWhiteSpace(stcStrIdFromTextEdit.EditValue.ToString())) return;


            SearchBarcodeData(invBarcodeTextEdit.Text);

            invBarcodeTextEdit.EditValue = null;
        }

        private void SearchBarcodeData(string barcodeNo)
        {
            if (!ValidateBarcode(barcodeNo)) return;
            if (!ValidateGridPrdMsur()) return;

            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(this.tbBarcode.brcPrdMsurId);

            this.tbProduct = ProductInStorMain.Where(x => x.id == (this.tbPrdMsur?.ppmPrdId ?? 0)).FirstOrDefault();// this.clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur?.ppmPrdId ?? 0);

            if (this.tbProduct == null || this.tbPrdMsur == null)
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found in selected Store!" : "عذراً لم يتم العثور على الصنف المطلوب في المخزن المحدد!");
                return;
            }

            gridView1.AddNewRow();

            gridView1.SetFocusedRowCellValue(colstcPrdId, this.tbProduct.id);
            gridView1.SetFocusedRowCellValue(colstcMsurId, this.tbPrdMsur.ppmId);
            gridView1.SetFocusedRowCellValue(colstcQuantity, 1);
            gridView1.UpdateCurrentRow();

            SetTotalQuantity(this.tbProduct.id, this.tbPrdMsur.ppmId, gridView1.FocusedRowHandle);
            gridView1.UpdateCurrentRow();

            // InitPrdQuanNdPrice();
        }
        private bool ValidateGridPrdMsur()
        {
            bool isValid = true;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colstcMsurId)) == this.tbBarcode.brcPrdMsurId)
                {
                    isValid = false;
                    gridView1.FocusedRowHandle = i;
                    break;
                }

            return isValid;
        }

        private bool ValidateBarcode(string barcodeNo)
        {
            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcodeNo);

            bool isValid = this.tbBarcode != null ? true : false;

            if (!isValid)
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found!" : "عذراً لم يتم العثور على الصنف المطلوب!");

            return isValid;
        }

        private void InitStockMainObj()
        {
            this.tbStockMain = new tblStockTransMain()
            {
                stcNo = this.clsTbStockTransMain.GetStockTransNewNo(),
                stcDate = DateTime.Now,
                stcBrnId = Session.CurBranch.brnId,
                stcUserId = Session.CurrentUser.id
            };
            tblStockTransMainBindingSource.DataSource = this.tbStockMain;
        }

        private void InitSubData()
        {
            this.tbStockSubListOld = this.clsTbStockTransSub.GetStockTransListByStcMainId(this.tbStockMain.stcId);
            IEnumerable<tblStockTransSub> tbStockTransSubList = this.tbStockSubListOld;
            tblStockTransSubBindingSource.DataSource = this.tbStockSubListOld;
        }

        private void InitListObjects()
        {
            this.tbStockSubListOld = new Collection<tblStockTransSub>();
        }

        private void InitPrdQuantityList()
        {
            this.tbPrdQuantityStrFromListOld = ClsStockPrdQuantityListConverter.InitPrdQuantityList(this.tbStockSubListOld, this.tbStockMain.stcStrIdFrom);
            this.tbPrdQuantityStrFromListNew = ClsStockPrdQuantityListConverter.InitPrdQuantityList(this.tbStockSubListOld, this.tbStockMain.stcStrIdFrom);
        }

        private void BindingSourceStopChanges()
        {
            this.BindingContext[tblStockTransMainBindingSource].Bindings.Cast<Binding>().ToList()
                .ForEach(b => b.DataSourceUpdateMode = DataSourceUpdateMode.Never);
            this.BindingContext[tblStockTransSubBindingSource].Bindings.Cast<Binding>().ToList()
                .ForEach(b => b.DataSourceUpdateMode = DataSourceUpdateMode.Never);
        }

        private void InitObjects(ClsTblStockTransMain clsTbStockTransMain, ClsTblStockTransSub clsTbStockTransSub, ClsTblStore clsTbStore, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            this.clsTbStore = clsTbStore;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
            this.clsTbStockTransMain = clsTbStockTransMain;
            this.clsTbStockTransSub = clsTbStockTransSub;
            this.clsPrdStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuantity.GetPrdQuantityList);
            this.clsTbBarcode = new ClsTblBarcode();
        }

        private void InitBindingSourceData()
        {
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            bool valid;
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == colstcQuantityAvailable.FieldName)
            {
                valid = this.listPrdQuantity.Any(x => x.Key == e.ListSourceRowIndex);
                if (valid) 
                    e.Value = this.listPrdQuantity[e.ListSourceRowIndex];
            }
            else if (e.Column.FieldName == colBarcode.FieldName)
            {
                tblStockTransSub st = e.Row as tblStockTransSub;
                if (st != null)
                {
                    valid = this.clsTbBarcode.tbBarcodeList.Any(x => x.brcPrdMsurId == st.stcMsurId);
                    if (valid) e.Value = this.clsTbBarcode.tbBarcodeList.FirstOrDefault(x => x.brcPrdMsurId == st.stcMsurId).brcNo;
                }

            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colstcMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colstcMsurId.FieldName)
                e.RepositoryItem = repositoryItemLookUpEditPrdMsur;
        }

        private void GridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colstcMsurId)
                tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colstcPrdId)));
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == colstcQuantity.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()) || e.RowHandle < 0) return;
                this.tbPrdQuantityStrFromListNew.ElementAt(e.RowHandle).prdQuantity = Convert.ToDouble(e.Value);//.ToString().Replace(".","")
            }
        }

        private void RepositoryItemSearchLookUpEditProduct_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            int prdId = Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("id"));
            int msurId = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId).ppmId;
            gridView1.SetFocusedRowCellValue(colstcPrdId, prdId);
            gridView1.SetFocusedRowCellValue(colstcMsurId, msurId);
            gridView1.SetFocusedRowCellValue(colstcQuantity, 1);
            gridView1.UpdateCurrentRow();

            SetTotalQuantity(prdId, msurId, gridView1.FocusedRowHandle);
        }
        private void RepositoryItemLookUpEditPrdMsur_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            var msur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            var curProd = gridView1.FocusedRowObject as tblStockTransSub;
            if(curProd!=null&& msur!=null)
            SetTotalQuantity(curProd.stcPrdId, msur.ppmId, gridView1.FocusedRowHandle);
        }

        private void GridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && view.FocusedColumn == colstcQuantity)
            {
                if (!this.listPrdQuantity.ContainsKey(view.FocusedRowHandle)) return; ;
                if (Convert.ToInt32(e.Value) > this.listPrdQuantity[view.FocusedRowHandle])
                {
                    e.Valid = false;
                    e.ErrorText = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا الكمية المتوفرة أقل من الكمية المطلوب تحويلها" : "Sorry, not enough product quantity";
                }
            }
        }

        private void InitPrdQuantityAvailable()
        {
            for (int i = 0; i < this.tbStockSubListOld.Count(); i++)
                SetTotalQuantity(this.tbStockSubListOld.ElementAt(i).stcPrdId, this.tbStockSubListOld.ElementAt(i).stcMsurId, i);
        }

        private void SetTotalQuantity(int prdId, int msurId, int rowHandle)
        {
            double quantity = this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(prdId,
                this.clsTbPrdMsur.GetPrdPriceMsurById(msurId), this.tbStockMain.stcStrIdFrom);

            if (!this.listPrdQuantity.Any(x => x.Key == rowHandle))
                this.listPrdQuantity.Add(rowHandle, quantity);
            else
                this.listPrdQuantity[rowHandle] = quantity;
        }

        private void StcStrIdFromTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor == null) return;

            short strId = Convert.ToInt16(editor.GetColumnValue("id"));
            InitPrdBindingSoruceData(strId);
        }

        private void StcDescTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            UpdateDescProgressBarControl();
        }

        private void UpdateDescProgressBarControl()
        {
            UpdateDescProgressBarControls(stcDescTextEdit.Text.Length);
        }

        private void UpdateDescProgressBarControls(int value)
        {
            progressBarControl1.EditValue = value;
            labelDescCount.Text = String.Format("{0}", stcDescTextEdit.Properties.MaxLength - value);
        }
        IEnumerable<tblProduct> ProductInStorMain;
        private void InitPrdBindingSoruceData(short strId)
        {
            ProductInStorMain = this.clsPrdStore.GetProductListByStrId(strId);
            tblProductBindingSource.DataSource = ProductInStorMain;
        }

        private bool SaveData()
        {
            if (this.isNew == true)
                this.clsTbStockTransMain.Add(tblStockTransMainBindingSource.Current as tblStockTransMain);
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateStockNo()) return false;
            if (!ValidateGridData()) return false;
            if (!this.clsTbStockTransMain.SaveDB) return false;
            if (this.isNew) SaveStockTransSubData();
            if (this.clsTbStockTransSub.SaveDB /*&& SavePrdQuantity()*/) return true;

            return false;
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            string mssg = ((!MySetting.GetPrivateSetting.LangEng) ? "التحويل المخزني رقم : " : "Stock transfer no.: ") + this.tbStockMain.stcNo;
            _ucStockTrans.SetRefreshListDialog(mssg, this.tbStockMain.stcNo, this.isNew);
            DialogResult = DialogResult.OK;
        }

        private void BbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitStockMainObj();
            tblStockTransSubBindingSource.DataSource = null;
            tblStockTransSubBindingSource.DataSource = typeof(tblStockTransSub);
            UpdateDescProgressBarControls(0);
        }

        private void BbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SaveStockTransSubData()
        {
            int stocId = this.tbStockMain.stcId;

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colstcPrdId) == null) continue;
                tblStockTransSub tbStockSub = gridView1.GetRow(i) as tblStockTransSub;

                if (tbStockSub == null) continue;

                tbStockSub.stcMainId = stocId;
                tbStockSub.stcDate = stcDateDateEdit.DateTime.Date;
                tbStockSub.stcBrnId = Session.CurBranch.brnId;
                this.clsTbStockTransSub.Add(tbStockSub);

                SetPrdQuantityList(tbStockSub);
            }
        }

        private void SetPrdQuantityList(tblStockTransSub tbStockSub)
        {
            this.tbPrdQuantityDeductList.Add(InitPrdQuantityObj(tbStockSub, this.tbStockMain.stcStrIdFrom));
            this.tbPrdQuantityAddList.Add(InitPrdQuantityObj(tbStockSub, this.tbStockMain.stcStrIdTo));
        }

        //private bool SavePrdQuantity()
        //{
        //    if (this.isNew && this.clsPrdQuantityOpr.DeductPrdQuantity(this.tbPrdQuantityDeductList) &&
        //        this.clsPrdQuantityOpr.AddPrdQuantity(this.tbPrdQuantityAddList)) return true;
        //    if (!this.isNew)
        //    {
        //        IEnumerable<ClsProductQuantList> tbPrdQuantityStrToListOld = ClsStockPrdQuantityListConverter.InitPrdQuantityList(this.tbPrdQuantityStrFromListOld, this.tbStockMain.stcStrIdTo);
        //        IEnumerable<ClsProductQuantList> tbPrdQuantityStrToListNew = ClsStockPrdQuantityListConverter.InitPrdQuantityList(this.tbPrdQuantityStrFromListNew, this.tbStockMain.stcStrIdTo);
        //        return this.clsPrdQuantityOpr.UpdateProductQuantity(this.tbPrdQuantityStrFromListOld, this.tbPrdQuantityStrFromListNew,
        //            false) && this.clsPrdQuantityOpr.UpdateProductQuantity(tbPrdQuantityStrToListOld, tbPrdQuantityStrToListNew, true);
        //    }
        //    return false;
        //}

        private ClsProductQuantList InitPrdQuantityObj(tblStockTransSub tbStockSub, short strId)
        {
            return new ClsProductQuantList()
            {
                prdId = tbStockSub.stcPrdId,
                prdPriceMsurId = tbStockSub.stcMsurId,
                prdQuantity = tbStockSub.stcQuantity,
                prdStrId = strId
            };
        }

        private bool ValidateStockNo()
        {
            bool isValid = true;

            if (this.isNew || (!this.isNew && this.tbStockMain.stcNo != this.stockNo))
                isValid = this.clsTbStockTransMain.ValidateStockNo(this.tbStockMain.stcNo);
            if (!isValid)
            {
                string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا لقد تم إستخدام رقم التحويل المخزني مسبقا!" : "Sorry stock transfer number have been used!";
                XtraMessageBox.Show(mssg);
                stcNoTextEdit.Focus();
            }

            return isValid;
        }

        private bool ValidateGridData()
        {
            if (gridView1.FocusedColumn == colstcQuantity) gridView1.FocusedColumn = colstcPrdId;
            else gridView1.FocusedColumn = colstcQuantity;
            gridView1.UpdateCurrentRow();
            if (gridView1.DataRowCount > 0) return true;

            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب إدخال الاصناف المراد تحويلها أولاً!" : "Please select products to transfer stock quantity first!";
            XtraMessageBox.Show(mssg);
            gridControl1.Focus();
            gridView1.FocusedColumn = colstcPrdId;

            return false;
        }

        private void SetItemProperties()
        {
            bbiReset.Enabled = false;
            ItemForstcDate.Enabled = false;
            ItemForstcStrIdFrom.Enabled = false;
            ItemForstcStrIdTo.Enabled = false;
        }

        private void SetGridProperties()
        {
            DisableGridColumns(colstcPrdId);
            DisableGridColumns(colstcMsurId);
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            ItemForinvBarcodeSrch.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void DisableGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.TabStop = false;
        }


    }
}
