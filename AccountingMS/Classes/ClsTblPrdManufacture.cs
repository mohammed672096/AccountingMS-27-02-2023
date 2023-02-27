using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblPrdManufacture
    {
        public ClsTblPrdManufacture()
        {
            Session.GetDataPrdManufacture();
        }
        public void RefreshData()
        {
            Session.GetDataPrdManufacture();
        }
        public IList<tblPrdManufacture> GetPrdManListByPrdId(int prdId)
        {
            return Session.PrdManufactures.Where(x => x.manPrdId == prdId).ToList();
        }
    }
}
