<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="StockistReport.aspx.cs" Inherits="VICCO.StockistReport" %>

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
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="StockistReport.aspx">Stockist Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Stockist Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtStockistCode" CssClass="form-control" runat="server" placeholder="Super Stockist Code"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Stockist Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnSearch_Stockist" Width="80px" />
                                </div>
                                <div class="col-md-3">
                                <a href="StockistReportDetails.aspx" target="_blank" class="btn btn-info">Show All Details</a>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>

                            <div class="size">
                            <div class="table-responsive">
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Oops! No record found..</strong>
                                </div>
                                <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid" DataKeyNames="STOCKIST_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Stockist Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Region">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("STOCKIST_REGION")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("MOBILE_NUMBER")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("Email")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("ActStatus")%>'></asp:Label>

                                               <%-- <asp:Label ID="Label81" runat="server" Font-Bold="false" Font-Size="10px" Text='<%# Eval("DIACTIVATE_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click" CssClass="btn btn-info"
                                                    Font-Size="11px" Width="60px" height="28px" ForeColor="White" Style="padding: 5px;">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <a href='Stockist.aspx?sid=<%# Eval("STOCKIST_ID")%>'><i class="fa fa-pencil"></i>
                                                </a>
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
    <div class="modal bounceIn animated in" runat="server" id="myModal" tabindex="-1"
        role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;
        padding-right: 17px;">
        <div class="modal-dialog">
            <div class="modal-content" style="height: 550px; overflow: auto;">
                <div class="modal-header">
                    <button type="button" class="close" onclick="Closemodel()">
                        ×</button>
                    <h4 class="modal-title" id="myModalLabel">
                        Stockist Details</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <span>Code : </span>
                        <asp:Label ID="lblCode" runat="server" Text="Name" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Name : </span>
                        <asp:Label ID="lblName" runat="server" Text="Name" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Address : </span>
                        <asp:Label ID="lblAddress" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>District : </span>
                        <asp:Label ID="lblDistrict" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Pincode : </span>
                        <asp:Label ID="lblPincode" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Region : </span>
                        <asp:Label ID="lblRegion" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Phone Number : </span>
                        <asp:Label ID="lblPhoneNo" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Mobile Number : </span>
                        <asp:Label ID="lblMobileNo" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Email : </span>
                        <asp:Label ID="lblEmail" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Country : </span>
                        <asp:Label ID="lblCountry" runat="server" CssClass="modellabel"></asp:Label></p>

                        <p>
                        <span>City : </span>
                        <asp:Label ID="lblCity" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Contact Person : </span>
                        <asp:Label ID="lblContactPerson" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>Pan : </span>
                        <asp:Label ID="lblPan" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>LST : </span>
                        <asp:Label ID="lblLst" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>GSTIN : </span>
                        <asp:Label ID="lblGSTIn" runat="server" CssClass="modellabel"></asp:Label></p>
                    <p>
                        <span>TPT : </span>
                        <asp:Label ID="lblTpt" runat="server" CssClass="modellabel"></asp:Label></p>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" onclick="Closemodel()">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Closemodel() {
            document.getElementById('ContentPlaceHolder1_myModal').style.display = 'none';

        }
    </script>
</asp:Content>
