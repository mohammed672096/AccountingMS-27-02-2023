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
    
    public partial class InventoryBalancingDetail
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public double Qty { get; set; }
        public double RealQty { get; set; }
        public double Shotage { get; set; }
        public double Surplus { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int MainID { get; set; }
        public double TotalPrice { get; set; }
        public double Cost { get; set; }
    }
}
