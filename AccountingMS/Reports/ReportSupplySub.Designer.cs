namespace AccountingMS
{
    partial class ReportSupplySub
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowV = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcProfitV = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowH = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcProfitH = new DevExpress.XtraReports.UI.XRTableCell();
            this.StyleHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.StyleEven = new DevExpress.XtraReports.UI.XRControlStyle();
            this.StyleOdd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterSupId = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterShowProfit = new DevExpress.XtraReports.Parameters.Parameter();
            this.tblSupplySubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parameterSupStatus = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplySubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 18F;
            this.Detail.Name = "Detail";
            // 
            // xrTable2
            // 
            this.xrTable2.EvenStyleName = "StyleEven";
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.OddStyleName = "StyleOdd";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowV});
            this.xrTable2.SizeF = new System.Drawing.SizeF(647F, 18F);
            // 
            // xrTableRowV
            // 
            this.xrTableRowV.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrtcPrice,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrtcProfitV});
            this.xrTableRowV.Name = "xrTableRowV";
            this.xrTableRowV.Weight = 11.5D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supPrdNo]")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.Weight = 1.8415600142760726D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supPrdName]")});
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.Weight = 4.534841608540928D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supQuanMain]")});
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "xrTableCell9";
            this.xrTableCell9.Weight = 1.1509750779180235D;
            // 
            // xrtcPrice
            // 
            this.xrtcPrice.Multiline = true;
            this.xrtcPrice.Name = "xrtcPrice";
            this.xrtcPrice.Text = "xrtcPrice";
            this.xrtcPrice.TextFormatString = "{0:n2}";
            this.xrtcPrice.Weight = 1.8415601020884995D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supTaxPrice]")});
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "xrTableCell11";
            this.xrTableCell11.TextFormatString = "{0:n2}";
            this.xrTableCell11.Weight = 1.8415601020884993D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[supCredit]")});
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.TextFormatString = "{0:n2}";
            this.xrTableCell12.Weight = 1.8415601020884993D;
            // 
            // xrtcProfitV
            // 
            this.xrtcProfitV.Multiline = true;
            this.xrtcProfitV.Name = "xrtcProfitV";
            this.xrtcProfitV.Text = "xrtcProfitV";
            this.xrtcProfitV.Weight = 1.8415600142760726D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeader1.HeightF = 20F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowH});
            this.xrTable1.SizeF = new System.Drawing.SizeF(647F, 20F);
            this.xrTable1.StyleName = "StyleHeader";
            // 
            // xrTableRowH
            // 
            this.xrTableRowH.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrtcProfitH});
            this.xrTableRowH.Name = "xrTableRowH";
            this.xrTableRowH.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.Text = "رقم الصنف";
            this.xrTableCell1.Weight = 1.8415600142760726D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "إسم الصنف";
            this.xrTableCell2.Weight = 4.534841608540928D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "الكمية";
            this.xrTableCell3.Weight = 1.1509750779180237D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "السعر";
            this.xrTableCell4.Weight = 1.8415601020884993D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "الضريبة";
            this.xrTableCell5.Weight = 1.8415601020884993D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.Text = "الإجمالي";
            this.xrTableCell6.Weight = 1.8415601020884993D;
            // 
            // xrtcProfitH
            // 
            this.xrtcProfitH.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrtcProfitH.Multiline = true;
            this.xrtcProfitH.Name = "xrtcProfitH";
            this.xrtcProfitH.StylePriority.UseBorders = false;
            this.xrtcProfitH.Text = "الربح";
            this.xrtcProfitH.Weight = 1.8415600142760726D;
            // 
            // StyleHeader
            // 
            this.StyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(155)))), ((int)(((byte)(24)))));
            this.StyleHeader.BorderColor = System.Drawing.Color.White;
            this.StyleHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.StyleHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 8.5F, DevExpress.Drawing.DXFontStyle.Bold);
            this.StyleHeader.ForeColor = System.Drawing.Color.White;
            this.StyleHeader.Name = "StyleHeader";
            this.StyleHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // StyleEven
            // 
            this.StyleEven.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(196)))));
            this.StyleEven.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.StyleEven.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.StyleEven.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.StyleEven.Name = "StyleEven";
            this.StyleEven.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // StyleOdd
            // 
            this.StyleOdd.BackColor = System.Drawing.Color.Transparent;
            this.StyleOdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.StyleOdd.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.StyleOdd.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.StyleOdd.Name = "StyleOdd";
            this.StyleOdd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // parameterSupId
            // 
            this.parameterSupId.Name = "parameterSupId";
            this.parameterSupId.Type = typeof(int);
            this.parameterSupId.ValueInfo = "0";
            this.parameterSupId.Visible = false;
            // 
            // parameterShowProfit
            // 
            this.parameterShowProfit.Name = "parameterShowProfit";
            this.parameterShowProfit.Type = typeof(bool);
            this.parameterShowProfit.ValueInfo = "False";
            this.parameterShowProfit.Visible = false;
            // 
            // tblSupplySubBindingSource
            // 
            this.tblSupplySubBindingSource.DataSource = typeof(AccountingMS.tblSupplySub);
            // 
            // parameterSupStatus
            // 
            this.parameterSupStatus.Name = "parameterSupStatus";
            this.parameterSupStatus.Type = typeof(short);
            this.parameterSupStatus.ValueInfo = "0";
            this.parameterSupStatus.Visible = false;
            // 
            // ReportSupplySub
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblSupplySubBindingSource});
            this.DataSource = this.tblSupplySubBindingSource;
            this.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(0, 0, 0, 0);
            this.PageWidth = 647;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterSupId,
            this.parameterShowProfit,
            this.parameterSupStatus});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.StyleHeader,
            this.StyleEven,
            this.StyleOdd});
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplySubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private System.Windows.Forms.BindingSource tblSupplySubBindingSource;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowV;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrtcPrice;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRControlStyle StyleHeader;
        private DevExpress.XtraReports.UI.XRControlStyle StyleEven;
        private DevExpress.XtraReports.UI.XRControlStyle StyleOdd;
        private DevExpress.XtraReports.Parameters.Parameter parameterSupId;
        private DevExpress.XtraReports.Parameters.Parameter parameterShowProfit;
        private DevExpress.XtraReports.UI.XRTableCell xrtcProfitV;
        private DevExpress.XtraReports.UI.XRTableCell xrtcProfitH;
        private DevExpress.XtraReports.Parameters.Parameter parameterSupStatus;
    }
}
