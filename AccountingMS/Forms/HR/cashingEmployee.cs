using AccountingMS.Classes;
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
using System.Data.SqlClient;
using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors;

namespace AccountingMS.Forms.HR
{
    public partial class cashingEmployee : DevExpress.XtraEditors.XtraForm
    {
        private static cashingEmployee instance;
        public static cashingEmployee Instance { get { if (instance == null || instance.IsDisposed == true) instance = new cashingEmployee(); return instance; } }
        cashingEmp cashingEmpl;
        formAddEmployeeVchr frmaddemp;
        accountingEntities context = new accountingEntities();
        ClsSalaryُEmp clsSemp = new ClsSalaryُEmp();
        public cashingEmployee()
        {
            InitializeComponent();

            cashingEmpBindingSource.DataSource = context.cashingEmps.ToList();
            BranchtextEdit.Properties.DataSource = context.tblBranches.ToList();
            entBoxNoTextEdit.Properties.DataSource = context.tblAccountBoxes.ToList();
            entBoxNoTextEdit.EditValueChanged += EntBoxNoTextEdit_EditValueChanged;
        }

        public cashingEmployee(formAddEmployeeVchr frmc)
        {
            InitializeComponent();
            frmaddemp = frmc;
            BranchtextEdit.Properties.DataSource = null;
            string emName = Convert.ToString(frmaddemp.gridView1.GetRowCellValue(frmaddemp.gridView1.FocusedRowHandle, "entAccName"));
            var id = context.tblEmployees.SingleOrDefault(m => m.empName == emName);
            tblEmployeeBindingSource.DataSource = context.tblEmployees.ToList().FirstOrDefault(x => x.id == id.id);
            layoutControlItem18.Visibility = LayoutVisibility.Never;
            layoutControlItem22.Visibility = LayoutVisibility.Never;
            layoutControlItem17.Visibility = LayoutVisibility.Never;
            layoutControlItem19.Visibility = LayoutVisibility.Never;
            layoutControlItem20.Visibility = LayoutVisibility.Never;
            layoutControlItem21.Visibility = LayoutVisibility.Never;
            entBoxNoTextEdit.Properties.DataSource = context.tblAccountBoxes.ToList();
            entBoxNoTextEdit.EditValueChanged += EntBoxNoTextEdit_EditValueChanged;
        }


        public cashingEmployee(cashingEmp obj, IEnumerable<cashingEmp> subObj, UCemployeesVchr ucEmployeeVchr, ClsTblEntryMain clsTbEntMain)
        {
            InitializeComponent();
            cashingEmpBindingSource.DataSource = context.cashingEmps.ToList();
            BranchtextEdit.Properties.DataSource = context.tblBranches.ToList();
            entBoxNoTextEdit.Properties.DataSource = context.tblAccountBoxes.ToList();
            entBoxNoTextEdit.EditValueChanged += EntBoxNoTextEdit_EditValueChanged;
        }


        private void EntBoxNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var curbox = context.tblAccountBoxes.Find(entBoxNoTextEdit.EditValue);
            entBoxNameTextEdit.EditValue = curbox.boxName;
            var curname = context.tblCurrencies.FirstOrDefault(m => m.id == curbox.boxCurrency);
            entCurrencyTextEdit.Text = curname.curName;
            entCurrencyTextEdit.EditValue = curname.curName;
            entCurrencyTextEdit.Tag = curname.id;


        }

        public class DaysInfo
        {
            public string NameOfDay { get; set; }
            public DateTime DateOfDay { get; set; }
            public string time_attendance { get; set; }
            public string time_leave { get; set; }
        }

        public List<DaysInfo> GetDays(int month, int year, int dy, int month2, int year2, int dy2)
        {
            List<DaysInfo> daysInfoList = new List<DaysInfo>();
            DateTime currentDate;

            int totalm = 0;
            if (month == month2) totalm = dy2; else totalm = DateTime.DaysInMonth(year, month);
            for (int day = dy; day <= totalm; day++)
            {
                currentDate = new DateTime(year, month, day);
                daysInfoList.Add(new DaysInfo() { NameOfDay = currentDate.DayOfWeek.ToString(), DateOfDay = currentDate, time_attendance = "غياب", time_leave = "غياب" });
            }
            if (month != month2)
            {
                for (int day = 1; day <= dy2; day++)
                {
                    currentDate = new DateTime(year2, month2, day);
                    daysInfoList.Add(new DaysInfo() { NameOfDay = currentDate.DayOfWeek.ToString(), DateOfDay = currentDate, time_attendance = "غياب", time_leave = "غياب" });
                }

            }

            return daysInfoList;
        }


