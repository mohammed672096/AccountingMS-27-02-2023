using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblSupplySub : IClsTblSupplySub
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblSupplySub> tbSupplySubList;
        Boolean noupload = false;

        private SupplyType supplyType;
        private byte status1, status2;
        private bool isDataInit = true;

        public ClsTblSupplySub() => InitData();
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
        SupplyType _supplyType;
        public ClsTblSupplySub(Boolean _noupload)
        {
            noupload = _noupload;
        }

        public ClsTblSupplySub(SupplyType supplyType, bool isInitData)
        {
            this.isDataInit = false;
            this.tbSupplySubList = null;
            this.supplyType = supplyType;
        }

        private IEnumerable<tblSupplySub> QueryData()
        {
            if (this.tbSupplySubList != null) return this.tbSupplySubList;

            if (Session.CurrentUser.id == 1)
            {
                switch (this.supplyType)
                {
                    case SupplyType.AllSupply:
                        return db.tblSupplySubs.AsQueryable().Where(x =>
                        x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                        x.supStatus <= 12).OrderBy(x => x.supDate);

                    case SupplyType.AllPhase:
                        return db.tblSupplySubs.AsQueryable().Where(x => 
                        x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                        (x.supStatus == 7 || x.supStatus == 10 || x.supStatus == 8 || x.supStatus == 12)).OrderBy(x => x.supDate);


                    case SupplyType.PurchasePhaseAll:
                    case SupplyType.SalesPhaseAll:

                        this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
                        this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

                        return db.tblSupplySubs.AsQueryable().Where(x => 
                        x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
                            .OrderBy(x => x.supDate);

                    case SupplyType.SalesAll:

                        return db.tblSupplySubs.AsQueryable().Where(x =>
                        x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11
                            || x.supStatus == 12)).OrderBy(x => x.supDate);

                    default:
                        this.status1 = (byte)this.supplyType;

                        return db.tblSupplySubs.AsQueryable().Where(x => 
                        x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1).OrderBy(x => x.supDate);
                }
            }
            else
            {
                switch (this.supplyType)
                {
                    case SupplyType.AllSupply:
                        return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId &&
                        x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                        x.supStatus <= 12).OrderBy(x => x.supDate);

                    case SupplyType.AllPhase:
                        return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId &&
                        x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                        (x.supStatus == 7 || x.supStatus == 10 || x.supStatus == 8 || x.supStatus == 12)).OrderBy(x => x.supDate);


                    case SupplyType.PurchasePhaseAll:
                    case SupplyType.SalesPhaseAll:

                        this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
                        this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

                        return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
                            .OrderBy(x => x.supDate);

                    case SupplyType.SalesAll:

                        return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11
                            || x.supStatus == 12)).OrderBy(x => x.supDate);

                    default:
                        this.status1 = (byte)this.supplyType;

                        return db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1).OrderBy(x => x.supDate);
                }
            }
        }

        public ClsTblSupplySub(SupplyType supplyType)
        {
            _supplyType = supplyType;
            switch (supplyType)
            {
                case SupplyType.PurchasePhaseAll:
                    InitData(7, 10);
                    break;
                case SupplyType.SalesPhaseAll:
                    InitData(8, 12);
                    break;
                case SupplyType.SalesAll:
                    InitData((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn);
                    break;
                default:
                    InitData(supplyType);
                    break;
            }
        }

        public ClsTblSupplySub(SupplyType supplyType1, SupplyType supplyType2)
        {
            InitData((byte)supplyType1, (byte)supplyType2);
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where  (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a).ToList();
            }
            else
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where a.supBrnId == Session.CurBranch.brnId && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a).ToList();
            }
         
        }

        private void InitData(SupplyType supplyType)
        {
            if (Session.CurrentUser.id == 1)
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
            else
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where a.supBrnId == Session.CurBranch.brnId && a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
        }

        private void InitData(byte status1, byte status2)
        {
            if (Session.CurrentUser.id == 1)
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
            else
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where a.supBrnId == Session.CurBranch.brnId && (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
        }

        private void InitData1(byte status1, byte status2, byte status3, byte status4)
        {
            if (Session.CurrentUser.id == 1)
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where (a.supStatus == status1 || a.supStatus == status2 || a.supStatus == status3 || a.supStatus == status4) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
            else
            {
                this.tbSupplySubList = (from a in db.tblSupplySubs
                                        where a.supBrnId == Session.CurBranch.brnId && (a.supStatus == status1 || a.supStatus == status2 || a.supStatus == status3 || a.supStatus == status4) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                        orderby a.supDate
                                        select a)/*.Take(10)*/.ToList();
            }
        }

        private void InitData(byte status1, byte status2, byte status3, byte status4)
        {
            if (_supplyType == SupplyType.SalesAll)
            {
             
                if (Session.CurrentUser.id == 1)
                {
                    this.tbSupplySubList = (from a in db.tblSupplySubs
                                            where (a.supStatus == status1 || a.supStatus == status2 || a.supStatus == status3 || a.supStatus == status4) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                            orderby a.supDate
                                            select a).Take(10).ToList();
                }
                else
                {
                    this.tbSupplySubList = (from a in db.tblSupplySubs
                                            where a.supBrnId == Session.CurBranch.brnId && (a.supStatus == status1 || a.supStatus == status2 || a.supStatus == status3 || a.supStatus == status4) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                            orderby a.supDate
                                            select a).Take(10).ToList();
                }
            }
            else InitData1(status1, status2, status3, status4);

        }

        public IEnumerable<tblSupplySub> GetSupplySubList => this.tbSupplySubList;

        public IEnumerable<tblSupplySub> GetSupplySubListBySupId1(int supMainId)
        {
            return (this.tbSupplySubList != null ? this.tbSupplySubList : QueryData()).Where(x => x.supNo == supMainId).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubBListByDtStartEnd(DateTime dtStart, DateTime dtEnd)
        {
            return this.tbSupplySubList.Where(x => x.supStatus <= 12 && x.supDate >= dtStart && x.supDate <= dtEnd).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubListBySupId(int supMainId)
        {
            return /*this.isDataInit ? */GetSupplySubListBySupIdL(supMainId)/* : GetSupplySubListBySupIdQ(supMainId)*/;
        }

        private IEnumerable<tblSupplySub> GetSupplySubListBySupIdL(int supMainId)
        {
            return(Session.CurrentUser.id==1)? db.tblSupplySubs.Where(x => x.supNo == supMainId).ToList() : db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == supMainId).ToList();
        }

        private IEnumerable<tblSupplySub> GetSupplySubListBySupIdQ(int supMainId)
        {
            return QueryData().AsQueryable().Where(x => x.supNo == supMainId).ToList();
        }

        public IList GetSupplySubIListBySupId1(int supMainId)
        {
            return (this.tbSupplySubList != null ? this.tbSupplySubList : QueryData()).Where(x => x.supNo == supMainId).ToList();
            //return this.tbSupplySubList.Where(x => x.supNo == supMainId).ToList();
        }

        public IList GetSupplySubIListBySupId(int supMainId)
        {
            return (Session.CurrentUser.id==1)? db.tblSupplySubs.Where(x => x.supNo == supMainId).ToList()
                : db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == supMainId).ToList();
        }

        public IEnumerable<tblSupplySub> GetSupplySubListByPrdId(int prdId)
        {

            if (!noupload)
                return QueryData().Where(x => x.supPrdId == prdId).OrderBy(x => x.supDate);
            //return this.tbSupplySubList.Where(x => x.supPrdId == prdId).OrderBy(x => x.supDate);
            else return (Session.CurrentUser.id == 1) ? db.tblSupplySubs.Where(x => x.supPrdId == prdId).OrderBy(x => x.supDate) 
                    : db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supPrdId == prdId).OrderBy(x => x.supDate);
        }

        public IEnumerable<tblSupplySub> GetSupplySubByAccNoNdDtStartEnd(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            if (_supplyType == SupplyType.SalesAll)
            {
                byte status1 = (byte)SupplyType.Sales, status2 = (byte)SupplyType.SalesPhase, status3 = (byte)SupplyType.SalesRtrn, status4 = (byte)SupplyType.SalesPhaseRtrn;
                return (Session.CurrentUser.id == 1) ? db.tblSupplySubs.Where(x => x.supAccNo == accNo && x.supDate >= dtStart && x.supDate <= dtEnd &&
                  (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3 || x.supStatus == status4)).OrderBy(x => x.supDate)
                  :db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supAccNo == accNo && x.supDate >= dtStart && x.supDate <= dtEnd &&
                  (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3 || x.supStatus == status4)).OrderBy(x => x.supDate);
            }
            return this.tbSupplySubList.Where(x => x.supAccNo == accNo && x.supDate >= dtStart && x.supDate <= dtEnd);
        }

        public IEnumerable<tblSupplySub> GetSupplySubSalesNdRtrnList()
        {
            return this.tbSupplySubList.Where(x => x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12).ToList();
        }

        public double GetSupplySubProfitById(int supId)
        {
            return this.tbSupplySubList.Where(x => x.id == supId).Select(x => Convert.ToDouble((x.supCredit - x.supTaxPrice) -
                (x.supPrice * Convert.ToDouble(x.supQuanMain)))).FirstOrDefault();
        }

        public double GetPrdMsurPurchaseLastPrice(int prdMsurId)
        {
            return this.tbSupplySubList.Where(x => x.supMsur == prdMsurId && (x.supStatus == 3 || x.supStatus == 7)).OrderByDescending(x => x.id).Select(x => Convert.ToDouble(x.supPrice)).FirstOrDefault();
        }

        public bool IsPrdMsurPurchaseFound(int prdMsurId)
        {
            return this.tbSupplySubList.Any(x => x.supMsur == prdMsurId && (x.supStatus == 3 || x.supStatus == 7));
        }

        public bool IsPrdFound(int prdId)
        {
            return QueryData().Any(x => x.supPrdId == prdId);
            //return this.tbSupplySubList.Any(x => x.supPrdId == prdId);
        }

        public bool IsPrdFoundPhased(int prdId)
        {
            return QueryData().Any(x => x.supPrdId == prdId && (x.supStatus == 7 || x.supStatus == 8 ||
                x.supStatus == 10 || x.supStatus == 12));
            //return this.tbSupplySubList.Any(x => x.supPrdId == prdId);
        }

        public bool CheckPrdMsur(int prdMsurId)
        {
            return this.tbSupplySubList.Any(x => x.supMsur == prdMsurId);
        }

        public double GetSupplyPrdTotalPurchasePrice(int supMainId)
        {
            double totalPrice = 0;
            foreach (var tbSupplySub in GetSupplySubListBySupId(supMainId))
                totalPrice += Convert.ToDouble(tbSupplySub.supPrice) * Convert.ToDouble(tbSupplySub.supQuanMain);

            return Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }

        public void Attach(tblSupplySub tbSupplySub)
        {
            db.tblSupplySubs.Attach(tbSupplySub);
        }

        public bool RemoveRecordsBySupplyMainId(int supId, SupplyType supplyType)
        {
            using (accountingEntities db = new accountingEntities())
            {
                db.tblSupplySubs.AsQueryable().Where(x => x.supNo == supId).ToList().ForEach(x => x.supStatus = (byte)supplyType);
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
            //foreach (var tbSupplySub in GetSupplySubListBySupId(supId)) tbSupplySub.supStatus = (byte)supplyType;
            //return SaveDB();
        }

        public bool DeleteRecordsBySupplyMainId(int supId)
        {
            if (db.tblSupplySubs.Where(x => x.supNo == supId).ToList() is List<tblSupplySub> SupplySub && SupplySub.Count > 0)
                db.tblSupplySubs.RemoveRange(SupplySub);
            //foreach (var tbSupplySub in GetSupplySubListBySupId(supId)) db.tblSupplySubs.Remove(tbSupplySub);
            return SaveDB();
        }

        public bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
