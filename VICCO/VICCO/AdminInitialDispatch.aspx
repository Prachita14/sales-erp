<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminInitialDispatch.aspx.cs" Inherits="VICCO.AdminInitialDispatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .table > thead > tr > th, .table > tfoot > tr > th, th
        {
            background-color: #d8dce3;
            color: Black;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="AdminInitialDispatch.aspx">Dispatched Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <h2 style="color: Red; text-align: center;">
                                    Vicco Laboratories</h2>
                                <div class="col-md-6">
                                    <h5>
                                        <span>Invoice No :</span>
                                        <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label></h5>
                                    <h5>
                                        Line Item :
                                        <asp:Label ID="lblLineItem" runat="server"></asp:Label></h5>
                                    <h5>
                                        Dispatch Note No :
                                        <asp:Label ID="lblDispatchNo" runat="server"></asp:Label></h5>
                                </div>
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">
                                    <h5 class="text-right">
                                        DATE :
                                        <asp:Label ID="lblDate" runat="server"></asp:Label></h5>
                                </div>
                                <div style="width: 100%; overflow: auto;">
                                    <asp:GridView ID="grdDistributor" runat="server" Width="1500px" AutoGenerateColumns="False"
                                        AllowPaging="false" BorderStyle="None" CssClass="table table-bordered nomargin">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_CODE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Batch No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("batch_number")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Shipped Qty. In PCS">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("shipped_quantity")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Billed Qty. In PCS">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("billed_quantity")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Scheme">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("scheme")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Disscount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("addi_discount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("total")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Recived Qty In PCS">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("received_quantity")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="UOM">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("GRN_UOM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Remark">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("remark")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-9">
                                    <h5>
                                        <span>Total Shipped Quantity :</span>
                                        <asp:Label ID="lblTotalShipped" runat="server"></asp:Label></h5>
                                    <h5>
                                        <span>Total Received Quantity :</span>
                                        <asp:Label ID="lblTotalReceived" runat="server"></asp:Label></h5>
                                </div>
                                <div class="col-md-3">
                                    <h3 class="text-right">
                                        Total :<asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

