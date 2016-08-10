using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProfile();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClsLogin log = new ClsLogin();
                string uploadfilename = "";
                log.Id = ClsCommon.UserId;
                log.RoleId = 0;
                log.IsApproved = (int)ClsLogin.BooleanValues.Approved;
                log.IsDeleted = false;
                log.GetRecord();
                if (log.DataRecieved && log.RoleId!=(int)ClsLogin.Role.Admin)
                {
                    log.UserName = txtName.Text;
                    log.Email = txtEmail.Text;
                    log.Address1 = txtAddress1.Text;
                    log.Address2 = txtAddress2.Text;
                    log.City = txtCity.Text;
                    log.State = txtState.Text;
                    log.Website = txtWebsite.Text;
                    log.PostalCode = txtZip.Text;
                    log.Country = txtCountry.Text;
                    if (fileUserUpload.HasFile)
                    {
                        if (log.Image != null && log.Image != "")
                        {
                            string path = Server.MapPath(ClsCommon.UserImagesPath) + log.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                        string[] arr = fileUserUpload.PostedFile.FileName.Split('.');

                        string file_ext = arr[1].ToLower();

                        if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                        {
                            uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                            uploadfilename = uploadfilename + "." + file_ext;
                            log.Image = uploadfilename;
                            HttpPostedFile ProfileImage = fileUserUpload.PostedFile;
                            System.Drawing.Image ThumbnailImage = System.Drawing.Image.FromStream(ProfileImage.InputStream,true,true);
                            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(ProfileImage.InputStream, true, true);

                            ThumbnailImage = ClsCommon.ResizeImage(ThumbnailImage, 30, 30);
                            ThumbnailImage.Save(Server.MapPath(ClsCommon.UserImagesThumnailPath) + uploadfilename);

                            originalImage = ClsCommon.ResizeImage(originalImage, 200, 200);
                            originalImage.Save(Server.MapPath(ClsCommon.UserImagesPath) + uploadfilename);
                            //fileUserUpload.SaveAs(Server.MapPath(ClsCommon.UserImagesPath) + uploadfilename);
                        }
                        else
                        {
                            uploadfilename = "";
                            log.Image = uploadfilename;
                        }
                    }
                    log.Edit();
                    ClsCommon.UserEmail = txtEmail.Text;
                    ClsCommon.UserImage = log.Image;
                    ClsCommon.UserId = log.Id;
                    ClsCommon.UserName = txtName.Text;
                    ClsCommon.PhoneNumber = txtPhone.Text;
                    ClsCommon.SetSession();
                    lblSuccessMsg.Text = "Update successfully";
                    alertSuccess.Style.Add("display", "block !important");
                    alertDanger.Style.Add("display", "none !important");
                    BindProfile();
                }
            }
            catch (Exception ex)
            {
                lblSuccessMsg.Text = ex.Message;
                alertSuccess.Style.Add("display", "none !important");
                alertDanger.Style.Add("display", "block !important");
            }
        }

        public void BindProfile()
        {
            ClsLogin log = new ClsLogin();
            log.Id = ClsCommon.UserId;
            log.RoleId = 0;
            log.IsApproved = (int)ClsLogin.BooleanValues.Approved;
            log.IsDeleted = false;
            log.GetRecord();
            if (log.DataRecieved && log.RoleId != (int)ClsLogin.Role.Admin)
            {
                txtName.Text = log.UserName;
                txtEmail.Text = log.Email;
                txtAddress1.Text = log.Address1;
                txtAddress2.Text = log.Address2;
                txtCity.Text = log.City;
                txtState.Text = log.State;
                txtWebsite.Text = log.Website;
                txtZip.Text = log.PostalCode;
                txtCountry.Text = log.Country;
                txtPhone.Text = log.PhoneNumber;
                target.ImageUrl = log.Image == "no-image-icon.png" || log.Image == null || log.Image == "" ? ClsCommon.NoImageIcon : ClsCommon.UserImagesPath + log.Image;
            }
        }
    }
}