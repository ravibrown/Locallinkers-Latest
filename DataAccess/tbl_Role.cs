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
    
    public partial class tbl_Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsApprovedByAdmin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
    }
}
