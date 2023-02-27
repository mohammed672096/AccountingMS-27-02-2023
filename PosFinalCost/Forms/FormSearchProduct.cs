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
using PosFinalCost.Classe;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace PosFinalCost.Forms
{
    public partial class FormSearchProduct : DevExpress.XtraEditors.XtraForm
    {
        public FormSearchProduct()
        {
            InitializeComponent();
            this.Text = (!Program.My_Setting.LangEng) ? "بحث الأصناف" : "Search Product";
            //this.Shown += FlyDialogPrd_Shown;
            productBindingSource.DataSource = Session.Products;
            gridViewSrchPrd.CustomUnboundColumnData += GridViewSrchPrd_CustomUnboundColumnData;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.RightToLeft = (!Program.My_Setting.LangEng) ? System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = (!Program.My_Setting.LangEng) ? true : false;
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
            var row = view.GetRow(e.ListSourceRowIndex) as Product;
            if (row != null)
                e.Value = GetFirstPriceInProduct(row.ID);
        }
        double GetFirstPriceInProduct(int id)
        {
            var ppm = Session.PrdMeasurments.FirstOrDefault(x => x.PrdId == id && x.Default);
            if (ppm == null) return 0;
            var pro = Session.Products.FirstOrDefault(x => x.ID == ppm.PrdId)?.PriceTax ?? false;
            return new MyFunaction().GetSalePrice(pro, ppm);
        }
        
        private void BtnClosSearchPro_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}