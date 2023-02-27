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
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using AccountingMS.Forms;

namespace AccountingMS
{

    public partial class formAddProudctMandobCpmm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //accountingEntities db = new accountingEntities();
        ClsTblProductQunatity clsTbPrdQuantity = new ClsTblProductQunatity();
        List<ClsProductQuantList> tbPrdQuantityAddList = new List<ClsProductQuantList>();
        List<ClsProductQuantList> tbPrdQuantityDeductList = new List<ClsProductQuantList>();
        IDictionary<int, double> listPrdQuantity = new Dictionary<int, double>();
        tblProduct tbProduct;
        tblPrdPriceMeasurment tbPrdMsur;
        //tblRepresentativeStore  tbRepStore;
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
        private readonly UCrepresentative _UCrepresentative;
        private tblStockTransMain tbStockMain;
        private bool isNew;
        private int stockNo;
        ClsTblBarcode clsTbBarcode;
        private IEnumerable<tblPrdPriceMeasurment> QueryData => db.tblPrdPriceMeasurments.AsQueryable()
                 .Where(x => x.ppmBrnId == Session.CurBranch.brnId).OrderBy(x => x.ppmPrdId);
        //public formAddProudctMandobCpmm(UCrepresentative UCrepresentative, ClsTblStore clsTbStore, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        public formAddProudctMandobCpmm(string repNameM)
        {
            InitializeComponent();
            InitObjects(clsTbStockTransMain, clsTbStockTransSub, clsTbStore, clsTbProduct, clsTbPrdMsur);
            InitBindingSourceData();
            NameMandobtextEdit1.Text = repNameM;
            repositoryColDelete.ButtonClick += RepositoryColDelete_ButtonClick;

            invBarcodeTextEdit.KeyDown += InvBarcodeTextEdit_KeyDown;

            stcStrIdFromTextEdit.EditValueChanged += StcStrIdFromTextEdit_EditValueChanged;
            AccountingMS.accountingEntities dbContext = new AccountingMS.accountingEntities();
            dbContext.tblProducts.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                dataLayoutControl2.DataSource = dbContext.tblProducts.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void RepositoryColDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var reps = db.RepCommissionDetails.Find(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colidrepcom)));
            db.RepCommissionDetails.Remove(reps);
            db.SaveChanges();
            refData();
        }

        void refData()
        {
            using (accountingEntities db = new accountingEntities())
            {
                repcompTextEdit1.Properties.DataSource = db.RepCommissions.ToList();
                gridControl1.DataSource = db.View_repComm.ToList().Where(m => m.idrepcom == Convert.ToInt32(repcompTextEdit1.EditValue) && m.repName == NameMandobtextEdit1.Text);
                // repcompTextEdit1.Properties.DataSource = db.RepCommissions.ToList();
            }

        }
        //private void ButtnDelete()
        //{
        //    RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
        //    gridControl1.RepositoryItems.Add(buttonDelete);
        //    buttonDelete.Buttons.Clear();
        //    buttonDelete.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
        //    buttonDelete.ButtonClick += ButtonDelete_ButtonClick;
        //    GridColumn clmnDelete = new GridColumn()
        //    {
        //        Name = "clmnDelete",
        //        Caption = "حذف",
        //        FieldName = "Delete",
        //        ColumnEdit = buttonDelete,
        //        VisibleIndex = 7,
        //        Width = 60

        //    };
        //    buttonDelete.TextEditStyle = TextEditStyles.HideTextEditor;
        //    gridView1.Columns.Add(clmnDelete);
        //    clmnDelete.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        //}
        //private void ButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView;
        //    if (view.FocusedRowHandle >= 0)
        //        view.DeleteSelectedRows();
        //}
        private void InitData(tblStockTransMain tbStockTransMain)
        {
            if (tbStockTransMain == null)
            {
                this.isNew = true;

                InitStockMainObj();
                //   ButtnDelete();
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
            if (string.IsNullOrWhiteSpace(stcStrIdFromTextEdit.Text))
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Choose the store first" : "اختر المخزن أولا");
                return;
            }
            if (string.IsNullOrWhiteSpace(stcStrIdFromTextEdit.EditValue.ToString())) return;


            SearchBarcodeData(invBarcodeTextEdit.Text);

            // invBarcodeTextEdit.EditValue = null;
        }

        public tblPrdPriceMeasurment GetPrdPriceMsurObjById(int msurId)
        {
            return QueryData.FirstOrDefault(x => x.ppmId == msurId);
        }

        private void SearchBarcodeData(string barcodeNo)
        {
            if (!ValidateBarcode(barcodeNo)) return;
            if (!ValidateGridPrdMsur()) return;
            var prod = GetPrdPriceMsurObjById(this.tbBarcode.brcPrdMsurId);
            PricetextEdit.Text = prod.ppmPrice.ToString();
            prdNameLookUpEdit.EditValue = prod.ppmPrdId;
        }
        private bool ValidateGridPrdMsur()
        {
            bool isValid = true;

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
            this.clsTbBarcode = new ClsTblBarcode();
        }

        private void InitBindingSourceData()
        {
            //tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
        }

        private void GridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }
        private void GridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
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
            // short strId = Convert.ToInt16(stcStrIdFromTextEdit.EditValue );
            InitPrdBindingSoruceData(strId);
        }

        private void StcDescTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            UpdateDescProgressBarControl();
        }

        private void UpdateDescProgressBarControl()
        {
        }

        private void UpdateDescProgressBarControls(int value)
        {
        }
        IEnumerable<tblProduct> ProductInStorMain;
        private void InitPrdBindingSoruceData(short strId)
        {
            tblProductBindingSource.DataSource = db.tblProducts.ToList().
                             Where(b => b.prdBrnId == strId);
        }

        private bool SaveData()
        {
            if (this.isNew == true)
            {


            }
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateStockNo()) return false;
            if (!this.clsTbStockTransMain.SaveDB) return false;
            if (this.isNew) SaveStockTransSubData();
            if (this.clsTbStockTransSub.SaveDB /*&& SavePrdQuantity()*/) return true;

            return false;
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (prdNameLookUpEdit.Text == "")
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Select the product first" : "حدد الصنف أولا");
                return;
            }
            using (accountingEntities db = new accountingEntities())
            {
                var repsD = db.RepCommissionDetails.ToList().FirstOrDefault(e => e.PrdId == Convert.ToInt32(prdNameLookUpEdit.EditValue) &&
                                                                    e.StorId == Convert.ToInt32(stcStrIdFromTextEdit.EditValue) &&
                                                                     e.RepCommission == Convert.ToInt32(repcompTextEdit1.EditValue));
                if (repsD != null)
                {
                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Attention, This item has already been registered" : "تم تسجيل هذا الصنف من قبل ");
                    return;
                }
                RepCommissionDetail reps = new RepCommissionDetail();
                reps.PrdId = Convert.ToInt32(prdNameLookUpEdit.EditValue);
                reps.StorId = Convert.ToInt32(stcStrIdFromTextEdit.EditValue);
                var repname = db.tblRepresentatives.ToList().FirstOrDefault(m => m.repName == NameMandobtextEdit1.Text);
                reps.RepId = repname.id;
                reps.RepCommission = Convert.ToInt32(repcompTextEdit1.EditValue);
                db.RepCommissionDetails.Add(reps);
                db.SaveChanges();
                refData();
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Ok, added successfully" : "تم اضافة الصنف للمندوب بنجاح ");
            }
        }

        private void BbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitStockMainObj();
            tblStockTransSubBindingSource.DataSource = null;
            tblStockTransSubBindingSource.DataSource = typeof(tblStockTransSub);
            UpdateDescProgressBarControls(0);
            repcompTextEdit1.Properties.DataSource = db.RepCommissions.ToList();
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
                // if (gridView1.GetRowCellValue(i, colstcPrdId) == null) continue;
                tblStockTransSub tbStockSub = gridView1.GetRow(i) as tblStockTransSub;
                if (tbStockSub == null) continue;
                tbStockSub.stcMainId = stocId;
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

            }

            return isValid;
        }

        private void SetItemProperties()
        {
            bbiReset.Enabled = false;
            ItemForstcStrIdFrom.Enabled = false;
        }

        private void SetGridProperties()
        {
            //  DisableGridColumns(colstcPrdId);
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
        accountingEntities db = new accountingEntities();
        private void formAddProudctMandob_Load(object sender, EventArgs e)
        {

            stcStrIdFromTextEdit.Properties.DataSource = (from Sto in db.tblStores.ToList() select new { id = Sto.id, strName = Sto.strName });
            stcStrIdFromTextEdit.Properties.DisplayMember = "strName";
            stcStrIdFromTextEdit.Properties.ValueMember = "id";

            refData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void prdNameLookUpEdit_KeyUp(object sender, KeyEventArgs e)
        {

        }

  

        private void invBarcodeTextEdit_KeyDown_1(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract) UpdateQuantity(e);
            //if (e.KeyCode == Keys.Enter)
            //    GetPrdBarcodeData(textEditBarcodeNo.Text);
        }

        private void textEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                FrmRepCommission frm = new FrmRepCommission();
                frm.ShowDialog();
            }
        }

        private void repcompTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            refData();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reps = db.RepCommissionDetails.Find(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colidrepcom)));
            db.RepCommissionDetails.Remove(reps);
            db.SaveChanges();
            refData();
        }
    }
}
