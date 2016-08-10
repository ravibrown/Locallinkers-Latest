<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LocalLinkers.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link href="/css/gsdk.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            var d = new Date().getTime();
            document.getElementById("tid").value = d;
            var points = '<%=Session["Points"] %>';
            $("#<%=txtPoints.ClientID%>").val(points);

        };

        function SubmitForm() {
            var amount = parseInt($('#hdnAmount').val());
            var ProductIds = $('#hdnProductIds').val();
            var OrderId = $('#hdnOrderId').val();
            if (amount > 0) {
                $("#PaymentForm").submit();
            }
            else {
                window.location.href = '/ccavResponseHandler.aspx?WithoutPayment=' + OrderId;
            }
        }

        function ReedemPoints() {
            var ExactPoints = $("#hdnPoints").val();
            var points = $("#<%=txtPoints.ClientID%>").val();
            var TotalAmount = $("#<%=lblTotalAmount.ClientID%>").text();
            var ReedemPoints = $("#<%=lblReedemPoints.ClientID%>").text();
            if (points == "")
            {
                $("#<%=txtPoints.ClientID%>").val(ExactPoints);
                alert("Please enter correct value.");
                return false;
            }
            if (parseInt(points) == 0 || parseInt(ExactPoints) == 0) {
                alert("You dont have points for reedem.");
                $("#<%=txtPoints.ClientID%>").val(ExactPoints);
                ShowReedem();
                return false;
            }

            if (parseFloat(TotalAmount) <= 0) {
                alert("Your reedem points is not used because total amount is 0. ");
                ShowReedem();
                return false;
            }

            if (parseInt(points) < 0) {
                alert("Neagative values not allowed.");
                $("#<%=txtPoints.ClientID%>").val(ExactPoints);
                ShowReedem();
                return false;
            }

            if (parseInt(ExactPoints) < parseInt(points)) {
                alert("Please enter only less than " + ExactPoints + " points or equal to " + ExactPoints + " points.");
                $("#<%=txtPoints.ClientID%>").val(ExactPoints);
                ShowReedem();
                return false;
            }
            var SetAmount = 0;
            var SetReedemPoints = 0;
            if (parseInt(TotalAmount) < parseInt(points)) {
                SetAmount = parseFloat(0).toFixed(2);
                SetReedemPoints = parseInt(parseInt(ExactPoints) - parseInt(TotalAmount));
                ReedemPoints = parseInt(ReedemPoints) + parseInt(TotalAmount);
            }
            else {
                SetAmount = parseFloat(parseFloat(TotalAmount) - parseFloat(points)).toFixed(2);
                SetReedemPoints = parseInt(parseInt(ExactPoints) - parseInt(points));
                ReedemPoints = parseInt(ReedemPoints) + parseInt(points);
            }

            $.ajax({
                url: '/Cart.aspx/SetPoints',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{ "points":"' + parseInt(SetReedemPoints) + '","TotalAmount":"' + parseFloat(SetAmount) + '","ReedemPoints":"' + parseInt(ReedemPoints) + '"}',
                success: function (data) {
                    if (data.d == "done") {
                        $("#<%=txtPoints.ClientID%>").val(SetReedemPoints);
                        $("#<%=lblReedemPoints.ClientID%>").text(ReedemPoints);
                        $("#<%=lblTotalAmount.ClientID%>").text(SetAmount);
                        $("#hdnPoints").val(SetReedemPoints);
                        $("#merchant_param4").val(ReedemPoints);
                        $("#amount").val(SetAmount);
                        $("#hdnAmount").val(SetAmount);
                        ShowReedem();
                    }
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }

        function CheckPoints() {
            $("#btnReedemPoints").css("display", "none");
            $("#btnSubmitPoints").removeClass("hide");
            $("#<%=txtPoints.ClientID%>").removeClass("hide");
        }

        function ShowReedem() {
            $("#btnReedemPoints").css("display", "block");
            $("#btnSubmitPoints").addClass("hide");
            $("#<%=txtPoints.ClientID%>").addClass("hide");
        }
    </script>
    <style>
        .txt-width {
            float: left;
            width: 70px;
            margin: 5px 0px 0 3px;
            padding: 6px 7px;
        }

        .btn_blue {
            background: #2ca8ff none repeat scroll 0 0;
            border-radius: 2px;
            color: #fff;
            float: left;
            font-size: 14px;
            margin: 5px 4px 0 8px;
            padding: 8px 15px;
        }

            .btn_blue:hover {
                color: #fff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Cart Profile  ++++++++++++++++++++++++++++++++++++++++-->

    <input type="hidden" id="hdnOrderId" value="<%=OrderId %>" />
    <input type="hidden" id="hdnAmount" value="<%=Convert.ToDecimal(Session["TotalAmount"]) %>" />
    <input type="hidden" id="hdnPoints" value="<%=Convert.ToInt64(Session["Points"]) %>" />
    <input type="hidden" id="hdnProductIds" value="<%=ProductIds %>" />
    <div class="cartprofile">
        <div class="container">
            <div class="row" style="background: rgb(255, 255, 255) none repeat scroll 0% 0%; box-shadow: 0px 1px 4px rgba(0, 0, 0, 0.23); margin-top: 15px; margin-bottom: 10px;">
                <div class="col-md-12">
                    <h4>Shopping Cart Table</h4>
                </div>
                <!--<div class="col-md-10 col-md-offset-1">-->
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table table-shopping">
                            <thead>
                                <tr>
                                    <th class="text-center"></th>
                                    <th class="tblimg">Product</th>
                                    <th class="th-description tableone">Description</th>
                                    <th class="text-right tabletwo">Price</th>
                                    <th class="text-right tablethree">Qty</th>
                                    <th class="text-right tablefour">Amount</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCart" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="img-container tblimg">
                                                    <img src="<%#Eval("Image") %>" alt="<%#Eval("Image") %>">
                                                </div>
                                            </td>
                                            <td class="td-name nameone"><%#Eval("Title") %> </td>
                                            <td class="tableone">
                                                <p><%#Eval("Description") %></p>
                                            </td>

                                            <td class="td-number tabletwo"><small>&#8377</small><%#Eval("Price") %> </td>
                                            <td class="td-number tablethree"><small>x</small><%#Eval("Quantity") %>  </td>
                                            <td class="td-number tablefour"><small>&#8377</small><%#Eval("ActualPrice") %> </td>
                                            <td class="td-actions">
                                                <a type="button" rel="tooltip" onclick="return RemoveCartItem(this);" data-id="<%#Eval("Id") %>" data-type="<%#Eval("Type") %>" data-placement="left" title="Remove item" class="btn btn-danger btn-simple btn-icon "><i class="fa fa-times"></i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div class="pricebottem">
                            <p style="margin-right: 146px;">
                                <span>Reedem Points </span>
                                <asp:Label ID="lblReedemPoints" runat="server">
                               <%=Convert.ToInt64(Session["ReedemPoints"]) %> </asp:Label>
                            </p>
                        </div>

                        <div class="pricebottem">
                            <div>
                                <a onclick="CheckPoints();" id="btnReedemPoints" class="anchor_Cursor btn_blue">Reedem Points</a>
                                <asp:TextBox ID="txtPoints" Text="" runat="server" onkeypress="return isNumberKey(event)" class="hide txt-width" />
                                <a onclick="ReedemPoints();" id="btnSubmitPoints" class="anchor_Cursor btn_blue hide">Submit </a>
                            </div>
                            <a onclick="SubmitForm();" class="anchor_Cursor">Continue  <i class="fa fa-chevron-right"></i></a>
                            <p>
                                <span>Total </span>&#8377 
                                <asp:Label ID="lblTotalAmount" runat="server">
                               <%=Convert.ToDecimal(Session["TotalAmount"]) %> </asp:Label>
                            </p>
                        </div>
                    </div>

                </div>
            </div>


        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End Cart Profile  ++++++++++++++++++++++++++++++++++++++++-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form method="post" id="PaymentForm" name="customerData" action="ccavRequestHandler.aspx">
        <input type="hidden" name="tid" id="tid" readonly />
        <input type="hidden" name="merchant_id" id="merchant_id" value="<%=DataAccess.Classes.ClsCommon.MerchantKey %>" />
        <input type="hidden" id="order_id" name="order_id" value="<%=OrderId %>" />
        <input type="hidden" id="amount" name="amount" value="<%=Convert.ToDecimal(Session["TotalAmount"]) %>" />
        <input type="hidden" name="currency" value="<%=DataAccess.Classes.ClsCommon.Currency %>" />
        <input type="hidden" name="redirect_url" value="<%=DataAccess.Classes.ClsCommon.RedirectUrl %>" />
        <input type="hidden" name="cancel_url" value="<%=DataAccess.Classes.ClsCommon.CancelUrl %>" />.
        <input type="hidden" id="merchant_param2" name="merchant_param2" value="<%=ProductIds %>" />
        <input type="hidden" id="merchant_param3" name="merchant_param3" value="<%=DataAccess.Classes.ClsCommon.UserId %>" />
        <input type="hidden" id="merchant_param4" name="merchant_param4" value="<%=Convert.ToInt64(Session["ReedemPoints"]) %>" />
    </form>
</asp:Content>


