using DevExpress.Data;
using DevExpress.DataProcessing;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class FormInventoryBalance : XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private accountingEntities db = new accountingEntities();

        private static FormInventoryBalance instance;
        public static FormInventoryBalance Instance { get { if (instance == null || instance.IsDisposed == true) instance = new FormInventoryBalance(); return instance; } }

        private InventoryBalanceing main { get => inventoryBalanceingBindingSource.Current as InventoryBalanceing; set { inventoryBalanceingBindingSource.DataSource = value; } }
        private ICollection<InventoryBalancingDetail> Detail => gridView1.DataSource as ICollection<InventoryBalancingDetail>;

        readonly RepositoryItemLookUpEdit repoItemUnite = new RepositoryItemLookUpEdit();
        ClsTblProduct clsTblProduct = new ClsTblProduct();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblProductQunatity clsTblProductQunatity = new ClsTblProductQunatity();
        ClsTblBarcode clsTbBarcode = new ClsTblBarcode();
        public FormInventoryBalance()
        {
            InitializeComponent();
            this.Shown += FormInventoryBalance_Shown;

            colCost.SummaryItem.SummaryType = SummaryItemType.Custom;
            colPrice.SummaryItem.SummaryType = SummaryItemType.Custom;


            gridView1.CustomSummaryCalculate += GridView1_CustomSummaryCalculate;
        }
        double totalPrice = 0;
        double totalCost = 0;
        private void GridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.IsTotalSummary)
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                if (item.FieldName == colPrice.FieldName)
                {
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            totalPrice = 0;
                            break;
                        case CustomSummaryProcess.Calculate:
                            double price = (double)view.GetRowCellValue(e.RowHandle, colPrice);
                            double realQty = (double)view.GetRowCellValue(e.RowHandle, colRealQty);
                            if (realQty > 0)
                                totalPrice += (price * realQty);
                            break;
                        case CustomSummaryProcess.Finalize:
                            e.TotalValue = totalPrice;
                            break;
                    }
                }
                if (item.FieldName == colCost.FieldName)
                {
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            totalCost = 0;
                            break;
                        case CustomSummaryProcess.Calculate:
                            double cost = (double)view.GetRowCellValue(e.RowHandle, colCost);
                            double realQty = (double)view.GetRowCellValue(e.RowHandle, colRealQty);
                            if (realQty > 0)
                                totalCost += (cost * realQty);
                            break;
                        case CustomSummaryProcess.Finalize:
                            e.TotalValue = totalCost;
                            break;
                    }
                }
            }
        }

        private void FormInventoryBalance_Load(object sender, EventArgs e)
        {
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText; ;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.RowUpdated += GridView1_RowUpdated;
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;
            repoUOM.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurList.Select(x => new { UnitID = x.ppmId, x.ppmMsurName, x.ppmStatus }).ToList();
            repoUOM.DisplayMember = "ppmMsurName";
            repoUOM.ValueMember = "UnitID";
            RepoProducts.DataSource = this.clsTblProduct.GetProductList.Select(x => new { x.id, x.prdName }).ToList();
            RepoProducts.DisplayMember = "prdName";
            RepoProducts.ValueMember = "id";

            BranchIDLookUpEdit.Properties.DataSource = db.tblBranches.Select(x => new { x.brnId, x.brnName, x.brnNameEn }).ToList();
            BranchIDLookUpEdit.Properties.DisplayMember = "brnName";
            BranchIDLookUpEdit.Properties.ValueMember = "brnId";
            BranchIDLookUpEdit.EditValue = db.tblBranches.FirstOrDefault()?.brnId;
        }



        public FormInventoryBalance(int id)
        {
            InitializeComponent();
            db = new accountingEntities();



            main = db.InventoryBalanceings.Find(id);
            GetDetails();
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            var row = view.GetRow(e.RowHandle) as InventoryBalancingDetail;
            if (row == null) return;
            if (row.Shotage > 0)
                e.Appearance.BackColor = Color.FromArgb(80, DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning);
            else if (row.Surplus > 0)
                e.Appearance.BackColor = Color.FromArgb(80, DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question);

            else
                e.Appearance.BackColor = Color.FromArgb(70, DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText);

        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "barCode")
            {
                int UnitID = Convert.ToInt32(gridView1.GetRowCellValue(e.ListSourceRowIndex, colUnitID));
                var obj = clsTbBarcode.GetBarcodeObjByPrdMsurId(UnitID);
                if (obj != null) e.DisplayText = obj.brcNo;
            }
        }

        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            GridView view = sender as GridView;
            var rows = (ICollection<AccountingMS.InventoryBalancingDetail>)gridView1.DataSource;
            if (rows == null) return;
            var groupedRows = from r in rows
                              group r by r.ProductID
                               into g
                              where g.Count() > 1
                              select g;


            foreach (var row in groupedRows)
            {

                var sortedList = row.OrderByDescending(x => x.ID);
                var detail = sortedList.First();
                for (int i = 1; i < sortedList.Count(); i++)
                {
                    var rowIndex = rows.ToList().IndexOf(sortedList.ToList()[i]);
                    view.FocusedRowHandle = view.GetRowHandle(rowIndex);
                    view.TopRowIndex = view.GetRowHandle(rowIndex);
                    view.DeleteRow(view.GetRowHandle(rowIndex));
                }
            }
        }

        #region Methods

        void GetDetails()
        {
            db.InventoryBalancingDetails.Where(x => x.MainID == main.ID).Load();
            gridControl1.DataSource = db.InventoryBalancingDetails.Local.ToBindingList();
        }
        void New()
        {
            db = new accountingEntities();
            main = new InventoryBalanceing()
            {
                Date = DateTime.Now,
            };
            GetDetails();
        }

        private bool IsValidate()
        {
            int erorr = 0;
            if (string.IsNullOrWhiteSpace(NameTextEdit.Text))
            {
                erorr++;
                NameTextEdit.ErrorText = "حقل مطلوب";
            }
            if (string.IsNullOrWhiteSpace(EmployeeNameTextEdit.Text))
            {
                erorr++;
                EmployeeNameTextEdit.ErrorText = "حقل مطلوب";
            }
            if (string.IsNullOrWhiteSpace(NotesMemoEdit.Text))
            {
                erorr++;
                NotesMemoEdit.ErrorText = "حقل مطلوب";
            }

            if ((BranchIDLookUpEdit.EditValue is int branchID && branchID > 0) == false)
            {
                erorr++;
                BranchIDLookUpEdit.ErrorText = "حقل مطلوب";
            }

            return erorr == 0;
        }
        void Save()
        {
            var detail = gridControl1.DataSource as ICollection<InventoryBalancingDetail>;

            IDTextEdit.Focus();
            if (!IsValidate()) return;

            if (main.ID == 0) db.InventoryBalanceings.Add(main);

            var totalSurplusSale = detail.Where(x => x.Surplus > 0).Sum(x => x.TotalPrice);
            var totalShotageSale = detail.Where(x => x.Shotage > 0).Sum(x => x.TotalPrice);
            main.TotalSurplusValueSale = totalSurplusSale;
            main.TotalShortageValueSale = totalShotageSale;
            main.NetProfitOrLosesSale = totalSurplusSale - totalShotageSale;
            db.SaveChanges();

            foreach (var item in Detail) item.MainID = main.ID;

            db.SaveChanges();

            //ClsPrdQuantityOperations.CalculateProductQty(Detail.Select(x => x.ProductID).ToList());
            MessageBox.Show("تم الحفظ بنجاح ");
            New();
        }

        private void GetPrdBarcodeData(string barcode)
        {

            if (BranchIDLookUpEdit.EditValue != null && BranchIDLookUpEdit.EditValue is int BranchID && BranchID > 0)
                main.BranchID = BranchID;
            else
            {
                MessageBox.Show("برجاء تحديد الفرع اولا");
                return;
            }
            if (string.IsNullOrWhiteSpace(barcode)) return;
            if (!ValidateBarcodeNo(barcode, out int prdMsurId)) return;
            //   var PrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(prdMsurId);
            var PrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(prdMsurId);
            if (PrdMsur == null) return;

            gridView1.AddNewRow();
            gridView1.SetFocusedRowCellValue(colProductID, PrdMsur.ppmPrdId);
            gridView1.SetFocusedRowCellValue(colUnitID, PrdMsur.ppmId);
            gridControl1.Refresh();
            textEdit1.EditValue = null;
            textEdit1.Focus();
        }
        private bool ValidateBarcodeNo(string barcode, out int prdMsurId)
        {
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcode);
            bool isValid = tbBarcode != null ? true : false;
            prdMsurId = tbBarcode != null ? tbBarcode.brcPrdMsurId : 0;
            return isValid;
        }
        private bool ValidateReplacProdact(int Pid, int Uid)
        {
            if (Uid == 0) return true;
            int index = gridView1.FocusedRowHandle;
            int Count = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (i == index) continue;
                var row = gridView1.GetRow(i) as InventoryBalancingDetail;
                if (row == null) continue;
                if (row.ProductID == Pid && row.UnitID == Uid)
                    Count++;
            }
            return Count == 0;
        }
        #endregion

        #region Event


        private void FormInventoryBalance_Shown(object sender, EventArgs e)
        {

            if (main == null || main.ID == 0)
                New();
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            //if (e.Column.FieldName == "supMsur")
            //    e.RepositoryItem = repositoryItemLookUpEditMeasurment;

            if (e.Column.FieldName == "UnitID")
            {
                RepositoryItemLookUpEdit repo = new RepositoryItemLookUpEdit();
                int ProductID = 0;
                if (int.TryParse(gridView1.GetFocusedRowCellValue(colProductID)?.ToString(), out ProductID))
                {
                    repo.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(ProductID).Select(x => new { UnitID = x.ppmId, x.ppmMsurName, x.ppmStatus });
                    repo.DisplayMember = "ppmMsurName";
                    repo.ValueMember = "UnitID";
                    gridControl1.RepositoryItems.Add(repo);

                    //CustomLookUpItemUnitColumn(repo);
                    e.RepositoryItem = repo;
                }
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }


        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as AccountingMS.InventoryBalancingDetail;
            if (row == null) return;
            //string BarCodeItemUnit = e.Value.ToString();
            //double value = 0.0;
            if (e.Column == gridColumn1)
            {
                GetPrdBarcodeData(gridView1.GetRowCellValue(e.RowHandle, gridColumn1)?.ToString());
            }
            switch (e.Column.FieldName)
            {

                case nameof(row.ProductID):
                    var unit = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(row.ProductID).FirstOrDefault(x => x.ppmStatus == 1);
                    if (unit != null)
                    {
                        row.UnitID = unit.ppmId;
                        goto case nameof(row.UnitID);
                    }
                    break;
                case nameof(row.UnitID):
                    //التحقق من عدم تكرار الصنف ووحدتة
                    if (!ValidateReplacProdact(row.ProductID, row.UnitID))
                    {
                        gridView1.SetColumnError(colUnitID, "تكرار الصنف ووحدتة");
                        return;
                    }
                    //عرض الرصيد الحالي
                    var Unit = clsTbPrdMsur.GetPrdPriceMsurById(row.UnitID);

                    // الكميه الاساسيه للصنف 
                    //double qty = ClsPrdQuantityOperations.GetProductBalanceInDate(row.ProductID, main.BranchID, main.Date);

                    row.Qty = 0;
                    //row.Qty = qty;
                    row.Cost = ((double)Unit.ppmPrice.Value);
                    row.Price = clsTbPrdMsur.GetPrdPriceMsurSalePrice(Unit.ppmId);

                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colQty, row.Qty));
                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colCost, row.Cost));
                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colPrice, row.Price));
                    break;
                case nameof(row.RealQty):
                    row.Shotage = 0;
                    row.Surplus = 0;
                    var num = row.RealQty - row.Qty;
                    if (num > 0)
                    {
                        row.Surplus = num;
                        GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colSurplus, row.Surplus));
                    }
                    else
                    {
                        row.Shotage = Math.Abs(num);
                        GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colShotage, row.Shotage));
                    }
                    break;
                case nameof(row.Qty):
                    row.RealQty = row.Qty;
                    break;
                case nameof(row.Shotage):
                case nameof(row.Surplus):
                case nameof(row.Price):
                case nameof(row.Cost):
                    //row.TotalPrice = row.Price * row.RealQty;// ( row.Surplus + row.Shotage);
                    //row.TotalCost = row.Cost * row.RealQty;//(row.Surplus + row.Shotage) ;
                    row.TotalPrice = row.Price * (row.Surplus + row.Shotage);
                    row.TotalCost = row.Cost * (row.Surplus + row.Shotage);
                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colTotalCost, row.TotalCost));
                    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colTotalPrice, row.TotalPrice));
                    break;
                default:
                    break;

            }

            UpdateTotal();
        }
        void UpdateTotal()
        {
            var detail = gridControl1.DataSource as ICollection<InventoryBalancingDetail>;
            if (detail != null)
            {
                var totalSurplus = detail.Sum(x => x.Surplus);
                var totalShotage = detail.Sum(x => x.Shotage);
                TotalSurplusQtyTextEdit.EditValue = totalSurplus;
                TotalShortageQtyTextEdit.EditValue = totalShotage;

                var totalSurplusCost = detail.Where(x => x.Surplus > 0).Sum(x => x.TotalCost);
                var totalShotageCost = detail.Where(x => x.Shotage > 0).Sum(x => x.TotalCost);
                TotalSurplusValueTextEdit.EditValue = totalSurplusCost;
                TotalShortageValueTextEdit.EditValue = totalShotageCost;

                var totalSurplusSale = detail.Where(x => x.Surplus > 0).Sum(x => x.TotalPrice);
                var totalShotageSale = detail.Where(x => x.Shotage > 0).Sum(x => x.TotalPrice);
                TotalSurplusValueSaleTextEdit.EditValue = totalSurplusSale;
                TotalShortageValueSaleTextEdit.EditValue = totalShotageSale;


                NetProfitOrLosesTextEdit.EditValue = detail.Sum(x => x.TotalCost);
                NetProfitOrLosesSaleTextEdit.EditValue = detail.Sum(x => x.TotalPrice);
            }
        }
        #endregion

        private void btnInsertAll_Click(object sender, EventArgs e)
        {
            int BranchID = 0;
            if (BranchIDLookUpEdit.EditValue != null && int.TryParse(BranchIDLookUpEdit.EditValue.ToString(), out BranchID) && BranchID > 0)
                main.BranchID = BranchID;
            else
            {
                MessageBox.Show("برجاء تحديد الفرع اولا");
                return;
            }
            flyDialog.WaitForm(this, 1);
            var BaseUnits = this.clsTbPrdMsur.GetPrdPriceMsurList.Where(x => x.ppmStatus == 1).GroupBy(x => x.ppmPrdId).Select(x => new
            {
                ProductID = x.Key,
                UnitID = x.FirstOrDefault() != null ? x.First().ppmId : 0,
            }).ToList();
            foreach (var item in BaseUnits)
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue(colProductID, item.ProductID);
                gridView1.SetFocusedRowCellValue(colUnitID, item.UnitID);
            }
            UpdateTotal();
            flyDialog.WaitForm(this, 0);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<InventoryBalancingDetail> items = new List<InventoryBalancingDetail>();
            foreach (var item in Detail)
            {
                if (item.Shotage == 0 && item.Surplus == 0)
                    items.Add(item);
                //     Detail.Remove(item);
            }

            foreach (var item in items)
            {
                Detail.Remove(item);
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetPrdBarcodeData(textEdit1.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //GridView view = sender as GridView;
            var rows = (ICollection<AccountingMS.InventoryBalancingDetail>)gridView1.DataSource;
            rows.ForEach(x =>
            {
                x.RealQty = Convert.ToInt32(spinEdit1.EditValue);
                x.Shotage = ((x.RealQty - x.Qty) > 0) ? 0 : Math.Abs(x.RealQty - x.Qty);
                x.Surplus = ((x.RealQty - x.Qty) > 0) ? Math.Abs(x.RealQty - x.Qty) : 0;
                x.TotalCost = x.Cost * (x.Surplus + x.Shotage);
                x.TotalPrice = x.Price * (x.Surplus + x.Shotage);
                //x.TotalCost = x.Cost * x.RealQty;// (x.Surplus+ x.Shotage) ;
                //x.TotalPrice = x.Price * x.RealQty;//( x.Surplus + x.Shotage);

            });
            UpdateTotal();
            gridView1.RefreshData();
        }

        private void BranchIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (main == null) return;
            int BranchID = 0;
            if (BranchIDLookUpEdit.EditValue != null && int.TryParse(BranchIDLookUpEdit.EditValue.ToString(), out BranchID) && BranchID > 0)
                main.BranchID = BranchID;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            gridView1.DeleteSelectedRows();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var rows = (ICollection<AccountingMS.InventoryBalancingDetail>)gridView1.DataSource;
            rows.ForEach(x =>
            {
                var Unit = clsTbPrdMsur.GetPrdPriceMsurById(x.UnitID);
                x.Cost = ((double)Unit.ppmPrice.Value);
                x.Price = clsTbPrdMsur.GetPrdPriceMsurSalePrice(Unit.ppmId);
                x.TotalCost = x.Cost * (x.Surplus + x.Shotage);
                x.TotalPrice = x.Price * (x.Surplus + x.Shotage);
            });
            UpdateTotal();
        }
    }
}