        public void New()
        {
            new_ec();
            // base.New();
        }

       
        void setdata()
        {
            cashingEmpl.empID = Convert.ToInt32(empIDTextEdit.EditValue);
            // cashingEmpl.typePay = Convert.ToInt32( empIDTextEdit.EditValue);
            cashingEmpl.dateAncestor = Convert.ToDateTime(starttextEdit.EditValue);
            cashingEmpl.BasicSalary = Convert.ToDouble(Basic_salary.EditValue);
            cashingEmpl.ExtraHours = TimeSpan.Parse(Extra_hours.EditValue.ToString());
            cashingEmpl.valueExtraHours = Convert.ToDouble(value_extra_hours.EditValue);
            cashingEmpl.numberOfDays = Convert.ToDouble(number_of_days.EditValue);
            cashingEmpl.valueAbsence = Convert.ToDouble(value_absence.EditValue);
            cashingEmpl.NumberAbsence = TimeSpan.Parse(Number_absence.EditValue.ToString());
            cashingEmpl.DelayValue = Convert.ToDouble(Delay_value.EditValue);
            cashingEmpl.mealAllowance = Convert.ToDouble(meal_allowance.EditValue);
            cashingEmpl.TransferAllowance = Convert.ToDouble(Transfer_allowance.EditValue);
            cashingEmpl.OtherRewards = Convert.ToDouble(Other_rewards.EditValue);
            cashingEmpl.ancestor = Convert.ToDouble(ancestor.EditValue);
            cashingEmpl.Insurances = Convert.ToDouble(Insurances.EditValue);
            cashingEmpl.OtherDiscounts = Convert.ToDouble(Other_discounts.EditValue);
            cashingEmpl.NetSalary = Convert.ToDouble(Net_salary.EditValue);
            cashingEmpl.entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue);
            cashingEmpl.entDate = datetextEdit.DateTime.Date;
            cashingEmpl.entDesc = entDesctextEdit.Text;
            cashingEmpl.entCurrency = Convert.ToByte(Convert.ToInt32(entCurrencyTextEdit.Tag));
        }

        void getdata()
        {
            empIDTextEdit.EditValue = cashingEmpl.empID;
            // empIDTextEdit.EditValue = cashingEmpl.typePay ; 
            starttextEdit.EditValue = cashingEmpl.dateAncestor;
            Basic_salary.EditValue = cashingEmpl.BasicSalary;
            Extra_hours.EditValue = cashingEmpl.ExtraHours;
            value_extra_hours.EditValue = cashingEmpl.valueExtraHours;
            number_of_days.EditValue = cashingEmpl.numberOfDays;
            value_absence.EditValue = cashingEmpl.valueAbsence;
            Number_absence.EditValue = cashingEmpl.NumberAbsence;
            Delay_value.EditValue = cashingEmpl.DelayValue;
            meal_allowance.EditValue = cashingEmpl.mealAllowance;
            Transfer_allowance.EditValue = cashingEmpl.TransferAllowance;
            Other_rewards.EditValue = cashingEmpl.OtherRewards;
            ancestor.EditValue = cashingEmpl.ancestor;
            Insurances.EditValue = cashingEmpl.Insurances;
            Other_discounts.EditValue = cashingEmpl.OtherDiscounts;
            Net_salary.EditValue = cashingEmpl.NetSalary;
            entBoxNoTextEdit.EditValue = cashingEmpl.entBoxNo;
            datetextEdit.EditValue = cashingEmpl.entDate; ;
            entDesctextEdit.Text = cashingEmpl.entDesc;

        }

        void Save()
        {

        }

        void Print()
        {
            // gridControl1.Print();

            using (ReportForm frmr = new ReportForm(null))
            {
                Reports.ReportCashingEmployee rep = new Reports.ReportCashingEmployee();
                rep.xrlHeader.Text = (" كشف مرتب السيد / "
                + empIDTextEdit.Text
                    + "راتب شهر  "
                   + starttextEdit.Text);
                rep.xrTableCell6.Text = Basic_salary.Text;
                rep.xrTableCell8.Text = meal_allowance.Text;
                rep.xrTableCell14.Text = Extra_hours.Text;
                rep.xrTableCell18.Text = Transfer_allowance.Text;
                rep.xrTableCell30.Text = Delay_value.Text;
                rep.xrTableCell11.Text = number_of_days.Text;
                rep.xrTableCell12.Text = ancestor.Text;
                rep.xrTableCell16.Text = value_absence.Text;
                rep.xrTableCell20.Text = Insurances.Text;
                rep.xrTableCell25.Text = Extra_hours.Text;
                rep.xrTableCell26.Text = Number_absence.Text;
                rep.xrTableCell27.Text = Other_rewards.Text;
                rep.xrTableCell28.Text = Other_discounts.Text;
                rep.xrTableCell34.Text = Net_salary.Text;
                rep.DataSource = gridControl1.DataSource;
                rep.RequestParameters = false;
                frmr.documentViewer1.DocumentSource = rep;
                frmr.ShowDialog();
            }
            // base.Print();
        }


        private void BranchtextEdit_EditValueChanged(object sender, EventArgs e)
        {
            empIDTextEdit.Properties.DataSource = context.tblEmployees.ToList().Where(m => m.empBrnId == Convert.ToInt32(BranchtextEdit.EditValue));

        }

        void new_ec()
        {
            Basic_salary.Text = "0";
            Extra_hours.Text = "0";
            value_extra_hours.Text = "0";
            number_of_days.Text = "0";
            value_absence.Text = "0";
            Number_absence.Text = "0";
            Delay_value.Text = "0";
            meal_allowance.Text = "0";
            Transfer_allowance.Text = "0";
            Other_rewards.Text = "0";
            ancestor.Text = "0";
            Insurances.Text = "0";
            Other_discounts.Text = "0";
            Net_salary.Text = "0";
        }

        void fillgrid()
        {
            if (starttextEdit.Text == "" || starttextEdit.Text == null) return;
            if (empIDTextEdit.EditValue == null) return;

            Basic_salary.EditValue = clsSemp.semp(Convert.ToInt32(empIDTextEdit.EditValue));
            var fillMonth = GetDays(starttextEdit.DateTime.Month, starttextEdit.DateTime.Year, starttextEdit.DateTime.Day, EndttextEdit.DateTime.Month, EndttextEdit.DateTime.Year, EndttextEdit.DateTime.Day);
            var totalday = Convert.ToDateTime(EndttextEdit.Text) - Convert.ToDateTime(starttextEdit.Text);
            gridControl1.DataSource = fillMonth;
            foreach (GridColumn item in dgv.Columns)
                item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            if (starttextEdit.Text == "") return;
            var daoff = context.AttendingLeavings.ToList().Where(m => m.empID == Convert.ToInt32(empIDTextEdit.EditValue)
                                                 && m.date_ancestor.Value.Date >= starttextEdit.DateTime.Date &&
                                                 m.date_ancestor.Value.Date <= EndttextEdit.DateTime.Date);

            foreach (var item in daoff)
            {
                for (short i = 0; i < dgv.DataRowCount; i++)
                {
                    if (Convert.ToDateTime(dgv.GetRowCellValue(i, coldate_ancestor)).Date == item.date_ancestor.Value.Date)
                    {
                        if (dgv.GetRowCellValue(i, coltime_attendance).ToString() == "غياب")
                        {
                            dgv.SetRowCellValue(i, coltime_leave, item.time_leave.ToString());
                            dgv.SetRowCellValue(i, coltime_attendance, item.time_attendance.ToString());
                            int ff = daoff.Count();

                        }
                    }
                    var emp = context.tblEmployees.Find(Convert.ToInt32(empIDTextEdit.EditValue));
                    var shiftemp = context.Shifts.FirstOrDefault(m => m.id == emp.shiftID);
                    if (shiftemp != null)
                    {
                        if (shiftemp.Holiday1 == dgv.GetRowCellValue(i, colday).ToString() || shiftemp.Holiday2 == dgv.GetRowCellValue(i, colday).ToString())
                        {
                            dgv.SetRowCellValue(i, coltime_attendance, "اجازة اسبوعية");
                            dgv.SetRowCellValue(i, coltime_leave, "اجازة اسبوعية");
                        }
                    }

                    //  الاجازات الرسميه
                    var offi = context.OfficialVacations.ToList().SingleOrDefault(m => m.fromdate.Date == Convert.ToDateTime(dgv.GetRowCellValue(i, coldate_ancestor).ToString()).Date);
                    if (offi != null)
                    {
                        dgv.SetRowCellValue(i, coltime_attendance, "اجازة رسمية");
                        dgv.SetRowCellValue(i, coltime_leave, "اجازة رسمية");
                    }

                    // الاجازات السنوية
                    DateTime dateday = Convert.ToDateTime(dgv.GetRowCellValue(i, coldate_ancestor));
                    var formhold = context.HolidayEmps.SingleOrDefault(m => m.empID == emp.id && m.dateAncestor.Value.Day == dateday.Day && m.dateAncestor.Value.Month == dateday.Month && m.dateAncestor.Value.Year == dateday.Year);
                    if (formhold != null)
                    {
                        dgv.SetRowCellValue(i, coltime_attendance, "اجازة سنوية");
                        dgv.SetRowCellValue(i, coltime_leave, "اجازة سنوية");
                    }

                }
            }

            //ورديات الموظف
            var shift = context.Shifts;

            //تأخير الموظف

            foreach (var item in daoff)
            {
                //item.time_attendance
                //item.time_leave

            }

            gridControl1.DataSource = fillMonth;
            number_of_days.EditValue = fillMonth.Count(x => x.time_attendance == "غياب");
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            new_ec();
            fillgrid();
            if (empIDTextEdit.Text == "" || empIDTextEdit.EditValue == null) return;
            if (starttextEdit.Text == "" || EndttextEdit.EditValue == null) return;
            //السلفيات
            ancestor.EditValue = clsSemp.ancestorEmp(Convert.ToInt32(empIDTextEdit.EditValue), Convert.ToDateTime(starttextEdit.EditValue), Convert.ToDateTime(EndttextEdit.EditValue));
            //التأمينات
            Insurances.EditValue = clsSemp.ValInsurances(Convert.ToInt32(empIDTextEdit.EditValue));
            //بدل وجبات
            meal_allowance.EditValue = clsSemp.ValmealAllowance(Convert.ToInt32(empIDTextEdit.EditValue));
            //بدل انتقالات
            Transfer_allowance.EditValue = clsSemp.ValTransferAllowance(Convert.ToInt32(empIDTextEdit.EditValue));
            //المكافأة
            Other_rewards.EditValue = clsSemp.OtherRewards(Convert.ToInt32(empIDTextEdit.EditValue), Convert.ToDateTime(starttextEdit.EditValue), Convert.ToDateTime(EndttextEdit.EditValue));
            //حساب عدد ساعات الاضافي
            Extra_hours.EditValue = clsSemp.SumExtraHours(Convert.ToInt32(empIDTextEdit.EditValue), Convert.ToDateTime(starttextEdit.EditValue), Convert.ToDateTime(EndttextEdit.EditValue));
            //حساب قيمة الاضافي
            value_extra_hours.EditValue = clsSemp.SumvalueExtraHours(TimeSpan.Parse(Extra_hours.EditValue.ToString()), Convert.ToInt32(empIDTextEdit.EditValue));

            //حساب عدد ساعات التأخير
            Number_absence.EditValue = clsSemp.SumTimAbsence(Convert.ToInt32(empIDTextEdit.EditValue), Convert.ToDateTime(starttextEdit.EditValue), Convert.ToDateTime(EndttextEdit.EditValue));
            Number_absence.EditValue = Number_absence.Text.Replace("-", "");
            //حساب قيمة التأخير
            Delay_value.EditValue = clsSemp.SumDelayValue(TimeSpan.Parse(Number_absence.EditValue.ToString()), Convert.ToInt32(empIDTextEdit.EditValue));
            Delay_value.EditValue = Math.Round(Convert.ToDouble(Delay_value.EditValue), 2).ToString();
            //حساب قيمة الغياب
            value_absence.EditValue = clsSemp.SumvalueAbsence(Convert.ToInt32(number_of_days.EditValue), Convert.ToInt32(empIDTextEdit.EditValue));
        }

        private void starttextEdit_EditValueChanged(object sender, EventArgs e)
        {
            textEdit2_EditValueChanged(null, null);
        }
        void ofDays()
        {
            try
            {
                number_of_days.EditValue = clsSemp.semp(Convert.ToInt32(empIDTextEdit.EditValue));
                var daoff = context.AttendingLeavings.ToList();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        void fill()
        {
            Net_salary.Text = Convert.ToString(Convert.ToDouble(Basic_salary.EditValue)
                                            + Convert.ToDouble(value_extra_hours.EditValue)
                                            - Convert.ToDouble(value_absence.EditValue)
                                            - Convert.ToDouble(Delay_value.Text)
                                            + Convert.ToDouble(meal_allowance.Text)
                                            + Convert.ToDouble(Transfer_allowance.Text)
                                            + Convert.ToDouble(Other_rewards.Text)
                                            - Convert.ToDouble(ancestor.Text)
                                            - Convert.ToDouble(Insurances.Text)
                                            - Convert.ToDouble(Other_discounts.Text));
            Net_salary.Text = Math.Round(Convert.ToDouble(Net_salary.Text), 2).ToString();
        }

        private void Other_rewards_EditValueChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void cashingEmployee_Load(object sender, EventArgs e)
        {

            datetextEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            EndttextEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            starttextEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void SaveEntrySubData()
        {
            using (accountingEntities db = new accountingEntities())
            {
                var empyid = db.tblEmployees.Find(Convert.ToInt32(empIDTextEdit.EditValue));
                var accbox = db.tblAccountBoxes.FirstOrDefault(m => m.id == empyid.empCurrency);
                var entmaall = db.tblEntryMains.ToList();
                int entma = 0;
                if (entmaall.Count() == 0)
                    entma = 0;
                else
                    entma = db.tblEntryMains.Max(x => x.id);
                entma = entma + 1;

                tblEntrySub tbEntSubMain = new tblEntrySub()
                {
                    entNo = entma,
                    entAccNo = Convert.ToInt32(entBoxNoTextEdit.Text),
                    entAccName = entBoxNameTextEdit.Text,
                    entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue),
                    entCredit = Convert.ToDouble(Net_salary.Text),
                    entDate = datetextEdit.DateTime,
                    entDesc = empIDTextEdit.Text + " " + entDesctextEdit.Text,
                    entCurrency = Convert.ToByte(accbox.id),
                    entBrnId = Session.CurBranch.brnId,
                    entView = 1,
                    entIsMain = 1,
                    entEqfal = 2,
                    entStatus = 7
                };
                db.tblEntrySubs.Add(tbEntSubMain);

                tblEntrySub tbEntSub = new tblEntrySub();
                tbEntSub.entNo = entma;
                tbEntSub.entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue);
                tbEntSub.entDate = datetextEdit.DateTime;
                tbEntSub.entBrnId = Session.CurBranch.brnId;
                tbEntSub.entView = 1;
                tbEntSub.entEqfal = 1;
                tbEntSub.entIsMain = 2;
                tbEntSub.entStatus = 7;
                db.tblEntrySubs.Add(tbEntSub);
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string nodtSalary = "راتب " + empIDTextEdit.Text + " من تاريخ " + starttextEdit.Text + " الى تاريخ " + EndttextEdit.Text;
            frmaddemp.entDescTextEdit.Text = " صرف راتب بتاريخ " + frmaddemp.entDateDateEdit.Text;

            frmaddemp.gridView1.SetRowCellValue(frmaddemp.gridView1.FocusedRowHandle, "entDebit", Net_salary.Text);
            frmaddemp.gridView1.SetRowCellValue(frmaddemp.gridView1.FocusedRowHandle, "entDesc", nodtSalary);
            this.Close();
            return;
            if (entDesctextEdit.Text == "" || entDesctextEdit == null || entBoxNoTextEdit.Text == "" || entBoxNoTextEdit == null)
            {
                XtraMessageBox.Show("يجب ادخال البيان ورقم الصندوق ");
                return;
            }

            cashingEmpl = new cashingEmp();
            setdata();
            context.cashingEmps.AddOrUpdate(cashingEmpl);
            context.SaveChanges();
            SaveEntrySubData();
            XtraMessageBox.Show("تم صرف الراتب بنجاح");
            New();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void EndttextEdit_EditValueChanged(object sender, EventArgs e)
        {
            textEdit2_EditValueChanged(null, null);
        }
    }
}
