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
    
    public partial class tbl_Business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Business()
        {
            this.tbl_BusinessBooking = new HashSet<tbl_BusinessBooking>();
            this.tbl_BusinessImages = new HashSet<tbl_BusinessImages>();
        }
    
        public long Id { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<long> SubCategoryId { get; set; }
        public string BusinessName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsApprovedByAdmin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<long> SelectedCity { get; set; }
        public Nullable<long> Subscription { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public Nullable<long> UserId { get; set; }
        public string PremiumImage { get; set; }
    
        public virtual tbl_Category tbl_Category { get; set; }
        public virtual tbl_Cities tbl_Cities { get; set; }
        public virtual tbl_SubCategory tbl_SubCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BusinessBooking> tbl_BusinessBooking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BusinessImages> tbl_BusinessImages { get; set; }
    }
}
