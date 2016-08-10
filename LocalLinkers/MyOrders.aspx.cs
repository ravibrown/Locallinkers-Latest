using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ClsCommon.GetSession())
                {
                    BindOrders();
                }
                else
                {
                    Response.Redirect("/Login");
                }
            }
        }
        public void BindOrders()
        {
            try
            {
                ClsOrderMapping order = new ClsOrderMapping();
                order.UserId = ClsCommon.UserId;
                order.IsDeleted = false;
                List<ClsOrderMapping> list_orders = order.GetAll();
                if (list_orders != null && list_orders.Count > 0)
                {
                    rptOrders.DataSource = list_orders;
                    rptOrders.DataBind();
                    divOrders.Visible = true;
                    divNoRecords.Visible = false;
                }
                else
                {
                    divOrders.Visible = false;
                    divNoRecords.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}