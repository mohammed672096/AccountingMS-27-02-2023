using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
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
using DAL;
using System.Reflection;
using DevExpress.XtraTreeList;
using System.Resources;
using DevExpress.XtraEditors.Repository;

namespace ERP.Forms
{
    public partial class frm_UserControl : frm_Master
    {
        DAL.St_User user;
        List<DAL.St_UserPrivilege> ScreenAccessList ; 
      
        private DataTable _screenPrivilage;
        public DataTable  ScreenPrivilage
        {
            get {
                if(_screenPrivilage == null)
                {
                    _screenPrivilage = new DataTable();
                    _screenPrivilage.Columns.Add("ID", typeof(int));
                    _screenPrivilage.Columns.Add("Tag", typeof(string));
                    _screenPrivilage.Columns.Add("Parent", typeof(int)); 
                    _screenPrivilage.Columns.Add("Text", typeof(string));
                    _screenPrivilage.Columns.Add("Show", typeof(bool));
                    _screenPrivilage.Columns.Add("Open", typeof(bool));
                    _screenPrivilage.Columns.Add("Add", typeof(bool));
                    _screenPrivilage.Columns.Add("Edit", typeof(bool));
                    _screenPrivilage.Columns.Add("Delete", typeof(bool));
                    _screenPrivilage.Columns.Add("Print", typeof(bool)); 
                    LoadNodesIntoDatatable(_screenPrivilage);
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_Revenue")
                        .FirstOrDefault()["Text"] = LangResource.RevenuEntry ;
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_RevenueList")
                       .FirstOrDefault()["Text"] =   LangResource.Revenues; 
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_Expence")
                                           .FirstOrDefault()["Text"] = LangResource.ExpenceEntry; 
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_ExpenceList")
                                           .FirstOrDefault()["Text"] = LangResource.Expenses;
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_CashNoteIn")
                           .FirstOrDefault()["Text"] = LangResource.CashNoteIn;
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_CashNoteInList")
                       .FirstOrDefault()["Text"] = LangResource.CashNoteIns ; 
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_CashNoteOut")
                                           .FirstOrDefault()["Text"] = LangResource.CashNoteOut;
                    _screenPrivilage.AsEnumerable().Where(x => x.Field<string>("Tag") == "frm_CashNoteOutList")
                           .FirstOrDefault()["Text"] = LangResource.CashNoteOuts;
                }
                return _screenPrivilage;

            }
            set
            {
                _screenPrivilage = value; 
            }
        }

        public frm_UserControl()
        {
            InitializeComponent();
         
            New();
        }

        public frm_UserControl(int UserID)
        {
            InitializeComponent(); 
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            user = db.St_Users.Where(x => x.ID == UserID).Single();
            GetData(); 
        }
        public frm_UserControl(DAL.St_User  User)
        {
            InitializeComponent();
          
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            user = User;
            GetData();
        }

        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var store = (from s in db.Inv_Stores select new { s.ID, s.Name }).ToList();
            lkp_DefualtStore .Properties.DataSource =
                lkp_DefualtRawStore .Properties.DataSource = store; 
            tlkp_MandetoryCustomerGroup.Properties.DataSource = (from g in db.Sl_CustomerGroups 
                                                                select new {g.Number ,g.Name  }).ToList();
            tlkp_CostCenter.Properties.DataSource = (from c in db.Acc_CostCenters
                                                    select new { c.ID, c.Name }).ToList();
            lkp_Employee.Properties.DataSource = db.HR_Employees.Where(x => x.Status != 0).Select(x => new { x.ID, x.Name }).ToList();
            lkp_DefaultSalesRepresentative.Properties.DataSource = db.HR_Employees.Where(x => x.Status != 0 
            && x.IsSalesRepresentative == true ).Select(x => new { x.ID, x.Name }).ToList();
            RefreshCustomerList();
            RefreshVendorslist();
            RefreshDrawerList();

