<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LocalLinkers.Admin.Products" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/global/plugins/dropzone/dropzone.min.js"></script>
    <script>
        function BindSubCategoryByCategory(subcategoryid) {
            $('#<%=drpSubCategory.ClientID%>').empty();
            var categoryid = $('#<%=drpCategory.ClientID%> option:selected').val();
            if (parseInt(categoryid) > 0) {
                $.ajax({
                    url: '/Admin/Products.aspx/GetSubCategories',
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



        function EditProduct(btn) {
            var id = $(btn).attr('data-id');
            var title = $(btn).attr('data-title');
            var shortdescription = $(btn).attr('data-shortdescription');
            var description = $(btn).attr('data-description');
            var categoryid = $(btn).attr('data-categoryid');
            var categoryname = $(btn).attr('data-categoryname');
            var subcategoryid = $(btn).attr('data-subcategoryid');
            var subcategoryname = $(btn).attr('data-subcategoryname');
            var actualprice = $(btn).attr('data-actualprice');
            var saleprice = $(btn).attr('data-saleprice');
            var stock = $(btn).attr('data-stock');
            var address = $(btn).attr('data-address');
            var city = $(btn).attr('data-city');
            var position = $(btn).attr('data-position');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            var latitude = $(btn).attr('data-latitude');
            var longitude = $(btn).attr('data-longitude');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkProduct.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }

            GetImages(id);


            $('#<%=hdnProductId.ClientID%>').val(id);
            $('#<%=drpCategory.ClientID%>').val(categoryid);
            $('#<%=hdnSubCategoryId.ClientID%>').val(subcategoryid);

            BindSubCategoryByCategory(subcategoryid);

            $('#<%=txtTitle.ClientID%>').val(title);
            $('#<%=txtDescription.ClientID%>').val(description);
            $('#<%=txtShortDescription.ClientID%>').val(shortdescription);
            $('#<%=txtActualPrice.ClientID%>').val(actualprice);
            $('#<%=txtSalePrice.ClientID%>').val(saleprice);
            $('#<%=txtStock.ClientID%>').val(stock);
            $('#<%=drpCity.ClientID%>').val(city);
            $('#<%=txtAddress.ClientID%>').val(address);
            $('#<%=drpPosition.ClientID%>').val(position);
            $('#Latitude').val(latitude);
            $('#Longitude').val(longitude);
            $('#<%=hdnLatitude.ClientID%>').val(latitude);
            $('#<%=hdnLongitude.ClientID%>').val(longitude);

            ShowPanel('Product');

        }

        function ResetAll() {
            $('#<%=chkProduct.ClientID%>').prop("checked", false);
            $('.checker span').removeClass('checked');
            $('#<%=hdnProductId.ClientID%>').val('');
            $('#<%=drpCategory.ClientID%>').val('0');
            $('#<%=drpSubCategory.ClientID%>').empty();
            $('#<%=hdnSubCategoryId.ClientID%>').val('');
            $('#<%=txtTitle.ClientID%>').val('');
            $('#<%=txtDescription.ClientID%>').val('');
            $('#<%=txtShortDescription.ClientID%>').val('');
            $('#<%=txtActualPrice.ClientID%>').val('');
            $('#<%=txtSalePrice.ClientID%>').val('');
            $('#<%=txtStock.ClientID%>').val('');
            $('#<%=drpCity.ClientID%>').val('0');
            $('#<%=txtAddress.ClientID%>').val('');
            $('#<%=drpPosition.ClientID%>').val('0');
            $('#Latitude').val('');
            $('#Longitude').val('');
            $('#<%=hdnLatitude.ClientID%>').val('');
            $('#<%=hdnLongitude.ClientID%>').val('');
            $('#Image').val('');
            $('#btnAddImage').trigger("click");
            $('.GridProducts').addClass('hide');
            $('.ProductPanel').removeClass('hide');
        }

        function CheckValidation() {
            var Title = $('#<%=txtTitle.ClientID%>').val();
            var Description = $('#<%=txtDescription.ClientID%>').val();
            var ShortDescription = $('#<%=txtShortDescription.ClientID%>').val();
            var Category = $('#<%=drpCategory.ClientID%> option:selected').val();
            var SubCategory = $('#<%=drpSubCategory.ClientID%> option:selected').val();
            var City = $('#<%=drpCity.ClientID%> option:selected').val();
            var ActualPrice = $('#<%=txtActualPrice.ClientID%>').val();
            var SalePrice = $('#<%=txtSalePrice.ClientID%>').val();
            var Stock = $('#<%=txtStock.ClientID%>').val();
            var Address = $('#<%=txtAddress.ClientID%>').val();
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

            if (Description == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter description.";
                }
                $('#<%=txtDescription.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtDescription.ClientID%>').css("border-color", "#c2cad8");
            }

            if (ShortDescription == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter short description.";
                }
                $('#<%=txtShortDescription.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtShortDescription.ClientID%>').css("border-color", "#c2cad8");
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


            if (Stock == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter stock.";
                }
                $('#<%=txtStock.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtStock.ClientID%>').css("border-color", "#c2cad8");
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
                    url: '/Admin/Products.aspx/DeleteImage',
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
                url: '/Admin/Products.aspx/GetImages',
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
            url: "/UploadImages.ashx?type=Products",
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
                        url: '/Admin/Products.aspx/DeleteImage',
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
    <asp:HiddenField runat="server" ID="hdnProductId" />
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
                <span>Products</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
      <div style="width: 100%">
        <h3 class="page-title" style="width: 85%; float: left;">Products
                       
        <small>All Products</small>
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
    <div class="row GridProducts">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Products Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ResetAll()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Product</label></a>
                        </div>

                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>Title </th>
                                    <th>Stock </th>
                                    <th>Actual Price </th>
                                    <th>Sale Price </th>
                                     <th>City </th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptProducts" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("Title") %> </td>
                                            <td><%#Eval("Stock") %>  </td>
                                            <td><%#Eval("ActualPrice") %>  </td>
                                            <td><%#Eval("SalePrice") %>  </td>
                                            <td><%#Eval("CityName") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %> </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-categoryid="<%#Eval("CategoryId") %>" data-subcategoryid="<%#Eval("SubCategoryId") %>" data-stock='<%#Eval("Stock") %>' data-subcategoryname="<%#Eval("SubCategoryName") %>" data-saleprice="<%#Eval("SalePrice") %>" data-actualprice="<%#Eval("ActualPrice") %>" data-title="<%#Eval("Title") %>" data-shortdescription="<%#Eval("ShortDescription") %>" data-description="<%#Eval("Description") %>" data-categoryname="<%#Eval("CategoryName") %>" data-city="<%#Eval("SelectedCity") %>" data-position="<%#Eval("SelectedPosition") %>" data-address="<%#Eval("Address") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" onclick="EditProduct(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>

                                                <a class="toggle delete" data-type="Product" data-id="<%#Eval("Id") %>">
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
    <div class="row ProductPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Product</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridProducts')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Products</label></a>
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
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Short Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtShortDescription" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" MaxLength="1000" />
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
                                    Stock
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtStock" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="5" />
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
                                            <img ng-src="/Admin/ProductImages/{{Image.Name}}" height="100" width="150" />
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
                                    <asp:CheckBox ID="chkProduct" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnProducts" OnClick="btnProducts_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
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
