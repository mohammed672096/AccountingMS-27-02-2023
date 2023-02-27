//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace AccountingMS
//{
//    public class ClsTblSupplyMain
//    {

//        Boolean noload = false;

//        private SupplyType supplyType;
//        private byte status1, status2;

//        public ClsTblSupplyMain() => InitData();

//        public ClsTblSupplyMain(byte allYears) => InitDataAllYears();

//        public ClsTblSupplyMain(Boolean _noload)
//        {
//            noload = _noload;
//        }

//        public ClsTblSupplyMain(int cus = 0)
//        {
//            if (cus != 0)
//                InitData(0);
//            else
//                InitData();
//        }

//        public ClsTblSupplyMain(SupplyType supplyType, bool isInitData)
//        {
//            this.supplyType = supplyType;
//        }

//        private IEnumerable<tblSupplyMain> QueryData()
//        {
//            if (Session.tblSupplyMain != null) return Session.tblSupplyMain;
//            using (var db = new accountingEntities())
//            {
//                if (Session.CurrentUser.id == 1)
//                {
//                    switch (this.supplyType)
//                    {
//                        case SupplyType.AllSupply:
//                            return db.tblSupplyMains.Where(x =>  x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd
//                            &&  x.supStatus <= 12).OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();
//                        case SupplyType.PurchasePhaseAll:
//                        case SupplyType.SalesPhaseAll:
//                            this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
//                            this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

//                            return db.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
//                                && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
//                                .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();

//                        default:
//                            this.status1 = (byte)this.supplyType;
//                            return db.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
//                                && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1)
//                                .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();
//                    }
//                }
//                else
//                {
//                    switch (this.supplyType)
//                    {
//                        case SupplyType.AllSupply:
//                            return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
//                                x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
//                                x.supStatus <= 12).OrderBy(x => x.supDate).AsQueryable()/*.AsNoTracking()*/.ToList();
//                        case SupplyType.PurchasePhaseAll:
//                        case SupplyType.SalesPhaseAll:

//                            this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
//                            this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

//                            return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
//                                && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
//                                .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();

//                        default:
//                            this.status1 = (byte)this.supplyType;

//                            return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
//                                && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1)
//                                .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();
//                    }
//                }
//            }
//        }



//        public ClsTblSupplyMain(SupplyType supplyType)
//        {
//            switch (supplyType)
//            {
//                case SupplyType.PurchasePhaseAll:
//                    InitData((byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchasePhaseRtrn);
//                    break;
//                case SupplyType.SalesPhaseAll:
//                    InitData((byte)SupplyType.SalesPhase, (byte)SupplyType.SalesPhaseRtrn);
//                    break;
//                default:
//                    InitData(supplyType);
//                    break;
//            }
//        }

//        public ClsTblSupplyMain(SupplyType supplyType1, SupplyType supplyType2)
//        {
//            InitData((byte)supplyType1, (byte)supplyType2);
//        }

//        private void InitData()
//        {
//            try
//            {
//                using (var db=new accountingEntities())
//                {
//                    if (Session.CurrentUser.id == 1)
//                    {
//                        Session.tblSupplyMain = db.tblSupplyMains?.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
//                         && x.supDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.supDate).ToList();
//                    }
//                    else
//                    {
//                        Session.tblSupplyMain = db.tblSupplyMains?.Where(x => x.supBrnId == Session.CurBranch.brnId
//                        && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.supDate).ToList();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Windows.Forms.MessageBox.Show(ex.Message);
//            }
//        }

//        private void InitDataAllYears()
//        {
//            using (var db = new accountingEntities())
//            {
//                Session.tblSupplyMain = (Session.CurrentUser.id == 1) ?  db.tblSupplyMains.AsNoTracking().Where(x => x.supStatus <= 12).ToList()
//                : db.tblSupplyMains.AsNoTracking().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supStatus <= 12).ToList();
//            }
//        }

