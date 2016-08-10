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
using System.Net;
using System.Text;

namespace LocalLinkers.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        public static Int64 PageIndex = 0;
        public static Int64 SelectedPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindOrders();
                GetTotalRecords();
                BindPaging();
            }
        }


        public void GetTotalRecords()
        {
            ClsOrders obj = new ClsOrders();
            obj.IsDeleted = false;
            TotalRecords = obj.GetTotalRecords();
        }

        public void BindPaging()
        {
            try
            {
                if (TotalRecords != 0 && TotalRecords > 20)
                {
                    double Page = Convert.ToDouble(Convert.ToDouble(TotalRecords) / Convert.ToDouble(drpPage.SelectedItem.Value));
                    //var splitvalue = Page.ToString().Split('.');
                    //PageIndex= Convert.ToInt32(splitvalue[0]);
                    //if (Convert.ToInt32(splitvalue[1]) >= 5)
                    //{
                    //    PageIndex = PageIndex + 1;
                    //}
                    PageIndex = Convert.ToInt32(Math.Ceiling(Page));
                    List<Paging> lst_paging = new List<Paging>();
                    for (int i = 0; i < PageIndex; i++)
                    {
                        Paging p = new Paging();
                        p.Text = Convert.ToInt32(i + 1).ToString();
                        p.Value = i;
                        lst_paging.Add(p);
                    }
                    if (lst_paging != null && lst_paging.Count > 0)
                    {
                        rptPaging.DataSource = lst_paging;
                        rptPaging.DataBind();
                    }
                }
                else
                {
                    rptPaging.DataSource = null;
                    rptPaging.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void BindOrders()
        {
            try
            {
                ClsOrders obj = new ClsOrders();
                obj.IsDeleted = false;
                if (Convert.ToInt64(drpPage.SelectedItem.Value) != -1)
                {
                    obj.Take = Convert.ToInt64(drpPage.SelectedItem.Value);
                    obj.Index = SelectedPage;
                }
                //obj.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                rptOrders.DataSource = obj.GetAll();
                rptOrders.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void drpPage_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPage = 0;
            BindOrders();
            BindPaging();
        }
        protected void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                ClsOrderAddress obj = new ClsOrderAddress();
                ClsOrders objOrder = new ClsOrders();

                if (hdnId.Value != "")
                {
                    objOrder.Id = Convert.ToInt64(hdnId.Value);
                    objOrder.GetRecord();
                }
                if (hdnOrderId.Value != "")
                {

                    obj.Id = Convert.ToInt64(hdnOrderId.Value);
                    obj.GetRecord();
                }
                obj.BillingAddress = txtBillingAddress.Text;
                obj.BillingState = txtBillingState.Text;
                obj.BillingCity = txtBillingCity.Text;
                obj.BillingCountry = txtBillingCountry.Text;
                obj.BillingZip = txtBillingZip.Text;
                obj.BillingEmail = txtBillingEmail.Text;
                obj.BillingName = txtBillingName.Text;
                obj.BillingTel = txtBillingTel.Text;
                obj.DeliveryAddress = txtDeliveryAddress.Text;
                obj.DeliveryState = txtDeliveryState.Text;
                obj.DeliveryCity = txtDeliveryCity.Text;
                obj.DeliveryCountry = txtDeliveryCountry.Text;
                obj.DeliveryZip = txtDeliveryZip.Text;
                obj.DeliveryEmail = txtDeliveryEmail.Text;
                obj.DeliveryName = txtDeliveryName.Text;
                obj.DeliveryTel = txtDeliveryTel.Text;
                if (chkOrder.Checked)
                {
                    objOrder.IsApprovedByAdmin = true;
                    obj.IsApprovedByAdmin = true;
                }
                else
                {
                    objOrder.IsApprovedByAdmin = false;
                    obj.IsApprovedByAdmin = false;
                }
                if (obj.DataRecieved)
                {
                    obj.Edit();
                    if (objOrder.DataRecieved)
                    {
                        objOrder.Edit();
                    }
                    lblSuccessMsg.Text = "Update Successfully";
                    alertSuccess.Style.Add("display", "block !important");
                }

                ResetAll();
                BindOrders();
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetAll()
        {
            txtBillingAddress.Text = "";
            txtBillingCity.Text = "";
            txtBillingCountry.Text = "";
            hdnOrderId.Value = "";
            txtBillingEmail.Text = "";
            txtBillingName.Text = "";
            txtBillingZip.Text = "";
            txtBillingState.Text = "";
            txtBillingTel.Text = "";
            txtDeliveryAddress.Text = "";
            txtDeliveryCity.Text = "";
            txtDeliveryCountry.Text = "";
            txtDeliveryEmail.Text = "";
            txtDeliveryName.Text = "";
            txtDeliveryZip.Text = "";
            txtDeliveryState.Text = "";
            txtDeliveryTel.Text = "";
            chkOrder.Checked = false;
        }

        public void rptPaging_OnItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Paging")
            {
                foreach (RepeaterItem item in rptPaging.Items)
                {
                    LinkButton linkButton = item.FindControl("lnkPaging") as LinkButton;
                    linkButton.Enabled = true;
                    linkButton.Style.Add("color", "#fff");
                    linkButton.Style.Add("background-color", "#337ab7");
                }
                LinkButton localLink = (LinkButton)e.Item.FindControl("lnkPaging");
                localLink.Enabled = false;
                localLink.Style.Add("color", "#000");
                localLink.Style.Add("background-color", "#fff");
                SelectedPage = Convert.ToInt32(e.CommandArgument);
                BindOrders();
            }
        }

        #region "WebMethod"
        [WebMethod]
        public static string DeleteOrder(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsOrders order = new ClsOrders();
                order.Id = id;
                order.GetRecord();
                if (order.DataRecieved)
                {
                    ClsOrderAddress orderAddress = new ClsOrderAddress();
                    orderAddress.Id = Convert.ToInt64(order.AddressId);
                    orderAddress.GetRecord();
                    if (orderAddress.DataRecieved)
                    {
                        orderAddress.IsDeleted = true;
                        orderAddress.Edit();
                    }
                    ClsOrderMapping orderMapping = new ClsOrderMapping();
                    orderMapping.OrderId = Convert.ToInt64(order.Id);
                    List<ClsOrderMapping> lst_order = orderMapping.GetAll();
                    if (lst_order != null && lst_order.Count > 0)
                    {
                        orderMapping.EditList();
                    }
                    order.IsDeleted = true;
                    order.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }
        #endregion
    }
}