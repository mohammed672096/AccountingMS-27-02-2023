﻿namespace PosFinalCost.Forms
{
    partial class UC_Setting
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
            this.userSettingsProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userSettingsProfileBindingSource
            // 
            this.userSettingsProfileBindingSource.DataSource = typeof(PosFinalCost.UserSettingsProfile);
            // 
            // UC_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UC_Setting";
            this.Load += new System.EventHandler(this.UC_Master_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource userSettingsProfileBindingSource;
    }
}
