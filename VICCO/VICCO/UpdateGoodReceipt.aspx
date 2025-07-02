<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="UpdateGoodReceipt.aspx.cs" Inherits="VICCO.UpdateGoodReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table > thead > tr > th, .table > tfoot > tr > th, th
        {
            background-color: #d8dce3;
            color: Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="UpdateGoodReceipt.aspx">Update Received Material</a></li>
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
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></h5>
                                    <h5>
                                        Line Item :
                                        <asp:Label ID="lblLineItem" runat="server" Text="Label"></asp:Label></h5>
                                    <h5>
                                        Dispatch Note No :
                                        <asp:Label ID="lblDispatchNo" runat="server" Text="Label"></asp:Label></h5>
                                </div>
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">
                                    <h5>
                                        DATE :
                                        <asp:Label ID="lblDate" runat="server"></asp:Label></h5>
                                </div>
                                <div style="width: 100%; overflow: auto;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdDistributor" runat="server" Width="1200px" AutoGenerateColumns="False"
                                                AllowPaging="false" BorderStyle="None" CssClass="table table-bordered nomargin"
                                                PageSize="10" DataKeyNames="ID">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Description"
                                                        HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Batch No" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("batch_number")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Shipped Qty. In Cases"
                                                        HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("shipped_quantity")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Scheme" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("scheme")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Discount" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("addi_discount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Amount" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("total")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Recived Qty In Cases"
                                                        HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtReceivedQuantity" runat="server" Text='<%# Eval("received_quantity")%>'
                                                                CausesValidation="true" Width="100px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtReceivedQuantity" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="UOM" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtUom" runat="server" Text='<%# Eval("GRN_UOM")%>' Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Remark" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemark" runat="server" Text='<%# Eval("remark")%>' Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Status" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("grn_status")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" CausesValidation="false" OnClick="Content_TextChange">Save</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="pagination" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-8">
                                    <h5>
                                        <span>Total Shipped Quantity :</span>
                                        <asp:Label ID="lblTotalShipped" runat="server"></asp:Label></h5>
                                    <h5>
                                        <span>Total Received Quantity :</span>
                                        <asp:Label ID="lblTotalReceived" runat="server"></asp:Label></h5>
                                </div>
                                <div class="col-md-3">
                                    <h3>
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
