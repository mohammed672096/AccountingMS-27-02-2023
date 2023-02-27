using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class FormInventoryBalanceList : XtraForm
    {
        private accountingEntities db = new accountingEntities();

        private static FormInventoryBalanceList instance;
        public static FormInventoryBalanceList Instance { get { if (instance == null || instance.IsDisposed == true) instance = new FormInventoryBalanceList(); return instance; } }

        public FormInventoryBalanceList()
        {
            InitializeComponent();
        }
        private void FormInventoryBalanceList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.InventoryBalanceings.Where(x => x.BranchID == Session.CurBranch.brnId).ToList();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormInventoryBalance.Instance.ShowDialog();

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as InventoryBalanceing;
            if (row != null)
            {
                FormInventoryBalance form = new FormInventoryBalance(row.ID);
                form.ShowDialog();
                FormInventoryBalanceList_Load(null, null);
            }

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("تنبية", "هل تريد الحذف", MessageBoxButtons.YesNo) == DialogResult.No) return;
            var row = gridView1.GetFocusedRow() as InventoryBalanceing;
            if (row != null)
            {
                accountingEntities db = new accountingEntities();
                db.InventoryBalanceings.Remove(db.InventoryBalanceings.Find(row.ID));
                db.InventoryBalancingDetails.RemoveRange(db.InventoryBalancingDetails.Where(x => x.MainID == row.ID));
                db.SaveChanges();
                FormInventoryBalanceList_Load(null, null);
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { FormInventoryBalanceList_Load(null, null); }
    }
}
