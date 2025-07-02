<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="GoodReceipt.aspx.cs" Inherits="VICCO.GoodReceipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }         
    
    </script>
    <style type="text/css">
        #btnupdate{
            padding: 5px;
            font-size: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="GoodReceipt.aspx">Manage Good Receipt</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Manage Good Receipt</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtInvoiceno" CssClass="form-control" runat="server" placeholder="Invoice No"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="From Date"
                                        TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" placeholder="To Date"
                                        TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                        <asp:ListItem>All</asp:ListItem>
                                        <asp:ListItem>Closed</asp:ListItem>
                                        <asp:ListItem>Stock In Transit</asp:ListItem>
                                        <asp:ListItem>Short Received</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnSearch_Dispatch" Width="100px" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid" DataKeyNames="INVOICE_NO" OnRowDataBound="grdDispatch_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Line_Item">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("LINE_ITEM")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("GRN_DATE","{0:dd MMM yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Status" ItemStyle-ForeColor="Red">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("GRN_STATUS")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderStyle-Width="60px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <a href='AdminDispatched.aspx?invno=<%# Eval("INVOICE_NO")%>' class="btn btn-info"
                                                                style="padding: 5px; font-size: 11px; width: 60px; color: White; margin-right:10px;">View </a>
                                                        </td>
                                                        <td>
                                                            <asp:HyperLink ID="btnupdate" NavigateUrl='<%# "UpdateGoodReceipt.aspx?invno=" + Eval("INVOICE_NO")%>' class="btn btn-warning"
                                                                style="padding: 5px; font-size: 11px;" runat="server">Update Material Received</asp:HyperLink>
                                                           <%-- <a  runat="server" href='AdminInitialDispatch.aspx?invno=<%# Eval("INVOICE_NO")%>' class="btn btn-warning" id="btnupdate"
                                                                style="padding: 5px; font-size: 11px;">Update Material Received </a>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
