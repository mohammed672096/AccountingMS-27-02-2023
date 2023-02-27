using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hassib.Common;
using System.Data.Entity.Migrations;
using AccountingMS;

namespace AccountingMS
{
    public partial class DepartmentView : MasterView
    {


        private static DepartmentView instance;
        public static DepartmentView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new DepartmentView(); return instance; } }


        accountingEntities context;
        public Department department { get => departmentBindingSource.Current as Department; set => departmentBindingSource.DataSource = value; }

        public DepartmentView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += DepartmentView_Shown;

        }

        private void DepartmentView_Shown(object sender, EventArgs e)
        {
            if (department == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Department row = gridView1.GetRow(gridView1.FocusedRowHandle) as Department;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.Departments.SingleOrDefault(x => x.id == id);
            
            if (sourceDepr != null)
            {
                department = sourceDepr;
                ParentIDLookUpEdit.Properties.DataSource = context.Departments
                .Where(depr => depr.id != sourceDepr.id).ToList();
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
            department = new Department() { };
            base.New();
        }
        public override void Save()
        {
            EnableValidation(dataLayoutControl1);
            if (this.ValidateChildren() == false)
                return;
            DisableValidation(dataLayoutControl1);
            context.Departments.AddOrUpdate(department);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.Departments.ToList();

            ParentIDLookUpEdit.Properties.DataSource = context.Departments.ToList();
           
            base.RefreshData();
        }
        public override void Delete()
        {
            context.Departments.Remove(department);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void DepartmentView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}