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
    public partial class Template : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTemplate();
                GetTotalRecords();
            }
        }

        public void GetTotalRecords()
        {
            ClsTemplate obj = new ClsTemplate();
            obj.IsDeleted = false;
            TotalRecords = obj.GetTotalRecords();
        }
        public void BindTemplate()
        {
            try
            {
                ClsTemplate obj = new ClsTemplate();
                obj.IsDeleted = false;
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTemplate obj = new ClsTemplate();
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
                            path = Server.MapPath(ClsCommon.TemplateImagesPath) + obj.IconImage;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                    }
                }

                obj.Title = txtTitle.Text;
                if (hdnTemplateId.Value == "")
                {
                    obj.TemplateId = 1;
                }
                else
                {
                    obj.TemplateId = Convert.ToInt64(hdnTemplateId.Value);
                }
                if (fileImage.HasFile)
                {
                    string[] arr = fileImage.PostedFile.FileName.Split('.');

                    string file_ext = arr[1].ToLower();

                    if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                    {
                        uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                        uploadfilename = uploadfilename + "." + file_ext;
                        obj.IconImage = uploadfilename;
                        fileImage.SaveAs(Server.MapPath(ClsCommon.TemplateImagesPath) + uploadfilename);
                    }
                    else
                    {
                        uploadfilename = "no-image-icon.png";
                        obj.IconImage = uploadfilename;
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
                    ClsTemplate objTemp = new ClsTemplate();
                    if (txtTitle.Text != "")
                    {
                        objTemp.Title = txtTitle.Text;
                        objTemp.IsDeleted = false;
                        objTemp.GetRecord();
                        if (!objTemp.DataRecieved)
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
                }
                else
                {
                    obj.Id = Convert.ToInt64(hdnId.Value);
                    obj.Edit();
                    lblSuccessMsg.Text = "Update Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }

                ResetAll();
                BindTemplate();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            hdnTemplateId.Value = "";
            hdnId.Value = "";
            txtTitle.Text = "";
            chkTemplate.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteTemplate(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsTemplate temp = new ClsTemplate();
                temp.Id = id;
                temp.GetRecord();
                if (temp.DataRecieved)
                {
                    ClsTemplateSlider objSlider = new ClsTemplateSlider();
                    objSlider.TemplateId = id;
                    objSlider.EditList();

                    ClsTemplateAboutUs objAbout = new ClsTemplateAboutUs();
                    objAbout.TemplateId = id;
                    objAbout.EditList();

                    ClsTemplateContact objContact = new ClsTemplateContact();
                    objContact.TemplateId = id;
                    objContact.EditList();

                    ClsTemplateServices objService = new ClsTemplateServices();
                    objService.TemplateId = id;
                    objService.EditList();

                    ClsTemplatePortfolio objPortfolio = new ClsTemplatePortfolio();
                    objPortfolio.TemplateId = id;
                    objPortfolio.EditList();

                    temp.IsDeleted = true;
                    temp.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }
        #endregion
    }
}