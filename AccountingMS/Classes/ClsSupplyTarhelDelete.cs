using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    class ClsSupplyTarhelDelete
    {
        private SupplyType supplyType;
        private byte supStatus, assStatus;

        public ClsSupplyTarhelDelete(SupplyType supplyType)
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            this.supplyType = supplyType;
            SetStatus();
            stopWatch.Stop("===============constructorTime = ");
        }

        public bool UndoPhaseInvoice(IEnumerable<tblSupplyMain> tbSupplyMainList)
        {
            foreach (var M in tbSupplyMainList)
                using (var db = new accountingEntities())
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    try
                    {
                        this.supplyType = (SupplyType)M.supStatus;
                        SetStatus();
                        db.tblSupplyMains.FirstOrDefault(x => x.id == M.id).supStatus = this.supStatus;
                        db.tblSupplySubs.Where(x => x.supNo == M.id).ToList().ForEach(x => x.supStatus = this.supStatus);
                        db.tblAssets.RemoveRange(db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId && x.asEntId == M.id && x.asStatus == this.assStatus));
                        db.SaveChanges();
                        transaction.Commit();
                        created = true;
                    }
                    catch (Exception ex)
                    {
                        created = false;
                        transaction.Rollback();
                    }
            return created;
        }
        bool created;
        private void SetStatus()
        {
            switch (this.supplyType)
            {
                case SupplyType.PurchasePhase:
                    this.supStatus = (byte)SupplyType.Purchase;
                    this.assStatus = 5;
                    break;
                case SupplyType.PurchasePhaseRtrn:
                    this.supStatus = (byte)SupplyType.PurchaseRtrn;
                    this.assStatus = 7;
                    break;
                case SupplyType.SalesPhase:
                    this.supStatus = (byte)SupplyType.Sales;
                    this.assStatus = 6;
                    break;
                case SupplyType.SalesPhaseRtrn:
                    this.supStatus = (byte)SupplyType.SalesRtrn;
                    this.assStatus = 8;
                    break;
            }
        }

    }
}
