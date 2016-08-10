<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CashBackCredits.aspx.cs" Inherits="LocalLinkers.CashBackCredits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">CashBack Credits</h4>
                        </div>
                        <div id="divCash" runat="server" class="content table-responsive table-full-width">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center">SNO</th>
                                        <th class="text-center">Points</th>
                                        <th class="text-center">Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCashBackCredits" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center"><%#Eval("SNO") %></td>
                                                <td class="text-center"><%#Eval("Points") %></td>
                                                <td class="text-center"><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("dd/MM/yyyy") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div id="divNoRecords" style="font-size: 20px; text-align: center; " runat="server">
                            No Records
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
