using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_1._0
{
    class StoreData
    {
        accountingEntities2 db = new accountingEntities2();
        BindingSource bindingsourceStore = new BindingSource();
        public void StoreNoLkUpEdt(DevExpress.XtraEditors.LookUpEdit accNoLookUp)
        {
            InitData();
            accNoLookUp.Properties.DataSource = bindingsourceStore;
            accNoLookUp.Properties.DisplayMember = "strName";
            accNoLookUp.Properties.ValueMember = "strNo";

            accNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strNo", "رقم المخزن", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strName", "إسم المخزن", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            accNoLookUp.Size = new System.Drawing.Size(100, 20);
        }

        private void InitData()
        {
            var q1 = db.tblStores.ToList();
            bindingsourceStore.DataSource = q1;
        }
    }
}
