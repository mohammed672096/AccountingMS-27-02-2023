using AccountingMS.ReportCustomModels;
using AccountingMS.Reports;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace AccountingMS.Forms
{
    public partial class frm_PrintItemBarcode : DevExpress.XtraEditors.XtraForm
    {
        public static void CheckIfTableExist()
        {
            var db = new accountingEntities();
            try
            {
                if (db.Database.Exists() == false)
                    return;
            }
            catch
            {
            }
            try
            {
                var x = db.BarcodeTemplates.Select(x => x.ID).FirstOrDefault();
            }
            catch (Exception)
            {
                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\Barcode.sql");
                db.Database.ExecuteSqlCommand(cmd, new object[0]);
            }
        }
        List<int> Ids;

        public frm_PrintItemBarcode(List<int> ids = null)
        {
            CheckIfTableExist();
            InitializeComponent();
            Ids = ids;

        }
        tblBranch tbBranch = new ClsTblBranch().GetBranchDataById(1/*Session.CurBranch.brnId*/);

        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as BarcodeData;
            if (row == null) return;
            row.BarcodeCount = 1;
            row.CompanyName = tbBranch.brnName;
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            var view = sender as GridView;
            var row = view.GetRow(e.RowHandle) as BarcodeData;
            accountingEntities db = new accountingEntities();

            if (row == null) return;
            var units = db.tblPrdPriceMeasurments.Where(x => x.ppmBrnId == Session.CurBranch.brnId && x.ppmPrdId == row.ID);

            if (e.Column.FieldName == "UnitID")
            {
                RepositoryItemLookUpEdit itemTemp = new RepositoryItemLookUpEdit();
                var datasource = units.Select(x => new { ID = x.ppmId, Name = x.ppmMsurName }).ToList();
                itemTemp.DataSource = datasource;
                itemTemp.DisplayMember = "Name";
                itemTemp.ValueMember = "ID";
                //datasource.RemoveAll(x => x == ""); 
                //itemTempComboBox.Items.AddRange(datasource);
                e.RepositoryItem = itemTemp;
            }


            if (e.Column.FieldName == "Barcode")
            {
                RepositoryItemComboBox barcodesBox = new RepositoryItemComboBox();
                var selectedUnit = units.FirstOrDefault(x => x.ppmId == row.UnitID);
                if (selectedUnit == null) return;
                var barcodes = db.tblBarcode.Where(x => x.brcPrdMsurId == selectedUnit.ppmId).ToList();
                // var datasource = new List<string>();

                //if (selectedUnit != null)
                //{
                //    datasource.Add(selectedUnit.ppmBarcode1);
                //    datasource.Add(selectedUnit.ppmBarcode2);
                //    datasource.Add(selectedUnit.ppmBarcode3); 
                //}
                //datasource.RemoveAll(x => x == "" || x == null );
                // barcodesBox.Items.AddRange(datasource);
                barcodesBox.Items.AddRange(barcodes.Select(x => x.brcNo).ToList());
                e.RepositoryItem = barcodesBox;
            }


        }


        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as BarcodeData;
            if (row == null) return;
            var ins = new BarcodeData();
            accountingEntities db = new accountingEntities();

            var item = db.tblProducts.SingleOrDefault(x => x.id == row.ID);
            if (item == null)
            {
                gridView1.DeleteRow(e.RowHandle);
                return;
            }
            var units = db.tblPrdPriceMeasurments.Where(x => x.ppmPrdId == item.id);
            switch (e.Column.FieldName)
            {
                case nameof(ins.ID):
                    row.ProductName = item.prdName;
                    row.Code = item.prdNo;
                    row.UnitID = units.Select(x => x.ppmId).FirstOrDefault();

                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, gridView1.Columns[nameof(row.UnitID)], row.UnitID));
                    break;
                case nameof(ins.UnitID):

                    var unit = units.SingleOrDefault(x => x.ppmId == row.UnitID);
                    if (unit == null) return;

                    var barcodes = db.tblBarcode.Where(x => x.brcPrdMsurId == unit.ppmId).ToList();
                    row.Barcode = barcodes.FirstOrDefault()?.brcNo;
                    row.Price = clsTbPrdMsur.GetPrdPriceMsurSalePrice(unit.ppmId);
                    row.UnitName = unit.ppmMsurName;
                    break;
            }
        }
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        BindingList<BarcodeData> products;
        public BindingList<BarcodeData> Productes
        { get { if (products == null) products = new BindingList<BarcodeData>(); return products; } set => products = value; }


        private void frm_PrintItemBarcode_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridControl1.DataSource = Productes;
            var ins = new BarcodeData();
            accountingEntities db = new accountingEntities();

            lookUpEdit1.Properties.DataSource = db.BarcodeTemplates.OrderByDescending(x => x.IsDefault).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.EditValue = db.BarcodeTemplates.OrderByDescending(x => x.IsDefault).FirstOrDefault().ID;

            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["Template"].Visible = false;
            lookUpEdit1.Properties.Columns["ID"].Visible = false;
            lookUpEdit1.Properties.Columns["IsDefault"].Visible = false;
            lookUpEdit1.Properties.ShowHeader = false;


            RepositoryItemSearchLookUpEdit repoItems = new RepositoryItemSearchLookUpEdit();
            repoItems.DataSource = db.tblProducts.Where(x => x.prdBrnId == Session.CurBranch.brnId).Select(x => new { ID = x.id, Name = x.prdName }).ToList();
            repoItems.ValueMember = "ID";
            repoItems.DisplayMember = "Name";


            RepositoryItemLookUpEdit repoUints = new RepositoryItemLookUpEdit();
            repoUints.DataSource = db.tblPrdPriceMeasurments.Where(x => x.ppmBrnId == Session.CurBranch.brnId).Select(x => new { ID = x.ppmId, Name = x.ppmMsurName }).ToList();
            repoUints.ValueMember = "ID";
            repoUints.DisplayMember = "Name";

            RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
            spinEdit.IsFloatValue = false;
            spinEdit.MinValue = 1;
            spinEdit.MaxValue = 100000;

            RepositoryItemSpinEdit repoSpinEdit = new RepositoryItemSpinEdit();


            gridControl1.RepositoryItems.Add(repoItems);
            gridControl1.RepositoryItems.Add(spinEdit);
            gridControl1.RepositoryItems.Add(repoSpinEdit);
            gridControl1.RepositoryItems.Add(repoUints);

            gridView1.Columns[nameof(ins.ID)].ColumnEdit = repoItems;
            gridView1.Columns[nameof(ins.BarcodeCount)].ColumnEdit = spinEdit;
            gridView1.Columns[nameof(ins.Price)].ColumnEdit = repoSpinEdit;
            gridView1.Columns[nameof(ins.UnitID)].ColumnEdit = repoUints;
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            gridControl1.RepositoryItems.Add(buttonEdit);
            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            GridColumn clmnDelete = new GridColumn() { Name = "Delete", FieldName = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 14, Width = 15 };
            buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;

            GridColumn clmnDeleteBarcode = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 100, Width = 15 };
            gridView1.Columns.Add(clmnDelete);



            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.InitNewRow += GridView1_InitNewRow;

            if (Ids != null)
                foreach (var id in Ids)
                {
                    gridView1.AddNewRow();
                    gridView1.SetFocusedRowCellValue("ID", id);

                }
        }
        private void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView;

            if (view.FocusedRowHandle >= 0)
            {

                view.DeleteSelectedRows();

            }

        }
        private void btn_Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Print(false);

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print(true);

        }
        void Print(bool fast)
        {
            var source = new List<BarcodeData>();
            foreach (var item in Productes)
            {
                for (int i = 0; i < item.BarcodeCount; i++)
                {
                    source.Add(item);
                }
            }

            rtp_Barcode.Print(source, Convert.ToInt32(lookUpEdit1.EditValue), fast);
        }
    }
}
