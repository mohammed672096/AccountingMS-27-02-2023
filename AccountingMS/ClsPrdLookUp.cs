using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting_1._0
{
    class ClsPrdLookUp
    {
        accountingEntities2 db = new accountingEntities2();
        BindingSource bindSourcePrdNo = new BindingSource();

        public void GetPrdNo(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit prdtNoLookUp)
        {
            InitData();
            prdtNoLookUp.DataSource = bindSourcePrdNo;
            prdtNoLookUp.DisplayMember = "prdNo";
            prdtNoLookUp.ValueMember = "prdNo";

            prdtNoLookUp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("prdNo", "رقم الصنف", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("prdName", "إسم الصنف", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }

        private void InitData()
        {
            var q1 = from prd in db.tblProducts
                     select new
                     {
                         prdNo = prd.prdNo,
                         prdName = prd.prdName,
                         prdGrpNo = prd.prdGrpNo,
                         prdMsurId = prd.prdMsurId
                     };
            bindSourcePrdNo.DataSource = q1.ToList();
        }
    }
}
