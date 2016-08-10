﻿using DataAccess.Classes;
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
    public partial class TemplateSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindTemplateSlider();
                }
            }
        }

        public void BindTemplateSlider()
        {
            try
            {
                ClsTemplateSlider obj = new ClsTemplateSlider();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTemplateSlider_Click(object sender, EventArgs e)
        {
            try
            {
                ClsTemplateSlider obj = new ClsTemplateSlider();
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
                            path = Server.MapPath(ClsCommon.TemplateSliderImagesPath) + obj.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                    }
                }

                obj.Title = txtTitle.Text;
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
                        fileImage.SaveAs(Server.MapPath(ClsCommon.TemplateSliderImagesPath) + uploadfilename);
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
                    ClsTemplateSlider objExist = new ClsTemplateSlider();
                    objExist.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                    objExist.IsDeleted = false;
                    List<ClsTemplateSlider> objSliderList = objExist.GetAll();
                    if (objSliderList.Count<ClsCommon.TemplateSliderLimit)
                    {
                        obj.Add();
                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                    else
                    {
                        lblSuccessMsg.Text = "Not allowed to add more than 5 images.";
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
                BindTemplateSlider();
            }
            catch (Exception ex)
            {

            }
        }



        public void ResetAll()
        {
            hdnId.Value = "";
            txtTitle.Text = "";
            chkTemplate.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteTemplateSlider(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsTemplateSlider slider = new ClsTemplateSlider();
                slider.Id = id;
                slider.GetRecord();
                if (slider.DataRecieved)
                {
                    slider.IsDeleted = true;
                    slider.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }
        #endregion
    }
}