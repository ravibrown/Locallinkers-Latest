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
    
    public partial class sp_GetDistance_Coupons_Result8
    {
        public Nullable<long> SNO { get; set; }
        public long Id { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<long> SubCategoryId { get; set; }
        public string Title { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<decimal> ActualPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> PayToMerchant { get; set; }
        public Nullable<decimal> CouponPrice { get; set; }
        public string OfferDetails { get; set; }
        public string TermsAndCondition { get; set; }
        public Nullable<long> Quantity { get; set; }
        public string UniqueId { get; set; }
        public string CouponMessage { get; set; }
        public Nullable<long> SelectedPosition { get; set; }
        public Nullable<long> SelectedCity { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsApprovedByAdmin { get; set; }
        public double Distance { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string CityName { get; set; }
        public string Image { get; set; }
        public bool IsAsPerBill { get; set; }
    }
}