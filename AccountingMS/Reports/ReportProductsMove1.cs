using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportProductsMove1 : XtraReport
    {
        public ReportProductsMove1()
        {
            InitializeComponent();
            this.BeforePrint += ReportProductsMove1_BeforePrint;
        }

        private void ReportProductsMove1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
        }

        public void BindData()
        {
            //lbl_FactorieNo.DataBindings.Add("Text", this.DataSource, "FactorieNo");
            //lbl_FactorieName.DataBindings.Add("Text", this.DataSource, "FactorieName");
            ////lbl_MonthName.DataBindings.Add("Text", this.DataSource, "MonthName");
            //lbl_ID.DataBindings.Add("Text", this.DataSource, "ID");
            //lbl_SellDate.DataBindings.Add("Text", this.DataSource, "TheDate");
            //lbl_Quantity.DataBindings.Add("Text", this.DataSource, "TheQuantity");
            //lbl_InvoValue.DataBindings.Add("Text", this.DataSource, "InvoValue");
            //lbl_Discount.DataBindings.Add("Text", this.DataSource, "Discount");
            //lbl_AfterDiscount.DataBindings.Add("Text", this.DataSource, "TotalAftDis");
            //lbl_Tax.DataBindings.Add("Text", this.DataSource, "TheTax");
            //lbl_TotalFinal.DataBindings.Add("Text", this.DataSource, "TheSafy");
            //lbl_user.DataBindings.Add("Text", this.DataSource, "user");
            //lbl_bayan.DataBindings.Add("Text", this.DataSource, "Bayan");


            //lbl_TotalDiscount.DataBindings.Add("Text", this.DataSource, "Discount");
            //lbl_TotalAfterDiscount.DataBindings.Add("Text", this.DataSource, "TotalAftDis");
            //lbl_TotalTax.DataBindings.Add("Text", this.DataSource, "TheTax");
            //lbl_TotalFinal1.DataBindings.Add("Text", this.DataSource, "TheSafy");
            //lbl_TheQuantity.DataBindings.Add("Text", this.DataSource, "TheQuantity");
            //lbl_FactoriePrice.DataBindings.Add("Text", this.DataSource, "FactoriePrice");

           xrBayan.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Bayan"));
            xrDocNo.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "DocNo"));
            //xrIndex.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Index"));
            xrPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Price"));
            xrQuantity.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Quantity"));
            xrSalePrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "SalePrice"));
            xrMoveType.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "MoveType"));
            xrMoveDate.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "MoveDate"));
        }
    }
}
