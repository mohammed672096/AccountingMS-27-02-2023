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

namespace ERP.Forms.MAIN 
{
    public partial class frm_PayCards : frm_Master
    {
        Acc_PayCard paycards;
        public frm_PayCards(int? ID = null, List<int> lst = null)
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
            paycards = db.Acc_PayCards.Where(x => x.ID == id).SingleOrDefault();
            if (paycards != null)
            {
                GetData();
                IsNew = false;
            }
        }
        
        public bool CheckIfCodeIsUsed(string Code)
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var obj = from s in db.Acc_PayCards where this.TextEdit_ID.Text != s.ID.ToString() && s.Number  == Code select s.ID;
            return (obj.Count() > 0);
        }
        private bool ValidData()
        {

          
            if (LookUpEdit_BankID.EditValue.ValidAsIntNonZero () == false )
            {
                LookUpEdit_BankID.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_BankID.Focus();
                return false;
            }
            if (TextEdit_Number.EditValue == null || String.IsNullOrEmpty(TextEdit_Number.Text))
            {
                TextEdit_Number.ErrorText = LangResource.ErrorCantBeEmpry;
                TextEdit_Number.Focus();
                return false;
            }
            if (SpinEdit_Commission.EditValue.IsNumber() ==false || Convert.ToDouble( SpinEdit_Commission.EditValue)<0)
            {
                SpinEdit_Commission.ErrorText = LangResource.ErrorCantBeEmpry;
                SpinEdit_Commission.Focus();
                return false;
            }
            if (LookUpEdit_CommissionAccount.EditValue .ValidAsIntNonZero () == false && Convert.ToDouble(  SpinEdit_Commission.EditValue) > 0  )
            {
                LookUpEdit_CommissionAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CommissionAccount.Focus();
                return false;
            }
            if (LookUpEdit_LinkedToBranch.EditValue.ToInt() < 0)
            {
                LookUpEdit_LinkedToBranch.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_LinkedToBranch.Focus();
                return false;
            }
            return true;
        }
        public override void Save()
        {
            if (CanSave() == false) return;
            if (!ValidData()) { return; }
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            if (IsNew)
            {
                paycards = new Acc_PayCard();
                db.Acc_PayCards.InsertOnSubmit(paycards);
            }
            else
            {
                paycards = db.Acc_PayCards.Where(s => s.ID == paycards.ID).First();
            }
            SetData();
            db.SubmitChanges();
            base.Save();
        }
        public override void Delete()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            if (CanPerformDelete()) return;
            if (IsNew) return;

            var acctevetylog = db.Acc_Pays.Where(x => x.PayType == 3 & x.PayID == paycards.ID);
            if (acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteCardISUsedInSystem, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PartNumber = paycards.ID.ToString();
            PartName = paycards.Number ;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                paycards = db.Acc_PayCards.Where(c => c.ID == paycards.ID).First();
                db.Acc_PayCards.DeleteOnSubmit(paycards);
                list.Remove(paycards.ID);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            paycards.BankID = LookUpEdit_BankID.EditValue.ToInt();
            paycards.Number = TextEdit_Number.Text ;
            paycards.Commission =Convert.ToDouble( SpinEdit_Commission.EditValue);
            paycards.CommissionAccount = LookUpEdit_CommissionAccount.EditValue.ToInt();
            paycards.LinkedToBranch = LookUpEdit_LinkedToBranch.EditValue.ToInt();
        }

        public override void New()
        {
            paycards = new Acc_PayCard();
            base.New();
            IsNew = true;
            ChangesMade = false;
        }
        public override void RefreshData()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);



            var banks = (from c in db.Acc_Banks
                         join a in db.Acc_Accounts
                         on c.AccountID equals a.ID
                         where a.Secrecy <= CurrentSession.user.AccountSecrecyLevel
                         select new { c.ID,Name =  c.BankName }) ;
            var PayCards = (from c in db.Acc_PayCards
                            join a in banks
                            on c.BankID  equals a.ID
                            select new { c.ID, a.Name , c.Number  }).ToList();
            var branches = db.Inv_Stores.Select(x => new { x.ID, x.Name }).ToList();
            branches.Add(new { ID = 0, Name = LangResource.All });

            LookUpEdit_LinkedToBranch.Properties.DataSource = branches;
            LookUpEdit_LinkedToBranch.Properties.DisplayMember = "Name";
            LookUpEdit_LinkedToBranch.Properties.ValueMember = "ID";
            LookUpEdit_LinkedToBranch.TranslateColumns();
            LookUpEdit_LinkedToBranch.Properties.Columns[0].Visible = false;

            LookUpEdit_BankID .Properties.DataSource = banks;
            LookUpEdit_BankID.Properties.DisplayMember = "Name";
            LookUpEdit_BankID.Properties.ValueMember = "ID";
            LookUpEdit_BankID.TranslateColumns();
            LookUpEdit_BankID.Properties.Columns[0].Visible = false;

            LookUpEdit_CommissionAccount .Properties.DataSource = CurrentSession.UserAccessbileAccounts.Select(x=>new { x.ID, x.Number, x.Name }).ToList();
            LookUpEdit_CommissionAccount.Properties.DisplayMember = "Name";
            LookUpEdit_CommissionAccount.Properties.ValueMember = "ID";
            LookUpEdit_CommissionAccount.TranslateColumns();
            LookUpEdit_CommissionAccount.Properties.Columns[0].Visible = false;

            lkp_List.DataSource = PayCards;
            list = PayCards.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Number";
            lkp_List.ValueMember = "ID";
            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;


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
            LookUpEdit_BankID.EditValueChanged += DataChanged;
            TextEdit_Number.EditValueChanged += DataChanged;
            SpinEdit_Commission.EditValueChanged += DataChanged;
            LookUpEdit_CommissionAccount.EditValueChanged += DataChanged;
            LookUpEdit_LinkedToBranch.EditValueChanged += DataChanged;
            #endregion 
        }
        private void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            TextEdit_ID.EditValue = paycards.ID;
            LookUpEdit_BankID.EditValue = paycards.BankID;
            TextEdit_Number.EditValue = paycards.Number;
            SpinEdit_Commission.EditValue = paycards.Commission;
            LookUpEdit_CommissionAccount.EditValue = paycards.CommissionAccount;
            LookUpEdit_LinkedToBranch.EditValue = paycards.LinkedToBranch;
        }
        public override void Print()
        {
           

        }
        
      
    }
}
