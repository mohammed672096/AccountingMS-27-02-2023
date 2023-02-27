using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSalePurchase : XtraReport
    {
        ReportSalePurchaseDetail rprtSalePurchaseDetail;
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblCurrency clsCurrency = new ClsTblCurrency();
        ClsTblSupplyMain clsTbSupplyMain = new ClsTblSupplyMain();
        List<tblSupplyMain> tbSupplyMainList;
        List<tblSupplyMain> tbSupplyMainTmpList;
        ICollection<tblUser> tbUserList;

        private byte currencyId, cashType;
        private DateTime dtStart, dtEnd;
        private double total, totalTax, totalDiscount;
        accountingEntities db = new accountingEntities();
        byte status = 1;
        public ReportSalePurchase(byte _status)
        {
            status = _status;
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitData(status);
            InitText(status);
            InitDefaultData();
            InitSubReport();
            new ClsReportHeaderData(this);

            xrSubRprtSalePurchaseDetail.BeforePrint += XrSubRprtSalePurchaseDetail_BeforePrint;
        }

        private void InitSubReport()
        {
            this.rprtSalePurchaseDetail = new ReportSalePurchaseDetail();

            xrSubRprtSalePurchaseDetail.ReportSource = this.rprtSalePurchaseDetail;
            xrSubRprtSalePurchaseDetail.ParameterBindings.Add(new ParameterBinding("parameterUserId", tblUserDataSource, "id"));
        }

        private void InitDefaultData()
        {
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
                tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
        }

        private void InitData(byte status)
        {
            this.tbSupplyMainList = (status == 1) ? this.clsTbSupplyMain.GetSupplyMainListPurchase() : this.clsTbSupplyMain.GetSupplyMainListSale();
        }

        private void InitText(byte status)
        {
            if (status == 2)
            {
                xrLabel17.Visible = false;
                xrLabel3.Visible = true;
                xrTableCellMain.Text = (!MySetting.GetPrivateSetting.LangEng) ? "كشف فواتير المبيعات" : "Sales Statement";
            }
            string Userpurchases = MySetting.GetPrivateSetting.LangEng ? "User purchases" : "مشتريات المستخدم";
            string UserSales = MySetting.GetPrivateSetting.LangEng ? "UserSales" : "مبيعات المستخدم";

            xrtcUserSalePurchase.Text = status == 1 ? Userpurchases : UserSales;
            xrtcUserSalePurchase.WidthF = status == 1 ? 180F : 170F;

            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
        }

        private void ReportPurchases_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "parameterCurrency")
                {
                    LookUpEdit lookUpEdit = new LookUpEdit();
                    lookUpEdit.Properties.DataSource = clsCurrency.GetCurrencyList;
                    lookUpEdit.Properties.DisplayMember = "curName";
                    lookUpEdit.Properties.ValueMember = "id";
                    lookUpEdit.Properties.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("curName", 0, ""),
                    });
                    info.Editor = lookUpEdit;
                }
            }
        }

        private void ReportPurchases_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDateStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDateEnd.Value);
            this.currencyId = Convert.ToByte(parameterCurrency.Value);
            this.cashType = Convert.ToByte(parameterCashType.Value);

            ResetTotalValues();
            InitLists();
            InitData();
            InitText();
            CalculateTotal();
            SetBandVisibility();
            SetUserTableVisibility();
            SetSubReportLocation();
            SetReportFooterVisibility();
        }

        private void XrSubRprtSalePurchaseDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.rprtSalePurchaseDetail.DataSource = this.tbSupplyMainTmpList;
        }

        private void InitLists()
        {
            this.tbUserList = new Collection<tblUser>();
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
            {
                if (status == 2)
                {
                    this.tbSupplyMainTmpList = db.tblSupplyMains.Where(x =>
                        x.supCurrency == this.currencyId && x.supDate >= this.dtStart && x.supDate <= this.dtEnd &&
                        (this.cashType != 3 ? x.supIsCash == this.cashType : x.supIsCash <= 2) &&
                        (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
                }
                else
                {
                    this.tbSupplyMainTmpList = db.tblSupplyMains.Where(x => x.supCurrency == this.currencyId && x.supDate >= this.dtStart &&
                    x.supDate <= this.dtEnd && (this.cashType != 3 ? x.supIsCash == this.cashType : x.supIsCash <= 2)
                    && (x.supStatus == 3 || x.supStatus == 7 || x.supStatus == 9 || x.supStatus == 10)).ToList();
                }

            }
            else {
                if (status == 2)
                {
                    this.tbSupplyMainTmpList = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                        x.supCurrency == this.currencyId && x.supDate >= this.dtStart && x.supDate <= this.dtEnd &&
                        (this.cashType != 3 ? x.supIsCash == this.cashType : x.supIsCash <= 2) &&
                        (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
                }
                else
                {
                    this.tbSupplyMainTmpList = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supCurrency == this.currencyId && x.supDate >= this.dtStart &&
                    x.supDate <= this.dtEnd && (this.cashType != 3 ? x.supIsCash == this.cashType : x.supIsCash <= 2) && (x.supStatus == 3 || x.supStatus == 7 || x.supStatus == 9 || x.supStatus == 10)).ToList();
                }
            }
            foreach (var userId in parameterUserId.Value as short[])
                this.tbUserList.Add(new tblUser() { id = userId });

            tblUserDataSource.DataSource = this.tbUserList;
        }

        private void InitText()
        {
            xrTableCellCurrency.Text = clsCurrency.GetCurrencyNameById(this.currencyId);
        }

        private void CalculateTotal()
        {
            foreach (var tbSupplyMain in tbSupplyMainList) CalculateTotal(tbSupplyMain);
        }

        private void CalculateTotal(tblSupplyMain tbSupplyMain)
        {
            if (tbSupplyMain.supStatus == 3 || tbSupplyMain.supStatus == 7 || tbSupplyMain.supStatus == 4 || tbSupplyMain.supStatus == 8)
            {

                this.totalTax += Convert.ToDouble(tbSupplyMain.supTaxPrice);
                this.totalDiscount += Convert.ToDouble(tbSupplyMain.supDscntAmount);
                this.total += tbSupplyMain.supTotal;
                //this.total += Convert.ToDouble(tbSupplyMain.supTaxPrice);
                //this.total += Convert.ToDouble(tbSupplyMain.supDscntAmount);
            }
            else
            {
                this.total -= tbSupplyMain.supTotal;
                //this.total -= Convert.ToDouble(tbSupplyMain.supTaxPrice);
                //this.total -= Convert.ToDouble(tbSupplyMain.supDscntAmount);
                this.totalTax -= Convert.ToDouble(tbSupplyMain.supTaxPrice);
                this.totalDiscount -= Convert.ToDouble(tbSupplyMain.supDscntAmount);
            }
        }

        private void ResetTotalValues()
        {
            this.total = 0;
            this.totalTax = 0;
            this.totalDiscount = 0;
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //SetStatus();
            //SetTotalColumn();
        }

        private void SetStatus()
        {
            //byte status = Convert.ToByte(GetCurrentColumnValue("supStatus")), isCash = Convert.ToByte(GetCurrentColumnValue("supIsCash"));
            //xrTableCellSupStatus.Text = ClsSupplyStatus.GetString(status, isCash);
        }

        private void SetTotalColumn()
        {
            //double total = Convert.ToDouble(GetCurrentColumnValue("supTotal")), 
            //    supTax = Convert.ToDouble(GetCurrentColumnValue("supTaxPrice")),
            //    supDiscount = Convert.ToDouble(GetCurrentColumnValue("supDscntAmount"));
            ////xrTableCellTotalFinalMain.Text = $"{(total + supTax):n2}";
            //xrTableCellTotalFinalMain.Text = $"{(total + supTax) - supDiscount:n2}";
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //xrTableCellTotal.Text = string.Format($"{this.total:n2}");
            //xrTableCellTotalTax.Text = string.Format($"{this.totalTax:n2}");
            //xrTableCellTotalDiscount.Text = string.Format($"{this.totalDiscount:n2}");
            //xrTableCellTotalFinal.Text = string.Format($"{(this.total + this.totalTax - this.totalDiscount):n2}");
            //xrTableCellTotalFinal.Text = string.Format($"{(this.total + this.totalTax) - this.totalDiscount:n2}");
        }

        private void SetBandVisibility()
        {
            bool visbility = (this.tbUserList.Count >= 1 || this.tbSupplyMainTmpList.Count >= 1) ? true : false;

            Detail.Visible = visbility;
        }

        private void SetUserTableVisibility()
        {
            xrTableUser.Visible = (this.tbUserList.Count > 0) ? true : false;
        }

        private void SetSubReportLocation()
        {
            xrSubRprtSalePurchaseDetail.LocationF = new System.Drawing.PointF(10, (this.tbUserList.Count > 0) ? 55 : 10);
        }

        private void SetReportFooterVisibility()
        {
            ReportFooter.Visible = (this.tbUserList.Count > 1) ? true : false;
        }

        private void xrtcUserId_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbUser.GetUserNameById(Convert.ToInt16(cell.Value));
        }



        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterCashType.Description = "Payment method:";
                parameterCurrency.Description = "Currency:";
                parameterUserId.Description = "Users";
                parameterDateStart.Description = "Date From";
                parameterDateEnd.Description = "Date To";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
    }
}
