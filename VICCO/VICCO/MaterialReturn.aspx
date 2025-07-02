<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="MaterialReturn.aspx.cs" Inherits="VICCO.MaterialReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .remove
    {
        color:#FF5722;
        font-weight:bold;
        padding-top:5px;
    }
    
    </style>
    <script type="text/javascript">

        function SuccessOk() {
            alertify.alert('Success', 'Material return added successfully...!', function () { alertify.success(window.location = "MaterialReturn.aspx"); });
        }
       
    </script>
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
                                Manage Material Return</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div id="pono" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Invoice No</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtInvoice" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="date" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Return Date
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCalender" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date Required..."
                                            ControlToValidate="txtCalender" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <asp:HiddenField ID="hidHSNCode" runat="server" />
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdProduct" runat="server" CssClass="table table-primary nomargin grid" AutoGenerateColumns="false"
                                                DataKeyNames="RETURN_ID" BorderStyle="None" OnRowDataBound="grdProduct_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" ItemStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PARTICULAR" ItemStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'
                                                                Style="display: none;"></asp:Label>
                                                            <asp:Label ID="lblProduct_id" runat="server" Text='<%# Eval("MATERIAL_ID")%>' Style="display: none;"></asp:Label>
                                                            <asp:DropDownList ID="auto_selectProduct" runat="server" data-placeholder="Select Product"
                                                                AutoPostBack="true" OnSelectedIndexChanged="DropDownProductContent_TextChange">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BATCH NO" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtBatchNo" runat="server" Text='<%# Eval("BATCH_NO")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>                                                            
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("RATE")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="QUANTITY" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("QUANTITY")%>' CssClass="form-control"
                                                                CausesValidation="true" AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtQuantity" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="COMMENT" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtComment" runat="server" Text='<%# Eval("COMMENT")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SUB TOTAL" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTotal" runat="server" Text='<%# Eval("TOTAL")%>' CssClass="form-control"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="RemoveProduct" CssClass="remove"
                                                                CausesValidation="false">x</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="col-md-5">
                                        <br />
                                        <asp:HiddenField ID="HidWizardState" runat="server" />
                                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="btn btn-primary"
                                            Width="100px" />
                                    </div>
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
