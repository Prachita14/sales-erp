<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true"
    CodeBehind="NoOfDisplayReport.aspx.cs" Inherits="VICCO.Employee.NoOfDisplayReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }         
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
          
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                No Of Display Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtFrom_Date" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        TextMode="Date" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtTo_Date" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        TextMode="Date" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnsearch" Width="80px" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table table-primary nomargin grid" DataKeyNames="EMP_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="id" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SR Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("EMP_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="From_Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("From_Date" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="To_Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("To_Date" ,"{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Brush">
                                            <ItemTemplate>
                                                <asp:Label ID="Label43" runat="server" Font-Bold="false" Text='<%# Eval("Brush")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Facewash">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("Facewash")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="IFB">
                                            <ItemTemplate>
                                                <asp:Label ID="Label46" runat="server" Font-Bold="false" Text='<%# Eval("IFB")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="NRY_C">
                                            <ItemTemplate>
                                                <asp:Label ID="Label443" runat="server" Font-Bold="false" Text='<%# Eval("NRY_C")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="NRY_S">
                                            <ItemTemplate>
                                                <asp:Label ID="Label454" runat="server" Font-Bold="false" Text='<%# Eval("NRY_S")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="OIB">
                                            <ItemTemplate>
                                                <asp:Label ID="Label426" runat="server" Font-Bold="false" Text='<%# Eval("OIB")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Paste">
                                            <ItemTemplate>
                                                <asp:Label ID="Label533" runat="server" Font-Bold="false" Text='<%# Eval("Paste")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Paste25">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4214" runat="server" Font-Bold="false" Text='<%# Eval("Paste25")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Pouch_Powder">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4756" runat="server" Font-Bold="false" Text='<%# Eval("Pouch_Powder")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Pouch_WSO">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4574" runat="server" Font-Bold="false" Text='<%# Eval("Pouch_WSO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Powder">
                                            <ItemTemplate>
                                                <asp:Label ID="Label456" runat="server" Font-Bold="false" Text='<%# Eval("Powder")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SF">
                                            <ItemTemplate>
                                                <asp:Label ID="Label553" runat="server" Font-Bold="false" Text='<%# Eval("SF")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Shaving">
                                            <ItemTemplate>
                                                <asp:Label ID="Label774" runat="server" Font-Bold="false" Text='<%# Eval("Shaving")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="VTC_Cream">
                                            <ItemTemplate>
                                                <asp:Label ID="Label886" runat="server" Font-Bold="false" Text='<%# Eval("VTC_Cream")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="WSO">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("WSO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Combine">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("COMBINE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("Total")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                            </div>
                            <!-- table-responsive -->
                        </div>
                    </div>
                </div>
                <!-- panel -->
                <!-- col-md-6 -->
            </div>
        </div>
        <!-- contentpanel -->
    </div>
</asp:Content>
