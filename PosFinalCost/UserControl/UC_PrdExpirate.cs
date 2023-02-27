using PosFinalCost.Classe;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.ExpressionEditor;
using System.Data.Entity;
using static PosFinalCost.Session;
using System.Transactions;
//using DevExpress.XtraReports.Design;

namespace PosFinalCost.Forms
{
    public partial class UC_PrdExpirate : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ProductData productData = new ProductData();
        FormSearchProduct FormDialogPrdSearch;
        IDictionary<int, double> listPrdQuantDic;
        IDictionary<int, double?> listPrdPriceDic;
        IDictionary<int, string> listPrdMsurName;
        IDictionary<int, double> listPrdQuanAvlbDic;
        MediaPlayer barcodeBeep;
        Uri barcodeBeepUri;
        private bool gridValid = true;
        public bool isNew;
        public UC_PrdExpirate(PrdExpirateMain obj, IEnumerable<PrdExpirateDetail> subObj)
        {
            InitializeComponent();
            //new ClsUserRoleValidation(this, UserControls.Sale);
            this.Load += UC_PrdExpirate_Load;
            InitDefaultData();
            InitData(obj, subObj);
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.listPrdQuantDic = new Dictionary<int, double>();
            GetResources();
            InitEvents();
        }
        #region Events
        private void UC_PrdExpirate_Load(object sender, EventArgs e)
        {
            Task.Run(() => InitFlyDialogPrdSrch());
            InitBarcodeBeep();
            textEditBarcodeNo.Focus();
            layoutControlGrooupMain.BestFit();

            SetSettingSales();
            var Su = PrdExpirateMainBindingSource.Current as PrdExpirateMain;
            InitPrdBindingSourceData((Su?.StorID as short?) ?? 0);
            Task.Run(() => SetFont());
        }
        private void RepositoryItemBtnBarcode_Click(object sender, EventArgs e)
        {
            if (gridView.GetRowCellValue(gridView.FocusedRowHandle, "PrdBarcode") != null)
            {
                formBarcode frm = new formBarcode();
                frm.Show();
                frm.SearchProduct(gridView.GetRowCellValue(gridView.FocusedRowHandle, "PrdBarcode").ToString());
            }
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void SetFont()
        {
            this.Invoke(new MethodInvoker(delegate {
                if (Program.My_Setting.SystemFontSale == Program.My_Setting.SystemFont) return;
                Font fontConverter = (Font)converter.ConvertFromString(Program.My_Setting.SystemFontSale);
                this.layoutControlGrooupMain.AppearanceItemCaption.Font = fontConverter;
                dataLayConMain.Items.Where(x => x is LayoutControlItem).ToList().ForEach(y =>
                ((LayoutControlItem)y).Owner.Appearance.Control.Font = fontConverter);
                bindingNavigator11.Font = fontConverter;
                repositoryItemSearchLookUpEditPrdNo.View.Appearance.Row.Font =
                repositoryItemSearchLookUpEditPrdNo.View.Appearance.HeaderPanel.Font =
                    repositoryItemLookUpEditMeasurment.AppearanceDropDownHeader.Font =
                repositoryItemLookUpEditMeasurment.AppearanceDropDown.Font = fontConverter;
                gridView.Appearance.HeaderPanel.Font = gridView.Appearance.Row.Font = gridView.Appearance.FooterPanel.Font = fontConverter;
            }));
            
        }
        private void SetSettingSales()
        {
                btnEditQuantity.Visible = btnEditQuantity.Visible ? Session.CurrSettings.CanChangeQtyInSales : btnEditQuantity.Visible;
                colQuanMain.OptionsColumn.AllowEdit = Session.CurrSettings.CanChangeQtyInSales;
                DateDateEdit.ReadOnly = !Session.CurrSettings.CanChangeSalesInvoiceDate;
        }
        private void InitEvents()
        {
            dataLayConMain.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.FocusedColumnChanged += GridView_FocusedColumnChanged;
            gridView.RowCountChanged += GridView_RowCountChanged;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.CustomRowCellEditForEditing += GridView_CustomRowCellEditForEditing;
            gridView.InvalidRowException += GridView_InvalidRowException;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            StrIdLookUpEdit.EditValueChanged += StrIdLookUpEdit_EditValueChanged;
            repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            repositoryItemBtnBarcode.Click += RepositoryItemBtnBarcode_Click;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
            btnClose.Click += BbiClose_Click;
            btnEditQuantity.Click += BbiEditQuantity_Click;
            btnReset.Click += btnReset_Click;
            btnSave.Click += BbiSave_Click;
            btnSaveAndNew.Click += BbiSaveAndNew_Click;
        }

        private void GridView_RowCountChanged(object sender, EventArgs e)
        {
            labelItemsCount.Text =$"عدد الاصناف :{PrdExpirateDetailBindingSource.Count}";
        }

        public bool FunClose() => (XtraMessageBox.Show(_resource.GetString("CloseFormMssgExpirPrd"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes);
        private void BbiClose_Click(object sender, EventArgs e)
        {
            if (!FunClose()) return;
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
                (this.Parent as XtraTabPage).Dispose();
            else
                this.ParentForm.Close();
        }

        private void BbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            PrdExpirateMain tbPrdExpirateMain = GetCurPrdExpirateMain();
            string mssg = string.Format(_resource.GetString("PrdExipertySuccessMssg"), tbPrdExpirateMain.ID);
            Form temp = this.ParentForm;
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
            {
                (this.Parent as XtraTabPage).Dispose();
                flyDialog.ShowDialogForm(temp, mssg, this.isNew);
            }
            else
            {
                this.ParentForm.Close();
                flyDialog.ShowDialogForm(((FormEntryMain)temp).parent1, mssg, this.isNew);
            }
          
        }
        private void BbiSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Session.CurrSettings.ShowResetMssg)
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }
        private void BbiEditQuantity_Click(object sender, EventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain))).ShowDialog();
        }
        private void StrIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            InitPrdBindingSourceData((StrIdLookUpEdit.EditValue as short?) ?? 0);
        }
        PrdExpirateMain GetCurPrdExpirateMain()=> PrdExpirateMainBindingSource.Current as PrdExpirateMain;
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.Product == null || !isNew || p != productData?.Product?.ID)
                GetData(null, p);
            if (e.FocusedRowHandle >= 0)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == p).ToList();
        }
        #endregion
        #region Function
        private void InitDefaultData()
        {
            StrIdLookUpEdit.IntializeData(Session.Stores);
            UserIDLookUpEdit.IntializeData(Session.UserTbls);
            BranchIDLookUpEdit.IntializeData(Session.Branches);
            StrIdLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeStore;
        }
        private void InitData(PrdExpirateMain obj, IEnumerable<PrdExpirateDetail> subObj)
        {
            this.isNew = obj == null;
            if (obj == null)
            {
                InitPrdExpirateMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
            }
            else
            {
                PrdExpirateMainBindingSource.DataSource = obj;
                PrdExpirateDetailBindingSource.DataSource = subObj;
                SetRibbonButtonsVisisbility();
            }
        }
        public void EnabledORDisabledUpdate(bool Enabled)
        {
            dataLayConMain.OptionsView.IsReadOnly = Enabled?DevExpress.Utils.DefaultBoolean.False:DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.ReadOnly = !Enabled;
            bindingNavigator11.Enabled = gridView.OptionsBehavior.Editable = btnDeleteRow.Enabled = Enabled;
        }
        DateTime d = DateTime.Now;
        private void InitPrdExpirateMainObj()
        { 
            PrdExpirateMain PrdExpirateMain = new PrdExpirateMain()
            {
                Date = DateTime.Now,
                StorID = (short)Session.CurrSettings.DefaultStore,
                UserID = Session.CurrentUser.ID,
                BranchID = Session.CurrentBranch.ID,
                No = $"{d.ToString("yy")}{d.ToString("MM")}{d.ToString("dd")}{d.ToString("HH")}{d.ToString("mm")}{d.ToString("ss")}",
            };
            PrdExpirateMainBindingSource.DataSource = PrdExpirateMain;
        }
   
        private void InitPrdBindingSourceData(short strId)
        {
            if (strId == 0) return;
            var tbProductList = (from prdQuantity in Session.ProductQunatities
                                 where prdQuantity.StrId == strId
                                 join prd in Session.Products
                                 on prdQuantity.prdId equals prd.ID
                                 select prd).ToList();
            ProductBindingSource.DataSource = tbProductList;

            var q1 = (from prd in tbProductList
                      group prd by prd.ID into prdGrp
                      join prdMsur in Session.PrdMeasurments
                      on prdGrp.Key
                      equals prdMsur.PrdId
                      where prdMsur.Default ==true
                      select new
                      {
                          prdId = prdGrp.Key,
                          prdPrice =myFunaction.GetMinSalePrice(prdGrp.FirstOrDefault().PriceTax, prdMsur),
                          PrdMsurName=prdMsur.Name,
                      }).Select(x => new { x.prdId, x.prdPrice, x.PrdMsurName });
            this.listPrdMsurName= q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault().PrdMsurName);
            this.listPrdPriceDic = q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.prdPrice);
        }
       
      
        #endregion
       

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "MsurID")
                e.RepositoryItem = repositoryItemLookUpEditMeasurment;
        }

        private void InitNewRowObject(PrdExpirateDetail PrdExpirateDetail,double QuanMainOrPriceWighit = 1, bool ProIsWaghit = false)
        {
            if (this.productData != null)
            {
                PrdExpirateDetail.PrdBarcode = this.productData.Barcode.MsurBarcode;
                PrdExpirateDetail.MsurID = this.productData.PrdMeasurment.ID;
                PrdExpirateDetail.ProductID = this.productData.Product.ID;
                PrdExpirateDetail.Price =this.productData.PrdMeasurment.Price??0;
                PrdExpirateDetail.ExpDate = DateTime.Now;
                if (ProIsWaghit)
                {
                    PrdExpirateDetail.Quantity = (CurrSettings.ReadMode == (byte)ReadModeType.Weight) ? QuanMainOrPriceWighit : 1;
                }
                else
                {
                    PrdExpirateDetail.Quantity = QuanMainOrPriceWighit;
                }
            }
        }
   
        PrdExpirateDetail temp = new PrdExpirateDetail();
        
        public void InitPrdSrch()
        {
           var pro= FormDialogPrdSearch.gridViewSrchPrd.GetFocusedRow() as Product;
            if (pro != null)
            GridView_CellValueChanging(gridView, new CellValueChangedEventArgs(-2147483647, colsupPrdNo, pro.ID));
        }
        private void GridViewSrchPrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) InitPrdSrch();
            else if (e.KeyCode == Keys.F5) FormDialogPrdSearch.Close();
        }

        private void GridViewSrchPrd_DoubleClick(object sender, EventArgs e)
        {
            InitPrdSrch();
        }
        private void repItemButEditSelectPro_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            InitPrdSrch();
        }
        private void GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                PrdExpirateDetail row = PrdExpirateDetailBindingSource.Current as PrdExpirateDetail;
                if (row == null&& e.Column.FieldName!= nameof(temp.ProductID)) return;
                switch (e.Column.FieldName)
                {
                    case nameof(temp.ProductID):
                        if (row == null || e.RowHandle < 0)
                        {
                            gridView.AddNewRow();
                            gridView.UpdateCurrentRow();
                        }
                        if (!GetData(null, ((e.Value as int?) ?? 0))) return;
                        row = PrdExpirateDetailBindingSource.Current as PrdExpirateDetail;
                        InitNewRowObject(row);
                        if (this.productData.Product.Status == (byte)ProductType.Service)
                        {
                            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                                this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
                            //ResetMeasurmentColumns(gridView.FocusedRowHandle);
                        }
                        else
                        {
                            SetPrdQuanAvlbList();
                        }
                        break;
                }
                gridView.RefreshData();
            }
            catch (Exception ex)
            {

            }
        }
        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Session.PrdMeasurments == null) return;
            if (e.Column.FieldName == "MsurID" && e.Value is int p && p > 0)
                e.DisplayText = Session.PrdMeasurments?.FirstOrDefault(x => x.ID == p)?.Name;
        }


        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.Product == null || !isNew || p != productData?.Product?.ID)
                GetData(null, p);
            if (e.FocusedColumn == colMsur)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == p).ToList();
        }
    
        private void RepositoryItemCalcEdit1SalePrice_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (Convert.ToDecimal(e.Value) > (decimal)999999999999999999.99) e.AcceptValue = false;
        }

        private void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        private void RepositoryItemLookUpEditMeasurment_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if(gridView.GetFocusedRow() is PrdExpirateDetail PrdExpirateDetail&&PrdExpirateDetail!=null)
            this.productData.PrdMeasurment = editor.GetSelectedDataRow() as PrdMeasurment;
            var tbBarcode = Session.Barcodes.FirstOrDefault(x => x.MsurId == this.productData.PrdMeasurment.ID);
            PrdExpirateDetail row = PrdExpirateDetailBindingSource.Current as PrdExpirateDetail;
            row.MsurID = this.productData.PrdMeasurment.ID;
            row.PrdBarcode = tbBarcode?.MsurBarcode;
            row.Price =(this.productData.PrdMeasurment.Price??0);
            gridView.UpdateCurrentRow();
            SetPrdQuanAvlbList();
        }
        private void RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (!e.IsGetData) return;
            int prdId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colprdId));
            if (!this.listPrdPriceDic.ContainsKey(prdId)) return;
            if (e.Column.FieldName == colprdSalePrice.FieldName)
                e.Value = this.listPrdPriceDic[prdId];
            else if (e.Column.FieldName == colsupMusrName.FieldName)
                e.Value = this.listPrdMsurName[prdId];
        }

        private void GridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == colCount.FieldName)
                if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;
           
            if (e.Column.FieldName != colprdQuanAvlb.FieldName) return;
            if (!e.IsGetData) return;
            var row=e.Row as PrdExpirateDetail;
            e.Value = GetQuanAvlb(row!=null? row.ProductID:0);
        }
        double GetQuanAvlb(int prdId)
        {
            if (!this.listPrdQuanAvlbDic.ContainsKey(prdId)) return 0;
            double otherQuantity = GetQuantityProductInGrid(prdId);
            return this.listPrdQuanAvlbDic[prdId] - otherQuantity;
        }

        public double GetQuantityProductInGrid(int PrdId)
        {
            var pro = PrdExpirateDetailBindingSource.List as IList<PrdExpirateDetail>;
            return pro.Where(x => x.ProductID == PrdId).Sum(x => x.Quantity);
        }
        
        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract) UpdateQuantity(e);
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textEditBarcodeNo.Text))
                GetPrdBarcodeData(textEditBarcodeNo.Text);
        }
        private void MessNotFoundBarcod()
        {
            XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEditBarcodeNo.EditValue = null;
        }
   
        private bool GetData(string barcode = null, int PrdId = 0)
        {
            if (barcode != null && PrdId == 0)
            {
                this.productData = (from b in Session.Barcodes
                                    join m in Session.PrdMeasurments on b.MsurId equals m.ID
                                    join p in Session.Products on m.PrdId equals p.ID
                                    join g in Session.GroupStrs on p.GrpNo equals g.ID
                                    where b.MsurBarcode == barcode //&& m.Default == 1
                                    select new ProductData
                                    {
                                        Barcode = b,
                                        PrdMeasurment = m,
                                        Product = p,
                                        GroupStr = g
                                    }).FirstOrDefault();
            }
            else if (barcode == null && PrdId > 0)
            {
               
                if (Session.Products.Any(x => x.ID == PrdId && x.Status == 2))
                {
                    this.productData = (from m in Session.PrdMeasurments
                                        join p in Session.Products on m.PrdId equals p.ID
                                        join g in Session.GroupStrs on p.GrpNo equals g.ID
                                        where p.ID == PrdId && m.Default == true
                                        select new ProductData
                                        {
                                            PrdMeasurment = m,
                                            Product = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }
                else
                {
                    this.productData = (from b in Session.Barcodes
                                        join m in Session.PrdMeasurments on b.MsurId equals m.ID
                                        join p in Session.Products on m.PrdId equals p.ID
                                        join g in Session.GroupStrs on p.GrpNo equals g.ID
                                        where p.ID == PrdId && m.Default == true
                                        select new ProductData
                                        {
                                            Barcode = b,
                                            PrdMeasurment = m,
                                            Product = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }

            }
            return this.productData != null;
        }
        
        private void GetPrdBarcodeData(string barcode)
        {
            var curList = (PrdExpirateDetailBindingSource.List as IList<PrdExpirateDetail>);
            PrdExpirateDetail row = curList.FirstOrDefault(x => x.PrdBarcode == barcode);
            bool FoundInGrid = curList.Any(x => x.PrdBarcode == barcode);
            barcode = myFunaction.ChickBarcodWaghit(barcode, out bool ProIsWaghit,out double value);
            if (!GetData(barcode))
            {
                MessNotFoundBarcod();
                return;
            }
            if (FoundInGrid) 
            {
                if (ProIsWaghit)
                {
                    row = myFunaction.GetCopyForObjectPrdExpirateDetail(row);
                    InitNewRowObject(row, value, ProIsWaghit);
                    row.PrdBarcode = textEditBarcodeNo.Text;
                    curList.Add(row);
                }
                else
                {
                    row.Quantity += (ProIsWaghit && Session.CurrSettings.ReadMode == (byte)ReadModeType.Price) ? 1 : value;
                }
            }
            else
            {
                row = myFunaction.GetCopyForObjectPrdExpirateDetail(new PrdExpirateDetail());
                InitNewRowObject(row, value, ProIsWaghit);
                row.PrdBarcode = textEditBarcodeNo.Text;
                curList.Add(row);
            }
            PrdExpirateDetailBindingSource.Position = PrdExpirateDetailBindingSource.IndexOf(row);
            PlayBarcodeBeep();
            SetPrdQuanAvlbList();
            gridView.RefreshData();
            return;
        }
       
        public double GetTotalPrdQuByPrdINdMsSta(int prdId, PrdMeasurment msurStatus, int strId)
        {
            ProductQunatity tbPrdQty = Session.ProductQunatities?.FirstOrDefault(x => x.StrId == strId && x.prdId == prdId);
            if (tbPrdQty == null) return 0;
            return (tbPrdQty.Quantity??0)*(msurStatus.Conversion??1);
        }

        private void UpdatePrdQuanAvlb()=>gridView.SetRowCellValue(gridView.FocusedRowHandle, colprdQuanAvlb, 1);
        private void SetPrdQuanAvlbList()
        { 
            short StorID = Convert.ToInt16(GetCurPrdExpirateMain().StorID);
            if (!this.listPrdQuanAvlbDic.ContainsKey(this.productData.Product.ID))
                this.listPrdQuanAvlbDic.Add(this.productData.Product.ID, GetTotalPrdQuByPrdINdMsSta(this.productData.Product.ID, this.productData.PrdMeasurment, StorID));
            else
                this.listPrdQuanAvlbDic[this.productData.Product.ID] = GetTotalPrdQuByPrdINdMsSta(this.productData.Product.ID, this.productData.PrdMeasurment, StorID);
        }
        private bool SaveData(bool printInvoice=true)
        {
            bool isSaved = false;
            PrdExpirateMain tbPrdExpirateMain = GetCurPrdExpirateMain();
            textEditBarcodeNo.Focus();
            gridView.FocusedColumn = (gridView.FocusedColumn == colsupPrdNo) ? colprdName : colsupPrdNo;
            if (tbPrdExpirateMain == null) return false;
            var curList = (PrdExpirateDetailBindingSource.List as IList<PrdExpirateDetail>);
            if (curList == null && this.gridValid)
            {
                XtraMessageBox.Show(_resource.GetString("GridErrorMssg"));
                return false;
            }
            try
            {
                if (curList.Count <= 0)
                {
                    ClsXtraMssgBox.ShowWarning("عذرا لا يوجد اصناف في الجدول!!!! ");
                    return false;
                }
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            if (this.isNew)
                            {
                                db.PrdExpirateMains.InsertOnSubmit(tbPrdExpirateMain);
                                tbPrdExpirateMain.No = $"{d.ToString("yy")}{d.ToString("MM")}{d.ToString("dd")}{d.ToString("HH")}{d.ToString("mm")}{d.ToString("ss")}";
                                db.SubmitChanges();
                                curList = PrdExpirateDetails(curList, tbPrdExpirateMain);
                                db.PrdExpirateDetails.InsertAllOnSubmit(curList);
                            }
                            else
                            {
                                db.PrdExpirateMains.DeleteOnSubmit(db.PrdExpirateMains.FirstOrDefault(x => x.ID == tbPrdExpirateMain.ID));
                                db.PrdExpirateMains.InsertOnSubmit(tbPrdExpirateMain);
                                curList = PrdExpirateDetails(curList, tbPrdExpirateMain);
                                db.PrdExpirateDetails.DeleteAllOnSubmit(db.PrdExpirateDetails.Where(y => y.ParentID == tbPrdExpirateMain.ID));
                                db.PrdExpirateDetails.InsertAllOnSubmit(curList);
                            }
                            db.SubmitChanges();
                        
                            transaction.Complete();
                            isSaved = true;
                        }
                        catch (Exception ex)
                        {
                            isSaved = false;
                            ClsXtraMssgBox.ShowError(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
            if (Program.My_Setting.SendPrdExpirToServerOnSave && this.isNew)
            {
                List<PrdExpirateDetail> tbPrdExpirateDetailList = myFunaction.GetCopyFromPrdExpirateDetail(curList.ToList());
                PrdExpirateMain temp = myFunaction.GetCopyFromPrdExpirateMain(tbPrdExpirateMain);
                Task.Run(() => new UploadDataToMain(temp, tbPrdExpirateDetailList));
            }
            return isSaved;
        }
        IList<PrdExpirateDetail> PrdExpirateDetails(IList<PrdExpirateDetail> curList, PrdExpirateMain tbPrdExpirateMain) => (from i in curList
                                                select new PrdExpirateDetail
                                                {
                                                    BranchID = tbPrdExpirateMain.BranchID,
                                                    Price = i.Price,
                                                    Date = tbPrdExpirateMain.Date,
                                                    ID = i.ID,
                                                    MsurID = i.MsurID,
                                                    ParentID = tbPrdExpirateMain.ID,
                                                    ProductID = i.ProductID,
                                                    Quantity = i.Quantity,
                                                    Status = i.Status,
                                                    ExpDate=i.ExpDate,
                                                    StoreID= tbPrdExpirateMain.StorID,
                                                    PrdBarcode  =i.PrdBarcode
                                                }).ToList();
        private void SaveAndNew(bool printInvoice)
        {
            if (!SaveData(printInvoice)) return;
            PrdExpirateMain tbPrdExpirateMain = GetCurPrdExpirateMain();
            string mssg = string.Format(_resource.GetString("PrdExipertySuccessMssg"),tbPrdExpirateMain.ID);
            flyDialog.ShowDialogUC(this, mssg,this.isNew);
            ResetData();
            this.isNew = true;
        }
        MyFunaction myFunaction = new MyFunaction();

        private void ResetData()
        {
            this.listPrdQuantDic = new Dictionary<int, double>();
            InitPrdExpirateMainObj();
            InitPrdExpirateDetailGridObj();
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.gridValid = true;
            textEditBarcodeNo.Focus();
        }
        private void InitPrdExpirateDetailGridObj()
        {
            PrdExpirateDetailBindingSource.DataSource = null;
            PrdExpirateDetailBindingSource.DataSource = typeof(PrdExpirateDetail);
        }

        public void SetProductQunatity(int rowHandle, double quantity)
        {
            gridView.SetRowCellValue(rowHandle, colQuanMain, quantity);
            gridView.RefreshRowCell(rowHandle, colQuanMain);
        }

        private void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!this.isNew) return;

            switch (e.KeyData)
            {
                case Keys.Delete:
                    DeleteRow();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    textEditBarcodeNo.Focus();
                    e.Handled = true;
                    break;
                case Keys.Add:
                case Keys.Subtract:
                    UpdateQuantity(e);
                    break;
            }
        }

        private void DeleteRow()
        {
            DeletePrdDataFromPrdQuantDicList();
            gridView.DeleteSelectedRows();
            textEditBarcodeNo.Focus();
        }

        private void UpdateQuantity(KeyEventArgs e)
        {
            var row =gridView.GetFocusedRow() as PrdExpirateDetail;
            if (row == null) return;
            double quantity = Convert.ToDouble(row.Quantity);
            quantity = (e.KeyData) switch
            {
                Keys.Add => ++quantity,
                Keys.Subtract when quantity > 1 => --quantity,
                _ => quantity
            };
            row.Quantity = quantity;
            UpdatePrdQuanAvlb();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        private void DeletePrdDataFromPrdQuantDicList()
        {
            if (this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Remove(gridView.FocusedRowHandle);
        }

        private void layoutControlGroup8_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(System.Drawing.Brushes.AliceBlue, e.Bounds);
            e.Handled = true;
        }
       
        private void SetRibbonButtonsVisisbility()
        {
            btnSaveAndNew.Visible = false;
            btnReset.Visible = false;
        }
        
        private void DisableGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.TabStop = false;
        }
     
        private void InitBarcodeBeep()
        {
            this.barcodeBeep = new MediaPlayer() { Volume = 1 };
            this.barcodeBeepUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\BarcodeBeep.wav");
        }

        private void PlayBarcodeBeep()
        {
            textEditBarcodeNo.EditValue = null;
            this.barcodeBeep.Open(this.barcodeBeepUri);
            this.barcodeBeep.Play();
        }

        private void InitFlyDialogPrdSrch()
        {
            if (this.InvokeRequired) this.Invoke(new MethodInvoker(delegate { InitFlyoutControls(); }));
            else InitFlyoutControls();
        }
        private void InitFlyoutControls()
        { 
            this.FormDialogPrdSearch = new FormSearchProduct(); 
            FormDialogPrdSearch.gridViewSrchPrd.KeyDown += GridViewSrchPrd_KeyDown;
            FormDialogPrdSearch.gridViewSrchPrd.DoubleClick += GridViewSrchPrd_DoubleClick;
            FormDialogPrdSearch.repItemButEditSelectPro.ButtonClick += repItemButEditSelectPro_ButtonClick;
        }
        public void ShowPrdSearchPanel()=>this.FormDialogPrdSearch.ShowDialog();
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
 
        private void DataLayoutControl1_GroupExpandChanged(object sender, LayoutGroupEventArgs e)
        {
            Program.My_Setting.supplySaleExpanded = layoutControlGrooupMain.Expanded;
            MySetting.ReadWriterSettingXml();
        }
        private void GetResources()
        {
            if (!Program.My_Setting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherEn));
            }

            if (Program.My_Setting.LangEng) EnglishTranslation();
        }
        private void EnglishLayout()
        {
            dataLayConMain.BeginUpdate();
            dataLayConMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataLayConMain.OptionsView.RightToLeftMirroringApplied = false;
            dataLayConMain.EndUpdate();
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        private void EnglishTranslation()
        {
            EnglishLayout();

            try
            {
                foreach (LayoutControlItem item in layoutControlGrooupMain.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                foreach (GridColumn col in gridView.Columns)
                    _resource.ApplyResources(col, col.Name, _ci);
            }
            catch { }
            try { _resource.ApplyResources(layoutControlGrooupMain, layoutControlGrooupMain.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnSave, btnSave.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnClose, btnClose.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnSaveAndNew, btnSaveAndNew.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnEditQuantity, btnEditQuantity.Name, _ci); } catch { }
            try { _resource.ApplyResources(labelItemsCount, labelItemsCount.Name, _ci); } catch { }

            try { repositoryItemLookUpEditMeasurment.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEditMeasurment.Columns1"); } catch { }
            try
            {
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Caption = _resource.GetString("colprdNo.Caption");
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Width = 150;
            }
            catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }
            try { colprdQuanAvlb.Caption = _resource.GetString("colprdQuanAvlb"); } catch { }
            try { btnReset.Text = _resource.GetString("btnReset"); } catch { }
            try { layoutControlGrooupMain.Text = _resource.GetString("layoutControlGrooupMain"); } catch { }
            try { ItemForBarcodeText.Text = _resource.GetString("ItemForBarcodeText"); } catch { }
            try { btnDeleteRow.Text = _resource.GetString("btnDeleteRow"); } catch { }
            try { simpleLabelItem1.Text = _resource.GetString("simpleLabelItem1"); } catch { }
            try { colCount.Caption = _resource.GetString("colCount"); } catch { }
        }
    }
}
