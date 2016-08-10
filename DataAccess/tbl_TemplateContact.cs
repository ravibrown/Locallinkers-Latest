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
    
    public partial class tbl_TemplateContact
    {
        public long Id { get; set; }
        public Nullable<long> TemplateId { get; set; }
        public string TumblarLink { get; set; }
        public string FaceBookLink { get; set; }
        public string GoogleLink { get; set; }
        public string TwitterLink { get; set; }
        public string PinInterestLink { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsApprovedByAdmin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    
        public virtual tbl_Template tbl_Template { get; set; }
    }
}
