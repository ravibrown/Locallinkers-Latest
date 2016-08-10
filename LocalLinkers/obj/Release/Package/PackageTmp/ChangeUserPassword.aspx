<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ChangeUserPassword.aspx.cs" Inherits="LocalLinkers.ChangeUserPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function CheckValidation() {
               var oldpassword = $('#<%=txtOldPassword.ClientID%>').val();
                var newpassword = $('#<%=txtNewPassword.ClientID%>').val();
                var confirmpassword = $('#<%=txtConfirmPassword.ClientID%>').val();
                var ErrorMessage = "";

                if (oldpassword == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter old password.";
                    }
                    $('#<%=txtOldPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtOldPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (newpassword == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter new password.";
                    }
                    $('#<%=txtNewPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtNewPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (confirmpassword == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter confirm password.";
                    }
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (confirmpassword != "" && newpassword != "" && confirmpassword != newpassword) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Confirm password and new password doesn't matched.";
                    }
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "#c2cad8");
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
    </script>
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
                <div class="col-md-6 col-md-offset-3">
                    <div class="card">
                        <div id="loginFormValidation">
                            <div class="header text-center">Change Your Password</div>
                            <div class="content">
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <div class="form-group">
                                            <label class="control-label">Old Password<star>*</star></label>
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtOldPassword" class="form-control" />
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label">
                                                New Password
                                                <star>*</star>
                                            </label>
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtNewPassword" class="form-control" />
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label">
                                                Confirm Password
                                                <star>*</star>
                                            </label>
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtConfirmPassword" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="footer text-center">
                                <div class="san-change-password">
                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_OnClick" OnClientClick="return CheckValidation();"  CssClass="btn btn-info btn-fill btn-wd san-change-password-button" Text="Save" runat="server" />                                    
                                    <button type="submit" class="btn btn-info btn-fill btn-wd san-change-password-button">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
