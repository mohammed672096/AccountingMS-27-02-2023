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
    
    public partial class tblCustomer
    {
        public int id { get; set; }
        public int custNo { get; set; }
        public long custAccNo { get; set; }
        public string custAccName { get; set; }
        public string custName { get; set; }
        public string custPhnNo { get; set; }
        public string custCountry { get; set; }
        public string custCity { get; set; }
        public string custAddress { get; set; }
        public string custEmail { get; set; }
        public Nullable<long> custCellingCredit { get; set; }
        public Nullable<byte> custCurrency { get; set; }
        public Nullable<byte> custSalePrice { get; set; }
        public string custTaxNo { get; set; }
        public Nullable<short> custBrnId { get; set; }
        public byte custStatus { get; set; }
        public string custNameEn { get; set; }
        public string custCountryEn { get; set; }
        public string custCityEn { get; set; }
        public string custAddressEn { get; set; }
        public string CommercialRegister { get; set; }
        public string PostalCode { get; set; }
        public Nullable<short> cusBankId { get; set; }
        public string cusAddNo { get; set; }
        public string cusBuildingNo { get; set; }
        public string cusAnotherID { get; set; }
        public string cusDistrict { get; set; }
        public string cusDistrictEn { get; set; }
    }
}
