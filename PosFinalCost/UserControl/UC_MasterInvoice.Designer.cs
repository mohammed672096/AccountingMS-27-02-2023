namespace PosFinalCost.Forms
{
    partial class UC_MasterInvoice
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MasterInvoice));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupMsur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPriceSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyChng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDscntAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAfterDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpaidCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingNavigator11 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStTxtInvoNo = new System.Windows.Forms.ToolStripTextBox();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPdf = new System.Windows.Forms.ToolStripButton();
            this.btnPrintXsl = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).BeginInit();
            this.bindingNavigator11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.NavajoWhite;
            this.gridView1.Appearance.Row.BackColor2 = ((System.Drawing.Color)(resources.GetObject("gridView1.Appearance.Row.BackColor2")));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupPrdName,
            this.gridColumn2,
            this.colsupMsur,
            this.colsupQuanMain,
            this.colsupPrice,
            this.colsupTaxPercent,
            this.colsupTaxPriceSub,
            this.gridColumn1,
            this.colsupCredit,
            this.gridColumn3});
            this.gridView1.DetailHeight = 485;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colsupPrdName
            // 
            resources.ApplyResources(this.colsupPrdName, "colsupPrdName");
            this.colsupPrdName.FieldName = "PrdId";
            this.colsupPrdName.MinWidth = 26;
            this.colsupPrdName.Name = "colsupPrdName";
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "Desc";
            this.gridColumn2.MinWidth = 26;
            this.gridColumn2.Name = "gridColumn2";
            // 
            // colsupMsur
            // 
            this.colsupMsur.AppearanceCell.Options.UseTextOptions = true;
            this.colsupMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupMsur, "colsupMsur");
            this.colsupMsur.FieldName = "Msur";
            this.colsupMsur.MinWidth = 26;
            this.colsupMsur.Name = "colsupMsur";
            // 
            // colsupQuanMain
            // 
            this.colsupQuanMain.AppearanceCell.Options.UseTextOptions = true;
            this.colsupQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupQuanMain, "colsupQuanMain");
            this.colsupQuanMain.FieldName = "QuanMain";
            this.colsupQuanMain.MinWidth = 26;
            this.colsupQuanMain.Name = "colsupQuanMain";
            // 
            // colsupPrice
            // 
            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupPrice, "colsupPrice");
            this.colsupPrice.DisplayFormat.FormatString = "n2";
            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupPrice.FieldName = "SalePrice";
            this.colsupPrice.MinWidth = 26;
            this.colsupPrice.Name = "colsupPrice";
            // 
            // colsupTaxPercent
            // 
            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupTaxPercent, "colsupTaxPercent");
            this.colsupTaxPercent.FieldName = "TaxPercent";
            this.colsupTaxPercent.MinWidth = 26;
            this.colsupTaxPercent.Name = "colsupTaxPercent";
            // 
            // colsupTaxPriceSub
            // 
            this.colsupTaxPriceSub.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPriceSub.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupTaxPriceSub, "colsupTaxPriceSub");
            this.colsupTaxPriceSub.DisplayFormat.FormatString = "n2";
            this.colsupTaxPriceSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTaxPriceSub.FieldName = "TaxPrice";
            this.colsupTaxPriceSub.MinWidth = 26;
            this.colsupTaxPriceSub.Name = "colsupTaxPriceSub";
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "DscntAmount";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // colsupCredit
            // 
            this.colsupCredit.AppearanceCell.Options.UseTextOptions = true;
            this.colsupCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colsupCredit, "colsupCredit");
            this.colsupCredit.DisplayFormat.FormatString = "n2";
            this.colsupCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupCredit.FieldName = "Total";
            this.colsupCredit.MinWidth = 26;
            this.colsupCredit.Name = "colsupCredit";
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "Date";
            this.gridColumn3.MinWidth = 26;
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.entityInstantFeedbackSource1;
            this.gridControl.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl.EmbeddedNavigator.Margin")));
            gridLevelNode2.LevelTemplate = this.gridView1;
            gridLevelNode2.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            resources.ApplyResources(this.gridControl, "gridControl");
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // entityInstantFeedbackSource1
            // 
            this.entityInstantFeedbackSource1.DefaultSorting = "Date DESC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(PosFinalCost.SupplyMain);
            this.entityInstantFeedbackSource1.KeyExpression = "ID";
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView.Appearance.HeaderPanel.Font")));
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.Row.Options.UseTextOptions = true;
            this.gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colID,
            this.colNo,
            this.colAccName,
            this.colRefNo,
            this.colDesc,
            this.colTotal,
            this.colDate,
            this.colUserId,
            this.colIsCash,
            this.colTotalFrgn,
            this.colTaxPrice,
            this.colCurrency,
            this.colCurrencyChng,
            this.colStrId,
            this.colDscntAmount,
            this.colNet,
            this.colTotalAfterDiscount,
            this.colIndex,
            this.colBoxId,
            this.colBankId,
            this.colpaidCash,
            this.colBankAmount,
            this.colCustId});
            this.gridView.DetailHeight = 485;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            // 
            // colStatus
            // 
            resources.ApplyResources(this.colStatus, "colStatus");
            this.colStatus.FieldName = "Status";
            this.colStatus.MinWidth = 26;
            this.colStatus.Name = "colStatus";
            // 
            // colID
            // 
            resources.ApplyResources(this.colID, "colID");
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 26;
            this.colID.Name = "colID";
            // 
            // colNo
            // 
            resources.ApplyResources(this.colNo, "colNo");
            this.colNo.FieldName = "No";
            this.colNo.MinWidth = 26;
            this.colNo.Name = "colNo";
            // 
            // colAccName
            // 
            resources.ApplyResources(this.colAccName, "colAccName");
            this.colAccName.FieldName = "AccName";
            this.colAccName.MinWidth = 26;
            this.colAccName.Name = "colAccName";
            this.colAccName.UnboundDataType = typeof(string);
            // 
            // colRefNo
            // 
            resources.ApplyResources(this.colRefNo, "colRefNo");
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.MinWidth = 26;
            this.colRefNo.Name = "colRefNo";
            // 
            // colDesc
            // 
            resources.ApplyResources(this.colDesc, "colDesc");
            this.colDesc.FieldName = "Desc";
            this.colDesc.MinWidth = 26;
            this.colDesc.Name = "colDesc";
            // 
            // colTotal
            // 
            resources.ApplyResources(this.colTotal, "colTotal");
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.MinWidth = 26;
            this.colTotal.Name = "colTotal";
            // 
            // colDate
            // 
            resources.ApplyResources(this.colDate, "colDate");
            this.colDate.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 160;
            this.colDate.Name = "colDate";
            // 
            // colUserId
            // 
            this.colUserId.FieldName = "UserId";
            this.colUserId.MinWidth = 26;
            this.colUserId.Name = "colUserId";
            resources.ApplyResources(this.colUserId, "colUserId");
            // 
            // colIsCash
            // 
            resources.ApplyResources(this.colIsCash, "colIsCash");
            this.colIsCash.FieldName = "IsCash";
            this.colIsCash.MinWidth = 26;
            this.colIsCash.Name = "colIsCash";
            // 
            // colTotalFrgn
            // 
            resources.ApplyResources(this.colTotalFrgn, "colTotalFrgn");
            this.colTotalFrgn.DisplayFormat.FormatString = "n2";
            this.colTotalFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFrgn.FieldName = "TotalFrgn";
            this.colTotalFrgn.MinWidth = 26;
            this.colTotalFrgn.Name = "colTotalFrgn";
            // 
            // colTaxPrice
            // 
            resources.ApplyResources(this.colTaxPrice, "colTaxPrice");
            this.colTaxPrice.DisplayFormat.FormatString = "n2";
            this.colTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPrice.FieldName = "TaxPrice";
            this.colTaxPrice.MinWidth = 26;
            this.colTaxPrice.Name = "colTaxPrice";
            // 
            // colCurrency
            // 
            resources.ApplyResources(this.colCurrency, "colCurrency");
            this.colCurrency.FieldName = "Currency";
            this.colCurrency.MinWidth = 26;
            this.colCurrency.Name = "colCurrency";
            // 
            // colCurrencyChng
            // 
            resources.ApplyResources(this.colCurrencyChng, "colCurrencyChng");
            this.colCurrencyChng.FieldName = "CurrencyChng";
            this.colCurrencyChng.MinWidth = 26;
            this.colCurrencyChng.Name = "colCurrencyChng";
            // 
            // colStrId
            // 
            resources.ApplyResources(this.colStrId, "colStrId");
            this.colStrId.FieldName = "StrId";
            this.colStrId.MinWidth = 26;
            this.colStrId.Name = "colStrId";
            // 
            // colDscntAmount
            // 
            resources.ApplyResources(this.colDscntAmount, "colDscntAmount");
            this.colDscntAmount.DisplayFormat.FormatString = "n2";
            this.colDscntAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDscntAmount.FieldName = "DscntAmount";
            this.colDscntAmount.MinWidth = 23;
            this.colDscntAmount.Name = "colDscntAmount";
            // 
            // colNet
            // 
            resources.ApplyResources(this.colNet, "colNet");
            this.colNet.DisplayFormat.FormatString = "n2";
            this.colNet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNet.FieldName = "Net";
            this.colNet.MinWidth = 23;
            this.colNet.Name = "colNet";
            // 
            // colTotalAfterDiscount
            // 
            resources.ApplyResources(this.colTotalAfterDiscount, "colTotalAfterDiscount");
            this.colTotalAfterDiscount.DisplayFormat.FormatString = "n2";
            this.colTotalAfterDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAfterDiscount.FieldName = "TotalAfterDiscount";
            this.colTotalAfterDiscount.MinWidth = 25;
            this.colTotalAfterDiscount.Name = "colTotalAfterDiscount";
            // 
            // colIndex
            // 
            resources.ApplyResources(this.colIndex, "colIndex");
            this.colIndex.FieldName = "Index";
            this.colIndex.MinWidth = 25;
            this.colIndex.Name = "colIndex";
            this.colIndex.UnboundDataType = typeof(int);
            // 
            // colBoxId
            // 
            this.colBoxId.FieldName = "BoxId";
            this.colBoxId.MinWidth = 25;
            this.colBoxId.Name = "colBoxId";
            resources.ApplyResources(this.colBoxId, "colBoxId");
            // 
            // colBankId
            // 
            this.colBankId.FieldName = "BankId";
            this.colBankId.Name = "colBankId";
            resources.ApplyResources(this.colBankId, "colBankId");
            // 
            // colpaidCash
            // 
            this.colpaidCash.FieldName = "paidCash";
            this.colpaidCash.MinWidth = 25;
            this.colpaidCash.Name = "colpaidCash";
            resources.ApplyResources(this.colpaidCash, "colpaidCash");
            // 
            // colBankAmount
            // 
            this.colBankAmount.FieldName = "BankAmount";
            this.colBankAmount.MinWidth = 25;
            this.colBankAmount.Name = "colBankAmount";
            resources.ApplyResources(this.colBankAmount, "colBankAmount");
            // 
            // colCustId
            // 
            this.colCustId.FieldName = "CustId";
            this.colCustId.MinWidth = 25;
            this.colCustId.Name = "colCustId";
            resources.ApplyResources(this.colCustId, "colCustId");
            // 
            // bindingNavigator11
            // 
            this.bindingNavigator11.AddNewItem = null;
            this.bindingNavigator11.CountItem = null;
            this.bindingNavigator11.DeleteItem = null;
            this.bindingNavigator11.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator21,
            this.btnAddNew,
            this.btnUpdate,
            this.btnRefresh,
            this.toolStripLabel1,
            this.toolStTxtInvoNo,
            this.btnPrint,
            this.btnPrintPdf,
            this.btnPrintXsl,
            this.btnDelete,
            this.btnClose});
            resources.ApplyResources(this.bindingNavigator11, "bindingNavigator11");
            this.bindingNavigator11.MoveFirstItem = null;
            this.bindingNavigator11.MoveLastItem = null;
            this.bindingNavigator11.MoveNextItem = null;
            this.bindingNavigator11.MovePreviousItem = null;
            this.bindingNavigator11.Name = "bindingNavigator11";
            this.bindingNavigator11.PositionItem = null;
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            resources.ApplyResources(this.toolStripSeparator21, "toolStripSeparator21");
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNew.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnAddNew, "btnAddNew");
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddNew.Name = "btnAddNew";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // toolStTxtInvoNo
            // 
            resources.ApplyResources(this.toolStTxtInvoNo, "toolStTxtInvoNo");
            this.toolStTxtInvoNo.Name = "toolStTxtInvoNo";
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            // 
            // btnPrintPdf
            // 
            this.btnPrintPdf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintPdf.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnPrintPdf, "btnPrintPdf");
            this.btnPrintPdf.Name = "btnPrintPdf";
            // 
            // btnPrintXsl
            // 
            this.btnPrintXsl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintXsl.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnPrintXsl, "btnPrintXsl");
            this.btnPrintXsl.Name = "btnPrintXsl";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.radioGroup1);
            this.layoutControl1.Controls.Add(this.gridControl);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            // 
            // radioGroup1
            // 
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup1.Properties.Items"))), resources.GetString("radioGroup1.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup1.Properties.Items2"))), resources.GetString("radioGroup1.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup1.Properties.Items4"))), resources.GetString("radioGroup1.Properties.Items5"))});
            this.radioGroup1.StyleController = this.layoutControl1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1419, 760);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1399, 691);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.radioGroup1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1399, 49);
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 18);
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // UC_MasterInvoice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.bindingNavigator11);
            this.Name = "UC_MasterInvoice";
            this.Load += new System.EventHandler(this.UC_Master_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).EndInit();
            this.bindingNavigator11.ResumeLayout(false);
            this.bindingNavigator11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingNavigator bindingNavigator11;
        public System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        public System.Windows.Forms.ToolStripButton btnUpdate;
        public System.Windows.Forms.ToolStripButton btnPrint;
        public System.Windows.Forms.ToolStripButton btnDelete;
        public System.Windows.Forms.ToolStripButton btnRefresh;
        public System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripTextBox toolStTxtInvoNo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colsupMsur;
        private DevExpress.XtraGrid.Columns.GridColumn colsupQuanMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPriceSub;
        private DevExpress.XtraGrid.Columns.GridColumn colsupCredit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCash;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFrgn;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyChng;
        private DevExpress.XtraGrid.Columns.GridColumn colStrId;
        private DevExpress.XtraGrid.Columns.GridColumn colDscntAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNet;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAfterDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxId;
        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
        private DevExpress.XtraGrid.Columns.GridColumn colpaidCash;
        private DevExpress.XtraGrid.Columns.GridColumn colBankAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCustId;
        public System.Windows.Forms.ToolStripButton btnPrintPdf;
        public System.Windows.Forms.ToolStripButton btnPrintXsl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

