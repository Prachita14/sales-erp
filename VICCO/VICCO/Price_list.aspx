<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="Price_list.aspx.cs" Inherits="VICCO.Price_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="Price_list.aspx">Price List</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Price List</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                             <asp:GridView ID="grdReport1" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid"  DataKeyNames="PRICE_ID">

                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("RATE")%>' CausesValidation="true" CssClass="form-control"
                                                            Width="100px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Input"
                                                            SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Scheme" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtScheme" runat="server" Text='<%# Eval("SCHEME")%>' CausesValidation="true" CssClass="form-control"
                                                            Width="100px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Input"
                                                            SetFocusOnError="true" ControlToValidate="txtScheme" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Disscount" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDisscount" runat="server" Text='<%# Eval("DISSCOUNT")%>' CausesValidation="true" CssClass="form-control"
                                                            Width="100px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Input"
                                                            SetFocusOnError="true" ControlToValidate="txtDisscount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Mrp" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMrp" runat="server" Text='<%# Eval("MRP")%>' CausesValidation="true" CssClass="form-control"
                                                            Width="100px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Input"
                                                            SetFocusOnError="true" ControlToValidate="txtMrp" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnSearch" runat="server" Text="Update" CssClass="btn btn-warning"
                                                            OnClick="Content_TextChange" Width="80px" />
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
