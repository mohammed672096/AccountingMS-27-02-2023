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

namespace AccountingMS
{
    public partial class OvertimeAndDelayRegulationView : MasterView
    {
        private static OvertimeAndDelayRegulationView instance;
        public static OvertimeAndDelayRegulationView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new OvertimeAndDelayRegulationView(); return instance; } }
        accountingEntities context;
        public OvertimeAndDelayRegulation OverandDelay { get =>overtimeAndDelayRegulationBindingSource.Current as OvertimeAndDelayRegulation; set => overtimeAndDelayRegulationBindingSource.DataSource = value; }
        public OvertimeAndDelayRegulationView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += OvertimeAndDelayRegulationView_Shown;
        }
        private void OvertimeAndDelayRegulationView_Shown(object sender, EventArgs e)
        {
            if (OverandDelay == null)
                New();
        }
        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            OvertimeAndDelayRegulation row = gridView1.GetRow(gridView1.FocusedRowHandle) as OvertimeAndDelayRegulation;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.OvertimeAndDelayRegulations.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                OverandDelay = sourceDepr;
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
            OverandDelay = new OvertimeAndDelayRegulation() { };
            base.New();
        }
        void SetOverandDelay()
        {
            OverandDelay.name = nameTextEdit.EditValue.ToString();
            OverandDelay.DiscountValuePerHour = Convert.ToDouble(DiscountValuePerHourTextEdit.EditValue);
            OverandDelay.ExtraValuePerHour = Convert.ToDouble(ExtraValuePerHourTextEdit.EditValue);
            OverandDelay.AbsenceValue = Convert.ToDouble(AbsenceValueTextEdit.EditValue);
            OverandDelay.notes = notesTextEdit.EditValue.ToString();
        }
        public override void Save()
        {
            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            SetOverandDelay();
            context.OvertimeAndDelayRegulations.AddOrUpdate(OverandDelay);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.OvertimeAndDelayRegulations.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            context.OvertimeAndDelayRegulations.Remove(OverandDelay);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void OvertimeAndDelayRegulationView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
    
}
