namespace AccountingMS
{
    partial class ReportAccountBillMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAccountBillMaster));
            this.tblAccountParmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubRprt = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.parameterDtEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelBranchName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchMailBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchFaxNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchPhnNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchAddressEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelBranchNameEn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBoxBranch = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterAccNo = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.tblAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parameterGroupRcrds = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountParmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tblAccountParmBindingSource
            // 
            this.tblAccountParmBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubRprt,
            this.xrTable3,
            this.xrTable5});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // xrSubRprt
            // 
            resources.ApplyResources(this.xrSubRprt, "xrSubRprt");
            this.xrSubRprt.Name = "xrSubRprt";
            // 
            // xrTable3
            // 
            resources.ApplyResources(this.xrTable3, "xrTable3");
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4,
            this.xrTableRow5});
            this.xrTable3.StylePriority.UseBackColor = false;
            this.xrTable3.StylePriority.UseBorderColor = false;
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16});
            this.xrTableRow4.Name = "xrTableRow4";
            resources.ApplyResources(this.xrTableRow4, "xrTableRow4");
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.RowSpan = 2;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            // 
            // xrTableCell15
            // 
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            // 
            // xrTableCell16
            // 
            resources.ApplyResources(this.xrTableCell16, "xrTableCell16");
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseForeColor = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19});
            this.xrTableRow5.Name = "xrTableRow5";
            resources.ApplyResources(this.xrTableRow5, "xrTableRow5");
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            resources.ApplyResources(this.xrTableCell17, "xrTableCell17");
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[accNo]")});
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            resources.ApplyResources(this.xrTableCell18, "xrTableCell18");
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[accCurrency]")});
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            resources.ApplyResources(this.xrTableCell19, "xrTableCell19");
            this.xrTableCell19.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.XrTableCell19_BeforePrint);
            // 
            // xrTable5
            // 
            resources.ApplyResources(this.xrTable5, "xrTable5");
            this.xrTable5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable5.BorderWidth = 5F;
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable5.StylePriority.UseBorderColor = false;
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UseBorderWidth = false;
            this.xrTable5.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell22,
            this.xrtcDate});
            this.xrTableRow3.Name = "xrTableRow3";
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            // 
            // xrTableCell13
            // 
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            this.xrTableCell13.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 3, 100F);
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCell22
            // 
            resources.ApplyResources(this.xrTableCell22, "xrTableCell22");
            this.xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[accName]")});
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 3, 100F);
            this.xrTableCell22.StylePriority.UseBackColor = false;
            this.xrTableCell22.StylePriority.UseBorderColor = false;
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseForeColor = false;
            this.xrTableCell22.StylePriority.UsePadding = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            // 
            // xrtcDate
            // 
            resources.ApplyResources(this.xrtcDate, "xrtcDate");
            this.xrtcDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrtcDate.Multiline = true;
            this.xrtcDate.Name = "xrtcDate";
            this.xrtcDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrtcDate.StylePriority.UseBackColor = false;
            this.xrtcDate.StylePriority.UseBorderColor = false;
            this.xrtcDate.StylePriority.UseBorders = false;
            this.xrtcDate.StylePriority.UseFont = false;
            this.xrtcDate.StylePriority.UseForeColor = false;
            this.xrtcDate.StylePriority.UsePadding = false;
            this.xrtcDate.StylePriority.UseTextAlignment = false;
            // 
            // parameterDtEnd
            // 
            resources.ApplyResources(this.parameterDtEnd, "parameterDtEnd");
            this.parameterDtEnd.Name = "parameterDtEnd";
            this.parameterDtEnd.Type = typeof(System.DateTime);
            this.parameterDtEnd.ValueInfo = "2019-12-31";
            // 
            // parameterDtStart
            // 
            resources.ApplyResources(this.parameterDtStart, "parameterDtStart");
            this.parameterDtStart.Name = "parameterDtStart";
            this.parameterDtStart.Type = typeof(System.DateTime);
            this.parameterDtStart.ValueInfo = "2018-01-01";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine5,
            this.xrLabelBranchName,
            this.xrLabelBranchAddress,
            this.xrLabelBranchPhnNo1,
            this.xrLabelBranchFaxNo1,
            this.xrLabelBranchMailBox1,
            this.xrLabelBranchMailBox2,
            this.xrLabelBranchFaxNo2,
            this.xrLabelBranchPhnNo2,
            this.xrLabelBranchAddressEn,
            this.xrLabelBranchNameEn,
            this.xrLabel15,
            this.xrPictureBoxBranch});
            resources.ApplyResources(this.TopMargin, "TopMargin");
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrLine5
            // 
            resources.ApplyResources(this.xrLine5, "xrLine5");
            this.xrLine5.Name = "xrLine5";
            // 
            // xrLabelBranchName
            // 
            this.xrLabelBranchName.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchName, "xrLabelBranchName");
            this.xrLabelBranchName.Name = "xrLabelBranchName";
            this.xrLabelBranchName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchName.StylePriority.UseFont = false;
            this.xrLabelBranchName.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchName.WordWrap = false;
            // 
            // xrLabelBranchAddress
            // 
            this.xrLabelBranchAddress.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchAddress, "xrLabelBranchAddress");
            this.xrLabelBranchAddress.Name = "xrLabelBranchAddress";
            this.xrLabelBranchAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddress.StylePriority.UseFont = false;
            this.xrLabelBranchAddress.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddress.WordWrap = false;
            // 
            // xrLabelBranchPhnNo1
            // 
            this.xrLabelBranchPhnNo1.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchPhnNo1, "xrLabelBranchPhnNo1");
            this.xrLabelBranchPhnNo1.Name = "xrLabelBranchPhnNo1";
            this.xrLabelBranchPhnNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo1.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo1.WordWrap = false;
            // 
            // xrLabelBranchFaxNo1
            // 
            this.xrLabelBranchFaxNo1.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchFaxNo1, "xrLabelBranchFaxNo1");
            this.xrLabelBranchFaxNo1.Name = "xrLabelBranchFaxNo1";
            this.xrLabelBranchFaxNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo1.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo1.WordWrap = false;
            // 
            // xrLabelBranchMailBox1
            // 
            this.xrLabelBranchMailBox1.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchMailBox1, "xrLabelBranchMailBox1");
            this.xrLabelBranchMailBox1.Name = "xrLabelBranchMailBox1";
            this.xrLabelBranchMailBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox1.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox1.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox1.WordWrap = false;
            // 
            // xrLabelBranchMailBox2
            // 
            this.xrLabelBranchMailBox2.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchMailBox2, "xrLabelBranchMailBox2");
            this.xrLabelBranchMailBox2.Name = "xrLabelBranchMailBox2";
            this.xrLabelBranchMailBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchMailBox2.StylePriority.UseFont = false;
            this.xrLabelBranchMailBox2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchMailBox2.WordWrap = false;
            // 
            // xrLabelBranchFaxNo2
            // 
            this.xrLabelBranchFaxNo2.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchFaxNo2, "xrLabelBranchFaxNo2");
            this.xrLabelBranchFaxNo2.Name = "xrLabelBranchFaxNo2";
            this.xrLabelBranchFaxNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchFaxNo2.StylePriority.UseFont = false;
            this.xrLabelBranchFaxNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchFaxNo2.WordWrap = false;
            // 
            // xrLabelBranchPhnNo2
            // 
            this.xrLabelBranchPhnNo2.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchPhnNo2, "xrLabelBranchPhnNo2");
            this.xrLabelBranchPhnNo2.Name = "xrLabelBranchPhnNo2";
            this.xrLabelBranchPhnNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchPhnNo2.StylePriority.UseFont = false;
            this.xrLabelBranchPhnNo2.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchPhnNo2.WordWrap = false;
            // 
            // xrLabelBranchAddressEn
            // 
            this.xrLabelBranchAddressEn.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchAddressEn, "xrLabelBranchAddressEn");
            this.xrLabelBranchAddressEn.Name = "xrLabelBranchAddressEn";
            this.xrLabelBranchAddressEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchAddressEn.StylePriority.UseFont = false;
            this.xrLabelBranchAddressEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchAddressEn.WordWrap = false;
            // 
            // xrLabelBranchNameEn
            // 
            this.xrLabelBranchNameEn.AutoWidth = true;
            resources.ApplyResources(this.xrLabelBranchNameEn, "xrLabelBranchNameEn");
            this.xrLabelBranchNameEn.Name = "xrLabelBranchNameEn";
            this.xrLabelBranchNameEn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelBranchNameEn.StylePriority.UseFont = false;
            this.xrLabelBranchNameEn.StylePriority.UseTextAlignment = false;
            this.xrLabelBranchNameEn.WordWrap = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.AutoWidth = true;
            resources.ApplyResources(this.xrLabel15, "xrLabel15");
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.WordWrap = false;
            // 
            // xrPictureBoxBranch
            // 
            resources.ApplyResources(this.xrPictureBoxBranch, "xrPictureBoxBranch");
            this.xrPictureBoxBranch.Name = "xrPictureBoxBranch";
            this.xrPictureBoxBranch.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrPictureBox1,
            this.xrLabel16});
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrLabel22
            // 
            resources.ApplyResources(this.xrLabel22, "xrLabel22");
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageUrl = "D:\\WorkApplications\\BTechImages\\BTech.png";
            resources.ApplyResources(this.xrPictureBox1, "xrPictureBox1");
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel16
            // 
            resources.ApplyResources(this.xrLabel16, "xrLabel16");
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            // 
            // parameterAccNo
            // 
            resources.ApplyResources(this.parameterAccNo, "parameterAccNo");
            this.parameterAccNo.Name = "parameterAccNo";
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // tblAccountBindingSource
            // 
            this.tblAccountBindingSource.DataSource = typeof(AccountingMS.tblAccount);
            // 
            // parameterGroupRcrds
            // 
            resources.ApplyResources(this.parameterGroupRcrds, "parameterGroupRcrds");
            this.parameterGroupRcrds.Name = "parameterGroupRcrds";
            this.parameterGroupRcrds.Type = typeof(bool);
            this.parameterGroupRcrds.ValueInfo = "False";
            // 
            // ReportAccountBillMaster
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblAccountBindingSource,
            this.tblAccountParmBindingSource});
            this.DataSource = this.tblAccountBindingSource;
            resources.ApplyResources(this, "$this");
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterAccNo,
            this.parameterDtStart,
            this.parameterDtEnd,
            this.parameterGroupRcrds});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.ScriptsSource = "\r\n";
            this.ShowPreviewMarginLines = false;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "20.1";
            this.ParametersRequestSubmit += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.ReportAccountBill_ParametersRequestSubmit);
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountParmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.Parameters.Parameter parameterAccNo;
        private System.Windows.Forms.BindingSource tblAccountBindingSource;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtEnd;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtStart;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchName;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddress;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo1;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox1;
        internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxBranch;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchMailBox2;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchFaxNo2;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchPhnNo2;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchAddressEn;
        internal DevExpress.XtraReports.UI.XRLabel xrLabelBranchNameEn;
        private DevExpress.XtraReports.UI.XRTable xrTable5;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrtcDate;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        protected internal DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel16;
        protected internal DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRSubreport xrSubRprt;
        private System.Windows.Forms.BindingSource tblAccountParmBindingSource;
        private DevExpress.XtraReports.Parameters.Parameter parameterGroupRcrds;
        protected internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        protected internal DevExpress.XtraReports.UI.XRLine xrLine5;
    }
}
