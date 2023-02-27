using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class EmployeeView :  MasterView
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void DepartmentIDTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }


        public override void New()
        {
          //  group = new Group() { };
            base.New();
        }
        public override void Save()
        {
            EnableValidation(dataLayoutControl1);
            if (this.ValidateChildren() == false)
                return;
            DisableValidation(dataLayoutControl1);
            //context.Groups.AddOrUpdate(group);
            //context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
         // gridControl1.DataSource = context.Groups.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {

            //base.Delete();
        }
    }
}
