using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_1._0
{
    class MeasurementData
    {
        accountingEntities2 db = new accountingEntities2();
        BindingSource bindingsourceMsur = new BindingSource();

        public void MsurNoLkUpEdt(DevExpress.XtraEditors.LookUpEdit msurNoLookUp)
        {
            InitData();
            msurNoLookUp.Properties.DataSource = bindingsourceMsur;
            msurNoLookUp.Properties.DisplayMember = "msurUnitMain";
            msurNoLookUp.Properties.ValueMember = "id";

            msurNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("msurUnitMain", "وحدة القياس", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }

        private void InitData()
        {
            var q1 = db.tblMeasurUnits.ToList();
            bindingsourceMsur.DataSource = q1;
        }

    }
}
