<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="LocalLinkers.ThankYou" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/gsdk.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ThanksPage">
        <div class="container">
            <div class="thanks_h2">
                <h2>THANK  YOU !   YOUR  ORDER  HAS  BEEN  PLACED </h2>
            </div>

            <div class="orderthanku">
                <h6>Your Order Transaction Id : <span><%=TransactionId %> </span></h6>
            </div>

            <div class="orderdetail">
                <div class="innerorderdetail">
                    <p>Thank you for shopping with Local Linkers. For any questions, complaint or feedback call us at +919219999000 or drop us an email at contact@locallinkers.com </p>
                    <p style="text-align: center; font-size: 16px; font-weight: bold; color: #8b2740; margin: 20px 0;">Thanks for shopping with us. </p>
                    <div class="continueorder"><a href="/Index">Continue Shopping </a></div>
                </div>
            </div>
        </div>
    </div>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
