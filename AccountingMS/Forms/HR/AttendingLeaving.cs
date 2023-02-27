using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class AttendingLeavingD : DevExpress.XtraEditors.XtraForm//: MasterView
    {
        private static AttendingLeavingD instance;
        public static AttendingLeavingD Instance { get { if (instance == null || instance.IsDisposed == true) instance = new AttendingLeavingD(); return instance; } }


        accountingEntities context;
        public AttendingLeaving AttendingLeav { get => attendingLeavingBindingSource.Current as AttendingLeaving; set => attendingLeavingBindingSource.DataSource = value; }

        public AttendingLeavingD()
        {
            InitializeComponent();
            //  DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            //gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView2.CustomColumnDisplayText += GridView2_CustomColumnDisplayText;
            this.Shown += AttendingLeaving_Shown;
        }

        private void GridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colempID)
            {
                var empName = context.tblEmployees.Find(Convert.ToInt32(e.Value));
                if (empName == null) return;
                e.DisplayText = empName.empName;

            }
           
        }

        private void AttendingLeaving_Shown(object sender, EventArgs e)
        {
            if (AttendingLeav == null)
                New();
        }



        //private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        //{
        //    Department row = gridView1.GetRow(gridView1.FocusedRowHandle) as Department;
        //    if (row != null)
        //        GoTo(row.id);
        //}
        //public void GoTo(int id)
        //{
        //    var sourceDepr = context.Departments.SingleOrDefault(x => x.id == id);

        //    if (sourceDepr != null)
        //    {
        //        department = sourceDepr;
        //        ParentIDLookUpEdit.Properties.DataSource = context.Departments
        //        .Where(depr => depr.id != sourceDepr.id).ToList();
        //        DataChanged = false;
        //        IsNew = false;
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show("المستند غير موجود ");
        //    }
        //}


        public void New()
        {
            AttendingLeav = new AttendingLeaving() { };
            //base.New();
        }

        //public void Save()
        //{

        //    setAttendingLeav();
        //    context.AttendingLeavings.AddOrUpdate(AttendingLeav);
        //    context.SaveChanges();
        //    // base.Save();
        //    New();
        //    RefreshData();
        //}
        public void RefreshData()
        {
            // gridControl1.DataSource = context.AttendingLeavings.ToList();

            //ParentIDLookUpEdit.Properties.DataSource = context.AttendingLeavings.ToList();

            //  base.RefreshData();
        }
        public void Delete()
        {
            context.AttendingLeavings.Remove(AttendingLeav);
            context.SaveChanges();
            //base.Delete();
            New();
            RefreshData();
        }

        private void AttendingLeavingD_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            empIDTextEdit.Properties.DataSource = context.tblEmployees.ToList();
            date_ancestorDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            time_attendanceTimeSpanEdit.EditValue = DateTime.Now.ToString("hh:mm:ss");
            time_leaveTimeSpanEdit.EditValue = DateTime.Now.ToString("hh:mm:ss");

        }

        private void date_ancestorDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            dteEmp();
        }

        void dteEmp()
        {
            if (empIDTextEdit.Text == "" || date_ancestorDateEdit.Text == "") return;
            using (accountingEntities db = new accountingEntities())
            {
                var attendance = db.AttendingLeavings.ToList().FirstOrDefault(m => m.empID == Convert.ToInt32(empIDTextEdit.EditValue)
                                            && m.date_ancestor.Value.Date.ToString("yyyy/MM/dd") == date_ancestorDateEdit.DateTime.Date.ToString("yyyy/MM/dd")
                                            && m.time_attendance != null
                                            && m.time_leave == null
                                            );

                if (attendance != null)
                {
                    // if (time_leaveTimeSpanEdit.EditValue == null || time_leaveTimeSpanEdit.EditValue.ToString() == "") return;
                    btnAdd.Text = "انصراف";
                    ItemFortime_attendance.Enabled = false;
                    ItemFortime_leave.Enabled = true;
                    time_attendanceTimeSpanEdit.EditValue = attendance.time_attendance;
                    // attendingLeavingBindingSource.DataSource = attendance;
                }
                else
                {
                    // if (time_attendanceTimeSpanEdit.EditValue == null || time_attendanceTimeSpanEdit.EditValue.ToString() == "") return;
                    btnAdd.Text = "حضور";
                    time_attendanceTimeSpanEdit.EditValue = "";
                    ItemFortime_attendance.Enabled = true;
                    ItemFortime_leave.Enabled = false;
                    //  attendingLeavingBindingSource.DataSource = context.AttendingLeavings.ToList();
                }

                var AttendingLeavM = db.AttendingLeavings.ToList().Where(m => m.empID == Convert.ToInt32(empIDTextEdit.EditValue) && m.date_ancestor.Value.Month == date_ancestorDateEdit.DateTime.Month);
                gridControl1.DataSource = AttendingLeavM;
            }


        }

        private void empIDTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            dteEmp();
        }

        void calh()
        {
            //if (type_RosaceaTextEdit.SelectedIndex == 0)
            //{
            //    TimeSpan ts2 = TimeSpan.Parse(time_attendanceTimeSpanEdit.Text);
            //    TimeSpan ts4 = TimeSpan.Parse(Time_leaveTimeSpanEdit.Text);
            //    var tx = (ts4 - ts2);
            //    clock_workTextEdit.Text = tx.Hours.ToString();
            //}
            //else
            //{
            //    TimeSpan ts2 = TimeSpan.Parse(time_attendanceTimeSpanEdit.Text);
            //    TimeSpan ts22 = TimeSpan.Parse("23:00:00");
            //    TimeSpan ts4 = TimeSpan.Parse(Time_leaveTimeSpanEdit.Text);
            //    TimeSpan ts44 = TimeSpan.Parse("00:00:00");
            //    var s = ts22 - ts2;
            //    var x = ts4 - ts44;
            //    int a1 = Convert.ToInt32(x.TotalHours.ToString());
            //    int a2 = Convert.ToInt32(s.TotalHours.ToString());
            //    clock_workTextEdit.Text = Convert.ToString((a1 + a2) + 1);
            //}


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_attendanceTimeSpanEdit.EditValue = DateTime.Now.ToString("hh:mm:ss");
            time_leaveTimeSpanEdit.EditValue = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var attendance = context.AttendingLeavings.ToList().FirstOrDefault(m => m.empID == Convert.ToInt32(empIDTextEdit.EditValue)
                                            && m.date_ancestor.Value.Date.ToString("yyyy/MM/dd") == date_ancestorDateEdit.DateTime.Date.ToString("yyyy/MM/dd")
                                            && m.time_attendance != null
                                            && m.time_leave == null
                                            );
            int y = 0;
            if (attendance != null) y = attendance.id;

            AttendingLeaving ad = new AttendingLeaving();
            if (y > 0)
                ad = context.AttendingLeavings.SingleOrDefault(m => m.id == y);

            if (time_attendanceTimeSpanEdit.Enabled == true) ad.time_attendance = time_attendanceTimeSpanEdit.TimeSpan;
            if (time_leaveTimeSpanEdit.Enabled == true) ad.time_leave = time_leaveTimeSpanEdit.TimeSpan;

            ad.date_ancestor = date_ancestorDateEdit.DateTime.Date;
            ad.empID = Convert.ToInt32(empIDTextEdit.EditValue);

            if (time_attendanceTimeSpanEdit.Enabled == true)
                context.AttendingLeavings.Add(ad);
            context.SaveChanges();
            New();
            gridControl1.DataSource = null;
            //  RefreshData();
            XtraMessageBox.Show("تم الحفظ");
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            dteEmp();
        }

        private void repositoryDeleteButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.RowCount == 0) return;

            //if (XtraMessageBox.Show($"هل تريد حذف هذه الفترة ؟"{ }, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
            //{
            // gridView2.GetFocusedRow();
            var att = context. AttendingLeavings.Find(Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colid)));
            context.AttendingLeavings.Remove(att);
            context.SaveChanges();
         //   gridView2.DeleteRow(gridView2.FocusedRowHandle);
            XtraMessageBox.Show("تم الحذف.");
            var AttendingLeavM = context.AttendingLeavings.ToList().Where(m => m.empID == Convert.ToInt32(empIDTextEdit.EditValue) && m.date_ancestor.Value.Month == date_ancestorDateEdit.DateTime.Month);
            gridControl1.DataSource = AttendingLeavM;
            //}
        }
    }
}