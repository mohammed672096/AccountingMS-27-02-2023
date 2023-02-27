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
    public partial class OfficialVacationView : MasterView
    {


        private static OfficialVacationView instance;
        public static OfficialVacationView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new OfficialVacationView(); return instance; } }


        accountingEntities context;
        public OfficialVacation Vacation { get => officialVacationBindingSource.Current as OfficialVacation; set => officialVacationBindingSource.DataSource = value; }
        public OfficialVacationView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += OfficialVacationView_Shown;
        }

        private void OfficialVacationView_Shown(object sender, EventArgs e)
        {
            if (Vacation == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            OfficialVacation row = gridView1.GetRow(gridView1.FocusedRowHandle) as OfficialVacation;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.OfficialVacations.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                Vacation = sourceDepr;
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
            Vacation = new OfficialVacation() { };
            base.New();
        }
        public override void Save()
        {
            if (ToDateDateEdit.Text.Trim() == string.Empty.Trim() || FromDateDateEdit.Text.Trim() == string.Empty.Trim())
                return;

            EnableValidation(dataLayoutControl1);
            if (this.ValidateChildren() == false)
                return;
            DisableValidation(dataLayoutControl1);
            context.OfficialVacations.AddOrUpdate(Vacation);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.OfficialVacations.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            context.OfficialVacations.Remove(Vacation);
            context.SaveChanges();

           base.Delete();
            New();
            RefreshData();
        }

        private void OfficialVacationView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            FromDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            ToDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
}
