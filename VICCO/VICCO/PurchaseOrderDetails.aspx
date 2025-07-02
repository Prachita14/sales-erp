<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderDetails.aspx.cs" Inherits="VICCO.PurchaseOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
     function WarningOk() {
         alertify.error('No record found...');
     }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="PurchaseOrder.aspx">Purchase Order Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <h2 style="color: Red; text-align: center;">
                                  <asp:Label ID="lblDistributor" runat="server"></asp:Label> </h2>
                                <div class="col-md-6">
                                    <h5>
                                        <span>Po No :</span>
                                        <asp:Label ID="lblPoNo" runat="server"></asp:Label></h5>
                                   <asp:Label ID="lblPurchaseOrder" runat="server" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">
                                    <h5>
                                        DATE :
                                        <asp:Label ID="lblDate" runat="server"></asp:Label></h5>
                                </div>
                                <div style="width: 100%; overflow: auto;">
                                    <asp:GridView ID="grdDistributor" runat="server" Width="1100px" AutoGenerateColumns="False"
                                        AllowPaging="false" BorderStyle="None" CssClass="table table-bordered nomargin"
                                        PageSize="10">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="MATERIAL NAME">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="HSN NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("UNIT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="QUANTITY">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("QTY")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="RATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SCHEME">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("SCHEME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="DISCOUNT">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("DISCOUNT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="AMOUNT">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("AMOUNT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("CGST")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("SGST")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SUBTOTAL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("SUB_TOTAL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("STATUS")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-9">
                                   
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
