<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderSlider.ascx.cs" Inherits="LocalLinkers.UserControl.HeaderSlider" %>
<div class="banner">
    <div class="carousel slide" id="carousel-47951" data-ride="carousel">
        <ol class="carousel-indicators">
            <asp:Repeater ID="rptHomeSliderIndicators" runat="server">
                <ItemTemplate>
                    <li class="<%#Convert.ToInt32(Eval("SNO"))==1?"active":"" %>" data-slide-to="<%#Convert.ToInt32(Eval("SNO"))-1%>" data-target="#carousel-47951"></li>
                </ItemTemplate>
            </asp:Repeater>
        </ol>

        <div class="carousel-inner">
            <asp:Repeater ID="rptHomeslider" runat="server">
                <ItemTemplate>
                    <div class="item <%#Convert.ToInt32(Eval("SNO"))==1?"active":"" %>">
                        <img alt="<%#Eval("Image") %>" src="<%=DataAccess.Classes.ClsCommon.HomeSliderImagesPath%><%#Eval("Image") %>" style="width: 100%;" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%--    <asp:Repeater ID="rptHomeslider" runat="server">
        <ItemTemplate>
            <img src='<%=DataAccess.Classes.ClsCommon.HomeSliderImagesPath%><%#Eval("Image") %>' alt="<%#Eval("Image") %>" />
        </ItemTemplate>
    </asp:Repeater>--%>
</div>
