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
    
    public partial class ExtendedOrderDeliveriesView
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
        public string ServiceName { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string MethodName { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryReason { get; set; }
        public string CargoID { get; set; }
        public string VendorName { get; set; }
        public Nullable<decimal> TotalIncome { get; set; }
        public Nullable<decimal> TotalLoss { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> DeliveredStock { get; set; }
        public Nullable<int> ReturnedStock { get; set; }
        public Nullable<int> StockToBeInboundOrOutbound { get; set; }
        public Nullable<int> TotalStock { get; set; }
        public Nullable<int> DeliveredProducts { get; set; }
        public Nullable<int> ReturnedProducts { get; set; }
        public Nullable<int> ProductsToBeInboundOrOutbound { get; set; }
        public Nullable<int> TotalProducts { get; set; }
        public Nullable<int> ClientsWhoCompletedDelivery { get; set; }
        public Nullable<int> ClientsWhoReturnedDelivery { get; set; }
        public Nullable<int> ClientsWhoWaitForDelivery { get; set; }
        public Nullable<int> ClientsWhoRequestedDelivery { get; set; }
        public Nullable<int> ServicesWithCompletedDeliveries { get; set; }
        public Nullable<int> ServicesWithCancelledOrReturnedDeliveries { get; set; }
        public Nullable<int> ServicesWithIdleOrStillProcessingDeliveries { get; set; }
        public Nullable<int> TotalServicesUsedInTheDeliveries { get; set; }
        public Nullable<int> MethodsUsedInCompletedDeliveries { get; set; }
        public Nullable<int> MethodsUsedInCancelledOrReturnedDeliveries { get; set; }
        public Nullable<int> MethodsUsedInIdleOrStillProcessingDeliveries { get; set; }
        public Nullable<int> TotalMethodsUsedInTheDeliveries { get; set; }
        public Nullable<int> CompletedDeliveriesCount { get; set; }
        public Nullable<int> CancelledOrReturnedDeliveriesCount { get; set; }
        public Nullable<int> IdleOrStillProcessingDeliveriesCount { get; set; }
        public Nullable<int> TotalDeliveriesCount { get; set; }
        public Nullable<decimal> DeliverySaleRatePercentByPrice { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByPrice { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByPrice { get; set; }
        public Nullable<decimal> DeliverySaleRatePercentByDesiredQuantity { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByDesiredQuantity { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByDesiredQuantity { get; set; }
        public Nullable<decimal> DeliveryCompletionRatePercentByProductCount { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByProductCount { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByProductCount { get; set; }
        public Nullable<decimal> DeliveryCompletionRatePercentByClientCount { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByClientCount { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByClientCount { get; set; }
        public Nullable<decimal> DeliverySaleRatePercentByServiceCount { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByServiceCount { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByServiceCount { get; set; }
        public Nullable<decimal> DeliverySaleRatePercentByMethodCount { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByMethodCount { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByMethodCount { get; set; }
        public Nullable<decimal> DeliverySaleRatePercentByCount { get; set; }
        public Nullable<decimal> DeliveryReturnRatePercentByCount { get; set; }
        public Nullable<decimal> DeliveryDueRatePercentByCount { get; set; }
    }
}
