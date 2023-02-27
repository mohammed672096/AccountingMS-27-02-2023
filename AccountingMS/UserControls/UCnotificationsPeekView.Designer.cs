
namespace AccountingMS
{
    partial class UCnotificationsPeekView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tblNotificationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colnotNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colnotNo = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colnotName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repoItemMemoEditNotName = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_colnotName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colnotAmount = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colnotAmount = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colnotStatus = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colnotStatus = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colnotDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colnotDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.tblNotificationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemMemoEditNotName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblNotificationBindingSource
            // 
            this.tblNotificationBindingSource.DataSource = typeof(AccountingMS.tblNotification);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblNotificationBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemMemoEditNotName});
            this.gridControl1.Size = new System.Drawing.Size(260, 450);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutView1
            // 
            this.layoutView1.CardHorzInterval = 1;
            this.layoutView1.CardMinSize = new System.Drawing.Size(140, 120);
            this.layoutView1.CardVertInterval = 3;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colnotNo,
            this.colnotName,
            this.colnotAmount,
            this.colnotStatus,
            this.colnotDate});
            this.layoutView1.DetailHeight = 377;
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colnotDate});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsBehavior.ReadOnly = true;
            this.layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.layoutView1.OptionsCustomization.AllowFilter = false;
            this.layoutView1.OptionsCustomization.AllowSort = false;
            this.layoutView1.OptionsHeaderPanel.ShowCustomizeButton = false;
            this.layoutView1.OptionsItemText.TextToControlDistance = 2;
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Column;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // colnotNo
            // 
            this.colnotNo.AppearanceCell.Options.UseTextOptions = true;
            this.colnotNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotNo.Caption = "رقم الفاتورة";
            this.colnotNo.FieldName = "notNo";
            this.colnotNo.LayoutViewField = this.layoutViewField_colnotNo;
            this.colnotNo.MinWidth = 23;
            this.colnotNo.Name = "colnotNo";
            this.colnotNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colnotNo.Width = 154;
            // 
            // layoutViewField_colnotNo
            // 
            this.layoutViewField_colnotNo.EditorPreferredWidth = 47;
            this.layoutViewField_colnotNo.Location = new System.Drawing.Point(0, 26);
            this.layoutViewField_colnotNo.Name = "layoutViewField_colnotNo";
            this.layoutViewField_colnotNo.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_colnotNo.Size = new System.Drawing.Size(107, 26);
            this.layoutViewField_colnotNo.TextSize = new System.Drawing.Size(59, 14);
            // 
            // colnotName
            // 
            this.colnotName.AppearanceCell.Options.UseTextOptions = true;
            this.colnotName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colnotName.ColumnEdit = this.repoItemMemoEditNotName;
            this.colnotName.FieldName = "notName";
            this.colnotName.LayoutViewField = this.layoutViewField_colnotName;
            this.colnotName.MinWidth = 23;
            this.colnotName.Name = "colnotName";
            this.colnotName.Width = 334;
            // 
            // repoItemMemoEditNotName
            // 
            this.repoItemMemoEditNotName.Name = "repoItemMemoEditNotName";
            this.repoItemMemoEditNotName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            // 
            // layoutViewField_colnotName
            // 
            this.layoutViewField_colnotName.EditorPreferredWidth = 107;
            this.layoutViewField_colnotName.Location = new System.Drawing.Point(107, 26);
            this.layoutViewField_colnotName.Name = "layoutViewField_colnotName";
            this.layoutViewField_colnotName.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_colnotName.Size = new System.Drawing.Size(99, 59);
            this.layoutViewField_colnotName.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colnotName.TextVisible = false;
            // 
            // colnotAmount
            // 
            this.colnotAmount.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colnotAmount.AppearanceCell.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.colnotAmount.AppearanceCell.Options.UseFont = true;
            this.colnotAmount.AppearanceCell.Options.UseForeColor = true;
            this.colnotAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colnotAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotAmount.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colnotAmount.AppearanceHeader.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.colnotAmount.AppearanceHeader.Options.UseFont = true;
            this.colnotAmount.AppearanceHeader.Options.UseForeColor = true;
            this.colnotAmount.Caption = "المبلغ";
            this.colnotAmount.DisplayFormat.FormatString = "n2";
            this.colnotAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnotAmount.FieldName = "notAmount";
            this.colnotAmount.LayoutViewField = this.layoutViewField_colnotAmount;
            this.colnotAmount.MinWidth = 23;
            this.colnotAmount.Name = "colnotAmount";
            this.colnotAmount.Width = 180;
            // 
            // layoutViewField_colnotAmount
            // 
            this.layoutViewField_colnotAmount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutViewField_colnotAmount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutViewField_colnotAmount.EditorPreferredWidth = 79;
            this.layoutViewField_colnotAmount.Location = new System.Drawing.Point(0, 52);
            this.layoutViewField_colnotAmount.Name = "layoutViewField_colnotAmount";
            this.layoutViewField_colnotAmount.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_colnotAmount.Size = new System.Drawing.Size(107, 33);
            this.layoutViewField_colnotAmount.TextSize = new System.Drawing.Size(32, 14);
            // 
            // colnotStatus
            // 
            this.colnotStatus.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colnotStatus.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colnotStatus.AppearanceCell.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.colnotStatus.AppearanceCell.Options.UseFont = true;
            this.colnotStatus.AppearanceCell.Options.UseForeColor = true;
            this.colnotStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colnotStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colnotStatus.Caption = "نوع الإشعار";
            this.colnotStatus.FieldName = "notStatus";
            this.colnotStatus.LayoutViewField = this.layoutViewField_colnotStatus;
            this.colnotStatus.MinWidth = 23;
            this.colnotStatus.Name = "colnotStatus";
            this.colnotStatus.Width = 334;
            // 
            // layoutViewField_colnotStatus
            // 
            this.layoutViewField_colnotStatus.EditorPreferredWidth = 231;
            this.layoutViewField_colnotStatus.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colnotStatus.Name = "layoutViewField_colnotStatus";
            this.layoutViewField_colnotStatus.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_colnotStatus.Size = new System.Drawing.Size(206, 26);
            this.layoutViewField_colnotStatus.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colnotStatus.TextVisible = false;
            // 
            // colnotDate
            // 
            this.colnotDate.Caption = "تاريخ الإستحقاق:";
            this.colnotDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colnotDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colnotDate.FieldName = "notDate";
            this.colnotDate.LayoutViewField = this.layoutViewField_colnotDate;
            this.colnotDate.MinWidth = 23;
            this.colnotDate.Name = "colnotDate";
            this.colnotDate.Width = 334;
            // 
            // layoutViewField_colnotDate
            // 
            this.layoutViewField_colnotDate.EditorPreferredWidth = 23;
            this.layoutViewField_colnotDate.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colnotDate.Name = "layoutViewField_colnotDate";
            this.layoutViewField_colnotDate.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_colnotDate.Size = new System.Drawing.Size(206, 78);
            this.layoutViewField_colnotDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colnotDate.TextSize = new System.Drawing.Size(88, 14);
            this.layoutViewField_colnotDate.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colnotStatus,
            this.layoutViewField_colnotAmount,
            this.layoutViewField_colnotNo,
            this.layoutViewField_colnotName});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeGroup.AutoSize;
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // UCnotificationsPeekView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "UCnotificationsPeekView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(260, 450);
            ((System.ComponentModel.ISupportInitialize)(this.tblNotificationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemMemoEditNotName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colnotDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tblNotificationBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colnotNo;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colnotName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colnotAmount;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colnotStatus;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colnotDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoItemMemoEditNotName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colnotNo;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colnotName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colnotAmount;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colnotStatus;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colnotDate;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}
