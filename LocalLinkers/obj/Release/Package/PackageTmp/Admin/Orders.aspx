<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="LocalLinkers.Admin.Orders" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditOrder(btn) {
            debugger;
            var id = $(btn).attr('data-id');
            var orderid = $(btn).attr('data-orderid');
            var userid = $(btn).attr('data-userid');
            var addressid = $(btn).attr('data-addressid');
            var type = $(btn).attr('data-type');
            var amount = $(btn).attr('data-amount');
            var discount = $(btn).attr('data-discount');
            var billingaddress = $(btn).attr('data-billingaddress');
            var billingname = $(btn).attr('data-billingname');
            var billingzip = $(btn).attr('data-billingzip');
            var billingstate = $(btn).attr('data-billingstate');
            var billingcity = $(btn).attr('data-billingcity');
            var billingcountry = $(btn).attr('data-billingcountry');
            var billingemail = $(btn).attr('data-billingemail');
            var billingtel = $(btn).attr('data-billingtel');
            var deliveryaddress = $(btn).attr('data-deliveryaddress');
            var deliveryname = $(btn).attr('data-deliveryname');
            var deliveryzip = $(btn).attr('data-deliveryzip');
            var deliverystate = $(btn).attr('data-deliverystate');
            var deliverycity = $(btn).attr('data-deliverycity');
            var deliverycountry = $(btn).attr('data-deliverycountry');
            var deliveryemail = $(btn).attr('data-deliveryemail');
            var deliverytel = $(btn).attr('data-deliverytel');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkOrder.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }


            $('#<%=hdnOrderId.ClientID%>').val(addressid);
            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=txtBillingAddress.ClientID%>').val(billingaddress);
            $('#<%=txtBillingCity.ClientID%>').val(billingcity);
            $('#<%=txtBillingCountry.ClientID%>').val(billingcountry);
            $('#<%=txtBillingState.ClientID%>').val(billingstate);
            $('#<%=txtBillingTel.ClientID%>').val(billingtel);
            $('#<%=txtBillingZip.ClientID%>').val(billingzip);
            $('#<%=txtBillingName.ClientID%>').val(billingname);
            $('#<%=txtBillingEmail.ClientID%>').val(billingemail);
            $('#<%=txtDeliveryAddress.ClientID%>').val(deliveryaddress);
            $('#<%=txtDeliveryCity.ClientID%>').val(deliverycity);
            $('#<%=txtDeliveryCountry.ClientID%>').val(deliverycountry);
            $('#<%=txtDeliveryState.ClientID%>').val(deliverystate);
            $('#<%=txtDeliveryTel.ClientID%>').val(deliverytel);
            $('#<%=txtDeliveryZip.ClientID%>').val(deliveryzip);
            $('#<%=txtDeliveryName.ClientID%>').val(deliveryname);
            $('#<%=txtDeliveryEmail.ClientID%>').val(deliveryemail);

            ShowPanel('Orders');

        }

        function CheckValidation() {
            var BillingAddress = $('#<%=txtBillingAddress.ClientID%>').val();
            var BillingCity = $('#<%=txtBillingCity.ClientID%>').val();
            var BillingCountry = $('#<%=txtBillingCountry.ClientID%>').val();
            var BillingState = $('#<%=txtBillingState.ClientID%>').val();
            var BillingTel = $('#<%=txtBillingTel.ClientID%>').val();
            var BillingZip = $('#<%=txtBillingZip.ClientID%>').val();
            var BillingName = $('#<%=txtBillingName.ClientID%>').val();
            var BillingEmail = $('#<%=txtBillingEmail.ClientID%>').val();
            var DeliveryEmail = $('#<%=txtDeliveryEmail.ClientID%>').val();
            var ErrorMessage = "";

            if (BillingAddress == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please senter billing address.";
                }
                $('#<%=txtBillingAddress.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingAddress.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BillingCity == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing city.";
                }
                $('#<%=txtBillingCity.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingCity.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BillingCountry == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing country.";
                }
                $('#<%=txtBillingCountry.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingCountry.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BillingState == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing state.";
                }
                $('#<%=txtBillingState.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingState.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BillingTel == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing phone.";
                }
                $('#<%=txtBillingTel.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingTel.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BillingZip == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing zip.";
                }
                $('#<%=txtBillingZip.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingZip.ClientID%>').css("border-color", "#c2cad8");
            }


            if (BillingName == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter billing name.";
                }
                $('#<%=txtBillingName.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingName.ClientID%>').css("border-color", "#c2cad8");
            }


            if (BillingEmail != "" && !IsEmail(BillingEmail)) {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter valid billing email.";
                }
                $('#<%=txtBillingEmail.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBillingEmail.ClientID%>').css("border-color", "#c2cad8");
            }

            if (DeliveryEmail != "" && !IsEmail(DeliveryEmail)) {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter valid delivery email.";
                }
                $('#<%=txtDeliveryEmail.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtDeliveryEmail.ClientID%>').css("border-color", "#c2cad8");
            }


            if (ErrorMessage != "") {
                $('#<%=lblErrorMsg.ClientID%>').text(ErrorMessage);
                $('#<%=alertDanger.ClientID%>').removeClass('hide');
                return false;
            }
            else {
                return true;
            }
        }


        function DeleteMsg(result) {
            $('#<%=lblSuccessMsg.ClientID%>').text(result.d);
            $('#<%=alertSuccess.ClientID%>').removeClass('hide');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnOrderId" />
    <asp:HiddenField runat="server" ID="hdnId" />
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="#">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Orders</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <div style="width: 100%">
        <h3 class="page-title" style="width: 85%; float: left;">Orders
                       
        <small>All Orders</small>
        </h3>
        <h3 class="page-title" style="width: 15%; float: right;">Total Records : <strong><%=TotalRecords %></strong>
        </h3>
    </div>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <!-- BEGIN DASHBOARD STATS 1-->

    <div class="clearfix"></div>
    <div class="alert alert-danger hide" id="alertDanger" runat="server">
        <asp:Label ID="lblErrorMsg" Text="" runat="server" />

    </div>
    <div class="alert alert-success hide" id="alertSuccess" runat="server">
        <asp:Label ID="lblSuccessMsg" Text="" runat="server" />
    </div>
    <div class="row GridOrders">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Orders Listing </span>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>OrderId</th>
                                    <th>UserPhone</th>
                                    <th>TrackingId</th>
                                    <th>PaymentMode</th>
                                    <th>Amount</th>
                                    <th>ReedemPoints</th>
                                    <th>Discount</th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptOrders" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("OrderId") %> </td>
                                            <td><%#Eval("UserPhone") %> </td>
                                            <td><%#Eval("TrackingId") %> </td>
                                            <td><%#Eval("PaymentMode") %> </td>
                                            <td><%#Eval("Amount") %> </td>
                                            <td><%#Eval("ReedemPoints") %> </td>
                                            <td><%#Eval("Discount") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %> </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-addressid="<%#Eval("AddressId") %>" data-userid="<%#Eval("userid") %>" data-userphone='<%#Eval("UserPhone") %>' data-trackingid='<%#Eval("TrackingId") %>' data-orderid="<%#Eval("OrderId") %>" data-type="<%#Eval("Type") %>" data-offertype="<%#Eval("OfferType") %>" data-offercode="<%#Eval("OfferCode") %>" data-discount="<%#Eval("Discount") %>" data-amount="<%#Eval("Amount") %>" data-billingaddress="<%#Eval("BillingAddress") %>" data-billingzip="<%#Eval("BillingZip") %>" data-billingname="<%#Eval("BillingName") %>" data-billingemail="<%#Eval("BillingEmail") %>" data-billingcity="<%#Eval("BillingCity") %>" data-billingcountry="<%#Eval("BillingCountry") %>" data-billingstate="<%#Eval("BillingState") %>" data-billingtel="<%#Eval("BillingTel") %>" data-deliveryname="<%#Eval("DeliveryName") %>" data-deliveryzip="<%#Eval("DeliveryZip") %>" data-deliveryaddress="<%#Eval("DeliveryAddress") %>" data-deliveryemail="<%#Eval("DeliveryEmail") %>" data-deliverycity="<%#Eval("DeliveryCity") %>" data-deliverycountry="<%#Eval("DeliveryCountry") %>" data-deliverystate="<%#Eval("DeliveryState") %>" data-deliverytel="<%#Eval("DeliveryTel") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditOrder(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>

                                                <a class="toggle delete" data-type="Order" data-id="<%#Eval("Id") %>">
                                                    <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                        Delete</label></a>
                                                <a class="toggle" href="/Admin/OrdersProducts?id=<%#Eval("Id") %>">
                                                    <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                        Products</label></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- End: life time stats -->
        </div>
    </div>
    <div class="row OrderPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Edit Order</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridOrders')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Orders</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->
                    <div id="form_sample_1" class="form-horizontal">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Name
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingName" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Address
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingAddress" TextMode="MultiLine" runat="server" class="form-control" MaxLength="500" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Phone
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingTel" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing City
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingCity" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing State
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingState" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Zip
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingZip" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="10" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Country
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingCountry" runat="server" class="form-control" MaxLength="50" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Billing Email
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBillingEmail" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Name
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryName" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Address
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryAddress" TextMode="MultiLine" runat="server" class="form-control" MaxLength="500" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Phone
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryTel" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery City
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryCity" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery State
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryState" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Zip
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryZip" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="10" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Country
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryCountry" runat="server" class="form-control" MaxLength="50" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Delivery Email
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDeliveryEmail" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Active        
                                </label>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="chkOrder" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnOrders" OnClick="btnOrders_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
                                    <button type="button" class="btn grey-salsa btn-outline">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END VALIDATION STATES-->
        </div>
    </div>
</asp:Content>
