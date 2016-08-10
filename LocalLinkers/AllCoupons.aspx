<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AllCoupons.aspx.cs" Inherits="LocalLinkers.AllCoupons" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/UserControl/HeaderSlider.ascx" TagPrefix="uc1" TagName="HeaderSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="css/gsdk.css" rel="stylesheet" />
    <link href="css/examples.css" rel="stylesheet" />
    <style>
        .tu_Float_Right {
            color: #333;
            float: right;
        }

        .Couponlist {
            height: 382px;
        }
    </style>
    <script>
        var take = 10;
        var index = 0;
        var CategoryIds = [];
        var CheckLoader = false;
        $(document).ready(function () {
            ShowCouponList(this);
        });
        function ShowCouponList(btn) {
            if (!CheckLoader) {
                LoaderShow();
            }
            index = index + 1;
            var keyword = $(btn).attr("data-keyword");
            if (typeof keyword === "undefined") {
                keyword = "";
            }
            else if (keyword != "") {
                LoaderShow();
                $("#div_SearchContent").hide();
                CategoryIds = "";
                index = 1;
            }
            $.ajax({
                url: '/AllCoupons.aspx/BindCoupons',
                type: "POST",
                data: '{ "index":"' + parseInt(index - 1) + '","take":"' + parseInt(take) + '","CategoryIds":"' + CategoryIds + '","Keyword":"' + keyword + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d.LstCoupons.length > 0) {
                        if (index - 1 == 0 || CheckLoader) {
                            $("#CouponTemplate").empty();
                        }
                        if (index - 1 == 0 && CategoryIds == '') {
                            $("#CategoryCheckBox").empty();
                            if (result.d.LstCategory.length > 0) {
                                $("#CheckBoxCategoryScript").tmpl(result.d.LstCategory).appendTo("#CategoryCheckBox");
                            }
                        }
                        $("#CouponScriptTemplate").tmpl(result.d.LstCoupons).appendTo("#CouponTemplate");
                        if (result.d.LstCoupons.length != 10) {
                            $(".btnloadclr").css("display", "none");
                        }
                        else {
                            $(".btnloadclr").css("display", "block");
                        }
                    }
                    else {
                        if (index - 1 == 0) {
                            $("#CouponTemplate").html('<div style="width:100%;text-align:left;font-size:14px;font-weight:bold"><font color="black">No Record.</font></div>');
                        }
                        $(".btnloadclr").css("display", "none");
                    }
                    LoaderHide();
                    CenterLoaderHide();
                }
            });
            return false;
        }

        function ResetFilters() {
            $('.SubCheckBox').each(function () {
                $(this).prop("checked", false);
            });
            FilterCoupons();
            return false;
        }

        function FilterCoupons() {
            CenterLoaderShow();
            CategoryIds = "";
            CheckLoader = true;
            $('.SubCheckBox').each(function () {
                var id = $(this).attr('data-id');
                if ($(this).prop("checked") == true) {
                    CategoryIds += id + ",";
                }
            });
            index = 0;
            ShowCouponList(this);
            return false;
        }

        function ShowLoadMore() {
            CheckLoader = false;
            ShowCouponList(this);
            return false;
        }

        function SortByDistance(btn) {
            var $wrapper = $('#CouponTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.Couponlist').sort(function (a, b) {
                    return b.dataset.distance - a.dataset.distance;
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                //$(btn).parent().find('.distance_down').css("display", "none");
                //$(btn).parent().find('.distance_up').css("display", "block");
            }
            else {
                $wrapper.find('.Couponlist').sort(function (a, b) {
                    return a.dataset.distance - b.dataset.distance;
                }).appendTo($wrapper);
                $(btn).addClass('asc');
                $(btn).removeClass('desc');
                //$(btn).parent().find('.distance_up').css("display", "none");
                //$(btn).parent().find('.distance_down').css("display", "block");

            }
            return false;
        }

        function SortByName(btn) {
            var $wrapper = $('#CouponTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.Couponlist').sort(function (a, b) {
                    return b.dataset.name.toLowerCase().localeCompare(a.dataset.name.toLowerCase());
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                //$(btn).parent().find('.name_down').css("display", "none");
                //$(btn).parent().find('.name_up').css("display", "block");
            }
            else {
                $wrapper.find('.Couponlist').sort(function (a, b) {
                    return a.dataset.name.toLowerCase().localeCompare(b.dataset.name.toLowerCase());
                }).appendTo($wrapper);
                $(btn).addClass('asc');
                $(btn).removeClass('desc');
                //$(btn).parent().find('.name_up').css("display", "none");
                //$(btn).parent().find('.name_down').css("display", "block");
            }
            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerDiv">
        <uc1:HeaderSlider runat="server" ID="HeaderSlider" />
    </div>
    <div class="category_detail">
        <div class="container">
           <%-- <div class="sorting_panel">
                <a onclick="return SortByDistance(this)" class="asc sorting_link">
                    <div class="fullsorting_width">
                        <div class="sorting_width90">SortByDistance</div>
                        <div class="sorting_width10"><i style="display: none;" class="fa fa-caret-up distance_up "></i><i class="fa fa-caret-down distance_down"></i></div>
                    </div>
                </a>
                <a onclick="return SortByName(this)" class="asc sorting_link">
                    <div class="fullsorting_width">
                        <div class="sorting_width90">SortByName</div>
                        <div class="sorting_width10"><i style="display: none;" class="fa fa-caret-up name_up"></i><i class="fa fa-caret-down name_down"></i></div>
                    </div>
                </a>
            </div>--%>
            <div class="colClasses">
                <div class="col-md-3 cetaNavList">
                    <div class="card card-refine card-plain">
                        <div class="header">
                            <h4 class="title">Categories
                                    <%--<button class="btn btn-default btn-xs btn pull-right btn-simple" onclick="return ResetFilters();" rel="tooltip" title="Reset Filter">
                                        <i class="fa fa-refresh"></i>
                                    </button>--%>
                                   <button onclick="return SortByDistance(this)" class="asc btn btn-default btn-xs btn pull-right btn-simple xy_btn" rel="tooltip" title="" data-original-title="Sort By Distance"> <img src="/images/sm_1.png" alt="#"> </button>
                                   <button  onclick="return SortByName(this)" class="asc btn btn-default btn-xs btn pull-right btn-simple xy_btn" rel="tooltip" title="" data-original-title="Sort By Name"> <img src="/images/sm_2.png" alt="#"> </button>
                             
                            </h4>
                        </div>
                        <div class="content">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div id="refineDesigner" class="panel-collapse collapse in">
                                        <div class="panel-body panel-scroll" id="CategoryCheckBox">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="col-md-9">
                    <div id="CouponTemplate"></div>

                   <%-- <div class="col-md-3 col-md-offset-4 btnloadclr">
                        <button onclick="return ShowLoadMore();" title="Load button" class="btn btn-default btn-round" id="successBtn">Load more</button>
                        <div class="Loader">
                            <img src="images/new.gif" alt="new.gif" />
                        </div>
                    </div>--%>
                     <div class="b_load_btn btnloadclr" > <a style="cursor:pointer;"  onclick="return ShowLoadMore();" id="successBtn" > Load More </a><div style="text-align:center" class="Loader">
                            <img src="/images/new.gif" style="width:64px;" alt="new.gif" />
                        </div> </div>
                </div>
            </div>
        </div>
    </div>

    <!--++++++++++++++++++++++++++++++++++++++++++ End Midel_div +++++++++++++++++++++++++++++++++++++++++++-->


    <uc1:Footer runat="server" ID="Footer" />
    <script id="CouponScriptTemplate" type="text/html">

        <div class="col-md-6 Couponlist" data-categoryid="${CategoryId}" data-distance="${parseInt(Distance)}" data-name="${Title.trim().substring(0,1)}">
            <div class="card">
                <div class="image" style="background-image: url('<%=DataAccess.Classes.ClsCommon.CouponImagesPath%>${Images}'); background-position: center center; background-size: cover;">
                    <img alt="Image${Title}" src="<%=DataAccess.Classes.ClsCommon.CouponImagesPath%>${Images} " style="display: none;" />
                    <div class="filter">
                        <a href='/CouponDetail/${Id}/${String(Title.replace(/ /g,"-").replace("%","percent"))}' class="btn btn-neutral btn-simple" type="button"><i class="fa fa-align-left"></i>View Coupon </a>
                    </div>
                </div>
                <div class="content">
                    <a href='/CouponDetail/${Id}/${String(Title.replace(/ /g,"-").replace("%","percent"))}' class="card-link">
                        <h4 class="title">${Title}</h4>
                    </a>
                    <p class="adrescoupon">
                        <i class="fa fa-map-marker"></i>
                        {{if (Address.length > 30)}}
                        ${Address.substring(0,30)}.. 
                        {{else}}
                         ${Address} 
                        {{/if}}   
                        <span class="tu_Float_Right">${parseInt(Distance)}KM</span>
                    </p>
                    <%--<p class="couponprice">Price: <span>&#8377 ${ActualPrice} </span>&nbsp &nbsp &nbsp &nbsp  Save: <span>&#8377 ${parseFloat(parseFloat(ActualPrice)-parseFloat(SalePrice)).toFixed(2)}  </span>&nbsp &nbsp &nbsp &nbsp  Pay: <span> {{if (IsAsPerBill==true)}}As per bill {{else}}&#8377 ${CouponPrice} {{/if}} </span></p>--%>
                    <p class="couponprice">Price: <span>&#8377 ${ActualPrice} </span>&nbsp &nbsp &nbsp &nbsp  Save: <span>&#8377 ${parseFloat(SalePrice).toFixed(2)}  </span>&nbsp &nbsp &nbsp &nbsp  Pay: <span> {{if (IsAsPerBill==true)}}As per bill {{else}}&#8377 ${PayToMerchant} {{/if}} </span></p>

                </div>
            </div>
        </div>

    </script>
    <script id="CheckBoxCategoryScript" type="text/html">
        <label style="width: 100%">
            <input type="checkbox" class="SubCheckBox" onchange="return FilterCoupons();" data-id="${Id}" value="${Id}" />
            ${Name}
        </label>
    </script>
    <script src="/js/get-shit-done.js"></script>

</asp:Content>
