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
    public partial class HomeSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHomeSlider();
            }
        }

        public void BindHomeSlider()
        {
            try
            {
                ClsHomeSlider obj = new ClsHomeSlider();
                obj.IsDeleted = false;
                rptHomeSlider.DataSource = obj.GetAll();
                rptHomeSlider.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnHomeSlider_Click(object sender, EventArgs e)
        {
            try
            {
                ClsHomeSlider obj = new ClsHomeSlider();
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
                            path = Server.MapPath(ClsCommon.HomeSliderImagesPath) + obj.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                    }
                }

                obj.Title = txtTitle.Text;
                if (fileImage.HasFile)
                {
                    string[] arr = fileImage.PostedFile.FileName.Split('.');

                    string file_ext = arr[1].ToLower();

                    if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                    {
                        uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                        uploadfilename = uploadfilename + "." + file_ext;
                        obj.Image = uploadfilename;
                        fileImage.SaveAs(Server.MapPath(ClsCommon.HomeSliderImagesPath) + uploadfilename);
                    }
                    else
                    {
                        uploadfilename = "no-image-icon.png";
                        obj.Image = uploadfilename;
                    }
                }
                if (chkHomeSlider.Checked)
                {
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    obj.IsApprovedByAdmin = false;
                }

                if (hdnId.Value == "")
                {
                    ClsHomeSlider objTemp = new ClsHomeSlider();
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
                BindHomeSlider();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            hdnId.Value = "";
            txtTitle.Text = "";
            chkHomeSlider.Checked = false;
        }

        #region "WebMethod"

        [WebMethod]
        public static string DeleteHomeSlider(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsHomeSlider temp = new ClsHomeSlider();
                temp.Id = id;
                temp.GetRecord();
                if (temp.DataRecieved)
                {
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