using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms.FAM
{
    public partial class frm_Currencys : frm_Master
    {
        public frm_Currencys()
        {
            InitializeComponent();
            btn_New.Visibility = btn_Print.Visibility = btn_Save.Visibility = btn_Delete.Visibility= DevExpress.XtraBars.BarItemVisibility.Never ;
            bar2.Visible = false;
        }
        DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

        public override void RefreshData()
        {
            base.RefreshData();
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var MainCurrency = db.Acc_Currencies.FirstOrDefault();
            if (MainCurrency != null)
            {
                txt_name.Text = MainCurrency.Name;
                txt_p1.Text = MainCurrency.Pound1;
                txt_p2.Text = MainCurrency.Pound2;
                txt_p2.Text = MainCurrency.Pound3;
                txt_pp1.Text = MainCurrency.Piaster1;
                txt_pp2.Text = MainCurrency.Piaster2;
                txt_pp3.Text = MainCurrency.Piaster3;
            }
            gridControl1.DataSource = db.Acc_Currencies
                .Select< Acc_Currency ,  Acc_Currency>((Expression<Func<DAL.Acc_Currency, DAL.Acc_Currency>>)(x => x)).
                Where<Acc_Currency>((Func<Acc_Currency, bool>)(x => x.ID > 1));
             
        }
        public override void Save()
        { 
        }
        public override void New()
        { 
        }
        public override void Delete()
        {
            
        }
        public override void Print()
        {
           // if (CanPerformPrint() == false) return;

        }

        private void frm_Currencys_Load(object sender, EventArgs e)
        {
            var MainCurrency = db.Acc_Currencies.FirstOrDefault();
            if (MainCurrency != null)
            {
                    MainCurrency.Name = txt_name.Text;
                MainCurrency.Pound1  =  txt_p1.Text  ;
                 MainCurrency.Pound2=   txt_p2.Text  ;
                 MainCurrency.Pound3=   txt_p2.Text  ;
                 MainCurrency.Piaster1= txt_pp1.Text ;
                 MainCurrency.Piaster2= txt_pp2.Text ;
                 MainCurrency.Piaster3= txt_pp3.Text ; 
            }
            else
            {
                db.Acc_Currencies.InsertOnSubmit(new DAL.Acc_Currency()
                {
                    ID = 1,
                    Name     = txt_name.Text,
                    Piaster1 = txt_p1.Text  ,
                    Piaster2 = txt_p2.Text  ,
                    Piaster3 = txt_p2.Text  ,
                    Pound1   = txt_pp1.Text ,
                    Pound2   = txt_pp2.Text ,
                    Pound3   = txt_pp3.Text,
                LastRate = 1
                });
            }
            db.SubmitChanges();

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            
        }
    }
}
