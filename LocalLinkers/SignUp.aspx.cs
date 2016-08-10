using DataAccess.Classes;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["code"]!=null)
                {
                    OTPPanel.Visible = true;
                    RegisterPanel.Visible = false;
                    CheckOtp();
                }
                else
                {
                    OTPPanel.Visible = false;
                    RegisterPanel.Visible = true;
                }
            }
        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClsLogin obj = new ClsLogin();
                obj.PhoneNumber = txtPhoneNumber.Text;
                obj.IsDeleted = false;
                obj.RoleId = (int)ClsLogin.Role.User;
                obj.GetRecord();
                if (!obj.DataRecieved)
                {
                    ClsLogin objEmail = new ClsLogin();
                    if (txtEmail.Text != "")
                    {
                        objEmail.Email = txtEmail.Text;
                        objEmail.IsDeleted = false;
                        objEmail.RoleId = (int)ClsLogin.Role.User;
                        objEmail.GetRecord();
                    }
                    if (!objEmail.DataRecieved)
                    {
                        obj.Password = txtPassword.Text;
                        obj.Email = txtEmail.Text;
                        obj.PlatForm = "Web";
                        obj.VerificationCode = ClsCommon.NewVerificationCode().Substring(0, 6);
                        obj.UniqueId = ClsCommon.CreateUniqueId();
                        obj.Add();
                        if (obj.DataRecieved)
                        {
                            string messagesignup = ClsCommon.SignUpMessage;
                            messagesignup = messagesignup.ToString().Replace("##OTP##", obj.VerificationCode);
                            ClsCommon.SendCodeThroughSms(obj.PhoneNumber, messagesignup);
                            if (obj.Email != "")
                            {
                                string host = HttpContext.Current.Request.Url.Host;
                                var callBackUrl = host + "/SignUp?code=" + obj.VerificationCode;
                                //SendGridMessage message = new SendGridMessage();
                                //message.AddTo(obj.Email);
                                //message.From = new MailAddress(obj.Email, ClsCommon.SiteName);
                                //message.Subject = ClsCommon.EmailRegisterSubject;
                                //message.Html = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.EmailRegisterBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";

                                //bool ret = ClsCommon.SendGrid(message);
                                EmailMessage message = new EmailMessage();
                                message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + messagesignup + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";
                                message.Subject = ClsCommon.EmailRegisterSubject;
                                message.To = obj.Email;
                                bool ret = ClsCommon.SendEmail(message);
                            }
                        }
                        OTPPanel.Visible = true;
                        RegisterPanel.Visible = false;
                        txtOTPPhoneNumber.Text = obj.PhoneNumber;
                        ResetAll();
                        Response.Write("<script>alert('Please check your email or phone and fill otp here.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Email Already Exist');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Phone Number Already Exist');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnOTP_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClsLogin obj = new ClsLogin();
                obj.PhoneNumber = txtOTPPhoneNumber.Text;
                obj.VerificationCode = txtOTP.Text;
                obj.IsDeleted = false;
                obj.GetRecord();
                if (obj.DataRecieved)
                {
                    obj.IsApprovedByAdmin = true;
                    obj.Edit();
                    ClsUserPoints points = new ClsUserPoints();
                    points.UserId = obj.Id;
                    points.Points = 10;
                    points.IsApprovedByAdmin = true;
                    points.Add();
                    Response.Redirect("/Login");
                }
                else
                {
                    Response.Write("<script>alert('OTP is incorrect.');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CheckOtp()
        {
            try
            {
                ClsLogin obj = new ClsLogin();
                obj.VerificationCode = Request.QueryString["code"].ToString();
                obj.IsDeleted = false;
                obj.GetRecord();
                if (obj.DataRecieved)
                {
                    obj.IsApprovedByAdmin = true;
                    obj.Edit();
                    ClsUserPoints points = new ClsUserPoints();
                    points.UserId = obj.Id;
                    points.Points = 10;
                    points.IsApprovedByAdmin = true;
                    points.Add();
                    string messageverified = ClsCommon.VerifiedMessage;
                    ClsCommon.SendCodeThroughSms(obj.PhoneNumber, messageverified);
                    if (obj.Email != "")
                    {
                        string host = HttpContext.Current.Request.Url.Host;
                        //SendGridMessage message = new SendGridMessage();
                        //message.AddTo(obj.Email);
                        //message.From = new MailAddress(obj.Email, ClsCommon.SiteName);
                        //message.Subject = ClsCommon.EmailRegisterSubject;
                        //message.Html = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.EmailRegisterBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";

                        //bool ret = ClsCommon.SendGrid(message);
                        EmailMessage message = new EmailMessage();
                        message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + messageverified;
                        message.Subject = ClsCommon.EmailRegisterSubject;
                        message.To = obj.Email;
                        bool ret = ClsCommon.SendEmail(message);
                    }
                    Response.Redirect("/Login");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void ResetAll()
        {
            txtPhoneNumber.Text = "";
            txtOTP.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
        }
    }
}