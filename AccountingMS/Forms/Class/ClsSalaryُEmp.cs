using DevExpress.Data.Browsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS.Classes
{
    public class ClsSalaryُEmp
    {
        accountingEntities db = new accountingEntities();
        public double semp(int i)
        {
            var s = db.tblEmployees.FirstOrDefault(m => m.id == i);
            return (Convert.ToDouble(s.empSal));
        }
        public double ancestorEmp(int i, DateTime M, DateTime y)
        {
            try
            {
                var s = db.ancestors.ToList().Where(m => m.empID == i
                                              && m.dateAncestor.Value.Date >= M.Date
                                              && m.dateAncestor.Value.Date <= y.Date)
                                              .Sum(x => (x.amount));


                if (s == null) return (0);

                return (s.Value);
            }
            catch (Exception)
            {
                return (0);

            }

        }
        public int shiftId()
        {
            int m = db.Shifts.Max(m => m.id);
            return (m);
        }
        public void DeleteshiftId(int id)
        {
            var mtt = db.TimeTables.Where(m => m.ShiftId == id).ToList();
            foreach (var item in mtt)
            {
                db.TimeTables.Remove(item);
                db.SaveChanges();
            }

        }

        //public List<DaysInfo> GetDays(int month, int year)
        //{
        //    List<DaysInfo> daysInfoList = new List<DaysInfo>();
        //    DateTime currentDate;
        //    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
        //    {
        //        currentDate = new DateTime(year, month, day);
        //        daysInfoList.Add(new DaysInfo() { NameOfDay = currentDate.DayOfWeek.ToString(), DateOfDay = currentDate, time_attendance = "غياب", time_leave = "غياب" });
        //    }
        //    return daysInfoList;
        //}

        public TimeSpan SumTimAbsence(int i, DateTime M, DateTime y)
        {
            TimeSpan attendance = TimeSpan.Parse("0:0:0");
            TimeSpan AttLev = TimeSpan.Parse("0:0:0");
            var sa = db.AttendingLeavings.ToList().Where(m => m.empID == i
                                              && m.date_ancestor.Value.Date >= M.Date
                                              && m.date_ancestor.Value.Date <= y.Date);
            var emp = db.tblEmployees.FirstOrDefault(m => m.id == i);
            var shiftemp = db.Shifts.FirstOrDefault(m => m.id == emp.shiftID);
            var timtab = db.TimeTables.ToList().Where(x => x.ShiftId == emp.shiftID);
            if (timtab.Count() == 0)
            {
                return (TimeSpan.Parse("0"));
            }
            else if (timtab.Count() == 1)
            {
                var timAttLev = db.TimeTables.SingleOrDefault(x => x.ShiftId == emp.shiftID);
                // shiftemp.clock_work   //عدد ساعات العمل
                // shiftemp.emp_Login //السماح بوقت الحضور
                // shiftemp.emp_exit //السماح بوقت الخروج 

                foreach (var item in sa)  //وقت حضور الموظف
                {
                    // if (timtab.Count() == 0) break;

                    //وقت الحضور
                    TimeSpan ts2 = TimeSpan.Parse(item.time_attendance.ToString()); // حضور اليوم للموظف
                    TimeSpan ts4 = TimeSpan.Parse(timAttLev.time_attendance.ToString()); // معاد الحضور
                    if (ts4 < ts2)
                    {
                        // تطبيق لايحة الحضور المتأخر الغياب
                        TimeSpan totaltim = (ts2 - ts4);
                        if (totaltim > shiftemp.emp_Login)
                        {
                            attendance = (attendance) + (ts2 - ts4);

                            //يتم الخصم
                        }
                    }
                    //وقت الانصراف
                    if (item.time_leave != null)
                    {
                        TimeSpan ts6 = TimeSpan.Parse(item.time_leave.ToString()); // انصراف اليوم للموظف
                        TimeSpan ts8 = TimeSpan.Parse(timAttLev.Time_leave.ToString()); // معاد الانصراف
                        if (ts6 < ts8)
                        {
                            // تطبيق لايحة الحضور المتأخر الغياب
                            TimeSpan totaltim = (ts8 - ts6);
                            if (totaltim > shiftemp.emp_exit)
                            {
                                attendance = (attendance) + (ts8 - ts6);
                                //يتم الخصم
                            }
                        }
                    }
                }
            }

            else if (timtab.Count() > 1)
            {
                //موظف له اكثر من وردية

                //var timAttLev = db.TimeTables.SingleOrDefault(x => x.ShiftId == emp.shiftID);
                // shiftemp.clock_work   //عدد ساعات العمل
                // shiftemp.emp_Login //السماح بوقت الحضور
                // shiftemp.emp_exit //السماح بوقت الخروج 

                foreach (var item in sa)  //وقت حضور الموظف
                {
                    // if (timtab.Count() == 0) break;
                    var shiftdayemp = db.AttendingLeavings.Where(x => x.empID == item.empID && x.date_ancestor == item.date_ancestor);
                    TimeSpan tsbetween = TimeSpan.Parse("0:0:0");
                    foreach (var g in shiftdayemp)
                    {
                        if (g.time_attendance != null && g.time_leave != null)
                        {
                            TimeSpan ts6 = TimeSpan.Parse(g.time_attendance.ToString()); // انصراف اليوم للموظف
                            TimeSpan ts8 = TimeSpan.Parse(g.time_leave.ToString()); // معاد الانصراف
                            tsbetween = tsbetween + (ts8 - ts6);
                        }
                    }
                    attendance = attendance + (TimeSpan.Parse(shiftemp.clock_work.ToString()) - tsbetween);

                }


            }


            return (attendance);
        }

        //حساب عدد ساعات الاضافي
        public TimeSpan SumExtraHours(int i, DateTime M, DateTime y)
        {
            TimeSpan attendance = TimeSpan.Parse("0:0:0");
            TimeSpan AttLev = TimeSpan.Parse("0:0:0");
            var sa = db.AttendingLeavings.ToList().Where(m => m.empID == i
                                              && m.date_ancestor.Value.Date >= M.Date
                                              && m.date_ancestor.Value.Date <= y.Date);
            var emp = db.tblEmployees.FirstOrDefault(m => m.id == i);
            var shiftemp = db.Shifts.FirstOrDefault(m => m.id == emp.shiftID);
            var timtab = db.TimeTables.ToList().Where(x => x.ShiftId == emp.shiftID);
            if (timtab.Count() == 0)
            {
                return (TimeSpan.Parse("0"));
            }
            else if (timtab.Count() == 1)
            {
                var timAttLev = db.TimeTables.SingleOrDefault(x => x.ShiftId == emp.shiftID);
                TimeSpan clockWork = TimeSpan.Parse(shiftemp.clock_work.ToString()); //عدد ساعات العمل
                foreach (var item in sa)  //وقت حضور الموظف
                {
                    if (timtab.Count() == 1)
                    {
                        //وقت الحضور
                        if (item.time_attendance != null && item.time_leave != null)
                        {
                            TimeSpan ts2 = TimeSpan.Parse(item.time_attendance.ToString()); // حضور اليوم للموظف
                                                                                            // TimeSpan ts4 = TimeSpan.Parse(timAttLev.time_attendance.ToString()); // معاد الحضور
                            TimeSpan ts6 = TimeSpan.Parse(item.time_leave.ToString()); // انصراف اليوم للموظف
                                                                                       // TimeSpan ts8 = TimeSpan.Parse(timAttLev.Time_leave.ToString()); // معاد الانصراف
                            if (clockWork < (ts6 - ts2))
                            {
                                // تطبيق لايحة الاضافي  
                                TimeSpan totaltim = (ts6 - ts2);
                                totaltim = totaltim - clockWork;
                                if (totaltim > TimeSpan.Parse("0:59:0"))
                                {
                                    attendance = (attendance) + (totaltim);

                                    //يتم الخصم
                                }
                            }
                        }
                    }
                    else if (timtab.Count() > 1)
                    {

                    }

                }
            }

            return (attendance);
        }

        //حساب الاضافي
        public double SumvalueExtraHours(TimeSpan ti, int empid)
        {
            var emp = db.tblEmployees.FirstOrDefault(x => x.id == empid);
            var d = db.OvertimeAndDelayRegulations.SingleOrDefault(m => m.id == emp.delayRegulationIDint);
            if (d == null) return (0);

            double valemp = (Convert.ToDouble(d.ExtraValuePerHour) * Convert.ToDouble(ti.TotalMinutes)) / 60;

            return (valemp);
        }
        public double SumDelayValue(TimeSpan ti, int empid)
        {
            var emp = db.tblEmployees.FirstOrDefault(x => x.id == empid);
            var d = db.OvertimeAndDelayRegulations.SingleOrDefault(m => m.id == emp.delayRegulationIDint);
            if (d == null) return (0);
            double valemp = (Convert.ToDouble(d.DiscountValuePerHour) * Convert.ToDouble(ti.TotalMinutes)) / 60;

            return (valemp);
        }



        public double SumvalueAbsence(int ti, int empid)
        {
            var emp = db.tblEmployees.FirstOrDefault(x => x.id == empid);
            var d = db.OvertimeAndDelayRegulations.SingleOrDefault(m => m.id == emp.delayRegulationIDint);
            if (d == null) return (0);
            double valemp = (Convert.ToDouble(d.AbsenceValue) * Convert.ToDouble(ti));
            return (valemp);
        }



        //void calh()
        //{
        //    if (type_RosaceaTextEdit.SelectedIndex == 0)
        //    {
        //        TimeSpan ts2 = TimeSpan.Parse(time_attendanceTimeSpanEdit.Text);
        //        TimeSpan ts4 = TimeSpan.Parse(Time_leaveTimeSpanEdit.Text);
        //        var tx = (ts4 - ts2);
        //        clock_workTextEdit.Text = tx.Hours.ToString();
        //    }
        //    else
        //    {
        //        TimeSpan ts2 = TimeSpan.Parse(time_attendanceTimeSpanEdit.Text);
        //        TimeSpan ts22 = TimeSpan.Parse("23:00:00");
        //        TimeSpan ts4 = TimeSpan.Parse(Time_leaveTimeSpanEdit.Text);
        //        TimeSpan ts44 = TimeSpan.Parse("00:00:00");
        //        //var s = ts22 - ts2;
        //        //var x = ts4 - ts44;
        //        int a1 = Convert.ToInt32(x.TotalHours.ToString());
        //        int a2 = Convert.ToInt32(s.TotalHours.ToString());
        //        clock_workTextEdit.Text = Convert.ToString((a1 + a2) + 1);
        //    }


        //}


        public double ValInsurances(int i)
        {
            var s = db.tblEmployees.SingleOrDefault(m => m.id == i);

            return (Convert.ToDouble(s.InsuranceValue));
        }
        public double ValmealAllowance(int i)
        {
            var s = db.tblEmployees.SingleOrDefault(m => m.id == i);

            return (Convert.ToDouble(s.MealAllowance));
        }
        public double ValTransferAllowance(int i)
        {
            var s = db.tblEmployees.SingleOrDefault(m => m.id == i);

            return (Convert.ToDouble(s.TransferAllowance));
        }
        public double OtherRewards(int i, DateTime M, DateTime y)
        {
            var s = db.Rewards.ToList().Where(m => m.empid == i
                                              && m.dateAncestor.Value.Date >= M.Date
                                              && m.dateAncestor.Value.Date <= y.Date)
                                      .Sum(x => (x.amount));
            if (s == null) return (0);

            return (s.Value);
        }


    }
    //public class DaysInfo
    //{
    //    public string NameOfDay { get; set; }
    //    public DateTime DateOfDay { get; set; }
    //}

    //public List<DaysInfo> GetDays(int month, int year)
    //{
    //    List<DaysInfo> daysInfoList = new List<DaysInfo>();
    //    DateTime currentDate;
    //    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
    //    {
    //        currentDate = new DateTime(year, month, day);
    //        daysInfoList.Add(new DaysInfo() { NameOfDay = currentDate.DayOfWeek.ToString(), DateOfDay = currentDate });
    //    }
    //    return daysInfoList;
    //}



}
