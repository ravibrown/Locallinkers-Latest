<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TemplateServices.aspx.cs" Inherits="LocalLinkers.Admin.TemplateServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EditTemplateServices(btn) {
            var id = $(btn).attr('data-id');
            var templateid = $(btn).attr('data-templateid');
            var title = $(btn).attr('data-title');
            var description = $(btn).attr('data-description');
            var isapprovedbyadmin = $(btn).attr('data-isapprovedbyadmin');


            if (isapprovedbyadmin == "True") {
                $('#<%=chkTemplate.ClientID%>').prop("checked", true);
                $('.checker span').addClass('checked');

            }

            $('#<%=hdnId.ClientID%>').val(id);
            $('#<%=txtTitle.ClientID%>').val(title);
            $('#<%=txtDescription.ClientID%>').val(description);

        }

        function ShowTemplates() {
            window.location.href = "/Admin/Template";
        }



        function CheckValidation() {
            var Title = $('#<%=txtTitle.ClientID%>').val();
                var Description = $('#<%=txtDescription.ClientID%>').val();
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

            if (Description == "") {
                if (ErrorMessage == "") {
                    ErrorMessage = "Please enter description.";
                }
                $('#<%=txtDescription.ClientID%>').css("border-color", "red");
            }
            else {
                $('#<%=txtDescription.ClientID%>').css("border-color", "#c2cad8");
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
                <span>Services</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <h3 class="page-title">Services
                       
        <small>Services Listing</small>
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
    <div class="row TemplateServicesPanel" id="TemplateServicesForm" runat="server">
        <div class="col-md-12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet light portlet-fit portlet-form bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Add Services</span>
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
                                    Title
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" MaxLength="200" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Description
                                    <span class="required">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" MaxLength="1000" />
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
                                        <asp:Button ID="btnTemplateServices" OnClick="btnTemplateServices_Click" OnClientClick="return CheckValidation()" Text="Submit" class="btn green" runat="server" />
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
    <div class="row GridTemplateServices" id="GridTemplateServicesPanel" runat="server">
        <div class="col-md-12">

            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Services</span>
                    </div>
                    <div class="actions">
                        <%--<div class="btn-group btn-group-devided" data-toggle="buttons">
                            <a onclick="ShowTemplates();">
                                <label class="btn btn-transparent red btn-outline btn-circle btn-sm active">
                                    View All Templates</label></a>
                        </div>--%>
                    </div>
                </div>

                <div class="portlet-body">
                    <div class="table-container">
                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <thead>
                                <tr role="row" class="heading">
                                    <th>Sno. </th>
                                    <th>BusinessName</th>
                                    <th>Title</th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptTemplate" runat="server">
                                    <ItemTemplate>
                                        <tr role="row" class="filter" id="Row_<%#Eval("Id") %>">
                                            <td><%#Eval("SNO") %> </td>
                                            <td><%#Eval("TemplateName") %>  </td>
                                            <td><%#Eval("Title") %>  </td>
                                            <td><%#Eval("IsApprovedByAdmin") %>  </td>
                                            <td><a class="toggle" data-id="<%#Eval("Id") %>" data-templateid="<%#Eval("templateid") %>" data-title="<%#Eval("Title") %>" data-description='<%#Eval("Description") %>' data-isapprovedbyadmin="<%#Eval("IsApprovedByAdmin") %>" onclick="EditTemplateServices(this)">
                                                <label class="btn btn-transparent blue btn-outline btn-circle btn-sm active">
                                                    Edit</label></a>
                                                <a class="toggle delete" data-type="TemplateServices" data-id="<%#Eval("Id") %>">
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
