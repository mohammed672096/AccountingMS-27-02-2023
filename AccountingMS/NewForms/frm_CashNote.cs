using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraDiagram.Bars;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Linq.Expressions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System.Collections.ObjectModel;
using System.Data.Linq;
using static ERP.Master;

namespace ERP.Forms
{
    public partial class frm_CashNote : frm_Master 
    {
        private bool ISCashIn;
        private int AccountID;

        private object CustomersList;
        private object VendorsList;
       // private object InvoicesList;
        Acc_CashNote  CashNote = new Acc_CashNote();
       public   override Master.SystemProssess ProcessType 
        { get 
            { if (CashNote.IsCashNote ) return Master.SystemProssess.CashNoteIn; 
                else return Master.SystemProssess.CashNoteOut;
            } 
        }
        DAL.ERPDataContext DetailsDataContexst;


        public frm_CashNote(bool _ISCashIn)
        {
            InitializeComponent();
            ISCashIn = _ISCashIn;
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            New();

        }
        /// <summary>
        /// Open new CashNote  
        /// </summary>
        /// <param name="_ISCashIn"> Cash trans type </param>
        /// <param name="ID"> Id  </param>
        /// <param name="IdType">    </param>
        public frm_CashNote(bool _ISCashIn, int ID ,String IdType)
        {
            InitializeComponent();
            ISCashIn = _ISCashIn;
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            New();
            switch (IdType)
            {
                case "Customer": CashNote.PartType  = 1; CashNote.PartID  = ID;  break; 
                case "Vendor":  CashNote.PartType = 0; CashNote.PartID = ID; break;   
                default:
                    LoadItemByCode(ID,_ISCashIn ); 
                    break;
            } 
        }
        public frm_CashNote(SystemProssess prossess  , int id ,int partType,int partId, int sourceType,  int sourceID   )
        {
            InitializeComponent();
            if (id > 0)
            {
                ISCashIn = (prossess == SystemProssess.CashNoteIn);
                LoadItemByID(id);
                ISCashIn = CashNote.IsCashNote;
                GetData();
                return;
            }

            ISCashIn = (prossess == SystemProssess.CashNoteIn);
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            New();
            CashNote.PartType = Convert.ToByte( partType);
            CashNote.PartID = partId;
            CashNote.LinkType = Convert.ToByte(sourceType);
            CashNote.LinkID = sourceID;
            GetData();
             
        }
        public frm_CashNote( int ID )
        {
            InitializeComponent();
            LoadItemByID(ID);
            ISCashIn = CashNote.IsCashNote;
            GetData();

           // ProccessType = ISCashIn ? Master.SystemProssess.CashNoteIn : Master.SystemProssess.CashNoteOut;


        }


        RepositoryItemLookUpEdit PaySourceRepo = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoCurrency = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit repoUsers = new RepositoryItemLookUpEdit();


        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            
            LookUpEdit_PartType.Properties.DataSource = new[]
                    {
                      new { ID = 1 ,Name =  LangResource.Vendor  },
                      new { ID = 2 ,Name =  LangResource.Customer  },
                      new { ID = 3 ,Name =  LangResource.Employee  },
                      new { ID = 4 ,Name =  LangResource.Account  },
                    };


            //if(ISCashIn)
            //{
            //    LookUpEdit_Source.Properties.DataSource = new[]
            //        {
            //          new { ID = 1 ,Name =  LangResource.Vendor  },
            //          new { ID = 2 ,Name =  LangResource.Customer  },
            //          new { ID = 3 ,Name =  LangResource.Employee  },
            //          new { ID = 4 ,Name =  LangResource.Account  },
            //        };

            //}


            PaySourceRepo.ValueMember = "ID";
            PaySourceRepo.DisplayMember = "Name";
            PaySourceRepo.NullText = "";


            RepositoryItemSpinEdit repospin = new RepositoryItemSpinEdit();
            RepositoryItemLookUpEdit repoPayTypes = new RepositoryItemLookUpEdit();

            List<Master.NameAndIDDataSource>  payTypes=new List<Master.NameAndIDDataSource>()
                        {
                        new Master.NameAndIDDataSource(){ID = 1 ,Name = LangResource.CashPay  },
                        new Master.NameAndIDDataSource(){ID = 2 ,Name = LangResource.BankTransfer },
                        new Master.NameAndIDDataSource(){ID = 3 ,Name = LangResource.PayCards },
                        new Master.NameAndIDDataSource(){ID = 4 ,Name = LangResource.OnAccount },
                        };
            repoPayTypes.DataSource = payTypes;
            repoPayTypes.ValueMember = "ID";
            repoPayTypes.DisplayMember = "Name";

            repoCurrency.ValueMember = "ID";
            repoCurrency.DisplayMember = "Name";
            repoCurrency.NullText = "";

            repoUsers.ValueMember = "ID";
            repoUsers.DisplayMember = "Name";
            repoUsers.NullText = "";


            GridControl_Pays.RepositoryItems.AddRange(new RepositoryItem[] {
            PaySourceRepo,
            repospin,
            repoPayTypes,
            repoCurrency,
            repoUsers   });


