<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TemplateContact.aspx.cs" Inherits="LocalLinkers.Admin.TemplateContact" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditTemplateContact(btn) {
            var id = $(btn).attr('data-id');
            var templateid = $(btn).attr('data-templateid');
            var email = $(btn).attr('data-email');
            var website = $(btn).attr('data-website');
            var phonenumber = $(btn).attr('data-phonenumber');
            var facebooklink = $(btn).attr('data-facebooklink');
            var twitterlink = $(btn).attr('data-twitterlink');
            var tumblarlink = $(btn).attr('data-tumblarlink');
            var pininterestlink = $(btn).attr('data-pininterestlink');
            var googlelink = $(btn).attr('data-googlelink');
            var address = $(btn).attr('data-address');
            var city = $(btn).attr('data-city');
            var state = $(btn).attr('data-state');
            var latitude = $(btn).attr('data-latitude');
            var longitude = $(btn).attr('data-longitude');
            var postalcode = $(btn).attr('data-postalcode');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkTemplate.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }

            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=txtEmail.ClientID%>').val(email);
            $('#<%=txtWebsite.ClientID%>').val(website);
            $('#<%=txtFacebookLink.ClientID%>').val(facebooklink);
            $('#<%=txtTwitterLink.ClientID%>').val(twitterlink);
            $('#<%=txtPhoneNumber.ClientID%>').val(phonenumber);
            $('#<%=txtTumblarLink.ClientID%>').val(tumblarlink);
            $('#<%=txtGoogleLink.ClientID%>').val(googlelink);
            $('#<%=txtPinInterestLink.ClientID%>').val(pininterestlink);
            $('#<%=txtAddress.ClientID%>').val(address);
            $('#<%=txtCity.ClientID%>').val(city);
            $('#<%=txtState.ClientID%>').val(state);
            $('#<%=txtPostalCode.ClientID%>').val(postalcode);
            $('#<%=TemplateContactForm.ClientID%>').css("display", "block");
            $('#<%=GridTemplateContactPanel.ClientID%>').css("display", "none");
            $('#Latitude').val(latitude);
            $('#Longitude').val(longitude);
            $('#<%=hdnLatitude.ClientID%>').val(latitude);
            $('#<%=hdnLongitude.ClientID%>').val(longitude);

        }

        function ShowTemplates() {
            window.location.href = "/Admin/Template";
        }


        function CheckValidation() {
            var PhoneNumber = $('#<%=txtPhoneNumber.ClientID%>').val();
            var FacebookLink = $('#<%=txtFacebookLink.ClientID%>').val();
            var TumblarLink = $('#<%=txtTumblarLink.ClientID%>').val();
            var Email = $('#<%=txtEmail.ClientID%>').val();
            var Website = $('#<%=txtWebsite.ClientID%>').val();
            var GoogleLink = $('#<%=txtGoogleLink.ClientID%>').val();
            var PinInterestLink = $('#<%=txtPinInterestLink.ClientID%>').val();
            var TwitterLink = $('#<%=txtTwitterLink.ClientID%>').val();
            var Address = $('#<%=txtAddress.ClientID%>').val();
            var City = $('#<%=txtCity.ClientID%>').val();
            var State = $('#<%=txtState.ClientID%>').val();
            var PostalCode = $('#<%=txtPostalCode.ClientID%>').val();
            var Latitude = $('#Latitude').val();
            var Longitude = $('#Longitude').val();
            $('#<%=hdnLatitude.ClientID%>').val(Latitude);
            $('#<%=hdnLongitude.ClientID%>').val(Longitude);
            var ErrorMessage = "";


        <%--    if (Website == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter website.";
                }
                $('#<%=txtWebsite.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtWebsite.ClientID%>').css("border-color", "#c2cad8");
            }--%>

            if (City == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter city.";
                }
                $('#<%=txtCity.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtCity.ClientID%>').css("border-color", "#c2cad8");
            }

            if (State == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter state.";
                }
                $('#<%=txtState.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtState.ClientID%>').css("border-color", "#c2cad8");
            }


            if (PostalCode == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter postalcode.";
                }
                $('#<%=txtPostalCode.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtPostalCode.ClientID%>').css("border-color", "#c2cad8");
            }

 <%--           if (Email == "") {
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


            if (PhoneNumber == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter phone number.";
                }
                $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "red");
        }
        else {
            $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "#c2cad8");
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

