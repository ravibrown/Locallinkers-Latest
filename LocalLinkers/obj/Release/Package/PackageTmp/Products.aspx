<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LocalLinkers.Products" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/UserControl/HeaderSlider.ascx" TagPrefix="uc1" TagName="HeaderSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="css/gsdk.css" rel="stylesheet" />
    <link href="css/examples.css" rel="stylesheet" />
    <script>
        var take = 10;
        var index = 0;
        var CategoryIds = [];
        var CheckLoader = false;
        $(document).ready(function () {
            ShowProductList(this);
        });
        function ShowProductList(btn) {
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
                url: '/Products.aspx/BindProducts',
                type: "POST",
                data: '{ "index":"' + parseInt(index - 1) + '","take":"' + parseInt(take) + '","CategoryIds":"' + CategoryIds + '","Keyword":"' + keyword + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d.LstProducts.length > 0) {
                        if (index - 1 == 0 || CheckLoader) {
                            $("#ProductTemplate").empty();
                        }
                        if (index - 1 == 0 && CategoryIds == '') {
                            $("#CategoryCheckBox").empty();
                            if (result.d.LstCategory.length > 0) {
                                $("#CheckBoxCategoryScript").tmpl(result.d.LstCategory).appendTo("#CategoryCheckBox");
                            }
                        }
                        $("#ProductScriptTemplate").tmpl(result.d.LstProducts).appendTo("#ProductTemplate");
                        if (result.d.LstProducts.length != 10) {
                            $(".btnloadclr").css("display", "none");
                        }
                        else {
                            $(".btnloadclr").css("display", "block");
                        }
                    }
                    else {
                        if (index - 1 == 0) {
                            $("#ProductTemplate").html('<div style="width:100%;text-align:left;font-size:14px;font-weight:bold"><font color="black">No Record.</font></div>');
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
            FilterProducts();
            return false;
        }

        function FilterProducts() {
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
            ShowProductList(this);
            return false;
        }

        function ShowLoadMore() {
            CheckLoader = false;
            ShowProductList(this);
            return false;
        }

        function SortByDistance(btn) {
            var $wrapper = $('#ProductTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.Productlist').sort(function (a, b) {
                    return b.dataset.distance - a.dataset.distance;
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                $(btn).parent().find('.distance_down').css("display", "none");
                $(btn).parent().find('.distance_up').css("display", "block");
            }
            else {
                $wrapper.find('.Productlist').sort(function (a, b) {
                    return a.dataset.distance - b.dataset.distance;
                }).appendTo($wrapper);
                $(btn).addClass('asc');
                $(btn).removeClass('desc');
                $(btn).parent().find('.distance_up').css("display", "none");
                $(btn).parent().find('.distance_down').css("display", "block");

            }
            return false;
        }

        function SortByName(btn) {
            var $wrapper = $('#ProductTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.Productlist').sort(function (a, b) {
                    return b.dataset.name.toLowerCase().localeCompare(a.dataset.name.toLowerCase());
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                $(btn).parent().find('.name_down').css("display", "none");
                $(btn).parent().find('.name_up').css("display", "block");
            }
            else {
                $wrapper.find('.Productlist').sort(function (a, b) {
                    return a.dataset.name.toLowerCase().localeCompare(b.dataset.name.toLowerCase());
                }).appendTo($wrapper);
                $(btn).addClass('asc');
                $(btn).removeClass('desc');
                $(btn).parent().find('.name_up').css("display", "none");
                $(btn).parent().find('.name_down').css("display", "block");
            }
            return false;
        }
    </script>
    <style>
        .card {
            height: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerDiv">
            <uc1:HeaderSlider runat="server" ID="HeaderSlider" />
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ Start Midel_div & Shoping Cart ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="category_detail">
        <div class="container">
            <div class="sorting_panel">
              <%--  <a onclick="return SortByDistance(this)" class="asc sorting_link">
                    <div class="fullsorting_width">
                        <div class="sorting_width90">SortByDistance</div>
                        <div class="sorting_width10"><i style="display: none;" class="fa fa-caret-up distance_up "></i><i class="fa fa-caret-down distance_down"></i></div>
                    </div>
                </a>--%>
                <a onclick="return SortByName(this)" class="asc sorting_link">
                    <div class="fullsorting_width">
                        <div class="sorting_width90">SortByName</div>
                        <div class="sorting_width10"><i style="display: none;" class="fa fa-caret-up name_up"></i><i class="fa fa-caret-down name_down"></i></div>
                    </div>
                </a>
            </div>
            <div class="colClasses">
                <div class="col-md-3 cetaNavList">
                    <div class="card card-refine card-plain">
                        <div class="header">
                            <h4 class="title">Categories
                                    <button class="btn btn-default btn-xs btn pull-right btn-simple" onclick="return ResetFilters();" rel="tooltip" title="Reset Filter">
                                        <i class="fa fa-refresh"></i>
                                    </button>
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
                <div class="col-md-9 floatnone" style="float: left;">
                    <div class="shopig_cart" id="ProductTemplate">
                    </div>


                    <div class="clearfix"></div>
                    <div class="col-md-3 col-md-offset-4 btnloadclr">
                        <button onclick="return ShowLoadMore();" rel="tooltip" title="Load button" class="btn btn-default btn-round LaodButton" id="successBtn">Load more</button>
                        <div class="Loader">
                            <img src="images/new.gif" alt="new.gif" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--++++++++++++++++++++++++++++++++++++++++++ End Midel_div Shoping Cart +++++++++++++++++++++++++++++++++++++++++++-->



    <uc1:Footer runat="server" ID="Footer" />
    <script id="ProductScriptTemplate" type="text/html">
        <div class="col-md-4 Productlist" data-categoryid="${CategoryId}" data-distance="${parseInt(Distance)}" data-name="${Title.trim().substring(0,1)}">
            <div class="card card-product">
                <div class="image">
                    <div data-ride="carousel" class="carousel slide" id="card-product-carousel${SNO}">
                        <div class="carousel-inner">
                            {{tmpl(Images) "#ProductImages"}}
                        </div>

                        <a data-slide="prev" href="#card-product-carousel${SNO}" class="left carousel-control">
                            <span class="fa fa-angle-left"></span>
                        </a>
                        <a data-slide="next" href="#card-product-carousel${SNO}" class="right carousel-control">
                            <span class="fa fa-angle-right"></span>
                        </a>
                    </div>
                </div>
                <div class="content">
                    <a href='/ProductDetail/${Id}/${String(Title.replace(/ /g,"-").replace("%","percent"))}'>
                        <h4 class="title">${Title}</h4>
                    </a>
                    <p class="description editdescription">
                        ${ShortDescription}
                    </p>
                    <div class="footer">
                        <span class="price price-old">&#8377 ${ActualPrice}</span>
                        <span class="price price-new">&#8377 ${SalePrice}</span>
                        <%--  <button class="btn btn-default btn-fill pull-right btn-xs btn-hover">
                                                    <i class="fa fa-star"></i>
                                                </button>--%>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script id="ProductImages" type="text/html">
        {{if SNO == "1"}}
        <div class="item active">
            <img src="<%=DataAccess.Classes.ClsCommon.ProductImagesPath %>${Image}" alt="${Image}" />
        </div>
        {{else}}
            <div class="item">
                <img src="<%=DataAccess.Classes.ClsCommon.ProductImagesPath %>${Image}" alt="${Image}" />
            </div>
        {{/if}}
    </script>

    <script id="CheckBoxCategoryScript" type="text/html">
        <label style="width: 100%">
            <input type="checkbox" class="SubCheckBox" onchange="return FilterProducts();" data-id="${Id}" value="${Id}" />
            ${Name}
        </label>
    </script>
    <script src="js/get-shit-done.js"></script>
    <script src="js/gsdk-checkbox.js"></script>
</asp:Content>
