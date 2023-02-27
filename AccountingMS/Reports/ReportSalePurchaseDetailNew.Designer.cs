namespace AccountingMS
{
    partial class ReportSalePurchaseDetailNew
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.detailTable = new DevExpress.XtraReports.UI.XRTable();
            this.detailTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellSupStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.quantity = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotalFinalMain = new DevExpress.XtraReports.UI.XRTableCell();
            this.lineTotal = new DevExpress.XtraReports.UI.XRTableCell();
            this.detailTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellSupAccName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.detailTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.detailTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.detailTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.headerTable = new DevExpress.XtraReports.UI.XRTable();
            this.headerTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.productDesctiptionCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.quantityCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.unitPriceCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.lineTotalCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.totalCaptionRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotal = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotalDiscount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotalAfterDiscount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotalTax = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTotalFinal = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterUserId = new DevExpress.XtraReports.Parameters.Parameter();
            this.tblSupplyMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detailTable});
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.Detail_BeforePrint);
            // 
            // detailTable
            // 
            this.detailTable.EvenStyleName = "xrControlStyle1";
            this.detailTable.Name = "detailTable";
            this.detailTable.OddStyleName = "xrControlStyle2";
            this.detailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.detailTableRow1,
            this.detailTableRow2});
            this.detailTable.StylePriority.UseBorderColor = false;
            this.detailTable.StylePriority.UseBorders = false;
            this.detailTable.StylePriority.UseFont = false;
            this.detailTable.StylePriority.UseTextAlignment = false;
            this.detailTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detailTableRow1
            // 
            this.detailTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCellSupStatus,
            this.xrTableCell7,
            this.xrTableCell9,
            this.quantity,
            this.xrTableCellTotalFinalMain,
            this.lineTotal});
            this.detailTableRow1.Name = "detailTableRow1";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BorderColor = System.Drawing.Color.White;
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.BorderWidth = 2F;
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supNo]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell3.RowSpan = 2;
            this.xrTableCell3.StylePriority.UseBorderColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseBorderWidth = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCellSupStatus
            // 
            this.xrTableCellSupStatus.BorderColor = System.Drawing.Color.White;
            this.xrTableCellSupStatus.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCellSupStatus.BorderWidth = 2F;
            this.xrTableCellSupStatus.Name = "xrTableCellSupStatus";
            this.xrTableCellSupStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCellSupStatus.StylePriority.UseBorderColor = false;
            this.xrTableCellSupStatus.StylePriority.UseBorders = false;
            this.xrTableCellSupStatus.StylePriority.UseBorderWidth = false;
            this.xrTableCellSupStatus.StylePriority.UseFont = false;
            this.xrTableCellSupStatus.StylePriority.UsePadding = false;
            this.xrTableCellSupStatus.StylePriority.UseTextAlignment = false;
            this.xrTableCellSupStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BorderColor = System.Drawing.Color.White;
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.BorderWidth = 2F;
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supTotal]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell7.RowSpan = 2;
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseBorderWidth = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BorderColor = System.Drawing.Color.White;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.BorderWidth = 2F;
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supDscntAmount]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell9.RowSpan = 2;
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseBorderWidth = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // quantity
            // 
            this.quantity.BorderColor = System.Drawing.Color.White;
            this.quantity.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.quantity.BorderWidth = 2F;
            this.quantity.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supTaxPrice]")});
            this.quantity.Name = "quantity";
            this.quantity.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.quantity.RowSpan = 2;
            this.quantity.StylePriority.UseBackColor = false;
            this.quantity.StylePriority.UseBorderColor = false;
            this.quantity.StylePriority.UseBorders = false;
            this.quantity.StylePriority.UseBorderWidth = false;
            this.quantity.StylePriority.UseFont = false;
            this.quantity.StylePriority.UsePadding = false;
            this.quantity.StylePriority.UseTextAlignment = false;
            this.quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCellTotalFinalMain
            // 
            this.xrTableCellTotalFinalMain.BorderColor = System.Drawing.Color.White;
            this.xrTableCellTotalFinalMain.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCellTotalFinalMain.BorderWidth = 2F;
            this.xrTableCellTotalFinalMain.Name = "xrTableCellTotalFinalMain";
            this.xrTableCellTotalFinalMain.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCellTotalFinalMain.RowSpan = 2;
            this.xrTableCellTotalFinalMain.StylePriority.UseBackColor = false;
            this.xrTableCellTotalFinalMain.StylePriority.UseBorderColor = false;
            this.xrTableCellTotalFinalMain.StylePriority.UseBorders = false;
            this.xrTableCellTotalFinalMain.StylePriority.UseBorderWidth = false;
            this.xrTableCellTotalFinalMain.StylePriority.UseFont = false;
            this.xrTableCellTotalFinalMain.StylePriority.UsePadding = false;
            this.xrTableCellTotalFinalMain.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotalFinalMain.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineTotal
            // 
            this.lineTotal.BorderColor = System.Drawing.Color.White;
            this.lineTotal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lineTotal.BorderWidth = 2F;
            this.lineTotal.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supDate]")});
            this.lineTotal.Name = "lineTotal";
            this.lineTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.lineTotal.RowSpan = 2;
            this.lineTotal.StylePriority.UseBackColor = false;
            this.lineTotal.StylePriority.UseBorderColor = false;
            this.lineTotal.StylePriority.UseBorders = false;
            this.lineTotal.StylePriority.UseBorderWidth = false;
            this.lineTotal.StylePriority.UseFont = false;
            this.lineTotal.StylePriority.UseForeColor = false;
            this.lineTotal.StylePriority.UsePadding = false;
            this.lineTotal.StylePriority.UseTextAlignment = false;
            this.lineTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detailTableRow2
            // 
            this.detailTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCellSupAccName,
            this.xrTableCell8,
            this.xrTableCell10,
            this.detailTableCell1,
            this.detailTableCell2,
            this.detailTableCell5});
            this.detailTableRow2.Name = "detailTableRow2";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            // 
            // xrTableCellSupAccName
            // 
            this.xrTableCellSupAccName.BorderColor = System.Drawing.Color.White;
            this.xrTableCellSupAccName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCellSupAccName.BorderWidth = 2F;
            this.xrTableCellSupAccName.Name = "xrTableCellSupAccName";
            this.xrTableCellSupAccName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCellSupAccName.StylePriority.UseBackColor = false;
            this.xrTableCellSupAccName.StylePriority.UseBorderColor = false;
            this.xrTableCellSupAccName.StylePriority.UseBorders = false;
            this.xrTableCellSupAccName.StylePriority.UseBorderWidth = false;
            this.xrTableCellSupAccName.StylePriority.UseFont = false;
            this.xrTableCellSupAccName.StylePriority.UseForeColor = false;
            this.xrTableCellSupAccName.StylePriority.UsePadding = false;
            this.xrTableCellSupAccName.StylePriority.UseTextAlignment = false;
            this.xrTableCellSupAccName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            // 
            // detailTableCell1
            // 
            this.detailTableCell1.Name = "detailTableCell1";
            this.detailTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.detailTableCell1.StylePriority.UsePadding = false;
            this.detailTableCell1.StylePriority.UseTextAlignment = false;
            this.detailTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // detailTableCell2
            // 
            this.detailTableCell2.Name = "detailTableCell2";
            this.detailTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.detailTableCell2.StylePriority.UsePadding = false;
            this.detailTableCell2.StylePriority.UseTextAlignment = false;
            this.detailTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // detailTableCell5
            // 
            this.detailTableCell5.Name = "detailTableCell5";
            this.detailTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.detailTableCell5.StylePriority.UseFont = false;
            this.detailTableCell5.StylePriority.UsePadding = false;
            this.detailTableCell5.StylePriority.UseTextAlignment = false;
            this.detailTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerTable});
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // headerTable
            // 
            this.headerTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.headerTable.BorderColor = System.Drawing.Color.Silver;
            this.headerTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.headerTable.BorderWidth = 2F;
            this.headerTable.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerTable.Name = "headerTable";
            this.headerTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.headerTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.headerTableRow});
            this.headerTable.StylePriority.UseBackColor = false;
            this.headerTable.StylePriority.UseBorderColor = false;
            this.headerTable.StylePriority.UseBorders = false;
            this.headerTable.StylePriority.UseBorderWidth = false;
            this.headerTable.StylePriority.UseFont = false;
            this.headerTable.StylePriority.UseForeColor = false;
            this.headerTable.StylePriority.UsePadding = false;
            // 
            // headerTableRow
            // 
            this.headerTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.productDesctiptionCaption,
            this.quantityCaption,
            this.xrTableCell5,
            this.xrTableCell6,
            this.unitPriceCaption,
            this.lineTotalCaption});
            this.headerTableRow.Name = "headerTableRow";
            this.headerTableRow.StylePriority.UseFont = false;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // productDesctiptionCaption
            // 
            this.productDesctiptionCaption.Name = "productDesctiptionCaption";
            this.productDesctiptionCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(30, 5, 5, 5, 100F);
            this.productDesctiptionCaption.StylePriority.UseBackColor = false;
            this.productDesctiptionCaption.StylePriority.UseFont = false;
            this.productDesctiptionCaption.StylePriority.UseForeColor = false;
            this.productDesctiptionCaption.StylePriority.UsePadding = false;
            this.productDesctiptionCaption.StylePriority.UseTextAlignment = false;
            this.productDesctiptionCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // quantityCaption
            // 
            this.quantityCaption.Name = "quantityCaption";
            this.quantityCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.quantityCaption.StylePriority.UseBackColor = false;
            this.quantityCaption.StylePriority.UseFont = false;
            this.quantityCaption.StylePriority.UseForeColor = false;
            this.quantityCaption.StylePriority.UsePadding = false;
            this.quantityCaption.StylePriority.UseTextAlignment = false;
            this.quantityCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // unitPriceCaption
            // 
            this.unitPriceCaption.Name = "unitPriceCaption";
            this.unitPriceCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.unitPriceCaption.StylePriority.UseBackColor = false;
            this.unitPriceCaption.StylePriority.UseFont = false;
            this.unitPriceCaption.StylePriority.UseForeColor = false;
            this.unitPriceCaption.StylePriority.UsePadding = false;
            this.unitPriceCaption.StylePriority.UseTextAlignment = false;
            this.unitPriceCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineTotalCaption
            // 
            this.lineTotalCaption.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lineTotalCaption.Name = "lineTotalCaption";
            this.lineTotalCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.lineTotalCaption.StylePriority.UseBackColor = false;
            this.lineTotalCaption.StylePriority.UseBorders = false;
            this.lineTotalCaption.StylePriority.UseFont = false;
            this.lineTotalCaption.StylePriority.UseForeColor = false;
            this.lineTotalCaption.StylePriority.UsePadding = false;
            this.lineTotalCaption.StylePriority.UseTextAlignment = false;
            this.lineTotalCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrTable1});
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.KeepTogether = true;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            this.GroupFooter1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.GroupFooter1_BeforePrint);
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([supNo])")});
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel1.Summary = xrSummary1;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            this.xrLabel1.WordWrap = false;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.totalCaptionRow,
            this.xrTableRow1});
            this.xrTable1.StylePriority.UseBackColor = false;
            // 
            // totalCaptionRow
            // 
            this.totalCaptionRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell2,
            this.xrTableCell18,
            this.xrTableCell16});
            this.totalCaptionRow.Name = "totalCaptionRow";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell14.ForeColor = System.Drawing.Color.White;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell14.RowSpan = 2;
            this.xrTableCell14.StylePriority.UseBackColor = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UseForeColor = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell14.WordWrap = false;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell11.ForeColor = System.Drawing.Color.White;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UseForeColor = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell12.ForeColor = System.Drawing.Color.White;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UseForeColor = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell2.ForeColor = System.Drawing.Color.White;
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseForeColor = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell18.ForeColor = System.Drawing.Color.White;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell18.StylePriority.UseBackColor = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseForeColor = false;
            this.xrTableCell18.StylePriority.UsePadding = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell16.ForeColor = System.Drawing.Color.White;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell16.StylePriority.UseBackColor = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseForeColor = false;
            this.xrTableCell16.StylePriority.UsePadding = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell15,
            this.xrTableCellTotal,
            this.xrTableCellTotalDiscount,
            this.xrTableCellTotalAfterDiscount,
            this.xrTableCellTotalTax,
            this.xrTableCellTotalFinal});
            this.xrTableRow1.Name = "xrTableRow1";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCell15.ForeColor = System.Drawing.Color.White;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrTableCell15.StylePriority.UseBackColor = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCellTotal
            // 
            this.xrTableCellTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCellTotal.ForeColor = System.Drawing.Color.White;
            this.xrTableCellTotal.Name = "xrTableCellTotal";
            this.xrTableCellTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCellTotal.StylePriority.UseBackColor = false;
            this.xrTableCellTotal.StylePriority.UseFont = false;
            this.xrTableCellTotal.StylePriority.UseForeColor = false;
            this.xrTableCellTotal.StylePriority.UsePadding = false;
            this.xrTableCellTotal.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCellTotal.WordWrap = false;
            // 
            // xrTableCellTotalDiscount
            // 
            this.xrTableCellTotalDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCellTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.xrTableCellTotalDiscount.Name = "xrTableCellTotalDiscount";
            this.xrTableCellTotalDiscount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCellTotalDiscount.StylePriority.UseBackColor = false;
            this.xrTableCellTotalDiscount.StylePriority.UseFont = false;
            this.xrTableCellTotalDiscount.StylePriority.UseForeColor = false;
            this.xrTableCellTotalDiscount.StylePriority.UsePadding = false;
            this.xrTableCellTotalDiscount.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotalDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCellTotalAfterDiscount
            // 
            this.xrTableCellTotalAfterDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCellTotalAfterDiscount.ForeColor = System.Drawing.Color.White;
            this.xrTableCellTotalAfterDiscount.Multiline = true;
            this.xrTableCellTotalAfterDiscount.Name = "xrTableCellTotalAfterDiscount";
            this.xrTableCellTotalAfterDiscount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCellTotalAfterDiscount.StylePriority.UseBackColor = false;
            this.xrTableCellTotalAfterDiscount.StylePriority.UseFont = false;
            this.xrTableCellTotalAfterDiscount.StylePriority.UseForeColor = false;
            this.xrTableCellTotalAfterDiscount.StylePriority.UsePadding = false;
            this.xrTableCellTotalAfterDiscount.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotalAfterDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCellTotalTax
            // 
            this.xrTableCellTotalTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCellTotalTax.ForeColor = System.Drawing.Color.White;
            this.xrTableCellTotalTax.Name = "xrTableCellTotalTax";
            this.xrTableCellTotalTax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCellTotalTax.StylePriority.UseBackColor = false;
            this.xrTableCellTotalTax.StylePriority.UseFont = false;
            this.xrTableCellTotalTax.StylePriority.UseForeColor = false;
            this.xrTableCellTotalTax.StylePriority.UsePadding = false;
            this.xrTableCellTotalTax.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotalTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCellTotalFinal
            // 
            this.xrTableCellTotalFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.xrTableCellTotalFinal.ForeColor = System.Drawing.Color.White;
            this.xrTableCellTotalFinal.Name = "xrTableCellTotalFinal";
            this.xrTableCellTotalFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCellTotalFinal.StylePriority.UseBackColor = false;
            this.xrTableCellTotalFinal.StylePriority.UseFont = false;
            this.xrTableCellTotalFinal.StylePriority.UseForeColor = false;
            this.xrTableCellTotalFinal.StylePriority.UsePadding = false;
            this.xrTableCellTotalFinal.StylePriority.UseTextAlignment = false;
            this.xrTableCellTotalFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // xrControlStyle2
            // 
            this.xrControlStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrControlStyle2.Name = "xrControlStyle2";
            this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // parameterUserId
            // 
            this.parameterUserId.Name = "parameterUserId";
            this.parameterUserId.Type = typeof(short);
            this.parameterUserId.ValueInfo = "0";
            // 
            // tblSupplyMainBindingSource
            // 
            this.tblSupplyMainBindingSource.DataSource = typeof(AccountingMS.tblSupplyMain);
            // 
            // ReportSalePurchaseDetail
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblSupplyMainBindingSource});
            this.DataSource = this.tblSupplyMainBindingSource;
            this.LocalizationItems.AddRange(new DevExpress.XtraReports.Localization.LocalizationItem[] {
            new DevExpress.XtraReports.Localization.LocalizationItem(this.BottomMargin, "Default", "HeightF", 0F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.Detail, "Default", "HeightF", 35F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTable, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTable, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTable, "Default", "SizeF", new System.Drawing.SizeF(787F, 35F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableCell1, "Default", "Weight", 0.570580394267132D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableCell2, "Default", "Weight", 0.81511480555989524D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableCell5, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableCell5, "Default", "Weight", 1.0145064754880326D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableRow1, "Default", "Weight", 7.4675601980203563D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.detailTableRow2, "Default", "Weight", 7.4675601980203572D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.GroupFooter1, "Default", "HeightF", 86.58334F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.GroupHeader1, "Default", "HeightF", 35F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.headerTable, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.headerTable, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.headerTable, "Default", "SizeF", new System.Drawing.SizeF(787F, 35F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.headerTableRow, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.headerTableRow, "Default", "Weight", 6.8299491460003461D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotal, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.5F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotal, "Default", "TextFormatString", "{0:tt h:mm yyyy/MM/dd}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotal, "Default", "Weight", 0.70583799491173882D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotalCaption, "Default", "Text", "التاريخ"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotalCaption, "en", "Text", "Date"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.lineTotalCaption, "Default", "Weight", 0.2833598761751861D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.productDesctiptionCaption, "Default", "Text", "البيان"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.productDesctiptionCaption, "en", "Text", "Statement"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.productDesctiptionCaption, "Default", "Weight", 0.50954890899810235D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.quantity, "Default", "TextFormatString", "{0:n}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.quantity, "Default", "Weight", 0.3969786986664679D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.quantityCaption, "Default", "Text", "المبلغ"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.quantityCaption, "en", "Text", "Amount"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.quantityCaption, "Default", "Weight", 0.22766799205237373D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "Margins", new DevExpress.Drawing.DXMargins(0, 0, 0, 0)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "PaperKind", System.Drawing.Printing.PaperKind.Custom),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.TopMargin, "Default", "HeightF", 0F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.totalCaptionRow, "Default", "Weight", 0.41551542553740262D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.unitPriceCaption, "Default", "Text", "الإجمالي"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.unitPriceCaption, "en", "Text", "Total"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.unitPriceCaption, "Default", "Weight", 0.22766798844507685D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(9.999878F, 63.58334F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "Default", "SizeF", new System.Drawing.SizeF(100F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "Default", "Text", "xrLabel1"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "Default", "TextFormatString", "عدد الفواتير : {0:#,#}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrLabel1, "en", "TextFormatString", "Number of bills: {0:#,#}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTable1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTable1, "Default", "SizeF", new System.Drawing.SizeF(787F, 63F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell1, "Default", "Text", "رقم الفاتورة"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell1, "en", "Text", "invoice number"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell1, "Default", "Weight", 0.21110731796325374D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell10, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell10, "Default", "Text", "xrTableCell10"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell10, "Default", "Weight", 0.65209189523348077D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell11, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell11, "Default", "Text", "المبلغ"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell11, "en", "Text", "Amount"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell11, "Default", "Weight", 1.7840653352087426D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell12, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell12, "Default", "Text", "الخصم"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell12, "en", "Text", "Discount"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell12, "Default", "Weight", 1.5599367049042174D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell14, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Black", 20F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell14, "Default", "Text", "الإجمالي"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell14, "en", "Text", "Total"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell14, "Default", "Weight", 1.4433906248801547D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell15, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 20F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell15, "Default", "Text", "xrTableCell15"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell15, "Default", "Weight", 1.4433906250217159D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell16, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell16, "Default", "Text", "الإجمالي النهائي"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell16, "en", "Text", "Final total"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell16, "Default", "Weight", 2.108602127233238D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell18, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell18, "Default", "Text", "الضريبة"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell18, "en", "Text", "Tax"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell18, "Default", "Weight", 1.6137276587636058D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell2, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell2, "Default", "Text", "الاجمالي بعد الخصم"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell2, "en", "Text", "Total after deduction"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell2, "Default", "Weight", 1.5599367049042174D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell3, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell3, "Default", "Text", "xrTableCell3"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell3, "Default", "Weight", 0.52586010121266735D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell4, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell4, "Default", "Text", "xrTableCell4"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell4, "Default", "Weight", 0.75582191931542364D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell5, "Default", "Text", "الخصم"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell5, "en", "Text", "Discount"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell5, "Default", "Weight", 0.18213438100398374D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell6, "Default", "Text", "الضريبة"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell6, "en", "Text", "Tax"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell6, "Default", "Weight", 0.15936758439421131D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell7, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell7, "Default", "Text", "xrTableCell7"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell7, "Default", "TextFormatString", "{0:n}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell7, "Default", "Weight", 0.567112416742618D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell8, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell8, "Default", "Text", "xrTableCell8"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell8, "Default", "Weight", 0.81511486028986591D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell9, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 9F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCell9, "Default", "Weight", 0.45368996336170153D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupAccName, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.5F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupAccName, "Default", "Text", "من حساب : [supAccName]"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupAccName, "en", "Text", "From account: [supAccName]"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupAccName, "Default", "Weight", 1.824327972459054D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupStatus, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 8.5F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellSupStatus, "Default", "Weight", 1.2692677568325688D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotal, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 18F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotal, "Default", "TextFormatString", "{0:n}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotal, "Default", "Weight", 1.7840653353837155D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalAfterDiscount, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 18F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalAfterDiscount, "Default", "Weight", 1.5599367050572084D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalDiscount, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 18F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalDiscount, "Default", "Weight", 1.5599367050572084D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalFinal, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 18F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalFinal, "Default", "Weight", 2.1086021274400397D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalFinalMain, "Default", "Weight", 0.567112424821558D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalTax, "Default", "Font", new DevExpress.Drawing.DXFont("Segoe UI", 18F, DevExpress.Drawing.DXFontStyle.Bold)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableCellTotalTax, "Default", "Weight", 1.6137276589218723D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.xrTableRow1, "Default", "Weight", 0.63158342379759314D)});
            this.PageHeight = 1803;
            this.PageWidth = 787;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterUserId});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1,
            this.xrControlStyle2});
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRTable headerTable;
        private DevExpress.XtraReports.UI.XRTableRow headerTableRow;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell productDesctiptionCaption;
        private DevExpress.XtraReports.UI.XRTableCell quantityCaption;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell unitPriceCaption;
        private DevExpress.XtraReports.UI.XRTableCell lineTotalCaption;
        private System.Windows.Forms.BindingSource tblSupplyMainBindingSource;
        private DevExpress.XtraReports.UI.XRTable detailTable;
        private DevExpress.XtraReports.UI.XRTableRow detailTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellSupStatus;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell quantity;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotalFinalMain;
        private DevExpress.XtraReports.UI.XRTableCell lineTotal;
        private DevExpress.XtraReports.UI.XRTableRow detailTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellSupAccName;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell5;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow totalCaptionRow;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotal;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotalDiscount;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotalTax;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotalFinal;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter parameterUserId;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTotalAfterDiscount;
    }
}
