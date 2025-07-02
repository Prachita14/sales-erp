<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="InvoiceReport.aspx.cs" Inherits="VICCO.InvoiceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function WarningOk() {
            alertify.error('No record found...');
        }
    </script>

    <script type="text/javascript">
        function customOpen(url) {
            var w = window.open(url, '_blank');
            w.focus();
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
                <li><a href="InvoiceReport.aspx">Invoice Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Invoice Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSearchPO" CssClass="form-control" runat="server" placeholder="Invoice NO"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Supplier Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="80px" OnClick="txtSearchPO_TextChanged" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                     <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid"  DataKeyNames="PO_NO">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("DISTRIBUTOR_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="QTY. IN PCS">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Grand Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" CssClass="text-warning" Font-Bold="false" Text='<%# Eval("GRN_STATUS")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <a href='POFormPrint.aspx?type=<%# Eval("GST_TYPE")%>&invoiceno=<%# Eval("PURCHASEORDER_ID")%>'
                                                    target="_blank" class="btn btn-info" style="font-size: 11px; width: 60px; color: White;
                                                    padding: 5px;">View</a>
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
