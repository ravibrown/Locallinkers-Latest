using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Admin
{
    public partial class OrdersProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindProducts();
                }
            }
        }

        public void BindProducts()
        {
            try
            {
                ClsOrderMapping obj = new ClsOrderMapping();
                obj.IsDeleted = false;
                obj.OrderId = Convert.ToInt64(Request.QueryString["id"]);
                rptOrdersProducts.DataSource = obj.GetAll();
                rptOrdersProducts.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

    }
}