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
namespace ERP.Forms
{
    public partial class frm_CashNoteList : frm_Master
    {
        RepositoryItemLookUpEdit repoDrawer = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoStore = new RepositoryItemLookUpEdit();
        private bool IsCashIn;
        private byte ProccessID;
        public frm_CashNoteList(bool _IsCashIn)
        {
            InitializeComponent();
            dt_From.DateTime = DateTime.Now.Date;
            IsCashIn = _IsCashIn;
            this.Name = (IsCashIn) ? "frm_CashNoteInList" : "frm_CashNoteOutList";

        }
        public override void frm_Load(object sender, EventArgs e)
        {

            this.Text = (IsCashIn) ? LangResource.CashNoteIns : LangResource.CashNoteOuts;
            this.Name = (IsCashIn) ? "frm_CashNoteInList" : "frm_CashNoteOutList";
            ProccessID = (byte)((IsCashIn) ? 16 : 17);


            btn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            base.frm_Load(sender, e);
            Master.RestoreGridLayout(gridView1, this);
            Master.TranslateGridColumn(gridView1);
            lkp_Drawer.Properties.ValueMember =
                lkp_Store.Properties.ValueMember =
                    repoStore.ValueMember =
                    repoDrawer.ValueMember = "ID";

            lkp_Drawer.Properties.DisplayMember =
                lkp_Store.Properties.DisplayMember =
                    repoStore.DisplayMember =
                    repoDrawer.DisplayMember = "Name";

            gridControl1.RepositoryItems.AddRange(new RepositoryItem[]
            {

                repoStore     , 
                repoDrawer
            });
             
            gridView1.Columns["StoreID"].ColumnEdit = repoStore;

        }
        public override void Delete()
        {
            deleteToolStripMenuItem.PerformClick();
        }
        public override void RefreshData()
        {

            GetGRidData();

            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            
            var branches = from s in objDataContext.Inv_Stores select new { s.ID, s.Name };
             
            lkp_Store.Properties.DataSource = repoStore.DataSource = branches.ToList();
           
            lkp_Drawer.Properties.DataSource = repoDrawer.DataSource = CurrentSession.UserAccessibleDrawer.Select(X => new { X.ID, X.Name });



        }
        void GetGRidData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

          
            

            var result = from e in db.Acc_CashNotes 
                        from u in db.St_Users.Where(x => x.ID == e.UserID).DefaultIfEmpty()
                         from p in (
                         db.Pr_Vendors.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Vendor), x.Name })
                                        .Concat(db.Sl_Customers.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Customer), x.Name }))
                                        .Concat(db.HR_Employees.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Employee), x.Name }))
                                        .Concat(db.Acc_Accounts.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Account), x.Name }))

                         ).Where(x => x.PartID == e.PartID && x.PartType == e.PartType).DefaultIfEmpty()
                         where e.IsCashNote  == IsCashIn 
                        select new
                        {
                            e.ID ,
                            e.Code,
                            p.PartType,
                            p.Name,
                            e.StoreID ,
                            e.Date,
                            e.Notes,
                            e.Amount,
                            e.DiscountValue,
                            Total = e.Amount + e.DiscountValue,
                            Source =e.LinkType  ,
                            SourceCode = e.LinkID ,
                            u.UserName
                        };


            

            // apply Filters 
            if (dt_From.EditValue != null)
                result = result.Where(x => x.Date >= dt_From.DateTime.Date);
            if (dt_To.EditValue != null)
                result = result.Where(x => x.Date <= dt_To.DateTime.Date);
            if (lkp_Store.EditValue != null && lkp_Store.EditValue != DBNull.Value)
                result = result.Where(x => x.StoreID == Convert.ToInt32(lkp_Store.EditValue));
          
            gridControl1.DataSource = result.ToList();
            gridView1.Columns["ID"].Visible = gridView1.Columns["ID"].OptionsColumn.ShowInCustomizationForm = false; 
            //  gridView1.re

        }
        public  override void New()
        {
            frm_Main.OpenForm(new frm_CashNote(IsCashIn ));
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

                frm_Main.OpenForm(new frm_CashNote( Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"))), openNew: true);
            }
        }

        private void frm_CashNoteList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(gridView1, this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
  //          //var UserCanDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == "frm_CashNote" + "_Delete");
  //          //if (UserCanDelete.Count() > 0) CanDelete = (bool)UserCanDelete.First().PrivilegeValue;
  ////if (!CanPerformDelete()) return;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                List<int> ids = new List<int>();
                foreach (var item in gridView1.GetSelectedRows())
                {
                    ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "Code")));

                }

                frm_CashNote.Delete(ids, IsCashIn, this.Name , ProccessID);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            ////var UserCanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == "frm_CashNote" + "_Print");
            ////if (UserCanPrint.Count() > 0) CanPrint = (bool)UserCanPrint.First().PrivilegeValue;
            ////if (!CanPrint) { XtraMessageBox.Show(LangResource.CantEditNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            List<int> ids = new List<int>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "Code")));
            }
            frm_CashNote.Print(ids, this.Name, IsCashIn);
        }
        bool IsClearingFilters;
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            IsClearingFilters = true;
            dt_From.EditValue = dt_To.EditValue  = lkp_Drawer.EditValue = lkp_Store.EditValue = null;
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
    }
}
