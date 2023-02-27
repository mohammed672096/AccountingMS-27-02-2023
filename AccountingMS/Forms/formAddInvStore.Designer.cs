namespace AccountingMS
{
    partial class formAddInvStore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddInvStore));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefreshPrdQuanNdPrice = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.invNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tblInvStoreMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.invStrIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSubmitGrpProducts = new DevExpress.XtraEditors.SimpleButton();
            this.invGrpIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblGroupStrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invBarcodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnSubmitInv = new DevExpress.XtraEditors.SimpleButton();
            this.invManualSrchTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblInvStoreMainLookupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invSetlmntAccIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForinvNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForinvDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForinvStrId = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupProductSrch = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForinvBarcodeSrch = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForinvGrpId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForbtnSubmitGrpProducts = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForinvManualSrch = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForbtnSubmitInv = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForinvSetlmntAccId = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblInvStoreSubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvMainId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPrdGrpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemSrchLookUpEditPrd = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repoItemSrchLookUpEditPrdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvQuanStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvQuanAvl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvQuanDefr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPriceAvrg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPriceDefr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvPriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvSalePriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemLookUpEditPrdMsur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invStrIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invGrpIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroupStrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invBarcodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invManualSrchTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreMainLookupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invSetlmntAccIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvStrId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupProductSrch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvBarcodeSrch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvGrpId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbtnSubmitGrpProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvManualSrch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbtnSubmitInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvSetlmntAccId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreSubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSrchLookUpEditPrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSrchLookUpEditPrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLookUpEditPrdMsur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 39, 34, 39);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bbiClose,
            this.bbiReset,
            this.bbiRefreshPrdQuanNdPrice});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 377;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiSave
            // 
            resources.ApplyResources(this.bbiSave, "bbiSave");
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose
            // 
            resources.ApplyResources(this.bbiClose, "bbiClose");
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiReset
            // 
            resources.ApplyResources(this.bbiReset, "bbiReset");
            this.bbiReset.Id = 3;
            this.bbiReset.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.reset;
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
            // 
            // bbiRefreshPrdQuanNdPrice
            // 
            resources.ApplyResources(this.bbiRefreshPrdQuanNdPrice, "bbiRefreshPrdQuanNdPrice");
            this.bbiRefreshPrdQuanNdPrice.Id = 4;
            this.bbiRefreshPrdQuanNdPrice.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.update;
            this.bbiRefreshPrdQuanNdPrice.Name = "bbiRefreshPrdQuanNdPrice";
            this.bbiRefreshPrdQuanNdPrice.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiRefreshPrdQuanNdPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefreshPrdQuanNdPrice_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiReset);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefreshPrdQuanNdPrice);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonStatusBar1
            // 
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            resources.ApplyResources(this.ribbonPage2, "ribbonPage2");
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.separatorControl1);
            this.dataLayoutControl1.Controls.Add(this.invNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.invDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.invStrIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.btnSubmitGrpProducts);
            this.dataLayoutControl1.Controls.Add(this.invGrpIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.invBarcodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.btnSubmitInv);
            this.dataLayoutControl1.Controls.Add(this.invManualSrchTextEdit);
            this.dataLayoutControl1.Controls.Add(this.invSetlmntAccIdTextEdit);
            this.dataLayoutControl1.DataSource = this.tblInvStoreMainBindingSource;
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineThickness = 7;
            resources.ApplyResources(this.separatorControl1, "separatorControl1");
            this.separatorControl1.Name = "separatorControl1";
            // 
            // invNoTextEdit
            // 
            this.invNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblInvStoreMainBindingSource, "invNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.invNoTextEdit, "invNoTextEdit");
            this.invNoTextEdit.MenuManager = this.ribbonControl1;
            this.invNoTextEdit.Name = "invNoTextEdit";
            this.invNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.invNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.invNoTextEdit.Properties.Mask.EditMask = resources.GetString("invNoTextEdit.Properties.Mask.EditMask");
            this.invNoTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("invNoTextEdit.Properties.Mask.MaskType")));
            this.invNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("invNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.invNoTextEdit.StyleController = this.dataLayoutControl1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "يجب أن لا يكون رقم الجرد 0";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.invNoTextEdit, conditionValidationRule1);
            // 
            // tblInvStoreMainBindingSource
            // 
            this.tblInvStoreMainBindingSource.DataSource = typeof(AccountingMS.tblInvStoreMain);
            // 
            // invDateDateEdit
            // 
            this.invDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblInvStoreMainBindingSource, "invDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.invDateDateEdit, "invDateDateEdit");
            this.invDateDateEdit.MenuManager = this.ribbonControl1;
            this.invDateDateEdit.Name = "invDateDateEdit";
            this.invDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invDateDateEdit.Properties.Buttons"))))});
            this.invDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invDateDateEdit.Properties.CalendarTimeProperties.Buttons"))))});
            this.invDateDateEdit.Properties.MaskSettings.Set("mask", "g");
            this.invDateDateEdit.StyleController = this.dataLayoutControl1;
            // 
            // invStrIdTextEdit
            // 
            this.invStrIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblInvStoreMainBindingSource, "invStrId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.invStrIdTextEdit, "invStrIdTextEdit");
            this.invStrIdTextEdit.MenuManager = this.ribbonControl1;
            this.invStrIdTextEdit.Name = "invStrIdTextEdit";
            this.invStrIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.invStrIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.invStrIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invStrIdTextEdit.Properties.Buttons"))))});
            this.invStrIdTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invStrIdTextEdit.Properties.Columns"), resources.GetString("invStrIdTextEdit.Properties.Columns1"), ((int)(resources.GetObject("invStrIdTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invStrIdTextEdit.Properties.Columns3"))), resources.GetString("invStrIdTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("invStrIdTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invStrIdTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invStrIdTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invStrIdTextEdit.Properties.Columns8"))))});
            this.invStrIdTextEdit.Properties.DataSource = this.tblStoreBindingSource;
            this.invStrIdTextEdit.Properties.DisplayMember = "strName";
            this.invStrIdTextEdit.Properties.NullText = resources.GetString("invStrIdTextEdit.Properties.NullText");
            this.invStrIdTextEdit.Properties.ShowHeader = false;
            this.invStrIdTextEdit.Properties.ValueMember = "id";
            this.invStrIdTextEdit.StyleController = this.dataLayoutControl1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule2.ErrorText = "يجب إختيار المخزن أولاً!";
            conditionValidationRule2.Value1 = ((short)(0));
            this.dxValidationProvider1.SetValidationRule(this.invStrIdTextEdit, conditionValidationRule2);
            // 
            // tblStoreBindingSource
            // 
            this.tblStoreBindingSource.DataSource = typeof(AccountingMS.tblStore);
            // 
            // btnSubmitGrpProducts
            // 
            resources.ApplyResources(this.btnSubmitGrpProducts, "btnSubmitGrpProducts");
            this.btnSubmitGrpProducts.Name = "btnSubmitGrpProducts";
            this.btnSubmitGrpProducts.StyleController = this.dataLayoutControl1;
            // 
            // invGrpIdTextEdit
            // 
            resources.ApplyResources(this.invGrpIdTextEdit, "invGrpIdTextEdit");
            this.invGrpIdTextEdit.MenuManager = this.ribbonControl1;
            this.invGrpIdTextEdit.Name = "invGrpIdTextEdit";
            this.invGrpIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invGrpIdTextEdit.Properties.Buttons"))))});
            this.invGrpIdTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invGrpIdTextEdit.Properties.Columns"), resources.GetString("invGrpIdTextEdit.Properties.Columns1"), ((int)(resources.GetObject("invGrpIdTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invGrpIdTextEdit.Properties.Columns3"))), resources.GetString("invGrpIdTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("invGrpIdTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invGrpIdTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invGrpIdTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invGrpIdTextEdit.Properties.Columns8"))))});
            this.invGrpIdTextEdit.Properties.DataSource = this.tblGroupStrBindingSource;
            this.invGrpIdTextEdit.Properties.DisplayMember = "grpName";
            this.invGrpIdTextEdit.Properties.NullText = resources.GetString("invGrpIdTextEdit.Properties.NullText");
            this.invGrpIdTextEdit.Properties.ShowHeader = false;
            this.invGrpIdTextEdit.Properties.ValueMember = "id";
            this.invGrpIdTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // tblGroupStrBindingSource
            // 
            this.tblGroupStrBindingSource.DataSource = typeof(AccountingMS.tblGroupStr);
            // 
            // invBarcodeTextEdit
            // 
            resources.ApplyResources(this.invBarcodeTextEdit, "invBarcodeTextEdit");
            this.invBarcodeTextEdit.MenuManager = this.ribbonControl1;
            this.invBarcodeTextEdit.Name = "invBarcodeTextEdit";
            this.invBarcodeTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // btnSubmitInv
            // 
            resources.ApplyResources(this.btnSubmitInv, "btnSubmitInv");
            this.btnSubmitInv.Name = "btnSubmitInv";
            this.btnSubmitInv.StyleController = this.dataLayoutControl1;
            // 
            // invManualSrchTextEdit
            // 
            resources.ApplyResources(this.invManualSrchTextEdit, "invManualSrchTextEdit");
            this.invManualSrchTextEdit.MenuManager = this.ribbonControl1;
            this.invManualSrchTextEdit.Name = "invManualSrchTextEdit";
            this.invManualSrchTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invManualSrchTextEdit.Properties.Buttons"))))});
            this.invManualSrchTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invManualSrchTextEdit.Properties.Columns"), resources.GetString("invManualSrchTextEdit.Properties.Columns1"), ((int)(resources.GetObject("invManualSrchTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invManualSrchTextEdit.Properties.Columns3"))), resources.GetString("invManualSrchTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("invManualSrchTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invManualSrchTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invManualSrchTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invManualSrchTextEdit.Properties.Columns8")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invManualSrchTextEdit.Properties.Columns9"), resources.GetString("invManualSrchTextEdit.Properties.Columns10"), ((int)(resources.GetObject("invManualSrchTextEdit.Properties.Columns11"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invManualSrchTextEdit.Properties.Columns12"))), resources.GetString("invManualSrchTextEdit.Properties.Columns13"), ((bool)(resources.GetObject("invManualSrchTextEdit.Properties.Columns14"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invManualSrchTextEdit.Properties.Columns15"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invManualSrchTextEdit.Properties.Columns16"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invManualSrchTextEdit.Properties.Columns17"))))});
            this.invManualSrchTextEdit.Properties.DataSource = this.tblInvStoreMainLookupBindingSource;
            this.invManualSrchTextEdit.Properties.DisplayMember = "invNo";
            this.invManualSrchTextEdit.Properties.NullText = resources.GetString("invManualSrchTextEdit.Properties.NullText");
            this.invManualSrchTextEdit.Properties.ValueMember = "id";
            this.invManualSrchTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // tblInvStoreMainLookupBindingSource
            // 
            this.tblInvStoreMainLookupBindingSource.DataSource = typeof(AccountingMS.tblInvStoreMain);
            // 
            // invSetlmntAccIdTextEdit
            // 
            resources.ApplyResources(this.invSetlmntAccIdTextEdit, "invSetlmntAccIdTextEdit");
            this.invSetlmntAccIdTextEdit.MenuManager = this.ribbonControl1;
            this.invSetlmntAccIdTextEdit.Name = "invSetlmntAccIdTextEdit";
            this.invSetlmntAccIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Buttons"))))});
            this.invSetlmntAccIdTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns"), resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns1"), ((int)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns3"))), resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns8")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns9"), resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns10"), ((int)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns11"))), ((DevExpress.Utils.FormatType)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns12"))), resources.GetString("invSetlmntAccIdTextEdit.Properties.Columns13"), ((bool)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns14"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns15"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns16"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("invSetlmntAccIdTextEdit.Properties.Columns17"))))});
            this.invSetlmntAccIdTextEdit.Properties.DataSource = this.tblAccountBindingSource;
            this.invSetlmntAccIdTextEdit.Properties.DisplayMember = "accName";
            this.invSetlmntAccIdTextEdit.Properties.NullText = resources.GetString("invSetlmntAccIdTextEdit.Properties.NullText");
            this.invSetlmntAccIdTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.invSetlmntAccIdTextEdit.Properties.ValueMember = "id";
            this.invSetlmntAccIdTextEdit.StyleController = this.dataLayoutControl1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.invSetlmntAccIdTextEdit, conditionValidationRule3);
            // 
            // tblAccountBindingSource
            // 
            this.tblAccountBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(14, 14, 14, 0);
            this.Root.Size = new System.Drawing.Size(1343, 192);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroupProductSrch});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1315, 172);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup3.AppearanceGroup.Font")));
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup3.AppearanceItemCaption.Font")));
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForinvNo,
            this.ItemForinvDate,
            this.ItemForinvStrId});
            this.layoutControlGroup3.Location = new System.Drawing.Point(656, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(14, 14, 14, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(659, 172);
            resources.ApplyResources(this.layoutControlGroup3, "layoutControlGroup3");
            // 
            // ItemForinvNo
            // 
            this.ItemForinvNo.Control = this.invNoTextEdit;
            this.ItemForinvNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForinvNo.Name = "ItemForinvNo";
            this.ItemForinvNo.Size = new System.Drawing.Size(627, 28);
            resources.ApplyResources(this.ItemForinvNo, "ItemForinvNo");
            this.ItemForinvNo.TextSize = new System.Drawing.Size(108, 23);
            // 
            // ItemForinvDate
            // 
            this.ItemForinvDate.Control = this.invDateDateEdit;
            this.ItemForinvDate.Location = new System.Drawing.Point(0, 56);
            this.ItemForinvDate.Name = "ItemForinvDate";
            this.ItemForinvDate.Size = new System.Drawing.Size(627, 62);
            resources.ApplyResources(this.ItemForinvDate, "ItemForinvDate");
            this.ItemForinvDate.TextSize = new System.Drawing.Size(108, 23);
            // 
            // ItemForinvStrId
            // 
            this.ItemForinvStrId.Control = this.invStrIdTextEdit;
            this.ItemForinvStrId.Location = new System.Drawing.Point(0, 28);
            this.ItemForinvStrId.Name = "ItemForinvStrId";
            this.ItemForinvStrId.Size = new System.Drawing.Size(627, 28);
            resources.ApplyResources(this.ItemForinvStrId, "ItemForinvStrId");
            this.ItemForinvStrId.TextSize = new System.Drawing.Size(108, 23);
            // 
            // layoutControlGroupProductSrch
            // 
            this.layoutControlGroupProductSrch.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroupProductSrch.AppearanceGroup.Font")));
            this.layoutControlGroupProductSrch.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupProductSrch.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroupProductSrch.AppearanceItemCaption.Font")));
            this.layoutControlGroupProductSrch.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroupProductSrch.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupProductSrch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForinvBarcodeSrch,
            this.ItemForinvGrpId,
            this.ItemForbtnSubmitGrpProducts,
            this.ItemForinvManualSrch,
            this.ItemForbtnSubmitInv,
            this.ItemForinvSetlmntAccId});
            this.layoutControlGroupProductSrch.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupProductSrch.Name = "layoutControlGroupProductSrch";
            this.layoutControlGroupProductSrch.Padding = new DevExpress.XtraLayout.Utils.Padding(14, 14, 14, 3);
            this.layoutControlGroupProductSrch.Size = new System.Drawing.Size(656, 172);
            resources.ApplyResources(this.layoutControlGroupProductSrch, "layoutControlGroupProductSrch");
            // 
            // ItemForinvBarcodeSrch
            // 
            this.ItemForinvBarcodeSrch.Control = this.invBarcodeTextEdit;
            this.ItemForinvBarcodeSrch.Enabled = false;
            this.ItemForinvBarcodeSrch.Location = new System.Drawing.Point(0, 62);
            this.ItemForinvBarcodeSrch.Name = "ItemForinvBarcodeSrch";
            this.ItemForinvBarcodeSrch.Size = new System.Drawing.Size(624, 28);
            resources.ApplyResources(this.ItemForinvBarcodeSrch, "ItemForinvBarcodeSrch");
            this.ItemForinvBarcodeSrch.TextSize = new System.Drawing.Size(108, 23);
            // 
            // ItemForinvGrpId
            // 
            this.ItemForinvGrpId.Control = this.invGrpIdTextEdit;
            this.ItemForinvGrpId.Enabled = false;
            this.ItemForinvGrpId.Location = new System.Drawing.Point(179, 31);
            this.ItemForinvGrpId.Name = "ItemForinvGrpId";
            this.ItemForinvGrpId.Size = new System.Drawing.Size(445, 31);
            resources.ApplyResources(this.ItemForinvGrpId, "ItemForinvGrpId");
            this.ItemForinvGrpId.TextSize = new System.Drawing.Size(108, 23);
            // 
            // ItemForbtnSubmitGrpProducts
            // 
            this.ItemForbtnSubmitGrpProducts.Control = this.btnSubmitGrpProducts;
            this.ItemForbtnSubmitGrpProducts.Location = new System.Drawing.Point(0, 31);
            this.ItemForbtnSubmitGrpProducts.Name = "ItemForbtnSubmitGrpProducts";
            this.ItemForbtnSubmitGrpProducts.Size = new System.Drawing.Size(179, 31);
            this.ItemForbtnSubmitGrpProducts.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForbtnSubmitGrpProducts.TextVisible = false;
            // 
            // ItemForinvManualSrch
            // 
            this.ItemForinvManualSrch.Control = this.invManualSrchTextEdit;
            this.ItemForinvManualSrch.Location = new System.Drawing.Point(179, 0);
            this.ItemForinvManualSrch.Name = "ItemForinvManualSrch";
            this.ItemForinvManualSrch.Size = new System.Drawing.Size(445, 31);
            resources.ApplyResources(this.ItemForinvManualSrch, "ItemForinvManualSrch");
            this.ItemForinvManualSrch.TextSize = new System.Drawing.Size(108, 23);
            // 
            // ItemForbtnSubmitInv
            // 
            this.ItemForbtnSubmitInv.Control = this.btnSubmitInv;
            this.ItemForbtnSubmitInv.Location = new System.Drawing.Point(0, 0);
            this.ItemForbtnSubmitInv.Name = "ItemForbtnSubmitInv";
            this.ItemForbtnSubmitInv.Size = new System.Drawing.Size(179, 31);
            this.ItemForbtnSubmitInv.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForbtnSubmitInv.TextVisible = false;
            // 
            // ItemForinvSetlmntAccId
            // 
            this.ItemForinvSetlmntAccId.Control = this.invSetlmntAccIdTextEdit;
            this.ItemForinvSetlmntAccId.Location = new System.Drawing.Point(0, 90);
            this.ItemForinvSetlmntAccId.Name = "ItemForinvSetlmntAccId";
            this.ItemForinvSetlmntAccId.Size = new System.Drawing.Size(624, 28);
            resources.ApplyResources(this.ItemForinvSetlmntAccId, "ItemForinvSetlmntAccId");
            this.ItemForinvSetlmntAccId.TextSize = new System.Drawing.Size(108, 23);
            this.ItemForinvSetlmntAccId.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.separatorControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 172);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(138, 1);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 0, 0);
            this.layoutControlItem2.Size = new System.Drawing.Size(1315, 6);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblInvStoreSubBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl1.EmbeddedNavigator.Margin")));
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemSrchLookUpEditPrd,
            this.repoItemLookUpEditPrdMsur});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblInvStoreSubBindingSource
            // 
            this.tblInvStoreSubBindingSource.DataSource = typeof(AccountingMS.tblInvStoreSub);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridView1.Appearance.FooterPanel.FontStyleDelta")));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colinvMainId,
            this.colinvPrdGrpId,
            this.colinvBarcode,
            this.colinvPrdId,
            this.colinvPrdMsurId,
            this.colinvQuanStr,
            this.colinvQuanAvl,
            this.colinvQuanDefr,
            this.colinvPriceAvrg,
            this.colinvPriceDefr,
            this.colinvPriceTotal,
            this.colinvSalePrice,
            this.colinvSalePriceTotal});
            this.gridView1.DetailHeight = 485;
            this.gridView1.FooterPanelHeight = 84;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.MinWidth = 26;
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            this.colid.OptionsColumn.ShowInExpressionEditor = false;
            resources.ApplyResources(this.colid, "colid");
            // 
            // colinvMainId
            // 
            this.colinvMainId.FieldName = "invMainId";
            this.colinvMainId.MinWidth = 26;
            this.colinvMainId.Name = "colinvMainId";
            this.colinvMainId.OptionsColumn.ShowInCustomizationForm = false;
            this.colinvMainId.OptionsColumn.ShowInExpressionEditor = false;
            resources.ApplyResources(this.colinvMainId, "colinvMainId");
            // 
            // colinvPrdGrpId
            // 
            this.colinvPrdGrpId.FieldName = "invPrdGrpId";
            this.colinvPrdGrpId.MinWidth = 26;
            this.colinvPrdGrpId.Name = "colinvPrdGrpId";
            this.colinvPrdGrpId.OptionsColumn.ShowInCustomizationForm = false;
            this.colinvPrdGrpId.OptionsColumn.ShowInExpressionEditor = false;
            resources.ApplyResources(this.colinvPrdGrpId, "colinvPrdGrpId");
            // 
            // colinvBarcode
            // 
            resources.ApplyResources(this.colinvBarcode, "colinvBarcode");
            this.colinvBarcode.FieldName = "invBarcode";
            this.colinvBarcode.MinWidth = 86;
            this.colinvBarcode.Name = "colinvBarcode";
            this.colinvBarcode.OptionsColumn.AllowEdit = false;
            this.colinvBarcode.OptionsColumn.ReadOnly = true;
            this.colinvBarcode.OptionsColumn.TabStop = false;
            // 
            // colinvPrdId
            // 
            this.colinvPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colinvPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvPrdId, "colinvPrdId");
            this.colinvPrdId.ColumnEdit = this.repoItemSrchLookUpEditPrd;
            this.colinvPrdId.FieldName = "invPrdId";
            this.colinvPrdId.MinWidth = 26;
            this.colinvPrdId.Name = "colinvPrdId";
            this.colinvPrdId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colinvPrdId.Summary"))), resources.GetString("colinvPrdId.Summary1"), resources.GetString("colinvPrdId.Summary2"))});
            // 
            // repoItemSrchLookUpEditPrd
            // 
            resources.ApplyResources(this.repoItemSrchLookUpEditPrd, "repoItemSrchLookUpEditPrd");
            this.repoItemSrchLookUpEditPrd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repoItemSrchLookUpEditPrd.Buttons"))))});
            this.repoItemSrchLookUpEditPrd.DataSource = this.tblProductBindingSource;
            this.repoItemSrchLookUpEditPrd.DisplayMember = "prdName";
            this.repoItemSrchLookUpEditPrd.Name = "repoItemSrchLookUpEditPrd";
            this.repoItemSrchLookUpEditPrd.PopupView = this.repoItemSrchLookUpEditPrdView;
            this.repoItemSrchLookUpEditPrd.ValueMember = "id";
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataSource = typeof(AccountingMS.tblProduct);
            // 
            // repoItemSrchLookUpEditPrdView
            // 
            this.repoItemSrchLookUpEditPrdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrdId,
            this.colprdNo,
            this.colprdName});
            this.repoItemSrchLookUpEditPrdView.DetailHeight = 485;
            this.repoItemSrchLookUpEditPrdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repoItemSrchLookUpEditPrdView.Name = "repoItemSrchLookUpEditPrdView";
            this.repoItemSrchLookUpEditPrdView.OptionsMenu.EnableColumnMenu = false;
            this.repoItemSrchLookUpEditPrdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repoItemSrchLookUpEditPrdView.OptionsView.ShowGroupPanel = false;
            // 
            // colPrdId
            // 
            resources.ApplyResources(this.colPrdId, "colPrdId");
            this.colPrdId.FieldName = "id";
            this.colPrdId.MinWidth = 26;
            this.colPrdId.Name = "colPrdId";
            // 
            // colprdNo
            // 
            resources.ApplyResources(this.colprdNo, "colprdNo");
            this.colprdNo.FieldName = "prdNo";
            this.colprdNo.MinWidth = 26;
            this.colprdNo.Name = "colprdNo";
            // 
            // colprdName
            // 
            resources.ApplyResources(this.colprdName, "colprdName");
            this.colprdName.FieldName = "prdName";
            this.colprdName.MinWidth = 26;
            this.colprdName.Name = "colprdName";
            // 
            // colinvPrdMsurId
            // 
            this.colinvPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colinvPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvPrdMsurId, "colinvPrdMsurId");
            this.colinvPrdMsurId.FieldName = "invPrdMsurId";
            this.colinvPrdMsurId.MinWidth = 26;
            this.colinvPrdMsurId.Name = "colinvPrdMsurId";
            // 
            // colinvQuanStr
            // 
            this.colinvQuanStr.AppearanceCell.Options.UseTextOptions = true;
            this.colinvQuanStr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvQuanStr, "colinvQuanStr");
            this.colinvQuanStr.FieldName = "invQuanStr";
            this.colinvQuanStr.MinWidth = 99;
            this.colinvQuanStr.Name = "colinvQuanStr";
            this.colinvQuanStr.OptionsColumn.AllowEdit = false;
            this.colinvQuanStr.OptionsColumn.TabStop = false;
            // 
            // colinvQuanAvl
            // 
            this.colinvQuanAvl.AppearanceCell.Options.UseTextOptions = true;
            this.colinvQuanAvl.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvQuanAvl, "colinvQuanAvl");
            this.colinvQuanAvl.FieldName = "invQuanAvl";
            this.colinvQuanAvl.MinWidth = 99;
            this.colinvQuanAvl.Name = "colinvQuanAvl";
            // 
            // colinvQuanDefr
            // 
            this.colinvQuanDefr.AppearanceCell.Options.UseTextOptions = true;
            this.colinvQuanDefr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvQuanDefr, "colinvQuanDefr");
            this.colinvQuanDefr.FieldName = "invQuanDefr";
            this.colinvQuanDefr.MinWidth = 99;
            this.colinvQuanDefr.Name = "colinvQuanDefr";
            this.colinvQuanDefr.OptionsColumn.AllowEdit = false;
            this.colinvQuanDefr.OptionsColumn.TabStop = false;
            // 
            // colinvPriceAvrg
            // 
            this.colinvPriceAvrg.AppearanceCell.Options.UseTextOptions = true;
            this.colinvPriceAvrg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvPriceAvrg, "colinvPriceAvrg");
            this.colinvPriceAvrg.DisplayFormat.FormatString = "n3";
            this.colinvPriceAvrg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colinvPriceAvrg.FieldName = "invPriceAvrg";
            this.colinvPriceAvrg.MinWidth = 26;
            this.colinvPriceAvrg.Name = "colinvPriceAvrg";
            this.colinvPriceAvrg.OptionsColumn.AllowEdit = false;
            this.colinvPriceAvrg.OptionsColumn.TabStop = false;
            // 
            // colinvPriceDefr
            // 
            this.colinvPriceDefr.AppearanceCell.Options.UseTextOptions = true;
            this.colinvPriceDefr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvPriceDefr, "colinvPriceDefr");
            this.colinvPriceDefr.DisplayFormat.FormatString = "n3";
            this.colinvPriceDefr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colinvPriceDefr.FieldName = "invPriceDefr";
            this.colinvPriceDefr.MinWidth = 99;
            this.colinvPriceDefr.Name = "colinvPriceDefr";
            this.colinvPriceDefr.OptionsColumn.AllowEdit = false;
            this.colinvPriceDefr.OptionsColumn.TabStop = false;
            // 
            // colinvPriceTotal
            // 
            this.colinvPriceTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colinvPriceTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvPriceTotal, "colinvPriceTotal");
            this.colinvPriceTotal.DisplayFormat.FormatString = "n3";
            this.colinvPriceTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colinvPriceTotal.FieldName = "invPriceTotal";
            this.colinvPriceTotal.MinWidth = 99;
            this.colinvPriceTotal.Name = "colinvPriceTotal";
            this.colinvPriceTotal.OptionsColumn.AllowEdit = false;
            this.colinvPriceTotal.OptionsColumn.TabStop = false;
            this.colinvPriceTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colinvPriceTotal.Summary"))), resources.GetString("colinvPriceTotal.Summary1"), resources.GetString("colinvPriceTotal.Summary2"))});
            // 
            // colinvSalePrice
            // 
            this.colinvSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colinvSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvSalePrice, "colinvSalePrice");
            this.colinvSalePrice.DisplayFormat.FormatString = "n3";
            this.colinvSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colinvSalePrice.FieldName = "invSalePrice";
            this.colinvSalePrice.MinWidth = 99;
            this.colinvSalePrice.Name = "colinvSalePrice";
            this.colinvSalePrice.OptionsColumn.AllowEdit = false;
            this.colinvSalePrice.OptionsColumn.TabStop = false;
            // 
            // colinvSalePriceTotal
            // 
            this.colinvSalePriceTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colinvSalePriceTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colinvSalePriceTotal, "colinvSalePriceTotal");
            this.colinvSalePriceTotal.DisplayFormat.FormatString = "n3";
            this.colinvSalePriceTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colinvSalePriceTotal.FieldName = "invSalePriceTotal";
            this.colinvSalePriceTotal.MinWidth = 99;
            this.colinvSalePriceTotal.Name = "colinvSalePriceTotal";
            this.colinvSalePriceTotal.OptionsColumn.AllowEdit = false;
            this.colinvSalePriceTotal.OptionsColumn.TabStop = false;
            this.colinvSalePriceTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colinvSalePriceTotal.Summary"))), resources.GetString("colinvSalePriceTotal.Summary1"), resources.GetString("colinvSalePriceTotal.Summary2"))});
            // 
            // repoItemLookUpEditPrdMsur
            // 
            resources.ApplyResources(this.repoItemLookUpEditPrdMsur, "repoItemLookUpEditPrdMsur");
            this.repoItemLookUpEditPrdMsur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repoItemLookUpEditPrdMsur.Buttons"))))});
            this.repoItemLookUpEditPrdMsur.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("repoItemLookUpEditPrdMsur.Columns"), resources.GetString("repoItemLookUpEditPrdMsur.Columns1"), ((int)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns3"))), resources.GetString("repoItemLookUpEditPrdMsur.Columns4"), ((bool)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("repoItemLookUpEditPrdMsur.Columns8"))))});
            this.repoItemLookUpEditPrdMsur.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.repoItemLookUpEditPrdMsur.DisplayMember = "ppmMsurName";
            this.repoItemLookUpEditPrdMsur.Name = "repoItemLookUpEditPrdMsur";
            this.repoItemLookUpEditPrdMsur.ShowHeader = false;
            this.repoItemLookUpEditPrdMsur.ValueMember = "ppmId";
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1343, 457);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1323, 437);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidateHiddenControls = false;
            // 
            // formAddInvStore
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "formAddInvStore";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invStrIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invGrpIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroupStrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invBarcodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invManualSrchTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreMainLookupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invSetlmntAccIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvStrId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupProductSrch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvBarcodeSrch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvGrpId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbtnSubmitGrpProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvManualSrch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbtnSubmitInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForinvSetlmntAccId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInvStoreSubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSrchLookUpEditPrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSrchLookUpEditPrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLookUpEditPrdMsur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource tblInvStoreMainBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblInvStoreSubBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colinvMainId;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPrdMsurId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit invNoTextEdit;
        private DevExpress.XtraEditors.DateEdit invDateDateEdit;
        private DevExpress.XtraEditors.LookUpEdit invStrIdTextEdit;
        private System.Windows.Forms.BindingSource tblStoreBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvStrId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvDate;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repoItemSrchLookUpEditPrd;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repoItemSrchLookUpEditPrdView;
        private DevExpress.XtraGrid.Columns.GridColumn colPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvGrpId;
        private DevExpress.XtraEditors.SimpleButton btnSubmitGrpProducts;
        private DevExpress.XtraLayout.LayoutControlItem ItemForbtnSubmitGrpProducts;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPrdGrpId;
        private DevExpress.XtraGrid.Columns.GridColumn colinvQuanStr;
        private DevExpress.XtraGrid.Columns.GridColumn colinvQuanAvl;
        private DevExpress.XtraGrid.Columns.GridColumn colinvQuanDefr;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPriceAvrg;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPriceDefr;
        private DevExpress.XtraEditors.LookUpEdit invGrpIdTextEdit;
        private DevExpress.XtraEditors.TextEdit invBarcodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupProductSrch;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvBarcodeSrch;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvManualSrch;
        private DevExpress.XtraEditors.SimpleButton btnSubmitInv;
        private DevExpress.XtraLayout.LayoutControlItem ItemForbtnSubmitInv;
        private DevExpress.XtraEditors.LookUpEdit invManualSrchTextEdit;
        private System.Windows.Forms.BindingSource tblInvStoreMainLookupBindingSource;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource tblGroupStrBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoItemLookUpEditPrdMsur;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshPrdQuanNdPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colinvPriceTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colinvSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colinvSalePriceTotal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForinvSetlmntAccId;
        private DevExpress.XtraEditors.LookUpEdit invSetlmntAccIdTextEdit;
        private System.Windows.Forms.BindingSource tblAccountBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colinvBarcode;
    }
}