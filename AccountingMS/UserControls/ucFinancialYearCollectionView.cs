using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucFinancialYearCollectionView : XtraUserControl
    {
        ClsTblFinancialYear clsTbFinancialYear;

        private readonly formFinancialYear _formFinancialYear;
        private int currentId;

        public ucFinancialYearCollectionView(formFinancialYear frmFinancialYear)
        {
            SetLanguage();
            InitializeComponent();
            InitData();
            SetCurrentYearEditor();
            _formFinancialYear = frmFinancialYear;
        }

        private void InitData()
        {
            this.clsTbFinancialYear = new ClsTblFinancialYear();
            tblFinancialYearBindingSource.DataSource = Session.tblFinancialYear;
        }

        private void SetCurrentYearEditor()
        {
            this.currentId = this.clsTbFinancialYear.GetDefaultFinancialYearId();
            gridLookUpEdit1.EditValue = this.currentId;
        }

        private void RefreshData()
        {
            this.clsTbFinancialYear.RefreshData();
            InitData();
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;
            if ((int)editor.EditValue == this.currentId) return;

            if (!ChangeYearMssgDialog(editor.Text))
                editor.EditValue = editor.OldEditValue;
            else
                UpdateDefaultFinancialYear(editor.GetSelectedDataRow() as tblFinancialYear);
        }

        private void UpdateDefaultFinancialYear(tblFinancialYear tbFinancialYear)
        {
            if (this.clsTbFinancialYear.UpdateDefaultFinancialYear(tbFinancialYear))
                XtraMessageBox.Show("تم تغير السنة الإفتراضية بنجاح");
        }

        private bool ChangeYearMssgDialog(string editValue)
        {
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? $"هل أنت متاكد من تغير السنة الإفتراضيه إلى : {editValue}؟ \nسيتم إعادة تشغيل النظام في حالة الموافقة." :
                $"Are you sure change default financial year to : {editValue}? \nChanges will reboot application.";
            if (XtraMessageBox.Show(mssg, "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Tag)
            {
                case "wbNew":
                    _formFinancialYear.NavigationPageObjectView();
                    break;
                case "wbRefresh":
                    RefreshData();
                    break;
                case "wbClose":
                    _formFinancialYear.Close();
                    break;
            }
        }

        public void RefreshListDialog()
        {
            RefreshData();
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