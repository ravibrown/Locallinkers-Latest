<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="LocalLinkers.Admin.Template" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditTemplate(btn) {
            var id = $(btn).attr('data-id');
            var image = $(btn).attr('data-iconimage');
            var templateid = $(btn).attr('data-templateid');
            var title = $(btn).attr('data-title');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            if (isapprovedbyadmin == "True") {
                $('#<%=chkTemplate.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');
            }
            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=hdnTemplateId.ClientID%>').val(templateid);
            $('#<%=txtTitle.ClientID%>').val(title);
            $('#<%=target.ClientID%>').attr('src', "/Admin/TemplateImages/" + image);
            ShowPanel('Template');
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

            function ResetAll() {
                $('#<%=chkTemplate.ClientID%>').prop("checked", false);
                $('.checker span').removeClass('checked');
                $('#<%=hdnTemplateId.ClientID%>').val('');
                $('#<%=hdnId.ClientID%>').val('');
                $('#<%=txtTitle.ClientID%>').val('');
                $('#<%=target.ClientID%>').attr('src', "/Admin/Images/no-image-icon.png");
                $('.GridTemplate').addClass('hide');
                $('.TemplatePanel').addClass('hide');
                $('.SelectTemplatePanel').removeClass('hide');
            }

            function SelectTemplate(id) {
                $('#<%=hdnTemplateId.ClientID%>').val(id);
                $('.GridTemplate').addClass('hide');
                $('.TemplatePanel').removeClass('hide');
                $('.SelectTemplatePanel').addClass('hide');
            }

            function ResetTemplate() {
                $('#<%=hdnTemplateId.ClientID%>').val('');
                $('.GridTemplate').addClass('hide');
                $('.TemplatePanel').addClass('hide');
                $('.SelectTemplatePanel').removeClass('hide');
            }

            function CheckValidation() {
                var Title = $('#<%=txtTitle.ClientID%>').val();
        var Image = $('#<%=target.ClientID%>').attr('src');
        var ErrorMessage = "";

        if (Title == "") {
            if (ErrorMessage == "") {
                ErrorMessage = "Please enter title.";
            }
            $('#<%=txtTitle.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtTitle.ClientID%>').css("border-color", "#c2cad8");
            }

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
        }

        function RedirectToTemplate(btn) {
            var id = $(btn).attr('data-id');
            var templateid = $(btn).attr('data-templateid');
            if (parseInt(templateid) == 1) {
                window.location.href = "/Template/Ladybird/Ladybird?id=" + id
            }
            else if (parseInt(templateid) == 2) {
                window.location.href = "/Template/Lambkin/Lambkin?id=" + id
            }
            else if (parseInt(templateid) == 3) {
                window.location.href = "/Template/Paramour/Paramour?id=" + id
            }
            else if (parseInt(templateid) == 4) {
                window.location.href = "/Template/Honeydew/Honeydew?id=" + id
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

        .Tempalte_img {
            margin: 10px;
        }

            .Tempalte_img img {
                border: 2px solid black;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnTemplateId" />
    <asp:HiddenField runat="server" ID="hdnId" />
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Template Listing</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <div style="width: 100%">
        <h3 class="page-title" style="width: 85%; float: left;">Template Listing
                       
        <small>All Template Listing</small>
        </h3>
        <h3 class="page-title" style="width: 15%; float: right;">Total Records : <strong><%=TotalRecords %></strong>
        </h3>
    </div>
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
    <div class="row GridTemplate">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Template Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ResetAll()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Template</label></a>
                        </div>

                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>Image </th>
                                    <th>Business Name </th>
                                    <th>AboutUs </th>
                                    <th>Slider </th>
                                    <th>Gallery </th>
                                    <th>Service </th>
                                    <th>ContactUs </th>
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
                                                <img class="category_img" src="<%#Eval("IconImage").ToString()!="" && Eval("IconImage").ToString()!=null?DataAccess.Classes.ClsCommon.TemplateImagesPath + Eval("IconImage"):"/Admin/Images/no-image-icon.png" %>" alt="<%#Eval("IconImage") %>" /></td>
                                            <td><%#Eval("Title") %>  </td>
                                            <td><a class="toggle" href="/Admin/TemplateAboutUs?id=<%#Eval("Id")%>">
                                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                    About Us</label></a></td>
                                            <td><a class="toggle" href="/Admin/TemplateSlider?id=<%#Eval("Id")%>">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Slider</label></a> </td>
                                            <td><a class="toggle" href="/Admin/TemplateGallery?id=<%#Eval("Id")%>">
                                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                    Galllery</label></a> </td>
                                            <td><a class="toggle" href="/Admin/TemplateServices?id=<%#Eval("Id")%>">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Services</label></a> </td>
                                            <td><a class="toggle" href="/Admin/TemplateContact?id=<%#Eval("Id")%>">
                                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                    Contact Us</label></a> </td>
                                            <td><%#Eval("IsApprovedByAdmin") %>  </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id")%>" data-templateid="<%#Eval("TemplateId") %>" data-iconimage="<%#Eval("IconImage") %>" data-title="<%#Eval("Title") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditTemplate(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="Template" data-id="<%#Eval("Id") %>">
                                                    <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                                        Delete</label></a>
                                                <a class="toggle" data-id="<%#Eval("Id")%>" data-templateid="<%#Eval("TemplateId") %>" onclick="RedirectToTemplate(this)">
                                                    <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                        Preview</label></a>
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
    <div class="row TemplatePanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Template</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ResetTemplate()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Reset Template</label></a>
                            <a onclick="ShowPanel('GridTemplate')">
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
                                    Title
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" MaxLength="40" />
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
                                        <asp:Button ID="btnTemplate" OnClick="btnTemplate_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
                                        <button type="button" class="btn grey-salsa btn-outline">Cancel</button>
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

    <div class="row SelectTemplatePanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Select Template</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridTemplate')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Templates</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->



                    <div class="col-md-3 Tempalte_img">
                        <img src="/Admin/Images/bg1.jpg" alt="Tempalte1" onclick="SelectTemplate(1)" /><br />
                        <h1>LadyBird</h1>

                    </div>
                    <div class="col-md-3 Tempalte_img">
                        <img src="/Admin/Images/bg2.jpg" alt="Tempalte2" onclick="SelectTemplate(2)" /><br />
                        <h1>Lambkin</h1>
                    </div>
                    <div class="col-md-3 Tempalte_img">
                        <img src="/Admin/Images/bg3.jpg" alt="Tempalte3" onclick="SelectTemplate(3)" /><br />
                        <h1>Paramour</h1>
                    </div>
                    <div class="col-md-3 Tempalte_img">

                        <img src="/Admin/Images/bg1.jpg" alt="Tempalte4" onclick="SelectTemplate(4)" /><br />
                        <h1>HoneyDew</h1>
                    </div>


                </div>

            </div>
            <!-- END FORM-->
        </div>
    </div>
    <!-- END VALIDATION STATES-->




</asp:Content>
