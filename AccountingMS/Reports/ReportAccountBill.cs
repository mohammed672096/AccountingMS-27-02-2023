using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportAccountBill : XtraReport
    {
        ClsTblAsset clsTbAsset = new ClsTblAsset(true);
        ClsTblAccount clsTbAccount = new ClsTblAccount();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        private accountingEntities db = new accountingEntities();

        private long accNo;
        private DateTime dtStart, dtEnd;

        public ReportAccountBill()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitDefaultData();
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            parameterDtStart.Value = DateTime.Now;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            tblAccountBindingSource.DataSource = this.clsTbAccount.GetAccountListType2();
            xrtcDate.Text += string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}");
        }

        private void ReportAccountBill_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "parameterAccNo")
                {
                    GridLookUpEdit lookUpEdit = new GridLookUpEdit();

                    lookUpEdit.Properties.DataSource = clsTbAccount.GetAccountListType2();
                    lookUpEdit.Properties.DisplayMember = "accName";
                    lookUpEdit.Properties.ValueMember = "accNo";
                    lookUpEdit.Properties.ValidateOnEnterKey = true;
                    lookUpEdit.Properties.ImmediatePopup = true;
                    lookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                    lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    lookUpEdit.Properties.View.Columns.AddRange(new GridColumn[]
                    {
                        new GridColumn {VisibleIndex=0,Visible=true, FieldName= "accNo" ,Caption=(!MySetting.GetPrivateSetting.LangEng) ? "رقم الحساب" : "Account No."  },
                        new GridColumn {VisibleIndex=0,Visible=true, FieldName= "accName" ,Caption= (!MySetting.GetPrivateSetting.LangEng) ? "إسم الحساب" : "Account Name" }
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

        private void ReportAccountBill_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            this.accNo = Convert.ToInt64(parameterAccNo.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);
            InitReportData();
        }

        private void InitReportData()
        {
            ICollection<tblAsset> tbAssetList = new Collection<tblAsset>();
            // tbAssetList.
            foreach (var tbAsset in this.clsTbAsset.GetAssetListByAccNo(accNo, this.dtStart, this.dtEnd))
            {
                tbAssetList.Add(tbAsset);
            }
            // ICollection<tblAsset> tbAssetList= this.clsTbAsset.GetAssetListByAccNo(accNo, this.dtStart, this.dtEnd,true);
            tblAssetBindingSource.DataSource = tbAssetList;
        }

        private void XrTableCell19_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(cell.Value));
        }

        private void xrtcEntNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null && Convert.ToInt32(cell.Value) == 0) cell.Text = null;
        }

        private void XrTableCell8_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = GetAssetType(Convert.ToByte(cell.Value));
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal totalDebit = Convert.ToDecimal(xrtcTotalDebit.Summary.GetResult()), totalCredit = Convert.ToDecimal(xrtcTotalCredit.Summary.GetResult());

            if (totalDebit > totalCredit) SetTotal(totalDebit, totalCredit, "مدين");
            else if (totalDebit < totalCredit) SetTotal(totalCredit, totalDebit, "دائن");
            else SetTotal(0, 0, null);
        }

        private void SetTotal(decimal total1, decimal total2, string text)
        {
            //xrtcTotal.Text = $"{total1 - total2:n2}";
            //xrtcTotalStr.Text = text;
            this.accNo = Convert.ToInt64(parameterAccNo.Value);
            var AccountBalance = new ClsTblAccount.AccountBalance(accNo);

            xrtcTotal.Text = AccountBalance.Balance.ToString("n2");
            xrtcTotalStr.Text = AccountBalance.Type;
        }

        private string GetAssetType(byte status)
        {
            switch (status)
            {
                case 1: return "رصيد إفتتاحي";
                case 2: return "قيد يومي";
                case 3: return "سند صرف";
                case 4: return "سند قبض";
                case 5: return "فاتورة مشتريات";
                case 6: return "فاتورة مبيعات";
                case 7: return "فاتورة مردود مشتريات";
                case 8: return "فاتورة مردود مبيعات";
                case 9: return "سند صرف الموظفين";
                case 10: return "رصيد إفتتاحي مخازن";
                default: return null;
            }
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
