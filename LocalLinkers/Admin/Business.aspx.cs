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
    #region"Extra Classes"
    public class Paging
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
    #endregion
    public partial class Business : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        public static Int64 PageIndex = 0;
        public static Int64 SelectedPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                divBusinessTable.Visible = false;
                
                TotalRecords = 0;

                drpSelectCategory.Items.Clear();
                drpSelectCategory.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpSelectCategory, "Category");

                drpSelectSubcategory.Items.Clear();
                drpSelectSubcategory.Items.Add(new ListItem("Select", "0"));

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
            obj.CategoryId = Convert.ToInt64(drpSelectCategory.SelectedItem.Value);
            obj.SubCategoryId = Convert.ToInt64(drpSelectSubcategory.SelectedItem.Value);
            obj.SelectedCity = 0;
            obj.IsApproved = (int)ClsBusiness.BooleanValues.Approved;
            TotalRecords = obj.GetTotalRecords();           
        }
        public void BindPaging()
        {
            try
            {
                if (TotalRecords != 0 && TotalRecords > 20)
                {
                    double Page = Convert.ToDouble(Convert.ToDouble(TotalRecords) / Convert.ToDouble(drpPage.SelectedItem.Value));
                    var splitvalue = Page.ToString().Split('.');
                    PageIndex = Convert.ToInt32(splitvalue[0]);
                    if (Convert.ToInt32(splitvalue[1]) >= 5)
                    {
                        PageIndex = PageIndex + 1;
                    }
                    List<Paging> lst_paging = new List<Paging>();
                    for (int i = 0; i < PageIndex; i++)
                    {
                        Paging p = new Paging();
                        p.Text = Convert.ToInt32(i + 1).ToString();
                        p.Value = i;
                        lst_paging.Add(p);
                    }
                    if (lst_paging != null && lst_paging.Count > 0)
                    {
                        rptPaging.DataSource = lst_paging;
                        rptPaging.DataBind();
                    }
                }
                else
                {
                    rptPaging.DataSource = null;
                    rptPaging.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void BindBusiness()
        {
            try
            {
                ClsBusiness obj = new ClsBusiness();
                obj.IsDeleted = false;
                obj.SelectedCity = 0;
                obj.CategoryId = Convert.ToInt64(drpSelectCategory.SelectedItem.Value);
                if (Convert.ToInt64(drpPage.SelectedItem.Value) != -1)
                {
                    obj.Take = Convert.ToInt64(drpPage.SelectedItem.Value);
                    obj.Index = SelectedPage;
                }
                obj.SubCategoryId = Convert.ToInt64(drpSelectSubcategory.SelectedItem.Value);
                obj.OrderBy = "Id";
                obj.IsApproved = (int)ClsBusiness.BooleanValues.Approved;
                rptBusiness.DataSource = obj.GetAll();
                rptBusiness.DataBind();
                divBusinessTable.Visible = true;
                divLoader.Style.Add("display", "none");
            }
            catch (Exception ex)
            {

            }
        }
        protected void drpSelectCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            List<Subcategory> lst_Subcat = new List<Subcategory>();
            ClsSubCategory obj = new ClsSubCategory();
            obj.CategoryId = Convert.ToInt64(drpSelectCategory.SelectedItem.Value);
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsSubCategory.BooleanValues.Approved;
            lst_Subcat = obj.GetDropDownAll();
            drpSelectSubcategory.Items.Clear();
            drpSelectSubcategory.Items.Add(new ListItem("Select", "0"));
            if (lst_Subcat != null && lst_Subcat.Count > 0)
            {
                foreach (var c in lst_Subcat)
                {
                    drpSelectSubcategory.Items.Add(new ListItem(c.Name, c.Id.ToString()));
                }
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
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            SelectedPage = 0;
            GetTotalRecords();
            BindPaging();
            BindBusiness();

        }
        public void rptPaging_OnItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Paging")
            {
                foreach (RepeaterItem item in rptPaging.Items)
                {
                    LinkButton linkButton = item.FindControl("lnkPaging") as LinkButton;
                    linkButton.Enabled = true;
                    linkButton.Style.Add("color", "#fff");
                    linkButton.Style.Add("background-color", "#337ab7");
                }
                LinkButton localLink = (LinkButton)e.Item.FindControl("lnkPaging");
                localLink.Enabled = false;
                localLink.Style.Add("color", "#000");
                localLink.Style.Add("background-color", "#fff");
                SelectedPage = Convert.ToInt32(e.CommandArgument);
                BindBusiness();
            }
        }
        protected void btnBusiness_Click(object sender, EventArgs e)
        {
            try
            {
                ClsBusiness obj = new ClsBusiness();
                string uploadfilename = "";
                string uploadpremiumfileename = "";
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
                        
                        if (FilePremiumImage.HasFile && obj.Subscription==(int)ClsBusiness.BusinessSubscription.Premium)
                        {
                            path = Server.MapPath(ClsCommon.BusinessPremiumImagesPath) + obj.PremiumImage;
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
                if (FilePremiumImage.HasFile && obj.Subscription==(int)ClsBusiness.BusinessSubscription.Premium)
                {
                    string[] arr = FilePremiumImage.PostedFile.FileName.Split('.');

                    string file_ext = arr[1].ToLower();

                    if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                    {
                        uploadpremiumfileename = DateTime.Now.ToFileTimeUtc().ToString();
                        uploadpremiumfileename = uploadpremiumfileename + "." + file_ext;
                        obj.PremiumImage = uploadpremiumfileename;
                        FilePremiumImage.SaveAs(Server.MapPath(ClsCommon.BusinessPremiumImagesPath) + uploadpremiumfileename);
                    }
                    else
                    {
                        uploadpremiumfileename = "no-image-icon.png";
                        obj.PremiumImage = uploadpremiumfileename;
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
        public static string DeactivateBusiness(int Id)
        {
            string result = "";
            if (Id > 0)
            {
                ClsBusiness busi = new ClsBusiness();
                busi.Id = Id;
                busi.GetRecord();
                if (busi.DataRecieved)
                {
                    busi.IsApprovedByAdmin = false;
                    busi.Edit();
                    result = "Deactivate Successfully";
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