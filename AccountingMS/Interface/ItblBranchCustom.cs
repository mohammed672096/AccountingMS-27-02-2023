namespace AccountingMS
{
    public interface ItblBranchCustom
    {
        short brnNo { get; set; }
        string brnName { get; set; }
        string brnNameEn { get; set; }
        string brnAddress { get; set; }
        string brnAddressEn { get; set; }
        string brnEmail { get; set; }
        string brnPhnNo { get; set; }
        string brnFaxNo { get; set; }
        string brnMailBox { get; set; }
        string brnTaxNo { get; set; }
        string brnTradeNo { get; set; }
    }
}
