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
    
    public partial class Shift
    {
        public int id { get; set; }
        public string name { get; set; }
        public System.DateTime startDate { get; set; }
        public int repeatEvery { get; set; }
        public Nullable<int> ShiftDaysid { get; set; }
        public Nullable<System.TimeSpan> clock_work { get; set; }
        public string Holiday1 { get; set; }
        public string Holiday2 { get; set; }
        public Nullable<System.TimeSpan> emp_Login { get; set; }
        public Nullable<System.TimeSpan> emp_exit { get; set; }
    }
}
