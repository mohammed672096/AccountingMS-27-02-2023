using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucFinancialYearObjView : XtraUserControl
    {
        accountingEntities db = new accountingEntities();
        tblFinancialYear tbFinancialYear;

        private readonly formFinancialYear _formFinanacialYear;
        private readonly ucFinancialYearCollectionView _ucFinancialYearCollectionView;

        public ucFinancialYearObjView(formFinancialYear frmFinancialYear, ucFinancialYearCollectionView ucFinancalYearCollectionView)
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData();
            _formFinanacialYear = frmFinancialYear;
            _ucFinancialYearCollectionView = ucFinancalYearCollectionView;
        }

        private void InitData()
        {
            this.tbFinancialYear = new tblFinancialYear()
            {
                fyBranchId = Session.CurBranch.brnId,
                fyDateStart = new DateTime(DateTime.Now.Year + 1, 01, 01),
                fyDateEnd = new DateTime(DateTime.Now.Year + 1, 12, 31),
                fyIsNewYear = true,
                fyStatus = false
            };
            tblFinancialYearBindingSource.DataSource = this.tbFinancialYear;
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            _formFinanacialYear.NavigationPageCollectionView();
        }

        private void windowsUIButtonPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Tag)
            {
                case "save":
                    Save();
                    break;
                case "cancel":
                    _formFinanacialYear.NavigationPageCollectionView();
                    break;
            }
        }

        private void Save()
        {
            if (!SaveData()) return;
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "السنة المالية : " : "Financial Year : ";
            mssg += fyNameTextEdit.Text;

            _formFinanacialYear.NavigationPageCollectionView();
            _formFinanacialYear.FlyDialogMssg(mssg);
            _ucFinancialYearCollectionView.RefreshListDialog();
            InitData();
        }

        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            ChangeFocus();
            ChangeIsNewYear();
            db.tblFinancialYears.Add(tblFinancialYearBindingSource.Current as tblFinancialYear);

            return SaveDB();
        }

        private void ChangeIsNewYear()
        {
            if (!this.tbFinancialYear.fyIsNewYear) return;

            var list = db.tblFinancialYears.ToList();
            if (list?.Count == 0) return;

            list.ForEach(x => x.fyIsNewYear = false);
        }

        private void ChangeFocus()
        {
            if (fyNameTextEdit.ContainsFocus)
                fyDateStartDateEdit.Focus();
            else
                fyNameTextEdit.Focus();
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

            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            windowsUIButtonPanel1.Buttons[0].Properties.Image = global::AccountingMS.Properties.Resources.backward_32x32;
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
