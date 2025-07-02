
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="MaterialReturnReport.aspx.cs" Inherits="VICCO.MaterialReturnReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>--%>
    <asp:HiddenField ID="hidSearchtext" runat="server" />
    <div class="mainpanel">
        <div class="contentpanel">
         <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="MaterialReturnReport.aspx">Material Return Report</a></li>
            </ol>

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Material Return Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                            <div class="col-md-2">
                                    <asp:DropDownList ID="ddlAprove" runat="server" class="select form-control">
                                    <asp:ListItem>New Request</asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select2" runat="server" class="select form-control" data-placeholder="Super Stockist Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" TextMode="Date"></asp:TextBox>
                                   
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="100px" OnClick="txtReturnMaterial_TextChanged" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <asp:HiddenField ID="hidHSNCode" runat="server" />
                          <div class="size">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdReport" runat="server" CssClass="table nomargin table-primary grid" AutoGenerateColumns="false"
                                        DataKeyNames="RETURN_ID" BorderStyle="None" Width="1600px" OnRowDataBound="grdReport_RowDataBound"> 

                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SUPER STOCKIST">
                                                <ItemTemplate>
                                                    <asp:Label ID="STOCKIST" runat="server" Text='<%# Eval("SUPPER_STOCKIST")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PARTICULAR">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_DESCREPTION")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="INVOICE NO" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label0" runat="server" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RETURN_DATE"  HeaderStyle-HorizontalAlign="Left">
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
                                            <asp:TemplateField HeaderText="STATUS" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                   <%-- <asp:LinkButton ID="lnkApprove" runat="server" Style="color: White; font-size: 12px; background-color:Green;
                                                       padding: 5px 7px; height:28px;" CausesValidation="false" CssClass="btn btn-success" OnClick="lnkApprove">Approve</asp:LinkButton>--%>
                                                    <asp:Label ID="Lable6" runat="server" Text='<%# Eval("APPRVE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField>
                                                <ItemTemplate>
                                                     <asp:LinkButton ID="lnkApprove" runat="server" Style="color: White; font-size: 12px; background-color:Green;
                                                       padding: 5px 7px; height:28px;" CausesValidation="false" CssClass="btn btn-success" OnClick="lnkApprove">Approve</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRejcet" runat="server" Style="color: White; font-size: 12px;
                                                      padding: 5px 7px; height:28px;" CausesValidation="false" CssClass="btn btn-danger" OnClick="lnkReject">Reject</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination" />
                                    </asp:GridView>
                                </div>
                          </div>
                               
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
