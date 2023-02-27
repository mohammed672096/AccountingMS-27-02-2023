using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsSupply : IClsSupply
    {
        accountingEntities db;
        IList<tblSupplyMain> tbSupplyMainList;

        public ClsSupply() { InitData(); }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbSupplyMainList = (from x in db.tblSupplyMains
                                     where x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd
                                     select x).Take(10).ToList();
        }

        private int StoreEntryNoBox1(long boxNo, byte status1, byte status2)
        {
            return this.tbSupplyMainList.Where(x => x.supAccNo == boxNo && (x.supStatus == status1 || x.supStatus == status2)).
                OrderByDescending(x => x.supNo).Select(x => x.supNo).FirstOrDefault() + 1;
        }

        public int StoreEntryNoBox( byte status1, byte status2)
        {
            try
            {
                db = new accountingEntities();

                if (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate.Value >= Session.CurrentYear.fyDateStart.Date &&
                    (x.supStatus == status1 || x.supStatus == status2)).Any())
                    return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && 
                        x.supDate.Value >= Session.CurrentYear.fyDateStart.Date && (x.supStatus == status1 || x.supStatus == status2))
                        .Max(x => x.supNo) + 1;

                //if (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && /*x.supAccNo == boxNo &&*/ (x.supStatus == status1 || x.supStatus == status2)).Any())
                //    return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && /*x.supAccNo == boxNo &&*/ (x.supStatus == status1 || x.supStatus == status2)).Max(x => x.supNo) + 1;
                else return 1;
            }
            catch
            {
                return 1;
            }
        }

     
        //public int StoreEntryNoCredit(byte status1, byte status2)
        //{
        //    db = new accountingEntities();
        //    try
        //    {
        //        if (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >=Session.CurrentYear.fyDateStart &&
        //            x.supIsCash == 2 && (x.supStatus == status1 || x.supStatus == status2)).Any())
        //            return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
        //                x.supDate >= Session.CurrentYear.fyDateStart && x.supIsCash == 2 &&
        //                (x.supStatus == status1 || x.supStatus == status2)).Max(x => x.supNo) + 1;

        //        //if (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supIsCash == 2 && (x.supStatus == status1 || x.supStatus == status2)).Any())
        //        //    return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supIsCash == 2 && (x.supStatus == status1 || x.supStatus == status2)).Max(x => x.supNo) + 1;
        //        else return 1;
        //    }
        //    catch
        //    {
        //        return 1;
        //    }

        //}

        private bool IsSupFoundBox1(int supNo, long boxNo, byte status1, byte status2)
        {
            return this.tbSupplyMainList.Any(x => x.supAccNo == boxNo && x.supNo == supNo && (x.supStatus == status1 || x.supStatus == status2));
        }

        public bool IsSupFoundBox(int supNo, long boxNo, byte status1, byte status2)
        {
            db = new accountingEntities();
            return db.tblSupplyMains.Any(x => x.supBrnId == Session.CurBranch.brnId && x.supDate > new DateTime(2021, 12, 31) &&
                x.supAccNo == boxNo && x.supNo == supNo && (x.supStatus == status1 || x.supStatus == status2));
            //return db.tblSupplyMains.Any(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supAccNo == boxNo && x.supNo == supNo && (x.supStatus == status1 || x.supStatus == status2));
        }

        private bool IsSupFoundCredit1(int supNo, byte status1, byte status2)
        {
            return this.tbSupplyMainList.Any(x => x.supIsCash == 2 && x.supNo == supNo && (x.supStatus == status1 || x.supStatus == status2));
        }

        public bool IsSupFoundCredit(int supNo, byte status1, byte status2)
        {
            return db.tblSupplyMains.Any(x => x.supBrnId == Session.CurBranch.brnId && x.supDate > new DateTime(2021, 12, 31) && 
                x.supDate <= Session.CurrentYear.fyDateEnd && x.supIsCash == 2 && x.supNo == supNo && (x.supStatus == status1 ||
                x.supStatus == status2));
        }
    }
}
