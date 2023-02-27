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
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraEditors.Repository;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using System.Data.Linq;

namespace ERP.Forms
{
    public partial class frm_Item :frm_Master 
    {
        public DAL.Inv_Item item = new DAL.Inv_Item();
        
        public frm_Item(List<int> lst = null)
        {
            InitializeComponent();
            New();
            this.list = lst;

        }

        public frm_Item(int itmID , List<int> lst = null )
        {
           
            InitializeComponent();
            LoadItem(itmID);
            this.list = lst;

        }
        void LoadItem(int itmID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            item = (from i in db.Inv_Items where i.ID == itmID select i).First();
            IsNew = false;
      
        }

        private void frm_Item_Load(object sender, EventArgs e)
        {
           
        }
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            objDataContext = new DAL.ERPDataContext(Program.setting.con);

            barItem_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            spn_Warranty.Visible = false;
            spn_Expire.Visible = false;
          
            GetData();
            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember  = "ID";
            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption  = LangResource.Store;
            gridView1.Columns[2].Caption = LangResource.ItemReorderLevel;
            gridView1.Columns[3].Caption = LangResource.ItemMaxBalance;
            gridView1.Columns[4].Caption = LangResource.Balance;
            gridView1.Columns[5].Caption = LangResource.location;
            gridView1.Columns[1].OptionsColumn.AllowEdit = gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            RepositoryItemSpinEdit repospin = new RepositoryItemSpinEdit();
            gridControl1.RepositoryItems.Add(repospin);
            gridView1.Columns[2].ColumnEdit = gridView1.Columns[3].ColumnEdit = repospin;


            gridView2.Columns["ID"].Visible = false;
            gridView2.Columns["ItemID"].Visible = false;
            gridView2.Columns["Inv_Item"].Visible = false;
            
            gridView_Barcodes .Columns["ID"].Visible = false;
            gridView_Barcodes.Columns["ItemID"].Visible = false;
            
            RepositoryItemCalcEdit calcEdit = new RepositoryItemCalcEdit();
            gridControl2 .RepositoryItems.Add(calcEdit);
            gridControl2.RepositoryItems.Add(repospin);
            gridControl2.RepositoryItems.Add(repoUOM);
            
            gridView2.Columns["Factor"].ColumnEdit = gridView2.Columns["SellDiscount"].ColumnEdit = calcEdit;
            gridView2.Columns["UnitID"].ColumnEdit = repoUOM;
            gridView2.Columns["SellPrice"].ColumnEdit = gridView2.Columns["BuyPrice"].ColumnEdit = gridView2.Columns["SellDiscount"].ColumnEdit = repospin;


            gridView2.TranslateColumns();
            gridView_Barcodes .TranslateColumns();



            gv_PPQ.Columns[0].Caption = LangResource.From;
            gv_PPQ.Columns[1].Caption = LangResource.To ;
            gv_PPQ.Columns[2].Caption = LangResource.Price;
            RepositoryItemCalcEdit repoCalc = new RepositoryItemCalcEdit();
            gc_PPQ.RepositoryItems.Add(repoCalc);
            gv_PPQ.Columns[0].ColumnEdit =
            gv_PPQ.Columns[1].ColumnEdit =
            gv_PPQ.Columns[2].ColumnEdit = repoCalc;


            repoUOM.ValueMember = "ID";
            repoUOM.DisplayMember  = "Name";
            repoUOM.NullText = "";
            
            repoUOMForBarcodes.ValueMember = "ID";
            repoUOMForBarcodes.DisplayMember = "Name";
            repoUOMForBarcodes.NullText = "";


            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            gridControl2.RepositoryItems.Add(buttonEdit);
            GridControl_Barcodes .RepositoryItems.Add(buttonEdit);
            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            GridColumn clmnDelete = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit ,VisibleIndex =6 ,Width = 15};
            buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor  ;

            
           
