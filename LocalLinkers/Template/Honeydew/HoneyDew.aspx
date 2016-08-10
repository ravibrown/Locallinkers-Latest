<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoneyDew.aspx.cs" Inherits="LocalLinkers.Template.Honeydew.HoneyDew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Honeydew</title>
    <meta name="description" content="A free HTML5/CSS3 template made exclusively for Codrops by Peter Finlan" />
    <meta name="keywords" content="html5 template, css3, one page, animations, agency, portfolio, web design" />
    <meta name="author" content="Peter Finlan" />
    <!-- Bootstrap -->

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <link href="css/flickity.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Nunito:400,300,700' rel='stylesheet' type='text/css' />
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/queries.css" rel="stylesheet" />
    <!-- Facebook and Twitter integration -->
    <meta property="og:title" content="" />
    <meta property="og:image" content="" />
    <meta property="og:url" content="" />
    <meta property="og:site_name" content="" />
    <meta property="og:description" content="" />
    <meta name="twitter:title" content="" />
    <meta name="twitter:image" content="" />
    <meta name="twitter:url" content="" />
    <meta name="twitter:card" content="" />
    <style>
        .carousel-inner > .item > img, .carousel-inner > .item > a > img {
            width: 100%;
        }
    </style>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
		<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
		<![endif]-->
