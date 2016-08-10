<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeactivateCoupons.aspx.cs" Inherits="LocalLinkers.Admin.DeactivateCoupons" EnableEventValidation="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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



        function EditCoupon(btn) {
            var id = $(btn).attr('data-id');
            var title = $(btn).attr('data-title');
            var businessname = $(btn).attr('data-businessname');
            var categoryid = $(btn).attr('data-categoryid');
            var categoryname = $(btn).attr('data-categoryname');
            var subcategoryid = $(btn).attr('data-subcategoryid');
            var subcategoryname = $(btn).attr('data-subcategoryname');
            var actualprice = $(btn).attr('data-actualprice');
            var saleprice = $(btn).attr('data-saleprice');
            var paytomerchant = $(btn).attr('data-paytomerchant');
            var couponmessage = $(btn).attr('data-couponmessage');
            var uniqueid = $(btn).attr('data-uniqueid');
            var quantity = $(btn).attr('data-quantity');
            var couponprice = $(btn).attr('data-couponprice');
            var offerdetails = $(btn).attr('data-offerdetails');
            var termsandcondition = $(btn).attr('data-termsandcondition');
            var phonenumber = $(btn).attr('data-phonenumber');
            var couponprice = $(btn).attr('data-couponprice');
            var address = $(btn).attr('data-address');
            var city = $(btn).attr('data-city');
            var position = $(btn).attr('data-position');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            var latitude = $(btn).attr('data-latitude');
            var longitude = $(btn).attr('data-longitude');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkCoupon.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }

            GetImages(id);


            $('#<%=hdnCouponId.ClientID%>').val(id);
            $('#<%=drpCategory.ClientID%>').val(categoryid);
            $('#<%=hdnSubCategoryId.ClientID%>').val(subcategoryid);

            BindSubCategoryByCategory(subcategoryid);

            $('#<%=txtTitle.ClientID%>').val(title);
            $('#<%=txtBusinessName.ClientID%>').val(businessname);
            $('#<%=txtActualPrice.ClientID%>').val(actualprice);
            $('#<%=txtSalePrice.ClientID%>').val(saleprice);
            $('#<%=txtPayToMerchant.ClientID%>').val(paytomerchant);
            $('#<%=txtCouponPrice.ClientID%>').val(couponprice);
            $('#<%=drpCity.ClientID%>').val(city);
            $('#<%=txtPhoneNumber.ClientID%>').val(phonenumber);
            $('#<%=txtAddress.ClientID%>').val(address);
            $('#<%=drpPosition.ClientID%>').val(position);
            $('#<%=txtCouponMessage.ClientID%>').val(couponmessage);
            $('#<%=hdnUniqueId.ClientID%>').val(uniqueid);
            $('#<%=txtQuantity.ClientID%>').val(quantity);
            CKEDITOR.instances['<%=txtOfferDetails.ClientID%>'].setData(offerdetails);
            CKEDITOR.instances['<%=txtTermsAndCondition.ClientID%>'].setData(termsandcondition);
            $('#Latitude').val(latitude);
            $('#Longitude').val(longitude);
            $('#<%=hdnLatitude.ClientID%>').val(latitude);
            $('#<%=hdnLongitude.ClientID%>').val(longitude);

            ShowPanel('Coupon');

        }

        function ResetAll() {
            $('#<%=chkCoupon.ClientID%>').prop("checked", false);
            $('.checker span').removeClass('checked');
            $('#<%=hdnCouponId.ClientID%>').val('');
            $('#<%=drpCategory.ClientID%>').val('0');
            $('#<%=drpSubCategory.ClientID%>').empty();
            $('#<%=hdnSubCategoryId.ClientID%>').val('');
            $('#<%=txtTitle.ClientID%>').val('');
            $('#<%=txtBusinessName.ClientID%>').val('');
            $('#<%=txtActualPrice.ClientID%>').val('');
            $('#<%=txtSalePrice.ClientID%>').val('');
            $('#<%=txtPayToMerchant.ClientID%>').val('');
            $('#<%=txtCouponMessage.ClientID%>').val('');
            $('#<%=hdnUniqueId.ClientID%>').val('');
            $('#<%=txtQuantity.ClientID%>').val('');
            $('#<%=txtCouponPrice.ClientID%>').val('');
            $('#<%=drpCity.ClientID%>').val('0');
            $('#<%=txtPhoneNumber.ClientID%>').val('');
            $('#<%=txtAddress.ClientID%>').val('');
            $('#<%=drpPosition.ClientID%>').val('0');
            $('#Latitude').val('');
            $('#Longitude').val('');
            $('#<%=hdnLatitude.ClientID%>').val('');
            $('#<%=hdnLongitude.ClientID%>').val('');
            CKEDITOR.instances['<%=txtOfferDetails.ClientID%>'].setData('');
            CKEDITOR.instances['<%=txtTermsAndCondition.ClientID%>'].setData('');
            $('#Image').val('');
            $('#btnAddImage').trigger("click");
            $('.GridCoupons').addClass('hide');
            $('.CouponPanel').removeClass('hide');
        }

        function CheckValidation() {
            var Title = $('#<%=txtTitle.ClientID%>').val();
            var BusinessName = $('#<%=txtBusinessName.ClientID%>').val();
            var Category = $('#<%=drpCategory.ClientID%> option:selected').val();
            var SubCategory = $('#<%=drpSubCategory.ClientID%> option:selected').val();
            var City = $('#<%=drpCity.ClientID%> option:selected').val();
            var OfferDetails = $('#<%=txtOfferDetails.ClientID%>').val();
            var TermsAndCondition = $('#<%=txtTermsAndCondition.ClientID%>').val();
            var ActualPrice = $('#<%=txtActualPrice.ClientID%>').val();
            var SalePrice = $('#<%=txtSalePrice.ClientID%>').val();
            var PayToMerchant = $('#<%=txtPayToMerchant.ClientID%>').val();
            var CouponPrice = $('#<%=txtCouponPrice.ClientID%>').val();
            var Address = $('#<%=txtAddress.ClientID%>').val();
            var CouponMessage = $('#<%=txtCouponMessage.ClientID%>').val();
            var Quantity = $('#<%=txtQuantity.ClientID%>').val();
            var Image = $('#Image').val();
            var Latitude = $('#Latitude').val();
            var Longitude = $('#Longitude').val();
            $('#<%=hdnImage.ClientID%>').val(Image);
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

            if (Title == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter title.";
                }
                $('#<%=txtTitle.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtTitle.ClientID%>').css("border-color", "#c2cad8");
            }

            if (Title.indexOf('-') > 0 || Title.indexOf('&') > 0 || Title.indexOf('/') > 0 || Title.indexOf('|') > 0 || Title.indexOf(';') > 0 || Title.indexOf('<') > 0 || Title.indexOf('>') > 0 || Title.indexOf('+') > 0) {
                if (ErrorMessage == "") {
                    ErrorMessage = "This type of (-,&,/,|,;,<,>,+) special characters is not allowed in title field.";
                }
                $('#<%=txtTitle.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtTitle.ClientID%>').css("border-color", "#c2cad8");
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

            if (ActualPrice == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter actual price.";
                }
                $('#<%=txtActualPrice.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtActualPrice.ClientID%>').css("border-color", "#c2cad8");
            }

            if (SalePrice == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter sale price.";
                }
                $('#<%=txtSalePrice.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtSalePrice.ClientID%>').css("border-color", "#c2cad8");
            }


            if (PayToMerchant == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter pay to merchant.";
                }
                $('#<%=txtPayToMerchant.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtPayToMerchant.ClientID%>').css("border-color", "#c2cad8");
            }

            if (CouponPrice == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter coupon price.";
                }
                $('#<%=txtCouponPrice.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtCouponPrice.ClientID%>').css("border-color", "#c2cad8");
            }

            if (CouponMessage == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter coupon message.";
                }
                $('#<%=txtCouponMessage.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtCouponMessage.ClientID%>').css("border-color", "#c2cad8");
            }

            if (Quantity == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter quantity.";
                }
                $('#<%=txtQuantity.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtQuantity.ClientID%>').css("border-color", "#c2cad8");
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

          <%--  if (OfferDetails == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please select offer details.";
                }
                $('#<%=txtOfferDetails.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtOfferDetails.ClientID%>').css("border-color", "#c2cad8");
            }

            if (TermsAndCondition == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please select terms and condition.";
                }
                $('#<%=txtTermsAndCondition.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtTermsAndCondition.ClientID%>').css("border-color", "#c2cad8");
            }--%>


            if (City == "0") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please select city.";
                }
                $('#<%=drpCity.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=drpCity.ClientID%>').css("border-color", "#c2cad8");
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


        function DeleteMsg(result) {
            $('#<%=lblSuccessMsg.ClientID%>').text(result.d);
            $('#<%=alertSuccess.ClientID%>').removeClass('hide');
        }

        function RemoveImage(btn) {
            if (confirm("Are you sure do you want to remove this item?")) {
                var name = $(btn).attr('data-image');
                $.ajax({
                    url: '/Admin/Coupons.aspx/DeleteImage',
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{ "myFile":"' + name + '"}',
                    success: function (data) {
                        var filename = $('#Image').val();
                        if (filename != "") {
                            filename = filename.replace("," + data.d, "");
                            filename = filename.replace(data.d + ",", "");
                            filename = filename.replace(data.d, "");

                            $('#Image').val(filename);
                            CheckImagesLength(4);
                            $('#btnAddImage').trigger("click");
                        }
                    },
                    error: function () {
                        alert("server error");
                    }
                });
            }
        }

        function GetImages(id) {
            $.ajax({
                url: '/Admin/Coupons.aspx/GetImages',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{ "Id":"' + parseInt(id) + '"}',
                success: function (data) {
                    $('#Image').val(data.d);
                    CheckImagesLength(4);
                    $('#btnAddImage').trigger("click");
                },
                error: function () {
                    alert("server error");
                }
            });
        }
    </script>
    <script>
        var ImageArr = [];
        Dropzone.options.dropzoneForm = {
            url: "/UploadImages.ashx?type=Coupons",
            addRemoveLinks: true,
            maxFiles: 4,
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
                        url: '/Admin/Coupons.aspx/DeleteImage',
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
                                CheckImagesLength(4);
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
                    CheckImagesLength(4);
                    $('#btnAddImage').trigger("click");
                    //alert($('#Image').val());

                });
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnCouponId" />
    <input type="hidden" id="Image" name="Image" value="" />
    <asp:HiddenField runat="server" ID="hdnImage" />
    <asp:HiddenField runat="server" ID="hdnUniqueId" />
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
                <span>Coupons</span>
            </li>
        </ul>
    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
        <div style="width:100%">
        <h3 class="page-title" style="width:85%;float:left;">Coupons
                       
        <small>Deactivate Coupons</small>
        </h3>
        <h3 class="page-title" style="width:15%;float:right;">Total Records : <strong><%=TotalRecords %></strong>
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
    <div class="row GridCoupons">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Coupons Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ResetAll()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Coupon</label></a>
                        </div>

                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>Position</th>
                                    <th>Title </th>
                                    <th>Business Name </th>
                                    <th>Phone Number </th>
                                    <th>Actual Price </th>
                                    <th>Sale Price </th>
                                    <th>Pay To Merchant </th>
                                    <th>Coupon Price </th>
                                    <th>City </th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCoupons" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("SelectedPosition") %> </td>
                                            <td><%#Eval("Title") %> </td>
                                            <td><%#Eval("BusinessName") %>  </td>
                                            <td><%#Eval("PhoneNumber") %>  </td>
                                            <td><%#Eval("ActualPrice") %>  </td>
                                            <td><%#Eval("SalePrice") %>  </td>
                                            <td><%#Eval("PayToMerchant") %>  </td>
                                            <td><%#Eval("CouponPrice") %>  </td>
                                            <td><%#Eval("CityName") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %> </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-categoryid="<%#Eval("CategoryId") %>" data-subcategoryid="<%#Eval("SubCategoryId") %>" data-offerdetails='<%#Eval("OfferDetails") %>' data-termsandcondition='<%#Eval("TermsAndCondition") %>' data-couponprice="<%#Eval("CouponPrice") %>" data-paytomerchant="<%#Eval("PayToMerchant") %>" data-subcategoryname="<%#Eval("SubCategoryName") %>" data-saleprice="<%#Eval("SalePrice") %>" data-actualprice="<%#Eval("ActualPrice") %>" data-title="<%#Eval("Title") %>" data-businessname="<%#Eval("BusinessName") %>" data-phonenumber="<%#Eval("PhoneNumber") %>" data-categoryname="<%#Eval("CategoryName") %>" data-city="<%#Eval("SelectedCity") %>" data-position="<%#Eval("SelectedPosition") %>" data-address="<%#Eval("Address") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" data-couponmessage="<%#Eval("CouponMessage") %>" data-uniqueid="<%#Eval("UniqueId") %>" data-quantity="<%#Eval("Quantity") %>" onclick="EditCoupon(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="Coupon" data-id="<%#Eval("Id") %>">
                                                    <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                        Delete</label></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- End: life time stats -->
        </div>
    </div>
    <div class="row CouponPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Coupon</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridCoupons')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Coupons</label></a>
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
                                    Title
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Business Name
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBusinessName" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Phone Number
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPhoneNumber" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Actual Price
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtActualPrice" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Sale Price
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSalePrice" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Pay To Merchant
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPayToMerchant" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Coupon Price
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtCouponPrice" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Coupon Message
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtCouponMessage" runat="server" class="form-control" MaxLength="50" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Quantity
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtQuantity" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Address
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" onblur="SetCoordinates(this);" class="form-control" MaxLength="500" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Offer Details
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-8">
                                    <CKEditor:CKEditorControl ID="txtOfferDetails" BasePath="~/ckeditor" Height="200" runat="server"></CKEditor:CKEditorControl>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    TermsAndcondition
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-8">
                                    <CKEditor:CKEditorControl ID="txtTermsAndCondition" BasePath="~/ckeditor" Height="200" runat="server"></CKEditor:CKEditorControl>

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
                                    Select Position    
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpPosition" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" Value="0" />
                                        <asp:ListItem Text="1" Value="1" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="4" Value="4" />
                                        <asp:ListItem Text="5" Value="5" />
                                        <asp:ListItem Text="6" Value="6" />
                                        <asp:ListItem Text="7" Value="7" />
                                        <asp:ListItem Text="8" Value="8" />
                                        <asp:ListItem Text="9" Value="9" />
                                        <asp:ListItem Text="10" Value="10" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Images        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <a id="lnkAddImage" href="#divPicture" class="fancybox">AddImage</a>
                                    <span class="help-block">Note:Limit of images is 4.</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                </label>
                                <div class="col-md-6">
                                    <div ng-app="MyApp" ng-controller="MyController" id="MyController">
                                        <div ng-repeat="Image in Images" style="float: left; margin-left: 10px;">
                                            <img ng-src="/Admin/CouponImages/{{Image.Name}}" height="100" width="150" />
                                            <br />
                                            <a onclick="RemoveImage(this)" data-image="{{Image.Name}}">Remove</a>
                                        </div>
                                        <input type="button" name="btnAddImage" id="btnAddImage" ng-click="AddImage();" value="" style="display: none;" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Active        
                                </label>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="chkCoupon" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnCoupons" OnClick="btnCoupons_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
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
