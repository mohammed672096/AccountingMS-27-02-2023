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
    public partial class frm_Stores : frm_Master 
    {
        DAL.Inv_Store store = new DAL.Inv_Store();

        public frm_Stores(List<int> lst = null)
        {
            InitializeComponent();
            New();
            this.list = lst;

        }
        public frm_Stores(int strID, List<int> lst = null)
        {

            InitializeComponent();
            LoadObject(strID);
            this.list = lst;

        }
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItem_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            lkp_ParentID.Properties.ValueMember = "ID";
            lkp_ParentID.Properties.DisplayMember   = "Name";
            lkp_List.ValueMember = "ID";
            lkp_List.DisplayMember   = "Name";
            GetData();
            layoutControl_LookUpEdit_CostOfSoldGoodsAccount.Visibility = layoutControl_LookUpEdit_InventoryAccount.Visibility = CurrentSession.Company.StockIsPeriodic ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem1.Visibility = layoutControlItem6.Visibility = layoutControl_LookUpEdit_OpenInventoryAccount.Visibility =
            layoutControl_LookUpEdit_CloseInventoryAccount.Visibility = CurrentSession.Company.StockIsPeriodic ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            chk_HasAccount_CheckedChanged(chk_HasAccount,null);
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.AddRange(new string[] { LangResource.FirstInFirstOut, LangResource.LastInFirstOut, LangResource.WeightedAverage });




            LookUpEdit_CloseInventoryAccount.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown));
            LookUpEdit_OpenInventoryAccount.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown));
            LookUpEdit_InventoryAccount.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown));

            #region DataChangedEventHandlers
            txt_Name.EditValueChanged += DataChanged;
            txt_Phone .EditValueChanged += DataChanged;
            txt_City .EditValueChanged += DataChanged;
            txt_Address .EditValueChanged += DataChanged;
            txt_ID.EditValueChanged += DataChanged;
            lkp_ParentID.EditValueChanged += DataChanged;
            tlkpSalesDiscountAcc .EditValueChanged += DataChanged;
            tlkp_PurchaseACC .EditValueChanged += DataChanged;
            tlkp_PurchaseDiscountAcc .EditValueChanged += DataChanged;
            tlkp_PurchaseReturnAcc .EditValueChanged += DataChanged;
            tlkp_SalesACC .EditValueChanged += DataChanged;
            tlkp_SalesReturnAcc .EditValueChanged += DataChanged;

            #endregion
            
        }
        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            CurrentSession.UserAccessbileAccounts = (from a in db.Acc_Accounts where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel select a).ToList();
            CurrentSession.UserAccessbileStores = (from s in db.Inv_Stores select s).ToList(); //join a in CurrentSession.UserAccessbileAccounts on s.

            var stores =( from s in CurrentSession.UserAccessbileStores  select new { s.ID, s.Name }).ToList();
            var accounts =( from a in CurrentSession.UserAccessbileAccounts select new { a.ID, a.Name ,a.ParentID  }).ToList();
            lkp_ParentID.Properties.DataSource = stores;
            lkp_List.DataSource = stores;
            if (list == null) list = stores.Select(x => x.ID).ToList();

            lkp_List.DisplayMember = "Name";
            lkp_List.ValueMember = "ID";
            lkp_List.PopulateColumns();
            lkp_List.Columns[0].Visible = false;

            tlkp_SalesACC.Properties.DataSource = accounts;
            tlkp_SalesACC.Properties.ValueMember = "ID";
            tlkp_SalesACC.Properties.DisplayMember = "Name";
            tlkp_SalesACC.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_SalesACC.Properties.TreeList.KeyFieldName  = "ID";

            tlkp_SalesReturnAcc.Properties.DataSource = accounts;
            tlkp_SalesReturnAcc.Properties.ValueMember = "ID";
            tlkp_SalesReturnAcc.Properties.DisplayMember = "Name";
            tlkp_SalesReturnAcc.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_SalesReturnAcc.Properties.TreeList.KeyFieldName = "ID";

            tlkpSalesDiscountAcc.Properties.DataSource = accounts;
            tlkpSalesDiscountAcc.Properties.ValueMember = "ID";
            tlkpSalesDiscountAcc.Properties.DisplayMember = "Name";
            tlkpSalesDiscountAcc.Properties.TreeList.ParentFieldName = "ParentID";
            tlkpSalesDiscountAcc.Properties.TreeList.KeyFieldName = "ID";

            tlkp_PurchaseACC.Properties.DataSource = accounts;
            tlkp_PurchaseACC.Properties.ValueMember = "ID";
            tlkp_PurchaseACC.Properties.DisplayMember = "Name";
            tlkp_PurchaseACC.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_PurchaseACC.Properties.TreeList.KeyFieldName = "ID";

            tlkp_PurchaseReturnAcc.Properties.DataSource = accounts;
            tlkp_PurchaseReturnAcc.Properties.ValueMember = "ID";
            tlkp_PurchaseReturnAcc.Properties.DisplayMember = "Name";
            tlkp_PurchaseReturnAcc.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_PurchaseReturnAcc.Properties.TreeList.KeyFieldName = "ID";

            tlkp_PurchaseDiscountAcc.Properties.DataSource = accounts;
            tlkp_PurchaseDiscountAcc.Properties.ValueMember = "ID";
            tlkp_PurchaseDiscountAcc.Properties.DisplayMember = "Name";
            tlkp_PurchaseDiscountAcc.Properties.TreeList.ParentFieldName = "ParentID";
            tlkp_PurchaseDiscountAcc.Properties.TreeList.KeyFieldName = "ID";


            LookUpEdit_CloseInventoryAccount.Properties.DataSource = accounts;
            LookUpEdit_OpenInventoryAccount.Properties.DataSource = accounts;
            LookUpEdit_CostOfSoldGoodsAccount.Properties.DataSource = accounts;
            LookUpEdit_InventoryAccount.Properties.DataSource = accounts;

            LookUpEdit_CloseInventoryAccount.Properties.ValueMember = "ID";
            LookUpEdit_OpenInventoryAccount.Properties.ValueMember = "ID";
            LookUpEdit_CostOfSoldGoodsAccount.Properties.ValueMember = "ID";
            LookUpEdit_InventoryAccount.Properties.ValueMember = "ID";

            LookUpEdit_CloseInventoryAccount.Properties.DisplayMember = "Name";
            LookUpEdit_OpenInventoryAccount.Properties.DisplayMember = "Name";
            LookUpEdit_CostOfSoldGoodsAccount.Properties.DisplayMember = "Name";
            LookUpEdit_InventoryAccount.Properties.DisplayMember = "Name";

            LookUpEdit_CloseInventoryAccount.Properties.TreeList.ParentFieldName = "ParentID";
            LookUpEdit_OpenInventoryAccount.Properties.TreeList.ParentFieldName = "ParentID";
            LookUpEdit_CostOfSoldGoodsAccount.Properties.TreeList.ParentFieldName = "ParentID";
            LookUpEdit_InventoryAccount.Properties.TreeList.ParentFieldName = "ParentID";

            LookUpEdit_CloseInventoryAccount.Properties.TreeList.KeyFieldName = "ID";
            LookUpEdit_OpenInventoryAccount.Properties.TreeList.KeyFieldName = "ID";
            LookUpEdit_CostOfSoldGoodsAccount.Properties.TreeList.KeyFieldName = "ID";
            LookUpEdit_InventoryAccount.Properties.TreeList.KeyFieldName = "ID";







            LookUpEdit_CostCenter.Properties.DataSource = db.Acc_CostCenters.Select(x => new { x.ID, x.Number, x.Name }).ToList();
            LookUpEdit_CostCenter.Properties.ValueMember = "ID";
            LookUpEdit_CostCenter.Properties.DisplayMember = "Name";
            base.RefreshData();
        }
        public override void GoTo(int id)
        {
            if (id.ToString() == txt_ID.Text) return;
            if (ChangesMade && !SaveChangedData()) return;
            LoadObject (id);
            GetData();
 
        }
        public bool CheckIfNameIsUsed(string Name)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var obj = from s in db.Inv_Stores where this.txt_ID.Text != s.ID.ToString() && s.Name == Name select s.ID;
            return (obj.Count()>0);
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
            if (comboBoxEdit1.SelectedIndex<0)
            {
                this.comboBoxEdit1.ErrorText = LangResource.ErrorCantBeEmpry;
                this.comboBoxEdit1.Focus();
                return false;
            }

            if (chk_HasAccount.Checked == false )
            {
                if (tlkp_SalesACC.EditValue.ValidAsIntNonZero() == false)
                {
                    this.tlkp_SalesACC.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.tlkp_SalesACC.Focus();
                    return false;
                }
                if (tlkp_SalesReturnAcc.EditValue.ValidAsIntNonZero() == false)
                {
                    this.tlkp_SalesReturnAcc.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.tlkp_SalesReturnAcc.Focus();
                    return false;
                }
                if (tlkpSalesDiscountAcc.EditValue.ValidAsIntNonZero() == false)
                {
                    this.tlkpSalesDiscountAcc.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.tlkpSalesDiscountAcc.Focus();
                    return false;
                }

                if (tlkp_PurchaseDiscountAcc.EditValue.ValidAsIntNonZero() == false)
                {
                    this.tlkp_PurchaseDiscountAcc.ErrorText = LangResource.ErrorCantBeEmpry;
                    this.tlkp_PurchaseDiscountAcc.Focus();
                    return false;
                }

                if (CurrentSession.Company.StockIsPeriodic)
                {
                    if (LookUpEdit_CostOfSoldGoodsAccount.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.LookUpEdit_CostOfSoldGoodsAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.LookUpEdit_CostOfSoldGoodsAccount.Focus();
                        return false;
                    }
                    if (LookUpEdit_InventoryAccount.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.LookUpEdit_InventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.LookUpEdit_InventoryAccount.Focus();
                        return false;
                    }
                }
                else
                {
                    if (LookUpEdit_CloseInventoryAccount.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.LookUpEdit_CloseInventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.LookUpEdit_CloseInventoryAccount.Focus();
                        return false;
                    }
                    if (LookUpEdit_OpenInventoryAccount.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.LookUpEdit_OpenInventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.LookUpEdit_OpenInventoryAccount.Focus();
                        return false;
                    }
                    if (tlkp_PurchaseACC.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.tlkp_PurchaseACC.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.tlkp_PurchaseACC.Focus();
                        return false;
                    }
                    if (tlkp_PurchaseReturnAcc.EditValue.ValidAsIntNonZero() == false)
                    {
                        this.tlkp_PurchaseReturnAcc.ErrorText = LangResource.ErrorCantBeEmpry;
                        this.tlkp_PurchaseReturnAcc.Focus();
                        return false;
                    }
                }



            }
            return true;
        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return (int)db.Inv_Stores .Max(n => n.ID) + 1;

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
            DAL.ERPDataContext SaveDataContext = new DAL.ERPDataContext(Program.setting.con);

            if (IsNew)
            {
                store = new DAL.Inv_Store();
                store.ID = Convert.ToInt32(txt_ID.Text);
           
                SaveDataContext.Inv_Stores.InsertOnSubmit(store);
            }
            else
            {
                store = SaveDataContext.Inv_Stores.Where(s => s.ID == Convert.ToInt32(store.ID)).First();

            }
            if(chk_HasAccount.Checked) GenrateAccounts();
            SetData();
            SaveDataContext.SubmitChanges();
            DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
            CurrentSession.UserAccessbileStores = (from s in objDataContext.Inv_Stores select s).ToList();
            base.Save();
           

        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            store = new DAL.Inv_Store();
            store.ID = GetNextID();
            IsNew = true;
            GetData();
            base.New();
            ChangesMade = false;
        }
        public override void Delete()
        { 
            if (!CanPerformDelete ()) return;
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);


            if (IsNew) return;
            var items = from i in db.Inv_StoreLogs where i.StoreID == store.ID select i.ID;
            var acctevetylog = from i in db.Acc_Activities where i.StoreID == store.ID select i.ID;

            if (items.Count() > 0 || acctevetylog.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteStoreIsUsedInTheSystem, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            PartNumber = store .ID.ToString();
            PartName = txt_Name.Text;
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                store = db.Inv_Stores.Where(x => x.ID == store.ID).Single();
                db.Inv_Stores .DeleteOnSubmit(store);
                db.SubmitChanges();
                base.Delete();
                New();
            }
        }
        void SetData()
        {
            store.Name = txt_Name.Text;
            store.ParentStoreID =  (int?) lkp_ParentID.EditValue;
            store.Phone = txt_Phone.Text;
            store.Address = txt_Address.Text;
            store.City = txt_City.Text;
            store.SellAccountID              = tlkp_SalesACC.EditValue as int?;
            store.SellReturnAccountID        =tlkp_SalesReturnAcc .EditValue  as int?;
            store.SalesDiscountAccountID     =tlkpSalesDiscountAcc .EditValue as int?;
            store.PurchaseAccountID          =tlkp_PurchaseACC .EditValue as int?;
            store.PurchaseReturnAccountID    =tlkp_PurchaseReturnAcc .EditValue as int?;
            store.PurchaseDiscountAccountID  =tlkp_PurchaseDiscountAcc .EditValue as int?;
            store.CloseInventoryAccount      = LookUpEdit_CloseInventoryAccount.EditValue as int?;
            store.OpenInventoryAccount       = LookUpEdit_OpenInventoryAccount.EditValue as int?;
            store.CostOfSoldGoodsAcc         = LookUpEdit_CostOfSoldGoodsAccount.EditValue as int?;
            store.InventoryAccount           = LookUpEdit_InventoryAccount.EditValue as int?;
            store.CostCenter = LookUpEdit_CostCenter.EditValue as int?;
            store.CostMethod = comboBoxEdit1.SelectedIndex;
            PartNumber = txt_ID .Text;
            PartName = txt_Name.Text;

        }
        void GetData()
        {
             txt_ID.Text = store.ID.ToString();
            barItem_Search.EditValue = store.ID;

              txt_Name.Text                      =  store.Name                     ;
             lkp_ParentID.EditValue             =  store.ParentStoreID            ;
             txt_Phone.Text                     =  store.Phone                    ;
             txt_Address.Text                   =  store.Address                  ;
             txt_City.Text                      =  store.City                     ;
             tlkp_SalesACC.EditValue                          =  store.SellAccountID            ;
             tlkp_SalesReturnAcc.EditValue                    =  store.SellReturnAccountID      ;
             tlkpSalesDiscountAcc.EditValue                   =  store.SalesDiscountAccountID   ;
             tlkp_PurchaseACC.EditValue                       =  store.PurchaseAccountID        ;
             tlkp_PurchaseReturnAcc.EditValue                 =  store.PurchaseReturnAccountID  ;
             tlkp_PurchaseDiscountAcc.EditValue               =  store.PurchaseDiscountAccountID;
             LookUpEdit_CloseInventoryAccount.EditValue      =   store.CloseInventoryAccount    ;
             LookUpEdit_OpenInventoryAccount.EditValue       =   store.OpenInventoryAccount     ;
             LookUpEdit_CostOfSoldGoodsAccount.EditValue     =   store.CostOfSoldGoodsAcc       ;
             LookUpEdit_InventoryAccount.EditValue           =   store.InventoryAccount         ;
             LookUpEdit_CostCenter.EditValue = store.CostCenter;
            comboBoxEdit1.SelectedIndex = store.CostMethod.ToInt(); ;
            PartNumber = txt_ID.Text;
            PartName = txt_Name.Text ;
            ChangesMade = false;

        }
        void GenrateAccounts()
        {

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var ParentCompany = db.Inv_Stores.Where(x => x.ID == Convert.ToInt32(lkp_ParentID.EditValue)).SingleOrDefault();
            var SalesAccount = (ParentCompany != null && ParentCompany.SellAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.SellAccountID : CurrentSession.Company.SalesAccount;
            var SalesReturnAccount = (ParentCompany != null && ParentCompany.SellReturnAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.SellReturnAccountID : CurrentSession.Company.SalesReturnAccount;
            var SalesDiscountAccount = (ParentCompany != null && ParentCompany.SalesDiscountAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.SalesDiscountAccountID : CurrentSession.Company.SalesDiscountAccount;
            var PurchasesAccount = (ParentCompany != null && ParentCompany.PurchaseAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.PurchaseAccountID : CurrentSession.Company.PurchasesAccount;
            var PurchasesReturnAccount = (ParentCompany != null && ParentCompany.PurchaseReturnAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.PurchaseReturnAccountID : CurrentSession.Company.PurchasesReturnAccount;
            var PurchaseDiscountAccount = (ParentCompany != null && ParentCompany.PurchaseDiscountAccountID.ValidAsIntNonZero()) ? (int)ParentCompany.PurchaseDiscountAccountID : CurrentSession.Company.PurchaseDiscountAccount;
            var CloseInventoryAccount = (ParentCompany != null && ParentCompany.CloseInventoryAccount.ValidAsIntNonZero()) ? (int)ParentCompany.CloseInventoryAccount : CurrentSession.Company.CloseInventoryAccount;
            var OpenInventoryAccount = (ParentCompany != null && ParentCompany.OpenInventoryAccount.ValidAsIntNonZero()) ? (int)ParentCompany.OpenInventoryAccount : CurrentSession.Company.OpenInventoryAccount;
            var CostOfSoldGoodsAccount = (ParentCompany != null && ParentCompany.CostOfSoldGoodsAcc.ValidAsIntNonZero()) ? (int)ParentCompany.CostOfSoldGoodsAcc : CurrentSession.Company.CostOfSoldGoodsAccount;
            var InventoryAccount = (ParentCompany != null && ParentCompany.InventoryAccount.ValidAsIntNonZero()) ? (int)ParentCompany.InventoryAccount : CurrentSession.Company.InventoryAccount;



        if( tlkp_SalesACC.EditValue                       .ValidAsIntNonZero()==false)  tlkp_SalesACC.EditValue       = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.Sales, SalesAccount);
        if( tlkp_SalesReturnAcc.EditValue                 .ValidAsIntNonZero()==false)  tlkp_SalesReturnAcc.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.SalesReturn, SalesReturnAccount);
        if( tlkpSalesDiscountAcc.EditValue                .ValidAsIntNonZero()==false)  tlkpSalesDiscountAcc.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.SalesDiscount, SalesDiscountAccount);
        if( tlkp_PurchaseACC.EditValue                    .ValidAsIntNonZero()==false)  tlkp_PurchaseACC.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.Purchases, PurchasesAccount);
        if( tlkp_PurchaseReturnAcc.EditValue              .ValidAsIntNonZero()==false)  tlkp_PurchaseReturnAcc.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.purchasesReturn, PurchasesReturnAccount);
        if( tlkp_PurchaseDiscountAcc.EditValue            .ValidAsIntNonZero()==false)  tlkp_PurchaseDiscountAcc.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.PurchaseDiscount, PurchaseDiscountAccount);
        if( LookUpEdit_CloseInventoryAccount.EditValue    .ValidAsIntNonZero()==false)  LookUpEdit_CloseInventoryAccount.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.CloseInventory, CloseInventoryAccount);
        if( LookUpEdit_OpenInventoryAccount.EditValue     .ValidAsIntNonZero()==false)  LookUpEdit_OpenInventoryAccount.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.OpenInventory, OpenInventoryAccount);
        if( LookUpEdit_CostOfSoldGoodsAccount.EditValue   .ValidAsIntNonZero()==false)  LookUpEdit_CostOfSoldGoodsAccount.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.CostOfSoldGoodsAccount, CostOfSoldGoodsAccount);
        if (LookUpEdit_InventoryAccount.EditValue         .ValidAsIntNonZero()==false)  LookUpEdit_InventoryAccount.EditValue = Master.InsertNewAccount(txt_Name.Text + " - " + LangResource.TheInventory, InventoryAccount);



            RefreshData();
        }
        void LoadObject(int StoreID)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            store = (from i in db.Inv_Stores  where i.ID == StoreID select i).First();
            IsNew = false;
          
        }

        private void chk_HasAccount_CheckedChanged(object sender, EventArgs e)
        {
            tlkp_SalesACC.ReadOnly = chk_HasAccount.Checked;
            tlkp_SalesReturnAcc.ReadOnly = chk_HasAccount.Checked;               
            tlkpSalesDiscountAcc.ReadOnly = chk_HasAccount.Checked;              
            tlkp_PurchaseACC.ReadOnly = chk_HasAccount.Checked;                  
            tlkp_PurchaseReturnAcc.ReadOnly = chk_HasAccount.Checked;            
            tlkp_PurchaseDiscountAcc.ReadOnly = chk_HasAccount.Checked;          
            LookUpEdit_CloseInventoryAccount.ReadOnly = chk_HasAccount.Checked;  
            LookUpEdit_OpenInventoryAccount.ReadOnly = chk_HasAccount.Checked;   
            LookUpEdit_CostOfSoldGoodsAccount.ReadOnly = chk_HasAccount.Checked; 
            LookUpEdit_InventoryAccount.ReadOnly = chk_HasAccount.Checked; 

        }

        private void lkp_ParentID_EditValueChanged(object sender, EventArgs e)
        {
            if (lkp_ParentID.EditValue.ValidAsIntNonZero())
            {
                chk_HasAccount.ReadOnly = true;
                if(IsNew)
                {
                    tlkp_SalesACC.EditValue                          = null;
                    tlkp_SalesReturnAcc.EditValue                    = null;
                    tlkpSalesDiscountAcc.EditValue                   = null;
                    tlkp_PurchaseACC.EditValue                       = null;
                    tlkp_PurchaseReturnAcc.EditValue                 = null;
                    tlkp_PurchaseDiscountAcc.EditValue               = null;
                    LookUpEdit_CloseInventoryAccount.EditValue       = null;
                    LookUpEdit_OpenInventoryAccount.EditValue        = null;
                    LookUpEdit_CostOfSoldGoodsAccount.EditValue      = null;
                    LookUpEdit_InventoryAccount.EditValue = null;
                }
            }
            else
            {
                chk_HasAccount.ReadOnly = false;
            }
        }
    }
}
