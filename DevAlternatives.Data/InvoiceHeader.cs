//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevAlternatives.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceHeader
    {
        public int InvoiceID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<decimal> InvoiceTotal { get; set; }
        public Nullable<int> TotalItems { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> StoreID { get; set; }
    }
}