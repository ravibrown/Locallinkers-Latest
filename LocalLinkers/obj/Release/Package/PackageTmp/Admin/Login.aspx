<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LocalLinkers.Admin.Login" %>

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
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="../assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/pages/css/login-5.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body class="login">
    <form id="form1" runat="server">
        <!-- BEGIN : LOGIN PAGE 5-1 -->
        <div class="user-login-5">
            <div class="row bs-reset">
                <div class="col-md-6 bs-reset">
                    <div class="login-bg" style="background-image: url(../assets/pages/img/login/bg1.jpg)">
                        <img class="login-logo" src="../assets/pages/img/login/logo.png" />
                    </div>
                </div>
                <div class="col-md-6 login-container bs-reset">
                    <div class="login-content">
                        <h1>Local Linkers Admin Login</h1>
                        <p>Lorem ipsum dolor sit amet, coectetuer adipiscing elit sed diam nonummy et nibh euismod aliquam erat volutpat. Lorem ipsum dolor sit amet, coectetuer adipiscing. </p>
                        <div class="login-form">
                            <div class="alert alert-danger hide" id="alertDanger" runat="server">
                                <asp:Label ID="lblErrorMsg" Text="" runat="server" />
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control form-control-solid placeholder-no-fix form-group" autocomplete="off" placeholder="Username" />
                                </div>
                                <div class="col-xs-6">
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control form-control-solid placeholder-no-fix form-group" autocomplete="off" placeholder="Password" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="rem-password">
                                        <p>
                                            Remember Me
                                            <asp:CheckBox ID="chkRember" class="rem-checkbox" runat="server" />
                                        </p>
                                    </div>
                                </div>
                                <div class="col-sm-8 text-right">
                                    <div class="forgot-password">
                                        <a href="javascript:;" id="forget-password" class="forget-password">Forgot Password?</a>
                                    </div>
                                    <asp:Button ID="btnLogin" OnClick="btnLogin_OnClick" OnClientClick="return CheckValidation('Login')" Text="Sign In" CssClass="btn blue " runat="server" />
                                </div>
                            </div>
                        </div>

                        <!-- BEGIN FORGOT PASSWORD FORM -->
                        <div class="forget-form" style="display:none;">
                            <h3 class="font-green">Forgot Password ?</h3>
                            <p>Enter your e-mail address below to reset your password. </p>
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" class="form-control placeholder-no-fix form-group" autocomplete="off" placeholder="Email" />
                            </div>
                            <div class="form-actions">
                                <button type="button" id="back-btn" class="btn grey btn-default">Back</button>
                                <asp:Button ID="btnForget" OnClick="btnForget_OnClick" OnClientClick="return CheckValidation('Forget')" Text="Submit" CssClass="btn blue btn-success uppercase pull-right" runat="server" />
                                <%--<button type="submit" class="btn blue btn-success uppercase pull-right">Submit</button>--%>
                            </div>
                        </div>
                        <!-- END FORGOT PASSWORD FORM -->
                    </div>
                    <div class="login-footer">
                        <div class="row bs-reset">
                            <div class="col-xs-5 bs-reset">
                                <ul class="login-social">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-facebook"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-twitter"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-dribbble"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-xs-7 bs-reset">
                                <div class="login-copyright text-right">
                                    <p>Copyright &copy; Local Linkers 2016</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END : LOGIN PAGE 5-1 -->
        <!--[if lt IE 9]>
<script src="../../assets/global/plugins/respond.min.js"></script>
<script src="../../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/login-5.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->
        <script>

            $(document).ready(function () {
                $(".login-form").keypress(function (e) {
                    if (e.keyCode === 13) {
                        $('#<%=btnLogin.ClientID%>').trigger("click")
                        
                    }
                });

                $(".forget-form").keypress(function (e) {
                    if (e.keyCode === 13) {
                        $('#<%=btnForget.ClientID%>').trigger("click")

                    }
                });
            });
            function CheckValidation(type) {
                var username = $('#<%=txtUserName.ClientID%>').val();
                var password = $('#<%=txtPassword.ClientID%>').val();
                var email = $('#<%=txtEmail.ClientID%>').val();
                var ErrorMessage = "";
                if (type == "Login") {
                    if (username == "") {
                        if (ErrorMessage == "") {
                            ErrorMessage = "Please enter user name.";
                        }
                        $('#<%=txtUserName.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtUserName.ClientID%>').css("border-color", "#c2cad8");
                    }


                    if (password == "") {
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
                    if (email == "") {
                        if (ErrorMessage == "") {
                            ErrorMessage = "Please enter email.";
                        }
                        $('#<%=txtEmail.ClientID%>').css("border-color", "red");
                    }
                    else if (!IsEmail) {
                        if (ErrorMessage == "") {
                            ErrorMessage = "Please enter valid email.";
                        }
                        $('#<%=txtEmail.ClientID%>').css("border-color", "red");

                    }
                    else {
                        $('#<%=txtEmail.ClientID%>').css("border-color", "#c2cad8");
                    }
                  
                }
                debugger;
                if (ErrorMessage != "") {
                    $('#<%=lblErrorMsg.ClientID%>').text(ErrorMessage);
                    $('#<%=alertDanger.ClientID%>').removeClass('hide');
                    return false;
                }
                else {
                    return true;
                }
            }

    function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }

        </script>
    </form>
</body>
</html>
