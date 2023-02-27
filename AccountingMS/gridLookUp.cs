using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.Data.OleDb;
using System.Linq;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;


namespace accounting_1._0
{
    class gridLookUp
    {
        public class AccNo
        {
            public long accNoAset { get; set; }
            public string accNameAset { get; set; }
        }
        List<AccNo> AccNos = new List<AccNo>();
        public void GridLoolUp()
        {
            
            accountingEntities2 db = new accountingEntities2();
            BindingSource bindingSourceAccNo = new BindingSource();
            var q1 = from a in db.tblAccounts
                     where a.accType == 2
                     select new
                     {
                         accNo = a.accNo,
                         accName = a.accName
                     };
            bindingSourceAccNo.DataSource = q1.ToList();
            AccNos.Add(new AccNo() { accNoAset = q1.First().accNo, accNameAset = q1.First().accName });
           
        }



    }
}
