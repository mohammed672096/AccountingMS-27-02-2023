//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class CouponBarcode
    {
        public int id { get; set; }
        public string CouponName { get; set; }
        public string BarCode { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<System.DateTime> dateExpir { get; set; }
        public Nullable<int> OffersID { get; set; }
        public Nullable<int> supNo { get; set; }
        public Nullable<decimal> supTotal { get; set; }
        public Nullable<decimal> couponPrice { get; set; }
    }
}
