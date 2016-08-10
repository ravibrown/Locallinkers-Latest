<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="HomeSlider.aspx.cs" Inherits="LocalLinkers.Admin.HomeSlider" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditHomeSlider(btn) {
            var id = $(btn).attr('data-id');
            var image = $(btn).attr('data-image');
            var title = $(btn).attr('data-title');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            if (isapprovedbyadmin == "True") {
                $('#<%=chkHomeSlider.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');
            }
            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=txtTitle.ClientID%>').val(title);
            $('#<%=target.ClientID%>').attr('src', "/Admin/HomeSliderImages/" + image);
            ShowPanel('HomeSlider');
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
                $('#<%=chkHomeSlider.ClientID%>').prop("checked", false);
                $('.checker span').removeClass('checked');
                $('#<%=hdnId.ClientID%>').val('');
                $('#<%=txtTitle.ClientID%>').val('');
                $('#<%=target.ClientID%>').attr('src', "/Admin/Images/no-image-icon.png");
                $('.GridHomeSlider').addClass('hide');
                $('.HomeSliderPanel').removeClass('hide');
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
    <asp:HiddenField runat="server" ID="hdnId" />
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Home Slider Listing</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <h3 class="page-title">Home Slider Listing
                       
        <small>All Home Slider Listing</small>
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
    <div class="row GridHomeSlider">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Home Slider Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ResetAll()">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Home Slider</label></a>
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
                                    <th>Title</th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptHomeSlider" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td>
                                                <img class="category_img" src="<%#Eval("Image").ToString()!="" && Eval("Image").ToString()!=null?DataAccess.Classes.ClsCommon.HomeSliderImagesPath + Eval("Image"):"/Admin/Images/no-image-icon.png" %>" alt="<%#Eval("Image") %>" /></td>
                                            <td><%#Eval("Title") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %>  </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id")%>"  data-image="<%#Eval("Image") %>" data-title="<%#Eval("Title") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditHomeSlider(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="HomeSlider" data-id="<%#Eval("Id") %>">
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
    <div class="row HomeSliderPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Home Slider</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridHomeSlider')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Home Sliders</label></a>
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
                                    <asp:CheckBox ID="chkHomeSlider" Text="" runat="server" />
                                </div>

                            </div>

                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnHomeSlider" OnClick="btnHomeSlider_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
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

    
    <!-- END VALIDATION STATES-->




</asp:Content>
