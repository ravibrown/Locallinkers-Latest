<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CouponConfirmation.aspx.cs" Inherits="LocalLinkers.CouponConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <script>
        function CheckValidation() {
            var CouponCode = $('#<%=txtCouponCode.ClientID%>').val();
            var ErrorMessage = "";
            if (CouponCode == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter coupon code.";
                }
                $('#<%=txtCouponCode.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtCouponCode.ClientID%>').css("border-color", "#c2cad8");
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

        .forget-page {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--+++++++++++++++++++++++++++++++++++++++++ Start Login Form  ++++++++++++++++++++++++++++++++++++++++-->
    <div class="formfieldpage">
        <div class="wrapper wrapper-full-page login-form">
            <div class="full-page login-page" data-color="orange" data-image="images/full-screen-image-1.jpg">

                <!--   you can change the color of the filter page using: data-color="blue | azure | green | orange | red | purple" -->
                <div class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                                <div>

                                    <!--   if you want to have the card without animation please remove the ".card-hidden" class   -->
                                    <div class="card card-hidden">
                                        <div class="header text-center">Confirm Coupon Code </div>
                                        <div class="content">
                                            <div id="divLogin" runat="server">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtPhoneNumber" onkeypress="return isNumberKey(event)" placeholder="Phone Number" class="form-control NoCopyPaste" MaxLength="12" />
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" class="form-control" MaxLength="20" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtCouponCode" placeholder="Coupon Code" class="form-control" MaxLength="7" />
                                            </div>
                                        </div>
                                        <div class="footer text-center">
                                            <asp:Button Text="Submit" ID="btnCouponCode" OnClick="btnCouponCode_OnClick" OnClientClick="return CheckValidation()" class="btn btn-fill btn-warning btn-wd" runat="server" />
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


<%--    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js"></script>--%>
    <%--  <script src="js/gsdk-checkbox.js"></script>--%>
    <script src="js/light-bootstrap-dashboard.js"></script>

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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
