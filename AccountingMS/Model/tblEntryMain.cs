namespace AccountingMS
{
    public partial class tblEntryMain
    {
        public tblEntryMain ShallowCopy()
        {
            return (tblEntryMain)this.MemberwiseClone();
        }
    }

    public partial class tblEntrySub
    {
        public virtual ClsTblAccount.AccountBalance AccountBalance { get; set; }

    }
}
