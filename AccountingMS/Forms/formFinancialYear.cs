using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formFinancialYear : DevExpress.XtraEditors.XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        public formFinancialYear()
        {
            SetLanguage();
            InitializeComponent();
            InitUCFinancialYear();
        }

        private void InitUCFinancialYear()
        {
            ucFinancialYearCollectionView ucFinancialYearColctionView = new ucFinancialYearCollectionView(this) { Dock = DockStyle.Fill };
            navigationPageCollectionView.Controls.Add(ucFinancialYearColctionView);
            navigationPageObjectView.Controls.Add(new ucFinancialYearObjView(this, ucFinancialYearColctionView) { Dock = DockStyle.Fill });
        }

        public void NavigationPageCollectionView()
        {
            flyDialog.WaitForm(this, 1);
            navigationFrame.SelectedPage = navigationPageCollectionView;
            flyDialog.WaitForm(this, 0);
        }

        public void NavigationPageObjectView()
        {
            flyDialog.WaitForm(this, 1);
            navigationFrame.SelectedPage = navigationPageObjectView;
            flyDialog.WaitForm(this, 0);
        }

        public void FlyDialogMssg(string mssg)
        {
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }
    }
}