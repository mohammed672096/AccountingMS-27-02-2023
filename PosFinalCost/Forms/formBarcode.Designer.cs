using DevExpress.XtraEditors;
using DevExpress.BarCodes;
using System.Drawing;
using System.Text;
using System;
namespace PosFinalCost
{
    partial class formBarcode {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        PictureEdit pictureEdit;
        BarCode barCode;
        CheckEdit checkEditBarcodeNo;
        ColorEdit backColorE;
        ColorEdit foreColorE;
        SpinEdit angleSE;
        TextEdit textEditCompanyName;
        TextEdit textEditProductName;
        CheckEdit checkEditCompanyName;
        CheckEdit checkEditPrdName;
        FontEdit codeTextFE;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBarcode));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.BarCodeVisualizationlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.comboBoxEditSymbology = new DevExpress.XtraEditors.ComboBoxEdit();
            this.errorText = new DevExpress.XtraEditors.LabelControl();
            this.checkEditPrdName = new DevExpress.XtraEditors.CheckEdit();
            this.bottomCaptionForeCE = new DevExpress.XtraEditors.ColorEdit();
            this.bottomCaptionFE = new DevExpress.XtraEditors.FontEdit();
            this.textEditProductName = new DevExpress.XtraEditors.TextEdit();
            this.bottomCaptionAligmentCB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEditCompanyName = new DevExpress.XtraEditors.CheckEdit();
            this.topCaptionForeCE = new DevExpress.XtraEditors.ColorEdit();
            this.topCaptionFE = new DevExpress.XtraEditors.FontEdit();
            this.topCaptionAligmentCB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.checkEditBarcodeNo = new DevExpress.XtraEditors.CheckEdit();
            this.codeTextVertAlignmentCB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.backColorE = new DevExpress.XtraEditors.ColorEdit();
            this.codeTextHorzAlignmentCB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.foreColorE = new DevExpress.XtraEditors.ColorEdit();
            this.codeTextFE = new DevExpress.XtraEditors.FontEdit();
            this.angleSE = new DevExpress.XtraEditors.SpinEdit();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPrdPrice = new DevExpress.XtraEditors.TextEdit();
            this.checkEditExpireDate = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPrdPrice = new DevExpress.XtraEditors.CheckEdit();
            this.textEditExpireDate = new DevExpress.XtraEditors.DateEdit();
            this.textEditProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colproductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditWidth = new DevExpress.XtraEditors.SpinEdit();
            this.textEditHeight = new DevExpress.XtraEditors.SpinEdit();
            this.textEditBarocdeNo = new DevExpress.XtraEditors.TextEdit();
            this.btnDefaultSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveUserSettings = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPageWidth = new DevExpress.XtraEditors.SpinEdit();
            this.btnPrintBarocde = new DevExpress.XtraEditors.SimpleButton();
            this.textEditOtherInfo = new DevExpress.XtraEditors.TextEdit();
            this.textEditSrchBarcode = new DevExpress.XtraEditors.TextEdit();
            this.textEditPrdMsur = new DevExpress.XtraEditors.LookUpEdit();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkEditSaleTax = new DevExpress.XtraEditors.CheckEdit();
            this.textEditPrinterBarcod = new DevExpress.XtraEditors.LookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picbarcode = new System.Windows.Forms.PictureBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.bottomCaptionGCitem = new DevExpress.XtraLayout.LayoutControlGroup();
            this.bottomCaptionForeCEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.bottomCaptionFEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.bottomCaptionTEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.bottomCaptionAligmentCBitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.bottomCaptionCEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.pictureEdititem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemBtnSaveUserSettings = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupPrdInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.barCodeTextitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutCotrolItemSrchBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPrdMsur = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemOtherInfo = new DevExpress.XtraLayout.LayoutControlItem();
            this.topCaptionGCitem = new DevExpress.XtraLayout.LayoutControlGroup();
            this.topCaptionCEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.topCaptionForeCEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.topCaptionFEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.topCaptionAligmentCBitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.topCaptionTEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.barCogeGCitem = new DevExpress.XtraLayout.LayoutControlGroup();
            this.showTextCEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.codeTextVertAlignmentCBitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.backColorEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.codeTextHorzAlignmentCBitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.foreColorEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.codeTextFEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.angleSEitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textEditHeightitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEditWidthitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemReportWidth = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForPrdExpirateAcc1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.clsProductBarcodeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeVisualizationlayoutControl1ConvertedLayout)).BeginInit();
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSymbology.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPrdName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionForeCE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionFE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionForeCE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionFE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBarcodeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreColorE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextFE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrdPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExpireDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPrdPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditExpireDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditExpireDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarocdeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPageWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOtherInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSrchBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrdMsur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSaleTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrinterBarcod.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionGCitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionForeCEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionFEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionTEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCBitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionCEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdititem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnSaveUserSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPrdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCodeTextitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCotrolItemSrchBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPrdMsur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOtherInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionGCitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionCEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionForeCEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionFEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCBitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionTEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCogeGCitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showTextCEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCBitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCBitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreColorEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextFEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSEitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeightitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidthitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReportWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPrdExpirateAcc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsProductBarcodeListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit
            // 
            this.pictureEdit.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pictureEdit, "pictureEdit");
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.ShowMenu = false;
            this.pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // BarCodeVisualizationlayoutControl1ConvertedLayout
            // 
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.spinEdit1);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.comboBoxEditSymbology);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.errorText);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.pictureEdit);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditPrdName);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.bottomCaptionForeCE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.bottomCaptionFE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditProductName);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.bottomCaptionAligmentCB);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditCompanyName);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.topCaptionForeCE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.topCaptionFE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.topCaptionAligmentCB);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditCompanyName);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditBarcodeNo);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.codeTextVertAlignmentCB);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.backColorE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.codeTextHorzAlignmentCB);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.foreColorE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.codeTextFE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.angleSE);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.btnPrintPreview);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditPrdPrice);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditExpireDate);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditPrdPrice);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditExpireDate);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditProduct);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditWidth);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditHeight);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditBarocdeNo);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.btnDefaultSettings);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.btnUserSettings);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.btnSaveUserSettings);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditPageWidth);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.btnPrintBarocde);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditOtherInfo);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditSrchBarcode);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditPrdMsur);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.checkEditSaleTax);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.textEditPrinterBarcod);
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Controls.Add(this.panel2);
            resources.ApplyResources(this.BarCodeVisualizationlayoutControl1ConvertedLayout, "BarCodeVisualizationlayoutControl1ConvertedLayout");
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.LookAndFeel.SkinName = "The Bezier";
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Name = "BarCodeVisualizationlayoutControl1ConvertedLayout";
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.OptionsView.RightToLeftMirroringApplied = true;
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            // 
            // spinEdit1
            // 
            resources.ApplyResources(this.spinEdit1, "spinEdit1");
            this.spinEdit1.MenuManager = this.ribbonControl1;
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("spinEdit1.Properties.Appearance.Font")));
            this.spinEdit1.Properties.Appearance.Options.UseFont = true;
            this.spinEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("spinEdit1.Properties.AutoHeight")));
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("spinEdit1.Properties.Buttons"))))});
            this.spinEdit1.Properties.IsFloatValue = false;
            this.spinEdit1.Properties.Mask.EditMask = resources.GetString("spinEdit1.Properties.Mask.EditMask");
            this.spinEdit1.Properties.MaxLength = 255;
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 39, 30, 39);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // comboBoxEditSymbology
            // 
            resources.ApplyResources(this.comboBoxEditSymbology, "comboBoxEditSymbology");
            this.comboBoxEditSymbology.Name = "comboBoxEditSymbology";
            this.comboBoxEditSymbology.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("comboBoxEditSymbology.Properties.Buttons"))))});
            this.comboBoxEditSymbology.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSymbology.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // errorText
            // 
            this.errorText.Appearance.BackColor = System.Drawing.Color.White;
            this.errorText.Appearance.ForeColor = System.Drawing.Color.Red;
            this.errorText.Appearance.Options.UseBackColor = true;
            this.errorText.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.errorText, "errorText");
            this.errorText.Name = "errorText";
            this.errorText.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // checkEditPrdName
            // 
            resources.ApplyResources(this.checkEditPrdName, "checkEditPrdName");
            this.checkEditPrdName.Name = "checkEditPrdName";
            this.checkEditPrdName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("checkEditPrdName.Properties.Appearance.Font")));
            this.checkEditPrdName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.checkEditPrdName.Properties.Appearance.Options.UseFont = true;
            this.checkEditPrdName.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditPrdName.Properties.Caption = resources.GetString("checkEditPrdName.Properties.Caption");
            this.checkEditPrdName.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.checkEditPrdName.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // bottomCaptionForeCE
            // 
            resources.ApplyResources(this.bottomCaptionForeCE, "bottomCaptionForeCE");
            this.bottomCaptionForeCE.Name = "bottomCaptionForeCE";
            this.bottomCaptionForeCE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.bottomCaptionForeCE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // bottomCaptionFE
            // 
            resources.ApplyResources(this.bottomCaptionFE, "bottomCaptionFE");
            this.bottomCaptionFE.Name = "bottomCaptionFE";
            this.bottomCaptionFE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bottomCaptionFE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.bottomCaptionFE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // textEditProductName
            // 
            resources.ApplyResources(this.textEditProductName, "textEditProductName");
            this.textEditProductName.Name = "textEditProductName";
            this.textEditProductName.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.textEditProductName.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // bottomCaptionAligmentCB
            // 
            resources.ApplyResources(this.bottomCaptionAligmentCB, "bottomCaptionAligmentCB");
            this.bottomCaptionAligmentCB.Name = "bottomCaptionAligmentCB";
            this.bottomCaptionAligmentCB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("bottomCaptionAligmentCB.Properties.Buttons"))))});
            this.bottomCaptionAligmentCB.Properties.DropDownRows = 20;
            this.bottomCaptionAligmentCB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.bottomCaptionAligmentCB.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.bottomCaptionAligmentCB.SelectedIndexChanged += new System.EventHandler(this.editValueChanged);
            // 
            // checkEditCompanyName
            // 
            resources.ApplyResources(this.checkEditCompanyName, "checkEditCompanyName");
            this.checkEditCompanyName.Name = "checkEditCompanyName";
            this.checkEditCompanyName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("checkEditCompanyName.Properties.Appearance.Font")));
            this.checkEditCompanyName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.checkEditCompanyName.Properties.Appearance.Options.UseFont = true;
            this.checkEditCompanyName.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditCompanyName.Properties.Caption = resources.GetString("checkEditCompanyName.Properties.Caption");
            this.checkEditCompanyName.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.checkEditCompanyName.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // topCaptionForeCE
            // 
            resources.ApplyResources(this.topCaptionForeCE, "topCaptionForeCE");
            this.topCaptionForeCE.Name = "topCaptionForeCE";
            this.topCaptionForeCE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.topCaptionForeCE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // topCaptionFE
            // 
            resources.ApplyResources(this.topCaptionFE, "topCaptionFE");
            this.topCaptionFE.Name = "topCaptionFE";
            this.topCaptionFE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.topCaptionFE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.topCaptionFE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // topCaptionAligmentCB
            // 
            resources.ApplyResources(this.topCaptionAligmentCB, "topCaptionAligmentCB");
            this.topCaptionAligmentCB.Name = "topCaptionAligmentCB";
            this.topCaptionAligmentCB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("topCaptionAligmentCB.Properties.Buttons"))))});
            this.topCaptionAligmentCB.Properties.DropDownRows = 20;
            this.topCaptionAligmentCB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.topCaptionAligmentCB.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.topCaptionAligmentCB.SelectedIndexChanged += new System.EventHandler(this.editValueChanged);
            // 
            // textEditCompanyName
            // 
            resources.ApplyResources(this.textEditCompanyName, "textEditCompanyName");
            this.textEditCompanyName.Name = "textEditCompanyName";
            this.textEditCompanyName.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.textEditCompanyName.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // checkEditBarcodeNo
            // 
            resources.ApplyResources(this.checkEditBarcodeNo, "checkEditBarcodeNo");
            this.checkEditBarcodeNo.Name = "checkEditBarcodeNo";
            this.checkEditBarcodeNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("checkEditBarcodeNo.Properties.Appearance.Font")));
            this.checkEditBarcodeNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.checkEditBarcodeNo.Properties.Appearance.Options.UseFont = true;
            this.checkEditBarcodeNo.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditBarcodeNo.Properties.Caption = resources.GetString("checkEditBarcodeNo.Properties.Caption");
            this.checkEditBarcodeNo.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.checkEditBarcodeNo.CheckStateChanged += new System.EventHandler(this.showTextCE_CheckStateChanged);
            // 
            // codeTextVertAlignmentCB
            // 
            resources.ApplyResources(this.codeTextVertAlignmentCB, "codeTextVertAlignmentCB");
            this.codeTextVertAlignmentCB.Name = "codeTextVertAlignmentCB";
            this.codeTextVertAlignmentCB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("codeTextVertAlignmentCB.Properties.Buttons"))))});
            this.codeTextVertAlignmentCB.Properties.DropDownRows = 20;
            this.codeTextVertAlignmentCB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.codeTextVertAlignmentCB.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.codeTextVertAlignmentCB.SelectedIndexChanged += new System.EventHandler(this.editValueChanged);
            // 
            // backColorE
            // 
            resources.ApplyResources(this.backColorE, "backColorE");
            this.backColorE.Name = "backColorE";
            this.backColorE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.backColorE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // codeTextHorzAlignmentCB
            // 
            resources.ApplyResources(this.codeTextHorzAlignmentCB, "codeTextHorzAlignmentCB");
            this.codeTextHorzAlignmentCB.Name = "codeTextHorzAlignmentCB";
            this.codeTextHorzAlignmentCB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("codeTextHorzAlignmentCB.Properties.Buttons"))))});
            this.codeTextHorzAlignmentCB.Properties.DropDownRows = 20;
            this.codeTextHorzAlignmentCB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.codeTextHorzAlignmentCB.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.codeTextHorzAlignmentCB.SelectedIndexChanged += new System.EventHandler(this.editValueChanged);
            // 
            // foreColorE
            // 
            resources.ApplyResources(this.foreColorE, "foreColorE");
            this.foreColorE.Name = "foreColorE";
            this.foreColorE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.foreColorE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // codeTextFE
            // 
            resources.ApplyResources(this.codeTextFE, "codeTextFE");
            this.codeTextFE.Name = "codeTextFE";
            this.codeTextFE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.codeTextFE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.codeTextFE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // angleSE
            // 
            resources.ApplyResources(this.angleSE, "angleSE");
            this.angleSE.Name = "angleSE";
            this.angleSE.Properties.Appearance.Options.UseTextOptions = true;
            this.angleSE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.angleSE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.angleSE.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.angleSE.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnPrintPreview.Appearance.Font")));
            this.btnPrintPreview.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintPreview.Appearance.Options.UseFont = true;
            this.btnPrintPreview.Appearance.Options.UseForeColor = true;
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            resources.ApplyResources(this.btnPrintPreview, "btnPrintPreview");
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.btnPrintPreview.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textEditPrdPrice
            // 
            resources.ApplyResources(this.textEditPrdPrice, "textEditPrdPrice");
            this.textEditPrdPrice.Name = "textEditPrdPrice";
            this.textEditPrdPrice.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // checkEditExpireDate
            // 
            resources.ApplyResources(this.checkEditExpireDate, "checkEditExpireDate");
            this.checkEditExpireDate.Name = "checkEditExpireDate";
            this.checkEditExpireDate.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("checkEditExpireDate.Properties.Appearance.Font")));
            this.checkEditExpireDate.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.checkEditExpireDate.Properties.Appearance.Options.UseFont = true;
            this.checkEditExpireDate.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditExpireDate.Properties.Caption = resources.GetString("checkEditExpireDate.Properties.Caption");
            this.checkEditExpireDate.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // checkEditPrdPrice
            // 
            resources.ApplyResources(this.checkEditPrdPrice, "checkEditPrdPrice");
            this.checkEditPrdPrice.Name = "checkEditPrdPrice";
            this.checkEditPrdPrice.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("checkEditPrdPrice.Properties.Appearance.Font")));
            this.checkEditPrdPrice.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.checkEditPrdPrice.Properties.Appearance.Options.UseFont = true;
            this.checkEditPrdPrice.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditPrdPrice.Properties.Caption = resources.GetString("checkEditPrdPrice.Properties.Caption");
            this.checkEditPrdPrice.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // textEditExpireDate
            // 
            resources.ApplyResources(this.textEditExpireDate, "textEditExpireDate");
            this.textEditExpireDate.Name = "textEditExpireDate";
            this.textEditExpireDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditExpireDate.Properties.Buttons"))))});
            this.textEditExpireDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditExpireDate.Properties.CalendarTimeProperties.Buttons"))))});
            this.textEditExpireDate.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.textEditExpireDate.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditExpireDate.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("textEditExpireDate.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.textEditExpireDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditExpireDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditExpireDate.Properties.EditFormat.FormatString = "{0:dd/MM/yyyy}";
            this.textEditExpireDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditExpireDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEditExpireDate.Properties.Mask.BeepOnError")));
            this.textEditExpireDate.Properties.Mask.EditMask = resources.GetString("textEditExpireDate.Properties.Mask.EditMask");
            this.textEditExpireDate.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // textEditProduct
            // 
            resources.ApplyResources(this.textEditProduct, "textEditProduct");
            this.textEditProduct.Name = "textEditProduct";
            this.textEditProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditProduct.Properties.Buttons"))))});
            this.textEditProduct.Properties.DataSource = this.tblProductBindingSource;
            this.textEditProduct.Properties.DisplayMember = "Name";
            this.textEditProduct.Properties.NullText = resources.GetString("textEditProduct.Properties.NullText");
            this.textEditProduct.Properties.PopupView = this.searchLookUpEdit1View;
            this.textEditProduct.Properties.ValueMember = "ID";
            this.textEditProduct.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.textEditProduct.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataSource = typeof(PosFinalCost.Product);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colproductName,
            this.colid});
            this.searchLookUpEdit1View.DetailHeight = 457;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colproductName
            // 
            resources.ApplyResources(this.colproductName, "colproductName");
            this.colproductName.FieldName = "Name";
            this.colproductName.Name = "colproductName";
            // 
            // colid
            // 
            this.colid.FieldName = "ID";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // textEditWidth
            // 
            resources.ApplyResources(this.textEditWidth, "textEditWidth");
            this.textEditWidth.Name = "textEditWidth";
            this.textEditWidth.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditWidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textEditWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditWidth.Properties.Buttons"))))});
            this.textEditWidth.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.textEditWidth.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.textEditWidth.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEditWidth.Properties.Mask.MaskType")));
            this.textEditWidth.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.textEditWidth.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.textEditWidth.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.textEditWidth.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // textEditHeight
            // 
            resources.ApplyResources(this.textEditHeight, "textEditHeight");
            this.textEditHeight.Name = "textEditHeight";
            this.textEditHeight.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditHeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textEditHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditHeight.Properties.Buttons"))))});
            this.textEditHeight.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.textEditHeight.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEditHeight.Properties.Mask.MaskType")));
            this.textEditHeight.Properties.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.textEditHeight.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textEditHeight.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.textEditHeight.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // textEditBarocdeNo
            // 
            resources.ApplyResources(this.textEditBarocdeNo, "textEditBarocdeNo");
            this.textEditBarocdeNo.Name = "textEditBarocdeNo";
            this.textEditBarocdeNo.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.textEditBarocdeNo, conditionValidationRule1);
            this.textEditBarocdeNo.EditValueChanged += new System.EventHandler(this.editValueChanged);
            // 
            // btnDefaultSettings
            // 
            this.btnDefaultSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultSettings.ImageOptions.Image")));
            resources.ApplyResources(this.btnDefaultSettings, "btnDefaultSettings");
            this.btnDefaultSettings.Name = "btnDefaultSettings";
            this.btnDefaultSettings.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.btnDefaultSettings.Click += new System.EventHandler(this.BtnDefaultSettings_Click);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnUserSettings.Appearance.Font")));
            this.btnUserSettings.Appearance.Options.UseFont = true;
            this.btnUserSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserSettings.ImageOptions.SvgImage")));
            resources.ApplyResources(this.btnUserSettings, "btnUserSettings");
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.btnUserSettings.Click += new System.EventHandler(this.BtnUserSettings_Click);
            // 
            // btnSaveUserSettings
            // 
            this.btnSaveUserSettings.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSaveUserSettings.Appearance.Font")));
            this.btnSaveUserSettings.Appearance.Options.UseFont = true;
            this.btnSaveUserSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveUserSettings.ImageOptions.SvgImage")));
            resources.ApplyResources(this.btnSaveUserSettings, "btnSaveUserSettings");
            this.btnSaveUserSettings.Name = "btnSaveUserSettings";
            this.btnSaveUserSettings.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.btnSaveUserSettings.Click += new System.EventHandler(this.BtnSaveUserSettings_Click);
            // 
            // textEditPageWidth
            // 
            resources.ApplyResources(this.textEditPageWidth, "textEditPageWidth");
            this.textEditPageWidth.MenuManager = this.ribbonControl1;
            this.textEditPageWidth.Name = "textEditPageWidth";
            this.textEditPageWidth.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditPageWidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textEditPageWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditPageWidth.Properties.Buttons"))))});
            this.textEditPageWidth.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // btnPrintBarocde
            // 
            this.btnPrintBarocde.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnPrintBarocde.Appearance.Font")));
            this.btnPrintBarocde.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintBarocde.Appearance.Options.UseFont = true;
            this.btnPrintBarocde.Appearance.Options.UseForeColor = true;
            this.btnPrintBarocde.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintBarocde.ImageOptions.SvgImage")));
            resources.ApplyResources(this.btnPrintBarocde, "btnPrintBarocde");
            this.btnPrintBarocde.Name = "btnPrintBarocde";
            this.btnPrintBarocde.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.btnPrintBarocde.Click += new System.EventHandler(this.BtnPrintBarocde_Click);
            // 
            // textEditOtherInfo
            // 
            resources.ApplyResources(this.textEditOtherInfo, "textEditOtherInfo");
            this.textEditOtherInfo.MenuManager = this.ribbonControl1;
            this.textEditOtherInfo.Name = "textEditOtherInfo";
            this.textEditOtherInfo.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // textEditSrchBarcode
            // 
            resources.ApplyResources(this.textEditSrchBarcode, "textEditSrchBarcode");
            this.textEditSrchBarcode.MenuManager = this.ribbonControl1;
            this.textEditSrchBarcode.Name = "textEditSrchBarcode";
            this.textEditSrchBarcode.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // textEditPrdMsur
            // 
            resources.ApplyResources(this.textEditPrdMsur, "textEditPrdMsur");
            this.textEditPrdMsur.MenuManager = this.ribbonControl1;
            this.textEditPrdMsur.Name = "textEditPrdMsur";
            this.textEditPrdMsur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditPrdMsur.Properties.Buttons"))))});
            this.textEditPrdMsur.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("textEditPrdMsur.Properties.Columns"), resources.GetString("textEditPrdMsur.Properties.Columns1"))});
            this.textEditPrdMsur.Properties.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.textEditPrdMsur.Properties.DisplayMember = "Name";
            this.textEditPrdMsur.Properties.NullText = resources.GetString("textEditPrdMsur.Properties.NullText");
            this.textEditPrdMsur.Properties.ShowHeader = false;
            this.textEditPrdMsur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.textEditPrdMsur.Properties.ValueMember = "ID";
            this.textEditPrdMsur.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(PosFinalCost.PrdMeasurment);
            // 
            // checkEditSaleTax
            // 
            resources.ApplyResources(this.checkEditSaleTax, "checkEditSaleTax");
            this.checkEditSaleTax.MenuManager = this.ribbonControl1;
            this.checkEditSaleTax.Name = "checkEditSaleTax";
            this.checkEditSaleTax.Properties.Caption = resources.GetString("checkEditSaleTax.Properties.Caption");
            this.checkEditSaleTax.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            this.checkEditSaleTax.CheckedChanged += new System.EventHandler(this.checkEditSaleTax_CheckedChanged);
            // 
            // textEditPrinterBarcod
            // 
            resources.ApplyResources(this.textEditPrinterBarcod, "textEditPrinterBarcod");
            this.textEditPrinterBarcod.Name = "textEditPrinterBarcod";
            this.textEditPrinterBarcod.Properties.AutoHeight = ((bool)(resources.GetObject("textEditPrinterBarcod.Properties.AutoHeight")));
            this.textEditPrinterBarcod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEditPrinterBarcod.Properties.Buttons"))))});
            this.textEditPrinterBarcod.Properties.NullText = resources.GetString("textEditPrinterBarcod.Properties.NullText");
            this.textEditPrinterBarcod.StyleController = this.BarCodeVisualizationlayoutControl1ConvertedLayout;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.picbarcode);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // picbarcode
            // 
            resources.ApplyResources(this.picbarcode, "picbarcode");
            this.picbarcode.Name = "picbarcode";
            this.picbarcode.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup1.AppearanceGroup.Font")));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup1.AppearanceItemCaption.Font")));
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.bottomCaptionGCitem,
            this.pictureEdititem,
            this.layoutControlGroup3,
            this.layoutControlItem1,
            this.layoutItemBtnSaveUserSettings,
            this.layoutControlGroupPrdInfo,
            this.topCaptionGCitem,
            this.barCogeGCitem,
            this.layoutControlGroup2,
            this.layoutControlItem8,
            this.itemForPrdExpirateAcc1,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem2,
            this.layoutControlItem11,
            this.layoutControlItem10});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1328, 805);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // bottomCaptionGCitem
            // 
            this.bottomCaptionGCitem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.bottomCaptionForeCEitem,
            this.bottomCaptionFEitem,
            this.bottomCaptionTEitem,
            this.bottomCaptionAligmentCBitem,
            this.bottomCaptionCEitem});
            this.bottomCaptionGCitem.Location = new System.Drawing.Point(308, 0);
            this.bottomCaptionGCitem.Name = "bottomCaptionGCitem";
            this.bottomCaptionGCitem.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.bottomCaptionGCitem.Size = new System.Drawing.Size(540, 181);
            resources.ApplyResources(this.bottomCaptionGCitem, "bottomCaptionGCitem");
            // 
            // bottomCaptionForeCEitem
            // 
            this.bottomCaptionForeCEitem.Control = this.bottomCaptionForeCE;
            this.bottomCaptionForeCEitem.Location = new System.Drawing.Point(0, 85);
            this.bottomCaptionForeCEitem.Name = "bottomCaptionForeCEitem";
            this.bottomCaptionForeCEitem.Size = new System.Drawing.Size(514, 27);
            resources.ApplyResources(this.bottomCaptionForeCEitem, "bottomCaptionForeCEitem");
            this.bottomCaptionForeCEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.bottomCaptionForeCEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // bottomCaptionFEitem
            // 
            this.bottomCaptionFEitem.Control = this.bottomCaptionFE;
            this.bottomCaptionFEitem.Location = new System.Drawing.Point(0, 112);
            this.bottomCaptionFEitem.Name = "bottomCaptionFEitem";
            this.bottomCaptionFEitem.Size = new System.Drawing.Size(514, 27);
            resources.ApplyResources(this.bottomCaptionFEitem, "bottomCaptionFEitem");
            this.bottomCaptionFEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.bottomCaptionFEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // bottomCaptionTEitem
            // 
            this.bottomCaptionTEitem.Control = this.textEditProductName;
            this.bottomCaptionTEitem.Location = new System.Drawing.Point(0, 31);
            this.bottomCaptionTEitem.Name = "bottomCaptionTEitem";
            this.bottomCaptionTEitem.Size = new System.Drawing.Size(514, 27);
            resources.ApplyResources(this.bottomCaptionTEitem, "bottomCaptionTEitem");
            this.bottomCaptionTEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // bottomCaptionAligmentCBitem
            // 
            this.bottomCaptionAligmentCBitem.Control = this.bottomCaptionAligmentCB;
            this.bottomCaptionAligmentCBitem.Location = new System.Drawing.Point(0, 58);
            this.bottomCaptionAligmentCBitem.Name = "bottomCaptionAligmentCBitem";
            this.bottomCaptionAligmentCBitem.Size = new System.Drawing.Size(514, 27);
            resources.ApplyResources(this.bottomCaptionAligmentCBitem, "bottomCaptionAligmentCBitem");
            this.bottomCaptionAligmentCBitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // bottomCaptionCEitem
            // 
            this.bottomCaptionCEitem.Control = this.checkEditPrdName;
            this.bottomCaptionCEitem.Location = new System.Drawing.Point(0, 0);
            this.bottomCaptionCEitem.Name = "bottomCaptionCEitem";
            this.bottomCaptionCEitem.Size = new System.Drawing.Size(514, 31);
            resources.ApplyResources(this.bottomCaptionCEitem, "bottomCaptionCEitem");
            this.bottomCaptionCEitem.TextSize = new System.Drawing.Size(0, 0);
            this.bottomCaptionCEitem.TextVisible = false;
            // 
            // pictureEdititem
            // 
            this.pictureEdititem.Control = this.pictureEdit;
            this.pictureEdititem.Location = new System.Drawing.Point(0, 437);
            this.pictureEdititem.Name = "pictureEdititem";
            this.pictureEdititem.Size = new System.Drawing.Size(848, 257);
            this.pictureEdititem.TextSize = new System.Drawing.Size(0, 0);
            this.pictureEdititem.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem12});
            this.layoutControlGroup3.Location = new System.Drawing.Point(848, 177);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.layoutControlGroup3.Size = new System.Drawing.Size(480, 128);
            resources.ApplyResources(this.layoutControlGroup3, "layoutControlGroup3");
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.checkEditExpireDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(272, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(182, 31);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkEditPrdPrice;
            this.layoutControlItem6.Location = new System.Drawing.Point(272, 31);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(182, 31);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.textEditExpireDate;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(272, 31);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEditPrdPrice;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(272, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.checkEditSaleTax;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 62);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 0, 0);
            this.layoutControlItem12.Size = new System.Drawing.Size(454, 24);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.errorText;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 782);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1328, 23);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutItemBtnSaveUserSettings
            // 
            this.layoutItemBtnSaveUserSettings.Control = this.btnSaveUserSettings;
            this.layoutItemBtnSaveUserSettings.Location = new System.Drawing.Point(1100, 694);
            this.layoutItemBtnSaveUserSettings.MaxSize = new System.Drawing.Size(0, 48);
            this.layoutItemBtnSaveUserSettings.MinSize = new System.Drawing.Size(205, 48);
            this.layoutItemBtnSaveUserSettings.Name = "layoutItemBtnSaveUserSettings";
            this.layoutItemBtnSaveUserSettings.Size = new System.Drawing.Size(228, 48);
            this.layoutItemBtnSaveUserSettings.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            resources.ApplyResources(this.layoutItemBtnSaveUserSettings, "layoutItemBtnSaveUserSettings");
            this.layoutItemBtnSaveUserSettings.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemBtnSaveUserSettings.TextVisible = false;
            // 
            // layoutControlGroupPrdInfo
            // 
            this.layoutControlGroupPrdInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.barCodeTextitem,
            this.layoutControlItem3,
            this.layoutCotrolItemSrchBarcode,
            this.layoutControlItemPrdMsur,
            this.layoutControlItemOtherInfo});
            this.layoutControlGroupPrdInfo.Location = new System.Drawing.Point(848, 0);
            this.layoutControlGroupPrdInfo.Name = "layoutControlGroupPrdInfo";
            this.layoutControlGroupPrdInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.layoutControlGroupPrdInfo.Size = new System.Drawing.Size(480, 177);
            resources.ApplyResources(this.layoutControlGroupPrdInfo, "layoutControlGroupPrdInfo");
            // 
            // barCodeTextitem
            // 
            this.barCodeTextitem.Control = this.textEditProduct;
            this.barCodeTextitem.Location = new System.Drawing.Point(0, 27);
            this.barCodeTextitem.Name = "barCodeTextitem";
            this.barCodeTextitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.barCodeTextitem, "barCodeTextitem");
            this.barCodeTextitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEditBarocdeNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutCotrolItemSrchBarcode
            // 
            this.layoutCotrolItemSrchBarcode.Control = this.textEditSrchBarcode;
            this.layoutCotrolItemSrchBarcode.Location = new System.Drawing.Point(0, 0);
            this.layoutCotrolItemSrchBarcode.Name = "layoutCotrolItemSrchBarcode";
            this.layoutCotrolItemSrchBarcode.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.layoutCotrolItemSrchBarcode, "layoutCotrolItemSrchBarcode");
            this.layoutCotrolItemSrchBarcode.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItemPrdMsur
            // 
            this.layoutControlItemPrdMsur.Control = this.textEditPrdMsur;
            this.layoutControlItemPrdMsur.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItemPrdMsur.Name = "layoutControlItemPrdMsur";
            this.layoutControlItemPrdMsur.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.layoutControlItemPrdMsur, "layoutControlItemPrdMsur");
            this.layoutControlItemPrdMsur.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItemOtherInfo
            // 
            this.layoutControlItemOtherInfo.Control = this.textEditOtherInfo;
            this.layoutControlItemOtherInfo.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItemOtherInfo.Name = "layoutControlItemOtherInfo";
            this.layoutControlItemOtherInfo.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.layoutControlItemOtherInfo, "layoutControlItemOtherInfo");
            this.layoutControlItemOtherInfo.TextSize = new System.Drawing.Size(177, 23);
            // 
            // topCaptionGCitem
            // 
            this.topCaptionGCitem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.topCaptionCEitem,
            this.topCaptionForeCEitem,
            this.topCaptionFEitem,
            this.topCaptionAligmentCBitem,
            this.topCaptionTEitem});
            this.topCaptionGCitem.Location = new System.Drawing.Point(0, 0);
            this.topCaptionGCitem.Name = "topCaptionGCitem";
            this.topCaptionGCitem.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.topCaptionGCitem.Size = new System.Drawing.Size(308, 181);
            resources.ApplyResources(this.topCaptionGCitem, "topCaptionGCitem");
            // 
            // topCaptionCEitem
            // 
            this.topCaptionCEitem.Control = this.checkEditCompanyName;
            this.topCaptionCEitem.Location = new System.Drawing.Point(0, 0);
            this.topCaptionCEitem.Name = "topCaptionCEitem";
            this.topCaptionCEitem.Size = new System.Drawing.Size(282, 31);
            resources.ApplyResources(this.topCaptionCEitem, "topCaptionCEitem");
            this.topCaptionCEitem.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.topCaptionCEitem.TextSize = new System.Drawing.Size(0, 0);
            this.topCaptionCEitem.TextVisible = false;
            // 
            // topCaptionForeCEitem
            // 
            this.topCaptionForeCEitem.Control = this.topCaptionForeCE;
            this.topCaptionForeCEitem.Location = new System.Drawing.Point(0, 85);
            this.topCaptionForeCEitem.Name = "topCaptionForeCEitem";
            this.topCaptionForeCEitem.Size = new System.Drawing.Size(282, 27);
            resources.ApplyResources(this.topCaptionForeCEitem, "topCaptionForeCEitem");
            this.topCaptionForeCEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.topCaptionForeCEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // topCaptionFEitem
            // 
            this.topCaptionFEitem.Control = this.topCaptionFE;
            this.topCaptionFEitem.Location = new System.Drawing.Point(0, 112);
            this.topCaptionFEitem.Name = "topCaptionFEitem";
            this.topCaptionFEitem.Size = new System.Drawing.Size(282, 27);
            resources.ApplyResources(this.topCaptionFEitem, "topCaptionFEitem");
            this.topCaptionFEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.topCaptionFEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // topCaptionAligmentCBitem
            // 
            this.topCaptionAligmentCBitem.Control = this.topCaptionAligmentCB;
            this.topCaptionAligmentCBitem.Location = new System.Drawing.Point(0, 58);
            this.topCaptionAligmentCBitem.Name = "topCaptionAligmentCBitem";
            this.topCaptionAligmentCBitem.Size = new System.Drawing.Size(282, 27);
            resources.ApplyResources(this.topCaptionAligmentCBitem, "topCaptionAligmentCBitem");
            this.topCaptionAligmentCBitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // topCaptionTEitem
            // 
            this.topCaptionTEitem.Control = this.textEditCompanyName;
            this.topCaptionTEitem.Location = new System.Drawing.Point(0, 31);
            this.topCaptionTEitem.Name = "topCaptionTEitem";
            this.topCaptionTEitem.Size = new System.Drawing.Size(282, 27);
            resources.ApplyResources(this.topCaptionTEitem, "topCaptionTEitem");
            this.topCaptionTEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // barCogeGCitem
            // 
            this.barCogeGCitem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.showTextCEitem,
            this.codeTextVertAlignmentCBitem,
            this.backColorEitem,
            this.codeTextHorzAlignmentCBitem,
            this.foreColorEitem,
            this.codeTextFEitem,
            this.angleSEitem,
            this.layoutControlItem9});
            this.barCogeGCitem.Location = new System.Drawing.Point(848, 431);
            this.barCogeGCitem.Name = "barCogeGCitem";
            this.barCogeGCitem.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.barCogeGCitem.Size = new System.Drawing.Size(480, 263);
            resources.ApplyResources(this.barCogeGCitem, "barCogeGCitem");
            // 
            // showTextCEitem
            // 
            this.showTextCEitem.Control = this.checkEditBarcodeNo;
            this.showTextCEitem.Location = new System.Drawing.Point(0, 0);
            this.showTextCEitem.Name = "showTextCEitem";
            this.showTextCEitem.Size = new System.Drawing.Size(454, 31);
            resources.ApplyResources(this.showTextCEitem, "showTextCEitem");
            this.showTextCEitem.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.showTextCEitem.TextSize = new System.Drawing.Size(0, 0);
            this.showTextCEitem.TextVisible = false;
            // 
            // codeTextVertAlignmentCBitem
            // 
            this.codeTextVertAlignmentCBitem.Control = this.codeTextVertAlignmentCB;
            this.codeTextVertAlignmentCBitem.Location = new System.Drawing.Point(0, 58);
            this.codeTextVertAlignmentCBitem.Name = "codeTextVertAlignmentCBitem";
            this.codeTextVertAlignmentCBitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.codeTextVertAlignmentCBitem, "codeTextVertAlignmentCBitem");
            this.codeTextVertAlignmentCBitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.codeTextVertAlignmentCBitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // backColorEitem
            // 
            this.backColorEitem.Control = this.backColorE;
            this.backColorEitem.Location = new System.Drawing.Point(0, 194);
            this.backColorEitem.Name = "backColorEitem";
            this.backColorEitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.backColorEitem, "backColorEitem");
            this.backColorEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.backColorEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // codeTextHorzAlignmentCBitem
            // 
            this.codeTextHorzAlignmentCBitem.Control = this.codeTextHorzAlignmentCB;
            this.codeTextHorzAlignmentCBitem.Location = new System.Drawing.Point(0, 85);
            this.codeTextHorzAlignmentCBitem.Name = "codeTextHorzAlignmentCBitem";
            this.codeTextHorzAlignmentCBitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.codeTextHorzAlignmentCBitem, "codeTextHorzAlignmentCBitem");
            this.codeTextHorzAlignmentCBitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.codeTextHorzAlignmentCBitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // foreColorEitem
            // 
            this.foreColorEitem.Control = this.foreColorE;
            this.foreColorEitem.Location = new System.Drawing.Point(0, 167);
            this.foreColorEitem.Name = "foreColorEitem";
            this.foreColorEitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.foreColorEitem, "foreColorEitem");
            this.foreColorEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.foreColorEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // codeTextFEitem
            // 
            this.codeTextFEitem.Control = this.codeTextFE;
            this.codeTextFEitem.Location = new System.Drawing.Point(0, 112);
            this.codeTextFEitem.Name = "codeTextFEitem";
            this.codeTextFEitem.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.codeTextFEitem, "codeTextFEitem");
            this.codeTextFEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.codeTextFEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // angleSEitem
            // 
            this.angleSEitem.Control = this.angleSE;
            this.angleSEitem.Location = new System.Drawing.Point(0, 139);
            this.angleSEitem.Name = "angleSEitem";
            this.angleSEitem.Size = new System.Drawing.Size(454, 28);
            resources.ApplyResources(this.angleSEitem, "angleSEitem");
            this.angleSEitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.angleSEitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.comboBoxEditSymbology;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(454, 27);
            resources.ApplyResources(this.layoutControlItem9, "layoutControlItem9");
            this.layoutControlItem9.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.textEditHeightitem,
            this.textEditWidthitem,
            this.layoutControlItemReportWidth});
            this.layoutControlGroup2.Location = new System.Drawing.Point(848, 305);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(480, 126);
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            // 
            // textEditHeightitem
            // 
            this.textEditHeightitem.Control = this.textEditHeight;
            this.textEditHeightitem.Location = new System.Drawing.Point(0, 28);
            this.textEditHeightitem.Name = "textEditHeightitem";
            this.textEditHeightitem.Size = new System.Drawing.Size(454, 28);
            resources.ApplyResources(this.textEditHeightitem, "textEditHeightitem");
            this.textEditHeightitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.textEditHeightitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // textEditWidthitem
            // 
            this.textEditWidthitem.Control = this.textEditWidth;
            this.textEditWidthitem.Location = new System.Drawing.Point(0, 0);
            this.textEditWidthitem.Name = "textEditWidthitem";
            this.textEditWidthitem.Size = new System.Drawing.Size(454, 28);
            resources.ApplyResources(this.textEditWidthitem, "textEditWidthitem");
            this.textEditWidthitem.TextLocation = DevExpress.Utils.Locations.Right;
            this.textEditWidthitem.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItemReportWidth
            // 
            this.layoutControlItemReportWidth.Control = this.textEditPageWidth;
            this.layoutControlItemReportWidth.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItemReportWidth.Name = "layoutControlItemReportWidth";
            this.layoutControlItemReportWidth.Size = new System.Drawing.Size(454, 28);
            resources.ApplyResources(this.layoutControlItemReportWidth, "layoutControlItemReportWidth");
            this.layoutControlItemReportWidth.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnDefaultSettings;
            this.layoutControlItem8.Location = new System.Drawing.Point(848, 742);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(249, 40);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(480, 40);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // itemForPrdExpirateAcc1
            // 
            this.itemForPrdExpirateAcc1.Control = this.textEditPrinterBarcod;
            resources.ApplyResources(this.itemForPrdExpirateAcc1, "itemForPrdExpirateAcc1");
            this.itemForPrdExpirateAcc1.Location = new System.Drawing.Point(308, 694);
            this.itemForPrdExpirateAcc1.MinSize = new System.Drawing.Size(255, 27);
            this.itemForPrdExpirateAcc1.Name = "itemForPrdExpirateAcc1";
            this.itemForPrdExpirateAcc1.Size = new System.Drawing.Size(540, 51);
            this.itemForPrdExpirateAcc1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itemForPrdExpirateAcc1.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.panel2;
            resources.ApplyResources(this.layoutControlItem15, "layoutControlItem15");
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 181);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(848, 256);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(177, 23);
            this.layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.spinEdit1;
            this.layoutControlItem16.Location = new System.Drawing.Point(308, 745);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(540, 37);
            resources.ApplyResources(this.layoutControlItem16, "layoutControlItem16");
            this.layoutControlItem16.TextSize = new System.Drawing.Size(177, 23);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrintPreview;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 694);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(51, 1);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(308, 51);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnPrintBarocde;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 745);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(91, 37);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(308, 37);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnUserSettings;
            this.layoutControlItem10.Location = new System.Drawing.Point(848, 694);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(0, 48);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(230, 48);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(252, 48);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(560, 241);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(301, 25);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            resources.ApplyResources(this.ribbonPage2, "ribbonPage2");
            // 
            // clsProductBarcodeListBindingSource
            // 
            this.clsProductBarcodeListBindingSource.DataSource = typeof(PosFinalCost.ClsProductBarcodeList);
            // 
            // formBarcode
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BarCodeVisualizationlayoutControl1ConvertedLayout);
            this.Controls.Add(this.ribbonControl1);
            this.KeyPreview = true;
            this.Name = "formBarcode";
            this.Ribbon = this.ribbonControl1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeVisualizationlayoutControl1ConvertedLayout)).EndInit();
            this.BarCodeVisualizationlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSymbology.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPrdName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionForeCE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionFE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionForeCE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionFE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBarcodeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreColorE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextFE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrdPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExpireDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPrdPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditExpireDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditExpireDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarocdeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPageWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOtherInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSrchBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrdMsur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSaleTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrinterBarcod.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionGCitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionForeCEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionFEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionTEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCBitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionCEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdititem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnSaveUserSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPrdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCodeTextitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCotrolItemSrchBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPrdMsur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOtherInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionGCitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionCEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionForeCEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionFEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCBitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionTEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCogeGCitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showTextCEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCBitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCBitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreColorEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextFEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSEitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeightitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidthitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReportWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPrdExpirateAcc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsProductBarcodeListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private ComboBoxEdit bottomCaptionAligmentCB;
        private ComboBoxEdit topCaptionAligmentCB;
        private ComboBoxEdit codeTextHorzAlignmentCB;
        private ComboBoxEdit codeTextVertAlignmentCB;
        private ColorEdit topCaptionForeCE;
        private ColorEdit bottomCaptionForeCE;
        private FontEdit topCaptionFE;
        private FontEdit bottomCaptionFE;
        private DevExpress.XtraLayout.LayoutControl BarCodeVisualizationlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem pictureEdititem;
        private DevExpress.XtraLayout.LayoutControlGroup bottomCaptionGCitem;
        private DevExpress.XtraLayout.LayoutControlItem bottomCaptionCEitem;
        private DevExpress.XtraLayout.LayoutControlItem bottomCaptionForeCEitem;
        private DevExpress.XtraLayout.LayoutControlItem bottomCaptionFEitem;
        private DevExpress.XtraLayout.LayoutControlItem bottomCaptionTEitem;
        private DevExpress.XtraLayout.LayoutControlItem bottomCaptionAligmentCBitem;
        private DevExpress.XtraLayout.LayoutControlGroup topCaptionGCitem;
        private DevExpress.XtraLayout.LayoutControlItem topCaptionCEitem;
        private DevExpress.XtraLayout.LayoutControlItem topCaptionForeCEitem;
        private DevExpress.XtraLayout.LayoutControlItem topCaptionFEitem;
        private DevExpress.XtraLayout.LayoutControlItem topCaptionAligmentCBitem;
        private DevExpress.XtraLayout.LayoutControlItem topCaptionTEitem;
        private DevExpress.XtraLayout.LayoutControlGroup barCogeGCitem;
        private DevExpress.XtraLayout.LayoutControlItem showTextCEitem;
        private DevExpress.XtraLayout.LayoutControlItem textEditHeightitem;
        private DevExpress.XtraLayout.LayoutControlItem textEditWidthitem;
        private DevExpress.XtraLayout.LayoutControlItem codeTextVertAlignmentCBitem;
        private DevExpress.XtraLayout.LayoutControlItem backColorEitem;
        private DevExpress.XtraLayout.LayoutControlItem codeTextHorzAlignmentCBitem;
        private DevExpress.XtraLayout.LayoutControlItem foreColorEitem;
        private DevExpress.XtraLayout.LayoutControlItem codeTextFEitem;
        private DevExpress.XtraLayout.LayoutControlItem angleSEitem;
        private DevExpress.XtraLayout.LayoutControlItem barCodeTextitem;
        private LabelControl errorText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private SimpleButton btnPrintPreview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private TextEdit textEditPrdPrice;
        private CheckEdit checkEditExpireDate;
        private CheckEdit checkEditPrdPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DateEdit textEditExpireDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private SpinEdit textEditWidth;
        private SpinEdit textEditHeight;
        private TextEdit textEditBarocdeNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private ComboBoxEdit comboBoxEditSymbology;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private SimpleButton btnDefaultSettings;
        private SimpleButton btnUserSettings;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraGrid.Columns.GridColumn colproductName;
        private SimpleButton btnSaveUserSettings;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnSaveUserSettings;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private SpinEdit textEditPageWidth;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemReportWidth;
        private SimpleButton btnPrintBarocde;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private TextEdit textEditOtherInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOtherInfo;
        private TextEdit textEditSrchBarcode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPrdInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutCotrolItemSrchBarcode;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPrdMsur;
        private LookUpEdit textEditPrdMsur;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private System.Windows.Forms.BindingSource clsProductBarcodeListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private CheckEdit checkEditSaleTax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        public SearchLookUpEdit textEditProduct;
        private LookUpEdit textEditPrinterBarcod;
        private DevExpress.XtraLayout.LayoutControlItem itemForPrdExpirateAcc1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picbarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
    }
}
