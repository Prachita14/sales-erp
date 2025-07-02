<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="VICCO.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="#"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="#">Purchase Order</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Purchase Order</h4>
                        </div>
                        <div class="panel-body">
                         <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSearchPO" CssClass="form-control" runat="server" placeholder="PO NO"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Distributor Name">
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
                                        Width="80px" OnClick="txtSearchPOClick" />
                                </div>
                            </div>
                             <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Opps! No record found..</strong>
                                </div>
                                     <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid"  
                                    DataKeyNames="DPURCHASEORDER_ID" onrowdatabound="grdReport_RowDataBound">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SR.NO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="PO NO.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Distributor Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("DISTRIBUTOR_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="DATE">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("DATE","{0:dd MMM yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="TOTAL">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="INVOICE NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvoiceno" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                            
                                          <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="STATUS">
                                            <ItemTemplate>
                                               <asp:Label ID="Label44" runat="server" Font-Bold="false" Text='<%# Eval("STATUS")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="ACTION">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server"  CssClass="btn btn-info"
                                                    Font-Size="11px" Width="60px" ForeColor="White" Style="padding: 5px;" OnClick="lnkView_Click">VIEW</asp:LinkButton>
                                                     <asp:HyperLink ID="lnkInvoice" runat="server"  CssClass="btn btn-warning" 
                                                    Font-Size="11px"  ForeColor="White" Style="padding: 5px;margin-left:5px;" NavigateUrl='<%#"Invoice.aspx?id="+ Eval("DPURCHASEORDER_ID") %>' Target="_blank" >Create Invoice</asp:HyperLink>
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