</head>
<body>

    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdnLongitude" />
        <asp:HiddenField runat="server" ID="hdnLatitude" />
        <div>
            <!--[if lt IE 7]>
		<p class="browsehappy">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
		<![endif]-->
            <!-- open/close -->
            <header>
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
                    <div class="container">
                        <div class="row nav-wrapper">
                            <div class="col-md-6 col-sm-6 col-xs-6 text-left san-logo-site">
                                <asp:Repeater ID="rptTemplate" runat="server">
                                    <ItemTemplate>
                                        <a href="#"><%#Eval("Title") %>
                                            <%--<img src="<%#DataAccess.Classes.ClsCommon.TemplateImagesPath %><%#Eval("IconImage") %>" alt="<%#Eval("IconImage") %>" />--%>
                                        </a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6 text-right navicon">
                                <p>MENU</p>
                                <a id="trigger-overlay" class="nav_slide_button nav-toggle" href="#"><span></span></a>
                            </div>
                        </div>

                    </div>
                </section>
            </header>


            <section class="features-intro" id="about" runat="server"  clientidmode="static">
                <asp:Repeater ID="rptAboutUs" runat="server">
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6 nopadding features-intro-img">
                                    <%--<div class="features-bg" style="background: url('<%#DataAccess.Classes.ClsCommon.TemplateAboutUsImagesPath %><%#Eval("Image") %>');background-repeat:no-repeat;">
                                        <div class="texture-overlay"></div>
                                        <div class="features-img wp1">
                                            <img src="img/html5-logo.png" alt="HTML5 Logo">
                                        </div>
                                    </div>--%>
                                    <div class="features-bg" style="background:none;">
                                        <div class="texture-overlay"></div>
                                        <div class="features-img wp1">
                                            <img src="<%#DataAccess.Classes.ClsCommon.TemplateAboutUsImagesPath %><%#Eval("Image") %>" width="100%;" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 nopadding">
                                    <h1 class="h1text aboutussection">About Us </h1>
                                    <div class="fslider">
                                        <%--                                        <ul class="slides dotsnone" id="featuresSlider">
                                            <li>--%>
                                        <%--<h1>The Fore-front of Design &amp; Technology</h1>--%>
                                        <p><%#Eval("AboutUs") %></p>

                                        <%--                                            </li>
                                        </ul>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </section>



            <section class="features-list" id="features" runat="server" clientidmode="static" style="padding: 60px 0px 90px;">
                <div class="container">
                    <h1 class="h1text">Services </h1>

                    <div class="row">

                        <div class="col-md-12">
                            <asp:Repeater ID="rptServices" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-4 feature-1 wp2">
                                        <div class="feature-icon"><i class="fa fa-desktop"></i></div>
                                        <div class="feature-content">
                                            <h1><%#Eval("Title") %></h1>
                                            <p><%#Eval("Description") %></p>
                                            <a href="#" class="read-more-btn">Read More <i class="fa fa-chevron-circle-right"></i></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>



                    </div>
                </div>
            </section>

            <section class="screenshots" id="screenshots" runat="server" clientidmode="static">
                <div class="container-fluid">
                    <div class="row">
                        <ul class="grid">
                            <asp:Repeater ID="rptGallery" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <figure>
                                            <img src="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>" />
                                            <figcaption>
                                                <div class="caption-content">
                                                    <a href="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" class="single_image">
                                                        <i class="fa fa-search"></i>
                                                        <br>
                                                        <p><%#Eval("Title") %></p>
                                                    </a>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </section>

            <section class="download downloadmapaddress" id="download" runat="server" clientidmode="static">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-9 nopadding features-intro-img">
                            <div id="mapwrapper" style="height: 447px; width: 100%;">
                                <div id="map"></div>
                            </div>
                        </div>

                        <div class="col-md-3 nopadding textpading">
                            <h1 class="Contacttext">Contact Us </h1>
                            <asp:Repeater ID="rptContact" runat="server">
                                <ItemTemplate>
                                    <ul class="col-xs-offset-4">
                                        <li style='<%#Eval("Website").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-briefcase"></i><a href="http://<%#Eval("Website") %>"> <%#Eval("Website") %></a></li>
                                        <li style='<%#Eval("Address").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-home"></i> <%#Eval("Address") %></li>
                                        <li style='<%#Eval("City").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-home"></i> <%#Eval("City") %></li>
                                        <li style='<%#Eval("State").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-home"></i> <%#Eval("State") %> <%#Eval("PostalCode") %></li>
                                        <li style='<%#Eval("PhoneNumber").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-phone"></i> <%#Eval("PhoneNumber") %></li>
                                        <li style='<%#Eval("Email").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-envelope"></i><a href="mailto:<%#Eval("Email") %>"> <%#Eval("Email") %></a></li>
                                        <li style='<%#Eval("Website").ToString().Length>0?"display:block;": "display:none !important;"%>'><i class="fa fa-tablet"></i><a href="http://<%#Eval("Website") %>"> <%#Eval("Website") %></a></li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>

                </div>

            </section>

        </div>



        <footer class="footerblack2">
            <div class="container">
                <div class="row">

                    <div class="col-md-5">
                        <asp:Repeater ID="rptSocialLink" runat="server">
                            <ItemTemplate>
                                <ul class="socialmedialink">
                                    <li class="twitter" style='background-color: #f0f0f0; <%#Eval("TwitterLink").ToString().Length>0?"display:block;": "display:none !important;"%>'><a target="_blank" href="<%#Eval("TwitterLink") %>">Twitter </a></li>
                                    <li class="facebook" style='background-color: #f0f0f0; <%#Eval("FaceBookLink").ToString().Length>0?"display:block;": "display:none !important;"%>'><a target="_blank" href="<%#Eval("FaceBookLink") %>">Facebook</a> </li>
                                    <li class="googleplus" style='background-color: #f0f0f0; <%#Eval("GoogleLink").ToString().Length>0?"display:block;": "display:none !important;"%>'><a target="_blank" href="<%#Eval("GoogleLink") %>">Google +r</a> </li>
                                    <li class="pinterest" style='background-color: #f0f0f0; <%#Eval("PinInterestLink").ToString().Length>0?"display:block;": "display:none !important;"%>'><a target="_blank" href="<%#Eval("PinInterestLink") %>">Pinterest</a> </li>
                                    <li class="tumblr" style='background-color: #f0f0f0; <%#Eval("TumblerLink").ToString().Length>0?"display:block;": "display:none !important;"%>'><a target="_blank" href="<%#Eval("TumblerLink") %>">Tumblr</a> </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>



                    <div class="col-md-7 footerancher">
                        <p class="credits">Designed with <i class="fa fa-heart"></i>by <a class="footeink" href="http://hashbrown.in/contact">Hashbrown Systems</a> </p>
                    </div>


                </div>
            </div>
        </footer>
        <div class="overlay overlay-boxify">
            <nav>
                <ul>
                    <li id="liAbout" runat="server"><a href="#about"><i class="fa fa-heart"></i>About</a></li>
                    <li id="liServices" runat="server"><a href="#features"><i class="fa fa-flash"></i>Services</a></li>
                </ul>
                <ul>
                    <li id="liPortfolio" runat="server"><a href="#screenshots"><i class="fa fa-desktop"></i>Portfolio</a></li>
                    <li id="liContact" runat="server"><a href="#download"><i class="fa fa-download"></i>Contact</a></li>
                </ul>


            </nav>
        </div>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="/js/jquery.min.js"></script>
        <script src="js/modernizr.custom.js"></script>
        <script src="js/min/toucheffects-min.js"></script>
        <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
        <script src="js/flickity.pkgd.min.js"></script>
        <script src="js/jquery.fancybox.pack.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/retina.js"></script>
        <script src="js/waypoints.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/min/scripts-min.js"></script>
        <script src="js/ap-scroll-top.js"></script>
        <!-- Google Analytics: change UA-XXXXX-X to be your site's ID. -->
        <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCeszX1LpqPGWQLEQ7LcJBWlh15jUo7JFQ&amp;sensor=true"></script>
        <script src="/Template/Paramour/assets/js/plugins.js"></script>

        <script type="text/javascript">
            // Setup plugin with default settings
            $(document).ready(function () {

                $.apScrollTop({
                    'onInit': function (evt) {
                        console.log('apScrollTop: init');
                    }
                });

                // Add event listeners
                $.apScrollTop().on('apstInit', function (evt) {
                    console.log('apScrollTop: init');
                });

                $.apScrollTop().on('apstToggle', function (evt, details) {
                    console.log('apScrollTop: toggle / is visible: ' + details.visible);
                });

                $.apScrollTop().on('apstCssClassesUpdated', function (evt) {
                    console.log('apScrollTop: cssClassesUpdated');
                });

                $.apScrollTop().on('apstPositionUpdated', function (evt) {
                    console.log('apScrollTop: positionUpdated');
                });

                $.apScrollTop().on('apstEnabled', function (evt) {
                    console.log('apScrollTop: enabled');
                });

                $.apScrollTop().on('apstDisabled', function (evt) {
                    console.log('apScrollTop: disabled');
                });

                $.apScrollTop().on('apstBeforeScrollTo', function (evt, details) {
                    console.log('apScrollTop: beforeScrollTo / position: ' + details.position + ', speed: ' + details.speed);

                    // You can return a single number here, which means that to this position
                    // browser window scolls to
                    /*
                    return 100;
                    */

                    // .. or you can return an object, containing position and speed:
                    /*
                    return {
                        position: 100,
                        speed: 100
                    };
                    */

                    // .. or do not return anything, so the default values are used to scroll
                });

                $.apScrollTop().on('apstScrolledTo', function (evt, details) {
                    console.log('apScrollTop: scrolledTo / position: ' + details.position);
                });

                $.apScrollTop().on('apstDestroy', function (evt, details) {
                    console.log('apScrollTop: destroy');
                });

            });


            // Add change events for options
            $('#option-enabled').on('change', function () {
                var enabled = $(this).is(':checked');
                $.apScrollTop('option', 'enabled', enabled);
            });

            $('#option-visibility-trigger').on('change', function () {
                var value = $(this).val();
                if (value == 'custom-function') {
                    $.apScrollTop('option', 'visibilityTrigger', function (currentYPos) {
                        var imagePosition = $('#image-for-custom-function').offset();
                        return (currentYPos > imagePosition.top);
                    });
                }
                else {
                    $.apScrollTop('option', 'visibilityTrigger', parseInt(value));
                }
            });

            $('#option-visibility-fade-speed').on('change', function () {
                var value = parseInt($(this).val());
                $.apScrollTop('option', 'visibilityFadeSpeed', value);
            });

            $('#option-scroll-speed').on('change', function () {
                var value = parseInt($(this).val());
                $.apScrollTop('option', 'scrollSpeed', value);
            });

            $('#option-position').on('change', function () {
                var value = $(this).val();
                $.apScrollTop('option', 'position', value);
            });
        </script>
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
                        image: "/Template/Paramour/assets/img/marker.png",
                        iconsize: [44, 44],
                        iconanchor: [12, 46],
                        infowindowanchor: [12, 0]
                    }
                }],
                icon: {
                    image: "/Template/Paramour/assets/img/marker.png",
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
      
    </form>
</body>
</html>
