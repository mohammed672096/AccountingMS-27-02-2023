using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class FrmRepCommission : DevExpress.XtraEditors.XtraForm
    {
        public FrmRepCommission()
        {
            InitializeComponent();
            refdata();
            gridView1.DoubleClick += GridView1_DoubleClick;

        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            RepCommission fa = gridView1.GetFocusedRow() as RepCommission;
            if (fa != null)
            {
                repCommissionBindingSource.DataSource = fa;
            }
        }
        bool Validation()
        {
            if (DisplayNameTextEdit.Text == "") { DisplayNameTextEdit.ErrorText = "This field is required"; return false; }
            if (commissionTextEdit.Text == "") { commissionTextEdit.ErrorText = "This field is required"; return false; }
            return true;
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void isActiveCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Validation() == false) return;
            using (accountingEntities db2 = new accountingEntities())
            {
                RepCommission repcom = new RepCommission();
                if (idTextEdit.Text != "0")
                    repcom = db2.RepCommissions.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));

                repcom.DisplayName = DisplayNameTextEdit.Text;
                repcom.commission = Convert.ToDouble(commissionTextEdit.EditValue);
                repcom.isActive = isActiveCheckEdit.Checked;
                repcom.Notes = NotesTextEdit.Text;
                if (idTextEdit.Text == "0")
                    db2.RepCommissions.Add(repcom);

                db2.SaveChanges();
                refdata();
                XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "ok, Saved successfully" : "تم الحفظ بنجاح ");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refdata();
        }
        void refdata()
        {
            using (accountingEntities db2 = new accountingEntities())
            {
                repCommissionBindingSource.DataSource = new RepCommission();
                gridControl1.DataSource = db2.RepCommissions.ToList();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (accountingEntities db2 = new accountingEntities())
            {
                if (idTextEdit.Text == "0" || idTextEdit.Text == "") return;
                if (gridView1.RowCount > 0)
                {
                    RepCommission repcomp = new RepCommission();
                    repcomp = db2.RepCommissions.ToList().FirstOrDefault(m => m.id == Convert.ToInt32(idTextEdit.Text));
                    db2.RepCommissions.Remove(repcomp);
                    db2.SaveChanges();
                    refdata();

                    XtraMessageBox.Show(MySetting.GetPrivateSetting.LangEng ? "Attention, Saved successfully" : "تم الحذف ");
                }
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refdata();
        }
    }
}
