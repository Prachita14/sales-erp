<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MappingReport.aspx.cs" Inherits="VICCO.MappingReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="as" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12
        {
            padding-top: 10px;
        }
        #ContentPlaceHolder1_chklstEmployee
        {
            background-color:White;
        }
    </style>

    <script src="js/jquery-3.3.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        function addLoadingimg() {
            $(".loading").css("display", "block");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
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
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <%--<asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                    <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select0" runat="server" class="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="auto_select0_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                    <div class="input-group-btn">
                                        <button data-toggle="dropdown" class="btn btn-default dropdown-toggle col-md-12" type="button">
                                            Select Employee<span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" style="height:200px; overflow:auto;">
                                            <li>
                                                <asp:CheckBoxList ID="chklstEmployee" runat="server">
                                                </asp:CheckBoxList>
                                            </li>                                           
                                        </ul>
                                    </div>--%>
                                  
                                    </div>
                                <div class="col-md-2" runat="server" id="region_ddl">
                                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClientClick="addLoadingimg()" OnClick="btnSearch_Report" Width="80px" />
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="table-responsive">
                                    <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                        margin-top: 20px; color: #505b72;">
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
                                    
                                </div>
                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

