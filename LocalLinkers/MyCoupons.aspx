<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MyCoupons.aspx.cs" Inherits="LocalLinkers.MyCoupons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">My Coupons</h4>
                            <%--<p class="category">Here is a subtitle for this table</p>--%>
                        </div>
                        <div id="divCoupons" runat="server" class="content table-responsive table-full-width">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center">SNO</th>
                                        <th class="text-center">Image</th>
                                        <th class="text-center">Title</th>
                                        <th class="text-center">Quantity</th>
                                        <th class="text-center">Price</th>
                                        <th class="text-center">Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCoupons" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center"><%#Eval("SNO") %></td>
                                                <td class="text-center">
                                                    <img src="<%#DataAccess.Classes.ClsCommon.CouponImagesPath%><%#Eval("Image") %>?width=100&height=100" alt="<%#Eval("Image") %>" style="width: 100px; height: 100px;" /></td>
                                                <td class="text-center"><%#Eval("Title") %></td>
                                                <td class="text-center"><%#Eval("Quantity") %></td>
                                                <td class="text-center"><%#Eval("Price") %></td>
                                                <td class="text-center"><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("dd/MM/yyyy") %></td>                                                
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
