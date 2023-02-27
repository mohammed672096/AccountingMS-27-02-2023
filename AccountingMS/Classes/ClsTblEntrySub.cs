using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblEntrySub
    {
        accountingEntities db = new accountingEntities();
        ICollection<tblEntrySub> tbEntrySubList;

        private readonly bool isEntType;
        private readonly byte entStatus;

        public ClsTblEntrySub()
        {
            this.isEntType = false;
            InitData();
        }

        public ClsTblEntrySub(EntryType entryType)
        {
            this.isEntType = true;
            this.entStatus = (byte)entryType;
            if (entryType != EntryType.EmpVoucherPhasedAll) InitData(this.entStatus);
            else
            {
                InitDataEntryPhasedEmp();
                this.isEntType = false;
            }
        }

        public ClsTblEntrySub(EntryType entryType1, EntryType entryType2)
        {
            InitData((byte)entryType1, (byte)entryType2);
        }

        public ClsTblEntrySub(EntryPhased entryPhased)
        {
            InitData(entryPhased);
        }
        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntrySubList = (from a in db.tblEntrySubs
                                       where /*a.entBrnId == Session.CurBranch.brnId && */(a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                       orderby a.entDate
                                       select a).ToList();
            else this.tbEntrySubList = (from a in db.tblEntrySubs
                                        where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.entDate
                                        select a).ToList();
        }

        private void InitData(byte entStatus)
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntrySubList = (from a in db.tblEntrySubs
                                       where /*a.entBrnId == Session.CurBranch.brnId &&*/ a.entStatus == entStatus && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                       orderby a.entDate
                                       select a).ToList();
            else this.tbEntrySubList = (from a in db.tblEntrySubs
                                        where a.entBrnId == Session.CurBranch.brnId && a.entStatus == entStatus && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.entDate
                                        select a).ToList();
        }

        private void InitData(byte entStatus1, byte entStatus2)
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntrySubList = (from a in db.tblEntrySubs
                                       where/* a.entBrnId == Session.CurBranch.brnId &&*/ (a.entStatus == entStatus1 || a.entStatus == entStatus2) && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                       orderby a.entDate
                                       select a).ToList();
            else this.tbEntrySubList = (from a in db.tblEntrySubs
                                        where a.entBrnId == Session.CurBranch.brnId && (a.entStatus == entStatus1 || a.entStatus == entStatus2) && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.entDate
                                        select a).ToList();
        }

        private void InitData(EntryPhased entryPhased)
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntrySubList = (from a in db.tblEntrySubs
                                       where /*a.entBrnId == Session.CurBranch.brnId &&*/ (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus == 4 || a.entStatus == 5 || a.entStatus == 6 || a.entStatus == 8)
                                       select a).ToList();
            else this.tbEntrySubList = (from a in db.tblEntrySubs
                                        where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus == 4 || a.entStatus == 5 || a.entStatus == 6 || a.entStatus == 8)
                                        select a).ToList();
        }

        private void InitDataEntryPhasedEmp()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntrySubList = (from a in db.tblEntrySubs
                                       where /*a.entBrnId == Session.CurBranch.brnId &&*/ (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus >= 8 && a.entStatus % 2 == 0)
                                       orderby a.entDate ascending
                                       select a).ToList();
            else this.tbEntrySubList = (from a in db.tblEntrySubs
                                        where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus >= 8 && a.entStatus % 2 == 0)
                                        orderby a.entDate ascending
                                        select a).ToList();

        }
        public IEnumerable<tblEntrySub> GetEntrySubList()
        {
            return this.tbEntrySubList;
        }

        public IEnumerable<tblEntrySub> GetEntrySubDataByEntNo(int entNo)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo).ToList();
        }

        public IEnumerable<tblEntrySub> GetEntrySubDataByEntNoNdEntBox(int entNo, int boxNo)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo && x.entBoxNo == boxNo).ToList();
        }

        public IEnumerable<tblEntrySub> GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(int entNo, int boxNo)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo && x.entBoxNo == boxNo && x.entIsMain == 2).ToList();
        }

        public IEnumerable<tblEntrySub> GetEntrySubDataByEntNoBoxNoNdStatusWhereEntMainIs2(int entNo, int boxNo, byte entStatus)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo && x.entBoxNo == boxNo && x.entStatus == entStatus && x.entIsMain == 2).ToList();
        }

        public IEnumerable<tblEntrySub> GetEntrySubDataByEntNoBoxNoNdEntStatus(int entNo, int boxNo, byte entStatus)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo && x.entBoxNo == boxNo && x.entStatus == entStatus).ToList();
        }

        public IEnumerable<tblEntrySub> GetEmpEntrySubDataByAccNoDtStartNdDtEndWhereEntMainIs2(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntrySubList.Where(x => (x.entStatus != 1 && x.entStatus != 4 && x.entStatus <= 8) &&
                x.entAccNo == accNo && x.entIsMain == 2 && x.entDate >= dtStart && x.entDate <= dtEnd).ToList();
        }

        public IEnumerable<tblEntrySub> GetEntrySubListByCustNoDtStartNdDtEnd(int custId, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntrySubList.Where(x => x.entCusNo == custId && x.entDate >= dtStart && x.entDate <= dtEnd).ToList();
        }

        public tblEntrySub GetEntrySubObjByEntNoNdEntBoxNoWhereEntMainIs1(int entNo, int boxNo)
        {
            return this.tbEntrySubList.Where(x => x.entNo == entNo && x.entBoxNo == boxNo && x.entIsMain == 1).FirstOrDefault();
        }

        public bool IsCustNoFoundByDtStartNdEnd(int custId, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntrySubList.Any(x => x.entCusNo == custId && x.entDate >= dtStart && x.entDate <= dtEnd);
        }

        public int GetEntNoById(int entId)
        {
            return this.tbEntrySubList.Where(x => x.id == entId).Select(x => x.entNo).FirstOrDefault();
        }

        public bool IsAccNoFound(long accNo)
        {
            return this.tbEntrySubList.Any(x => x.entAccNo == accNo);
        }

        public void RefreshData()
        {
            if (!isEntType) InitData();
            else InitData(this.entStatus);
        }

        public void RefreshPhasedData()
        {
            InitData(EntryPhased.Entry);
        }

        public bool DeleteRecordsByEntNo(int entNo)
        {
            IEnumerable<tblEntrySub> tbEntSubList = GetEntrySubDataByEntNo(entNo);
            foreach (var tbEntSub in tbEntSubList) db.tblEntrySubs.Remove(tbEntSub);
            return SaveDB();
        }

        public bool DeleteRecordsByEntNo(int entNo, int boxNo)
        {
            IEnumerable<tblEntrySub> tbEntSubList = GetEntrySubDataByEntNoNdEntBox(entNo, boxNo);
            foreach (var tbEntSub in tbEntSubList) db.tblEntrySubs.Remove(tbEntSub);
            return SaveDB();
        }

        public bool DeleteRecordsByEntNoNdBoxNo(int entNo, int boxNo)
        {
            IEnumerable<tblEntrySub> tbEntSubList = GetEntrySubDataByEntNoNdEntBox(entNo, boxNo);
            foreach (var tbEntSub in tbEntSubList) db.tblEntrySubs.Remove(tbEntSub);
            return SaveDB();
        }

        protected internal bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
