using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace AccountingMS
{
    class ClsSupplierBalanceData
    {
        ClsTblAsset clsTbAsset = new ClsTblAsset(true);
        ClsTblSupplyMain mSupplyMain = new ClsTblSupplyMain(true);
        ClsTblEntrySub mEntrySub = new ClsTblEntrySub();
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblEntrySub> tbEntrySubList;
        long splAccNo;
        accountingEntities db = new accountingEntities();

        public ClsSupplierBalanceData()
        {
            InitData();
        }

        public ClsSupplierBalanceData(long splAccNo)
        {
            this.splAccNo = splAccNo;
            InitData();
            CalculateBalance();
        }

        private void InitData()
        {
            this.tbSupplyMainList = this.mSupplyMain.GetSupplyMainList;
            this.tbEntrySubList = this.mEntrySub.GetEntrySubList();
            this.GetSupplyMainInvoices = new Collection<tblSupplyMain>();
            this.GetEntrySubList = new Collection<tblEntrySub>();
        }

        private void CalculateBalance()
        {
            CalculateAssetBalance();
            CalculateSupplyMainBalance();
            CalculateEntrySubBalance();
        }

        private void CalculateAssetBalance()
        {
            foreach (var tbAsset in this.clsTbAsset.GetAssetOpeningBalanceByAccNo(this.splAccNo))
            {
                this.Debit += Convert.ToDouble(tbAsset.asDebit);
                this.Credit += Convert.ToDouble(tbAsset.asCredit);
            }
        }

        private void CalculateSupplyMainBalance()
        {
            var tbmain = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supAccNo == this.splAccNo
             && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd);
            //var tbmain = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supAccNo == this.splAccNo);
            foreach (var tbSupMain in tbmain)
            {
                if (tbSupMain.supStatus == 3 || tbSupMain.supStatus == 7)
                    this.Credit += (Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice) - Convert.ToDouble(tbSupMain.supDscntAmount));
                else if (tbSupMain.supStatus == 9 || tbSupMain.supStatus == 10)
                    this.Debit += (Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice) - Convert.ToDouble(tbSupMain.supDscntAmount));

                this.GetSupplyMainInvoices.Add(tbSupMain);
            }
        }

        private void CalculateEntrySubBalance1()
        {
            foreach (var tbEntSub in this.tbEntrySubList)
            {
                if (tbEntSub.entAccNo == this.splAccNo)
                {
                    if (tbEntSub.entStatus == 2 || tbEntSub.entStatus == 5)
                        this.Debit += Convert.ToDouble(tbEntSub.entDebit) + Convert.ToDouble(tbEntSub.entTaxPrice);
                    else if (tbEntSub.entStatus == 3 || tbEntSub.entStatus == 6)
                        this.Credit += Convert.ToDouble(tbEntSub.entCredit) + Convert.ToDouble(tbEntSub.entTaxPrice);

                    this.GetEntrySubList.Add(tbEntSub);
                }
            }
        }

        private void CalculateEntrySubBalance()
        {
            var tbmain = db.tblEntrySubs.Where(x => x.entBrnId == Session.CurBranch.brnId && x.entAccNo == this.splAccNo
             && x.entDate >= Session.CurrentYear.fyDateStart && x.entDate <= Session.CurrentYear.fyDateEnd);
            //var tbmain = db.tblEntrySubs.Where(x => x.entBrnId == Session.CurBranch.brnId && x.entAccNo == this.splAccNo);
            foreach (var tbEntSub in tbmain)
            {
                if (tbEntSub.entStatus == 2 || tbEntSub.entStatus == 5)
                    this.Debit += (Convert.ToDouble(tbEntSub.entDebit) + Convert.ToDouble(tbEntSub.entTaxPrice));
                else if (tbEntSub.entStatus == 3 || tbEntSub.entStatus == 6)
                    this.Credit += (Convert.ToDouble(tbEntSub.entCredit) + Convert.ToDouble(tbEntSub.entTaxPrice));

                this.GetEntrySubList.Add(tbEntSub);
            }
        }

        public void CalculatePeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            this.DebitPeriod = 0; this.CreditPeriod = 0;

            CalculateAssetPeriodOpnBalance(accNo, dtStart.Date, dtEnd.Date);
            CalculateSupplyMainPeriodBalance(accNo, dtStart.Date, dtEnd.Date);
            CalculateEntrySubPeriodBalance(accNo, dtStart.Date, dtEnd.Date);
        }

        private void CalculateAssetPeriodOpnBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            this.TblEntrySubPeriodList = new Collection<tblEntrySub>();

            foreach (var tbAsset in this.clsTbAsset.GetAssetOpeningBalanceByAccNo(accNo))
            {
                if (tbAsset.asDate >= dtStart && tbAsset.asDate <= dtEnd)
                {
                    this.DebitPeriod += Convert.ToDouble(tbAsset.asDebit);
                    this.CreditPeriod += Convert.ToDouble(tbAsset.asCredit);

                    this.TblEntrySubPeriodList.Add(new tblEntrySub()
                    {
                        entDebit = tbAsset.asDebit,
                        entCredit = tbAsset.asCredit,
                        entDate = tbAsset.asDate,
                        entDesc = "رصيد إفتتاحي"
                    });
                }
            }
        }

        private void CalculateSupplyMainPeriodBalance1(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            DateTime date;
            this.TblSupplyMainPeriodList = new Collection<tblSupplyMain>();

            foreach (var tbSupMain in this.tbSupplyMainList)
            {
                date = Convert.ToDateTime(tbSupMain.supDate).Date;
                if (tbSupMain.supAccNo == accNo && date >= dtStart && date <= dtEnd)
                {
                    if (tbSupMain.supStatus == 3 || tbSupMain.supStatus == 7)
                        this.CreditPeriod += ((Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice)) - Convert.ToDouble(tbSupMain.supDscntAmount));
                    else if (tbSupMain.supStatus == 9 || tbSupMain.supStatus == 10)
                        this.DebitPeriod += ((Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice)) - Convert.ToDouble(tbSupMain.supDscntAmount));

                    this.TblSupplyMainPeriodList.Add(tbSupMain);
                }
            }
        }

        private void CalculateSupplyMainPeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {

            this.TblSupplyMainPeriodList = new Collection<tblSupplyMain>();
            var tbSupMains = db.tblSupplyMains.ToList().FindAll(a => a.supBrnId == Session.CurBranch.brnId &&
            (a.supDate >= Session.CurrentYear.fyDateStart && a.supDate <= Session.CurrentYear.fyDateEnd) && a.supAccNo == accNo && a.supDate.Value.Date >= dtStart && a.supDate.Value.Date <= dtEnd);
            //var tbSupMains = db.tblSupplyMains.ToList().FindAll(a => a.supBrnId == Session.CurBranch.brnId && a.supAccNo == accNo 
            //&& a.supDate.Value.Date >= dtStart && a.supDate.Value.Date <= dtEnd);
            this.CreditPeriod += tbSupMains.Where(a => a.supStatus == 3 || a.supStatus == 7).Sum(a => ((Convert.ToDouble(a.supTotal) + Convert.ToDouble(a.supTaxPrice)) - Convert.ToDouble(a.supDscntAmount)));
            this.DebitPeriod += tbSupMains.Where(a => a.supStatus == 9 || a.supStatus == 10).Sum(a => ((Convert.ToDouble(a.supTotal) + Convert.ToDouble(a.supTaxPrice)) - Convert.ToDouble(a.supDscntAmount)));
            tbSupMains.ForEach(a => this.TblSupplyMainPeriodList.Add(a.ShallowCopy()));
            // this.TblSupplyMainPeriodList.ToList().AddRange(tbSupMains.ToList());
            //foreach (var tbSupMain in this.tbSupplyMainList)
            //{
            //    date = Convert.ToDateTime(tbSupMain.supDate).Date;
            //    if (tbSupMain.supAccNo == accNo && date >= dtStart && date <= dtEnd)
            //    {
            //        if (tbSupMain.supStatus == 3 || tbSupMain.supStatus == 7)
            //            this.CreditPeriod += ((Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice)) - Convert.ToDouble(tbSupMain.supDscntAmount));
            //        else if (tbSupMain.supStatus == 9 || tbSupMain.supStatus == 10)
            //            this.DebitPeriod += ((Convert.ToDouble(tbSupMain.supTotal) + Convert.ToDouble(tbSupMain.supTaxPrice)) - Convert.ToDouble(tbSupMain.supDscntAmount));

            //        this.TblSupplyMainPeriodList.Add(tbSupMain);
            //    }
            //}
        }

        private void CalculateEntrySubPeriodBalance(long accNo, DateTime dtStart, DateTime dtEnd)
        {
            // DateTime date;
            //this.TblEntrySubPeriodList = new Collection<tblEntrySub>();


            var tbEntSubs = db.tblEntrySubs.ToList().FindAll(a => a.entBrnId == Session.CurBranch.brnId && (a.entDate >= Session.CurrentYear.fyDateStart && a.entDate <= Session.CurrentYear.fyDateEnd) && a.entAccNo == accNo && a.entDate >= dtStart && a.entDate <= dtEnd);
            //var tbEntSubs = db.tblEntrySubs.ToList().FindAll(a => a.entBrnId == Session.CurBranch.brnId && a.entAccNo == accNo && a.entDate >= dtStart && a.entDate <= dtEnd);

            this.DebitPeriod += tbEntSubs.Where(a => a.entStatus == 2 || a.entStatus == 5 || a.entStatus == 1 || a.entStatus == 4)
                .Sum(a => Convert.ToDouble(a.entDebit) + Convert.ToDouble(a.entTaxPrice));
            this.CreditPeriod += tbEntSubs.Where(a => a.entStatus == 3 || a.entStatus == 6 || a.entStatus == 1 || a.entStatus == 4)
                .Sum(a => Convert.ToDouble(a.entCredit) + Convert.ToDouble(a.entTaxPrice));
            tbEntSubs.ForEach(a => this.TblEntrySubPeriodList.Add(a));
            //this.TblEntrySubPeriodList.ToList().AddRange(tbEntSubs);
            //foreach (var tbEntSub in this.tbEntrySubList)
            //{
            //    date = Convert.ToDateTime(tbEntSub.entDate).Date;
            //    if (tbEntSub.entAccNo == accNo && date >= dtStart && date <= dtEnd)
            //    {
            //        if (tbEntSub.entStatus == 2 || tbEntSub.entStatus == 5)
            //            this.DebitPeriod += Convert.ToDouble(tbEntSub.entDebit) + Convert.ToDouble(tbEntSub.entTaxPrice);
            //        else if (tbEntSub.entStatus == 3 || tbEntSub.entStatus == 6)
            //            this.CreditPeriod += Convert.ToDouble(tbEntSub.entCredit) + Convert.ToDouble(tbEntSub.entTaxPrice);

            //        this.TblEntrySubPeriodList.Add(tbEntSub);
            //    }
            //}
        }

        public double Debit { get; private set; } = 0;
        public double Credit { get; private set; } = 0;
        public double DebitPeriod { get; private set; }
        public double CreditPeriod { get; private set; }
        public ICollection<tblSupplyMain> GetSupplyMainInvoices { get; private set; }
        public ICollection<tblEntrySub> GetEntrySubList { get; private set; }
        public ICollection<tblSupplyMain> TblSupplyMainPeriodList { get; private set; }
        public ICollection<tblEntrySub> TblEntrySubPeriodList { get; private set; }
    }
}
