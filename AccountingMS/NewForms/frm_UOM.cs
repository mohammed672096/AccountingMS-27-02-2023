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
using System.Linq.Expressions;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;

namespace ERP.Forms
{
    public partial class frm_UOM : DevExpress.XtraEditors.XtraForm
    {
        public frm_UOM()
        {
            InitializeComponent();
        }
        DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);

        private void frm_UOM_Load(object sender, EventArgs e)
        {
           
            gridControl1.DataSource = objDataContext.Inv_UOMs.Select<DAL.Inv_UOM, DAL.Inv_UOM>((Expression<Func<DAL.Inv_UOM, DAL.Inv_UOM>>)(x => x));
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = LangResource.UnitName; 

        }

     

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                ColumnView clm = sender as ColumnView;
                if (clm.GetRowCellValue(e.RowHandle, "Name").ToString() == string.Empty)
                {
                    e.Valid = false;
                    clm.SetColumnError(clm.Columns["Name"], "*");
                }
            }
            catch (Exception)
            {

                e.Valid = false;
            }
           
        }
     

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode   = ExceptionMode.NoAction;
        }

     

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            objDataContext.SubmitChanges();
        }
    }
}