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
    public partial class JobView : MasterView
    {

        private static JobView instance;
        public static JobView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new JobView(); return instance; } }


        accountingEntities context;
        public Job job { get => jobBindingSource.Current as Job; set => jobBindingSource.DataSource = value; }

        public JobView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += JobView_Shown;
        }

        private void JobView_Shown(object sender, EventArgs e)
        {
            if (job == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Job row = gridView1.GetRow(gridView1.FocusedRowHandle) as Job;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.Jobs.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                job = sourceDepr;
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
            job = new Job() { };
            base.New();
        }
        public override void Save()
        {
            if (textEdit2.Text==String.Empty )
            {
                XtraMessageBox.Show("ادخل اسم الوظيفة أولا ");
                return;
            }
            EnableValidation(dataLayoutControl1);
            if (this.ValidateChildren() == false)
                return;
            DisableValidation(dataLayoutControl1);
            context.Jobs.AddOrUpdate(job);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.Jobs.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (textEdit2.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد الوظيفة التى تريد حذفها ");
                return;
            }
            context.Jobs.Remove(job);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void JobView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
    }
