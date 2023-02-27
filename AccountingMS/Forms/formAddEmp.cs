using AccountingMS.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddEmployee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsLinQuery lq = new ClsLinQuery();
        tblEmployee tbEmployee;
        ClsTblEmployee clsTbEmployee;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private readonly UCemployees _ucEmployees;
        private bool IsNew;
        private long empAccNo;
        private int dfltempAccNo;

        public formAddEmployee(UCemployees ucEmployees, tblEmployee obj)
        {
            InitializeComponent();
            InitData(obj);
            InitDefaultData();
            GetResources();
            this._ucEmployees = ucEmployees;
            //shiftIDTextEdit.Properties.DataSource = db.Shifts.ToList();
            shiftBindingSource.DataSource = db.Shifts.ToList();
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
            empAccNoTextEdit.EditValueChanged += EmpAccNoTextEdit_EditValueChanged;
          
        }

        private void InitData(tblEmployee obj)
        {
            if (obj == null)
            {
                this.IsNew = true;
                this.clsTbEmployee = new ClsTblEmployee(true);
                this.tbEmployee = new tblEmployee() { empNo = this.clsTbEmployee.GetNewEmpNo(), empCurrency = 0, empBrnId = Session.CurBranch.brnId, empStatus = 1 };
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, tblEmployeeBindingSource, nameof(this.tbEmployee.empBrnId));
                tblEmployeeBindingSource.DataSource = this.tbEmployee;
                this.clsTbEmployee.Add(tblEmployeeBindingSource.Current as tblEmployee);
            }
            else
            {
                this.IsNew = false;
                this.clsTbEmployee = new ClsTblEmployee(false);
                this.tbEmployee = obj;
                tblEmployeeBindingSource.DataSource = this.tbEmployee;
                this.clsTbEmployee.Attach(tblEmployeeBindingSource.Current as tblEmployee);
                SetEditForm();
            }
        }

        private void InitDefaultData()
        {
            lq.accNo(empAccNoTextEdit);

            if (this.IsNew)
            {
                this.clsTbAccount = new ClsTblAccount();
                this.clsTbDefaultAcc = new ClsTblDefaultAccount();
                tbEmployee.empCurrency = new ClsTblCurrency().InitCurrencyLookupEdit(empCurrencyTextEdit);

                SetAutoAccNo();
            }
        }

        private void SetEditForm()
        {
            this.Text = (!MySetting.GetPrivateSetting.LangEng) ? $"تعديل بيانات الموظف : {this.tbEmployee.empName}" : $"Update Employee Data : {this.tbEmployee.empName}";
            ItemForempAccNo.Enabled = false;
            ItemForempNo.Enabled = false;
        }

        private void SetAutoAccNo()
        {
            ribbonPageGroupAutoAddAccNo.Visible = true;
            bbiAutoAccNo.Checked = true;
            BbiAutoAccNoItemVisibility(true);
        }

        private void EmpAccNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbEmployee.empCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
        }

        private void BbiAutoAccNo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BbiAutoAccNoItemVisibility(bbiAutoAccNo.Checked);
        }

        private void BbiAutoAccNoItemVisibility(bool checkState)
        {
            switch (checkState)
            {
                case true:
                    ItemForempAccNo.TextAlignMode = TextAlignModeItem.AutoSize;
                    ItemForempAccNo.Visibility = LayoutVisibility.Never;
                    ItemForempNo.Visibility = LayoutVisibility.Never;
                    ItemForempCurrency.Visibility = LayoutVisibility.Always;
                    break;
                case false:
                    ItemForempCurrency.Visibility = LayoutVisibility.Never;
                    ItemForempNo.Visibility = LayoutVisibility.Always;
                    ItemForempAccNo.Visibility = LayoutVisibility.Always;
                    ItemForempAccNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    break;
            }
            SetCurrentFocusedItem(checkState);
        }

        private void SetCurrentFocusedItem(bool autoAccNo)
        {
            if (!autoAccNo)
                empAccNoTextEdit.Focus();
            else
                empNameTextEdit.Focus();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (!dxValidationProvider1.Validate()) return;
            //if (abcenceregistionIDTextEdit.Text == "" || delayRegulationIDintTextEdit.Text == "" ||  shiftIDTextEdit.Text == "")
            //{ XtraMessageBox.Show("ادخل اللوائح أولاً"); return; }
            if (!SaveAutoAccNo()) return;

            if (this.clsTbEmployee.Save())
            {
                _ucEmployees.RefreshListDialog(_resource.GetString("employee") + empNameTextEdit.Text, this.IsNew);
                this.Close();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveAutoAccNo()
        {
            if (!this.IsNew || !bbiAutoAccNo.Checked) return true;

            SetNewAccNo();
            SetEmpObjFileds();

            return SaveNewAccToTblAccounts();
        }

        private bool SetNewAccNo()
        {
            tblEmployee Emp = tblEmployeeBindingSource.Current as tblEmployee;
            if (Emp == null) return false;
            if (Emp.empBrnId == null | Emp.empBrnId == 0)
            {
                XtraMessageBox.Show("يجب تحديد الفرع الخاص بالموظف");
                return false;
            }
            this.dfltempAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)DefaultAccType.Employee, Emp.empBrnId.Value)));

            if (this.dfltempAccNo <= 0)
            {
                XtraMessageBox.Show("يجب تحديد الحساب الافتراضي للموظفين لهذا الفرع");
                return false;
            }
            this.empAccNo = this.clsTbAccount.GetNewAccNo(dfltempAccNo.ToString());
            return true;
        }

        private void SetEmpObjFileds()
        {
            this.tbEmployee.empAccNo = this.empAccNo;
            this.tbEmployee.empNo = Convert.ToInt32(this.empAccNo % 100000);
        }


        private bool SaveNewAccToTblAccounts()
        {
            tblEmployee Emp = tblEmployeeBindingSource.Current as tblEmployee;
            Emp.shiftID = Convert.ToInt32(shiftIDTextEdit.EditValue);

            if (Emp == null) return false;
            return this.clsTbAccount.Add(DefaultAccType.Employee, this.empAccNo, empNameTextEdit.Text, Convert.ToByte(empCurrencyTextEdit.EditValue), 2, Emp.empBrnId.Value);
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
                _resource = new ComponentResourceManager(typeof(Language.formAddEmployeeEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            _resource.ApplyResources(barButtonItem2, barButtonItem2.Name, _ci);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);

            empAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            empAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");

            this.Text = _resource.GetString("$this.Text");
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

        private void expirationInsuranceDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = $"متبقي: {  (int)expirationInsuranceDateEdit.DateTime.Date.Subtract(DateTime.Now).TotalDays} يوم";
        }

        private void expirationResidenceDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"متبقي: { (int)expirationResidenceDateEdit.DateTime.Date.Subtract(DateTime.Now).TotalDays} يوم";
        }

        private void WorkEndDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            label3.Text = $"متبقي: {  (int)WorkEndDateDateEdit.DateTime.Date.Subtract(DateTime.Now).TotalDays} يوم";
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddEmpPDF frm = new frmAddEmpPDF();
            frm.ShowDialog();
        }

        private void formAddEmployee_Load(object sender, EventArgs e)
        {
           this.TopMost = true;
           this.TopMost = false;
            using (accountingEntities db2 = new accountingEntities())
            {
                JobidTextEdit.Properties.DataSource = db.Jobs.ToList();
                GroupIdTextEdit.Properties.DataSource = db.Groups.ToList();
                DepartmentIDTextEdit.Properties.DataSource = db.Departments.ToList();
                absenceRegulationBindingSource.DataSource = db.AbsenceRegulations.ToList();
                overtimeAndDelayRegulationBindingSource.DataSource = db.OvertimeAndDelayRegulations.ToList();
                salaryRegulationBindingSource.DataSource = db.SalaryRegulations.ToList();
                salaryExtensionBindingSource.DataSource = db.SalaryExtensions.ToList();

                MaritalStatusTextEdit.Properties.DataSource = new List<MaritalStatusM>()
                {
                    new MaritalStatusM() {ID= 0, Name="اعزب" },
                     new MaritalStatusM() {ID= 1,Name="متزوج" }
                };
                MaritalStatusTextEdit.Properties.DisplayMember = "Name";
                MaritalStatusTextEdit.Properties.ValueMember = "ID";
                MilitarilyStatusTextEdit.Properties.DataSource = new List<MaritalStatusM>()
                {
                    new MaritalStatusM() {ID= 0, Name="اعفاء" },
                     new MaritalStatusM() {ID= 1,Name="مؤجل" },
                     new MaritalStatusM() {ID= 2,Name="مؤدي" }
                };
                MilitarilyStatusTextEdit.Properties.DisplayMember = "Name";
                MilitarilyStatusTextEdit.Properties.ValueMember = "ID";


                GenderTypeCheckEdit.Properties.DataSource = new List<gender>()
                {
                    new gender() {ID= 0, Name="ذكر" },
                     new gender() {ID= 1,Name="انثى" },
                };
                GenderTypeCheckEdit.Properties.DisplayMember = "Name";
                GenderTypeCheckEdit.Properties.ValueMember = "ID";

            }



        }

        class MaritalStatusM
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        class gender
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        class MilitarilyStatusM
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new AbcenceRegulationView(); frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new OvertimeAndDelayRegulationView(); frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ShiftView(); frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }
    }
}