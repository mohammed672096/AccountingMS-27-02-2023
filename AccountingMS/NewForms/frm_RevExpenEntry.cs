using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace ERP.Forms
{
    public partial class frm_RevExpenEntry : frm_Master
    {
        private bool IsRevenue;
        private byte ProccessID;

        Acc_RevExpEntry Entry = new Acc_RevExpEntry();
        DataTable EntrysTable = new DataTable();
       // RepositoryItemLookUpEdit   AccountsRepo = new RepositoryItemLookUpEdit();
        RepositoryItemGridLookUpEdit   AccountsRepo = new RepositoryItemGridLookUpEdit();
        RepositoryItemSpinEdit repospin = new RepositoryItemSpinEdit();
        RepositoryItemMemoEdit repositoryItemMemo = new RepositoryItemMemoEdit();

        public frm_RevExpenEntry(bool _isRevenue)
        {
            InitializeComponent();
            IntDetailsDataTable();
            IsRevenue = _isRevenue;
            this.Name = (IsRevenue) ? "frm_Revenue" : "frm_Expence"; 
            New();
        }

        public frm_RevExpenEntry(bool _isRevenue, int ID)
        {
            InitializeComponent();
            IntDetailsDataTable();
            IsRevenue = _isRevenue;
            this.Name = (IsRevenue) ? "frm_Revenue" : "frm_Expence";

            LoadItem(ID);
        }

        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            this.Text = labelControl1.Text = (IsRevenue) ? LangResource.RevenuEntry : LangResource.ExpenceEntry;

            this.Name = (IsRevenue) ? "frm_Revenue" : "frm_Expence";
            ProccessID = (byte)((IsRevenue) ? 14 : 15);

            Master.RestoreGridLayout(gridView1, this);
         //   AccountsRepo.CloseUp += AccountsRepo_CloseUp;
            AccountsRepo.ValidateOnEnterKey = true;
            AccountsRepo.AllowNullInput = DefaultBoolean.False;
            AccountsRepo.BestFitMode = BestFitMode.BestFitResizePopup;
            AccountsRepo.ImmediatePopup = true;
        //    AccountsRepo.EditValueChanged += AccountsRepo_EditValueChanged;

            GridView repoAccountView = new GridView();
            AccountsRepo.View = repoAccountView;
            repoAccountView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            repoAccountView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Far;
            repoAccountView.Appearance.Row.Options.UseTextOptions = true;
            repoAccountView.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
            repoAccountView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            repoAccountView.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            repoAccountView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
            repoAccountView.OptionsBehavior.AutoSelectAllInEditor = false;
            repoAccountView.OptionsBehavior.AutoUpdateTotalSummary = false;
            repoAccountView.OptionsSelection.EnableAppearanceFocusedCell = false;
            repoAccountView.OptionsSelection.UseIndicatorForSelection = true;
      
            repoAccountView.OptionsView.ShowAutoFilterRow = true;
            repoAccountView.OptionsView.ShowDetailButtons = false;
            repoAccountView.OptionsView.ShowGroupPanel = false;
            repoAccountView.OptionsView.ShowIndicator = false;
       //     AccountsRepo.TextEditStyle = TextEditStyles.DisableTextEditor;
            //repoAccountView.OptionsBehavior.AutoPopulateColumns = true;
            //repoAccountView.Columns.AddVisible("Name");
            Master.TranslateGridColumn(gridView1);
            Master.TranslateGridColumn(repoAccountView);
            btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lkp_Store.Properties.ValueMember = "ID";
            lkp_Store.Properties.DisplayMember = "Name";

            lkp_Drawer.Properties.ValueMember = "ID";
            lkp_Drawer.Properties.DisplayMember = "Name";
            lkp_Drawer.Properties.PopulateColumns();
            lkp_Drawer.Properties.Columns[0].Visible = false;


            AccountsRepo.Buttons.Add(new EditorButton("Add", ButtonPredefines.Plus));
            AccountsRepo.ButtonClick += AccountsRepo_ButtonClick;  

            AccountsRepo.ValueMember = "ID";
            AccountsRepo.DisplayMember = "Name";
            gridControl1.RepositoryItems.AddRange(new RepositoryItem[]
                {repospin, repositoryItemMemo, AccountsRepo});
            GetData();

            gridView1.Columns["RevExpAccountId"].ColumnEdit = AccountsRepo;
            gridView1.Columns["Amount"].ColumnEdit = repospin;
            gridView1.Columns["Amount"].Summary.Clear();
            gridView1.Columns["Amount"].Summary.Add(SummaryItemType.Sum, "Amount", "{0:n1}");
            gridView1.Columns["Notes"].ColumnEdit = repositoryItemMemo;

            #region DataChangedEventHandlers 

            dt_Date.EditValueChanged += DataChanged;
            lkp_Store.EditValueChanged += DataChanged;
            lkp_Drawer.EditValueChanged += DataChanged;

            #endregion
        }

        private void AccountsRepo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
                return;

            string btnName = e.Button.Tag.ToString();
            if (btnName == "Add")
            {
                if (IsRevenue)
                    Master.AddRevenueAccount(this);
                else
                    Master.AddExpencesAccount(this);
            }
        }

        private void AccountsRepo_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void AccountsRepo_CloseUp(object sender,CloseUpEventArgs e)
        {
           
        }

        public override void RefreshData()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var store = (from s in db.Inv_Stores select new {s.ID, s.Name}).ToList();
            lkp_Store.Properties.DataSource = store;
            lkp_Drawer.Properties.DataSource = CurrentSession.UserAccessibleDrawer.Select(x => new {x.ID, x.Name});

            if (IsRevenue)
                AccountsRepo.DataSource = (CurrentSession.UserAccessbileAccounts
                    .Where(x => x.Number.ToString()
                    .StartsWith(
                           db.Acc_Accounts.Where(xa => xa.ID == CurrentSession . Company.RevenueAccount).Single().Number  ) 
                           && x.Number != db.Acc_Accounts.Where(xa => xa.ID == CurrentSession . Company.ExpensesAccount).Single().Number )
                    .Select(x => new { x.ID, x.Name })).ToList();
            else
                AccountsRepo.DataSource = (CurrentSession.UserAccessbileAccounts
                    .Where(x => x.Number.ToString()
                    .StartsWith(db.Acc_Accounts.Where(xa => xa.ID == CurrentSession . Company.ExpensesAccount).Single().Number)
                    && x.Number != db.Acc_Accounts.Where(xa => xa.ID == CurrentSession . Company.ExpensesAccount).Single().Number)
                    .Select(x => new { x.ID, x.Name })).ToList();
            // AccountsRepo.View.PopulateColumns(AccountsRepo.DataSource);
            base.RefreshData();
        }

        private bool ValidData()
        {
            if (EntrysTable.Rows.Count == 0)
            {
                XtraMessageBox.Show(LangResource.ErrorMustInsertOneItemAtLeast, "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (gridView1.HasColumnErrors)
            {
                return false;
            }


            if (lkp_Store.EditValue.ValidAsIntNonZero() == false )
            {
                lkp_Store.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }

            if (lkp_Drawer.EditValue. ValidAsIntNonZero() == false )
            {
                lkp_Drawer.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }

            return true;

        }
       
        public override void Save()
        {
            if (!CanSave()) return;
            if (!ValidData())  return;
          

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            if (IsNew)
            {
                Entry = new Acc_RevExpEntry();
                db.Acc_RevExpEntries.InsertOnSubmit(Entry);
                Entry.UserID = CurrentSession.user.ID;
            }
            else
            {
                Entry = db.Acc_RevExpEntries.Where(x => x.ID == Entry.ID).First();
                if (Entry == null)
                {
                    Entry = new Acc_RevExpEntry();
                    db.Acc_RevExpEntries.InsertOnSubmit(Entry);
                    Entry.UserID = CurrentSession.user.ID;
                }

                Entry.LastUpdateUserID = CurrentSession.user.ID;
                Entry.LastUpdateDate = db.GetSystemDate();
            }

            SetData();
            db.SubmitChanges();
            Master.DeleteAccountAcctivity(ProccessID.ToString(), Entry.ID.ToString());
            db.Acc_RevExpEntryDetails.DeleteAllOnSubmit(db.Acc_RevExpEntryDetails.Where(x=>x.RevExpEntryID == Entry.ID));
            db.SubmitChanges();

            Acc_Activity acctivity = new Acc_Activity()
            {
                CostCEnter = Entry.CostCenter,
                Date = Entry.EntryDate,
                StoreID = Entry.StoreID,
                Type = ProccessID.ToString(),
                TypeID = Entry.ID.ToString()
            };
            if (IsRevenue)
                acctivity.Note = LangResource.Revenue + " " + LangResource.Number + " " + Entry.ID;
            else
                acctivity.Note = LangResource.Expense + " " + LangResource.Number + " " + Entry.ID;

            db.Acc_Activities.InsertOnSubmit(acctivity);
            db.SubmitChanges();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Acc_RevExpEntryDetail detail = new Acc_RevExpEntryDetail()
                {
                    RevExpEntryID = Entry.ID,
                    Notes = gridView1.GetRowCellValue(i, "Notes").ToString(),
                    Amount = Convert.ToDouble(gridView1.GetRowCellValue(i, "Amount")),
                    RevExpAccountId = Convert.ToInt32(gridView1.GetRowCellValue(i, "RevExpAccountId"))
                };
                db.Acc_RevExpEntryDetails.InsertOnSubmit(detail);
                Acc_ActivityDetial det = new Acc_ActivityDetial()
                {
                    ACCID = detail.RevExpAccountId,
                    AcivityID = acctivity.ID,
                    Note = gridView1.GetRowCellDisplayText(i, "RevExpAccountId").ToString() + ":" + detail.Amount +
                           " " + detail.Notes,
                    Debit = 0,
                    Credit = 0,
                };

                if (IsRevenue)
                    det.Debit = Convert.ToDouble(gridView1.GetRowCellValue(i, "Amount"));
                else
                    det.Credit = Convert.ToDouble(gridView1.GetRowCellValue(i, "Amount"));
                db.Acc_ActivityDetials.InsertOnSubmit(det);
                acctivity.Note += Environment.NewLine + det.Note;

            }
            DAL.Acc_ActivityDetial DrawerAcctivity = new Acc_ActivityDetial() // for drawer 
            {
                ACCID = (int)CurrentSession.UserAccessibleDrawer.Where(x => x.ID == Entry.DrawerAccountId).Select(x => x.ACCID).SingleOrDefault(),
                Debit = 0,
                Credit = 0,
                AcivityID = acctivity.ID,
                Note = acctivity.Note
            };

            if (IsRevenue)
                DrawerAcctivity.Debit = Convert.ToDouble(EntrysTable.Compute("Sum(Amount)", ""));
            else
                DrawerAcctivity.Credit = Convert.ToDouble(EntrysTable.Compute("Sum(Amount)", ""));

            db.Acc_ActivityDetials.InsertOnSubmit(DrawerAcctivity);

            db.SubmitChanges();
            base.Save();
        }

        public override void RunUserPrivilage()
        {
            base.RunUserPrivilage();
            lkp_Store.ReadOnly = !(bool) CurrentSession.user.CanChangeStore;
            lkp_Drawer.ReadOnly = !(bool) CurrentSession.user.CanChangeDrawer;
            lkp_CCenter.ReadOnly = !(bool) CurrentSession.user.CanChangeCCenter;

        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                return (int)db.Acc_RevExpEntries.Where(x=>x.IsRevenue == IsRevenue ) .Max(n => n.Code) + 1;
            }
            catch
            {
                return (int)1;
            }
        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            Entry = new Acc_RevExpEntry();
            Entry.Code = GetNextID();
            Entry.StoreID = CurrentSession.user.DefaultStore;
            Entry.DrawerAccountId = CurrentSession.user.DefaultDrawer;
            Entry.CostCenter = CurrentSession.user.DefualtCCenter;
            Entry.EntryDate = (new DAL.ERPDataContext()).GetSystemDate();
            Entry.StoreID = Convert.ToInt32(CurrentSession.user.DefaultRawStore);
            EntrysTable.Clear();
            GetData();
            base.New();
            IsNew = true;
            ChangesMade = false;
        }

        public override void Delete()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            if (!AllowDelete)
            {
                XtraMessageBox.Show(LangResource.CantDeleteNoPermission, "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (IsNew) return;
            PartNumber = txt_Code.Text.ToString();
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                Delete(new List<int>() {Entry.ID}, this.Name, ProccessID);
                New();
            }

        }

        void SetData()
        {
            Entry.Code = Convert.ToInt32(txt_Code.Text);
            Entry.StoreID = Convert.ToInt32(lkp_Store.EditValue);
            Entry.DrawerAccountId  = Convert.ToInt32(lkp_Drawer .EditValue);
            Entry.EntryDate = dt_Date.DateTime;
            Entry.CostCenter = (int?) lkp_CCenter.EditValue;
            Entry.Notes = memoEdit1.Text;
            Entry.Total = Convert.ToDouble(EntrysTable.Compute("Sum(Amount)", ""));
            PartNumber = Entry.Code.ToString();
            Entry.IsRevenue = IsRevenue;
        }

        void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
            EntrysTable.Clear();
            txt_Code.Text = Entry.Code.ToString(); 
            lkp_Store.EditValue = Entry.StoreID;
            lkp_Drawer.EditValue =    Entry.DrawerAccountId; 
            dt_Date.DateTime = Entry.EntryDate; 
            lkp_CCenter.EditValue = Entry.CostCenter; 
            memoEdit1.Text = Entry.Notes; 
            PartNumber = Entry.Code.ToString(); 
            txt_InsertUser.Text = db.St_Users.Where(x => x.ID == Entry.UserID).Select(x => x.UserName).FirstOrDefault();
            txt_UpdateUser.Text = db.St_Users.Where(x => x.ID == Entry.LastUpdateUserID).Select(x => x.UserName)
                .FirstOrDefault();
            txt_LastUpdate.Text = (Entry.LastUpdateDate != null)
                ? ((DateTime) Entry.LastUpdateDate).ToString("yyyy-MM-dd dddd hh:mm tt")
                : "";

            var query = db.Acc_RevExpEntryDetails.Where(x => x.RevExpEntryID == Entry.ID).Select(x => x).ToList();
            foreach (var q in query  )
            {
                EntrysTable.Rows.Add(q.RevExpAccountId, q.Amount, q.Notes);
            }
            gridControl1.DataSource = EntrysTable ;

            ChangesMade = false;

        }

        void IntDetailsDataTable()
        {
            EntrysTable.Columns.Add("RevExpAccountId", type: typeof(Int32)).Caption = LangResource.Account;
            EntrysTable.Columns.Add("Amount", typeof(double)).Caption = LangResource.Amount;
            EntrysTable.Columns.Add("Notes", typeof(string)).Caption = LangResource.Notes;
            ChangesMade = false;

        }

        void LoadObject(int ID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            Entry = (from i in db.Acc_RevExpEntries where i.ID == ID select i).First();
            IsNew = false;
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl gridControl = sender as GridControl;
            GridView focusedView = gridControl.FocusedView as GridView;
            if (e.KeyCode == Keys.Return && focusedView.FocusedColumn != focusedView.Columns["Notes"])
            {
                 
                    gridView1.PostEditor();
                    gridView1.UpdateCurrentRow();
                    gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
              
             
            }
            else if(e.KeyCode == Keys.Return && e.Modifiers == Keys.Shift)
            {
                gridView1.PostEditor();
                gridView1.UpdateCurrentRow();
                gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            }
            else if (e.KeyCode == Keys.Tab && e.Modifiers != Keys.Shift)
            {
                if (focusedView.FocusedColumn.VisibleIndex == 0)
                    focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.VisibleColumns.Count - 1];
                else
                    focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex - 1];
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                focusedView.DeleteSelectedRows();
            else if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift)
            {
                if (focusedView.FocusedColumn.VisibleIndex == focusedView.VisibleColumns.Count)
                    focusedView.FocusedColumn = focusedView.VisibleColumns[0];
                else
                    focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex + 1];
                e.Handled = true;
            }
            else
            {
                //if (e.KeyCode != Keys.Up || focusedView.GetFocusedRow() == null || !(focusedView.GetFocusedRow() as DataRowView).IsNew || focusedView.GetFocusedRowCellValue("ItemId") != null && !(focusedView.GetFocusedRowCellValue("ItemId").ToString() == string.Empty))
                //    return;
                //focusedView.DeleteRow(focusedView.FocusedRowHandle);
            }

        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            int h = e.RowHandle;
            GridView view = sender as GridView;
            if (view.GetRowCellValue(e.RowHandle, "RevExpAccountId").ValidAsIntNonZero() == false)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["RevExpAccountId"], LangResource.ErrorCantBeEmpry);
            }
            if (view.GetRowCellValue(e.RowHandle, "Amount").ValidAsIntNonZero() == false)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Amount"], LangResource.ErrorValMustBeGreaterThan0);
            }
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
          
                e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.RowCount > 0)
            {
                view .SetFocusedRowCellValue( "RevExpAccountId", view.GetRowCellValue(view.RowCount-1 , "RevExpAccountId"));
            }

     
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            ChangesMade = true;
        }


        void LoadItem(int ID)
        {
            DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
            Entry  = (from i in dbc.Acc_RevExpEntries  where i.ID == ID select i).First();
            IsNew = false;
        }

        private void frm_RevExpenEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SaveGridLayout(gridView1 , this);
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            ChangesMade = true;
        }

        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            Print(new List<int>() { Entry.ID }, this.Name , IsRevenue );

        }
        public static void Delete(List<int> ids, string CallerForm ,byte ProccessID)

        {
            DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);

        


            foreach (var item in ids)
            {
                Master.InsertUserLog(2, CallerForm, "", item.ToString());
                Master.DeleteAccountAcctivity(ProccessID.ToString(), item.ToString());
            }

            db.Acc_RevExpEntryDetails.DeleteAllOnSubmit(db.Acc_RevExpEntryDetails.Where(x => ids.Contains(x.ID) )); 
            db.Acc_RevExpEntries .DeleteAllOnSubmit(db.Acc_RevExpEntries .Where(c => ids.Contains(c.ID)));
            db.SubmitChanges();
            Master.RefreshAllWindows();

        }
        public static DataSet PrintDataSource(List<int> ids)
        {
            DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);
            DataSet ds = new DataSet("SERP");
            DataTable HeaderDT = new DataTable("Head");
            DataTable DetailsDT = new DataTable("Details");

            HeaderDT.Columns.Add("ID", typeof(Int32)); 
            HeaderDT.Columns.Add("Code", typeof(string));
            HeaderDT.Columns.Add("Store");
            HeaderDT.Columns.Add("Drawer");
            HeaderDT.Columns.Add("CostCenter");
            HeaderDT.Columns.Add("Date", typeof(DateTime));
            HeaderDT.Columns.Add("Notes", typeof(string)); 
            HeaderDT.Columns.Add("Total");
            HeaderDT.Columns.Add("User");
            HeaderDT.Columns.Add("TotalInText");

            //// Details Datatable 
            DetailsDT.Columns.Add("HeadID", typeof(Int32)); 
            DetailsDT.Columns.Add("Account", typeof(string)).Caption = LangResource.Item;
            DetailsDT.Columns.Add("Amount", typeof(double)).Caption = LangResource.Unit;
            DetailsDT.Columns.Add("Notes", typeof(string )).Caption = LangResource.QTY;
            DetailsDT.Columns.Add("AmountInText", typeof(string )).Caption = LangResource.Unit;


            var quiry = from e in db.Acc_RevExpEntries 
                        join b in db.Inv_Stores on e.StoreID equals b.ID 
                        from d in db.Acc_Drawers.Where(x => x.ID == e.DrawerAccountId )
                        from u in db.St_Users.Where(x => x.ID == e.UserID).DefaultIfEmpty()
                        from cc in db.Acc_CostCenters .Where(x => x.ID == e.CostCenter ).DefaultIfEmpty()
                where ids.Contains(e.ID)
                        select new
                        {
                            e.ID ,
                            e.Code, 
                            Store = b.Name,
                            Drawer = d.Name,
                            CostCenter = cc.Name ,
                            e.EntryDate ,
                            e.Notes,
                            e.Total,
                            u.UserName
                        };

            foreach (var h in quiry.ToList())
                HeaderDT.Rows.Add(h.ID, h.Code, h.Store , h.Drawer , h.CostCenter , h.EntryDate , h.Notes
                    , h.Total , h.UserName ,  Master.ConvertMoneyToText(h.Total.ToString(),1) );

            // detials 
            var query = from d in db.Acc_RevExpEntryDetails 
                        from ac in db.Acc_Accounts.Where(x => x.ID  == d.RevExpAccountId ).DefaultIfEmpty()
                        where ids.Contains(d.RevExpEntryID )
                        select new
                        {
                            HeadID = d.RevExpEntryID ,
                            Account = ac.Name ,
                            Amount = d.Amount ,
                            Notes = d.Notes 

                        };
          
            foreach (var q in query.ToList())
                DetailsDT.Rows.Add(q.HeadID, q.Account , q.Amount , q.Notes , Master.ConvertMoneyToText (q.Amount .ToString(),1) );
              
            ds.Tables.Add(HeaderDT);
            ds.Tables.Add(DetailsDT);
            ds.Relations.Add("HeadDetials", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0]);
            return ds;
        }
        public static void Print(List<int> ids, string CallerForm,bool IsRevenue)
        {

            foreach (var item in ids)
            {
                Master.InsertUserLog(3, CallerForm, "", item.ToString());
            }
            Reporting.rpt_RevExpenEntry.Print(PrintDataSource(ids), IsRevenue);
            //base.Print();
        }

    }
}
