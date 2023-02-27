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
    public partial class frm_RevExpensEntryList : frm_Master
    {
        RepositoryItemLookUpEdit repoDrawer = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoStore = new RepositoryItemLookUpEdit();
        private bool IsRevenue;
        private byte ProccessID;
        public frm_RevExpensEntryList(bool _sRevenue)
        {
            InitializeComponent();
            dt_From.DateTime = DateTime.Now.Date;
            IsRevenue = _sRevenue;
            this.Name = (IsRevenue) ? "frm_RevenueList" : "frm_ExpenceList";


        }
        public override void frm_Load(object sender, EventArgs e)
        {

            this.Text =  (IsRevenue) ? LangResource.Revenues  : LangResource.Expenses ;
            this.Name = (IsRevenue) ? "frm_RevenueList" : "frm_ExpenceList";
            ProccessID = (byte)((IsRevenue) ? 14 : 15);

            
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
            gridView1.Columns["DrawerID"].ColumnEdit = repoDrawer;
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
            var result = from e in db.Acc_RevExpEntries 
                         from d in db.Acc_RevExpEntryDetails .Where(x => x.RevExpEntryID  == e.ID)
                         from u in db.St_Users.Where(x => x.ID == e.UserID)
                from ac in db.Acc_Accounts .Where(x=>x.ID  == d.RevExpAccountId)
                         where (e.IsRevenue == IsRevenue)
                         select new
                         {
                             e.ID,
                             e.Code, 
                            Account =  ac.Name ,
                             e.StoreID,
                             Date=  e.EntryDate ,
                             DrawerID=  e.DrawerAccountId ,
                             e.Total ,
                             UserID = u.UserName,
                             e.Notes, 
                         };

            // apply Filters 
            if (dt_From.EditValue != null)
                result = result.Where(x => x.Date >= dt_From.DateTime.Date);
            if (dt_To.EditValue != null)
                result = result.Where(x => x.Date <= dt_To.DateTime.Date);
            if (lkp_Store.EditValue != null && lkp_Store.EditValue != DBNull.Value)
                result = result.Where(x => x.StoreID == Convert.ToInt32(lkp_Store.EditValue));
            if (lkp_Drawer.EditValue != null && lkp_Drawer.EditValue != DBNull.Value)
                result = result.Where(x => x.DrawerID == Convert.ToInt32(lkp_Drawer.EditValue)); 
            gridControl1.DataSource = result.ToList();
            //  gridView1.re

        }
        public  override void New()
        {
            frm_Main.OpenForm(new frm_RevExpenEntry(IsRevenue));
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

                frm_Main.OpenForm(new frm_RevExpenEntry(IsRevenue,Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"))), openNew: true);
            }
        }

        private void frm_RevExpensEntryList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(gridView1, this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
  //          //var UserCanDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == "frm_RevExpenEntry" + "_Delete");
  //          //if (UserCanDelete.Count() > 0) CanDelete = (bool)UserCanDelete.First().PrivilegeValue;
  ////if (!CanPerformDelete()) return;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                List<int> ids = new List<int>();
                foreach (var item in gridView1.GetSelectedRows())
                {
                    ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "ID")));

                }

                frm_RevExpenEntry.Delete(ids, this.Name, ProccessID);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            ////var UserCanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == "frm_RevExpenEntry" + "_Print");
            ////if (UserCanPrint.Count() > 0) CanPrint = (bool)UserCanPrint.First().PrivilegeValue;
            ////if (!CanPrint) { XtraMessageBox.Show(LangResource.CantEditNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            List<int> ids = new List<int>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                ids.Add(Convert.ToInt32(gridView1.GetRowCellValue(item, "ID")));
            }
            frm_RevExpenEntry.Print(ids, this.Name,IsRevenue );
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
