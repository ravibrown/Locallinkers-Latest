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

namespace LocalLinkers
{
    public partial class AddBusiness : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBusiness();
                GetTotalRecords();
                drpCategory.Items.Clear();
                drpCategory.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpCategory, "Category");

                drpCity.Items.Clear();
                drpCity.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpCity, "City");
            }
        }
        public void GetTotalRecords()
        {
            ClsBusiness obj = new ClsBusiness();
            obj.IsDeleted = false;
            obj.SelectedCity = 0;
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
                obj.UserId = ClsCommon.UserId;
                List<ClsBusiness> lst = obj.GetAll();
                if (lst != null && lst.Count > 0)
                {
                    divNoRecords.Visible = false;
                    divBusiness.Visible = true;
                    rptBusiness.DataSource = obj.GetAll();
                    rptBusiness.DataBind();
                }
                else
                {
                    divNoRecords.Visible = true;
                    divBusiness.Visible = false;
                }
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
                obj.UserId = ClsCommon.UserId;
                obj.BusinessName = txtBusinessName.Text;
                obj.PhoneNumber1 = txtPhoneNumber1.Text;
                obj.PhoneNumber2 = txtPhoneNumber2.Text;
                obj.ContactPerson = txtContactPerson.Text;
                obj.Email = txtEmail.Text;
                obj.Website = txtWebsite.Text;
                obj.Latitude = hdnLatitude.Value;
                obj.Longitude = hdnLongitude.Value;
                obj.SelectedCity = Convert.ToInt64(drpCity.SelectedItem.Value);
                obj.IsApprovedByAdmin = false;
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
                    if (obj.Id > 0)
                    {
                        ClsLogin log = new ClsLogin();
                        log.Id = ClsCommon.UserId;
                        log.RoleId = ClsCommon.RoleId;
                        log.GetRecord();
                        if (log.DataRecieved && log.RoleId == (int)ClsLogin.Role.User)
                        {
                            log.RoleId = (int)ClsLogin.Role.Merchant;
                            log.Edit();
                            Session["RoleId"] = (int)ClsLogin.Role.Merchant;
                        }

                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
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
            drpCategory.SelectedIndex = 0;
            drpSubCategory.Items.Clear();
            drpSubCategory.Items.Add(new ListItem("Select", "0"));
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
        #endregion
    }
}