using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSaleUserWithoutProfit : XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblProductQunatity clsTbPrdQuantity = new ClsTblProductQunatity();
        ClsTblBarcode clsTbBarcode = new ClsTblBarcode();
        ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub(SupplyType.SalesAll);
        List<tblPrdSaleDetail> tbPrdSaleDetailList;
        ICollection<tblUser> tbUserList;
        IEnumerable<tblPrdSaleDetail> tbPrdSaleDetailTmpList;

        private DateTime dtStart, dtEnd;

        public ReportSaleUserWithoutProfit()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterUserId.Description = "Users";
                parameterShowDetail.Description = "Detailed:";
                parameterDtStart.Description = "Date From";
                parameterDtEnd.Description = "Date To";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
            tblPrdSaleTotalBindingSource.DataSource = this.tbPrdSaleDetailTmpList;
            parameterShowDetail.Value = true;
            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
            new ClsReportHeaderData(this);
        }

        private void ReportSaleGroup_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            this.tbUserList = new Collection<tblUser>();
            this.tbPrdSaleDetailList = new List<tblPrdSaleDetail>();
            InitData();
            CalculateTotalProfit();
            SetUserTableVisibility();
            SetReportFooterVisibility();
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
            tblPrdSaleTotalBindingSource.DataSource = this.tbPrdSaleDetailTmpList;
        }

        
        
        private void InitData()
        {
            foreach (var userId in parameterUserId.Value as short[])
            {
                this.tbUserList.Add(new tblUser() { id = userId });
                InitPrdSaleDetailTmpList(userId);
                this.tbPrdSaleDetailList.AddRange(this.tbPrdSaleDetailTmpList);
            }
           if(((parameterShowDetail.Value as bool?) ?? true)) 
                InitProdSaleDetailList();

            this.DataSource = this.tbPrdSaleDetailList;
        tblUserDataSource.DataSource = this.tbUserList;
        tblPrdSaleTotalBindingSource.DataSource = this.tbPrdSaleDetailList;
        }
        private void InitProdSaleDetailList() {
            foreach (var item in this.tbPrdSaleDetailList)
            {
                item.prdBarcode = this.clsTbBarcode.GetBarcodeNoByPrdMsurId(item?.prdMsur ?? 0);

                var ppm = this.clsTbPrdMsur.GetPrdPriceMsurObjById(item.prdMsur);
                item.prdQuantString = $"{item.prdQuant} {ppm?.ppmMsurName}";

                var pq = this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdId(item.prdId);
                if (pq == null) continue;

                item.prdQuanRemaining = ppm?.ppmStatus switch
                {
                    2 => Convert.ToString(pq.prdSubQuantity),
                    3 => Convert.ToString(pq.prdSubQuantity3),
                    _ => Convert.ToString(pq.prdQuantity),
                } + $" {ppm?.ppmMsurName}";
            };
        }
        private void InitPrdSaleDetailTmpList(short userid)
        {
            IEnumerable<tblSupplySub> tbPrdSaleDetailTmpList2;

            using (accountingEntities db = new accountingEntities())
            {
                byte status1 = (byte)SupplyType.Sales, status2 = (byte)SupplyType.SalesPhase, status3 = (byte)SupplyType.SalesRtrn, status4 = (byte)SupplyType.SalesPhaseRtrn;
                tbPrdSaleDetailTmpList2= db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId&&x.supUserId== userid && x.supDate >= this.dtStart && x.supDate <= this.dtEnd &&
                  (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3 || x.supStatus == status4)).OrderBy(x => x.supDate);
            
            this.tbPrdSaleDetailTmpList = tbPrdSaleDetailTmpList2.GroupBy(x => new { x.supUserId, x.supMsur, x.supPrdId }, (key, grp) => new tblPrdSaleDetail()
                {
                    userId = Convert.ToInt16(key.supUserId),
                    prdMsur = Convert.ToInt32(key.supMsur),
                    prdId = Convert.ToInt32(key.supPrdId),
                    prdName = grp.Select(x => x.supPrdName).FirstOrDefault(),
                    prdQuant = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supQuanMain)),
                    prdPrice = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                    prdSalePrice = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                    prdDscntAmount = grp.Where(x => x.supStatus <= 8 && Convert.ToDouble(x.supDscntPercent) > 0).Sum(x => (Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble((x.supDscntPercent / 100))),
                    prdTax = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supTaxPrice)),
                    prdQuantRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supQuanMain)),
                    prdPriceRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                    prdSalePriceRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                    prdDscntAmountRtrn = grp.Where(x => x.supStatus >= 11 && Convert.ToDouble(x.supDscntPercent) > 0).Sum(x => (Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble((x.supDscntPercent / 100))),
                    prdTaxRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supTaxPrice)),
                    
                }).ToList();

                this.tbPrdSaleDetailTmpList.ToList().ForEach(c => c.prdSaleTotal = (c.prdSalePrice - c.prdDscntAmount + c.prdTax) - (c.prdSalePriceRtrn - c.prdDscntAmountRtrn + c.prdTaxRtrn));
                CalculateProfit();
            }
        }

        private void CalculateProfit()
        {
            foreach (var tbPrdSale in this.tbPrdSaleDetailTmpList)
            {
                tbPrdSale.prdQuant -= tbPrdSale.prdQuantRtrn;
                tbPrdSale.prdTax -= tbPrdSale.prdTaxRtrn;
                tbPrdSale.prdPrice -= tbPrdSale.prdPriceRtrn;
                tbPrdSale.prdSalePrice -= tbPrdSale.prdSalePriceRtrn;
                tbPrdSale.prdDscntAmount -= tbPrdSale.prdDscntAmountRtrn;
                tbPrdSale.prdSaleProfit = (tbPrdSale.prdSalePrice - tbPrdSale.prdDscntAmount) - tbPrdSale.prdPrice;
                tbPrdSale.prdSaleProfitPercent = $"{ ((tbPrdSale.prdSaleProfit == 0) ? 0 : ((tbPrdSale.prdPrice != 0) ? (tbPrdSale.prdSaleProfit * 100) / tbPrdSale.prdPrice : 100)):n2}%";
            }
        }

        private void CalculateTotalProfit()
        {
            if (this.tbUserList.Count <= 1) return;
            var tbPrdSaleTotal = new tblPrdSaleDetail();

            foreach (var tbPrdSale in this.tbPrdSaleDetailList)
            {
                tbPrdSaleTotal.prdTax += tbPrdSale.prdTax;
                tbPrdSaleTotal.prdPrice += tbPrdSale.prdPrice;
                tbPrdSaleTotal.prdSalePrice += tbPrdSale.prdSalePrice;
                tbPrdSaleTotal.prdDscntAmount += tbPrdSale.prdDscntAmount;
                tbPrdSaleTotal.prdSaleProfit += tbPrdSale.prdSaleProfit;
            }
            tbPrdSaleTotal.prdSaleTotal = (tbPrdSaleTotal.prdSalePrice - tbPrdSaleTotal.prdDscntAmount) + tbPrdSaleTotal.prdTax;
            tbPrdSaleTotal.prdSaleProfitPercent = $"{ ((tbPrdSaleTotal.prdSaleProfit == 0) ? 0 : ((tbPrdSaleTotal.prdPrice != 0) ? (tbPrdSaleTotal.prdSaleProfit * 100) / tbPrdSaleTotal.prdPrice : 100)):n2}%";

            SetTotalText(tbPrdSaleTotal);
        }

        private void SetTotalText(tblPrdSaleDetail tbPrdSaleTotal)
        {
            xrtcTotalFianlPrice.Text = $"{tbPrdSaleTotal.prdPrice:n3}";
            xrtcTotalFianlSalePrice.Text = $"{tbPrdSaleTotal.prdSalePrice:n2}";
            xrtcTotalFianlSaleTotal.Text = $"{tbPrdSaleTotal.prdSaleTotal:n2}";
            xrtcTotalFianlDiscount.Text = $"{tbPrdSaleTotal.prdDscntAmount:n2}";
            xrtcTotalFinalPrdTax.Text = $"{tbPrdSaleTotal.prdTax:n2}";
           
        }

        private void SetUserTableVisibility()
        {
            xrTableUser.Visible = (this.tbUserList.Count > 0) ? true : false;
        }

     
       
        private void XrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbUser.GetUserNameById(Convert.ToInt16(cell.Value));
        }
        private void SetReportFooterVisibility()
        {
            ReportFooter.Visible = (this.tbUserList.Count > 1) ? true : false;
        }

        private void ReportSale_WithoutProfit_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
            tblPrdSaleTotalBindingSource.DataSource = this.tbPrdSaleDetailTmpList;
            this.Detail.Visible=((parameterShowDetail.Value as bool?)??true);
            GroupHeader1.Visible = ((parameterShowDetail.Value as bool?) ?? true);
        }
        private void XrLabelTotal_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraReports.UI.XRLabel lbl = sender as XRLabel;
            xrLabelTotal.Text = (Convert.ToInt16(lbl.Value) > 0) ? $"إجمالي مبيعات المستخدم {this.clsTbUser.GetUserNameById(Convert.ToInt16(lbl.Value))}" : "الإجمالي";
        }
    }
}