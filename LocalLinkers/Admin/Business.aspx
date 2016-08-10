<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="LocalLinkers.Admin.Business" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/global/plugins/dropzone/dropzone.min.js"></script>
    <script>
        function BindSubCategoryByCategory(subcategoryid) {
            $('#<%=drpSubCategory.ClientID%>').empty();
            var categoryid = $('#<%=drpCategory.ClientID%> option:selected').val();
            if (parseInt(categoryid) > 0) {
                $.ajax({
                    url: '/Admin/Coupons.aspx/GetSubCategories',
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{ "CategoryId":"' + parseInt(categoryid) + '"}',
                    success: function (data) {
                        var maindata = JSON.parse(data.d);
                        if (maindata.length > 0) {
                            $('#<%=drpSubCategory.ClientID%>').append($("<option value=0>Select</option>"));
                            for (var i = 0; i < maindata.length; i++) {
                                var Id = maindata[i].Id;
                                var Text = maindata[i].Name;
                                $('#<%=drpSubCategory.ClientID%>').append($("<option value=" + Id + ">" + Text + "</option>"));
                            }
                            if (subcategoryid != 0) {
                                $('#<%=drpSubCategory.ClientID%>').val(subcategoryid);
                            }
                        }
                        else {
                            var Value = 0;
                            var Text = "Select";
                            $('#<%=drpSubCategory.ClientID%>').append($("<option value=" + Value + ">" + Text + "</option>"));
                        }
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });
            }
            else {
                var Value = 0;
                var Text = "Select";
                $('#<%=drpSubCategory.ClientID%>').append($("<option value=" + Value + ">" + Text + "</option>"));
            }
        }

        function EditBusiness(btn) {
            var id = $(btn).attr('data-id');
            var description = $(btn).attr('data-description');
            var businessname = $(btn).attr('data-businessname');
            var categoryid = $(btn).attr('data-categoryid');
            var categoryname = $(btn).attr('data-categoryname');
            var subcategoryid = $(btn).attr('data-subcategoryid');
            var subcategoryname = $(btn).attr('data-subcategoryname');
            var email = $(btn).attr('data-email');
            var website = $(btn).attr('data-website');
            var contactperson = $(btn).attr('data-contactperson');
            var phonenumber1 = $(btn).attr('data-phonenumber1');
            var phonenumber2 = $(btn).attr('data-phonenumber2');
            var address = $(btn).attr('data-address');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            var latitude = $(btn).attr('data-latitude');
            var longitude = $(btn).attr('data-longitude');
            var city = $(btn).attr('data-city');
            var subscription = $(btn).attr('data-subscription');
            var image = $(btn).attr('data-image');
            var premiumimage = $(btn).attr('data-premiumimage');
            if (isapprovedbyadmin == "True") {
                $('#<%=chkBusiness.ClientID%>').prop("checked", true);
                    $('.checker span').addClass('checked');

                }

                //GetImages(id);

                $('#<%=hdnBusinessId.ClientID%>').val(id);
                $('#<%=drpCategory.ClientID%>').val(categoryid);
                $('#<%=hdnSubCategoryId.ClientID%>').val(subcategoryid);

                BindSubCategoryByCategory(subcategoryid);

                $('#<%=txtDescription.ClientID%>').val(description);
                $('#<%=txtBusinessName.ClientID%>').val(businessname);
                $('#<%=txtEmail.ClientID%>').val(email);
                $('#<%=txtWebsite.ClientID%>').val(website);
                $('#<%=txtContactPerson.ClientID%>').val(contactperson);
                $('#<%=txtPhoneNumber1.ClientID%>').val(phonenumber1);
                $('#<%=txtPhoneNumber2.ClientID%>').val(phonenumber2);
                $('#<%=txtAddress.ClientID%>').val(address);
                $('#<%=drpCity.ClientID%>').val(city);
                $('#<%=drpSubscription.ClientID%>').val(subscription);
                $('#Latitude').val(latitude);
                $('#Longitude').val(longitude);
                $('#<%=target.ClientID%>').attr('src', "/Admin/BusinessImages/" + image);
                if (subscription == "1") {
                    $('#<%=TargetPremiumImage.ClientID%>').attr('src', "/Admin/BusinessPremiumImages/" + premiumimage);
                    $('#divPremiumImage').removeClass("hide");
                }
                $('#<%=hdnLatitude.ClientID%>').val(latitude);
                $('#<%=hdnLongitude.ClientID%>').val(longitude);
                ShowPanel('Business');

            }

            function DeactivateBusiness(btn) {
                var id = $(btn).attr('data-id');
                CenterLoaderShow();
                $.ajax({
                    url: '/Admin/Business.aspx/DeactivateBusiness',
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{ "Id":"' + parseInt(id) + '"}',
                    success: function (data) {
                        CenterLoaderHide();
                        alert(data.d);
                        window.location.href = window.location.href;
                    },
                    error: function () {
                        alert("server error");
                    }
                });
            }

            function ResetAll() {
                $('#<%=chkBusiness.ClientID%>').prop("checked", false);
                $('.checker span').removeClass('checked');
                $('#<%=hdnBusinessId.ClientID%>').val('');
                $('#<%=drpCategory.ClientID%>').val('0');
                $('#<%=drpSubscription.ClientID%>').val('0');
                $('#<%=drpSubCategory.ClientID%>').empty();
                $('#<%=hdnSubCategoryId.ClientID%>').val('');
                $('#<%=txtDescription.ClientID%>').val('');
                $('#<%=txtBusinessName.ClientID%>').val('');
                $('#<%=txtEmail.ClientID%>').val('');
                $('#<%=txtWebsite.ClientID%>').val('');
                $('#<%=txtContactPerson.ClientID%>').val('');
                $('#<%=txtPhoneNumber1.ClientID%>').val('');
                $('#<%=txtPhoneNumber2.ClientID%>').val('');
                $('#<%=drpCity.ClientID%>').val('0');
                $('#<%=txtAddress.ClientID%>').val('');
                $('#Latitude').val('');
                $('#Longitude').val('');
                $('#<%=hdnLatitude.ClientID%>').val('');
                $('#<%=hdnLongitude.ClientID%>').val('');
                //$('#Image').val('');
                $('#btnAddImage').trigger("click");
                $('.GridBusiness').addClass('hide');
                $('.BusinessPanel').removeClass('hide');
            }

            function CheckValidation() {
                var PhoneNumber = $('#<%=txtPhoneNumber1.ClientID%>').val();
                var BusinessName = $('#<%=txtBusinessName.ClientID%>').val();
                var Category = $('#<%=drpCategory.ClientID%> option:selected').val();
                var SubCategory = $('#<%=drpSubCategory.ClientID%> option:selected').val();
                var Subscription = $('#<%=drpSubscription.ClientID%> option:selected').val();
                var City = $('#<%=drpCity.ClientID%> option:selected').val();
                var Description = $('#<%=txtDescription.ClientID%>').val();
                var Email = $('#<%=txtEmail.ClientID%>').val();
                var Website = $('#<%=txtWebsite.ClientID%>').val();
                var ContactPerson = $('#<%=txtContactPerson.ClientID%>').val();
                var Address = $('#<%=txtAddress.ClientID%>').val();
                //var Image = $('#Image').val();
                var Latitude = $('#Latitude').val();
                var Longitude = $('#Longitude').val();
            <%--$('#<%=hdnImage.ClientID%>').val(Image);--%>
                $('#<%=hdnLatitude.ClientID%>').val(Latitude);
                $('#<%=hdnLongitude.ClientID%>').val(Longitude);
                var ErrorMessage = "";

                if (Category == "0") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please select category.";
                    }
                    $('#<%=drpCategory.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=drpCategory.ClientID%>').css("border-color", "#c2cad8");
                }

                if (SubCategory == "0") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please select sub category.";
                    }
                    $('#<%=drpSubCategory.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=drpSubCategory.ClientID%>').css("border-color", "#c2cad8");
                $('#<%=hdnSubCategoryId.ClientID%>').val(SubCategory);
            }

            if (PhoneNumber == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter phone number 1.";
                }
                $('#<%=txtPhoneNumber1.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtPhoneNumber1.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BusinessName == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter businessname.";
                }
                $('#<%=txtBusinessName.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBusinessName.ClientID%>').css("border-color", "#c2cad8");
            }

            if (BusinessName.indexOf('-') > 0 || BusinessName.indexOf('&') > 0 || BusinessName.indexOf('/') > 0 || BusinessName.indexOf('|') > 0 || BusinessName.indexOf(';') > 0 || BusinessName.indexOf('<') > 0 || BusinessName.indexOf('>') > 0 || BusinessName.indexOf('+') > 0) {
                if (ErrorMessage == "") {
                    ErrorMessage = "This type of (-,&,/,|,;,<,>,+) special characters is not allowed in business name field.";
                }
                $('#<%=txtBusinessName.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtBusinessName.ClientID%>').css("border-color", "#c2cad8");
            }


            if (Description == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter description.";
                }
                $('#<%=txtDescription.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtDescription.ClientID%>').css("border-color", "#c2cad8");
            }

            if (ContactPerson == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter contact person.";
                }
                $('#<%=txtContactPerson.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtContactPerson.ClientID%>').css("border-color", "#c2cad8");
            }


