<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lambkin.aspx.cs" Inherits="LocalLinkers.Template.Lambkin.Lambkin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Lambkin</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="realm premium theme" />
    <meta name="author" content="Designova" />

    <!-- Le styles -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/typography.css" rel="stylesheet" />
    <link href="stylesheets/jquery.tweet.css" rel="stylesheet" />
    <link href="stylesheets/flexslider.css" rel="stylesheet" />



    <!--  Isotope  -->
    <link rel="stylesheet" href="stylesheets/prettyPhoto.css" />
    <link rel="stylesheet" href="stylesheets/isotope.css" />

    <!-- Custom style -->
    <link href="stylesheets/icomoon.css" rel="stylesheet" />
    <link href="stylesheets/responsive-nav.css" rel="stylesheet" />
    <link href="stylesheets/style.css" rel="stylesheet" />
    <style>
        .carousel-inner > .item > img, .carousel-inner > .item > a > img {
            width: 100%;
        }

        .gallery_img_ht {
            height: 210px;
        }

        .service_panel_mrgnbtm {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdnLongitude" />
        <asp:HiddenField runat="server" ID="hdnLatitude" />
        <asp:HiddenField runat="server" ID="hdnAddress" ClientIDMode="Static" />
        <div>

            <!-- Mobile Only Navigation - 2 types each for (480px to 640px) and (640px to 960px) wide device screens -->
            <header id="mobile-header" class="hidden-desktop clearfix">
                <div id="nav">
                    <ul class="clearfix">
                        <li id="liHomeMobile" runat="server"><a class="scroll-link" href="#header" data-soffset="0">Home</a></li>
                        <li id="liAboutMobile" runat="server"><a class="scroll-link" href="#about" data-soffset="0">About</a></li>
                        <!--       <li><a class="scroll-link" href="#portfolio" data-soffset="0">Portfolio</a></li>-->
                        <li id="liServicesMobile" runat="server"><a class="scroll-link" href="#services" data-soffset="0">Services</a></li>
                        <li id="liPortfolioMobile" runat="server"><a class="scroll-link" href="#news" data-soffset="0">portfolio</a></li>
                        <li id="liContactMobile" runat="server"><a class="scroll-link" href="#contact" data-soffset="0">Contact</a></li>
                    </ul>
                </div>
            </header>

            <div class="header-fixed-nav hidden-phone hidden-tablet">
                <div class="nav">
                    <asp:Repeater ID="rptTemplate" runat="server">
                        <ItemTemplate>
                            <a href="#">
                                <img style="padding-top:10px;" src="<%#DataAccess.Classes.ClsCommon.TemplateImagesPath %><%#Eval("IconImage") %>" alt="<%#Eval("IconImage") %>" class="logoimgtemp">
                            </a>
                            <%--<h1><%#Eval("Title") %></h1>--%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul>
                        <li id="liHome" runat="server"><a id="header-linker" class="scroll-link active" href="#header" data-soffset="0">home</a></li>
                        <li id="liAbout" runat="server"><a id="about-linker" class="scroll-link" href="#about" data-soffset="0">about</a></li>
                        <!--<li><a id="portfolio-linker" class="scroll-link" href="#portfolio" data-soffset="0">portfolio</a></li>-->
                        <li id="liServices" runat="server"><a id="services-linker" class="scroll-link" href="#services" data-soffset="0">services</a></li>
                        <li id="liPortfolio" runat="server"><a id="news-linker" class="scroll-link" href="#news" data-soffset="0">portfolio</a></li>
                        <li id="liContact" runat="server"><a id="contact-linker" class="scroll-link" href="#contact" data-soffset="0">contact</a></li>
                    </ul>
                </div>
                <div class="nav2">
                    <asp:Repeater ID="rptSocialLink" runat="server">
                        <ItemTemplate>
                            <div style='<%#Eval("FaceBookLink").ToString().Length>0?"display:block;": "display:none;"%>'><a href="<%#Eval("FaceBookLink") %>" target="_blank" class="facebook-icon"></a></div>
                            <div style='<%#Eval("GoogleLink").ToString().Length>0?"display:block;": "display:none;"%>'><a href="<%#Eval("GoogleLink") %>" target="_blank" class="google-plus-icon"></a></div>
                            <div style='<%#Eval("TwitterLink").ToString().Length>0?"display:block;": "display:none;"%>'><a href="<%#Eval("TwitterLink") %>" target="_blank" class="twitter-icon"></a></div>
                            <div style='<%#Eval("PinInterestLink").ToString().Length>0?"display:block;": "display:none;"%>'><a href="<%#Eval("PinInterestLink") %>" target="_blank" class="icon-pinterest" style="float: left; width: 100%;"></a></div>
                            <div style='<%#Eval("TumblerLink").ToString().Length>0?"display:block;": "display:none;"%>'><a href="<%#Eval("TumblerLink") %>" class="def" target="_blank"></a><i class="fa fa-tumblr"></i></div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

            <!-- Primary Page Layout
	================================================== -->

            <div id="header" runat="server" clientidmode="Static" class="page">
                <section class="container-fluid">
                    <div class="row-fluid">

                        <article class="span12">
                            <div class="logor">
                                <a href="#">
                                    <img src="images/logo.png" alt="" />
                                </a>
                            </div>
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
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <a href="#"><%#Eval("Title") %><img src="<%#DataAccess.Classes.ClsCommon.TemplateImagesPath %><%#Eval("IconImage") %>" alt="<%#Eval("IconImage") %>" /></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>

                                </div>
                            </section>
                        </article>
                        <!-- span : ends -->

                    </div>
                    <!-- row-fuild : ends -->
                </section>
                <!-- container-fluid : ends-->
            </div>
            <!-- header : ends -->
            <div class="page" id="about" runat="server" clientidmode="Static">
                <section class="container-fluid">
                    <div class="row-fluid">
                        <div data-stellar-background-ratio="2" class="service-carousel-bg-img" style="background-position: 50% -10px;">
                            <div class="service-carousel-bg-color">
                                <section class="container">
                                    <div class="row">
                                        <article class="span12">
                                            <asp:Repeater ID="rptAboutUs" runat="server">
                                                <ItemTemplate>
                                                    <div class="service-carousel-text">
                                                        <h3>About Us</h3>
                                                        <p><%#Eval("AboutUs") %></p>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </article>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                </section>
            </div>


            <!-- services carousel -->


            <div id="services" runat="server" clientidmode="Static" class="page bg-white" style="padding: 15px 0 0 0">
                <section class="container-fluid page-bg-img">
                    <div class="row-fluid">
                        <section class="container">
                            <div class="row">
                                <div class="page-style span4">
                                    <h3>services</h3>
                                    <div class="about-style-img">
                                        <img src="images/page-header-images/services.png" alt="realm" />
                                    </div>
                                </div>
                                <div class="page-style-details span8">
                                    <h3>Best from us</h3>
                                    <h5>Here is what we can promise you</h5>
                                    <p>
                                        We are a creative agency from Sao Paulo.We create perfect designs, strunning digital experience and promising brand identities. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ac nunc quis augue pellentesque condimentum. Fusce pulvinar lacus et eleifend blandit. 
                                    </p>

                                </div>


                            </div>
                            <!-- // End of .row -->
                        </section>
                        <!-- // End of .container -->
                    </div>
                    <!-- // End of .row-fluid -->
                </section>
                <!-- // End of .container-fluid -->
                <section class="container-fluid">
                    <div <%--class="row-fluid"--%>>
                        <section class="container">
                            <div class="row custom-padding" style="padding: 30px 0 0">
                                <asp:Repeater ID="rptServices" runat="server">
                                    <ItemTemplate>
                                        <article class="span3 service_panel_mrgnbtm">
                                            <div class="about-heading-<%#(Convert.ToInt32(Eval("SNO").ToString()) % 2 == 0?"black":"red")%>">
                                                <img src="images/about-images/heading-<%#(Convert.ToInt32(Eval("SNO").ToString()) % 2 == 0?"two":"one")%>.png" alt="realm">
                                            </div>
                                            <div class="about-details-red">
                                                <h3><%#Eval("Title") %></h3>
                                                <p><%#Eval("Description") %>< </p>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </section>
                        <!-- container : ends -->
                    </div>
                    <!-- row-fuild : ends -->
                </section>
                <!-- container-fluid : ends-->
            </div>
            <!-- services : ends -->



            <div id="news" runat="server" clientidmode="Static" class="page">
                <section class="container-fluid page-bg-img">
                    <div class="row-fluid">
                        <section class="container">
                            <div class="row">
                                <div class="page-style span4">
                                    <h3>portfolio</h3>
                                    <div class="about-style-img">
                                        <img alt="realm" src="images/page-header-images/portfolio.png" />
                                    </div>
                                </div>
                                <div class="page-style-details span8">
                                    <h3>Best from us</h3>
                                    <h5>Here is what we can promise you</h5>
                                    <p>
                                        We are a creative agency from Sao Paulo.We create perfect designs, strunning digital experience and promising brand identities. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ac nunc quis augue pellentesque condimentum. Fusce pulvinar lacus et eleifend blandit. 
                                    </p>

                                </div>


                            </div>
                            <!-- // End of .row -->
                        </section>
                        <!-- // End of .container -->
                    </div>
                    <!-- // End of .row-fluid -->
                </section>


                <section class="container-fluid">
                    <div class="custom-padding bg-white" style="padding: 30px 0px 0px;">
                        <section class="container">


                            <div class="row">
                                <asp:Repeater ID="rptGallery" runat="server">
                                    <ItemTemplate>
                                        <article class="span2">
                                            <div class="news-img-section">
                                                <div class="imgs img1">
                                                    <a href="#news-main-banner" class="news-scroll-link" data-title="News title can be of two lines." data-newstitle="mar 05 2013 / News Category" data-txt="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words. classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin" data-bgcolor="#D90E0E" data-color="#fff" data-href="#">
                                                        <img src="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>" class="gallery_img_ht" />
                                                        <div class="blog-attr">
                                                            <h4><%#Eval("Title") %></h4>
                                                            <p>Posted on <%#Convert.ToDateTime(Eval("CreatedDate")).ToShortTimeString()%></p>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div class="row">
                            </div>
                        </section>
                        <!-- container : ends -->
                    </div>
                    <!-- row-fuild : ends -->
                </section>
                <!-- container-fluid : ends-->
            </div>
            <!-- news : ends -->


            <div id="contact" runat="server" clientidmode="Static" class="page bg-white">
                <section class="container-fluid  page-bg-img">
                    <div class="row-fluid">
                        <section class="container">
                            <div class="row">
                                <div class="page-style span4">
                                    <h3>contact</h3>
                                    <div class="about-style-img">
                                        <img src="images/page-header-images/contact.png" alt="realm" />
                                    </div>
                                </div>
                                <div class="page-style-details span8">

                                    <div class="row">
                                        <article class="span12">
                                            <div class="contact-address iconaddress">
                                                <asp:Repeater ID="rptContact" runat="server">
                                                    <ItemTemplate>
                                                        
                                                        <p style='<%#Eval("Address").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("Address") %></p>
                                                        <p style='<%#Eval("City").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("City") %></p>
                                                        <p style='<%#Eval("State").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-home"></i><%#Eval("State") %> <%#Eval("PostalCode") %></p>
                                                        <p style='<%#Eval("PhoneNumber").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-phone"></i><%#Eval("PhoneNumber") %></p>
                                                        <p style='<%#Eval("Email").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-envelope"></i><a href="mailto:<%#Eval("Email") %>"><%#Eval("Email") %></a></p>
                                                        <p style='<%#Eval("Website").ToString().Length>0?"display:block;": "display:none;"%>'><i class="fa fa-globe"></i><a href="<%#Eval("Website") %>"><%#Eval("Website") %></a></p>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </article>
                                    </div>
                                </div>
                            </div>
                            <!-- // End of .row -->
                        </section>
                        <!-- // End of .container -->
                    </div>
                    <!-- // End of .row-fluid -->
                </section>
                <!-- // End of .container-fluid -->



                <section class="container-fluid">
                    <div id="mapwrapper" style="height: 230px; width: 100%;">
                        <div id="map"></div>
                    </div>
                </section>

            </div>
            <!-- Footer starts -->
            <div id="footer">

                <section class="container-fluid">
                    <div class="row-fluid">
                        <section class="container">
                            <div class="row">

                                <article class="span4">
                                    <div class="copyright">
                                        <p>Copyright &copy; 2016 </p>
                                    </div>
                                </article>
                                <!-- // End of .span12-->

                                <article class="span8">
                                    <div class="credits text-right hrttexticon">
                                        <!--<p>A premium template from Designova.</p>-->

                                        <p>Designed with <i class="fa fa-heart"></i>by <a class="footeink" href="http://hashbrown.in/contact">Hashbrown Systems</a> </p>


                                    </div>
                                </article>
                                <!-- // End of .span12-->

                            </div>
                            <!-- // End of .row -->
                        </section>
                        <!-- // End of .container -->
                    </div>
                    <!-- // End of .row-fluid -->
                </section>
                <!-- // End of .container-fluid -->
            </div>
            <!-- // End of #footer -->
            <!-- Footer ends -->

            <!-- JS
	================================================== -->
            <!-- jQuery Library File -->
            <script src="javascripts/jquery-1.7.2.min.js"></script>
            <script src="javascripts/jquery.easing.1.3.js"></script>

            <!-- Bootstrap JS Files -->
            <script src="assets/js/bootstrap-transition.js"></script>
            <script src="assets/js/bootstrap-alert.js"></script>
            <script src="assets/js/bootstrap-modal.js"></script>
            <script src="assets/js/bootstrap-dropdown.js"></script>
            <script src="assets/js/bootstrap-scrollspy.js"></script>
            <script src="assets/js/bootstrap-tab.js"></script>
            <script src="assets/js/bootstrap-tooltip.js"></script>
            <script src="assets/js/bootstrap-popover.js"></script>
            <script src="assets/js/bootstrap-button.js"></script>
            <script src="assets/js/bootstrap-collapse.js"></script>
            <script src="assets/js/bootstrap-carousel.js"></script>
            <script src="assets/js/bootstrap-typeahead.js"></script>
            <script src="assets/js/bootstrap-affix.js"></script>
            <script src="javascripts/jquery.tweet.js"></script>
            <script src="javascripts/responsive-nav.js"></script>
            <script src="javascripts/jquery.prettyPhoto.js"></script>
            <script src="javascripts/jquery.isotope.min.js"></script>
            <script src="javascripts/jquery.flickr.js"></script>
            <script src="javascripts/jquery.stellar.js"></script>
            <script src="javascripts/jquery.flexslider.js"></script>
            <script src="javascripts/form-validation.js"></script>
            <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCeszX1LpqPGWQLEQ7LcJBWlh15jUo7JFQ&amp;sensor=true"></script>
            
            <script src="/Template/Paramour/assets/js/plugins.js"></script>
            <!-- Custom JS Files -->
            <script src="javascripts/script.js" type="text/javascript"></script>
            <script>
                var navigation = responsiveNav("#nav", { // Selector: The ID of the wrapper
                    animate: true, // Boolean: Use CSS3 transitions, true or false
                    transition: 400, // Integer: Speed of the transition, in milliseconds
                    label: "Menu", // String: Label for the navigation toggle
                    insert: "after", // String: Insert the toggle before or after the navigation
                    customToggle: "", // Selector: Specify the ID of a custom toggle
                    openPos: "relative", // String: Position of the opened nav, relative or static
                    jsClass: "js", // String: 'JS enabled' class which is added to <html> el
                    init: function () { }, // Function: Init callback
                    open: function () { }, // Function: Open callback
                    close: function () { } // Function: Close callback
                });
            </script>
            <!-- Inline jQuery Codes -->



            <!-- supersized jquery code - Full screen BG slider -->
            <script type="text/javascript">


                $(window).load(function () {
                    $('.flexslider').flexslider({
                        animation: "slide",
                        controlNav: false
                    });
                });

                //jQuery(function ($) {



            </script>

            <script>
                //Masonry Filterable Portfolio
                $(function () {

                    var $container = $('#container');

                    $container.isotope({
                        itemSelector: '.element',
                        layoutMode: 'masonry'
                    });


                    var $optionSets = $('#options .option-set'),
                        $optionLinks = $optionSets.find('a');

                    $optionLinks.click(function () {
                        var $this = $(this);
                        // don't proceed if already selected
                        if ($this.hasClass('selected')) {
                            return false;
                        }
                        var $optionSet = $this.parents('.option-set');
                        $optionSet.find('.selected').removeClass('selected');
                        $this.addClass('selected');

                        // make option object dynamically, i.e. { filter: '.my-filter-class' }
                        var options = {},
                            key = $optionSet.attr('data-option-key'),
                            value = $this.attr('data-option-value');
                        // parse 'false' as false boolean
                        value = value === 'false' ? false : value;
                        options[key] = value;
                        if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
                            // changes in layout modes need extra logic
                            changeLayoutMode($this, options)
                        } else {
                            // creativewise, apply new options
                            $container.isotope(options);
                        }

                        return false;
                    });

                });
            </script>
             <script type="text/javascript">
                 jQuery(document).ready(function ($) {
                     var lat = $("#<%=hdnLatitude.ClientID%>").val();
                   var long = $("#<%=hdnLongitude.ClientID%>").val();
                     'use strict';

                     var contentString = '<div id="content">' +'<div id="bodyContent">' + $("#hdnAddress").val() + '</div></div>';

                     
                     //marker.addListener('click', function () {
                     //    infowindow.open(map, marker);
                     //});

                  $("#mapwrapper").gMap({
                       controls: false,
                       scrollwheel: true,
                       markers: [{
                           latitude: lat,
                           longitude: long,
                           infoWindow: {
                               content: 'Tesst'
                           },
                           icon: {
                               image: "/Template/Paramour/assets/img/marker.png",
                               iconsize: [44, 44],
                               iconanchor: [12, 46],
                               infowindowanchor: [12, 0]
                           }
                       }],
                       //icon: {
                       //    image: "/Template/Paramour/assets/img/marker.png",
                       //    iconsize: [26, 46],
                       //    iconanchor: [12, 46],
                       //    infowindowanchor: [12, 0]
                       //},
                       latitude: lat,
                       longitude: long,
                       zoom: 14
                });
                
               });
    </script>
         <%--   <script>
                function initialize() {
                    var lat = $("#<%=hdnLatitude.ClientID%>").val();
                var long = $("#<%=hdnLongitude.ClientID%>").val();
                var mycenter = new google.maps.LatLng(lat, long);
                var mapProp = {
                    center: mycenter,
                    zoom: 15,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
                var marker = new google.maps.Marker({
                    position: mycenter,
                    map: map,
                });

                marker.setMap(map);
            }
            google.maps.event.addDomListener(window, 'load', initialize);
        </script>--%>


            <script src="javascripts/retina.js"></script>
        </div>
    </form>
</body>
</html>
