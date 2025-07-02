<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SetTarget.aspx.cs" Inherits="VICCO.Employee.SetTarget" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }

        function SaveOk() {
            alertify.alert('Success', 'Target details successfully...!', function () { alertify.success('Ok'); });
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
    <script type="text/javascript">

        var selected_material_id = [];
        var selected_material_name = [];

        function AssignMaterialId(id, name) {
            selected_material_id.push(id);
            selected_material_name.push(name);
        }

        function MaterialChange() {

            var e = document.getElementById("ContentPlaceHolder1_auto_select8");
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
                //                if (selected_material_id == "") {
                //                    AssignMaterialId($('#ContentPlaceHolder1_hdMaterialId').val(), $('#ContentPlaceHolder1_HiddenField1').val());
                //                }

                var e = document.getElementById("ContentPlaceHolder1_auto_select8");
                var Material_name = e.options[id].text;

                selected_material_id.remove(id);
                //selected_material_id.splice(selected_material_id.indexOf(id), 1);
                $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

                selected_material_name.remove(Material_name);
                //selected_material_name.splice(selected_material_name.indexOf(Material_name), 1);
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
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Set Target</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row">
                                <asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRegion_Change">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Super Stockist Name"
                                        AutoPostBack="true" OnSelectedIndexChanged="auto_select1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="District Name"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_Change">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Distributor Name">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Distributor Name Required..."
                                        ControlToValidate="auto_select2" Display="Dynamic" InitialValue="0" CssClass="error"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnTarget" runat="server" Text="Set Target" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnTarget_Click" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <hr />
                            <div class="table-responsive">
                                <asp:Panel ID="pnlSearch" runat="server" Visible="false">
                                    <div class="col-md-1">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="false" Text="Search By"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="auto_select8" runat="server" class="form-control" data-placeholder="Material Name"
                                            onchange="MaterialChange()">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                            autofocus OnClick="btnSearch_Report" Width="80px" />
                                    </div>
                                </asp:Panel>
                                <div class="clearfix">
                                </div>
                                <br />
                                <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                    color: #505b72;">
                                    <strong>Oops! No record found..</strong></div>
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
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Set Target">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSetTarget" CssClass="form-control" Text='<%# Eval("TARGET")%>'
                                                    runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                    ControlToValidate="txtSetTarget" runat="server" ErrorMessage="Only Numbers allowed"
                                                    ForeColor="Red" ValidationExpression="\d+">
                                                </asp:RegularExpressionValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="From Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" 
                                                    Text='<%#  Eval("FROM_DATE","{0:yyyy-MM-dd}")%>' ToolTip="From Date" TextMode="Date"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="To Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                                    Text='<%# Eval("TO_DATE","{0:yyyy-MM-dd}")%>' ToolTip="To Date" TextMode="Date"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Set Target">
                                            <ItemTemplate>
                                            <center>
                                                <asp:Button ID="btnSearch" runat="server" Text="Save" CssClass="btn btn-primary"
                                                    ValidationGroup="Save" CausesValidation="true" OnClick="btnSavetarget_Click"
                                                    Width="80px" />
                                                <asp:LinkButton ID="lnkDelete" runat="server" ForeColor="Red" OnClick="lnkDelete_Click"><i class="fa fa-close"></i></asp:LinkButton>
                                                </center>
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
