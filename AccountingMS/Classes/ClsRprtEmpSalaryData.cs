using System;

namespace AccountingMS
{
    class ClsRprtEmpSalaryData
    {
        public int empNo { set; get; }
        public string empName { set; get; }
        public int empSalary { set; get; }
        public int empSalRcvd { set; get; }
        public int empSalRmng { set; get; }
        public DateTime empEntDate { set; get; }
        public string empEntDesc { set; get; }
    }
}
