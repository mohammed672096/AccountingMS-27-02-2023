using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingMS
{
    public partial class ReportProduct : XtraReport
    {
        accountingEntities db = new accountingEntities();
        ClsTblStore clsTbStore = new ClsTblStore();
        ClsTblProduct clsTbProduct = new ClsTblProduct();
        ClsTblProductQunatity clsTbPrdQuantity = new ClsTblProductQunatity();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblStockTransMain clsTbStockMain = new ClsTblStockTransMain();
        ClsTblStockTransSub clsTbStockSub = new ClsTblStockTransSub();
        ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub();
        ClsTblProductQtyOpn clsTbPrdQuanOpn = new ClsTblProductQtyOpn();
        ClsTblBarcode ClsTblBarcode = new ClsTblBarcode();

        private DateTime dtStart, dtEnd;
        private int prdId;
        private decimal totalIncome;
        private decimal totalOutcome;
        private double QtyIncome;
        private double QtyOutcome;

        public ReportProduct()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitData();
            InitDefaultData();
            new ClsReportHeaderData(this);
            this.ParametersRequestBeforeShow += ReportProduct_ParametersRequestBeforeShow;

            DetailStockTrans.BeforePrint += DetailStockTrans_BeforePrint;
            DetailSupplySub.BeforePrint += DetailSupplySub_BeforePrint;
            xrTableCellSupNo.BeforePrint += XrTableCellSupNo_BeforePrint;
        }

        private void XrTableCellSupNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraReports.UI.XRTableCell cell = sender as DevExpress.XtraReports.UI.XRTableCell;
            if (cell == null) return;
            cell.Text = clsTbSupplySub.GetSupplyNumber(cell.Text).ToString();
        }

        private void InitData()
        {
            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList;
        }
        private void ReportProduct_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "parameterProduct")
                {
                    GridLookUpEdit lookUpEdit = new GridLookUpEdit();

                    lookUpEdit.Properties.DataSource = tblProductBindingSource.DataSource;
                    lookUpEdit.Properties.DisplayMember = "prdName";
                    lookUpEdit.Properties.ValueMember = "id";
                    lookUpEdit.Properties.ValidateOnEnterKey = true;
                    lookUpEdit.Properties.ImmediatePopup = true;
                    lookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                    lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    lookUpEdit.Properties.View.Columns.AddRange(new GridColumn[]
                    {
                        new GridColumn {VisibleIndex=0,Visible=false, FieldName= "id" ,Caption ="id"  },
                        new GridColumn {VisibleIndex=0,Visible=true, FieldName= "prdName" ,Caption ="الاسم"  },
                        new GridColumn {VisibleIndex=0,Visible=true, FieldName= "prdNameEng" ,Caption ="English name"  },
                    });
                    var view = lookUpEdit.Properties.View;
                    view.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
                    view.OptionsSelection.UseIndicatorForSelection = true;
                    view.OptionsView.ShowAutoFilterRow = true;
                    view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
                    info.Editor = lookUpEdit;
                }
            }
        }



        private void InitDefaultData()
        {
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"التاريخ: {DateTime.Now:yyyy-MM-dd}") : string.Format($"Date: {DateTime.Now:dd-MM-yyyy}");
        }

        private void ReportProduct_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDateStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            if (txtBarcode.Value != null && !string.IsNullOrWhiteSpace(txtBarcode.Value.ToString()))
            {
                this.prdId = ClsTblBarcode.GetProductIDByNo(txtBarcode.Value.ToString());
                if (prdId == -1)
                {
                    System.Windows.Forms.MessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "Barcode error" : "خطأ في الباركود");
                    return;
                }
            }
            else
                this.prdId = Convert.ToInt32(parameterProduct.Value);

            this.totalIncome = 0; this.totalOutcome = 0;
            this.QtyIncome = this.QtyOutcome = 0;
            InitPrdData();
            InitStockTransData();
            InitOpenBalancData();
            InitBalancData();
            InitSupplyData();
            SetHeaderTotalAmount();
            SetHeaderPrdQuantity();
        }

        private void InitPrdData()
        {
            tblProductObjBindingSource.DataSource = this.clsTbProduct.GetPrdObjByPrdId(this.prdId);
        }

        private void InitStockTransData()
        {
            IEnumerable<tblStockTransSub> tbStockSubList = this.clsTbStockSub.GetStockTransListByPrdId(this.prdId).Where
                                                        (x => x.stcDate >= this.dtStart && x.stcDate < this.dtEnd);
            tblStockTransSubBindingSource.DataSource = tbStockSubList;
            SetDetailBandVisibility(tbStockSubList.Count(), BandStockTrans);
        }
        private void InitOpenBalancData()
        {
            List<AccountingMS.tblProductQtyOpn> tbPrdQuanOpn = new List<tblProductQtyOpn>();
            tbPrdQuanOpn = this.clsTbPrdQuanOpn.GetProductQtyOpnList.Where(x => x.qtyPrdId == this.prdId).ToList();
            tblOpenBalancSubBindingSource.DataSource = tbPrdQuanOpn;
            SetDetailBandVisibility(tbPrdQuanOpn.Count(), BandOpenBalance);
        }
        private void InitBalancData()
        {

            InventoryBalancingDetailBindingSource.DataSource = db.InventoryBalancingDetails.Where(x => x.ProductID == this.prdId).ToList();

            SetDetailBandVisibility((InventoryBalancingDetailBindingSource.DataSource as List<InventoryBalancingDetail>).Count(), BandInventoryBalancingDetail);
        }

        private void DetailStockTrans_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tblStockTransMain tbStockMain = this.clsTbStockMain.GetStockMainObjById(Convert.ToInt32(BandStockTrans.GetCurrentColumnValue("stcMainId")));
            if (tbStockMain == null) return;

            SetStockData(tbStockMain);
            SetStockTransDesc(tbStockMain.stcDesc);
        }

        private void SetStockData(tblStockTransMain tbStockMain)
        {
            xrtcStcNo.Text = tbStockMain.stcNo.ToString();
            string from = MySetting.GetPrivateSetting.LangEng ? "Statement:" : "من";
            string to = MySetting.GetPrivateSetting.LangEng ? "Statement:" : "إلى";
            xrtcStcStore.Text = $"{from} {this.clsTbStore.GetStoreNameById(tbStockMain.stcStrIdFrom)} {to} {this.clsTbStore.GetStoreNameById(tbStockMain.stcStrIdTo)}";
            xrtcStcQuantity.Text = $"{BandStockTrans.GetCurrentColumnValue("stcQuantity")} {this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(BandStockTrans.GetCurrentColumnValue("stcMsurId")))}";
        }

        private void SetStockTransDesc(string stcDesc)
        {
            xrtcStcDesc.Text = MySetting.GetPrivateSetting.LangEng ? "Statement:" : "البيان: " + stcDesc;
            SetDetailTable(!string.IsNullOrEmpty(stcDesc) ? true : false, !string.IsNullOrEmpty(stcDesc) ? 40 : 25);
        }

        private void SetDetailTable(bool isStcDescVisible, float height)
        {
            xrtrStcDesc.Visible = isStcDescVisible;
            xrTable6.HeightF = height;
            DetailStockTrans.HeightF = height;
        }
        Dictionary<int, int> SupplyNumber;
        private void InitSupplyData()
        {
            IEnumerable<tblSupplySub> tbSupplySubList = this.clsTbSupplySub.GetSupplySubListByPrdId(this.prdId).Where
                (x => x.supDate >= this.dtStart && x.supDate < this.dtEnd);

            SupplyNumber = new Dictionary<int, int>();

            Dictionary<int, double> QtyIn = new Dictionary<int, double>();
            Dictionary<int, double> QtyOut = new Dictionary<int, double>();

            foreach (var tbSupplySub in tbSupplySubList)
            {
                var unit = clsTbPrdMsur.GetPrdPriceMsurById(tbSupplySub.supMsur.Value);

                if (!QtyIn.ContainsKey(unit.ppmId)) QtyIn.Add(unit.ppmId, 0);

                if (tbSupplySub.supStatus == 3 || tbSupplySub.supStatus == 7 || tbSupplySub.supStatus == 11 || tbSupplySub.supStatus == 12)
                {
                    this.totalIncome += (Convert.ToDecimal(tbSupplySub.supDebit));

                    if (!QtyIn.ContainsKey(unit.ppmId)) QtyIn.Add(unit.ppmId, 0);
                    QtyIn[unit.ppmId] += tbSupplySub.supQuanMain.HasValue ? tbSupplySub.supQuanMain.Value : 0;


                }
                else
                {
                    this.totalOutcome += (Convert.ToDecimal(tbSupplySub.supCredit)); // * Convert.ToInt32(tbSupplySub.supQuanMain));

                    if (!QtyOut.ContainsKey(unit.ppmId)) QtyOut.Add(unit.ppmId, 0);
                    QtyOut[unit.ppmId] += tbSupplySub.supQuanMain.HasValue ? tbSupplySub.supQuanMain.Value : 0;

                }
            }
            tblSupplySubBindingSource.DataSource = tbSupplySubList;
            SetDetailBandVisibility(tbSupplySubList.Count(), BandSupplySub);


            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in QtyIn)
            {
                if (stringBuilder.Length > 0) stringBuilder.Append(", ");
                stringBuilder.Append(item.Value);
                stringBuilder.Append(clsTbPrdMsur.GetPrdPriceMsurNameById(item.Key));

            }
            xrTableCellTotalIncoming.Text = stringBuilder.ToString();

            stringBuilder = new StringBuilder();
            foreach (var item in QtyOut)
            {
                if (stringBuilder.Length > 0) stringBuilder.Append(", ");
                stringBuilder.Append(item.Value);
                stringBuilder.Append(clsTbPrdMsur.GetPrdPriceMsurNameById(item.Key));
            }
            xrTableCellTotalOutgoing.Text = stringBuilder.ToString();

        }

        private void DetailSupplySub_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrtcSupStatus.Text = ClsSupplyStatus.GetString(Convert.ToByte(BandSupplySub.GetCurrentColumnValue("supStatus")));
            xrtcSupMsur.Text = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(BandSupplySub.GetCurrentColumnValue("supMsur")));
        }
        private void DetailOpenBalance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrtcPrdMsurId.Text = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(BandOpenBalance.GetCurrentColumnValue("qtyPrdMsurId")));

        }
        private void SetDetailBandVisibility(int listCount, DetailReportBand detailBand)
        {
            detailBand.Visible = (listCount > 0) ? true : false;
        }

        private void SetHeaderTotalAmount()
        {
            xrTableCell30.Text = string.Format($"{this.totalIncome:0,0.00}");
            xrTableCell31.Text = string.Format($"{this.totalOutcome:0,0.00}");
            //xrTableCell30.Text = string.Format($"{this.QtyIncome:0,0.00}");
            //xrTableCell31.Text = string.Format($"{this.QtyOutcome:0,0.00}");
        }

        private void SetHeaderPrdQuantity()
        {
            tblProductQunatity tbPrdQuantity = clsTbPrdQuantity.GetTotalPrdQuantityByPrdId(this.prdId);
            string strQuantity = null;

            if (tbPrdQuantity?.prdQuantity > 0)
                strQuantity = string.Format($"{tbPrdQuantity.prdQuantity} {clsTbPrdMsur.GetPrdPriceMsurUnitName1ByPrdId(this.prdId)}");
            if (tbPrdQuantity?.prdSubQuantity > 0)
            {
                if (strQuantity != null)
                    strQuantity += " - ";
                strQuantity += string.Format($"{tbPrdQuantity.prdSubQuantity} {clsTbPrdMsur.GetPrdPriceMsurUnitName2ByPrdId(this.prdId)}");
            }
            if (tbPrdQuantity?.prdSubQuantity3 > 0)
            {
                if (strQuantity != null)
                    strQuantity += " - ";
                strQuantity += string.Format($"{tbPrdQuantity.prdSubQuantity3} {clsTbPrdMsur.GetPrdPriceMsurUnitName3ByPrdId(this.prdId)}");
            }

            xrTableCellQuantity.Text = strQuantity;
        }

        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
                parameterDateStart.Description = "Date From";
                parameterDateEnd.Description = "Date To";

                parameterProduct.Description = "Product";
                txtBarcode.Description = "Barcode";

            }
        }
    }
}
