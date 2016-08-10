using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using LocalLinkers.DataContract;

namespace LocalLinkers.ServiceContract
{
    [ServiceContract]

    public interface ILoginService
    {
        [WebInvoke(UriTemplate = "AddUser", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Add User")]

        ResultDataContract AddUser(SignUpDataContract data);

        [WebInvoke(UriTemplate = "Login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("User Login")]

        LoginResultDataContract Login(LoginDataContract data);

        [WebInvoke(UriTemplate = "CheckVerificationCode", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Verification Code Check")]
        LoginResultDataContract CheckVerificationCode(VerificationDataContract data);

      

        [WebInvoke(UriTemplate = "ResendVerificationCode", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Verification Code Resend")]

        VerificationResultDataContract ResendVerificationCode(VerificationByPhoneNumberDataContract data);

        [WebInvoke(UriTemplate = "ResetPassword", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Reset New Password")]

        ResultDataContract ResetPassword(ResetPasswordDataContract data);

        [WebInvoke(UriTemplate = "ForgotPassword", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("If User Forgot Password")]
        VerificationResultDataContract ForgetPassword(ForgetInputDataContract data);
       

        [WebInvoke(UriTemplate = "ChangePassword", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("If User Want To Change Password")]
        ResultDataContract ChangePassword(ChangePasswordDataContract data);


        [WebInvoke(UriTemplate = "EditProfile", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Edit User Details")]
        ResultDataContractWithUserImage EditProfile(ProfileDataContract data);

        [WebInvoke(UriTemplate = "CouponsList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]        
        [FaultContract(typeof(FaultException))]
        [Description("List of All Coupons")]
        CouponListDataContract CouponsList(PagingDataContract data);

        [WebInvoke(UriTemplate = "BusinessList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All Business")]

        BusinessListDataContract BusinessList(PagingDataContract data);

        [WebInvoke(UriTemplate = "ProductList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All Products")]

        ProductListDataContract ProductList(PagingDataContract data);

        [WebInvoke(UriTemplate = "CategoryList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All Categories")]

        CategoryListDataContract CategoryList(CategoryFilterDataContract data);

        [WebInvoke(UriTemplate = "SuCategoryList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of Sub Categories by CategoryId")]

        SubCategoryListDataContract SubCategoryList(SubCategoryFilterDataContract data);

        [WebInvoke(UriTemplate = "CityList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All cities")]

        CityListDataContract CityList();

        [WebInvoke(UriTemplate = "OrdersList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All orders")]

        OrdersListDataContract OrdersList(OrderParameterDataContract data);

        [WebInvoke(UriTemplate = "AddressList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("List of All Addresses")]

        AddressListDataContract AddressList(AddressParameterDataContract data);

        [WebInvoke(UriTemplate = "BusinessBooking", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Book Business")]

        ResultDataContract ConfirmBusinessBooking(BookingConfirmationDataContract data);

        [WebInvoke(UriTemplate = "HomeSlider", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Home Slider")]

        HomeSliderListDataContract HomeSlider();

        [WebInvoke(UriTemplate = "GetUserPoints", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get User Points")]

        PointsResultDataContract GetUserPoints(PointsDataContract data);

        [WebInvoke(UriTemplate = "GetImagesByType", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get Images By Type")]

        ImagesDataContract GetImagesByType(GetImagesDataContract data);

        [WebInvoke(UriTemplate = "GetListingsByDistance", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get Listing By Distance")]
        List<ListingByDistanceDataContract> GetListingsByDistance(ListingByDistanceDataBindingModel model);

        [WebInvoke(UriTemplate = "GetCouponListingsByDistance", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get Coupon Listing By Distance")]
        CouponListDataContract GetCouponListingsByDistance(ListingByDistanceDataBindingModel model);

        [WebInvoke(UriTemplate = "GetCouponListingsByMultiPolygon", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get Coupon Listing By MultiPolygon")]
        CouponListDataContract GetCouponListingsByMultiPolygon(ListingByDistanceWithMultiPolygonDataBindingModel model);
    }
}
