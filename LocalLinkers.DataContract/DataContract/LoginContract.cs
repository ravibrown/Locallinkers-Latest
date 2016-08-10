using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LocalLinkers.DataContract
{
    [DataContract]
    public class LoginDataContract
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class ForgetInputDataContract
    {
        [DataMember]
        public string PhoneNumber { get; set; }
    }

    [DataContract]
    public class VerificationDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string VerificationCode { get; set; }
    }

    [DataContract]
    public class OTPDataContract
    {
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string OTPCode { get; set; }
    }
    [DataContract]
    public class HomeSliderDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public string Image { get; set; }
    }

    [DataContract]
    public class VerificationByPhoneNumberDataContract
    {
        [DataMember]
        public string PhoneNumber { get; set; }
    }

    [DataContract]
    public class SignUpDataContract
    {

        [DataMember]
        public string DeviceCode { get; set; }
        [DataMember]
        public string IMEI { get; set; }
        [DataMember]
        public string Platform { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }

    }

    public class ResultDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string Result_Details { get; set; }
    }
    public class ResultDataContractWithUserImage
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string ImageName{ get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string Result_Details { get; set; }
    }


    public class LoginResultDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public Int64? RoleId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public Int64? ReedemPoints { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string Result_Details { get; set; }
    }

    public class ResetPasswordDataContract
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string OTP { get; set; }
    }


    public class VerificationResultDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string VerifcationCode { get; set; }
        [DataMember]
        public string Result_Details { get; set; }
    }

    public class CouponDataContract
    {
       
        [DataMember]
        public Int64 CouponId { get; set; }
        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public Int64? CityId { get; set; }
        [DataMember]
        public Int64 SubCategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string SubCategoryName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public Int64? Distance { get; set; }
        [DataMember]
        public decimal? ActualPrice { get; set; }
        [DataMember]
        public decimal? SalePrice { get; set; }
        [DataMember]
        public decimal? PayToMerchant { get; set; }
        [DataMember]
        public decimal? CouponPrice { get; set; }
        [DataMember]
        public string OfferDetails { get; set; }
        [DataMember]
        public string CouponMessage { get; set; }
        [DataMember]
        public Int64? Quantity { get; set; }
        [DataMember]
        public string UniqueId { get; set; }
        [DataMember]
        public string TermsAndCondition { get; set; }
        [DataMember]
        public Int64? SelectedPosition { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }

        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }
        [DataMember]
        public string Image { get; set; }
        
        [DataMember]
        public bool? IsAsPerBill { get; set; }
    }

    public class PointsResultDataContract
    {

        [DataMember]
        public Int64? ReedemPoints { get; set; }
        [DataMember]
        public string  Result { get; set; }
    }

    public class PointsDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
    }

    public class ProductDataContract
    {

        [DataMember]
        public Int64 ProductId { get; set; }
        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public Int64? CityId { get; set; }
        [DataMember]
        public Int64 SubCategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string SubCategoryName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ShortDescription { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public Int64? Distance { get; set; }
        [DataMember]
        public decimal? ActualPrice { get; set; }
        [DataMember]
        public decimal? SalePrice { get; set; }
        [DataMember]
        public Int64? Stock { get; set; }
        [DataMember]
        public Int64? SelectedPosition { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }
        [DataMember]
        public string Image { get; set; }

    }


    public class CategoryDataContract
    {

        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }

    }

    public class SubCategoryDataContract
    {

        [DataMember]
        public Int64 SubCategoryId { get; set; }
        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }

    }

    public class BusinessDataContract
    {

        [DataMember]
        public Int64 BusinessId { get; set; }
        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public Int64 SubCategoryId { get; set; }
        [DataMember]
        public Int64 CityId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string SubCategoryName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string ButtonTitle { get; set; }
        [DataMember]
        public string UserMessage { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public string PhoneNumber1 { get; set; }
        [DataMember]
        public string PhoneNumber2 { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public Int64? Distance { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public Int64 Subscription { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }
        [DataMember]
        public string Image { get; set; }

    }

    public class OrderDataContract
    {

        [DataMember]
        public Int64 OrderId { get; set; }
        [DataMember]
        public string TrackingId { get; set; }
        [DataMember]
        public string CouponCode { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public decimal? Discount { get; set; }
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public string UserPhone { get; set; }
        [DataMember]
        public string DeliveryAddress { get; set; }
        [DataMember]
        public string DeliveryZip { get; set; }
        [DataMember]
        public string DeliveryTel { get; set; }
        [DataMember]
        public string DeliveryName { get; set; }
        [DataMember]
        public string DeliveryEmail { get; set; }
        [DataMember]
        public string DeliveryCity { get; set; }
        [DataMember]
        public string DeliveryState { get; set; }
        [DataMember]
        public string DeliveryCountry { get; set; }
        [DataMember]
        public string BillingAddress { get; set; }
        [DataMember]
        public string BillingZip { get; set; }
        [DataMember]
        public string BillingTel { get; set; }
        [DataMember]
        public string BillingName { get; set; }
        [DataMember]
        public string BillingEmail { get; set; }
        [DataMember]
        public string BillingCity { get; set; }
        [DataMember]
        public string BillingState { get; set; }
        [DataMember]
        public string BillingCountry { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public Int64? CreatedBy { get; set; }
        [DataMember]
        public bool? IsDeleted { get; set; }
        [DataMember]
        public bool? IsApprovedByAdmin { get; set; }

    }

    public class OrdersProducts
    {
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public Int64 AddressId { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public Int64 Quantity { get; set; }
    }

    public class Images
    {
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public Int64 Id { get; set; }
    }

    public class ImagesDataContract
    {
        [DataMember]
        public List<Images> lst_Images { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class GetImagesDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public string Type { get; set; }
    }

    public class BookingConfirmationDataContract
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string UserMessage { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public Int64 BusinessId { get; set; }
    }

    public class CategoryFilterDataContract
    {
        [DataMember]
        public string Type { get; set; }
    }

    public class SubCategoryFilterDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }
    }

    public class CouponListDataContract
    {
        [DataMember]
        public List<CouponDataContract> Lst_Coupons { get; set; }
        [DataMember]
        public List<HomeSliderDataContract> lst_Slider { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class BusinessListDataContract
    {
        [DataMember]
        public List<BusinessDataContract> Lst_Business { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class HomeSliderListDataContract
    {
        [DataMember]
        public List<HomeSliderDataContract> Lst_Slider { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class ProductListDataContract
    {
        [DataMember]
        public List<ProductDataContract> Lst_Products { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class CategoryListDataContract
    {
        [DataMember]
        public List<CategoryDataContract> Lst_Category { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class SubCategoryListDataContract
    {
        [DataMember]
        public List<SubCategoryDataContract> Lst_SubCategory { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class CityListDataContract
    {
        [DataMember]
        public List<CityDataContract> Lst_City { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class CityDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public string CityName { get; set; }
    }

    public class OrdersListDataContract
    {
        [DataMember]
        public List<OrdersProducts> Lst_Orders { get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class AddressListDataContract
    {
        [DataMember]
        public List<OrderDataContract> Lst_Address{ get; set; }
        [DataMember]
        public string Result { get; set; }
    }

    public class PagingDataContract
    {
        [DataMember]
        public int Counter { get; set; }
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public Int64 AddressId { get; set; }
        [DataMember]
        public Int64 CityId { get; set; }
        [DataMember]
        public Int64 SelectedPosition { get; set; }
        [DataMember]
        public Int64 CategoryId { get; set; }
        [DataMember]
        public Int64 SubCategoryId { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Keyword { get; set; }
    }

    public class OrderParameterDataContract
    {
        [DataMember]
        public int Counter { get; set; }
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
    }

 

    public class AddressParameterDataContract
    {
        [DataMember]
        public Int64 AddressId { get; set; }
    }

    public class ChangePasswordDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string OldPassword { get; set; }
        [DataMember]
        public string NewPassword { get; set; }
    }
    public class ProfileDataContract
    {
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public bool ImageChange { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
    }

    public class ListingByDistanceDataContract
    {
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public long ListingID { get; set; }

        [DataMember]
        public long CategoryID { get; set; }


        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
    public class ListingByDistanceDataBindingModel
    {
   public string latitude{get;set;}
        public string longitude{get;set;} 
        public long cityID{get;set;}
        public decimal distance{get;set;}
        public int type{get;set;}
    }

   
    public class ListingByDistanceWithMultiPolygonDataBindingModel

    {
        public List<string> lst_longLat { get; set; }
        //public long cityID { get; set; }
        //public decimal distance { get; set; }
        public int type { get; set; }
    }
}
