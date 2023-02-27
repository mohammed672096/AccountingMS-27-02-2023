using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    class ClsLinQuery
    {
        BindingSource bindingSourceAccNo = new BindingSource();
        public void accNo(DevExpress.XtraEditors.LookUpEdit accNoLookUp)
        {
            InitData();
            accNoLookUp.Properties.DataSource = bindingSourceAccNo;
            accNoLookUp.Properties.DisplayMember = "accNo";
            accNoLookUp.Properties.ValueMember = "accNo";

            accNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accNo", "رقم الحساب", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accName", "إسم الحساب", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            accNoLookUp.Size = new System.Drawing.Size(50, 20);
        }

      

        private void InitData()
        {
            using (var db=new accountingEntities())
            {
                var q1 = from a in db.tblAccounts.AsNoTracking()
                         where /*a.accBrnId == Session.CurBranch.brnId && */a.accType == 2
                         select new
                         {
                             accNo = a.accNo,
                             accName = a.accName,
                             accCurrency = a.accCurrency
                         };

                bindingSourceAccNo.DataSource = q1.ToList();
            }
           
        }


    }
}