            GridColumn clmnDeleteBarcode = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 6, Width = 15 };
          
            
            gridView2.Columns.Add(clmnDelete);
            
            gridView_Barcodes .Columns.Add(clmnDeleteBarcode); 
            GridControl_Barcodes .RepositoryItems.Add(repoUOMForBarcodes );
            gridView_Barcodes.Columns["UnitID"].ColumnEdit = repoUOMForBarcodes;
           
            gridView2.ClearSorting();
            gridView2.Columns["Factor"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridView2.Columns["DefualtBuy"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["DefualtSell"].OptionsColumn.AllowEdit = false;

            gridView_Barcodes.ViewCaption = LangResource.ItemCodes;
            gridView2.ViewCaption = LangResource.UOM ;
            


            #region DataChangedEventHandler 
            txt_Name.EditValueChanged += DataChanged;
            spn_BuyTaxValue                   .EditValueChanged += DataChanged;
            spn_BuyTax                        .EditValueChanged += DataChanged;
            spn_SellTaxValue                  .EditValueChanged += DataChanged;
            spn_SellTax                       .EditValueChanged += DataChanged;
            Treelkp_Group                     .EditValueChanged += DataChanged;
           
            chk_Color                   .EditValueChanged += DataChanged;
            chk_Size                    .EditValueChanged += DataChanged;
            spn_Expire                  .EditValueChanged += DataChanged;
            spn_Warranty                .EditValueChanged += DataChanged;
            chk_Expire                  .EditValueChanged += DataChanged;
            chk_Warranty                .EditValueChanged += DataChanged;
            chk_Serial                  .EditValueChanged += DataChanged;
            chk_Active                  .EditValueChanged += DataChanged;
            ComboBoxEdit_Type             .EditValueChanged += DataChanged;
            lkp_Company                 .EditValueChanged += DataChanged;
           
            gridView1.CellValueChanged += DataChanged;

            #endregion 

            gridView2.CustomRowCellEditForEditing += GridView2_CustomRowCellEditForEditing;
            gridView2.ValidateRow += GridView2_ValidateRow;
            gridView2.InvalidRowException += GridView2_InvalidRowException;
            gridView_Barcodes .InvalidRowException += GridView2_InvalidRowException;
            gridView_Barcodes.ValidateRow += GridView_Barcodes_ValidateRow;
           gridView2.Click += GridView2_Click;
            gridView2.FocusedColumnChanged += GridView2_FocusedColumnChanged;
            gridView2.FocusedRowChanged += GridView2_FocusedRowChanged;
            gridControl2.ProcessGridKey += GridControl2_ProcessGridKey;
            gridView2.CellValueChanged += GridView2_CellValueChanged;
            gridView2.RowCountChanged += GridView2_RowCountChanged;
            gridView2.CellValueChanging += GridView2_CellValueChanging;

           
        }

          //  Debug.Print(e.OldValue.ToString() + e.NewValue.ToString());
    

        private void GridView2_CellValueChanging(object sender, CellValueChangedEventArgs  e)
        {
            if (e.Column.FieldName == "UnitID"&& e.Value.ValidAsIntNonZero ())
            {
                var OldValue = gridView2.GetRowCellValue(e.RowHandle, e.Column).ToInt();
                
                foreach (var barcode in ((Collection<DAL.Inv_ItemBarcode>)gridView_Barcodes.DataSource))
                {
                    if (barcode.UnitID == OldValue)
                        barcode.UnitID = e.Value.ToInt();

                }
            };
        }

        private void GridView_Barcodes_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            int h = e.RowHandle;
            GridView view = sender as GridView;
            if (view.GetRowCellValue(e.RowHandle, "UnitID").ValidAsIntNonZero() == false)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["UnitID"], LangResource.ErrorCantBeEmpry);
            }
            if (view.GetRowCellValue(e.RowHandle, "Barcode") == null || String.IsNullOrEmpty( view.GetRowCellValue(e.RowHandle, "Barcode").ToString().Trim ()  ) )
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Barcode"], LangResource.ErrorCantBeEmpry);
            }
            var flag = false;
           // foreach (var b in ((Collection<DAL.Inv_ItemBarcode >)view.DataSource))
           //     if (b.UnitID  != view.GetRowCellValue(e.RowHandle, "UnitID").ToInt())
           //         flag =flag || (view.GetRowCellValue(e.RowHandle, "Barcode") != null && view.GetRowCellValue(e.RowHandle, "Barcode").ToString() == b.Barcode);
           
           flag = flag || (view.GetRowCellValue(e.RowHandle, "Barcode") != null && CheckIfBarcodeISUsed(view.GetRowCellValue(e.RowHandle, "Barcode").ToString().Trim()));


            if( flag )
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Barcode"], LangResource.ErorrThisCodeIsUsedBefore );
            }
            
        }

        private void GridView2_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView2.DataSource == null) return;
            var usedUnitsIDs = ((Collection<DAL.Inv_ItemUnit>)gridView2.DataSource).Select(x => x.UnitID).ToList();
            repoUOMForBarcodes.DataSource = ((List<DAL.Inv_UOM>)repoUOM.DataSource).Where(x => usedUnitsIDs.Contains(x.ID)).ToList();
        }

        private void GridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView2_RowCountChanged(null, null);
           
        }

        private void GridControl2_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {


                GridControl gridControl = sender as GridControl;
                GridView focusedView = gridControl.FocusedView as GridView;
                if (e.KeyCode == Keys.Return)
                {
                    GridColumn focusedColumn = (gridControl.FocusedView as ColumnView).FocusedColumn;
                    focusedView.PostEditor();
                    int focusedRowHandle = (gridControl.FocusedView as ColumnView).FocusedRowHandle;
                    if (focusedView.FocusedColumn == focusedView.Columns["UnitID"])
                    {
                        GridControl2_ProcessGridKey(sender, new KeyEventArgs(Keys.Tab));
                    }
                    else if (focusedView.FocusedColumn == focusedView.Columns["Factor"])
                    {
                        focusedView.FocusedColumn = focusedView.Columns["SellPrice"];

                    }
                    else if (focusedView.FocusedColumn == focusedView.Columns["SellPrice"])
                    {
                        focusedView.FocusedColumn = focusedView.Columns["BuyPrice"];

                    }
                    else if (focusedView.FocusedColumn == focusedView.Columns["BuyPrice"])
                    {
                        if (focusedView.IsLastRow) focusedView.AddNewRow();
                        focusedView.FocusedRowHandle = focusedRowHandle + 1;
                        focusedView.FocusedColumn = focusedView.Columns["UnitID"];
                    }

                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Tab && e.Modifiers != Keys.Shift)
                {
                    if (focusedView.FocusedColumn == focusedView.Columns["UnitID"])
                        focusedView.FocusedColumn = focusedView.Columns["Factor"];
                    else
                        focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex - 1];
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                    ButtonEdit_ButtonClick(null, null);
            }
            catch
            {
            }
        }

        private void GridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView2_FocusedColumnChanged(sender, new FocusedColumnChangedEventArgs(gridView2.FocusedColumn, gridView2.FocusedColumn));


        }

        private void GridView2_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
          if(e.FocusedColumn.FieldName == "Factor" )
                e.FocusedColumn.OptionsColumn.AllowEdit = !(gridView2.FocusedRowHandle  == 0  && gridView2.GetFocusedRowCellValue(e.FocusedColumn).ToInt() == 1);
        }

        private void GridView2_Click(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (  info.InRowCell && view .RowCount > 1 && info.RowHandle >= 1)
            {
                var selection =  (Collection<DAL.Inv_ItemUnit>)view.DataSource;
                if(info.Column.FieldName == "DefualtBuy")
                {
                   
                    foreach (var item in selection )
                    {
                        item.DefualtBuy = false;
                    }
                    view.SetRowCellValue(info.RowHandle, info.Column, true);
                }
                else if(info.Column.FieldName == "DefualtSell")
                {
                    
                    foreach (var item in selection)
                    {
                        item.DefualtSell = false;
                    }
                    view.SetRowCellValue(info.RowHandle, info.Column, true);
                }
                
            }
        }

        private void GridView2_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
          
                e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            ColumnView columnView = sender as ColumnView;
            int h = e.RowHandle;
            GridView view = sender as GridView; 
            if (view.GetRowCellValue(e.RowHandle, "UnitID").ValidAsIntNonZero()== false )
            {
                e.Valid = false;
                view.SetColumnError(gridView2.Columns["UnitID"], LangResource.ErrorCantBeEmpry);
            }
            if (view.GetRowCellValue(e.RowHandle, "Factor").ValidAsIntNonZero() == false ||(e.RowHandle != 0 && view.GetRowCellValue(e.RowHandle, "Factor").ToInt()<=1) )
            {
                e.Valid = false;
                view.SetColumnError(gridView2.Columns["Factor"], LangResource.ErrorValMustBeGreaterThan1 );
            }
        }

        private void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView ;
            if(view.Name == gridView2.Name && view.FocusedRowHandle >= 1)
            {  
                    if (((bool?)view.GetFocusedRowCellValue(view.Columns["DefualtBuy"])) == true)
                        view.SetRowCellValue(0, "DefualtBuy", true);
                    if (((bool?)view.GetFocusedRowCellValue(view.Columns["DefualtSell"])) == true)
                        view.SetRowCellValue(0, "DefualtSell", true); 
                      view.DeleteSelectedRows ();
            }
            else if (  view.FocusedRowHandle >=0)
            {
                view.DeleteSelectedRows();

            }

        }

        private void GridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "UnitID")
            {
                List<int> ids = new List<int>();
                foreach (var uom in gridView2.DataSource as Collection <DAL.Inv_ItemUnit > )
                {
                    
                    ids.Add(uom.UnitID );
                }
                if(e.CellValue.IsNumber())  ids.Remove((int)e.CellValue);
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

                var tempList = db.Inv_UOMs.Where(x => !ids.Contains(x.ID)).ToList();
                 RepositoryItemLookUpEdit tempRepoUOM = new RepositoryItemLookUpEdit();
                tempRepoUOM.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
                tempRepoUOM.ButtonClick += TempRepoUOM_ButtonClick;
                tempRepoUOM.ValueMember = "ID";
                tempRepoUOM.DisplayMember = "Name";
                tempRepoUOM.DataSource = tempList;
                tempRepoUOM.TranslateColumns();
                tempRepoUOM.Columns["ID"].Visible = false;
                tempRepoUOM.NullText = "";
                e.RepositoryItem = tempRepoUOM;


            }
        }

        private void TempRepoUOM_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
           if(e.Button.Kind == ButtonPredefines.Plus)
            {
                frm_Main.OpenForm(new frm_UOM(), true);
                RefreshData();
            }
        }

        DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
        RepositoryItemLookUpEdit repoUOM = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoUOMForBarcodes = new RepositoryItemLookUpEdit();

        public override void RefreshData()
        {
        DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var companys = from c in db.Inv_Companies select c;
            var group = from g in db.Inv_ItemGroups  select g;
            lkp_Company.Properties.DataSource = companys.ToList();
            lkp_Company.Properties.ValueMember = "ID";
            lkp_Company.Properties.DisplayMember = "Name";
            lkp_Company.Properties.PopulateColumns(); 
            lkp_Company.Properties.Columns[0].Visible = false;
            Treelkp_Group.Properties.DataSource = group.ToList();
            Treelkp_Group.Properties.ValueMember = "Number";
            Treelkp_Group.Properties.DisplayMember = "Name";
            Treelkp_Group.Properties.TreeList.ParentFieldName = "ParentID";
            Treelkp_Group.Properties.TreeList.KeyFieldName = "Number";
            
            repoUOM .DataSource = db.Inv_UOMs .ToList(); 
            GridView2_RowCountChanged(null, null);
            var result = from c in CurrentSession.Products
                         select new
                         {
                             c.ID,
                             c.Name,
                         }; 
            lkp_List.DataSource = result;
            if (list == null) list = result.Select(x => x.ID).ToList();
        }
        public override void GoTo(int id)
        {
            if (id.ToString() == txt_ID.Text) return;
            if (ChangesMade && !SaveChangedData()) return;
            LoadItem(id);
            GetData();
        }
      
        private void ComboBoxEdit_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            chk_Expire.Enabled = true;
          //  xtraTabPage2.PageVisible = true;
            chk_Serial .Enabled = true;
            chk_Warranty .Enabled = true;
        

            switch (ComboBoxEdit_Type.SelectedIndex)
            {
                case 2:
                    chk_Expire.Checked = false;
                    chk_Expire.Enabled = false;
                    chk_Warranty.Checked = false;
                    chk_Warranty.Enabled = false;
                    chk_Serial.Checked = false;
                    chk_Serial.Enabled = false;
                 //   xtraTabPage2.PageVisible = false;
                    break;
                case 3:
                    chk_Expire.Checked = true;
                    chk_Expire.Enabled = false;
                    break;
            }

        }

        private void chk_Warranty_CheckedChanged(object sender, EventArgs e)
        {
            layoutControlItem13 .Visibility  = chk_Warranty.Checked? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never  ;  
           
        }

        private void chk_Expire_CheckedChanged(object sender, EventArgs e)
        {
            layoutControlItem14.Visibility = chk_Expire.Checked ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void lkp_Company_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton) ) return;
            if (e.Button.Tag != null  && e.Button.Tag.ToString() == "add")
            {
                frm_Main.OpenForm(new frm_Inv_Company(), true);
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
                var companys = from c in db.Inv_Companies select c;
                lkp_Company.Properties.DataSource = companys.ToList();


            }
        }


        int GetNextID()
        {
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return (int)db.Inv_Items .Max(n => n.ID ) + 1;

            }
            catch
            {
                return (int)  1;


            }
        }
        public Boolean CheckIfBarcodeISUsed(string barcode )
        {
           
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
            var y = from b in db.Inv_ItemBarcodes   where b.Barcode.ToString() == barcode && b.ItemID != item.ID select b;
            var x = from b in db.Inv_Items  where b.Code.ToString() == barcode select b;
            return ( y.Count()+x.Count () > 0|| item.Code == barcode || TextEdit_Code.Text == barcode); 
        }
        public Boolean CheckIfNameIsUsed(string name)
        {
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var x = from b in db.Inv_Items where b.Name  == name.TrimEnd().TrimStart() && b.ID != item.ID select b;
            
            return (x.Count() > 0 );
        }

        private void Treelkp_Group_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton)) return;
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "add")
            {
                frm_Main.OpenForm(new frm_ItemGroup(), true);
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

                var group = from g in db.Inv_ItemGroups select g;
                Treelkp_Group.Properties.DataSource = group.ToList();
            }
        }

        public override void Save()
        {
           // if (IsNew && !CanAdd) { XtraMessageBox.Show(LangResource.CantAddNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
          if (CanSave() == false) return;
            if(!ValidData()) {  return; }

            
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            if(IsNew)   db.Inv_Items.InsertOnSubmit(item);
            else item = (from i in db.Inv_Items where i.ID == item.ID select i).First ();
            SetData();
            db.SubmitChanges();
            db.Inv_ItemLocations.DeleteAllOnSubmit(db.Inv_ItemLocations.Where(x => x.ItemID == item.ID));
            db.Inv_ItemPPQs .DeleteAllOnSubmit(db.Inv_ItemPPQs .Where(x => x.ItemID == item.ID));
            db.SubmitChanges();
            for (int i = 0; i <= gridView1.RowCount-1; i++)
            {
                db.Inv_ItemLocations.InsertOnSubmit(new DAL.Inv_ItemLocation()
                {
                    ItemID = item.ID,
                    ItemLocation = gridView1.GetRowCellValue(i, "Location").ToString(),
                    Max = Convert.ToDouble(gridView1.GetRowCellValue(i, "Max")),
                    Min = Convert.ToDouble(gridView1.GetRowCellValue(i, "Min")),
                    StoreID = Convert.ToInt32(gridView1.GetRowCellValue(i, "ID"))
                });
            }
            for (int i = 0; i <= gv_PPQ.RowCount -1; i++)
            {
                db.Inv_ItemPPQs.InsertOnSubmit(new DAL.Inv_ItemPPQ()
                {
                    ItemID = item.ID,
                    FromQty = Convert.ToDouble(gv_PPQ.GetRowCellValue(i, "FromQty")),
                    ToQty = Convert.ToDouble(gv_PPQ.GetRowCellValue(i, "ToQty")),
                    Price = Convert.ToDouble(gv_PPQ.GetRowCellValue(i, "Price")),
                });
            }
            
            db.Inv_ItemUnits.DeleteAllOnSubmit(db.Inv_ItemUnits.Where(x=>x.ItemID == item.ID ));
            db.Inv_ItemBarcodes.DeleteAllOnSubmit(db.Inv_ItemBarcodes.Where(y => y.ItemID == item.ID));
            db.SubmitChanges();
            foreach (var uom in ((Collection<DAL.Inv_ItemUnit>) gridView2.DataSource ))
            {
                uom.Inv_Item = item;
                db.Inv_ItemUnits.InsertOnSubmit (uom);
            }
            db.SubmitChanges();

            foreach (var barcode  in ((Collection<DAL.Inv_ItemBarcode >)gridView_Barcodes .DataSource))
            {
                barcode.ItemID = item.ID;
                db.Inv_ItemBarcodes .InsertOnSubmit (barcode );

            }

            //objDataContext.SubmitChanges();
            db.SubmitChanges();
            CurrentSession.Products = (from c in objDataContext .Inv_Items select c).ToList();
            CurrentSession.ProductsUints = (from c in objDataContext.Inv_ItemUnits select c).ToList();
            base.Save();  
           

        }
        private bool ValidData()
        {
            if (string.IsNullOrEmpty(this.txt_Name.Text.Trim()))
            {
                this.txt_Name.ErrorText = LangResource .ErrorCantBeEmpry;
                this.txt_Name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.TextEdit_Code.Text.Trim()))
            {
                this.TextEdit_Code.ErrorText = LangResource.ErrorCantBeEmpry;
                this.TextEdit_Code.Focus();
                return false;
            }
            if (CheckIfNameIsUsed ( this.txt_Name.Text))
            {
                this.txt_Name.ErrorText = LangResource.ErorrThisNameIsUsedBefore;
                this.txt_Name.Focus();
                return false;
            }

            if (gridView2  .RowCount== 0)
            {
                XtraMessageBox.Show(LangResource.ErrorMustInsertOneUOMAtleast, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (gridView2.HasColumnErrors)
            {
                return false;
            }
            if (gridView_Barcodes .HasColumnErrors)
            {
                return false;
            }

            if (chk_Expire.Checked &&  Convert.ToDouble( spn_Expire .EditValue) <= 0)
            {

                this.spn_Expire.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                this.spn_Expire.Focus();
                return false;

            }
            if (chk_Warranty .Checked && Convert.ToDouble(spn_Warranty .EditValue) <= 0)
            {

                this.spn_Warranty.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                this.spn_Warranty.Focus();
                return false;

            }


            return true;
        }
        void SetData()
        {
            item.Name = txt_Name.Text.TrimEnd().TrimStart();
            item.Code = TextEdit_Code .Text.TrimEnd().TrimStart();
            item.Company = Convert.ToInt32(lkp_Company.EditValue);
            item.GroupID = Convert.ToInt32(Treelkp_Group.EditValue);
            item.Type = ComboBoxEdit_Type.SelectedIndex;
          
            item.Suspended = chk_Active.Checked;
            item.Color = chk_Color.Checked;
            item.Expier = chk_Expire.Checked;
            item.Serial = chk_Serial.Checked;
            item.Size = chk_Size.Checked;
            item.Warranty = chk_Warranty.Checked;
            item.WarntyDuration = Convert.ToInt32(spn_Warranty.EditValue);
            item.ShelfLife = Convert.ToInt32(spn_Expire.EditValue);
            

            PartNumber = item.ID.ToString();
            PartName = txt_Name.Text;

            

        }
        void GetData()
        {
            txt_ID.Text = item.ID.ToString();
            barItem_Search.EditValue = item.ID;

            txt_Name.Text = item.Name;
            lkp_Company.EditValue = item.Company;
            Treelkp_Group.EditValue = item.GroupID;
            ComboBoxEdit_Type.SelectedIndex =   item.Type;
         
            chk_Active.EditValue   =(bool)item.Suspended;
            chk_Color.EditValue    =(bool)item.Color;
            chk_Expire.EditValue   =(bool)item.Expier;
            chk_Serial.EditValue   =(bool)item.Serial;
            chk_Size.EditValue     =(bool)item.Size;
            chk_Warranty.EditValue =(bool)item.Warranty;
            spn_Warranty.EditValue =item.WarntyDuration;
            spn_Expire.EditValue = item.ShelfLife;
            TextEdit_Code.Text = item.Code;
           PartNumber = item.ID.ToString();
            PartName = txt_Name.Text;
           
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            gridControl2.DataSource = db.Inv_ItemUnits.Select<DAL.Inv_ItemUnit, DAL.Inv_ItemUnit>((Expression<Func<DAL.Inv_ItemUnit, DAL.Inv_ItemUnit>>)(x => x)).Where(x=>x.ItemID == item.ID  );
            GridControl_Barcodes .DataSource = objDataContext .Inv_ItemBarcodes .Select<DAL.Inv_ItemBarcode, DAL.Inv_ItemBarcode>((Expression<Func<DAL.Inv_ItemBarcode, DAL.Inv_ItemBarcode>>)(x => x)).Where(x => x.ItemID == item.ID);



            var ItemLocations = (from s in db.Inv_Stores
                                from  l in db.Inv_ItemLocations.Where( x => x.StoreID == s.ID && x.ItemID == item.ID ).DefaultIfEmpty ()
                                select new {s.ID,s.Name ,Min =  l.Min.GetValueOrDefault(0) ,Max = l.Max.GetValueOrDefault(0)
                                , Balance = db.Inv_StoreLogs.Where(x => x.ItemID == item.ID && x.StoreID == s.ID).Sum(x => x.ItemQuIN - x.ItemQuOut ),l.ItemLocation  }).ToList();
            DataTable ItemLocationsDT = new DataTable();
            ItemLocationsDT.Columns.Add("ID");
            ItemLocationsDT.Columns.Add("Name");
            ItemLocationsDT.Columns.Add("Min");
            ItemLocationsDT.Columns.Add("Max");
            ItemLocationsDT.Columns.Add("Balance");
            ItemLocationsDT.Columns.Add("Location");
            foreach (var item in ItemLocations )
                ItemLocationsDT.Rows.Add(item.ID, item.Name, item.Min, item.Max, item.Balance, item.ItemLocation);
            gridControl1.DataSource = ItemLocationsDT;

            DataTable PPQDT = new DataTable();
            PPQDT.Columns.Add("FromQty");
            PPQDT.Columns.Add("ToQty");
            PPQDT.Columns.Add("Price");
            var PPQ = from p in db.Inv_ItemPPQs where p.ItemID == item.ID select new { p.FromQty, p.ToQty, p.Price };
            foreach (var item in PPQ.ToList())
                PPQDT.Rows.Add(item.FromQty, item.ToQty, item.Price);
            if (IsNew)
            {
                DAL.Inv_ItemUnit itemUnit = new DAL.Inv_ItemUnit();
                itemUnit.Factor = 1;
                itemUnit.UnitID = 1;
                itemUnit.DefualtBuy = itemUnit.DefualtSell = true;
                itemUnit.SellDiscount = itemUnit.SellPrice = itemUnit.BuyPrice = 0;
                ((Collection<DAL.Inv_ItemUnit>)gridView2.DataSource).Add(itemUnit);
            }
            gc_PPQ.DataSource = PPQDT;
            ChangesMade = false;

        }
        public static string GetMaxCode()
        {
            DAL.ERPDataContext dbs = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                var ST = dbs.Inv_Items .Max(n => n.Code);
                if (ST != null) return ST;
            }
            catch
            {

            }
            return "PRD000000";
        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;

            item = new DAL.Inv_Item();
          
            item.ID = GetNextID();
            item.Code =  Master.GetNextNumberInString(GetMaxCode());
            item.Company = item.GroupID =    1;
           
            IsNew = true;
            GetData();
            base.New();
            ChangesMade = false; 
        }
        public override void Delete()
        {
  
            if (IsNew) return;
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);


            var items = from i in db.Inv_StoreLogs  where i.ItemID  == item.ID  select i.ID;
            if (items.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteItemISUsedInSystem , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PartNumber = item.ID.ToString();
            PartName = txt_Name.Text;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                var ItemUnits = db.Inv_ItemUnits.Where(u =>  u.ItemID == item.ID );
                item = db.Inv_Items.Where(i => i.ID == item.ID).First();
                db.Inv_ItemUnits.DeleteAllOnSubmit (ItemUnits);
                db.Inv_ItemBarcodes.DeleteAllOnSubmit(db.Inv_ItemBarcodes.Where(y => y.ItemID == item.ID));
                db.Inv_Items.DeleteOnSubmit(item );
                db.SubmitChanges();
                CurrentSession.Products = (from c in db .Inv_Items select c).ToList();
                CurrentSession.ProductsUints = (from c in db.Inv_ItemUnits select c).ToList();

                base.Delete();
                New();
            }
        }

        private void txt_Barcode1_EditValueChanged(object sender, EventArgs e)
        {
        //    CheckIfBarcodeISUsed(txt_Barcode1.Text);
        }

        private void frm_Item_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void chk_Serial_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Serial.Checked)
            {
                gridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                for (int i = 1; i < gridView2.RowCount; i++)
                {
                    gridView2.DeleteRow(i);
                }
            }
            else
            {
                gridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.Top  ;

            }
        }
    }
}