namespace AccountingMS
{
    partial class formFinancialYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFinancialYear));
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageCollectionView = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPageObjectView = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame
            // 
            this.navigationFrame.Controls.Add(this.navigationPageCollectionView);
            this.navigationFrame.Controls.Add(this.navigationPageObjectView);
            resources.ApplyResources(this.navigationFrame, "navigationFrame");
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageCollectionView,
            this.navigationPageObjectView});
            this.navigationFrame.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.navigationFrame.SelectedPage = this.navigationPageCollectionView;
            this.navigationFrame.TransitionAnimationProperties.FrameInterval = 5000;
            // 
            // navigationPageCollectionView
            // 
            this.navigationPageCollectionView.Name = "navigationPageCollectionView";
            resources.ApplyResources(this.navigationPageCollectionView, "navigationPageCollectionView");
            // 
            // navigationPageObjectView
            // 
            resources.ApplyResources(this.navigationPageObjectView, "navigationPageObjectView");
            this.navigationPageObjectView.Name = "navigationPageObjectView";
            // 
            // formFinancialYear
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame);
            this.IconOptions.ShowIcon = false;
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.True;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "formFinancialYear";
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageObjectView;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageCollectionView;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
    }
}