using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frm_Customer : frm_Master 
    {
       // DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
        DAL.Sl_Customer customer = new DAL.Sl_Customer();

        public frm_Customer(List<int> lst = null)
        {
            InitializeComponent();
            New();
            this.list = lst;

        }
        public frm_Customer(int CusID, List<int> lst = null)
        {
            InitializeComponent();
            LoadObject(CusID);
            this.list = lst;

        }
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItem_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
 
            lkp_List.ValueMember = "ID";
            lkp_List.DisplayMember = "Name";
            GetData();
            #region DataChangedEventHandlers
            txt_Name.EditValueChanged += DataChanged;
            txt_Phone.EditValueChanged += DataChanged;
            txt_City.EditValueChanged += DataChanged;
            txt_Address.EditValueChanged += DataChanged;
            txt_ID.EditValueChanged += DataChanged;
            tlkp_Group .EditValueChanged += DataChanged;
            tlkp_Account .EditValueChanged += DataChanged;
            tlkp_Account.EditValueChanged += DataChanged;
            spn_Balance .EditValueChanged += DataChanged;
            spn_MaxCredit .EditValueChanged += DataChanged;
            date_Balance .EditValueChanged += DataChanged;
            cb_Balance.EditValueChanged += DataChanged;
            cb_Secrecy.SelectedIndexChanged += DataChanged;
            txt_Email .EditValueChanged += DataChanged;
            txt_Mobile.EditValueChanged += DataChanged;

            #endregion

        }
        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            lkp_Currancy.Properties.DataSource = db.Acc_Currencies.Select(x => new { x.ID, x.Name }).ToList();
            CurrentSession.UserAccessbileAccounts = (from a in db.Acc_Accounts where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel select a).ToList();
            CurrentSession.UserAccessbileCustomers = (from c in db.Sl_Customers
                                                      join a in db.Acc_Accounts
                                                      on c.Account equals a.ID
                                                      join g in db.Sl_CustomerGroups on c.GroupID equals g.Number
                                                      where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel &&
                                                      g.Number.ToString().StartsWith(CurrentSession.user.CustomersGroup.ToString())
                                                      select c).ToList();

            var customers = (from s in CurrentSession.UserAccessbileCustomers select new { s.ID, s.Name }).ToList();
            var accounts = (from a in CurrentSession.UserAccessbileAccounts select new { a.ID , a.Name, a.ParentID }).ToList();

            lkp_List.DataSource = customers;
            if (list == null) list = customers.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";

            lkp_Currancy.Properties .DisplayMember = "Name";
            lkp_Currancy.Properties.ValueMember = "ID";

            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;

            tlkp_Account.Properties.DataSource = accounts;
            tlkp_Account.Properties.ValueMember = "ID";
            tlkp_Account.Properties.DisplayMember = "Name";
            tlkp_Account.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_Account.Properties.TreeList.KeyFieldName = "ID";

            tlkp_Group.Properties.DataSource = (from g in CurrentSession.UserAccessbileCustomergroup select new { g.Number, g.Name, g.ParentID, g.Discount }).ToList();
            tlkp_Group.Properties.ValueMember = "Number";
            tlkp_Group.Properties.DisplayMember = "Name";
            tlkp_Group.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_Group.Properties.TreeList.KeyFieldName = "Number";


            base.RefreshData();
        }
        public override void GoTo(int id)
        {
            if (id.ToString() == txt_ID.Text) return;
            if (ChangesMade && !SaveChangedData()) return;
            LoadObject(id);
            GetData();

        }
        public bool CheckIfNameIsUsed(string Name)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var obj = from s in db.Sl_Customers  where this.txt_ID.Text != s.ID.ToString() && s.Name == Name select s.ID;
            return (obj.Count() > 0);
        }
        private bool ValidData()
        {
            if (string.IsNullOrEmpty(this.txt_Name.Text.Trim()))
            {
                this.txt_Name.ErrorText = LangResource.ErrorCantBeEmpry;
                this.txt_Name.Focus();
                return false;
            }
            if (CheckIfNameIsUsed(this.txt_Name.Text))
            {
                this.txt_Name.ErrorText = LangResource.ErorrThisNameIsUsedBefore;
                this.txt_Name.Focus();
                return false;
            }
            if( chk_HasSeprateAccount.Checked == false && tlkp_Account .EditValue == null)
            {
                this.tlkp_Account.ErrorText = LangResource.ErrorCantBeEmpry;
                this.tlkp_Account.Focus();
                return false;
            }
            if(cb_Balance.SelectedIndex> 0)
            {
                if( Convert.ToDouble(spn_Balance .EditValue ) <= 0)
                {
                    this.spn_Balance.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                    this.spn_Balance.Focus();
                    return false;
                }
                if ( date_Balance.EditValue == null )
                {
                    this.date_Balance.ErrorText = LangResource.ErrorCantBeEmpry ;
                    this.date_Balance.Focus();
                    return false;
                }
                if (lkp_Currancy .EditValue == null)
                {
                    this.lkp_Currancy.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.lkp_Currancy.Focus();
                    return false;
                }
                if (spn_Rate .EditValue == null && Convert.ToDouble(spn_Rate.EditValue) <= 0)
                {
                    this.spn_Rate.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                    this.spn_Rate.Focus();
                    return false;
                }
            }

            return true;
        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                return (int)db.Sl_Customers.Max(n => n.ID) + 1;

            }
            catch
            {
                return (int)1;


            }
        }
        public override void Save()
        {
           // if (IsNew && !CanAdd) { XtraMessageBox.Show(LangResource.CantAddNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
          if (CanSave() == false) return;
            if (!ValidData()) { return; }
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            DAL.ERPDataContext SaveDataContext = new DAL.ERPDataContext(Program.setting.con);

            if (IsNew)
            {
                customer = new DAL.Sl_Customer ();
                customer.ID = Convert.ToInt32(txt_ID.Text);
                if (IsNew && chk_HasSeprateAccount.Checked) GenrateAccounts();
                SaveDataContext.Sl_Customers.InsertOnSubmit(customer);
            }
            else
            {
                customer = SaveDataContext.Sl_Customers.Where(s => s.ID == Convert.ToInt32(customer.ID)).First();
                if (!IsNew && chk_HasSeprateAccount.Checked && chk_HasSeprateAccount.Enabled)
                    GenrateAccounts();
                else
                    Master.UpdateAccount(customer.Account, txt_Name.Text, secrecy: cb_Secrecy.SelectedIndex);
                RefreshData();

            }
            SetData();
            if(cb_Balance.SelectedIndex > 0)
            {
                Master.AccountOpenBalance OP = new Master.AccountOpenBalance();
                OP.IsDebit = (cb_Balance.SelectedIndex == 1);
                OP.Amount = Convert.ToDouble(spn_Balance.EditValue);
                OP.Date = date_Balance.DateTime;
                OP.CurrencyID = (int?)lkp_Currancy.EditValue ?? 1;
                OP.CurrencyRate  = Convert.ToDouble((decimal?) spn_Rate .EditValue??1);

                Master.CreatAccOpenBalance(customer.Account, customer.Name, OP);
            }
            else
            {
                Master.DeleteAccountAcctivity("0", customer.Account.ToString());
            }

            SaveDataContext.SubmitChanges();
            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            CurrentSession.UserAccessbileCustomers = (from c in db.Sl_Customers
                                                      join a in db.Acc_Accounts
                                                      on c.Account equals a.ID 
                                                      join g in db.Sl_CustomerGroups on c.GroupID equals g.Number
                                                      where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel &&
                                                      g.Number.ToString().StartsWith(CurrentSession.user.CustomersGroup.ToString())
                                                      select c).ToList();

            base.Save();
            chk_HasSeprateAccount.Enabled = !chk_HasSeprateAccount.Checked;


        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            customer = new DAL.Sl_Customer ();
            customer.ID = GetNextID();
            customer.GroupID = 1;
            customer.LinkedToAccount = false;
            cb_Secrecy.SelectedIndex =(int ) CurrentSession.user.AccountSecrecyLevel;
            IsNew = true;
            GetData();
            base.New();
            ChangesMade = false;
        }
        public override void Delete()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
  //if (!CanPerformDelete()) return;
            if (IsNew) return;
            var acctevetylog = from i in db.Acc_ActivityDetials join l in db.Acc_Activities on i.AcivityID equals l.ID
                               where i.ACCID == customer.Account && l.Type !="0" select i.ID;
            if (  acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeletecustomerIsUsedInTheSystem, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var linkedCustomers = (from i in db.Sl_Customers where i.LinkedToAccount == true && i.Account == customer.Account select i.ID).Count();
            if (linkedCustomers > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeletecustomerIsParentOfanotherCustomer, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PartNumber = customer.ID.ToString();
            PartName = txt_Name.Text;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                customer = db.Sl_Customers.Where(c => c.ID == customer.ID).First();
                db.Sl_Customers.DeleteOnSubmit(customer);
                if (customer.LinkedToAccount == false)
                {
                    db.Acc_Accounts.DeleteOnSubmit(db.Acc_Accounts.Where(a => a.ID  == customer.Account).First());
                    Master.DeleteAccountAcctivity("0", customer.Account.ToString());
                }
                list.Remove(customer.ID);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            customer.Name = txt_Name.Text;
            customer.GroupID = (int?)tlkp_Group.EditValue;
            customer.Phone = txt_Phone.Text;
            customer.Mobile  = txt_Mobile.Text;
            customer.Address = txt_Address.Text;
            customer.City = txt_City.Text;
            customer.EMail  = txt_Email .Text;
            customer.MaxCredit = Convert.ToInt32( spn_MaxCredit.EditValue);
            customer.LinkedToAccount = !chk_HasSeprateAccount.Checked;
          //  if (IsNew && chk_HasSeprateAccount.Checked) GenrateAccounts();
            customer.Account = Convert.ToInt32(tlkp_Account .EditValue);
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;

        }
        void GetData()
        {
            txt_ID.Text =  customer.ID.ToString();
            uc_CustomerSideMenu1.CustomerID = customer.ID;
            barItem_Search.EditValue = customer.ID;
            txt_Name.Text = customer.Name;
            tlkp_Group.EditValue = customer.GroupID;
            txt_Phone.Text = customer.Phone;
            txt_Address.Text = customer.Address;
            txt_City.Text = customer.City;
            tlkp_Account.EditValue = customer.Account;
            txt_Mobile.Text  =   customer.Mobile;
            txt_Email.Text  = customer.EMail  ;
            spn_MaxCredit.EditValue = customer.MaxCredit;
            chk_HasSeprateAccount.Checked= !customer.LinkedToAccount;
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;
            if(!IsNew)
            {
                uc_CustomerSideMenu1.CustomerID = customer.ID;
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
                tlkp_Account.ReadOnly  = chk_HasSeprateAccount.Checked;
                cb_Secrecy.SelectedIndex =(int) db.Acc_Accounts.Where(x => x.ID == customer.Account).First().Secrecy ;
                chk_HasSeprateAccount.Enabled = !chk_HasSeprateAccount.Checked;
                Master.AccountOpenBalance OP =  Master.GetAccountOpenBalance(customer.Account );
                if (OP.Amount > 0)
                {
                    cb_Balance.SelectedIndex = (OP.IsDebit) ? 1 : 2;
                    spn_Balance.EditValue = OP.Amount;
                    date_Balance.EditValue = OP.Date;
                    OP.Date = date_Balance.DateTime;
                    lkp_Currancy.EditValue = OP.CurrencyID;
                    spn_Rate.EditValue = OP.CurrencyRate;
                }
                else cb_Balance.SelectedIndex = 0;


            }
            else
            {
                cb_Balance.SelectedIndex = 0;
                chk_HasSeprateAccount.Checked= true;
                chk_HasSeprateAccount.Enabled = true;
                tlkp_Account.ReadOnly  = false ;
                uc_CustomerSideMenu1.CustomerID = 0;

            }
            ChangesMade = false;


        }
        void GenrateAccounts()
        {
            tlkp_Account.EditValue = Master.InsertNewAccount(txt_Name.Text, CurrentSession.Company . CustomersAccount ,secrecy:cb_Secrecy.SelectedIndex);
            RefreshData();
        }
        void LoadObject(int customerID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            customer = (from i in db.Sl_Customers where i.ID == customerID select i).First();
            IsNew = false;

        }

        private void tlkp_Group_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        
            if (e.Button.GetType() != typeof(EditorButton)) return;
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "add")
            {
                frm_Main.OpenForm(new frm_CustomerGroup(), true);
                RefreshData();
         
            }
     
    }

        private void chk_HasSeprateAccount_CheckedChanged(object sender, EventArgs e)
        {
            bool HaseSepAccount = chk_HasSeprateAccount.Checked ; 
            lc_Account.Visibility = HaseSepAccount ? LayoutVisibility.Never : LayoutVisibility.Always;
            lc_Secracy.Visibility = lc_MaxCredit.Visibility = gb_OpenBalance.Visibility =
                !HaseSepAccount ? LayoutVisibility.Never : LayoutVisibility.Always;
         
        }

        private void cb_Balance_SelectedIndexChanged(object sender, EventArgs e)
        {
            date_Balance.Enabled = spn_Balance.Enabled = lkp_Currancy .Enabled= (cb_Balance.SelectedIndex > 0);
            if(cb_Balance.SelectedIndex <= 0)
            {
                spn_Balance.EditValue = 0;
                lkp_Currancy.EditValue = 1;
            }
            else
            {
                lkp_Currancy.EditValue = null;
       
            }
        }

       
       
        private void lkp_Currancy_EditValueChanged(object sender, EventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            int id;
            if(lkp_Currancy.EditValue != null && int.TryParse(lkp_Currancy.EditValue.ToString(),out id))
            {
                spn_Rate.EditValue = db.Acc_Currencies.Where(x => x.ID == id).Select(x => x.LastRate).FirstOrDefault();
              spn_Rate.Enabled =    !(Convert.ToInt32(lkp_Currancy.EditValue) == 1)  ;

            }
            else
            {
                spn_Rate.EditValue = null;
                spn_Rate.Enabled = false;

            }
        }
    }
}
