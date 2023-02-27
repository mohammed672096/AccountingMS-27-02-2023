namespace AccountingMS
{
    partial class ReportCustomerSupplierBalance
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
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings2 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreportCustSuplBalanceData = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcBalanceName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcInvoiceName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabelBranchAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelBranchPhnNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddressEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchNameEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBoxBranch = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrlHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterAccId = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterShowInvoice = new DevExpress.XtraReports.Parameters.Parameter();
            this.EvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.OddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterInvoiceDetail = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterShowEntry = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterCash = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterShowProfit = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterShowCustDetail = new DevExpress.XtraReports.Parameters.Parameter();
            this.tblBalanceDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSupplyMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntrySubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parameterGroupUnioun = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterCombineSupNdEnt = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBalanceDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCustSuplBalanceData,
            this.xrTable3,
            this.xrLabel1});
            this.Detail.HeightF = 115F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrSubreportCustSuplBalanceData
            // 
            this.xrSubreportCustSuplBalanceData.LocationFloat = new DevExpress.Utils.PointFloat(10F, 80F);
            this.xrSubreportCustSuplBalanceData.Name = "xrSubreportCustSuplBalanceData";
            this.xrSubreportCustSuplBalanceData.SizeF = new System.Drawing.SizeF(787F, 23F);
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
            this.xrtcInvoiceName,
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
            this.xrtcBalanceName.Text = "كشف رصيد العميل :";
            this.xrtcBalanceName.Weight = 0.45239862762297911D;
            // 
            // xrtcInvoiceName
            // 
            this.xrtcInvoiceName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[accName]")});
            this.xrtcInvoiceName.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 15F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrtcInvoiceName.Multiline = true;
            this.xrtcInvoiceName.Name = "xrtcInvoiceName";
            this.xrtcInvoiceName.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrtcInvoiceName.StylePriority.UseFont = false;
            this.xrtcInvoiceName.StylePriority.UsePadding = false;
            this.xrtcInvoiceName.Weight = 1.1774055687126883D;
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
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelBranchAddress,
            this.xrLabelBranchName,
            this.xrLine5,
            this.xrLabelBranchPhnNo1,
            this.xrLabelBranchFaxNo1,
            this.xrLabelBranchMailBox1,
            this.xrLabelBranchMailBox2,
            this.xrLabelBranchFaxNo2,
            this.xrLabelBranchPhnNo2,
            this.xrLabelBranchAddressEn,
            this.xrLabelBranchNameEn,
            this.xrPictureBoxBranch,
            this.xrlHeader});
            this.TopMargin.HeightF = 150F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(8.958261F, 134.6407F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(787.9584F, 5.124924F);
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
            // xrPictureBoxBranch
            // 
            this.xrPictureBoxBranch.LocationFloat = new DevExpress.Utils.PointFloat(331.9763F, 11.64064F);
            this.xrPictureBoxBranch.Name = "xrPictureBoxBranch";
            this.xrPictureBoxBranch.SizeF = new System.Drawing.SizeF(127.0004F, 92.00004F);
            this.xrPictureBoxBranch.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
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
            this.xrlHeader.Text = "تقرير أرصدة العملاء";
            this.xrlHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrlHeader.WordWrap = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrPictureBox1,
            this.xrLabel16});
            this.BottomMargin.HeightF = 75F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // parameterAccId
            // 
            this.parameterAccId.Description = "العميل :";
            this.parameterAccId.MultiValue = true;
            this.parameterAccId.Name = "parameterAccId";
            this.parameterAccId.Type = typeof(int);
            this.parameterAccId.ValueInfo = "0";
            // 
            // parameterDtStart
            // 
            this.parameterDtStart.Description = "من تاريخ :";
            this.parameterDtStart.Name = "parameterDtStart";
            this.parameterDtStart.Type = typeof(System.DateTime);
            // 
            // parameterDtEnd
            // 
            this.parameterDtEnd.Description = "إلى تاريخ :";
            this.parameterDtEnd.Name = "parameterDtEnd";
            this.parameterDtEnd.Type = typeof(System.DateTime);
            // 
            // parameterShowInvoice
            // 
            this.parameterShowInvoice.Description = "عرض الفواتير :";
            this.parameterShowInvoice.Name = "parameterShowInvoice";
            this.parameterShowInvoice.Type = typeof(bool);
            this.parameterShowInvoice.ValueInfo = "True";
            // 
            // EvenStyle
            // 
            this.EvenStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.EvenStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(207)))), ((int)(((byte)(189)))));
            this.EvenStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.EvenStyle.BorderWidth = 1F;
            this.EvenStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.EvenStyle.ForeColor = System.Drawing.Color.Black;
            this.EvenStyle.Name = "EvenStyle";
            // 
            // OddStyle
            // 
            this.OddStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.OddStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(207)))), ((int)(((byte)(189)))));
            this.OddStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.OddStyle.BorderWidth = 1F;
            this.OddStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.OddStyle.ForeColor = System.Drawing.Color.Black;
            this.OddStyle.Name = "OddStyle";
            // 
            // parameterInvoiceDetail
            // 
            this.parameterInvoiceDetail.Description = "تفصيلي :";
            this.parameterInvoiceDetail.Name = "parameterInvoiceDetail";
            this.parameterInvoiceDetail.Type = typeof(bool);
            this.parameterInvoiceDetail.ValueInfo = "False";
            // 
            // parameterShowEntry
            // 
            this.parameterShowEntry.Description = "عرض السندات :";
            this.parameterShowEntry.Name = "parameterShowEntry";
            this.parameterShowEntry.Type = typeof(bool);
            this.parameterShowEntry.ValueInfo = "True";
            // 
            // parameterCash
            // 
            this.parameterCash.Description = "طريقة الدفع :";
            this.parameterCash.Name = "parameterCash";
            this.parameterCash.Type = typeof(bool);
            this.parameterCash.ValueInfo = "False";
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(false, "أجل"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(true, "نقد + أجل"));
            this.parameterCash.ValueSourceSettings = staticListLookUpSettings1;
            // 
            // parameterShowProfit
            // 
            this.parameterShowProfit.Description = "عرض الربح :";
            this.parameterShowProfit.Name = "parameterShowProfit";
            this.parameterShowProfit.Type = typeof(bool);
            this.parameterShowProfit.ValueInfo = "False";
            // 
            // parameterShowCustDetail
            // 
            this.parameterShowCustDetail.Description = "بيانات العميل :";
            this.parameterShowCustDetail.Name = "parameterShowCustDetail";
            this.parameterShowCustDetail.Type = typeof(bool);
            this.parameterShowCustDetail.ValueInfo = "False";
            staticListLookUpSettings2.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(true, "تفصيلي"));
            staticListLookUpSettings2.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(false, "مختصر"));
            this.parameterShowCustDetail.ValueSourceSettings = staticListLookUpSettings2;
            // 
            // tblBalanceDataBindingSource
            // 
            this.tblBalanceDataBindingSource.DataSource = typeof(AccountingMS.ClsBalanceColumnsData);
            // 
            // tblSupplyMainBindingSource
            // 
            this.tblSupplyMainBindingSource.DataSource = typeof(AccountingMS.tblSupplyMain);
            // 
            // tblEntrySubBindingSource
            // 
            this.tblEntrySubBindingSource.DataSource = typeof(AccountingMS.tblEntrySub);
            // 
            // tblAccountBindingSource
            // 
            this.tblAccountBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // parameterGroupUnioun
            // 
            this.parameterGroupUnioun.Description = "عرض مدمج :";
            this.parameterGroupUnioun.Name = "parameterGroupUnioun";
            this.parameterGroupUnioun.Type = typeof(bool);
            this.parameterGroupUnioun.ValueInfo = "True";
            // 
            // parameterCombineSupNdEnt
            // 
            this.parameterCombineSupNdEnt.Description = "دمج الفواتير والسندات";
            this.parameterCombineSupNdEnt.Name = "parameterCombineSupNdEnt";
            this.parameterCombineSupNdEnt.Type = typeof(bool);
            this.parameterCombineSupNdEnt.ValueInfo = "False";
            // 
            // ReportCustomerSupplierBalance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblBalanceDataBindingSource,
            this.tblSupplyMainBindingSource,
            this.tblEntrySubBindingSource,
            this.tblAccountBindingSource});
            this.DataSource = this.tblAccountBindingSource;
            this.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(10, 10, 150, 75);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterAccId,
            this.parameterDtStart,
            this.parameterDtEnd,
            this.parameterShowCustDetail,
            this.parameterShowInvoice,
            this.parameterInvoiceDetail,
            this.parameterCash,
            this.parameterShowProfit,
            this.parameterShowEntry,
            this.parameterCombineSupNdEnt,
            this.parameterGroupUnioun});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.EvenStyle,
            this.OddStyle});
            this.Version = "21.1";
            this.ParametersRequestSubmit += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.ReportCustomerSupplierBalance_ParametersRequestSubmit);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBalanceDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddress;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchName;
        public DevExpress.XtraReports.UI.XRLine xrLine5;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox1;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddressEn;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchNameEn;
        public DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxBranch;
        private DevExpress.XtraReports.UI.XRLabel xrlHeader;
        private DevExpress.XtraReports.Parameters.Parameter parameterAccId;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtStart;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtEnd;
        private DevExpress.XtraReports.Parameters.Parameter parameterShowInvoice;
        private System.Windows.Forms.BindingSource tblBalanceDataBindingSource;
        private System.Windows.Forms.BindingSource tblSupplyMainBindingSource;
        private System.Windows.Forms.BindingSource tblEntrySubBindingSource;
        private DevExpress.XtraReports.UI.XRControlStyle EvenStyle;
        private DevExpress.XtraReports.UI.XRControlStyle OddStyle;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel22;
        protected internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.Parameters.Parameter parameterInvoiceDetail;
        private DevExpress.XtraReports.Parameters.Parameter parameterShowEntry;
        private System.Windows.Forms.BindingSource tblAccountBindingSource;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreportCustSuplBalanceData;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrtcBalanceName;
        private DevExpress.XtraReports.UI.XRTableCell xrtcInvoiceName;
        private DevExpress.XtraReports.UI.XRTableCell xrtcDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter parameterCash;
        private DevExpress.XtraReports.Parameters.Parameter parameterShowProfit;
        private DevExpress.XtraReports.Parameters.Parameter parameterShowCustDetail;
        private DevExpress.XtraReports.Parameters.Parameter parameterGroupUnioun;
        private DevExpress.XtraReports.Parameters.Parameter parameterCombineSupNdEnt;
    }
}
