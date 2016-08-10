<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AddBusiness.aspx.cs" Inherits="LocalLinkers.AddBusiness" EnableEventValidation="false" %>

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

        function PreviewImage(input, type) {
            var file = $('#<%=fileImage.ClientID%>');
            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = new Image;

                    img.onload = function () {
                        if (img.width >= 320 && img.height >= 293) {
                            $('#<%=target.ClientID%>').attr('src', e.target.result);
                        }
                        else {
                            alert("Please select 320*293 or greater than this dimension image")
                            $(file).replaceWith($(file).clone());
                        }
                    };
                    img.src = e.target.result;

                }
                reader.readAsDataURL(input.files[0]);
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
            $('#Latitude').val(latitude);
            $('#Longitude').val(longitude);
            $('#<%=hdnLatitude.ClientID%>').val(latitude);
            $('#<%=hdnLongitude.ClientID%>').val(longitude);
            $('#<%=target.ClientID%>').attr('src', "/Admin/BusinessImages/" + image);
            $('.GridBusiness').addClass('hide');
            $('.BusinessPanel').removeClass('hide');
        }

        function ResetAll() {
            $('#<%=hdnBusinessId.ClientID%>').val('');
            $('#<%=drpCategory.ClientID%>').val('0');
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
            $('#btnAddImage').trigger("click");
            $('.GridBusiness').addClass('hide');
            $('.BusinessPanel').removeClass('hide');
            return false;
        }

        function CheckValidation() {
            var PhoneNumber = $('#<%=txtPhoneNumber1.ClientID%>').val();
                var BusinessName = $('#<%=txtBusinessName.ClientID%>').val();
                var Category = $('#<%=drpCategory.ClientID%> option:selected').val();
                var SubCategory = $('#<%=drpSubCategory.ClientID%> option:selected').val();
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
        .AddBusiness_Btn {
            color: #fff;
            font-size: 16px;
            float: right;
            margin-bottom: 10px;
            background: #9368e9 !important;
        }

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

    <div class="clearfix"></div>
    <div class="alert alert-danger hide" id="alertDanger" runat="server">
        <asp:Label ID="lblErrorMsg" Text="" runat="server" />

    </div>
    <div class="alert alert-success hide" id="alertSuccess" runat="server">
        <asp:Label ID="lblSuccessMsg" Text="" runat="server" />
    </div>
    <div class="content GridBusiness">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header text-center">
                            <div class="san-add-button">
                                <h4 class="title"><a onclick="return ResetAll();" class="btn btn-default btn-fill btn-wd AddBusiness_Btn">Add Business</a></h4>
                            </div>
                            <div class="san-my-coupon">
                                <h4 class="title">My Business</h4>
                                <p class="category coupan-text">
                                    Reach customers with local advertising on locallinkes.
                                    <br />
                                    Set up your business listing and profile on the Saharanpur's leading online business directory
                                </p>
                                <br />
                            </div>
                        </div>
                        <div class="content table-responsive table-full-width">
                            <div id="divBusiness" runat="server">
                                <table class="table table-bigboy">
                                    <thead>
                                        <tr>
                                            <th class="text-center">Image</th>
                                            <th>Business Name</th>
                                            <th class="th-description">Status</th>
                                            <th class="text-right">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptBusiness" runat="server">
                                            <ItemTemplate>
                                                <tr id="Row_<%#Eval("Id") %>">
                                                    <td>
                                                        <img src='<%=DataAccess.Classes.ClsCommon.BusinessImagesPath%><%#Eval("Image") %>?width=100&height=100' alt="<%#Eval("Image") %>" /></td>
                                                    <td class="td-name"><%#Eval("BusinessName") %>  </td>
                                                    <td class="td-number"><%#Convert.ToBoolean(Eval("IsApprovedByAdmin"))?"Verified":"UnVerified" %> </td>
                                                    <td class="td-number"><a class="toggle" style="cursor: pointer;" data-id="<%#Eval("Id") %>" data-categoryid="<%#Eval("CategoryId") %>" data-subcategoryid="<%#Eval("SubCategoryId") %>" data-email='<%#Eval("Email") %>' data-website='<%#Eval("Website") %>' data-contactperson="<%#Eval("ContactPerson") %>" data-city="<%#Eval("SelectedCity") %>" data-phonenumber2="<%#Eval("PhoneNumber2") %>" data-subcategoryname="<%#Eval("SubCategoryName") %>" data-description="<%#Eval("Description") %>" data-businessname="<%#Eval("BusinessName") %>" data-phonenumber1="<%#Eval("PhoneNumber1") %>" data-categoryname="<%#Eval("CategoryName") %>" data-address="<%#Eval("Address") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" data-subscription="<%#Eval("Subscription") %>" data-image="<%#Eval("Image") %>" onclick="EditBusiness(this)">Edit</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <div id="divNoRecords" style="font-size: 20px; text-align: center; margin-top: 200px;" runat="server">
                                No Records
                            </div>
                        </div>

                    </div>

                    <!--  end card  -->
                </div>
                <!-- end col-md-12 -->
            </div>
            <!-- end row -->

        </div>
    </div>
    <div class="content BusinessPanel hide">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div id="wizardCard" class="card card-wizard san-card-wizard">
                        <div id="wizardForm">
                            <div class="content">
                                <div class="tab-content">
                                    <div id="tab1" class="tab-pane active">
                                        <h5 class="text-center">Add New Business</h5>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Category</label>
                                                    <asp:DropDownList ID="drpCategory" onchange="BindSubCategoryByCategory(0);" runat="server" class="form-control">
                                                        <asp:ListItem Text="Select" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Sub-Category</label>
                                                    <asp:DropDownList ID="drpSubCategory" runat="server" class="form-control">
                                                        <asp:ListItem Text="Select" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Business Name</label>
                                                    <asp:TextBox ID="txtBusinessName" runat="server" class="form-control" MaxLength="40" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Contact Person</label>
                                                    <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" MaxLength="55" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Business Description</label>
                                                    <div class="san-textarea">
                                                        <asp:TextBox ID="txtDescription" runat="server" class="form-control" MaxLength="200" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Adress</label>
                                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" onblur="SetCoordinates(this);" runat="server" class="form-control" MaxLength="60" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Phone Number 1</label>
                                                    <asp:TextBox ID="txtPhoneNumber1" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Phone Number 2 (Optional)</label>
                                                    <asp:TextBox ID="txtPhoneNumber2" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Email (Optional)</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Website (Optional)</label>
                                                    <asp:TextBox ID="txtWebsite" runat="server" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">City</label>
                                                    <asp:DropDownList ID="drpCity" runat="server" class="form-control">
                                                        <asp:ListItem Text="Select" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Image</label>
                                                    <asp:FileUpload ID="fileImage" runat="server" onchange="PreviewImage(this,'About')" class="form-control" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <asp:Image ID="target" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="san-edit-button-save">
                                                    <asp:Button ID="btnBusiness" OnClick="btnBusiness_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn btn-fill btn-info" runat="server" />
                                                </div>

                                                <div class="san-edit-button-concel">
                                                    <button type="button" class="btn btn-fill btn-info">Cancel</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
