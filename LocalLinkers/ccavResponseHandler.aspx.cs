using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using DataAccess.Classes;

public partial class ResponseHandler : System.Web.UI.Page
{
    public static string Merchant_Param1 = string.Empty;
    public static string Status = string.Empty;
    public static string MerchantPhoneNumber = string.Empty;
    public static string TrackingId = string.Empty;
    public static int UserId = 0;
    public static int OrdersId = 0;
    public static Int64 Amount = 0;
    public int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["WithoutPayment"] != null)
            {
                string NewUniqueId = ClsCommon.NewVerificationCode().ToString().Substring(0, 6);
                AddOrder("WithoutPayment", NewUniqueId, Request.QueryString["WithoutPayment"].ToString());
            }
            else
            {
                AddOrder("CCAVENUE", "", "");
            }
        }


    }
    //public void AddOrder(string paymentmethod, string OrderId)
    //{
    //    try
    //    {
    //        ClsOrderAddress ordAdrres = new ClsOrderAddress();
    //        ClsOrders ords = new ClsOrders();
    //        if (paymentmethod == "CCAVENUE")
    //        {
    //            string workingKey = ClsCommon.WorkingKey;//put in the 32bit alpha numeric key in the quotes provided here
    //            //CCACrypto ccaCrypto = new CCACrypto();
    //            //string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
    //            //string[] segments = encResponse.Split('&');
    //            foreach (string seg in Request.QueryString)
    //            {
    //                //string[] parts = seg.Split('=');
    //                //if (parts.Length > 0)
    //                {
    //                    string Key = seg; //parts[0].Trim();
    //                    string Value = Request.QueryString[seg]; //parts[1].Trim();

    //                    if (Key == "tracking_id")
    //                    {
    //                        ordAdrres.TrackingId = Value;
    //                        ords.TrackingId = Value;
    //                        TrackingId = Value;
    //                    }
    //                    else if (Key == "order_id")
    //                    {
    //                        ords.OrderId = Value;
    //                    }
    //                    else if (Key == "order_status")
    //                    {
    //                        Status = Value;
    //                    }
    //                    else if (Key == "offer_code")
    //                    {
    //                        if (Value != "null" && Value != null)
    //                        {
    //                            ords.OfferType = Value;
    //                        }
    //                    }
    //                    else if (Key == "offer_type")
    //                    {
    //                        if (Value != "null" && Value != null)
    //                        {
    //                            ords.OfferCode = Value;
    //                        }
    //                    }
    //                    else if (Key == "discount_value")
    //                    {
    //                        ords.Discount = Convert.ToDecimal(Value);
    //                    }
    //                    else if (Key == "payment_mode")
    //                    {
    //                        ordAdrres.PaymentMode = Value;
    //                    }
    //                    else if (Key == "bank_ref_no")
    //                    {
    //                        ordAdrres.BankReferenceNumber = Value;
    //                    }
    //                    else if (Key == "currency")
    //                    {
    //                        ordAdrres.Currency = Value;
    //                    }
    //                    else if (Key == "amount")
    //                    {
    //                        ords.Amount = Convert.ToDecimal(Value);
    //                        Amount = Convert.ToInt64(Value);
    //                    }
    //                    else if (Key == "billing_name")
    //                    {
    //                        ordAdrres.BillingName = Value;
    //                    }
    //                    else if (Key == "billing_address")
    //                    {
    //                        ordAdrres.BillingAddress = Value;
    //                    }
    //                    else if (Key == "billing_city")
    //                    {
    //                        ordAdrres.BillingCity = Value;
    //                    }
    //                    else if (Key == "billing_state")
    //                    {
    //                        ordAdrres.BillingState = Value;
    //                    }
    //                    else if (Key == "billing_zip")
    //                    {
    //                        ordAdrres.BillingZip = Value;
    //                    }
    //                    else if (Key == "billing_tel")
    //                    {
    //                        ordAdrres.BillingTel = Value;
    //                    }
    //                    else if (Key == "billing_country")
    //                    {
    //                        ordAdrres.BillingCountry = Value;
    //                    }
    //                    else if (Key == "billing_email")
    //                    {
    //                        ordAdrres.BillingEmail = Value;
    //                    }
    //                    else if (Key == "delivery_name")
    //                    {
    //                        ordAdrres.DeliveryName = Value;
    //                    }
    //                    else if (Key == "delivery_address")
    //                    {
    //                        ordAdrres.DeliveryAddress = Value;
    //                    }
    //                    else if (Key == "delivery_city")
    //                    {
    //                        ordAdrres.DeliveryCity = Value;
    //                    }
    //                    else if (Key == "delivery_state")
    //                    {
    //                        ordAdrres.DeliveryState = Value;
    //                    }
    //                    else if (Key == "delivery_zip")
    //                    {
    //                        ordAdrres.DeliveryZip = Value;
    //                    }
    //                    else if (Key == "delivery_tel")
    //                    {
    //                        ordAdrres.DeliveryTel = Value;
    //                    }
    //                    else if (Key == "delivery_country")
    //                    {
    //                        ordAdrres.DeliveryCountry = Value;
    //                    }
    //                    else if (Key == "delivery_email")
    //                    {
    //                        ordAdrres.DeliveryEmail = Value;
    //                    }
    //                    else if (Key == "merchant_param2")
    //                    {
    //                        Merchant_Param1 = Value;
    //                    }
    //                    else if (Key == "merchant_param3")
    //                    {
    //                        UserId = Convert.ToInt32(Value.Trim());
    //                    }
    //                    else if (Key == "merchant_param4")
    //                    {
    //                        ords.ReedemPoints = Convert.ToInt64(Value.Trim());
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (ClsCommon.GetSession() && Request.QueryString["UserId"] == null)
    //            {
    //                ClsLogin log = new ClsLogin();
    //                log.Id = ClsCommon.UserId;
    //                log.RoleId = ClsCommon.RoleId;
    //                log.GetRecord();
    //                if (log.DataRecieved)
    //                {
    //                    ordAdrres.BillingEmail = log.Email;
    //                    ordAdrres.DeliveryEmail = log.Email;
    //                    ordAdrres.BillingTel = log.PhoneNumber;
    //                    ordAdrres.DeliveryTel = log.PhoneNumber;
    //                    ordAdrres.PaymentMode = "Free";
    //                    ords.Amount = 0;
    //                    ords.Discount = 0;
    //                    if (Session["ReedemPoints"] != null)
    //                    {
    //                        ords.ReedemPoints = Convert.ToInt32(Session["ReedemPoints"]);
    //                    }
    //                    else
    //                    {
    //                        ords.ReedemPoints = 0;
    //                    }
    //                    ords.OrderId = OrderId;
    //                    TrackingId = OrderId;
    //                    Amount = 0;
    //                    UserId = Convert.ToInt32(ClsCommon.UserId);
    //                    Merchant_Param1 = Session["ProductIds"].ToString();
    //                    Status = "Success";
    //                }
    //            }
    //            else
    //            {
    //                ClsLogin log = new ClsLogin();
    //                log.Id = Convert.ToInt32(Request.QueryString["UserId"]);
    //                log.RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
    //                log.GetRecord();
    //                if (log.DataRecieved)
    //                {
    //                    ordAdrres.BillingEmail = log.Email;
    //                    ordAdrres.DeliveryEmail = log.Email;
    //                    ordAdrres.BillingTel = log.PhoneNumber;
    //                    ordAdrres.DeliveryTel = log.PhoneNumber;
    //                    ordAdrres.PaymentMode = "Free";
    //                    ords.Amount = 0;
    //                    ords.Discount = 0;
    //                    if (Request.QueryString["ReedemPoints"] != null)
    //                    {
    //                        ords.ReedemPoints = Convert.ToInt32(Request.QueryString["ReedemPoints"]);
    //                    }
    //                    else
    //                    {
    //                        ords.ReedemPoints = 0;
    //                    }
    //                    ords.OrderId = OrderId;
    //                    TrackingId = OrderId;
    //                    Amount = 0;
    //                    UserId = Convert.ToInt32(Request.QueryString["UserId"]);
    //                    Merchant_Param1 = Request.QueryString["ProductIds"].ToString().Replace("-", ",").Replace("_", "|");
    //                    Status = "Success";
    //                }
    //            }
    //        }
    //        if (Status == "Success")
    //        {
    //            ordAdrres.Add();
    //            if (ordAdrres.Id > 0 && UserId != 0)
    //            {
    //                ords.AddressId = ordAdrres.Id;
    //                ords.UserId = UserId;
    //                ords.Add();


    //                if (ords.Id > 0)
    //                {

    //                    OrdersId = Convert.ToInt32(ords.Id);
    //                    if (ords.ReedemPoints > 0)
    //                    {
    //                        ClsUserPoints pts = new ClsUserPoints();
    //                        pts.UserId = UserId;
    //                        pts.Points = -(ords.ReedemPoints);
    //                        pts.OrderId = ords.Id;
    //                        pts.IsApprovedByAdmin = true;
    //                        pts.Add();
    //                    }
    //                    if (Merchant_Param1 != "")
    //                    {
    //                        string[] merchant_params = Merchant_Param1.Split('|');
    //                        if (merchant_params.Length > 0)
    //                        {
    //                            foreach (var item in merchant_params)
    //                            {
    //                                if (item != "")
    //                                {
    //                                    string[] merch_parts = item.Split(',');
    //                                    string type = "";
    //                                    int ProductId = 0;
    //                                    if (Convert.ToInt64(merch_parts[1].Trim()) == 1)
    //                                    {
    //                                        type = "Product";
    //                                    }
    //                                    else
    //                                    {
    //                                        type = "Coupon";
    //                                    }
    //                                    ClsOrderMapping ordMapping = new ClsOrderMapping();
    //                                    ordMapping.OrderId = ords.Id;
    //                                    ordMapping.Type = type;
    //                                    ordMapping.Quantity = Convert.ToInt64(merch_parts[2].Trim());
    //                                    ClsProducts pro = new ClsProducts();
    //                                    ClsCoupons coup = new ClsCoupons();
    //                                    if (ordMapping.Type == "Product")
    //                                    {
    //                                        pro.Id = Convert.ToInt64(merch_parts[0].Trim());
    //                                        pro.IsDeleted = false;
    //                                        pro.IsApproved = (int)ClsProducts.BooleanValues.Approved;
    //                                        pro.GetRecord();
    //                                        if (pro.DataRecieved)
    //                                        {
    //                                            if (pro.Stock != 0)
    //                                            {
    //                                                pro.Stock = pro.Stock - 1;
    //                                                pro.Edit();
    //                                                ProductId = AddOrderDetail(coup, pro, "Product", Convert.ToInt64(ordMapping.Quantity));
    //                                            }
    //                                        }
    //                                    }
    //                                    else if (ordMapping.Type == "Coupon")
    //                                    {
    //                                        coup.Id = Convert.ToInt64(merch_parts[0].Trim());
    //                                        coup.IsDeleted = false;
    //                                        coup.IsApproved = (int)ClsProducts.BooleanValues.Approved;
    //                                        coup.GetRecord();
    //                                        if (coup.DataRecieved)
    //                                        {
    //                                            if (coup.Quantity != 0)
    //                                            {
    //                                                coup.Quantity = coup.Quantity - 1;
    //                                                coup.Edit();
    //                                                MerchantPhoneNumber = coup.PhoneNumber;
    //                                                ProductId = AddOrderDetail(coup, pro, "Coupon", Convert.ToInt64(ordMapping.Quantity));
    //                                            }
    //                                        }
    //                                    }
    //                                    if (ProductId > 0)
    //                                    {
    //                                        ordMapping.ProductId = ProductId;
    //                                        ordMapping.Add();
    //                                    }
    //                                    if (coup.DataRecieved)
    //                                    {
    //                                        try
    //                                        {
    //                                            if (ClsCommon.GetSession())
    //                                            {
    //                                                if (ordAdrres.BillingTel.Trim() != "" && ordAdrres.BillingTel.Trim() != ClsCommon.PhoneNumber)
    //                                                {
    //                                                    ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), coup.CouponMessage + ords.OrderId);
    //                                                }
    //                                                if (ClsCommon.PhoneNumber != "")
    //                                                {
    //                                                    ClsCommon.SendCodeThroughSms(ClsCommon.PhoneNumber.Trim(), coup.CouponMessage + ords.OrderId);
    //                                                }
    //                                            }
    //                                            else
    //                                            {
    //                                                if (ordAdrres.BillingTel.Trim() != "")
    //                                                {
    //                                                    ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), coup.CouponMessage + ords.OrderId);
    //                                                }
    //                                            }
    //                                            if (MerchantPhoneNumber != "")
    //                                            {
    //                                                string merchantmessage = ClsCommon.MerchantCouponMessage;
    //                                                merchantmessage = merchantmessage.Replace("##CouponCode##", ords.OrderId);
    //                                                ClsCommon.SendCodeThroughSms(MerchantPhoneNumber.Trim(), merchantmessage);
    //                                            }
    //                                        }
    //                                        catch (Exception ex)
    //                                        {

    //                                        }
    //                                    }
    //                                    if (Amount > 0)
    //                                    {
    //                                        ClsUserPoints points = new ClsUserPoints();
    //                                        points.UserId = UserId;
    //                                        points.OrderId = OrdersId;
    //                                        points.Points = Convert.ToInt64(Amount);
    //                                        points.IsApprovedByAdmin = true;
    //                                        points.Add();
    //                                    }
    //                                    Session["OrderList"] = null;
    //                                    Session["ProductIds"] = null;
    //                                    Session["TotalAmount"] = null;
    //                                    Session["Points"] = null;
    //                                    Session["ReedemPoints"] = null;
    //                                    Response.Redirect("/ThankYou?TransactionId=" + TrackingId);
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message + "<br/>" + ex.InnerException);
    //    }
    //}
    public void GetEmail(string msg)
    {
        EmailMessage message = new EmailMessage();
        message.Message = msg;
        message.Subject = ClsCommon.BusinessBookingSubject;
        message.To = "ravi@impact-works.com";
        ClsCommon.SendEmail(message);
    }
    public void AddOrder(string paymentmethod, string OrderId, string CreatedOrderIdForCheck)
    {

        
        string msg = string.Empty;
        try
        {
            ClsOrderAddress ordAdrres = new ClsOrderAddress();
            if (!string.IsNullOrEmpty(CreatedOrderIdForCheck))
            {
                ordAdrres.OrderId = CreatedOrderIdForCheck;
                ordAdrres.GetRecord();
                if (ordAdrres.DataRecieved)
                {
                  //  GetEmail("Already Exists " + counter);
                    Response.Write("<script>alert('Already Exist.')</script>");
                    counter++;
                    return;
                }
                else
                {
                   // GetEmail("not exists"+counter);
                }
            }
            ClsOrders ords = new ClsOrders();
            #region ccavenue
            if (paymentmethod == "CCAVENUE")
            {
                string workingKey = ClsCommon.WorkingKey;//put in the 32bit alpha numeric key in the quotes provided here
                CCACrypto ccaCrypto = new CCACrypto();
                string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);//"order_id=358274&tracking_id=105044180657&bank_ref_no=028020&order_status=Success&failure_message=&payment_mode=Credit Card&card_name=Visa&status_code=0&status_message=Transaction Successful¤cy=INR&amount=1.0&billing_name=tushar bedi&billing_address=1327/10&billing_city=Jalandhar&billing_state=Punjab&billing_zip=144001&billing_country=India&billing_tel=9988151580&billing_email=tushki.justimagine@gmail.com&delivery_name=tushar bedi&delivery_address=1327/10&delivery_city=Jalandhar&delivery_state=Punjab&delivery_zip=144001&delivery_country=India&delivery_tel=9988151580&merchant_param1=&merchant_param2=21,2,1&merchant_param3=5&merchant_param4=0&merchant_param5=&vault=N&offer_type=null&offer_code=null&discount_value=0.0&mer_amount=1.0&eci_value=05";

                string[] segments = encResponse.Split('&');
                foreach (string seg in segments)
                {
                    string[] parts = seg.Split('=');
                    if (parts.Length > 0)
                    {
                        string Key = parts[0].Trim();
                        string Value = parts[1].Trim();

                        if (Key == "tracking_id")
                        {
                            ordAdrres.TrackingId = Value;
                            ords.TrackingId = Value;
                            TrackingId = Value;
                        }
                        else if (Key == "order_id")
                        {
                            ords.OrderId = Value;
                            if (string.IsNullOrEmpty(CreatedOrderIdForCheck))
                            {
                                ordAdrres.OrderId = ords.OrderId;
                                ordAdrres.GetRecord();
                                if (ordAdrres.DataRecieved)
                                {
                                    Response.Write("<script>alert('Already Exist.')</script>");
                                    return;
                                }
                            }
                        }
                        else if (Key == "order_status")
                        {
                            Status = Value;
                        }
                        else if (Key == "offer_code")
                        {
                            if (Value != "null" && Value != null)
                            {
                                ords.OfferType = Value;
                            }
                        }
                        else if (Key == "offer_type")
                        {
                            if (Value != "null" && Value != null)
                            {
                                ords.OfferCode = Value;
                            }
                        }
                        else if (Key == "discount_value")
                        {
                            ords.Discount = Convert.ToDecimal(Value);
                        }
                        else if (Key == "payment_mode")
                        {
                            ordAdrres.PaymentMode = Value;
                        }
                        else if (Key == "bank_ref_no")
                        {
                            ordAdrres.BankReferenceNumber = Value;
                        }
                        else if (Key == "currency")
                        {
                            ordAdrres.Currency = Value;
                        }
                        else if (Key == "amount")
                        {
                            ords.Amount = Convert.ToDecimal(Value);
                            Amount = Convert.ToInt64(Convert.ToDecimal(Value));
                        }
                        else if (Key == "billing_name")
                        {
                            ordAdrres.BillingName = Value;
                        }
                        else if (Key == "billing_address")
                        {
                            ordAdrres.BillingAddress = Value;
                        }
                        else if (Key == "billing_city")
                        {
                            ordAdrres.BillingCity = Value;
                        }
                        else if (Key == "billing_state")
                        {
                            ordAdrres.BillingState = Value;
                        }
                        else if (Key == "billing_zip")
                        {
                            ordAdrres.BillingZip = Value;
                        }
                        else if (Key == "billing_tel")
                        {
                            ordAdrres.BillingTel = Value;
                        }
                        else if (Key == "billing_country")
                        {
                            ordAdrres.BillingCountry = Value;
                        }
                        else if (Key == "billing_email")
                        {
                            ordAdrres.BillingEmail = Value;
                        }
                        else if (Key == "delivery_name")
                        {
                            ordAdrres.DeliveryName = Value;
                        }
                        else if (Key == "delivery_address")
                        {
                            ordAdrres.DeliveryAddress = Value;
                        }
                        else if (Key == "delivery_city")
                        {
                            ordAdrres.DeliveryCity = Value;
                        }
                        else if (Key == "delivery_state")
                        {
                            ordAdrres.DeliveryState = Value;
                        }
                        else if (Key == "delivery_zip")
                        {
                            ordAdrres.DeliveryZip = Value;
                        }
                        else if (Key == "delivery_tel")
                        {
                            ordAdrres.DeliveryTel = Value;
                        }
                        else if (Key == "delivery_country")
                        {
                            ordAdrres.DeliveryCountry = Value;
                        }
                        else if (Key == "delivery_email")
                        {
                            ordAdrres.DeliveryEmail = Value;
                        }
                        else if (Key == "merchant_param2")
                        {
                            Merchant_Param1 = Value;
                        }
                        else if (Key == "merchant_param3")
                        {
                            UserId = Convert.ToInt32(Value.Trim());
                        }
                        else if (Key == "merchant_param4")
                        {
                            ords.ReedemPoints = 0;//Convert.ToInt64(Value.Trim());
                        }
                    }
                }
            }
            #endregion
            else
            {
                if (ClsCommon.GetSession() && Request.QueryString["UserId"] == null)
                {
                    ClsLogin log = new ClsLogin();
                    log.Id = ClsCommon.UserId;
                    log.RoleId = ClsCommon.RoleId;
                    log.GetRecord();
                    if (log.DataRecieved)
                    {
                        ordAdrres.BillingEmail = log.Email;
                        ordAdrres.DeliveryEmail = log.Email;
                        ordAdrres.BillingTel = log.PhoneNumber;
                        ordAdrres.DeliveryTel = log.PhoneNumber;
                        ordAdrres.PaymentMode = "Free";
                        ords.Amount = 0;
                        ords.Discount = 0;
                        if (Session["ReedemPoints"] != null)
                        {
                            ords.ReedemPoints = Convert.ToInt32(Session["ReedemPoints"]);
                        }
                        else
                        {
                            ords.ReedemPoints = 0;
                        }
                        ords.OrderId = OrderId;
                        TrackingId = OrderId;
                        Amount = 0;
                        UserId = Convert.ToInt32(ClsCommon.UserId);
                        Merchant_Param1 = Session["ProductIds"].ToString();
                        Status = "Success";
                    }
                }
                else
                {
                    ClsLogin log = new ClsLogin();
                    log.Id = Convert.ToInt32(Request.QueryString["UserId"]);
                    log.RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
                    log.GetRecord();
                    if (log.DataRecieved)
                    {
                        ordAdrres.BillingEmail = log.Email;
                        ordAdrres.DeliveryEmail = log.Email;
                        ordAdrres.BillingTel = log.PhoneNumber;
                        ordAdrres.DeliveryTel = log.PhoneNumber;
                        ordAdrres.PaymentMode = "Free";
                        ords.Amount = 0;
                        ords.Discount = 0;
                        if (Request.QueryString["ReedemPoints"] != null)
                        {
                            ords.ReedemPoints = Convert.ToInt32(Request.QueryString["ReedemPoints"]);
                        }
                        else
                        {
                            ords.ReedemPoints = 0;
                        }
                        ords.OrderId = OrderId;
                        TrackingId = OrderId;
                        Amount = 0;
                        UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                        Merchant_Param1 = Request.QueryString["ProductIds"].ToString().Replace("-", ",").Replace("_", "|");
                        Status = "Success";
                    }
                }
            }

            if (Status == "Success")
            {
                msg = "Entered IN Success<br/>";
                ordAdrres.Add();
                msg += "OrderAddress Added<br/>";
                if (ordAdrres.Id > 0 && UserId != 0)
                {
                    ords.AddressId = ordAdrres.Id;
                    ords.UserId = UserId;
                    ords.Add();

                    msg += "order Added";
                    if (ords.Id > 0)
                    {

                        OrdersId = Convert.ToInt32(ords.Id);
                        if (ords.ReedemPoints > 0)
                        {
                            msg += "Redeem Points entered";
                            ClsUserPoints pts = new ClsUserPoints();
                            pts.UserId = UserId;
                            pts.Points = -(ords.ReedemPoints);
                            pts.OrderId = ords.Id;
                            pts.IsApprovedByAdmin = true;

                            pts.Add();
                            msg += "Redeem Points added";
                        }
                        if (Merchant_Param1 != "")
                        {
                            string[] merchant_params = Merchant_Param1.Split('|');
                            if (merchant_params.Length > 0)
                            {
                                foreach (var item in merchant_params)
                                {
                                    if (item != "")
                                    {
                                        string[] merch_parts = item.Split(',');
                                        string type = "";
                                        int ProductId = 0;
                                        if (Convert.ToInt64(merch_parts[1].Trim()) == 1)
                                        {
                                            type = "Product";
                                        }
                                        else
                                        {
                                            type = "Coupon";
                                        }
                                        ClsOrderMapping ordMapping = new ClsOrderMapping();
                                        ordMapping.OrderId = ords.Id;
                                        ordMapping.Type = type;
                                        ordMapping.Quantity = Convert.ToInt64(merch_parts[2].Trim());
                                        ClsProducts pro = new ClsProducts();
                                        ClsCoupons coup = new ClsCoupons();
                                        if (ordMapping.Type == "Product")
                                        {
                                            pro.Id = Convert.ToInt64(merch_parts[0].Trim());
                                            pro.IsDeleted = false;
                                            pro.IsApproved = (int)ClsProducts.BooleanValues.Approved;
                                            pro.GetRecord();
                                            if (pro.DataRecieved)
                                            {
                                                if (pro.Stock != 0)
                                                {
                                                    pro.Stock = pro.Stock - 1;
                                                    pro.Edit();
                                                    ProductId = AddOrderDetail(coup, pro, "Product", Convert.ToInt64(ordMapping.Quantity));
                                                }
                                            }
                                        }
                                        else if (ordMapping.Type == "Coupon")
                                        {
                                            coup.Id = Convert.ToInt64(merch_parts[0].Trim());
                                            coup.IsDeleted = false;
                                            coup.IsApproved = (int)ClsProducts.BooleanValues.Approved;
                                            coup.GetRecord();
                                            if (coup.DataRecieved)
                                            {
                                                if (coup.Quantity != 0)
                                                {
                                                    coup.Quantity = coup.Quantity - 1;
                                                    coup.Edit();
                                                    MerchantPhoneNumber = coup.PhoneNumber;
                                                    ProductId = AddOrderDetail(coup, pro, "Coupon", Convert.ToInt64(ordMapping.Quantity));
                                                }
                                            }
                                        }
                                        if (ProductId > 0)
                                        {
                                            ordMapping.ProductId = ProductId;
                                            ordMapping.OriginalProductId = Convert.ToInt64(merch_parts[0].Trim());
                                            ordMapping.Add();
                                        }
                                        if (coup.DataRecieved)
                                        {
                                            try
                                            {
                                                string couponmessage = ClsCommon.CouponPurchaseMessage;
                                                couponmessage = couponmessage.ToString().Replace("##CouponTitle##", coup.Title);
                                                couponmessage = couponmessage.ToString().Replace("##BusinessName##", coup.BusinessName);
                                                couponmessage = couponmessage.ToString().Replace("##CouponCode##", ords.OrderId);
                                                couponmessage = couponmessage.ToString().Replace("&", "and");
                                                string UserPhoneNumberForMessage = "";
                                                if (ClsCommon.GetSession())
                                                {
                                                    if (ordAdrres.BillingTel.Trim() != "" && ordAdrres.BillingTel.Trim() != ClsCommon.PhoneNumber)
                                                    {
                                                        UserPhoneNumberForMessage = ordAdrres.BillingTel.Trim();
                                                        //ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), coup.CouponMessage + ords.OrderId);
                                                        ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), couponmessage);

                                                    }
                                                    if (ClsCommon.PhoneNumber != "")
                                                    {
                                                        UserPhoneNumberForMessage = ClsCommon.PhoneNumber.Trim();
                                                        //ClsCommon.SendCodeThroughSms(ClsCommon.PhoneNumber.Trim(), coup.CouponMessage + ords.OrderId);
                                                        ClsCommon.SendCodeThroughSms(ClsCommon.PhoneNumber.Trim(), couponmessage);
                                                    }
                                                }
                                                else
                                                {
                                                    if (ordAdrres.BillingTel.Trim() != "")
                                                    {
                                                        UserPhoneNumberForMessage = ordAdrres.BillingTel.Trim();
                                                        //ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), coup.CouponMessage + ords.OrderId);
                                                        ClsCommon.SendCodeThroughSms(ordAdrres.BillingTel.Trim(), couponmessage);
                                                    }
                                                }
                                                if (MerchantPhoneNumber != "")
                                                {
                                                    string merchantmessage = ClsCommon.MerchantCouponMessage;
                                                    merchantmessage = merchantmessage.Replace("##CouponCode##", ords.OrderId);
                                                    merchantmessage = merchantmessage.Replace("##CouponTitle##", coup.Title);
                                                    merchantmessage = merchantmessage.Replace("##UserPhoneNumber##", UserPhoneNumberForMessage);
                                                    merchantmessage = merchantmessage.Replace("&", "and");
                                                    ClsCommon.SendCodeThroughSms(MerchantPhoneNumber.Trim(), merchantmessage);
                                                }
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                        if (Amount > 0)
                                        {
                                            ClsUserPoints points = new ClsUserPoints();
                                            points.UserId = UserId;
                                            points.OrderId = OrdersId;
                                            points.Points = Convert.ToInt64(Amount);
                                            points.IsApprovedByAdmin = true;
                                            points.Add();
                                        }
                                        Session["OrderList"] = null;
                                        Session["ProductIds"] = null;
                                        Session["TotalAmount"] = null;
                                        Session["Points"] = null;
                                        Session["ReedemPoints"] = null;
                                        Response.Redirect("/ThankYou?TransactionId=" + TrackingId,true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
           // GetEmail(ex.Message + "<br/>" + ex.InnerException);
            Response.Write(ex.Message + "<br/>" + ex.InnerException);
            //Response.Write(msg);
        }
    }

    public int AddOrderDetail(ClsCoupons coup, ClsProducts pro, string type, Int64 quantity)
    {
        int ProductId = 0;
        try
        {
            ClsOrderDetails ord = new ClsOrderDetails();
            if (type == "Coupon")
            {
                ord.SubCategoryId = coup.SubCategoryId;
                ord.CategoryId = coup.CategoryId;
                ord.SelectedCity = coup.SelectedCity;
                ord.Title = coup.Title;
                ord.BusinessName = coup.BusinessName;
                ord.PhoneNumber = coup.PhoneNumber;
                ord.Address = coup.Address;
                ord.Latitude = coup.Latitude;
                ord.Longitude = coup.Longitude;
                ord.ActualPrice = coup.ActualPrice;
                ord.SalePrice = coup.SalePrice;
                ord.PayToMerchant = coup.PayToMerchant;
                ord.CouponMessage = coup.CouponMessage;
                ord.CouponPrice = coup.CouponPrice;
                ord.OfferDetails = coup.OfferDetails;
                ord.TermsAndCondition = coup.TermsAndCondition;
                ord.SelectedPosition = coup.SelectedPosition;
                ord.Quantity = quantity;
                ord.Type = type;
                ord.ShortDescription = "";
                ord.Description = "";
                ord.IsApprovedByAdmin = coup.IsApprovedByAdmin;
                ord.IsDeleted = coup.IsDeleted;
                ord.CreatedDate = coup.CreatedDate;
                ord.UpdatedDate = coup.UpdatedDate;
                ord.CreatedBy = coup.CreatedBy;
                ord.UniqueId = coup.UniqueId;
            }
            else if (type == "Product")
            {
                ord.SubCategoryId = pro.SubCategoryId;
                ord.CategoryId = pro.CategoryId;
                ord.BusinessName = "";
                ord.SelectedCity = pro.SelectedCity;
                ord.Title = pro.Title;
                ord.PhoneNumber = "";
                ord.Address = pro.Address;
                ord.Latitude = pro.Latitude;
                ord.Longitude = pro.Longitude;
                ord.ActualPrice = pro.ActualPrice;
                ord.SalePrice = pro.SalePrice;
                ord.PayToMerchant = 0;
                ord.CouponMessage = "";
                ord.CouponPrice = 0;
                ord.OfferDetails = "";
                ord.TermsAndCondition = "";
                ord.SelectedPosition = pro.SelectedPosition;
                ord.Quantity = quantity;
                ord.Type = type;
                ord.ShortDescription = pro.ShortDescription;
                ord.Description = pro.Description;
                ord.IsApprovedByAdmin = pro.IsApprovedByAdmin;
                ord.IsDeleted = pro.IsDeleted;
                ord.CreatedDate = pro.CreatedDate;
                ord.UpdatedDate = pro.UpdatedDate;
                ord.CreatedBy = pro.CreatedBy;
                ord.UniqueId = "";
            }

            if (type != "")
            {
                ord.Add();
                ProductId = Convert.ToInt32(ord.Id);
                if (ProductId > 0)
                {
                    if (type == "Product")
                    {
                        ClsProductImages pro_image = new ClsProductImages();
                        pro_image.ProductId = pro.Id;
                        pro_image.IsDeleted = false;
                        List<ClsProductImages> lst_images = pro_image.GetAll();
                        if (lst_images != null && lst_images.Count > 0)
                        {
                            foreach (var item in lst_images)
                            {
                                ClsOrderDetailImages img = new ClsOrderDetailImages();
                                img.Image = item.Image;
                                img.ProductId = ProductId;
                                img.IsApprovedByAdmin = item.IsApprovedByAdmin;
                                img.IsDeleted = item.IsDeleted;
                                img.CreatedBy = item.CreatedBy;
                                img.CreatedDate = item.CreatedDate;
                                img.UpdatedDate = item.UpdatedDate;
                                img.Add();
                            }
                        }
                    }
                    else if (type == "Coupon")
                    {
                        ClsCouponImages coup_image = new ClsCouponImages();
                        coup_image.CouponId = coup.Id;
                        coup_image.IsDeleted = false;
                        List<ClsCouponImages> lst_coupimages = coup_image.GetAll();
                        if (lst_coupimages != null && lst_coupimages.Count > 0)
                        {
                            foreach (var item in lst_coupimages)
                            {
                                ClsOrderDetailImages img = new ClsOrderDetailImages();
                                img.Image = item.Image;
                                img.ProductId = ProductId;
                                img.IsApprovedByAdmin = item.IsApprovedByAdmin;
                                img.IsDeleted = item.IsDeleted;
                                img.CreatedBy = item.CreatedBy;
                                img.CreatedDate = item.CreatedDate;
                                img.UpdatedDate = item.UpdatedDate;
                                img.Add();
                            }
                        }
                    }
                }
            }
            else
            {
                ProductId = 0;
            }

        }
        catch (Exception ex)
        {
            ProductId = 0;
        }
        return ProductId;
    }
}
