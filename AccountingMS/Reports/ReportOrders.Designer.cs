namespace AccountingMS
{
    partial class ReportOrders
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.tblOrderTypeBindingSourceParameter = new System.Windows.Forms.BindingSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabelBranchMailBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBoxBranch = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabelBranchNameEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddressEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrSubreportOrderaMaster = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameterOrderType = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterOrderDetail = new DevExpress.XtraReports.Parameters.Parameter();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrlDate = new DevExpress.XtraReports.UI.XRLabel();
            this.tblOrderTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderTypeBindingSourceParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tblOrderTypeBindingSourceParameter
            // 
            this.tblOrderTypeBindingSourceParameter.DataSource = typeof(tblOrderType);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelBranchMailBox1,
            this.xrLabelBranchFaxNo1,
            this.xrLabelBranchPhnNo1,
            this.xrLabelBranchAddress,
            this.xrLabelBranchName,
            this.xrlHeader,
            this.xrPictureBoxBranch,
            this.xrLabelBranchNameEn,
            this.xrLabelBranchAddressEn,
            this.xrLabelBranchPhnNo2,
            this.xrLabelBranchFaxNo2,
            this.xrLabelBranchMailBox2,
            this.xrLine5});
            this.TopMargin.HeightF = 150F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrLabelBranchMailBox1
            // 
            this.xrLabelBranchMailBox1.AutoWidth = true;
            this.xrLabelBranchMailBox1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.xrLabelBranchMailBox1.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 102F);
            this.xrLabelBranchMailBox1.Name = "xrLabelBranchMailBox1";
            this.xrLabelBranchMailBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox1.SizeF = new System.Drawing.SizeF(100F, 22.99999F);
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
            this.xrLabelBranchFaxNo1.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 79.00003F);
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
            this.xrLabelBranchPhnNo1.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 56.00001F);
            this.xrLabelBranchPhnNo1.Name = "xrLabelBranchPhnNo1";
            this.xrLabelBranchPhnNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo1.SizeF = new System.Drawing.SizeF(100F, 22.99999F);
            this.xrLabelBranchPhnNo1.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo1.Text = "xrLabelBranchName";
            this.xrLabelBranchPhnNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchPhnNo1.WordWrap = false;
            // 
            // xrLabelBranchAddress
            // 
            this.xrLabelBranchAddress.AutoWidth = true;
            this.xrLabelBranchAddress.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchAddress.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 33.00002F);
            this.xrLabelBranchAddress.Name = "xrLabelBranchAddress";
            this.xrLabelBranchAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddress.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchAddress.StylePriority.UseFont = false;
            this.xrLabelBranchAddress.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddress.Text = "xrLabelBranchName";
            this.xrLabelBranchAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchAddress.WordWrap = false;
            // 
            // xrLabelBranchName
            // 
            this.xrLabelBranchName.AutoWidth = true;
            this.xrLabelBranchName.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchName.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 10.00001F);
            this.xrLabelBranchName.Name = "xrLabelBranchName";
            this.xrLabelBranchName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchName.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabelBranchName.StylePriority.UseFont = false;
            this.xrLabelBranchName.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchName.Text = "xrLabelBranchName";
            this.xrLabelBranchName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchName.WordWrap = false;
            // 
            // xrlHeader
            // 
            this.xrlHeader.AutoWidth = true;
            this.xrlHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrlHeader.ForeColor = System.Drawing.Color.Navy;
            this.xrlHeader.LocationFloat = new DevExpress.Utils.PointFloat(333.3229F, 110F);
            this.xrlHeader.Name = "xrlHeader";
            this.xrlHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlHeader.SizeF = new System.Drawing.SizeF(127.0004F, 23F);
            this.xrlHeader.StylePriority.UseFont = false;
            this.xrlHeader.StylePriority.UseForeColor = false;
            this.xrlHeader.StylePriority.UseTextAlignment = false;
            this.xrlHeader.Text = "تقرير الطلبات";
            this.xrlHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrlHeader.WordWrap = false;
            // 
            // xrPictureBoxBranch
            // 
            this.xrPictureBoxBranch.LocationFloat = new DevExpress.Utils.PointFloat(333.3229F, 10.00001F);
            this.xrPictureBoxBranch.Name = "xrPictureBoxBranch";
            this.xrPictureBoxBranch.SizeF = new System.Drawing.SizeF(127.0004F, 92.00004F);
            this.xrPictureBoxBranch.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabelBranchNameEn
            // 
            this.xrLabelBranchNameEn.AutoWidth = true;
            this.xrLabelBranchNameEn.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabelBranchNameEn.LocationFloat = new DevExpress.Utils.PointFloat(699.0004F, 10.00004F);
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
            this.xrLabelBranchAddressEn.LocationFloat = new DevExpress.Utils.PointFloat(699.0004F, 33.00002F);
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
            this.xrLabelBranchPhnNo2.LocationFloat = new DevExpress.Utils.PointFloat(699.0004F, 56.00004F);
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
            this.xrLabelBranchFaxNo2.LocationFloat = new DevExpress.Utils.PointFloat(699.0004F, 79.00006F);
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
            this.xrLabelBranchMailBox2.LocationFloat = new DevExpress.Utils.PointFloat(699.0004F, 102.0001F);
            this.xrLabelBranchMailBox2.Name = "xrLabelBranchMailBox2";
            this.xrLabelBranchMailBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox2.SizeF = new System.Drawing.SizeF(100F, 23.00001F);
            this.xrLabelBranchMailBox2.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox2.Text = "xrLabelBranchName";
            this.xrLabelBranchMailBox2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchMailBox2.WordWrap = false;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(10.00029F, 133F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(788.9996F, 5.124985F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrPictureBox1,
            this.xrLabel16});
            this.BottomMargin.HeightF = 75F;
            this.BottomMargin.Name = "BottomMargin";
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
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrSubreportOrderaMaster});
            this.Detail.KeepTogether = true;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            // 
            // xrTable2
            // 
            this.xrTable2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.xrTable2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable2.BorderWidth = 2F;
            this.xrTable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(787F, 30F);
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseForeColor = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 15F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "كشف فواتير";
            this.xrTableCell2.Weight = 0.41931384036925717D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ordCaption]")});
            this.xrTableCell4.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 15F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.Weight = 0.51461241357359833D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "من تاريخ : [Parameters.parameterDtStart!yyyy/MM/dd]  إلى تاريخ : [Parameters.para" +
    "meterDtEnd!yyyy/MM/dd]";
            this.xrTableCell5.Weight = 2.0660737460571443D;
            // 
            // xrSubreportOrderaMaster
            // 
            this.xrSubreportOrderaMaster.LocationFloat = new DevExpress.Utils.PointFloat(10F, 50F);
            this.xrSubreportOrderaMaster.Name = "xrSubreportOrderaMaster";
            this.xrSubreportOrderaMaster.SizeF = new System.Drawing.SizeF(787F, 23F);
            // 
            // parameterOrderType
            // 
            this.parameterOrderType.AllowNull = true;
            this.parameterOrderType.Description = "طلبات: ";
            dynamicListLookUpSettings1.DataSource = this.tblOrderTypeBindingSourceParameter;
            dynamicListLookUpSettings1.DisplayMember = "ordCaption";
            dynamicListLookUpSettings1.ValueMember = "ordStatus";
            this.parameterOrderType.LookUpSettings = dynamicListLookUpSettings1;
            this.parameterOrderType.MultiValue = true;
            this.parameterOrderType.Name = "parameterOrderType";
            this.parameterOrderType.Type = typeof(short);
            // 
            // parameterDtStart
            // 
            this.parameterDtStart.Description = "من تاريخ:";
            this.parameterDtStart.Name = "parameterDtStart";
            this.parameterDtStart.Type = typeof(System.DateTime);
            // 
            // parameterDtEnd
            // 
            this.parameterDtEnd.Description = "إلى تاريخ: ";
            this.parameterDtEnd.Name = "parameterDtEnd";
            this.parameterDtEnd.Type = typeof(System.DateTime);
            // 
            // parameterOrderDetail
            // 
            this.parameterOrderDetail.Description = "تفصيلي: ";
            this.parameterOrderDetail.Name = "parameterOrderDetail";
            this.parameterOrderDetail.Type = typeof(bool);
            this.parameterOrderDetail.ValueInfo = "True";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlDate});
            this.GroupHeader1.HeightF = 30F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrlDate
            // 
            this.xrlDate.AutoWidth = true;
            this.xrlDate.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.xrlDate.LocationFloat = new DevExpress.Utils.PointFloat(698.9171F, 0F);
            this.xrlDate.Name = "xrlDate";
            this.xrlDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlDate.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrlDate.StylePriority.UseFont = false;
            this.xrlDate.Text = "التاريخ : ";
            this.xrlDate.WordWrap = false;
            // 
            // tblOrderTypeBindingSource
            // 
            this.tblOrderTypeBindingSource.DataSource = typeof(tblOrderType);
            // 
            // ReportOrders
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblOrderTypeBindingSource,
            this.tblOrderTypeBindingSourceParameter});
            this.DataSource = this.tblOrderTypeBindingSource;
            this.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(10, 10, 150, 75);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterOrderType,
            this.parameterDtStart,
            this.parameterDtEnd,
            this.parameterOrderDetail});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderTypeBindingSourceParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddress;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchName;
        private DevExpress.XtraReports.UI.XRLabel xrlHeader;
        internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxBranch;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchNameEn;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddressEn;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo2;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo2;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox2;
        public DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.Parameters.Parameter parameterOrderType;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtStart;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtEnd;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel22;
        protected internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private System.Windows.Forms.BindingSource tblOrderTypeBindingSource;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreportOrderaMaster;
        private DevExpress.XtraReports.Parameters.Parameter parameterOrderDetail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrlDate;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private System.Windows.Forms.BindingSource tblOrderTypeBindingSourceParameter;
    }
}
