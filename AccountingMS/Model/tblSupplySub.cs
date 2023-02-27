namespace AccountingMS
{
    public partial class tblSupplySub : ItblSupplySub
    {
        public tblSupplySub ShallowCopy()
        {
            return (tblSupplySub)this.MemberwiseClone();
        }

        string ItblSupplySub.supMsur { get; set; }
        double? ItblSupplySub.supQuanMain1 { get; set; }
        double? ItblSupplySub.supQuanMain2 { get; set; }

    }
}
