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
    
    public partial class ClientView
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserDisplayName { get; set; }
        public System.DateTime UserBirthDate { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public byte[] UserProfilePic { get; set; }
        public decimal UserBalance { get; set; }
        public string UserDiagnose { get; set; }
        public System.DateTime UserDateOfRegister { get; set; }
        public int UserRole { get; set; }
        public Nullable<decimal> PredictedAverageClientSpending { get; set; }
        public int ID { get; set; }
        public Nullable<decimal> AverageClientSpending { get; set; }
    }
}
