using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    class ClsTblCustomerInvoice
    {

        public ClsTblCustomerInvoice()
        {
            using (var db = new accountingEntities())
            {
                if (Session.CurrentUser.id == 1)
                {
                    if (Session.tbCustomerInvoiceList.Count != db.tblCustomerInvoices.AsNoTracking().Count())
                        Session.tbCustomerInvoiceList = db.tblCustomerInvoices.AsNoTracking().ToList();
                }
                else if (Session.tbCustomerInvoiceList.Count != db.tblCustomerInvoices.AsNoTracking().Where(x => x.invBrnId == Session.CurBranch.brnId).Count())
                    Session.tbCustomerInvoiceList = db.tblCustomerInvoices.AsNoTracking().Where(x => x.invBrnId == Session.CurBranch.brnId).ToList();
            }
        }
        public IEnumerable<tblCustomerInvoice> GetCustomerInvoiceList => Session.tbCustomerInvoiceList;

        public int GetCustomerIdByInvoiceId(int invId)
        {
            return (Session.tbCustomerInvoiceList?.FirstOrDefault(x => x.invSupId == invId)?.invCstId) ?? 0;
        }
    }
}
