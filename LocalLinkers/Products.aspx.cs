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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
        }
        #region "WebMethods"
        [WebMethod]
        public static ProductList BindProducts(int index, int take,string CategoryIds,string Keyword)
        {
            List<ClsPropProducts> lst = new List<ClsPropProducts>();
            ProductList lst_products = new ProductList();
            try
            {
                ClsProducts obj = new ClsProducts();
                obj.IsDeleted = false;
                if (HttpContext.Current.Session["SelectedCityId"] != null)
                {
                    obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                }
                else
                {
                    obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                }
                obj.Take = take;
                obj.Index = index;
                obj.IsApproved = (int)ClsProducts.BooleanValues.Approved;
                obj.CategoryIds = CategoryIds;
                obj.Keyword = Keyword;
                lst = obj.GetAllForAjax();
                if (index == 0 && CategoryIds == "")
                {
                    ClsCategory cat = new ClsCategory();
                    cat.IsDeleted = false;
                    cat.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                    lst_products.LstCategory = cat.GetAllForAjaxWithProducts();
                }
                else
                {
                    lst_products.LstCategory = null;
                }
                lst_products.LstProducts = lst;
            }
            catch (Exception ex)
            {

            }
            return lst_products;
        }
        #endregion
      
    }
    public class ProductList
    {
        //LstCategory
        private List<ClsPropCategory> _LstCategory = null;
        public List<ClsPropCategory> LstCategory
        {
            get { return _LstCategory; }
            set { _LstCategory = value; }
        }

        //LstProducts
        private List<ClsPropProducts> _LstProducts = null;
        public List<ClsPropProducts> LstProducts
        {
            get { return _LstProducts; }
            set { _LstProducts = value; }
        }
    }
}