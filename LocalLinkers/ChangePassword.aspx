<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LocalLinkers.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Local Linkers</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body class="login">
    <form id="form1" runat="server">
        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="index.html">
                <img src="assets/pages/img/login/logo.png" alt="" />
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">

            <!-- BEGIN FORGOT PASSWORD FORM -->
            <div class="login-form">
                <div class="alert alert-danger hide" id="alertDanger" runat="server">
                    <asp:Label ID="lblErrorMsg" Text="" runat="server" />
                </div>
                <h3 class="font-green">Change password</h3>
                <p>Please enter your new password.</p>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" autocomplete="off" placeholder="Password" />

                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" autocomplete="off" placeholder="Confirm Password" />
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnChangePassword" OnClick="btnChangePassword_OnClick" OnClientClick="return CheckValidation()" Text="Submit" CssClass="btn btn-success uppercase pull-right" runat="server" />

                </div>
            </div>

        </div>
        <div class="copyright">2016 © Desgined By Hashbrown. </div>
        <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="assets/pages/scripts/login.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->
        <script>
            function CheckValidation() {
                var password = $('#<%=txtPassword.ClientID%>').val();
                var confirmpassword = $('#<%=txtConfirmPassword.ClientID%>').val();
                var ErrorMessage = "";

                if (password == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter password.";
                    }
                    $('#<%=txtPassword.ClientID%>').css("border-color", "red");
                }
                else if (confirmpassword == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter confirm password.";
                    }
                    $('#<%=txtConfirmPassword.ClientID%>').css("border-color", "red");
                }
                else if (password != confirmpassword) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Password didn't matched with confirm password.";
                    }
                    $('#<%=txtPassword.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtPassword.ClientID%>').css("border-color", "#c2cad8");
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
    </form>
</body>
</html>
