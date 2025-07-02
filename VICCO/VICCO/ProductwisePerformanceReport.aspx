<%@ Page Title="" Language="C#" MasterPageFile="~/office.Master" AutoEventWireup="true"
    CodeBehind="ProductwisePerformanceReport.aspx.cs" Inherits="VICCO.ProductwisePerformanceReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="ProductwisePerformanceReport.aspx">Product Wise (Qty) Performance Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Product Wise (Qty) Performance Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <asp:HiddenField ID="hdMaterialId" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                            <div class="col-md-2">
                                <asp:DropDownList ID="auto_select2" runat="server" class="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Region name Required..."
                                    ControlToValidate="auto_select2" Display="Dynamic" CssClass="error" ForeColor="Red" InitialValue="0" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Material Name">
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
                                    OnClick="btnSearch_Report" Width="80px" />
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                    margin-top: 20px; color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                
                                <rsweb:reportviewer id="ReportViewer1" runat="server" width="100%" asyncrendering="true"
                                    pagecountmode="Actual" style="width: 100%; overflow: auto;" sizetoreportcontent="true">
                                        </rsweb:reportviewer>
                            </div>
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
