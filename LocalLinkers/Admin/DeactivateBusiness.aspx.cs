using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.IO;
using System.Data;
using System.Web.Services;
using DataAccess;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace LocalLinkers.Admin
{
    public partial class DeactivateBusiness : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTotalRecords();
            if (!IsPostBack)
            {
                BindBusiness();               
                drpCategory.Items.Clear();
                drpCategory.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpCategory, "Category");

                drpCity.Items.Clear();
                drpCity.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpCity, "City");

                drpSubscription.Items.Clear();
                drpSubscription.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpSubscription, "Subscription");
            }
        }
        public void GetTotalRecords()
        {
            ClsBusiness obj = new ClsBusiness();
            obj.IsDeleted = false;
            obj.SelectedCity = 0;
            obj.IsApproved = (int)ClsBusiness.BooleanValues.Disapproved;
            TotalRecords = obj.GetTotalRecords();
        }
        public void BindBusiness()
        {
            try
            {
                ClsBusiness obj = new ClsBusiness();
                obj.IsDeleted = false;
                obj.SelectedCity = 0;
                obj.OrderBy = "Id";
                obj.IsApproved = (int)ClsBusiness.BooleanValues.Disapproved;
                rptBusiness.DataSource = obj.GetAll();
                rptBusiness.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private void fill_drpCategory(DropDownList ddl, string type)
        {
            try
            {
                if (type == "City")
                {
                    List<tbl_Cities> lst_city = new List<tbl_Cities>();
                    ClsCoupons obj = new ClsCoupons();
                    lst_city = obj.GetAllCities();
                    foreach (var c in lst_city)
                    {
                        ddl.Items.Add(new ListItem(c.CityName, c.Id.ToString()));
                    }
                }
                else if (type == "Category")
                {
                    List<ClsCategory> lst_cat = new List<ClsCategory>();
                    ClsCategory obj = new ClsCategory();
                    obj.IsDeleted = false;
                    obj.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                    lst_cat = obj.GetAll();
                    foreach (ClsCategory c in lst_cat)
                    {
                        ddl.Items.Add(new ListItem(c.Name, c.Id.ToString()));
                    }
                }
                else if (type == "Subscription")
                {
                    Array itemNames = System.Enum.GetNames(typeof(ClsBusiness.BusinessSubscription));
                    foreach (String name in itemNames)
                    {
                        //get the enum item value
                        Int32 value = (Int32)Enum.Parse(typeof(ClsBusiness.BusinessSubscription), name);
                        ListItem listItem = new ListItem(name, value.ToString());
                        ddl.Items.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnBusiness_Click(object sender, EventArgs e)
        {
            try
            {
                ClsBusiness obj = new ClsBusiness();
                string uploadfilename = "";
                string path = "";
                if (hdnBusinessId.Value != "")
                {
                    obj.Id = Convert.ToInt64(hdnBusinessId.Value);
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        if (fileImage.HasFile)
                        {
                            path = Server.MapPath(ClsCommon.BusinessImagesPath) + obj.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                    }
                }
                obj.Description = txtDescription.Text;
                obj.SubCategoryId = Convert.ToInt64(hdnSubCategoryId.Value);
                obj.CategoryId = Convert.ToInt64(drpCategory.SelectedItem.Value);
                obj.Address = txtAddress.Text;
                obj.BusinessName = txtBusinessName.Text;
                obj.PhoneNumber1 = txtPhoneNumber1.Text;
                obj.PhoneNumber2 = txtPhoneNumber2.Text;
                obj.ContactPerson = txtContactPerson.Text;
                obj.Email = txtEmail.Text;
                obj.Website = txtWebsite.Text;
                if (hdnLatitude.Value != "")
                {
                    obj.Latitude = hdnLatitude.Value;
                    obj.Longitude = hdnLongitude.Value;
                }
                obj.SelectedCity = Convert.ToInt64(drpCity.SelectedItem.Value);
                obj.Subscription = Convert.ToInt64(drpSubscription.SelectedItem.Value);
                if (chkBusiness.Checked)
                {
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    obj.IsApprovedByAdmin = false;
                }
                if (fileImage.HasFile)
                {
                    string[] arr = fileImage.PostedFile.FileName.Split('.');

                    string file_ext = arr[1].ToLower();

                    if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                    {
                        uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                        uploadfilename = uploadfilename + "." + file_ext;
                        obj.Image = uploadfilename;
                        fileImage.SaveAs(Server.MapPath(ClsCommon.BusinessImagesPath) + uploadfilename);
                    }
                    else
                    {
                        uploadfilename = "no-image-icon.png";
                        obj.Image = uploadfilename;
                    }
                }
                if (hdnBusinessId.Value == "")
                {
                    obj.Add();
                    lblSuccessMsg.Text = "Add Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }
                else
                {
                    obj.Id = Convert.ToInt64(hdnBusinessId.Value);
                    obj.Edit();

                    ClsBusinessImages deleteimg = new ClsBusinessImages();
                    deleteimg.BusinessId = obj.Id;
                    deleteimg.DeleteByBusinessId();

                    lblSuccessMsg.Text = "Update Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }

                //if (hdnImage.Value != "")
                //{
                //    string[] imgs = hdnImage.Value.Split(',');
                //    int Count = 0;
                //    foreach (var item in imgs)
                //    {

                //        if (item != "")
                //        {
                //            Count = Count + 1;
                //            if (Count <= ClsCommon.BusinessImagesLimit)
                //            {
                //                ClsBusinessImages objImg = new ClsBusinessImages();
                //                objImg.Image = item;
                //                objImg.BusinessId = obj.Id;
                //                objImg.Add();
                //            }
                //        }
                //    }
                //}

                ResetAll();
                BindBusiness();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            txtDescription.Text = "";
            txtBusinessName.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtContactPerson.Text = "";
            hdnLatitude.Value = "";
            hdnBusinessId.Value = "";
            hdnLongitude.Value = "";
            txtAddress.Text = "";
            hdnSubCategoryId.Value = "";
            txtPhoneNumber1.Text = "";
            txtPhoneNumber2.Text = "";
            //hdnImage.Value = "";
            drpCategory.SelectedIndex = 0;
            drpSubCategory.Items.Clear();
            drpSubCategory.Items.Add(new ListItem("Select", "0"));
            chkBusiness.Checked = false;
        }

        #region "WebMethod"      

        [WebMethod]
        public static string DeleteBusiness(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsBusiness busi = new ClsBusiness();
                busi.Id = id;
                busi.GetRecord();
                if (busi.DataRecieved)
                {
                    busi.IsDeleted = true;
                    busi.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }

        [WebMethod]
        public static string ActivateBusiness(int Id)
        {
            string result = "";
            if (Id > 0)
            {
                ClsBusiness busi = new ClsBusiness();
                busi.Id = Id;
                busi.GetRecord();
                if (busi.DataRecieved)
                {
                    busi.IsApprovedByAdmin = true;                    
                    busi.Edit();
                    result = "Activate Successfully";
                }
            }
            return result;
        }

        [WebMethod]
        public static string DeleteImage(string myFile)
        {
            string filePath = "";

            string _fileName = "";

            if (myFile != null && myFile != "")
            {
                string relativePath = ClsCommon.BusinessImagesPath;
                string pathForSaving = System.Web.HttpContext.Current.Server.MapPath(relativePath);
                try
                {
                    string combinePath = Path.Combine(pathForSaving, myFile);
                    FileInfo file = new FileInfo(combinePath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    filePath = String.Format("{0}/{1}", relativePath, myFile);
                    _fileName = myFile;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return _fileName;
        }

        [WebMethod]
        public static string GetImages(int Id)
        {
            string result = "";
            ClsBusinessImages img = new ClsBusinessImages();
            img.BusinessId = Id;
            List<ClsBusinessImages> list_imgs = img.GetAll();
            foreach (var item in list_imgs)
            {
                if (item.Image != "")
                {
                    result += item.Image + ",";
                }
            }
            result = result.TrimEnd(',');
            return result;
        }
        #endregion
    }
}