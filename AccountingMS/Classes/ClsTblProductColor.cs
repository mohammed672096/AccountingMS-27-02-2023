using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblProductColor
    {
        public ClsTblProductColor()
        {
            if (Session.ProductColors.Count <= 0)
                Session.GetDataProductColors();
        }

        public IList<tblProductColor> GetProductColorList => Session.ProductColors;

        public int GetProductColorQuantById(byte colId)
        {
            return Session.ProductColors.Where(x => x.colId == colId).Select(x => x.colQuan).FirstOrDefault();
        }

        public string GetProductColorHtmlById(byte colId)
        {
            return Session.ProductColors.Where(x => x.colId == colId).Select(x => x.colHtml).FirstOrDefault();
        }

    }
}
