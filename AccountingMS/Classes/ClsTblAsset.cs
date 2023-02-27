using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblAsset
    {
        accountingEntities db;
        IEnumerable<tblAsset> tbAssetList;
        Boolean noload = false;

        public ClsTblAsset(byte isInitData = 1)
        {
            this.tbAssetList = null;
            db = new accountingEntities();
            if (Convert.ToBoolean(isInitData)) InitData();
        }

        public ClsTblAsset(Boolean _noload)
        {
            db = new accountingEntities();
            noload = _noload;
        }

        private void InitData()
        {
            this.tbAssetList = (from a in db.tblAssets
                                where a.asBrnId == Session.CurBranch.brnId && (a.asDate >= Session.CurrentYear.fyDateStart && a.asDate <= Session.CurrentYear.fyDateEnd)
                                select a).ToList();
        }

        //private IEnumerable<tblAsset> QueryData => this.tbAssetList != null ? this.tbAssetList :
        //    db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd).AsQueryable().ToList();

        private IQueryable<tblAsset> QueryData => db.tblAssets.AsQueryable().Where(x => x.asBrnId == Session.CurBranch.brnId
            && x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd);

        public IEnumerable<tblAsset> GetAssetList => this.tbAssetList;

        public IEnumerable<tblAsset> GetAssetListByAccNo(long accNo)
        {
            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asBrnId == Session.CurBranch.brnId && x.asAccNo == accNo).OrderBy(x => x.asDate);
            else
                return db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asAccNo == accNo).OrderBy(x => x.asDate);
        }

        public IEnumerable<tblAsset> GetAssetListByAccNo(long accNo, DateTime date1, DateTime date2)
        {

            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asAccNo == accNo).OrderBy(x => x.asDate);
            else
                return db.tblAssets.Where(x => x.asAccNo == accNo && x.asDate >= date1 && x.asDate <= date2).OrderBy(x => x.asDate);
        }

        public IEnumerable<tblAsset> GetAssetListByEntIdAndStatus(int entId, byte status)
        {
            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asEntId == entId && x.asStatus == status);
            else return db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == entId && x.asStatus == status);

        }

        public IEnumerable<tblAsset> GetAssetListByEntIdAndStatus2(int entId, byte status)
        {
            return db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == entId && x.asStatus == status)
                .AsQueryable().AsNoTracking();
        }

        public IEnumerable<tblAsset> AssetOpeningList => (!noload ?
            (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asBrnId == Session.CurBranch.brnId && x.asStatus == 1).ToList() :
            db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asStatus == 1 &&
            x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd).ToList());

        public IEnumerable<tblAsset> GetAssetOpeningBalanceByAccNo1(long accNo)
        {
            return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asStatus == 1 && x.asAccNo == accNo);
        }

        public IEnumerable<tblAsset> GetAssetOpeningBalanceByAccNo(long accNo)
        {
            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asBrnId == Session.CurBranch.brnId && x.asStatus == 1 &&
                    x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd &&
                    x.asAccNo == accNo);
            else
                return db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asStatus == 1 &&
                    x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd &&
                    x.asAccNo == accNo);
            //return this.tbAssetList.Where(x => x.asStatus == 1 && x.asAccNo == accNo);
        }

        public IEnumerable<tblAsset> GetAssetListByAccNoNdDtStartEnd(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asAccNo == accNo && x.asDate >= dtStart && x.asDate <= dtEnd).OrderBy(x => x.asDate).ToList();
        }
        public class Asset : tblAsset
        {
            public double? Balance { get; set; }

        }
        public IEnumerable<Asset> GetAssetsByAccNoNdDtStartEnd(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            var asset = (this.tbAssetList ?? QueryData.AsQueryable())
                .Where(x => x.asAccNo == accNo)
                .Where(x => x.asDate >= dtStart)
                .Where(x => x.asDate <= dtEnd)
                .AsQueryable();
            var assets = from ast in asset
                         select new Asset
                         {
                             asAccNo = ast.asAccNo,
                             asAccName = ast.asAccName,
                             asDate = ast.asDate,
                             asEntId = ast.asEntId,
                             asEntNo = ast.asEntNo,
                             asDebit = ast.asDebit,
                             asCredit = ast.asCredit,
                             asDesc = ast.asDesc,
                             asStatus = ast.asStatus,
                             asView = ast.asView,
                             asUserId = ast.asUserId,
                             asBrnId = ast.asBrnId,
                             Balance = 0
                         };


            var beforeAssetsBalaneList = (from a in db.tblAssets
                                          where a.asBrnId == Session.CurBranch.brnId && (a.asDate >= Session.CurrentYear.fyDateStart && a.asDate <= Session.CurrentYear.fyDateEnd)
                                          select a)
            .Where(x => x.asAccNo == accNo && x.asDate < dtStart).Select(sa => new { sa.asDebit, sa.asCredit }).ToList();

            double beforeAssetsBalane =
               (beforeAssetsBalaneList.Select(sa => sa.asDebit).Sum() ?? 0)
                - (beforeAssetsBalaneList.Select(sa => sa.asCredit).Sum() ?? 0);


            var data = assets.ToList();
            data.Add(new Asset
            {
                asAccNo = 0,
                asAccName = "",
                asDate = dtStart,
                asEntId = 0,
                asEntNo = 0,
                asDebit = (beforeAssetsBalane > 0) ? beforeAssetsBalane : 0,
                asCredit = (beforeAssetsBalane < 0) ? Math.Abs(beforeAssetsBalane) : 0,
                asDesc = "رصيد سابق",
                asStatus = 100,
                asView = 100,
                asUserId = 0,
                asBrnId = 0,
                Balance = beforeAssetsBalane
            });

            data = data.OrderBy(x => x.asDate).ThenBy(x => x.asEntNo).ToList();
            double balance = 0;
            data.ForEach(d =>
            {
                balance += d.asDebit ?? 0;
                balance -= d.asCredit ?? 0;
                d.Balance = balance;
            });
            return data;
            //   return 
        }

        public IEnumerable<tblAsset> GetAssetSupplyListByEntId(int supId)
        {
            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asEntId == supId && x.asStatus >= 5 && x.asStatus <= 8).ToList();
            else return db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == supId && x.asStatus >= 5 && x.asStatus <= 8).ToList();
        }

        public tblAsset GetAssetObjByEntIdViewNdStatus(int entId, byte asView, byte asStatus)
        {
            if (!noload)
                return (this.tbAssetList ?? QueryData.AsQueryable()).FirstOrDefault(x => x.asEntId == entId && x.asView == asView && x.asStatus == asStatus);
            else return db.tblAssets.FirstOrDefault(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == entId && x.asView == asView && x.asStatus == asStatus);
        }

        public bool IsSupplyIdFound(int supId)
        {
            if (!noload) return (this.tbAssetList ?? QueryData).Any(x => x.asEntId == supId &&
                x.asStatus >= 5 && x.asStatus <= 8);
            else return db.tblAssets.Any(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == supId &&
                x.asStatus >= 5 && x.asStatus <= 8);
        }

        public bool IsSupplyIdFound2(int supId)
        {
            return db.tblAssets.AsQueryable().Any(x => x.asBrnId == Session.CurBranch.brnId &&
                x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd &&
                x.asEntId == supId && x.asStatus >= 5 && x.asStatus <= 8);
        }

        public bool UpdateAssetDebitByPrdMsurId(int msurId, double amount)
        {

            tblAsset tbAsset = (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asStatus == 10 && x.asEntId == msurId).FirstOrDefault();
            var aset = db.tblAssets.Find(tbAsset.id);
            // db.tblAssets.Attach(tbAsset);
            aset.asDebit = amount;

            return Save;
        }

        public bool DeleteRowByPrdMsurId(int msurId)
        {
            tblAsset tbAsset = (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asStatus == 10 && x.asEntId == msurId).FirstOrDefault();
            if (tbAsset != null)
                db.tblAssets.Remove(tbAsset);

            return Save;
        }

        public bool DeleteAssetByEntIdNdStatus(int entId, byte asStatus)
        {
            db.tblAssets.RemoveRange((this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asEntId == entId && x.asStatus == asStatus));
            return Save;
        }

        public bool DeleteAssetPrdQuanOpnAll()
        {
            var tbAssetPrdQuanOpnList = (this.tbAssetList ?? QueryData.AsQueryable()).Where(x => x.asStatus == 10).ToList();
            db.tblAssets.RemoveRange(tbAssetPrdQuanOpnList);
            return Save;
        }

        public void Add(tblAsset tbAsset)
        {
            db.tblAssets.Add(tbAsset);
        }
        public void Delete(tblAsset tbAsset)
        {
            db.tblAssets.Remove(tbAsset);
        }

        public bool Save => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
