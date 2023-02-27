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
using System.Globalization;
using DevExpress.XtraGrid;
using AccountingMS;
using System.Collections.ObjectModel;
using AccountingMS.Classes;

namespace AccountingMS
{
    public partial class ShiftView : MasterView
    {


        private static ShiftView instance;
        public static ShiftView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new ShiftView(); return instance; } }
        accountingEntities context;
        public Shift shift
        {
            get => shiftBindingSource.Current as Shift;
            set
            {
                shiftBindingSource.DataSource = value;
            }
        }

          public TimeTable timeTable
        {
            get => timeTableBindingSource.Current as TimeTable;
            set
            {
                timeTableBindingSource.DataSource = value;
            }
        }


        public ShiftView()
        {
            InitializeComponent();
            // IList<TimeTable> tbltim;
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += ShiftView_Shown;
        }

        private void ShiftView_Shown(object sender, EventArgs e)
        {
            if (shift == null)
                New();
            if (timeTable == null)
                New();

        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Shift row = gridView1.GetRow(gridView1.FocusedRowHandle) as Shift;
            if (row != null)
                GoTo(row.id);

            timeTableBindingSource.DataSource = context.TimeTables.ToList().Where(m => m.ShiftId == Convert.ToInt32(idTextEdit.EditValue));
            // gridControl2.DataSource = "";
        }
        public void GoTo(int id)
        {
            //var sourceDepr = 
            //    context.Shifts.Include(x=>x.ShiftDaysid)
            //    .SingleOrDefault(x => x.id == id);
            //if (sourceDepr != null)
            //{
            //    shift = sourceDepr; 
            //    DataChanged = false;
            //    IsNew = false;
            //}
            //else
            //{
            //    XtraMessageBox.Show("المستند غير موجود ");
            //}

            var sourceDepr = context.Shifts.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                shift = sourceDepr;
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
            shift = new Shift() { };
            timeTable = new TimeTable() { };
            base.New();
        }

        void setshift()
        {
            shift.name = nameTextEdit.Text;
            shift.clock_work =TimeSpan.Parse( clock_workTextEdit.EditValue.ToString());
            shift.Holiday1 = Holiday1TextEdit.EditValue.ToString();
            shift.Holiday2 = Holiday2TextEdit.EditValue.ToString();
            if (emp_LoginTextEdit.Text.Trim() != "")
                shift.emp_Login = TimeSpan.Parse(emp_LoginTextEdit.EditValue.ToString());
            if (emp_exitTextEdit.Text.Trim() != "")
                shift.emp_exit = TimeSpan.Parse(emp_exitTextEdit.EditValue.ToString());
        }
        public override void Save()
        {
            if (nameTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("ادخل اسم الوردية أولا ");
                return;
            }
            if  (gridView2.RowCount == 0)
            {
                XtraMessageBox.Show("ادخل وقت الوردية");
                return;
            }

            calh();
            setshift();
            context.Shifts.AddOrUpdate(shift);
            context.SaveChanges();
            base.Save();
            SaveGridData();
            New();
            RefreshData();
        }
        ClsSalaryُEmp clss = new ClsSalaryُEmp();
        private void SaveGridData()
        {
            TimeTable tbltimtabl = new TimeTable();
            for (short i = 0; i < gridView2.DataRowCount; i++)
            {
                tbltimtabl = new TimeTable();
                if (idTextEdit.Text == "0" || idTextEdit.Text.Trim() == "".Trim())
                    tbltimtabl.ShiftId = clss.shiftId();
                else
                {
                    tbltimtabl.ShiftId = Convert.ToInt32(idTextEdit.EditValue);
                    clss.DeleteshiftId(Convert.ToInt32(idTextEdit.EditValue));
                }
                tbltimtabl.time_attendance = TimeSpan.Parse(gridView2.GetRowCellValue(i, coltime_attendance).ToString());
                tbltimtabl.Time_leave = TimeSpan.Parse(gridView2.GetRowCellValue(i, colTime_leave).ToString());
                context.TimeTables.Add(tbltimtabl);
                context.SaveChanges();
            }
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.Shifts.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (nameTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد الوردية التى تريد حذفها ");
                return;
            }
            context.Shifts.Remove(shift);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        void calh()
        {
            if (gridView2.RowCount == 0) return;
            TimeSpan totalH = TimeSpan.Parse( "0");
            clock_workTextEdit.EditValue = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                    TimeSpan ts2 = TimeSpan.Parse(gridView2.GetRowCellValue(i, coltime_attendance).ToString());
                    TimeSpan ts4 = TimeSpan.Parse(gridView2.GetRowCellValue(i, colTime_leave).ToString());
                    totalH = totalH + (ts4 - ts2);
            }
            clock_workTextEdit.EditValue = (totalH);
        }

        void ShiftDays()
        {
            //int DayNo = 0;
            //int RowCount = 0;

            //try { DayNo = ((int)RepeatEveryTextEdit.EditValue); } catch { DayNo = 0; };
            //RowCount = gridViewShiftDay.RowCount;
            ////if (RowCount == 0)
            //{

            //    for (int i = 0; i < DayNo; i++)
            //    {
            //        gridViewShiftDay.AddNewRow();
            //        gridViewShiftDay.SetRowCellValue(i, gridViewShiftDay.Columns[0], i);


            //    }
            // }

            //else if (RowCount > DayNo)
            //{
            //    for (int i = RowCount; i >= DayNo; i--)
            //    {
            //        gridViewShiftDay.DeleteRow(i);


            //    }
            //} 


            //else if (RowCount < DayNo)
            //{
            //    for (int i = RowCount; i < DayNo; i++)
            //    {
            //        gridViewShiftDay.AddNewRow();
            //        gridViewShiftDay.SetRowCellValue(i, gridViewShiftDay.Columns[0], i);


            //    }
            //}

        }
        private void RepeatEveryTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            ShiftDays();
        }

        private void gridViewShiftDay_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // DateTime StartDate = DateTime.Now;

            //try { StartDate = (DateTime)StartDateDateEdit.EditValue; } catch { StartDate = DateTime.Now; }

            //if (e.Column.FieldName == "Day")
            //{

            //    StartDate = StartDate.AddDays((int)e.Value);
            //    e.DisplayText = StartDate.ToString("dddd", new CultureInfo("ar-AE"));
            //}


        }

        private void StartDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //  ShiftDays();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            calh();
        }

        private void repositoryItemButtonDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.RowCount == 0) return;

            //if (XtraMessageBox.Show($"هل تريد حذف هذه الفترة ؟"{ }, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
            //{
                // gridView2.GetFocusedRow();
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
                XtraMessageBox.Show("تم الحذف.");
            //}

        }

        private void ShiftView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }
    }
}
