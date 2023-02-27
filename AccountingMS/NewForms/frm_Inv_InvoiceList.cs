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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;
using static ERP.Master;

namespace ERP.Forms
{
    public partial class frm_Inv_InvoiceList : frm_Master
    {
        Master.InvoiceType InvoiceType;
        public frm_Inv_InvoiceList(Master.InvoiceType _InvoiceType)
        {
            InitializeComponent();
            InvoiceType = _InvoiceType;
            dt_From.DateTime = DateTime.Now.Date;
        }
        
        public frm_Inv_InvoiceList(Master.InvoiceType _InvoiceType, PartTypes partType, int PartID)
        {
            InitializeComponent();
            InvoiceType = _InvoiceType;
            LookUpEdit_PartType.EditValue = partType;
            LookUpEdit_PartID .EditValue = PartID;
        }
        public override void frm_Load(object sender, EventArgs e)
        {

            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //   btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            base.frm_Load(sender, e);
            Master.RestoreGridLayout(gridView1, this);
            gridView1.TranslateColumns();

            gridView1.OptionsDetail.DetailMode = DetailMode.Classic;
            gridView1.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsDetail.ShowDetailTabs = true;
            gridView1.DetailVerticalIndent = 25;



            repoSize.PopulateColumns();
            repoSize.Columns["ID"].Visible = false;


            repoColor.PopulateColumns();
            repoColor.Columns["ID"].Visible = false;

            ItemsRepo.ValueMember =
            UOMRepo.ValueMember =
            BranchRepo.ValueMember =
            repoSize.ValueMember =
            repoColor.ValueMember =
            LookUpEdit_PartType.Properties.ValueMember =
            LookUpEdit_PartID.Properties.ValueMember =
            lkp_Store.Properties.ValueMember = "ID";

            ItemsRepo.DisplayMember =
            UOMRepo.DisplayMember =
             BranchRepo.DisplayMember =
             repoSize.DisplayMember =
             repoColor.DisplayMember =
              LookUpEdit_PartType.Properties.DisplayMember =
             LookUpEdit_PartID.Properties.DisplayMember =
             lkp_Store.Properties.DisplayMember = "Name";

            gridControl1.RepositoryItems.AddRange(new RepositoryItem[]
            {
                 ItemsRepo      ,
                 UOMRepo        ,
                 BranchRepo     ,
                 repoSize       ,
                 repoColor      ,
            });

            gridView1.Columns["StoreID"].ColumnEdit = BranchRepo;
            gridView1.Columns["DiscountRatio"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric ;
            gridView1.Columns["DiscountRatio"].DisplayFormat.FormatString  = "p";

        }
        RepositoryItemLookUpEdit ItemsRepo = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit UOMRepo = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit BranchRepo = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoSize = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoColor = new RepositoryItemLookUpEdit();
        public override void Delete()
        {
            deleteToolStripMenuItem.PerformClick();
        }
        public override void RefreshData()
        {

            GetGRidData();

            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            var UOM = from u in objDataContext.Inv_UOMs select u;
            var items = from c in objDataContext.Inv_Items select new { c.ID, c.Name };
            var branches = from s in objDataContext.Inv_Stores select new { s.ID, s.Name };

            repoColor.DataSource = (from c in objDataContext.Inv_Colors select c).ToList();
            repoSize.DataSource = (from s in objDataContext.Inv_Sizes select s).ToList();
            UOMRepo.DataSource = UOM.ToList();
            ItemsRepo.DataSource = items.ToList();
            lkp_Store.Properties.DataSource = BranchRepo.DataSource = branches.ToList();
          


        }
        void GetGRidData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var result = from i in db.Inv_Invoices
                         from u in db.St_Users.Where(x => x.ID == i.UserID)
                         where i.SecresyLevel <= CurrentSession.user.SalesInvoiceSececyLevel 
                         && i.InvoiceType ==(int) InvoiceType 
                         select new
                         {
                             i.ID,
                             i.Code,
                             i.PartID,
                             i.StoreID,
                             i.Date,
                             i.DeliveryDate,
                             i.DiscountRatio,
                             i.DueDate,
                             i.PostState,
                             i.Net,
                             OuterPay = (double?)db.Acc_Pays.Where(x => x.SourceType == 6 && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0,
                             PayStatus = "",
                             Remains = i.Net - ((double?)db.Acc_Pays.Where(x => x.SourceType == 6 && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0),
                             i.Source, 
                             i.SourceID,
                             i.IsApproved ,
                             UserID = u.UserName,
                             i.Notes,
                             NumberOFTakeBills = db.Inv_ItemTakes.Where(x => x.Type == 1 && x.TypeID == i.ID).Count(),
                             Details = (from d in db.Inv_InvoiceDetails
                                        from l in db.Inv_StoreLogs.Where(x => x.TypeID == d.ID && x.Type == 6).DefaultIfEmpty()
                                        where d.InvoiceID == i.ID
                                        select new
                                        {
                                            d.ItemID,
                                            d.ItemUnitID,
                                            d.ItemQty,
                                            d.Price,
                                            d.TotalPrice,
                                            l.Serial,
                                            l.Size,
                                            l.Color,
                                            l.ExpDate
                                        }    ).ToList(),
                             Bills = (from d in db.Inv_InvoiceDetails 
                                      from itm in db.Inv_Items.Where(x => x.ID == d.ItemID)
                                      from uom in db.Inv_UOMs.Where(x => x.ID == d.ItemUnitID)
                                      where db.Inv_Invoices.Select(x => x.ID).Contains(d.InvoiceID )
                                      group d.ItemQty  by new { ItemID = itm.Name, ItemUnitID = uom.Name } into Grouped
                                      select new
                                      {
                                          Grouped.Key.ItemID,
                                          Grouped.Key.ItemUnitID,
                                          Total = Grouped.Sum(),
                                      }
                                         ).ToList()
                                         ,
                                         CashNotes=(db.Acc_CashNotes.Where(x => x.IsCashNote && x.LinkType == 1 && x.LinkID == i.ID)
                                         .Select (x=>new {x.Code  ,x.Date ,x.Amount  })).ToList()




                         };
           
            // apply Filters 
            //if (dt_From.EditValue != null)
            //    result = result.Where(x => x.Date >= dt_From.DateTime.Date);
            //if (dt_To.EditValue != null)
            //    result = result.Where(x => x.Date <= dt_To.DateTime.Date);
            //if (LookUpEdit_PartID  .EditValue .ValidAsIntNonZero())
            //    result = result.Where(x => x.PartID  == Convert.ToInt32(LookUpEdit_PartID.EditValue));
            //if (lkp_Store.EditValue != null && lkp_Store.EditValue != DBNull.Value)
            //    result = result.Where(x => x.StoreID == Convert.ToInt32(lkp_Store.EditValue));
            ////if (lkp_Drawer.EditValue != null && lkp_Drawer.EditValue != DBNull.Value)
            ////    result = result.Where(x => x.DrawerID == Convert.ToInt32(lkp_Drawer.EditValue));


            gridControl1.DataSource = result.ToList();
            //  gridView1.re

        }
        public override void New()
        {
            frm_Main.OpenForm(new frm_Inv_Invoice(list, InvoiceType));
        }
        public override void Save()
        {

        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            gridView1.OptionsPrint.PrintFilterInfo = true;
            Reporting.rpt_GridReport.Print(gridControl1, this.Text, gridView1.FilterPanelText, (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes) ? true : false);
            base.Print();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {

                frm_Main.OpenForm(new frm_Inv_Invoice(Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")), list), openNew: true);
            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            if (sender == null) return;
            list = new List<int>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                list.Add(Convert.ToInt32(gridView.GetRowCellValue(i, "ID")));

            }
        }

        private void frm_Inv_InvoiceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(gridView1, this);
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = e.View as GridView;

            view.OptionsView.ShowFooter = false;
            view.OptionsView.ShowViewCaption = true;
            Master.TranslateGridColumn(view);


            if (view.LevelName == "Details")
            {
                view.ViewCaption = LangResource.Details;
                view.Columns["ItemID"].ColumnEdit = ItemsRepo;
                view.Columns["ItemUnitID"].ColumnEdit = UOMRepo;
                view.Columns["Color"].ColumnEdit = repoColor;
                view.Columns["Size"].ColumnEdit = repoSize;
                repoColor.NullText = repoSize.NullText = "";
                view.SynchronizeClones = true;
                view.Name = "Details";
                Master.RestoreGridLayout(view, this);
            }

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            if (!CanPerformDelete()) return;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                List<int> ids = new List<int>();
                foreach (var item in gridView1.GetSelectedRows())
                {
                    ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "ID")));

                }

                frm_Inv_Invoice.Delete(ids, this.Name,InvoiceType );
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            ////var UserCanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == "frm_Inv_Invoice" + "_Print");
            ////if (UserCanPrint.Count() > 0) CanPrint = (bool)UserCanPrint.First().PrivilegeValue;
            ////if (!CanPrint) { XtraMessageBox.Show(LangResource.CantEditNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            List<int> ids = new List<int>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "ID")));
            }
            frm_Inv_Invoice.Print(ids, this.Name, InvoiceType);
        }
        bool IsClearingFilters;
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            IsClearingFilters = true;
            dt_From.EditValue = dt_To.EditValue = LookUpEdit_PartType .EditValue  = lkp_Store.EditValue = null;
            IsClearingFilters = false;
            GetGRidData();
        }

        private void Filters_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsClearingFilters)
                GetGRidData();
        }

        private void Filter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
                return;

            string btnName = e.Button.Tag.ToString();
            if (btnName == "Clear")
            {

                ((DevExpress.XtraEditors.BaseEdit)sender).EditValue = null;
            }
        }

        private void gridView1_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            if (e.RelationName == "Details")
                e.RelationName = LangResource.Details;
            if (e.RelationName == "Bills")
                e.RelationName = LangResource.ItemTakeBills;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            int h = e.RowHandle;
            GridView view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName == "PostState")
            {

                if (view.GetRowCellValue(e.RowHandle, "PostState") != null &&
                    view.GetRowCellValue(e.RowHandle, "PostState") != DBNull.Value)
                {
                    //if (Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "Status")) == true)
                    //{
                    //}
                    //else if (Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "PostState")) == false
                    //    && Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "NumberOFTakeBills")) == 0)
                    //    e.Appearance.BackColor = System.Drawing.Color.Yellow;
                    //else if (Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "PostState")) == false
                    //   && Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "NumberOFTakeBills")) > 0)
                    //    e.Appearance.BackColor = System.Drawing.Color.LightYellow;

                    // e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
                }
            }
            else if (e.Column.FieldName == "PayStatus")
            {
                //    if(view.GetRowCellValue(e.RowHandle, "PayType") == null ||
                //        view.GetRowCellValue(e.RowHandle, "PayType") == DBNull.Value)
                //        e.Graphics.FillRectangle(new SolidBrush(Color.Orange ), e.Bounds);
                //    else if(Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "PayType")) == false )
                //        e.Graphics.FillRectangle(new SolidBrush(Color.Red ), e.Bounds);

                if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Remains")) <= 0)
                {
                    e.DisplayText = LangResource.FullyPaid;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
                }
                else if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Remains")) > 0
                    && Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Remains")) < Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Net")))
                {
                    e.DisplayText = LangResource.PartiallyPaid;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Orange), e.Bounds);
                }
                else if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Remains")) == Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Net")))
                {
                    e.DisplayText = LangResource.NotPaid;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                }

            }
            else if (e.Column.FieldName == "Source")
            {
                    e.DisplayText = Master.Prossess [e.CellValue.ToInt()]; 
            }
            
        }

        private void covertToToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    if (gridView1.SelectedRowsCount == 0) return;
        //    DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

        //    foreach (var item in gridView1.GetSelectedRows())
        //    {
        //        if (db.Inv_Invoices.Where(x => x.ID == Convert.ToInt32(gridView1.GetRowCellValue(item, "ID"))).SingleOrDefault().PostState == 0)
        //            frm_Main.OpenForm(new frm_ItemTake(1, Convert.ToInt32(gridView1.GetRowCellValue(item, "ID"))), openNew: true, CloseIfOpen: false);
        //    }

        }
    }
}