using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsEntryDeleteTarhel
    {
        accountingEntities db;
        IEnumerable<tblAsset> tbAssetList;

        private byte entStatus, asStatus;

        public ClsEntryDeleteTarhel()
        {
            InitData();
        }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbAssetList = (from a in db.tblAssets
                                where a.asBrnId == Session.CurBranch.brnId && (a.asStatus >= 1 && a.asStatus <= 4) || (a.asStatus >= 9 && a.asStatus != 10)
                                orderby a.asEntId ascending
                                select a).ToList();
        }

        public bool Delete(tblEntryMain tbEntMain, IEnumerable<tblEntrySub> tbEntSubList)
        {
            SetStatus(tbEntMain.entStatus);
            UpdateEntMain(tbEntMain);
            UpdateEntSub(tbEntSubList);

            return SaveDB();
        }

        private void UpdateEntMain(tblEntryMain tbEntMain)
        {
            db.tblEntryMains.Attach(tbEntMain);
            tbEntMain.entStatus = this.entStatus;
        }

        private void UpdateEntSub(IEnumerable<tblEntrySub> tbEntSubList)
        {
            foreach (var tbEntSub in tbEntSubList)
            {
                db.tblEntrySubs.Attach(tbEntSub);
                tbEntSub.entStatus = this.entStatus;
                DeleteTblAssetEntry(tbEntSub.id);
            }
        }

        private void DeleteTblAssetEntry(int entId)
        {
            foreach (var tbAsset in this.tbAssetList)
            {
                if (tbAsset.asEntId > entId) break;
                if (tbAsset.asEntId == entId && tbAsset.asStatus == this.asStatus)
                    db.tblAssets.Remove(tbAsset);
            }
        }

        private void SetStatus(byte entStatus)
        {
            EntryType entryType = (EntryType)entStatus;
            switch ((EntryType)entStatus)
            {
                case EntryType.EntryPhased:
                    this.entStatus = 1;
                    this.asStatus = 2;
                    break;
                case EntryType.EntryVoucherPhased:
                    this.entStatus = 2;
                    this.asStatus = 3;
                    break;
                case EntryType.EntryReceiptPhased:
                    this.entStatus = 3;
                    this.asStatus = 4;
                    break;
                case EntryType.EmppVoucherPhased:
                    this.entStatus = 7;
                    this.asStatus = 9;
                    break;
                case EntryType.EmpVoucherTipPhased:
                    this.entStatus = (byte)EntryType.EmpVoucherTip;
                    this.asStatus = (byte)AssetType.EntEmpVchrTip;
                    break;
                case EntryType.EmpVoucherOvrTmPhased:
                    this.entStatus = (byte)EntryType.EmpVoucherOvrTm;
                    this.asStatus = (byte)AssetType.EntEmpVchrOvrTm;
                    break;
            }
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
