namespace AccountingMS
{
    partial class ReportSalePurchase
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
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.tblUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubRprtSalePurchaseDetail = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrTableUser = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcUserSalePurchase = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcUserId = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelBranchNameEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddressEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBoxBranch = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabelBranchMailBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.invoiceInfoTable = new DevExpress.XtraReports.UI.XRTable();
            this.invoiceInfoTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellMain = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceInfoTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.totalCaption2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceDateCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceNumberCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceInfoTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.total2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellCurrency = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.baseControlStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.evenDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.oddDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterDateStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterCurrency = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterCashType = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterUserId = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.tblUserDataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceInfoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tblUserBindingSource
            // 
            this.tblUserBindingSource.DataSource = typeof(AccountingMS.tblUser);
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubRprtSalePurchaseDetail,
            this.xrTableUser});
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry;
            this.Detail.StyleName = "baseControlStyle";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrSubRprtSalePurchaseDetail
            // 
            this.xrSubRprtSalePurchaseDetail.Name = "xrSubRprtSalePurchaseDetail";
            // 
            // xrTableUser
            // 
            this.xrTableUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.xrTableUser.BorderColor = System.Drawing.Color.White;
            this.xrTableUser.ForeColor = System.Drawing.Color.White;
            this.xrTableUser.Name = "xrTableUser";
            this.xrTableUser.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTableUser.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTableUser.StylePriority.UseBackColor = false;
            this.xrTableUser.StylePriority.UseBorderColor = false;
            this.xrTableUser.StylePriority.UseForeColor = false;
            this.xrTableUser.StylePriority.UseTextAlignment = false;
            this.xrTableUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcUserSalePurchase,
            this.xrtcUserId});
            this.xrTableRow2.Name = "xrTableRow2";
            // 
            // xrtcUserSalePurchase
            // 
            this.xrtcUserSalePurchase.Multiline = true;
            this.xrtcUserSalePurchase.Name = "xrtcUserSalePurchase";
            this.xrtcUserSalePurchase.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrtcUserSalePurchase.StylePriority.UseFont = false;
            this.xrtcUserSalePurchase.StylePriority.UsePadding = false;
            // 
            // xrtcUserId
            // 
            this.xrtcUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrtcUserId.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrtcUserId.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[id]")});
            this.xrtcUserId.Multiline = true;
            this.xrtcUserId.Name = "xrtcUserId";
            this.xrtcUserId.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrtcUserId.StylePriority.UseBackColor = false;
            this.xrtcUserId.StylePriority.UseBorders = false;
            this.xrtcUserId.StylePriority.UseFont = false;
            this.xrtcUserId.StylePriority.UsePadding = false;
            this.xrtcUserId.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.xrtcUserId_BeforePrint);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine5,
            this.xrLabelBranchNameEn,
            this.xrLabelBranchAddressEn,
            this.xrLabelBranchPhnNo2,
            this.xrLabelBranchFaxNo2,
            this.xrLabelBranchMailBox2,
            this.xrPictureBoxBranch,
            this.xrLabelBranchMailBox1,
            this.xrLabelBranchFaxNo1,
            this.xrLabelBranchPhnNo1,
            this.xrLabelBranchAddress,
            this.xrLabelBranchName,
            this.xrLabel3,
            this.xrLabel17});
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseBackColor = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine5
            // 
            this.xrLine5.Name = "xrLine5";
            // 
            // xrLabelBranchNameEn
            // 
            this.xrLabelBranchNameEn.AutoWidth = true;
            this.xrLabelBranchNameEn.Name = "xrLabelBranchNameEn";
            this.xrLabelBranchNameEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchNameEn.StylePriority.UseFont = false;
            this.xrLabelBranchNameEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchNameEn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchNameEn.WordWrap = false;
            // 
            // xrLabelBranchAddressEn
            // 
            this.xrLabelBranchAddressEn.AutoWidth = true;
            this.xrLabelBranchAddressEn.Name = "xrLabelBranchAddressEn";
            this.xrLabelBranchAddressEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddressEn.StylePriority.UseFont = false;
            this.xrLabelBranchAddressEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddressEn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchAddressEn.WordWrap = false;
            // 
            // xrLabelBranchPhnNo2
            // 
            this.xrLabelBranchPhnNo2.AutoWidth = true;
            this.xrLabelBranchPhnNo2.Name = "xrLabelBranchPhnNo2";
            this.xrLabelBranchPhnNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo2.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchPhnNo2.WordWrap = false;
            // 
            // xrLabelBranchFaxNo2
            // 
            this.xrLabelBranchFaxNo2.AutoWidth = true;
            this.xrLabelBranchFaxNo2.Name = "xrLabelBranchFaxNo2";
            this.xrLabelBranchFaxNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo2.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchFaxNo2.WordWrap = false;
            // 
            // xrLabelBranchMailBox2
            // 
            this.xrLabelBranchMailBox2.AutoWidth = true;
            this.xrLabelBranchMailBox2.Name = "xrLabelBranchMailBox2";
            this.xrLabelBranchMailBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox2.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBranchMailBox2.WordWrap = false;
            // 
            // xrPictureBoxBranch
            // 
            this.xrPictureBoxBranch.Name = "xrPictureBoxBranch";
            this.xrPictureBoxBranch.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabelBranchMailBox1
            // 
            this.xrLabelBranchMailBox1.AutoWidth = true;
            this.xrLabelBranchMailBox1.Name = "xrLabelBranchMailBox1";
            this.xrLabelBranchMailBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox1.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchMailBox1.WordWrap = false;
            // 
            // xrLabelBranchFaxNo1
            // 
            this.xrLabelBranchFaxNo1.AutoWidth = true;
            this.xrLabelBranchFaxNo1.Name = "xrLabelBranchFaxNo1";
            this.xrLabelBranchFaxNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo1.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchFaxNo1.WordWrap = false;
            // 
            // xrLabelBranchPhnNo1
            // 
            this.xrLabelBranchPhnNo1.AutoWidth = true;
            this.xrLabelBranchPhnNo1.Name = "xrLabelBranchPhnNo1";
            this.xrLabelBranchPhnNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo1.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchPhnNo1.WordWrap = false;
            // 
            // xrLabelBranchAddress
            // 
            this.xrLabelBranchAddress.AutoWidth = true;
            this.xrLabelBranchAddress.Name = "xrLabelBranchAddress";
            this.xrLabelBranchAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddress.StylePriority.UseFont = false;
            this.xrLabelBranchAddress.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchAddress.WordWrap = false;
            // 
            // xrLabelBranchName
            // 
            this.xrLabelBranchName.AutoWidth = true;
            this.xrLabelBranchName.Name = "xrLabelBranchName";
            this.xrLabelBranchName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchName.StylePriority.UseFont = false;
            this.xrLabelBranchName.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabelBranchName.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.AutoWidth = true;
            this.xrLabel3.ForeColor = System.Drawing.Color.Navy;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel3.WordWrap = false;
            // 
            // xrLabel17
            // 
            this.xrLabel17.AutoWidth = true;
            this.xrLabel17.ForeColor = System.Drawing.Color.Navy;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel17.WordWrap = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrLabel16,
            this.xrPictureBox1});
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StyleName = "baseControlStyle";
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(global::AccountingMS.Properties.Resources.BTech, true);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.StylePriority.UseBorderColor = false;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            this.xrPictureBox1.StylePriority.UsePadding = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("InvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.StyleName = "baseControlStyle";
            this.GroupHeader2.StylePriority.UseBackColor = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.Empty;
            this.xrPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.BorderWidth = 3F;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.invoiceInfoTable});
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.StylePriority.UseBackColor = false;
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            this.xrPanel1.StylePriority.UseBorderWidth = false;
            // 
            // invoiceInfoTable
            // 
            this.invoiceInfoTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.invoiceInfoTable.Name = "invoiceInfoTable";
            this.invoiceInfoTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.invoiceInfoTableRow1,
            this.invoiceInfoTableRow2,
            this.invoiceInfoTableRow3});
            this.invoiceInfoTable.StylePriority.UseBackColor = false;
            // 
            // invoiceInfoTableRow1
            // 
            this.invoiceInfoTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellMain});
            this.invoiceInfoTableRow1.Name = "invoiceInfoTableRow1";
            // 
            // xrTableCellMain
            // 
            this.xrTableCellMain.BorderColor = System.Drawing.Color.LightGray;
            this.xrTableCellMain.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCellMain.BorderWidth = 5F;
            this.xrTableCellMain.Name = "xrTableCellMain";
            this.xrTableCellMain.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCellMain.StylePriority.UseBackColor = false;
            this.xrTableCellMain.StylePriority.UseBorderColor = false;
            this.xrTableCellMain.StylePriority.UseBorders = false;
            this.xrTableCellMain.StylePriority.UseBorderWidth = false;
            this.xrTableCellMain.StylePriority.UseFont = false;
            this.xrTableCellMain.StylePriority.UseForeColor = false;
            this.xrTableCellMain.StylePriority.UsePadding = false;
            this.xrTableCellMain.StylePriority.UseTextAlignment = false;
            this.xrTableCellMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // invoiceInfoTableRow2
            // 
            this.invoiceInfoTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.totalCaption2,
            this.invoiceDateCaption,
            this.invoiceNumberCaption});
            this.invoiceInfoTableRow2.Name = "invoiceInfoTableRow2";
            // 
            // totalCaption2
            // 
            this.totalCaption2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.totalCaption2.ForeColor = System.Drawing.Color.Gray;
            this.totalCaption2.Name = "totalCaption2";
            this.totalCaption2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 5, 5, 100F);
            this.totalCaption2.RowSpan = 2;
            this.totalCaption2.StylePriority.UseBackColor = false;
            this.totalCaption2.StylePriority.UseBorderColor = false;
            this.totalCaption2.StylePriority.UseBorders = false;
            this.totalCaption2.StylePriority.UseFont = false;
            this.totalCaption2.StylePriority.UseForeColor = false;
            this.totalCaption2.StylePriority.UsePadding = false;
            this.totalCaption2.StylePriority.UseTextAlignment = false;
            this.totalCaption2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // invoiceDateCaption
            // 
            this.invoiceDateCaption.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.invoiceDateCaption.BorderWidth = 1F;
            this.invoiceDateCaption.ForeColor = System.Drawing.Color.Gray;
            this.invoiceDateCaption.Name = "invoiceDateCaption";
            this.invoiceDateCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.invoiceDateCaption.StylePriority.UseBackColor = false;
            this.invoiceDateCaption.StylePriority.UseBorders = false;
            this.invoiceDateCaption.StylePriority.UseBorderWidth = false;
            this.invoiceDateCaption.StylePriority.UseFont = false;
            this.invoiceDateCaption.StylePriority.UseForeColor = false;
            this.invoiceDateCaption.StylePriority.UsePadding = false;
            this.invoiceDateCaption.StylePriority.UseTextAlignment = false;
            this.invoiceDateCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // invoiceNumberCaption
            // 
            this.invoiceNumberCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.invoiceNumberCaption.BorderWidth = 1F;
            this.invoiceNumberCaption.ForeColor = System.Drawing.Color.Gray;
            this.invoiceNumberCaption.Name = "invoiceNumberCaption";
            this.invoiceNumberCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.invoiceNumberCaption.StylePriority.UseBackColor = false;
            this.invoiceNumberCaption.StylePriority.UseBorderColor = false;
            this.invoiceNumberCaption.StylePriority.UseBorders = false;
            this.invoiceNumberCaption.StylePriority.UseBorderWidth = false;
            this.invoiceNumberCaption.StylePriority.UseFont = false;
            this.invoiceNumberCaption.StylePriority.UseForeColor = false;
            this.invoiceNumberCaption.StylePriority.UsePadding = false;
            this.invoiceNumberCaption.StylePriority.UseTextAlignment = false;
            this.invoiceNumberCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // invoiceInfoTableRow3
            // 
            this.invoiceInfoTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.total2,
            this.xrTableCellCurrency,
            this.xrTableCellDate});
            this.invoiceInfoTableRow3.Name = "invoiceInfoTableRow3";
            this.invoiceInfoTableRow3.StylePriority.UseFont = false;
            // 
            // total2
            // 
            this.total2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.total2.Name = "total2";
            this.total2.StylePriority.UseBackColor = false;
            this.total2.StylePriority.UseBorderColor = false;
            this.total2.StylePriority.UseBorders = false;
            this.total2.StylePriority.UseFont = false;
            this.total2.StylePriority.UseTextAlignment = false;
            this.total2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableCellCurrency
            // 
            this.xrTableCellCurrency.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCellCurrency.BorderWidth = 1F;
            this.xrTableCellCurrency.Name = "xrTableCellCurrency";
            this.xrTableCellCurrency.StylePriority.UseBackColor = false;
            this.xrTableCellCurrency.StylePriority.UseBorders = false;
            this.xrTableCellCurrency.StylePriority.UseBorderWidth = false;
            this.xrTableCellCurrency.StylePriority.UseFont = false;
            this.xrTableCellCurrency.StylePriority.UseTextAlignment = false;
            this.xrTableCellCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCellDate
            // 
            this.xrTableCellDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrTableCellDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCellDate.Name = "xrTableCellDate";
            this.xrTableCellDate.StylePriority.UseBackColor = false;
            this.xrTableCellDate.StylePriority.UseBorderColor = false;
            this.xrTableCellDate.StylePriority.UseBorders = false;
            this.xrTableCellDate.StylePriority.UseFont = false;
            this.xrTableCellDate.StylePriority.UseTextAlignment = false;
            this.xrTableCellDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // baseControlStyle
            // 
            this.baseControlStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.baseControlStyle.Name = "baseControlStyle";
            this.baseControlStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // evenDetailStyle
            // 
            this.evenDetailStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.evenDetailStyle.Name = "evenDetailStyle";
            this.evenDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // oddDetailStyle
            // 
            this.oddDetailStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.oddDetailStyle.Name = "oddDetailStyle";
            this.oddDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // parameterDateStart
            // 
            this.parameterDateStart.Name = "parameterDateStart";
            this.parameterDateStart.Type = typeof(System.DateTime);
            // 
            // parameterDateEnd
            // 
            this.parameterDateEnd.Name = "parameterDateEnd";
            this.parameterDateEnd.Type = typeof(System.DateTime);
            // 
            // parameterCurrency
            // 
            this.parameterCurrency.Name = "parameterCurrency";
            this.parameterCurrency.Type = typeof(short);
            this.parameterCurrency.ValueInfo = "1";
            // 
            // parameterCashType
            // 
            this.parameterCashType.Name = "parameterCashType";
            this.parameterCashType.Type = typeof(short);
            this.parameterCashType.ValueInfo = "1";
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(((short)(1)), "نقد"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(((short)(2)), "آجل"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(((short)(3)), "نقد + آجل"));
            this.parameterCashType.ValueSourceSettings = staticListLookUpSettings1;
            // 
            // parameterUserId
            // 
            this.parameterUserId.MultiValue = true;
            this.parameterUserId.Name = "parameterUserId";
            this.parameterUserId.Type = typeof(short);
            dynamicListLookUpSettings1.DataSource = this.tblUserBindingSource;
            dynamicListLookUpSettings1.DisplayMember = "userName";
            dynamicListLookUpSettings1.ValueMember = "id";
            this.parameterUserId.ValueSourceSettings = dynamicListLookUpSettings1;
            // 
            // ReportFooter
            // 
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // tblUserDataSource
            // 
            this.tblUserDataSource.DataSource = typeof(AccountingMS.tblUser);
            // 
            // ReportSalePurchase
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader2,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblUserDataSource,
            this.tblUserBindingSource});
            this.DataSource = this.tblUserDataSource;
            this.LocalizationItems.AddRange(new DevExpress.XtraReports.Localization.LocalizationItem[] {
            new DevExpress.XtraReports.Localization.LocalizationItem(this.BottomMargin, "Default", "HeightF", 75F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.Detail, "Default", "HeightF", 78F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.GroupHeader2, "Default", "HeightF", 143.2916F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceDateCaption, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceDateCaption, "Default", "Text", "العملة"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceDateCaption, "en", "Text", "Currency"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceDateCaption, "Default", "Weight", 0.57997904386578725D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTable, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(4.00006F, 3.999996F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTable, "Default", "SizeF", new System.Drawing.SizeF(779F, 105F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTableRow1, "Default", "Weight", 0.86014172164636638D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTableRow2, "Default", "Weight", 0.28671391126730511D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTableRow3, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 12F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceInfoTableRow3, "Default", "Weight", 0.35839234456675434D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceNumberCaption, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceNumberCaption, "Default", "Text", "تاريخ التقرير"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceNumberCaption, "en", "Text", "Date of the report"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.invoiceNumberCaption, "Default", "Weight", 0.57997904386578725D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.parameterCashType, "Default", "Description", "طريقة الدفع:"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.parameterCurrency, "Default", "Description", "العملة"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.parameterDateEnd, "Default", "Description", "إلى تاريخ:"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.parameterDateStart, "Default", "Description", "من تاريخ:"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.parameterUserId, "Default", "Description", "المستخدمين :"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "Margins", new DevExpress.Drawing.DXMargins(10, 10, 150, 75)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "PaperKind", System.Drawing.Printing.PaperKind.A4),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.TopMargin, "Default", "HeightF", 150F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.total2, "Default", "Text", "$0.00"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.total2, "Default", "TextFormatString", "{0:$0.00}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.total2, "Default", "Weight", 1.4815969112165046D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.totalCaption2, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.totalCaption2, "Default", "Text", "من تاريخ : [Parameters.parameterDateStart!yyyy/MM/dd]  إلى تاريخ : [Parameters.pa" +
                    "rameterDateEnd!yyyy/MM/dd]"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.totalCaption2, "en", "Text", "Date From : [Parameters.parameterDateStart!yyyy/MM/dd]  Date To : [Parameters.par" +
                    "ameterDateEnd!yyyy/MM/dd]"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.totalCaption2, "Default", "Weight", 1.4815969112165046D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel16, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel16, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(533.2917F, 23.79169F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel16, "Default", "SizeF", new System.Drawing.SizeF(267.7083F, 40.20831F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel16, "Default", "Text", "B-Technology Accounting Mangment System\r\nTel: +967-777-299-175"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(340.7494F, 110.9375F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "en", "LocationFloat", new DevExpress.Utils.PointFloat(245.8745F, 110.9375F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "Default", "SizeF", new System.Drawing.SizeF(127.0004F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "en", "SizeF", new System.Drawing.SizeF(320.7504F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "Default", "Text", "تقرير فواتير المشتريات"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel17, "en", "Text", "Purchase invoice report"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel22, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel22, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(13.99994F, 23.79169F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel22, "Default", "SizeF", new System.Drawing.SizeF(267.7083F, 40.20831F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel22, "Default", "Text", "Copy rights B-Technology"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(340.7494F, 110.9376F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "en", "LocationFloat", new DevExpress.Utils.PointFloat(245.8743F, 110.9376F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "Default", "SizeF", new System.Drawing.SizeF(127.0004F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "en", "SizeF", new System.Drawing.SizeF(320.7505F, 23.00002F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "Default", "Text", "تقرير فواتير المبيعات"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "en", "Text", "Sales invoice report"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel3, "Default", "Visible", false),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddress, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddress, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999974F, 33.00002F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddress, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddress, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddressEn, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddressEn, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(696.9166F, 32.99999F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddressEn, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchAddressEn, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo1, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999974F, 79.00003F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo1, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo1, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo2, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(696.9166F, 79.00006F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo2, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchFaxNo2, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox1, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999974F, 102F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox1, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox1, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox2, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(696.9166F, 102F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox2, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchMailBox2, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchName, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchName, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999974F, 10.00001F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchName, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchName, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchNameEn, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchNameEn, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(696.9166F, 10.00001F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchNameEn, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchNameEn, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo1, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999974F, 56.00001F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo1, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo1, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo2, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(696.9166F, 56.00001F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo2, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabelBranchPhnNo2, "Default", "Text", "xrLabelBranchName"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLine5, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(8.958261F, 134.6407F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLine5, "Default", "SizeF", new System.Drawing.SizeF(787.9584F, 5.124924F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPanel1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999879F, 10.00001F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPanel1, "Default", "SizeF", new System.Drawing.SizeF(787F, 113F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPictureBox1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(369.7497F, 10.85129F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPictureBox1, "Default", "SizeF", new System.Drawing.SizeF(100F, 60.41666F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPictureBoxBranch, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(340.7494F, 10.93752F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrPictureBoxBranch, "Default", "SizeF", new System.Drawing.SizeF(127.0004F, 92.00004F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrSubRprtSalePurchaseDetail, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(10F, 55F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrSubRprtSalePurchaseDetail, "Default", "SizeF", new System.Drawing.SizeF(787F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellCurrency, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 10F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellCurrency, "Default", "Weight", 0.57997904386578725D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellDate, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 10F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellDate, "Default", "Weight", 0.57997904386578725D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellMain, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 24F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellMain, "Default", "Text", "كشف فواتير المشتريات"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellMain, "en", "Text", "Purchase invoice statement"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellMain, "Default", "Weight", 2.6415549989480791D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableRow2, "Default", "Weight", 1.4D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableUser, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(10F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableUser, "Default", "SizeF", new System.Drawing.SizeF(787F, 35F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrtcUserId, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 18.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrtcUserId, "Default", "Text", "xrtcUserId"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrtcUserId, "Default", "Weight", 1.567979669631512D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrtcUserSalePurchase, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 15F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrtcUserSalePurchase, "Default", "Weight", 0.43202033036848797D)});
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterUserId,
            this.parameterCurrency,
            this.parameterDateStart,
            this.parameterDateEnd,
            this.parameterCashType});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.baseControlStyle,
            this.evenDetailStyle,
            this.oddDetailStyle});
            this.Version = "20.1";
            this.ParametersRequestBeforeShow += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.ReportPurchases_ParametersRequestBeforeShow);
            this.ParametersRequestSubmit += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.ReportPurchases_ParametersRequestSubmit);
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceInfoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRControlStyle baseControlStyle;
        private DevExpress.XtraReports.UI.XRControlStyle evenDetailStyle;
        private DevExpress.XtraReports.UI.XRControlStyle oddDetailStyle;
        private System.Windows.Forms.BindingSource tblUserDataSource;
        private DevExpress.XtraReports.Parameters.Parameter parameterDateStart;
        private DevExpress.XtraReports.Parameters.Parameter parameterDateEnd;
        private DevExpress.XtraReports.Parameters.Parameter parameterCurrency;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRTable invoiceInfoTable;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellMain;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell totalCaption2;
        private DevExpress.XtraReports.UI.XRTableCell invoiceDateCaption;
        private DevExpress.XtraReports.UI.XRTableCell invoiceNumberCaption;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell total2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellCurrency;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxBranch;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddress;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchName;
        protected internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel16;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.Parameters.Parameter parameterCashType;
        private System.Windows.Forms.BindingSource tblUserBindingSource;
        private DevExpress.XtraReports.Parameters.Parameter parameterUserId;
        private DevExpress.XtraReports.UI.XRSubreport xrSubRprtSalePurchaseDetail;
        private DevExpress.XtraReports.UI.XRTable xrTableUser;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrtcUserSalePurchase;
        private DevExpress.XtraReports.UI.XRTableCell xrtcUserId;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchNameEn;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddressEn;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo2;
        public DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox2;
        protected internal DevExpress.XtraReports.UI.XRLine xrLine5;
    }
}
