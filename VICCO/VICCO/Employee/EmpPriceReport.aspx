<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true"
    CodeBehind="EmpPriceReport.aspx.cs" Inherits="VICCO.EmpPriceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }
    
    </script>   
    
    <script type="text/javascript" src="../lib/jquery/jquery.js"></script>
    <script type="text/javascript">

        var selected_material_id = [];
        var selected_material_name = [];

        function AssignMaterialId(id, name) {
            selected_material_id.push(id);
            selected_material_name.push(name);
        }

        function MaterialChange() {

            var e = document.getElementById("ContentPlaceHolder1_auto_select1");
            var Material_name = e.options[e.selectedIndex].text;
            var Material_id = e.options[e.selectedIndex].value;

            if (Material_name == "") {
            }
            else {
                var materials = "<div id='material'><span class='alert alert-success'>" + Material_name + "<button type='button' id='" + Material_id + "' onclick='RemoveMaterialId(" + Material_id + ")' class='close' data-dismiss='alert' aria-hidden='true'>×</button></span></div>";
                $('#ContentPlaceHolder1_ShowSelectedMaterial').append(materials);

                selected_material_id.push(Material_id);
                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

                selected_material_name.push(Material_name);
                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
            }
        }

        Array.prototype.remove = function (x) {
            var i;
            for (i in this) {
                if (this[i].toString() == x.toString()) {
                    this.splice(i, 1)
                }
            }
        }

        function RemoveMaterialId(id) {
            {
                
                var e = document.getElementById("ContentPlaceHolder1_auto_select1");
                var Material_name = e.options[id].text;

                selected_material_id.remove(id);
                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

                selected_material_name.remove(Material_name);
                $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
            }
        }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <div class="mainpanel">
        <div class="contentpanel">         
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Price Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Material Name"
                                        onchange="MaterialChange()">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRegion_Change">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Super Stockist Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" TextMode="Date"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date Required..."
                                        ControlToValidate="txtFromDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE" TextMode="Date"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="To Date Required..."
                                        ControlToValidate="txttoDate" Display="Dynamic" CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                               
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-1 mt20">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                                OnClick="btnSearch_Report" Width="100px" />
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="table-responsive">
                                            <br />
                                            <div id="errorMsg" runat="server" visible="false" class="alert alert-warning" style="background-color: #d8dce3;
                                                color: #505b72;">
                                                <strong>Oops! No record found..</strong>
                                            </div>                                     
                                                 <asp:GridView ID="grdReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    BorderStyle="None" CssClass="table nomargin table-primary grid">

                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="INVOICE NUMBER">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="RATE TO SS">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("RATE_TO_SS")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="RATE TO DIST">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("RATE_TO_DIST")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="MARGIN %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("MARGIN")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="pagination" />
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <div class="loading">
                                        <center>
                                            <img src="../images/loading.gif" />
                                        </center>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
