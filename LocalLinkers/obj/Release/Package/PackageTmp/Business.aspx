<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="LocalLinkers.Business" %>

<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/gsdk.css" rel="stylesheet" />
    <link href="/css/examples.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="js/jquery-ui.js"></script>
    <script src="/js/bootstrap-datepicker.js"></script>
    <script>
        var take = 10;
        var index = 0;
        var SubcategoryIds = "";
        var CheckLoader = false;
        var SliderLoad = false;

        $(document).ready(function () {
            ShowBusinessList(this);
            $('.carousel').carousel({
                interval: 8000
            });
        });

        function ShowBusinessList(btn) {
            if (!CheckLoader) {
                LoaderShow();
            }
            var Latitude = '<%= Session["Latitude"] %>';
            var Longitude = '<%= Session["Longitude"] %>';
            index = index + 1;
            var keyword = $(btn).attr("data-keyword");
            if (typeof keyword === "undefined") {
                keyword = "";
            }
            else if (keyword != "") {
                LoaderShow();
                $("#div_SearchContent").hide();
                SubcategoryIds = "";
                index = 1;
            }
            $.ajax({
                url: '/Business.aspx/BindBusiness',
                type: "POST",
                data: '{ "index":"' + parseInt(index - 1) + '","take":"' + parseInt(take) + '","categoryid":"' + parseInt(<%=CategoryId%>) + '","SubCategoryIds":"' + SubcategoryIds + '","Latitude":"' + Latitude + '","Longitude":"' + Longitude + '","Keyword":"' + keyword + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d.LstBusiness.length > 0) {
                        if (index - 1 == 0 || CheckLoader) {
                            $("#BusinessTemplate").empty();
                            if (result.d.LstSlider.length > 0 && !SliderLoad) {
                                $("#SliderTemplate").empty();
                                $("#SliderIndicatorsTemplate").empty();
                                $("#SliderScriptTemplate").tmpl(result.d.LstSlider).appendTo("#SliderTemplate");
                                $("#SliderIndicatorsScriptTemplate").tmpl(result.d.LstSlider).appendTo("#SliderIndicatorsTemplate");
                                SliderLoad = true;
                            }
                        }
                        if (index - 1 == 0 && SubcategoryIds == '') {
                            $("#SubCategoryCheckBox").empty();
                            if (result.d.LstSubCategory.length > 0) {
                                $("#CheckBoxSubCategoryScript").tmpl(result.d.LstSubCategory).appendTo("#SubCategoryCheckBox");
                            }
                        }
                        $("#BusinessScriptTemplate").tmpl(result.d.LstBusiness).appendTo("#BusinessTemplate");
                        if (result.d.LstBusiness.length != 10) {
                            $(".btnloadclr").css("display", "none");
                        }
                        else {
                            $(".btnloadclr").css("display", "block");
                        }
                    }
                    else {
                        if (index - 1 == 0) {
                            $("#BusinessTemplate").html('<div style="width:100%;text-align:left;font-size:14px;font-weight:bold"><font color="black">No Record.</font></div>');
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
            FilterBusiness();
            return false;
        }

        function ResetAll() {
            $("#txtDate").val('');
            $("#drpTime").val('01');
            $("#drpMinutes").val('00');
            $("#drpAm_Pm").val('AM');
            $(".modalClose").trigger("click");
        }

        function SendConfirmMessage() {
            var id = $("#hdnModalBusinessId").val();
            var exactdate = $("#txtDate").val();
            var time = $("#drpTime").val();
            var minutes = $("#drpMinutes").val();
            var drpAm_Pm = $("#drpAm_Pm").val();
            var exactTime = time + ":" + minutes + " " + drpAm_Pm;
            var usermessage = $("#txtUserMessage").val();
            var from = exactdate.split("/");
            var selectedDate = new Date(from[2], from[1] - 1, from[0]);
            var nowDate = new Date();
            var today = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), 0, 0, 0, 0);
            if (exactdate == "") {
                alert("Please select date");
                return false;
            }

            if (selectedDate == today) {
            }
            else if (selectedDate < today) {
                alert("Please select current date or future date. ");
                return false;
            }


            if (usermessage == "") {
                alert("Please enter message");
                return false;
            }

            if (id != "") {
                CenterLoaderShow();
                $.ajax({
                    url: '/Business.aspx/SendConfirmMessage',
                    type: "POST",
                    data: '{ "BusinessId":"' + parseInt(id) + '","date":"' + exactdate + '","time":"' + exactTime + '","usermessage":"' + usermessage + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        if (result.d.indexOf("Login") > 0) {
                            window.location.href = result.d;
                        }
                        else {
                            alert(result.d);
                            ResetAll();
                        }
                        CenterLoaderHide();
                    }
                });
                return false;
            }
        }

        function SetModalLabels(btn) {
            var flag = '<%=DataAccess.Classes.ClsCommon.GetSession()%>';
            if (flag == "True") {
                var buttonName = $(btn).attr("data-buttonname");
                var usermessage = $(btn).attr("data-usermessage");
                var id = $(btn).attr("data-id");
                if (id != "") {
                    $(".bookingModal").text(buttonName);
                    $("#hdnModalBusinessId").val(id);
                    $("#txtUserMessage").val(usermessage);
                    ResetAll();
                    $("#btnOpenModal").trigger("click");
                }
            }
            else {
                alert("Please login first");
                window.location.href = "/Login?ReturnUrl=" + window.location.pathname;
            }
            return false;
        }

        function FilterBusiness() {
            CenterLoaderShow();
            SubcategoryIds = "";
            CheckLoader = true;
            $('.SubCheckBox').each(function () {
                var id = $(this).attr('data-id');
                if ($(this).prop("checked") == true) {
                    SubcategoryIds += id + ",";
                }
            });
            index = 0;
            ShowBusinessList(this);
            return false;
        }

        function ShowLoadMore() {
            CheckLoader = false;
            ShowBusinessList(this);
            return false;
        }

        function SortByDistance(btn) {
            var $wrapper = $('#BusinessTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.cetacoll').sort(function (a, b) {
                    return b.dataset.distance - a.dataset.distance;
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                //$(btn).parent().find('.distance_down').css("display", "none");
                //$(btn).parent().find('.distance_up').css("display", "block");
            }
            else {
                $wrapper.find('.cetacoll').sort(function (a, b) {
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
            var $wrapper = $('#BusinessTemplate');
            if ($(btn).hasClass('asc')) {
                $wrapper.find('.cetacoll').sort(function (a, b) {
                    return b.dataset.name.toLowerCase().localeCompare(a.dataset.name.toLowerCase());
                }).appendTo($wrapper);
                $(btn).addClass('desc');
                $(btn).removeClass('asc');
                //$(btn).parent().find('.name_down').css("display", "none");
                //$(btn).parent().find('.name_up').css("display", "block");
            }
            else {
                $wrapper.find('.cetacoll').sort(function (a, b) {
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
    <style>
        .slider_AnchorButton {
            bottom: 0;
            position: absolute;
            right: 0;
        }

        .lblBookingBtn {
            color: #fff !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerDiv">
        <div class="carousel slide" id="carousel-47951" data-ride="carousel">
            <ol class="carousel-indicators" id="SliderIndicatorsTemplate">
            </ol>
            <div class="carousel-inner" id="SliderTemplate">
            </div>
        </div>
    </div>
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Midel_div ++++++++++++++++++++++++++++++++++++++++++-->

    <div class="category_detail">
        <div class="container">
            <%--<div class="sorting_panel">
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
                            <h4 class="title"><%=CategoryName %>
                                <%--<button class="btn btn-default btn-xs btn pull-right btn-simple xy_btn" onclick="return ResetFilters();" rel="tooltip" title="" data-original-title="Refresh"> <img src="/images/sm_3.png" alt="#"> </button>--%>
                                <button onclick="return SortByDistance(this)" class="asc btn btn-default btn-xs btn pull-right btn-simple xy_btn" rel="tooltip" title="" data-original-title="Sort By Distance">
                                    <img src="/images/sm_1.png" alt="#">
                                </button>
                                <button onclick="return SortByName(this)" class="asc btn btn-default btn-xs btn pull-right btn-simple xy_btn" rel="tooltip" title="" data-original-title="Sort By Name">
                                    <img src="/images/sm_2.png" alt="#">
                                </button>
                                <%--<button class="btn btn-default btn-xs btn pull-right btn-simple" onclick="return ResetFilters();" rel="tooltip" title="Reset Filter">
                                        <i class="fa fa-refresh"></i>
                                    </button>--%>
                            </h4>
                        </div>
                        <div class="content">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div id="refineDesigner" class="panel-collapse collapse in">
                                        <div class="panel-body panel-scroll" id="SubCategoryCheckBox">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-9" style="float: left;">
                    <div id="BusinessTemplate"></div>
                    <%-- <div class="col-md-3 col-md-offset-4 btnloadclr">
                        <button onclick="return ShowLoadMore();" rel="tooltip" title="Load button" class="btn btn-default btn-round" id="successBtn">Load more</button>
                        <div class="Loader">
                            <img src="/images/new.gif" alt="new.gif" />
                        </div>
                    </div>--%>
                    <div class="b_load_btn btnloadclr">
                        <a style="cursor: pointer;" onclick="return ShowLoadMore();" id="successBtn">Load More </a>
                        <div style="text-align: center" class="Loader">
                            <img src="/images/new.gif" style="64px;" alt="new.gif" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--++++++++++++++++++++++++++++++++++++++++++ End Midel_div +++++++++++++++++++++++++++++++++++++++++++-->

    <uc1:Footer runat="server" ID="Footer" />

    <!-- Modal -->
    <a style="display: none;" id="btnOpenModal" data-toggle="modal" data-target="#myModal"></a>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close modalClose" data-dismiss="modal">&times;</button>
                    <input type="hidden" id="hdnModalBusinessId" name="hdnModalBusinessId" value=" " />
                    <h4 class="modal-title">
                        <asp:Label Text="Book" ID="lblBookingText" CssClass="bookingModal" runat="server" /></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-2"><strong>Date:</strong></div>
                        <div class="col-md-6">
                            <input class="datepicker form-control" id="txtDate" type="text" data-date-format="dd/mm/yyyy" readonly="readonly" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2"><strong>Time:</strong></div>
                        <div class="col-md-6">
                            <select id="drpTime" class="form-control" style="width: 30%; float: left; margin-right: 3%;">
                                <option value="01">01</option>
                                <option value="02">02</option>
                                <option value="03">03</option>
                                <option value="04">04</option>
                                <option value="05">05</option>
                                <option value="06">06</option>
                                <option value="07">07</option>
                                <option value="08">08</option>
                                <option value="09">09</option>
                                <option value="10">10</option>
                                <option value="11">11</option>
                                <option value="12">12</option>
                            </select>
                            <select id="drpMinutes" class="form-control" style="width: 30%; float: left; margin-right: 3%;">
                                <option value="00">00</option>
                                <option value="01">01</option>
                                <option value="02">02</option>
                                <option value="03">03</option>
                                <option value="04">04</option>
                                <option value="05">05</option>
                                <option value="06">06</option>
                                <option value="07">07</option>
                                <option value="08">08</option>
                                <option value="09">09</option>
                                <option value="10">10</option>
                                <option value="11">11</option>
                                <option value="12">12</option>
                                <option value="13">13</option>
                                <option value="14">14</option>
                                <option value="15">15</option>
                                <option value="16">16</option>
                                <option value="17">17</option>
                                <option value="18">18</option>
                                <option value="19">19</option>
                                <option value="20">20</option>
                                <option value="21">21</option>
                                <option value="22">22</option>
                                <option value="23">23</option>
                                <option value="24">24</option>
                                <option value="25">25</option>
                                <option value="26">26</option>
                                <option value="27">27</option>
                                <option value="28">28</option>
                                <option value="29">29</option>
                                <option value="30">30</option>
                                <option value="31">31</option>
                                <option value="32">32</option>
                                <option value="33">33</option>
                                <option value="34">34</option>
                                <option value="35">35</option>
                                <option value="36">36</option>
                                <option value="37">37</option>
                                <option value="38">38</option>
                                <option value="39">39</option>
                                <option value="40">40</option>
                                <option value="41">41</option>
                                <option value="42">42</option>
                                <option value="43">43</option>
                                <option value="44">44</option>
                                <option value="45">45</option>
                                <option value="46">46</option>
                                <option value="47">47</option>
                                <option value="48">48</option>
                                <option value="49">49</option>
                                <option value="50">50</option>
                                <option value="51">51</option>
                                <option value="52">52</option>
                                <option value="53">53</option>
                                <option value="54">54</option>
                                <option value="55">55</option>
                                <option value="56">56</option>
                                <option value="57">57</option>
                                <option value="58">58</option>
                                <option value="59">59</option>
                            </select>
                            <select id="drpAm_Pm" class="form-control" style="width: 34%; float: left;">
                                <option value="AM">AM</option>
                                <option value="PM">PM</option>
                            </select>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-2"><strong>Message:</strong></div>
                        <div class="col-md-6">
                            <textarea class="form-control" id="txtUserMessage" maxlength="500"></textarea>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-md-6">
                            <div class="lolocater">

                                <a onclick="return SendConfirmMessage()" class="anchor_Cursor" style="float: left;">
                                    <asp:Label Text="Book" ID="lblBookingButton" CssClass="bookingModal lblBookingBtn" runat="server" />
                                </a>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>

    <!--+++++++++++++++++++++++++++++++++++++++++ End footer_down ++++++++++++++++++++++++++++++++++++++++++-->
    <script id="BusinessScriptTemplate" type="text/html">
        <div class="col-md-12 cetacoll" data-subcategoryid="${SubCategoryId}" data-distance="${parseInt(Distance)}" data-name="${BusinessName.trim().substring(0,1)}">
            <div class="card card-horizontal cardcetalist1">
                <div class="row">
                    <div class="col-md-5">

                        <div class="hoHoverImg">
                            <i class="fa fa-thumbs-up"></i>
                            <p>Local Thinker Verified </p>
                        </div>
                        <div class="hoHoverImg_right"><i class="fa fa-star-o"></i></div>

                        <div class="image" style="background-image: url('<%=DataAccess.Classes.ClsCommon.BusinessImagesPath%>${Image}?width=320&height=293&mode=crop'); background-position: center center; background-size: cover;">
                            <img alt="image${Id}" src="<%=DataAccess.Classes.ClsCommon.BusinessImagesPath%>${Image}?width=320&height=293&mode=crop" style="display: none;" />
                            {{if Subscription==1}}
                            <div class="icon_h1">
                                <img src="/images/hover_icon.png" alt="" style="display: none;">
                            </div>
                            {{/if}}
                            <div class="filter filter-azure">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <div class="content" style="overflow: hidden; padding-top: 0px !important;">

                            <a href="#" class="card-link appr_ryt">
                                <h4 class="title">${BusinessName} </h4>
                            </a>
                            {{if (Subscription!=3)}}
                            <a href="#" style="cursor: none;" class="card-link appr_lft">
                                <img src="/images/verified1.png" alt="">
                            </a>
                            {{/if}}
                            <%--<a href="#" class="card-link appr_lft"><i class="fa fa-thumbs-up"></i>Verified  </a>--%>

                            <p class="category text-info" style="width: 85%;"><i class="fa fa-user"></i>${ContactPerson} </p>
                            <p class="category text-info"><i class="fa fa-phone"></i>${PhoneNumber1}</p>
                            <p class="category text-info" style="font-size: 14px !important"><i class="fa fa-home"></i>${Address}</p>

                            <a href="#" class="card-link">
                                <p class="description" style="min-height: 74px; overflow: hidden; height: 74px; line-height: 1.6;">
                                    ${Description}
                                </p>
                            </a>

                            <div class="lolocater" style="margin-bottom: 0px; margin-top: 10px;">
                                <p style="font-size: 12px; margin-top: 20px;"><i class="fa fa-location-arrow"></i>${parseInt(Distance)}Km </p>
                                {{if (Subscription!=3)}}
                                <a class="anchor_Cursor bookform" onclick="return SetModalLabels(this);" data-usermessage="${UserMessage}" data-buttonname="${ButtonTitle}" data-id="${Id}">${ButtonTitle} </a>
                                {{/if}}
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <script id="CheckBoxSubCategoryScript" type="text/html">
        <label style="width: 100%">
            <input type="checkbox" class="SubCheckBox" onchange="return FilterBusiness();" data-id="${Id}" value="${Id}" />
            ${Name}
        </label>
    </script>

    <script id="SliderScriptTemplate" type="text/html">
        {{if (SNO==1)}}
					<div class="item active">
                        <img alt="${PremiumImage}" src="<%=DataAccess.Classes.ClsCommon.BusinessPremiumImagesPath%>${PremiumImage}" style="width: 100%; height: 400px;" />
                        <%--<div class="lolocater">
                            {{if (Subscription!=3)}}
                                <a class="anchor_Cursor slider_AnchorButton" onclick="return SetModalLabels(this);" data-usermessage="${UserMessage}" data-buttonname="${ButtonTitle}" data-id="${Id}">${ButtonTitle} </a>
                            {{/if}}
                        </div>--%>
                    </div>
        {{else}}
                    <div class="item">
                        <img alt="${PremiumImage}" src="<%=DataAccess.Classes.ClsCommon.BusinessPremiumImagesPath%>${PremiumImage}" style="width: 100%; height: 400px;" />
                        <%--<div class="lolocater">
                            {{if (Subscription!=3)}}
                                <a class="anchor_Cursor slider_AnchorButton" onclick="return SetModalLabels(this);" data-usermessage="${UserMessage}" data-buttonname="${ButtonTitle}" data-id="${Id}">${ButtonTitle} </a>
                            {{/if}}
                        </div>--%>
                    </div>
        {{/if}}        
    </script>

    <script id="SliderIndicatorsScriptTemplate" type="text/html">
        {{if (SNO==1)}}
					<li class="active" data-slide-to="${parseInt(SNO-1)}" data-target="#carousel-47951"></li>
        {{else}}
                    <li data-slide-to="${parseInt(SNO-1)}" data-target="#carousel-47951"></li>
        {{/if}}       
    </script>

    <script src="/js/get-shit-done.js"></script>
    <script src="/js/gsdk-checkbox.js"></script>

</asp:Content>
