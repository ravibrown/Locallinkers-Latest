<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LadyBird.aspx.cs" Inherits="LocalLinkers.Ladybird.LadyBird" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ladybird</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="theweblab" />

    <link href="images/ico/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="images/ico/favicon.ico" rel="icon" type="image/x-icon" />

    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="lib/uikit/css/uikit.min.css" rel="stylesheet" />

    <link href="css/style.css" rel="stylesheet" />
    <link href="css/layout-style-parallax.css" rel="stylesheet" />
    <link href="css/google-font-OpenSans.css" rel="stylesheet" />

    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <link href="lib/CSS3AnnotationOverlayEffect/css/style.css" rel="stylesheet" />

    <link href="lib/jquery.bxslider/jquery.bxslider.css" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-migrate-1.0.0.js"></script>
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
            <a href="#top" id="toTop"></a>
            <!-- Header Section -->
            <div id="section1">
                <div class="top_wrapper">
                    <div class="san-top-button">
                        <button type="submit" class="btn btn-default san-discard">Discard</button>
                        <button type="submit" class="btn btn-default san-publish">Publish</button>
                    </div>
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <asp:Repeater ID="rptSliderIndicators" runat="server">
                                <ItemTemplate>
                                    <li data-target="#carousel-example-generic" data-slide-to="<%#Convert.ToInt32(Eval("SNO"))-1 %>" class="<%#(Eval("SNO").ToString() == "1"?"active":"")%>"></li>

                                </ItemTemplate>
                            </asp:Repeater>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <asp:Repeater ID="rptSlider" runat="server">
                                <ItemTemplate>
                                    <div class="item <%#(Eval("SNO").ToString() == "1"?"active":"" )%>">
                                        <img src="<%#DataAccess.Classes.ClsCommon.TemplateSliderImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- Controls -->
                    </div>

                </div>
            </div>


            <!-- Fixed navbar -->
            <div id="nav-wrapper">
                <div id="nav" class="navbar">
                    <div class="container">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <asp:Repeater ID="rptTemplate" runat="server">
                                <ItemTemplate>
                                    <a style="color: #fff" class="navbar-brand" href="#"><%#Eval("Title") %> <%--<img src="<%#DataAccess.Classes.ClsCommon.TemplateImagesPath %><%#Eval("IconImage") %>" alt="<%#Eval("IconImage") %>" />--%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="navbar-collapse collapse">
                            <ul class="nav navbar-nav navbar-right">
                                <li class="current"><a href="#section1">Home</a></li>
                                <li><a href="#section2">Services</a></li>
                                <li><a href="#section3">About Us</a></li>
                                <li><a href="#section6">Portfolio</a></li>
                                <li><a href="#section7">Contact</a></li>
                            </ul>
                        </div>
                        <!--/.nav-collapse -->
                    </div>
                </div>
            </div>

            <!-- Service/how to -->
            <div id="section2">
                <div class="wrapper white service">
                    <div class="container text-center">
                        <div class="row">
                            <div class="col-md-12 alt_heading" data-uk-scrollspy="{cls:'uk-animation-scale-up', repeat: true}">
                                <h2>Services<span></span></h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-md-6 text-center">
                                <h3>Lollipop powder danish sugar plum caramels liquorice sweet cookie.</h3>
                            </div>
                            <div class="col-md-3"></div>
                        </div>
                        <div class="row text-center">
                            <asp:Repeater ID="rptServices" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-3" data-uk-scrollspy="{cls:'uk-animation-scale-up', delay:<%#Convert.ToInt32(Eval("SNO"))*300 %>}">
                                        <i class="fa fa-user"></i>
                                        <h4><%#Eval("Title") %></h4>
                                        <p><%#Eval("Description") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Feature Section -->
            <div id="section3">
                <div class="features_wrapper">
                    <div class="wrapper deepblue features">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 text-center" data-uk-scrollspy="{cls:'uk-animation-scale-up', repeat: true}">
                                    <h2>About Us<span></span></h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="rptAboutUs" runat="server">
                    <ItemTemplate>
                        <div class="wrapper container fet">
                            <div class="row spc">
                                <div class="col-md-6" data-uk-scrollspy="{cls:'uk-animation-slide-left'}">
                                    <img src="<%#DataAccess.Classes.ClsCommon.TemplateAboutUsImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>" />
                                </div>
                                <div class="col-md-6" data-uk-scrollspy="{cls:'uk-animation-slide-right'}">
                                    <h3>About Us</h3>
                                    <p><%#Eval("AboutUs") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- Pricing Table -->
            <div id="section6">
                <div class="price_wrapper">
                    <div class="wrapper deepblue">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 text-center" data-uk-scrollspy="{cls:'uk-animation-scale-up', repeat: true}">
                                    <h2>Gallery<span></span></h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="price lightgray">
                    <div class="container">
                        <div class="row flat">
                            <asp:Repeater ID="rptGallery" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-3 col-md-3 col-xs-6 san-small-photo" data-uk-scrollspy="{cls:'uk-animation-scale-up', delay:<%#Convert.ToInt32(Eval("SNO"))*300 %>}">
                                        <img src="<%#DataAccess.Classes.ClsCommon.TemplateGalleryImagesPath %><%#Eval("Image") %>" alt="<%#Eval("Image") %>" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>


            <!-- Footer -->
            <div class="footer deepblue_footer" id="section7">
                <div class="container text-center">
                    <div class="row san-get-touch">
                        <div class="col-md-12" data-uk-scrollspy="{cls:'uk-animation-scale-up', repeat: true}">
                            <h2>Get in touch!<span></span></h2>
                        </div>
                        <div class="col-md-12" data-uk-scrollspy="{cls:'uk-animation-scale-up'}">
                            <asp:Repeater ID="rptContact" runat="server">
                                <ItemTemplate>
                                    <address class="san-address">
                                        <%#Eval("Address") %>
                                        <br />
                                        <%#Eval("City") %>
                                        <br />
                                        <%#Eval("State") %> <%#Eval("PostalCode") %>
                                        <br />
                                        <%#Eval("PhoneNumber") %>
                                        <br />
                                        <a href="mailto:<%#Eval("Email") %>"><%#Eval("Email") %></a>
                                        <br />
                                        <%#Eval("Website") %>
                                    </address>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rptSocialLink" runat="server">
                                <ItemTemplate>
                                    <ul class="social" style="margin-bottom: 0; padding-left: 0;">
                                        <li style='<%#Eval("FaceBookLink").ToString().Trim().Length>0?"display:block;": "display:none;"%>'><a href="http://<%#Eval("FaceBookLink") %>" target="_blank"><i class="fa fa-facebook"></i></a></li>
                                        <li style='<%#Eval("TwitterLink").ToString().Trim().Length>0?"display:block;": "display:none;"%>'><a href="http://<%#Eval("TwitterLink") %>" target="_blank"><i class="fa fa-twitter"></i></a></li>
                                        <li style='<%#Eval("GoogleLink").ToString().Trim().Length>0?"display:block;": "display:none;"%>'><a href="http://<%#Eval("GoogleLink") %>" target="_blank"><i class="fa fa-google-plus"></i></a></li>
                                        <li style='<%#Eval("PinInterestLink").ToString().Trim().Length>0?"display:block;": "display:none;"%>'><a href="http://<%#Eval("PinInterestLink") %>" target="_blank"><i class="fa fa-pinterest"></i></a></li>
                                        <li style='<%#Eval("TumblerLink").ToString().Trim().Length>0?"display:block;": "display:none;"%>'><a href="http://<%#Eval("TumblerLink") %>" target="_blank"><i class="fa fa-tumblr"></i></a></li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="row san-get-touch">
                        <div class="col-md-12" data-uk-scrollspy="{cls:'uk-animation-scale-up', repeat: true}">
                            <div id="mapwrapper" style="height: 350px; width: 600px;">
                                <div id="map"></div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <div class="san-footer">

                <section class="container-fluid">
                    <div class="san-footer-button">
                        <button type="submit" class="btn btn-default san-footer-discard">Discard</button>
                        <button type="submit" class="btn btn-default san-footer-publish">Publish</button>
                    </div>
                    <div class="row-fluid">
                        <section class="container">
                            <div class="row">

                                <article class="san-copyright">
                                    <div class="copyright">
                                        <p>Copyright &copy; 2016 </p>
                                    </div>
                                </article>
                                <!-- // End of .span12-->

                                <article class="san-designed">
                                    <div class="credits text-right hrttexticon">
                                        <!--<p>A premium template from Designova.</p>-->

                                        <p>Designed with <i class="fa fa-heart"></i>by <a href="http://hashbrown.in/contact" class="footeink">Hashbrown Systems</a> </p>


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


            <script src="assets/js/bootstrap.min.js"></script>

            <script src="lib/uikit/js/uikit.min.js"></script>

            <!-- mailchimp -->
            <script src="lib/mcapi-simple-subscribe-jquery/js/mailing-list.js"></script>
            <!-- mailchimp -->

            <!-- Simple-Form -->
            <script src="lib/Simple-Form/validation.js"></script>
            <script src="lib/Simple-Form/form.js"></script>
            <script src="lib/Simple-Form/index.js"></script>
            <!-- Simple-Form -->

            <script src="lib/scrollToTop/jquery.scrollToTop.min.js"></script>

            <script src="lib/jQuery-One-Page-Nav/jquery.scrollTo.js"></script>
            <script src="lib/jQuery-One-Page-Nav/jquery.nav.js"></script>

            <script src="lib/jquery-parallax/scripts/jquery.parallax-1.1.3.js"></script>

            <script src="lib/jquery.bxslider/jquery.bxslider.min.js"></script>

             <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCeszX1LpqPGWQLEQ7LcJBWlh15jUo7JFQ&amp;sensor=true"></script>

            <script src="/Template/Paramour/assets/js/plugins.js"></script>

            <script type="text/javascript">
                jQuery(document).ready(function () {
                    jQuery('.bxslider').bxSlider({
                        auto: true,
                        controls: false,
                        mode: 'vertical',
                        slideMargin: 40
                    });

                    jQuery('.top_wrapper').parallax("50%", 0.4);
                    jQuery('.features_wrapper').parallax("50%", 0.2);
                    jQuery('.subscribe_wrapper').parallax("50%", 0.2);
                    jQuery('.clients_wrapper').parallax("50%", 0.2);
                    jQuery('.team_wrapper').parallax("50%", 0.2);
                    jQuery('.price_wrapper').parallax("50%", 0.2);
                    jQuery('.faq_wrapper').parallax("50%", 0.2);

                    jQuery('.nav').onePageNav();

                    jQuery('#nav-wrapper').height($("#nav").height());

                    jQuery('#nav').affix({
                        offset: { top: $('#nav').offset().top }
                    });

                    jQuery(function () {
                        jQuery("#toTop").scrollToTop(1000);
                    });
                })
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
            <%--<script>
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
        </div>
    </form>
</body>
</html>
