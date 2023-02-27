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
using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraReports.UserDesigner;

namespace ERP.Forms
{
    public partial class frm_SystemSettings : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        St_CompanyInfo companyinfo;
        public frm_SystemSettings()
        {
            InitializeComponent();
            this.Load += frm_Load;
            this.FormClosing += frm_Master_FormClosing;
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            companyinfo = db.St_CompanyInfos.First();
            AccountLookUpEditslist = new List<LookUpEdit>(){
            LookUpEdit_EmployeesDueAccount,
            LookUpEdit_WagesAccount,
            LookUpEdit_DueSalerysAccount,
            LookUpEdit_DrawerAccount,
            LookUpEdit_BanksAccount,
            LookUpEdit_CustomersAccount,
            LookUpEdit_NotesReceivableAccount,
            LookUpEdit_InventoryAccount,
            LookUpEdit_VendorsAccount,
            LookUpEdit_CapitalAccount,
            LookUpEdit_NotesPayableAccount,
            LookUpEdit_TaxAccount,
            LookUpEdit_ManufacturingExpAccount,
            LookUpEdit_MerchandisingAccount,
            LookUpEdit_PurchasesAccount,
            LookUpEdit_PurchasesReturnAccount,
            LookUpEdit_SalesAccount,
            LookUpEdit_SalesReturnAccount,
            LookUpEdit_OpenInventoryAccount,
            LookUpEdit_CloseInventoryAccount,
            LookUpEdit_PurchaseDiscountAccount,
            LookUpEdit_SalesDiscountAccount,
            LookUpEdit_FixedAssetsAccount,
            LookUpEdit_SalesDeductTaxAccount,
            LookUpEdit_PurchaseDeductTaxAccount,
            LookUpEdit_DebitNoteAccount,
            LookUpEdit_CostOfSoldGoodsAccount,
            LookUpEdit_DepreciationAccount,
            LookUpEdit_ExpensesAccount,
            LookUpEdit_RevenueAccount,
            LookUpEdit_PurchaseAddTaxAccount,
            LookUpEdit_SalesAddTaxAccount,
            LookUpEdit_RecieveNotesUnderCollectAccount,
            LookUpEdit_CreditNoteAccount,
        };
            RefreshData();
            RunUserPrivilage();

        }
        internal bool CanEdit;

        public bool ChangesMade { get; private set; }
        public bool ProssingKey { get; private set; }

