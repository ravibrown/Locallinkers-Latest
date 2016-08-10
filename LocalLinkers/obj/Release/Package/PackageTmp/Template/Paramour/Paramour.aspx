<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paramour.aspx.cs" Inherits="LocalLinkers.Template.Paramour.Paramour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>Paramour</title>
    <meta content="Insert Your Site Description" name="description" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/prettyPhoto.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/pe-icons.css" rel="stylesheet" />
    <link href="assets/css/animate.css" rel="stylesheet" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/css?family=Droid+Sans:400,700,300" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="assets/img/ico/favicon.ico" />
    <link rel="apple-touch-icon" sizes="144x144" href="assets/img/ico/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="assets/img/ico/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="assets/img/ico/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" href="assets/img/ico/apple-touch-icon-57x57.png" />
    <script src="assets/js/modernizr.js"></script>
    <script src="assets/js/jquery.js"></script>

    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var lat = $("#<%=hdnLatitude.ClientID%>").val();
            var long = $("#<%=hdnLongitude.ClientID%>").val();
            'use strict';
            $("#mapwrapper").gMap({
                controls: false,
                scrollwheel: true,
                markers: [{
                    latitude: lat,
                    longitude: long,
                    icon: {
                        image: "assets/img/marker.png",
                        iconsize: [44, 44],
                        iconanchor: [12, 46],
                        infowindowanchor: [12, 0]
                    }
                }],
                icon: {
                    image: "assets/img/marker.png",
                    iconsize: [26, 46],
                    iconanchor: [12, 46],
                    infowindowanchor: [12, 0]
                },
                latitude: lat,
                longitude: long,
                zoom: 14
            });
        });
    </script>
    <style>
        .carousel-inner > .item > img, .carousel-inner > .item > a > img {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdnLongitude" />
        <asp:HiddenField runat="server" ID="hdnLatitude" />
        <div>
            <header>
                <div class="home-nav">
                    <div class="container">
                        <a href="#" class="mobile-nav"></a>

                        <div class="logo">
                            <a href="#home-slider" title="Bold | Responsive One Page Template"><span class="fa fa-ticket logo-icon"></span>
                                <asp:Repeater ID="rptTemplate2" runat="server">
                                    <ItemTemplate>
                                        <h1><%#Eval("Title") %></h1>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </a>
                        </div>

                        <nav id="home-menu">
                            <ul id="home-menu-nav">
                                <li class="current"><a href="#home-slider">Home</a></li>
                                <li><a href="#about">About Us</a></li>
                                <li><a href="#services">Services</a></li>
                                <li><a href="#work">Portfolio</a></li>
                                <li><a href="#contact">Contact</a></li>
                            </ul>
                        </nav>

                    </div>
                </div>
            </header>
            <!-- End Header -->

            <div class="ole">
                <div id="jSplash">
                    <div id="circle"></div>
                </div>
            </div>
            <!-- End of Splash Screen -->
            <!-- Homepage Slider -->

            <div id="home-slider">
                <section class="hero">
                    <div class="texture-overlay">

                        <div data-ride="carousel" class="carousel slide" id="carousel-example-generic">
                            <!-- Indicators -->
                            <ol class="carousel-indicators">
                                <asp:Repeater ID="rptSliderIndicators" runat="server">
                                    <ItemTemplate>
                                        <li data-target="#carousel-example-generic" data-slide-to="<%#Convert.ToInt32(Eval("SNO"))-1 %>" class="<%#(Eval("SNO").ToString() == "1"?"active":"")%>"></li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ol>


                            <div role="listbox" class="carousel-inner">
                                <asp:Repeater ID="rptSlider" runat="server">
                                    <ItemTemplate>
                                        <div class="item <%#(Eval("SNO").ToString() == "1"?"active":"" )%>">
                                            <img src="<%#DataAccess.Classes.ClsCommon.TemplateSliderImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>

                    </div>

                </section>

            </div>
            <!-- End Homepage Slider -->
            <!-- Header -->

            <header>
                <div class="sticky-nav fade-in">
                    <div class="container">
                        <a href="#" class="mobile-nav"></a>

                        <div class="logo">
                            <a href="#home-slider" title="Logo"><span class="fa fa-ticket logo-icon"></span>
                                <asp:Repeater ID="rptTemplate" runat="server">
                                    <ItemTemplate>
                                        <h1><%#Eval("Title") %></h1>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </a>
                        </div>

                        <nav id="menu">
                            <ul id="menu-nav">
                                <li><a href="#home-slider">Home</a></li>
                                <li><a href="#about">About Us</a></li>
                                <li><a href="#services">Services</a></li>
                                <li><a href="#work">portfolio</a></li>
                                <li><a href="#contact">Contact</a></li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </header>
            <!-- End Header -->

            <div class="section" id="about">
                <div class="container">
                    <!-- Title Page -->

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="title-page">
                                <h2 class="title fade-down">About Us</h2>
                                <hr class="fade-up" />
                                <h3 class="title-description fade-up">Who Are We?</h3>
                            </div>
                        </div>
                    </div>
                    <asp:Repeater ID="rptAboutUs" runat="server">
                        <ItemTemplate>
                            <div class="row gap">
                                <div class="col-md-8 fade-left">
                                    <p style="font-size: 30px;line-height: 40px;"><%#Eval("AboutUs") %></p>
                                </div>
                                <div class="col-md-4">
                                    <div class="qa-message-list" id="wallmessages">
                                        <div class="message-item fade-right">
                                            <div class="message-inner">
                                                <div class="message-head clearfix">
                                                    <div class="user-detail">
                                                        <%--<img src="assets/img/about_img.jpg" alt="aboutus" />--%>
                                                         <img src="<%#DataAccess.Classes.ClsCommon.TemplateAboutUsImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>"/>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>




                    <div class="row">
                        <div id="logo-slider" class="owl-carousel">
                        </div>
                    </div>
                </div>
            </div>
            <!-- End About Section -->

            <div class="divider-wrapper" id="services">
                <div class="container">

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="title-page">
                                <h2 class="title fade-down">Services</h2>
                                <hr class="fade-up" />
                                <h3 class="title-description fade-up">Who Can We Do For You?</h3>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <asp:Repeater ID="rptServices" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-1 centered">
                                    <i class="fa fa-certificate service-icon fade-left"></i>
                                </div>
                                <div class="col-lg-3 fade-right">
                                    <h3><%#Eval("Title") %></h3>
                                    <p><%#Eval("Description") %></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!-- End About Section -->

            <!-- Our Work Section -->

            <div class="section" id="work">
                <div class="container">

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="title-page">
                                <h2 class="title fade-down">Our Work</h2>
                                <hr class="fade-up" />
                                <h3 class="title-description fade-up">Some Examples Of What We Do</h3>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="" >
                    <div class="row">

                        <div class=" ">
                            <section id="projects">
                                <ul id="thumbs" style="width:100%;">
                                    <!-- Item Project and Filter Name -->
                                    <asp:Repeater ID="rptGallery" runat="server">
                                        <ItemTemplate>
                                            <li class="portfolio-item image-wrap col-md-3 design">
                                                <div class="hover-wrap">
                                                    <h2><%#Eval("Title") %></h2>
                                                    <span class="overlay-text-thumb">
                                                        <a class="overlay-link" data-rel="prettyPhoto" href="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" title="<%#Eval("Title") %>"><i class="fa fa-picture-o"></i></a>
                                                        <!-- <a class="overlay-link" href="single-project.html" title="Image Title"><i class="fa fa-link"></i></a>-->
                                                    </span>
                                                </div>
                                                <img src="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>" />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </section>
                        </div>
                    </div>
                    <!-- End Portfolio Projects -->
                </div>
            </div>
            <!-- End Our Work Section -->
            <!-- About Section -->



            <div id="mapwrapper">
                <div id="googleMap"></div>
            </div>

            <div class="section" id="contact" style="padding: 50px 15px">
                <div class="container">
                    <!-- Title Page -->

                    <div class="row">
                        <div class="col-sm-3 col-md-12" style="text-align: center">
                            <div class="contact-details fade-right clrul">
                                <h3>Contact Details</h3>
                                <asp:Repeater ID="rptContact" runat="server">
                                    <ItemTemplate>
                                        <ul>
                                            <li style='<%#Eval("Website").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-briefcase"></i><a href="http://<%#Eval("Website") %>"><%#Eval("Website") %></a></li>
                                            <li style='<%#Eval("Address").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("Address") %></li>
                                            <li style='<%#Eval("City").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("City") %></li>
                                            <li style='<%#Eval("State").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("State") %> <%#Eval("PostalCode") %></li>
                                            <li style='<%#Eval("PhoneNumber").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-phone"></i><%#Eval("PhoneNumber") %></li>
                                            <li style='<%#Eval("Email").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-envelope"></i><a href="mailto:<%#Eval("Email") %>"><%#Eval("Email") %></a></li>
                                            <li style='<%#Eval("Website").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-tablet"></i><a href="http://<%#Eval("Website") %>"><%#Eval("Website") %></a></li>
                                        </ul>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Footer -->
            <footer>
                <div class="container">
                    <div class="row">
                        <asp:Repeater ID="rptSocialLink" runat="server">
                            <ItemTemplate>
                                <div id="footer-social" class="col-sm-6 col-md-6" style="text-align: left;">
                                    <nav id="social">
                                        <ul>
                                            <li style='<%#Eval("TwitterLink").ToString().Length>0?"display:block;": "display:none;"%>'>
                                                <div class="flip">
                                                    <div class="card">
                                                        <div style='<%#Eval("TwitterLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face front"><a href="http://<%#Eval("TwitterLink") %>" class="bounce-in" target="_blank" title="Follow Me on Twitter"><i class="fa fa-twitter"></i></a></div>
                                                        <div style='<%#Eval("TwitterLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face back"><a href="http://<%#Eval("TwitterLink") %>" class="bounce-in" target="_blank" title="Follow Me on Twitter"><i class="fa fa-twitter"></i></a></div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li style='<%#Eval("PinInterestLink").ToString().Length>0?"display:block;": "display:none;"%>'>
                                                <div class="flip">
                                                    <div class="card">
                                                        <div style='<%#Eval("PinInterestLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face front"><a href="http://<%#Eval("PinInterestLink") %>" class="bounce-in" target="_blank" title="Follow Me on Dribbble"><i class="fa fa-pinterest"></i></a></div>
                                                        <div style='<%#Eval("PinInterestLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face back"><a href="http://<%#Eval("PinInterestLink") %>" class="bounce-in" target="_blank" title="Follow Me on Dribbble"><i class="fa fa-pinterest"></i></a></div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li style='<%#Eval("FaceBookLink").ToString().Length>0?"display:block;": "display:none;"%>'>
                                                <div class="flip">
                                                    <div class="card">
                                                        <div style='<%#Eval("FaceBookLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face front"><a href="http://<%#Eval("FaceBookLink") %>" class="bounce-in" target="_blank" title="Follow Me on Facebook"><i class="fa fa-facebook"></i></a></div>
                                                        <div style='<%#Eval("FaceBookLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face back"><a href="http://<%#Eval("FaceBookLink") %>" class="bounce-in" target="_blank" title="Follow Me on Facebook"><i class="fa fa-facebook"></i></a></div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li style='<%#Eval("GoogleLink").ToString().Length>0?"display:block;": "display:none;"%>'>
                                                <div class="flip">
                                                    <div class="card">
                                                        <div style='<%#Eval("GoogleLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face front"><a href="http://<%#Eval("GoogleLink") %>" class="bounce-in" target="_blank" title="Follow Me on Google Plus"><i class="fa fa-google-plus"></i></a></div>
                                                        <div style='<%#Eval("GoogleLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face back"><a href="http://<%#Eval("GoogleLink") %>" class="bounce-in" target="_blank" title="Follow Me on Google Plus"><i class="fa fa-google-plus"></i></a></div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li style='<%#Eval("TumblerLink").ToString().Length>0?"display:block;": "display:none;"%>'>
                                                <div class="flip">
                                                    <div class="card">
                                                        <div style='<%#Eval("TumblerLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face front"><a href="http://<%#Eval("TumblerLink") %>" class="bounce-in" target="_blank" title="Follow Me on LinkedIn"><i class="fa fa-tumblr"></i></a></div>
                                                        <div style='<%#Eval("TumblerLink").ToString().Length>0?"display:block;": "display:none;"%>' class="face back"><a href="http://<%#Eval("TumblerLink") %>" class="bounce-in" target="_blank" title="Follow Me on LinkedIn"><i class="fa fa-tumblr"></i></a></div>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                        <div class="col-sm-6 col-md-6">
                            <p class="credits" style="text-align: right;">Designed with <i class="fa fa-heart" style="color: #fe6e3a;"></i>by <a class="footeink" href="http://hashbrown.in/contact" style="color: #fe6e3a;">Hashbrown Systems</a> </p>
                        </div>
                    </div>
                </div>
            </footer>
            <!-- End Footer -->

            <!-- Search -->
            <div class="modal fade" id="search-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-body">
                            <input type="text" name="search" id="search" placeholder="Enter Your Search Term Here" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Back To Top -->
            <a href="#" id="back-to-top"><i class="fa fa-angle-up"></i></a>
            <!-- End Back to Top -->

            <script src="assets/js/bootstrap.min.js"></script>
            <script src="assets/js/prettyPhoto.js"></script>
            <script src="assets/js/plugins.js"></script>
            <script src="assets/js/init.js"></script>
            <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCeszX1LpqPGWQLEQ7LcJBWlh15jUo7JFQ&amp;sensor=true"></script>

        </div>
    </form>
</body>
</html>
