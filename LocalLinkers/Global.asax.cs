using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel;
using System.ServiceModel.Activation;
using LocalLinkers.ServiceImplementation;
using LocalLinkers.ServiceContract;
using System.Web;

namespace LocalLinkers
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            RouteTable.Routes.Add(new ServiceRoute("api/User", new WebServiceHostFactory(), typeof(LocalLinkers.ServiceImplementation.LoginService)));
            RouteTable.Routes.Add(new ServiceRoute("api/v2/User", new WebServiceHostFactory(), typeof(LocalLinkers.ServiceImplementation.LoginServiceV2)));
            RouteTable.Routes.MapPageRoute("AdminCategoryRoute", "Admin/Category", "~/Admin/Category.aspx");
            RouteTable.Routes.MapPageRoute("AdminCouponsRoute", "Admin/Coupons", "~/Admin/Coupons.aspx");
            RouteTable.Routes.MapPageRoute("AdminDeactivateCouponsRoute", "Admin/DeactivateCoupons", "~/Admin/DeactivateCoupons.aspx");
            RouteTable.Routes.MapPageRoute("AdminProductsRoute", "Admin/Products", "~/Admin/Products.aspx");
            RouteTable.Routes.MapPageRoute("AdminBusinessRoute", "Admin/Business", "~/Admin/Business.aspx");
            RouteTable.Routes.MapPageRoute("AdminDeactivateBusinessRoute", "Admin/DeactivateBusiness", "~/Admin/DeactivateBusiness.aspx");
            RouteTable.Routes.MapPageRoute("AdminUserBusinessRoute", "Admin/UserBusiness", "~/Admin/UserBusiness.aspx");
            RouteTable.Routes.MapPageRoute("AdminLoginRoute", "Admin/Login", "~/Admin/Login.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateRoute", "Admin/Template", "~/Admin/Template.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateContactRoute", "Admin/TemplateContact", "~/Admin/TemplateContact.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateAboutUsRoute", "Admin/TemplateAboutUs", "~/Admin/TemplateAboutUs.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateSliderRoute", "Admin/TemplateSlider", "~/Admin/TemplateSlider.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateGalleryRoute", "Admin/TemplateGallery", "~/Admin/TemplateGallery.aspx");
            RouteTable.Routes.MapPageRoute("AdminTemplateServicesRoute", "Admin/TemplateServices", "~/Admin/TemplateServices.aspx");
            RouteTable.Routes.MapPageRoute("AdminHomeSliderRoute", "Admin/HomeSlider", "~/Admin/HomeSlider.aspx");
            RouteTable.Routes.MapPageRoute("AdminOrdersRoute", "Admin/Orders", "~/Admin/Orders.aspx");
            RouteTable.Routes.MapPageRoute("AdminOrdersProductsRoute", "Admin/OrdersProducts", "~/Admin/OrdersProducts.aspx");

            RouteTable.Routes.MapPageRoute("ContactUsRoute", "contactus", "~/contactus.aspx");
            RouteTable.Routes.MapPageRoute("aboutusRoute", "aboutus", "~/aboutus.aspx");
            RouteTable.Routes.MapPageRoute("termsRoute", "terms", "~/terms.aspx");
            RouteTable.Routes.MapPageRoute("privacypolicyRoute", "privacypolicy", "~/privacypolicy.aspx");
            RouteTable.Routes.MapPageRoute("ChangePasswordRoute", "ChangePassword", "~/ChangePassword.aspx");
            RouteTable.Routes.MapPageRoute("ChangeUserPasswordRoute", "ChangeUserPassword", "~/ChangeUserPassword.aspx");
            RouteTable.Routes.MapPageRoute("TemplateLadyBirdRoute", "Template/LadyBird/LadyBird", "~/Template/LadyBird/LadyBird.aspx");
            RouteTable.Routes.MapPageRoute("TemplateHoneydewRoute", "Template/Honeydew/Honeydew", "~/Template/Honeydew/Honeydew.aspx");
            RouteTable.Routes.MapPageRoute("TemplateLambkinRoute", "Template/Lambkin/Lambkin", "~/Template/Lambkin/Lambkin.aspx");
            RouteTable.Routes.MapPageRoute("TemplateParamourRoute", "Template/Paramour/Paramour", "~/Template/Paramour/Paramour.aspx");
            RouteTable.Routes.MapPageRoute("IndexRoute", "Index", "~/Index.aspx");
            RouteTable.Routes.MapPageRoute("SignUpRoute", "SignUp", "~/SignUp.aspx");
            RouteTable.Routes.MapPageRoute("CategoryRoute", "Category", "~/Category.aspx");
            RouteTable.Routes.MapPageRoute("ProductsRoute", "Products", "~/Products.aspx");
            RouteTable.Routes.MapPageRoute("AllCouponsRoute", "AllCoupons", "~/AllCoupons.aspx");
            RouteTable.Routes.MapPageRoute("LoginRoute", "Login", "~/Login.aspx");
            RouteTable.Routes.MapPageRoute("ResetPasswordRoute", "ResetPassword", "~/ResetPassword.aspx");
            RouteTable.Routes.MapPageRoute("CouponDetailRoute", "CouponDetail/{Id}/{Title}", "~/CouponDetail.aspx");
            RouteTable.Routes.MapPageRoute("ProductDetailRoute", "ProductDetail/{Id}/{Title}", "~/ProductDetail.aspx");
            RouteTable.Routes.MapPageRoute("BusinessRoute", "Business/{Id}/{Title}", "~/Business.aspx");
            RouteTable.Routes.MapPageRoute("SingleBusinessRoute", "Business", "~/Business.aspx");
            RouteTable.Routes.MapPageRoute("CartRoute", "Cart", "~/Cart.aspx");
            RouteTable.Routes.MapPageRoute("CancelRoute", "Cancel", "~/Cancel.aspx");
            RouteTable.Routes.MapPageRoute("CouponConfirmationRoute", "verify", "~/CouponConfirmation.aspx");
            RouteTable.Routes.MapPageRoute("ThankYouRoute", "ThankYou", "~/ThankYou.aspx");
            RouteTable.Routes.MapPageRoute("ProfileRoute", "Profile", "~/Profile.aspx");
            RouteTable.Routes.MapPageRoute("MyOrdersRoute", "MyOrders", "~/MyOrders.aspx");
            RouteTable.Routes.MapPageRoute("CashBackCreditsRoute", "CashBackCredits", "~/CashBackCredits.aspx");
            RouteTable.Routes.MapPageRoute("AddBusinessRoute", "MyBusiness", "~/AddBusiness.aspx");
            RouteTable.Routes.MapPageRoute("MyCouponsRoute", "MyCoupons", "~/MyCoupons.aspx");
        }

        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            var host = FirstRequestInitialisation.Initialise(app.Context);
        }

        static class FirstRequestInitialisation
        {
            private static string host = null;
            private static Object s_lock = new Object();

            // Initialise only on the first request
            public static string Initialise(HttpContext context)
            {
                if (string.IsNullOrEmpty(host))
                {
                    lock (s_lock)
                    {
                        if (string.IsNullOrEmpty(host))
                        {
                            var uri = context.Request.Url;
                            host = uri.GetLeftPart(UriPartial.Authority);
                        }
                    }
                }
                return host;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}