﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AutogeneratedSuperpo.aspx.cs" Inherits="VICCO.AutogeneratedSuperpo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="AutogeneratedSuperpo.aspx">Super Stock Alert</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">Super Wise Minimum Stock Alert</h4>
                        </div>
                        <div class="panel-body">

                            <div class="clearfix">
                            </div>
                            <div class="size">
                                <div class="table-responsive">
                                    <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3; color: #505b72;">
                                        <strong>No record found..</strong>
                                    </div>                                    
                                    
                                        <asp:GridView ID="grdReport" runat="server" Width="100%" Style AutoGenerateColumns="False"
                                            BorderStyle="None" CssClass="table table-bordered table-warning nomargin stock">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>                                                
                                                <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#bf7c1d" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Stockist" HeaderStyle-BackColor="#bf7c1d" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("STOCKIST_NAME")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#bf7c1d" HeaderText="Item Count" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_COUNT")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" HeaderStyle-BackColor="#bf7c1d" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <a href='Autogenerateditemview.aspx?sid=<%# Eval("STOCKIST_ID")%>'
                                                            class="btn btn-info" style="font-size: 11px; width: 60px; color: White; padding: 5px;">View</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="pagination" />
                                        </asp:GridView>
                                    
                                    <br />
                                    <a href="Autogeneratedpohistory.aspx" class="btn btn-default">View History</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
