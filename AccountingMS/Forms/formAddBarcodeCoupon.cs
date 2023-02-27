using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace AccountingMS.Forms
{
    public partial class formAddBarcodeCoupon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        public formAddBarcodeCoupon()
        {
            InitializeComponent();

            gridControl1.DataSource = db.CouponBarcodes.ToList();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Convert.ToDouble( couponPriceTextEdit.Text.ToString() ) <=0)
            {
                MessageBox.Show("ادخل قسيمة الخصم");
                return;
            }
            if (dateExpirDateEdit.Text =="")
            {
                MessageBox.Show("ادخل اسم قسيمة الخصم ");
                return;
            }
            
            
            for (int i = 0; i < Convert.ToInt32(countbarcodetextEdit.Text); i++)
            {
                CouponBarcode coup = new CouponBarcode();
                coup.CouponName = CouponNameTextEdit.Text;
                coup.BarCode = DateTime.Now.ToString("yyMMd") + i.ToString() + DateTime.Now.TimeOfDay.ToString("hhmmss");
                coup.IsDefault = true;
                coup.dateExpir = Convert.ToDateTime(dateExpirDateEdit.EditValue);
                coup.couponPrice = Convert.ToDecimal(couponPriceTextEdit.EditValue);
                coup.OffersID = 3;
                
                db.CouponBarcodes.Add(coup);
                db.SaveChanges();


            }
            MessageBox.Show("تم الحفظ بنجاح");
            gridControl1.DataSource = db.CouponBarcodes.ToList();//.Where(s => s.DiscountType == DiscountTypeLookUpEdit.SelectedIndex);

        }

        private void btnprintcouponBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formBarcodeCoupon frm = new formBarcodeCoupon();
            frm.ShowDialog();
        }

        private void repositorycoldeletBarcodeuttonEdit_Click(object sender, EventArgs e)
        {


        }

        private void repositorycoldeletBarcodeuttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //حذف باركود
            // CouponBarcode delbarcode = new CouponBarcode();
            var delbarcode = db.CouponBarcodes.ToList().SingleOrDefault(a => a.BarCode == Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BarCode")));
            db.CouponBarcodes.Remove(delbarcode);
            db.SaveChanges();
            gridControl1.DataSource = db.CouponBarcodes.ToList();


        }

        private void formAddBarcodeCoupon_Load(object sender, EventArgs e)
        {
            dateExpirDateEdit.EditValue = DateTime.Now;
        }
    }
}