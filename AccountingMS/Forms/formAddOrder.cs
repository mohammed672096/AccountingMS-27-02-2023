using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblOrderMain clsTbOrderMain;
        ClsTblOrderSub clsTbOrderSub;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTbBarcode;
        tblOrderMain tbOrderMain;
        tblProduct tbProduct;
        tblPrdPriceMeasurment tbPrdMsur;
        tblBarcode tbBarcode;
        IList<tblOrderSub> tbOrderSubList;
        CultureInfo _ci;
        ComponentResourceManager _resource;

        private readonly ucOrders ucOrders;
        private readonly OrderType orderType;
        private bool isNew;
        private bool isValidateClose = true;
        private int ordNoOld;
        private byte taxPercent = MySetting.GetPrivateSetting.taxDefault;

        private async void FormAddOrder_Load(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            InitForm();
            await InitObjectsAsync();
            InitBindingSourceData();
            BsiCount();
            UpdateProgrsesBarDesc();

            flyDialog.WaitForm(this, 0);
            textEditBarcodeNo.Focus();
        }

        public formAddOrder(ucOrders ucOrders, OrderType orderType, ClsTblOrderMain clsTbOrderMain, ClsTblOrderSub clsTbOrderSub, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur, tblOrderMain tbOrderMain = null)
        {
            this.ucOrders = ucOrders;
            this.orderType = orderType;
            InitializeComponent();
            GetResources();
            InitObjects(clsTbOrderMain, clsTbOrderSub, clsTbProduct, clsTbPrdMsur);
            InitData(tbOrderMain);
            InitDefaultData();
            InitEvents();

        }
        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl1.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.ucOrderEn));

            foreach (var control in mainRibbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    c.Visibility = BarItemVisibility.Always;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView1.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (LayoutControlItem item in layoutControlGroupMain.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }
            foreach (LayoutControlItem item in layoutControlGroupDesc.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }
            foreach (LayoutControlItem item in layoutControlGroup2.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }

            _resource.ApplyResources(layoutControlGroupDesc, layoutControlGroupDesc.Name, _ci);
            _resource.ApplyResources(layoutControlGroupMain, layoutControlGroupMain.Name, _ci);
            _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name, _ci);
        }
        private void InitEvents()
        {
            this.Load += FormAddOrder_Load;
            this.FormClosing += FormAddOrder_FormClosing;

            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;

            gridView1.InitNewRow += GridView1_InitNewRow;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.FocusedColumnChanged += GridView1_FocusedColumnChanged;

            repoItemSLEProduct.EditValueChanged += RepoItemSLEProduct_EditValueChanged;

            ordDescTextEdit.EditValueChanging += OrdDescTextEdit_EditValueChanging;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
        }

        private async Task InitObjectsAsync()
        {
            await Task.Run(() => this.clsTbBarcode = new ClsTblBarcode());
        }

        private void InitObjects(ClsTblOrderMain clsTbOrderMain, ClsTblOrderSub clsTbOrderSub, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            this.clsTbOrderMain = clsTbOrderMain;
            this.clsTbOrderSub = clsTbOrderSub;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList;
        }

        private void InitBindingSourceData()
        {
            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList;
        }

        private void InitDefaultData()
        {
            this.Text = ClsOrderStatus.GetString(this.orderType);
        }

        private void InitData(tblOrderMain tbOrderMain)
        {
            if (tbOrderMain == null)
            {
                InitOrderMainObj();
            }
            else
            {
                InitOrderUpdateData(tbOrderMain);
                InitEditProperties();
            }
        }

        private void InitOrderMainObj()
        {
            this.isNew = true;
            this.tbOrderMain = new tblOrderMain()
            {
                ordNo = this.clsTbOrderMain.GetOrderNewNo(),
                ordDate = DateTime.Now,
                ordUsrId = Session.CurrentUser.id,
                ordBrnId = Session.CurBranch.brnId,
                ordStatus = (byte)this.orderType
            };
            tblOrderMainBindingSource.DataSource = this.tbOrderMain;
        }

        private void InitOrderUpdateData(tblOrderMain tbOrderMain)
        {
            this.isNew = false;
            this.ordNoOld = tbOrderMain.ordNo;
            this.tbOrderMain = tbOrderMain;
            this.tbOrderSubList = this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId);

            tblOrderMainBindingSource.DataSource = this.tbOrderMain;
            tblOrderSubBindingSource.DataSource = this.tbOrderSubList;
        }

        private void InitOrderSubObj()
        {
            tblOrderSubBindingSource.DataSource = null;
            tblOrderSubBindingSource.DataSource = typeof(tblOrderSub);
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEditBarcodeNo.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteRow();
                e.Handled = true;
            }
        }

        private void DeleteRow()
        {
            var tbOrderSub = gridView1.GetFocusedRow() as tblOrderSub;
            if (tbOrderSub == null) return;

            if (tbOrderSub?.ordId != 0) this.clsTbOrderSub.Remove(tbOrderSub);
            gridView1.DeleteSelectedRows();
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colordMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colordMsurId.FieldName) e.RepositoryItem = repoItemLookUpEditPrdMsur;
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitPrdMsurData();
        }

        private void GridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == colordMsurId.FieldName) InitPrdMsurData();
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!ValidateOrderType()) return;

            if (e.Column.FieldName == colordQuantity.FieldName)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, colordPrice) == null) return;
                if (e?.Value == null || !double.TryParse(e.Value.ToString(), out double quantity)) return;

                double price = GetPrice();
                price *= quantity;
                double tax = price * (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, colordTaxPercent)) / 100);
                double total = Math.Round(price + tax, 3, MidpointRounding.AwayFromZero);

                gridView1.SetFocusedRowCellValue(colordTax, tax);
                gridView1.SetRowCellValue(e.RowHandle, colordTotal, total);
            }
            if (e.Column.FieldName == colordPrice.FieldName)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, colordQuantity) == null) return;
                if (e?.Value == null || !double.TryParse(e.Value.ToString(), out double price)) return;

                double quantity = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, colordQuantity));
                price *= quantity;
                double tax = price * (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, colordTaxPercent)) / 100);
                double total = Math.Round(price + tax, 3, MidpointRounding.AwayFromZero);

                gridView1.SetFocusedRowCellValue(colordTax, tax);
                gridView1.SetRowCellValue(e.RowHandle, colordTotal, total);
            }
            if (e.Column.FieldName == colordPriceSale.FieldName)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, colordQuantity) == null) return;
                if (e?.Value == null || !double.TryParse(e.Value.ToString(), out double price)) return;

                double quantity = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, colordQuantity));
                price *= quantity;
                double tax = price * (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, colordTaxPercent)) / 100);
                double total = Math.Round(price + tax, 3, MidpointRounding.AwayFromZero);

                gridView1.SetFocusedRowCellValue(colordTax, tax);
                gridView1.SetRowCellValue(e.RowHandle, colordTotal, total);
            }
        }

        private void RepoItemSLEProduct_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            this.tbProduct = editor.Properties.View.GetFocusedRow() as tblProduct;

            if (this.tbProduct == null) return;

            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(this.tbProduct.id);
            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur?.ppmId ?? 0);

            AddNewRow(gridView1.FocusedRowHandle);

            if (this.tbProduct.prdStatus == (byte)ProductType.Service)
                gridView1.SetFocusedRowCellValue(colordTaxPercent, this.taxPercent);
        }

        private void RepoItemLookUpEditPrdMsur_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            if (this.tbPrdMsur == null) return;

            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);

            gridView1.SetFocusedRowCellValue(colordPrdBarcode, this.tbBarcode?.brcNo);
            gridView1.SetFocusedRowCellValue(colordPrice, tbPrdMsur?.ppmPrice);
            if (this.tbProduct == null) this.tbProduct = clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur.ppmPrdId);
            SetSalePrice(gridView1.FocusedRowHandle, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur));
            CalculateTotal();
        }

        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            AddNewRow(e.RowHandle);
        }

        private void AddNewRow(int rowHandle)
        {
            if (this.tbPrdMsur == null) return;
            gridView1.SetRowCellValue(rowHandle, colordPrdBarcode, this.tbBarcode?.brcNo);
            gridView1.SetRowCellValue(rowHandle, colordPrdId, this.tbProduct?.id);
            gridView1.SetRowCellValue(rowHandle, colordMsurId, this.tbPrdMsur?.ppmId);
            gridView1.SetRowCellValue(rowHandle, colordQuantity, 1);

            if (this.orderType == OrderType.Purchase || this.orderType == OrderType.PriceOffer)
            {
                gridView1.SetRowCellValue(rowHandle, colordTaxPercent, this.taxPercent);
                gridView1.SetRowCellValue(rowHandle, colordPrice, this.tbPrdMsur?.ppmPrice);
            }
            SetSalePrice(rowHandle, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur));
            UpdateGrid();
            CalculateTotal();
        }

        private void UpdateGrid()
        {
            gridView1.UpdateCurrentRow();
            ClearBarcodeNoText();
            BsiCount();
        }

        private void SetSalePrice(int rowHandle, double? salePrice)
        {
            if (this.orderType != OrderType.PriceOffer) return;
            gridView1.SetRowCellValue(rowHandle, colordPriceSale, salePrice);
        }

        private double GetPrice()
        {
            return Convert.ToDouble(gridView1.GetFocusedRowCellValue(this.orderType == OrderType.PriceOffer ? colordPriceSale : colordPrice));
        }

        private void CalculateTotal()
        {
            if (!ValidateOrderType()) return;

            double price = GetPrice();
            double quantity = Convert.ToDouble(gridView1.GetFocusedRowCellValue(colordQuantity));
            price *= quantity;
            double tax = price * (Convert.ToDouble(gridView1.GetFocusedRowCellValue(colordTaxPercent)) / 100);
            double total = Math.Round(price + tax, 3, MidpointRounding.AwayFromZero);

            gridView1.SetFocusedRowCellValue(colordTax, tax);
            gridView1.SetFocusedRowCellValue(colordTotal, total);
        }

        private bool ValidateOrderType()
        {
            return (byte)this.orderType >= (byte)OrderType.Purchase;
        }

        private void InitPrdMsurData()
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colordPrdId)));
        }

        private void BsiCount()
        {
            bsiCount.Caption = (!MySetting.GetPrivateSetting.LangEng ? "العدد: " : "RECORDS: ") + tblOrderSubBindingSource.Count;
        }

        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrEmpty(textEditBarcodeNo.Text)) return;

            string barcodeNo = textEditBarcodeNo.Text;
            if (!ValidateBarcodeNo(barcodeNo)) return;
            if (IsGridBarcodeNoFound(barcodeNo)) return;

            this.tbProduct = this.clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur.ppmPrdId);
            gridView1.AddNewRow();
        }

        private bool ValidateBarcodeNo(string barcodeNo)
        {
            bool isValid = this.clsTbBarcode.IsBarcodeNoFound(barcodeNo);

            if (!isValid)
            {
                ClsXtraMssgBox.ShowError("عذراُ، رقم الباركود غير موجود!");
                return false;
            }

            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcodeNo);
            if (this.tbBarcode == null) return false;

            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(this.tbBarcode.brcPrdMsurId);
            if (tbPrdMsur == null) return false;

            ClearBarcodeNoText();

            return true;
        }

        private bool IsGridBarcodeNoFound(string barcodeNo)
        {
            gridView1.UpdateCurrentRow();
            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (gridView1.GetRowCellValue(i, colordPrdBarcode).ToString() == barcodeNo)
                {
                    gridView1.SetRowCellValue(i, colordQuantity, Convert.ToDouble(gridView1.GetRowCellValue(i, colordQuantity)) + 1);
                    ClearBarcodeNoText();
                    CalculateTotal();
                    return true;
                }

            return false;
        }

        private void ClearBarcodeNoText()
        {
            textEditBarcodeNo.EditValue = null;
        }

        private void OrdDescTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            UpdateProgrsesBarDesc();
        }

        private void UpdateProgrsesBarDesc()
        {
            UpdateProgrsesBarDesc(ordDescTextEdit.Text.Length);
        }

        private void UpdateProgrsesBarDesc(int value)
        {
            progressBarControl1.EditValue = value;
            labelDescCount.Text = String.Format("{0}", ordDescTextEdit.Properties.MaxLength - value);
        }

        private bool SaveData()
        {
            UpdateProperties();
            if (!ValidateData()) return false;
            if (SaveOrderMain() && SaveOrderSub()) return true;
            return false;
        }

        private void UpdateProperties()
        {
            textEditBarcodeNo.Focus();
            gridView1.FocusedColumn = colordId;
            gridView1.UpdateCurrentRow();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            this.ucOrders.SetRefreshListDialog(GetSaveMssg(), this.tbOrderMain, this.tbOrderSubList, this.isNew);
            this.isValidateClose = false;

            DialogResult = DialogResult.OK;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;
            flyDialog.ShowDialogFormBelowRIbbon(this, mainRibbonControl, GetSaveMssg(), this.isNew);

            PrintInvoice();
            this.clsTbOrderMain = new ClsTblOrderMain(this.orderType);
            ResetData();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetData();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!IsCloseForm()) return;

            this.isValidateClose = false;
            this.Close();
        }

        private void FormAddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isValidateClose) return;
            e.Cancel = !IsCloseForm();
        }

        private bool IsCloseForm()
        {
            bool isCloseForm = ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إغلاق الشاشة؟") == DialogResult.Yes ? true : false;

            if (isCloseForm && !this.isNew)
            {
                this.clsTbOrderMain.ResetChanges(this.tbOrderMain);
                this.clsTbOrderSub.ResetChanges(this.tbOrderSubList);
            }

            return isCloseForm;
        }

        private void ResetData()
        {
            this.isNew = true;
            InitOrderMainObj();
            InitOrderSubObj();
            BsiCount();
            UpdateProgrsesBarDesc();
        }

        private bool ValidateData()
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return false;
                if (!ValidateOrdNo()) return false;
                if (!ValidateGridData()) return false;
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddOrder ValidateData", true);
                return false;
            }
            return true;
        }

        private bool SaveOrderMain()
        {
            try
            {
                if (this.isNew) this.clsTbOrderMain.Add(tblOrderMainBindingSource.Current as tblOrderMain);
                return this.clsTbOrderMain.SaveDB;
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddOrder SaveOrderMain", true);
                return false;
            }
        }

        private bool SaveOrderSub()
        {
            try
            {
                SaveGridData();
                return this.clsTbOrderSub.SaveDB;
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddOrder SaveOrderSub", true);
                return false;
            }
        }

        private void SaveGridData()
        {
            this.tbOrderSubList = new Collection<tblOrderSub>();
            int ordMainId = this.tbOrderMain.ordId;

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colordPrdId) == null) continue;

                var tbOrderSub = gridView1.GetRow(i) as tblOrderSub;
                if (tbOrderSub == null) continue;

                tbOrderSub.ordMainId = ordMainId;
                tbOrderSub.ordDate = ordDateDateEdit.DateTime.Date;
                tbOrderSub.ordBrnId = Session.CurBranch.brnId;
                tbOrderSub.ordStatus = (byte)this.orderType;

                this.tbOrderSubList.Add(tbOrderSub);
                if (tbOrderSub?.ordId == 0) this.clsTbOrderSub.Add(tbOrderSub);
            }
        }

        private bool ValidateOrdNo()
        {
            bool isValid = true;

            if (this.isNew && this.clsTbOrderMain.IsOrdNoFound(this.tbOrderMain.ordNo)) isValid = false;
            if (!this.isNew && this.ordNoOld != this.tbOrderMain.ordNo && this.clsTbOrderMain.IsOrdNoFound(this.tbOrderMain.ordNo)) isValid = false;

            if (!isValid) ClsXtraMssgBox.ShowError((!MySetting.GetPrivateSetting.LangEng) ?
                $"عذراً رقم {ClsOrderStatus.GetString(this.orderType)}: {this.tbOrderMain.ordNo} تم إستخدامه مسبقا!" : $"Sorry order number: {this.tbOrderMain.ordNo} has been used!");

            return isValid;
        }

        private bool ValidateGridData()
        {
            bool isValid = true;
            if (gridView1.DataRowCount == 0) isValid = false;
            if (!isValid) ClsXtraMssgBox.ShowError((!MySetting.GetPrivateSetting.LangEng) ?
                "عذرا لا يوجد بيانات في الجدول!" : "Sorry there is no data in the grid!");

            return isValid;
        }

        private string GetSaveMssg()
        {
            return (!MySetting.GetPrivateSetting.LangEng) ? $"{ClsOrderStatus.GetString(this.orderType)} رقم : {this.tbOrderMain.ordNo}" : $"order no.: {this.tbOrderMain.ordNo}";
        }

        private void PrintInvoice()
        {
            if (MySetting.DefaultSetting.ordersShowPrintMssg) PrintInvoiceMssg();
            else Print();
        }

        private void PrintInvoiceMssg()
        {
            if (ClsXtraMssgBox.ShowQuesPrint((!MySetting.GetPrivateSetting.LangEng) ? $"هل تريد طباعة الفاتورة رقم: {tbOrderMain.ordNo}"
                : $"Do you want to print Invoice no.: {tbOrderMain.ordNo}") != DialogResult.Yes) return;
            Print();
        }

        private void Print()
        {
            flyDialog.WaitForm(this, 1);
            if (MySetting.DefaultSetting.ordersPrintPreview)
            {
                var frm = new ReportForm(ReportType.OrderInvoice, tblObject: this.tbOrderMain,
                 tblObjectList: this.tbOrderSubList, clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur);
                frm.Show();
                flyDialog.WaitForm(this, 0,frm);
            }
            else
            {
                ClsPrintReport.PrintOrder(this.tbOrderMain, this.tbOrderSubList, this.clsTbProduct, this.clsTbPrdMsur);
                flyDialog.WaitForm(this, 0);
            }
        }

        private void InitEditProperties()
        {
            bbiReset.Visibility = BarItemVisibility.Never;
            bbiSaveAndNew.Visibility = BarItemVisibility.Never;
        }

        private void InitForm()
        {
            InitPriceOfferForm();
            InitOrdPurchaseProperties();
        }

        private void InitPriceOfferForm()
        {
            if (this.orderType != OrderType.PriceOffer) return;
            this.Text = !MySetting.GetPrivateSetting.LangEng ? "عرض سعر" : "Offer Price";
            layoutControlGroupMain.Text = !MySetting.GetPrivateSetting.LangEng ? "بيانات الفاتورة الرئيسية" : "Main Order Data";
            layoutControlGroupDesc.Text = !MySetting.GetPrivateSetting.LangEng ? "البيان" : "Description";
            ItemForordNo.Text = !MySetting.GetPrivateSetting.LangEng ? "رقم الفاتورة:" : "Order No";

            int colIndex = colordQuantity.VisibleIndex;

            InitColumnProperties(colordPriceSale, ++colIndex);
            InitColumnProperties(colordTax, ++colIndex);
            InitColumnProperties(colordTotal, ++colIndex);
        }

        private void InitOrdPurchaseProperties()
        {
            if (this.orderType != OrderType.Purchase) return;



            InitPurchaseGridProp();
        }

        private void InitPurchaseGridProp()
        {
            InitColumnProperties(colordPrice, 4);
            InitColumnProperties(colordTax, 5);
            InitColumnProperties(colordTotal, 6);
        }

        private void InitColumnProperties(GridColumn colOrder, int visibileIndex)
        {
            colOrder.Visible = true;
            colOrder.VisibleIndex = visibileIndex;
            colOrder.OptionsColumn.ShowInCustomizationForm = true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
