using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string a=ClsCommon.Encode("admin@123");
            //string b = a;
            if (!IsPostBack)
            {
                if (Request.Cookies["YourAppLogin"] != null)
                {
                    string username = Request.Cookies["YourAppLogin"].Values["username"];
                    string password = Request.Cookies["YourAppLogin"].Values["password"];
                    txtUserName.Text = username;
                    txtPassword.Attributes.Add("value", password);
                }
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.UserName = txtUserName.Text;
            log.Password = ClsCommon.Encode(txtPassword.Text);
            log.RoleId = (int)ClsLogin.Role.Admin;
            if (log.UserName != "" && log.Password != "")
            {
                bool flag = log.IsAunthenticate();
                if (flag)
                {
                    ClsCommon.UserId = log.Id;
                    ClsCommon.UserName = log.UserName;
                    ClsCommon.RoleId = Convert.ToInt32(log.RoleId);
                    bool SetSession = ClsCommon.SetSession();

                    if (SetSession)
                    {

                        if (chkRember.Checked)
                        {
                            HttpCookie cookie = new HttpCookie("YourAppLogin");
                            cookie.Values.Add("username", txtUserName.Text);
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
                            Response.Redirect("/Admin/Category");
                        }
                    }

                }
                else
                {
                    lblErrorMsg.Text = "Invalid Credentials!";
                    alertDanger.Style.Add("display", "block !important");
                    ResetAll();
                }
            }
            else
            {
                lblErrorMsg.Text = "Please enter username and password!";
                alertDanger.Style.Add("display", "block !important");
            }

        }

        protected void btnForget_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.Email = txtEmail.Text;
        }

        public void ResetAll()
        {
            txtPassword.Attributes.Add("value", "");
            txtUserName.Text = "";
            txtEmail.Text = "";
            chkRember.Checked = false;
        }
    }
}