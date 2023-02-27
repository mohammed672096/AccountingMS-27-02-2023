using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frm_Drawer : frm_Master 
    {
        DAL.Acc_Drawer drawer = new DAL.Acc_Drawer();

        public frm_Drawer()
        {
            InitializeComponent();
            New();
        }

    public override void frm_Load(object sender, EventArgs e)
    {
        base.frm_Load(sender, e);
        btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        barItem_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always ;

        lkp_List.ValueMember = "ID";
        lkp_List.DisplayMember = "Name";
        GetData();
        #region DataChangedEventHandlers
        txt_Name.EditValueChanged += DataChanged;
        spn_Balance.EditValueChanged += DataChanged;
        date_Balance.EditValueChanged += DataChanged;
        cb_Secrecy.SelectedIndexChanged += DataChanged;

            #endregion
     }
        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var drawers = (from c in db.Acc_Drawers 
                                                      join a in db.Acc_Accounts
                                                      on (int)c.ACCID  equals a.ID 
                                                      where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel 
                                                      select new {c.ID , c.Name }).ToList();

            
            lkp_List.DataSource = drawers;
            list = drawers.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";
            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;


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
            var obj = from s in db.Acc_Drawers  where this.txt_ID.Text != s.ID.ToString() && s.Name == Name select s.ID;
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

            if (Convert.ToDouble(spn_Balance.EditValue) < 0)
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


            return true;
        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                return (int)db.Acc_Drawers.Max(n => n.ID) + 1;
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
                drawer = new DAL.Acc_Drawer ();
                drawer.ID = Convert.ToInt32(txt_ID.Text);
                GenrateAccounts();
                SaveDataContext.Acc_Drawers.InsertOnSubmit(drawer);
            }
            else
            {
                drawer = SaveDataContext.Acc_Drawers.Where(s => s.ID == Convert.ToInt32(drawer.ID)).First();
                
                Master.UpdateAccount((int)drawer.ACCID, txt_Name.Text, secrecy: cb_Secrecy.SelectedIndex);
                RefreshData();

            }
            SetData();
          
                Master.AccountOpenBalance OP = new Master.AccountOpenBalance();
                OP.IsDebit = true ;
                OP.Amount = Convert.ToDouble(spn_Balance.EditValue);
                OP.Date = date_Balance.DateTime;
                Master.CreatAccOpenBalance((int)drawer.ACCID, drawer.Name, OP);
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


        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            drawer = new DAL.Acc_Drawer ();
            drawer.ID = GetNextID();
            spn_Balance.EditValue = 0;
            date_Balance.DateTime = DateTime.Now; 
            cb_Secrecy.SelectedIndex = (int)CurrentSession.user.AccountSecrecyLevel;
            IsNew = true;
            GetData();
            base.New();
            ChangesMade = false;
        }
        public override void Delete()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            if (!CanPerformDelete()) return;
            if (IsNew) return;
            var acctevetylog = from i in db.Acc_ActivityDetials
                               join l in db.Acc_Activities on i.AcivityID equals l.ID
                               where i.ACCID == drawer.ACCID && l.Type != "0"
                               select i.ID;
            if (acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteDrawerHasTransactions, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          

            PartNumber = drawer.ID.ToString();
            PartName = txt_Name.Text;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                drawer = db.Acc_Drawers.Where(c => c.ID == drawer.ID).First();
                db.Acc_Drawers.DeleteOnSubmit(drawer);
                db.Acc_Accounts.DeleteOnSubmit(db.Acc_Accounts.Where(a => a.ID == drawer.ACCID ).First());
                Master.DeleteAccountAcctivity("0", drawer.ACCID.ToString());
                list.Remove(drawer.ID);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            drawer.Name = txt_Name.Text;
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;

        }
        void GetData()
        {
            txt_ID.Text = drawer.ID.ToString();
            barItem_Search.EditValue = drawer.ID;
            txt_Name.Text = drawer.Name;
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text;
            if (!IsNew )
            {
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
                cb_Secrecy.SelectedIndex = (int)db.Acc_Accounts.Where(x => x.ID  == drawer.ACCID).First().Secrecy;
                Master.AccountOpenBalance OP = Master.GetAccountOpenBalance((int) drawer.ACCID );
                spn_Balance.EditValue = OP.Amount;
                date_Balance.EditValue = OP.Date;
                OP.Date = date_Balance.DateTime;

            }

            ChangesMade = false;


        }
        void GenrateAccounts()
        {
            drawer .ACCID  =(int) Master.InsertNewAccount(txt_Name.Text, CurrentSession.Company . DrawerAccount , secrecy: cb_Secrecy.SelectedIndex);
            RefreshData();
        }
        void LoadObject(int DrawerID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            drawer = (from i in db.Acc_Drawers where i.ID == DrawerID select i).First();
            IsNew = false;

        }

    }
}
