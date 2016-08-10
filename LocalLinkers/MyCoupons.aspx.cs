using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class MyCoupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCoupons();
            }
        }

        public void BindCoupons()
        {
            try
            {
                ClsOrderMapping order = new ClsOrderMapping();
                order.UserId = ClsCommon.UserId;
                order.IsDeleted = false;
                order.Type = "Coupon";
                List<ClsOrderMapping> list_orders = order.GetAll();
                if (list_orders != null && list_orders.Count > 0)
                {
                    rptCoupons.DataSource = list_orders;
                    rptCoupons.DataBind();
                    divCoupons.Visible = true;
                    divNoRecords.Visible = false;
                }
                else
                {
                    divCoupons.Visible = false;
                    divNoRecords.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}