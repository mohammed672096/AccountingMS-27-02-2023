using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Hassib.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity.Migrations;
using AccountingMS;

namespace AccountingMS
{
    public partial class AbcenceRegulationView : MasterView
    {
        accountingEntities context = new accountingEntities();
        private static AbcenceRegulationView instance;
        public static AbcenceRegulationView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new AbcenceRegulationView(); return instance; } }


       
        public AbsenceRegulation regulation  { get => absenceRegulationBindingSource.Current as AbsenceRegulation; set => absenceRegulationBindingSource.DataSource = value; }
        public AbcenceRegulationView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += AbcenceRegulationView_Shown;
        }

        private void AbcenceRegulationView_Shown(object sender, EventArgs e)
        {
            if (regulation == null)
                New();
        }

        private   void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            AbsenceRegulation row = gridView1.GetRow(gridView1.FocusedRowHandle) as AbsenceRegulation;
            if (row != null)
                GoTo(row.id );
        }
        public void GoTo(int id)
        {
            var sourceRegulation = context.AbsenceRegulations.SingleOrDefault(x => x.id == id);
            if (sourceRegulation != null)
            {
                regulation = sourceRegulation;
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
            regulation = new AbsenceRegulation() { }; 
            base.New();
        }

        void Setregulation()
        {
            regulation.name = textEdit2.EditValue.ToString();
            regulation.daypermissionDayDeduction =Convert.ToDouble( textEdit3.EditValue);
            regulation.daypermissionFixedAmount = Convert.ToDouble( textEdit4.EditValue);
            regulation.nondaypermissionDayDeduction = Convert.ToDouble( textEdit5.EditValue);
            regulation.nondaypermissionFixedAmount = Convert.ToDouble( textEdit6.EditValue);
            regulation.balance = Convert.ToInt32(balanceTextEdit.EditValue);

        }
        public override void Save()
        {
            if (textEdit2.Text == String.Empty)
            {
                XtraMessageBox.Show("ادخل اسم اللائحة أولا  ");
                return;
            }

            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            Setregulation();
            context.AbsenceRegulations.AddOrUpdate(regulation);
           context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.AbsenceRegulations.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (textEdit2.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد اسم اللائحة التى تريد حذفها ");
                return;
            }

            context.AbsenceRegulations.Remove(regulation);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void dataLayoutControl1_Click(object sender, EventArgs e)
        {

        }

        private void AbcenceRegulationView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}
