namespace ERP.Forms
{
    partial class frm_CustomerList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CustomerList));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.CustomerListGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.uc_CustomerSideMenu1 = new ERP.Forms.UserControls.uc_CustomerSideMenu();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lkp_List
            // 
            resources.ApplyResources(this.lkp_List, "lkp_List");
            // 
            // SubItem_ConvertTo
            // 
            resources.ApplyResources(this.SubItem_ConvertTo, "SubItem_ConvertTo");
            this.SubItem_ConvertTo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_ConvertTo.ImageOptions.Image")));
            this.SubItem_ConvertTo.ImageOptions.ImageIndex = ((int)(resources.GetObject("SubItem_ConvertTo.ImageOptions.ImageIndex")));
            this.SubItem_ConvertTo.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("SubItem_ConvertTo.ImageOptions.LargeImageIndex")));
            this.SubItem_ConvertTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubItem_ConvertTo.ImageOptions.SvgImage")));
            this.SubItem_ConvertTo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ConvertToOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ConvertToOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ConvertToOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ConvertToOrder)});
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.Image")));
            // 
            // SubItem_Printbills
            // 
            resources.ApplyResources(this.SubItem_Printbills, "SubItem_Printbills");
            this.SubItem_Printbills.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_Printbills.ImageOptions.Image")));
            this.SubItem_Printbills.ImageOptions.ImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.ImageIndex")));
            this.SubItem_Printbills.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.LargeImageIndex")));
            this.SubItem_Printbills.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubItem_Printbills.ImageOptions.SvgImage")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.Image")));
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleDescription");
            this.gridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleName");
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImage")));
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl1.EmbeddedNavigator.MaximumSize")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.MainView = this.CustomerListGridView;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CustomerListGridView});
            // 
            // CustomerListGridView
            // 
            resources.ApplyResources(this.CustomerListGridView, "CustomerListGridView");
            this.CustomerListGridView.GridControl = this.gridControl1;
            this.CustomerListGridView.Name = "CustomerListGridView";
            this.CustomerListGridView.OptionsBehavior.Editable = false;
            this.CustomerListGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.CustomerListGridView_FocusedRowChanged);
            this.CustomerListGridView.ColumnFilterChanged += new System.EventHandler(this.gridView1_ColumnFilterChanged);
            this.CustomerListGridView.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // uc_CustomerSideMenu1
            // 
            resources.ApplyResources(this.uc_CustomerSideMenu1, "uc_CustomerSideMenu1");
            this.uc_CustomerSideMenu1.CustomerID = 0;
            this.uc_CustomerSideMenu1.Name = "uc_CustomerSideMenu1";
            // 
            // frm_CustomerList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.uc_CustomerSideMenu1);
            this.Name = "frm_CustomerList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_CustomerList_FormClosing);
            this.Load += new System.EventHandler(this.frm_CustomerList_Load);
            this.Controls.SetChildIndex(this.uc_CustomerSideMenu1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerListGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView CustomerListGridView;
        private UserControls.uc_CustomerSideMenu uc_CustomerSideMenu1;
    }
}