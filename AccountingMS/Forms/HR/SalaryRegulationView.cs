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
using System.Data.Entity;
using AccountingMS;
using DevExpress.XtraEditors.Controls;

namespace AccountingMS
{
    public partial class SalaryRegulationView : MasterView
    {

        private static SalaryRegulationView instance;
        public static SalaryRegulationView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new SalaryRegulationView(); return instance; } }


        accountingEntities context;
        public SalaryRegulation Regulation { get => salaryRegulationBindingSource.Current as SalaryRegulation; set => salaryRegulationBindingSource.DataSource = value; }

        public SalaryRegulationView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += SalaryRegulationView_Shown;
        }



        private void SalaryRegulationView_Shown(object sender, EventArgs e)
        {
            if (Regulation == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            SalaryRegulation row = gridView1.GetRow(gridView1.FocusedRowHandle) as SalaryRegulation;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.SalaryRegulations.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                Regulation = sourceDepr;
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
            Regulation = new SalaryRegulation() { };
            base.New();
        }
        void SetRegulation()
        {
            Regulation.name = nameTextEdit.EditValue.ToString();
            Regulation.costCenter = costCenterTextEdit.EditValue.ToString();
            Regulation.ExpensesAccount =Convert.ToDouble( ExpensesAccountTextEdit.EditValue);
            Regulation.BenefitsAccount = Convert.ToDouble(BenefitsAccountTextEdit.EditValue);
            Regulation.DayValue= Convert.ToDouble(DayValueTextEdit.EditValue);
            Regulation.HourValue= Convert.ToDouble(HourValueTextEdit.EditValue);
            Regulation.SalaryPeriod = Convert.ToString(SalaryPeriodTextEdit.EditValue);
            Regulation.SalaryCalculation = Convert.ToString(SalaryCalculationTextEdit.EditValue);
            Regulation.DefaultSalary= Convert.ToDouble(DefaultSalaryTextEdit.EditValue);
            Regulation.Equation = Convert.ToDouble(EquationTextEdit.EditValue);

        }
        public override void Save()
        {
           // EnableValidation(dataLayoutControl1);
           // DisableValidation(dataLayoutControl1);
            SetRegulation();
            context.SalaryRegulations.AddOrUpdate(Regulation);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.SalaryRegulations.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            context.SalaryRegulations.Remove(Regulation);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void SalaryRegulationView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}
