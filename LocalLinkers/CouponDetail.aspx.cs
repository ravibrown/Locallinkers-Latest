using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class CouponDetail : System.Web.UI.Page
    {
        public int CouponId = 0;
        public string CouponName = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                string host = HttpContext.Current.Request.Url.AbsolutePath;
                string[] splitUrl = host.Split('/');
                CouponId = Convert.ToInt32(splitUrl[2]);
                CouponName = splitUrl[3].ToString().Replace("percent","%").Replace("-"," ");
                if (CouponId > 0)
                {
                    BindCouponDetial();
                  
                }
                else
                {
                    Response.Redirect("/Index");
                }
            }
        }

        public void BindCouponDetial()
        {
            ClsCoupons obj = new ClsCoupons();
            obj.Id = CouponId;
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
            obj.GetRecord();
            if (obj.Title.ToLower().Trim() == CouponName.ToLower().Trim() && obj.DataRecieved)
            {
                ClsCoupons record = new ClsCoupons();
                record.Id = CouponId;
                record.IsDeleted = false;
                record.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                var couponDetail = record.GetAll();
                rptCouponsDetial.DataSource = couponDetail;
                rptCouponsDetial.DataBind();

              
                BindRelatedCoupons(couponDetail.FirstOrDefault().CategoryId);
               
            }
        }

        public void BindRelatedCoupons(long? couponCategory)
        {
            ClsCoupons obj = new ClsCoupons();
            //obj.IsDeleted = false;
            //obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
            //obj.Take = 4;
            var relatedCoupons = obj.GetRelatedCoupons(couponCategory);
            if (relatedCoupons != null)
            {
                if (relatedCoupons.Count > 0)
                {
                    divRelatedCoupons.Visible = true;
                    rptRelatedCoupons.DataSource = relatedCoupons;
                    rptRelatedCoupons.DataBind();
                }
                else
                {
                    divRelatedCoupons.Visible = false;
                }
            }
            else
            {
                divRelatedCoupons.Visible = false;
            }
        }

        protected string GetImagePath(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsCouponImages img = new ClsCouponImages();
                img.CouponId = id;
                img.GetRecord();
                if (img.DataRecieved)
                {
                    result = ClsCommon.CouponImagesPath + img.Image;
                }
            }
            return result;
        }
        protected void rptCouponsDetial_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptCouponImages = (Repeater)(e.Item.FindControl("rptCouponImages"));
                HiddenField hdnId = (HiddenField)(e.Item.FindControl("hdnId"));
                ClsCouponImages obj = new ClsCouponImages();
                obj.CouponId = Convert.ToInt64(hdnId.Value);
                obj.IsDeleted = false;
                List<ClsCouponImages> objlist = obj.GetAll();
                if (objlist.Count>0 && objlist!=null)
                {
                    rptCouponImages.DataSource = objlist;
                    rptCouponImages.DataBind();
                }

                if (ClsCommon.GetSession())
                {
                    ClsOrderMapping OrderExist = new ClsOrderMapping();
                    OrderExist.UserId = ClsCommon.UserId;
                    OrderExist.OriginalProductId = Convert.ToInt64(hdnId.Value);
                    OrderExist.Type = "Coupon";
                    OrderExist.GetRecord();
                    Control divBuy = (Control)(e.Item.FindControl("divBuy"));
                    Control divPurchased = (Control)(e.Item.FindControl("divPurchased"));
                    if (OrderExist.DataRecieved)
                    {
                        divBuy.Visible = false;
                        divPurchased.Visible = true;
                    }
                    else
                    {
                        divBuy.Visible = true;
                        divPurchased.Visible = false;
                    }
                }
                //Need to assign the Data in datatable

            }

        }
    }
}