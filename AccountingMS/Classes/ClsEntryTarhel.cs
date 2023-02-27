using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;
namespace AccountingMS
{
    public class ClsEntryTarhel
    {
        ClsTblEntrySub clsTbEntSub;
        private byte entStatus;
        private byte assStatus;

        public ClsEntryTarhel(ClsTblEntrySub clsTbEntSub)
        {
            this.clsTbEntSub = clsTbEntSub;
        }
        public class errorList
        {
            [DisplayName("رقم السند")]
            public int ID { get; set; }
            [DisplayName("الخطاء")]
            public string Error { get; set; }
        }
        public List<errorList> errorListTarhel = new List<errorList>();
        bool created;
        List<tblAsset> tbAssetList;
        public bool EntryTarhel(IEnumerable<tblEntryMain> tbEntMainList, byte entStatus, byte assStatus)
        {
            this.entStatus = entStatus;
            this.assStatus = assStatus;
            int countSaved = 0;
            this.tbAssetList = new List<tblAsset>();
            foreach (var tbEntMain in tbEntMainList)
                using (var db = new accountingEntities())
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    try
                    {
                        created = true;
                        IEnumerable<tblEntrySub> tbEntSubList = this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBox(tbEntMain.entNo, Convert.ToInt32(tbEntMain.entBoxNo));
                        ChickSumForDebitAndCredit(tbEntSubList);
                        AddTblAssetObj(tbEntSubList);
                        foreach (var tbEntSub in tbEntSubList)
                        {
                            if (db.tblAssets.Any(x => x.asEntId == tbEntSub.id && x.asDate.Value.Year == tbEntSub.entDate.Value.Year && x.asStatus == this.assStatus))
                            {
                                db.tblAssets.RemoveRange(db.tblAssets.Where(x => x.asEntId == tbEntSub.id && x.asDate.Value.Year == tbEntSub.entDate.Value.Year && x.asStatus == this.assStatus));
                                db.SaveChanges();
                            }
                            db.tblEntrySubs.Attach(tbEntSub);
                            tbEntSub.entStatus = this.entStatus;
                        }
                        var s = (from a in tbAssetList
                                 join c in db.tblAccounts on a.asAccNo equals c.accNo
                                 select new { a.asCredit, a.asDebit }).ToList();
                        decimal d1 =Convert.ToDecimal( s.Sum(x => x.asDebit));
                        decimal  d2 = Convert.ToDecimal(s.Sum(x => x.asCredit));
                        if (d1 != d2)
                            errorListTarhel.Add(new errorList { ID = tbEntMain.entNo, Error = "يوجد ارقام حسابات مكرره في الدليل المحاسبي" });

                        if (!db.tblAccounts.Select(x => x.accNo).ToList().Any(a => tbAssetList.Select(x => x.asAccNo).Contains(a)))
                            errorListTarhel.Add(new errorList { ID = tbEntMain.entNo, Error = "يوجد حسابات غير موجودة في الدليل المحاسبي" });
                        if (errorListTarhel.Where(x => x.ID == tbEntMain.entNo).Count() > 0)
                        {
                            transaction.Rollback();
                            this.tbAssetList.Clear();
                            continue;
                        }

                        db.tblAssets.AddRange(this.tbAssetList);
                        db.tblEntryMains.Attach(tbEntMain);
                        tbEntMain.entStatus = entStatus;
                        //db.tblEntrySubs.Where(x => x.entNo == tbEntMain.entNo&&x.entStatus=).ToList().ForEach(x => x.supStatus = this.supStatus);
                        db.SaveChanges();
                        transaction.Commit();
                        countSaved++;
                    }
                    catch (Exception ex)
                    {
                        errorListTarhel.Add(new errorList { ID = tbEntMain.entNo, Error = ex.Message });
                        this.tbAssetList.Clear();
                        transaction.Rollback();
                    }
            return countSaved > 0;
        }
        void ChickSumForDebitAndCredit(IEnumerable<tblEntrySub> tbEntSubList)
        {
            decimal SumDebit =Convert.ToDecimal(tbEntSubList?.Sum(x => x.entDebit) ?? 0);
            decimal SumCredit = Convert.ToDecimal(tbEntSubList?.Sum(x => x.entCredit) ?? 0);
            if (SumDebit != SumCredit)
                errorListTarhel.Add(new errorList { ID = tbEntSubList.FirstOrDefault().entNo, Error = "اجمالي المدين لا يساوي اجمالي الدائن" });
        }
        private void AddTblAssetObj(IEnumerable<tblEntrySub> tbEntSubList)
        {
            this.tbAssetList = (from tbEntSub in tbEntSubList
                                select new tblAsset()
                                {
                                    asAccNo = (long)tbEntSub.entAccNo,
                                    asAccName = tbEntSub.entAccName,
                                    asDate = tbEntSub.entDate,
                                    asEntId = tbEntSub.id,
                                    asEntNo = tbEntSub.entNo,
                                    asStatus = this.assStatus,
                                    asDebit = tbEntSub.entDebit,
                                    asCredit = tbEntSub.entCredit,
                                    asDesc = tbEntSub.entDesc,
                                    asBrnId = Session.CurBranch.brnId,
                                    asUserId = Session.CurrentUser.id,
                                    asView = 1
                                }).ToList();
        }

    }
}
