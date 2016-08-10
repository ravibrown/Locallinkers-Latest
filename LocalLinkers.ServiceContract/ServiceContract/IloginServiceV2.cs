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

    public interface ILoginServiceV2
    {

        [WebInvoke(UriTemplate = "CheckVerificationCode", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Verification Code Check")]
        LoginResultDataContract CheckVerificationCode(OTPDataContract data);

        [WebInvoke(UriTemplate = "SubCategoryList?categoryId={categoryId}&type={type}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Get SubCategory List which have data")]
        SubCategoryListDataContract SubCategoryList(long categoryId, string type);

        [WebInvoke(UriTemplate = "CheckCouponValidation?UserId={userid}&CouponId={couponid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(FaultException))]
        [Description("Check Coupon Is Already Purchased Or Not")]
        ResultDataContract CheckCouponValidation(long userid, long couponid);

    }
}
