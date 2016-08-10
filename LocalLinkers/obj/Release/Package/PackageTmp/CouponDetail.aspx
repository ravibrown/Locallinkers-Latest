<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CouponDetail.aspx.cs" Inherits="LocalLinkers.CouponDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="couponDeal">
        <asp:Repeater ID="rptCouponsDetial" runat="server" OnItemDataBound="rptCouponsDetial_OnItemDataBound">
            <ItemTemplate>
                <div class="abhold">
                    <div class="abhold-text">
                        <h3><%#Eval("Title") %></h3>
                    </div>
                </div>

                <div class="container">
                    <div class="cou_poncolor">
                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' />
                        <div class="col-md-7 coupnimages">
                            <div class="carousel slide" id="carousel-47951" data-ride="carousel">
                                <div class="carousel-inner">

                                    <asp:Repeater ID="rptCouponImages" runat="server">
                                        <ItemTemplate>
                                            <div class="item <%#(Eval("SNO").ToString() == "1"?"active":"" )%>">
                                                <img src="<%#DataAccess.Classes.ClsCommon.CouponImagesPath %><%#Eval("Image") %>" alt="Carousel Bootstrap <%#(Eval("SNO").ToString() == "1"?"First":"Second" )%>" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <a class="left carousel-control" href="#carousel-47951" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control" href="#carousel-47951" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
                            </div>

                        </div>

                        <div class="col-md-5">
                            <div class="coupntext">
                                <h2><span class="fa fa-rupee"></span><%#Eval("CouponPrice") %> </h2>

                                <div class="col-md-12 text-center">
                                    <div class="col-md-12">
                                        <div class="col-md-6 col-xs-6">Value</div>
                                        <div class="col-md-6 col-xs-6">You Save</div>
                                    </div>
                                    <div class="col-md-12 col-xs-12">
                                        <div class="col-md-6 col-xs-6">
                                            <h4><span class="fa fa-rupee"></span><%#Eval("ActualPrice") %></h4>
                                        </div>
                                        <div class="col-md-6 col-xs-6">
                                            <h4><span class="fa fa-rupee"></span><%#Eval("SalePrice") %></h4>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 text-center toptextdiv"><b>Pay to Merchant:<%#Convert.ToBoolean(Eval("IsAsPerBill"))==true?" As per bill":" <span class='fa fa-rupee'></span>"+Eval("PayToMerchant")+"</b><span>"%></span></div>


                                <div class="col-md-12">
                                    <div class="col-md-12 col-sm-12 btn-warning text-center" data-id="<%#Eval("Id") %>" data-description="<%#Eval("Title") %>" data-price="<%#Eval("CouponPrice") %>" data-image="<%#Eval("Images") %>" data-title="<%#Eval("BusinessName") %>" onclick="return AddToCart(this,'Coupon');" style="cursor: pointer; margin: 0 0 7px;">
                                        <h4><span class="glyphicon glyphicon-shopping-cart"></span>Buy</h4>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">

                            <div class="centercoupon">
                                <h2>Address </h2>
                                <p><%#Eval("Address") %> </p>
                            </div>

                            <div class="centercoupon">
                                <h2>Offers Details </h2>
                                <div class="col-md-offset-1 couponofr" style="margin-left:0px;">
                                    <%#Eval("OfferDetails") %>
                                </div>
                            </div>

                            <div class="centercoupon">
                                <h2>Terms and Conditions </h2>
                                <div class="col-md-offset-1 couponofr" style="margin-left:0px;">
                                    <%#Eval("TermsAndCondition") %>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="container" id="divRelatedCoupons" runat="server">
            <div class="cou_poncolor">
                <div class="col-md-12">
                    <div class="centercoupon">
                        <h2>Related Details </h2>
                        <div class="relpix pixre">
                            <asp:Repeater ID="rptRelatedCoupons" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-3">
                                        <div class="sub_pro_full">
                                            
                                            <a href="/CouponDetail/<%#Eval("Id") %>/<%#Eval("Title").ToString().Replace(" ","-").Replace("%","percent")%>">
                                                <h2><%#Eval("Title") %>
                                                    <div class="sa_price"><i class="fa fa-inr"></i><%#Eval("CouponPrice") %>  </div>
                                                </h2>
                                                <img src="<%#DataAccess.Classes.ClsCommon.CouponImagesPath %><%#Eval("Images") %>" alt="<%#Eval("Images") %>" />
                                            </a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
