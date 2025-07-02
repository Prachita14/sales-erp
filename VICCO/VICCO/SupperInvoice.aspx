<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupperInvoice.aspx.cs" Inherits="VICCO.SupperInvoice" %>

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

        function SuccessOk() {
            alertify.alert('Success', 'Invoice Deleted Successfully...!', function () { alertify.success(window.location = "SupperInvoice.aspx"); });
        }
        function Confirm() {
            alertify.confirm('Warning', 'Are you sure want to delete!', function () { document.getElementById("<%=Button1.ClientID %>").click();}
                , function () { alertify.error('Cancel') });
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
                            <h4 class="panel-title">Invoice Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSearchPO" CssClass="form-control" runat="server" placeholder="Invoice NO"></asp:TextBox>
                                </div>

                                <%--<div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Supplier Name">
                                    </asp:DropDownList>
                                </div>--%>

                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Stockist Name">
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
                                    BorderStyle="None" CssClass="table nomargin table-primary grid" DataKeyNames="PURCHASEORDER_ID" OnRowDataBound="grdInvoice_RowDataBound">

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
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Stokist Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label22" runat="server" Font-Bold="false" Text='<%# Eval("NAME")%>'></asp:Label>
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

                                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Created At">
                                            <ItemTemplate>
                                                <asp:Label ID="Label21" runat="server" Font-Bold="false" Text='<%# Eval("CREATED_ON" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Created By">
                                            <ItemTemplate>
                                                <asp:Label ID="Label25" runat="server" Font-Bold="false" Text='<%# Eval("CREATEDBY_USER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Modified At">
                                            <ItemTemplate>
                                                <asp:Label ID="Label23" runat="server" Font-Bold="false" Text='<%# Eval("MODIFIED_AT" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Modified By">
                                            <ItemTemplate>
                                                <asp:Label ID="Label24" runat="server" Font-Bold="false" Text='<%# Eval("MODIFIED_USER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="Label99" runat="server" CssClass="text-warning" Font-Bold="false" Text='<%# Eval("GRN_STATUS")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <a href='POFormPrint.aspx?type=<%# Eval("GST_TYPE")%>&invoiceno=<%# Eval("PURCHASEORDER_ID")%>'
                                                    target="_blank" class="btn btn-info" style="font-size: 11px; width: 60px; color: White; padding: 5px;">View</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Visible="false" Font-Bold="false" Text='<%# Eval("GST_TYPE")%>'></asp:Label>
                                                <asp:Panel ID="gstlink" runat="server" Style="float: left;">

                                                    <a target="_blank" visible="false" href='EditInvoice.aspx?type=<%# Eval("GST_TYPE")%>&invoiceno=<%# Eval("PURCHASEORDER_ID")%>&sid=<%# Eval("STOCKIST_ID")%>'>
                                                        <i class="fa fa-pencil"></i></a>
                                                </asp:Panel>
                                                <asp:Panel ID="igstlink" runat="server" Style="float: left;">
                                                    <a target="_blank" visible="false" href='EditIgstInvoice.aspx?type=<%# Eval("GST_TYPE")%>&invoiceno=<%# Eval("PURCHASEORDER_ID")%>&sid=<%# Eval("STOCKIST_ID")%>'>
                                                        <i class="fa fa-pencil"></i></a>
                                                </asp:Panel>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btndeleteconfirm"><i class="fa fa-trash-o"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btndelete" Style="display:none;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
