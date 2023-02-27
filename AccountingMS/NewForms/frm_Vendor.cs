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
    public partial class frm_Vendor : frm_Master
    {
        // DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
        DAL.Pr_Vendor vendor = new DAL.Pr_Vendor();

        public frm_Vendor(List<int> lst = null)
        {
            InitializeComponent();
            New();
            this.list = lst;

        }
        public frm_Vendor(int CusID, List<int> lst = null)
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
            tlkp_Group.EditValueChanged += DataChanged;
            tlkp_Account.EditValueChanged += DataChanged;
            tlkp_Account.EditValueChanged += DataChanged;
            spn_Balance.EditValueChanged += DataChanged;
            spn_MaxCredit.EditValueChanged += DataChanged;
            date_Balance.EditValueChanged += DataChanged;
            cb_Balance.EditValueChanged += DataChanged;
            cb_Secrecy.SelectedIndexChanged += DataChanged;
            txt_Email.EditValueChanged += DataChanged;
            txt_Mobile.EditValueChanged += DataChanged;

            #endregion

        }
        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            lkp_Currancy.Properties.DataSource = db.Acc_Currencies.Select(x => new { x.ID, x.Name }).ToList();
            CurrentSession.UserAccessbileAccounts = (from a in db.Acc_Accounts where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel select a).ToList();
            CurrentSession.UserAccessbileVendors = (from c in db.Pr_Vendors
                                                      join a in db.Acc_Accounts
                                                      on c.Account equals a.ID
                                                      join g in db.Pr_VendorGroups on c.GroupID equals g.Number
                                                      where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel
                                                      select c).ToList();

            var vendors = (from s in CurrentSession.UserAccessbileVendors select new { s.ID, s.Name }).ToList();
            var accounts = (from a in CurrentSession.UserAccessbileAccounts select new { a.ID , a.Name, a.ParentID }).ToList();

            lkp_List.DataSource = vendors;
            if (list == null) list = vendors.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";

            lkp_Currancy.Properties.DisplayMember = "Name";
            lkp_Currancy.Properties.ValueMember = "ID";

            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;

            tlkp_Account.Properties.DataSource = accounts;
            tlkp_Account.Properties.ValueMember = "ID";
            tlkp_Account.Properties.DisplayMember = "Name";
            tlkp_Account.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_Account.Properties.TreeList.KeyFieldName = "ID";

            tlkp_Group.Properties.DataSource = (from g in db.Pr_VendorGroups select new { g.Number, g.Name, g.ParentID}).ToList();
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
            var obj = from s in db.Pr_Vendors where this.txt_ID.Text != s.ID.ToString() && s.Name == Name select s.ID;
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
            if (chk_HasSeprateAccount.Checked == false && tlkp_Account.EditValue == null)
            {
                this.tlkp_Account.ErrorText = LangResource.ErrorCantBeEmpry;
                this.tlkp_Account.Focus();
                return false;
            }
            if (cb_Balance.SelectedIndex > 0)
            {
                if (Convert.ToDouble(spn_Balance.EditValue) <= 0)
                {
                    this.spn_Balance.ErrorText = LangResource.ErrorValMustBeGreaterThan0;
                    this.spn_Balance.Focus();
                    return false;
                }
                if (date_Balance.EditValue == null)
                {
                    this.date_Balance.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.date_Balance.Focus();
                    return false;
                }
                if (lkp_Currancy.EditValue == null)
                {
                    this.lkp_Currancy.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.lkp_Currancy.Focus();
                    return false;
                }
                if (spn_Rate.EditValue == null && Convert.ToDouble(spn_Rate.EditValue) <= 0)
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
                return (int)db.Pr_Vendors.Max(n => n.ID) + 1;

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
                vendor = new DAL.Pr_Vendor();
                vendor.ID = Convert.ToInt32(txt_ID.Text);
                if (IsNew && chk_HasSeprateAccount.Checked) GenrateAccounts();
                SaveDataContext.Pr_Vendors.InsertOnSubmit(vendor);
            }
            else
            {
                vendor = SaveDataContext.Pr_Vendors.Where(s => s.ID == Convert.ToInt32(vendor.ID)).First();
                if (!IsNew && chk_HasSeprateAccount.Checked && chk_HasSeprateAccount.Enabled)
                    GenrateAccounts();
                else
                    Master.UpdateAccount(vendor.Account, txt_Name.Text, secrecy: cb_Secrecy.SelectedIndex);
                RefreshData();

            }
            SetData();
            if (cb_Balance.SelectedIndex > 0)
            {
                Master.AccountOpenBalance OP = new Master.AccountOpenBalance();
                OP.IsDebit = (cb_Balance.SelectedIndex == 1);
                OP.Amount = Convert.ToDouble(spn_Balance.EditValue);
                OP.Date = date_Balance.DateTime;
                OP.CurrencyID = (int?)lkp_Currancy.EditValue ?? 1;
                OP.CurrencyRate = Convert.ToDouble((decimal?)spn_Rate.EditValue ?? 1);

                Master.CreatAccOpenBalance((int)vendor.Account, vendor.Name, OP);
            }
            else
            {
                Master.DeleteAccountAcctivity("0", vendor.Account.ToString());
            }

            SaveDataContext.SubmitChanges();
            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            CurrentSession.UserAccessbileVendors = (from c in db.Pr_Vendors
                                                      join a in db.Acc_Accounts
                                                      on c.Account equals a.ID 
                                                      join g in db.Pr_VendorGroups on c.GroupID equals g.Number
                                                      where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel  
                                                      select c).ToList();
            base.Save();
            chk_HasSeprateAccount.Enabled = !chk_HasSeprateAccount.Checked;

        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            vendor = new DAL.Pr_Vendor();
            vendor.ID = GetNextID();
            vendor.GroupID = 1;
            vendor.LinkedToAccount = false;
            cb_Secrecy.SelectedIndex = (int)CurrentSession.user.AccountSecrecyLevel;
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
            var acctevetylog = from i in db.Acc_ActivityDetials
                               join l in db.Acc_Activities on i.AcivityID equals l.ID
                               where i.ACCID == vendor.Account && l.Type != "0"
                               select i.ID;
            if (acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeletevendorIsUsedInTheSystem, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var linkedVendors = (from i in db.Pr_Vendors where i.LinkedToAccount == true && i.Account == vendor.Account select i.ID).Count();
            if (linkedVendors > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeletevendorIsParentOfanotherVendor, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PartNumber = vendor.ID.ToString();
            PartName = txt_Name.Text;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                vendor = db.Pr_Vendors.Where(c => c.ID == vendor.ID).First();
                db.Pr_Vendors.DeleteOnSubmit(vendor);
                if (vendor.LinkedToAccount == false)
                {
                    db.Acc_Accounts.DeleteOnSubmit(db.Acc_Accounts.Where(a => a.ID  == vendor.Account).First());
                    Master.DeleteAccountAcctivity("0", vendor.Account.ToString());
                }
                list.Remove(vendor.ID);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            vendor.Name = txt_Name.Text;
            vendor.GroupID = (int?)tlkp_Group.EditValue;
            vendor.Phone = txt_Phone.Text;
            vendor.Mobile = txt_Mobile.Text;
            vendor.Address = txt_Address.Text;
            vendor.City = txt_City.Text;
            vendor.EMail = txt_Email.Text;
            vendor.MaxCredit = Convert.ToInt32(spn_MaxCredit.EditValue);
            vendor.LinkedToAccount = !chk_HasSeprateAccount.Checked; 
            vendor.Account = Convert.ToInt32(tlkp_Account.EditValue);
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;

        }
        void GetData()
        {
            txt_ID.Text = vendor.ID.ToString();
            barItem_Search.EditValue = vendor.ID;
            txt_Name.Text = vendor.Name;
            tlkp_Group.EditValue = vendor.GroupID;
            txt_Phone.Text = vendor.Phone;
            txt_Address.Text = vendor.Address;
            txt_City.Text = vendor.City;
            tlkp_Account.EditValue = vendor.Account;
            txt_Mobile.Text = vendor.Mobile;
            txt_Email.Text = vendor.EMail;
            spn_MaxCredit.EditValue = vendor.MaxCredit;
            chk_HasSeprateAccount.Checked = !(bool)vendor.LinkedToAccount;
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;
            if (!IsNew)
            {
                uc_VendorSideMenu1.VendorID  = vendor .ID;
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
                tlkp_Account.Enabled = !chk_HasSeprateAccount.Checked;
                cb_Secrecy.SelectedIndex = (int)db.Acc_Accounts.Where(x => x.ID  == vendor.Account).First().Secrecy;
                chk_HasSeprateAccount.Enabled = !chk_HasSeprateAccount.Checked;
                Master.AccountOpenBalance OP = Master.GetAccountOpenBalance((long)vendor.Account);
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
                chk_HasSeprateAccount.Checked = true;
                chk_HasSeprateAccount.Enabled = true;
                tlkp_Account.ReadOnly = false;
                uc_VendorSideMenu1.VendorID  = 0;

            }
            ChangesMade = false;


        }
        void GenrateAccounts()
        {
            tlkp_Account.EditValue = Master.InsertNewAccount(txt_Name.Text, CurrentSession.Company . VendorsAccount , secrecy: cb_Secrecy.SelectedIndex);
            RefreshData();
        }
        void LoadObject(int vendorID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            vendor = (from i in db.Pr_Vendors where i.ID == vendorID select i).First();
            IsNew = false;

        }

        private void tlkp_Group_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if (e.Button.GetType() != typeof(EditorButton)) return;
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "add")
            {
                frm_Main.OpenForm(new frm_VendorGroup(), true);
                RefreshData();

            }

        }

        private void chk_HasSeprateAccount_CheckedChanged(object sender, EventArgs e)
        {
            bool HaseSepAccount = chk_HasSeprateAccount.Checked;
            lc_Account.Visibility = HaseSepAccount ? LayoutVisibility.Never : LayoutVisibility.Always;
            lc_Secracy.Visibility = lc_MaxCredit.Visibility = gb_OpenBalance.Visibility =
                !HaseSepAccount ? LayoutVisibility.Never : LayoutVisibility.Always;

        }

        private void cb_Balance_SelectedIndexChanged(object sender, EventArgs e)
        {
            date_Balance.Enabled = spn_Balance.Enabled = lkp_Currancy.Enabled = (cb_Balance.SelectedIndex > 0);
            if (cb_Balance.SelectedIndex <= 0)
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
            if (lkp_Currancy.EditValue != null && int.TryParse(lkp_Currancy.EditValue.ToString(), out id))
            {
                spn_Rate.EditValue = db.Acc_Currencies.Where(x => x.ID == id).Select(x => x.LastRate).FirstOrDefault();
                spn_Rate.Enabled = !(Convert.ToInt32(lkp_Currancy.EditValue) == 1);

            }
            else
            {
                spn_Rate.EditValue = null;
                spn_Rate.Enabled = false;

            }
        }
    }
}
