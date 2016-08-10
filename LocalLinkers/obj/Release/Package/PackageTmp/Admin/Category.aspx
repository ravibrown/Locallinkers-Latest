<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LocalLinkers.Admin.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditCategory(btn) {
            var id = $(btn).attr('data-id');
            var name = $(btn).attr('data-name');
            var description = $(btn).attr('data-description');
            var categoryid = $(btn).attr('data-categoryid');
            var categoryname = $(btn).attr('data-categoryname');
            var buttontitle = $(btn).attr('data-buttontitle');
            var usermessage = $(btn).attr('data-usermessage');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');
            var image = $(btn).attr('data-image');
            if (categoryname == "") {
                ShowPanel('Category');
                $('#<%=txtname.ClientID%>').val(name);
                $('#<%=txtDescription.ClientID%>').val(description);
                $('#<%=txtUserMessage.ClientID%>').val(usermessage);
                $('#<%=txtButtonTitle.ClientID%>').val(buttontitle);
                if (isapprovedbyadmin == "True") {
                    $('#<%=chkCategory.ClientID%>').prop("checked", true);
                    $('.checker span').addClass('checked');

                }
                $('#<%=target.ClientID%>').attr('src', "/Admin/CategoryImages/" + image);
                $('#<%=hdnCategoryId.ClientID%>').val(id);
            }
            else {
                ShowPanel('SubCategory');
                $('#<%=txtSubCategoryName.ClientID%>').val(name);
                $('#<%=txtSubCategoryDecs.ClientID%>').val(description);
                if (isapprovedbyadmin == "True") {
                    $('#<%=chkSubCategory.ClientID%>').prop("checked", true);
                    $('.checker span').addClass('checked');

                }
                $('#<%=hdnSubCategoryId.ClientID%>').val(id);
                $('#<%=drpCategory.ClientID%>').val(categoryid);
            }
        }

        function DeleteMsg(result) {
            $('#<%=lblSuccessMsg.ClientID%>').text(result.d);
            $('#<%=alertSuccess.ClientID%>').removeClass('hide');
        }




        function PreviewImage(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=target.ClientID%>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                }
            }

            function ShowSubcategory() {
                window.location.href = "/Admin/Category?type=sub";
            }

            function CheckValidation(type) {
                var ErrorMessage = "";
                if (type == "Category") {
                    var name = $('#<%=txtname.ClientID%>').val();
                    var desc = $('#<%=txtDescription.ClientID%>').val();
                    var buttontitle = $('#<%=txtButtonTitle.ClientID%>').val();
                    var usermessage = $('#<%=txtUserMessage.ClientID%>').val();
                    if (name == "") {
                        ErrorMessage = "Please add name.";
                        $('#<%=txtname.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtname.ClientID%>').css("border-color", "#c2cad8");
                    }

                    if (name.indexOf('-') > 0 || name.indexOf('&') > 0 || name.indexOf('/') > 0 || name.indexOf('|') > 0 || name.indexOf(';') > 0 || name.indexOf('<') > 0 || name.indexOf('>') > 0 || name.indexOf('+') > 0) {
                        if (ErrorMessage == "") {
                            ErrorMessage = "This type of (-,&,/,|,;,<,>,+) special characters is not allowed in title field.";
                        }
                        $('#<%=txtname.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtname.ClientID%>').css("border-color", "#c2cad8");
                    }

                    if (desc == "") {
                        ErrorMessage = "Please add description.";
                        $('#<%=txtDescription.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtDescription.ClientID%>').css("border-color", "#c2cad8");
                    }

                    if (buttontitle == "") {
                        ErrorMessage = "Please add button title.";
                        $('#<%=txtButtonTitle.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtButtonTitle.ClientID%>').css("border-color", "#c2cad8");
                    }

                    if (usermessage == "") {
                        ErrorMessage = "Please add message.";
                        $('#<%=txtUserMessage.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtUserMessage.ClientID%>').css("border-color", "#c2cad8");
                    }


                }
                else if (type == "SubCategory") {
                    var name = $('#<%=txtSubCategoryName.ClientID%>').val();
                    var desc = $('#<%=txtSubCategoryDecs.ClientID%>').val();
                    var category = $('#<%=drpCategory.ClientID%> option:selected').val();

                    if (name == "") {
                        ErrorMessage = "Please add name.";
                        $('#<%=txtSubCategoryName.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtSubCategoryName.ClientID%>').css("border-color", "#c2cad8");
                    }
                    if (desc == "") {
                        ErrorMessage = "Please add description.";
                        $('#<%=txtSubCategoryDecs.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=txtSubCategoryDecs.ClientID%>').css("border-color", "#c2cad8");
                    }
                    if (category == "0") {
                        ErrorMessage = "Please select category.";
                        $('#<%=drpCategory.ClientID%>').css("border-color", "red");
                    }
                    else {
                        $('#<%=drpCategory.ClientID%>').css("border-color", "#c2cad8");
                    }

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
    <asp:HiddenField runat="server" ID="hdnCategoryId" />
    <asp:HiddenField runat="server" ID="hdnSubCategoryId" />
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="index.html">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Categories</span>
            </li>
        </ul>
    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <div style="width: 100%">
        <h3 class="page-title" style="width: 85%; float: left;">Categories
                       
        <small>All Categories</small>
        </h3>
        <h3 class="page-title" style="width: 15%; float: right;">Total Records : <strong><%=TotalRecords %></strong>
        </h3>
    </div>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <!-- BEGIN DASHBOARD STATS 1-->

    <div class="clearfix"></div>
    <div class="alert alert-danger hide" id="alertDanger" runat="server">
        <%--<button class="close" data-close="alert"></button>--%>
        <asp:Label ID="lblErrorMsg" Text="" runat="server" />

    </div>
    <div class="alert alert-success hide" id="alertSuccess" runat="server">
        <%-- <button class="close" data-close="alert"></button>--%>
        <asp:Label ID="lblSuccessMsg" Text="" runat="server" />
    </div>
    <div class="row GridCategories">
        <div class="col-md-12">
            <%-- <div class="note note-info">
                <p>NOTE: The below datatable is not connected to a real database so the filter and sorting is just simulated for demo purposes only. </p>
            </div>--%>

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Categories Listing </span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a class="toggle" onclick="ShowPanel('Category')">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                    Add New Category</label></a>
                            <a class="toggle" onclick="ShowPanel('SubCategory')">
                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm">
                                    Add New SubCategory</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th id="thImage" runat="server">Image</th>
                                    <th id="thCategoryName" runat="server">CategoryName </th>
                                    <th>Name </th>
                                    <th>Description </th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_OnItemDataBound">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td id="tdImage" runat="server">
                                                <img class="category_img" src="<%#Eval("Image").ToString()!="" && Eval("Image").ToString()!=null?DataAccess.Classes.ClsCommon.CategoryImagesPath + Eval("Image"):"/Admin/Images/no-image-icon.png" %>" alt="<%#Eval("Image") %>" />
                                            </td>
                                            <td id="tdCategoryName" runat="server"><%#Eval("CategoryName") %> </td>
                                            <td><%#Eval("Name") %>  </td>
                                            <td><%#Eval("Description") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %> </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-image="<%#Eval("Image") %>" data-categoryid="<%#Eval("CategoryId") %>" data-name="<%#Eval("Name") %>" data-categoryname="<%#Eval("CategoryName") %>" data-description="<%#Eval("Description") %>" data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" data-usermessage="<%#Eval("UserMessage") %>" data-buttontitle="<%#Eval("ButtonTitle") %>" onclick="EditCategory(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>

                                                <a class="toggle delete" data-type="Category" data-id="<%#Eval("Id") %>" data-categoryname="<%#Eval("CategoryName") %>">
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
    <div class="row CategoryPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New Category</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowPanel('GridCategory')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Categories</label></a>
                            <a onclick="ShowPanel('SubCategory')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm">
                                    Add New Sub Category</label></a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->
                    <div id="form_sample_1" class="form-horizontal">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Name     
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtname" runat="server" class="form-control" MaxLength="40" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Button Title
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtButtonTitle" runat="server" class="form-control" MaxLength="100" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Message
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtUserMessage" runat="server" class="form-control" MaxLength="500" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Image        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fileCatgoryImage" runat="server" onchange="PreviewImage(this)" class="form-control" />
                                    <span class="help-block">Note: Icon size should be 32 x 32 </span>
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
                                    <asp:CheckBox ID="chkCategory" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnCategory" OnClick="btnCategory_Click" OnClientClick="return CheckValidation('Category')" Text="Submit" class="btn green" runat="server" />
                                    <button type="button" class="btn grey-salsa btn-outline">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END VALIDATION STATES-->
        </div>
    </div>
    <div class="row SubCategoryPanel hide">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add New SubCategory</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowSubcategory()">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Sub Categories</label>
                            </a>
                            <a onclick="ShowPanel('Category')">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm">
                                    Add New Category</label>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <!-- BEGIN FORM-->
                    <div id="form_sample_2" class="form-horizontal">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Category     
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drpCategory" runat="server" class="form-control">
                                        <asp:ListItem Text="Select" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Name     
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSubCategoryName" runat="server" class="form-control" MaxLength="40" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSubCategoryDecs" runat="server" class="form-control" MaxLength="140" />
                                </div>
                            </div>
                            <div class="form-group hide">
                                <label class="control-label col-md-3">
                                    Image        
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fileSubCategoryImage" runat="server" class="form-control" />
                                    <span class="help-block">Note: Icon size should be 32 x 32 </span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Active      
                                </label>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="chkSubCategory" Text="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSubCategory" OnClick="btnSubCategory_Click" OnClientClick="return CheckValidation('SubCategory');" Text="Submit" class="btn green" runat="server" />
                                    <button type="button" class="btn grey-salsa btn-outline">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END VALIDATION STATES-->
        </div>
    </div>
</asp:Content>

