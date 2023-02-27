using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_1._0
{
    class GroupData
    {
        accountingEntities2 db = new accountingEntities2();
        BindingSource bindingsourceGroup = new BindingSource();

        public void GroupNoLkUpEdt(DevExpress.XtraEditors.LookUpEdit grpNoLookUp)
        {
            InitData();
            grpNoLookUp.Properties.DataSource = bindingsourceGroup;
            grpNoLookUp.Properties.DisplayMember = "grpName";
            grpNoLookUp.Properties.ValueMember = "grpNo";

            grpNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grpNo", "رقم المجموعة", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grpName", "إسم المجموعة", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }

        private void InitData()
        {
            var q1 = db.tblGroupStrs.ToList();
            bindingsourceGroup.DataSource = q1;
        }
    }
}
