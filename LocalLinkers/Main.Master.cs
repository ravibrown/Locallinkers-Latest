using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LocalLinkers
{
    public partial class Main : System.Web.UI.MasterPage
    {


        public static int CouponCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           // GoToMobileAppLink();
            BindCartCount();

            if (!IsPostBack)
            {
                if (ClsCommon.GetSession())
                {
                    CheckCouponCount();
                }
                BindCities();
            }
        }
        public void GoToMobileAppLink()
        {
            string strUserAgent = HttpContext.Current.Request.UserAgent.ToString().ToLower();
            bool MobileDevice = HttpContext.Current.Request.Browser.IsMobileDevice;

            if (strUserAgent != null)
            {
                //EmailMessage emailMessage=new EmailMessage();
                //emailMessage.To="ravi@impact-works.com";
                //emailMessage.Subject = "Mobile useragent";
                //emailMessage.Message = strUserAgent;
                //ClsCommon.SendEmail(emailMessage);
                // if (MobileDevice == true || strUserAgent.Contains("iphone") || strUserAgent.Contains("blackberry") ||
                //     strUserAgent.Contains("mobile") || strUserAgent.Contains("webOS") ||
                //strUserAgent.Contains("IEMobile") || strUserAgent.Contains("android") || strUserAgent.Contains("windows ce") 
                //|| strUserAgent.Contains("opera mini") || strUserAgent.Contains("palm"))
                if (strUserAgent.Contains("iphone")||strUserAgent.Contains("ipad"))
                {
                    Response.Redirect(ClsCommon.IphoneAppUrl);
                }
                else if (strUserAgent.Contains("android"))
                {
                    Response.Redirect(ClsCommon.AndroidAppUrl);
                }
            }


        }
        public void CheckCouponCount()
        {
            ClsCoupons coup = new ClsCoupons();
            coup.IsDeleted = false;
            coup.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
            coup.PhoneNumber = ClsCommon.PhoneNumber;
            List<ClsCoupons> lst = coup.GetAll();
            if (lst != null && lst.Count > 0)
            {
                CouponCount = 1;
            }
        }
        public void BindCartCount()
        {
            if (Session["OrderList"] != null)
            {
                lblcarttotal.InnerHtml = ((List<DataAccess.Classes.ClsPropOrderList>)Session["OrderList"]).Count.ToString() + " Items";
            }
            else
            {
                lblcarttotal.InnerHtml = "0 Items";
            }
        }
        public void BindCities()
        {
            ClsCoupons city = new ClsCoupons();
            rptCities.DataSource = city.GetAllCities();
            rptCities.DataBind();
            if (Session["SelectedCity"] != null)
            {
                lblSelectedCity.Text = Session["SelectedCity"].ToString();

            }
            else
            {
                lblSelectedCity.Text = ClsCommon.DefaultSelectedCityName;
                Session["SelectedCity"] = ClsCommon.DefaultSelectedCityName;
                Session["SelectedCityId"] = ClsCommon.DefaultSelectedCity;
                var latlong = ClsCommon.GetLatLongByCityID(ClsCommon.DefaultSelectedCity);
                HttpContext.Current.Session["Latitude"] = latlong.Latitude;
                HttpContext.Current.Session["Longitude"] = latlong.Longitude;
            }
            
        }
    }
}