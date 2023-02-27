using AccountingMS.Properties;
using DevExpress.XtraSplashScreen;
using System;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class SplashScreenBTech : SplashScreen
    {
        public SplashScreenBTech()
        {
            InitializeComponent();
            SetLabelVersion();
            EnglishTranslation();
        }

        private void SetLabelVersion()
        {
            liVersion.Text = $"إصدار {ClsVersion.Current}";
        }

        private void EnglishTranslation()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            liStart.Text = "Starting...";
            liVersion.Text = $"Version {ClsVersion.Current}";
            liAccountingMS.Text = "Accounting Manegment System";
            SetRTL();
        }

        private void SetRTL()
        {
            layoutControl1.BeginUpdate();
            layoutControl1.RightToLeft = RightToLeft.No;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl1.EndUpdate();

            this.RightToLeft = RightToLeft.No;
            //this.RightToLeftLayout = false;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}