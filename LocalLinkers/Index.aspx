<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LocalLinkers.Index" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/UserControl/HeaderSlider.ascx" TagPrefix="uc1" TagName="HeaderSlider" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/gsdk.css?random=12345" rel="stylesheet" />
    <style>
        .cat_icon {
            height: 32px;
            width: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:HeaderSlider runat="server" ID="HeaderSlider" />
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Midel_div ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="midel_div">
        <div class="container">
            <div class="category _nvi">
                <ul>
                    <asp:Repeater ID="rptCategory" runat="server">
                        <ItemTemplate>
                            <li><a href="/Business/<%#Eval("Id") %>/<%#Eval("Name").ToString().Replace(" ","-").Replace("%","percent") %>">
                                <img src="<%#DataAccess.Classes.ClsCommon.CategoryImagesPath %><%#Eval("Image") %>?height=32&width=32&mode=crop" class="cat_icon" alt="<%#Eval("Image") %>" />
                                <p>
                                    <%#Eval("Name") %>
                                </p>
                            </a></li>

                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="view">
                    <a href="/Category" class="btn btn-block btn-lg btn-fill btn-info">View More</a>
                </div>
            </div>
            <div class="hotdeal">
                <h3><span>Trending</span> in <%=Session["SelectedCity"] %> <a href="/AllCoupons">MORE <i class="fa fa-chevron-right"></i></a></h3>
            </div>
            <div class="cardddiv">
                <asp:Repeater ID="rptCards" runat="server">
                    <ItemTemplate>
                        <div class="<%#ChangeCardWidth(Convert.ToInt32(Eval("SNO"))) %>">
                            <a href="/CouponDetail/<%#Eval("Id") %>/<%#Eval("Title").ToString().Replace(" ","-").Replace("%","percent") %>">
                                <div class="card card-background">
                                    <div class="image" style="background-image: url('<%#DataAccess.Classes.ClsCommon.CouponImagesPath %><%#Eval("Images") %>'); background-position: center center; background-size: cover;">
                                        <img alt="Image<%#Convert.ToInt32(Eval("SNO")) %>" src="<%#DataAccess.Classes.ClsCommon.CouponImagesPath %><%#Eval("Images") %>" style="display: none;" />
                                        <div class="<%#ChangeCardColor(Convert.ToInt32(Eval("SNO"))) %>"></div>
                                    </div>
                                    <div class="content">

                                        <a href="/CouponDetail/<%#Eval("Id") %>/<%#Eval("Title").ToString().Replace(" ","-").Replace("%","percent") %>">
                                            <br />
                                            <h4 class="title"><%#Eval("Title") %><br />
                                                <%-- <small>€ 450/mo</small>--%>
                                            </h4>

                                        </a>
                                    </div>
                                    <div class="footer">
                                        <i class="fa fa-map-marker"></i><%#Eval("Address") %>,<%#Eval("CityName") %><div class="author pull-right">
                                            <a data-placement="left" title="" rel="tooltip" href="#" >&#8377 <%#Eval("CouponPrice") %>
                                            <%--<a data-placement="left" title="" rel="tooltip" href="#" data-original-title="Radu Tintescu">&#8377 <%#Eval("CouponPrice") %>--%>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <!-- end card -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <!--++++++++++++++++++++++++++++++++++++++++++ End Midel_div +++++++++++++++++++++++++++++++++++++++++++-->



    <!--+++++++++++++++++++++++++++++++++++++++++ Start RedSpace ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="redspace">
        <div class="container">
            <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
            <!-- new728/90 code -->
            <ins class="adsbygoogle"
                style="display: inline-block; width: 100%; height: 90px"
                data-ad-client="ca-pub-7022945573268635"
                data-ad-slot="4003310509"></ins>
            <script>
                (adsbygoogle = window.adsbygoogle || []).push({});
            </script>
        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End RedSpace ++++++++++++++++++++++++++++++++++++++++++-->

    <!--+++++++++++++++++++++++++++++++++++++++++ Strt Dealslist ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="Dealslist">
        <div class="container">
            <div class="hotdeal">
                <h3><span>Big Savers</span> in <%=Session["SelectedCity"] %>  <a href="/Products">MORE <i class="fa fa-chevron-right"></i></a></h3>
            </div>
            <div id="product-cards" class="">
                <div class="col-md-12 scrollbackgrund">
                    <asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="rptProducts_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-md-4">
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' />
                                <div class="card card-product">
                                    <div class="image">
                                        <div data-ride="carousel" class="carousel slide" id="card-product-carousel<%#(Eval("SNO").ToString())%>">
                                            <div class="carousel-inner">
                                                <asp:Repeater ID="rptProductImages" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item <%#(Eval("SNO").ToString() == "1"?"active":"" )%>">
                                                            <img src="<%#DataAccess.Classes.ClsCommon.ProductImagesPath %><%#Eval("Image") %>" alt="Carousel Bootstrap <%#(Eval("SNO").ToString() == "1"?"First":"Second" )%>" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <a data-slide="prev" href="#card-product-carousel<%#(Eval("SNO").ToString())%>" class="left carousel-control">
                                                <span class="fa fa-angle-left"></span>
                                            </a>
                                            <a data-slide="next" href="#card-product-carousel<%#(Eval("SNO").ToString())%>" class="right carousel-control">
                                                <span class="fa fa-angle-right"></span>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="content">
                                        <a href="/ProductDetail/<%#Eval("Id") %>/<%#Eval("Title").ToString().Replace(" ","-").Replace("%","percent") %>">
                                            <h4 class="title"><%#Eval("Title") %></h4>
                                        </a>
                                        <p class="description editdescription">
                                            <%#Eval("ShortDescription") %>
                                        </p>
                                        <div class="footer">
                                            <span class="price price-old">&#8377 <%#Eval("ActualPrice") %></span>
                                            <span class="price price-new">&#8377 <%#Eval("SalePrice") %></span>
                                            <a class="btn btn-default btn-fill pull-right btn-xs btn-hover">
                                                <i class="fa fa-star"></i>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End Dealslist ++++++++++++++++++++++++++++++++++++++++++-->

    <!--+++++++++++++++++++++++++++++++++++++++++ Start RedSpace ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="redspace">
        <div class="container">
            <div class="red_space">
                <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <!-- Godaddy Add -->
                <ins class="adsbygoogle"
                    style="display: inline-block; width: 728px; height: 90px"
                    data-ad-client="ca-pub-7022945573268635"
                    data-ad-slot="1950536502"></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>

            </div>
        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End RedSpace ++++++++++++++++++++++++++++++++++++++++++-->

    <!--+++++++++++++++++++++++++++++++++++++++++ Start city_deals ++++++++++++++++++++++++++++++++++++++++++-->

    <%--<div class="city_deals">
        <div class="container" style="padding: 0px;">
            <div class="hotdeal">
                <h3><span>Hot Deals</span> in <%=Session["SelectedCity"] %></h3>
            </div>
        </div>
        <div class="container" style="border: 1px solid #ddd;">
            <ul class="row" id="flexiselDemo2">
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img1.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">Amazing Discount at Flipkart</h4>
                            </a>
                        </div>
                    </div>
                </li>
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img2.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">Get yummy treat on mcsonalds</h4>
                            </a>
                        </div>
                    </div>
                </li>
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img3.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">amazing dicount on pepperfry</h4>
                            </a>
                        </div>
                    </div>
                </li>
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img4.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">Amazing discounts at FirstCry</h4>
                            </a>
                        </div>
                    </div>
                </li>
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img5.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">one stop destination for all products</h4>
                            </a>
                        </div>
                    </div>
                </li>
                <li class="col-md-2">
                    <div class="card card-product card-plain">
                        <div class="image">
                            <a href="#">
                                <img src="images/slider_img2.png" alt="..." />
                            </a>
                        </div>
                        <div class="content">
                            <a href="#">
                                <h4 class="title">Get yummy treat on mcsonalds</h4>
                            </a>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>--%>
    <div class="city_deals">

        <div class="subscribe-line subscribe-line-transparent" style="background-image: url(/images/email_pic.png)">
            <div class="container">
                <div class="row">
                    <div class="col-md-9">
                        <%--<form class="">--%>
                            <div class="form-group">
                                <input id="txtsubscribe"  runat="server" type="text" value="" class="form-control" placeholder="Kindly enter your email for fantabulous offers.">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Text="*" ControlToValidate="txtsubscribe" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" Text="*"  ControlToValidate="txtsubscribe" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                       
                                     </div>
                        <%--</form>--%>
                    </div>
                    <div class="col-md-3">
                        <asp:Button id="btnSubscribe" runat="server" CssClass="btn btn-warning btn-fill btn-block" Text="Subscribe Now!" OnClick="btnSubscribe_Click" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!--+++++++++++++++++++++++++++++++++++++++++ End city_deals ++++++++++++++++++++++++++++++++++++++++++-->


    <!--+++++++++++++++++++++++++++++++++++++++++ Start Local_shops ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="local_shops">
        <div class="container">
        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End Local_shops ++++++++++++++++++++++++++++++++++++++++++-->
    <uc1:Footer runat="server" ID="Footer" />


    
    <script src="/js/get-shit-done.js"></script>


    <!--+++++++++++++++++++++++++++++++++++++++++ Carousel Slider Js Start ++++++++++++++++++++++++++++++++++++++++++-->

    <script src="/js/jquery.flexisel.js"></script>

    <script type="text/javascript">
        function deeplinking() {
            if (navigator.userAgent.match(/iPhone|iPad|iPod/i)) {

                window.location = "locallinkers://";

                setTimeout(function () {
                    //window.location = 'itms-apps://itunes.apple.com/app/browze-app/id1049738179?mt=8'
                    window.location = 'itms-apps://itunes.apple.com/us/app/local-linkers/id1098179119?mt=8'
                }, 250);

            }
            else if (navigator.userAgent.match(/Android/i)) {
                window.location = 'intent://#Intent;scheme=locallinkers;package=com.hbs.hashbrownsys.locallinkers;end;';
            }
           
        }

        $(function () {
            deeplinking();
        })
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



    <!--+++++++++++++++++++++++++++++++++++++++++ Carousel Slider Js End ++++++++++++++++++++++++++++++++++++++++++-->
</asp:Content>
