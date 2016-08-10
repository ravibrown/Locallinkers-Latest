using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["id"]==null)
                {
                    Response.Redirect("/Index");
                }
            }
        }

        protected void btnForget_OnClick(object sender, EventArgs e)
        {
            ClsLogin log = new ClsLogin();
            log.UniqueId = Request.QueryString["id"].ToString();
            log.IsDeleted = false;
            log.GetRecord();
            if(log.DataRecieved)
            {
                log.Password = txtPassword.Text;
                log.Edit();
                Response.Write("<script>alert('Successully Updated');</script>");
            }
        }
    }
}