namespace AccountingMS
{
    public partial class tblAccount
    {
        public tblAccount ShallowCopy()
        {
            return (tblAccount)this.MemberwiseClone();
        }
    }
}
