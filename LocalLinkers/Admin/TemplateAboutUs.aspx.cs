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
    public partial class TemplateAboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ClsTemplateAboutUs objExist = new ClsTemplateAboutUs();
                    objExist.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                    objExist.IsDeleted = false;
                    if (objExist.IsExist())
                    {
                        TemplateAboutUsForm.Style.Add("display", "none");
                    }
                    else
                    {
                        GridTemplateAboutUsPanel.Style.Add("display", "none");
                    }
                    BindTemplateAboutus();
                    ClsTemplate templateObj = new ClsTemplate();
                    templateObj.Id = objExist.TemplateId.GetValueOrDefault();
                    templateObj.IsDeleted = false;
                    templateObj.IsApprovedByAdmin = true;
                    templateObj.GetRecord();
                    if (templateObj.DataRecieved)
                    {
                        if (templateObj.TemplateId == 1)
                        {
                            divTagLine.Visible = true;
                        }
                        else
                        {
                            divTagLine.Visible = false;
                        }

                    }
                }
            }
        }

        public void BindTemplateAboutus()
        {
            try
            {
                ClsTemplateAboutUs obj = new ClsTemplateAboutUs();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTemplateAboutUs_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTemplateAboutUs obj = new ClsTemplateAboutUs();
                string uploadfilename = "";
                string path = "";
                if (hdnId.Value != "")
                {
                    obj.Id = Convert.ToInt64(hdnId.Value);
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        if (fileImage.HasFile)
                        {
                            path = Server.MapPath(ClsCommon.TemplateAboutUsImagesPath) + obj.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                    }
                }

                obj.AboutUs = txtAboutUs.Text;
                
                obj.Tagline = txtTagline.Text;          
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);

                
                if (fileImage.HasFile)
                {
                    string[] arr = fileImage.PostedFile.FileName.Split('.');

                    string file_ext = arr[1].ToLower();

                    if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                    {
                        uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                        uploadfilename = uploadfilename + "." + file_ext;
                        obj.Image = uploadfilename;
                        fileImage.SaveAs(Server.MapPath(ClsCommon.TemplateAboutUsImagesPath) + uploadfilename);
                    }
                    else
                    {
                        uploadfilename = "no-image-icon.png";
                        obj.Image = uploadfilename;
                    }
                }
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
                    ClsTemplateAboutUs objExist = new ClsTemplateAboutUs();
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
                TemplateAboutUsForm.Style.Add("display", "none");
                GridTemplateAboutUsPanel.Style.Add("display", "block");
                ResetAll();
                BindTemplateAboutus();
            }
            catch (Exception ex)
            {

            }
        }



        public void ResetAll()
        {
            hdnId.Value = "";
            txtAboutUs.Text = "";
            txtTagline.Text = "";

            chkTemplate.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteTemplateAboutUs(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsTemplateAboutUs about = new ClsTemplateAboutUs();
                about.Id = id;
                about.GetRecord();
                if (about.DataRecieved)
                {
                    about.IsDeleted = true;
                    about.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }
        #endregion
    }
}