using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class CouponConfirmation : System.Web.UI.Page
    {
        public static int UserId = 0;
        public static string CouponTitle = "";
        public static string UserBusinessName = "";
        public static string  Coupon = "";
        public static bool IsCouponActivated = false;
        protected void Page_Init(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath;            
            if (!ClsCommon.GetSession())
            {
                divLogin.Visible = true;
            }
            else
            {
                divLogin.Visible = false;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Code"] != null)
                {
                    DirectActivateCoupon(Request.QueryString["Code"].ToString().Trim());
                }
            }
        }
       
        protected void btnCouponCode_OnClick(object sender, EventArgs e)
        {
            if (!ClsCommon.GetSession())
            {
                Login();
            }
            else
            {
                bool flag = ActivateCoupon(txtCouponCode.Text.Trim());
                if (flag)
                {
                    ClsLogin log = new ClsLogin();
                    log.Id = UserId;
                    log.RoleId = 0;
                    log.GetRecord();
                    if(log.DataRecieved)
                    {
                        string messagecoupon = ClsCommon.CouponVerifyMessage;
                        messagecoupon = messagecoupon.ToString().Replace("##CouponTitle##", CouponTitle);
                        messagecoupon = messagecoupon.ToString().Replace("##BusinessName##", UserBusinessName);
                        messagecoupon = messagecoupon.ToString().Replace("&", "and");
                        ClsCommon.SendCodeThroughSms(log.PhoneNumber, messagecoupon);
                    }
                    Response.Write("<script>alert('Coupon Activated.');window.location.href='/Index';</script>");
                }
                else
                {
                    if (IsCouponActivated)
                    {
                        Response.Write("<script>alert('This coupon has expired or has already been activated.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Coupon Code');</script>");
                    }
                }
            }
        }

        public void Login()
        {
            ClsLogin log = new ClsLogin();
            log.PhoneNumber = txtPhoneNumber.Text;
            log.Password = ClsCommon.Encode(txtPassword.Text);
            log.IsDeleted = false;
            log.IsApproved = (int)ClsLogin.BooleanValues.Approved;
            if (log.PhoneNumber != "" && log.Password != "")
            {
                bool flag = log.IsAunthenticate();
                if (flag && log.RoleId != (int)ClsLogin.Role.Admin)
                {
                    if (ActivateCoupon(txtCouponCode.Text.Trim()))
                    {
                        ClsCommon.UserId = log.Id;
                        if (log.PhoneNumber != null)
                        {
                            ClsCommon.PhoneNumber = log.PhoneNumber;
                        }
                        else
                        {
                            ClsCommon.PhoneNumber = "";
                        }
                        if (log.UserName != null)
                        {
                            ClsCommon.UserName = log.UserName;
                        }
                        else
                        {
                            ClsCommon.UserName = "";
                        }
                        if (log.Email != null)
                        {
                            ClsCommon.UserEmail = log.Email;
                        }
                        else
                        {
                            ClsCommon.UserEmail = "";
                        }
                        if (log.RoleId != null)
                        {
                            ClsCommon.RoleId = Convert.ToInt32(log.RoleId);
                        }
                        else
                        {
                            ClsCommon.RoleId = 0;
                        }
                        if (log.Image != null)
                        {
                            ClsCommon.UserImage = log.Image;
                        }
                        else
                        {
                            ClsCommon.UserImage = "";
                        }

                        bool SetSession = ClsCommon.SetSession();

                        if (SetSession)
                        {
                            ClsLogin log1 = new ClsLogin();
                            log1.Id = UserId;
                            log1.RoleId = 0;
                            log1.GetRecord();
                            if (log1.DataRecieved)
                            {
                                string messagecoupon = ClsCommon.CouponVerifyMessage;
                                messagecoupon = messagecoupon.ToString().Replace("##CouponTitle##", CouponTitle);
                                messagecoupon = messagecoupon.ToString().Replace("##BusinessName##", UserBusinessName);
                                messagecoupon = messagecoupon.ToString().Replace("&", "and");
                                ClsCommon.SendCodeThroughSms(log1.PhoneNumber, messagecoupon);
                            }
                            Response.Write("<script>alert('Coupon Activated.');window.location.href='/Index';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid Credentials.');</script>");
                        }
                    }
                    else
                    {
                        if (IsCouponActivated)
                        {
                            Response.Write("<script>alert('This coupon has expired or has already been activated.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid Coupon Code');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter phone number and password.');</script>");
            }
        }

        public bool ActivateCoupon(string CouponCode)
        {
            try
            {
                ClsOrderMapping obj = new ClsOrderMapping();
                obj.CouponCode = CouponCode;
                Coupon = CouponCode;
                obj.IsDeleted = false;
                obj.Type = "Coupon";
                obj.GetRecord();
                if (obj.DataRecieved)
                {
                    ClsOrderDetails ord = new ClsOrderDetails();
                    ord.Id = Convert.ToInt64(obj.ProductId);
                    ord.GetRecord();
                    if(obj.IsApprovedByAdmin)
                    {
                        IsCouponActivated = true;                        
                        return false;
                    }
                    else if (ord.DataRecieved && (ord.PhoneNumber.Trim() == ClsCommon.PhoneNumber.Trim()))
                    {
                        CouponTitle = ord.Title;
                        UserBusinessName = ord.BusinessName;
                        obj.IsApprovedByAdmin = true;
                        obj.Edit();
                        UserId = Convert.ToInt32(obj.UserId);
                        return true;
                    }
                    else if (ord.DataRecieved && (ord.PhoneNumber.Trim() == txtPhoneNumber.Text.Trim()))
                    {
                        CouponTitle = ord.Title;
                        UserBusinessName = ord.BusinessName;
                        obj.IsApprovedByAdmin = true;
                        obj.Edit();
                        UserId = Convert.ToInt32(obj.UserId);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DirectActivateCoupon(string CouponCode)
        {
            try
            {
                ClsOrderMapping obj = new ClsOrderMapping();
                obj.CouponCode = CouponCode;
                Coupon = CouponCode;
                obj.IsDeleted = false;
                obj.Type = "Coupon";
                obj.GetRecord();
                if (obj.DataRecieved)
                {
                    ClsOrderDetails ord = new ClsOrderDetails();
                    ord.Id = Convert.ToInt64(obj.ProductId);
                    ord.GetRecord();
                    if (obj.IsApprovedByAdmin)
                    {
                        Response.Write("<script>alert('This coupon has expired or has already been activated.');</script>");
                    }
                    else if (ord.DataRecieved && (ord.PhoneNumber.Trim() == ClsCommon.PhoneNumber.Trim()))
                    {
                        CouponTitle = ord.Title;
                        UserBusinessName = ord.BusinessName;
                        obj.IsApprovedByAdmin = true;
                        obj.Edit();
                        UserId = Convert.ToInt32(obj.UserId);
                        Response.Write("<script>alert('Coupon Activated.');window.location.href='/Index';</script>");
                    }
                    else if (ord.DataRecieved && (ord.PhoneNumber.Trim() == txtPhoneNumber.Text.Trim()))
                    {
                        CouponTitle = ord.Title;
                        UserBusinessName = ord.BusinessName;
                        obj.IsApprovedByAdmin = true;
                        obj.Edit();
                        UserId = Convert.ToInt32(obj.UserId);
                        Response.Write("<script>alert('Coupon Activated.');window.location.href='/Index';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Coupon Code');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Coupon Code');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error! Try Again Later');</script>");
            }
        }
    }
}