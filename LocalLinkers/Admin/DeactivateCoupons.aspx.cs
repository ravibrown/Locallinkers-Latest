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
using System.Net;
using System.Text;

namespace LocalLinkers.Admin
{
    public partial class DeactivateCoupons : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindCoupons();
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
            ClsCoupons obj = new ClsCoupons();
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsCoupons.BooleanValues.Disapproved;
            TotalRecords = obj.GetTotalRecords();
        }
        public void BindCoupons()
        {
            try
            {
                ClsCoupons obj = new ClsCoupons();
                obj.IsDeleted = false;
                obj.IsApproved = (int)ClsCoupons.BooleanValues.Disapproved;
                rptCoupons.DataSource = obj.GetAll();
                rptCoupons.DataBind();
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
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnCoupons_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCoupons obj = new ClsCoupons();
                if (hdnCouponId.Value != "")
                {
                    obj.Id = Convert.ToInt64(hdnCouponId.Value);
                    obj.GetRecord();
                    if (chkCoupon.Checked)
                    {
                        obj.UpdatedDate = DateTime.UtcNow;
                    }
                }
                obj.Title = txtTitle.Text;
                obj.SubCategoryId = Convert.ToInt64(hdnSubCategoryId.Value);
                obj.CategoryId = Convert.ToInt64(drpCategory.SelectedItem.Value);
                obj.Address = txtAddress.Text;
                obj.BusinessName = txtBusinessName.Text;
                obj.PhoneNumber = txtPhoneNumber.Text;
                obj.OfferDetails = txtOfferDetails.Text;
                obj.TermsAndCondition = txtTermsAndCondition.Text;
                if (hdnLatitude.Value != "")
                {
                    obj.Latitude = hdnLatitude.Value;
                    obj.Longitude = hdnLongitude.Value;
                }
                obj.ActualPrice = Convert.ToDecimal(txtActualPrice.Text);
                obj.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
                obj.PayToMerchant = Convert.ToDecimal(txtPayToMerchant.Text);
                obj.CouponPrice = Convert.ToDecimal(txtCouponPrice.Text);
                obj.SelectedPosition = Convert.ToInt64(drpPosition.SelectedItem.Value);
                obj.SelectedCity = Convert.ToInt64(drpCity.SelectedItem.Value);
                obj.Quantity = Convert.ToInt64(txtQuantity.Text);
                obj.CouponMessage = txtCouponMessage.Text;
                if (chkCoupon.Checked)
                {
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    obj.IsApprovedByAdmin = false;
                }
                obj.CheckPosition();
                if (hdnCouponId.Value == "")
                {
                    obj.UniqueId = ClsCommon.CreateUniqueId().Substring(0, 6);
                    obj.Add();
                    lblSuccessMsg.Text = "Add Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }
                else
                {
                    obj.Id = Convert.ToInt64(hdnCouponId.Value);
                    obj.Edit();

                    ClsCouponImages deleteimg = new ClsCouponImages();
                    deleteimg.CouponId = obj.Id;
                    deleteimg.DeleteByCouponId();

                    lblSuccessMsg.Text = "Update Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }

                if (hdnImage.Value != "")
                {
                    string[] imgs = hdnImage.Value.Split(',');
                    int Count = 0;
                    foreach (var item in imgs)
                    {

                        if (item != "")
                        {
                            Count = Count + 1;
                            if (Count <= ClsCommon.CouponImagesLimit)
                            {
                                ClsCouponImages objImg = new ClsCouponImages();
                                objImg.Image = item;
                                objImg.CouponId = obj.Id;
                                objImg.Add();
                            }
                        }
                    }
                }

                ResetAll();
                BindCoupons();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            txtTitle.Text = "";
            txtCouponMessage.Text="";
            txtQuantity.Text = "";
            hdnUniqueId.Value = "";
            txtBusinessName.Text = "";
            txtOfferDetails.Text = "";
            txtActualPrice.Text = "";
            txtSalePrice.Text = "";
            hdnLatitude.Value = "";
            hdnCouponId.Value = "";
            hdnLongitude.Value = "";
            hdnImage.Value = "";
            txtPayToMerchant.Text = "";
            txtCouponPrice.Text = "";
            txtAddress.Text = "";
            hdnSubCategoryId.Value = "";
            txtPhoneNumber.Text = "";
            drpPosition.SelectedIndex = 0;
            drpCity.SelectedIndex = 0;
            drpCategory.SelectedIndex = 0;
            drpSubCategory.Items.Clear();
            drpSubCategory.Items.Add(new ListItem("Select", "0"));
            chkCoupon.Checked = false;
        }

        #region "WebMethod"
        [WebMethod]
        public static string GetSubCategories(int CategoryId)
        {
            try
            {
                List<Subcategory> lst_Subcat = new List<Subcategory>();
                ClsSubCategory obj = new ClsSubCategory();
                obj.CategoryId = CategoryId;
                obj.IsDeleted = false;
                obj.IsApproved = (int)ClsSubCategory.BooleanValues.Approved;
                lst_Subcat = obj.GetDropDownAll();
                var json = JsonConvert.SerializeObject(lst_Subcat, Formatting.None,
    new JsonSerializerSettings()
    {
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });

                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static string DeleteCoupon(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsCoupons coupon = new ClsCoupons();
                coupon.Id = id;
                coupon.GetRecord();
                if (coupon.DataRecieved)
                {
                    coupon.IsDeleted = true;
                    coupon.Edit();
                    result = "Delete Successfully";
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
                string relativePath = ClsCommon.CouponImagesPath;
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
            ClsCouponImages img = new ClsCouponImages();
            img.CouponId = Id;
            List<ClsCouponImages> list_imgs = img.GetAll();
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

        [WebMethod]
        public static string Logout()
        {
            string result = "";
            HttpContext.Current.Session.Clear();
            result = "/Admin/Login";
            return result;
        }

        [WebMethod]
        public static string FindCoordinates(string Address = "")
        {
            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + Address + "&sensor=false";
            string cordinates = "";
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    foreach (DataRow row in dsResult.Tables["result"].Rows)
                    {
                        string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                        DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                        cordinates=location["lat"]+","+location["lng"];
                        break;
                    }
                }
            }
            return cordinates;
        }

        #endregion
    }
}