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
    public partial class ancestorW : MasterView
    {

        private static ancestorW instance;
        public static ancestorW Instance { get { if (instance == null || instance.IsDisposed == true) instance = new ancestorW(); return instance; } }


        accountingEntities context;
        public ancestor Ancestor { get => ancestorBindingSource.Current as ancestor; set => ancestorBindingSource.DataSource = value; }

        public ancestorW()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            empIDTextEdit.Properties.DataSource = context.tblEmployees.ToList();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            this.Shown += AncestorW_Shown; ;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colempID)
            {
                var empName = context.tblEmployees.Find(Convert.ToInt32(e.Value));
                if (empName == null) return;
                e.DisplayText = empName.empName;

            }

        }

        private void AncestorW_Shown(object sender, EventArgs e)
        {
            if (Ancestor == null)
                New();
        }

        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            ancestor row = gridView1.GetRow(gridView1.FocusedRowHandle) as ancestor;
            if (row != null)
                GoTo(row.id);
        }

        public void GoTo(int id)
        {
            var sourceDepr = context.ancestors.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                Ancestor = sourceDepr;
                DataChanged = false;
                IsNew = false;
            }
            else
            {
                XtraMessageBox.Show("المستند غير موجود ");
            }
        }
        public void GetData()
        {
            empIDTextEdit.EditValue = Ancestor.empID;
            dateAncestorDateEdit.EditValue = Ancestor.dateAncestor;
            amountTextEdit.EditValue = Ancestor.amount;
            reasonTextEdit.EditValue = Ancestor.reason;
        }
        public void SetData()
        {
            Ancestor.empID =( empIDTextEdit.EditValue as int?) ?? 0;
            Ancestor.dateAncestor =Convert.ToDateTime( dateAncestorDateEdit.EditValue);
            Ancestor.amount =Convert.ToDouble( amountTextEdit.EditValue);
            Ancestor.reason = reasonTextEdit.EditValue.ToString();
        }

        public override void New()
        {
            Ancestor = new ancestor() { };
            base.New();
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
            context.ancestors.AddOrUpdate(Ancestor);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.ancestors.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (empIDTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد السلفة التى تريد حذفها ");
                return;
            }
            context.ancestors.Remove(Ancestor);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void ancestorW_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            dateAncestorDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
}
