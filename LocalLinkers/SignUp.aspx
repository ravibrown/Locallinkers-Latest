<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LocalLinkers.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <script>
        function CheckValidation(type) {
            var PhoneNumber = $('#<%=txtPhoneNumber.ClientID%>').val();
            var Password = $('#<%=txtPassword.ClientID%>').val();
            var ConfirmPassword = $('#<%=txtConfirmPassword.ClientID%>').val();
            var Email = $('#<%=txtEmail.ClientID%>').val();
            var OTPPhoneNumber = $('#<%=txtOTPPhoneNumber.ClientID%>').val();
            var OTP = $('#<%=txtOTP.ClientID%>').val();
            var ErrorMessage = "";
            if (type == "Register") {

                if (PhoneNumber == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter phone number.";
                    }
                    $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "#c2cad8");
                }

                if (PhoneNumber.length < 10) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter at least 10 digit phone number.";
                    }
                    $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtPhoneNumber.ClientID%>').css("border-color", "#c2cad8");
                }

                if (Password == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter password.";
                    }
                    $('#<%=txtPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (ConfirmPassword == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter confirm password.";
                    }
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (ConfirmPassword != Password) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Password doesn't matched with confirm password.";
                    }
                    $('#<%=txtPassword.ClientID%>').css("border-color", "red");
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "#c2cad8");
                    $('#<%=txtPassword.ClientID%>').css("border-color", "#c2cad8");
                }

                if (Email != "" && !IsEmail(Email)) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Email is not valid.";
                    }
                    $('#<%=txtEmail.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtEmail.ClientID%>').css("border-color", "#c2cad8");
                }

                if ($('#<%=chkTermsAndCondition.ClientID%>').prop("checked") == false) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please check terms and condition.";
                    }
                    $('#<%=chkTermsAndCondition.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=chkTermsAndCondition.ClientID%>').css("border-color", "#c2cad8");
                }
            }
            else if (type = "OTP") {
                if (OTPPhoneNumber == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter phone number.";
                    }
                    $('#<%=txtOTPPhoneNumber.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtOTPPhoneNumber.ClientID%>').css("border-color", "#c2cad8");
                }

                if (OTP == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter one time password.";
                    }
                    $('#<%=txtOTP.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtOTP.ClientID%>').css("border-color", "#c2cad8");
                }

            }

        if (ErrorMessage != "") {
            alert(ErrorMessage);
            return false;
        }
        else {
            return true;
        }
    }

    </script>
    <style>
        input[type='checkbox'] {
            display: block !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Login Form  ++++++++++++++++++++++++++++++++++++++++-->

    <div class="formfieldpage">
        <div class="wrapper wrapper-full-page register-page" id="RegisterPanel" runat="server">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">
                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>
                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">Welcome to Locallinkers.com</div>
                                        <div class="content">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPhoneNumber" onkeypress="return isNumberKey(event)" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" class="form-control" MaxLength="20" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" placeholder="Confirm Password" class="form-control" MaxLength="20" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" placeholder="Email(optional)" class="form-control" MaxLength="50" />
                                            </div>
                                            <div class="form-group">
                                                <label class="checkbox">
                                                    <asp:CheckBox ID="chkTermsAndCondition" CssClass="display_block" Text="" runat="server" />
                                                    I agree to terms & conditions
                                                </label>
                                            </div>
                                        </div>
                                        <div class="footer text-center">
                                            <asp:Button Text="Register" ID="btnRegister" OnClick="btnRegister_OnClick" OnClientClick="return CheckValidation('Register')" class="btn btn-fill btn-warning btn-wd" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="wrapper wrapper-full-page otp-page" id="OTPPanel" runat="server">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">

                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>
                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">Enter Your OTP</div>
                                        <div class="content">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtOTPPhoneNumber" onkeypress="return isNumberKey(event)" ReadOnly="true" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtOTP" TextMode="Password" placeholder="One Time Password(OTP)" class="form-control" MaxLength="6" />
                                            </div>

                                        </div>
                                        <div class="footer text-center">
                                            <asp:Button Text="Submit" ID="btnOTP" OnClick="btnOTP_OnClick" OnClientClick="return CheckValidation('OTP')" class="btn btn-fill btn-warning btn-wd" runat="server" />
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

    <!--+++++++++++++++++++++++++++++++++++++++++ End Login Form  ++++++++++++++++++++++++++++++++++++++++-->


   
    <script src="/js/light-bootstrap-dashboard.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            lbd.checkFullPageBackgroundImage();

            setTimeout(function () {
                // after 1000 ms we add the class animated to the login/register card
                $('.card').removeClass('card-hidden');
            }, 700)

        });
    </script>

</asp:Content>