//        private void InitData(int cust)
//        {
//            using (var db = new accountingEntities())
//            {
//                if (Session.CurrentUser.id == 1)
//                    Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                             where a.supCustSplId != null && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                             orderby a.supDate
//                                             select a)/*.Take(20)*/.ToList();
//                else Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                              where a.supCustSplId != null && a.supBrnId == Session.CurBranch.brnId && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                              orderby a.supDate
//                                              select a)/*.Take(20)*/.ToList();
//            }
//        }


//        private void InitData(SupplyType supplyType)
//        {
//            using (var db = new accountingEntities())
//            {
//                if (Session.CurrentUser.id == 1)
//                    Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                             where a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                             orderby a.supDate
//                                             select a)/*.Take(10)*/.ToList();
//                else
//                    Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                             where a.supBrnId == Session.CurBranch.brnId && a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                             orderby a.supDate
//                                             select a)/*.Take(10)*/.ToList();
//            }
//        }

//        private void InitData(byte status1, byte status2)
//        {
//            using (var db = new accountingEntities())
//            {
//                if (Session.CurrentUser.id == 1)
//                    Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                             where (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                             orderby a.supDate
//                                             select a)/*.Take(10)*/.ToList();
//                else Session.tblSupplyMain = (from a in db.tblSupplyMains.AsNoTracking()
//                                              where a.supBrnId == Session.CurBranch.brnId && (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
//                                              orderby a.supDate
//                                              select a)/*.Take(10)*/.ToList();
//            }
//        }

//        public IEnumerable<tblSupplyMain> GetSupplyMainList =>  Session.tblSupplyMain;

//        public List<tblSupplyMain> GetSupplyMainListPurchaseNdSale()
//        {
//            if (!noload)
//                return Session.tblSupplyMain.Where(x => x.supStatus != 15 && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18).ToList();
//            else
//                using (var db = new accountingEntities())
//                {
//                    return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.AsNoTracking().Where(x =>
//                    x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus != 15
//                   && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18).ToList()
//                : db.tblSupplyMains.AsNoTracking().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
//                && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus != 15 && x.supStatus != 16
//                && x.supStatus != 17 && x.supStatus != 18).ToList();
//                }
//        }

//        public List<tblSupplyMain> GetSupplyMainListPurchase()
//        {
//            return (from a in  Session.tblSupplyMain
//                    where a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10
//                    select a).ToList();
//        }

//        public List<tblSupplyMain> GetSupplyMainListSale()
//        {
//            return (from a in  Session.tblSupplyMain
//                    where a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12
//                    select a).ToList();
//        }

//        public List<tblSupplyMain> GetSupplyMainListSaleByDtStartEnd(DateTime dtStart, DateTime dtEnd)
//        {

//            if (!noload)
//                return Session.tblSupplyMain.Where(x => x.supDate >= dtStart && x.supDate <= dtEnd &&
//                   (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
//            else using (var db = new accountingEntities())
//                {
//                    return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.AsNoTracking().Where(x => x.supDate >= dtStart && x.supDate <= dtEnd &&
//                (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList()
//                : db.tblSupplyMains.AsNoTracking().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= dtStart && x.supDate <= dtEnd &&
//                 (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
//                }
//        }

//        public List<tblSupplyMain> GetSupplyMainSuppliersList()
//        {
//            if (!noload)
//                return (from a in Session.tblSupplyMain
//                        where a.supIsCash == 2 && (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)
//                        orderby a.supDate ascending
//                        select a).ToList();
//            else
//                using (var db = new accountingEntities())
//                {
//                    return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.AsNoTracking().Where(a => a.supIsCash == 2 &&
//                (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)).OrderBy(a => a.supDate).ToList()
//                : db.tblSupplyMains.AsNoTracking().Where(a => a.supBrnId == Session.CurBranch.brnId && a.supIsCash == 2 &&
//                 (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)).OrderBy(a => a.supDate).ToList();
//                }
//        }

//        public IEnumerable<tblSupplyMain> GetSupplyMainListPhasedPurchase()
//        {

//            return  Session.tblSupplyMain.Where(x => x.supStatus == 7);
//        }

