<%@ Page Title="" Language="C#" MasterPageFile="~/office.Master" AutoEventWireup="true"
    CodeBehind="SecondaryCumulativeReport.aspx.cs" Inherits="VICCO.SecondaryCumulativeReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="SecondaryCumulativeReport.aspx">Secondary Cumulative Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">Secondary Cumulative Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-3">
                                <asp:DropDownList ID="auto_select4" runat="server" class="form-control" data-placeholder="Material Name">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <asp:DropDownList ID="auto_select1" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="Month">
                                    <asp:ListItem>Select Month</asp:ListItem>
                                    <asp:ListItem Value="10">Jan</asp:ListItem>
                                    <asp:ListItem Value="11">Feb</asp:ListItem>
                                    <asp:ListItem Value="12">Mar</asp:ListItem>
                                    <asp:ListItem Value="1">Apr</asp:ListItem>
                                    <asp:ListItem Value="2">May</asp:ListItem>
                                    <asp:ListItem Value="3">Jun</asp:ListItem>
                                    <asp:ListItem Value="4">Jul</asp:ListItem>
                                    <asp:ListItem Value="5">Aug</asp:ListItem>
                                    <asp:ListItem Value="6">Sep</asp:ListItem>
                                    <asp:ListItem Value="7">Oct</asp:ListItem>
                                    <asp:ListItem Value="8">Nov</asp:ListItem>
                                    <asp:ListItem Value="9">Dec</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="auto_select6" runat="server" class="form-control" data-placeholder="Year">
                                    <asp:ListItem>Select To Year</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select To Year" ErrorMessage="Year Required..."
                                    ControlToValidate="auto_select6" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                    autofocus OnClick="btnSearch_Report" />
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <br />
                                <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3; color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                                    PageCountMode="Actual" Style="width: 100%; overflow: auto; height: 550px;" SizeToReportContent="true">
                                </rsweb:ReportViewer>
                            </div>
                            <!-- table-responsive -->
                        </div>
                    </div>
                    <!-- panel -->
                    <!-- col-md-6 -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
