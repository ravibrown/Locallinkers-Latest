using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class ChangeUserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
               

                if (HttpContext.Current.Session["UserId"] != null)
                {
                    ClsLogin log = new ClsLogin();
                    log.Id = Convert.ToInt64(Session["UserId"]);

                    //log.RoleId = ClsCommon.RoleId;
                    //log.IsDeleted = false;
                    //log.IsApproved = (int)ClsLogin.BooleanValues.Approved;
                    log.GetUserByID(log.Id);
                    if (log.DataRecieved)
                    {
                        if (log.Password.Trim() == txtOldPassword.Text.Trim())
                        {
                            log.Password = txtNewPassword.Text;
                            log.Edit();
                            lblSuccessMsg.Text = "Password changed successfully";
                            alertSuccess.Style.Add("display", "block !important");
                            alertDanger.Style.Add("display", "none !important");
                            ResetAll();
                        }
                        else
                        {
                            lblErrorMsg.Text = "Old password is incorrect.";
                            alertDanger.Style.Add("display", "block !important");
                            alertSuccess.Style.Add("display", "none !important");
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "User Not Exist.";
                        alertDanger.Style.Add("display", "block !important");
                        alertSuccess.Style.Add("display", "none !important");
                        ResetAll();
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Your session has been expired. Please login again.";
                    alertDanger.Style.Add("display", "block !important");
                    alertSuccess.Style.Add("display", "none !important");
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                alertDanger.Style.Add("display", "block !important");
                alertSuccess.Style.Add("display", "none !important");
            }
        }

        public void ResetAll()
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtOldPassword.Text = "";
        }
    }
}