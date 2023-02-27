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
using DevExpress.XtraEditors.Repository;
using System.Linq.Expressions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Diagnostics;

namespace ERP.Forms
{
    public partial class frm_ItemList :frm_Master 
    {

        RepositoryItemLookUpEdit uomrepo = new RepositoryItemLookUpEdit();

        public frm_ItemList()
        {
            InitializeComponent();
        }

        private void frm_ItemList_Load(object sender, EventArgs e)
        {
            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        public override void Save()
        {
         

        }
        public override void Delete()
        {
          
        }
        public override void frm_Load(object sender, EventArgs e)
        {


            base.frm_Load(sender, e);
            Master.RestoreGridLayout(gridView1, this);

            gridView1.Columns["ID"].Caption  = LangResource.ID;
            gridView1.Columns["ID"].Visible  = false ;
            gridView1.Columns["ID"].OptionsColumn.ShowInCustomizationForm   = false;
            gridView1.Columns["Name"].Caption  = LangResource.Name;
            gridView1.Columns["Type"].Caption  = LangResource.Type ;
            gridView1.Columns["Company"].Caption  = LangResource.Company;
            gridView1.Columns["GroupID"].Caption  = LangResource.Group;
            gridView1.Columns["Color"].Caption  = LangResource.Color;
            gridView1.Columns["Expier"].Caption  = LangResource.Expier;
            gridView1.Columns["Warranty"].Caption  = LangResource.Warranty;
            gridView1.Columns["Serial"].Caption  = LangResource.Serial;
        
            gridView1.Columns["Suspended"].Caption  = LangResource.Suspended;
          
            gridView1.OptionsDetail.DetailMode = DetailMode.Classic ;
            gridView1.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridView1.DetailVerticalIndent = 25;
            

        }
        public override void RefreshData()
        {
            GetGRidData();


            RepositoryItemLookUpEdit grouprepo = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit Companyrepo = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit typerepo = new RepositoryItemLookUpEdit();
           
            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);

            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("Name") });
            dataTable.Rows.Add(0, LangResource.Inventory );
            dataTable.Rows.Add(1, LangResource.Assembly );
            dataTable.Rows.Add(2, LangResource.Service );
            dataTable.Rows.Add(3, LangResource.Drug );

            var UOM = from u in objDataContext.Inv_UOMs select u;
            uomrepo.DataSource = UOM.ToList();
            uomrepo.ValueMember = "ID";
            uomrepo.DisplayMember = "Name";

            var companys = from c in objDataContext.Inv_Companies select c;
            var group = from g in objDataContext.Inv_ItemGroups select g;


            typerepo.DataSource = dataTable;
            typerepo.ValueMember = "ID";
            typerepo.DisplayMember = "Name";

            Companyrepo.DataSource = companys.ToList();
            Companyrepo.ValueMember = "ID";
            Companyrepo.DisplayMember = "Name";
            Companyrepo.PopulateColumns();
            Companyrepo.Columns[0].Visible = false;

            grouprepo.DataSource = group.ToList();
            grouprepo.ValueMember = "Number";
            grouprepo.DisplayMember = "Name";

            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { grouprepo, Companyrepo , typerepo , uomrepo });
            gridView1.Columns["Company"].ColumnEdit = Companyrepo;
            gridView1.Columns["GroupID"].ColumnEdit = grouprepo;
            gridView1.Columns["Type"].ColumnEdit = typerepo;
        //    gridView1.Columns["UnitID"].ColumnEdit = uomrepo;


        }
        void GetGRidData()
        {

            //var result = from c in CurrentSession.Products select new { c.Inv_ItemUnits.First().Barcode  ,c.ID, c.Name
            //    ,c.Inv_ItemUnits.First().UnitID
            //    ,c.Inv_ItemUnits.First().BuyPrice 
            //    ,c.Inv_ItemUnits.First().SellPrice
            //    ,c.Type, c.GroupID, c.Company, c.Suspended  
            //    ,c.PTax ,c.PTaxValue ,c.STax ,c.STaxValue 
            //    ,c.Serial ,c.Warranty ,c.Expier ,c.Color 
            // }
            var result = from c in CurrentSession.Products
                         select new
                         {
                             c.Inv_ItemUnits ,
                             c.ID,
                             c.Name
,
                            
                             c.Type,
                             c.GroupID,
                             c.Company,
                             c.Suspended,
                             c.Serial,
                             c.Warranty,
                             c.Expier,
                             c.Color

                         };
            gridControl1.DataSource = result.ToList();

           
        }
        public override void New()
        {
            frm_Main.OpenForm(new frm_Item(list));
        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            gridView1.OptionsPrint.PrintFilterInfo = true;
            Reporting.rpt_GridReport.Print(gridControl1,LangResource.ItemsList  ,gridView1.FilterPanelText,(this.RightToLeft == System.Windows.Forms.RightToLeft.Yes )?true:false);
            base.Print();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle >= 0)
            {

                frm_Main.OpenForm(new frm_Item(Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")), list), openNew:true);
            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            list = new List<int>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                list .Add(Convert.ToInt32( gridView .GetRowCellValue(i,"ID")));
                
            }

        }

        private void frm_ItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(gridView1, this);
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = e.View as GridView;
            view.OptionsView.ShowFooter = false;
            view.ViewCaption = "cap";
            view.Columns["ID"].Visible = view.Columns["ID"].OptionsColumn.ShowInCustomizationForm =
                  view.Columns["Inv_Item"].Visible = view.Columns["Inv_Item"].OptionsColumn.ShowInCustomizationForm =
                  view.Columns["ItemID"].Visible = view.Columns["ItemID"].OptionsColumn.ShowInCustomizationForm =
                  false;
            view.Columns["SellPrice"].Caption = LangResource.SellPrice;
            view.Columns["BuyPrice"].Caption = LangResource.BuyPrice;
            view.Columns["UnitID"].Caption = LangResource.ItemUnitFirst;
         //   view.Columns["Barcode"].Caption = LangResource.Barcode;
            view.Columns["DefualtSell"].VisibleIndex
                = view.Columns["DefualtBuy"].VisibleIndex
                = view.Columns["Factor"].VisibleIndex = view.Columns["SellDiscount"].VisibleIndex = -1;
            view.OptionsView.ColumnAutoWidth = false;   
            view.Columns["UnitID"].ColumnEdit = uomrepo;
            view.Name = "UnitView";
            view.SynchronizeClones = true;

            Master.RestoreGridLayout(view, this);
            

        }

        private void gridView1_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = LangResource.UOM;
        }

        private void gridView1_MasterRowCollapsing(object sender, MasterRowCanExpandEventArgs e)
        {
           
        }

        private void gridControl1_ViewRemoved(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = e.View as GridView;
            view.Name = "UnitView";
            Master.SaveGridLayout (view, this);

        }
    }
}