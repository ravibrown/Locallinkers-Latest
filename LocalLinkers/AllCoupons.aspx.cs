using DataAccess.Classes;
using Newtonsoft.Json;
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
    public partial class AllCoupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region "WebMethod"
        [WebMethod]
        public static CouponList BindCoupons(int index, int take,string CategoryIds,string Keyword)
        {
            List<ClsPropCoupons> lst = new List<ClsPropCoupons>();
            CouponList lst_Coupons = new CouponList();
            try
            {
                ClsCoupons obj = new ClsCoupons();
                obj.IsDeleted = false;
                obj.Take = take;
                if (HttpContext.Current.Session["SelectedCityId"] != null)
                {
                    obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                }
                else
                {
                    obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                }

                var latlong = ClsCommon.GetLatLongByCityID(obj.SelectedCity);
                HttpContext.Current.Session["Latitude"] = latlong.Latitude;
                HttpContext.Current.Session["Longitude"] = latlong.Longitude;
                obj.Latitude= latlong.Latitude; 
                obj.Longitude = latlong.Longitude;

                obj.Index = index;
                obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                obj.CategoryIds = CategoryIds;
                obj.Keyword = Keyword;
                lst = obj.GetAllForAjax();
                if (index == 0 && CategoryIds=="")
                {
                    ClsCategory cat = new ClsCategory();
                    cat.IsDeleted = false;
                    cat.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                    lst_Coupons.LstCategory = cat.GetAllForAjaxWithCoupons();
                }
                else
                {
                    lst_Coupons.LstCategory = null;
                }
                lst_Coupons.LstCoupons = lst;
                
            }
            catch(Exception ex)
            {
               
            }
            return lst_Coupons;
        }
        #endregion
    }

    public class CouponList
    {
        //LstCategory
        private List<ClsPropCategory> _LstCategory = null;
        public List<ClsPropCategory> LstCategory
        {
            get { return _LstCategory; }
            set { _LstCategory = value; }
        }

        //LstCoupons
        private List<ClsPropCoupons> _LstCoupons = null;
        public List<ClsPropCoupons> LstCoupons
        {
            get { return _LstCoupons; }
            set { _LstCoupons = value; }
        }
    }
}