<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Setsuperminstock.aspx.cs" Inherits="VICCO.Setsuperminstock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="#">Set Super Min Stock</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">Set Super Min Stock</h4>
                        </div>
                        <div class="panel-body">
                            <div class="clearfix">
                            </div>
                            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                                <div class="table-responsive role">
                                    <asp:GridView ID="grdReportNoExport" runat="server" CssClass="table table-primary nomargin grid" AutoGenerateColumns="false" Style="display: block;"
                                        DataKeyNames="ID" BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" ItemStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MATERIAL NAME" ItemStyle-Width="70%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MIN STOCK(CS)" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMinstock" runat="server" Text='<%# Eval("MIN_STOCK_CS")%>' CssClass="form-control"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                    <asp:Button ID="Button1" runat="server" Text="Save" Style="width: 100px;" OnClick="btn_Stockupdate" OnClientClick="Clearsearch3()" CssClass="btn btn-primary" />
                                    <br />
                                </div>
                                <!-- table-responsive -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
