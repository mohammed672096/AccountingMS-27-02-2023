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
    public partial class TimeTableView : MasterView
    {

        private static TimeTableView instance;
        public static TimeTableView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new TimeTableView(); return instance; } }


        accountingEntities context;
        public TimeTable table { get => timeTableBindingSource.Current as TimeTable; set => timeTableBindingSource.DataSource = value; }


        public TimeTableView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += TimeTableView_Shown;
        }

        private void TimeTableView_Shown(object sender, EventArgs e)
        {
            if (table == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            TimeTable row = gridView1.GetRow(gridView1.FocusedRowHandle) as TimeTable;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.TimeTables.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                table = sourceDepr;
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
            table = new TimeTable() { };
            base.New();
        }
        void setdata()
        {
            table.name = nameTextEdit.Text;
            table.time_attendance =TimeSpan.Parse( time_attendanceTimeSpanEdit.EditValue.ToString());
            table.Time_leave = TimeSpan.Parse(Time_leaveTimeSpanEdit.EditValue.ToString());
            table.ShiftType = ShiftTypeCheckEdit.Checked;
        }
        public override void Save()
        {
            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            setdata();
            context.TimeTables.AddOrUpdate(table);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.TimeTables.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {

            //base.Delete();
        }

        private void TimeTableView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}