//namespace PosFinalCost.Forms
//{
//    partial class UC_MasterInvoice
//    {
//        /// <summary> 
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        /// <summary> 
//        /// Required method for Designer support - do not modify 
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MasterInvoice));
//            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
//            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
//            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupMsur = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupTaxPriceSub = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colsupCredit = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.gridControl = new DevExpress.XtraGrid.GridControl();
//            this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
//            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
//            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colAccName = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colIsCash = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colTotalFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colCurrencyChng = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colStrId = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colDscntAmount = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colNet = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colTotalAfterDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colBoxId = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colBankId = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colpaidCash = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colBankAmount = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.colCustId = new DevExpress.XtraGrid.Columns.GridColumn();
//            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
//            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
//            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
//            this.btnPrint = new System.Windows.Forms.ToolStripButton();
//            this.btnDelete = new System.Windows.Forms.ToolStripButton();
//            this.btnClose = new System.Windows.Forms.ToolStripButton();
//            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // gridView1
//            // 
//            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
//            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Navy;
//            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
//            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
//            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.NavajoWhite;
//            this.gridView1.Appearance.Row.BackColor2 = ((System.Drawing.Color)(resources.GetObject("gridView1.Appearance.Row.BackColor2")));
//            this.gridView1.Appearance.Row.Options.UseBackColor = true;
//            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
//            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
//            this.colsupPrdName,
//            this.gridColumn2,
//            this.colsupMsur,
//            this.colsupQuanMain,
//            this.colsupPrice,
//            this.colsupTaxPercent,
//            this.colsupTaxPriceSub,
//            this.gridColumn1,
//            this.colsupCredit,
//            this.gridColumn3});
//            this.gridView1.DetailHeight = 485;
//            this.gridView1.GridControl = this.gridControl;
//            this.gridView1.Name = "gridView1";
//            this.gridView1.OptionsBehavior.Editable = false;
//            this.gridView1.OptionsView.ShowGroupPanel = false;
//            // 
//            // colsupPrdName
//            // 
//            resources.ApplyResources(this.colsupPrdName, "colsupPrdName");
//            this.colsupPrdName.FieldName = "PrdId";
//            this.colsupPrdName.MinWidth = 26;
//            this.colsupPrdName.Name = "colsupPrdName";
//            // 
//            // gridColumn2
//            // 
//            resources.ApplyResources(this.gridColumn2, "gridColumn2");
//            this.gridColumn2.FieldName = "Desc";
//            this.gridColumn2.MinWidth = 26;
//            this.gridColumn2.Name = "gridColumn2";
//            // 
//            // colsupMsur
//            // 
//            this.colsupMsur.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupMsur, "colsupMsur");
//            this.colsupMsur.FieldName = "Msur";
//            this.colsupMsur.MinWidth = 26;
//            this.colsupMsur.Name = "colsupMsur";
//            // 
//            // colsupQuanMain
//            // 
//            this.colsupQuanMain.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupQuanMain, "colsupQuanMain");
//            this.colsupQuanMain.FieldName = "QuanMain";
//            this.colsupQuanMain.MinWidth = 26;
//            this.colsupQuanMain.Name = "colsupQuanMain";
//            // 
//            // colsupPrice
//            // 
//            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupPrice, "colsupPrice");
//            this.colsupPrice.DisplayFormat.FormatString = "n2";
//            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colsupPrice.FieldName = "SalePrice";
//            this.colsupPrice.MinWidth = 26;
//            this.colsupPrice.Name = "colsupPrice";
//            // 
//            // colsupTaxPercent
//            // 
//            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupTaxPercent, "colsupTaxPercent");
//            this.colsupTaxPercent.FieldName = "TaxPercent";
//            this.colsupTaxPercent.MinWidth = 26;
//            this.colsupTaxPercent.Name = "colsupTaxPercent";
//            // 
//            // colsupTaxPriceSub
//            // 
//            this.colsupTaxPriceSub.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupTaxPriceSub.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupTaxPriceSub, "colsupTaxPriceSub");
//            this.colsupTaxPriceSub.DisplayFormat.FormatString = "n2";
//            this.colsupTaxPriceSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colsupTaxPriceSub.FieldName = "TaxPrice";
//            this.colsupTaxPriceSub.MinWidth = 26;
//            this.colsupTaxPriceSub.Name = "colsupTaxPriceSub";
//            // 
//            // gridColumn1
//            // 
//            resources.ApplyResources(this.gridColumn1, "gridColumn1");
//            this.gridColumn1.DisplayFormat.FormatString = "n2";
//            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.gridColumn1.FieldName = "DscntAmount";
//            this.gridColumn1.MinWidth = 25;
//            this.gridColumn1.Name = "gridColumn1";
//            // 
//            // colsupCredit
//            // 
//            this.colsupCredit.AppearanceCell.Options.UseTextOptions = true;
//            this.colsupCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            resources.ApplyResources(this.colsupCredit, "colsupCredit");
//            this.colsupCredit.DisplayFormat.FormatString = "n2";
//            this.colsupCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colsupCredit.FieldName = "Total";
//            this.colsupCredit.MinWidth = 26;
//            this.colsupCredit.Name = "colsupCredit";
//            // 
//            // gridColumn3
//            // 
//            resources.ApplyResources(this.gridColumn3, "gridColumn3");
//            this.gridColumn3.FieldName = "Date";
//            this.gridColumn3.MinWidth = 26;
//            this.gridColumn3.Name = "gridColumn3";
//            // 
//            // gridControl
//            // 
//            this.gridControl.DataSource = this.entityInstantFeedbackSource1;
//            resources.ApplyResources(this.gridControl, "gridControl");
//            this.gridControl.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl.EmbeddedNavigator.Margin")));
//            gridLevelNode1.LevelTemplate = this.gridView1;
//            gridLevelNode1.RelationName = "Level1";
//            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
//            gridLevelNode1});
//            this.gridControl.MainView = this.gridView;
//            this.gridControl.Name = "gridControl";
//            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
//            this.gridView,
//            this.gridView1});
//            // 
//            // entityInstantFeedbackSource1
//            // 
//            this.entityInstantFeedbackSource1.DefaultSorting = "Date DESC";
//            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(PosFinalCost.SupplyMain);
//            this.entityInstantFeedbackSource1.KeyExpression = "ID";
//            // 
//            // gridView
//            // 
//            this.gridView.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView.Appearance.HeaderPanel.Font")));
//            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
//            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
//            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
//            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
//            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            this.gridView.Appearance.Row.Options.UseTextOptions = true;
//            this.gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
//            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
//            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
//            this.colStatus,
//            this.colID,
//            this.colNo,
//            this.colAccName,
//            this.colRefNo,
//            this.colDesc,
//            this.colTotal,
//            this.colDate,
//            this.colUserId,
//            this.colIsCash,
//            this.colTotalFrgn,
//            this.colTaxPrice,
//            this.colCurrency,
//            this.colCurrencyChng,
//            this.colStrId,
//            this.colDscntAmount,
//            this.colNet,
//            this.colTotalAfterDiscount,
//            this.colIndex,
//            this.colBoxId,
//            this.colBankId,
//            this.colpaidCash,
//            this.colBankAmount,
//            this.colCustId});
//            this.gridView.DetailHeight = 485;
//            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
//            this.gridView.GridControl = this.gridControl;
//            this.gridView.Name = "gridView";
//            this.gridView.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
//            this.gridView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
//            this.gridView.OptionsBehavior.Editable = false;
//            this.gridView.OptionsBehavior.ReadOnly = true;
//            this.gridView.OptionsDetail.ShowDetailTabs = false;
//            this.gridView.OptionsFind.AlwaysVisible = true;
//            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
//            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
//            this.gridView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
//            this.gridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
//            this.gridView.OptionsView.ShowFooter = true;
//            this.gridView.RowHeight = 32;
//            // 
//            // colStatus
//            // 
//            resources.ApplyResources(this.colStatus, "colStatus");
//            this.colStatus.FieldName = "Status";
//            this.colStatus.MinWidth = 26;
//            this.colStatus.Name = "colStatus";
//            // 
//            // colID
//            // 
//            resources.ApplyResources(this.colID, "colID");
//            this.colID.FieldName = "ID";
//            this.colID.MinWidth = 26;
//            this.colID.Name = "colID";
//            // 
//            // colNo
//            // 
//            resources.ApplyResources(this.colNo, "colNo");
//            this.colNo.FieldName = "No";
//            this.colNo.MinWidth = 26;
//            this.colNo.Name = "colNo";
//            // 
//            // colAccName
//            // 
//            resources.ApplyResources(this.colAccName, "colAccName");
//            this.colAccName.FieldName = "AccName";
//            this.colAccName.MinWidth = 26;
//            this.colAccName.Name = "colAccName";
//            this.colAccName.UnboundDataType = typeof(string);
//            // 
//            // colRefNo
//            // 
//            resources.ApplyResources(this.colRefNo, "colRefNo");
//            this.colRefNo.FieldName = "RefNo";
//            this.colRefNo.MinWidth = 26;
//            this.colRefNo.Name = "colRefNo";
//            // 
//            // colDesc
//            // 
//            resources.ApplyResources(this.colDesc, "colDesc");
//            this.colDesc.FieldName = "Desc";
//            this.colDesc.MinWidth = 26;
//            this.colDesc.Name = "colDesc";
//            // 
//            // colTotal
//            // 
//            resources.ApplyResources(this.colTotal, "colTotal");
//            this.colTotal.DisplayFormat.FormatString = "n2";
//            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colTotal.FieldName = "Total";
//            this.colTotal.MinWidth = 26;
//            this.colTotal.Name = "colTotal";
//            // 
//            // colDate
//            // 
//            resources.ApplyResources(this.colDate, "colDate");
//            this.colDate.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
//            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
//            this.colDate.FieldName = "Date";
//            this.colDate.MinWidth = 160;
//            this.colDate.Name = "colDate";
//            // 
//            // colUserId
//            // 
//            this.colUserId.FieldName = "UserId";
//            this.colUserId.MinWidth = 26;
//            this.colUserId.Name = "colUserId";
//            resources.ApplyResources(this.colUserId, "colUserId");
//            // 
//            // colIsCash
//            // 
//            resources.ApplyResources(this.colIsCash, "colIsCash");
//            this.colIsCash.FieldName = "IsCash";
//            this.colIsCash.MinWidth = 26;
//            this.colIsCash.Name = "colIsCash";
//            // 
//            // colTotalFrgn
//            // 
//            resources.ApplyResources(this.colTotalFrgn, "colTotalFrgn");
//            this.colTotalFrgn.DisplayFormat.FormatString = "n2";
//            this.colTotalFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colTotalFrgn.FieldName = "TotalFrgn";
//            this.colTotalFrgn.MinWidth = 26;
//            this.colTotalFrgn.Name = "colTotalFrgn";
//            // 
//            // colTaxPrice
//            // 
//            resources.ApplyResources(this.colTaxPrice, "colTaxPrice");
//            this.colTaxPrice.DisplayFormat.FormatString = "n2";
//            this.colTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colTaxPrice.FieldName = "TaxPrice";
//            this.colTaxPrice.MinWidth = 26;
//            this.colTaxPrice.Name = "colTaxPrice";
//            // 
//            // colCurrency
//            // 
//            resources.ApplyResources(this.colCurrency, "colCurrency");
//            this.colCurrency.FieldName = "Currency";
//            this.colCurrency.MinWidth = 26;
//            this.colCurrency.Name = "colCurrency";
//            // 
//            // colCurrencyChng
//            // 
//            resources.ApplyResources(this.colCurrencyChng, "colCurrencyChng");
//            this.colCurrencyChng.FieldName = "CurrencyChng";
//            this.colCurrencyChng.MinWidth = 26;
//            this.colCurrencyChng.Name = "colCurrencyChng";
//            // 
//            // colStrId
//            // 
//            resources.ApplyResources(this.colStrId, "colStrId");
//            this.colStrId.FieldName = "StrId";
//            this.colStrId.MinWidth = 26;
//            this.colStrId.Name = "colStrId";
//            // 
//            // colDscntAmount
//            // 
//            resources.ApplyResources(this.colDscntAmount, "colDscntAmount");
//            this.colDscntAmount.DisplayFormat.FormatString = "n2";
//            this.colDscntAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colDscntAmount.FieldName = "DscntAmount";
//            this.colDscntAmount.MinWidth = 23;
//            this.colDscntAmount.Name = "colDscntAmount";
//            // 
//            // colNet
//            // 
//            resources.ApplyResources(this.colNet, "colNet");
//            this.colNet.DisplayFormat.FormatString = "n2";
//            this.colNet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colNet.FieldName = "Net";
//            this.colNet.MinWidth = 23;
//            this.colNet.Name = "colNet";
//            this.colNet.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
//            // 
//            // colTotalAfterDiscount
//            // 
//            resources.ApplyResources(this.colTotalAfterDiscount, "colTotalAfterDiscount");
//            this.colTotalAfterDiscount.DisplayFormat.FormatString = "n2";
//            this.colTotalAfterDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
//            this.colTotalAfterDiscount.FieldName = "TotalAfterDiscount";
//            this.colTotalAfterDiscount.MinWidth = 25;
//            this.colTotalAfterDiscount.Name = "colTotalAfterDiscount";
//            // 
//            // colIndex
//            // 
//            resources.ApplyResources(this.colIndex, "colIndex");
//            this.colIndex.FieldName = "Index";
//            this.colIndex.MinWidth = 25;
//            this.colIndex.Name = "colIndex";
//            this.colIndex.UnboundDataType = typeof(int);
//            // 
//            // colBoxId
//            // 
//            this.colBoxId.FieldName = "BoxId";
//            this.colBoxId.MinWidth = 25;
//            this.colBoxId.Name = "colBoxId";
//            resources.ApplyResources(this.colBoxId, "colBoxId");
//            // 
//            // colBankId
//            // 
//            this.colBankId.FieldName = "BankId";
//            this.colBankId.Name = "colBankId";
//            resources.ApplyResources(this.colBankId, "colBankId");
//            // 
//            // colpaidCash
//            // 
//            this.colpaidCash.FieldName = "paidCash";
//            this.colpaidCash.MinWidth = 25;
//            this.colpaidCash.Name = "colpaidCash";
//            resources.ApplyResources(this.colpaidCash, "colpaidCash");
//            // 
//            // colBankAmount
//            // 
//            this.colBankAmount.FieldName = "BankAmount";
//            this.colBankAmount.MinWidth = 25;
//            this.colBankAmount.Name = "colBankAmount";
//            resources.ApplyResources(this.colBankAmount, "colBankAmount");
//            // 
//            // colCustId
//            // 
//            this.colCustId.FieldName = "CustId";
//            this.colCustId.MinWidth = 25;
//            this.colCustId.Name = "colCustId";
//            resources.ApplyResources(this.colCustId, "colCustId");
//            // 
//            // btnAddNew
//            // 
//            this.btnAddNew.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.btnAddNew.ForeColor = System.Drawing.Color.Black;
//            this.btnAddNew.Image = global::PosFinalCost.Properties.Resources.add_32x32;
//            resources.ApplyResources(this.btnAddNew, "btnAddNew");
//            this.btnAddNew.Margin = new System.Windows.Forms.Padding(0);
//            this.btnAddNew.Name = "btnAddNew";
//            // 
//            // btnUpdate
//            // 
//            this.btnUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
//            this.btnUpdate.Image = global::PosFinalCost.Properties.Resources.editcontact_32x32;
//            resources.ApplyResources(this.btnUpdate, "btnUpdate");
//            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
//            this.btnUpdate.Name = "btnUpdate";
//            // 
//            // btnRefresh
//            // 
//            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
//            resources.ApplyResources(this.btnRefresh, "btnRefresh");
//            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
//            this.btnRefresh.Name = "btnRefresh";
//            // 
//            // btnPrint
//            // 
//            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
//            resources.ApplyResources(this.btnPrint, "btnPrint");
//            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
//            this.btnPrint.Name = "btnPrint";
//            // 
//            // btnDelete
//            // 
//            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.btnDelete.ForeColor = System.Drawing.Color.Black;
//            resources.ApplyResources(this.btnDelete, "btnDelete");
//            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
//            this.btnDelete.Name = "btnDelete";
//            // 
//            // btnClose
//            // 
//            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.btnClose.ForeColor = System.Drawing.Color.Black;
//            this.btnClose.Image = global::PosFinalCost.Properties.Resources.close_32x32;
//            resources.ApplyResources(this.btnClose, "btnClose");
//            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.btnClose.Name = "btnClose";
//            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
//            // 
//            // UC_MasterInvoice
//            // 
//            resources.ApplyResources(this, "$this");
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.gridControl);
//            this.Name = "UC_MasterInvoice";
//            this.Load += new System.EventHandler(this.UC_Master_Load);
//            this.Controls.SetChildIndex(this.gridControl, 0);
//            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion
//        private DevExpress.XtraGrid.GridControl gridControl;
//        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
//        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupMsur;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupQuanMain;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPercent;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPriceSub;
//        private DevExpress.XtraGrid.Columns.GridColumn colsupCredit;
//        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
//        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
//        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
//        private DevExpress.XtraGrid.Columns.GridColumn colID;
//        private DevExpress.XtraGrid.Columns.GridColumn colNo;
//        private DevExpress.XtraGrid.Columns.GridColumn colAccName;
//        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
//        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
//        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
//        private DevExpress.XtraGrid.Columns.GridColumn colDate;
//        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
//        private DevExpress.XtraGrid.Columns.GridColumn colIsCash;
//        private DevExpress.XtraGrid.Columns.GridColumn colTotalFrgn;
//        private DevExpress.XtraGrid.Columns.GridColumn colTaxPrice;
//        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
//        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyChng;
//        private DevExpress.XtraGrid.Columns.GridColumn colStrId;
//        private DevExpress.XtraGrid.Columns.GridColumn colDscntAmount;
//        private DevExpress.XtraGrid.Columns.GridColumn colNet;
//        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
//        private DevExpress.XtraGrid.Columns.GridColumn colTotalAfterDiscount;
//        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
//        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
//        private DevExpress.XtraGrid.Columns.GridColumn colBoxId;
//        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
//        private DevExpress.XtraGrid.Columns.GridColumn colpaidCash;
//        private DevExpress.XtraGrid.Columns.GridColumn colBankAmount;
//        private DevExpress.XtraGrid.Columns.GridColumn colCustId;
//        public System.Windows.Forms.ToolStripButton btnAddNew;
//        public System.Windows.Forms.ToolStripButton btnUpdate;
//        public System.Windows.Forms.ToolStripButton btnRefresh;
//        public System.Windows.Forms.ToolStripButton btnPrint;
//        public System.Windows.Forms.ToolStripButton btnDelete;
//        public System.Windows.Forms.ToolStripButton btnClose;
//    }
//}
