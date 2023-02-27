using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCemployees : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblEmployee clsTbEmployee = new ClsTblEmployee(true);
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        public UCemployees()
        {
            InitializeComponent();
            //bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
            //bbiEdit.ItemShortcut = new BarShortcut(Keys.F4);
            //bbiDelete.ItemShortcut = new BarShortcut(Keys.F6);
            //bbiRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            //bbiPrintPreview.ItemShortcut = new BarShortcut(Keys.F8);
            //barButtonItem1.ItemShortcut = new BarShortcut(Keys.F7);
            GetResources();
            InitData();
            new ClsUserControlValidation(this, UserControls.Employees);

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridControl.KeyDown += GridControl_KeyDown;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                bbiDelete.PerformClick();
        }

        private void InitData()
        {
            tblEmployeeBindingSource.DataSource = this.clsTbEmployee.GetEmployeeList;
            bsiRecordsCount.Caption = _resource.GetString("count") + tblEmployeeBindingSource.Count;
            tblEmployee gr = new tblEmployee();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.empBrnId));
        }

        private void RefreshData()
        {
            this.clsTbEmployee.RefreshData();
            InitData();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "empCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            EditEmployee();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new formAddEmployee(this, null).Show();
            flyDialog.WaitForm(this, 0);
        }

        private void EditEmployee()
        {
            flyDialog.WaitForm(this, 1);
            new formAddEmployee(this, tblEmployeeBindingSource.Current as tblEmployee).Show();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEmployeeBindingSource)) return;
            EditEmployee();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEmployeeBindingSource)) return;
            DeletetRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.EmpSalaryDetail);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.EmpSalary);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void DeletetRecord()
        {
            var tbEmpoyee = gridView.GetFocusedRow() as tblEmployee;
            string delMssg = string.Format(_resource.GetString("delEmpMssg"), tbEmpoyee.empName);

            if (XtraMessageBox.Show(delMssg, "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);

            bool isFound = new ClsTblEntrySub().IsAccNoFound(tbEmpoyee.empAccNo);
            if (IsFound(isFound, tbEmpoyee.empName)) return;

            flyDialog.WaitForm(this, 0);

            if (!new ClsTblAccount().DeleteByAccNo(tbEmpoyee.empAccNo)) return;
            if (!this.clsTbEmployee.Delete(tbEmpoyee)) return;

            string mssg = string.Format(_resource.GetString("delEmpSuccessMssg"), tbEmpoyee.empName);
            flyDialog.ShowDialogUCCustomdMsg(this, mssg);
            tblEmployeeBindingSource.RemoveCurrent();
        }

        private bool IsFound(bool isFound, string empName)
        {
            if (isFound)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(string.Format(_resource.GetString("delEmpErrorMssg"), empName));
            }
            return isFound;
        }

        public void RefreshListDialog(string name, bool isNew)
        {
            if (isNew)
                flyDialog.ShowDialogUC(this, name);
            else
                flyDialog.ShowDialogUCUpdMsg(this, name);

            RefreshData();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.EmployeesNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCemployeesEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

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

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
        }
    }
}
