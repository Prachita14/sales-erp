<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="Setdistributorsale.aspx.cs" Inherits="VICCO.Employee.Setdistributorsale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }

        function SaveOk() {
            alertify.alert('Success', 'Sale Qty added successfully...!', function () { alertify.success('Ok'); });
        }         
    
    </script>

    <style type="text/css">
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
        
        .select2-container--default .select2-selection--single .select2-selection__arrow
        {
            height: 26px;
        }
    </style>
    <style type="text/css">
        .total
        {
            margin: 40px;
            width: 30%;
            background-color: #e0e0e0;
        }
        
        .total tr td
        {
            padding: 10px;
            font-weight: bold;
        }
        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12
        {
            padding-top: 10px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Set Sale</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row">                                
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Distributor Name">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Distributor Name Required..."
                                        ControlToValidate="auto_select2" Display="Dynamic" InitialValue="0" CssClass="error"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="Month">
                                    <asp:ListItem>Select Month</asp:ListItem>
                                    <asp:ListItem>Jan</asp:ListItem>
                                    <asp:ListItem>Feb</asp:ListItem>
                                    <asp:ListItem>Mar</asp:ListItem>
                                    <asp:ListItem>Apr</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                    <asp:ListItem>Jun</asp:ListItem>
                                    <asp:ListItem>Jul</asp:ListItem>
                                    <asp:ListItem>Aug</asp:ListItem>
                                    <asp:ListItem>Sep</asp:ListItem>
                                    <asp:ListItem>Oct</asp:ListItem>
                                    <asp:ListItem>Nov</asp:ListItem>
                                    <asp:ListItem>Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select Month" ErrorMessage="Month Required..."
                                        ControlToValidate="auto_select3" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select4" runat="server" class="form-control" data-placeholder="Year">
                                    <asp:ListItem>Select Year</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select Year" ErrorMessage="Year Required..."
                                        ControlToValidate="auto_select4" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnGet" runat="server" Text="Submit" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnGetMaterial" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <hr />
                            <div class="table-responsive">                                
                                <div class="clearfix">
                                </div>
                                <br />
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                <asp:GridView ID="grdMaterial" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdMaterial_RowDataBound"
                                    AllowPaging="false" BorderStyle="None"
                                    CssClass="table nomargin grid" PageSize="10" DataKeyNames="ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_CODE")%>'></asp:Label>
                                                <asp:Label ID="lblMaterialId" runat="server" Visible="false" Font-Bold="false" Text='<%# Eval("MATERIAL_ID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Closing Stock" ControlStyle-Width="30%">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSale" CssClass="form-control" Text='<%# Eval("SALE")%>' runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                    ControlToValidate="txtSale" runat="server" ErrorMessage="Only Numbers allowed"
                                                    ForeColor="Red" ValidationExpression="\d+">
                                                </asp:RegularExpressionValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                                <asp:HiddenField ID="Rowcount" runat="server" />
                                <br />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" Visible="false"
                                        Width="80px" OnClick="btnSaveClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

