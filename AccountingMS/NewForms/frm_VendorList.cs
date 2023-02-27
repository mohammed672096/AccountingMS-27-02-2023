using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace ERP.Forms
{
    public partial class frm_VendorList : frm_Master
    {
        public frm_VendorList()
        {
            InitializeComponent();
        }

        private void frm_VendorList_Load(object sender, EventArgs e)
        {
            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        public override void frm_Load(object sender, EventArgs e)
        {


            base.frm_Load(sender, e);
            Master.RestoreGridLayout(VendorListGridView, this);

            VendorListGridView.Columns["ID"].Caption = LangResource.ID;
            VendorListGridView.Columns["ID"].Visible = false;
            VendorListGridView.Columns["ID"].OptionsColumn.ShowInCustomizationForm = false;
            VendorListGridView.Columns["Name"].Caption = LangResource.Name;
            VendorListGridView.Columns["Phone"].Caption = LangResource.Phone;
            VendorListGridView.Columns["City"].Caption = LangResource.City;
            VendorListGridView.Columns["Address"].Caption = LangResource.Address;


        }
        public override void RefreshData()
        {
            GetGRidData();
            RepositoryItemLookUpEdit Vendorsrepo = new RepositoryItemLookUpEdit();
            Vendorsrepo.NullText = "";

            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            var Vendorsgroup = from u in objDataContext.Pr_VendorGroups  select u;
            Vendorsrepo.DataSource = Vendorsgroup;
            Vendorsrepo.ValueMember = "Number";
            Vendorsrepo.DisplayMember = "Name";
            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { Vendorsrepo });
            // VendorListGridView.Columns["ParentVendorID"].ColumnEdit = Vendorsrepo;


        }
        void GetGRidData()
        {

            gridControl1.DataSource = (from s in CurrentSession.UserAccessbileVendors select new { s.ID, s.Name, s.Phone, s.City, s.Address, s.Mobile, s.MaxCredit }).ToList();

        }
        public override void New()
        {
            frm_Main.OpenForm(new frm_Vendor(list));
        }
        public override void Delete()
        {
            
        }
        public override void Save()
        {
           
        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            VendorListGridView.OptionsPrint.PrintFilterInfo = true;
            Reporting.rpt_GridReport.Print(gridControl1, this.Text, VendorListGridView.FilterPanelText, (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes) ? true : false);
            base.Print();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (VendorListGridView.FocusedRowHandle >= 0)
            {

                frm_Main.OpenForm(new frm_Vendor(Convert.ToInt32(VendorListGridView.GetFocusedRowCellValue("ID")), list), openNew: true);
            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            list = new List<int>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                list.Add(Convert.ToInt32(gridView.GetRowCellValue(i, "ID")));

            }

        }

        private void frm_VendorList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(VendorListGridView, this);
        }
        private void VendorListGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                int x = 0;
                int.TryParse(VendorListGridView.GetFocusedRowCellValue("ID").ToString(), out x);
                uc_VendorSideMenu1.VendorID = x;
            }
        }
    }
}
