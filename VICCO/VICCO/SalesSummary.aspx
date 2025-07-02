<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SalesSummary.aspx.cs" Inherits="VICCO.SalesSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12
        {
            padding-top: 10px;
        }
    </style>
     
    <script type="text/javascript">
        function addLoadingimg() {
            $(".loading").css("display", "block");
        }

        function WarningOk() {
            alertify.error('No record found...');
        } 
    </script>
    <script type="text/javascript">

        var selected_material_id = [];
        var selected_material_name = [];

        function AssignMaterialId(id, name) {
            selected_material_id.push(id);
            selected_material_name.push(name);
        }

        function MaterialChange() {

            var e = document.getElementById("ContentPlaceHolder1_auto_select6");
            var Material_name = e.options[e.selectedIndex].text;
            var Material_id = e.options[e.selectedIndex].value;

            if (Material_name == "") {
            }
            else {
                var materials = "<div id='material'><span class='alert alert-success'>" + Material_name + "<button type='button' id='" + Material_id + "' onclick='RemoveMaterialId(" + Material_id + ")' class='close' data-dismiss='alert' aria-hidden='true'>×</button></span></div>";
                $('#ContentPlaceHolder1_ShowSelectedMaterial').append(materials);

                selected_material_id.push(Material_id);
                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

                selected_material_name.push(Material_name);
                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
            }
        }

        Array.prototype.remove = function (x) {
            var i;
            for (i in this) {
                if (this[i].toString() == x.toString()) {
                    this.splice(i, 1)
                }
            }
        }

        function RemoveMaterialId(id) {
            {
                var e = document.getElementById("ContentPlaceHolder1_auto_select6");
                var Material_name = e.options[id].text;

                selected_material_id.remove(id);
                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

                selected_material_name.remove(Material_name);
                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
            }
        }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="SalesSummary.aspx">Sales Summary</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Sales Summary</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlTypeTextChange">
                                                <asp:ListItem>All India</asp:ListItem>
                                                <asp:ListItem>State Wise</asp:ListItem>
                                                <asp:ListItem>Stockist Wise</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlRegion_Change">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="auto_select7" runat="server" class="form-control" data-placeholder="Material Group"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_Change">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="auto_select6" runat="server" class="form-control" data-placeholder="Material Name"
                                                onchange="MaterialChange()">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Super Stockist Name"
                                                AutoPostBack="true" OnSelectedIndexChanged="auto_select1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="District Name"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_Change">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Distributor Name">
                                            </asp:DropDownList>
                                          <%--  <select id="select2" class="form-control" runat="server" data-placeholder="DISTRIBUTOR NAME" autocomplete="off" usebuttons="true"
                                            autocorrect="off"
                                            autocapitalize="none" multiple="true">
                                        </select>--%>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="auto_select4" runat="server" class="form-control" data-placeholder="Town Name">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="auto_select5" runat="server" class="form-control" data-placeholder="Sales Officer">
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
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                                OnClientClick="addLoadingimg()" OnClick="SelectedIndexChange" Width="80px" />
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <br />
                                        <br />
                                        <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                                color: #505b72;">
                                                <strong>Oops! No record found..</strong>
                                            </div>
                                        
                                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                                                PageCountMode="Actual" Style="overflow: auto;" SizeToReportContent="true">
                                            </rsweb:ReportViewer>
                                        
                                        <div class="loading" style="display: none;">
                                            <center>
                                                <img src="images/loading.gif" />
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                    <ProgressTemplate>
                                        <div class="loading">
                                            <center>
                                                <img src="../images/loading.gif" />
                                            </center>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
