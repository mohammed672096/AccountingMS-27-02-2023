using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AccountingMS.Classes;
using DevExpress.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using System.Security.Principal;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Extensions;
using DevExpress.XtraLayout;
using DevExpress.ChartRangeControlClient.Core;
using System.Data.Entity;
using DevExpress.XtraGrid;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraReports.UI;

namespace AccountingMS.Report
{
    public partial class FormReportInvoiceFromTo : DevExpress.XtraEditors.XtraForm
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsAppearance clsAppearance = new ClsAppearance();
        byte docType1;
        public FormReportInvoiceFromTo(byte docType)
        {
            InitializeComponent();
            docType1 = docType;
            clsAppearance.AppearanceGridView(gridView);
            clsAppearance.AppearanceGridView(gridView1);
            gridView1.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            clsAppearance.LayoutAppearance(layoutControlGroup2);
            clsAppearance.LayoutAppearance(layoutControlGroup4);
            labelControl1.BackColor = layoutControlGroup4.AppearanceGroup.BorderColor;
            labelControl1.ForeColor = Color.White;
            if (docType == 1)
            {
                this.Text = MySetting.GetPrivateSetting.LangEng ? "Purchases Report" : "تقارير المشتريات";
                InvoType.Properties.Items.AddRange((from s in ClsSupplyStatus.InvoicePurTypesList select new CheckedListBoxItem() { Description = s.Name, Value = s.ID }).ToArray());
                supplyTypes.AddRange(new SupplyType[] { SupplyType.Purchase, SupplyType.PurchasePhase, SupplyType.PurchaseRtrn, SupplyType.PurchasePhaseRtrn });
                ReportModel.Properties.Items.AddRange((from s in ReportSaleModelsList where s.ID != 3 select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
                ReportModel.Properties.Items.ForEach(x => x.Description = MySetting.GetPrivateSetting.LangEng ? x.Description.Replace("Sale", "Purchase") : x.Description.Replace("مبيعات", "مشتريات"));
            }
            else if (docType ==2)
            {
                this.Text = MySetting.GetPrivateSetting.LangEng ? "Sales Report" : "تقارير المبيعات";
                InvoType.Properties.Items.AddRange((from s in ClsSupplyStatus.InvoiceSaleTypesList select new CheckedListBoxItem() { Description = s.Name, Value = s.ID }).ToArray());
                supplyTypes.AddRange(new SupplyType[] { SupplyType.Sales, SupplyType.SalesPhase, SupplyType.SalesRtrn, SupplyType.SalesPhaseRtrn });
                ReportModel.Properties.Items.AddRange((from s in ReportSaleModelsList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            }
            ReportModel.AutoSizeInLayoutControl = true;
            PayMethod.Properties.Items.AddRange((from s in ClsSupplyStatus.PayMethodsList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            PayMethod.Properties.Items.Add(new RadioGroupItem() { Description =MySetting.GetPrivateSetting.LangEng?"All":"الكل", Value = 3 });
            PayMethod.EditValue = 3;
            ReportType.Properties.Items.AddRange((from s in ClsSupplyStatus.ReportTypeList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            //ReportType.
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            InvoType.Closed += InvoType_Closed;
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
            PayMethod.EditValueChanged += PayMethod_EditValueChanged;
        }
        public static List<ValueAndID> ReportSaleModelsList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)ReportSaleModel.SaleAndPur , Name  =MySetting.GetPrivateSetting.LangEng?"Sales Report":ReportSaleModel.SaleAndPur.GetDescription()},
                new ValueAndID() { ID = (byte)ReportSaleModel.SaleCasher , Name  =MySetting.GetPrivateSetting.LangEng?"Casher Sales Report":ReportSaleModel.SaleCasher.GetDescription()},
                new ValueAndID() { ID = (byte)ReportSaleModel.SaleDetail , Name  =MySetting.GetPrivateSetting.LangEng?"Sales Detail Report":ReportSaleModel.SaleDetail.GetDescription()},
                new ValueAndID() { ID = (byte)ReportSaleModel.SaleGroupSt , Name  =MySetting.GetPrivateSetting.LangEng?"Sales Group Store Report":ReportSaleModel.SaleGroupSt.GetDescription()},
                //new ValueAndID() { ID = (byte)ReportSaleModel.SaleGroupStRoll , Name  =MySetting.GetPrivateSetting.LangEng?"Sales Group Store Report Roll":ReportSaleModel.SaleGroupStRoll.GetDescription()},
                new ValueAndID() { ID = (byte)ReportSaleModel.BranchSale , Name  =MySetting.GetPrivateSetting.LangEng?"Branch sales Report":ReportSaleModel.BranchSale.GetDescription()},
                //new ValueAndID() { ID = (byte)ReportSaleModel.SaleUser , Name  =MySetting.GetPrivateSetting.LangEng?"Sales Users Report":ReportSaleModel.SaleUser.GetDescription()},
                //new ValueAndID() { ID = (byte)ReportSaleModel.SaleTotal , Name  =MySetting.GetPrivateSetting.LangEng?"Total sales report":ReportSaleModel.SaleTotal.GetDescription()},
        };
        private void PayMethod_EditValueChanged(object sender, EventArgs e)
        {
            if (this.IsActive)
                Refresh_Acc();
        }

        private void InvoType_Closed(object sender, ClosedEventArgs e)
        {
            if (this.IsActive)
            {
                supplyTypes.Clear();
                InvoType.Properties.Items.Where(x => x.CheckState == CheckState.Checked).ForEach(x =>
                {
                    switch ((SupplyType)((byte)x.Value))
                    {
                        case SupplyType.Purchase:
                            supplyTypes.Add(SupplyType.Purchase);
                            supplyTypes.Add(SupplyType.PurchasePhase);
                            break;
                        case SupplyType.PurchaseRtrn:
                            supplyTypes.Add(SupplyType.PurchaseRtrn);
                            supplyTypes.Add(SupplyType.PurchasePhaseRtrn);
                            break;
                        case SupplyType.Sales:
                            supplyTypes.Add(SupplyType.Sales);
                            supplyTypes.Add(SupplyType.SalesPhase);
                            break;
                        case SupplyType.SalesRtrn:
                            supplyTypes.Add(SupplyType.SalesRtrn);
                            supplyTypes.Add(SupplyType.SalesPhaseRtrn);
                            break;
                    }
                });
                Refresh_Acc();
            }
        }
        tblSupplyMain tblSupplyMain=new tblSupplyMain();
        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) => e.RelationCount = 1;
        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e) => e.IsEmpty = false;
        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e) => e.RelationName = "Level1";
        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            using (accountingEntities db = new accountingEntities())
            e.ChildList = db.tblSupplySubs.AsNoTracking().Where(x => x.supNo == GetFoucsedSupplyMainId&& x.supBrnId ==Session.CurBranch.brnId).ToList();
        }
        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null|| e.ListSourceRowIndex<0) return;
            switch (e.Column.FieldName)
            {
                case nameof(tblSupplyMain.supStatus)when(e.Value is byte state):
                    e.DisplayText = ClsSupplyStatus.GetString(state, (byte)gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, colIsCash));
                    break;
                case nameof(tblSupplyMain.supCurrency) when (e.Value is byte curr):
                    e.DisplayText = Session.Currencies?.FirstOrDefault(x => x.id == curr)?.curName;
                    break;
                case nameof(tblSupplyMain.supBoxId) when (e.Value is short boxid):
                    e.DisplayText = Session.Boxes?.FirstOrDefault(x => x.id == boxid)?.boxName;
                    break;
                case nameof(tblSupplyMain.supBankId) when (e.Value is short BankId):
                    e.DisplayText = Session.Banks?.FirstOrDefault(x => x.id == BankId)?.bankName;
                    break;
                case nameof(tblSupplyMain.supCustSplId) when (e.Value is int cust && gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, colStatus) is byte typ):
                   if (typ == 4|| typ == 8|| typ == 11|| typ ==12)
                        e.DisplayText = Session.Customers?.FirstOrDefault(x => x.id == cust)?.custName;
                   else if (typ == 3 || typ == 7 || typ == 9 || typ == 10)
                        e.DisplayText = Session.Suppliers?.FirstOrDefault(x => x.id == cust)?.splName;
                    break;
                case nameof(tblSupplyMain.supUserId) when (e.Value is short u):
                    e.DisplayText = Session.tblUser?.FirstOrDefault(x => x.id == u)?.userName;
                    break;
                case nameof(tblSupplyMain.supBrnId) when (e.Value is short b):
                    e.DisplayText = Session.Branches?.FirstOrDefault(x => x.brnId == b)?.brnName;
                    break;
                default:
                    break;
            }
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.Name == colsupPrdName.Name && e.Value is int ProId1)
                e.DisplayText = Session.Products?.FirstOrDefault(x => x.id == ProId1)?.prdName;
            else if (e.Column.Name == colsupPrdNo.Name && e.Value is int ProId)
                e.DisplayText = Session.Products?.FirstOrDefault(x => x.id == ProId)?.prdNo;
            else if (e.Column.FieldName =="supMsur" && e.Value is int pMsur)
                e.DisplayText = Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == pMsur)?.ppmMsurName;
        }
        private void Print_Click(object sender, EventArgs e)
        {
            RReportTypesFun();
            Print(groupBand);
        }
        ReportForm frmReport;
        public void Print(DevExpress.XtraReports.UI.XtraReport Report)
        {
            frmReport.documentViewer1.DocumentSource = Report;
            frmReport.Show();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        XtraReport groupBand;
        List<tblSupplyMain> Filter_data = new List<tblSupplyMain>();
        byte s1, s2,s3,s4;
        public void RReportTypesFun()
        {
            flydDialog.WaitForm(this, 1);
            if (docType1 == 1)
            {
                s1 = 3; s2 = 7; s3 = 9; s4 = 10;
            }
            else
            {
                s1 = 4; s2 = 8; s3 = 11; s4 = 12;
            }
            Filter_data.Clear();
            if (!string.Empty.Contains(gridView.FilterPanelText))
            {
                for (int i = 0; i < gridView.RowCount; i++)
                    Filter_data.Add(gridView.GetRow(i) as tblSupplyMain);
            }
            else Filter_data= (supplyMainBindingSource.List as IList<tblSupplyMain>).ToList();
            switch ((ReportSaleModel)((byte)ReportModel.EditValue))
            {
                case ReportSaleModel.SaleAndPur:
                    groupBand = new ReportSalePurGroUser(dtime_Start.DateTime, dtime_End.DateTime, docType1);
                    groupBand.DataSource = Filter_data;
                    break;
                case ReportSaleModel.SaleCasher:
                    groupBand = new ReportSaleCashier1(dtime_Start.DateTime, dtime_End.DateTime,docType1);
                    var box = BoxList.Count > 0 ? BoxList : Session.Boxes;
                    groupBand.DataSource = Filter_data.Where(x => box.Any(y => y.boxAccNo == x.supAccNo)).GroupBy(x =>
                         new { x.supAccNo, x.supUserId }, (key, grp) => new
                         {
                             InvCount = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Count(),
                             Total = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTotal),
                             TotalTax = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTaxPrice ?? 0),
                             TotalDscnt = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supDscntAmount ?? 0),
                             TotalBank = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supBankAmount ?? 0),
                             TotalCash = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTotal + (x.supTaxPrice ?? 0) - (x.supDscntAmount ?? 0) - (x.supBankAmount ?? 0)),

                             InvRtrnCount = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Count(),
                             TotalRtrn = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTotal),
                             TotalTaxRtrn = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTaxPrice ?? 0),
                             TotalDscntRtrn = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supDscntAmount ?? 0),
                             TotalBankRtrn = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supBankAmount ?? 0),
                             TotalCashRtrn = grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTotal + (x.supTaxPrice ?? 0) - (x.supDscntAmount ?? 0) - (x.supBankAmount ?? 0)),
                             HeaderText = (docType1 == 1 ? "مشتريات " : "مبيعات ")+ grp.FirstOrDefault().supAccName + $"\nالمستخدم: {this.clsTbUser.GetUserNameById(key.supUserId)}",
                         });
                    break;
                case ReportSaleModel.SaleDetail:
                    using (var db = new accountingEntities())
                    {
                        var first = (from m in Filter_data.Where(x => x.supTotal > 0)
                                     join s in db.tblSupplySubs on (m.id, m.supStatus) equals (s.supNo, s.supStatus) into SupList
                                     select new
                                     {
                                         supAccNo = m.supAccNo,
                                         supAccName = m.supAccName,
                                         supStatus = m.supStatus,
                                         supDate = m.supDate,
                                         supNo = m.supNo,
                                         supPrdPrice = SupList.Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                                         supPrdSalePrice = SupList.Sum(x => (x.supSalePrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                                         supTotal = SupList.Sum(x => (x.supSalePrice ?? 0) * Convert.ToDouble(x.supQuanMain)) - (m.supDscntAmount ?? 0),
                                         supTaxPrice = SupList.Sum(x => x.supTaxPrice ?? 0),
                                         supTaxPercent = (m.supTaxPercent ?? 0) / 100d,
                                         supBankAmount = m.supBankAmount ?? 0,
                                         supIsCash = m.supIsCash,
                                         paidCash = m.paidCash ?? 0,
                                         supDscntPercent = (m.supDscntPercent ?? 0) / 100d,
                                         supDscntAmount = SupList.Sum(x => x.supDscntAmount ?? 0)
                                     }).ToList();
                        var data = (from m in first
                                    select new
                                    {
                                        m.supAccNo,
                                        m.supAccName,
                                        m.supStatus,
                                        m.supDate,
                                        m.supNo,
                                        m.supPrdPrice,
                                        m.supPrdSalePrice,
                                        m.supTotal,
                                        supProfit = m.supTotal - m.supPrdPrice,
                                        supProfitPercent = m.supPrdPrice != 0 ? (float)Math.Round((m.supTotal - m.supPrdPrice) * 100 / m.supPrdPrice, 2, MidpointRounding.AwayFromZero) : 100,
                                        m.supTaxPrice,
                                        m.supTaxPercent,
                                        supTotalFinal = m.supTotal + m.supTaxPrice,
                                        supPaidCash = m.supIsCash == 1 ? m.supTotal + m.supTaxPrice - m.supBankAmount : Convert.ToDouble(m.paidCash),
                                        m.supBankAmount,
                                        supPaidCredit = m.supIsCash == 2 ? m.supTotal + m.supTaxPrice - m.supBankAmount - Convert.ToDouble(m.paidCash) : 0,
                                        m.supIsCash,
                                        m.supDscntPercent,
                                        m.supDscntAmount
                                    }).ToList();

                        var total = data.GroupBy(x => new { x.supAccNo }, (key, grp) => new totals
                        {
                            totalPrdPrice = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supPrdPrice) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supPrdPrice),
                            totalPrdSalePrice = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supPrdSalePrice) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supPrdSalePrice),
                            totalDscntAmount = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supDscntAmount) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supDscntAmount),
                            totalTaxPrice = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTaxPrice) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTaxPrice),
                            totalFinal = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTotalFinal) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTotalFinal),
                            totalPaidCash = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supPaidCash) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supPaidCash),
                            totalPaidCredit = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supPaidCredit) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supPaidCredit),
                            totalPaidBank = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supBankAmount) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supBankAmount),
                            totalPrice = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supTotal) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supTotal),
                            totalProfit = grp.Where(x => x.supStatus ==s1 || x.supStatus ==s2).Sum(x => x.supProfit) -
                            grp.Where(x => x.supStatus ==s3 || x.supStatus ==s4).Sum(x => x.supProfit),
                            supAccNo = key.supAccNo,
                        }).ToList();
                        groupBand = new ReportSalePurDetail(dtime_Start.DateTime, dtime_End.DateTime, docType1, total);
                        groupBand.DataSource = data;
                    }
                    break;
                case ReportSaleModel.SaleGroupSt:
                    var group1 = GroupStrList.Count > 0 ? GroupStrList : Session.tblGroupStr;
                    using (var db = new accountingEntities())
                    {
                        var first1 = (from m in Filter_data//.Where(x => x.supTotal > 0)
                                      join s in db.tblSupplySubs on m.id equals s.supNo
                                      join d in group1 on s.supAccNo equals d.grpAccNo
                                      select s).ToList();
                        var first = (first1.GroupBy(x => new {  x.supAccNo,  x.supPrdId ,x.supMsur, x.supUserId }, (key, grp) => new tblPrdSaleDetail
                        {
                            grpAccNo = key.supAccNo,
                            userId = key.supUserId??0,
                            prdMsur = key.supMsur??0,
                            prdId=key.supPrdId??0,
                            prdName = grp?.FirstOrDefault()?.supPrdName,
                            prdBarcode= grp.FirstOrDefault()?.supPrdBarcode,
                            prdQuant = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => Convert.ToDouble(x.supQuanMain)),
                            prdPrice = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => (x.supPrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdSalePrice = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                            prdDscntAmount = grp.Where(x => (x.supStatus == s1 || x.supStatus == s2) && (x.supDscntPercent ?? 0) > 0).Sum(x => (Price(x) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble(x.supDscntPercent / 100)),
                            prdTax = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => x.supTaxPrice ?? 0),
                            prdQuantRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => x.supQuanMain ?? 0),
                            prdPriceRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => (x.supPrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdSalePriceRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => (x.supSalePrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdDscntAmountRtrn = grp.Where(x => (x.supStatus == s3 || x.supStatus == s4) && (x.supDscntPercent ?? 0) > 0).Sum(x => (Price(x) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble(x.supDscntPercent / 100)),
                            prdTaxRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => x.supTaxPrice ?? 0),
                        }).ToList());
                        var last = (from f in first
                                    select new tblPrdSaleDetail
                                    {
                                        grpAccNo = f.grpAccNo,
                                        userId = f.userId,
                                        prdMsur = f.prdMsur,
                                        prdId = f.prdId,
                                        prdName = f.prdName,
                                        prdBarcode=f.prdBarcode,
                                        prdQuant = f.prdQuant - f.prdQuantRtrn,
                                        prdPrice = f.prdPrice - f.prdPriceRtrn,
                                        prdSalePrice = f.prdSalePrice - f.prdSalePriceRtrn,
                                        prdDscntAmount = f.prdDscntAmount - f.prdDscntAmountRtrn,
                                        prdTax = f.prdTax - f.prdTaxRtrn,
                                        prdQuantRtrn = f.prdQuantRtrn,
                                        prdPriceRtrn = f.prdPriceRtrn,
                                        prdSalePriceRtrn = f.prdSalePriceRtrn,
                                        prdDscntAmountRtrn = f.prdDscntAmountRtrn,
                                        prdTaxRtrn = f.prdTaxRtrn,
                                    }).ToList();
                        var last2 = (from f1 in last
                                     from u in Session.tblPrdPriceMeasurment
                                     where u.ppmId==f1.prdMsur
                                     select new tblPrdSaleDetail
                                     {
                                         grpAccNo = f1.grpAccNo,
                                         userId = f1.userId,
                                         prdMsur = f1.prdMsur,
                                         prdQuantString= f1.prdQuant+" "+u.ppmMsurName,
                                         prdId = f1.prdId,
                                         prdName = f1.prdName,
                                         prdBarcode = f1.prdBarcode,
                                         prdQuant = f1.prdQuant,
                                         prdPrice = f1.prdPrice,
                                         prdSalePrice = f1.prdSalePrice,
                                         prdDscntAmount = f1.prdDscntAmount,
                                         prdTax = f1.prdTax,
                                         prdQuantRtrn = f1.prdQuantRtrn,
                                         prdPriceRtrn = f1.prdPriceRtrn,
                                         prdSalePriceRtrn = f1.prdSalePriceRtrn,
                                         prdDscntAmountRtrn = f1.prdDscntAmountRtrn,
                                         prdTaxRtrn = f1.prdTaxRtrn,
                                         prdSaleProfit = f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice,
                                         prdSaleTotal = ((docType1 == 1 ?f1.prdPrice: f1.prdSalePrice) - f1.prdDscntAmount) + f1.prdTax,
                                         prdSaleProfitPercent = $"{ ((f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice) == 0 ? 0 : ((f1.prdPrice != 0) ? ((f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice) * 100) / f1.prdPrice : 100)):n2}%"//; ((f.prdSalePrice - f.prdDscntAmount - f.prdPrice)==0 ? 0 : ((f.prdSalePrice - f.prdDscntAmount - f.prdPrice) * 100 / f.prdPrice)).ToString()
                                     }).ToList();
                        
                        groupBand = new ReportSalePurGroup(dtime_Start.DateTime, dtime_End.DateTime, docType1);
                        if (((byte)ReportType.EditValue) == 1)
                            ((ReportSalePurGroup)groupBand).Detail.Visible = ((ReportSalePurGroup)groupBand).GroupFooter1.Visible= 
                                ((ReportSalePurGroup)groupBand).GroupHeader1.Visible= false;
                        groupBand.DataSource = last2;
                    }
                  
                    break;
                case ReportSaleModel.SaleGroupStRoll:
                    break;
                case ReportSaleModel.BranchSale:
                    var Branch1 = /*BranchStrList.Count > 0 ? BranchStrList :*/ Session.Branches;
                    using (var db = new accountingEntities())
                    {
                        var first1 = (from m in Filter_data//.Where(x => x.supTotal > 0)
                                      join s in db.tblSupplySubs on m.id equals s.supNo
                                      join d in Branch1 on s.supBrnId equals d.brnId
                                      select s).ToList();
                        var first = (first1.GroupBy(x => new { x.supPrdId, x.supMsur, x.supBrnId }, (key, grp) => new tblPrdSaleDetail
                        {
                            BranchId = key.supBrnId??0,
                            prdMsur = key.supMsur ?? 0,
                            prdId = key.supPrdId ?? 0,
                            prdName = grp?.FirstOrDefault()?.supPrdName,
                            prdBarcode = grp.FirstOrDefault()?.supPrdBarcode,
                            prdQuant = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => Convert.ToDouble(x.supQuanMain)),
                            prdPrice = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => (x.supPrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdSalePrice = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                            prdDscntAmount = grp.Where(x => (x.supStatus == s1 || x.supStatus == s2) && (x.supDscntPercent ?? 0) > 0).Sum(x => (Price(x) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble(x.supDscntPercent / 100)),
                            prdTax = grp.Where(x => x.supStatus == s1 || x.supStatus == s2).Sum(x => x.supTaxPrice ?? 0),
                            prdQuantRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => x.supQuanMain ?? 0),
                            prdPriceRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => (x.supPrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdSalePriceRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => (x.supSalePrice ?? 0) * Convert.ToDouble(x.supQuanMain)),
                            prdDscntAmountRtrn = grp.Where(x => (x.supStatus == s3 || x.supStatus == s4) && (x.supDscntPercent ?? 0) > 0).Sum(x => (Price(x) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble(x.supDscntPercent / 100)),
                            prdTaxRtrn = grp.Where(x => x.supStatus == s3 || x.supStatus == s4).Sum(x => x.supTaxPrice ?? 0),
                        }).ToList());
                        var last = (from f in first
                                    select new tblPrdSaleDetail
                                    {
                                        BranchId = f.BranchId,
                                        prdMsur = f.prdMsur,
                                        prdId = f.prdId,
                                        prdName = f.prdName,
                                        prdBarcode = f.prdBarcode,
                                        prdQuant = f.prdQuant - f.prdQuantRtrn,
                                        prdPrice = f.prdPrice - f.prdPriceRtrn,
                                        prdSalePrice = f.prdSalePrice - f.prdSalePriceRtrn,
                                        prdDscntAmount = f.prdDscntAmount - f.prdDscntAmountRtrn,
                                        prdTax = f.prdTax - f.prdTaxRtrn,
                                        prdQuantRtrn = f.prdQuantRtrn,
                                        prdPriceRtrn = f.prdPriceRtrn,
                                        prdSalePriceRtrn = f.prdSalePriceRtrn,
                                        prdDscntAmountRtrn = f.prdDscntAmountRtrn,
                                        prdTaxRtrn = f.prdTaxRtrn,
                                    }).ToList();
                        var last2 = (from f1 in last
                                     from u in Session.tblPrdPriceMeasurment
                                     where u.ppmId == f1.prdMsur
                                     select new tblPrdSaleDetail
                                     {
                                         BranchId = f1.BranchId,
                                         prdMsur = f1.prdMsur,
                                         prdQuantString = f1.prdQuant + " " + u.ppmMsurName,
                                         prdId = f1.prdId,
                                         prdName = f1.prdName,
                                         prdBarcode = f1.prdBarcode,
                                         prdQuant = f1.prdQuant,
                                         prdPrice = f1.prdPrice,
                                         prdSalePrice = f1.prdSalePrice,
                                         prdDscntAmount = f1.prdDscntAmount,
                                         prdTax = f1.prdTax,
                                         prdQuantRtrn = f1.prdQuantRtrn,
                                         prdPriceRtrn = f1.prdPriceRtrn,
                                         prdSalePriceRtrn = f1.prdSalePriceRtrn,
                                         prdDscntAmountRtrn = f1.prdDscntAmountRtrn,
                                         prdTaxRtrn = f1.prdTaxRtrn,
                                         prdSaleProfit = f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice,
                                         prdSaleTotal = ((docType1 == 1 ? f1.prdPrice : f1.prdSalePrice) - f1.prdDscntAmount) + f1.prdTax,
                                         prdSaleProfitPercent = $"{ ((f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice) == 0 ? 0 : ((f1.prdPrice != 0) ? ((f1.prdSalePrice - f1.prdDscntAmount - f1.prdPrice) * 100) / f1.prdPrice : 100)):n2}%"//; ((f.prdSalePrice - f.prdDscntAmount - f.prdPrice)==0 ? 0 : ((f.prdSalePrice - f.prdDscntAmount - f.prdPrice) * 100 / f.prdPrice)).ToString()
                                     }).ToList();

                        groupBand = new ReportSalePurBranch(dtime_Start.DateTime, dtime_End.DateTime, docType1);
                        if (((byte)ReportType.EditValue) == 1)
                            ((ReportSalePurBranch)groupBand).Detail.Visible = ((ReportSalePurBranch)groupBand).GroupFooter1.Visible =
                                ((ReportSalePurBranch)groupBand).GroupHeader1.Visible = false;
                        groupBand.DataSource = last2;
                    }
                    break;
                case ReportSaleModel.SaleUser:
                    break;
                case ReportSaleModel.SaleTotal:
                    break;
                default:
                    break;
            }
            frmReport = new ReportForm(groupBand);
            frmReport.Text = ReportModel.Properties.Items.FirstOrDefault(x => (byte)x.Value ==(byte)ReportModel.EditValue)?.Description;
            flydDialog.WaitForm(this, 0,this);
        }
        double Price(tblSupplySub supplySub) => docType1 == 1 ? (supplySub.supPrice ?? 0) : (supplySub.supSalePrice ?? 0);
    public class totals
        {
            public Nullable<long> supAccNo { get; set; }
            public Nullable<double> totalPrdPrice { get; set; }
            public Nullable<double> totalPrdSalePrice { get; set; }
            public Nullable<double> totalDscntAmount { get; set; }
            public Nullable<double> totalTaxPrice { get; set; }
            public Nullable<double> totalFinal { get; set; }
            public Nullable<double> totalPaidCash { get; set; }
            public Nullable<double> totalPaidCredit { get; set; }
            public Nullable<double> totalPaidBank { get; set; }
            public Nullable<double> totalPrice { get; set; }
            public Nullable<double> totalProfit { get; set; }
        }
        private void ExportPDF_Click(object sender, EventArgs e)
        {
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "PDF Files|*.pdf";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                groupBand.ExportToPdf(xtraSaveFileDialog1.FileName);
        }
        IQueryable<tblSupplyMain> AllSelectInvoList;
        private void Refreash_Click(object sender, EventArgs e)
        {
            ResetAllFilter();
            Refresh_Acc();
        }
        void ResetAllFilter()
        {
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;

            BankLookup.EditValue = BoxLookup.EditValue = CustLookup.EditValue =
              BranchLookup.EditValue = UserLookup.EditValue= StoreLookup.EditValue=CurruncyLookup.EditValue=SuppLookup.EditValue = null;
         
            UserLookupView.ClearSelection();
            BranchLookupView.ClearSelection();
            StoreLookupView.ClearSelection();
            CurruncyLookupView.ClearSelection();
            BoxLookupView.ClearSelection();
            CustLookupView.ClearSelection();
            SuppLookupView.ClearSelection();
            BankLookupView.ClearSelection();
        }
        private void Dtime_Start_EditValueChanged(object sender, EventArgs e)
        {
            if(this.IsActive)
            Refresh_Acc();
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "Excel Files|*.Xls";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                groupBand.ExportToXls(xtraSaveFileDialog1.FileName);
        }
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        List<SupplyType> supplyTypes = new List<SupplyType>();
        public void Refresh_Acc()
        {
            flydDialog.WaitForm(this, 1);
            byte IsCash =Convert.ToByte(PayMethod.EditValue) == 3 ? (byte)1 : Convert.ToByte(PayMethod.EditValue);
            byte IsCash2 = Convert.ToByte(PayMethod.EditValue) == 3 ? (byte)2 : Convert.ToByte(PayMethod.EditValue);
            using (accountingEntities db = new accountingEntities())
            {
                AllSelectInvoList = (from a in db.tblSupplyMains join s in supplyTypes on a.supStatus equals (byte)s
                                         where a.supDate >= dtime_Start.DateTime && a.supDate <= dtime_End.DateTime && !a.IsDelete
                                         && (a.supIsCash == IsCash || a.supIsCash == IsCash2)
                                         select a).AsNoTracking().AsQueryable();
                var gg=AllSelectInvoList.ToList().Where(x=>x.supUserId==1).ToList();
                if (BoxList.Count > 0)
                    AllSelectInvoList = (from tblAccountBox in BoxList join a in AllSelectInvoList on tblAccountBox.boxAccNo equals a.supAccNo select a).AsQueryable();
                if (BankList.Count > 0)
                    AllSelectInvoList = (from tblAccountBank in BankList join a in AllSelectInvoList on tblAccountBank.id equals a.supBankId select a).AsQueryable();
                if (CurrencyList.Count > 0)
                    AllSelectInvoList = (from curr in CurrencyList join a in AllSelectInvoList on curr.id equals a.supCurrency select a).AsQueryable();
                if (Session.CurrentUser.id != 1 && UserList.Count <= 0) UserList.Add(Session.CurrentUser);
                if (UserList.Count > 0)
                    AllSelectInvoList = (from u in UserList join a in AllSelectInvoList on u.id equals a.supUserId select a).AsQueryable();
                if (BranchList.Count > 0)
                    AllSelectInvoList = (from u in BranchList join a in AllSelectInvoList on u.brnId equals a.supBrnId select a).AsQueryable();
                if (CustomerList.Count > 0)
                    AllSelectInvoList = (from Cus in CustomerList join a in AllSelectInvoList on Cus.id equals a.supCustSplId
                                         where a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12 select a).AsQueryable();
                    if (SupplierList.Count > 0)
                    AllSelectInvoList = (from Sup in SupplierList join a in AllSelectInvoList on Sup.id equals a.supCustSplId
                                         where a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10 select a).AsQueryable();
                supplyMainBindingSource.DataSource = AllSelectInvoList.ToList();
            }
            flydDialog.WaitForm(this, 0,this);
        }
        public void InitClsGridLookUpEdit()
        {
            GridBox.gridEdit.Closed += GridEdit_Closed;
            GridBox.gridView.SelectionChanged += GridView_SelectionChanged;

            GridBank.gridEdit.Closed += GridEdit_Closed;
            GridBank.gridView.SelectionChanged += GridView_SelectionChanged;

            GridCust.gridEdit.Closed += GridEdit_Closed;
            GridCust.gridView.SelectionChanged += GridView_SelectionChanged;

            GridSupp.gridEdit.Closed += GridEdit_Closed;
            GridSupp.gridView.SelectionChanged += GridView_SelectionChanged;

            GridStore.gridEdit.Closed += GridEdit_Closed;
            GridStore.gridView.SelectionChanged += GridView_SelectionChanged;

            GridCurruncy.gridEdit.Closed += GridEdit_Closed;
            GridCurruncy.gridView.SelectionChanged += GridView_SelectionChanged;

            GridUser.gridEdit.Closed += GridEdit_Closed;
            GridUser.gridView.SelectionChanged += GridView_SelectionChanged;

        }

        public List<tblCurrency> CurrencyList = new List<tblCurrency>();
        public List<tblUser> UserList = new List<tblUser>();
        public List<tblBranch> BranchList = new List<tblBranch>();
        public List<tblAccountBox> BoxList = new List<tblAccountBox>();
        public List<tblAccountBank> BankList = new List<tblAccountBank>();
        public List<tblGroupStr> GroupStrList = new List<tblGroupStr>();
        public List<tblCustomer> CustomerList = new List<tblCustomer>();
        public List<tblSupplier> SupplierList = new List<tblSupplier>();
        public void GridEdit_Closed(object sender, ClosedEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            switch (gridLookUpEdit.Name)
            { 
                case "CustLookup":
                    if (CustomerList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ",CustomerList.Select(x => x.custName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "SuppLookup":
                    if (SupplierList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", SupplierList.Select(x => x.splName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "StoreLookup":
                    if (GroupStrList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", GroupStrList.Select(x => x.grpName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "CurruncyLookup":
                    if (CurrencyList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", CurrencyList.Select(x => x.curName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BoxLookup":
                    if (BoxList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BoxList.Select(x => x.boxName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BankLookup":
                    if (BankList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BankList.Select(x => x.bankName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "UserLookup":
                    if (UserList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", UserList.Select(x => x.userName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                case "BranchLookup":
                    if (BranchList.Count > 0)
                        gridLookUpEdit.EditValue = string.Join(", ", BranchList.Select(x => x.brnName).ToList());
                    else gridLookUpEdit.EditValue = null;
                    break;
                default:
                    break;
            }
           
            Refresh_Acc();
        }
        public void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            switch (view.Name)
            {
                case "CustLookupView":
                    this.CustomerList = new List<tblCustomer>();
                    view.GetSelectedRows().ForEach(x => this.CustomerList.Add(view.GetRow(x) as tblCustomer));
                    break;
                case "SuppLookupView":
                    SupplierList = new List<tblSupplier>();
                    view.GetSelectedRows().ForEach(x => SupplierList.Add(view.GetRow(x) as tblSupplier));
                    break;
                case "StoreLookupView":
                    GroupStrList = new List<tblGroupStr>();
                    view.GetSelectedRows().ForEach(x => GroupStrList.Add(view.GetRow(x) as tblGroupStr));
                    break;
                case "CurruncyLookupView":
                    CurrencyList = new List<tblCurrency>();
                    view.GetSelectedRows().ForEach(x => CurrencyList.Add(view.GetRow(x) as tblCurrency));
                    break;
                case "BoxLookupView":
                    BoxList = new List<tblAccountBox>();
                    view.GetSelectedRows().ForEach(x => BoxList.Add(view.GetRow(x) as tblAccountBox));
                    break;
                case "BankLookupView":
                    BankList = new List<tblAccountBank>();
                    view.GetSelectedRows().ForEach(x => BankList.Add(view.GetRow(x) as tblAccountBank));
                    break;
                case "UserLookupView":
                    UserList = new List<tblUser>();
                    view.GetSelectedRows().ForEach(x => UserList.Add(view.GetRow(x) as tblUser));
                    break;
                case "BranchLookupView":
                    BranchList = new List<tblBranch>();
                    view.GetSelectedRows().ForEach(x => BranchList.Add(view.GetRow(x) as tblBranch));
                    break;
                default:
                    break;
            }


        }

        private void XtraFormAccountsFromTo_Load(object sender, EventArgs e)
        {
            flydDialog.WaitForm(this, 1);
            currencyBindingSource.DataSource = Session.Currencies;
            customerBindingSource.DataSource = Session.Customers;
            supplierBindingSource.DataSource = Session.Suppliers;
            bankBindingSource.DataSource = Session.Banks;
            boxBindingSource.DataSource = Session.Boxes;
            tblBranchBindingSource.DataSource = Session.Branches;
            if(Session.CurrentUser.id!=1)
            userTblBindingSource.DataSource = Session.CurrentUser;
            else userTblBindingSource.DataSource = Session.tblUser;
            GroupStrBindingSource.DataSource=Session.tblGroupStr;
            
            GridBank = new ClsGridLookupEdit(BankLookup, "bankNo", "bankName", "البنك");
            GridUser = new ClsGridLookupEdit(UserLookup, "id", "userName", "المستخدم");
            GridBranch = new ClsGridLookupEdit(BranchLookup, "brnId", "brnName", "الفرع");
            GridCurruncy = new ClsGridLookupEdit(CurruncyLookup, "id", "curName", "العمله");
            GridBox = new ClsGridLookupEdit(BoxLookup, "boxNo", "boxName", "الصندوق");
            GridCust = new ClsGridLookupEdit(CustLookup, "custNo", "custName", "العميل");
            GridSupp = new ClsGridLookupEdit(SuppLookup, "splNo", "splName", "المورد");
            GridStore = new ClsGridLookupEdit(StoreLookup, "grpNo", "grpName", "المجموعة المخزنية");
            flydDialog.WaitForm(this, 0,this);
            Refresh_Acc();
            InitClsGridLookUpEdit();
        }
        ClsGridLookupEdit GridBox, GridBank, GridUser, GridBranch, GridCurruncy, GridStore, GridCust, GridSupp;
       
    }
}