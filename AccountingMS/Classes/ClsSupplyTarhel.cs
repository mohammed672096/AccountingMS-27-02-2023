using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsSupplyTarhel
    {
        ClsTblBank clsTbBank = new ClsTblBank();
        ClsTblAccount clsTbAccount;
        ClsTblGroupStr clsTbGroupStr;
        List<tblAsset> tbAssetList;
        ClsTblBox clsTbBox = new ClsTblBox();
        private SupplyType supplyType;
        ClsTblPrdManufacture clsTbPrdMan;
        private byte supStatus, assStatus;
        public ClsSupplyTarhel(SupplyType supplyType, ClsTblAccount clsTbAccount = null, ClsTblGroupStr clsTbGroup = null)
        {
            this.supplyType = supplyType;
            SetStatus();
            InitObjects(clsTbAccount, clsTbGroup);
        }


        private void AddSupplyToAcc(tblSupplyMain M, double Amount, string AccName, long AccNo, bool isDebit)
        {
            this.tbAssetList.Add(new tblAsset()
            {
                asEntId = M.id,
                asEntNo = M.supNo,
                asAccNo = AccNo,
                asAccName = AccName,
                asDesc = M.supDesc,
                asDate = M.supDate,
                asBrnId = M.supBrnId,
                asUserId = M.supUserId,
                asStatus = this.assStatus,
                asView = 2,
                asDebit = isDebit ?Amount: 0,
                asCredit = isDebit ? 0 : Amount
            });
        }
        public class errorList
        {
            [DisplayName("رقم الفاتورة")]
            public int ID { get; set; }
            [DisplayName("الخطاء")]
            public string Error { get; set; }
        }
        public List<errorList> errorListTarhel = new List<errorList>();
        double GetTax(tblSupplySub s, bool isSale)
        {
            double total = (isSale ? (s.supSalePrice ?? 0) : (s.supPrice ?? 0)) * Convert.ToDouble(s.supQuanMain);
            double dis = total * (Convert.ToDouble(s.supDscntPercent) / 100);
            if ((s.supTaxPrice ?? 0)! > 0)
                return s.supTaxPrice ?? 0;
            if (MySetting.DefaultSetting.CalcTaxAfterDiscount)
                return (total - dis) * (Convert.ToDouble(s.supTaxPercent) / 100);
            else
                return total * (Convert.ToDouble(s.supTaxPercent) / 100);
        }
        double GetDiscountSale(tblSupplySub s)
        {
            double total = (s.supSalePrice ?? 0) * Convert.ToDouble(s.supQuanMain);
            return total * (Convert.ToDouble(s.supDscntPercent) / 100d);
        }
        double GetDiscountBuy(tblSupplySub s, bool isSale)
        {
            double total = (s.supPrice ?? 0) * Convert.ToDouble(s.supQuanMain);
            return !isSale ? total * (Convert.ToDouble(s.supDscntPercent) / 100d) : 0;
        }
        void SetTax(tblSupplyMain M, bool isDebit, double tax)
        {
            tblTaxAccount tbTaxAcc;
            if (ClsTblDefaultAccount.tbTaxAccountList.Count <= 0)
                ClsTblDefaultAccount.GetDataDefaultAccount();
            if (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn)
                tbTaxAcc = ClsTblDefaultAccount.tbTaxAccountList?.FirstOrDefault(x => x.taxStatus == 5);
            else tbTaxAcc = ClsTblDefaultAccount.tbTaxAccountList?.FirstOrDefault(x => x.taxStatus == 4);
            if (tbTaxAcc == null) return;
            ChickAccNo(M.supNo, Convert.ToInt64(tbTaxAcc.taxAccNo), "الضريبة");
            AddSupplyToAcc(M, tax, tbTaxAcc.taxAccName, Convert.ToInt64(tbTaxAcc.taxAccNo), !isDebit);
        }
        bool created;
        public bool PhaseAutoInvoice(tblSupplyMain M)
        {
            bool isDebit = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.PurchaseRtrn);
            bool isSale = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn);
            int countSaved = 0;
            this.tbAssetList = new List<tblAsset>();
            var GroAndAcc = (from g in clsTbGroupStr.GetGroupList
                             select new
                             {
                                 g.grpAccNo,
                                 g.grpCostAccNo,
                                 g.id,
                                 g.grpSalesAccNo,
                                 g.grpSalesRtrnAccNo,
                                 AccName = this.clsTbAccount.GetAccountNameByNo2(g.grpAccNo),
                                 SalesAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpSalesAccNo ?? 0),
                                 SalesRtrnAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpSalesRtrnAccNo ?? 0),
                                 CostAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpCostAccNo ?? 0),
                             });
            using (var db = new accountingEntities())
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                try
                {
                    created = true;
                    //db.Database.Log = Console.Write;
                    var ListSub = db.tblSupplySubs.Where(x => x.supNo == M.id).ToList();
                    if (ListSub.Count <= 0) errorListTarhel.Add(new errorList { ID = M.supNo, Error = "لا يوجد اصناف في هذه الفاتورة" });
                    var supply = (from s in ListSub
                                  join p in db.tblProducts on s.supPrdId equals p.id
                                  join g in GroAndAcc on p.prdGrpNo equals g.id
                                  select new
                                  {
                                      g.id,
                                      g.grpAccNo,
                                      g.grpCostAccNo,
                                      g.grpSalesAccNo,
                                      g.grpSalesRtrnAccNo,
                                      g.AccName,
                                      g.CostAccName,
                                      g.SalesAccName,
                                      g.SalesRtrnAccName,
                                      AmountEradat = ((s.supSalePrice ?? 0) * Convert.ToDouble(s.supQuanMain)) - GetDiscountSale(s),
                                      AmountTax = GetTax(s, isSale),
                                      AmountCost = ((s.supPrice ?? 0) * Convert.ToDouble(s.supQuanMain)) - GetDiscountBuy(s, isSale),
                                  }).GroupBy(x => x.id).Select(y =>
                                    new {
                                        SumEradat = y.Sum(x => x.AmountEradat),
                                        SumTax = y.Sum(x => x.AmountTax),
                                        SumCost = y.Sum(x => x.AmountCost),
                                        AccNo = y.Max(x => x.grpAccNo),
                                        SalesAccNo = y.Max(x => x.grpSalesAccNo),
                                        SalesRtrnAccNo = y.Max(x => x.grpSalesRtrnAccNo),
                                        CostAccNo = y.Max(x => x.grpCostAccNo),
                                        y.FirstOrDefault().AccName,
                                        y.FirstOrDefault().SalesAccName,
                                        y.FirstOrDefault().CostAccName,
                                        y.FirstOrDefault().SalesRtrnAccName,
                                    }).ToList();
                    supply.ForEach(x =>        //ترحيل حسابات المجموعات المخزنية
                    {
                        ChickAccNo(M.supNo, x.AccNo, "المخزون");
                        AddSupplyToAcc(M, x.SumCost, x.AccName, x.AccNo, !isDebit); //  ترحيل المخزون 
                        if (MySetting.DefaultSetting.InvType && isSale)  // الجرد المستمر 
                        {
                            ChickAccNo(M.supNo, x.CostAccNo ?? 0, "تكلفة المبيعات");
                            if (x.SumCost > 0) AddSupplyToAcc(M, x.SumCost, x.CostAccName, x.CostAccNo ?? 0, isDebit); // ترحيل تكلفة المبيعات 
                        }
                        if (this.supplyType == SupplyType.Sales)
                        {
                            ChickAccNo(M.supNo, x.SalesAccNo ?? 0, "المبيعات");
                            if (x.SumEradat > 0) AddSupplyToAcc(M, x.SumEradat, x.SalesAccName, x.SalesAccNo ?? 0, !isDebit);
                        }
                        else if (SupplyType.SalesRtrn == this.supplyType)
                        {
                            ChickAccNo(M.supNo, x.SalesRtrnAccNo ?? 0, "مردود المبيعات");
                            if (x.SumEradat > 0) AddSupplyToAcc(M, x.SumEradat, x.SalesRtrnAccName, x.SalesRtrnAccNo ?? 0, !isDebit);
                        }
                    });
                    if ((supply?.Sum(x => x?.SumTax) ?? 0) is double tax && tax > 0) SetTax(M, isDebit, tax);//ترحيل مبلغ الضريبة
                    ChickAccNo(M.supNo, M.supAccNo ?? 0, (M.supIsCash == 1 ? "الصندوق" : "العميل"));
                    SetAmount(GetNewAsset(M), M, isDebit);
                    ChickSumForDebitAndCredit(M, isDebit);
                    if (errorListTarhel.Where(x => x.ID == M.supNo).Count() > 0)
                    {
                        transaction.Rollback();
                        this.tbAssetList.Clear();
                        return false;
                    }
                    if (db.tblAssets.Any(x => x.asEntId == M.id && x.asDate.Value.Year == M.supDate.Value.Year && x.asStatus == this.assStatus))
                    {
                        db.tblAssets.RemoveRange(db.tblAssets.Where(x => x.asEntId == M.id && x.asDate.Value.Year == M.supDate.Value.Year && x.asStatus == this.assStatus));
                        db.SaveChanges();
                    }
                    db.tblAssets.AddRange(this.tbAssetList);
                    this.tbAssetList = new List<tblAsset>();
                    db.tblSupplyMains.FirstOrDefault(x => x.id == M.id).supStatus = this.supStatus;
                    db.tblSupplySubs.Where(x => x.supNo == M.id).ToList().ForEach(x => x.supStatus = this.supStatus);
                    db.SaveChanges();
                    transaction.Commit();
                    countSaved++;
                }
                catch (Exception ex)
                {
                    errorListTarhel.Add(new errorList { ID = M.supNo, Error = ex.Message });
                    this.tbAssetList.Clear();
                    transaction.Rollback();
                }
            return countSaved > 0;
        }
        public bool PhaseInvoice(IEnumerable<tblSupplyMain> tbSupplyMainList)
        {
            bool isDebit = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.PurchaseRtrn);
            bool isSale = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn);
            int countSaved = 0;
            this.tbAssetList = new List<tblAsset>();
            var GroAndAcc = (from g in clsTbGroupStr.GetGroupList
                             select new
                             {
                                 g.grpAccNo,
                                 g.grpCostAccNo,
                                 g.id,
                                 g.grpSalesAccNo,
                                 g.grpSalesRtrnAccNo,
                                 AccName = this.clsTbAccount.GetAccountNameByNo2(g.grpAccNo),
                                 SalesAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpSalesAccNo ?? 0),
                                 SalesRtrnAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpSalesRtrnAccNo ?? 0),
                                 CostAccName = this.clsTbAccount.GetAccountNameByNo2(g.grpCostAccNo ?? 0),
                             });
            foreach (var M in tbSupplyMainList)
                using (var db = new accountingEntities())
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    try
                    {
                        created = true;
                        //db.Database.Log = Console.Write;
                        var ListSub = db.tblSupplySubs.Where(x => x.supNo == M.id).ToList();
                        if (ListSub.Count <= 0) errorListTarhel.Add(new errorList { ID = M.supNo, Error = "لا يوجد اصناف في هذه الفاتورة" });
                        var supply = (from s in ListSub
                                      join p in db.tblProducts on s.supPrdId equals p.id
                                      join g in GroAndAcc on p.prdGrpNo equals g.id
                                      select new
                                      {
                                          g.id,
                                          g.grpAccNo,
                                          g.grpCostAccNo,
                                          g.grpSalesAccNo,
                                          g.grpSalesRtrnAccNo,
                                          g.AccName,
                                          g.CostAccName,
                                          g.SalesAccName,
                                          g.SalesRtrnAccName,
                                          AmountEradat = ((s.supSalePrice ?? 0) * Convert.ToDouble(s.supQuanMain)) - GetDiscountSale(s),
                                          AmountTax = GetTax(s, isSale),
                                          AmountCost = ((s.supPrice ?? 0) * Convert.ToDouble(s.supQuanMain)) - GetDiscountBuy(s, isSale),
                                      }).GroupBy(x => x.id).Select(y =>
                                        new {
                                            SumEradat = y.Sum(x => x.AmountEradat),
                                            SumTax = y.Sum(x => x.AmountTax),
                                            SumCost = y.Sum(x => x.AmountCost),
                                            AccNo = y.Max(x => x.grpAccNo),
                                            SalesAccNo = y.Max(x => x.grpSalesAccNo),
                                            SalesRtrnAccNo = y.Max(x => x.grpSalesRtrnAccNo),
                                            CostAccNo = y.Max(x => x.grpCostAccNo),
                                            y.FirstOrDefault().AccName,
                                            y.FirstOrDefault().SalesAccName,
                                            y.FirstOrDefault().CostAccName,
                                            y.FirstOrDefault().SalesRtrnAccName,
                                        }).ToList();
                        supply.ForEach(x =>        //ترحيل حسابات المجموعات المخزنية
                        {
                            ChickAccNo(M.supNo, x.AccNo, "المخزون");
                            AddSupplyToAcc(M, x.SumCost, x.AccName, x.AccNo, !isDebit); //  ترحيل المخزون 
                            if (MySetting.DefaultSetting.InvType && isSale)  // الجرد المستمر 
                            {
                                ChickAccNo(M.supNo, x.CostAccNo ?? 0, "تكلفة المبيعات");
                                if (x.SumCost > 0) AddSupplyToAcc(M, x.SumCost, x.CostAccName, x.CostAccNo ?? 0, isDebit); // ترحيل تكلفة المبيعات 
                            }
                            if (this.supplyType == SupplyType.Sales)
                            {
                                ChickAccNo(M.supNo, x.SalesAccNo ?? 0, "المبيعات");
                                if (x.SumEradat > 0) AddSupplyToAcc(M, x.SumEradat, x.SalesAccName, x.SalesAccNo ?? 0, !isDebit);
                            }
                            else if (SupplyType.SalesRtrn == this.supplyType)
                            {
                                ChickAccNo(M.supNo, x.SalesRtrnAccNo ?? 0, "مردود المبيعات");
                                if (x.SumEradat > 0) AddSupplyToAcc(M, x.SumEradat, x.SalesRtrnAccName, x.SalesRtrnAccNo ?? 0, !isDebit);
                            }
                        });
                        if ((supply?.Sum(x => x?.SumTax) ?? 0) is double tax && tax > 0) SetTax(M, isDebit, tax);//ترحيل مبلغ الضريبة
                        ChickAccNo(M.supNo, M.supAccNo ?? 0, (M.supIsCash == 1 ? "الصندوق" : "العميل"));
                        SetAmount(GetNewAsset(M), M, isDebit);
                        ChickSumForDebitAndCredit(M, isDebit);
                        if (errorListTarhel.Where(x => x.ID == M.supNo).Count() > 0)
                        {
                            transaction.Rollback();
                            this.tbAssetList.Clear();
                            continue;
                        }
                        if (db.tblAssets.Any(x => x.asEntId == M.id && x.asDate.Value.Year == M.supDate.Value.Year && x.asStatus == this.assStatus))
                        {
                            db.tblAssets.RemoveRange(db.tblAssets.Where(x => x.asEntId == M.id && x.asDate.Value.Year == M.supDate.Value.Year && x.asStatus == this.assStatus));
                            db.SaveChanges();
                        }
                        db.tblAssets.AddRange(this.tbAssetList);
                        this.tbAssetList = new List<tblAsset>();
                        db.tblSupplyMains.FirstOrDefault(x => x.id == M.id).supStatus = this.supStatus;
                        db.tblSupplySubs.Where(x => x.supNo == M.id).ToList().ForEach(x => x.supStatus = this.supStatus);
                        db.SaveChanges();
                        transaction.Commit();
                        countSaved++;
                    }
                    catch (Exception ex)
                    {
                        errorListTarhel.Add(new errorList { ID = M.supNo, Error = ex.Message });
                        this.tbAssetList.Clear();
                        transaction.Rollback();
                    }
            return countSaved > 0;
        }
        void ChickAccNo(int supNo, long AccNo, string AccName)
        {
            int count = this.clsTbAccount.GetAccountList.Count(a => a.accNo == AccNo);
            if (AccNo == 0 || count < 1)
                errorListTarhel.Add(new errorList { ID = supNo, Error = $"حساب {AccName} غير محدد" });
            else if (count > 1)
                errorListTarhel.Add(new errorList { ID = supNo, Error = $"لا يمكن ان يكون رقم حساب {AccName} مكررا في الدليل المحاسبي" });

        }
        void ChickSumForDebitAndCredit(tblSupplyMain M, bool isDebit)
        {
            double SumDebit = this.tbAssetList?.Sum(x => x.asDebit) ?? 0;
            double SumCredit = this.tbAssetList?.Sum(x => x.asCredit) ?? 0;
            if (SumDebit != SumCredit)
            {
                double amount = (SumDebit > SumCredit) ? (SumDebit - SumCredit) : (SumCredit - SumDebit);
                if (amount >= 1)
                    errorListTarhel.Add(new errorList { ID = M.supNo, Error = "اجمالي المدين لا يساوي اجمالي الدائن" });
                else
                {
                    tblAsset tblAsset = this.tbAssetList.FirstOrDefault(x => x.asView == 1);
                    if (tblAsset == null) return;
                    if (isDebit)
                    {
                        if (SumDebit < SumCredit) tblAsset.asDebit += amount;
                        else if (SumDebit > SumCredit) tblAsset.asDebit -= amount;
                    }
                    else
                    {
                        if (SumDebit < SumCredit) tblAsset.asCredit -= amount;
                        else if (SumDebit > SumCredit) tblAsset.asCredit += amount;
                    }
                }
            }
        }
        private void SetStatus()
        {
            if (this.supplyType == SupplyType.DirectSalesRtrn) this.supplyType = SupplyType.SalesRtrn;
            else if (this.supplyType == SupplyType.DirectPurchaseRtrn) this.supplyType = SupplyType.PurchaseRtrn;

            switch (this.supplyType)
            {
                case SupplyType.Purchase:
                    this.supStatus = (byte)SupplyType.PurchasePhase;
                    this.assStatus = 5;
                    break;
                case SupplyType.PurchaseRtrn:
                    this.supStatus = (byte)SupplyType.PurchasePhaseRtrn;
                    this.assStatus = 7;
                    break;
                case SupplyType.Sales:
                    this.supStatus = (byte)SupplyType.SalesPhase;
                    this.assStatus = 6;
                    break;
                case SupplyType.SalesRtrn:
                    this.supStatus = (byte)SupplyType.SalesPhaseRtrn;
                    this.assStatus = 8;
                    break;
            }
        }
        private tblAsset GetNewAsset(tblSupplyMain tbSupplyMain) => new tblAsset()
        {
            asEntId = tbSupplyMain.id,
            asEntNo = tbSupplyMain.supNo,
            asAccNo = Convert.ToInt64(tbSupplyMain.supAccNo),
            asAccName = tbSupplyMain.supAccName,
            asDesc = tbSupplyMain.supDesc,
            asDate = tbSupplyMain.supDate,
            asBrnId = tbSupplyMain.supBrnId,
            asUserId = Session.CurrentUser.id,
            asStatus = this.assStatus,
            asView = 1
        };
        private void SetAmount(tblAsset tbAsset, tblSupplyMain tbSupplyMain, bool IsDebit)
        {
            double amount = Math.Round((tbSupplyMain.supTotal + (tbSupplyMain.supTaxPrice ?? 0)) - (tbSupplyMain.supDscntAmount ?? 0), 2);
            double BankAmount = Math.Round((tbSupplyMain.supBankAmount ?? 0), 2);
            if (BankAmount > amount) BankAmount = amount;
            double CashAmount;
            if (BankAmount > 0)
            {
                tbAsset.asAccNo = this.clsTbBank.GetTblBankList?.FirstOrDefault(x => x.id == tbSupplyMain.supBankId)?.bankAccNo ?? 0;
                tbAsset.asAccName = this.clsTbAccount.GetAccountNameByNo2(tbAsset.asAccNo);
                tbAsset.asDebit = IsDebit ? BankAmount : 0;
                tbAsset.asCredit = IsDebit ? 0 : BankAmount;
                this.tbAssetList.Add(tbAsset);
            }
            CashAmount = Math.Round(tbSupplyMain.supIsCash == 1 ? amount - BankAmount : Convert.ToDouble(tbSupplyMain.paidCash), 2);
            tblAsset tbAsset2 = GetNewAsset(tbSupplyMain);
            switch (tbSupplyMain.supIsCash)
            {
                case 1 when (CashAmount > 0):
                    tbAsset2.asDebit = IsDebit ? CashAmount : 0;
                    tbAsset2.asCredit = IsDebit ? 0 : CashAmount;
                    this.tbAssetList.Add(tbAsset2);
                    break;
                case 2:
                    if (CashAmount > amount) CashAmount = amount;
                    if (BankAmount + CashAmount > amount) CashAmount = amount - BankAmount;
                    if (CashAmount > 0)
                    {
                        tbAsset2.asAccNo = this.clsTbBox.GetBoxObjById(Convert.ToInt32(tbSupplyMain.supBoxId))?.boxAccNo ?? 0;
                        tbAsset2.asAccName = this.clsTbAccount.GetAccountNameByNo2(tbAsset2.asAccNo);
                        tbAsset2.asDebit = IsDebit ? CashAmount : 0;
                        tbAsset2.asCredit = IsDebit ? 0 : CashAmount;
                        this.tbAssetList.Add(tbAsset2);
                    }
                    tblAsset tbAsset3 = GetNewAsset(tbSupplyMain);
                    tbAsset3.asDebit = IsDebit ? amount : CashAmount + BankAmount;
                    tbAsset3.asCredit = IsDebit ? CashAmount + BankAmount : amount;
                    this.tbAssetList.Add(tbAsset3);
                    break;
            }
        }



        private void InitObjects(ClsTblAccount clsTbAccount, ClsTblGroupStr clsTbGroup)
        {
            this.clsTbAccount = clsTbAccount ?? new ClsTblAccount();
            this.clsTbGroupStr = clsTbGroup ?? new ClsTblGroupStr();
            if (this.supplyType != SupplyType.Sales && this.supplyType != SupplyType.SalesRtrn) return;
            this.clsTbPrdMan = new ClsTblPrdManufacture();
        }

        //private void PhaseManufacture(int supMainId, int supNo, tblSupplySub tbSupplySub)
        //{
        //    var tbPrdMan = this.clsTbPrdMan.GetPrdManListByPrdId((int)tbSupplySub.supPrdId).ToList();
        //    tbPrdMan.ForEach(x =>
        //    {
        //        var tbSupplySubTmp = tbSupplySub.ShallowCopy();
        //        var tbGroup = this.clsTbGroupStr.GetGroupObjById(this.clsTbProduct.GetPrdGroupIdByPrdId(x.manPrdSubId));
        //        var tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(x.manPrdMsurId);

        //        tbSupplySubTmp.supAccNo = (tbGroup?.grpAccNo).GetValueOrDefault();
        //        tbSupplySubTmp.supAccName = tbGroup?.grpName;
        //        tbSupplySubTmp.supPrdId = x.manPrdSubId;
        //        tbSupplySubTmp.supPrice = tbPrdMsur?.ppmPrice;
        //        tbSupplySubTmp.supSalePrice = tbPrdMsur?.ppmSalePrice;
        //        tbSupplySubTmp.supQuanMain *= Convert.ToDouble(x.manQuan);

        //        tbSupplySubTmp.supTaxPrice = (double)GetTaxPrice(tbSupplySubTmp);
        //        int grpId = tbGroup?.id ?? 0;

        //        long accNo = (this.supplyType == SupplyType.Sales) ? this.clsTbGroupStr.GetGroupSaleAccNoById(grpId) :
        //          this.clsTbGroupStr.GetGroupSaleRtrnAccNoById(grpId);
        //        AddSupplyTblAssetObj(supMainId, supNo, accNo,
        //                this.clsTbAccount.GetAccountNameByNo(accNo), tbSupplySub.supDesc, 2, GetAmountDiscount(tbSupplySub), null,
        //                (this.supplyType == SupplyType.Sales) ? false : true, tbSupplySub.supDate, tbSupplySub.supBrnId);

        //        AddSupplySubTblAssetTaxObj(supMainId, supNo, tbSupplySubTmp);

        //        if (this.isInvContinuous)
        //        {
        //            AddSupplySubTblAssetCostObj(supMainId, supNo, grpId, tbSupplySubTmp);
        //            AddSupplyTblAssetObj(supMainId, supNo, tbSupplySubTmp.supAccNo, tbSupplySubTmp.supAccName, tbSupplySub.supDesc, 1,
        //                tbSupplySubTmp.supPrice * Convert.ToDouble(tbSupplySubTmp.supQuanMain), null,
        //                (this.supplyType == SupplyType.Sales) ? false : true, tbSupplySub.supDate, tbSupplySub.supBrnId);
        //        }
        //    });
        //}


    }
}
