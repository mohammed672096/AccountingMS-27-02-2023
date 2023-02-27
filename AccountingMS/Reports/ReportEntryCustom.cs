using AccountingMS.Classes;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportEntryCustom : XtraReport
    {
        public ReportEntryCustom(EntryDataCustom entryDataCustom,List<EntrySubDataCustom> entrySubDataCustoms,ReportCustomType customType)
        {
            SetLanguage();
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            switch (customType)
            {
                case ReportCustomType.A4:
                    break;
                case ReportCustomType.Chasier:
                    break;
                case ReportCustomType.Entry:
                    this.LoadLayout(ClsPath.ReportDailyEntryCustomFile);
                    break;
                case ReportCustomType.EntryVoucher:
                    this.LoadLayout(ClsPath.ReportEntryVocherCustomFile);
                    break;
                case ReportCustomType.EntryReceipt:
                    this.LoadLayout(ClsPath.ReportEntryReciptCustomFile);
                    break;
                default:
                    break;
            }
            SetRTL();
            EntryMainBindingSource.DataSource = entryDataCustom;
            entrySubDataBindingSource.DataSource = entrySubDataCustoms;
        }
        public ReportEntryCustom()
        {
            SetLanguage();
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            SetRTL();
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