<%--            if (Website == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter website.";
                }
                $('#<%=txtWebsite.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtWebsite.ClientID%>').css("border-color", "#c2cad8");
            }

            if (Email == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter email.";
                }
                $('#<%=txtEmail.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtEmail.ClientID%>').css("border-color", "#c2cad8");
            }--%>

                if (!IsEmail(Email) && Email != "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter valid email.";
                    }
                    $('#<%=txtEmail.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtEmail.ClientID%>').css("border-color", "#c2cad8");
                }

                if (Address == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter address.";
                    }
                    $('#<%=txtAddress.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtAddress.ClientID%>').css("border-color", "#c2cad8");
            }

            if (City == "0") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please select city.";
                }
                $('#<%=drpCity.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=drpCity.ClientID%>').css("border-color", "#c2cad8");
            }

            if (Subscription == "0") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please select subscription.";
                }
                $('#<%=drpSubscription.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=drpSubscription.ClientID%>').css("border-color", "#c2cad8");
            }


            if (ErrorMessage != "") {
                $('#<%=lblErrorMsg.ClientID%>').text(ErrorMessage);
                $('#<%=alertDanger.ClientID%>').removeClass('hide');
                return false;
            }
            else {
                return true;
            }
        }

        function LoadingShow() {
            $('.loading').show();
        }

        function DeleteMsg(result) {
            $('#<%=lblSuccessMsg.ClientID%>').text(result.d);
            $('#<%=alertSuccess.ClientID%>').removeClass('hide');
        }

        function PreviewImage(input, type) {
            var file = "";
            if (type == "Premium") {
                file = $('#<%=FilePremiumImage.ClientID%>');
            }
            else {
                file = $('#<%=fileImage.ClientID%>');
            }
            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = new Image;

                    img.onload = function () {
                        if (type == "Premium") {
                            if (img.width >= 1900 && img.height >= 500) {
                                $('#<%=TargetPremiumImage.ClientID%>').attr('src', e.target.result);
                           }
                           else {
                               alert("Please select 1900*500 or greater than this dimension image")
                               $(file).replaceWith($(file).clone());
                           }
                       }
                       else {
                           if (img.width >= 320 && img.height >= 293) {
                               $('#<%=target.ClientID%>').attr('src', e.target.result);
                            }
                            else {
                                alert("Please select 320*293 or greater than this dimension image")
                                $(file).replaceWith($(file).clone());
                            }

                        }
                   };
                   img.src = e.target.result;

               }
                reader.readAsDataURL(input.files[0]);
            }
        }

        function ShowUploadFile() {
            var Subscription = $('#<%=drpSubscription.ClientID%> option:selected').val();

            if (Subscription == "1") {
                $('#divPremiumImage').removeClass("hide");
            }
            else {
                $('#divPremiumImage').addClass("hide");
            }
        }

        //function RemoveImage(btn) {
        //    if (confirm("Are you sure do you want to remove this item?")) {
        //        var name = $(btn).attr('data-image');
        //        $.ajax({
        //            url: '/Admin/Business.aspx/DeleteImage',
        //            type: "POST",
        //            contentType: "application/json; charset=utf-8",
        //            dataType: "json",
        //            data: '{ "myFile":"' + name + '"}',
        //            success: function (data) {
        //                var filename = $('#Image').val();
        //                if (filename != "") {
        //                    filename = filename.replace("," + data.d, "");
        //                    filename = filename.replace(data.d + ",", "");
        //                    filename = filename.replace(data.d, "");

        //                    $('#Image').val(filename);
        //                    CheckImagesLength(5);
        //                    $('#btnAddImage').trigger("click");
        //                }

        //            },
        //            error: function () {
        //                alert("server error");
        //            }
        //        });
        //    }
        //}

        //function GetImages(id) {
        //    $.ajax({
        //        url: '/Admin/Business.aspx/GetImages',
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        data: '{ "Id":"' + parseInt(id) + '"}',
        //        success: function (data) {
        //            $('#Image').val(data.d);
        //            CheckImagesLength(5);
        //            $('#btnAddImage').trigger("click");
        //        },
        //        error: function () {
        //            alert("server error");
        //        }
        //    });
        //}





    </script>
    <%--    <script>
        var ImageArr = [];

        Dropzone.options.dropzoneForm = {
            url: "/UploadImages.ashx?type=Business",
            addRemoveLinks: true,
            maxFiles: 5,
            maxFilesize: 1,
            removedfile: function (file) {
                if (confirm("Are you sure do you want to remove this item?")) {
                    var name = file.name;
                    var ValueOfImage = 0;
                    $.each(ImageArr, function (i, val) {
                        if (ImageArr[i].indexOf(name) !== -1) {
                            var image_val = ImageArr[i].split(',');
                            name = image_val[0];
                            ValueOfImage = i;
                        }
                    });
                    ImageArr.splice($.inArray(ImageArr[ValueOfImage], ImageArr), 1);
                    $.ajax({
                        url: '/Admin/Business.aspx/DeleteImage',
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: '{ "myFile":"' + name + '"}',
                        success: function (data) {
                            var filename = $('#Image').val();
                            if (filename != "") {
                                filename = filename.replace("," + data.d, "");
                                filename = filename.replace(data.d, "");
                                $('#Image').val(filename);
                                CheckImagesLength(5);
                                $('#btnAddImage').trigger("click");
                            }

                        },
                        error: function () {
                            alert("server error");
                        }
                    });
                    var _ref;
                    return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
                }
            },
            init: function () {

                this.on("complete", function (data) {
                    var res = data.xhr.responseText;
                    var filename = $('#Image').val();
                    var image = res.split(',');
                    if (filename != "") {
                        $('#Image').val(filename + "," + image[0]);
                    }
                    else {
                        $('#Image').val(image[0]);
                    }
                    ImageArr.push(res);
                    CheckImagesLength(5);
                    $('#btnAddImage').trigger("click");
                    //alert($('#Image').val());

                });
            }
        };
    </script>--%>
    <style>
        .category_img_big {
            width: 200px;
            height: 200px;
        }



        .loading {
            position: fixed;
            top: 50%;
            left: 50%;
            z-index: 999;
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="loading" runat="server" id="divLoader">
        <img src="/images/new.gif" alt="new.gif" />
    </div>
    <asp:HiddenField runat="server" ID="hdnBusinessId" />
    <input type="hidden" id="Image" name="Image" value="" />
    <asp:HiddenField runat="server" ID="hdnImage" />
    <asp:HiddenField runat="server" ID="hdnLongitude" />
    <asp:HiddenField runat="server" ID="hdnLatitude" />
    <asp:HiddenField runat="server" ID="hdnSubCategoryId" />
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Business Listing</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <div style="width: 100%">
        <h3 class="page-title" style="width: 85%; float: left;">Business Listing
                       
        <small>Live Business Listing</small>
        </h3>
        <h3 class="page-title" style="width: 15%; float: right;">Total Records : <strong><%=TotalRecords %></strong>
        </h3>
    </div>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <!-- BEGIN DASHBOARD STATS 1-->

    <div class="clearfix"></div>
    <div class="alert alert-danger hide" id="alertDanger" runat="server">
        <asp:Label ID="lblErrorMsg" Text="" runat="server" />

    </div>
    <div class="alert alert-success hide" id="alertSuccess" runat="server">
        <asp:Label ID="lblSuccessMsg" Text="" runat="server" />
    </div>
    <div class="row GridBusiness">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Business Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ResetAll()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Business</label></a>
                        </div>

                    </div>
                </div>
                <div class="portlet-body" style="padding-bottom: 50px;">
                    <div class="table-container">
                        <div class="col-md-12" style="margin-bottom: 20px;">
                            <asp:DropDownList ID="drpSelectCategory" OnSelectedIndexChanged="drpSelectCategory_OnSelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 200px; margin-left: 20px; display: initial;">
                                <asp:ListItem Text="Select" Value="0" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpSelectSubcategory" runat="server" class="form-control" Style="width: 200px; margin-left: 20px; display: initial;">
                                <asp:ListItem Text="Select" Value="0" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpPage" runat="server" class="form-control" Style="width: 100px; margin-left: 20px; display: initial;">
                                <asp:ListItem Text="20" Value="20" />
                                <asp:ListItem Text="50" Value="50" />
                                <asp:ListItem Text="100" Value="100" />
                            </asp:DropDownList>
                            <asp:Button ID="btnSearch" OnClick="btnSearch_OnClick" OnClientClick="LoadingShow();" Text="Search" runat="server" class="form-control" Style="width: 100px; margin-left: 20px; background-color: #337ab7; color: #fff; display: initial;" />
                        </div>
                        <div id="divBusinessTable" runat="server">
                            <table class="table table-striped table-hover table-bordered">
                                <thead>
                                    <tr role="row" class="heading">
                                        <th>Sno. </th>
                                        <th>Category Name </th>
                                        <th>SubCategory Name </th>
                                        <th>Business Name </th>
                                        <th>Contact person </th>
                                        <th>Phone Number </th>
                                        <th>Email </th>
                                        <th>Website </th>
                                        <th>Status </th>
                                        <th>Actions </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptBusiness" runat="server">
                                        <ItemTemplate>
                                            <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                                <td><%#Eval("SNO") %> </td>
                                                <td><%#Eval("CategoryName") %>  </td>
                                                <td><%#Eval("SubCategoryName") %>  </td>
                                                <td><%#Eval("BusinessName") %>  </td>
                                                <td><%#Eval("ContactPerson") %>  </td>
                                                <td><%#Eval("PhoneNumber1") %>  </td>
                                                <td><%#Eval("Email") %>  </td>
                                                <td><%#Eval("Website") %>  </td>
                                                <td><%#Eval("IsApprovedByAdmin") %> </td>
                                                <td><a class="toggle" data-id="<%#Eval("Id") %>" data-premiumimage="<%#Eval("PremiumImage")%>" data-image="<%#Eval("Image")%>" data-categoryid="<%#Eval("CategoryId") %>" data-subcategoryid="<%#Eval("SubCategoryId") %>" data-email='<%#Eval("Email") %>' data-website='<%#Eval("Website") %>' data-contactperson="<%#Eval("ContactPerson") %>" data-city="<%#Eval("SelectedCity") %>" data-phonenumber2="<%#Eval("PhoneNumber2") %>" data-subcategoryname="<%#Eval("SubCategoryName") %>" data-description="<%#Eval("Description") %>" data-businessname="<%#Eval("BusinessName") %>" data-phonenumber1="<%#Eval("PhoneNumber1") %>" data-categoryname="<%#Eval("CategoryName") %>" data-address="<%#Eval("Address") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" data-subscription="<%#Eval("Subscription") %>" onclick="EditBusiness(this)">
                                                    <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                        Edit</label></a>

                                                    <%--                                                <a class="toggle delete" data-type="Business" data-id="<%#Eval("Id") %>">
                                                    <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                        Delete</label></a>--%>

                                                    <a class="toggle" data-type="Business" onclick="DeactivateBusiness(this);" data-id="<%#Eval("Id") %>">
                                                        <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                            Deactivate</label></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                            </table>
                            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_OnItemCommand">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPaging" CssClass="paging_sect" Text='<%#Eval("Text") %>' CommandArgument='<%#Eval("Value") %>' CommandName="Paging" OnClientClick="LoadingShow();" runat="server" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End: life time stats -->
        </div>
    </div>
    <div class="row BusinessPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Business</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridBusiness')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Business</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->
                    <div id="form_sample_1" class="form-horizontal">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Category    
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpCategory" onchange="BindSubCategoryByCategory(0);" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Sub Category    
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpSubCategory" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Business Name
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBusinessName" runat="server" class="form-control" MaxLength="40" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Contact Person
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" MaxLength="55" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Address
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" onblur="SetCoordinates(this);" runat="server" class="form-control" MaxLength="60" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Phone Number 1
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPhoneNumber1" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Phone Number 2
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPhoneNumber2" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Email
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Website
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtWebsite" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Select City    
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpCity" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Subscription  
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpSubscription" onchange="ShowUploadFile();" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="divPremiumImage" class="hide">
                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Premium Image        
                                    <span class="required">* </span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="FilePremiumImage" runat="server" onchange="PreviewImage(this,'Premium')" class="form-control" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                    </label>
                                    <div class="col-md-4">
                                        <asp:Image ID="TargetPremiumImage" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Image        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fileImage" runat="server" onchange="PreviewImage(this,'About')" class="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                </label>
                                <div class="col-md-4">
                                    <asp:Image ID="target" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
                                </div>
                            </div>

                            <%--<div class="form-group">
                                <label class="control-label col-md-3">
                                </label>
                                <div class="col-md-6">
                                    <div ng-app="MyApp" ng-controller="MyController" id="MyController">
                                        <div ng-repeat="Image in Images" style="float: left; margin-left: 10px;">
                                            <img ng-src="/Admin/BusinessImages/{{Image.Name}}" height="100" width="150" />
                                            <br />
                                            <a onclick="RemoveImage(this)" data-image="{{Image.Name}}">Remove</a>
                                        </div>
                                        <input type="button" name="btnAddImage" id="btnAddImage" ng-click="AddImage();" value="" style="display: none;" />
                                    </div>
                                </div>
                            </div>--%>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Active     
                                </label>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="chkBusiness" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnBusiness" OnClick="btnBusiness_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
                                    <button type="button" class="btn grey-salsa btn-outline">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END VALIDATION STATES-->
        </div>
    </div>
</asp:Content>