            GridView_Pays.Columns["PayID"].ColumnEdit = PaySourceRepo;
            GridView_Pays.Columns["PayType"].ColumnEdit = repoPayTypes;
            GridView_Pays.Columns["CurrancyRate"].ColumnEdit = repospin;
            GridView_Pays.Columns["Amount"].ColumnEdit = repospin;
            GridView_Pays.Columns["CurrancyID"].ColumnEdit = repoCurrency;
            GridView_Pays.Columns["UserID"].ColumnEdit = repoUsers;
            GridView_Pays.Columns["SourceType"].Visible =
            GridView_Pays.Columns["SourceID"].Visible =
            GridView_Pays.Columns["UserID"].OptionsColumn.AllowFocus =
            GridView_Pays.Columns["InsertDate"].OptionsColumn.AllowFocus =
            GridView_Pays.Columns["ID"].Visible = false;
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            GridControl_Pays.RepositoryItems.Add(buttonEdit);
            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            GridColumn clmnDelete = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 14, Width = 15 };
            buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            GridColumn clmnDeleteBarcode = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 100, Width = 15 };
            GridView_Pays.Columns.Add(clmnDelete);


            GridView_Pays.TranslateColumns();
            GridView_Pays.Columns["PayID"].Caption = LangResource.PayAccount;
            GridView_Pays.Columns["PayType"].Caption = LangResource.PayType;
            GridView_Pays.Columns["Refrence"].Caption = LangResource.RefrenceNumber;
            GridView_Pays.Columns["PayDate"].Caption = LangResource.PayDate;
            GridView_Pays.Columns["CurrancyRate"].Caption = LangResource.CurrancyRate;
            GridView_Pays.Columns["InsertDate"].Caption = LangResource.InsertDate;
            GridView_Pays.FocusedColumnChanged += GridView_Pays_FocusedColumnChanged;
            GridView_Pays.FocusedRowChanged += GridView_Pays_FocusedRowChanged;
            GridView_Pays.CustomRowCellEditForEditing += GridView_Pays_CustomRowCellEditForEditing;
            GridView_Pays.InitNewRow += GridView_Pays_InitNewRow;
            GridView_Pays.CellValueChanged += GridView_Pays_CellValueChanged;
            GridView_Pays.RowCountChanged += GridView_Pays_RowCountChanged;
            GridView_Pays.ValidateRow += GridView_Pays_ValidateRow;
            GridView_Pays.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView2_InvalidRowException);


            this.Text = layoutControlGroup5 .Text = (ISCashIn) ? LangResource.CashNoteIn  : LangResource.CashNoteOut;
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            RunUserPrivilage();
            lkp_Store.Properties.ValueMember = "ID";
            lkp_Store.Properties.DisplayMember = "Name";

            

            LookUpEdit_PartID.Properties.ValueMember = "ID";
            LookUpEdit_PartID.Properties.DisplayMember = "Name";

            LookUpEdit_PartType.Properties.ValueMember = "ID";
            LookUpEdit_PartType.Properties.DisplayMember = "Name";


            LookUpEdit_SourceID.Properties.ValueMember = "ID";
            LookUpEdit_SourceID.Properties.DisplayMember = "Code";


            LookUpEdit_Source.Properties.ValueMember = "ID";
            LookUpEdit_Source.Properties.DisplayMember = "Name";


            glkp_Source_EditValueChanged(null, null);

            #region DataChangedEventHandlers 
            dt_Date.EditValueChanged += DataChanged;
            memoEdit1.EditValueChanged += DataChanged;
            lkp_Store.EditValueChanged += DataChanged;
            LookUpEdit_SourceID.EditValueChanged += DataChanged;
            LookUpEdit_PartID.EditValueChanged += DataChanged;
            txt_Code.EditValueChanged += DataChanged;
            #endregion
        }

        public override void RefreshData()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var store = (from s in db.Inv_Stores select new { s.ID, s.Name }).ToList();
            lkp_Store.Properties.DataSource = store;
            CustomersList = (from c in CurrentSession.UserAccessbileCustomers select new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
            VendorsList = (from v in CurrentSession.UserAccessbileVendors select new { v.ID, v.Name, v.City, v.Address, v.Mobile, v.Phone  }).ToList();
            RefreshPaySources();
            repoCurrency.DataSource = db.Acc_Currencies.Select(x => new { x.ID, x.Name });
            repoUsers.DataSource = db.St_Users.Select(x => new { x.ID, Name = x.UserName }).ToList();

            // AccountsRepo.View.PopulateColumns(AccountsRepo.DataSource);
            base.RefreshData();
        }
        void RefreshPaySources()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var banks = CurrentSession.UserAccessibleBanks.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.AccountID, Name = x.BankName }).ToList();
            var drawers = CurrentSession.UserAccessibleDrawer.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.ACCID ?? 0, Name = x.Name }).ToList();
            var paycards = CurrentSession.UserAccessiblePayCards.Where(x => banks.Select(b => b.ID).Contains(x.BankID)).Select(x => new { x.ID, Name = x.Number }).ToList();
            var accounts = CurrentSession.UserAccessbileAccounts.Where(x => db.Acc_Accounts.Where(a => a.ParentID == x.ID).Count() == 0).Select(x => new { x.ID, Name = x.Name }).ToList();
          
            var dataSources = drawers; 

            dataSources.AddRange(paycards);
            dataSources.AddRange(accounts);
            dataSources.AddRange(banks);



            PaySourceRepo.DataSource = dataSources;

        }


        private bool ValidData()
        {
            if (Convert.ToDouble(spn_Total.EditValue ) == 0)
            {
                spn_Total.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                return false;
            }


            if (LookUpEdit_PartID .EditValue.ValidAsIntNonZero () == false )
            {
                LookUpEdit_PartID.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }


            if (lkp_Store.EditValue == null || lkp_Store.EditValue == DBNull.Value ||
                lkp_Store.EditValue.GetType() != typeof(int))
            {
                lkp_Store.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }
            if(LookUpEdit_Source.EditValue .ToInt ()!= (int)Master.SystemProssess.Without  && LookUpEdit_SourceID.EditValue .ValidAsIntNonZero() == false )
            {
                LookUpEdit_SourceID.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }

            
            return true;

        }
        public override void Save()
        {
            if (IsNew && !CanAdd)
            {
                XtraMessageBox.Show(LangResource.CantAddNoPermission, "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!IsNew && !CanEdit)
            {
                XtraMessageBox.Show(LangResource.CantEditNoPermission, "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!ValidData())
            {
                return;
            }

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            if (IsNew)
            {
                CashNote = new Acc_CashNote();
                db.Acc_CashNotes.InsertOnSubmit(CashNote);
                CashNote.UserID = CurrentSession.user.ID;
            }
            else
            {
                
                CashNote = db.Acc_CashNotes .Where(x => x.ID == CashNote.ID).First();
                if (CashNote == null)
                {
                    CashNote = new Acc_CashNote();
                    db.Acc_CashNotes.InsertOnSubmit(CashNote);
                    CashNote.UserID = CurrentSession.user.ID;
                }

                CashNote.LastUpdateUserID = CurrentSession.user.ID;
                CashNote.LastUpdateDate = db.GetSystemDate();
            } 
            SetData();
            db.SubmitChanges();
         
            Master.DeleteAccountAcctivity(((int)ProcessType).ToString(), CashNote.Code .ToString());
            foreach (var item in ((Collection<Acc_Pay>)GridView_Pays.DataSource))
            {
                item.SourceID = CashNote .Code ;
                item.SourceType = (int)ProcessType;

            }

            db.Acc_Pays.DeleteAllOnSubmit(db.Acc_Pays.Where(x => x.PayType == ((int)Master.PayTypes.CashNote) && x.PayID == CashNote.ID));
            db.SubmitChanges();


            DetailsDataContexst.SubmitChanges();

           
            
            
            
            var MainMessage = "";
            var DiscountAccount = 0;
            var IsPartCredit = true;
            var PartAccount = 0;



            if (ISCashIn)
            {
                IsPartCredit = true; 
                MainMessage = LangResource.CashNoteIn + " " + LangResource.Number + " " + CashNote.Code;
                DiscountAccount = CurrentSession.Company.SalesDiscountAccount;
            }
            else
            {
                IsPartCredit = false; 
                MainMessage = LangResource.CashNoteOut  + " " + LangResource.Number + " " + CashNote.Code;
                DiscountAccount = CurrentSession.Company.PurchaseDiscountAccount ;
            }
            switch (CashNote.PartType)
            {
                case (int)Master.PartTypes.Vendor:
                    PartAccount = db.Pr_Vendors.Where(x => x.ID == CashNote.PartID).SingleOrDefault().Account;
                    break;
                case (int)Master.PartTypes.Customer:
                    PartAccount = db.Sl_Customers.Where(x => x.ID == CashNote.PartID).SingleOrDefault().Account;
                    break;
                case (int)Master.PartTypes.Account:
                    PartAccount = CashNote.PartID;
                    break;
                case (int)Master.PartTypes.Employee:
                    PartAccount = db.HR_Employees.Where(x => x.ID == CashNote.PartID).SingleOrDefault().AccountId.Value;
                    break;
            }

            Acc_Activity acctivity = new Acc_Activity()
            {

                Date = CashNote.Date,
                StoreID = CashNote.StoreID,
                Type = ((int)ProcessType).ToString(),
                TypeID = CashNote.Code.ToString(),
                CostCEnter = CashNote.CCenter,
                Note = MainMessage,
                InsertDate = CashNote.Date ,
                LastUpdateDate = CashNote.LastUpdateDate,
                LastUpdateUserID = CashNote.UserID,
                UserID = CashNote.UserID
            };
            db.Acc_Activities.InsertOnSubmit(acctivity);
            db.SubmitChanges();
            foreach (var pay in ((Collection<Acc_Pay>)GridView_Pays.DataSource))
            {
                pay.SourceType =(int) ProcessType;
                pay.SourceID = CashNote.Code ;
                

                switch (pay.PayType)
                {
                    case 1:// Drawer
                    case 2:// Bank
                    case 4:// Account
                        db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                        {
                            ACCID = pay.PayID,
                            Debit = IsPartCredit ? pay.Amount : 0,
                            Credit = IsPartCredit ? 0 : pay.Amount,
                            AcivityID = acctivity.ID,
                            DueDate = pay.PayDate,
                            Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay),
                            CurrencyID = pay.CurrancyID,
                            CurrencyRate = pay.CurrancyRate,
                            CostCenter = CashNote.CCenter
                        });
                        db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                        {
                            ACCID = (int)CurrentSession.UserAccessbileCustomers.Where(x => x.ID == CashNote.PartID).Select(x => x.Account).SingleOrDefault(),
                            Debit = IsPartCredit ? 0 : pay.Amount,
                            Credit = IsPartCredit ? pay.Amount : 0,
                            AcivityID = acctivity.ID,
                            DueDate = pay.PayDate,
                            Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay),
                            CurrencyID = pay.CurrancyID,
                            CurrencyRate = pay.CurrancyRate,
                            CostCenter = CashNote.CCenter
                        });
                        break;

                    case 3://Pay Card 
                        var card = db.Acc_PayCards.Where(x => x.ID == pay.PayID).SingleOrDefault();
                        var bank = db.Acc_Banks.Where(x => x.ID == card.BankID).SingleOrDefault();
                        db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                        {
                            ACCID = bank.AccountID,
                            Debit = IsPartCredit ? pay.Amount - (pay.Amount * card.Commission) : 0,
                            Credit = IsPartCredit ? 0 : pay.Amount - (pay.Amount * card.Commission),
                            AcivityID = acctivity.ID,
                            DueDate = pay.PayDate,
                            Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay),
                            CurrencyID = pay.CurrancyID,
                            CurrencyRate = pay.CurrancyRate,
                            CostCenter = CashNote.CCenter
                        });
                        if (card.Commission > 0) db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                        {
                            ACCID = card.CommissionAccount,
                            Debit = IsPartCredit ? (pay.Amount * card.Commission) : 0,
                            Credit = IsPartCredit ? 0 : (pay.Amount * card.Commission),
                            AcivityID = acctivity.ID,
                            DueDate = pay.PayDate,
                            Note = string.Format("{0}-{2}-{1}", MainMessage, LangResource.Pay, LangResource.Commission),
                            CurrencyID = pay.CurrancyID,
                            CurrencyRate = pay.CurrancyRate,
                            CostCenter = CashNote.CCenter
                        });
                        db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                        {
                            ACCID = (int)CurrentSession.UserAccessbileCustomers.Where(x => x.ID == CashNote.PartID).Select(x => x.Account).SingleOrDefault(),
                            Debit = IsPartCredit ? 0 : pay.Amount,
                            Credit = IsPartCredit ? pay.Amount : 0,
                            AcivityID = acctivity.ID,
                            DueDate = pay.PayDate,
                            Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay),
                            CurrencyID = pay.CurrancyID,
                            CurrencyRate = pay.CurrancyRate,
                            CostCenter = CashNote.CCenter
                        });
                        break;
                    
                    default:
                        break;
                }

            }


            if (CashNote.DiscountValue > 0)
            {
                db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                {
                    ACCID = DiscountAccount,
                    Debit = IsPartCredit ? CashNote.DiscountValue : 0,
                    Credit = IsPartCredit ? 0 : CashNote.DiscountValue,
                    AcivityID = acctivity.ID,
                    Note = string.Format("{0}-{1}", MainMessage, LangResource.Discount),
                    CurrencyID = 1,
                    CurrencyRate = 1,
                    CostCenter = CashNote.CCenter

                });
                db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
                {
                    ACCID = PartAccount,
                    Debit = IsPartCredit ? 0 : CashNote.DiscountValue,
                    Credit = IsPartCredit ? CashNote.DiscountValue : 0,
                    AcivityID = acctivity.ID,
                    Note = string.Format("{0}-{1}", MainMessage, LangResource.Discount),
                    CurrencyID = 1,
                    CurrencyRate = 1,
                    CostCenter = CashNote .CCenter
                });
            }
            ChangeSet cs = db.GetChangeSet();
            double debit = 0;
            double credit = 0;

            foreach (var item in cs.Inserts)
            {

                if (item.GetType() == typeof(Acc_ActivityDetial))
                {
                    debit += ((Acc_ActivityDetial)item).Debit;
                    credit += ((Acc_ActivityDetial)item).Credit;

                }
            }
            if (debit != credit)
            {
                XtraMessageBox.Show("Debit ={" + debit + "}   / Credit={" + credit + "} حدث خطأ ما , القيود غير متزنه ");
            }
            if(CashNote.LinkType != (int)Master.SystemProssess.Without)
            {
                db.Acc_Pays.InsertOnSubmit(new Acc_Pay()
                {
                    PayType = (int)Master.PayTypes.CashNote ,
                    PayID = CashNote.ID ,
                    Amount = CashNote.DiscountValue + CashNote.Amount ,
                    Code = CashNote.Code.ToString () ,
                    CurrancyID = 1 ,
                    CurrancyRate = 1,
                    InsertDate = db.GetSystemDate(),
                    Notes = "" , 
                    Refrence = CashNote.Code.ToString(),
                    PayDate = CashNote.Date ,
                    UserID = CashNote.LastUpdateUserID?? CurrentSession.user.ID  ,
                    SourceID = CashNote.LinkID .Value ,
                    SourceType = CashNote.LinkType 
                });
            }

            db.SubmitChanges();
            DetailsDataContexst.SubmitChanges();
            base.Save();
            /* ToDo
             Mark Invoices as 
            */   
        }
        public override void RunUserPrivilage()
        {
            if (CurrentSession.user.HasAccess == 0)
            {
                CanAdd = AllowDelete = CanEdit = CanPrint = true;
                return;
            }

            CanAdd = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanAdd).FirstOrDefault();
            CanEdit = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanEdit).FirstOrDefault();
            AllowDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanDelete).FirstOrDefault();
            CanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanPrint).FirstOrDefault();

            lkp_Store.ReadOnly = !(bool)CurrentSession.user.CanChangeStore;
            GridView_Pays.Columns["PayID"].OptionsColumn.ReadOnly  =  !(bool)CurrentSession.user.CanChangeDrawer;
        

        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return  db.Acc_CashNotes .Where(x => x.IsCashNote  == ISCashIn).Max(n => n.Code) + 1;
            }
            catch
            {
                return (int)1;
            }
        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            IsNew = true;
            CashNote = new Acc_CashNote();
            CashNote.IsCashNote = ISCashIn;
            CashNote.Code   = GetNextID();
      
            CashNote.StoreID = CurrentSession.user.DefaultStore;
          
            CashNote.Date  = (new DAL.ERPDataContext()).GetSystemDate();
            CashNote.StoreID = Convert.ToInt32(CurrentSession.user.DefaultRawStore);

            CashNote.PartType = ISCashIn ? (byte)Master.PartTypes.Customer : (byte)Master.PartTypes.Vendor;

            CashNote.LinkType  = (int)Master.SystemProssess.Without;

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
                Delete(new List<int>() { CashNote.Code },ISCashIn, this.Name, (byte)ProcessType);
                New();
            }

        }

        void SetData()
        {
            CashNote.Code   = Convert.ToInt32(txt_Code.Text);
            CashNote.IsCashNote = ISCashIn; 
            CashNote.StoreID = Convert.ToInt32(lkp_Store.EditValue);
            CashNote.CCenter   = Convert.ToInt32(lkp_CCenter.EditValue);
            CashNote.Date   = dt_Date.DateTime;
            CashNote.PartType =(byte)LookUpEdit_PartType.EditValue .ToInt() ;
            CashNote.PartID = LookUpEdit_PartID.EditValue.ToInt();
            CashNote.LinkType = (byte)LookUpEdit_Source.EditValue.ToInt();
            CashNote.LinkID = (int?)LookUpEdit_SourceID.EditValue;
            CashNote.Notes = memoEdit1.Text;
            CashNote.Amount  = Convert.ToDouble(spn_Paid.EditValue  );
            CashNote.DiscountValue   = Convert.ToDouble(spn_Discount.EditValue  );
            PartNumber = CashNote.Code  .ToString();
           
        }

        void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			DetailsDataContexst = new DAL.ERPDataContext(Program.setting.con);

            GridControl_Pays.DataSource =
                   DetailsDataContexst.Acc_Pays.Select<DAL.Acc_Pay, DAL.Acc_Pay>((Expression<Func<DAL.Acc_Pay, DAL.Acc_Pay>>)
                   (x => x)).Where(x => x.SourceType == (int)ProcessType && x.SourceID == CashNote.Code);

            if (IsNew)
                ((Collection<Acc_Pay>)GridView_Pays.DataSource).Add(new Acc_Pay()
                {
                    CurrancyID = 1,
                    Amount = 0,
                    Code = CashNote.Code.ToString(),
                    CurrancyRate = 1,
                    InsertDate = CashNote.Date,
                    PayDate = CashNote.Date,
                    PayType = 1,
                    PayID = CurrentSession.UserAccessibleDrawer.Where(x => x.ID == CurrentSession.user.DefaultDrawer).Single().ACCID.Value,
                    SourceID = CashNote.ID,
                    SourceType = (int)ProcessType,
                    UserID = CurrentSession.user.ID
                });


            txt_Code.Text = CashNote.Code  .ToString();
            lkp_Store.EditValue = CashNote.StoreID;
            lkp_CCenter.EditValue = CashNote.CCenter ;
            LookUpEdit_PartType.EditValue= (int)  CashNote.PartType;
            LookUpEdit_PartID.EditValue=   CashNote.PartID;
            LookUpEdit_Source.EditValue= (int)CashNote.LinkType;
            LookUpEdit_SourceID.EditValue=CashNote.LinkID;
            dt_Date.DateTime = CashNote.Date ;
            memoEdit1.Text = CashNote.Notes;
            spn_Paid.EditValue = CashNote.Amount;
            spn_Discount.EditValue = CashNote.DiscountValue;


            PartNumber = CashNote.Code  .ToString();
            txt_InsertUser.Text = db.St_Users.Where(x => x.ID == CashNote.UserID).Select(x => x.UserName).FirstOrDefault();
            txt_UpdateUser.Text = db.St_Users.Where(x => x.ID == CashNote.LastUpdateUserID).Select(x => x.UserName)
                .FirstOrDefault();
            txt_LastUpdate.Text = (CashNote.LastUpdateDate != null)
                ? ((DateTime)CashNote.LastUpdateDate).ToString("yyyy-MM-dd dddd hh:mm tt")    : "";



            ChangesMade = false;

        }
        public override void Print()
        {

            Print(new List<int>() { CashNote.Code }, this.Name, ISCashIn );

        }
        public static void Delete(List<int> Codes,Boolean IsCashIn , string CallerForm, byte ProccessID)

        {
            DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);
            foreach (var item in Codes)
            {
                Master.InsertUserLog(2, CallerForm, "", item.ToString());
                Master.DeleteAccountAcctivity(ProccessID.ToString(), item.ToString());
            }
            db.Acc_Pays.DeleteAllOnSubmit(db.Acc_Pays.Where(x => x.SourceType == ProccessID && Codes.Contains(x.SourceID )));
            db.Acc_Pays.DeleteAllOnSubmit(db.Acc_Pays.Where(x => x.PayType  ==(int) Master.PayTypes.CashNote  &&
                                                  db.Acc_CashNotes.Where(c => Codes.Contains(c.Code) && c.IsCashNote == IsCashIn).Select(c=>c.ID ).Contains(x.PayID )));
            db.SubmitChanges();
            db.Acc_CashNotes .DeleteAllOnSubmit(db.Acc_CashNotes .Where(c => Codes.Contains(c.Code) && c.IsCashNote == IsCashIn ));
            db.SubmitChanges();

            Master.RefreshAllWindows(); 
        }
        public static object  PrintDataSource(List<int> ids, Master.SystemProssess proccessType)
        {
          
            ERPDataContext db = new ERPDataContext(Program.setting.con);


            //HeaderDT.Columns.Add("Code", typeof(string));
            //HeaderDT.Columns.Add("Store");
            //HeaderDT.Columns.Add("Drawer"); 
            //HeaderDT.Columns.Add("Date", typeof(DateTime));
            //HeaderDT.Columns.Add("Notes", typeof(string));
            //HeaderDT.Columns.Add("Amount");
            //HeaderDT.Columns.Add("Discount");
            //HeaderDT.Columns.Add("Total");
            //HeaderDT.Columns.Add("TotalInText");
            //HeaderDT.Columns.Add("PartType");
            //HeaderDT.Columns.Add("PartName");
            //HeaderDT.Columns.Add("Source");
            //HeaderDT.Columns.Add("SourceCode");
            //HeaderDT.Columns.Add("User");






            //var parts = db.Pr_Vendors.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Vendor), x.Name });
            //parts.Concat(db.Sl_Customers.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Customer), x.Name }));
            //parts.Concat(db.HR_Employees.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Employee), x.Name }));
            //parts.Concat(db.Acc_Accounts.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Account), x.Name }));

            var Invoices = db.Inv_Invoices.Select(i => i);
            
            var quiry =( from e in db.Acc_CashNotes 
                        join b in db.Inv_Stores on e.StoreID equals b.ID
                     //   from d in db.Acc_Drawers.Where(x => x.ID == e.DrawerACCID )
                        from u in db.St_Users.Where(x => x.ID == e.UserID).DefaultIfEmpty()
                        from p in(
                        db.Pr_Vendors.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Vendor), x.Name })
                                       .Concat(db.Sl_Customers.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Customer), x.Name }))
                                       .Concat(db.HR_Employees.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Employee), x.Name }))
                                       .Concat(db.Acc_Accounts.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Account), x.Name }))
                        
                        ).Where(x => x.PartID  == e.PartID  && x.PartType == e.PartType ).DefaultIfEmpty()
                        from i in Invoices .Where (x =>x.InvoiceType == e.LinkType && x.ID == e.LinkID  ).DefaultIfEmpty ()
                        where ids.Contains(e.Code )
                        select new
                        {
                            e.ID,
                            e.Code, 
                            Barcode = string.Format("#*{0}*{1}", ((int)proccessType).ToString() , e.Code ),
                            p.PartType  ,
                            PartTypeText = "",
                            p.Name ,
                            Store = b.Name,
                            //Drawer = d.Name, 
                            e.Date ,
                            e.Notes,
                            e.Amount ,
                            NetText = "", 
                            e.DiscountValue ,
                            Total = e.Amount+e.DiscountValue,
                            e.LinkType ,
                            SourceName = "" ,
                            SourceCode = i.ID.ToString() + "-"+  i.Code.ToString()  ,
                            u.UserName,
                            Pays = db.Acc_Pays .Where(x=>x.SourceType == ((int)proccessType) && x.SourceID == e.Code  ).Select (
                             x=>   new {
                                 x.Amount ,
                                 x.Refrence ,
                                 x.PayType,PayTypeText ="",
                                 x.PayID,PayIDText="" , 
                                 x.PayDate ,
                                 Currancy = db.Acc_Currencies.Single(c=>c.ID == x.CurrancyID ).Name  , 
                                 x.CurrancyRate ,
                                 x.Notes     }).ToList()
                        }).ToList();

            //foreach (var h in quiry.ToList())
            //    HeaderDT.Rows.Add(h.Code , h.Store , h.Date , h.Notes
            //        , h.Amount , h.DiscountValue ,h.Total , Master.ConvertMoneyToText(h.Total.ToString() ,1)
            //       , h.PartType ,h.Name ,h.SourceName ,h.SourceCode  , h.UserName); 
            //ds.Tables.Add(HeaderDT); 
            List<Master.NameAndIDDataSource> payTypes = new List<Master.NameAndIDDataSource>()
                        {
                        new Master.NameAndIDDataSource(){ID = 1 ,Name = LangResource.CashPay  },
                        new Master.NameAndIDDataSource(){ID = 2 ,Name = LangResource.BankTransfer },
                        new Master.NameAndIDDataSource(){ID = 3 ,Name = LangResource.PayCards },
                        new Master.NameAndIDDataSource(){ID = 4 ,Name = LangResource.OnAccount },
                        };
            var banks = CurrentSession.UserAccessibleBanks.Select(x => new { ID = x.AccountID, Name = x.BankName ,Type =(int) Master.PayTypes.Bank  }).ToList();
            var drawers = CurrentSession.UserAccessibleDrawer.Select(x => new { ID = x.ACCID ?? 0, Name = x.Name, Type = (int)Master.PayTypes.Drawer }).ToList();
            var paycards = CurrentSession.UserAccessiblePayCards.Where(x => banks.Select(b => b.ID).Contains(x.BankID)).Select(x => new { x.ID, Name = x.Number, Type = (int)Master.PayTypes.PayCard }).ToList();
            var accounts = CurrentSession.UserAccessbileAccounts.Where(x => db.Acc_Accounts.Where(a => a.ParentID == x.ID).Count() == 0).Select(x => new { x.ID, Name = x.Name, Type = (int)Master.PayTypes.Account }).ToList();

            var PaySourcesName = drawers;

            PaySourcesName.AddRange(paycards);
            PaySourcesName.AddRange(accounts);
            PaySourcesName.AddRange(banks);

             var parts =   new[]
                   {
                      new { ID = 1 ,Name =  LangResource.Vendor  },
                      new { ID = 2 ,Name =  LangResource.Customer  },
                      new { ID = 3 ,Name =  LangResource.Employee  },
                      new { ID = 4 ,Name =  LangResource.Account  },
                    };

            quiry.ForEach(x =>
            {
                x.Set(i => i.NetText, Master.ConvertMoneyToText(x.Amount.ToString(), 1));
                x.Set(i => i.PartTypeText , parts.Single  (p=>p.ID == x.PartType).Name );
                if (x.LinkType > 0 && x.LinkType < Master.Prossess.Count()) 
                x.Set(i => i.SourceName , Master.Prossess[x.LinkType]);
                x.Pays.ForEach(p =>
                {
                    p.Set(i => i.PayTypeText, payTypes.Single(pt => pt.ID == p.PayType).Name);
                    p.Set(i => i.PayIDText , PaySourcesName.Single(pt => pt.ID  == p.PayID && pt.Type == p.PayType ).Name);


                });

            });
            return quiry;
        }
        public static void Print(List<int> ids, string CallerForm, bool IsCashIn)
        {

            foreach (var item in ids)
            {
                Master.InsertUserLog(3, CallerForm, "", item.ToString());
            }
            Reporting.rpt_CashNote .Print(PrintDataSource(ids,IsCashIn? SystemProssess.CashNoteIn : SystemProssess.CashNoteOut ), IsCashIn);
            //base.Print();
        }

     
        void LoadItemByCode(int code ,bool isCashIn )
        {
            DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
            CashNote = dbc.Acc_CashNotes.Where(x => x.Code  == code && x.IsCashNote == isCashIn).Single();// (from i in dbc.Acc_CashNotes where i.ID   == ID  select i).FirstOrDefault();
            ISCashIn = isCashIn;
            if (CashNote == null)
                New();
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            IsNew = false;
        }
        void LoadItemByID(int id)
        {
            DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
            CashNote = dbc.Acc_CashNotes.Where(x => x.ID == id ).SingleOrDefault();// (from i in dbc.Acc_CashNotes where i.ID   == ID  select i).FirstOrDefault();
            if(CashNote == null)
                CashNote = dbc.Acc_CashNotes.Where(x => x.Code  == id && x.IsCashNote == ISCashIn ).SingleOrDefault();// (from i in dbc.Acc_CashNotes where i.ID   == ID  select i).FirstOrDefault();
            if(CashNote ==null)
            {
                XtraMessageBox.Show(LangResource.DocumentNotFound);
                New();
                return;
            }
            this.Name = (ISCashIn) ? "frm_CashNoteIn" : "frm_CashNoteOut";
            IsNew = false;
        }

        private void LookUpEdit_PartType_EditValueChanged(object sender, EventArgs e)
        {
      
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var sources = new List<Master.NameAndIDDataSource>();
            sources.Add(new Master.NameAndIDDataSource() { ID = (int)Master.SystemProssess.Without, Name = Master.Prossess[(int)Master.SystemProssess.Without] }); 
            switch (LookUpEdit_PartType.EditValue.ToInt())
            {
                case 0:
                    LookUpEdit_PartID.Properties.DataSource = null;
                    LookUpEdit_PartID.EditValue = 0;
                    break;
                case (int)Master.PartTypes.Vendor :

                    LookUpEdit_PartID.Properties.DataSource = CurrentSession.UserAccessbileVendors.Select(c => new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
                    LookUpEdit_PartID.EditValue = null;
                    glkp_Fromitem.Text = LangResource.Vendor;

                    if (ISCashIn)
                        sources.Add(new Master.NameAndIDDataSource() { ID = (int)Master.SystemProssess.PurchaseReturn , Name = Master.Prossess[(int)Master.SystemProssess.PurchaseReturn] }); 
                    else
                        sources.Add(new Master.NameAndIDDataSource() { ID = (int)Master.SystemProssess.PurchaseInvoice , Name = Master.Prossess[(int)Master.SystemProssess.PurchaseInvoice] });  
                    break;

                case (int)Master.PartTypes.Customer :
                    LookUpEdit_PartID.Properties.DataSource = CurrentSession.UserAccessbileCustomers.Select(c => new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
                    LookUpEdit_PartID.EditValue =null;
                    glkp_Fromitem.Text = LangResource.Customer;
                     
                    if (ISCashIn)
                        sources.Add(new Master.NameAndIDDataSource() { ID = (int)Master.SystemProssess.SalesInvoice , Name = Master.Prossess[(int)Master.SystemProssess.SalesInvoice ] });
                    else
                        sources.Add(new Master.NameAndIDDataSource() { ID = (int)Master.SystemProssess.SalesReturn , Name = Master.Prossess[(int)Master.SystemProssess.SalesReturn ] });
                    break;
                case (int)Master.PartTypes.Employee :
                    LookUpEdit_PartID.Properties.DataSource = db.HR_Employees.Select(c => new { c.ID, c.Name }).ToList();
                    LookUpEdit_PartID.EditValue = 0;
                    glkp_Fromitem.Text = LangResource.Employee;

                    break;
                case (int)Master.PartTypes.Account:
                    LookUpEdit_PartID.Properties.DataSource = db.Acc_Accounts.Where(x => CurrentSession.UserAccessbileAccounts.Select(a => a.ID).Contains(x.ID) &&
                    db.Acc_Accounts.Where(a => a.ParentID == x.ID).Count() == 0).Select(c => new { c.ID, c.Name }).ToList();
                    LookUpEdit_PartID.EditValue = 0;
                    glkp_Fromitem.Text = LangResource.Account;
                    break;

                default:
                    break;
            }


           


            LookUpEdit_Source.Properties.DataSource = sources;
            LookUpEdit_Source.Properties.ValueMember = "ID";
            LookUpEdit_Source.Properties.DisplayMember = "Name";
            LookUpEdit_Source.Properties.ShowHeader = false;
            //LookUpEdit_Source.Properties.Columns[0].Visible = false; 
            
            LookUpEdit_PartID.Properties.PopulateViewColumns();
            Master.TranslateGridColumn(LookUpEdit_PartID.Properties.View);
           

        }
        private void cb_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
 


        }

        private void spn_Paid_EditValueChanged(object sender, EventArgs e)
        {
            spn_Total.EditValue = Convert.ToDouble(spn_Paid.EditValue) + Convert.ToDouble(spn_Discount.EditValue);
        }

        private void glkp_From_EditValueChanged(object sender, EventArgs e)
        {
            cb_Sourceitem.Enabled = glkp_Sourceitem.Enabled =
               (LookUpEdit_PartID.EditValue != null && LookUpEdit_PartID.EditValue != DBNull.Value);
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            if (LookUpEdit_PartID.EditValue == null) return;
            switch (LookUpEdit_PartType.EditValue.ToInt())
            {
                case 0:
                    break;

                case (int)Master.PartTypes.Vendor:
                    AccountID = CurrentSession.UserAccessbileVendors
                        .Where(x => x.ID.ToString() == LookUpEdit_PartID.EditValue.ToString()).Select(x => x.Account)
                        .FirstOrDefault(); break;
                case (int)Master.PartTypes.Customer :
                    AccountID = CurrentSession.UserAccessbileCustomers
                        .Where(x => x.ID.ToString() == LookUpEdit_PartID.EditValue.ToString()).Select(x => x.Account)
                        .FirstOrDefault(); break;
                case (int)Master.PartTypes.Employee :
                    AccountID = db.HR_Employees 
                        .Where(x => x.ID  ==Convert.ToInt32( LookUpEdit_PartID.EditValue)).Select(x => x.AccountId )
                        .FirstOrDefault()??0;
                    break;
                case (int)Master.PartTypes.Account:
                    AccountID = LookUpEdit_PartID.EditValue.ToInt();
                    break;
                default:
                    throw new NotImplementedException();
            }
            Master.AccountBalance CustomerBalance = Master.GetAccountBalance(AccountID);
            txt_BalanceBefore.Text = Math.Abs(CustomerBalance.Balance).ToString();
            txt_BBType.Text = (CustomerBalance.Balance >= 0) ? LangResource.Debit : LangResource.Credit;


        }

        private void glkp_Source_EditValueChanged(object sender, EventArgs e)
        {
            if (LookUpEdit_SourceID.EditValue == null || LookUpEdit_SourceID.EditValue == DBNull.Value || IsNew == false ) return;
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var Invoice = (from i in db.Inv_Invoices
                           where i.ID == Convert.ToInt32(LookUpEdit_SourceID.EditValue)
                           select new
                           {
                               i.PartType ,
                               i.PartID , 
                               i.Net,
                               Paid = (double?)db.Acc_Pays.Where(x => x.SourceType == Convert.ToInt32(LookUpEdit_Source.EditValue) && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0,
                           }

            ).FirstOrDefault();
            if (Invoice != null)
            {
                txt_PaiedFromInvoice.Text = Invoice.Paid.ToString();
                txt_InvoiceNet.Text = Invoice.Net.ToString(); 
                txt_Remains.Text = (Invoice.Net - Invoice.Paid ).ToString();
                if (Convert.ToDouble(spn_Paid.EditValue) == 0)
                {
                    var firstPay = ((Collection<Acc_Pay>)GridView_Pays.DataSource).FirstOrDefault();
                    if (firstPay != null)
                        firstPay.Amount = Convert.ToDouble((Invoice.Net - Invoice.Paid)); 
                    GridView_Pays_RowCountChanged(null, null); 
                }
                groupControl3item.Expanded = true;
                LookUpEdit_PartID.EditValue  = Invoice.PartID;
                LookUpEdit_PartType.EditValue =(int) Invoice.PartType;


            }
            else
            {
                txt_PaiedFromInvoice.Text =
                txt_InvoiceNet.Text =
                txt_Remains.Text = "";
                groupControl3item.Expanded = false; 
            }


        }

        private void cb_Source_EditValueChanged(object sender, EventArgs e)
        {

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var Invoices = db.Inv_Invoices.Select(x=>x);

            if(LookUpEdit_PartType.EditValue .ValidAsIntNonZero())
                Invoices = Invoices.Where(x => x.PartType == Convert.ToInt32(LookUpEdit_PartType.EditValue));
            if (LookUpEdit_Source.EditValue.ValidAsIntNonZero())
                Invoices = Invoices.Where(x => x.InvoiceType  == Convert.ToInt32(LookUpEdit_Source.EditValue));
            else
            {
                LookUpEdit_SourceID.Properties.DataSource = null;
                LookUpEdit_SourceID.EditValue = null;
                return; 
            }

            Invoices = Invoices.Where(i => (i.Net - ((double?)db.Acc_Pays.Where(x => x.SourceType == 6 && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0)) > 0 || i.ID == CashNote.LinkID ).Select(i => i);
            Invoices = Invoices.Where(x => x.IsApproved);
            var parts = db.Pr_Vendors.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Vendor), x.Name });
            parts.Concat(db.Sl_Customers .Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Customer ), x.Name }));
            parts.Concat(db.HR_Employees.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Employee), x.Name }));
            parts.Concat(db.Acc_Accounts.Select(x => new { PartID = x.ID, PartType = ((int)Master.PartTypes.Account), x.Name }));
            LookUpEdit_SourceID.Properties.DataSource = Invoices.Select(i => new
            {
                i.ID ,
                i.Code ,
                Part = parts.Where(x=>x.PartID == i.PartID && x.PartType == i.PartType  ).Single().Name ,
                i.Net,
                i.Date,
                Paid = (double?)db.Acc_Pays.Where(x => x.SourceType == 6 && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0, 
                Remains = i.Net - ((double?)db.Acc_Pays.Where(x => x.SourceType == 6 && x.SourceID == i.ID).Sum(x => x.Amount) ?? 0), 
            });
            LookUpEdit_SourceID.Properties.PopulateViewColumns();
            Master.TranslateGridColumn(LookUpEdit_SourceID.Properties.View);
        }

        private void glkp_Source_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null) return;
            if (LookUpEdit_SourceID.EditValue == null || LookUpEdit_SourceID.EditValue == DBNull.Value && Convert.ToInt32(LookUpEdit_SourceID.EditValue) == 0) return;
            if (e.Button.Tag.ToString() == "Open" && LookUpEdit_SourceID.EditValue != null )
            {
                //if (cb_Source.Text == LangResource.PurchaseInvoice)
                //    frm_Main.OpenForm(new frm_Pr_PrInvoice (Convert.ToInt32(glkp_Source.EditValue)), openNew: true, CloseIfOpen: false);
                //else if (cb_Source.Text == LangResource.purchasesReturn)
                //    frm_Main.OpenForm(new frm_Pr_PrReturnInvoice (Convert.ToInt32(glkp_Source.EditValue)), openNew: true, CloseIfOpen: false);
              //  else
                if (LookUpEdit_Source.Text == LangResource.SalesInvoice)
                    frm_Main.OpenForm(new frm_Inv_Invoice (Convert.ToInt32(LookUpEdit_SourceID.EditValue)), openNew: true, CloseIfOpen: false);
                else if (LookUpEdit_Source.Text == LangResource.SalesReturnInvoice)
                    frm_Main.OpenForm(new frm_Sl_SlReturnInvoice (Convert.ToInt32(LookUpEdit_SourceID.EditValue)), openNew: true, CloseIfOpen: false);

            } 
        }
        private void GridView_Pays_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var row = e.Row as Acc_Pay;
            var view = sender as GridView;
            if (row == null)
                return;
            if (row.Amount <= 0)
            {
                view.SetColumnError(view.Columns[nameof(row.Amount)], LangResource.ErrorValMustBeGreaterThan0);

                e.Valid = false;
            }
            if (row.PayType <= 0)
            {
                view.SetColumnError(view.Columns[nameof(row.PayType)], "");

                e.Valid = false;
            }
            if (row.PayID <= 0)
            {
                view.SetColumnError(view.Columns[nameof(row.PayID)], "");

                e.Valid = false;
            }
            if (row.PayDate.Year <= 1950)
            {

                view.SetColumnError(view.Columns[nameof(row.PayDate)], "");

                e.Valid = false;
            }
            if ((row.PayType == 2 || row.PayType == 3) && (row.Refrence == null || row.Refrence.Trim() == ""))
            {
                view.SetColumnError(view.Columns[nameof(row.Refrence)], LangResource.MustEnterTheBankTransferNumber);
                e.Valid = false;
            }
            if (row.PayType == 5 && (row.Refrence == null || row.Refrence.Trim() == ""))
            {

                view.SetColumnError(view.Columns[nameof(row.Refrence)], LangResource.MustEnterCashNoteNumber);
                e.Valid = false;
            }
            if (row.CurrancyRate <= 0)
            {
                view.SetColumnError(view.Columns[nameof(row.CurrancyRate)], LangResource.ErrorValMustBeGreaterThan0);
                e.Valid = false;
            }
        }

        private void GridView_Pays_RowCountChanged(object sender, EventArgs e)
        {
            var sum = (GridView_Pays.DataSource as Collection<Acc_Pay>).Sum(x => x.Amount);
            spn_Paid.EditValue = sum;
        }

        private void GridView_Pays_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var row = GridView_Pays.GetRow(e.RowHandle) as Acc_Pay;
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            if (e.Column.FieldName == nameof(row.CurrancyID))
            {
                var currency = db.Acc_Currencies.Where(x => x.ID == row.CurrancyID).Single();
                row.CurrancyRate = currency.LastRate;
            }
             

            row.UserID = CurrentSession.user.ID;
            row.InsertDate = db.GetSystemDate();
            GridView_Pays_RowCountChanged(sender, null);


        }

        private void GridView_Pays_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var row = GridView_Pays.GetRow(e.RowHandle) as Acc_Pay;
            if (row.PayType == 0)
                row.PayType = 1;
            row.UserID = CurrentSession.user.ID;
            row.InsertDate = db.GetSystemDate();
            row.PayDate = CashNote .Date;
            row.CurrancyID = 1;
            row.CurrancyRate = 1;
            row.SourceType = (int)Master.SystemProssess.SalesInvoice;
            row.SourceID = CashNote.Code ;
            row.Refrence = "";
        }

        private void GridView_Pays_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
            GridView Senderview = sender as GridView;

            if (e.Column.FieldName == "PayID")
            {
                RepositoryItemLookUpEdit PayIDRepoEXP = new RepositoryItemLookUpEdit();
                PayIDRepoEXP.NullText = "";
                if (Senderview.GetRowCellValue(e.RowHandle, "PayType").ValidAsIntNonZero() == false)
                { e.RepositoryItem = new RepositoryItem(); return; }

                var drawers = CurrentSession.UserAccessibleDrawer.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.ACCID, Name = x.Name });
                var banks = CurrentSession.UserAccessibleBanks.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.AccountID, Name = x.BankName });
                var paycards = CurrentSession.UserAccessiblePayCards.Where(x => banks.Select(b => b.ID).Contains(x.BankID)).Select(x => new { x.ID, Name = x.Number });
                var accounts = CurrentSession.UserAccessbileAccounts.Where(x => dbc.Acc_Accounts.Where(a => x.ParentID == x.ID).Count() == 0).Select(x => new { x.ID, Name = x.Name });
                switch (Senderview.GetRowCellValue(e.RowHandle, "PayType").ToInt())
                {
                    case 1:
                        PayIDRepoEXP.DataSource = drawers.ToList();
                        break;
                    case 2:
                        PayIDRepoEXP.DataSource = banks.ToList();
                        break;
                    case 3:
                        PayIDRepoEXP.DataSource = paycards.ToList();
                        break;
                    case 4:
                        PayIDRepoEXP.DataSource = accounts.ToList();
                        break;
                  
                }
                PayIDRepoEXP.DisplayMember = "Name";
                PayIDRepoEXP.ValueMember = "ID";
                PayIDRepoEXP.PopulateColumns();
                PayIDRepoEXP.Columns[0].Visible = false;
                e.RepositoryItem = PayIDRepoEXP;
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


        private void GridView_Pays_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView_Pays_FocusedColumnChanged(sender, new FocusedColumnChangedEventArgs(GridView_Pays.FocusedColumn, GridView_Pays.FocusedColumn));
        }

        private void GridView_Pays_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            var row = GridView_Pays.GetFocusedRow() as Acc_Pay;
            if (row == null) return;
            if (CurrentSession.user.CanPayFromSalesInvoice == false && row.PayID == (int)Master.PayTypes.Drawer)
            {
                e.FocusedColumn.OptionsColumn.ReadOnly = true;
                return;
            }
            if (e.FocusedColumn.FieldName == nameof(row.CurrancyRate))
            {
                e.FocusedColumn.OptionsColumn.ReadOnly = row.CurrancyID == 1;
            }
            if (e.FocusedColumn.FieldName == nameof(row.Amount))
            {
                e.FocusedColumn.OptionsColumn.ReadOnly = row.PayType == 5;
            }

        }
        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

    }
}