<%--                if (FacebookLink == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter facebook link.";
                    }
                    $('#<%=txtFacebookLink.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtFacebookLink.ClientID%>').css("border-color", "#c2cad8");
                }


                if (TumblarLink == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter tumblar link.";
                    }
                    $('#<%=txtTumblarLink.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtTumblarLink.ClientID%>').css("border-color", "#c2cad8");
                }

                if (GoogleLink == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter google link.";
                    }
                    $('#<%=txtGoogleLink.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtGoogleLink.ClientID%>').css("border-color", "#c2cad8");
                }

                if (PinInterestLink == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter pininterest link.";
                    }
                    $('#<%=txtPinInterestLink.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtPinInterestLink.ClientID%>').css("border-color", "#c2cad8");
                }

                if (TwitterLink == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter twitter link.";
                    }
                    $('#<%=txtTwitterLink.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtTwitterLink.ClientID%>').css("border-color", "#c2cad8");
                }--%>

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
                $('#<%=TemplateContactForm.ClientID%>').css("display", "block");
                $('#<%=GridTemplateContactPanel.ClientID%>').css("display", "none");
            }

            function SetAddressCoordinates() {

                var MainAddress = $('#<%=txtAddress.ClientID%>').val();
            var City = $('#<%=txtCity.ClientID%>').val();
            var State = $('#<%=txtState.ClientID%>').val();

                //var address = State + "," + City + "," + MainAddress;
                var address = MainAddress + ", " + City + ", " + State;
            if (State != "" && City != "" && address != "") {
                $.ajax({
                    url: '/Admin/Coupons.aspx/FindCoordinates',
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{ "Address":"' + address.toString() + '"}',
                    success: function (data) {
                        debugger;
                        var coordinates = data.d.split(',');
                        $('#Latitude').val(coordinates[0]);
                        $('#Longitude').val(coordinates[1]);
                    },
                    error: function () {
                        alert("server error");
                    }
                });
            }
        }

    </script>

    <style>
        .category_img {
            width: 50px;
            height: 50px;
        }

        .category_img_big {
            width: 150px;
            height: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnId" />
    <asp:HiddenField runat="server" ID="hdnLongitude" />
    <asp:HiddenField runat="server" ID="hdnLatitude" />

    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Contact Us</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <h3 class="page-title">Contact Us
                       
        <small>Contact Us Listing</small>
    </h3>
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
    <div class="row TemplateContactPanel" id="TemplateContactForm" runat="server">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add Contact</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowTemplates();">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Templates</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->
                    <div id="form_sample_1" class="form-horizontal">
                        <div class="form-body">

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Address
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAddress" onblur="SetAddressCoordinates();" TextMode="MultiLine" runat="server" class="form-control" MaxLength="500" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    City
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtCity" onblur="SetAddressCoordinates();" runat="server" class="form-control" MaxLength="20" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    State
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtState" onblur="SetAddressCoordinates();" runat="server" class="form-control" MaxLength="50" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    PostalCode
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPostalCode" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="6" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Phone Number
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPhoneNumber" onkeypress="return isNumberKey(event)" runat="server" class="form-control NoCopyPaste" MaxLength="20" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Email
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Website
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtWebsite" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Facebook Link
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtFacebookLink" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Twiiter Link
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTwitterLink" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Google Link
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtGoogleLink" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    PinInterest Link
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPinInterestLink" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Tumblar Link
                                <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTumblarLink" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Active  
                                </label>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="chkTemplate" Text="" runat="server" />
                                </div>
                            </div>

                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnTemplateContact" OnClick="btnTemplateContact_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
                                        <a href="/Admin/Template" class="btn grey-salsa btn-outline">Cancel</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END VALIDATION STATES-->
    </div>
    <div class="row GridTemplateContact" id="GridTemplateContactPanel" runat="server">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Contact Us</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowTemplates();">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Templates</label></a>
                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>BusinessName</th>
                                    <th>PhoneNumber</th>
                                    <th>Address</th>
                                    <th>Email</th>
                                    <th>Website</th>
                                    <th>Facebook</th>
                                    <th>Twitter</th>
                                    <th>Tumblar</th>
                                    <th>Google</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptTemplate" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("TemplateName") %></td>
                                            <td><%#Eval("PhoneNumber") %></td>
                                            <td><%#Eval("Address") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td><%#Eval("Website") %></td>
                                            <td><%#Eval("FaceBookLink") %></td>
                                            <td><%#Eval("TwitterLink") %></td>
                                            <td><%#Eval("TumblerLink") %></td>
                                            <td><%#Eval("GoogleLink") %></td>
                                            <td><%#Eval("IsApprovedByAdmin") %></td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-templateid="<%#Eval("TemplateId") %>" data-latitude="<%#Eval("Latitude") %>" data-longitude="<%#Eval("Longitude") %>" data-facebooklink="<%#Eval("FaceBookLink") %>" data-email='<%#Eval("Email") %>' data-website='<%#Eval("Website") %>' data-tumblarlink="<%#Eval("TumblerLink") %>" data-googlelink="<%#Eval("GoogleLink") %>" data-pininterestlink="<%#Eval("PinInterestLink") %>" data-twitterlink="<%#Eval("TwitterLink") %>" data-phonenumber="<%#Eval("PhoneNumber") %>" data-address="<%#Eval("Address") %>" data-city="<%#Eval("City") %>" data-state="<%#Eval("State") %>" data-postalcode="<%#Eval("PostalCode") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditTemplateContact(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="TemplateContact" data-id="<%#Eval("Id") %>">
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
</asp:Content>
