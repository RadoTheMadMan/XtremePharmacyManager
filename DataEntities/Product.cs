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
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductImages = new HashSet<ProductImage>();
            this.ProductOrders = new HashSet<ProductOrder>();
        }
    
        public int ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public System.DateTime ProductExpiryDate { get; set; }
        public string ProductRegNum { get; set; }
        public string ProductPartNum { get; set; }
        public string ProductStorageLocation { get; set; }
        public Nullable<int> VendorID { get; set; }
    
        public virtual ProductBrand ProductBrand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ProductVendor ProductVendor { get; set; }
    }
}
