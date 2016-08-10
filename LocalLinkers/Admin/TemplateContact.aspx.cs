using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Admin
{
    public partial class TemplateContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ClsTemplateContact objExist = new ClsTemplateContact();
                    objExist.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                    objExist.IsDeleted = false;
                    if (objExist.IsExist())
                    {
                        TemplateContactForm.Style.Add("display", "none");
                    }
                    else
                    {
                        GridTemplateContactPanel.Style.Add("display", "none");
                    }
                    BindTemplateContact();
                }
            }
        }

        public void BindTemplateContact()
        {
            try
            {
                ClsTemplateContact obj = new ClsTemplateContact();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTemplateContact_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTemplateContact obj = new ClsTemplateContact();
                obj.FacebookLink = txtFacebookLink.Text;
                obj.TwitterLink = txtTwitterLink.Text;
                obj.TumblerLink = txtTumblarLink.Text;
                obj.Website = txtWebsite.Text;
                obj.GoogleLink = txtGoogleLink.Text;
                obj.Email = txtEmail.Text;
                obj.PinInterestLink = txtPinInterestLink.Text;
                obj.Address = txtAddress.Text;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                obj.PhoneNumber = txtPhoneNumber.Text;
                obj.PostalCode = txtPostalCode.Text;
                obj.State = txtState.Text;
                obj.City = txtCity.Text;
                obj.Latitude = hdnLatitude.Value;
                obj.Longitude = hdnLongitude.Value;

                if (chkTemplate.Checked)
                {
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    obj.IsApprovedByAdmin = false;
                }
                if (hdnId.Value == "")
                {
                    ClsTemplateContact objExist = new ClsTemplateContact();
                    objExist.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                    objExist.IsDeleted = false;
                    if (!objExist.IsExist())
                    {
                        obj.Add();
                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                    else
                    {
                        lblSuccessMsg.Text = "Already Exist";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                }
                else
                {
                    obj.Id = Convert.ToInt64(hdnId.Value);
                    obj.Edit();
                    lblSuccessMsg.Text = "Update Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }
                TemplateContactForm.Style.Add("display", "none");
                GridTemplateContactPanel.Style.Add("display", "block");
                ResetAll();
                BindTemplateContact();
            }
            catch (Exception ex)
            {

            }
        }



        public void ResetAll()
        {
            txtFacebookLink.Text = "";
            txtTumblarLink.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtTwitterLink.Text = "";
            hdnId.Value = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            txtPinInterestLink.Text = "";
            txtGoogleLink.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            chkTemplate.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteTemplateContact(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsTemplateContact cont = new ClsTemplateContact();
                cont.Id = id;
                cont.GetRecord();
                if (cont.DataRecieved)
                {
                    cont.IsDeleted = true;
                    cont.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }

        #endregion
    }
}