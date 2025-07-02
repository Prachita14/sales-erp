<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeMasterReport.aspx.cs" Inherits="VICCO.EmployeeMasterReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">

     function WarningOk() {
         alertify.error('No record found...');
     }  
     function SuccessOk() {
         alertify.alert('Success', 'Deleted Successfully...!', function () { alertify.success(window.location = "EmployeeMasterReport.aspx"); });
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
                <li><a href="EmployeeMasterReport.aspx">Employee Master Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                               Employee Master Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-2">
                                 <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Designation">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Employee Code And Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_material"
                                     Width="100px" />
                                </div>                                
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Opps! No record found..</strong>
                                </div>
                                    <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid"  DataKeyNames="EMP_ID">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Employee Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("EMP_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("EMP_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("POSITION")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Parent">
                                            <ItemTemplate>
                                                <asp:Label ID="Label32" runat="server" Font-Bold="false" Text='<%# Eval("PARENT_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("EMP_EMAIL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Password">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("EMP_PASSWORD")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Joining Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("JOINING_DATE" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Deactived Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("DEACTIVE_DATE" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <a href='EmployeeMaster.aspx?Eid=<%# Eval("EMP_ID")%>'><i class="fa fa-pencil"></i>
                                                </a>                                           
                                            <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btndeleteclick"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
