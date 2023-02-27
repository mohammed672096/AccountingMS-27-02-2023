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

namespace ERP.Forms
{
    public partial class frm_UsersList : DevExpress.XtraEditors.XtraForm
    {
        public static int SelectedUserID = 0;
        bool IsSelecteing = false; 

        public frm_UsersList(bool _IsSelecteing=false )
        {
            InitializeComponent();
            IsSelecteing = _IsSelecteing;
        }

        private void frm_UsersList_Load(object sender, EventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            gridControl1.DataSource = (from u in db.St_Users select new { u.ID, u.UserName }).ToArray();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            int UserID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            if (IsSelecteing)
            {
                SelectedUserID =UserID;
                this.Close();
            }else 
            {
                frm_Main.OpenForm(new frm_UserControl(UserID)); 
            }
        }
    }
}