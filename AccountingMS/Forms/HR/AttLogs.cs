using AccountingMS.Forms.Class;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AccountingMS.Forms.HR
{
    public partial class AttLogs : DevExpress.XtraEditors.XtraForm
    {
        bool bIsConnected = false;
        int iMachineNumber;
        int idwErrorCode = 0;
        zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        accountingEntities db = new accountingEntities();
        String sdwEnrollNumber;
        int idwVerifyMode;
        int idwInOutMode;
        int idwYear;
        int idwMonth;
        int idwDay;
        int idwHour;
        int idwMinute;
        int idwSecond;
        int idwWorkcode;

        int iGLCount = 0;

        public AttLogs()
        {
            InitializeComponent();
           
        }

        private void save_btn_Click(object sender, EventArgs e)
        {

        }

        void fill_name(int emp_code)
        {
            // var attt = db.AttendingLeavings.Where(m => m.empID == emp_code && m.date_ancestor ==);
        }
        void empname(int emp_code)
        {
            fill_name(emp_code);
            //fill_holiday()
            //Dim sql = "select * from employees where emp_name=N'" & (emp_name.Text) & "'"
            //Dim adp As New SqlDataAdapter(sql, sqlconn)
            //Dim ds As New DataSet
            //adp.Fill(ds)
            //Dim dt = ds.Tables(0)
            //If dt.Rows.Count > 0 Then
            //    Dim dr = dt.Rows(0)
            //    '========= بيانات اساسية============  
            //    emp_code.Text = dr!emp_code
            //    roseca.Text = dr!Rosacea
            //End If
        }
        void btnS(int emp_code, string attendType, string date_ancestor, string time_attendance)
        {
            if (emp_code == 0) return;
            empname(emp_code);

            // emp_name_SelectedIndexChanged(Nothing, Nothing)
            // If holiday.Text = Holiday1.Text Then
            //     Exit Sub
            // End If
            // If holiday.Text = Holiday2.Text Then
            //     Exit Sub
            // End If
            // If date_ancestor.Value >= Format(date_ancestor1.Value, "yyyy/MM/dd") And date_ancestor.Value <= Format(date_ancestor_2.Value, "yyyy/MM/dd") Then
            //     Exit Sub
            // End If

            // Try
            //     Dim sql = "select * from Attending_leaving where emp_name=N'" & (emp_name.Text) & "' and date_ancestor='" & Format(date_ancestor.Value, "yyyy/MM/dd") & "'"
            //     Dim adp As New SqlDataAdapter(sql, sqlconn)
            //     Dim ds As New DataSet
            //     adp.Fill(ds)
            //     Dim dt = ds.Tables(0)
            //     If dt.Rows.Count > 0 Then
            //         Dim dr = dt.Rows(0)
            //         '========= بيانات اساسية============
            //         Select Case attendType
            //             Case "IN"
            //                 dr!time_attendance = time_attendance.Text
            //                 'dr!time_leave = "00:00:00"
            //             Case "OUT"
            //                 ' dr!time_attendance ="00:00:00"
            //                 dr!time_leave = time_attendance.Text
            //         End Select
            //         'dr!time_leave = time_attendance.Text
            //         time_attendance1.EditValue = dr!time_attendance

            //         Dim ts2 As TimeSpan = TimeSpan.Parse(time_attendance1.Text)
            //         Dim ts4 As TimeSpan = TimeSpan.Parse(time_attendance.Text)
            //         Dim x = ts4 - ts2
            //         If type_Rosacea.Text = "وردية صباحية" Then
            //             dr!betwen_attendance = CType(x.TotalHours, String)
            //         Else
            //             Dim ts22 As TimeSpan = TimeSpan.Parse("23:00:00")
            //             Dim ts44 As TimeSpan = TimeSpan.Parse("00:00:00")
            //             Dim s = ts22 - ts2
            //             Dim z = ts4 - ts44
            //             Dim a1 As Integer = CType(z.TotalHours, String)
            //             Dim a2 As Integer = CType(s.TotalHours, String)
            //             dr!betwen_attendance = (a1 + a2) + 1
            //         End If
            //         Dim cmd As New SqlCommandBuilder(adp)
            //         adp.Update(dt)
            //     Else
            //         Dim dr = dt.NewRow
            //         dr!emp_code = emp_code.Text
            //         dr!emp_name = emp_name.Text
            //         dr!date_ancestor = Format(date_ancestor.Value, "yyyy/MM/dd")

            //         Select Case attendType
            //             Case "IN"
            //                 dr!time_attendance = time_attendance.Text
            //                 dr!time_leave = "00:00:00"
            //             Case "OUT"
            //                 dr!time_attendance = "00:00:00"
            //                 dr!time_leave = time_attendance.Text
            //         End Select
            //         'dr!time_attendance = time_attendance.Text
            //         'dr!time_leave = "00:00:00"
            //         dr!betwen_attendance = 0
            //         dt.Rows.Add(dr)
            //         Dim cmd As New SqlCommandBuilder(adp)
            //         adp.Update(dt)
            //     End If
            //     new_fill()
            // Catch ex As Exception
            // End Try
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (bIsConnected == false)
            {
                XtraMessageBox.Show("الرجاء توصيل الجهاز أولا");
                return;
            }
            dgv1.Rows.Clear();
            //String sdwEnrollNumber;
            //int idwVerifyMode;
            //int idwInOutMode;
            //int idwYear;
            //int idwMonth;
            //int idwDay;
            //int idwHour;
            //int idwMinute;
            //int idwSecond;
            //int idwWorkcode;

            //int idwErrorCode;
            //int iGLCount = 0;
            //Dim lvItem As New ListViewItem("Items", 0)

            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(iMachineNumber, false); //'disable the device
            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))   //'read all the attendance records to the memory
            {
                //    'get records from the memory

                //while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode))
                //{
                //    int num5 = dgv1.Rows.Add();
                //    iGLCount += 1;
                //    dgv1.Rows[num5].Cells[0].Value = iGLCount.ToString();
                //    dgv1.Rows[num5].Cells[1].Value = sdwEnrollNumber;
                //    dgv1.Rows[num5].Cells[2].Value = idwVerifyMode.ToString();
                //    dgv1.Rows[num5].Cells[3].Value = idwInOutMode.ToString();
                //    //dgv1.Rows[num5].Cells[4].Value = idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString();
                //    dgv1.Rows[num5].Cells[6].Value = iGLCount.ToString();
                //    //dgv1.Rows[num5].Cells[5].Value = idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString();
                //}

                for (int i = 0; i < dgv1.Rows.Count - 1; i--)
                {
                    if (Convert.ToDateTime(dgv1.Rows[i].Cells[4].Value) < DateTimePicker1.DateTime || Convert.ToDateTime(dgv1.Rows[i].Cells[4].Value) > DateTimePicker2.DateTime)
                        dgv1.Rows.RemoveAt(i);
                }
                for (int z = 0; z < dgv1.Rows.Count - 1; z++)
                {
                    switch (dgv1.Rows[z].Cells[3].Value)
                    {
                        case 0:
                            dgv1.Rows[z].Cells[3].Value = "IN";
                            break;
                        case 1:
                            dgv1.Rows[z].Cells[3].Value = "OUT";
                            break;
                        case 2:
                            dgv1.Rows[z].Cells[3].Value = "Break-Out";
                            break;
                        case 3:
                            dgv1.Rows[z].Cells[3].Value = "Break-In";
                            break;
                        case 4:
                            dgv1.Rows[z].Cells[3].Value = "Ot-In";
                            break;
                        case 5:
                            dgv1.Rows[z].Cells[3].Value = "OUT";
                            break; ;
                        default:
                            break;
                    }
                }

                //    //    '--------------------------------------
                //    //    ' كود حساب الوقت ناقص

                //    //    '--------------------------------------
                for (int i = 0; i < dgv1.Rows.Count - 1; i++)
                {

                    var emp = db.tblEmployees.SingleOrDefault(m => m.fingerprintcode == dgv1.Rows[i].Cells[1].Value.ToString());
                    if (emp != null)
                    {
                        dgv1.Rows[i].Cells[8].Value = emp.empName;
                        dgv1.Rows[i].Cells[9].Value = emp.id;
                    }
                    else
                    {
                        dgv1.Rows[i].Cells[8].Value = "لا يوجد موظف";
                    }
                }
            }

            else
            {
                Cursor = Cursors.Default;
                axCZKEM1.GetLastError(idwErrorCode);
                if (idwErrorCode != 0)
                {
                    XtraMessageBox.Show("Reading data from terminal failed,ErrorCode ");
                }
                else
                {
                    XtraMessageBox.Show("No data from terminal returns!");
                }


            }

            axCZKEM1.EnableDevice(iMachineNumber, true); //'enable the device
                Cursor = Cursors.Default;
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtIP.Text.Trim() == "")
                {
                    XtraMessageBox.Show("لا يمكن أن يكون IP والمنفذ فارغين");
                    return;
                }

                Cursor = Cursors.WaitCursor;

                if (btnConnect.Text == "قطع الاتصال")
                {
                    axCZKEM1.Disconnect();
                    bIsConnected = false;
                    btnConnect.Text = "اتصال";
                    lblState.Text = "الحالة الحالية: غير متصل";
                    Cursor = Cursors.Default;
                    return;
                }
                bIsConnected = axCZKEM1.Connect_Net(txtIP.Text.Trim(), Convert.ToInt32(txtPort.Text.Trim()));
                if (bIsConnected == true)
                {
                    btnConnect.Text = "قطع الاتصال";
                    btnConnect.Refresh();
                    lblState.Text = "الحالة الحالية: متصل";
                    iMachineNumber = 1; //n fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                    axCZKEM1.RegEvent(iMachineNumber, 65535); //'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                }
                else
                {
                    axCZKEM1.GetLastError(idwErrorCode);
                    XtraMessageBox.Show("تعذر توصيل الجهاز ، رمز الخطأ=");

                }
                Cursor = Cursors.Default;

            }
            catch (Exception)
            {



            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (cbPort.Text.Trim() == "" || cbBaudRate.Text.Trim() == "" || txtMachineSN.Text.Trim() == "")
            {
                XtraMessageBox.Show("لا يمكن أن يكون المنفذ ومعدل Baud ");
                return;
            }
            // int idwErrorCode;
            int iPort = 0;
            string sPort = cbPort.Text.Trim();
            for (int i = 1; i < 9; i++)
            {
                if (sPort.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            Cursor = Cursors.WaitCursor;

            if (btnRsConnect.Text == "قطع الاتصال")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnRsConnect.Text = "الاتصال";
                lblState.Text = "الحالة الحالية: غير متصل";
                Cursor = Cursors.Default;
                return;
            }

            iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim()); // //when you are using the serial port communication,you can distinguish different devices by their serial port number.
            bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()));
            if (bIsConnected == true)
            {
                btnRsConnect.Text = "Disconnect";
                btnRsConnect.Refresh();
                lblState.Text = "Current State:Connected";
                axCZKEM1.RegEvent(iMachineNumber, 65535); // Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=");
            }
            Cursor = Cursors.Default;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //int idwErrorCode;
            string sCom = "";
            Cursor = Cursors.WaitCursor;
            if (btnUSBConnect.Text == "Disconnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnUSBConnect.Text = "Connect";
                lblState.Text = "Current State:Disconnected";
                Cursor = Cursors.Default;
                return;
            }

            bool bSearch;
            SearchforUSBCom usbcom = new SearchforUSBCom(); // new

            bSearch = usbcom.SearchforCom(sCom);

            if (bSearch == false)
            {
                MessageBox.Show("Can not find the virtual serial port that can be used");
                Cursor = Cursors.Default;
                return;
            }
            int iPort;
            for (iPort = 1; iPort < 9; iPort++)
            {
                if (sCom.IndexOf(iPort.ToString()) > -1) break;
            }
            iMachineNumber = Convert.ToInt32(txtMachineSN2.Text.Trim());
            if (iMachineNumber == 0 || iMachineNumber > 255)
            {
                MessageBox.Show("The Machine Number is invalid!");
                Cursor = Cursors.Default;
                return;
            }
            var iBaudRate = 115200; // 115200 is one possible baudrate value(its value cannot be 0)
            bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, iBaudRate);

            if (bIsConnected == true)
            {
                btnUSBConnect.Text = "Disconnect";
                btnUSBConnect.Refresh();
                lblState.Text = "Current State:Connected";
                axCZKEM1.RegEvent(iMachineNumber, 65535); // Here you can register the realtime events that you want
            }
            else
            {
                axCZKEM1.GetLastError(idwErrorCode);
                MessageBox.Show("Unable to connect the device");
            }

            Cursor = Cursors.Default;

        }

        private void AttLogs_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            DateTimePicker1.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            DateTimePicker2.EditValue = DateTime.Now.ToString("yyyy/MM/dd");


            btnConnect_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count == 0)
            {
                XtraMessageBox.Show("لا يوجد حضور او انصراف لتسجيله");
            }
            else
            {
                try
                {
                    var att = db.AttendingLeavings.ToList().Where(a => a.date_ancestor.Value.Date >= DateTimePicker1.DateTime.Date && a.date_ancestor.Value.Date <= DateTimePicker2.DateTime.Date);
                    foreach (var i in att)
                    {
                        var item = db.AttendingLeavings.SingleOrDefault(m => m.id == i.id);
                        db.AttendingLeavings.Remove(item);
                        db.SaveChanges();
                    }

                    for (int i = 0; i < dgv1.Rows.Count - 1; i++)
                    {
                        int emp_code = Convert.ToInt32(dgv1.Rows[i].Cells[9].Value);
                        string attendType = dgv1.Rows[i].Cells[3].Value.ToString();
                        string date_ancestor = dgv1.Rows[i].Cells[4].Value.ToString();
                        string time_attendance = dgv1.Rows[i].Cells[5].Value.ToString();
                        btnS(emp_code, attendType, date_ancestor, time_attendance);
                    }
                    XtraMessageBox.Show("تم الحفظ بنجاح");


                }
                catch (Exception)
                {


                }
            }
        }
    }
}