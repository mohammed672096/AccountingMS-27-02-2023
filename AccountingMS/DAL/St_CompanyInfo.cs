namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class St_CompanyInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyName { get; set; }

        [Column(TypeName = "image")]
        public byte[] CompanyLogo { get; set; }

        [StringLength(50)]
        public string CompanyAddress { get; set; }

        [StringLength(50)]
        public string CompanyCity { get; set; }

        [StringLength(50)]
        public string CompanyPhone { get; set; }

        [StringLength(50)]
        public string CompanyMobile { get; set; }

        [StringLength(50)]
        public string CompanyCommercialBook { get; set; }

        [StringLength(50)]
        public string CompanyTaxCard { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CompanyFYearStart { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CompanyFYearEnd { get; set; }

        public string FAM { get; set; }

        public string HRM { get; set; }

        public string IMS { get; set; }

        public string LMS { get; set; }

        public string MMS { get; set; }

        public string PHS { get; set; }

        public string PMS { get; set; }

        public string QMS { get; set; }

        public string RPS { get; set; }

        public string SPM { get; set; }

        public bool ReleaseProductWithoutQMSAprove { get; set; }

        public bool ApproveQMFormWithoutVal { get; set; }

        public bool MoneyToTextMode { get; set; }

        public bool SellRawMaterial { get; set; }

        public bool BuyAssembly { get; set; }

        public bool AutoSerialForAssembly { get; set; }

        [Required]
        public string PrimaryReportingFolderName { get; set; }

        [Required]
        public string SecondaryReportingPath { get; set; }

        public int EmployeesDueAccount { get; set; }

        public int WagesAccount { get; set; }

        public int DueSalerysAccount { get; set; }

        public int DrawerAccount { get; set; }

        public int BanksAccount { get; set; }

        public int CustomersAccount { get; set; }

        public int NotesReceivableAccount { get; set; }

        public int InventoryAccount { get; set; }

        public int VendorsAccount { get; set; }

        public int CapitalAccount { get; set; }

        public int NotesPayableAccount { get; set; }

        public int TaxAccount { get; set; }

        public int ManufacturingExpAccount { get; set; }

        public int MerchandisingAccount { get; set; }

        public int PurchasesAccount { get; set; }

        public int PurchasesReturnAccount { get; set; }

        public int SalesAccount { get; set; }

        public int SalesReturnAccount { get; set; }

        public int OpenInventoryAccount { get; set; }

        public int CloseInventoryAccount { get; set; }

        public int PurchaseDiscountAccount { get; set; }

        public int SalesDiscountAccount { get; set; }

        public int FixedAssetsAccount { get; set; }

        public int SalesDeductTaxAccount { get; set; }

        public int PurchaseDeductTaxAccount { get; set; }

        public int DebitNoteAccount { get; set; }

        public int CostOfSoldGoodsAccount { get; set; }

        public int LetterOfCreditAccount { get; set; }

        public int DepreciationAccount { get; set; }

        public int ExpensesAccount { get; set; }

        public int RevenueAccount { get; set; }

        public int PurchaseAddTaxAccount { get; set; }

        public int SalesAddTaxAccount { get; set; }

        public int RecieveNotesUnderCollectAccount { get; set; }

        public int CreditNoteAccount { get; set; }

        public bool PurchaseAutoSerialBatch { get; set; }

        public bool PriceIncludeSalesTax { get; set; }

        public int PrInvoiceWorkflow { get; set; }

        public bool PriceIncludePurchaseTax { get; set; }

        public bool CalcPurchaseTaxPerItem { get; set; }

        public bool InvoicesCodeRedundancy { get; set; }

        public bool SalesOrderReserveGood { get; set; }

        public int InvoiceWorkflow { get; set; }

        public bool PrintBarcodePerInventory { get; set; }

        public int BarcodeItemCodeLength { get; set; }

        public int BarcodeQtyLength { get; set; }

        public bool DoPeriodicBackup { get; set; }

        [Required]
        public string BackupPath { get; set; }

        public bool StockIsPeriodic { get; set; }

        public bool FpDependOnInOut { get; set; }

        public bool PreventInvoiceDeletionAfterBarcodePrint { get; set; }
    }
}
