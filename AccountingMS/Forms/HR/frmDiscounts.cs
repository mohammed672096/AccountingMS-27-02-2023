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
    public partial class frmDiscounts : MasterView
    {
        private static frmDiscounts instance;
        public static frmDiscounts Instance { get { if (instance == null || instance.IsDisposed == true) instance = new frmDiscounts(); return instance; } }


        accountingEntities context;
        public Discount discount { get => discountBindingSource.Current as Discount; set => discountBindingSource.DataSource = value; }


        public frmDiscounts()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            empIDTextEdit.Properties.DataSource = context.tblEmployees.ToList();
            repositoryItemLookUpEdit1.DataSource = context.tblEmployees.ToList();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += FrmDiscounts_Shown;

        }

        private void FrmDiscounts_Shown(object sender, EventArgs e)
        {
            if (discount == null)
                New();
        }
        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Discount row = gridView1.GetRow(gridView1.FocusedRowHandle) as Discount;
            if (row != null)
                GoTo(row.id);
        }

        public void GoTo(int id)
        {
            var sourceDepr = context.Discounts.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                discount = sourceDepr;
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
            empIDTextEdit.EditValue = discount.empID;
            date_ancestorDateEdit.EditValue = discount.date_ancestor;
            amountTextEdit.EditValue = discount.amount;
            reasonTextEdit.EditValue = discount.reason;
        }
        public void SetData()
        {
            discount.empID = (empIDTextEdit.EditValue as int?) ?? 0;
            discount.date_ancestor  = Convert.ToDateTime(date_ancestorDateEdit.EditValue);
            discount.amount = Convert.ToDouble(amountTextEdit.EditValue);
            discount.reason = reasonTextEdit.EditValue.ToString();
        }

        public override void New()
        {
            discount = new Discount() { };
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
            context.Discounts.AddOrUpdate(discount);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.Discounts.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (empIDTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد الخصم التى تريد حذفها ");
                return;
            }
            context.Discounts.Remove(discount);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            date_ancestorDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");

            
        }
    }
}