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
    
    public partial class SalaryRegulation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string costCenter { get; set; }
        public Nullable<double> ExpensesAccount { get; set; }
        public Nullable<double> BenefitsAccount { get; set; }
        public Nullable<double> DayValue { get; set; }
        public Nullable<double> HourValue { get; set; }
        public string SalaryPeriod { get; set; }
        public string SalaryCalculation { get; set; }
        public Nullable<double> DefaultSalary { get; set; }
        public Nullable<double> Equation { get; set; }
        public Nullable<int> BenefitListid { get; set; }
        public Nullable<int> DeductionListid { get; set; }
    }
}
