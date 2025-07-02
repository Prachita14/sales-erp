<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Notice.aspx.cs" Inherits="VICCO.Notice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       
        function SuccessOk() {
            alertify.alert('Success', 'Notice added successfully...!', function () { alertify.success(window.location = "Notice.aspx"); });
        }

        function UpdateOk() {
            alertify.alert('Success', 'Notice updated successfully...!', function () { alertify.success(window.location = "Notice.aspx"); });
        }

       
        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Notice deleted successfully...');
        }

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="Material.aspx">Add Notice</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Notice</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please your Notice Description.</p>
                            <hr style="border-color: #fc8414;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </asp:ToolkitScriptManager>
                                
                                <cc1:Editor ID="Editor1" runat="server" Width="100%" Height="200px" />
                               
                                <div class="clearfix">
                                </div>
                                <br />
                                <div class="form-group mb20">
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkStockist" name="checkbox" runat="server" />
                                        <span>Stockist</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkSales" name="checkbox" runat="server" />
                                        <span>Sales Team</span>
                                    </label>
                                    <div class="col-md-12">
                                        <hr style="border-color: #03A9F4;" />
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                            OnClick="btnSaveNotice" ValidationGroup="Save" />
                                              <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                            OnClick="btnUpdateNotice" ValidationGroup="Update" />
                                        <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
                                        <a href="Notice.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <br />
                                <hr style="border-color: #fc8414;" />
                                <asp:GridView ID="grdNotice" runat="server" Width="100%" AutoGenerateColumns="False"
                                    DataKeyNames="NOTICE_ID" OnPageIndexChanging="grdNotice_PageIndexChanging" AllowPaging="true"
                                    BorderStyle="None" CssClass="table nomargin grid" PageSize="6">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Notice" ItemStyle-Width="500px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%#  Limit(Eval("PLAIN_TEXT"),100) %>'
                                                    ToolTip='<%# Eval("NOTICE_TEXT") %>'></asp:Label>
                                                <asp:LinkButton ID="ReadMoreLinkButton" runat="server" ForeColor="red" Font-Size="12px"
                                                    Text="Read More" Visible='<%# SetVisibility(Eval("PLAIN_TEXT"), 100) %>' OnClick="ReadMoreLinkButton_Click">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="STOCKIST">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("IS_STOCKIST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SALES">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("IS_SALES")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o" title="Delete"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