//        public tblSupplyMain GetSupplyObjById(int supId)
//        {
//            return ( Session.tblSupplyMain ?? QueryData()).Where(x => x.id == supId).FirstOrDefault();
//        }

//        public int GetSupplyNoById(int supId)
//        {
//            return  Session.tblSupplyMain.Where(x => x.id == supId).Select(x => x.supNo).FirstOrDefault();
//        }

//        public bool IsAccNoFound(long accNo)
//        {
//            return  Session.tblSupplyMain.Any(x => x.supAccNo == accNo);
//        }

//        public bool IsSupNoFound(long? accNo, byte status1, byte status2, int supNo)
//        {
//            return  Session.tblSupplyMain.Any(x => (accNo != 0 ? x.supAccNo == accNo : x.supIsCash == 2) 
//            && (x.supStatus == status1 || x.supStatus == status2) && x.supNo == supNo);
//        }

//        protected internal int GetSupplyCount(byte status)
//        {
//            if ( Session.tblSupplyMain == null) return 0;
//            return  Session.tblSupplyMain.Where(x => x.supStatus == status).Count();
//        }

//        protected internal int GetSupplyCount(byte status1, byte status2)
//        {
//            return  Session.tblSupplyMain.Where(x => x.supStatus == status1 || x.supStatus == status2).Count();
//        }

//        public bool Remove(tblSupplyMain tbSupplyMain, SupplyType supplyType)
//        {
//            using (var db = new accountingEntities())
//            {
//                db.tblSupplyMains.FirstOrDefault(x=>x.id==tbSupplyMain.id).supStatus= (byte)supplyType;
//                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
//                {
//                    //Session.tblSupplyMain.FirstOrDefault(x => x.id == tbSupplyMain.id).supStatus= (byte)supplyType;

//                    return true;
//                }

//                return false;
//            }
//        }

//        public bool Delete(tblSupplyMain tbSupplyMain)
//        {
//            using (var db = new accountingEntities())
//            {
//                db.tblSupplyMains.Remove(db.tblSupplyMains.FirstOrDefault(x=>x.id== tbSupplyMain.id));
//                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
//                {
//                    var sup = Session.tblSupplyMain.FirstOrDefault(x => x.id == tbSupplyMain.id);
//                    if(sup!=null)
//                    Session.tblSupplyMain.Remove(sup);
//                    return true;
//                }
//                return false;
//            }
//        }

