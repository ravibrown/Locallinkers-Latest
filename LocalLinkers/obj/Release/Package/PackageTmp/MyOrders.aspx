<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="LocalLinkers.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">My Orders</h4>
                            <%--<p class="category">Here is a subtitle for this table</p>--%>
                        </div>
                        <div id="divOrders" runat="server" class="content table-responsive table-full-width">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center">SNO</th>
                                        <th class="text-center">Image</th>
                                        <th class="text-center">Title</th>
                                        <th class="text-center">Quantity</th>
                                        <th class="text-center">Price</th>
                                        <th class="text-center">Date</th>
                                        <th class="text-center">Type</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptOrders" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center"><%#Eval("SNO") %></td>
                                                <td class="text-center">
                                                    <img src="<%#Eval("Type").ToString()=="Coupon"?DataAccess.Classes.ClsCommon.CouponImagesPath:DataAccess.Classes.ClsCommon.ProductImagesPath%><%#Eval("Image") %>" alt="<%#Eval("Image") %>" style="width: 50px; height: 50px;" /></td>
                                                <td class="text-center"><%#Eval("Title") %></td>
                                                <td class="text-center"><%#Eval("Quantity") %></td>
                                                <td class="text-center"><%#Eval("Price") %></td>
                                                <td class="text-center"><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("dd/MM/yyyy") %></td>
                                                <td class="text-center"><%#Eval("Type") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div id="divNoRecords" style="font-size: 20px; text-align: center;" runat="server">
                            No Records
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
