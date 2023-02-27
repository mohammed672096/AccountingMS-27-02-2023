using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{

    public class ClsTblSupplySubQ : IClsTblSupplySub
    {
        accountingEntities db;

        private SupplyType supplyType;
        private bool isSupplyType;
        private byte status1, status2;

        public ClsTblSupplySubQ()
        {
            db = new accountingEntities();

            this.isSupplyType = true;
            this.supplyType = SupplyType.Default;
        }

        public ClsTblSupplySubQ(SupplyType supplyType)
        {
            db = new accountingEntities();

            this.isSupplyType = true;
            this.supplyType = supplyType;
        }

        public ClsTblSupplySubQ(SupplyType supplyType1, SupplyType supplyType2)
        {
            db = new accountingEntities();

            this.isSupplyType = false;
            this.status1 = (byte)supplyType1;
            this.status2 = (byte)supplyType2;
        }

        private IEnumerable<tblSupplySub> QueryData
        {
            get
            {
                if (isSupplyType) return this.supplyType switch
                {
                    SupplyType.PurchasePhaseAll => QueryDataQ(7, 10),
                    SupplyType.SalesPhaseAll => QueryDataQ(8, 12),
                    SupplyType.SalesAll => QueryDataQ(4, 8, 11, 12),
                    SupplyType.AllPhase => QueryDataQ(7, 8, 10, 12),
                    SupplyType.AllSupply => QueryDataAllSupply(),
                    SupplyType.Default => QueryDataD(),
                    _ => QueryDataQ()
                };
                else return QueryDataQ(this.status1, this.status2);
            }
        }

        private IEnumerable<tblSupplySub> QueryDataD()
        {
            return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                    && x.supDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.supDate);
        }

        private IEnumerable<tblSupplySub> QueryDataQ()
        {
            return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                    && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1).OrderBy(x => x.supDate);
        }

        private IEnumerable<tblSupplySub> QueryDataQ(byte status1, byte status2)
        {
            return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                    (x.supStatus == status1 || x.supStatus == status2)).OrderBy(x => x.supDate);
        }

        private IEnumerable<tblSupplySub> QueryDataQ(byte status1, byte status2, byte status3, byte status4)
        {
            return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                    (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3 || x.supStatus == status4)).OrderBy(x => x.supDate);
        }

        private IEnumerable<tblSupplySub> QueryDataAllSupply()
        {
            return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                    && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus <= 12).OrderBy(x => x.supDate);
        }

        public IEnumerable<tblSupplySub> GetSupplySubList => QueryData.ToList();

        public IEnumerable<tblSupplySub> GetSupplySubListBySupId1(int supMainId)
        {
            return QueryData.AsQueryable().Where(x => x.supNo == supMainId).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubBListByDtStartEnd(DateTime dtStart, DateTime dtEnd)
        {
            return QueryData.AsQueryable().Where(x => x.supStatus <= 12 && x.supDate >= dtStart && x.supDate <= dtEnd).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubListBySupId(int supMainId)
        {
            return QueryData.AsQueryable().Where(x => x.supNo == supMainId).ToList();
        }

        public IList GetSupplySubIListBySupId(int supMainId)
        {
            return QueryData.AsQueryable().Where(x => x.supNo == supMainId).ToList();
        }

        public IList GetSupplySubIListBySupId1(int supMainId)
        {
            return QueryData.AsQueryable().Where(x => x.supNo == supMainId).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubListByPrdId(int prdId)
        {
            return QueryData.AsQueryable().Where(x => x.supPrdId == prdId).OrderBy(x => x.supDate).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubByAccNoNdDtStartEnd(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            return QueryData.AsQueryable().Where(x => x.supAccNo == accNo && x.supDate >= dtStart && x.supDate <= dtEnd);
        }

        public IEnumerable<tblSupplySub> GetSupplySubSalesNdRtrnList()
        {
            return QueryData.AsQueryable().Where(x => x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12).ToList();
        }

        public double GetSupplySubProfitById(int supId)
        {
            var tbSupplySub = QueryData.AsQueryable().Where(x => x.id == supId).FirstOrDefault();
            if (tbSupplySub == null) return 0;

            return (Convert.ToDouble(tbSupplySub.supCredit) - Convert.ToDouble(tbSupplySub.supTaxPrice)) -
                (Convert.ToDouble(tbSupplySub.supPrice) * Convert.ToDouble(tbSupplySub.supQuanMain));
        }

        public double GetPrdMsurPurchaseLastPrice(int prdMsurId)
        {
            return QueryData.AsQueryable().Where(x => x.supMsur == prdMsurId && (x.supStatus == 3 || x.supStatus == 7))
                .OrderByDescending(x => x.id).Select(x => x.supPrice ?? 0).FirstOrDefault();
        }

        public bool IsPrdMsurPurchaseFound(int prdMsurId)
        {
            return QueryData.AsQueryable().Any(x => x.supMsur == prdMsurId && (x.supStatus == 3 || x.supStatus == 7));
        }

        public bool IsPrdFound(int prdId)
        {
            return QueryData.AsQueryable().Any(x => x.supPrdId == prdId);
        }

        public bool IsPrdFoundPhased(int prdId)
        {
            return QueryData.AsQueryable().Any(x => x.supPrdId == prdId && (x.supStatus == 7 || x.supStatus == 8 ||
                x.supStatus == 10 || x.supStatus == 12));
        }

        public bool CheckPrdMsur(int prdMsurId)
        {
            return QueryData.AsQueryable().Any(x => x.supMsur == prdMsurId);
        }

        public double GetSupplyPrdTotalPurchasePrice(int supMainId)
        {
            double totalPrice = 0;
            foreach (var tbSupplySub in GetSupplySubListBySupId(supMainId))
                totalPrice += Convert.ToDouble(tbSupplySub.supPrice) * Convert.ToDouble(tbSupplySub.supQuanMain);

            return Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }

        public int GetSupplyNumber(string supNo)
        {
            int num = 0;
            if (int.TryParse(supNo, out num))
                return GetSupplyNumber(num);
            return default;
        }

        public int GetSupplyNumber(int supNo)
        {

            var supplyMain = db.tblSupplyMains.FirstOrDefault(x => x.id == supNo);
            if (supplyMain == null) return default;
            return supplyMain.supNo;
        }

        public bool RemoveRecordsBySupplyMainId(int supId, SupplyType supplyType)
        {
            foreach (var tbSupplySub in GetSupplySubListBySupId(supId)) tbSupplySub.supStatus = (byte)supplyType;
            return SaveDB();
        }

        public bool DeleteRecordsBySupplyMainId(int supId)
        {
            foreach (var tbSupplySub in GetSupplySubListBySupId(supId)) db.tblSupplySubs.Remove(tbSupplySub);
            return SaveDB();
        }

        public void Attach(tblSupplySub tbSupplySub)
        {
            db.tblSupplySubs.Attach(tbSupplySub);
        }

        public bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
