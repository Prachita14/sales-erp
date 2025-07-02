<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TargetvsSale.aspx.cs" Inherits="VICCO.TargetvsSale" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12
        {
            padding-top: 10px;
        }
    </style>
    <script type="text/javascript" src="../lib/jquery/jquery.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="TargetvsSale.aspx">Target Vs Sale Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Target Vs Sale Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                          <div class="col-md-3">
                              <asp:DropDownList ID="ddlReportWise" runat="server" CssClass="form-control">
                              <asp:ListItem>Select</asp:ListItem>
                              <asp:ListItem>Distributor</asp:ListItem>
                              <asp:ListItem>Stockist</asp:ListItem>
                              <asp:ListItem>SO</asp:ListItem>
                              <asp:ListItem>SR</asp:ListItem>
                              <asp:ListItem>ASM</asp:ListItem>
                              <asp:ListItem>State Head</asp:ListItem>
                              <asp:ListItem>National Head</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="Month">
                                        <asp:ListItem Value="0">Select Month</asp:ListItem>
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                        ErrorMessage="Month Required..." ControlToValidate="auto_select3" Display="Dynamic"
                                        CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select6" runat="server" class="form-control" data-placeholder="Year">
                                        <asp:ListItem>Select To Year</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select To Year"
                                        ErrorMessage="Year Required..." ControlToValidate="auto_select6" Display="Dynamic"
                                        CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnSearch_Report" Width="100px" />
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="table-responsive">
                                    <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                        margin-top: 20px; color: #505b72;">
                                        <strong>Oops! No record found..</strong>
                                    </div>
                                 
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="true"
                                        PageCountMode="Actual" Style="overflow: auto;" SizeToReportContent="true">
                                    </rsweb:ReportViewer>
                                   
                                </div>
                            
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>