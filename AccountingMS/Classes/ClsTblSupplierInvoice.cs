using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    class ClsTblSupplierInvoice
    {
        public ClsTblSupplierInvoice()
        {
            Session.GetDatatblSupplierInvoice();
        }

        public IEnumerable<tblSupplierInvoice> GetSupplierInvoiceList => Session.tbSupplierInvoiceList;

        public int GetSupplierIdByInvoiceId(int invId)
        {
            tblSupplierInvoice tb = Session.tbSupplierInvoiceList.Where(x => x.invSupId == invId).FirstOrDefault();
            return (tb != null) ? tb.invSplId : 0;
        }
    }
}
