using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        public int ProductId = 0;
        public string ProductName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string host = HttpContext.Current.Request.Url.AbsolutePath;
                string[] splitUrl = host.Split('/');
                ProductId = Convert.ToInt32(splitUrl[2]);
                ProductName = splitUrl[3].ToString().Replace("percent","%").Replace("-", " ");
                if (ProductId > 0)
                {
                    BindProductDetial();
                    BindProductImages();
                }
                else
                {
                    Response.Redirect("/Index");
                }
            }
        }
        public void BindProductDetial()
        {
            ClsProducts obj = new ClsProducts();
            obj.Id = ProductId;
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsProducts.BooleanValues.Approved;
            obj.GetRecord();
            if (obj.Title == ProductName && obj.DataRecieved)
            {
                rptProductsDetial.DataSource = obj.GetAll();
                rptProductsDetial.DataBind();
            }
        }

        public void BindProductImages()
        {
            ClsProductImages obj = new ClsProductImages();
            obj.ProductId = ProductId;
            obj.IsDeleted = false;
            rptProductImages.DataSource = obj.GetAll();
            rptProductImages.DataBind();
            rptIndicatorImages.DataSource = obj.GetAll();
            rptIndicatorImages.DataBind();
        }

    }
}