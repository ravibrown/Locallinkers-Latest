using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["YourAppUserLogin"] != null)
                {
                    string username = Request.Cookies["YourAppUserLogin"].Values["username"];
                    string password = Request.Cookies["YourAppUserLogin"].Values["password"];
                    txtPhoneNumber.Text = username;
                    txtPassword.Attributes.Add("value", password);
                }
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.PhoneNumber = txtPhoneNumber.Text;
            log.Password = ClsCommon.Encode(txtPassword.Text);
            if (log.PhoneNumber != "" && log.Password != "")
            {
                bool flag = log.IsAunthenticate();
                if (flag && log.RoleId!=(int)ClsLogin.Role.Admin)
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

                        if (chkRemember.Checked)
                        {
                            HttpCookie cookie = new HttpCookie("YourAppUserLogin");
                            cookie.Values.Add("username", txtPhoneNumber.Text);
                            cookie.Values.Add("password", txtPassword.Text);
                            cookie.Expires = DateTime.Now.AddYears(1);
                            Response.Cookies.Add(cookie);
                        }

                        if (Request.QueryString["ReturnUrl"] != null)
                        {
                            Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
                        }
                        else
                        {
                            Response.Redirect("/Index");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentials.');</script>");
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
        protected void btnForget_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.PhoneNumber = txtForgetPhoneNumber.Text;
            log.IsDeleted = false;
            log.RoleId = 0;
            log.GetRecord();
            if (log.DataRecieved && log.RoleId != (int)ClsLogin.Role.Admin)
            {
                log.VerificationCode=ClsCommon.NewVerificationCode().Substring(0,6);
                log.Edit();
                ClsCommon.SendCodeThroughSms(log.PhoneNumber, log.VerificationCode + ClsCommon.ForgetPasswordMessage);
                Response.Write("<script>alert('Please check your phone and put otp here.');</script>");
                divLogin.Style.Add("display", "none !important");
                divForget.Style.Add("display", "none !important");
                divOTP.Style.Add("display", "block !important");
                txtForgetPhoneNumber.Text = "";
            }
            else
            {
                Response.Write("<script>alert('User not exist.');</script>");
                divLogin.Style.Add("display", "none !important");
                divOTP.Style.Add("display", "none !important");
                divForget.Style.Add("display", "block !important");
            }
        }

        protected void btnOTP_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.PhoneNumber = txtOTPPhoneNumber.Text;
            log.IsDeleted = false;
            //log.RoleId = 0;
            //log.GetRecord();
            if (log.IsAunthenticate()&& log.RoleId != (int)ClsLogin.Role.Admin)
            {
                if (log.VerificationCode.Trim() == txtOTP.Text.Trim())
                {
                    Response.Redirect("/ChangePassword?id=" + log.UniqueId);
                }
                else
                {
                    Response.Write("<script>alert('Invalid Code.');</script>");
                    divLogin.Style.Add("display", "none !important");
                    divForget.Style.Add("display", "none !important");
                    divOTP.Style.Add("display", "block !important");
                }
            }
            else
            {
                Response.Write("<script>alert('Phone Number Not Exits.');</script>");
                divLogin.Style.Add("display", "none !important");
                divForget.Style.Add("display", "none !important");
                divOTP.Style.Add("display", "block !important");
            }
        }
        
    }
}