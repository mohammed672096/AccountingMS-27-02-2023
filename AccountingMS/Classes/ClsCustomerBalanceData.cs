using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    class ClsCustomerBalanceData
    {

        long custAccNo;

        public ClsCustomerBalanceData()
        {
        }

        public ClsCustomerBalanceData(Boolean _noload)
        {

        }
     
        public void CalculateBalance(long accNo)
        {
            this.DebitPeriod = 0;
            this.CreditPeriod = 0;
            this.custAccNo = accNo;
            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => 
            CalaculateAssetPeriodOpnBalance(this.custAccNo, Session.CurrentYear.fyDateStart, Session.CurrentYear.fyDateEnd);
            //taskList.Add(Task.Run(() => 
            CalculateSupplyMainPeriodBalance(this.custAccNo, Session.CurrentYear.fyDateStart, Session.CurrentYear.fyDateEnd);
            //taskList.Add(Task.Run(() =>
            CalculateEntrySubPeriodBalance(this.custAccNo, Session.CurrentYear.fyDateStart, Session.CurrentYear.fyDateEnd);
            //await Task.WhenAll(taskList);
        }
        public double GetCurrentBalance()
        {
            return this.DebitPeriod - this.CreditPeriod;
        }

        public IEnumerable<tblSupplyMain> GetCustomerInvoices(int custId)
        {
            using (accountingEntities db = new accountingEntities())
                return db.tblSupplyMains.AsNoTracking().Where(x => x.supCustSplId == custId && x.supBrnId == Session.CurBranch.brnId &&
                              (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
        }

        public IEnumerable<tblSupplyMain> GetCustomerInvoices(int custId, DateTime dtStart, DateTime dtEnd)
        {
            using (accountingEntities db = new accountingEntities())
                return db.tblSupplyMains.AsNoTracking().Where(x => x.supCustSplId == custId && x.supDate >= dtStart &&
                           x.supDate <= dtEnd && x.supBrnId == Session.CurBranch.brnId &&
                           (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
        }

        public IEnumerable<tblEntrySub> GetCustomerEntries(long accNo)
        {
            using (accountingEntities db = new accountingEntities())
                return db.tblEntrySubs.AsNoTracking().Where(x => x.entAccNo == accNo && x.entBrnId == Session.CurBranch.brnId).ToList();
        }

        public IList GetTblSupplySubListBySupId(int supId)
        {
            using (accountingEntities db = new accountingEntities())
                return db.tblSupplySubs.AsNoTracking().Where(x => x.supNo == supId && x.supBrnId == Session.CurBranch.brnId &&
                    (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
        }

        public void CalculatePeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            this.DebitPeriod = 0; this.CreditPeriod = 0;

            CalaculateAssetPeriodOpnBalance(accNo, dtStart, dtEnd);
            CalculateSupplyMainPeriodBalance(accNo, dtStart.Date, dtEnd);
            CalculateEntrySubPeriodBalance(accNo, dtStart.Date, dtEnd);
            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => CalaculateAssetPeriodOpnBalance(accNo, dtStart, dtEnd)));
            //taskList.Add(Task.Run(() => CalculateSupplyMainPeriodBalance(accNo, dtStart, dtEnd)));
            //taskList.Add(Task.Run(() => CalculateEntrySubPeriodBalance(accNo, dtStart, dtEnd)));
            //await Task.WhenAll(taskList);
        }

        private void CalaculateAssetPeriodOpnBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            this.TblEntrySubPeriodList = new List<tblEntrySub>();
        using (accountingEntities db = new accountingEntities())
        {
            var ass = db.tblAssets.AsNoTracking().Where(x => x.asBrnId == Session.CurBranch.brnId && x.asStatus == 1 &&
                                  x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd &&
                                  x.asDate >= dtStart && x.asDate <= dtEnd &&
                                  x.asAccNo == accNo).ToList();
            if (ass.Count > 0)
            {
                this.DebitPeriod += ass.Sum(x => (x.asDebit ?? 0));
                this.CreditPeriod += ass.Sum(x => (x.asCredit ?? 0));
            }
            this.TblEntrySubPeriodList.AddRange((from a in ass
                                                 select new tblEntrySub()
                                                 {
                                                     entDebit = a.asDebit,
                                                     entCredit = a.asCredit,
                                                     entDate = a.asDate,
                                                     entDesc = "رصيد إفتتاحي"
                                                 }).ToList());
        }

        }
        private void CalculateSupplyMainPeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            this.TblSupplyMainPeriodList = new List<tblSupplyMain>();
            using (accountingEntities db = new accountingEntities())
            {
                var tbSupMains = db.tblSupplyMains.AsNoTracking().Where(x => x.supAccNo == accNo && x.supDate >= dtStart && x.supDate <= dtEnd && x.supBrnId == Session.CurBranch.brnId&&!x.IsDelete);
                if (tbSupMains.Count() <= 0) return;
                this.CreditPeriod += tbSupMains.Where(a => a.supStatus == 11 || a.supStatus == 12).ToList().Sum(a => a.net);
                this.CreditPeriod += tbSupMains.Where(a => a.supStatus == 4 || a.supStatus == 8).ToList().Sum(a => (a.supBankAmount ?? 0) + (a.paidCash ?? 0));
                this.DebitPeriod += tbSupMains.Where(a => a.supStatus == 4 || a.supStatus == 8).ToList().Sum(a => a.net);
                this.TblSupplyMainPeriodList.AddRange(from a in tbSupMains.ToList() select a.ShallowCopy());
            }
        }

        private void CalculateEntrySubPeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            //DateTime date;
            if (this.TblEntrySubPeriodList == null)
                this.TblEntrySubPeriodList = new List<tblEntrySub>();
            using (accountingEntities db = new accountingEntities())
            {
                var entry = db.tblEntrySubs.AsNoTracking().Where(x => x.entAccNo == accNo && x.entDate >= dtStart && x.entDate <= dtEnd && x.entBrnId == Session.CurBranch.brnId).ToList();
                this.DebitPeriod += entry.Where(x => x.entStatus == 2 || x.entStatus == 5 || x.entStatus == 4).ToList().Sum(x => (x.entDebit ?? 0) + (x.entTaxPrice ?? 0));
                this.CreditPeriod +=entry.Where(x => x.entStatus == 3 || x.entStatus == 6 || x.entStatus == 4).ToList().Sum(x => (x.entCredit ?? 0) + (x.entTaxPrice ?? 0));
                this.TblEntrySubPeriodList.AddRange(entry);
            }
        }

        public double DebitPeriod { get; private set; }
        public double CreditPeriod { get; private set; }
        public List<tblSupplyMain> TblSupplyMainPeriodList { get; private set; }
        public List<tblEntrySub> TblEntrySubPeriodList { get; private set; }
    }
}