//        protected internal void DeleteVoid(tblSupplyMain tbSupplyMain)
//        {
//            using (var db = new accountingEntities())
//            {
//                db.tblSupplyMains.Remove(db.tblSupplyMains.FirstOrDefault(x => x.id == tbSupplyMain.id));
//                db.SaveChanges();
//            }
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblSupplyMain
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        Boolean noload = false;

        private SupplyType supplyType;
        private byte status1, status2;

        public ClsTblSupplyMain() => InitData();

        public ClsTblSupplyMain(byte allYears) => InitDataAllYears();

        public ClsTblSupplyMain(Boolean _noload)
        {
            noload = _noload;
        }

        public ClsTblSupplyMain(int cus = 0)
        {
            if (cus != 0)
                InitData(0);
            else
                InitData();
        }

        public ClsTblSupplyMain(SupplyType supplyType, bool isInitData)
        {
            this.supplyType = supplyType;
            this.tbSupplyMainList = null;
        }

        private IEnumerable<tblSupplyMain> QueryData()
        {
            if (this.tbSupplyMainList != null) return this.tbSupplyMainList;
            if (Session.CurrentUser.id == 1)
            {
                switch (this.supplyType)
                {
                    case SupplyType.AllSupply:
                        return db.tblSupplyMains.Where(x =>
                            x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                            x.supStatus <= 12).OrderBy(x => x.supDate).AsQueryable()/*.AsNoTracking()*/.ToList();
                    case SupplyType.PurchasePhaseAll:
                    case SupplyType.SalesPhaseAll:

                        this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
                        this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

                        return db.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
                            .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();

                    default:
                        this.status1 = (byte)this.supplyType;

                        return db.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1)
                            .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();
                }
            }
            else
            {
                switch (this.supplyType)
                {
                    case SupplyType.AllSupply:
                        return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                            x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd &&
                            x.supStatus <= 12).OrderBy(x => x.supDate).AsQueryable()/*.AsNoTracking()*/.ToList();
                    case SupplyType.PurchasePhaseAll:
                    case SupplyType.SalesPhaseAll:

                        this.status1 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)7 : (byte)8;
                        this.status2 = this.supplyType == SupplyType.PurchasePhaseAll ? (byte)10 : (byte)12;

                        return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == this.status1 || x.supStatus == this.status2))
                            .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();

                    default:
                        this.status1 = (byte)this.supplyType;

                        return db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                            && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus == this.status1)
                            .OrderBy(x => x.supDate).AsQueryable().AsNoTracking().ToList();
                }
            }
        }



        public ClsTblSupplyMain(SupplyType supplyType)
        {
            switch (supplyType)
            {
                case SupplyType.PurchasePhaseAll:
                    InitData((byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchasePhaseRtrn);
                    break;
                case SupplyType.SalesPhaseAll:
                    InitData((byte)SupplyType.SalesPhase, (byte)SupplyType.SalesPhaseRtrn);
                    break;
                default:
                    InitData(supplyType);
                    break;
            }
        }

        public ClsTblSupplyMain(SupplyType supplyType1, SupplyType supplyType2)
        {
            InitData((byte)supplyType1, (byte)supplyType2);
        }

        private void InitData()
        {
            try
            {
                if (Session.CurrentUser.id == 1)
                {
                    this.tbSupplyMainList = db.tblSupplyMains?.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
                    && x.supDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.supDate).ToList();
                }
                else
                {
                    this.tbSupplyMainList = db.tblSupplyMains?.Where(x => x.supBrnId == Session.CurBranch.brnId
                    && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.supDate).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void InitDataAllYears()
        {
            this.tbSupplyMainList = (Session.CurrentUser.id == 1) ?
                db.tblSupplyMains.Where(x => x.supStatus <= 12).ToList()
                : db.tblSupplyMains
                .Where(x => x.supBrnId == Session.CurBranch.brnId && x.supStatus <= 12).ToList();
        }

        private void InitData(int cust)
        {
            if (Session.CurrentUser.id == 1)
                this.tbSupplyMainList = (from a in db.tblSupplyMains
                                         where a.supCustSplId != null && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                         orderby a.supDate
                                         select a)/*.Take(20)*/.ToList();
            else this.tbSupplyMainList = (from a in db.tblSupplyMains
                                          where a.supCustSplId != null && a.supBrnId == Session.CurBranch.brnId && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                          orderby a.supDate
                                          select a)/*.Take(20)*/.ToList();
        }


        private void InitData(SupplyType supplyType)
        {
            if (Session.CurrentUser.id == 1)
                this.tbSupplyMainList = (from a in db.tblSupplyMains
                                         where a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                         orderby a.supDate
                                         select a)/*.Take(10)*/.ToList();
            else
                this.tbSupplyMainList = (from a in db.tblSupplyMains
                                         where a.supBrnId == Session.CurBranch.brnId && a.supStatus == (byte)supplyType && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                         orderby a.supDate
                                         select a)/*.Take(10)*/.ToList();

        }

        private void InitData(byte status1, byte status2)
        {
            if (Session.CurrentUser.id == 1)
                this.tbSupplyMainList = (from a in db.tblSupplyMains
                                         where (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                         orderby a.supDate
                                         select a)/*.Take(10)*/.ToList();
            else this.tbSupplyMainList = (from a in db.tblSupplyMains
                                          where a.supBrnId == Session.CurBranch.brnId && (a.supStatus == status1 || a.supStatus == status2) && (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd)
                                          orderby a.supDate
                                          select a)/*.Take(10)*/.ToList();
        }

        public IEnumerable<tblSupplyMain> GetSupplyMainList => this.tbSupplyMainList;

        public List<tblSupplyMain> GetSupplyMainListPurchaseNdSale()
        {
            if (!noload)

                return this.tbSupplyMainList.Where(x => x.supStatus != 15 && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18).ToList();
            else
                return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.Where(x =>
                     x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus != 15
                    && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18).ToList()
                : db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= Session.CurrentYear.fyDateStart
                && x.supDate <= Session.CurrentYear.fyDateEnd && x.supStatus != 15 && x.supStatus != 16
                && x.supStatus != 17 && x.supStatus != 18).ToList();
        }

        public List<tblSupplyMain> GetSupplyMainListPurchase()
        {
            return (from a in this.tbSupplyMainList
                    where a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10
                    select a).ToList();
        }

        public List<tblSupplyMain> GetSupplyMainListSale()
        {
            return (from a in this.tbSupplyMainList
                    where a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12
                    select a).ToList();
        }

        public List<tblSupplyMain> GetSupplyMainListSaleByDtStartEnd(DateTime dtStart, DateTime dtEnd)
        {

            if (!noload)
                return this.tbSupplyMainList.Where(x => x.supDate >= dtStart && x.supDate <= dtEnd &&
                    (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();
            else
                return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.Where(x => x.supDate >= dtStart && x.supDate <= dtEnd &&
                (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList()
                : db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= dtStart && x.supDate <= dtEnd &&
                 (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 11 || x.supStatus == 12)).ToList();

        }

        public List<tblSupplyMain> GetSupplyMainSuppliersList()
        {
            if (!noload)
                return (from a in this.tbSupplyMainList
                        where a.supIsCash == 2 && (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)
                        orderby a.supDate ascending
                        select a).ToList();
            else
                return (Session.CurrentUser.id == 1) ? db.tblSupplyMains.Where(a => a.supIsCash == 2 &&
                (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)).OrderBy(a => a.supDate).ToList()
                : db.tblSupplyMains.Where(a => a.supBrnId == Session.CurBranch.brnId && a.supIsCash == 2 &&
                 (a.supStatus == 3 || a.supStatus == 7 || a.supStatus == 9 || a.supStatus == 10)).OrderBy(a => a.supDate).ToList();
        }

        public IEnumerable<tblSupplyMain> GetSupplyMainListPhasedPurchase()
        {

            return this.tbSupplyMainList.Where(x => x.supStatus == 7);
        }

        public tblSupplyMain GetSupplyObjById(int supId)
        {
            return db.tblSupplyMains.FirstOrDefault(x => x.id == supId);
        }

        public int GetSupplyNoById(int supId)
        {
            return this.tbSupplyMainList.Where(x => x.id == supId).Select(x => x.supNo).FirstOrDefault();
        }

        public bool IsAccNoFound(long accNo)
        {
            return this.tbSupplyMainList.Any(x => x.supAccNo == accNo);
        }

        public bool IsSupNoFound(long? accNo, byte status1, byte status2, int supNo)
        {
            return this.tbSupplyMainList.Any(x => (accNo != 0 ? x.supAccNo == accNo : x.supIsCash == 2)
            && (x.supStatus == status1 || x.supStatus == status2) && x.supNo == supNo);
        }

        protected internal int GetSupplyCount(byte status)
        {
            if (this.tbSupplyMainList == null) return 0;
            return this.tbSupplyMainList.Where(x => x.supStatus == status).Count();
        }

        protected internal int GetSupplyCount(byte status1, byte status2)
        {
            return this.tbSupplyMainList.Where(x => x.supStatus == status1 || x.supStatus == status2).Count();
        }

        public bool Remove(tblSupplyMain tbSupplyMain, SupplyType supplyType)
        {
            db.tblSupplyMains.Attach(tbSupplyMain);
            tbSupplyMain.supStatus = (byte)supplyType;
            tbSupplyMain.IsDelete = true;
            return SaveDB();
        }

        public bool Delete(tblSupplyMain tbSupplyMain)
        {
            db.tblSupplyMains.Remove(tbSupplyMain);
            return SaveDB();
        }

        protected internal void DeleteVoid(tblSupplyMain tbSupplyMain)
        {
            db.tblSupplyMains.Remove(tbSupplyMain);
        }

        protected internal bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}

