<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true" CodeBehind="Superpurchaseorder.aspx.cs" Inherits="VICCO.Superpurchaseorder" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SuccessMsg() {
            alertify.alert('Success', 'Purchase Order Created Successfully...!', function () { window.location = "Superporeport.aspx" });
        }
    </script>
    <style>
        .manual thead {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="#">Purchase Order</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">Create Purchase Order</h4>
                        </div>
                        <div class="panel-body">
                            <%--<div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3; color: #505b72;">
                                <strong>Min stock not found or Purchase order already created..</strong>
                            </div>--%>
                            <center>
                                <a href="Superporeport.aspx" class="btn btn-default">View History</a>
                                <br /><br /><br />
                            </center>
                            <div id="content" runat="server">
                                <div class="col-md-12 row role" style="margin-bottom: 30px;">
                                    <div id="pono" class="form-group col-md-4">
                                        <label class="col-md-2 control-label">
                                            To</label>
                                        <label class="col-md-8 control-label">
                                            <strong>VICCO Laboratories</strong>
                                        </label>
                                    </div>
                                    <div class="col-md-4"></div>
                                    <div id="date" class="form-group col-md-4">
                                        <label class="col-md-4 control-label">
                                            Date
                                        </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCalender" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="table-responsive">
                                    <asp:GridView ID="grdPurchaseorder" runat="server" CssClass="table table-primary nomargin grid" AutoGenerateColumns="false" Style="display: block;"
                                        DataKeyNames="ID" BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" ItemStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PARTICULAR" ItemStyle-Width="40%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                    <asp:Label ID="lblProduct_id" runat="server" Text='<%# Eval("MATERIAL_ID")%>' Style="display: none;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CURRENT STOCK" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurrentStock" runat="server" Text='<%# Eval("CURRENT_STOCK")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MIN QTY REQUIRED (CS)" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMinpoQty" runat="server" Text='<%# Eval("MIN_STOCK_CS")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DIFFRENCE" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiffStock" runat="server" Text='<%# Eval("DIFF_STOCK")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Qty (CS)" HeaderStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" type="number" min='<%# Eval("DIFF_STOCK")%>' Text='<%# Eval("DIFF_STOCK")%>' CssClass="form-control"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="grdManualProduct" runat="server" OnRowDataBound="grdManualProduct_RowDataBound" CssClass="table table-primary nomargin grid manual" AutoGenerateColumns="false" Style="display: block;" DataKeyNames="ID" BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PARTICULAR" ItemStyle-Width="60%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'
                                                        Style="display: none;"></asp:Label>
                                                    <asp:Label ID="lblProduct_id" runat="server" Text='<%# Eval("MATERIAL_ID")%>' Style="display: none;"></asp:Label>
                                                    <asp:DropDownList ID="auto_selectProduct" runat="server" data-placeholder="Select Product"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ProductContent_TextChange" ValidationGroup="check">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MIN QTY REQUIRED (CS)" ItemStyle-Width="22%">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Qty (CS)" HeaderStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" type="number" min='<%# Eval("QTY")%>' AutoPostBack="true" OnTextChanged="Content_TextChange" Text='<%# Eval("QTY")%>' CssClass="form-control"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" OnClick="RemoveProduct" ForeColor="#FF5722"
                                                        CausesValidation="false">x</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                    <hr />
                                    <div class="col-md-12">
                                        <asp:Button ID="Button1" runat="server" Text="Create PO" CssClass="btn btn-primary" OnClick="btnSubmit_Click" CausesValidation="true" />
                                        <!-- table-responsive -->
                                    </div>
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="false"></rsweb:ReportViewer>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
