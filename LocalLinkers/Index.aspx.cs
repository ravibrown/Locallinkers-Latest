using DataAccess.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCoupons();
                BindProducts();
                BindCategory();
            }
        }
        public void BindCoupons()
        {
            try
            {
                ClsCoupons obj = new ClsCoupons();
                obj.IsDeleted = false;
                obj.SelectedPosition = 1;
                obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                if (Session["SelectedCityId"] != null)
                {
                    obj.SelectedCity = Convert.ToInt64(Session["SelectedCityId"]);
                }
                else
                {
                    obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                }
                rptCards.DataSource = obj.GetAll();
                rptCards.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        public void BindProducts()
        {
            try
            {
                ClsProducts obj = new ClsProducts();
                obj.IsDeleted = false;
                obj.Take = 3;
                obj.IsApproved = (int)ClsProducts.BooleanValues.Approved;
                obj.IsApprovedByAdmin = true;
                if (Session["SelectedCityId"] != null)
                {
                    obj.SelectedCity = Convert.ToInt64(Session["SelectedCityId"]);
                }
                else
                {
                    obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                }
                rptProducts.DataSource = obj.GetAll();
                rptProducts.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        public void BindCategory()
        {
            try
            {
                ClsCategory obj = new ClsCategory();
                obj.IsDeleted = false;
                obj.Take = 12;
                obj.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                rptCategory.DataSource = obj.GetAll();
                rptCategory.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void rptProducts_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptProductImages = (Repeater)(e.Item.FindControl("rptProductImages"));
                HiddenField hdnId = (HiddenField)(e.Item.FindControl("hdnId"));
                ClsProductImages obj = new ClsProductImages();
                obj.ProductId = Convert.ToInt64(hdnId.Value);
                obj.IsDeleted = false;
                List<ClsProductImages> objlist = obj.GetAll();
                if (objlist.Count > 0 && objlist != null)
                {
                    rptProductImages.DataSource = objlist;
                    rptProductImages.DataBind();
                }
                //Need to assign the Data in datatable

            }

        }

        protected string ChangeCardWidth(int number)
        {
            string result = "";
            if (number == 1 || number == 11 || number == 21)
            {
                result = "col-md-6 fstclass";
            }
            else if (number == 2 || number == 12||number == 22)
            {
                result = "col-md-6 scndclass";
            }
            else if (number == 3 || number == 13 || number == 23)
            {
                result = "col-md-3 fstsmall";
            }
            else if (number == 4 || number == 14 || number == 24)
            {
                result = "col-md-4 nochange";
            }
            else if (number == 5 || number == 15 || number == 25)
            {
                result = "col-md-5 scndsmal";
            }
            else if (number == 6 || number == 16 || number == 26)
            {
                result = "col-md-4 fstsame";
            }
            else if (number == 7 || number == 17 || number == 27)
            {
                result = "col-md-4 nochange";
            }
            else if (number == 8 || number == 18 || number == 28)
            {
                result = "col-md-4 scndsame";
            }
            else if (number == 9 || number == 19 || number == 29)
            {
                result = "col-md-6 fstclass";
            }
            else if (number == 10 || number == 20 || number == 30)
            {
                result = "col-md-6 scndclass";
            }
            return result;
        }

        protected string ChangeCardColor(int number)
        {
            string result = "";
            if (number == 1)
            {
                result = "filter filter-orange";
            }
            else if (number == 2)
            {
                result = "filter";
            }
            else if (number == 3)
            {
                result = "filter filter-orange";
            }
            else if (number == 4)
            {
                result = "filter";
            }
            else if (number == 5)
            {
                result = "filter";
            }
            else if (number == 6)
            {
                result = "filter";
            }
            else if (number == 7)
            {
                result = "filter";
            }
            else if (number == 8)
            {
                result = "filter filter-azure";
            }
            else if (number == 9)
            {
                result = "filter filter-orange";
            }
            else if (number == 10)
            {
                result = "filter";
            }
            return result;
        }



        #region "WebMethod"
        [WebMethod]
        public static string Logout()
        {
            string result = "";
            ClsCommon.RemoveSession();
            result = "/Index";
            return result;
        }

        [WebMethod]
        public static string SetCity(string city, int id)
        {
            string result = "";
            HttpContext.Current.Session["SelectedCity"] = city;
            HttpContext.Current.Session["SelectedCityId"] = id;
            var latlong = ClsCommon.GetLatLongByCityID(id);
            HttpContext.Current.Session["Latitude"] = latlong.Latitude;
            HttpContext.Current.Session["Longitude"] = latlong.Longitude;
            result = "done";
            return result;
        }

        [WebMethod(EnableSession = true)]
        public static string AddToCart(int id, string type, string description, string price, string title, string image, int quantity)
        {
            string result = "";
            List<ClsPropOrderList> order_list = new List<ClsPropOrderList>();
            Int64 AddQuantity = 0;
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                order_list = (List<ClsPropOrderList>)HttpContext.Current.Session["OrderList"];
                ClsPropOrderList CheckOrder = order_list.FirstOrDefault(a => a.Id == id && a.Type == type);
                if (CheckOrder != null && type != "Coupon")
                {
                    AddQuantity = Convert.ToInt64(CheckOrder.Quantity);
                    order_list.Remove(CheckOrder);
                }
                else if (CheckOrder != null)
                {
                    result = "Already Exist.";
                    return result;
                }
            }
            ClsPropOrderList obj = new ClsPropOrderList();
            if (type == "Product")
            {
                obj.Image = ClsCommon.ProductImagesPath + image;
            }
            else if (type == "Coupon")
            {
                obj.Image = ClsCommon.CouponImagesPath + image;
            }
            obj.Id = id;
            obj.Price = Convert.ToDecimal(price);
            obj.Quantity = quantity + AddQuantity;
            obj.Description = description;
            obj.Title = title;
            obj.CreatedDate = DateTime.UtcNow;
            obj.UpdatedDate = DateTime.UtcNow;
            obj.ActualPrice = Convert.ToDecimal(obj.Quantity * obj.Price);
            obj.Type = type;
            order_list.Add(obj);
            order_list = order_list.Select((r, index) => new ClsPropOrderList
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Price = r.Price,
                ActualPrice = r.ActualPrice,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                Quantity = r.Quantity,
                Image = r.Image,
                Type = r.Type,
                SNO = index + 1
            }).ToList();
            HttpContext.Current.Session["OrderList"] = order_list;
            result = "done";
            return result;
        }

        [WebMethod]
        public static string RemoveCartItem(int id, string type)
        {
            string result = "";
            List<ClsPropOrderList> order_list = new List<ClsPropOrderList>();
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                order_list = (List<ClsPropOrderList>)HttpContext.Current.Session["OrderList"];
                ClsPropOrderList CheckOrder = order_list.FirstOrDefault(a => a.Id == id && a.Type == type);
                if (CheckOrder != null)
                {
                    HttpContext.Current.Session["TotalAmount"] = Convert.ToDecimal(HttpContext.Current.Session["TotalAmount"]) - Convert.ToDecimal(CheckOrder.ActualPrice);
                    if (Convert.ToDecimal(HttpContext.Current.Session["TotalAmount"]) < 0)
                    {
                        HttpContext.Current.Session["ReedemPoints"] = Convert.ToInt32(HttpContext.Current.Session["ReedemPoints"]) + Convert.ToInt32(HttpContext.Current.Session["TotalAmount"]);
                        HttpContext.Current.Session["Points"] = Math.Abs(Convert.ToInt32(HttpContext.Current.Session["TotalAmount"]) - Convert.ToInt32((HttpContext.Current.Session["Points"])));
                        HttpContext.Current.Session["TotalAmount"] = Convert.ToDecimal(0);
                    }
                    order_list.Remove(CheckOrder);
                }
            }
            order_list = order_list.Select((r, index) => new ClsPropOrderList
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Price = r.Price,
                ActualPrice = r.ActualPrice,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                Quantity = r.Quantity,
                Image = r.Image,
                Type = r.Type,
                SNO = index + 1
            }).ToList();
            HttpContext.Current.Session["OrderList"] = order_list;
            if (order_list.Count == 0)
            {
                HttpContext.Current.Session["Points"] = null;
                HttpContext.Current.Session["TotalAmount"] = null;
                HttpContext.Current.Session["ReedemPoints"] = null;
                HttpContext.Current.Session["OrderList"] = null;
                result = "index";
            }
            else
            {
                result = "done";
            }
            return result;
        }

        [WebMethod]
        public static IList TopSearchContent(string Keyword, string type, Int64 CategoryId)
        {
            List<ClsPropCoupons> lstcoupons = new List<ClsPropCoupons>();
            List<ClsPropBusiness> lstbusiness = new List<ClsPropBusiness>();
            List<ClsPropProducts> lstproducts = new List<ClsPropProducts>();
            try
            {
                if (type.ToLower() == "business")
                {
                    ClsBusiness obj = new ClsBusiness();
                    obj.IsDeleted = false;
                    obj.Take = 10;
                    if (HttpContext.Current.Session["SelectedCityId"] != null)
                    {
                        obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                    }
                    else
                    {
                        obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                    }
                    obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                    obj.Keyword = Keyword;
                    obj.CategoryId = CategoryId;
                    lstbusiness = obj.GetAllForAjax();
                    return lstbusiness;
                }
                else if (type.ToLower() == "products")
                {
                    ClsProducts obj = new ClsProducts();
                    obj.IsDeleted = false;
                    obj.Take = 10;
                    if (HttpContext.Current.Session["SelectedCityId"] != null)
                    {
                        obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                    }
                    else
                    {
                        obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                    }
                    obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                    obj.Keyword = Keyword;
                    lstproducts = obj.GetAllForAjax();
                    return lstproducts;
                }
                else
                {
                    ClsCoupons obj = new ClsCoupons();
                    obj.IsDeleted = false;
                    obj.Take = 10;
                    if (HttpContext.Current.Session["SelectedCityId"] != null)
                    {
                        obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                    }
                    else
                    {
                        obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                    }
                    obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                    obj.Keyword = Keyword;
                    lstcoupons = obj.GetAllForAjax();
                    return lstcoupons;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [WebMethod]
        public static string SetCoordinates(string latitude, string longitude)
        {
            string result = "";
            HttpContext.Current.Session["Latitude"] = latitude;
            HttpContext.Current.Session["Longitude"] = longitude;
            result = "done";
            return result;
        }
        #endregion

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = "Hi<br/> We got a subscription for following email:<br/> " + txtsubscribe.Value + "<br/>";
            emailMessage.Subject = ClsCommon.SubjectSubscribe;
            emailMessage.To = "contact@locallinkers.com"; //ClsCommon.FromEmail;
            bool ret = ClsCommon.SendEmail(emailMessage);
            if (ret)
            {
                txtsubscribe.Value = "";
                Response.Write("<script>alert('Thanks for subscribing with us.')</script>");
            }
            else { Response.Write("<script>alert('Something went wrong.Please try again later.')</script>"); }
        }
    }
}