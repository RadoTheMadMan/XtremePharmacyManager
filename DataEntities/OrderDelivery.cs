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

    [Serializable]
    public partial class OrderDelivery
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> DeliveryServiceID { get; set; }
        public Nullable<int> PaymentMethodID { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryReason { get; set; }
        public string CargoID { get; set; }
    
        public virtual DeliveryService DeliveryService { get; set; }
        public virtual ProductOrder ProductOrder { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
