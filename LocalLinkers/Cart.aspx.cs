using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Cart : System.Web.UI.Page
    {
        public static string OrderId = string.Empty;
        public static string ProductIds = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["OrderList"] != null)
                {
                    if (ClsCommon.GetSession())
                    {
                        OrderId = ClsCommon.NewVerificationCode().ToString().Substring(0, 6);
                        BinOrderList();
                        SumPoints();
                    }
                    else
                    {
                        Response.Redirect("/Login?ReturnUrl=/Cart");
                    }
                }
                else
                {
                    Response.Redirect("/Index");
                }

            }
        }

        public void BinOrderList()
        {
            List<ClsPropOrderList> lst = (List<ClsPropOrderList>)Session["OrderList"];
            if (lst != null && lst.Count > 0)
            {
                int count = 0;
                ProductIds = "";
                for (int i = lst.Count - 1; i >= 0; i--)
                {
                    ClsOrderMapping OrderExist = new ClsOrderMapping();
                    OrderExist.UserId = ClsCommon.UserId;
                    OrderExist.OriginalProductId = lst[i].Id;
                    OrderExist.Type = "Coupon";
                    OrderExist.GetRecord();
                    if (OrderExist.DataRecieved)
                    {
                        lst.RemoveAt(i);
                        lblWaringMsg.Text = "Some items has been removed from your cart because that already purchased by you.";
                    }
                    else
                    {
                        count = count + 1;
                        int typeid = 0;
                        if (lst[i].Type == "Product")
                        {
                            typeid = 1;
                        }
                        else
                        {
                            typeid = 2;
                        }
                        if (lst.Count != count)
                        {
                            ProductIds += lst[i].Id + "," + typeid + "," + lst[i].Quantity + "|";
                        }
                        else
                        {
                            ProductIds += lst[i].Id + "," + typeid + "," + lst[i].Quantity;
                        }
                    }

                }
                Session["OrderList"] = lst;
                if (lst != null && lst.Count > 0)
                {
                    rptCart.DataSource = lst;
                    rptCart.DataBind();
                    if (Session["ReedemPoints"] == null)
                    {
                        Session["ReedemPoints"] = 0;
                    }
                    Session["TotalAmount"] = lst.Sum(a => a.ActualPrice).Value;
                    Session["TotalAmount"] = Convert.ToDecimal(Session["TotalAmount"]) - Convert.ToDecimal(Session["ReedemPoints"]);
                    Session["ProductIds"] = ProductIds;
                }
                else
                {
                    Response.Write("<script>alert('All items has been removed from your cart because that already purchased by you.');window.location.href='/Index';</script>");
                }
            }
        }

        public void SumPoints()
        {
            ClsUserPoints point = new ClsUserPoints();
            point.UserId = ClsCommon.UserId;
            point.IsDeleted = false;
            if (Session["Points"] == null && Convert.ToInt64(Session["Points"]) == 0)
            {
                Session["Points"] = point.SumPoints();
            }
        }

        #region"WebMethods"
        [WebMethod]
        public static string SetPoints(Int64 points, decimal TotalAmount, Int64 ReedemPoints)
        {
            string result = "";
            try
            {
                HttpContext.Current.Session["Points"] = points;
                HttpContext.Current.Session["ReedemPoints"] = ReedemPoints;
                HttpContext.Current.Session["TotalAmount"] = TotalAmount;
                result = "done";
            }
            catch (Exception ex)
            {
                result = "error";
            }
            return result;
        }
        #endregion
    }
}