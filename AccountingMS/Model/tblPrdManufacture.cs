namespace AccountingMS
{
    public partial class tblPrdManufacture
    {
        public tblPrdManufacture ShallowCopy()
        {
            return (tblPrdManufacture)this.MemberwiseClone();
        }
    }
}
