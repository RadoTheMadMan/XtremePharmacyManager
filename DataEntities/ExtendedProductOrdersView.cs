//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XtremePharmacyManager.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExtendedProductOrdersView
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ProductDescription { get; set; }
        public System.DateTime ProductExpiryDate { get; set; }
        public int DesiredQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAddress { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }
        public int OrderStatus { get; set; }
        public string OrderReason { get; set; }
    }
}
