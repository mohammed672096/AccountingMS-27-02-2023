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
using DevExpress.XtraLayout;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
using DevExpress.XtraBars;
using DAL;

namespace ERP .Forms.MAIN 
{
    public partial class frm_Bank : frm_Master
    {
        Acc_Bank bank;
        
        public frm_Bank( )
        {
            InitializeComponent();
            New();
            GetData(); 
        }
        public override void GoTo(int id)
        {
            if (id.ToString() == TextEdit_ID.Text) return;
            if (ChangesMade && !SaveChangedData()) return;
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            bank = db.Acc_Banks.Where(x => x.ID == id).SingleOrDefault();
            if (bank != null) { 
                GetData();
                IsNew = false;
            }
        }
        public bool CheckIfNameIsUsed(string Name)
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var obj = from s in db.Acc_Banks where this.TextEdit_ID.Text != s.ID.ToString() && s.BankName == Name select s.ID;
            return (obj.Count() > 0);
        }
        public bool CheckIfCodeIsUsed(string Code)
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var obj = from s in db.Acc_Banks where this.TextEdit_ID.Text != s.ID.ToString() && s.BankAccountNumber == Code select s.ID;
            return (obj.Count() > 0);
        }
        private bool ValidData()
        {

           
            if (TextEdit_BankName.EditValue == null || String.IsNullOrEmpty(TextEdit_BankName.Text))
            {
                TextEdit_BankName.ErrorText = LangResource.ErrorCantBeEmpry;
                TextEdit_BankName.Focus();
                return false;
            }
            if (TextEdit_BankAccountNumber.EditValue == null || String.IsNullOrEmpty(TextEdit_BankAccountNumber.Text))
            {
                TextEdit_BankAccountNumber.ErrorText = LangResource.ErrorCantBeEmpry;
                TextEdit_BankAccountNumber.Focus();
                return false;
            }
            if (TextEdit_LinkedToBranch.EditValue.ToInt ()<0)
            {
                TextEdit_LinkedToBranch.ErrorText = LangResource.ErrorCantBeEmpry;
                TextEdit_LinkedToBranch.Focus();
                return false;
            }
            if (usc_OpenBalance1.Validate() == false)
                return false;
            return true;
        }
        public override void Save()
        {
            if (CanSave() == false) return;
            if (!ValidData()) { return; }
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            if (IsNew)
            {
                bank = new Acc_Bank();
                db.Acc_Banks.InsertOnSubmit(bank);
                GenrateAccounts();
            }
            else
            {
                bank = db.Acc_Banks.Where(s => s.ID == bank.ID).First();
                Master.UpdateAccount((int)bank.AccountID , TextEdit_BankName .Text, secrecy: cb_Secrecy.SelectedIndex);
            }
            SetData();
            db.SubmitChanges();
            usc_OpenBalance1.Save();
                RefreshData();
            base.Save();
        }
        public override void Delete()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            if (CanPerformDelete() == false ) return;
            if (IsNew) return;
            var acctevetylog = from i in db.Acc_ActivityDetials
                               join l in db.Acc_Activities on i.AcivityID equals l.ID
                               where i.ACCID == bank.AccountID && l.Type != "0"
                               select i.ID;
            if (acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteDrawerHasTransactions, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var PayCards = db.Acc_PayCards.Where(x => x.BankID == bank.ID).Count();
            if (PayCards > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteBankUsedByPayCards , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PartNumber = bank.ID.ToString();
            PartName = bank.BankAccountNumber;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                bank = db.Acc_Banks.Where(c => c.ID == bank.ID).First();
                db.Acc_Banks.DeleteOnSubmit(bank);
                db.Acc_Accounts.DeleteOnSubmit(db.Acc_Accounts.Where(a => a.ID == bank.AccountID ).First());
                list.Remove(bank.ID);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            bank.BankName = TextEdit_BankName.Text ;
            bank.BankAccountNumber = TextEdit_BankAccountNumber.Text;
            bank.Address = TextEdit_Address.Text;
            bank.Phone1 = TextEdit_Phone1.Text;
            bank.Phone2 = TextEdit_Phone2.Text;
            bank.Phone3 = TextEdit_Phone3.Text;
            bank.Notes = TextEdit_Notes.Text;
            bank.LinkedToBranch = TextEdit_LinkedToBranch.EditValue.ToInt();
            usc_OpenBalance1.Account = bank.AccountID;

        }

        public override void New()
        {
            bank = new Acc_Bank() { LinkedToBranch =0};
           cb_Secrecy.SelectedIndex = 5;

            base.New();
            IsNew = true;
            GetData();
            ChangesMade = false;
        }
        public override void RefreshData()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var banks = (from c in db.Acc_Banks
                           join a in db.Acc_Accounts
                           on c.AccountID  equals a.ID
                           where a.Secrecy <= CurrentSession.user.AccountSecrecyLevel
                           select new { c.ID, c.BankName  }).ToList();

            var branches = db.Inv_Stores.Select(x => new { x.ID, x.Name }).ToList();
            branches.Add(new {ID= 0,Name =  LangResource.All });
            TextEdit_LinkedToBranch.Properties.DataSource = branches;
            TextEdit_LinkedToBranch.Properties.DisplayMember = "Name";
            TextEdit_LinkedToBranch.Properties.ValueMember = "ID";
            TextEdit_LinkedToBranch.TranslateColumns();
            TextEdit_LinkedToBranch.Properties.Columns[0].Visible = false;
            lkp_List.DataSource = banks;
            list = banks.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";
            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;
            usc_OpenBalance1.RefreshData();



            base.RefreshData();

        }
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            layoutControl1.AllowCustomization = false;
            btn_Refresh.Visibility = BarItemVisibility.Never;
            btn_Print.Visibility = BarItemVisibility.Never;
            barItem_Search.Visibility = BarItemVisibility.Always;
            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";
            lkp_List.PopulateColumns();

            #region DataChanged

            TextEdit_ID.EditValueChanged += DataChanged;
            TextEdit_BankName.EditValueChanged += DataChanged;
            TextEdit_BankAccountNumber.EditValueChanged += DataChanged;
            TextEdit_Address.EditValueChanged += DataChanged;
            TextEdit_Phone1.EditValueChanged += DataChanged;
            TextEdit_Phone2.EditValueChanged += DataChanged;
            TextEdit_Phone3.EditValueChanged += DataChanged;
            TextEdit_Notes.EditValueChanged += DataChanged;
            TextEdit_LinkedToBranch.EditValueChanged += DataChanged;
            #endregion 
        }
        private void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            TextEdit_ID.EditValue = bank.ID;
            TextEdit_BankName.EditValue = bank.BankName;
            TextEdit_BankAccountNumber.EditValue = bank.BankAccountNumber;
            TextEdit_Address.EditValue = bank.Address;
            TextEdit_Phone1.EditValue = bank.Phone1;
            TextEdit_Phone2.EditValue = bank.Phone2;
            TextEdit_Phone3.EditValue = bank.Phone3;
            TextEdit_Notes.EditValue = bank.Notes;
            TextEdit_LinkedToBranch.EditValue = bank.LinkedToBranch;
            usc_OpenBalance1.Account = bank.AccountID;
            usc_OpenBalance1.GetData();
            if (!IsNew)
                cb_Secrecy.SelectedIndex = (int)db.Acc_Accounts.Where(x => x.ID == bank.AccountID).First().Secrecy;


        }
        void GenrateAccounts()
        {
            bank.AccountID = (int)Master.InsertNewAccount(TextEdit_BankName .Text, CurrentSession.Company.BanksAccount , secrecy: cb_Secrecy.SelectedIndex);
            RefreshData();
        }
        public override void Print()
        {
           
        }
    
      
      
       
    }
}
