namespace AccountingMS.FormsMain
{
    partial class MasterForm
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
           void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_SaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Print = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Log = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Save,
            this.btn_New,
            this.btn_Delete,
            this.btn_Print,
            this.btn_Refresh,
            this.btn_Log,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btn_SaveAndNew});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 13;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SaveAndNew),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_New, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Delete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Print, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Refresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Log)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // btn_SaveAndNew
            // 
            resources.ApplyResources(this.btn_SaveAndNew, "btn_SaveAndNew");
            this.btn_SaveAndNew.Id = 12;
            this.btn_SaveAndNew.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_SaveAndNew.ImageOptions.ImageIndex")));
            this.btn_SaveAndNew.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_SaveAndNew.ImageOptions.LargeImageIndex")));
            this.btn_SaveAndNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_SaveAndNew.ImageOptions.SvgImage")));
            this.btn_SaveAndNew.Name = "btn_SaveAndNew";
            this.btn_SaveAndNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_SaveAndNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_SaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveAndNew_ItemClick);
            // 
            // btn_Save
            // 
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Id = 0;
            this.btn_Save.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_Save.ImageOptions.ImageIndex")));
            this.btn_Save.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_Save.ImageOptions.LargeImageIndex")));
            this.btn_Save.Name = "btn_Save";
            // 
            // btn_New
            // 
            resources.ApplyResources(this.btn_New, "btn_New");
            this.btn_New.Id = 1;
            this.btn_New.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_New.ImageOptions.ImageIndex")));
            this.btn_New.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_New.ImageOptions.LargeImageIndex")));
            this.btn_New.Name = "btn_New";
            // 
            // btn_Delete
            // 
            resources.ApplyResources(this.btn_Delete, "btn_Delete");
            this.btn_Delete.Id = 2;
            this.btn_Delete.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_Delete.ImageOptions.ImageIndex")));
            this.btn_Delete.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_Delete.ImageOptions.LargeImageIndex")));
            this.btn_Delete.Name = "btn_Delete";
            // 
            // btn_Print
            // 
            resources.ApplyResources(this.btn_Print, "btn_Print");
            this.btn_Print.Enabled = false;
            this.btn_Print.Id = 4;
            this.btn_Print.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_Print.ImageOptions.ImageIndex")));
            this.btn_Print.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_Print.ImageOptions.LargeImageIndex")));
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btn_Refresh
            // 
            resources.ApplyResources(this.btn_Refresh, "btn_Refresh");
            this.btn_Refresh.Id = 5;
            this.btn_Refresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_Refresh.ImageOptions.ImageIndex")));
            this.btn_Refresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_Refresh.ImageOptions.LargeImageIndex")));
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btn_Log
            // 
            resources.ApplyResources(this.btn_Log, "btn_Log");
            this.btn_Log.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_Log.Id = 6;
            this.btn_Log.ImageOptions.ImageIndex = ((int)(resources.GetObject("btn_Log.ImageOptions.ImageIndex")));
            this.btn_Log.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btn_Log.ImageOptions.LargeImageIndex")));
            this.btn_Log.Name = "btn_Log";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Manager = this.barManager1;
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Manager = this.barManager1;
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Manager = this.barManager1;
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Manager = this.barManager1;
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.ImageIndex")));
            this.barButtonItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.LargeImageIndex")));
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem2.ImageOptions.ImageIndex")));
            this.barButtonItem2.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem2.ImageOptions.LargeImageIndex")));
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // MasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MasterForm.IconOptions.Image")));
            this.Name = "MasterForm";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        public DevExpress.XtraBars.BarButtonItem btn_Save;
        public DevExpress.XtraBars.BarButtonItem btn_New;
        public DevExpress.XtraBars.BarButtonItem btn_Delete;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem btn_Print;
        public  DevExpress.XtraBars.BarButtonItem btn_Refresh;
        public DevExpress.XtraBars.BarButtonItem btn_Log;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        public DevExpress.XtraBars.BarButtonItem btn_SaveAndNew;
    }
}