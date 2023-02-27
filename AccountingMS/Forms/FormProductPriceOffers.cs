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
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace AccountingMS.Forms
{

    public partial class FormProductPriceOffers : DevExpress.XtraEditors.XtraForm
    {

        accountingEntities db = new accountingEntities();
        // accountingEntities db2 = new accountingEntities();

        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsProductByStore clsPrdStore;
        tblBarcode tbBarcode;
        ClsTblBarcode clsTbBarcode;

        int maId = 25922910;
        private IEnumerable<tblPrdPriceMeasurment> QueryData => db.tblPrdPriceMeasurments.AsQueryable()
               .Where(x => x.ppmBrnId == Session.CurBranch.brnId).OrderBy(x => x.ppmPrdId);
        public FormProductPriceOffers()
        {
            InitializeComponent();

            InitObjects(clsTbStore, clsTbProduct, clsTbPrdMsur);
            StoreIdLookUpEdit.EditValueChanged += StoreIdLookUpEdit_EditValueChanged;
            invBarcodeTextEdit.KeyDown += InvBarcodeTextEdit_KeyDown;

            //AccountingMS.accountingEntities dbContext = new AccountingMS.accountingEntities();
            //dbContext.OffersProducts.LoadAsync().ContinueWith(loadTask =>
            //{
            //    // Bind data to control when loading complete
            //    combProduct.Properties.DataSource = dbContext.OffersProducts.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void InitObjects(ClsTblStore clsTbStore, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            this.clsTbStore = clsTbStore;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
            this.clsTbBarcode = new ClsTblBarcode();
        }
        private void InvBarcodeTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(invBarcodeTextEdit.Text)) return;
            if (string.IsNullOrWhiteSpace(StoreIdLookUpEdit.Text))
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Choose the store first" : "اختر المخزن أولا");
                return;
            }
            if (string.IsNullOrWhiteSpace(StoreIdLookUpEdit.EditValue.ToString())) return;


            SearchBarcodeData(invBarcodeTextEdit.Text);

            // invBarcodeTextEdit.EditValue = null;
        }

        private bool ValidateBarcode(string barcodeNo)
        {
            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcodeNo);

            bool isValid = this.tbBarcode != null ? true : false;

            if (!isValid)
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found!" : "عذراً لم يتم العثور على الصنف المطلوب!");

            return isValid;
        }
        private void SearchBarcodeData(string barcodeNo)
        {
            if (!ValidateBarcode(barcodeNo)) return;
            var prod = GetPrdPriceMsurObjById(this.tbBarcode.brcPrdMsurId);
            prdNoTextEdit.EditValue = prod.ppmPrdId;

        }
        public tblPrdPriceMeasurment GetPrdPriceMsurObjById(int msurId)
        {
            return QueryData.FirstOrDefault(x => x.ppmId == msurId);
        }

        private void StoreIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor == null) return;

            short strId = Convert.ToInt16(editor.GetColumnValue("id"));
            InitPrdBindingSoruceData(strId);
        }
        private void InitPrdBindingSoruceData(short strId)
        {
            tblProductBindingSource.DataSource = db.tblProducts.ToList().
                             Where(b => b.prdBrnId == strId);
            //repositoryItemLookUpEdit2.DataSource = db.tblProducts.ToList().
            //                 Where(b => b.prdBrnId == strId);

        }

        private void FormProductPriceOffers_Load(object sender, EventArgs e)
        {
            StoreIdLookUpEdit.Properties.DataSource = (from Sto in db.tblStores.ToList() select new { id = Sto.id, strName = Sto.strName });
            StoreIdLookUpEdit.Properties.DisplayMember = "strName";
            StoreIdLookUpEdit.Properties.ValueMember = "id";
            layoutControlGroup3.Visibility = LayoutVisibility.Never;
            StartDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            ExpireDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            CustmerStartDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            CustmerEndDateDateEdit.EditValue = DateTime.Now.ToString("yyyy/MM/dd");


            DiscountTypeLookUpEdit.Properties.Items.AddRange(DiscountTypeList);
            DiscountTypeLookUpEdit.SelectedIndex = 0;

            radioGroup1.Properties.Items.AddRange(StateTypeList);
            radioGroup1.SelectedIndex = 0;
            stateAndDescName();
            maxOffersProducts();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stateAndDescName();
            if (DiscountTypeLookUpEdit.SelectedIndex == 0)
            {
                if (Convert.ToDateTime(StartDateDateEdit.EditValue) > Convert.ToDateTime(ExpireDateDateEdit.EditValue) && Convert.ToDateTime(StartDateDateEdit.EditValue) < DateTime.Now)
                {
                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, Make sure to enter the date" : "تأكد من ادخال التاريخ");
                    return;
                }
                if (showNametextEdit.Text == "")
                {
                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, Enter a name to view the discount" : "ادخل اسم لعرض الخصم");
                    return;
                }
                //int count = ((IList)combProduct.Properties.DataSource).Count;
                if (Convert.ToInt32(labelControl1.Text) <= 0)
                {
                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, Choose the product first and then click Add" : "اختر الصنف أولا ثم اضغط اضافة");

                    return;
                }
                //if (combProduct.Controls.Count <=0)
                //{
                //    MessageBox.Show("ادخل الصنف أولا");
                //    return;
                //}
                //else
                //{
                //    var oferrid = db.tblProductPriceOffers.FirstOrDefault(e => e.prdNo == prdNoTextEdit.EditValue.ToString());
                //    if (oferrid != null)
                //    {
                //        db.tblProductPriceOffers.Remove(oferrid);
                //        db.SaveChanges();
                //    }
                //}

            }
            else
            {

                var oferrid = db.tblProductPriceOffers.FirstOrDefault(e => e.DiscountType == DiscountTypeLookUpEdit.SelectedIndex);
                if (oferrid != null)
                {
                    db.tblProductPriceOffers.Remove(oferrid);
                    db.SaveChanges();
                }
            }


            tblProductPriceOffer oferr = new tblProductPriceOffer();
            //oferr.StoreId = Convert.ToInt32(StoreIdLookUpEdit.EditValue);
            //oferr.prdNo = Convert.ToString(prdNoTextEdit.EditValue);
            oferr.id = db.tblProductPriceOffers.Count() + 1;
            oferr.ShowName = Convert.ToString(showNametextEdit.EditValue);
            oferr.DiscountType = DiscountTypeLookUpEdit.SelectedIndex;
            oferr.DiscountName = DescName;
            oferr.State = radioGroup1.SelectedIndex;
            oferr.StateName = stateName;
            switch (radioGroup1.SelectedIndex)
            {

                case 0:

                    break;
                case 1:

                    oferr.StartDate = Convert.ToDateTime(StartDateDateEdit.EditValue);
                    oferr.ExpireDate = Convert.ToDateTime(ExpireDateDateEdit.EditValue);
                    if (DiscountTypeLookUpEdit.SelectedIndex == 2)
                    {
                        oferr.CustmerStartDate = Convert.ToDateTime(CustmerStartDateDateEdit.EditValue);
                        oferr.CustmerEndDate = Convert.ToDateTime(CustmerEndDateDateEdit.EditValue);
                    }
                    break;
                case 2:

                    break;
                default:
                    break;
            }


            if (DiscountTypeLookUpEdit.SelectedIndex == 0)
            {
                oferr.Quantity = Convert.ToInt32(QuantityTextEdit.EditValue);
            }
            else
            {
                oferr.TotalFatora = Convert.ToDouble(TotalFatoraTextEdit.EditValue);
            }
            oferr.Price = Convert.ToDouble(PriceTextEdit.EditValue);
            oferr.Notes = Convert.ToString(NotesTextEdit.EditValue);

            oferr.Date = DateTime.Now;
            db.tblProductPriceOffers.Add(oferr);
            db.SaveChanges();
            ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Ok, Saved successfully" : "تم الحفظ بنجاح");

            if (DiscountTypeLookUpEdit.SelectedIndex == 0)
            {
                int maId = 25922910;
                var idppo = db.tblProductPriceOffers.Max(m => m.id);
                var ppoOffersID = db.OffersProducts.ToList().Where(m => m.OffersID == maId);
                if (ppoOffersID.Count() > 0)
                {

                    foreach (var ma in ppoOffersID)
                    {
                        ma.OffersID = idppo;
                        db.SaveChanges();
                    }

                }
                //if (ppoOffersID!=null)
                //{
                //    ppoOffersID.OffersID = idppo;
                //    db.SaveChanges();
                //}
            }


            //foreach (var h in prdNoTextEdit.ItemIndex() )
            //{
            //    OffersProduct pf = new OffersProduct();
            //    pf.productName = h.ToString();
            //    pf.OffersID = idppo;

            //}
            gridControl1.DataSource = db.tblProductPriceOffers.ToList().Where(s => s.DiscountType == DiscountTypeLookUpEdit.SelectedIndex);
            maxOffersProducts();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Close();
        }
        public RadioGroupItem[] DiscountTypeList ={
                new RadioGroupItem() { Value = (int)DiscountType.OnProduct  , Description  =(MySetting.GetPrivateSetting.LangEng)?"product discount":"خصم على المنتج" },
                new RadioGroupItem() { Value = (int)DiscountType.OnInvoice  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Warning":"خصم على الفاتورة" },
                new RadioGroupItem() { Value = (int)DiscountType.OnCustomer  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Discount on customer bills for a period":"خصم على فواتير عميل عن فترة" },
                new RadioGroupItem() { Value = (int)DiscountType.Coupon  , Description  =(MySetting.GetPrivateSetting.LangEng)?"discount voucher":"قسيمة خصم" },

        };

        public RadioGroupItem[] StateTypeList ={
                new RadioGroupItem() { Value = (int)DiscountType.OnProduct  , Description  =(MySetting.GetPrivateSetting.LangEng)?"permanent":"دائم" },
                new RadioGroupItem() { Value = (int)DiscountType.OnInvoice  , Description  =(MySetting.GetPrivateSetting.LangEng)?"during a period of time":"خلال فترة" },
                new RadioGroupItem() { Value = (int)DiscountType.OnCustomer  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Inactive":"غير نشط" },
        };

        private string stateName;
        private string DescName;
        private void stateAndDescName()
        {
            switch (DiscountTypeLookUpEdit.SelectedIndex)
            {
                case 0: DescName = "خصم على المنتج"; break;
                case 1: DescName = "خصم على الفاتورة"; break;
                case 2: DescName = "خصم على فواتير عميل عن فترة"; break;
                case 3: DescName = "قسيمة خصم"; break;
                default:
                    break;
            }
            switch (radioGroup1.SelectedIndex)
            {
                case 0: stateName = "دائم"; break;
                case 1: stateName = "خلال فترة"; break;
                case 2: stateName = "غير نشط"; break;
                default:
                    break;
            }

        }
        private void DiscountTypeLookUpEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DiscountTypeLookUpEdit.SelectedIndex)
            {
                case 0://خصم على منتج
                    layoutControlPrdStr.Visibility = LayoutVisibility.Always;
                    layoutNameSHow.Visibility = LayoutVisibility.Always;
                    ItemForTotalFatora.Visibility = LayoutVisibility.Never;
                    ItemForQuantity.Visibility = LayoutVisibility.Always;
                    layoutControlCustmerFatora.Visibility = LayoutVisibility.Never;
                    layoutControlItem1.Visibility = LayoutVisibility.Never;
                    gridControl1.DataSource = db.tblProductPriceOffers.ToList().Where(s => s.DiscountType == 0);
                    colShowName.Visible = true;
                    colQuantity.Visible = true;
                    colTotalFatora.Visible = false;
                    colCustmerStartDate.Visible = false;
                    colCustmerEndDate.Visible = false;
                    break;
                case 1://خصم على الفاتورة
                    layoutControlPrdStr.Visibility = LayoutVisibility.Never;
                    layoutNameSHow.Visibility = LayoutVisibility.Never;
                    ItemForTotalFatora.Visibility = LayoutVisibility.Always;
                    ItemForQuantity.Visibility = LayoutVisibility.Never;
                    layoutControlCustmerFatora.Visibility = LayoutVisibility.Never;
                    layoutControlItem1.Visibility = LayoutVisibility.Never;
                    gridControl1.DataSource = db.tblProductPriceOffers.ToList().Where(s => s.DiscountType == 1);
                    colShowName.Visible = false;
                    colQuantity.Visible = false;
                    colTotalFatora.Visible = true;
                    colCustmerStartDate.Visible = false;
                    colCustmerEndDate.Visible = false;

                    break;
                case 2://خصم على اجمالى فواتير عميل عن فترة
                    layoutControlCustmerFatora.Visibility = LayoutVisibility.Always;
                    layoutControlPrdStr.Visibility = LayoutVisibility.Never;
                    layoutNameSHow.Visibility = LayoutVisibility.Never;
                    ItemForTotalFatora.Visibility = LayoutVisibility.Always;
                    ItemForQuantity.Visibility = LayoutVisibility.Never;
                    layoutControlItem1.Visibility = LayoutVisibility.Never;
                    gridControl1.DataSource = db.tblProductPriceOffers.ToList().Where(s => s.DiscountType == 2);
                    colShowName.Visible = false;
                    colQuantity.Visible = false;
                    colTotalFatora.Visible = true;
                    colCustmerStartDate.Visible = true;
                    colCustmerEndDate.Visible = true;

                    break;
                case 3://قسيمة خصم
                    layoutControlCustmerFatora.Visibility = LayoutVisibility.Never;
                    layoutNameSHow.Visibility = LayoutVisibility.Never;
                    layoutControlPrdStr.Visibility = LayoutVisibility.Never;
                    ItemForTotalFatora.Visibility = LayoutVisibility.Never;
                    ItemForQuantity.Visibility = LayoutVisibility.Never;
                    layoutControlItem1.Visibility = LayoutVisibility.Always;
                    gridControl1.DataSource = db.tblProductPriceOffers.Where(s => s.DiscountType == 3).ToList();
                   
                    colShowName.Visible = false;
                    colQuantity.Visible = false;
                    colTotalFatora.Visible = false;
                    colCustmerStartDate.Visible = false;
                    colCustmerEndDate.Visible = false;

                    break;

                default:
                    break;
            }

            //if (DiscountTypeLookUpEdit.SelectedIndex == 0)
            //{

            //}
            //else
            //{

            //}
        }

        private void barcodeCouponButton_Click(object sender, EventArgs e)
        {
            formAddBarcodeCoupon frm = new formAddBarcodeCoupon();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formAddBarcodeCoupon frm = new formAddBarcodeCoupon();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formBarcodeCoupon frm = new formBarcodeCoupon();
            //frm. SearchProduct("0");
            frm.ShowDialog();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //التعديلات
            //  DiscountTypeLookUpEdit.EditValue= gridView1.SetFocusedRowCellValue(, "")

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //int count = ((IList)combProduct.Properties.DataSource).Count;
            //if (count <= 0)
            //{
            //    MessageBox.Show("  اختر الصنف أولا ثم اضغط اضافة");
            //    return;
            //}
            if (prdNoTextEdit.Text == "")
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Choose the product first" : "اختر الصنف أولا");

                return;
            }



            var serchProduct = db.OffersProducts.ToList().FirstOrDefault(t => t.productID == Convert.ToInt32(prdNoTextEdit.EditValue) && t.OffersID == maId);
            if (serchProduct != null)
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, This item has been produced by" : "تم اضافة هذا الصنف من قبل");
                return;
            }
            OffersProduct proOffer = new OffersProduct();
            // combProduct.Controls.Add(prdNoTextEdit.EditValue,"");

            proOffer.productID = Convert.ToInt32(prdNoTextEdit.EditValue);
            proOffer.productName = prdNoTextEdit.Text;
            proOffer.OffersID = Convert.ToInt32(maId);
            db.OffersProducts.Add(proOffer);
            db.SaveChanges();
            ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Ok, The product has been successfully added to the offer" : "تم اضافة الصنف الى العرض بنجاح");
            maxOffersProducts();

        }

        void maxOffersProducts()
        {
            var testoffr = db.OffersProducts.ToList().Where(a => a.OffersID == maId);
            //if (testoffr.Count()>0)
            //{
            combProduct.Properties.DataSource = testoffr;
            //var count1 = Convert.ToInt32(((IList)combProduct.Properties.DataSource).Count);
            labelControl1.Text = Convert.ToString(testoffr.Count());
            //}
            //else
            //{
            //    labelControl1.Text = "0";
            //}

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (combProduct.Text == "")
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, Select from the list the product you want to delete" : "حدد من قائمة اصناف العرض الذى تريد حذفة");
                return;
            }
            else
            {

                var serchProduct = db.OffersProducts.ToList().SingleOrDefault(t => t.productID == Convert.ToInt32(combProduct.EditValue) && t.OffersID == Convert.ToInt32(maId));
                if (serchProduct == null) return;

                db.OffersProducts.Remove(serchProduct);
                db.SaveChanges();
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Ok, This item has been removed from this offer" : "تم حذف الصنف من هذا العرض");
                maxOffersProducts();

            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                layoutControlGroup3.Visibility = LayoutVisibility.Always;
                colStartDate.Visible = true;
                colExpireDate.Visible = true;
            }
            else
            {
                layoutControlGroup3.Visibility = LayoutVisibility.Never;
                colStartDate.Visible = false;
                colExpireDate.Visible = false;
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(colid) == null) return;
            string mssg = ((!MySetting.GetPrivateSetting.LangEng ? "هل انت متاكد من حذف هذا العرض : " : "Are you sure to delete this offer: "));
            if (XtraMessageBox.Show(mssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colid));

            var offerdel = db.OffersProducts.ToList().Find(m => m.OffersID == id);
            if (offerdel != null)
                db.OffersProducts.Remove(offerdel);
            //db.SaveChanges();
            var delshow = db.tblProductPriceOffers.Find(id);
            if (delshow != null)
                db.tblProductPriceOffers.Remove(delshow);
            db.SaveChanges();
            gridControl1.DataSource = db.tblProductPriceOffers.ToList().Where(s => s.DiscountType == DiscountTypeLookUpEdit.SelectedIndex);
        }


    }
}
