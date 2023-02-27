using PosFinalCost.Classe;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
namespace PosFinalCost.Forms
{
    public partial class UC_AddSaleInvoicePos : UserControl
    {
       
        public UC_AddSaleInvoicePos()
        {
            InitializeComponent();
            
        }
        
        void InitProductData()
        {
            gridControlProudct.DataSource = from p in Session.Products
                                            join m in Session.PrdMeasurments on p.ID equals m.PrdId
                                            select new
                                            {
                                                Name=p.Name,
                                                Price=m.SalePrice,
                                                //Discount=p.d
                                            };
        }
    }
}
