<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true"
    CodeBehind="NoOfDisplay.aspx.cs" Inherits="VICCO.Employee.NoOfDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .control-label
        {
            padding-top: 10px;
        }
        .completionList
        {
            border: 1px solid #aaa;
            height: 200px;
            padding: 3px;
            position: absolute;
            top: 0;
            overflow: auto;
            background-color: #FFFFFF;
            z-index: 999999 !important;
        }
        .completionList li
        {
            list-style: none;
            padding: 5px;
        }
        .completionList li:hover
        {
            background-color: #2598ab;
            color: White;
            border-radius: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
           
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                No Of Display</h4>
                        </div>
                        <div class="panel-body">
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" DataKeyNames="EMP_ID"
                                    BorderStyle="None" AllowPaging="false" CssClass="table table-primary nomargin grid">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SR">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("EMP_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="From_Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="form-control" TextMode="Date"
                                                    Width="100%"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="To_Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTo_Date" runat="server" CssClass="form-control" TextMode="Date"
                                                    Width="100%"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Brush">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBrush" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Face Wash ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtfacewash" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText=" IFB">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtifb" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="NRY-C">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtnryc" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="NRY-S">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtnrys" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="OIB">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtoib" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Paste">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpaste" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Paste 25">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpaste25" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="POUCH Powder">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpouchpowder" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="POUCH WSO">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpouchwso" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Powder">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtpowder" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="SF">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsf" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Shaving">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtshaving" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText=" VTC Cream">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtvtccream" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="WSO">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtwso" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Combine">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCombine" runat="server" CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="No Of Display">
                                            <ItemTemplate>
                                                <asp:Button ID="btnTarget" runat="server" Text="Submit" CssClass="btn btn-primary"
                                                    Width="80px" OnClick="btnorder" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
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
