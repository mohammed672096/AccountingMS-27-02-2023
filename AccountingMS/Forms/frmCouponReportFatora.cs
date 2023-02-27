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
using System.Data.Entity;
using DevExpress.XtraLayout.Utils;

namespace AccountingMS.Forms
{
    public partial class frmCouponReportFatora : DevExpress.XtraEditors.XtraForm
    {
        //  accountingEntities db = new accountingEntities();
        public frmCouponReportFatora()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            datafill();
        }

        public void datafill()
        {
            using (accountingEntities db = new accountingEntities())
            {
                try
                {
                    gridControl1.DataSource = null;
                    showcop();
                    DateTime datestar = Convert.ToDateTime(datefirt.EditValue).Date;
                    DateTime dateend = Convert.ToDateTime(datelast.EditValue).Date;
                    if (fatoracheckEdit1.Checked == true)
                    {
                        if (radioGroup1.SelectedIndex == 0)
                        {
                            gridControl1.DataSource = db.CouponBarcodes.Where(a => a.IsDefault == false && a.dateExpir.Value.Date >= datestar && a.dateExpir.Value.Date <= dateend).ToList();
                        }
                        else
                        {
                            if (textEdit1.Text != "")
                                gridControl1.DataSource = db.CouponBarcodes.Where(a => a.CouponName == textEdit1.Text && a.IsDefault == false && a.dateExpir.Value.Date >= datestar && a.dateExpir.Value.Date <= dateend).ToList();
                            else
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Choose one of the coupon offers" : "اختر احد عروض القسيمة");
                        }
                    }
                    else
                    {

                        if (radioGroup1.SelectedIndex == 0)
                        {
                            gridControl1.DataSource = db.CouponBarcodes.Where(a => a.dateExpir.Value.Date >= datestar && a.dateExpir.Value.Date <= dateend).ToList();
                        }
                        else
                        {
                            if (textEdit1.Text != "")
                                gridControl1.DataSource = db.CouponBarcodes.Where(a => a.CouponName == textEdit1.Text && a.dateExpir.Value.Date >= datestar && a.dateExpir.Value.Date <= dateend).ToList();
                            else
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Choose one of the coupon offers" : "اختر احد عروض القسيمة");
                        }
                    }

                }
                catch (Exception)
                {

                }
            }

        }

        private void frmCouponReportFatora_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            datefirt.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            datelast.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            using (accountingEntities db = new accountingEntities())
            {
                var q = (from c in db.CouponBarcodes select new { c.id, c.CouponName });
                textEdit1.Properties.DataSource = q.Select(c => c.CouponName).Distinct().ToList();
                showcop();
            }
        }

        void showcop()
        {
            if (radioGroup1.SelectedIndex == 0)
                layoutControlItem5.Visibility = LayoutVisibility.Never;
            else
                layoutControlItem5.Visibility = LayoutVisibility.Always;


        }

        private void textEdit1_Click(object sender, EventArgs e)
        {


        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void datefirt_EditValueChanged(object sender, EventArgs e)
        {
            datafill();

        }

        private void fatoracheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.Print();
        }
    }
}