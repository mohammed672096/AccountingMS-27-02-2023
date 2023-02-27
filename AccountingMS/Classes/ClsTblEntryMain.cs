using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblEntryMain
    {
        accountingEntities db = new accountingEntities();
        ICollection<tblEntryMain> tbEntMainList;

        private readonly bool isEntType = false;
        private byte entStatus1, entStatus2;

        public ClsTblEntryMain()
        {
            InitData();
        }

        public ClsTblEntryMain(EntryType entryType)
        {
            this.isEntType = true;
            SetEntStatus(entryType);

            if (entryType != EntryType.EmpVoucherPhasedAll) InitData(this.entStatus1);
            else
            {
                InitDataEntryPhasedEmp();
                this.isEntType = false;
            }
        }

        public ClsTblEntryMain(EntryType entryType1, EntryType entryType2)
        {
            InitData((byte)entryType1, (byte)entryType2);
        }

        public ClsTblEntryMain(EntryPhased entryPhased)
        {
            if (entryPhased == EntryPhased.Entry) InitDataEntryPhased();
            else InitDataEntryPhasedEmp();
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntMainList = (from a in db.tblEntryMains
                                      where /*a.entBrnId == Session.CurBranch.brnId &&*/ (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                      orderby a.entDate
                                      select a).ToList();
            else this.tbEntMainList = (from a in db.tblEntryMains
                                       where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                       orderby a.entDate
                                       select a).ToList();
        }

        private void InitData(byte entStatus)
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntMainList = (from a in db.tblEntryMains
                                      where /*a.entBrnId == Session.CurBranch.brnId &&*/ (a.entStatus == this.entStatus1 || a.entStatus == this.entStatus2) && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                      orderby a.entDate
                                      select a).ToList();
            else this.tbEntMainList = (from a in db.tblEntryMains
                                       where a.entBrnId == Session.CurBranch.brnId && (a.entStatus == this.entStatus1 || a.entStatus == this.entStatus2) && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd)
                                       orderby a.entDate
                                       select a).ToList();
        }

        private void InitData(byte status1, byte status2)
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntMainList = db.tblEntryMains.Where(x => /*x.entBrnId == Session.CurBranch.brnId &&*/ x.entDate >= Session.CurrentYear.fyDateStart
                && x.entDate <= Session.CurrentYear.fyDateEnd && (x.entStatus == status1 || x.entStatus == status2)).ToList();
            else this.tbEntMainList = db.tblEntryMains.Where(x => x.entBrnId == Session.CurBranch.brnId && x.entDate >= Session.CurrentYear.fyDateStart
                     && x.entDate <= Session.CurrentYear.fyDateEnd && (x.entStatus == status1 || x.entStatus == status2)).ToList();

        }

        private void InitDataEntryPhased()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntMainList = (from a in db.tblEntryMains
                                      where /*a.entBrnId == Session.CurBranch.brnId && */(a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus == 4 || a.entStatus == 5 || a.entStatus == 6)
                                      orderby a.entDate ascending
                                      select a).ToList();
            else this.tbEntMainList = (from a in db.tblEntryMains
                                       where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus == 4 || a.entStatus == 5 || a.entStatus == 6)
                                       orderby a.entDate ascending
                                       select a).ToList();
        }

        private void InitDataEntryPhasedEmp()
        {
            if (Session.CurrentUser.id == 1)
                this.tbEntMainList = (from a in db.tblEntryMains
                                      where /*a.entBrnId == Session.CurBranch.brnId && */(a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus >= 8 && a.entStatus % 2 == 0)
                                      orderby a.entDate ascending
                                      select a).ToList();
            else this.tbEntMainList = (from a in db.tblEntryMains
                                       where a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && (a.entStatus >= 8 && a.entStatus % 2 == 0)
                                       orderby a.entDate ascending
                                       select a).ToList();
        }

        public IEnumerable<tblEntryMain> GetEntMainList()
        {
            if (!isEntType) return this.tbEntMainList.OrderByDescending(x => x.entDate).ToList();
            else return this.tbEntMainList.Where(x => x.entStatus == this.entStatus1).OrderByDescending(x => x.entDate).ToList();
        }

        protected internal IEnumerable<tblEntryMain> GetEntMainVoucherNdRecieptList()
        {
            return this.tbEntMainList.Where(x => x.entStatus != 1 && x.entStatus != 4).ToList();
        }

        public void RefreshData()
        {
            if (!isEntType) InitData();
            else InitData(this.entStatus1);
        }

        public void RefreshPhasedData()
        {
            InitDataEntryPhased();
        }

        public IEnumerable<tblEntryMain> GetEntryMainListByBoxNoDtStartNdDtEnd(int boxNo, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntMainList.Where(x => x.entBoxNo == boxNo && x.entDate >= dtStart && x.entDate <= dtEnd).ToList();
        }

        public IEnumerable<tblEntryMain> GetEntryMainListByBoxAccNoDtStartNdDtEnd(long boxAccNo, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntMainList.Where(x => x.entBoxNo == boxAccNo && x.entDate >= dtStart && x.entDate <= dtEnd).ToList();
        }

        public bool IsEntryMainFound(int boxNo, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntMainList.Any(x => x.entBoxNo == boxNo && x.entDate >= dtStart && x.entDate <= dtEnd);
        }

        public bool IsEntryMainFound(long boxAccNo, DateTime dtStart, DateTime dtEnd)
        {
            return this.tbEntMainList.Any(x => x.entBoxNo == boxAccNo && x.entDate >= dtStart && x.entDate <= dtEnd);
        }

        public tblEntryMain GetEntryMainObjById(int entId)
        {
            return this.tbEntMainList.FirstOrDefault(x => x.id == entId);
        }

        public int GetNewEntNo()
        {
            return (this.tbEntMainList?.Max(x => x?.entNo)??0) + 1;
        }

        public int GetNewEntNoByBoxNo(int boxNo)
        {
            return this.tbEntMainList.OrderByDescending(x => x.id).Select(x => x.entNo).FirstOrDefault() + 1;
        }
        //public int GetNewEntNoByBoxNo(int boxNo)
        //{
        //    return this.tbEntMainList.Where(x => x.entBoxNo == boxNo).OrderByDescending(x => x.entNo).Select(x => x.entNo).FirstOrDefault() + 1;
        //}

        public int GetEntNoById(int entId)
        {
            return this.tbEntMainList.Where(x => x.id == entId).Select(x => x.entNo).FirstOrDefault();
        }

        public tblEntryMain GetEntMainObjByEntNo(int entNo)
        {
            return this.tbEntMainList.Where(x => x.entNo == entNo).FirstOrDefault();
        }

        public tblEntryMain GetEntMainObjByEntNoNdStatus(int entNo, byte entStatus)
        {
            return this.tbEntMainList.Where(x => x.entNo == entNo && x.entStatus == entStatus).FirstOrDefault();
        }

        public bool IsBoxNoFound(int boxNo)
        {
            return this.tbEntMainList.Any(x => x.entBoxNo == boxNo);
        }

        public bool IsEntryNoFound(int entNo)
        {
            return QueryData().Any(x => x.entNo == entNo);
        }

        private IEnumerable<tblEntryMain> QueryData()
        {
            return db.tblEntryMains.Where(x => x.entBrnId == Session.CurBranch.brnId && x.entDate >= Session.CurrentYear.fyDateStart
                && x.entDate <= Session.CurrentYear.fyDateEnd && (x.entStatus == this.entStatus1 || x.entStatus == this.entStatus2))
                .AsQueryable().AsNoTracking().ToList();
        }

        public bool IsEntryNoFound(int entNo, int boxNo)
        {
            return QueryData().Any(x => x.entNo == entNo && x.entBoxNo == boxNo);
            //return this.tbEntMainList.Any(x => x.entNo == entNo && x.entBoxNo == boxNo);
        }

        public bool Delete(tblEntryMain tbEntMain)
        {
            db.tblEntryMains.Remove(tbEntMain);
            return SaveDB();
        }

        private void SetEntStatus(EntryType entryType)
        {
            switch (entryType)
            {
                case EntryType.DailyEntry:
                    this.entStatus1 = 1;
                    this.entStatus2 = 4;
                    break;
                case EntryType.EntryVoucher:
                    this.entStatus1 = 2;
                    this.entStatus2 = 5;
                    break;
                case EntryType.EntryReceipt:
                    this.entStatus1 = 3;
                    this.entStatus2 = 6;
                    break;
                case EntryType.EmpVoucher:
                    this.entStatus1 = 7;
                    this.entStatus2 = 8;
                    break;
                case EntryType.EmpVoucherTip:
                    this.entStatus1 = (byte)EntryType.EmpVoucherTip;
                    this.entStatus2 = (byte)EntryType.EmpVoucherTipPhased;
                    break;
                case EntryType.EmpVoucherOvrTm:
                    this.entStatus1 = (byte)EntryType.EmpVoucherOvrTm;
                    this.entStatus2 = (byte)EntryType.EmpVoucherOvrTmPhased;
                    break;
            }
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
