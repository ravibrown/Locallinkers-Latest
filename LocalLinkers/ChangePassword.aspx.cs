using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("/Admin/Login");
                }
            }
        }
        protected void btnChangePassword_OnClick(object sender, EventArgs e)
        {
            ClsLogin obj = new ClsLogin();
            if (Request.QueryString["id"] != null)
            {
                obj.UniqueId = Request.QueryString["id"].ToString();
                bool flag = obj.IsAunthenticate();
                if (flag)
                {
                    obj.Password = txtPassword.Text.Trim();
                    obj.Edit();
                    if (obj.RoleId == (int)ClsLogin.Role.Admin)
                    {
                        Response.Redirect("/Admin/Login");
                    }
                    else
                    {
                        Response.Redirect("/Login");
                    }
                }
            }

        }
    }
}