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
    
    public partial class Reward
    {
        public int id { get; set; }
        public Nullable<int> empid { get; set; }
        public Nullable<System.DateTime> dateAncestor { get; set; }
        public Nullable<double> amount { get; set; }
        public string reason { get; set; }
    }
}