using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public class ClsDrawerPeriodTarhel
    {
        List<tblAsset> tbAssetList;
        public ClsDrawerPeriodTarhel()
        {

        }
        public bool UndoPhaseDrawerPeriod(IEnumerable<DrawerPeriod> tbDrawerPeriodList)
        {
            int countSaved = 0;
            foreach (var M in tbDrawerPeriodList)
                using (var db = new accountingEntities())
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    try
                    {
                        db.DrawerPeriods.FirstOrDefault(x => x.ID == M.ID).IsTarhil = false;
                        db.tblAssets.RemoveRange(db.tblAssets.Where(x => x.asBrnId == M.BranchID && x.asEntId == M.ID && (x.asStatus == (byte)AssetType.CloseDailyBox || x.asStatus == (byte)AssetType.UnderSettlement)));
                        db.SaveChanges();
                        transaction.Commit();
                        countSaved++;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
            return countSaved > 0;
        }
        public class errorList
        {
            [DisplayName("رقم الفاتورة")]
            public int ID { get; set; }
            [DisplayName("الخطاء")]
            public string Error { get; set; }
        }
        public List<errorList> errorListTarhel = new List<errorList>();
        private void AddTblAssetObj(DrawerPeriod CurrPeriod)
        {
            tblAccountBox boxAcc = Session.Boxes.FirstOrDefault(x => x.id == CurrPeriod?.DrawerID);
            tblAccountBox boxCloseAcc = Session.Boxes.FirstOrDefault(x => x.id == CurrPeriod?.ClosingDrwerID);
            this.tbAssetList = new List<tblAsset>();
            if (CurrPeriod.TransferdBalance != 0)
            {
                this.tbAssetList.Add(new tblAsset()
                {
                    asAccNo = boxAcc.boxAccNo,
                    asAccName = boxAcc.boxName,
                    asDate = CurrPeriod.PeriodEnd,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asStatus = (byte?)AssetType.CloseDailyBox,
                    asDebit = (CurrPeriod.TransferdBalance < 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asCredit = (CurrPeriod.TransferdBalance > 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asDesc = ("اغلاق يومية صندوق رقم" + CurrPeriod.ID.ToString()),
                    asBrnId = CurrPeriod.BranchID,
                    asUserId = CurrPeriod.PeriodUserID,
                    asView = 1
                });
                this.tbAssetList.Add(new tblAsset()
                {
                    asAccNo = boxCloseAcc.boxAccNo,
                    asAccName = boxCloseAcc.boxName,
                    asDate = CurrPeriod.PeriodEnd,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asStatus = (byte?)AssetType.CloseDailyBox,
                    asDebit = (CurrPeriod.TransferdBalance > 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asCredit = (CurrPeriod.TransferdBalance < 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asDesc = ("اغلاق يومية صندوق رقم" + CurrPeriod.ID.ToString()),
                    asBrnId = CurrPeriod.BranchID,
                    asUserId = CurrPeriod.ClosingPeriodUserID,
                    asView = 1
                });
            }

            var BalanceDifference = CurrPeriod.ActualBalance - CurrPeriod.ClosingBalance;
            if (BalanceDifference != 0)
            {
                string statment = "تسويه عجز / زياده ليوميه صندوق" + " رقم " + CurrPeriod.ID;
                this.tbAssetList.Add(new tblAsset()
                {
                    asBrnId = Session.CurBranch?.brnId,
                    asDate = CurrPeriod.PeriodEnd,
                    asStatus = (byte?)AssetType.UnderSettlement,
                    asDesc = statment,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asDebit = (BalanceDifference > 0) ? Math.Abs(BalanceDifference) : 0,
                    asCredit = (BalanceDifference < 0) ? Math.Abs(BalanceDifference) : 0,
                    asUserId = CurrPeriod.PeriodUserID,
                    asAccNo = boxAcc.boxAccNo,
                    asAccName = Session.Accounts.FirstOrDefault(x => x.accNo == boxAcc.boxAccNo)?.accName ?? boxAcc.boxName,
                    asView = 1,
                });
                var acc = Session.Accounts.FirstOrDefault(x => x.id == CurrPeriod.DifferenceAccountID);
                this.tbAssetList.Add(new tblAsset()
                {
                    asBrnId = Session.CurBranch?.brnId,
                    asDate = CurrPeriod.PeriodEnd,
                    asStatus = (byte?)AssetType.UnderSettlement,
                    asDesc = statment,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asDebit = (BalanceDifference < 0) ? Math.Abs(BalanceDifference) : 0,
                    asCredit = (BalanceDifference > 0) ? Math.Abs(BalanceDifference) : 0,
                    asUserId = CurrPeriod.PeriodUserID,
                    asAccNo = acc.accNo,
                    asAccName = acc.accName,
                    asView = 1,
                });
            }
        }
        public bool PhaseAutoDrawerPeriod(DrawerPeriod CurrPeriod)
        {
            ChickAccNo(CurrPeriod);
            AddTblAssetObj(CurrPeriod);
            decimal SumDebit = Convert.ToDecimal(tbAssetList?.Sum(x => x.asDebit) ?? 0);
            decimal SumCredit = Convert.ToDecimal(tbAssetList?.Sum(x => x.asCredit) ?? 0);
            if (SumDebit != SumCredit)
                errorListTarhel.Add(new errorList { ID = CurrPeriod.ID, Error = "اجمالي المدين لا يساوي اجمالي الدائن" });
            bool isSaved = false;
            using (var db = new accountingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (errorListTarhel.Where(x => x.ID == CurrPeriod.ID).Count() > 0)
                        {
                            transaction.Rollback();
                            this.tbAssetList.Clear();
                            return false;
                        }
                        if (this.tbAssetList.Count > 0)
                            db.tblAssets.AddRange(this.tbAssetList);
                        db.DrawerPeriods.AddOrUpdate(CurrPeriod);
                        db.DrawerPeriods.FirstOrDefault(x => x.ID == CurrPeriod.ID).IsTarhil = true;
                        db.SaveChanges();
                        transaction.Commit();
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        this.tbAssetList.Clear();
                        transaction.Rollback();
                        errorListTarhel.Add(new errorList { ID = CurrPeriod.ID, Error = "اجمالي المدين لا يساوي اجمالي الدائن" });
                        return false;
                    }
                }
            }
            return isSaved;
        }
        public bool PhaseDrawerPeriod(IEnumerable<DrawerPeriod> tbDrawerPeriodList)
        {
            int countSaved = 0;
            foreach (var M in tbDrawerPeriodList)
                if (PhaseAutoDrawerPeriod(M))
                    countSaved++;
            return countSaved > 0;
        }
        void ChickAccNo(DrawerPeriod drawer)
        {
            double BalanceDifference = drawer.ActualBalance - drawer.ClosingBalance;
            if (BalanceDifference != 0 && (drawer.DifferenceAccountID ?? 0) == 0)
                errorListTarhel.Add(new errorList { ID = drawer.ID, Error = "يجب اختيار حساب التسوية بسبب وجود عجز او زياده " });
            if ((drawer.DifferenceAccountID ?? 0) > 0 && !Session.Accounts.Any(x => x.id == drawer.DifferenceAccountID))
                errorListTarhel.Add(new errorList { ID = drawer.ID, Error = "حساب التسوية غير موجود في الدليل المحاسبي" });
            tblAccountBox boxAcc = Session.Boxes.FirstOrDefault(x => x.id == drawer?.DrawerID);
            tblAccountBox boxCloseAcc = Session.Boxes.FirstOrDefault(x => x.id == drawer?.ClosingDrwerID);
            if (boxAcc == null)
                errorListTarhel.Add(new errorList { ID = drawer.ID, Error = "لا يوجد صندوق لهذه الفتره يجب تحديد الصندوق اولا عند فتح اليومية " });
            else if (!Session.Accounts.Any(x => x.accNo == boxAcc.boxAccNo))
                errorListTarhel.Add(new errorList { ID = drawer.ID, Error = "هذا الصندوق غير مربوط باي حساب في الدليل المحاسبي!!!" });
            else if (!Session.Accounts.Any(x => x.accNo == boxCloseAcc.boxAccNo))
                errorListTarhel.Add(new errorList { ID = drawer.ID, Error = " صندوق الاغلاق غير مربوط باي حساب في الدليل المحاسبي!!!" });
        }
    }
}
