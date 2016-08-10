<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LocalLinkers.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <link href="css/gsdk.css?random=12345" rel="stylesheet" />

    <script>
        function CheckValidation(type) {
            var PhoneNumber = $('#<%=txtPhoneNumber.ClientID%>').val();
            var Password = $('#<%=txtPassword.ClientID%>').val();
            var ForgetPhone = $('#<%=txtForgetPhoneNumber.ClientID%>').val();
            var OTPPhone = $('#<%=txtOTPPhoneNumber.ClientID%>').val();
            var OTP = $('#<%=txtOTP.ClientID%>').val();
            var ErrorMessage = "";
            if (type == "Login") {
                if (PhoneNumber == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter phone number.";
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
            }
            else if (type == "Forget") {
                if (ForgetPhone == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter phone number.";
                    }
                    $('#<%=txtForgetPhoneNumber.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtForgetPhoneNumber.ClientID%>').css("border-color", "#c2cad8");
                }

            }
            else if (type == "OTP") {
                if (OTPPhone == "") {
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
                        ErrorMessage = "Please enter otp.";
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

function ChangeDiv() {
    $('.forget-form').css("display", "block");
    $('.login-form').css("display", "none");
}
    </script>
    <style>
        input[type='checkbox'] {
            display: block !important;
        }

        .forget-page {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Login Form  ++++++++++++++++++++++++++++++++++++++++-->
    <div class="formfieldpage">
        <div class="wrapper wrapper-full-page login-form" id="divLogin" runat="server">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">

                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>

                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">Login To Locallinkers.com</div>
                                        <div class="content">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPhoneNumber" onkeypress="return isNumberKey(event)" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" class="form-control" MaxLength="20" />
                                            </div>
                                            <div class="form-group">
                                                <label class="checkbox" style="width: 190px; float: left;">
                                                    <asp:CheckBox ID="chkRemember" Text="" runat="server" CssClass="display_block" />
                                                    Keep me Logged In
                                                </label>
                                                <a class="fg_socialpassword" onclick="return ChangeDiv();" style="cursor: pointer;">Forgot Password </a>
                                            </div>
                                        </div>
                                        <div class="footer text-center">
                                            <asp:Button Text="Login" ID="btnLogin" OnClick="btnLogin_OnClick" OnClientClick="return CheckValidation('Login')" class="btn btn-fill btn-warning btn-wd" runat="server" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="wrapper wrapper-full-page forget-form" id="divForget" runat="server" style="display: none;">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">

                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>

                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">Forget Password</div>
                                        <div class="content">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtForgetPhoneNumber" onkeypress="return isNumberKey(event)" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                            </div>

                                        </div>
                                        <div class="footer text-center">
                                            <asp:Button Text="Submit" ID="btnForget" OnClick="btnForget_OnClick" OnClientClick="return CheckValidation('Forget')" class="btn btn-fill btn-warning btn-wd" runat="server" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="wrapper wrapper-full-page otp-form" id="divOTP" runat="server" style="display: none;">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">

                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>

                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">OTP(ONE TIME PASSWORD)</div>
                                        <div class="content">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtOTPPhoneNumber" onkeypress="return isNumberKey(event)" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" TextMode="Password" ID="txtOTP" onkeypress="return isNumberKey(event)" placeholder="OTP" class="form-control NoCopyPaste" MaxLength="12" />
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



    <script src="/js/get-shit-done.js"></script>
    <%--  <script src="js/gsdk-checkbox.js"></script>--%>
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