        public Boolean CanSave()
        {


            return (CanEdit || Forms.MAIN.frm_RequestAdminAccess.RequestPremission(this.Name + "_Edit"));
          
        }
        public virtual void RunUserPrivilage()
        {

            if (CurrentSession.user.HasAccess == 0)
            {
                CanEdit  = true;
                return;
            }

              CanEdit = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanEdit).FirstOrDefault();
          
        }
        private bool ValidData()
        {

            if (RaidoEdit_MoneyToTextMode.SelectedIndex  < 0 )
            {
                RaidoEdit_MoneyToTextMode.ErrorText = LangResource.ErrorCantBeEmpry;
                RaidoEdit_MoneyToTextMode.Focus();
                return false;
            }
             if (CheckEdit_DoPeriodicBackup.SelectedIndex < 0)
             {
                 CheckEdit_DoPeriodicBackup.ErrorText = LangResource.ErrorCantBeEmpry;
                 CheckEdit_DoPeriodicBackup.Focus();
                 return false;
             }
             if (CheckEdit_DoPeriodicBackup.SelectedIndex == 1 && (TextEdit_BackupPath.Text  == null || String.IsNullOrEmpty(TextEdit_BackupPath.Text) ))
             {
                 TextEdit_BackupPath.ErrorText = LangResource.ErrorCantBeEmpry;
                 TextEdit_BackupPath.Focus();
                 return false;
             }
             if (RadioGroup_StockIsPeriodic.SelectedIndex < 0)
            {
                 RadioGroup_StockIsPeriodic.ErrorText = LangResource.ErrorCantBeEmpry;
                 RadioGroup_StockIsPeriodic.Focus();
                 return false;
             }
            // if (CheckEdit_ReleaseProductWithoutQMSAprove.EditValue == null || String.IsNullOrEmpty(CheckEdit_ReleaseProductWithoutQMSAprove.Text))
            // {
            //     CheckEdit_ReleaseProductWithoutQMSAprove.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_ReleaseProductWithoutQMSAprove.Focus();
            //     return false;
            // }
            // if (CheckEdit_ApproveQMFormWithoutVal.EditValue == null || String.IsNullOrEmpty(CheckEdit_ApproveQMFormWithoutVal.Text))
            // {
            //     CheckEdit_ApproveQMFormWithoutVal.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_ApproveQMFormWithoutVal.Focus();
            //     return false;
            // }
            // 
            // if (CheckEdit_SellRawMaterial.EditValue == null || String.IsNullOrEmpty(CheckEdit_SellRawMaterial.Text))
            // {
            //     CheckEdit_SellRawMaterial.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_SellRawMaterial.Focus();
            //     return false;
            // }
            // if (CheckEdit_BuyAssembly.EditValue == null || String.IsNullOrEmpty(CheckEdit_BuyAssembly.Text))
            // {
            //     CheckEdit_BuyAssembly.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_BuyAssembly.Focus();
            //     return false;
            // }
            // if (CheckEdit_AutoSerialForAssembly.EditValue == null || String.IsNullOrEmpty(CheckEdit_AutoSerialForAssembly.Text))
            // {
            //     CheckEdit_AutoSerialForAssembly.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_AutoSerialForAssembly.Focus();
            //     return false;
            // }
            // if (TextEdit_PrimaryReportingFolderName.EditValue == null || String.IsNullOrEmpty(TextEdit_PrimaryReportingFolderName.Text))
            // {
            //     TextEdit_PrimaryReportingFolderName.ErrorText = LangResource.ErrorCantBeEmpry;
            //     TextEdit_PrimaryReportingFolderName.Focus();
            //     return false;
            // }
            // if (TextEdit_SecondaryReportingPath.EditValue == null || String.IsNullOrEmpty(TextEdit_SecondaryReportingPath.Text))
            // {
            //     TextEdit_SecondaryReportingPath.ErrorText = LangResource.ErrorCantBeEmpry;
            //     TextEdit_SecondaryReportingPath.Focus();
            //     return false;
            // }


            if (LookUpEdit_EmployeesDueAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup15.Expanded = true;
                LookUpEdit_EmployeesDueAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_EmployeesDueAccount.Focus();
                return false;
            }
            if (LookUpEdit_WagesAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup15.Expanded = true;
                LookUpEdit_WagesAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_WagesAccount.Focus();
                return false;
            }
            if (LookUpEdit_DueSalerysAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup15.Expanded = true;
                LookUpEdit_DueSalerysAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_DueSalerysAccount.Focus();
                return false;
            }
            if (LookUpEdit_DrawerAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_DrawerAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_DrawerAccount.Focus();
                return false;
            }
            if (LookUpEdit_BanksAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_BanksAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_BanksAccount.Focus();
                return false;
            }
            if (LookUpEdit_CustomersAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_CustomersAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CustomersAccount.Focus();
                return false;
            }
            if (LookUpEdit_NotesReceivableAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_NotesReceivableAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_NotesReceivableAccount.Focus();
                return false;
            }
            if (LookUpEdit_InventoryAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_InventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_InventoryAccount.Focus();
                return false;
            }
            if (LookUpEdit_VendorsAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup14.Expanded = true;
                LookUpEdit_VendorsAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_VendorsAccount.Focus();
                return false;
            }
            if (LookUpEdit_CapitalAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup14.Expanded = true;
                LookUpEdit_CapitalAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CapitalAccount.Focus();
                return false;
            }
            if (LookUpEdit_NotesPayableAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup14.Expanded = true;
                LookUpEdit_NotesPayableAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_NotesPayableAccount.Focus();
                return false;
            }
            if (LookUpEdit_TaxAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup8.Expanded = true;
                LookUpEdit_TaxAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_TaxAccount.Focus();
                return false;
            }
            if (LookUpEdit_ManufacturingExpAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup13.Expanded = true;
                LookUpEdit_ManufacturingExpAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_ManufacturingExpAccount.Focus();
                return false;
            }
            if (LookUpEdit_MerchandisingAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_MerchandisingAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_MerchandisingAccount.Focus();
                return false;
            }
            if (LookUpEdit_PurchasesAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_PurchasesAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_PurchasesAccount.Focus();
                return false;
            }
            if (LookUpEdit_PurchasesReturnAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_PurchasesReturnAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_PurchasesReturnAccount.Focus();
                return false;
            }
            if (LookUpEdit_SalesAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_SalesAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_SalesAccount.Focus();
                return false;
            }
            if (LookUpEdit_SalesReturnAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_SalesReturnAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_SalesReturnAccount.Focus();
                return false;
            }
            if (LookUpEdit_OpenInventoryAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_OpenInventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_OpenInventoryAccount.Focus();
                return false;
            }
            if (LookUpEdit_CloseInventoryAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_CloseInventoryAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CloseInventoryAccount.Focus();
                return false;
            }
            if (LookUpEdit_PurchaseDiscountAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_PurchaseDiscountAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_PurchaseDiscountAccount.Focus();
                return false;
            }
            if (LookUpEdit_SalesDiscountAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_SalesDiscountAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_SalesDiscountAccount.Focus();
                return false;
            }
            if (LookUpEdit_FixedAssetsAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_FixedAssetsAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_FixedAssetsAccount.Focus();
                return false;
            }
            if (LookUpEdit_SalesDeductTaxAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup8.Expanded = true;
                LookUpEdit_SalesDeductTaxAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_SalesDeductTaxAccount.Focus();
                return false;
            }
            if (LookUpEdit_PurchaseDeductTaxAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup8.Expanded = true;
                LookUpEdit_PurchaseDeductTaxAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_PurchaseDeductTaxAccount.Focus();
                return false;
            }
            if (LookUpEdit_DebitNoteAccount.EditValue.IsNumber() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup12.Expanded = true;
                LookUpEdit_DebitNoteAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_DebitNoteAccount.Focus();
                return false;
            }
            if (LookUpEdit_CostOfSoldGoodsAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup10.Expanded = true;
                LookUpEdit_CostOfSoldGoodsAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CostOfSoldGoodsAccount.Focus();
                return false;
            }

            if (LookUpEdit_DepreciationAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup14.Expanded = true;
                LookUpEdit_DepreciationAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_DepreciationAccount.Focus();
                return false;
            }
            if (LookUpEdit_ExpensesAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup11.Expanded = true;
                LookUpEdit_ExpensesAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_ExpensesAccount.Focus();
                return false;
            }
            if (LookUpEdit_RevenueAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup11.Expanded = true;
                LookUpEdit_RevenueAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_RevenueAccount.Focus();
                return false;
            }
            if (LookUpEdit_PurchaseAddTaxAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup8.Expanded = true;
                LookUpEdit_PurchaseAddTaxAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_PurchaseAddTaxAccount.Focus();
                return false;
            }
            if (LookUpEdit_SalesAddTaxAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup8.Expanded = true;
                LookUpEdit_SalesAddTaxAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_SalesAddTaxAccount.Focus();
                return false;
            }
            if (LookUpEdit_RecieveNotesUnderCollectAccount.EditValue.ValidAsIntNonZero() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup9.Expanded = true;
                LookUpEdit_RecieveNotesUnderCollectAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_RecieveNotesUnderCollectAccount.Focus();
                return false;
            }
            if (LookUpEdit_CreditNoteAccount.EditValue.IsNumber() == false)
            {
                tabbedControlGroup1.SelectedTabPage = Tab_Accounts; layoutControlGroup12.Expanded = true;
                LookUpEdit_CreditNoteAccount.ErrorText = LangResource.ErrorCantBeEmpry;
                LookUpEdit_CreditNoteAccount.Focus();
                return false;
            }
            // if (CheckEdit_PurchaseAutoSerialBatch.EditValue == null || String.IsNullOrEmpty(CheckEdit_PurchaseAutoSerialBatch.Text))
            // {
            //     CheckEdit_PurchaseAutoSerialBatch.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_PurchaseAutoSerialBatch.Focus();
            //     return false;
            // }
            // if (CheckEdit_PriceIncludeSalesTax.EditValue == null || String.IsNullOrEmpty(CheckEdit_PriceIncludeSalesTax.Text))
            // {
            //     CheckEdit_PriceIncludeSalesTax.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_PriceIncludeSalesTax.Focus();
            //     return false;
            // }
            // if (RadioGroup_PrInvoiceWorkflow.EditValue == null || String.IsNullOrEmpty(RadioGroup_PrInvoiceWorkflow.Text))
            // {
            //     RadioGroup_PrInvoiceWorkflow.ErrorText = LangResource.ErrorCantBeEmpry;
            //     RadioGroup_PrInvoiceWorkflow.Focus();
            //     return false;
            // }
            // if (CheckEdit_PriceIncludePurchaseTax.EditValue == null || String.IsNullOrEmpty(CheckEdit_PriceIncludePurchaseTax.Text))
            // {
            //     CheckEdit_PriceIncludePurchaseTax.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_PriceIncludePurchaseTax.Focus();
            //     return false;
            // }
            // if (CheckEdit_CalcPurchaseTaxPerItem.EditValue == null || String.IsNullOrEmpty(CheckEdit_CalcPurchaseTaxPerItem.Text))
            // {
            //     CheckEdit_CalcPurchaseTaxPerItem.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_CalcPurchaseTaxPerItem.Focus();
            //     return false;
            // }
            // if (CheckEdit_InvoicesCodeRedundancy.EditValue == null || String.IsNullOrEmpty(CheckEdit_InvoicesCodeRedundancy.Text))
            // {
            //     CheckEdit_InvoicesCodeRedundancy.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_InvoicesCodeRedundancy.Focus();
            //     return false;
            // }
            // if (CheckEdit_SalesOrderReserveGood.EditValue == null || String.IsNullOrEmpty(CheckEdit_SalesOrderReserveGood.Text))
            // {
            //     CheckEdit_SalesOrderReserveGood.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_SalesOrderReserveGood.Focus();
            //     return false;
            // }
            // if (RadioGroup_InvoiceWorkflow.EditValue == null || String.IsNullOrEmpty(RadioGroup_InvoiceWorkflow.Text))
            // {
            //     RadioGroup_InvoiceWorkflow.ErrorText = LangResource.ErrorCantBeEmpry;
            //     RadioGroup_InvoiceWorkflow.Focus();
            //     return false;
            // }
            // if (CheckEdit_PrintBarcodePerInventory.EditValue == null || String.IsNullOrEmpty(CheckEdit_PrintBarcodePerInventory.Text))
            // {
            //     CheckEdit_PrintBarcodePerInventory.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_PrintBarcodePerInventory.Focus();
            //     return false;
            // }
      

            // if (CheckEdit_FpDependOnInOut.EditValue == null || String.IsNullOrEmpty(CheckEdit_FpDependOnInOut.Text))
            // {
            //     CheckEdit_FpDependOnInOut.ErrorText = LangResource.ErrorCantBeEmpry;
            //     CheckEdit_FpDependOnInOut.Focus();
            //     return false;
            // }
            return true;
        }
        public void frm_Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesMade && !SaveChangedData()) e.Cancel = true;

        }
        public bool SaveChangedData()
        {
            switch (Master.AskForSaving())
            {

                case DialogResult.Cancel: return false;
                case DialogResult.Yes: Save(); return true;
                case DialogResult.No: return true;
                default: return false;


            }
        }
        public virtual void frm_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (ProssingKey) return;
            ProssingKey = true;
        
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {

                Save();

            }
         
            
       
            ProssingKey = false;
        }
        internal virtual void DataChanged(object sender, EventArgs e)
        {
            ChangesMade = true;

        }
        public  void Save()
        {
            if (CanSave() == false) return;
            if (!ValidData()) { return; }

            ERPDataContext db = new ERPDataContext(Program.setting.con);
            companyinfo = db.St_CompanyInfos.Where(s => s.ID == companyinfo.ID).First();
            SetData();
            db.SubmitChanges();
            Program.setting.CasherPrinter = ComboBoxEdit_CasherPrinter.Text;
            Program.setting.DefaultPrinter = ComboBoxEdit_DefaultPrinter.Text;
            Program.setting.TempletPath = TextEdit_TempletPath.Text;
            Program.setting.PrintPayBillOnSave = ToggleSwitch_PrintPayBillOnSave.IsOn;
            Program.setting.PrintItemWithdrawBillOnSave = ToggleSwitch_PrintItemWithdrawBillOnSave.IsOn;
            Master.InsertUserLog( 0 , this.Name, "", "");
            Master.Saved(false , "", "");
            Master.RefreshAllWindows();
        }
        
        void SetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            companyinfo.DoPeriodicBackup =Convert.ToBoolean( CheckEdit_DoPeriodicBackup.SelectedIndex);
            companyinfo.BackupPath = TextEdit_BackupPath.Text ;
            companyinfo.StockIsPeriodic = Convert.ToBoolean(RadioGroup_StockIsPeriodic.SelectedIndex);
            companyinfo.MoneyToTextMode = Convert.ToBoolean(RaidoEdit_MoneyToTextMode.SelectedIndex);



            //companyinfo.ReleaseProductWithoutQMSAprove = CheckEdit_ReleaseProductWithoutQMSAprove.EditValue;
            //companyinfo.ApproveQMFormWithoutVal = CheckEdit_ApproveQMFormWithoutVal.EditValue;
            //companyinfo.SellRawMaterial = CheckEdit_SellRawMaterial.EditValue;
            //companyinfo.BuyAssembly = CheckEdit_BuyAssembly.EditValue;
            //companyinfo.AutoSerialForAssembly = CheckEdit_AutoSerialForAssembly.EditValue;
            //companyinfo.PrimaryReportingFolderName = TextEdit_PrimaryReportingFolderName.EditValue;
            //companyinfo.SecondaryReportingPath = TextEdit_SecondaryReportingPath.EditValue;
            
            
            companyinfo.EmployeesDueAccount =Convert.ToInt32( LookUpEdit_EmployeesDueAccount.EditValue);
            companyinfo.WagesAccount =Convert.ToInt32( LookUpEdit_WagesAccount.EditValue);
            companyinfo.DueSalerysAccount =Convert.ToInt32( LookUpEdit_DueSalerysAccount.EditValue);
            companyinfo.DrawerAccount =Convert.ToInt32( LookUpEdit_DrawerAccount.EditValue);
            companyinfo.BanksAccount =Convert.ToInt32( LookUpEdit_BanksAccount.EditValue);
            companyinfo.CustomersAccount =Convert.ToInt32( LookUpEdit_CustomersAccount.EditValue);
            companyinfo.NotesReceivableAccount =Convert.ToInt32( LookUpEdit_NotesReceivableAccount.EditValue);
            companyinfo.InventoryAccount =Convert.ToInt32( LookUpEdit_InventoryAccount.EditValue);
            companyinfo.VendorsAccount =Convert.ToInt32( LookUpEdit_VendorsAccount.EditValue);
            companyinfo.CapitalAccount =Convert.ToInt32( LookUpEdit_CapitalAccount.EditValue);
            companyinfo.NotesPayableAccount =Convert.ToInt32( LookUpEdit_NotesPayableAccount.EditValue);
            companyinfo.TaxAccount =Convert.ToInt32( LookUpEdit_TaxAccount.EditValue);
            companyinfo.ManufacturingExpAccount =Convert.ToInt32( LookUpEdit_ManufacturingExpAccount.EditValue);
            companyinfo.MerchandisingAccount =Convert.ToInt32( LookUpEdit_MerchandisingAccount.EditValue);
            companyinfo.PurchasesAccount =Convert.ToInt32( LookUpEdit_PurchasesAccount.EditValue);
            companyinfo.PurchasesReturnAccount =Convert.ToInt32( LookUpEdit_PurchasesReturnAccount.EditValue);
            companyinfo.SalesAccount =Convert.ToInt32( LookUpEdit_SalesAccount.EditValue);
            companyinfo.SalesReturnAccount =Convert.ToInt32( LookUpEdit_SalesReturnAccount.EditValue);
            companyinfo.OpenInventoryAccount =Convert.ToInt32( LookUpEdit_OpenInventoryAccount.EditValue);
            companyinfo.CloseInventoryAccount =Convert.ToInt32( LookUpEdit_CloseInventoryAccount.EditValue);
            companyinfo.PurchaseDiscountAccount =Convert.ToInt32( LookUpEdit_PurchaseDiscountAccount.EditValue);
            companyinfo.SalesDiscountAccount =Convert.ToInt32( LookUpEdit_SalesDiscountAccount.EditValue);
            companyinfo.FixedAssetsAccount =Convert.ToInt32( LookUpEdit_FixedAssetsAccount.EditValue);
            companyinfo.SalesDeductTaxAccount =Convert.ToInt32( LookUpEdit_SalesDeductTaxAccount.EditValue);
            companyinfo.PurchaseDeductTaxAccount =Convert.ToInt32( LookUpEdit_PurchaseDeductTaxAccount.EditValue);
            companyinfo.DebitNoteAccount =Convert.ToInt32( LookUpEdit_DebitNoteAccount.EditValue);
            companyinfo.CostOfSoldGoodsAccount =Convert.ToInt32( LookUpEdit_CostOfSoldGoodsAccount.EditValue);
            companyinfo.DepreciationAccount =Convert.ToInt32( LookUpEdit_DepreciationAccount.EditValue);
            companyinfo.ExpensesAccount =Convert.ToInt32( LookUpEdit_ExpensesAccount.EditValue);
            companyinfo.RevenueAccount =Convert.ToInt32( LookUpEdit_RevenueAccount.EditValue);
            companyinfo.PurchaseAddTaxAccount =Convert.ToInt32( LookUpEdit_PurchaseAddTaxAccount.EditValue);
            companyinfo.SalesAddTaxAccount =Convert.ToInt32( LookUpEdit_SalesAddTaxAccount.EditValue);
            
            
            //companyinfo.RecieveNotesUnderCollectAccount = LookUpEdit_RecieveNotesUnderCollectAccount.EditValue;
            //companyinfo.CreditNoteAccount = LookUpEdit_CreditNoteAccount.EditValue;
            //companyinfo.PurchaseAutoSerialBatch = CheckEdit_PurchaseAutoSerialBatch.EditValue;
            //companyinfo.PriceIncludeSalesTax = CheckEdit_PriceIncludeSalesTax.EditValue;
            //companyinfo.PrInvoiceWorkflow = RadioGroup_PrInvoiceWorkflow.EditValue;
            //companyinfo.PriceIncludePurchaseTax = CheckEdit_PriceIncludePurchaseTax.EditValue;
            //companyinfo.CalcPurchaseTaxPerItem = CheckEdit_CalcPurchaseTaxPerItem.EditValue;
            //companyinfo.InvoicesCodeRedundancy = CheckEdit_InvoicesCodeRedundancy.EditValue;
            //companyinfo.SalesOrderReserveGood = CheckEdit_SalesOrderReserveGood.EditValue;
            //companyinfo.InvoiceWorkflow = RadioGroup_InvoiceWorkflow.EditValue;
            //companyinfo.PrintBarcodePerInventory = CheckEdit_PrintBarcodePerInventory.EditValue;
            companyinfo.BarcodeItemCodeLength = SpinEdit_BarcodeItemCodeLength.EditValue.ToInt();
            companyinfo.BarcodeQtyLength = SpinEdit_BarcodeQtyLength.EditValue.ToInt();

            //companyinfo.FpDependOnInOut = CheckEdit_FpDependOnInOut.EditValue;
        }

        List<LookUpEdit> AccountLookUpEditslist;
      
        public void RefreshData()
        {
            ERPDataContext db = new ERPDataContext(Program.setting.con);
            var accounts = db.Acc_Accounts.Select(x => new
            {
                x.ID,
                x.Number,
                x.Name,
                ParentAccount = db.Acc_Accounts.Where(p => p.ID == x.ParentID).SingleOrDefault().Name
            }).ToList();
          
            AccountLookUpEditslist.ToList().ForEach(a =>
            {
                a.Properties.DataSource = accounts;
                a.Properties.ValueMember = "ID";
                a.Properties.DisplayMember = "Name";
                a.Properties.Buttons.Clear();
                a.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown ),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus )
                });
                a.Properties.ActionButtonIndex = 0;
                a.ButtonClick -= A_ButtonClick;
                a.ButtonClick += A_ButtonClick;
                
            });

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ComboBoxEdit_CasherPrinter.Properties.Items.Add(printer);
                ComboBoxEdit_DefaultPrinter.Properties.Items.Add(printer);
            }
            DataTable ReportsDT = new DataTable();
            ReportsDT.Columns.Add("ReportName", typeof(string));
            ReportsDT.Columns.Add("ReportCaption", typeof(string));
            ReportsDT.Rows.Add("rpt_GridReport", LangResource.GridReport);
            ReportsDT.Rows.Add("rpt_Inv_OpenBalance", LangResource.OpenBalance);
            ReportsDT.Rows.Add("rpt_Inv_ItemDamage", LangResource.ItemDamage);
            ReportsDT.Rows.Add("rpt_Inv_ItemAdd", LangResource.ItemAdd);
            ReportsDT.Rows.Add("rpt_Inv_ItemStoreMove", LangResource.ItemStoreMove);
            ReportsDT.Rows.Add("rpt_Inv_Invoice", LangResource.SalesInvoice);

            ReportsDT.Rows.Add("rpt_Sl_Requst", LangResource.SalesRequest);
            ReportsDT.Rows.Add("rpt_Sl_Order", LangResource.SalesOrder);
            ReportsDT.Rows.Add("rpt_Inv_InvoiceItemTakeBill", LangResource.ItemWithDrawOrder);
            ReportsDT.Rows.Add("rpt_Inv_InvoicePayBill", LangResource.InvoicePayBill);
            ReportsDT.Rows.Add("rpt_Sl_SlReturnInvoice", LangResource.SalesReturnInvoice);
            ReportsDT.Rows.Add("rpt_Pr_PrInvoice", LangResource.PurchaseInvoice);
            ReportsDT.Rows.Add("rpt_Pr_Requst", LangResource.PurchaseRequest);
            ReportsDT.Rows.Add("rpt_Pr_Order", LangResource.PurchaseOrder);
            ReportsDT.Rows.Add("rpt_Pr_PrInvoiceItemAddBill", LangResource.ItemAddOrder);
            ReportsDT.Rows.Add("rpt_Pr_PrInvoicePayBill", LangResource.InvoiceReciveBill);
            ReportsDT.Rows.Add("rpt_Pr_PrReturnInvoice", LangResource.PurchaseReturnInvoice);


            LookUpEdit_Reports.Properties.DataSource = ReportsDT;
            LookUpEdit_Reports.Properties.ValueMember = "ReportName";
            LookUpEdit_Reports.Properties.DisplayMember = "ReportCaption";
            LookUpEdit_Reports.Properties.PopulateColumns();

        }

        private void A_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //
        }

        public   void frm_Load(object sender, EventArgs e)
        {
            
            layoutControl1.AllowCustomization = false;
            accordionControl1_ElementClick(accordionControl1, new DevExpress.XtraBars.Navigation.ElementClickEventArgs(accordionControlElement1));
            tabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False ;
            RadioGroup_StockIsPeriodic.Properties.Items.AddRange(new string[] { LangResource.Continuous, LangResource.Periodic });
            RaidoEdit_MoneyToTextMode.Properties.Items.AddRange(new string[] {LangResource.RightToLeftArabic, LangResource.LeftToRightForgin  });
            CheckEdit_DoPeriodicBackup.Properties.Items.AddRange(new string[] { LangResource.No, LangResource.Yes });


           
            
           
             
            GetData();



            #region DataChanged


            CheckEdit_ReleaseProductWithoutQMSAprove.EditValueChanged += DataChanged;
            CheckEdit_ApproveQMFormWithoutVal.EditValueChanged += DataChanged;
            RaidoEdit_MoneyToTextMode.EditValueChanged += DataChanged;
            CheckEdit_SellRawMaterial.EditValueChanged += DataChanged;
            CheckEdit_BuyAssembly.EditValueChanged += DataChanged;
            CheckEdit_AutoSerialForAssembly.EditValueChanged += DataChanged;
            TextEdit_PrimaryReportingFolderName.EditValueChanged += DataChanged;
            TextEdit_SecondaryReportingPath.EditValueChanged += DataChanged;
            LookUpEdit_EmployeesDueAccount.EditValueChanged += DataChanged;
            LookUpEdit_WagesAccount.EditValueChanged += DataChanged;
            LookUpEdit_DueSalerysAccount.EditValueChanged += DataChanged;
            LookUpEdit_DrawerAccount.EditValueChanged += DataChanged;
            LookUpEdit_BanksAccount.EditValueChanged += DataChanged;
            LookUpEdit_CustomersAccount.EditValueChanged += DataChanged;
            LookUpEdit_NotesReceivableAccount.EditValueChanged += DataChanged;
            LookUpEdit_InventoryAccount.EditValueChanged += DataChanged;
            LookUpEdit_VendorsAccount.EditValueChanged += DataChanged;
            LookUpEdit_CapitalAccount.EditValueChanged += DataChanged;
            LookUpEdit_NotesPayableAccount.EditValueChanged += DataChanged;
            LookUpEdit_TaxAccount.EditValueChanged += DataChanged;
            LookUpEdit_ManufacturingExpAccount.EditValueChanged += DataChanged;
            LookUpEdit_MerchandisingAccount.EditValueChanged += DataChanged;
            LookUpEdit_PurchasesAccount.EditValueChanged += DataChanged;
            LookUpEdit_PurchasesReturnAccount.EditValueChanged += DataChanged;
            LookUpEdit_SalesAccount.EditValueChanged += DataChanged;
            LookUpEdit_SalesReturnAccount.EditValueChanged += DataChanged;
            LookUpEdit_OpenInventoryAccount.EditValueChanged += DataChanged;
            LookUpEdit_CloseInventoryAccount.EditValueChanged += DataChanged;
            LookUpEdit_PurchaseDiscountAccount.EditValueChanged += DataChanged;
            LookUpEdit_SalesDiscountAccount.EditValueChanged += DataChanged;
            LookUpEdit_FixedAssetsAccount.EditValueChanged += DataChanged;
            LookUpEdit_SalesDeductTaxAccount.EditValueChanged += DataChanged;
            LookUpEdit_PurchaseDeductTaxAccount.EditValueChanged += DataChanged;
            LookUpEdit_DebitNoteAccount.EditValueChanged += DataChanged;
            LookUpEdit_CostOfSoldGoodsAccount.EditValueChanged += DataChanged;
            LookUpEdit_DepreciationAccount.EditValueChanged += DataChanged;
            LookUpEdit_ExpensesAccount.EditValueChanged += DataChanged;
            LookUpEdit_RevenueAccount.EditValueChanged += DataChanged;
            LookUpEdit_PurchaseAddTaxAccount.EditValueChanged += DataChanged;
            LookUpEdit_SalesAddTaxAccount.EditValueChanged += DataChanged;
            LookUpEdit_RecieveNotesUnderCollectAccount.EditValueChanged += DataChanged;
            LookUpEdit_CreditNoteAccount.EditValueChanged += DataChanged;
            CheckEdit_PurchaseAutoSerialBatch.EditValueChanged += DataChanged;
            CheckEdit_PriceIncludeSalesTax.EditValueChanged += DataChanged;
            CheckEdit_PriceIncludePurchaseTax.EditValueChanged += DataChanged;
            CheckEdit_CalcPurchaseTaxPerItem.EditValueChanged += DataChanged;
            CheckEdit_InvoicesCodeRedundancy.EditValueChanged += DataChanged;
            CheckEdit_SalesOrderReserveGood.EditValueChanged += DataChanged;
            CheckEdit_PrintBarcodePerInventory.EditValueChanged += DataChanged;
            SpinEdit_BarcodeItemCodeLength.EditValueChanged += DataChanged;
            SpinEdit_BarcodeQtyLength.EditValueChanged += DataChanged;
            CheckEdit_DoPeriodicBackup.EditValueChanged += DataChanged;
            TextEdit_BackupPath.EditValueChanged += DataChanged;
            RadioGroup_StockIsPeriodic.EditValueChanged += DataChanged;
            CheckEdit_FpDependOnInOut.EditValueChanged += DataChanged;
            #endregion 
        }
        private void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            companyinfo = db.St_CompanyInfos.First();
            RaidoEdit_MoneyToTextMode.SelectedIndex  =Convert.ToInt16( companyinfo.MoneyToTextMode);
            RadioGroup_StockIsPeriodic.SelectedIndex = Convert.ToInt16(companyinfo.StockIsPeriodic);
            CheckEdit_DoPeriodicBackup.SelectedIndex = Convert.ToInt16(companyinfo.DoPeriodicBackup);
            TextEdit_BackupPath.Text  =  companyinfo.BackupPath ;

            CheckEdit_ReleaseProductWithoutQMSAprove.EditValue = companyinfo.ReleaseProductWithoutQMSAprove;
            CheckEdit_ApproveQMFormWithoutVal.EditValue = companyinfo.ApproveQMFormWithoutVal;
            CheckEdit_SellRawMaterial.EditValue = companyinfo.SellRawMaterial;
            CheckEdit_BuyAssembly.EditValue = companyinfo.BuyAssembly;
            CheckEdit_AutoSerialForAssembly.EditValue = companyinfo.AutoSerialForAssembly;
            TextEdit_PrimaryReportingFolderName.EditValue = companyinfo.PrimaryReportingFolderName;
            TextEdit_SecondaryReportingPath.EditValue = companyinfo.SecondaryReportingPath;
            
            #region Accounts
            LookUpEdit_EmployeesDueAccount.EditValue = companyinfo.EmployeesDueAccount;
            LookUpEdit_WagesAccount.EditValue = companyinfo.WagesAccount;
            LookUpEdit_DueSalerysAccount.EditValue = companyinfo.DueSalerysAccount;
            LookUpEdit_DrawerAccount.EditValue = companyinfo.DrawerAccount;
            LookUpEdit_BanksAccount.EditValue = companyinfo.BanksAccount;
            LookUpEdit_CustomersAccount.EditValue = companyinfo.CustomersAccount;
            LookUpEdit_NotesReceivableAccount.EditValue = companyinfo.NotesReceivableAccount;
            LookUpEdit_InventoryAccount.EditValue = companyinfo.InventoryAccount;
            LookUpEdit_VendorsAccount.EditValue = companyinfo.VendorsAccount;
            LookUpEdit_CapitalAccount.EditValue = companyinfo.CapitalAccount;
            LookUpEdit_NotesPayableAccount.EditValue = companyinfo.NotesPayableAccount;
            LookUpEdit_TaxAccount.EditValue = companyinfo.TaxAccount;
            LookUpEdit_ManufacturingExpAccount.EditValue = companyinfo.ManufacturingExpAccount;
            LookUpEdit_MerchandisingAccount.EditValue = companyinfo.MerchandisingAccount;
            LookUpEdit_PurchasesAccount.EditValue = companyinfo.PurchasesAccount;
            LookUpEdit_PurchasesReturnAccount.EditValue = companyinfo.PurchasesReturnAccount;
            LookUpEdit_SalesAccount.EditValue = companyinfo.SalesAccount;
            LookUpEdit_SalesReturnAccount.EditValue = companyinfo.SalesReturnAccount;
            LookUpEdit_OpenInventoryAccount.EditValue = companyinfo.OpenInventoryAccount;
            LookUpEdit_CloseInventoryAccount.EditValue = companyinfo.CloseInventoryAccount;
            LookUpEdit_PurchaseDiscountAccount.EditValue = companyinfo.PurchaseDiscountAccount;
            LookUpEdit_SalesDiscountAccount.EditValue = companyinfo.SalesDiscountAccount;
            LookUpEdit_FixedAssetsAccount.EditValue = companyinfo.FixedAssetsAccount;
            LookUpEdit_SalesDeductTaxAccount.EditValue = companyinfo.SalesDeductTaxAccount;
            LookUpEdit_PurchaseDeductTaxAccount.EditValue = companyinfo.PurchaseDeductTaxAccount;
            LookUpEdit_DebitNoteAccount.EditValue = companyinfo.DebitNoteAccount;
            LookUpEdit_CostOfSoldGoodsAccount.EditValue = companyinfo.CostOfSoldGoodsAccount;
            LookUpEdit_DepreciationAccount.EditValue = companyinfo.DepreciationAccount;
            LookUpEdit_ExpensesAccount.EditValue = companyinfo.ExpensesAccount;
            LookUpEdit_RevenueAccount.EditValue = companyinfo.RevenueAccount;
            LookUpEdit_PurchaseAddTaxAccount.EditValue = companyinfo.PurchaseAddTaxAccount;
            LookUpEdit_SalesAddTaxAccount.EditValue = companyinfo.SalesAddTaxAccount;
            LookUpEdit_RecieveNotesUnderCollectAccount.EditValue = companyinfo.RecieveNotesUnderCollectAccount;
            LookUpEdit_CreditNoteAccount.EditValue = companyinfo.CreditNoteAccount;

            if (LookUpEdit_EmployeesDueAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_EmployeesDueAccount.EditValue = AccountTemplate.Accounts.EmployeesDueAccount.ID;
            if (LookUpEdit_WagesAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_WagesAccount.EditValue = AccountTemplate.Accounts.WagesAccount.ID;
            if (LookUpEdit_DueSalerysAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_DueSalerysAccount.EditValue = AccountTemplate.Accounts.DueSalerysAccount.ID;
            if (LookUpEdit_DrawerAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_DrawerAccount.EditValue = AccountTemplate.Accounts.DrawerAccount.ID;
            if (LookUpEdit_BanksAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_BanksAccount.EditValue = AccountTemplate.Accounts.BanksAccount.ID;
            if (LookUpEdit_CustomersAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_CustomersAccount.EditValue = AccountTemplate.Accounts.CustomersAccount.ID;
            if (LookUpEdit_NotesReceivableAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_NotesReceivableAccount.EditValue = AccountTemplate.Accounts.NotesReceivableAccount.ID;
            if (LookUpEdit_InventoryAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_InventoryAccount.EditValue = AccountTemplate.Accounts.InventoryAccount.ID;
            if (LookUpEdit_VendorsAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_VendorsAccount.EditValue = AccountTemplate.Accounts.VendorsAccount.ID;
            if (LookUpEdit_CapitalAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_CapitalAccount.EditValue = AccountTemplate.Accounts.CapitalAccount.ID;
            if (LookUpEdit_NotesPayableAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_NotesPayableAccount.EditValue = AccountTemplate.Accounts.NotesPayableAccount.ID;
            if (LookUpEdit_TaxAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_TaxAccount.EditValue = AccountTemplate.Accounts.TaxAccount.ID;
            if (LookUpEdit_ManufacturingExpAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_ManufacturingExpAccount.EditValue = AccountTemplate.Accounts.ManufacturingExpAccount.ID;
            if (LookUpEdit_MerchandisingAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_MerchandisingAccount.EditValue = AccountTemplate.Accounts.MerchandisingAccount.ID;
            if (LookUpEdit_PurchasesAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_PurchasesAccount.EditValue = AccountTemplate.Accounts.PurchasesAccount.ID;
            if (LookUpEdit_PurchasesReturnAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_PurchasesReturnAccount.EditValue = AccountTemplate.Accounts.PurchasesReturnAccount.ID;
            if (LookUpEdit_SalesAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_SalesAccount.EditValue = AccountTemplate.Accounts.SalesAccount.ID;
            if (LookUpEdit_SalesReturnAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_SalesReturnAccount.EditValue = AccountTemplate.Accounts.SalesReturnAccount.ID;
            if (LookUpEdit_OpenInventoryAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_OpenInventoryAccount.EditValue = AccountTemplate.Accounts.OpenInventoryAccount.ID;
            if (LookUpEdit_CloseInventoryAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_CloseInventoryAccount.EditValue = AccountTemplate.Accounts.CloseInventoryAccount.ID;
            if (LookUpEdit_PurchaseDiscountAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_PurchaseDiscountAccount.EditValue = AccountTemplate.Accounts.PurchaseDiscountAccount.ID;
            if (LookUpEdit_SalesDiscountAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_SalesDiscountAccount.EditValue = AccountTemplate.Accounts.SalesDiscountAccount.ID;
            if (LookUpEdit_FixedAssetsAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_FixedAssetsAccount.EditValue = AccountTemplate.Accounts.FixedAssetsAccount.ID;
            if (LookUpEdit_SalesDeductTaxAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_SalesDeductTaxAccount.EditValue = AccountTemplate.Accounts.SalesDeductTaxAccount.ID;
            if (LookUpEdit_PurchaseDeductTaxAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_PurchaseDeductTaxAccount.EditValue = AccountTemplate.Accounts.PurchaseDeductTaxAccount.ID;
            if (LookUpEdit_CostOfSoldGoodsAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_CostOfSoldGoodsAccount.EditValue = AccountTemplate.Accounts.CostOfSoldGoodsAccount.ID;
            if (LookUpEdit_DepreciationAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_DepreciationAccount.EditValue = AccountTemplate.Accounts.DepreciationAccount.ID;
            if (LookUpEdit_ExpensesAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_ExpensesAccount.EditValue = AccountTemplate.Accounts.ExpensesAccount.ID;
            if (LookUpEdit_RevenueAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_RevenueAccount.EditValue = AccountTemplate.Accounts.RevenueAccount.ID;
            if (LookUpEdit_PurchaseAddTaxAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_PurchaseAddTaxAccount.EditValue = AccountTemplate.Accounts.PurchaseAddTaxAccount.ID;
            if (LookUpEdit_SalesAddTaxAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_SalesAddTaxAccount.EditValue = AccountTemplate.Accounts.SalesAddTaxAccount.ID;
            if (LookUpEdit_RecieveNotesUnderCollectAccount.EditValue.ValidAsIntNonZero() == false) LookUpEdit_RecieveNotesUnderCollectAccount.EditValue = AccountTemplate.Accounts.RecieveNotesUnderCollectAccount.ID;
            //if (LookUpEdit_DebitNoteAccount.ValidAsIntNonZero() == false) LookUpEdit_DebitNoteAccount.EditValue = AccountTemplate.Accounts.DebitNoteAccount;
            //if (LookUpEdit_CreditNoteAccount.ValidAsIntNonZero() == false) LookUpEdit_CreditNoteAccount.EditValue = AccountTemplate.Accounts.CreditNoteAccount;


            //.ValidAsIntNonZero()==false )

            /*

         LookUpEdit_EmployeesDueAccount            
         LookUpEdit_WagesAccount                   
         LookUpEdit_DueSalerysAccount              
         LookUpEdit_DrawerAccount                  
         LookUpEdit_BanksAccount                   
         LookUpEdit_CustomersAccount               
         LookUpEdit_NotesReceivableAccount         
         LookUpEdit_InventoryAccount               
         LookUpEdit_VendorsAccount                 
         LookUpEdit_CapitalAccount                 
         LookUpEdit_NotesPayableAccount            
         LookUpEdit_TaxAccount                     
         LookUpEdit_ManufacturingExpAccount        
         LookUpEdit_MerchandisingAccount           
         LookUpEdit_PurchasesAccount               
         LookUpEdit_PurchasesReturnAccount         
         LookUpEdit_SalesAccount                   
         LookUpEdit_SalesReturnAccount             
         LookUpEdit_OpenInventoryAccount           
         LookUpEdit_CloseInventoryAccount          
         LookUpEdit_PurchaseDiscountAccount        
         LookUpEdit_SalesDiscountAccount           
         LookUpEdit_FixedAssetsAccount             
         LookUpEdit_SalesDeductTaxAccount          
         LookUpEdit_PurchaseDeductTaxAccount       
         LookUpEdit_DebitNoteAccount               
         LookUpEdit_CostOfSoldGoodsAccount         
         LookUpEdit_DepreciationAccount            
         LookUpEdit_ExpensesAccount                
         LookUpEdit_RevenueAccount                 
         LookUpEdit_PurchaseAddTaxAccount          
         LookUpEdit_SalesAddTaxAccount             
         LookUpEdit_RecieveNotesUnderCollectAccount
         LookUpEdit_CreditNoteAccount              

             */
            #endregion
            CheckEdit_PurchaseAutoSerialBatch.EditValue = companyinfo.PurchaseAutoSerialBatch;
            CheckEdit_PriceIncludeSalesTax.EditValue = companyinfo.PriceIncludeSalesTax;
            CheckEdit_PriceIncludePurchaseTax.EditValue = companyinfo.PriceIncludePurchaseTax;
            CheckEdit_CalcPurchaseTaxPerItem.EditValue = companyinfo.CalcPurchaseTaxPerItem;
            CheckEdit_InvoicesCodeRedundancy.EditValue = companyinfo.InvoicesCodeRedundancy;
            CheckEdit_SalesOrderReserveGood.EditValue = companyinfo.SalesOrderReserveGood;
            CheckEdit_PrintBarcodePerInventory.EditValue = companyinfo.PrintBarcodePerInventory;
            SpinEdit_BarcodeItemCodeLength.EditValue = companyinfo.BarcodeItemCodeLength;
            SpinEdit_BarcodeQtyLength.EditValue = companyinfo.BarcodeQtyLength;

            CheckEdit_FpDependOnInOut.EditValue = companyinfo.FpDependOnInOut;

            ComboBoxEdit_CasherPrinter.Text = Program.setting.CasherPrinter;
            ComboBoxEdit_DefaultPrinter.Text = Program.setting.DefaultPrinter;
            TextEdit_TempletPath.Text = Program.setting.TempletPath;
            ToggleSwitch_PrintPayBillOnSave.IsOn = Program.setting.PrintPayBillOnSave;
            ToggleSwitch_PrintItemWithdrawBillOnSave.IsOn = Program.setting.PrintItemWithdrawBillOnSave;

        }

        private void accordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            var PressedTap = tabbedControlGroup1.TabPages.ToList().Where(x => x.Name == ((string)e.Element.Tag)).SingleOrDefault() as LayoutGroup ;
            if(PressedTap != null)
            {
                tabbedControlGroup1.SelectedTabPage = PressedTap;
                layoutControlGroup1.Text = e.Element.Text;
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RadioGroup_StockIsPeriodic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioGroup_StockIsPeriodic.SelectedIndex == 0)
            {
                layoutControl_LookUpEdit_MerchandisingAccount.Visibility =
                layoutControl_LookUpEdit_CloseInventoryAccount.Visibility =
                layoutControl_LookUpEdit_OpenInventoryAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControl_LookUpEdit_InventoryAccount.Visibility =
                layoutControl_LookUpEdit_CostOfSoldGoodsAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
            else
            {
                layoutControl_LookUpEdit_MerchandisingAccount.Visibility =
                layoutControl_LookUpEdit_CloseInventoryAccount.Visibility =
                layoutControl_LookUpEdit_OpenInventoryAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;
                layoutControl_LookUpEdit_InventoryAccount.Visibility =
                layoutControl_LookUpEdit_CostOfSoldGoodsAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never ;

            }
        }
        XRDesignMdiController mdiController; 
        private void Button_OpenReportDesinger_Click(object sender, EventArgs e)
        {
            XtraReport rpt = null;
            switch (LookUpEdit_Reports .EditValue.ToString())
            {
                case "rpt_Inv_OpenBalance": rpt = new Reporting.rpt_Inv_OpenBalance(); break;
                case "rpt_GridReport": rpt = new Reporting.rpt_GridReport(); break;
                case "rpt_Inv_ItemDamage": rpt = new Reporting.rpt_Inv_ItemDamage(); break;
                case "rpt_Inv_ItemAdd": rpt = new Reporting.rpt_Inv_ItemAdd(); break;
                case "rpt_Inv_ItemTake": rpt = new Reporting.rpt_Inv_ItemTake(); break;
                case "rpt_Inv_ItemStoreMove": rpt = new Reporting.rpt_Inv_ItemStoreMove(); break;
                case "rpt_Inv_Invoice": rpt = new Reporting.rpt_Inv_Invoice(); break;

                case "rpt_Sl_Requst": rpt = new Reporting.rpt_Sl_Requst(); break;
                case "rpt_Sl_Order": rpt = new Reporting.rpt_Sl_Order(); break;
                case "rpt_Inv_InvoiceItemTakeBill": rpt = new Reporting.rpt_Inv_InvoiceItemTakeBill(); break;
                case "rpt_Inv_InvoicePayBill": rpt = new Reporting.rpt_Inv_InvoicePayBill(); break;
                case "rpt_Sl_SlReturnInvoice": rpt = new Reporting.rpt_Sl_SlReturnInvoice(); break;

                case "rpt_Pr_PrInvoice": rpt = new Reporting.rpt_Pr_PrInvoice(); break;
                case "rpt_Pr_Requst": rpt = new Reporting.rpt_Pr_Requst(); break;
                case "rpt_Pr_Order": rpt = new Reporting.rpt_Pr_Order(); break;
                case "rpt_Pr_PrInvoiceItemAddBill": rpt = new Reporting.rpt_Pr_PrInvoiceItemAddBill(); break;
                case "rpt_Pr_PrInvoicePayBill": rpt = new Reporting.rpt_Pr_PrInvoicePayBill(); break;
                case "rpt_Pr_PrReturnInvoice": rpt = new Reporting.rpt_Pr_PrReturnInvoice(); break;
            }
            if (rpt == null) return;
            if (File.Exists(Program.setting.TempletPath + "\\PrintTemplets\\" + LookUpEdit_Reports .EditValue.ToString() + ".xml"))
                rpt.LoadLayout(Program.setting.TempletPath + "\\PrintTemplets\\" + LookUpEdit_Reports.EditValue.ToString() + ".xml");
            else if (File.Exists(CurrentSession.DTemplatePath + "\\" + LookUpEdit_Reports.EditValue.ToString() + ".xml"))
                rpt.LoadLayout(CurrentSession.DTemplatePath + "\\" + LookUpEdit_Reports.EditValue.ToString() + ".xml");

            //rpt.DisplayName = comboBoxEdit1.EditValue.ToString();
            //rpt.Name = comboBoxEdit1.EditValue.ToString();

            //  rpt.ShowDesigner();
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;

            // Handle the DesignPanelLoaded event of the MDI controller,
            // to override the SaveCommandHandler for every loaded report.
            mdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

            // Open an empty report in the form.
            mdiController.OpenReport(rpt);

            // Show the form.
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null)
            {
                mdiController.ActiveDesignPanel.CloseReport();
            }
        }
        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }
        public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
            }

            public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
                object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
                ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                                   command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

            void Save()
            {
                // Write your custom saving here.
                // ... // For instance:
                panel.Report.Name = panel.Report.GetType().Name;
                string Path = CurrentSession.DTemplatePath + "\\" + panel.Report.Name + ".xml";
                panel.Report.SaveLayout(Path);
                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;
            }
        }

    }
}
