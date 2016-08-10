<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrdersProducts.aspx.cs" Inherits="LocalLinkers.Admin.OrdersProducts" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function ShowOrders() {
            window.location.href = "/Admin/Orders";
        }
    
    </script>

    <style>
        .category_img {
            width: 50px;
            height: 50px;
        }

        .category_img_big {
            width: 150px;
            height: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnId" />

    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="#">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Products</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <h3 class="page-title">Products
                       
        <small>Products Listing</small>
    </h3>
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

    <div class="row GridTemplateContact" id="GridTemplateContactPanel" runat="server">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Products</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowOrders();">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Orders</label></a>
                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>OrderId</th>
                                    <th>Title</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Type</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptOrdersProducts" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("CouponCode") %></td>
                                            <td><%#Eval("Title") %></td>
                                            <td><%#Eval("Quantity") %></td>
                                            <td><%#Eval("Price") %></td>
                                            <td><%#Eval("Type") %></td>
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
</asp:Content>
