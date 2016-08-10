<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LocalLinkers.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PreviewImage(input) {
            var file = $('#<%=fileUserUpload.ClientID%>');
            var fileextension = input.files[0].name.split(".");
            if (fileextension[1].toLowerCase() == "jpg" || fileextension[1].toLowerCase() == "jpeg" || fileextension[1].toLowerCase() == "gif" || fileextension[1].toLowerCase() == "png") {
                if (parseInt(input.files[0].size / 1024 / 1024) >= 1) {
                    alert('The file size can not exceed 1MB.');
                    $(file).replaceWith($(file).clone());
                    return false;
                }
                else {
                    if (input.files && input.files[0]) {

                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#<%=target.ClientID%>').attr('src', e.target.result);
                        }
                        reader.readAsDataURL(input.files[0]);
                    }
                }
            }
            else {
                alert('This file is not jpg,png,gif.Please add only jpg,png,gif file.');
                $(file).replaceWith($(file).clone());
                return false;
            }
        }
        function UploadImageClick()
        {
            $('#<%=fileUserUpload.ClientID%>').trigger('click');
            return false;
        }
        function VaildImage(id) {
            var file = $('#<%=fileUserUpload.ClientID%>');
            var fileextension = id.files[0].name.split(".");
            if (fileextension[1].toLowerCase() != "jpg"||fileextension[1].toLowerCase() != "png") {
                alert('This file is not mp4.Please add only mp4 file.');
                $(file).replaceWith($(file).clone());
            }
            else if (parseInt(id.files[0].size / 1024 / 1024) >= 1) {
                alert('The file size can not exceed 1MB.');
                $(file).replaceWith($(file).clone());
            }

        }
    </script>
    <style>
        .UserPhoto img {
            width: 200px;
            height: 200px;
            overflow: hidden;
            border-radius: 50%;
            border: 4px solid gray;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger hide" id="alertDanger" runat="server">
        <asp:Label ID="lblErrorMsg" Text="" runat="server" />

    </div>
    <div class="alert alert-success hide" id="alertSuccess" runat="server">
        <asp:Label ID="lblSuccessMsg" Text="" runat="server" />
    </div>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div id="wizardCard" class="card card-wizard">
                        <div id="wizardForm">

                            <div class="content">
                                <div class="tab-content">
                                    <div id="tab1" class="tab-pane active">
                                        <h5 class="text-center">Personal Information</h5>
                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Name</label>
                                                    <asp:TextBox runat="server" ID="txtName" placeholder="Name" class="form-control" MaxLength="20" />
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Adress Line 1</label>
                                                    <asp:TextBox runat="server" ID="txtAddress1" placeholder="Adress Line 1" class="form-control" MaxLength="200" />

                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Adress Line 2</label>
                                                    <asp:TextBox runat="server" ID="txtAddress2" placeholder="Adress Line 2" class="form-control" MaxLength="200" />
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">City</label>
                                                    <asp:TextBox runat="server" ID="txtCity" placeholder="City" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <label class="control-label">State</label>
                                                    <asp:TextBox runat="server" ID="txtState" placeholder="State" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Country</label>
                                                    <asp:TextBox runat="server" ID="txtCountry" placeholder="Country" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <label class="control-label">Zip / Pincode</label>
                                                    <asp:TextBox runat="server" ID="txtZip" placeholder="Zip / Pincode" class="form-control" MaxLength="10" />
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <br />

                                        <h5 class="text-center">Contact Information</h5>
                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-1">
                                                <div class="form-group">
                                                    <div class="UserPhoto">
                                                        <asp:Image ID="target" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
                                                    </div>
                                                    <a onclick="return UploadImageClick();" style="cursor:pointer;margin-left: 56px;">Upload Image</a>
                                                    <asp:FileUpload ID="fileUserUpload"  runat="server" onchange="PreviewImage(this)" class="form-control hide"  />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Email</label>
                                                    <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <label class="control-label">Phone</label>
                                                    <asp:TextBox runat="server" ID="txtPhone" placeholder="Phone" class="form-control" MaxLength="10" ReadOnly="true" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="control-label">Website</label>
                                                    <asp:TextBox runat="server" ID="txtWebsite" placeholder="Website" class="form-control" MaxLength="100" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-10 col-md-offset-1">
                                            <div class="san-edit-button-save">
                                                <asp:Button Text="Save" ID="btnSubmit" OnClick="btnSubmit_OnClick" CssClass="btn btn-fill btn-info" runat="server" />
                                            </div>

                                            <div class="san-edit-button-concel">
                                                <button class="btn btn-fill btn-info" type="submit">Cancel</button>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="footer">
                                <button class="btn btn-default btn-fill btn-wd btn-back pull-left disabled" type="button" style="display: none;">Back</button>

                                <button onclick="onFinishWizard()" class="btn btn-info btn-fill btn-wd btn-finish pull-right" type="button">Finish</button>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
