using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace accounting_1._0
{
    class ClsTarhel
    {
        accountingEntities2 db;
        ArrayList list = new ArrayList();

        public bool EntryTarhel (ArrayList list, byte srchStatus, byte entStatus, byte assStatus)
        {
            db = new accountingEntities2();
            DateTime d = DateTime.Now;

            var entryMain = (from a in db.tblEntryMains
                             where a.entBrnId == ClsBranchId.BranchId && (a.entDate >= ClsFinancialYear.FyDtStart && a.entDate <= ClsFinancialYear.FyDtEnd) && a.entStatus == srchStatus
                             select a).ToList();
            var entrySub = (from a in db.tblEntrySubs
                            where a.entBrnId == ClsBranchId.BranchId && (a.entDate >= ClsFinancialYear.FyDtStart && a.entDate <= ClsFinancialYear.FyDtEnd) && a.entStatus == srchStatus
                            select a).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                tblEntryMain entMainList = new tblEntryMain();
                if (srchStatus > 1)
                    entMainList = (tblEntryMain)list[i];
                bool taxFlag = true;

                foreach (var entryMainUpdate in entryMain)
                {
                    if (srchStatus == 1)
                    {
                        if ((int)list[i] == entryMainUpdate.entNo)
                        {
                            entryMainUpdate.entStatus = entStatus;
                            break;
                        }
                    }
                    else
                    {
                        if (entryMainUpdate.entNo == entMainList.entNo && entryMainUpdate.entBoxNo == entMainList.entBoxNo)
                        {
                            entryMainUpdate.entStatus = entStatus;
                            break;
                        }
                    }
                }
                
                foreach (var entrySubUpdate in entrySub)
                {
                    bool isFound = false;

                    if (srchStatus == 1)
                    {
                        if ((int)list[i] == entrySubUpdate.entNo)
                            isFound = true;
                    }
                    else
                    {
                        if (entrySubUpdate.entNo == entMainList.entNo && entrySubUpdate.entBoxNo == entMainList.entBoxNo)
                            isFound = true;
                    }

                    if (isFound)
                    {
                        entrySubUpdate.entStatus = entStatus;

                        tblAsset asset = new tblAsset()
                        {
                            asAccNo = (long)entrySubUpdate.entAccNo,
                            asAccName = entrySubUpdate.entAccName,
                            asDate = d.Date,
                            asEntNo = entrySubUpdate.id,
                            asStatus = assStatus,
                            asDebit = entrySubUpdate.entDebit,
                            asCredit = entrySubUpdate.entCredit,
                            asBrnId = ClsBranchId.BranchId,
                            asUserId = ClsUserId.UserId,
                            asView = 1
                        };
                        db.tblAssets.Add(asset);

                        if (entrySubUpdate.entTaxPrice > 0 && taxFlag)                  //Save TaxAmount to tax account for main entry
                        {
                            ClsTaxAccounts taxAccount = new ClsTaxAccounts();
                            taxAccount.EntryTaxAcc();

                            tblAsset assetTax = new tblAsset()
                            {
                                asAccNo = taxAccount.taxAccNo,
                                asAccName = taxAccount.taxAccName,
                                asDate = d.Date,
                                asEntNo = entrySubUpdate.id,
                                asStatus = assStatus,
                                asDebit = entrySubUpdate.entTaxPrice,
                                asBrnId = ClsBranchId.BranchId,
                                asUserId = ClsUserId.UserId,
                                asView = 1
                            };
                            taxFlag = false;
                            db.tblAssets.Add(assetTax);
                        }
                    }
                }
            }

            return (SaveDB()) ? true : false;
        }

        public bool DeleteTarhel(tblEntryMain tbEntMain, BindingList<tblEntrySub> tbEntSub)
        {
            db = new accountingEntities2();
            var tbAsset = (from a in db.tblAssets
                           where a.asBrnId == ClsBranchId.BranchId && a.asStatus == 2 || a.asStatus == 3 || a.asStatus == 4 || a.asStatus == 9
                           orderby a.asEntNo ascending
                           select a).ToList();
            byte status = tbEntMain.entStatus, aStatus = 0, entSubStauts = 0;
            db.tblEntryMains.Attach(tbEntMain);

            if (status == 4)
            {
                tbEntMain.entStatus = 1;
                entSubStauts = 1;
                aStatus = 2;
            }
            else if (status == 5)
            {
                tbEntMain.entStatus = 2;
                entSubStauts = 3;
                aStatus = 3;
            }
            else if (status == 6)
            {
                tbEntMain.entStatus = 3;
                entSubStauts = 3;
                aStatus = 4;
            }
            else if (status == 8)
            {
                tbEntMain.entStatus = 7;
                entSubStauts = 7;
                aStatus = 9;
            }

            foreach (var tEntSub in tbEntSub)
            {
                db.tblEntrySubs.Attach(tEntSub);
                tEntSub.entStatus = entSubStauts;

                foreach (var tAsset in tbAsset)
                {
                    if (tAsset.asEntNo > tEntSub.id) break;
                    if (tAsset.asEntNo == tEntSub.id && tAsset.asStatus == aStatus)
                        db.tblAssets.Remove(tAsset);
                }
            }

            if (SaveDB()) return true;
            else return false;
        }

        private bool SaveDB()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
