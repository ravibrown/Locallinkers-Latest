//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_OrderAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_OrderAddress()
        {
            this.tbl_Orders = new HashSet<tbl_Orders>();
        }
    
        public long Id { get; set; }
        public string PaymentMode { get; set; }
        public string TrackingId { get; set; }
        public string BankReferenceNumber { get; set; }
        public string Currency { get; set; }
        public string BillingAddress { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZip { get; set; }
        public string BillingName { get; set; }
        public string BillingCountry { get; set; }
        public string BillingTel { get; set; }
        public string BillingEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryState { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryTel { get; set; }
        public string DeliveryEmail { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsApprovedByAdmin { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string OrderId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Orders> tbl_Orders { get; set; }
    }
}
