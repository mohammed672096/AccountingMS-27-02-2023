using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCaccountsBalance : DevExpress.XtraEditors.XtraUserControl
    {
        // accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ArrayList list = new ArrayList();

        List<tblAsset> tblAccountBalance = new List<tblAsset>();
        List<tblAsset> tblAssets = new List<tblAsset>();
        CultureInfo _ci;
        ComponentResourceManager _resource;
        private double total = 0;
        private Int64 cellValue = 0;

        public UCaccountsBalance()
        {
            InitializeComponent();
            GetResources();

            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.cellValue = Convert.ToInt64(gridView.GetFocusedRowCellValue(gridView.Columns["asAccNo"]));
            var curBalance = gridView.GetFocusedRow() as tblAsset;
            if (curBalance != null)
            {
                lblAccName.Text = curBalance.asAccName;
                lblAccNo.Text = curBalance.asAccNo.ToString();
                lblCredit.Text = curBalance.asCredit.Value.ToString("n");
                lblDebt.Text = curBalance.asDebit.Value.ToString("n");
                lblBalance.Text = gridView.GetFocusedRowCellValue(gridView.Columns["gridColumn1"]).ToString();
                InitDetailData(this.cellValue);
            }
        }

        private void InitDetailData(Int64 accNo)
        {
            tblAssetBindingSource.Clear();
            tblAssetBindingSource.DataSource = tblAssets.Where(x => x.asAccNo == accNo).ToList();
        }

        private void UCaccountsBalance_Load(object sender, EventArgs e)
        {
            gridView1.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            InitData();
        }

        private void InitData()
        {
            bindingSource1.Clear();
            using (var db = new accountingEntities())
            {
                tblAssets = (from a in db.tblAssets
                             where a.asBrnId == Session.CurBranch.brnId & a.asCredit != a.asDebit &
                          a.asDate >= Session.CurrentYear.fyDateStart & a.asDate <= Session.CurrentYear.fyDateEnd
                             select a).ToList();
                tblAccountBalance = (from acc in tblAssets
                                     group acc by acc.asAccNo into accBalanceGrp
                                     select new tblAsset
                                     {
                                         asAccNo = accBalanceGrp.Key,
                                         asAccName = accBalanceGrp.Max(x => x.asAccName),
                                         asDebit = accBalanceGrp.Sum(x => (x.asDebit ?? 0)),
                                         asCredit = accBalanceGrp.Sum(x => (x.asCredit ?? 0) ),
                                     }).OrderBy(x => x.asAccNo.ToString()).ToList();

                foreach (var account in tblAccountBalance)
                {
                    bindingSource1.Add(account);
                    gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
                    this.total = account.asDebit.Value - account.asCredit.Value;
                    string debit = (!MySetting.GetPrivateSetting.LangEng ? "  مدين" : "  Debit");
                    string Credit = (!MySetting.GetPrivateSetting.LangEng ? "  دائن" : "  Credit");
                    string balance = (this.total >= 0 ? this.total.ToString("n") + debit : (this.total * -1).ToString("n") + Credit);
                    list.Add(balance);
                }
                bsiRecordsCount.Caption = "RECORDS : " + bindingSource1.Count;
            }
        }

        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn1" && e.IsGetData)
                e.Value = list[e.ListSourceRowIndex].ToString();
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm =new ReportForm(ReportType.AccountBill);
             frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "asStatus" && e.DisplayText != null)
            {
                e.DisplayText = e.DisplayText switch
                {
                    "1" => "رصيد إفتتاحي",
                    "2" => "قيد يومي",
                    "3" => "سند صرف",
                    "4" => "سند قبض",
                    "5" => "فاتورة مشتريات",
                    "6" => "فاتورة مبيعات",
                    "7" => "فاتورة مردود مشتريات",
                    "8" => "فاتورة مردود مبيعات",
                    "9" => "سند صرف الموظفين",
                    "10" => "رصيد إفتتاحي مخازن",
                    _ => e.DisplayText,
                };
            }
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.BalanceSheet1); 
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
              var frm = new ReportForm(ReportType.BalanceSheet2);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;
            gridControl2.RightToLeft = RightToLeft.No;
            //layoutControl1.RightToLeft = RightToLeft.No;
            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCaccountsBalanceEn));

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView1.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(gridView1, gridView1.Name, _ci);
            _resource.ApplyResources(layConItemDebit, layConItemDebit.Name, _ci);
            _resource.ApplyResources(layConItemCredit, layConItemCredit.Name, _ci);
            _resource.ApplyResources(layConItemBalance, layConItemBalance.Name, _ci);
            _resource.ApplyResources(layConItemAccName, layConItemAccName.Name, _ci);
            _resource.ApplyResources(layConItemAccNo, layConItemAccNo.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
        }
    }
}
