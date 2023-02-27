using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_1._0
{
    class CustData
    {
        //public int CustNo { set; get; }
        //public string CustName { set; get; }

        BindingSource bindSourceCustNo = new BindingSource();
        accountingEntities2 db = new accountingEntities2();

        public void GetCustNo (DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit custNoLookUp)
        {
            InitData();
            custNoLookUp.DataSource = bindSourceCustNo;
            custNoLookUp.DisplayMember = "cstNo";
            custNoLookUp.ValueMember = "cstNo";

            custNoLookUp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cstNo", "رقم العميل", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cstName", "إسم العميل", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }

        private void InitData()
        {
            var q1 = from cst in db.tblCustomers
                     select new
                     {
                         cstNo = cst.custNo,
                         cstName = cst.custName,
                         cstAccNo = cst.custAccNo,
                         cstAccName = cst.custAccName
                     };
            bindSourceCustNo.DataSource = q1.ToList();
        }
    }
}
