<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true"
    CodeBehind="TargetReport.aspx.cs" Inherits="VICCO.Employee.TargetReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .total
        {
            margin: 40px;
            width: 30%;
            background-color: #e0e0e0;
        }
        
        .total tr td
        {
            padding: 10px;
            font-weight: bold;
        }
        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12
        {
            padding-top: 10px;
        }
        .collapse
        {
            height: 200px !important;
        }
        .alert-success
        {
            width: auto;
            margin-left: 5px;
            padding: 5px;
        }
        .close
        {
            float: none;
        }
        #material
        {
            width: auto;
            float: left;
            margin-bottom: 10px;
        }
    </style>
    <script type="text/javascript" src="../lib/jquery/jquery.js"></script>
    <script type="text/javascript">

        //        var selected_material_id = [];
        //        var selected_material_name = [];

        //        function AssignMaterialId(id, name) {
        //            selected_material_id.push(id);
        //            selected_material_name.push(name);
        //        }

        //        function MaterialChange() {

        //            var e = document.getElementById("ContentPlaceHolder1_auto_select1");
        //            var Material_name = e.options[e.selectedIndex].text;
        //            var Material_id = e.options[e.selectedIndex].value;

        //            if (Material_name == "") {
        //            }
        //            else {
        //                var materials = "<div id='material'><span class='alert alert-success'>" + Material_name + "<button type='button' id='" + Material_id + "' onclick='RemoveMaterialId(" + Material_id + ")' class='close' data-dismiss='alert' aria-hidden='true'>×</button></span></div>";
        //                $('#ContentPlaceHolder1_ShowSelectedMaterial').append(materials);

        //                selected_material_id.push(Material_id);
        //                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

        //                selected_material_name.push(Material_name);
        //                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
        //            }
        //        }

        //        Array.prototype.remove = function (x) {
        //            var i;
        //            for (i in this) {
        //                if (this[i].toString() == x.toString()) {
        //                    this.splice(i, 1)
        //                }
        //            }
        //        }

        //        function RemoveMaterialId(id) {
        //            {
        //                //                if (selected_material_id == "") {
        //                //                    AssignMaterialId($('#ContentPlaceHolder1_hdMaterialId').val(), $('#ContentPlaceHolder1_HiddenField1').val());
        //                //                }

        //                var e = document.getElementById("ContentPlaceHolder1_auto_select1");
        //                var Material_name = e.options[id].text;

        //                selected_material_id.remove(id);
        //                //selected_material_id.splice(selected_material_id.indexOf(id), 1);
        //                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

        //                selected_material_name.remove(Material_name);
        //                //selected_material_name.splice(selected_material_name.indexOf(Material_name), 1);
        //                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
        //            }
        //        }

        function addLoadingimg() {
            $(".loading").css("display", "block");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="EmployeeDashboard.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="TargetReport.aspx">Target Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Target Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <%--<asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Material Name"
                                        onchange="MaterialChange()">
                                    </asp:DropDownList>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                <div class="col-md-2" runat="server" id="region_ddl">
                                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRegion_Change">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3" runat="server" id="stockist_ddl">
                                    <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Super Stockist Name"
                                        AutoPostBack="true" OnSelectedIndexChanged="auto_select2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="District Name"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_Change">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select4" runat="server" class="form-control" data-placeholder="Distributor Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select5" runat="server" class="form-control" data-placeholder="Town Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date Required..."
                                        ControlToValidate="txtFromDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="To Date Required..."
                                        ControlToValidate="txttoDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClientClick="addLoadingimg()"
                                        OnClick="btnSearch_Report" Width="80px" />
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="table-responsive">
                                    <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                        margin-top: 20px; color: #505b72;">
                                        <strong>Oops! No record found..</strong>
                                    </div>
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                                        PageCountMode="Actual" Style="width: 100%; overflow: auto; height: 400px;" SizeToReportContent="true">
                                    </rsweb:ReportViewer>
                                    <div class="loading" style="display: none;">
                                        <center>
                                            <img src="images/loading.gif" />
                                        </center>
                                    </div>
                                    <div class="Extra-pagination" style="float: right;">
                                        <asp:HiddenField ID="isFirst" runat="server" />
                                        <asp:HiddenField ID="TotalPages" runat="server" />
                                        <asp:Label ID="lblPageNo" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblTotalPage" runat="server" ></asp:Label>
                                        <asp:Button ID="btnPrivious" runat="server" Text="Privious" CssClass="btn btn-default" Visible="false"
                                            OnClick="btnPriviousClick" Width="80px" />
                                        <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-default" OnClick="btnNextClick" Visible="false"
                                            Width="80px" />
                                    </div>
                                </div>
                                <!-- table-responsive -->
                                <%--</ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <div class="loading">
                                        <center>
                                            <img src="images/loading.gif" />
                                        </center>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                            </div>
                        </div>
                        <!-- panel -->
                        <!-- col-md-6 -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
