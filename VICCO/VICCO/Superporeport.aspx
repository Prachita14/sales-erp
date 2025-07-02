<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true" CodeBehind="Superporeport.aspx.cs" Inherits="VICCO.Superporeport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="Superporeport.aspx">Purchase Order</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">Purchase Order Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">                                
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" TextMode="Date"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date Required..."
                                        ControlToValidate="txtFromDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE" TextMode="Date"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="To Date Required..."
                                        ControlToValidate="txttoDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnSearch_Stockist" Width="80px" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="size">
                                <div class="table-responsive">
                                    <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3; color: #505b72;">
                                        <strong>Oops! No record found..</strong>
                                    </div>

                                    <asp:GridView ID="grdReportNoExport" runat="server" Width="100%" AutoGenerateColumns="False"
                                        BorderStyle="None" CssClass="table nomargin table-primary grid">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Stockist">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("STOCKIST_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="PO NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Grand Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <a href='AutogeneratedPrint.aspx?pono=<%# Eval("SPURCHASEORDER_ID")%>'
                                                        target="_blank" class="btn btn-info" style="font-size: 11px; width: 60px; color: White; padding: 5px;">View</a>
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
    </div>
</asp:Content>
