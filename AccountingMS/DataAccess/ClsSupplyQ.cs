using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsSupplyQ : IClsSupply
    {
        accountingEntities db;
        private IQueryable<tblSupplyMain> QueryData
        {
            get
            {
                ValidateFinancialYear();

                db = new accountingEntities();

                return db.tblSupplyMains.AsQueryable().AsNoTracking()
                    .Where(x => x.supBrnId == Session.CurBranch.brnId &&
                    x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd);
            }
        }
        public int StoreEntryNoBox(byte status1, byte status2)
        {
            try
            {
                db = new accountingEntities();

                if (db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate.Value >= Session.CurrentYear.fyDateStart.Date &&
                    (x.supStatus == status1 || x.supStatus == status2)).Any())
                    return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                        x.supDate.Value >= Session.CurrentYear.fyDateStart.Date && (x.supStatus == status1 || x.supStatus == status2))
                        .Max(x => x.supNo) + 1;
                else return 1;
            }
            catch
            {
                return 1;
            }
        }


        public int StoreEntryNoCredit(byte status1, byte status2)
        {
            try
            {
                return Convert.ToInt32(QueryData.AsQueryable().AsNoTracking()
                    .Where(x => x.supIsCash == 2 && (x.supStatus == status1 || x.supStatus == status2))
                    .Max(x =>(int?)x.supNo)) + 1;
            }
            finally { db.Dispose(); }
        }

        public bool IsSupFoundBox(int supNo, long boxNo, byte status1, byte status2)
        {
            try
            {
                return QueryData.AsQueryable().Any(x => x.supAccNo == boxNo && x.supNo == supNo &&
                    (x.supStatus == status1 || x.supStatus == status2));
            }
            finally { db.Dispose(); }
        }

        public bool IsSupFoundCredit(int supNo, byte status1, byte status2)
        {
            try
            {
                return QueryData.AsQueryable().Any(x => x.supNo == supNo && x.supIsCash == 2 &&
                     (x.supStatus == status1 || x.supStatus == status2));
            }
            finally { db.Dispose(); }
        }

        private void ValidateFinancialYear()
        {
            if (Session.CurrentYear.fyDateEnd > DateTime.Now) return;

            using var db = new accountingEntities();

            var item = db.tblFinancialYears.Where(x => x.fyIsNewYear).AsQueryable().AsNoTracking().FirstOrDefault();
            if (item == null) return;

            Session.CurrentYear.fyId = item.fyId;
            Session.CurrentYear.fyDateStart = item.fyDateStart;
            Session.CurrentYear.fyDateEnd = ClsDateConverter.ConvertTime(item.fyDateEnd);
        }
    }
}
