using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportEmpSalary : XtraReport
    {
        accountingEntities db = new accountingEntities();

        private dynamic tbEmployee;
        private dynamic tbEntSub;
        private short month;
        private short year;
        private bool isGeneral;
        private int empSal;

        public ReportEmpSalary(bool isGeneral)
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData();
            InitDefaultData();

            this.isGeneral = isGeneral;
            new ClsReportHeaderData(this);
        }

        private void InitDefaultData()
        {
            parameterDate.Value = DateTime.Now.Date;
        }

        private void InitData()
        {
            this.tbEmployee = (from a in db.tblEmployees
                               where a.empBrnId == Session.CurBranch.brnId
                               select a).ToList();
            this.tbEntSub = (from a in db.tblEntrySubs
                             where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus == 7 || a.entStatus == 8)
                             orderby a.entDate
                             select a).ToList();
        }

        private void ReportEmpSalary_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            GetDateValues();

            if (this.isGeneral)
                EmpTotalSalary();
            else
            {
                Detail.Visible = false;
                DetailReport.Visible = false;
            }
        }

        private void GetDateValues()
        {
            DateTime dt = Convert.ToDateTime(parameterDate.Value).Date;
            this.month = Convert.ToInt16(dt.Month);
            this.year = Convert.ToInt16(dt.Year);
        }

        private void EmpTotalSalary()
        {
            List<ClsRprtEmpSalaryData> rprtEmpSalList = new List<ClsRprtEmpSalaryData>();
            DateTime dtEntSub;
            short monthEntSub, yearEntSub;
            int salRcvd;

            xrLabel3.Text = this.month.ToString();
            xrLabel4.Text = this.year.ToString();

            foreach (var tbEmp in this.tbEmployee)
            {
                ClsRprtEmpSalaryData empSal = new ClsRprtEmpSalaryData();
                salRcvd = 0;

                foreach (var tEntSub in this.tbEntSub)
                {
                    if (tEntSub.entAccNo == tbEmp.empAccNo)
                    {
                        dtEntSub = Convert.ToDateTime(tEntSub.entDate);
                        monthEntSub = Convert.ToInt16(dtEntSub.Month);
                        yearEntSub = Convert.ToInt16(dtEntSub.Year);

                        if (yearEntSub >= this.year && monthEntSub > this.month) break;
                        if (yearEntSub == this.year && monthEntSub == this.month)
                            salRcvd += Convert.ToInt32(tEntSub.entDebit);
                    }
                }

                empSal.empNo = tbEmp.empNo;
                empSal.empName = tbEmp.empName;
                empSal.empSalary = Convert.ToInt32(tbEmp.empSal);
                empSal.empSalRcvd = salRcvd;
                empSal.empSalRmng = Convert.ToInt32(tbEmp.empSal) - salRcvd;
                rprtEmpSalList.Add(empSal);
            }
            bindingSource1.DataSource = rprtEmpSalList;
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
