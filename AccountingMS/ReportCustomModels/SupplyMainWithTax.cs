using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS.ReportCustomModels
{
    public class SupplyMainWithTax
    {
        public int Number { get; set; }
        public int Code { get; set; }
        public string DocName { get; set; }
        public string PartName { get; set; }
        public string RefNumber { get; set; }
        public string TaxNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Net => Total + Tax - Discount;
        public short BranchId { get; set; }

        public static List<SupplyMainWithTax> GetSupplyList(DateTime startDate, DateTime EndDate, SupplyType type,short Branch)
        {
            using (accountingEntities db = new accountingEntities())
            {
                var CustomersAndSupplayer = db.tblCustomers.Where(x => x.custBrnId == Branch || Branch == 0).Select(x => new { x.id, Type = (byte)SupplyType.SalesPhase, Name = x.custName, TaxNumber = x.custTaxNo });
                CustomersAndSupplayer = CustomersAndSupplayer
                    .Concat(db.tblSuppliers.Where(x => x.splBrnId == Branch|| Branch==0).Select(x => new { x.id, Type = (byte)SupplyType.PurchasePhase, Name = x.splName, TaxNumber = x.splTaxNo }));

                var invoiceRowDate =
                    from inv in db.tblSupplyMains.Where(x => (x.supBrnId == Branch || Branch == 0) && x.supStatus == (byte)type && x.supDate >= startDate && x.supDate <= EndDate && x.supTaxPrice > 0)
                    from supInv in db.tblSupplierInvoices.Where(x =>(x.invBrnId == Branch || Branch == 0) && x.invSupId == inv.id && inv.supStatus == (byte)SupplyType.PurchasePhase).Select(x => (int?)x.invSplId).DefaultIfEmpty()
                    select new
                    {
                        inv.MainNo,
                        inv.supNo,
                        inv.supRefNo,
                        PartID = supInv ?? inv.supCustSplId,
                        inv.supDate,
                        inv.supTotal,
                        inv.supDscntAmount,
                        inv.supTaxPrice,
                        inv.supBrnId
                    };
                var data = (from inv in invoiceRowDate.OrderBy(x => x.supDate)
                            from part in CustomersAndSupplayer.Where(x => x.id == inv.PartID && x.Type == (byte)type).DefaultIfEmpty()
                            select new SupplyMainWithTax
                            {   Number=inv.MainNo.Value,
                                Code = inv.supNo,
                                RefNumber = inv.supRefNo,
                                DocName = (type == SupplyType.SalesPhaseRtrn) ? "مردود مبيعات" : (type == SupplyType.SalesPhase) ? "مبيعات" : (type == SupplyType.PurchasePhase) ? "مشتريات" : (type == SupplyType.PurchasePhaseRtrn) ? "مردود مشتريات" : "",
                                Discount = inv.supDscntAmount ?? 0,
                                InvoiceDate = inv.supDate,
                                PartName = (part != null) ? part.Name : "",
                                Tax = inv.supTaxPrice ?? 0,
                                TaxNumber = (part != null) ? part.TaxNumber : "",
                                Total = inv.supTotal,
                                BranchId=inv.supBrnId.Value
                            }).OrderBy(x=>x.Number).ToList();
                return data;
            }
        }

    }
}
