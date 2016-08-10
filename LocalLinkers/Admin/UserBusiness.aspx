<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserBusiness.aspx.cs" Inherits="LocalLinkers.Admin.UserBusiness" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            if (isapprovedbyadmin == "True") {
                $('#<%=chkBusiness.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }


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
            $('#<%=target.ClientID%>').attr('src', "/Admin/BusinessImages/" + image);
            $('#Latitude').val(latitude);
            $('#Longitude').val(longitude);
            $('#<%=hdnLatitude.ClientID%>').val(latitude);
            $('#<%=hdnLongitude.ClientID%>').val(longitude);
            ShowPanel('Business');

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
            var Latitude = $('#Latitude').val();
            var Longitude = $('#Longitude').val();
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


        function DeleteMsg(result) {
            $('#<%=lblSuccessMsg.ClientID%>').text(result.d);
            $('#<%=alertSuccess.ClientID%>').removeClass('hide');
        }


    </script>
     <style>
        .category_img_big {
            width: 200px;
            height: 200px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnBusinessId" />
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
                       
        <small>All Business Listing</small>
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
                        <span class="caption-subject font-green sbold uppercase">User Created Business Listing </span>
                    </div>

                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
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
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-categoryid="<%#Eval("CategoryId") %>" data-image="<%#Eval("Image") %>" data-subcategoryid="<%#Eval("SubCategoryId") %>" data-email='<%#Eval("Email") %>' data-website='<%#Eval("Website") %>' data-contactperson="<%#Eval("ContactPerson") %>" data-city="<%#Eval("SelectedCity") %>" data-phonenumber2="<%#Eval("PhoneNumber2") %>" data-subcategoryname="<%#Eval("SubCategoryName") %>" data-description="<%#Eval("Description") %>" data-businessname="<%#Eval("BusinessName") %>" data-phonenumber1="<%#Eval("PhoneNumber1") %>" data-categoryname="<%#Eval("CategoryName") %>" data-address="<%#Eval("Address") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" data-subscription="<%#Eval("Subscription") %>" onclick="EditBusiness(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>

                                                <a class="toggle delete" data-type="Business" data-id="<%#Eval("Id") %>">
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
                                    <asp:TextBox ID="txtBusinessName" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Contact Person
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control" MaxLength="400" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Address
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" onblur="SetCoordinates(this);" runat="server" class="form-control" MaxLength="500" />
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
                                    <asp:DropDownList ID="drpSubscription" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" />
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Images        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fileImage" runat="server" onchange="PreviewImage(this,'About')" class="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                </label>
                                <div class="col-md-6">
                                    <asp:Image ID="target" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
                                </div>
                            </div>

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
