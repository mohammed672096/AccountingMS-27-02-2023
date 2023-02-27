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
    public partial class frm_StoreList : frm_Master
    {
        public frm_StoreList()
        {
            InitializeComponent();
        }

        private void frm_StoreList_Load(object sender, EventArgs e)
        {
            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        public override void frm_Load(object sender, EventArgs e)
        {


            base.frm_Load(sender, e);
            Master.RestoreGridLayout(StoreListGridView, this);

            StoreListGridView.Columns["ID"].Caption = LangResource.ID;
            StoreListGridView.Columns["ID"].Visible = false;
            StoreListGridView.Columns["ID"].OptionsColumn.ShowInCustomizationForm = false;
            StoreListGridView.Columns["Name"].Caption = LangResource.Name;
            StoreListGridView.Columns["Phone"].Caption = LangResource.Phone;
            StoreListGridView.Columns["City"].Caption = LangResource.City;
            StoreListGridView.Columns["Address"].Caption = LangResource.Address;
            StoreListGridView.Columns["ParentStoreID"].Caption = LangResource.ParentStoreID;


        }
        public override void RefreshData()
        {
            GetGRidData();
            RepositoryItemLookUpEdit storesrepo = new RepositoryItemLookUpEdit();
            storesrepo.NullText = "";

            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            var stores = from u in objDataContext.Inv_Stores  select u;
            storesrepo.DataSource = stores ;
            storesrepo.ValueMember = "ID";
            storesrepo.DisplayMember = "Name";
            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { storesrepo });
            StoreListGridView.Columns["ParentStoreID"].ColumnEdit = storesrepo;


        }
        void GetGRidData()
        {
          
            gridControl1.DataSource = (from s in  CurrentSession.UserAccessbileStores select new { s.ID, s.Name, s.Phone ,s.City ,s.Address , s.ParentStoreID}).ToList();

        }
        public override void New()
        {
            frm_Main.OpenForm(new frm_Stores (list));
        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            StoreListGridView.OptionsPrint.PrintFilterInfo = true;
            Reporting.rpt_GridReport.Print(gridControl1, this.Text, StoreListGridView.FilterPanelText, (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes) ? true : false);
            base.Print();
        }
        public override void Save()
        {
            
        }
        public override void Delete()
        {
            
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (StoreListGridView.FocusedRowHandle >= 0)
            {

                frm_Main.OpenForm(new frm_Stores(Convert.ToInt32(StoreListGridView.GetFocusedRowCellValue("ID")), list), openNew: true);
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

        private void frm_StoreList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(StoreListGridView, this);
        }
    }
}
