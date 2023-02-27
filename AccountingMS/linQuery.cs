    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Dynamic;

namespace accounting_1._0
{
    class linQuery
    {
        accountingEntities2 db = new accountingEntities2();
        BindingSource bindingSourceAccNo = new BindingSource();
        BindingSource bindingSourceBoxNo = new BindingSource();
        BindingSource bindingSourceEntry = new BindingSource();
        BindingSource bindingSourceEntrySub = new BindingSource();

        public int custNoLq { set; get; }
        public string custNameLq { set; get; }

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

        public Boolean InitDataCustAcc (Int64 custAccNo)
        {
            var q1 = from cust in db.tblCustomers
                     select new
                     {
                         custAccNo = cust.custAccNo,
                         custNo = cust.custNo,
                         custName = cust.custName
                     };

            foreach (var cust in q1)
            {
                if (cust.custAccNo == custAccNo)
                {
                    custNoLq = cust.custNo;
                    custNameLq = cust.custName;
                    return true;
                }
            }
            return false;
        }

        public void AccNoGrid(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            InitData();
            repositoryItemLookUpEdit.DataSource = bindingSourceAccNo;
            repositoryItemLookUpEdit.DisplayMember = "accNo";
            repositoryItemLookUpEdit.ValueMember = "accNo";

            repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accNo", "رقم الحساب", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accName", "إسم الحساب", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }

        private void InitData()
        {
            var q1 = from a in db.tblAccounts
                     where a.accType == 2
                     select new
                     {
                         accNo = a.accNo,
                         accName = a.accName,
                         accCurrency = a.accCurrency
                     };

            bindingSourceAccNo.DataSource = q1.ToList();
        }

        public void BoxNo(DevExpress.XtraEditors.LookUpEdit boxNoLookUp)
        {
            InitDataBox();
            boxNoLookUp.Properties.DataSource = bindingSourceBoxNo;
            boxNoLookUp.Properties.DisplayMember = "boxNo";
            boxNoLookUp.Properties.ValueMember = "boxNo";
            boxNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxNoLookUp.Size = new System.Drawing.Size(50, 20);
        }

        private void InitDataBox()
        {
            var q1 = from a in db.tblAccountBoxes
                     select new
                     {
                         boxNo = a.boxNo,
                         boxName = a.boxName,
                         boxAccNo = a.boxAccNo
                     };

            bindingSourceBoxNo.DataSource = q1.ToList();
            XtraMessageBox.Show("ohNo");
        }

        public string AccNoName (Int64 accNoName)
        {
            var q = from an in db.tblAccounts
                    where an.accNo == accNoName
                    select new
                    {
                        accName = an.accName
                    };
            string value = q.First().accName;
            return value;
        }
        public int EntNo()
        {
            int entValue = 0;

            entValue = (from em in db.tblEntryMains
                        orderby em.entNo descending
                        select em.entNo).First();
            return entValue + 1;
        }

        public BindingSource entryQuery(short stat)
        {
            var q = from r in db.tblEntryMains
                    where r.entStatus == stat
                    select r;
            bindingSourceEntry.DataSource = q.ToList();
            return bindingSourceEntry;
        }

        public BindingSource entrySubQuery(long cellValue)
        {
            var q = from r in db.tblEntrySubs
                    where r.entNo == cellValue
                    select r;
            bindingSourceEntrySub.DataSource = q.ToList();
            return bindingSourceEntrySub;
        }
        
    }
}
