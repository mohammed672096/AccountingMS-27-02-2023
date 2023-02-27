namespace AccountingMS
{
    public class ClsProductQuantList
    {
        public int prdId { set; get; }
        public string prdNo { set; get; }
        public string prdName { set; get; }
        public double prdQuantity { set; get; }
        public double prdPrice { set; get; }
        public short prdStrId { set; get; }
        public int prdPriceMsurId { set; get; }
        public bool prdIsIncrease { set; get; }

        public ClsProductQuantList ShallowCopy()
        {
            return (ClsProductQuantList)this.MemberwiseClone();
        }
    }
}