            base.RefreshData();

        }
        #region Refresh dependenscy Data 
        void RefreshCustomerList()
        {
            if(tlkp_MandetoryCustomerGroup.EditValue  != null)
            {
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
                 lkp_DefualtCustomer.Properties.DataSource  = 
                    (from c in db.Sl_Customers.Where(x => x.GroupID.ToString().StartsWith(tlkp_MandetoryCustomerGroup.EditValue.ToString()) )
                     join ac in db.Acc_Accounts on c.Account equals ac.ID  
                     where ac.Secrecy >=Convert.ToInt32( bar_AccountSecracy.EditValue)  
                     select new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();

            }else
            {
                lkp_DefualtCustomer.Properties.DataSource = null; 
            }

        }
        void RefreshDrawerList()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            lkp_DefualtDrawer.Properties.DataSource =
               (from d in db.Acc_Drawers
                join ac in db.Acc_Accounts on (long)d.ACCID equals ac.ID 
                where ac.Secrecy >= Convert.ToInt32(bar_AccountSecracy.EditValue)
                select new { d.ID, d.Name }).ToList(); 
        }
        void RefreshVendorslist()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            lkp_DefualtVendor .Properties.DataSource =
               (from c in db.Pr_Vendors  
                join ac in db.Acc_Accounts on c.Account equals ac.ID 
                where ac.Secrecy >= Convert.ToInt32(bar_AccountSecracy.EditValue)
                select new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
           
        }
        #endregion

        void LoadNodesIntoDatatable( DataTable dt)
        {
            foreach (var  item in GUI.BarItem.BarItems) 
                    dt.Rows.Add(item.ID ,item.Tag, item.ParentID , item.Text, false, false, false, false, false, false);
           
        }
     
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            treeList1.Nodes.Clear(); 
            treeList1.DataSource = ScreenPrivilage;
            GetScreenAccess(user);
          //  treeList1.ExpandAll();
            treeList1.ParentFieldName = "Parent";
            treeList1.KeyFieldName = "ID";
            treeList1.OptionsBehavior.Editable = true;
            repositoryItemCheckEdit1.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio2;
            repositoryItemCheckEdit1.CheckBoxOptions.SvgColorChecked = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            repositoryItemCheckEdit1.CheckBoxOptions.SvgColorGrayed = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            repositoryItemCheckEdit1.CheckBoxOptions.SvgColorUnchecked = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;

            treeList1.RepositoryItems.Add(repositoryItemCheckEdit1);
            treeList1.Columns["Show"].ColumnEdit =
            treeList1.Columns["Open"].ColumnEdit =
            treeList1.Columns["Add" ].ColumnEdit =
            treeList1.Columns["Edit"].ColumnEdit =
            treeList1.Columns["Delete"].ColumnEdit =
            treeList1.Columns["Print"].ColumnEdit = repositoryItemCheckEdit1;
            treeList1.Columns["Text"].Caption = LangResource.Name;
            treeList1.Columns["Show"].Caption = LangResource.Show;
            treeList1.Columns["Open"].Caption = LangResource.Open;
            treeList1.Columns["Add" ].Caption = LangResource.Add;
            treeList1.Columns["Edit"].Caption = LangResource.Edit ;
            treeList1.Columns["Delete"].Caption = LangResource.Delete  ;
            treeList1.Columns["Print"].Caption = LangResource.Print   ;
            treeList1.ExpandAll();
            treeList1.Columns["Text"].Width = simpleButton7.Width;
            treeList1.Columns["Text"].OptionsColumn.AllowEdit = false;
    //        treeList1.Columns[2].OptionsColumn.AllowEdit = false;
            treeList1.Columns["Tag"].Visible  = false;


            radioGroup3_SelectedIndexChanged(new object() , new EventArgs());
            lkp_DefualtStore.Properties.ValueMember =
                lkp_DefualtVendor.Properties.ValueMember =
                lkp_DefualtRawStore.Properties.ValueMember =
                tlkp_CostCenter .Properties.ValueMember = 
                lkp_DefualtDrawer .Properties.ValueMember =
                lkp_Employee .Properties.ValueMember =
                lkp_DefaultSalesRepresentative.Properties.ValueMember =
                lkp_DefualtCustomer.Properties.ValueMember = "ID";
            tlkp_MandetoryCustomerGroup.Properties.ValueMember = "Number";


       lkp_DefualtStore.Properties.DisplayMember  =
                lkp_DefualtVendor.Properties.DisplayMember =
                lkp_DefualtRawStore.Properties.DisplayMember =
                 tlkp_MandetoryCustomerGroup.Properties.DisplayMember =
                tlkp_CostCenter.Properties.DisplayMember = 
                lkp_DefualtDrawer.Properties.DisplayMember =
                lkp_Employee.Properties.DisplayMember =
                lkp_DefaultSalesRepresentative.Properties.DisplayMember =
                lkp_DefualtCustomer.Properties.DisplayMember = "Name";

