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
    public partial class Products : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindProducts();
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
            ClsProducts obj = new ClsProducts();
            obj.IsDeleted = false;
            TotalRecords = obj.GetTotalRecords();
        }

        public void BindProducts()
        {
            try
            {
                ClsProducts obj = new ClsProducts();
                obj.IsDeleted = false;
                rptProducts.DataSource = obj.GetAll();
                rptProducts.DataBind();
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
                    ClsProducts obj = new ClsProducts();
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

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                ClsProducts obj = new ClsProducts();
                obj.Title = txtTitle.Text;
                obj.SubCategoryId = Convert.ToInt64(hdnSubCategoryId.Value);
                obj.CategoryId = Convert.ToInt64(drpCategory.SelectedItem.Value);
                obj.Address = txtAddress.Text;
                obj.ShortDescription = txtShortDescription.Text;
                obj.Description = txtDescription.Text;
                if (hdnLatitude.Value != "")
                {
                    obj.Latitude = hdnLatitude.Value;
                    obj.Longitude = hdnLongitude.Value;
                }
                obj.ActualPrice = Convert.ToDecimal(txtActualPrice.Text);
                obj.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
                obj.Stock = Convert.ToInt64(txtStock.Text);
                obj.SelectedPosition = Convert.ToInt64(drpPosition.SelectedItem.Value);
                obj.SelectedCity = Convert.ToInt64(drpCity.SelectedItem.Value);
                if (chkProduct.Checked)
                {
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    obj.IsApprovedByAdmin = false;
                }
                obj.CheckPosition();
                if (hdnProductId.Value == "")
                {
                    obj.Add();
                    lblSuccessMsg.Text = "Add Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }
                else
                {
                    obj.Id = Convert.ToInt64(hdnProductId.Value);
                    obj.Edit();

                    ClsProductImages deleteimg = new ClsProductImages();
                    deleteimg.ProductId = obj.Id;
                    deleteimg.DeleteByProductId();

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
                            if (Count <= ClsCommon.ProductImagesLimit)
                            {
                                ClsProductImages objImg = new ClsProductImages();
                                objImg.Image = item;
                                objImg.ProductId = obj.Id;
                                objImg.Add();
                            }
                        }
                    }
                }

                ResetAll();
                BindProducts();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtShortDescription.Text = "";
            txtStock.Text = "";
            txtActualPrice.Text = "";
            txtSalePrice.Text = "";
            hdnLatitude.Value = "";
            hdnProductId.Value = "";
            hdnLongitude.Value = "";
            hdnImage.Value = "";
            txtAddress.Text = "";
            hdnSubCategoryId.Value = "";
            drpPosition.SelectedIndex = 0;
            drpCity.SelectedIndex = 0;
            drpCategory.SelectedIndex = 0;
            drpSubCategory.Items.Clear();
            drpSubCategory.Items.Add(new ListItem("Select", "0"));
            chkProduct.Checked = false;
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
        public static string DeleteProduct(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsProducts Product = new ClsProducts();
                Product.Id = id;
                Product.GetRecord();
                if (Product.DataRecieved)
                {
                    Product.IsDeleted = true;
                    Product.Edit();
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
                string relativePath = ClsCommon.ProductImagesPath;
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
            ClsProductImages img = new ClsProductImages();
            img.ProductId = Id;
            List<ClsProductImages> list_imgs = img.GetAll();
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
        #endregion
    }
}