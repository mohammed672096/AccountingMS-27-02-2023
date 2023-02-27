using DevExpress.XtraEditors;
using Hassib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS.Forms.HR
{
    public partial class FormalHoliday : MasterView
    {
        private static FormalHoliday instance;
        public static FormalHoliday Instance { get { if (instance == null || instance.IsDisposed == true) instance = new FormalHoliday(); return instance; } }


        accountingEntities context;
        public HolidayEmp holidayemp { get => holidayEmpBindingSource.Current as HolidayEmp; set => holidayEmpBindingSource.DataSource = value; }

        public FormalHoliday()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            empIDTextEdit.Properties.DataSource = context.tblEmployees.ToList();
            repositoryItemLookUpEdit1.DataSource = context.tblEmployees.ToList();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += FormalHoliday_Shown;
        }

        private void FormalHoliday_Shown(object sender, EventArgs e)
        {
            if (holidayemp == null)
                New();
        }

        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            HolidayEmp row = gridView1.GetRow(gridView1.FocusedRowHandle) as HolidayEmp;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.HolidayEmps.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                holidayemp = sourceDepr;
                DataChanged = false;
                IsNew = false;
            }
            else
            {
                XtraMessageBox.Show("المستند غير موجود ");
            }
        }

        public override void New()
        {
            holidayemp = new HolidayEmp() { };
            base.New();
        }
        public void SetData()
        {
            holidayemp.empID = Convert.ToInt32(empIDTextEdit.EditValue);
            holidayemp.holidayName = holidayNameTextEdit.Text;
            holidayemp.dateAncestor = Convert.ToDateTime(dateAncestorDateEdit.EditValue);
            holidayemp.reason = reasonTextEdit.Text;
            holidayemp.balance = Convert.ToInt32(balanceTextEdit.EditValue);
        }
        public override void Save()
        {
            if (empIDTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("ادخل اسم الموظف أولا ");
                return;
            }
            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            SetData();
            context.HolidayEmps.AddOrUpdate(holidayemp);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.HolidayEmps.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (empIDTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد الاسم التى تريد حذفها ");
                return;
            }
            context.HolidayEmps.Remove(holidayemp);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void empIDTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var sumbalance = context.HolidayEmps.ToList().Where(x => x.empID == Convert.ToInt32( empIDTextEdit.EditValue));
            balanceTextEdit.EditValue = sumbalance.Count();
        }

        private void FormalHoliday_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;

            dateAncestorDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");

        }
    }
}
