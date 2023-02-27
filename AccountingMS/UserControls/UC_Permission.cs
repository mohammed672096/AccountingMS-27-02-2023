using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using AccountingMS.Classes;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraLayout;
using System.IO;
using Newtonsoft.Json;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using static System.Resources.ResXFileRef;
using AccountingMS.Reports;

namespace AccountingMS
{
    public partial class UC_Permission : UC_Master
    {
        string TableName = "tblAccount";
        public UC_Permission()
        {
            InitializeComponent();
            bindingNavigator.BindingSource = tblAllUserControlBindingSource;
            dataLayout.ShowCustomization += DataLayoutControl1_ShowCustomization;
            dataLayout.HideCustomization += DataLayoutControl1_HideCustomization;
            treeList1.RowClick += treeList1_RowClick;
           treeList1.OptionsView.ShowColumns = false;
            myFunaction.AppearanceTreeList(treeList1);
           }
        ClsAppearance myFunaction = new ClsAppearance();
      
       
        private void treeList1_RowClick(object sender, DevExpress.XtraTreeList.RowClickEventArgs e)
        {
            if (tblAllUserControlBindingSource.Count <= 0) return;
            tblAllUserControlBindingSource.Position = e.Node.Id;
            dataLayout.Refresh();
        }
        private void DataLayoutControl1_HideCustomization(object sender, EventArgs e) => ClsPath.SaveCustomContol(this.dataLayout, TableName);
        private void DataLayoutControl1_ShowCustomization(object sender, EventArgs e) => ((DataLayoutControl)sender).CustomizationForm.Text = "تغيير التصميم";
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        tblAccount GetCurrAccount => tblAllUserControlBindingSource.Current as tblAccount;
        public static string No;
        public static string MessgTextValidNo => !MySetting.GetPrivateSetting.LangEng ? $"رقم {No} موجود من قبل !!!\n قم باختيار رقم اخر" : $"Number {No} already exists,\n choose another Number!!!";
        public override void Save()
        {
            //if (tblAllUserControlBindingSource.Current is tblAccount account && account != null)
            //{
            //    tblAllUserControlBindingSource.EndEdit();
            //    using (var db = new accountingEntities())
            //    {
            //        level = treeList1.FocusedNode.Level;
            //        if (account.accNo.ToString().StartsWith(Parent.accNo.ToString()) && account.accNo > Parent.accNo)
            //        {
            //            string mssg = $"الحساب: {account?.accName} ";
            //            if (IsNew ? db.tblAccounts.Any(x => x.accNo == account.accNo)
            //                : db.tblAccounts.Any(x => x.accNo == account.accNo && x.id != account.id))
            //            {
            //                No = mssg + account.accNo.ToString();
            //                ClsXtraMssgBox.ShowError(MessgTextValidNo);
            //                return;
            //            }
            //            account.accBrnId = account.accBrnId==null?Session.CurBranch.brnId: account.accBrnId;
            //            account.accStatus = account.accStatus == null ? 1 : account.accStatus;
            //            if (IsNew) db.tblAccounts.Add(account);
            //            else if (db.tblAccounts.Any(x => x.id == account.id))
            //            {
            //                var Baseitem = db.tblAccounts.Find(account.id);
            //                db.Entry(Baseitem).CurrentValues.SetValues(account);

            //                //tblAccount account1 = db.tblAccounts.FirstOrDefault(x => x.id == account.id);
            //                //account1.id = account.id;
            //                //account1.ParentID = account.ParentID;
            //                //account1.accBrnId = account.accBrnId;
            //                //account1.accCat = account.accCat;
            //                //account1.accCurrency = account.accCurrency;
            //                //account1.accLevel = account.accLevel;
            //                //account1.accName = account.accName;
            //                //account1.accNo = account.accNo;
            //                //account1.accStatus = account.accStatus;
            //                //account1.accType = account.accType;
            //                //account1.accParent = account.accParent;
            //            }
            //            else
            //                db.tblAccounts.Add(account);
            //            db.SaveChanges();
            //            flyDailog.ShowDialogUC(this, mssg, IsNew);
            //            RefreshData();
            //        }
            //        else
            //        {
            //            ClsXtraMssgBox.ShowWarning("عفوا رقم الحساب غير صحيح \n يجب ان يبداء رقم الحساب برقم الحساب الرئيسي");
            //            return;
            //        }
            //    }
            //    TextReadOnly(true);
            //    IsNew = false;
            //}
            
            base.Save();
        }
        DXValidationProvider dxValidationProvider = new DXValidationProvider();
        private void ValidationProvider(BaseEdit edit)
        {
            ConditionValidationRule conditionValidationRule1 = new ConditionValidationRule();
            conditionValidationRule1.ConditionOperator = ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            dxValidationProvider.SetValidationRule(edit, conditionValidationRule1);
        }
        public override void Print()
        {
            GridReportP.Print(treeList1, this.Text, layoutControlGroup2.Text);
            base.Print();   
        }
        public override void New()
        {
            //TextReadOnly(false);
            //tblAccount account = GetCurrAccount;
            //account.accType = 2;
            //account.accCurrency = Session.LocalCurrency().id;
            base.New();
        }

