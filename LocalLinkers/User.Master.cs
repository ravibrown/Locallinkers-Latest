using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            if (!ClsCommon.GetSession())
            {
                Response.Redirect("/Login?ReturnUrl=" + url);
            }
            else if (ClsCommon.RoleId == (int)ClsLogin.Role.Admin)
            {
                Response.Redirect("/Login?ReturnUrl=" + url);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}