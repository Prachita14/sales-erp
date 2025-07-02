<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MaterialReport.aspx.cs" Inherits="VICCO.MaterialReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">

     function WarningOk() {
         alertify.error('No record found...');
     }         
    
    </script>
    <style>
.table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
    padding: 10px 10px !important;
}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="MaterialReport.aspx">Material Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Material Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMaterialCode" CssClass="form-control" runat="server" placeholder="Material Code"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Material Name">
                                    </asp:DropDownList>
                                </div>                                
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_material"
                                        Width="80px"/>
                                </div>
                                <div class="col-md-3">
                                <a href="MaterialReportdetails.aspx" target="_blank" class="btn btn-info">Show All Details</a>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="size">
                            <div class="table-responsive">
                             <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Opps! No record found..</strong>
                            </div>
                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="table nomargin table-primary grid" 
                                     DataKeyNames="MATERIAL_ID">
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
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Group">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_GROUP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSgst" runat="server" Font-Bold="false" Text='<%# Eval("SGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCgst" runat="server" Font-Bold="false" Text='<%# Eval("CGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="MRP">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("MRP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" HeaderText="Action">
                                            <ItemTemplate>
                                                <a href='Material.aspx?mid=<%# Eval("MATERIAL_ID")%>'><i class="fa fa-pencil"></i></a>
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