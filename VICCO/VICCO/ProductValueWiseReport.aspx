<%@ Page Title="" Language="C#" MasterPageFile="~/office.Master" AutoEventWireup="true" 
CodeBehind="ProductValueWiseReport.aspx.cs" Inherits="VICCO.ProductValueWiseReport" %>

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
                <li><a href="SecondaryCumulativeReport.aspx">Product and Value Wise Secondary Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Product and Value Wise Secondary Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-2" runat="server" id="region_ddl">
                                                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                        <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="Month">
                                    <asp:ListItem>Select From Month</asp:ListItem>
                                    <asp:ListItem>Jan</asp:ListItem>
                                    <asp:ListItem>Feb</asp:ListItem>
                                    <asp:ListItem>Mar</asp:ListItem>
                                    <asp:ListItem>Apr</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                    <asp:ListItem>Jun</asp:ListItem>
                                    <asp:ListItem>Jul</asp:ListItem>
                                    <asp:ListItem>Aug</asp:ListItem>
                                    <asp:ListItem>Sep</asp:ListItem>
                                    <asp:ListItem>Oct</asp:ListItem>
                                    <asp:ListItem>Nov</asp:ListItem>
                                    <asp:ListItem>Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select From Month" ErrorMessage="Month Required..."
                                        ControlToValidate="auto_select3" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>


                            <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select6" runat="server" class="form-control" data-placeholder="Year">
                                    <asp:ListItem>Select To Year</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select To Year" ErrorMessage="Year Required..."
                                        ControlToValidate="auto_select6" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                           
                                    <div class="col-md-4">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                            autofocus OnClick="btnSearch_Report" />
                                    </div>

                                    <div class="clearfix">
                                    </div>

                                    <div class="table-responsive">
                                        <br />
                                        <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                            color: #505b72;">
                                            <strong>Oops! No record found..</strong>
                                        </div>
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                                            PageCountMode="Actual" Style="width: 100%; overflow: auto; height: 1000px;" SizeToReportContent="true">
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
