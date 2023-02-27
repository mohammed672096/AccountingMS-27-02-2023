﻿namespace AccountingMS
{
    partial class ReportGeneralLedger
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.tblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrlHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBoxBranch = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabelBranchNameEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddressEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelBranchName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTableBalanceV = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcTotalDebitStr = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcTotalCreditStr = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcCurrentBalanceStr = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcTotalDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcTotalCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcCurrentBalance = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcBalanceName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcAccName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.parameterAccNo = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtEnd = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableBalanceV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tblBindingSource
            // 
            this.tblBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlHeader,
            this.xrPictureBoxBranch,
            this.xrLabelBranchNameEn,
            this.xrLabelBranchAddressEn,
            this.xrLabelBranchPhnNo2,
            this.xrLabelBranchFaxNo2,
            this.xrLabelBranchMailBox2,
            this.xrLabelBranchMailBox1,
            this.xrLabelBranchFaxNo1,
            this.xrLabelBranchPhnNo1,
            this.xrLine5,
            this.xrLabelBranchName,
            this.xrLabelBranchAddress});
            this.TopMargin.HeightF = 150F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrlHeader
            // 
            this.xrlHeader.AutoWidth = true;
            this.xrlHeader.CanGrow = false;
            this.xrlHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrlHeader.ForeColor = System.Drawing.Color.Navy;
            this.xrlHeader.LocationFloat = new DevExpress.Utils.PointFloat(331.9763F, 111.6407F);
            this.xrlHeader.Name = "xrlHeader";
            this.xrlHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlHeader.SizeF = new System.Drawing.SizeF(127.0835F, 23F);
            this.xrlHeader.StylePriority.UseFont = false;
            this.xrlHeader.StylePriority.UseForeColor = false;
            this.xrlHeader.StylePriority.UseTextAlignment = false;
            this.xrlHeader.Text = "تقرير الأستاذ العام";
            this.xrlHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrlHeader.WordWrap = false;
            // 
            // xrPictureBoxBranch
            // 
            this.xrPictureBoxBranch.LocationFloat = new DevExpress.Utils.PointFloat(331.9763F, 11.64064F);
            this.xrPictureBoxBranch.Name = "xrPictureBoxBranch";
            this.xrPictureBoxBranch.SizeF = new System.Drawing.SizeF(127.0004F, 92.00004F);
            this.xrPictureBoxBranch.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabelBranchNameEn
            // 
            this.xrLabelBranchNameEn.AutoWidth = true;
            this.xrLabelBranchNameEn.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchNameEn.LocationFloat = new DevExpress.Utils.PointFloat(696.9166F, 10.00001F);
            this.xrLabelBranchNameEn.Name = "xrLabelBranchNameEn";
            this.xrLabelBranchNameEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchNameEn.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchNameEn.StylePriority.UseFont = false;
            this.xrLabelBranchNameEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchNameEn.Text = "xrLabelBranchName";
            this.xrLabelBranchNameEn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchNameEn.WordWrap = false;
            // 
            // xrLabelBranchAddressEn
            // 
            this.xrLabelBranchAddressEn.AutoWidth = true;
            this.xrLabelBranchAddressEn.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchAddressEn.LocationFloat = new DevExpress.Utils.PointFloat(696.9166F, 32.99999F);
            this.xrLabelBranchAddressEn.Name = "xrLabelBranchAddressEn";
            this.xrLabelBranchAddressEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddressEn.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchAddressEn.StylePriority.UseFont = false;
            this.xrLabelBranchAddressEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddressEn.Text = "xrLabelBranchName";
            this.xrLabelBranchAddressEn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchAddressEn.WordWrap = false;
            // 
            // xrLabelBranchPhnNo2
            // 
            this.xrLabelBranchPhnNo2.AutoWidth = true;
            this.xrLabelBranchPhnNo2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchPhnNo2.LocationFloat = new DevExpress.Utils.PointFloat(696.9166F, 56.00001F);
            this.xrLabelBranchPhnNo2.Name = "xrLabelBranchPhnNo2";
            this.xrLabelBranchPhnNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchPhnNo2.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo2.Text = "xrLabelBranchName";
            this.xrLabelBranchPhnNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchPhnNo2.WordWrap = false;
            // 
            // xrLabelBranchFaxNo2
            // 
            this.xrLabelBranchFaxNo2.AutoWidth = true;
            this.xrLabelBranchFaxNo2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchFaxNo2.LocationFloat = new DevExpress.Utils.PointFloat(696.9166F, 79.00006F);
            this.xrLabelBranchFaxNo2.Name = "xrLabelBranchFaxNo2";
            this.xrLabelBranchFaxNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchFaxNo2.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo2.Text = "xrLabelBranchName";
            this.xrLabelBranchFaxNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchFaxNo2.WordWrap = false;
            // 
            // xrLabelBranchMailBox2
            // 
            this.xrLabelBranchMailBox2.AutoWidth = true;
            this.xrLabelBranchMailBox2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchMailBox2.LocationFloat = new DevExpress.Utils.PointFloat(696.9166F, 102F);
            this.xrLabelBranchMailBox2.Name = "xrLabelBranchMailBox2";
            this.xrLabelBranchMailBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchMailBox2.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox2.Text = "xrLabelBranchName";
            this.xrLabelBranchMailBox2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchMailBox2.WordWrap = false;
            // 
            // xrLabelBranchMailBox1
            // 
            this.xrLabelBranchMailBox1.AutoWidth = true;
            this.xrLabelBranchMailBox1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchMailBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 102F);
            this.xrLabelBranchMailBox1.Name = "xrLabelBranchMailBox1";
            this.xrLabelBranchMailBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchMailBox1.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox1.Text = "xrLabelBranchName";
            this.xrLabelBranchMailBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchMailBox1.WordWrap = false;
            // 
            // xrLabelBranchFaxNo1
            // 
            this.xrLabelBranchFaxNo1.AutoWidth = true;
            this.xrLabelBranchFaxNo1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchFaxNo1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 79.00005F);
            this.xrLabelBranchFaxNo1.Name = "xrLabelBranchFaxNo1";
            this.xrLabelBranchFaxNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchFaxNo1.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo1.Text = "xrLabelBranchName";
            this.xrLabelBranchFaxNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchFaxNo1.WordWrap = false;
            // 
            // xrLabelBranchPhnNo1
            // 
            this.xrLabelBranchPhnNo1.AutoWidth = true;
            this.xrLabelBranchPhnNo1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchPhnNo1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 56.00001F);
            this.xrLabelBranchPhnNo1.Name = "xrLabelBranchPhnNo1";
            this.xrLabelBranchPhnNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchPhnNo1.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo1.Text = "xrLabelBranchName";
            this.xrLabelBranchPhnNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchPhnNo1.WordWrap = false;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(8.958261F, 134.6407F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(787.9584F, 5.124924F);
            // 
            // xrLabelBranchName
            // 
            this.xrLabelBranchName.AutoWidth = true;
            this.xrLabelBranchName.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchName.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.xrLabelBranchName.Name = "xrLabelBranchName";
            this.xrLabelBranchName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchName.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchName.StylePriority.UseFont = false;
            this.xrLabelBranchName.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchName.Text = "xrLabelBranchName";
            this.xrLabelBranchName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchName.WordWrap = false;
            // 
            // xrLabelBranchAddress
            // 
            this.xrLabelBranchAddress.AutoWidth = true;
            this.xrLabelBranchAddress.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchAddress.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 32.99998F);
            this.xrLabelBranchAddress.Name = "xrLabelBranchAddress";
            this.xrLabelBranchAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddress.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchAddress.StylePriority.UseFont = false;
            this.xrLabelBranchAddress.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddress.Text = "xrLabelBranchName";
            this.xrLabelBranchAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchAddress.WordWrap = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrPictureBox1,
            this.xrLabel22});
            this.BottomMargin.HeightF = 75F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(529.0415F, 19.55961F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(267.7083F, 40.20831F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "B-Technology Accounting Mangment System\r\nTel: +967-777-299-175";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(global::AccountingMS.Properties.Resources.BTech, true);
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(343.5168F, 7.291668F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(100F, 60.41666F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.StylePriority.UseBorderColor = false;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            this.xrPictureBox1.StylePriority.UsePadding = false;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(10F, 19.55961F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(267.7083F, 40.20831F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Copy rights B-Technology";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableBalanceV});
            this.Detail.HeightF = 129.1667F;
            this.Detail.Name = "Detail";
            // 
            // xrTableBalanceV
            // 
            this.xrTableBalanceV.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.xrTableBalanceV.Name = "xrTableBalanceV";
            this.xrTableBalanceV.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6,
            this.xrTableRow5});
            this.xrTableBalanceV.SizeF = new System.Drawing.SizeF(787F, 50F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcTotalDebitStr,
            this.xrtcTotalCreditStr,
            this.xrtcCurrentBalanceStr});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 11.5D;
            // 
            // xrtcTotalDebitStr
            // 
            this.xrtcTotalDebitStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(223)))), ((int)(((byte)(201)))));
            this.xrtcTotalDebitStr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.xrtcTotalDebitStr.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcTotalDebitStr.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcTotalDebitStr.ForeColor = System.Drawing.Color.Green;
            this.xrtcTotalDebitStr.Multiline = true;
            this.xrtcTotalDebitStr.Name = "xrtcTotalDebitStr";
            this.xrtcTotalDebitStr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcTotalDebitStr.StylePriority.UseBackColor = false;
            this.xrtcTotalDebitStr.StylePriority.UseBorderColor = false;
            this.xrtcTotalDebitStr.StylePriority.UseBorders = false;
            this.xrtcTotalDebitStr.StylePriority.UseFont = false;
            this.xrtcTotalDebitStr.StylePriority.UseForeColor = false;
            this.xrtcTotalDebitStr.StylePriority.UsePadding = false;
            this.xrtcTotalDebitStr.StylePriority.UseTextAlignment = false;
            this.xrtcTotalDebitStr.Text = "مدين";
            this.xrtcTotalDebitStr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcTotalDebitStr.Weight = 0.19723865877712032D;
            // 
            // xrtcTotalCreditStr
            // 
            this.xrtcTotalCreditStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(212)))), ((int)(((byte)(194)))));
            this.xrtcTotalCreditStr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.xrtcTotalCreditStr.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcTotalCreditStr.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcTotalCreditStr.ForeColor = System.Drawing.Color.Red;
            this.xrtcTotalCreditStr.Multiline = true;
            this.xrtcTotalCreditStr.Name = "xrtcTotalCreditStr";
            this.xrtcTotalCreditStr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcTotalCreditStr.StylePriority.UseBackColor = false;
            this.xrtcTotalCreditStr.StylePriority.UseBorderColor = false;
            this.xrtcTotalCreditStr.StylePriority.UseBorders = false;
            this.xrtcTotalCreditStr.StylePriority.UseFont = false;
            this.xrtcTotalCreditStr.StylePriority.UseForeColor = false;
            this.xrtcTotalCreditStr.StylePriority.UsePadding = false;
            this.xrtcTotalCreditStr.StylePriority.UseTextAlignment = false;
            this.xrtcTotalCreditStr.Text = "دائن";
            this.xrtcTotalCreditStr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcTotalCreditStr.Weight = 0.19723865877712032D;
            // 
            // xrtcCurrentBalanceStr
            // 
            this.xrtcCurrentBalanceStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(223)))), ((int)(((byte)(201)))));
            this.xrtcCurrentBalanceStr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.xrtcCurrentBalanceStr.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcCurrentBalanceStr.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcCurrentBalanceStr.ForeColor = System.Drawing.Color.Green;
            this.xrtcCurrentBalanceStr.Multiline = true;
            this.xrtcCurrentBalanceStr.Name = "xrtcCurrentBalanceStr";
            this.xrtcCurrentBalanceStr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcCurrentBalanceStr.StylePriority.UseBackColor = false;
            this.xrtcCurrentBalanceStr.StylePriority.UseBorderColor = false;
            this.xrtcCurrentBalanceStr.StylePriority.UseBorders = false;
            this.xrtcCurrentBalanceStr.StylePriority.UseFont = false;
            this.xrtcCurrentBalanceStr.StylePriority.UseForeColor = false;
            this.xrtcCurrentBalanceStr.StylePriority.UsePadding = false;
            this.xrtcCurrentBalanceStr.StylePriority.UseTextAlignment = false;
            this.xrtcCurrentBalanceStr.Text = "الرصيد الحالي";
            this.xrtcCurrentBalanceStr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcCurrentBalanceStr.Weight = 0.19723865877712032D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcTotalDebit,
            this.xrtcTotalCredit,
            this.xrtcCurrentBalance});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableRow5.StylePriority.UsePadding = false;
            this.xrTableRow5.Weight = 11.5D;
            // 
            // xrtcTotalDebit
            // 
            this.xrtcTotalDebit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.xrtcTotalDebit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.xrtcTotalDebit.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcTotalDebit.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcTotalDebit.ForeColor = System.Drawing.Color.Green;
            this.xrtcTotalDebit.Multiline = true;
            this.xrtcTotalDebit.Name = "xrtcTotalDebit";
            this.xrtcTotalDebit.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcTotalDebit.StylePriority.UseBackColor = false;
            this.xrtcTotalDebit.StylePriority.UseBorderColor = false;
            this.xrtcTotalDebit.StylePriority.UseBorders = false;
            this.xrtcTotalDebit.StylePriority.UseFont = false;
            this.xrtcTotalDebit.StylePriority.UseForeColor = false;
            this.xrtcTotalDebit.StylePriority.UsePadding = false;
            this.xrtcTotalDebit.StylePriority.UseTextAlignment = false;
            this.xrtcTotalDebit.Text = "xrtcTotalDebit";
            this.xrtcTotalDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcTotalDebit.TextFormatString = "{0:n2}";
            this.xrtcTotalDebit.Weight = 0.19723865877712032D;
            // 
            // xrtcTotalCredit
            // 
            this.xrtcTotalCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.xrtcTotalCredit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.xrtcTotalCredit.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcTotalCredit.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcTotalCredit.ForeColor = System.Drawing.Color.Red;
            this.xrtcTotalCredit.Multiline = true;
            this.xrtcTotalCredit.Name = "xrtcTotalCredit";
            this.xrtcTotalCredit.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcTotalCredit.StylePriority.UseBackColor = false;
            this.xrtcTotalCredit.StylePriority.UseBorderColor = false;
            this.xrtcTotalCredit.StylePriority.UseBorders = false;
            this.xrtcTotalCredit.StylePriority.UseFont = false;
            this.xrtcTotalCredit.StylePriority.UseForeColor = false;
            this.xrtcTotalCredit.StylePriority.UsePadding = false;
            this.xrtcTotalCredit.StylePriority.UseTextAlignment = false;
            this.xrtcTotalCredit.Text = "xrtcTotalCredit";
            this.xrtcTotalCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcTotalCredit.TextFormatString = "{0:n2}";
            this.xrtcTotalCredit.Weight = 0.19723865877712032D;
            // 
            // xrtcCurrentBalance
            // 
            this.xrtcCurrentBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.xrtcCurrentBalance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.xrtcCurrentBalance.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtcCurrentBalance.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcCurrentBalance.ForeColor = System.Drawing.Color.Green;
            this.xrtcCurrentBalance.Multiline = true;
            this.xrtcCurrentBalance.Name = "xrtcCurrentBalance";
            this.xrtcCurrentBalance.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 4, 3, 100F);
            this.xrtcCurrentBalance.StylePriority.UseBackColor = false;
            this.xrtcCurrentBalance.StylePriority.UseBorderColor = false;
            this.xrtcCurrentBalance.StylePriority.UseBorders = false;
            this.xrtcCurrentBalance.StylePriority.UseFont = false;
            this.xrtcCurrentBalance.StylePriority.UseForeColor = false;
            this.xrtcCurrentBalance.StylePriority.UsePadding = false;
            this.xrtcCurrentBalance.StylePriority.UseTextAlignment = false;
            this.xrtcCurrentBalance.Text = "xrtcCurrentBalance";
            this.xrtcCurrentBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcCurrentBalance.TextFormatString = "{0:n2}";
            this.xrtcCurrentBalance.Weight = 0.19723865877712032D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrTable3});
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00012F, 45.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(448.8932F, 18.83332F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "من تاريخ : [Parameters.parameterDtStart!yyyy/MM/dd]  إلى تاريخ : [Parameters.para" +
    "meterDtEnd!yyyy/MM/dd]";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel1.WordWrap = false;
            // 
            // xrTable3
            // 
            this.xrTable3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.xrTable3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable3.BorderWidth = 2F;
            this.xrTable3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 5, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(786.9166F, 35F);
            this.xrTable3.StylePriority.UseBorderColor = false;
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseBorderWidth = false;
            this.xrTable3.StylePriority.UseForeColor = false;
            this.xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcBalanceName,
            this.xrtcAccName,
            this.xrtcDate});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrtcBalanceName
            // 
            this.xrtcBalanceName.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 15F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcBalanceName.Name = "xrtcBalanceName";
            this.xrtcBalanceName.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrtcBalanceName.StylePriority.UseFont = false;
            this.xrtcBalanceName.StylePriority.UsePadding = false;
            this.xrtcBalanceName.Text = "إسم الحساب:";
            this.xrtcBalanceName.Weight = 0.303928957398214D;
            // 
            // xrtcAccName
            // 
            this.xrtcAccName.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 15F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcAccName.Multiline = true;
            this.xrtcAccName.Name = "xrtcAccName";
            this.xrtcAccName.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrtcAccName.StylePriority.UseFont = false;
            this.xrtcAccName.StylePriority.UsePadding = false;
            this.xrtcAccName.Weight = 1.3258752389374533D;
            // 
            // xrtcDate
            // 
            this.xrtcDate.Font = new DevExpress.Drawing.DXFont("Tahoma", 8.5F);
            this.xrtcDate.Name = "xrtcDate";
            this.xrtcDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrtcDate.StylePriority.UseFont = false;
            this.xrtcDate.StylePriority.UsePadding = false;
            this.xrtcDate.StylePriority.UseTextAlignment = false;
            this.xrtcDate.Text = "التاريخ : ";
            this.xrtcDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            this.xrtcDate.Weight = 0.370195803664333D;
            // 
            // parameterAccNo
            // 
            this.parameterAccNo.Description = "الحساب:";
            this.parameterAccNo.Name = "parameterAccNo";
            this.parameterAccNo.Type = typeof(long);
            this.parameterAccNo.ValueInfo = "0";
            dynamicListLookUpSettings1.DataMember = null;
            dynamicListLookUpSettings1.DataSource = this.tblBindingSource;
            dynamicListLookUpSettings1.DisplayMember = "accName";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.SortMember = null;
            dynamicListLookUpSettings1.ValueMember = "accNo";
            this.parameterAccNo.ValueSourceSettings = dynamicListLookUpSettings1;
            // 
            // parameterDtStart
            // 
            this.parameterDtStart.Description = "من تاريح:";
            this.parameterDtStart.Name = "parameterDtStart";
            this.parameterDtStart.Type = typeof(System.DateTime);
            // 
            // parameterDtEnd
            // 
            this.parameterDtEnd.Description = "إلى تاريخ:";
            this.parameterDtEnd.Name = "parameterDtEnd";
            this.parameterDtEnd.Type = typeof(System.DateTime);
            // 
            // ReportGeneralLedger
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblBindingSource});
            this.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(10, 10, 150, 75);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterAccNo,
            this.parameterDtStart,
            this.parameterDtEnd});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableBalanceV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrlHeader;
        public DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxBranch;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchNameEn;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddressEn;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchName;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddress;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel16;
        protected internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrtcBalanceName;
        private DevExpress.XtraReports.UI.XRTableCell xrtcAccName;
        private DevExpress.XtraReports.UI.XRTableCell xrtcDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter parameterAccNo;
        private System.Windows.Forms.BindingSource tblBindingSource;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtStart;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtEnd;
        private DevExpress.XtraReports.UI.XRTable xrTableBalanceV;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrtcTotalDebitStr;
        private DevExpress.XtraReports.UI.XRTableCell xrtcTotalCreditStr;
        private DevExpress.XtraReports.UI.XRTableCell xrtcCurrentBalanceStr;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrtcTotalDebit;
        private DevExpress.XtraReports.UI.XRTableCell xrtcTotalCredit;
        private DevExpress.XtraReports.UI.XRTableCell xrtcCurrentBalance;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        public DevExpress.XtraReports.UI.XRLine xrLine5;
    }
}
