namespace AccountingMS
{
    partial class ReportOrdersMaster
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
            this.xrSubreportOrderDetail = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcOrdNoVal = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcOrdDateVal = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcOrdNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcOrdDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.EvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.OddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterDtStart = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDtEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterOrderType = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterOrderDetail = new DevExpress.XtraReports.Parameters.Parameter();
            this.tableDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.tblOrderMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 1.916663F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportOrderDetail,
            this.xrTable2});
            this.Detail.HeightF = 22F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // xrSubreportOrderDetail
            // 
            this.xrSubreportOrderDetail.LocationFloat = new DevExpress.Utils.PointFloat(100F, 22F);
            this.xrSubreportOrderDetail.Name = "xrSubreportOrderDetail";
            this.xrSubreportOrderDetail.SizeF = new System.Drawing.SizeF(687F, 0F);
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.xrTable2.BorderColor = System.Drawing.Color.White;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTable2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.75F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(787F, 22F);
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcOrdNoVal,
            this.xrTableCell7,
            this.xrtcOrdDateVal});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 11.5D;
            // 
            // xrtcOrdNoVal
            // 
            this.xrtcOrdNoVal.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ordNo]")});
            this.xrtcOrdNoVal.Multiline = true;
            this.xrtcOrdNoVal.Name = "xrtcOrdNoVal";
            this.xrtcOrdNoVal.StylePriority.UseBorders = false;
            this.xrtcOrdNoVal.StylePriority.UsePadding = false;
            this.xrtcOrdNoVal.StylePriority.UseTextAlignment = false;
            this.xrtcOrdNoVal.Text = "xrtcOrdNoVal";
            this.xrtcOrdNoVal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtcOrdNoVal.Weight = 0.075186266345476385D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ordDesc]")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.Weight = 0.45111763631457485D;
            // 
            // xrtcOrdDateVal
            // 
            this.xrtcOrdDateVal.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ordDate]")});
            this.xrtcOrdDateVal.Multiline = true;
            this.xrtcOrdDateVal.Name = "xrtcOrdDateVal";
            this.xrtcOrdDateVal.StylePriority.UseBorders = false;
            this.xrtcOrdDateVal.StylePriority.UsePadding = false;
            this.xrtcOrdDateVal.StylePriority.UseTextAlignment = false;
            this.xrtcOrdDateVal.Text = "xrtcOrdDateVal";
            this.xrtcOrdDateVal.TextFormatString = "{0:yyyy/MM/dd}";
            this.xrtcOrdDateVal.Weight = 0.065412073671309745D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeader1.HeightF = 24F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrTable1.BorderColor = System.Drawing.Color.White;
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTable1.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTable1.ForeColor = System.Drawing.Color.White;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(787F, 24F);
            this.xrTable1.StyleName = "HeaderDetailStyle";
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcOrdNo,
            this.xrTableCell4,
            this.xrtcOrdDate});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 11.5D;
            // 
            // xrtcOrdNo
            // 
            this.xrtcOrdNo.Multiline = true;
            this.xrtcOrdNo.Name = "xrtcOrdNo";
            this.xrtcOrdNo.StylePriority.UsePadding = false;
            this.xrtcOrdNo.StylePriority.UseTextAlignment = false;
            this.xrtcOrdNo.Text = "رقم الطلب";
            this.xrtcOrdNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrtcOrdNo.Weight = 0.075186266345476385D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "البيان";
            this.xrTableCell4.Weight = 0.45111763631457491D;
            // 
            // xrtcOrdDate
            // 
            this.xrtcOrdDate.Multiline = true;
            this.xrtcOrdDate.Name = "xrtcOrdDate";
            this.xrtcOrdDate.StylePriority.UsePadding = false;
            this.xrtcOrdDate.StylePriority.UseTextAlignment = false;
            this.xrtcOrdDate.Text = "التاريخ";
            this.xrtcOrdDate.Weight = 0.065412073671309745D;
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
            // HeaderStyle
            // 
            this.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.HeaderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(177)))), ((int)(((byte)(183)))));
            this.HeaderStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.HeaderStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 11F, DevExpress.Drawing.DXFontStyle.Bold);
            this.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.HeaderStyle.Name = "HeaderStyle";
            this.HeaderStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // parameterDtStart
            // 
            this.parameterDtStart.Name = "parameterDtStart";
            this.parameterDtStart.Type = typeof(System.DateTime);
            this.parameterDtStart.Visible = false;
            // 
            // parameterDtEnd
            // 
            this.parameterDtEnd.Name = "parameterDtEnd";
            this.parameterDtEnd.Type = typeof(System.DateTime);
            this.parameterDtEnd.Visible = false;
            // 
            // parameterOrderType
            // 
            this.parameterOrderType.Name = "parameterOrderType";
            this.parameterOrderType.Type = typeof(short);
            this.parameterOrderType.ValueInfo = "0";
            this.parameterOrderType.Visible = false;
            // 
            // parameterOrderDetail
            // 
            this.parameterOrderDetail.Name = "parameterOrderDetail";
            this.parameterOrderDetail.Type = typeof(bool);
            this.parameterOrderDetail.ValueInfo = "False";
            // 
            // tableDetailStyle
            // 
            this.tableDetailStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.tableDetailStyle.BorderColor = System.Drawing.Color.White;
            this.tableDetailStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.tableDetailStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.75F);
            this.tableDetailStyle.ForeColor = System.Drawing.Color.Black;
            this.tableDetailStyle.Name = "tableDetailStyle";
            this.tableDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // HeaderDetailStyle
            // 
            this.HeaderDetailStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.HeaderDetailStyle.BorderColor = System.Drawing.Color.White;
            this.HeaderDetailStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.HeaderDetailStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI Semibold", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.HeaderDetailStyle.ForeColor = System.Drawing.Color.White;
            this.HeaderDetailStyle.Name = "HeaderDetailStyle";
            this.HeaderDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // tblOrderMainBindingSource
            // 
            this.tblOrderMainBindingSource.DataSource = typeof(tblOrderMain);
            // 
            // ReportOrdersMaster
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.tblOrderMainBindingSource});
            this.DataSource = this.tblOrderMainBindingSource;
            this.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(0, 0, 0, 2);
            this.PageHeight = 1803;
            this.PageWidth = 787;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterDtStart,
            this.parameterDtEnd,
            this.parameterOrderType,
            this.parameterOrderDetail});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.EvenStyle,
            this.OddStyle,
            this.HeaderStyle,
            this.tableDetailStyle,
            this.HeaderDetailStyle});
            this.StyleSheetPath = "";
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrtcOrdNo;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrtcOrdDate;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrtcOrdNoVal;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrtcOrdDateVal;
        private System.Windows.Forms.BindingSource tblOrderMainBindingSource;
        private DevExpress.XtraReports.UI.XRControlStyle EvenStyle;
        private DevExpress.XtraReports.UI.XRControlStyle OddStyle;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderStyle;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreportOrderDetail;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtStart;
        private DevExpress.XtraReports.Parameters.Parameter parameterDtEnd;
        private DevExpress.XtraReports.Parameters.Parameter parameterOrderType;
        private DevExpress.XtraReports.Parameters.Parameter parameterOrderDetail;
        private DevExpress.XtraReports.UI.XRControlStyle tableDetailStyle;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderDetailStyle;
    }
}
