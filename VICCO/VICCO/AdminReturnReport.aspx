<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminReturnReport.aspx.cs" Inherits="VICCO.AdminReturnReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .control-label
        {
            padding-top: 10px;
        }
        .grid a
        {
            color: #505b72;
            font-size: 16px;
            padding-left: 5px;
        }
        .grid a:hover
        {
            color: #257bab;
        }       
        .content
        {
            height: 560px;
        }
        .table td th tr
        {
            border: 1px solid black;
        }
        .supplierheading
        {
            color: #ffffff;
            background-color: #2574ab;
            border-color: #2574ab;
            padding-top: 10px;
            padding-bottom: 10px;
            border-bottom: 0;
            font-size: 16px;
        }
        
        .nomargin td
        {
            padding: 2px;
            vertical-align: middle !important;
        }
        
        .error
        {
            background: rgb(251, 227, 228);
            border: 1px solid #fbc2c4;
            color: #8a1f11;
            margin: 0 !important;
        }
        
        .qty
        {
            width: 10%;
        }
        
        .select2
        {
            width: 100% !important;
        }
        .select2-container--default .select2-selection--single .select2-selection__arrow
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hidSearchtext" runat="server" />
    <div class="mainpanel">
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Material Return Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                             <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Super Stockist Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" TextMode="Date"></asp:TextBox>
                                    <%--<asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" runat="server"
                                        Format="dd MMM yyyy">
                                    </asp:CalendarExtender>--%>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="80px" OnClick="txtReturnMaterial_TextChanged" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <asp:HiddenField ID="hidHSNCode" runat="server" />
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdProduct" runat="server" CssClass="table nomargin grid" AutoGenerateColumns="false"
                                                BorderStyle="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="NO" ItemStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PARTICULAR" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_DESCREPTION")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="INVOICE NO" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label0" runat="server" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RETURN_DATE" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("RETURN_DATE" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BATCH NO" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("BATCH_NO")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RATE" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("RATE")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="QUANTITY" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("QUANTITY")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="COMMENT" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("COMMENT")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("TOTAL")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <!-- table-responsive -->
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <!-- col-md-12 -->
        </div>
    </div>
</asp:Content>

