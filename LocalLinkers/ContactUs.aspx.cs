using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = "Hi <br/>Name: " + name.Value + "<br/>Email:" + email.Value + "<br/>Phone: " + phone.Value + "<br/>Message: " + message.Value + "";
            emailMessage.Subject = ClsCommon.SubjectContactUs;
            emailMessage.To = "contact@locallinkers.com"; //ClsCommon.FromEmail;
            bool ret = ClsCommon.SendEmail(emailMessage);
            if (ret)
            {
                name.Value = "";
                email.Value = "";
                phone.Value = "";
                message.Value = "";
                Response.Write("<script>alert('Thanks for contacting us.')</script>");
            }
            else { Response.Write("<script>alert('Something went wrong.Please try again later.')</script>"); }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            Page.ClientScript.RegisterForEventValidation(btnSubmit.UniqueID);
            base.Render(writer);
        }
    }
}