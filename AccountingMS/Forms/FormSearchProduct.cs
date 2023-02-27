using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AccountingMS.Classes;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace AccountingMS.Forms
{
    public partial class FormSearchProduct : DevExpress.XtraEditors.XtraForm
    {
        public FormSearchProduct()
        {
            InitializeComponent();
            this.Text = (!MySetting.GetPrivateSetting.LangEng) ? "بحث الأصناف" : "Search tblProduct";
            //this.Shown += FlyDialogPrd_Shown;
            productBindingSource.DataSource = Session.Products;
            gridViewSrchPrd.CustomUnboundColumnData += GridViewSrchPrd_CustomUnboundColumnData;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.RightToLeft = (!MySetting.GetPrivateSetting.LangEng) ? System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = (!MySetting.GetPrivateSetting.LangEng) ? true : false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
        }
        private void GridViewSrchPrd_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != colPrdSalePrice2.FieldName) return;
            if (!e.IsGetData) return;
            var row = view.GetRow(e.ListSourceRowIndex) as tblProduct;
            if (row != null)
                e.Value = GetFirstPriceInProduct(row.id);
        }
        double GetFirstPriceInProduct(int id)
        {
            var ppm = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmPrdId == id && x.ppmDefault);
            if (ppm == null) return 0;
            var pro = Session.Products.FirstOrDefault(x => x.id == ppm.ppmPrdId)?.prdPriceTax ?? false;
            return new ClsTblPrdPriceMeasurment().GetppmSalePrice(pro, ppm);
        }
        
        private void BtnClosSearchPro_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}