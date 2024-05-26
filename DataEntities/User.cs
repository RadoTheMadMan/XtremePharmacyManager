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
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.ProductOrders = new HashSet<ProductOrder>();
            this.ProductOrders1 = new HashSet<ProductOrder>();
        }
    
        public int ID { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrders1 { get; set; }
    }
}
