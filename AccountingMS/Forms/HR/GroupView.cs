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
    public partial class GroupView : MasterView
    {

        private static GroupView instance;
        public static GroupView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new GroupView(); return instance; } }


        accountingEntities context;
        public Group group { get => groupBindingSource.Current as Group; set => groupBindingSource.DataSource = value; }

        public GroupView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += GroupView_Shown;
        }



        private void GroupView_Shown(object sender, EventArgs e)
        {
            if (group == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Group row = gridView1.GetRow(gridView1.FocusedRowHandle) as Group;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.Groups.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                group = sourceDepr;
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
            group = new Group() { };
            base.New();
        }
        public override void Save()
        {
            EnableValidation(dataLayoutControl1);
            if (this.ValidateChildren() == false)
                return;
            DisableValidation(dataLayoutControl1);
            context.Groups.AddOrUpdate(group);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.Groups.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {

            context.Groups.Remove(group);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void GroupView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}
