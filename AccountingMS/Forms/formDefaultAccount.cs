using AccountingMS.Classes;
using AccountingMS.Forms;
using AccountingMS.Reports;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDefaultAccount : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount=new ClsTblAccount();
        ClsTblDefaultAccount clsTblDefaultAccount = new ClsTblDefaultAccount();
        ClsAppearance clsAppearance = new ClsAppearance();
        public formDefaultAccount()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            this.Load += FormDefaultSettings_Load;
            clsAppearance.AppearanceGridView(gridView);
            clsAppearance.AppearanceGridView(gridViewTax);
            gridView.OptionsBehavior.ReadOnly = false;
            gridViewTax.OptionsBehavior.ReadOnly = false;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridViewTax.CustomColumnDisplayText += GridViewTax_CustomColumnDisplayText;
            clsAppearance.AppearanceTreeList(repositoryItemTreeListLookUpEdit1.TreeList);
            clsAppearance.AppearanceTreeList(repositoryItemTreeListLookUpEdit2.TreeList);
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == "dflStatus" && e.Value is byte stat)
                e.DisplayText = GetNameAccDefult((DefaultAccType)stat);
            if (e.Column.FieldName == "dfltBrnId" && e.Value is short b)
                e.DisplayText =new ClsTblBranch().GetBranchName(b);
        }
        private void GridViewTax_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == "taxStatus" && e.Value is byte stat)
                e.DisplayText = ((DefaultTaxAccType)stat).GetDescription();
        }
        static string GetNameAccDefult(DefaultAccType stat)
        {
            string DeAcc = !MySetting.GetPrivateSetting.LangEng ? "الحساب الإفتراضي " : " Default Account";
            if (MySetting.GetPrivateSetting.LangEng)
                return stat.GetDescription() + DeAcc;
            switch (stat)
            {
                case DefaultAccType.Customer:
                    return DeAcc += "للعملاء";
                case DefaultAccType.Supplier:
                    return DeAcc += "للموردين";
                case DefaultAccType.Box:
                    return DeAcc += "للصناديق";
                case DefaultAccType.Bank:
                    return DeAcc += "للبنوك";
                case DefaultAccType.Employee:
                    return DeAcc += "للموظفين";
                case DefaultAccType.GrpAcc:
                    return DeAcc += "للمخزون";
                case DefaultAccType.GrpAccSale:
                    return DeAcc += "للمبيعات";
                case DefaultAccType.GrpAccSaleCost:
                    return DeAcc += "لتكلفة المبيعات - جرد مستمر";
                case DefaultAccType.GrpAccSaleRtrn:
                    return DeAcc += "لمردود المبيعات";
                case DefaultAccType.GrpAccSaleRtrnCost:
                    return DeAcc += "لتكلفة مردود المبيعات - جرد مستمر";
                case DefaultAccType.GrpAccDiscount:
                    return DeAcc += "للخصم المسموح به";
                case DefaultAccType.GrpAccPurchase:
                    return DeAcc += "للمشتريات - جرد دوري";
                case DefaultAccType.GrpAccPurchaseRtrn:
                    return DeAcc += "لمردود المشتريات - جرد دوري";
                case DefaultAccType.PrdExpirateAcc:
                    return DeAcc += "للمخزون التالف";
                case DefaultAccType.Representative:
                    return DeAcc += "للمناديب";
                default:return "";
            }
        }
     
        private void FormDefaultSettings_Load(object sender, EventArgs e)
        {
            InitData();
        }
      
        public List<ValueAndID> DefaultAccTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)DefaultAccType.Bank, Name  =GetNameAccDefult(DefaultAccType.Bank) },
                new ValueAndID() { ID = (byte)DefaultAccType.Box, Name  =GetNameAccDefult(DefaultAccType.Box) },
                new ValueAndID() { ID = (byte)DefaultAccType.Customer, Name  =GetNameAccDefult(DefaultAccType.Customer) },
                new ValueAndID() { ID = (byte)DefaultAccType.Supplier, Name  =GetNameAccDefult(DefaultAccType.Supplier) },
                new ValueAndID() { ID = (byte)DefaultAccType.Employee, Name  =GetNameAccDefult(DefaultAccType.Employee) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAcc, Name  =GetNameAccDefult(DefaultAccType.GrpAcc) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccDiscount, Name  =GetNameAccDefult(DefaultAccType.GrpAccDiscount) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccPurchase, Name  =GetNameAccDefult(DefaultAccType.GrpAccPurchase) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccPurchaseRtrn, Name  =GetNameAccDefult(DefaultAccType.GrpAccPurchaseRtrn) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccSale, Name  =GetNameAccDefult(DefaultAccType.GrpAccSale) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccSaleCost, Name  =GetNameAccDefult(DefaultAccType.GrpAccSaleCost) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccSaleRtrn, Name  =GetNameAccDefult(DefaultAccType.GrpAccSaleRtrn) },
                new ValueAndID() { ID = (byte)DefaultAccType.GrpAccSaleRtrnCost, Name  =GetNameAccDefult(DefaultAccType.GrpAccSaleRtrnCost) },
                new ValueAndID() { ID = (byte)DefaultAccType.PrdExpirateAcc, Name  =GetNameAccDefult(DefaultAccType.PrdExpirateAcc) },
                new ValueAndID() { ID = (byte)DefaultAccType.Representative, Name  =GetNameAccDefult(DefaultAccType.Representative) },
               };


        private void InitData()
        {
            List<tblDefaultAccount> list = new List<tblDefaultAccount>();
            ClsStopWatch stopWatch = new ClsStopWatch();
            if (MySetting.DefaultSetting.InvType)
            {
                list = clsTblDefaultAccount.GetTblDefaultAccountsList.Where(x => x.dflStatus != 14 && x.dflStatus != 15).ToList();
                DefaultAccTypeList.Where(x => x.ID != 14 && x.ID != 15).ToList().ForEach(y => {
                    if (!list.Any(x => x.dflStatus == y.ID))
                        list.Add(new tblDefaultAccount { dflStatus = y.ID, dfltBrnId = Session.CurBranch.brnId, dflAccNo = 0 });
                });
                tblDefaultAccountBindingSource.DataSource = list.OrderBy(x => x.dflStatus);
            }
            else
            {
                list = clsTblDefaultAccount.GetTblDefaultAccountsList.Where(x => x.dflStatus != 8 && x.dflStatus != 10).ToList();
                DefaultAccTypeList.Where(x => x.ID != 8 && x.ID != 10).ToList().ForEach(y => {
                    if (!list.Any(x => x.dflStatus == y.ID))
                        list.Add(new tblDefaultAccount { dflStatus = y.ID, dfltBrnId = Session.CurBranch.brnId, dflAccNo = 0 });
                });
                tblDefaultAccountBindingSource.DataSource = list.OrderBy(x => x.dflStatus);
            }
            tblTaxAccountBindingSource.DataSource = ClsTblDefaultAccount.tbTaxAccountList.OrderBy(x=>x.taxStatus);
            repositoryItemTreeListLookUpEdit1.DataSource =(from a in clsTbAccount.GetAccountList
                 where a.accType == 1 && (a.accParent != null || a.accNo <= 4)
                 select new
                 {
                     ID = a.id,
                     ParentID = this.clsTbAccount.GetAccountList.FirstOrDefault(x => x.accNo == a.accParent)?.id,
                     Name = a.accNo + " - " + a.accName,
                 }).ToList();
            repositoryItemTreeListLookUpEdit2.DataSource = (from a in clsTbAccount.GetAccountList select new {ID = a.id,
            ParentID = this.clsTbAccount.GetAccountList.FirstOrDefault(x => x.accNo == a.accParent)?.id, Name = a.accNo + " - " + a.accName,No=a.accNo }).ToList();
            stopWatch.Stop();
        }
      
        private void SaveData()
        {
            using (var db = new accountingEntities())
            {
                var DefaultAccount = tblDefaultAccountBindingSource.List as IList<tblDefaultAccount>;
                DefaultAccount.ToList().ForEach(x =>
                {
                    if (db.tblDefaultAccounts.Any(y => y.dflId == x.dflId))
                        db.tblDefaultAccounts.FirstOrDefault(y => y.dflId == x.dflId).dflAccNo = x.dflAccNo;
                    else db.tblDefaultAccounts.Add(x);
                });
                var DefaultTaxAccount = tblTaxAccountBindingSource.List as IList<tblTaxAccount>;
                DefaultTaxAccount.ToList().ForEach(x =>
                {
                    if (db.tblTaxAccounts.Any(y => y.taxId == x.taxId))
                    {
                        db.tblTaxAccounts.FirstOrDefault(y => y.taxId == x.taxId).taxAccNo = x.taxAccNo;
                        db.tblTaxAccounts.FirstOrDefault(y => y.taxId == x.taxId).taxAccName = clsTbAccount.GetAccountNameByNo(x.taxAccNo ?? 0);
                    }
                    else db.tblTaxAccounts.Add(x);
                });
                if (db.SaveChanges() > 0)
                    ShowSaveMssg();
                MySetting.DefaultSetting = db.tblSettings?.FirstOrDefault(x => x.MachineName == Environment.MachineName);
            }
        }
     
        private void ShowSaveMssg()
        {
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "الحسابات الإفتراضيه" : "Default Accounts";
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
        }
  
        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            dataLayoutControl4.BeginUpdate();
            dataLayoutControl4.RightToLeft = RightToLeft.No;
            dataLayoutControl4.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl4.EndUpdate();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
            this.Close();
        }
    }
}