using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblEmployee
    {
        accountingEntities db = new accountingEntities();
        ICollection<tblEmployee> tbEmployeeList;

        public ClsTblEmployee()
        {
            InitData();
        }

        public ClsTblEmployee(bool initData)
        {
            if (initData) InitData();
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEmployeeList = db.tblEmployees.AsQueryable().ToList();
            else this.tbEmployeeList = (from a in db.tblEmployees.AsQueryable()
                                        where a.empBrnId == Session.CurBranch.brnId
                                        select a).ToList();
        }

        public IEnumerable<tblEmployee> GetEmployeeList => this.tbEmployeeList;

        public void RefreshData() => InitData();

        public IEnumerable<tblEmployee> GetEemployeeListByCurId(byte curId)
        {
            return this.tbEmployeeList.Where(x => x.empCurrency == curId).ToList();
        }

        public tblEmployee GetEmployeeObjById(int empId)
        {
            return this.tbEmployeeList.Where(x => x.id == empId).FirstOrDefault();
        }

        public long GetEmployeeAccNoById(int empId)
        {
            return this.tbEmployeeList.Where(x => x.id == empId).Select(x => x.empAccNo).FirstOrDefault();
        }

        public int GetEmployeeIdByAccNo(long accNo)
        {
            return this.tbEmployeeList.FirstOrDefault(x => x.empAccNo == accNo).id;
        }

        public int GetNewEmpNo()
        {
            int empNo = this.tbEmployeeList.OrderByDescending(x => x.empNo).Select(x => x.empNo).FirstOrDefault();
            return ++empNo;
        }

        public void Add(tblEmployee tbEmployee)
        {
            db.tblEmployees.Add(tbEmployee);
        }

        public void Attach(tblEmployee tbEmployee)
        {
            db.tblEmployees.Attach(tbEmployee);
        }

        public bool Delete(tblEmployee tbEmployee)
        {
            db.tblEmployees.Remove(tbEmployee);
            return SaveDB();
        }

        public bool Save() => SaveDB();

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