        public override void EnableOrDisyble(bool state)
        {
            treeList1.Enabled = state;
            if (state)
            {
                bindingNavigator.MoveFirstItem = Movefirst;
                bindingNavigator.MovePreviousItem = Moveprevious;
                bindingNavigator.MoveNextItem = Movenext;
                bindingNavigator.MoveLastItem = Movelast;
            }
            else bindingNavigator.MoveFirstItem = bindingNavigator.MovePreviousItem =
                 bindingNavigator.MoveNextItem = bindingNavigator.MoveLastItem = null;
            Movefirst.Enabled = Moveprevious.Enabled = Movenext.Enabled = Movelast.Enabled = state;
            base.EnableOrDisyble(state);
        }
        int level;
        public override void Delete()
        {
            //var us = tblAllUserControlBindingSource.Current as tblAccount;
            //if (us == null) return;
            //if (Session.Accounts.Any(x => x.accParent == us.accNo || x.ParentID == us.id))
            //{
            //    ClsXtraMssgBox.ShowWarning("عذرا لا يمكن حذف حساب رئيسي يحتوي على حسابات فرعيه");
            //    return;
            //}
            //if (ClsXtraMssgBox.ShowWarningYesNo($"هل انت متاكد من حذف الحساب {us.accName}؟") == DialogResult.Yes)
            //{
            //    //if (!new ClsTblAccount().CanDelete(us))
            //    //    return;
            //    //level = treeList1.FocusedNode.Level;
            //    //using (var dbLocal = new accountingEntities())
            //    //{
            //    //    dbLocal.tblAccounts.RemoveRange(dbLocal.tblAccounts.Where(x => x.id == us.id));
            //    //    dbLocal.SaveChanges();
                  
            //    //}
            //    RefreshData();
            //}
            base.Delete();
        }

        public override void DataUpdate()
        {
            //if (GetCurrAccount != null && GetCurrAccount.ParentID == null)
            //{
            //    ClsXtraMssgBox.ShowError("عفوا لا يمكن تعديل بيانات هذا الحساب!!!");
            //    btnReset.PerformClick();
            //    return;
            //}
            //TextReadOnly(false);
            base.DataUpdate();
        }
        public override void RefreshData()
        {
            //TextReadOnly(true);
            using (var db = new accountingEntities())
            {
                //tblAllUserControlBindingSource.DataSource = db.tblAllUserControls.ToList();
            }

            //  Session.GetDataAccounts();
            //  treeListLookUpEdit1TreeList.DataSource = (from ac in Session.Accounts
            //                                            where ac.accType == 1 select new {ID= ac.id, ac.ParentID,Number=ac.accNo, Name = ac.accNo + " - " + ac.accName }).ToList();

            //  tblAllUserControlBindingSource.DataSource = Session.Accounts.ToList();
            //  CurrencieIDTextEdit.IntializeData(Session.Currencies);
            //  AccountCategorieTextEdit.Properties.DataSource = Session.Accounts.Where(x => x.accParent == null||x.accParent==0).ToList();
            //var ex=  treeList1.Nodes.Where(x=>x.Expanded).ToList();
            //  treeList1.DataSource = (from ac in Session.Accounts select new { ID = ac.id, ac.ParentID, Number = ac.accNo, Name = ac.accNo + " - " + ac.accName }).ToList();
            //  //ex.ForEach(x=>treeList1.ExpandToLevel(x.Level));
            //  treeList1.ExpandToLevel(level);
            base.RefreshData();
        }
        public override void Reset()
        {
            RefreshData();
            base.Reset();
        }
        private void UC_Master_Load(object sender, EventArgs e)
        {
            RefreshData();
            //new ClsUserRoleValidation(this, UserControls.DefaultSettings);
        }

        private void treeList1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
