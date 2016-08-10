<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="LocalLinkers.ProductDetail" %>
<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/UserControl/HeaderSlider.ascx" TagPrefix="uc1" TagName="HeaderSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/examples.css" rel="stylesheet" />
    <link href="/css/gsdk.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerDiv">
           <uc1:HeaderSlider runat="server" ID="HeaderSlider" />
    </div>
    <div class=" single_pro_page">
        <div class="container">
            <div class="col-md-5">
                <div class="tab-content">
                    <asp:Repeater ID="rptProductImages" runat="server">
                        <ItemTemplate>
                            <div class="tab-pane <%#(Eval("SNO").ToString() == "1"?"active":"" )%>" id="product-page<%#(Eval("SNO").ToString())%>">
                                <img src="<%#DataAccess.Classes.ClsCommon.ProductImagesPath %><%#Eval("Image") %>" alt="Carousel Bootstrap <%#(Eval("SNO").ToString() == "1"?"First":"Second" )%>" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <ul class="nav nav-text" role="tablist" id="flexiselDemo1">
                    <asp:Repeater ID="rptIndicatorImages" runat="server">
                        <ItemTemplate>
                            <li class="<%#(Eval("SNO").ToString() == "1"?"active":"" )%>"><a href="#product-page<%#(Eval("SNO").ToString())%>" role="tab" data-toggle="tab" aria-expanded="false">
                                <img src="<%#DataAccess.Classes.ClsCommon.ProductImagesPath %><%#Eval("Image") %>" alt="Carousel Bootstrap <%#(Eval("SNO").ToString() == "1"?"First":"Second" )%>" /></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <asp:Repeater ID="rptProductsDetial" runat="server">
                <ItemTemplate>
                    <div class="col-md-7">
                        <div class="product-details card-product">
                            <a href="#">
                                <h3 class="title"><%#Eval("Title") %></h3>
                            </a>
                            <p class="description"><%#Eval("ShortDescription") %>   </p>
                            <span class="price price-old">&#8377 <%#Eval("ActualPrice") %></span>
                            <span class="price price-new">&#8377 <%#Eval("SalePrice") %></span>
                        </div>

                        <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="headingOne">
                                    <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Product Description  </a></h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                    <div class="panel-body"><%#Eval("Description") %> </div>
                                </div>
                            </div>
                        </div>

                        <div class="cartprodiv">
                            <div class="selectqty"><span class="selectqtyfield">Qty</span><input type="number" onkeypress="return isNumberKey(event)" min="1" max="100" value="1" class="inputqty quantity" /></div>
                            <div class="pull-right">
                                <%--<button data-original-title="Add to wishlist" data-placement="left" title="" rel="tooltip" class="btn btn-danger btn-simple btn-hover"><i class="fa fa-heart-o"></i></button>--%>
                                <a class="btn btn-fill" data-id="<%#Eval("Id") %>" data-description="<%#Eval("ShortDescription") %>" data-price="<%#Eval("SalePrice") %>" data-image="<%#Eval("Image") %>" data-title="<%#Eval("Title") %>" onclick="return AddToCart(this,'Product');">Add to Cart</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <uc1:Footer runat="server" id="Footer" />

    <script src="/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="/js/get-shit-done.js"></script>


    <!--+++++++++++++++++++++++++++++++++++++++++ Carousel Slider Js Start ++++++++++++++++++++++++++++++++++++++++++-->

    <script src="/js/jquery.flexisel.js"></script>

    <script type="text/javascript">

        $(window).load(function () {
            $("#flexiselDemo1").flexisel({
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 1
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 2
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 3
                    }
                }
            });


            $("#flexiselDemo2").flexisel({
                enableResponsiveBreakpoints: true,
                visibleItems: 6,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 1
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 2
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 3
                    }
                }
            });
        });


    </script>
</asp:Content>