            lkp_DefualtStore.ItemIndex =
                lkp_DefualtRawStore.ItemIndex =
                lkp_DefualtVendor.ItemIndex =  
                lkp_DefualtCustomer.ItemIndex = 1;
            tlkp_MandetoryCustomerGroup.EditValue =
                          tlkp_CostCenter.EditValue  = 1;

            simpleButton7_SizeChanged(null,null );

            this.isFormPainted = true;
        }
        private void treeList1_CustomDrawNodeButton(object sender, DevExpress.XtraTreeList.CustomDrawNodeButtonEventArgs e)
        {
            Rectangle rect = Rectangle.Inflate(e.Bounds, -2, -2);

            // painting background
            Brush backBrush = e.Cache.GetSolidBrush(Color.WhiteSmoke);
            e.Cache.FillRectangle(backBrush, rect);
            // painting borders
            e.Cache.DrawRectangle(e.Cache.GetPen(Color.Black), rect);

            // determining the character to display
            string displayCharacter = e.Expanded ? "-" : "+";
            // formatting the output character
            StringFormat outCharacterFormat = e.Appearance.GetStringFormat();
            outCharacterFormat.Alignment = StringAlignment.Center;
            outCharacterFormat.LineAlignment = StringAlignment.Center;

            // painting the character
            e.Appearance.FontSizeDelta = -2;
            e.Appearance.FontStyleDelta = FontStyle.Bold;
            e.Cache.DrawString(displayCharacter, e.Appearance.Font,
                e.Cache.GetSolidBrush(Color.Black), rect, outCharacterFormat);

            // prohibiting default painting
            e.Handled = true;

        }
 


        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (radioGroup_Access .SelectedIndex == 0)
            {
                treeList1.CheckAll();
               treeList1.Enabled = false;
                radioGroup_AccessByTime.Enabled = false; 
                radioGroup_AccessByTime.SelectedIndex = 1;
                chk_CanChangeCashNoteDates.Checked =
                    chk_CanChangeCostCenter.Checked =
                    chk_CanChangeDefualtStore.Checked =
                    chk_CanChangeDrawer.Checked =
                    chk_CanChangePrice.Checked =
                    true;

                chk_CanChangeCashNoteDates.Enabled  =
                   chk_CanChangeCostCenter.Enabled =
                   chk_CanChangeDefualtStore.Enabled =
                   chk_CanChangeDrawer.Enabled =
                   chk_CanChangePrice.Enabled =
                   false ;
                bar_AccountSecracy.EditValue = 0;
                bar_AccountSecracy.Enabled = false;
            }
            else
            {
                radioGroup_AccessByTime.Enabled = treeList1.Enabled = true  ;

                chk_CanChangeCashNoteDates.Enabled =
                   chk_CanChangeCostCenter.Enabled =
                   chk_CanChangeDefualtStore.Enabled =
                   chk_CanChangeDrawer.Enabled =
                   chk_CanChangePrice.Enabled =
                   true;
                bar_AccountSecracy.Enabled = true ;

            }
        }

        private void radioGroup_AccessByTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ci_AccessByTimeType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never ;

            if (radioGroup_AccessByTime.SelectedIndex == 0)
            {
                ci_AccessByTimeType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; 
            }
        }

        private void radioGroup_AccessByTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ci_FromTime.Visibility = ci_ToTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            if(radioGroup_AccessByTimeType.SelectedIndex == 1)
            {
                ci_FromTime.Visibility = ci_ToTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;


            }
        }

        private void tlkp_MandetoryCustomerGroup_EditValueChanged(object sender, EventArgs e)
        {
            RefreshCustomerList();
        }

        private void bar_AccountSecracy_EditValueChanged(object sender, EventArgs e)
        {
            RefreshCustomerList();
            RefreshVendorslist();
            RefreshDrawerList();
        }
        int GetNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                return (int)db.St_Users .Max(n => n.ID) + 1;
            }
            catch
            {
                return (int)1;
            }
        }
        public  override  void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            user = new DAL.St_User();
            user.ID = GetNextID();
            user.DefaultCustomer = CurrentSession.UserAccessbileCustomers.First().ID;
            user.DefaultDrawer  = CurrentSession.UserAccessibleDrawer .First().ID;
            user.DefaultRawStore  = CurrentSession.UserAccessbileStores .First().ID;
            user.DefaultStore  = CurrentSession.UserAccessbileStores.First().ID;
            user.DefaultVendor  = CurrentSession.UserAccessbileVendors .First().ID;
            user.DefualtCCenter  = 1;
            user.CustomersGroup  = 1;
            user.HasAccess  = 0;
            user.AccessByTime  =true  ;
            user.AccountSecrecyLevel = 0;
            GetData();
            base.New();
            IsNew = true;
            ChangesMade = false;

        }
        public override void Save()
        {

            if (CanSave() == false) return;
            if (!ValidData()) { return; }
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            db.St_UserPrivileges.DeleteAllOnSubmit(db.St_UserPrivileges.Where(x => x.UserID == user.ID));
            db.SubmitChanges();
            SaveAsNew:
            if (IsNew)
            {
                
                db.St_Users.InsertOnSubmit(user);
                 
            }
            else
            {
                user  = db.St_Users .Where(x => x.ID == user .ID).First();
                if (user  == null)
                {
                    New();
                    goto SaveAsNew;
                }
             
            }
           
            SetData();
            db.St_UserPrivileges.InsertAllOnSubmit(ScreenAccessList);
            db.SubmitChanges();
            PartName = user.UserName;
            PartNumber = user.ID.ToString();
            // override tha base  Save void  
            
                if ((bool)CurrentSession.user.PrintAfterSaving && IsNew) Print();
                Master.InsertUserLog((IsNew) ? 0 : 1, this.Name, PartName, PartNumber);
                Master.Saved(IsNew, PartName, PartNumber);
                Master.RefreshAllWindows();
                ChangesMade = false;
                IsNew = false;
         

        }
        public void checkAll()
        {

        }
        public override void Print()
        {
          
        }
        public override void Delete()
        {
           // base.Delete();
        }
        private bool ValidData()
        {
           if(txt_UserName.Text .Trim() == string.Empty)
            {
                txt_UserName.ErrorText = LangResource.ErrorCantBeEmpry;
                return false; 
            }
            if (txt_Password.Text.Trim() == string.Empty)
            {
                txt_Password.ErrorText = LangResource.ErrorCantBeEmpry;
                return false;
            }
            return true;
        }

        void SetData()
        {
            user.ID = Convert.ToInt32(txt_ID.Text);
            user.UserName = txt_UserName.Text;
            user.PassWord = MyCryptography.Encrypt(txt_Password.Text);
            user.HasAccess = (byte)radioGroup_Access.SelectedIndex;
            user.AccessByTime = Convert.ToBoolean(radioGroup_AccessByTime.SelectedIndex);
            user.AccessByTimeType = Convert.ToBoolean(radioGroup_AccessByTimeType.SelectedIndex);
            user.FromTime =(DateTime?) timeEdit1.EditValue;
            user.ToTime = (DateTime?)timeEdit2.EditValue;
            // Screen Access 
           
            ScreenAccessList = new List<DAL.St_UserPrivilege>();
            foreach (DataRow  r in ScreenPrivilage .Rows)
            {
                ScreenAccessList.Add(new St_UserPrivilege()
                {
                    UserID = user.ID ,
                    PrivilageName = r["Tag"].ToString(),
                    CanAdd = (bool)r["Add"],
                    CanDelete  = (bool)r["Delete"],
                    CanEdit  = (bool)r["Edit"],
                    CanOpen  = (bool)r["Open"],
                    CanPrint  = (bool)r["Print"]  ,
                    Show = (bool)r["Show"]
                });
            }
            user.DefaultDrawer = Convert.ToInt32(lkp_DefualtDrawer.EditValue);
            user.DefaultStore = Convert.ToInt32(lkp_DefualtStore.EditValue);
            user.DefaultRawStore = Convert.ToInt32(lkp_DefualtRawStore.EditValue);
            user.WhenPrintShowMode = Convert.ToByte(radioGroup_PrintingMode.SelectedIndex);
            user.PrintAfterSaving = chk_PrintAfterSaving.Checked;
            user.CanChangeStore = chk_CanChangeDefualtStore.Checked;
            user.CanChangeDrawer = chk_CanChangeDrawer.Checked;

            user.EmployeeID = lkp_Employee.EditValue as int?;
            user.DefaultSalesRepresentative = lkp_DefaultSalesRepresentative .EditValue as int?;
            user.AccountSecrecyLevel = Convert.ToInt32(bar_AccountSecracy.EditValue);
            user.DefualtCCenter = Convert.ToInt32(tlkp_CostCenter.EditValue);
            user.CanChangeCCenter = chk_CanChangeCostCenter.Checked;
            user.CanEditInClosedPeriod = chk_CanEditInClosedPeriod.Checked;

            user.CustomersGroup = Convert.ToInt32(tlkp_MandetoryCustomerGroup.EditValue);
            user.DefaultCustomer = Convert.ToInt32(lkp_DefualtCustomer.EditValue);
            user.WhenSelllingItemHasExpired = Convert.ToByte(radioGroup_SellingExpire.SelectedIndex);
            user.SellLowerPriceThanBuy = Convert.ToByte(radioGroup_WhenSellingLessThanBuy.SelectedIndex);
            user.WhenSellingQtyNoBalance = Convert.ToByte(radioGroup_WhenSellingNoBalance.SelectedIndex);
            user.WhenSellingToMaxCreditCustomer = Convert.ToByte(radioGroup_WhenSellingClintMaxCredit.SelectedIndex);
            user.CanChangeItemPrice = chk_CanChangePrice.Checked;
            user.CanAddTotalDiscount = checkEdit_CanAddTotalDiscount.Checked;
            user.HideItemDiscount = checkEdit_HideDiscount.Checked;
            user.HideItemCost = checkEdit_HiedBuyPrice.Checked;
            user.ShowItemBalance = checkEdit_ShowItemBalance.Checked;
            user.CanSellByCredit = checkEdit_SellWithCredit.Checked;

            user.DefaultVendor = Convert.ToInt32(lkp_DefualtVendor.EditValue);
            user.WhenAddingQtyMaxBalance = radioGroup_WhenAddingMaxBalanceItem.SelectedIndex;
            user.WhenSellingQtyLessThanReorder = Convert.ToByte(radioGroup_WhenTakingMinBalanceItem.SelectedIndex);

             user.HideCostInManfOrder= chk_HideCostInManfOrder.Checked;
            user.HideItemProfitInManfOrder = chk_HideItemProfitInManfOrder.Checked;
            user.HideRawItemsInManfOrder = chk_HideRawItemsInManfOrder.Checked;
            user.CanApproveVacation = CheckEdit_CanApproveVacation.Checked;
            user.MustSelectVacationRequstInVacation = CheckEdit_MustSelectVacationRequstInVacation.Checked;
            
            user.CanPayFromSalesInvoice = CheckEdit_CanPayFromSalesInvoice.Checked;
            user.SalesInvoiceSececyLevel =(ComboBoxEdit_SalesInvoiceSececyLevel.SelectedIndex<0)? Convert.ToByte(9):Convert.ToByte( ComboBoxEdit_SalesInvoiceSececyLevel.SelectedIndex);
            user.PurchaseInvoiceSececyLevel = (ComboBoxEdit_PurchaseInvoiceSececyLevel.SelectedIndex < 0) ? Convert.ToByte(9) : Convert.ToByte(ComboBoxEdit_PurchaseInvoiceSececyLevel.SelectedIndex);
            user.CanPrintNotPaidSalesInvoice = CheckEdit_CanPrintNotPaidSalesInvoice.Checked;
            user.CanChangeSalesRepresentative = CheckEdit_CanChangeSalesRepresentative.Checked;
            user.CanApproveSalesInvoices = CheckEdit_CanApproveSalesInvoices.Checked;
        }
        #region FillData
        void GetData()
        {
            txt_ID.Text = user.ID.ToString();
            txt_UserName.Text = user.UserName;
            try
            {
                txt_Password.Text = MyCryptography.Decrypt(user.PassWord);

            }
            catch 
            {
                txt_Password.Text = "";
            }
            radioGroup_Access.Enabled = txt_UserName.Enabled =   (user.ID != 1);
           
            GetUserAccess(user);
            GetScreenAccess(user);
            GetGeneralSetting(user);
            GetAccountSetting(user);
            GetSellingSettings(user);
            GetPurchasingSetting(user);
            GeProductionSetting(user);
            GetHRSetting(user);
        }

        private void GeProductionSetting(St_User user)
        {
            chk_HideCostInManfOrder.Checked = user.HideCostInManfOrder;
            chk_HideItemProfitInManfOrder.Checked = user.HideItemProfitInManfOrder;
            chk_HideRawItemsInManfOrder.Checked = user.HideRawItemsInManfOrder;
        }
        private void GetHRSetting(St_User user)
        {
            CheckEdit_CanApproveVacation .Checked = user.CanApproveVacation;
            CheckEdit_MustSelectVacationRequstInVacation.Checked = user.MustSelectVacationRequstInVacation;
        }
        void GetUserAccess(DAL.St_User _user)
        {
            radioGroup_Access.SelectedIndex = Convert.ToInt32(_user.HasAccess);
            radioGroup_AccessByTime.SelectedIndex = Convert.ToInt32(_user.AccessByTime);
            radioGroup_AccessByTimeType.SelectedIndex = Convert.ToInt32(_user.AccessByTimeType);
            lkp_Employee.EditValue = _user.EmployeeID; 
            timeEdit1.EditValue = _user.FromTime;
            timeEdit2.EditValue = _user.ToTime; 


        }
        void GetScreenAccess(DAL.St_User _user)
        {

            foreach (var set in _user.St_UserPrivileges.ToList())
            {


                TreeListNode node = treeList1.GetNodeList().Where(x => (x.GetValue("Tag") as string) == set.PrivilageName).FirstOrDefault() as TreeListNode;

                if (node != null)
                {

                    node.SetValue("Show", set.Show) ;
                    node.SetValue("Open", set.CanOpen ) ;
                    node.SetValue("Add", set.CanAdd ) ;
                    node.SetValue("Delete", set.CanDelete ) ;
                    node.SetValue("Edit", set.CanEdit ) ;
                    node.SetValue("Print", set.CanPrint );
                }



            }

        }
        void GetGeneralSetting(DAL.St_User _user)
        {
            lkp_DefualtDrawer.EditValue = _user.DefaultDrawer;
            lkp_DefualtStore.EditValue = _user.DefaultStore;
            lkp_DefualtRawStore.EditValue = _user.DefaultRawStore;
            radioGroup_PrintingMode.SelectedIndex = _user.WhenPrintShowMode;
            chk_PrintAfterSaving.Checked = _user.PrintAfterSaving;
            chk_CanChangeDefualtStore.Checked  = _user.CanChangeStore;
            chk_CanChangeDrawer.Checked = _user.CanChangeDrawer;
        }
        void GetAccountSetting(DAL.St_User _user)
        {
            bar_AccountSecracy.EditValue = _user.AccountSecrecyLevel;
            tlkp_CostCenter.EditValue = _user.DefualtCCenter;
            chk_CanChangeCostCenter .Checked = _user.CanChangeCCenter;
            chk_CanEditInClosedPeriod.Checked = _user.CanEditInClosedPeriod; 

        }
        void GetSellingSettings(DAL.St_User _user)
        {
            tlkp_MandetoryCustomerGroup.EditValue = _user.CustomersGroup;
            lkp_DefualtCustomer.EditValue = _user.DefaultCustomer;
            lkp_DefaultSalesRepresentative.EditValue = _user.DefaultSalesRepresentative; 
            radioGroup_SellingExpire.SelectedIndex = _user.WhenSelllingItemHasExpired;
            radioGroup_WhenSellingLessThanBuy.SelectedIndex = _user.SellLowerPriceThanBuy;
            radioGroup_WhenSellingNoBalance.SelectedIndex = _user.WhenSellingQtyNoBalance;
            radioGroup_WhenSellingClintMaxCredit.SelectedIndex = _user.WhenSellingToMaxCreditCustomer;
            chk_CanChangePrice.Checked = _user.CanChangeItemPrice;
            checkEdit_CanAddTotalDiscount.Checked = _user.CanAddTotalDiscount;
            checkEdit_HideDiscount.Checked = _user.HideItemDiscount;
            checkEdit_HiedBuyPrice.Checked = _user.HideItemCost;
            checkEdit_ShowItemBalance.Checked = _user.ShowItemBalance;
            checkEdit_SellWithCredit.Checked = _user.CanSellByCredit;


            CheckEdit_CanPayFromSalesInvoice.Checked = _user.CanPayFromSalesInvoice;
            ComboBoxEdit_SalesInvoiceSececyLevel.SelectedIndex = _user.SalesInvoiceSececyLevel;
            ComboBoxEdit_PurchaseInvoiceSececyLevel.SelectedIndex = _user.PurchaseInvoiceSececyLevel;
            CheckEdit_CanPrintNotPaidSalesInvoice.Checked = _user.CanPrintNotPaidSalesInvoice;
            CheckEdit_CanChangeSalesRepresentative.Checked = _user.CanChangeSalesRepresentative;
            CheckEdit_CanApproveSalesInvoices.Checked = _user.CanApproveSalesInvoices;

        }
        void GetPurchasingSetting(DAL.St_User _user)
        {
            lkp_DefualtVendor.EditValue = _user.DefaultVendor;
            radioGroup_WhenAddingMaxBalanceItem.SelectedIndex = _user.WhenAddingQtyMaxBalance;
            radioGroup_WhenTakingMinBalanceItem.SelectedIndex = _user.WhenSellingQtyLessThanReorder;

        }
        #endregion

        private void treeList1_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Node.Id >= 0)
            {
                switch (e.Column.FieldName )
                {
                    case "Open":
                        if (e.Node.GetValue("Tag").ToString().StartsWith("TSI_"))
                            e.RepositoryItem =new RepositoryItem();
                        break;
                    case "Add":
                        if (e.Node.GetValue("Tag").ToString().StartsWith("TSI_")
                            || e.Node.GetValue("Tag").ToString().EndsWith ("List"))
                            e.RepositoryItem = new RepositoryItem();
                        break;
                    case "Edit":
                        if (e.Node.GetValue("Tag").ToString().StartsWith("TSI_") 
                            || e.Node.GetValue("Tag").ToString().EndsWith("List"))
                            e.RepositoryItem = new RepositoryItem();
                        break;
                    case "Delete":
                        if (e.Node.GetValue("Tag").ToString().StartsWith("TSI_")
                             || e.Node.GetValue("Tag").ToString().EndsWith("List"))
                            e.RepositoryItem = new RepositoryItem();
                        break;
                    case "Print":
                        if (e.Node.GetValue("Tag").ToString().StartsWith("TSI_"))
                            e.RepositoryItem = e.RepositoryItem = new RepositoryItem();
                        break;
                    default:
                        break;
                }
                

            }
       
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            treeList1.SelectAll();
        }

        private   void simpleButton1_Click(object sender, EventArgs e)
        {
           

        }
        async Task MarkScreenAccess(List<int > ls , bool check , string tag )
        {
            GUI.frm_ProgressBar frm = new GUI.frm_ProgressBar();
            frm.Show();
            await Task.Run(new Action(() =>
            {
                var max = ls.Count;
               
                int pos = 0;

                foreach (DataRow item in ScreenPrivilage.Rows)
                {
                    if (ls.Contains(item[0].ToInt()))
                    {
                        item[tag ] = check;
                        ls.Remove(item[0].ToInt());
                        if (ls.Count == 0)
                        {
                            break;
                        }
                        frm.Invoke(new Action(() => {
                            frm.Progress = pos / max * 100;
                            frm.Update();

                        }));
                        pos++;
                    }
                }


            }));
            frm.Close();

        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
           
        }

        private void simpleButton7_Resize(object sender, EventArgs e)
        {
            if (treeList1 != null && treeList1.Columns.Count > 0)
                treeList1.Columns[0].Width = layoutControlItem43.Width;

        }

        private   void simpleButton7_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void lkp_Employee_EditValueChanged(object sender, EventArgs e)
        {
            if (lkp_Employee.EditValue.ValidAsIntNonZero())
            {
                radioGroup_AccessByTimeType.Properties.Items[0].Enabled = true ;

            }
            else {
                radioGroup_AccessByTimeType.Properties.Items[0].Enabled = false;
                radioGroup_AccessByTimeType.SelectedIndex = 1;
            }


        }

        private void simpleButton7_SizeChanged(object sender, EventArgs e)
        {
            if (treeList1 != null && treeList1.Columns.Count > 0)
                treeList1.Columns["Text"].Width = layoutControlItem43.Width;

        }

        private async  void simpleButton1_Click_1(object sender, EventArgs e)
        {
            treeList1.SelectAll();
            var ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
         
            await  MarkScreenAccess(ls,true , "Show");
              ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, true, "Edit");
              ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, true, "Delete");
              ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, true, "Open");
              ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, true, "Add");
              ls  = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, true, "Print");

        }

        private async  void chkbtn_Print_CheckedChanged(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            CheckEdit btn = sender as CheckEdit;
            var ls = treeList1.Selection.Select(x => x.GetValue("ID").ToInt()).ToList();
            await MarkScreenAccess(ls, btn.Checked, btn.Tag.ToString());

        }
    }
}
