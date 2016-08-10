using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Admin
{
    public partial class TemplateServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindTemplateServices();
                }
            }
        }

        public void BindTemplateServices()
        {
            try
            {
                ClsTemplateServices obj = new ClsTemplateServices();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTemplateServices_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTemplateServices obj = new ClsTemplateServices();               

                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
               
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
                    ClsTemplateServices objExist = new ClsTemplateServices();
                    objExist.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                    objExist.IsDeleted = false;
                    List<ClsTemplateServices> objSliderList = objExist.GetAll();
                    if (objSliderList.Count < ClsCommon.TemplateServicesLimit)
                    {
                        obj.Add();
                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                    else
                    {
                        lblSuccessMsg.Text = "Not allowed to add more than 8 services.";
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
                ResetAll();
                BindTemplateServices();
            }
            catch (Exception ex)
            {

            }
        }



        public void ResetAll()
        {
            hdnId.Value = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            chkTemplate.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteTemplateServices(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsTemplateServices services = new ClsTemplateServices();
                services.Id = id;
                services.GetRecord();
                if (services.DataRecieved)
                {
                    services.IsDeleted = true;
                    services.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }
        #endregion
    }
}