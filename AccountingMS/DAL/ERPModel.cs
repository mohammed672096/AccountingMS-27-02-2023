namespace AccountingMS.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ERPModel : DbContext
    {
        public ERPModel()
            : base("name=ERPModel")
        { 
        }

        public virtual DbSet<Acc_Accounts> Acc_Accounts { get; set; }
        public virtual DbSet<Acc_Activity> Acc_Activity { get; set; }
        public virtual DbSet<Acc_ActivityDetial> Acc_ActivityDetial { get; set; }
        public virtual DbSet<Acc_Banks> Acc_Banks { get; set; }
        public virtual DbSet<Acc_CashNote> Acc_CashNote { get; set; }
        public virtual DbSet<Acc_CashTransfer> Acc_CashTransfer { get; set; }
        public virtual DbSet<Acc_CostCenter> Acc_CostCenter { get; set; }
        public virtual DbSet<Acc_CurrencyChangeLog> Acc_CurrencyChangeLog { get; set; }
        public virtual DbSet<Acc_Currencys> Acc_Currencys { get; set; }
        public virtual DbSet<Acc_Drawer> Acc_Drawer { get; set; }
        public virtual DbSet<Acc_PayCards> Acc_PayCards { get; set; }
        public virtual DbSet<Acc_Pays> Acc_Pays { get; set; }
        public virtual DbSet<Acc_Receipts> Acc_Receipts { get; set; }
        public virtual DbSet<Acc_RevExpEntry> Acc_RevExpEntry { get; set; }
        public virtual DbSet<Acc_RevExpEntryDetails> Acc_RevExpEntryDetails { get; set; }
        public virtual DbSet<Inv_Color> Inv_Color { get; set; }
        public virtual DbSet<Inv_Company> Inv_Company { get; set; }
        public virtual DbSet<Inv_Invoice> Inv_Invoice { get; set; }
        public virtual DbSet<Inv_InvoiceDetail> Inv_InvoiceDetail { get; set; }
        public virtual DbSet<Inv_InvoicesExpense> Inv_InvoicesExpense { get; set; }
        public virtual DbSet<Inv_ItemAdd> Inv_ItemAdd { get; set; }
        public virtual DbSet<Inv_ItemAddDetails> Inv_ItemAddDetails { get; set; }
        public virtual DbSet<Inv_ItemBarcodeLog> Inv_ItemBarcodeLog { get; set; }
        public virtual DbSet<Inv_ItemBarcodes> Inv_ItemBarcodes { get; set; }
        public virtual DbSet<Inv_ItemDamage> Inv_ItemDamage { get; set; }
        public virtual DbSet<Inv_ItemDamageDetails> Inv_ItemDamageDetails { get; set; }
        public virtual DbSet<Inv_ItemGroup> Inv_ItemGroup { get; set; }
        public virtual DbSet<Inv_ItemLocation> Inv_ItemLocation { get; set; }
        public virtual DbSet<Inv_ItemOpenBalance> Inv_ItemOpenBalance { get; set; }
        public virtual DbSet<Inv_ItemOpenBalanceDetails> Inv_ItemOpenBalanceDetails { get; set; }
        public virtual DbSet<Inv_ItemPPQ> Inv_ItemPPQ { get; set; }
        public virtual DbSet<Inv_Items> Inv_Items { get; set; }
        public virtual DbSet<Inv_ItemStoreMove> Inv_ItemStoreMove { get; set; }
        public virtual DbSet<Inv_ItemStoreMoveDetails> Inv_ItemStoreMoveDetails { get; set; }
        public virtual DbSet<Inv_ItemTake> Inv_ItemTake { get; set; }
        public virtual DbSet<Inv_ItemTakeDetails> Inv_ItemTakeDetails { get; set; }
        public virtual DbSet<Inv_ItemUnits> Inv_ItemUnits { get; set; }
        public virtual DbSet<Inv_PriceChange> Inv_PriceChange { get; set; }
        public virtual DbSet<Inv_Size> Inv_Size { get; set; }
        public virtual DbSet<Inv_Store> Inv_Store { get; set; }
        public virtual DbSet<Inv_StoreLog> Inv_StoreLog { get; set; }
        public virtual DbSet<Inv_UOM> Inv_UOM { get; set; }
        public virtual DbSet<Pr_InvoicesExpense> Pr_InvoicesExpense { get; set; }
        public virtual DbSet<Pr_Vendor> Pr_Vendor { get; set; }
        public virtual DbSet<Pr_VendorGroup> Pr_VendorGroup { get; set; }
        public virtual DbSet<Sl_Customer> Sl_Customer { get; set; }
        public virtual DbSet<Sl_CustomerGroup> Sl_CustomerGroup { get; set; }
        public virtual DbSet<St_CompanyInfo> St_CompanyInfo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inv_InvoiceDetail>()
                .Property(e => e.Batch)
                .IsFixedLength();

            modelBuilder.Entity<Inv_ItemBarcodeLog>()
                .Property(e => e.Batch)
                .IsFixedLength();

            modelBuilder.Entity<Inv_ItemOpenBalance>()
                .HasMany(e => e.Inv_ItemOpenBalanceDetails)
                .WithRequired(e => e.Inv_ItemOpenBalance)
                .HasForeignKey(e => e.ItemOpenBalanceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inv_Items>()
                .HasMany(e => e.Inv_ItemUnits)
                .WithRequired(e => e.Inv_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inv_StoreLog>()
                .Property(e => e.Note)
                .IsFixedLength();

            modelBuilder.Entity<Inv_StoreLog>()
                .Property(e => e.Batch)
                .IsFixedLength();
        }
    }
}
