namespace AccountingMS
{
    public class ClsPrdTrackingStatus
    {
        public static string GetString(byte status)
        {
            PrdTracking prdTracking = (PrdTracking)status;

            return (prdTracking) switch
            {
                PrdTracking.Purchase => "مشتريات",
                PrdTracking.PurchaseRtrn => "مردود مشتريات",
                PrdTracking.Sale => "مبيعات",
                PrdTracking.SaleRtrn => "مردود مبيعات",
                PrdTracking.Opn => "رصيد إفتتاحي",
                PrdTracking.Exp => "إتلاف",
                PrdTracking.TransIn => "تحويل مخزني إستلام",
                PrdTracking.TransOut => "تحويل مخزني إخراج",
                PrdTracking.Inv => "جرد",
                _ => null
            };
        }
    }
}
