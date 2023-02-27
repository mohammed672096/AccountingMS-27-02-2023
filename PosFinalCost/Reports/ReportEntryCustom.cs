using PosFinalCost.Classe;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace PosFinalCost.Report
{
    public partial class ReportEntryCustom : XtraReport
    {
        public ReportEntryCustom(EntryDataCustom entryDataCustom,List<EntrySubCustom> entrySubDataCustoms,byte customType)
        {
            SetLanguage();
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (Program.My_Setting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            switch (customType)
            {
                case 1:
                    this.LoadLayout(ClsPath.ReportDailyEntry);
                    break;
                case 2:
                    this.LoadLayout(ClsPath.ReportEntryVocher);
                    break;
                case 3:
                    this.LoadLayout(ClsPath.ReportEntryRecipt);
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
            if (Program.My_Setting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            SetRTL();
        }

        private void SetLanguage()
        {
            if (!Program.My_Setting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }
        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
