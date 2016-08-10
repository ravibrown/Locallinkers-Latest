<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LocalLinkers.Category" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/UserControl/HeaderSlider.ascx" TagPrefix="uc1" TagName="HeaderSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/gsdk.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerDiv">

        <uc1:HeaderSlider runat="server" ID="HeaderSlider" />

    </div>
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Midel_div ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="cetaiconList">
        <div class="container">
            <div class="iconmain">
                <span class="iconclr">
                    <!-- <i class="fa fa-arrows"></i>-->
                    <img src="/images/icon_browse.png" alt="icon_browse.png" />
                </span>
                <h2>Browse Category </h2>
            </div>
            <div class="cetaiconList2">
                <div class="col-md-12">
                    <asp:Repeater ID="rptCategory" runat="server">
                        <ItemTemplate>
                            <div class="imageki">
                                <div class="imgview">
                                    <a href="/Business/<%#Eval("Id") %>/<%#Eval("Name").ToString().Replace(" ","-") %>">
                                        <img src="<%#DataAccess.Classes.ClsCommon.CategoryImagesPath %><%#Eval("Image") %>?height=80&width=80&mode=crop" alt="<%#Eval("Image") %>" />
                                        <br />
                                        <%#Eval("Name") %></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>
    </div>

    <!--++++++++++++++++++++++++++++++++++++++++++ End Midel_div +++++++++++++++++++++++++++++++++++++++++++-->


    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
