<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TemplateAboutUs.aspx.cs" Inherits="LocalLinkers.Admin.TemplateAboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

    <script>
       
        function EditTemplateAboutUs(btn) {
            var id = $(btn).attr('data-id');
            var templateid = $(btn).attr('data-templateid');
            var aboutus = $(btn).attr('data-aboutus');
            var tagline = $(btn).attr('data-tagline');
            var image = $(btn).attr('data-image');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkTemplate.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }

            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=txtAboutUs.ClientID%>').val(aboutus);
            $('#<%=txtTagline.ClientID%>').val(tagline);
            $('#<%=target.ClientID%>').attr('src', "/Admin/TemplateAboutUsImages/" + image);
            $('#<%=TemplateAboutUsForm.ClientID%>').css("display", "block");
            $('#<%=GridTemplateAboutUsPanel.ClientID%>').css("display", "none");

        }

        function ShowTemplates() {
            window.location.href = "/Admin/Template";
        }

        function PreviewImage(input, type) {
            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=target.ClientID%>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                }
            }

            function CheckValidation() {
                var AboutUs = $('#<%=txtAboutUs.ClientID%>').val();
                var Tagline= $('#<%=txtTagline.ClientID%>').val();
                var Image = $('#<%=target.ClientID%>').attr('src');
                var ErrorMessage = "";

                if (AboutUs == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter about us.";
                    }
                    $('#<%=txtAboutUs.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtAboutUs.ClientID%>').css("border-color", "#c2cad8");
                }

                <%--if (Tagline == "") {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please enter tagline.";
                    }
                    $('#<%=txtTagline.ClientID%>').css("border-color", "red");
                }
                else {
                    $('#<%=txtTagline.ClientID%>').css("border-color", "#c2cad8");
                }--%>

                if (Image.indexOf('no-image-icon.png') !== -1) {
                    if (ErrorMessage == "") {
                        ErrorMessage = "Please select image.";
                    }
                    $('#<%=fileImage.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=fileImage.ClientID%>').css("border-color", "#c2cad8");
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
            $('#<%=TemplateAboutUsForm.ClientID%>').css("display", "block");
            $('#<%=GridTemplateAboutUsPanel.ClientID%>').css("display", "none");
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

    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>About Us</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <h3 class="page-title">About Us
                       
        <small>About Us Listing</small>
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
    <div class="row TemplateAboutUsPanel" id="TemplateAboutUsForm" runat="server">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add About Us</span>
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
                                    About Us
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAboutUs" ClientIDMode="Static" TextMode="MultiLine" runat="server" class="form-control" MaxLength="700" />
                                </div>
                            </div>
                            <div id="divTagLine" runat="server" class="form-group">
                                <label class="control-label col-md-3">
                                    Tagline
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTagline" ClientIDMode="Static" TextMode="SingleLine" 
                                         runat="server" class="form-control" MaxLength="250" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Image        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fileImage" runat="server" onchange="PreviewImage(this,'About')" class="form-control" />
                                    <span class="help-block">Note: Image size should be 32 x 32 </span>
                                </div>
                                <div class="col-md-4">
                                    <asp:Image ID="target" runat="server" class="category_img_big" ImageUrl="/Admin/Images/no-image-icon.png" />
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
                                        <asp:Button ID="btnTemplateAboutUs" OnClick="btnTemplateAboutUs_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
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
    <div class="row GridTemplateAboutUs" id="GridTemplateAboutUsPanel" runat="server">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">About Us</span>
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
                                    <th>Image</th>
                                    <th>BusinessName</th>
                                    <th>AboutUs</th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptTemplate" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td>
                                                <img class="category_img" src="<%#Eval("Image").ToString()!="" && Eval("Image").ToString()!=null?DataAccess.Classes.ClsCommon.TemplateAboutUsImagesPath + Eval("Image"):"/Admin/Images/no-image-icon.png" %>" alt="<%#Eval("Image") %>" /></td>
                                            <td><%#Eval("TemplateName") %>  </td>
                                            <td><%#Eval("AboutUs") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %>  </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-templateid="<%#Eval("templateid") %>" data-aboutus="<%#Eval("AboutUs") %>" data-tagline="<%#Eval("tagline") %>" data-image='<%#Eval("Image") %>' data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditTemplateAboutUs(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="TemplateAboutUs" data-id="<%#Eval("Id") %>">
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
