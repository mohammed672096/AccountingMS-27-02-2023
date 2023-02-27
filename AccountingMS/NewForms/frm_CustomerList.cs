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
    public partial class frm_CustomerList : frm_Master
    {
        public frm_CustomerList()
        {
            InitializeComponent();
        }

        private void frm_CustomerList_Load(object sender, EventArgs e)
        {
            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        public override void frm_Load(object sender, EventArgs e)
        {


            base.frm_Load(sender, e);
            Master.RestoreGridLayout(CustomerListGridView, this);

            CustomerListGridView.Columns["ID"].Caption = LangResource.ID;
            CustomerListGridView.Columns["ID"].Visible = false;
            CustomerListGridView.Columns["ID"].OptionsColumn.ShowInCustomizationForm = false;
            CustomerListGridView.Columns["Name"].Caption = LangResource.Name;
            CustomerListGridView.Columns["Phone"].Caption = LangResource.Phone;
            CustomerListGridView.Columns["City"].Caption = LangResource.City;
            CustomerListGridView.Columns["Address"].Caption = LangResource.Address;


          

        }
        public override void RefreshData()
        {
            GetGRidData();
            RepositoryItemLookUpEdit customersrepo = new RepositoryItemLookUpEdit();
            customersrepo.NullText = "";

            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            var customersgroup = from u in objDataContext.Sl_CustomerGroups  select u;
            customersrepo.DataSource = customersgroup;
            customersrepo.ValueMember = "Number";
            customersrepo.DisplayMember = "Name";
            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { customersrepo });
           // CustomerListGridView.Columns["ParentCustomerID"].ColumnEdit = customersrepo;


        }
        void GetGRidData()
        {

            gridControl1.DataSource = (from s in CurrentSession.UserAccessbileCustomers select new { s.ID, s.Name, s.Phone, s.City, s.Address, s.Mobile ,s.MaxCredit  }).ToList();

        }
        public override void New()
        {
            frm_Main.OpenForm(new frm_Customer(list));
        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            CustomerListGridView.OptionsPrint.PrintFilterInfo = true;
            Reporting.rpt_GridReport.Print(gridControl1, this.Text, CustomerListGridView.FilterPanelText, (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes) ? true : false);
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
            if (CustomerListGridView.FocusedRowHandle >= 0)
            {

                frm_Main.OpenForm(new frm_Customer(Convert.ToInt32(CustomerListGridView.GetFocusedRowCellValue("ID")), list), openNew: true);
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

        private void frm_CustomerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(CustomerListGridView, this);
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            if (CustomerListGridView.FocusedRowHandle >= 0)
                frm_Main.OpenForm(new frm_Inv_Invoice(Convert.ToInt32(CustomerListGridView.GetFocusedRowCellValue("ID")), Master.PartTypes.Customer , Master.InvoiceType.SalesInvoice,list));
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            if (CustomerListGridView.FocusedRowHandle >= 0)
                frm_Main.OpenForm(new frm_Inv_InvoiceList (Master.InvoiceType.SalesInvoice,Master.PartTypes.Customer  ,Convert.ToInt32(CustomerListGridView.GetFocusedRowCellValue("ID"))));
        }

        private void CustomerListGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(e.FocusedRowHandle >= 0)
            {
                int x = 0;
                int.TryParse(CustomerListGridView.GetFocusedRowCellValue("ID").ToString(), out x );
                uc_CustomerSideMenu1.CustomerID = x;
            }
        }
    }
}
