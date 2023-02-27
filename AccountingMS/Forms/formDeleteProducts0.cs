using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDeleteProducts0 : DevExpress.XtraEditors.XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblProductQunatity clsTbPrdQuantity;
        ClsTblPrdPriceMeasurment clsTbPrdPriceMsur;
        IList<tblProductData> tbProducDatatList;

        public formDeleteProducts0(ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdPriceMsur)
        {
            InitializeComponent();
            InitObjects(clsTbProduct, clsTbPrdPriceMsur);
        }

        private void InitObjects(ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdPriceMsur)
        {
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdPriceMsur = clsTbPrdPriceMsur;
            this.clsTbPrdQuantity = new ClsTblProductQunatity();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            SearchProducts0();
            SetLabelCount();
            flyDialog.WaitForm(this, 0);
        }

        private void BtnSearchPrdPrice0_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            SearchProductsPrice0();
            SetLabelCount();
            flyDialog.WaitForm(this, 0);
        }

        private void BtnSearhcPrdSalePrice0_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            SearchProductsSalePrice0();
            SetLabelCount();
            flyDialog.WaitForm(this, 0);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"هل انت متاكد من حذف {this.tbProducDatatList.Count():#,#} صنف ؟", "حذف الاصناف", MessageBoxButtons.YesNo)
                != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            if (this.clsTbProduct.DeleteProductsByProductDataList(this.tbProducDatatList) && this.clsTbPrdPriceMsur.DeletePrdPriceMsutByProductDataList
                (this.tbProducDatatList) && this.clsTbPrdQuantity.DeleteProductsByProductDataList(this.tbProducDatatList))
            {
                flyDialog.WaitForm(this, 0);
                DialogResult = DialogResult.OK;
            }
        }

        private void SetLabelCount()
        {
            labelCount.Text = $"العدد : {this.tbProducDatatList.Count():#,#}";
            labelCount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void SearchProducts0()
        {
            this.tbProducDatatList = (from prdPriceMsur in this.clsTbPrdPriceMsur.GetPrdPriceMsurList
                                      where prdPriceMsur.ppmPrice == 0 && prdPriceMsur.ppmSalePrice == 0
                                      join product in this.clsTbProduct.GetProductList
                                      on prdPriceMsur.ppmPrdId equals product.id
                                      select new tblProductData
                                      {
                                          id = product.id,
                                          prdName = product.prdName,
                                          ppmBarcode11 = prdPriceMsur.ppmBarcode1,
                                          ppmPrice1 = prdPriceMsur.ppmPrice,
                                          ppmSalePrice1 = prdPriceMsur.ppmSalePrice
                                      }).ToList();
            tblProductDataBindingSource.DataSource = this.tbProducDatatList;
        }

        private void SearchProductsPrice0()
        {
            this.tbProducDatatList = (from prdPriceMsur in this.clsTbPrdPriceMsur.GetPrdPriceMsurList
                                      where prdPriceMsur.ppmPrice == 0
                                      join product in this.clsTbProduct.GetProductList
                                      on prdPriceMsur.ppmPrdId equals product.id
                                      select new tblProductData
                                      {
                                          id = product.id,
                                          prdName = product.prdName,
                                          ppmBarcode11 = prdPriceMsur.ppmBarcode1,
                                          ppmPrice1 = prdPriceMsur.ppmPrice,
                                          ppmSalePrice1 = prdPriceMsur.ppmSalePrice
                                      }).ToList();
            tblProductDataBindingSource.DataSource = this.tbProducDatatList;
        }

        private void SearchProductsSalePrice0()
        {
            this.tbProducDatatList = (from prdPriceMsur in this.clsTbPrdPriceMsur.GetPrdPriceMsurList
                                      where prdPriceMsur.ppmSalePrice == 0
                                      join product in this.clsTbProduct.GetProductList
                                      on prdPriceMsur.ppmPrdId equals product.id
                                      select new tblProductData
                                      {
                                          id = product.id,
                                          prdName = product.prdName,
                                          ppmBarcode11 = prdPriceMsur.ppmBarcode1,
                                          ppmPrice1 = prdPriceMsur.ppmPrice,
                                          ppmSalePrice1 = prdPriceMsur.ppmSalePrice
                                      }).ToList();
            tblProductDataBindingSource.DataSource = this.tbProducDatatList;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}