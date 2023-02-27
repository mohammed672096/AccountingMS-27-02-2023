using System.Windows.Forms;

namespace AccountingMS
{
    partial class UC_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Account));
            this.userSettingsProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCostCenterID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCostCenterRestriction = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCategorie = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCurrencieID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUserID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEnterTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccount1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tblAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccountLevelTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CostCenterIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CurrencieIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.AccountTypeTextEdit = new DevExpress.XtraEditors.RadioGroup();
            this.AccountCategorieTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ParentIDSearchLookUpEdit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForParentID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrencieID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCostCenterID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccountType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccountCategorie = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccountLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tblAccountMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NameTextEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).BeginInit();
            this.dataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLevelTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostCenterIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencieIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountCategorieTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentIDSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencieID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCostCenterID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayout
            // 
            resources.ApplyResources(this.dataLayout, "dataLayout");
            this.dataLayout.Appearance.Control.Options.UseTextOptions = true;
            this.dataLayout.Appearance.Control.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.dataLayout.Controls.Add(this.treeList1);
            this.dataLayout.Controls.Add(this.NumberTextEdit);
            this.dataLayout.Controls.Add(this.AccountLevelTextEdit);
            this.dataLayout.Controls.Add(this.CostCenterIDTextEdit);
            this.dataLayout.Controls.Add(this.CurrencieIDTextEdit);
            this.dataLayout.Controls.Add(this.AccountTypeTextEdit);
            this.dataLayout.Controls.Add(this.AccountCategorieTextEdit);
            this.dataLayout.Controls.Add(this.ParentIDSearchLookUpEdit);
            this.dataLayout.Controls.Add(this.NameTextEdit);
            this.dataLayout.DataSource = this.tblAccountBindingSource;
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayout.Root = this.Root;
            // 
            // treeList1
            // 
            resources.ApplyResources(this.treeList1, "treeList1");
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colNumber,
            this.colAccountLevel,
            this.colAccountType,
            this.colCostCenterID,
            this.colCostCenterRestriction,
            this.colAccountCategorie,
            this.colCurrencieID,
            this.colUserID,
            this.colEnterTime,
            this.colEnName,
            this.colAccount1});
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsFind.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Large;
            this.treeList1.Load += new System.EventHandler(this.treeList1_Load);
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colNumber
            // 
            resources.ApplyResources(this.colNumber, "colNumber");
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            // 
            // colAccountLevel
            // 
            resources.ApplyResources(this.colAccountLevel, "colAccountLevel");
            this.colAccountLevel.FieldName = "AccountLevel";
            this.colAccountLevel.Name = "colAccountLevel";
            // 
            // colAccountType
            // 
            resources.ApplyResources(this.colAccountType, "colAccountType");
            this.colAccountType.FieldName = "AccountType";
            this.colAccountType.Name = "colAccountType";
            // 
            // colCostCenterID
            // 
            resources.ApplyResources(this.colCostCenterID, "colCostCenterID");
            this.colCostCenterID.FieldName = "CostCenterID";
            this.colCostCenterID.Name = "colCostCenterID";
            // 
            // colCostCenterRestriction
            // 
            resources.ApplyResources(this.colCostCenterRestriction, "colCostCenterRestriction");
            this.colCostCenterRestriction.FieldName = "CostCenterRestriction";
            this.colCostCenterRestriction.Name = "colCostCenterRestriction";
            // 
            // colAccountCategorie
            // 
            resources.ApplyResources(this.colAccountCategorie, "colAccountCategorie");
            this.colAccountCategorie.FieldName = "AccountCategorie";
            this.colAccountCategorie.Name = "colAccountCategorie";
            // 
            // colCurrencieID
            // 
            resources.ApplyResources(this.colCurrencieID, "colCurrencieID");
            this.colCurrencieID.FieldName = "CurrencieID";
            this.colCurrencieID.Name = "colCurrencieID";
            // 
            // colUserID
            // 
            resources.ApplyResources(this.colUserID, "colUserID");
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // colEnterTime
            // 
            resources.ApplyResources(this.colEnterTime, "colEnterTime");
            this.colEnterTime.FieldName = "EnterTime";
            this.colEnterTime.Name = "colEnterTime";
            // 
            // colEnName
            // 
            resources.ApplyResources(this.colEnName, "colEnName");
            this.colEnName.FieldName = "EnName";
            this.colEnName.Name = "colEnName";
            // 
            // colAccount1
            // 
            resources.ApplyResources(this.colAccount1, "colAccount1");
            this.colAccount1.FieldName = "Account1";
            this.colAccount1.Name = "colAccount1";
            // 
            // NumberTextEdit
            // 
            resources.ApplyResources(this.NumberTextEdit, "NumberTextEdit");
            this.NumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumberTextEdit.Name = "NumberTextEdit";
            this.NumberTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.NumberTextEdit.Properties.MaskSettings.Set("mask", "d");
            this.NumberTextEdit.StyleController = this.dataLayout;
            // 
            // tblAccountBindingSource
            // 
            this.tblAccountBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // AccountLevelTextEdit
            // 
            resources.ApplyResources(this.AccountLevelTextEdit, "AccountLevelTextEdit");
            this.AccountLevelTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accLevel", true));
            this.AccountLevelTextEdit.Name = "AccountLevelTextEdit";
            this.AccountLevelTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AccountLevelTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.AccountLevelTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AccountLevelTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AccountLevelTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.AccountLevelTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.AccountLevelTextEdit.Properties.ReadOnly = true;
            this.AccountLevelTextEdit.StyleController = this.dataLayout;
            // 
            // CostCenterIDTextEdit
            // 
            resources.ApplyResources(this.CostCenterIDTextEdit, "CostCenterIDTextEdit");
            this.CostCenterIDTextEdit.Name = "CostCenterIDTextEdit";
            this.CostCenterIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CostCenterIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CostCenterIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CostCenterIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("CostCenterIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.CostCenterIDTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.CostCenterIDTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.CostCenterIDTextEdit.StyleController = this.dataLayout;
            // 
            // CurrencieIDTextEdit
            // 
            resources.ApplyResources(this.CurrencieIDTextEdit, "CurrencieIDTextEdit");
            this.CurrencieIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accCurrency", true));
            this.CurrencieIDTextEdit.Name = "CurrencieIDTextEdit";
            this.CurrencieIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CurrencieIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CurrencieIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CurrencieIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CurrencieIDTextEdit.Properties.Buttons"))))});
            this.CurrencieIDTextEdit.Properties.DisplayMember = "Name";
            this.CurrencieIDTextEdit.Properties.NullText = resources.GetString("CurrencieIDTextEdit.Properties.NullText");
            this.CurrencieIDTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.CurrencieIDTextEdit.Properties.ValueMember = "ID";
            this.CurrencieIDTextEdit.StyleController = this.dataLayout;
            // 
            // AccountTypeTextEdit
            // 
            resources.ApplyResources(this.AccountTypeTextEdit, "AccountTypeTextEdit");
            this.AccountTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accType", true));
            this.AccountTypeTextEdit.Name = "AccountTypeTextEdit";
            this.AccountTypeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AccountTypeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.AccountTypeTextEdit.Properties.Columns = 2;
            this.AccountTypeTextEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("AccountTypeTextEdit.Properties.Items"))), resources.GetString("AccountTypeTextEdit.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("AccountTypeTextEdit.Properties.Items2"))), resources.GetString("AccountTypeTextEdit.Properties.Items3"))});
            this.AccountTypeTextEdit.Properties.ReadOnly = true;
            this.AccountTypeTextEdit.StyleController = this.dataLayout;
            // 
            // AccountCategorieTextEdit
            // 
            resources.ApplyResources(this.AccountCategorieTextEdit, "AccountCategorieTextEdit");
            this.AccountCategorieTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accCat", true));
            this.AccountCategorieTextEdit.Name = "AccountCategorieTextEdit";
            this.AccountCategorieTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.AccountCategorieTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AccountCategorieTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.AccountCategorieTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AccountCategorieTextEdit.Properties.AutoHeight")));
            this.AccountCategorieTextEdit.Properties.DisplayMember = "accName";
            this.AccountCategorieTextEdit.Properties.NullText = resources.GetString("AccountCategorieTextEdit.Properties.NullText");
            this.AccountCategorieTextEdit.Properties.ReadOnly = true;
            this.AccountCategorieTextEdit.Properties.ValueMember = "accCat";
            this.AccountCategorieTextEdit.StyleController = this.dataLayout;
            // 
            // ParentIDSearchLookUpEdit
            // 
            resources.ApplyResources(this.ParentIDSearchLookUpEdit, "ParentIDSearchLookUpEdit");
            this.ParentIDSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "ParentID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ParentIDSearchLookUpEdit.Name = "ParentIDSearchLookUpEdit";
            this.ParentIDSearchLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ParentIDSearchLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ParentIDSearchLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ParentIDSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ParentIDSearchLookUpEdit.Properties.Buttons"))))});
            this.ParentIDSearchLookUpEdit.Properties.DisplayMember = "Name";
            this.ParentIDSearchLookUpEdit.Properties.NullText = resources.GetString("ParentIDSearchLookUpEdit.Properties.NullText");
            this.ParentIDSearchLookUpEdit.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.ParentIDSearchLookUpEdit.Properties.ValueMember = "ID";
            this.ParentIDSearchLookUpEdit.StyleController = this.dataLayout;
            // 
            // treeListLookUpEdit1TreeList
            // 
            resources.ApplyResources(this.treeListLookUpEdit1TreeList, "treeListLookUpEdit1TreeList");
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListName});
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.Editable = false;
            this.treeListLookUpEdit1TreeList.OptionsBehavior.PopulateServiceColumns = true;
            this.treeListLookUpEdit1TreeList.OptionsBehavior.ReadOnly = true;
            this.treeListLookUpEdit1TreeList.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            // 
            // treeListName
            // 
            resources.ApplyResources(this.treeListName, "treeListName");
            this.treeListName.FieldName = "Name";
            this.treeListName.Name = "treeListName";
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 5, 10);
            this.Root.Size = new System.Drawing.Size(1383, 662);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1363, 647);
            // 
            // layoutControlGroup
            // 
            resources.ApplyResources(this.layoutControlGroup, "layoutControlGroup");
            this.layoutControlGroup.AppearanceGroup.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.layoutControlGroup.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForParentID,
            this.ItemForCurrencieID,
            this.ItemForName,
            this.ItemForCostCenterID,
            this.ItemForAccountType,
            this.ItemForNumber,
            this.ItemForAccountCategorie,
            this.ItemForAccountLevel,
            this.emptySpaceItem1});
            this.layoutControlGroup.Location = new System.Drawing.Point(907, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(456, 647);
            // 
            // ItemForParentID
            // 
            resources.ApplyResources(this.ItemForParentID, "ItemForParentID");
            this.ItemForParentID.Control = this.ParentIDSearchLookUpEdit;
            this.ItemForParentID.Location = new System.Drawing.Point(0, 0);
            this.ItemForParentID.Name = "ItemForParentID";
            this.ItemForParentID.Size = new System.Drawing.Size(432, 28);
            this.ItemForParentID.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForCurrencieID
            // 
            resources.ApplyResources(this.ItemForCurrencieID, "ItemForCurrencieID");
            this.ItemForCurrencieID.Control = this.CurrencieIDTextEdit;
            this.ItemForCurrencieID.Location = new System.Drawing.Point(0, 155);
            this.ItemForCurrencieID.Name = "ItemForCurrencieID";
            this.ItemForCurrencieID.Size = new System.Drawing.Size(432, 28);
            this.ItemForCurrencieID.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForName
            // 
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 56);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(432, 71);
            this.ItemForName.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForCostCenterID
            // 
            resources.ApplyResources(this.ItemForCostCenterID, "ItemForCostCenterID");
            this.ItemForCostCenterID.Control = this.CostCenterIDTextEdit;
            this.ItemForCostCenterID.Location = new System.Drawing.Point(0, 257);
            this.ItemForCostCenterID.Name = "ItemForCostCenterID";
            this.ItemForCostCenterID.Size = new System.Drawing.Size(432, 28);
            this.ItemForCostCenterID.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForAccountType
            // 
            resources.ApplyResources(this.ItemForAccountType, "ItemForAccountType");
            this.ItemForAccountType.Control = this.AccountTypeTextEdit;
            this.ItemForAccountType.Location = new System.Drawing.Point(0, 211);
            this.ItemForAccountType.Name = "ItemForAccountType";
            this.ItemForAccountType.Size = new System.Drawing.Size(432, 46);
            this.ItemForAccountType.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForNumber
            // 
            resources.ApplyResources(this.ItemForNumber, "ItemForNumber");
            this.ItemForNumber.Control = this.NumberTextEdit;
            this.ItemForNumber.Location = new System.Drawing.Point(0, 28);
            this.ItemForNumber.Name = "ItemForNumber";
            this.ItemForNumber.Size = new System.Drawing.Size(432, 28);
            this.ItemForNumber.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForAccountCategorie
            // 
            resources.ApplyResources(this.ItemForAccountCategorie, "ItemForAccountCategorie");
            this.ItemForAccountCategorie.Control = this.AccountCategorieTextEdit;
            this.ItemForAccountCategorie.Location = new System.Drawing.Point(0, 127);
            this.ItemForAccountCategorie.Name = "ItemForAccountCategorie";
            this.ItemForAccountCategorie.Size = new System.Drawing.Size(432, 28);
            this.ItemForAccountCategorie.TextSize = new System.Drawing.Size(114, 18);
            // 
            // ItemForAccountLevel
            // 
            resources.ApplyResources(this.ItemForAccountLevel, "ItemForAccountLevel");
            this.ItemForAccountLevel.Control = this.AccountLevelTextEdit;
            this.ItemForAccountLevel.Location = new System.Drawing.Point(0, 183);
            this.ItemForAccountLevel.Name = "ItemForAccountLevel";
            this.ItemForAccountLevel.Size = new System.Drawing.Size(432, 28);
            this.ItemForAccountLevel.TextSize = new System.Drawing.Size(114, 18);
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.AppearanceGroup.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(907, 647);
            // 
            // layoutControlItem1
            // 
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Control = this.treeList1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(883, 592);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 285);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(432, 307);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // NameTextEdit
            // 
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblAccountBindingSource, "accName", true));
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.StyleController = this.dataLayout;
            // 
            // UC_Account
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayout);
            this.Name = "UC_Account";
            this.Load += new System.EventHandler(this.UC_Master_Load);
            this.Controls.SetChildIndex(this.dataLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).EndInit();
            this.dataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLevelTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostCenterIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencieIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountCategorieTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentIDSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencieID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCostCenterID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource userSettingsProfileBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayout;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNumber;
        private DevExpress.XtraEditors.TextEdit NumberTextEdit;
        private DevExpress.XtraEditors.TextEdit AccountLevelTextEdit;
        private DevExpress.XtraEditors.TextEdit CostCenterIDTextEdit;
        private DevExpress.XtraEditors.LookUpEdit CurrencieIDTextEdit;
        private DevExpress.XtraEditors.RadioGroup AccountTypeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit AccountCategorieTextEdit;
        private DevExpress.XtraEditors.TreeListLookUpEdit ParentIDSearchLookUpEdit;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForParentID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccountCategorie;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccountType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccountLevel;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrencieID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCostCenterID;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource tblAccountBindingSource;
        private System.Windows.Forms.BindingSource tblAccountMainBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCostCenterID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCostCenterRestriction;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCategorie;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCurrencieID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnterTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccount1;
        private DevExpress.XtraEditors.MemoEdit NameTextEdit;
    }
}
