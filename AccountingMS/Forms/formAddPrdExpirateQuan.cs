using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddPrdExpirateQuan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db;
        ClsTblProductQunatity clsTbPrdQuantity;
        List<ClsProductQuantList> tbPrdQuantityDeductList = new List<ClsProductQuantList>();
       // IDictionary<int, double> listPrdQuantity = new Dictionary<int, double>();
        ClsTblPrdExpirateQuan clsTbPrdExpirateQuan;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblPrdPriceQuan clsTbPrdPrQuan;
        tblPrdexpirateQuanMain tbPrdExpirateQuanMain;
        ClsTblDefaultAccount clsTbDfltAcc;
        ClsTblAccount clsTbAccount;
        ClsTblGroupStr clsTbGroup;
        ClsProductByStore clsPrdStore;
        //ClsTblAsset clsTbAsset;
        tblAccount tbAccountPrdExp;
        tblAccount tbAccountPrdGrp;
        tblAsset tbAssetPrdExp;
        tblAsset tbAssetPrdGrp;
        ClsTblBarcode clsTbBarcode=new ClsTblBarcode();
        IEnumerable<ClsProductQuantList> tbPrdQuanListOld;
        IEnumerable<tblPrdExpirateQuan> tbListPrdExpirateQuan;
        ClsTblStore clsTbStore;

        private readonly UCprdExpirateQuan ucPrdExpirateQuan;
        private bool isNew;
        private string prdName;

        private async void FormAddPrdExpirateQuan_Load(object sender, EventArgs e)
        {
            await InitObjectsAsync();
            //IniDefaultDataAsync();
            ValidateDefaultAcc();
            stcStrIdFromTextEdit.Properties.DataSource = clsTbStore.GetStoreList;
            this.tbAccountPrdExp = this.clsTbAccount.GetAccountObjById(this.clsTbDfltAcc.GetDefaultAccIdByType(DefaultAccType.PrdExpirateAcc));
        }

        public formAddPrdExpirateQuan(UCprdExpirateQuan ucPrdExpirateQuan, ClsTblPrdExpirateQuan clsTbPrdExpirateQuan, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur, tblPrdexpirateQuanMain tbPrdExpirateQuanMain = null, ClsTblStore clsTbStore=null)
        {
            InitializeComponent();

            this.ucPrdExpirateQuan = ucPrdExpirateQuan;
            this.clsTbPrdExpirateQuan = clsTbPrdExpirateQuan;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
            this.clsTbStore = clsTbStore;
            clsTbPrdQuantity = new ClsTblProductQunatity();
            this.clsPrdStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuantity.GetPrdQuantityList);
            InitData(tbPrdExpirateQuanMain);
            InitEvents();
        }
      
        IEnumerable<tblProduct> ProductInStorMain;
        private void InitPrdBindingSoruceData(short strId)
        {
            ProductInStorMain = this.clsPrdStore.GetProductListByStrId(strId);
            tblProductBindingSource.DataSource = ProductInStorMain;
        }
        private void StcStrIdFromTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor == null) return;

            short strId = Convert.ToInt16(editor.GetColumnValue("id"));
            InitPrdBindingSoruceData(strId);
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
             if (e.Column.FieldName == colBarcode.FieldName)
            {
                tblPrdExpirateQuan st = e.Row as tblPrdExpirateQuan;
                if (st != null)
                     e.Value = this.clsTbBarcode.GetBarcodeNoByPrdMsurId(st.expPrdMsurId);
            }
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colexpPrdMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }
        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colexpPrdMsurId.FieldName)
                e.RepositoryItem = repositoryItemLookUpEditPrdMsur;
        }

        private void GridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colexpPrdMsurId)
                tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colexpPrdName)));
        }
        private void InitEvents()
        {
            this.Load += FormAddPrdExpirateQuan_Load;
           // expPrdPriceQuanIdTextEdit.EditValueChanged += ExpPrdPriceQuanIdTextEdit_EditValueChanged;
          //  expPrdPriceQuanIdTextEdit.CustomDisplayText += ExpPrdPriceQuanIdTextEdit_CustomDisplayText;
            invBarcodeTextEdit.KeyDown += InvBarcodeTextEdit_KeyDown;
            gridView1.FocusedColumnChanged += GridView1_FocusedColumnChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            stcStrIdFromTextEdit.EditValueChanged += StcStrIdFromTextEdit_EditValueChanged;
            repositoryItemSearchLookUpEditProduct.EditValueChanged += RepositoryItemSearchLookUpEditProduct_EditValueChanged;
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
        private void RepositoryItemSearchLookUpEditProduct_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            int prdId = Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("id"));
            var msur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId);
            gridView1.SetFocusedRowCellValue(colexpPrdName, prdId);
            gridView1.SetFocusedRowCellValue(colexpPrdMsurId, msur.ppmId);
            gridView1.SetFocusedRowCellValue(colexpPrdDate, DateTime.Now);
            gridView1.SetFocusedRowCellValue(colexpQuan, 1);
            gridView1.SetFocusedRowCellValue(colexpPrdPrice, msur.ppmPrice);
            gridView1.UpdateCurrentRow();

        //    SetTotalQuantity(prdId, msurId, gridView1.FocusedRowHandle);
        }
        private void ExpPrdPriceQuanIdTextEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = this.prdName;
        }

        private void InitData(tblPrdexpirateQuanMain tbPrdExpirateQuanMain)
        {
            db = new accountingEntities();

            if (tbPrdExpirateQuanMain == null)
            {
                this.isNew = true;
                ItemForexpMainId.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                InitNewObject();
                ButtnDelete();
            }
            else
            {
                ItemForinvBarcodeSrch.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.isNew = false;
                this.tbPrdExpirateQuanMain = tbPrdExpirateQuanMain.ShallowCopy();
            
                tblPrdexpirateQuanMainBindingSource.DataSource = this.tbPrdExpirateQuanMain;
                db.tblPrdexpirateQuanMains.Attach(this.tbPrdExpirateQuanMain);
                InitListObjects();
                InitSubData();
                SetGridProperties();
                SetItemProperties();
            }
        }
        private void SetItemProperties()
        {
            bbiReset.Enabled = false;
          //  ItemForexpPrdDate.Enabled = false;
            ItemForexpMainId.Enabled = false;
            ItemForStrId.Enabled = false;
        }

        private void SetGridProperties()
        {
            DisableGridColumns(colexpPrdId);
            DisableGridColumns(colexpPrdMsurId);
            DisableGridColumns(colexpPrdName);
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
        private void InitSubData()
        {
            this.tbListPrdExpirateQuan = this.clsTbPrdExpirateQuan.GetPrdExpirateQuanList.Where(x=>x.expMainId==this.tbPrdExpirateQuanMain.expMainId).ToList();
            IEnumerable<tblPrdExpirateQuan> PrdExpirateQuanSubList = this.tbListPrdExpirateQuan;
            tblPrdExpirateQuanBindingSource.DataSource = this.tbListPrdExpirateQuan;
            this.tbPrdQuanListOld = GetPrdQuanList(this.tbListPrdExpirateQuan);
        }

        private void InitListObjects()
        {
            this.tbListPrdExpirateQuan = new Collection<tblPrdExpirateQuan>();
        }
        private void InvBarcodeTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(invBarcodeTextEdit.Text)) return;
            SearchBarcodeData(invBarcodeTextEdit.Text);

            invBarcodeTextEdit.EditValue = null;
        }
        private void SearchBarcodeData(string barcodeNo)
        {
            if (!ValidateBarcode(barcodeNo)) return;
            if (!ValidateGridPrdMsur()) return;
            gridView1.AddNewRow();
            gridView1.SetFocusedRowCellValue(colexpPrdName, this.ProductData.tblProduct.id);
            gridView1.SetFocusedRowCellValue(colexpPrdMsurId, this.ProductData.PrdMeasurment.ppmId);
            gridView1.SetFocusedRowCellValue(colexpQuan, 1);
            gridView1.SetFocusedRowCellValue(colexpPrdDate, DateTime.Now);
            gridView1.SetFocusedRowCellValue(colexpPrdPrice, this.ProductData.PrdMeasurment.ppmPrice);
            gridView1.UpdateCurrentRow();

            //SetTotalQuantity(this.ProductData.tblProductRow1.id, this.ProductData.tblPrdPriceMeasurmentRow1.ppmId, gridView1.FocusedRowHandle);
            gridView1.UpdateCurrentRow();
        }
        private bool ValidateGridPrdMsur()
        {
            bool isValid = true;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colexpPrdMsurId)) == this.ProductData.tblBarcode.brcPrdMsurId)
                {
                    isValid = false;
                    gridView1.FocusedRowHandle = i;
                    break;
                }

            return isValid;
        }
        tblProductDataRow1 ProductData;
        private bool ValidateBarcode(string barcodeNo)
        {
            ProductData = this.clsTbBarcode.GetProductDataObjByBarcodeNo(barcodeNo);

            bool isValid = ProductData != null ? true : false;

            if (!isValid)
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found!" : "عذراً لم يتم العثور على الصنف المطلوب!");
            //bbiReset.PerformClick();
            return isValid;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbPrdPrQuan = new ClsTblPrdPriceQuan()));
            taskList.Add(Task.Run(() => this.clsTbAccount = new ClsTblAccount()));
            taskList.Add(Task.Run(() => this.clsTbDfltAcc = new ClsTblDefaultAccount()));
            taskList.Add(Task.Run(() => this.clsTbGroup = new ClsTblGroupStr()));
          //  taskList.Add(Task.Run(() => this.clsTbBarcode = new ClsTblBarcode()));
            taskList.Add(Task.Run(() => clsTbPrdQuantity = new ClsTblProductQunatity()));
            await Task.WhenAll(taskList);
        }

        //private async Task IniDefaultDataAsync()
        //{
        //    await Task.Run(() => tblPrdPriceQuanBindingSource.DataSource = this.clsTbPrdPrQuan.GetPrdPiceQuanActiveList());
        //}

        private void InitNewObject()
        {
            this.tbPrdExpirateQuanMain = new tblPrdexpirateQuanMain()
            {
                expMainDate = DateTime.Now,
                expMainBrnId = Session.CurBranch.brnId,
                expMainStrid = MySetting.DefaultSetting.defaultStrId
            };
            tblPrdexpirateQuanMainBindingSource.DataSource=this.tbPrdExpirateQuanMain;
        }
        private bool SaveData()
        {
            if (this.isNew == true)
                db.tblPrdexpirateQuanMains.Add(tblPrdexpirateQuanMainBindingSource.Current as tblPrdexpirateQuanMain);
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateGridData()) return false;
            if (!ClsSaveDB.Save(db, LogHelper.GetLogger())) return false;
            if (this.isNew) SavePrdexpirateQuanSubData();
            if (this.clsTbPrdExpirateQuan.SaveDB/*&& UpdateQuantity()*/ && SaveAssetAcc()) return true;

            return false;
        }
        private void SavePrdexpirateQuanSubData()
        {
            var prExMain = tblPrdexpirateQuanMainBindingSource.Current as tblPrdexpirateQuanMain;
            if (prExMain == null) return;
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colexpPrdId) == null) continue;
                tblPrdExpirateQuan tbPrdExpirateQuan = gridView1.GetRow(i) as tblPrdExpirateQuan;

                if (tbPrdExpirateQuan == null) continue;
                tbPrdExpirateQuan.expMainId = prExMain.expMainId;
                tbPrdExpirateQuan.expStrid = prExMain.expMainStrid;
                tbPrdExpirateQuan.expDate = expPrdDateDateEdit.DateTime.Date;
                tbPrdExpirateQuan.expBrnId = Session.CurBranch.brnId;
                this.clsTbPrdExpirateQuan.Add(tbPrdExpirateQuan);
                this.tbPrdQuantityDeductList.Add(InitPrdQuantityObj(tbPrdExpirateQuan));
            }
        }
     

        //private bool UpdateQuantity()
        //{
        //    if (this.isNew)
        //        return this.clsPrdQuanOpr.DeductPrdQuantity(tbPrdQuantityDeductList) && this.clsPrdPrQuanOpr.DeductPrdQuantity(tbPrdQuantityDeductList);
        //    else
        //        return this.clsPrdQuanOpr.UpdateProductQuantity(this.tbPrdQuanListOld, GetPrdQuanList(tblPrdExpirateQuanBindingSource.List as IEnumerable<tblPrdExpirateQuan>), false) &&
        //            this.clsPrdPrQuanOpr.UpdateProductQuantity(this.tbPrdQuanListOld, GetPrdQuanList(tblPrdExpirateQuanBindingSource.List as IEnumerable<tblPrdExpirateQuan>), false);
        //}
        private bool ValidateGridData()
        {
            if (gridView1.FocusedColumn == colexpQuan) gridView1.FocusedColumn = colexpPrdName;
            else gridView1.FocusedColumn = colexpQuan;
            gridView1.UpdateCurrentRow();
            if (gridView1.DataRowCount > 0) return true;

            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب إدخال الاصناف التالفة أولاً!" : "Please select products to damaged quantity first!";
            XtraMessageBox.Show(mssg);
            gridControl1.Focus();
            gridView1.FocusedColumn = colexpPrdName;

            return false;
        }

       
        List<tblAsset> assest;
        private bool SaveAssetAcc()
        {
            if (!isNew)
            {
              assest = db.tblAssets.AsQueryable().Where(x => x.asDate >= Session.CurrentYear.fyDateStart
              && x.asDate <= Session.CurrentYear.fyDateEnd
              && x.asBrnId == Session.CurBranch.brnId
              && x.asStatus == (byte)AssetType.PrdExpirate).ToList();
            }
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                tblPrdExpirateQuan tbPrdExpirateQuan = gridView1.GetRow(i) as tblPrdExpirateQuan;
                if (tbPrdExpirateQuan == null) continue;
                this.tbAccountPrdGrp = this.clsTbAccount.GetAccountObjByNo(this.clsTbGroup.GetGroupAccNoById(this.clsTbProduct.GetPrdGroupIdByPrdId(Convert.ToInt32(tbPrdExpirateQuan.expStrid))));
                double amount = Math.Round(tbPrdExpirateQuan.expPrdPrice * Convert.ToDouble(tbPrdExpirateQuan.expQuan), 2, MidpointRounding.AwayFromZero);

                if (this.isNew)
                {
                    if(amount==0) continue;
                    this.tbAssetPrdExp = AddAssetObj(this.tbAccountPrdExp, 1);
                    this.tbAssetPrdGrp = AddAssetObj(this.tbAccountPrdGrp, 2);
                    this.tbAssetPrdExp.asEntId = tbPrdExpirateQuan.expId;
                    this.tbAssetPrdGrp.asEntId = tbPrdExpirateQuan.expId;
                    this.tbAssetPrdExp.asDebit = amount;
                    this.tbAssetPrdGrp.asCredit = amount;
                }
                else
                {
                    var Currassest = assest.Where(x => x.asEntId == tbPrdExpirateQuan.expId).ToList();
                    if (assest.Count > 0)
                    {
                        this.tbAssetPrdExp = Currassest.FirstOrDefault(x => x.asView == 1);
                        this.tbAssetPrdGrp = Currassest.FirstOrDefault(x => x.asView == 2);
                        db.tblAssets.Attach(this.tbAssetPrdExp);
                        db.tblAssets.Attach(this.tbAssetPrdGrp);
                        this.tbAssetPrdExp.asDebit = amount;
                        this.tbAssetPrdGrp.asCredit = amount;
                    }
                }
            }
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

       

     

        private tblAsset AddAssetObj(tblAccount tbAccount, byte asView)
        {
            var tbAsset = new tblAsset()
            {
                asEntId = 0,
                asAccNo = tbAccount.accNo,
                asAccName = tbAccount.accName,
                asDate = DateTime.Now,
                asView = asView,
                asUserId = Session.CurrentUser.id,
                asBrnId = Session.CurBranch.brnId,
                asStatus = (byte)AssetType.PrdExpirate
            };
            db.tblAssets.Add(tbAsset);

            return tbAsset;
        }

       


       
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            if (!SaveData()) return;
          //  if (!SetAssetEntId()) return;

            this.ucPrdExpirateQuan.SetRefreshDialogList($"الاصناف التالفة", this.isNew);
            DialogResult = DialogResult.OK;
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitNewObject();
           ResetData();

        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private ClsProductQuantList InitPrdQuantityObj(tblPrdExpirateQuan tbPrdExpirateQuan)
        {
            return new ClsProductQuantList()
            {
                prdId = tbPrdExpirateQuan.expPrdId,
                prdPriceMsurId = tbPrdExpirateQuan.expPrdMsurId,
                prdQuantity = tbPrdExpirateQuan.expQuan,
                prdStrId = tbPrdExpirateQuan.expStrid
            };
        }
        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            return true;
        }

        private IEnumerable<ClsProductQuantList> GetPrdQuanList(IEnumerable<tblPrdExpirateQuan> tbPrdExpirateQuan)
        {
            List<ClsProductQuantList> ProductQuantList = (from p in tbPrdExpirateQuan
                                                          select new ClsProductQuantList
                                                          {
                                                              prdId = p.expPrdId,
                                                              prdPriceMsurId = p.expPrdMsurId,
                                                              prdPrice = p.expPrdPrice,
                                                              prdQuantity = p.expQuan,
                                                              prdStrId = p.expStrid
                                                          }).ToList();
            return ProductQuantList;
        }

        private void ValidateDefaultAcc()
        {
            if (this.clsTbDfltAcc.IsDefaultAccFound((byte)DefaultAccType.PrdExpirateAcc, Session.CurBranch.brnId)) return;

            string mssg = "عذرا يرجى إدخال حساب الأصناف التالفه من إعدادات النظام أولاُ!";
            mssg += "\n\nإدارة النظام -> الإعدادات الإفتراضية -> إعدادات المخازن.";
            ClsXtraMssgBox.ShowError(mssg);

            this.Close();
        }

        private void ResetData()
        {
            tblPrdExpirateQuanBindingSource.Clear();
        }
    }
}