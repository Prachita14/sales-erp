<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Uplodedtarget.aspx.cs" Inherits="VICCO.Uplodedtarget" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function WarningOk() {
            alertify.error('No record found...');
        }
    </script>
    <script type="text/javascript">

        var selected_material_id = [];
        var selected_material_name = [];

        function AssignMaterialId(id, name) {
            selected_material_id.push(id);
            selected_material_name.push(name);
        }

        function MaterialChange() {

            var e = document.getElementById("ContentPlaceHolder1_Ddlmaterial");
            var Material_name = e.options[e.selectedIndex].text;
            var Material_id = e.options[e.selectedIndex].value;

            if (Material_name == "Material Name") {
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

            var e = document.getElementById("ContentPlaceHolder1_auto_select1");
            var Material_name = e.options[id].text;

            selected_material_id.remove(id);
            $('#ContentPlaceHolder1_hdMaterialId').val(selected_material_id);

            selected_material_name.remove(Material_name);
            $('#ContentPlaceHolder1_HiddenField1').val(selected_material_name);
        }

    </script>
    <style type="text/css">
        .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 10px 10px !important;
        }

        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
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
                            <h4 class="panel-title">Material Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" id="ShowSelectedMaterial" runat="server">
                            </div>
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <asp:HiddenField ID="hdMaterialId" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlMaterialGroup" runat="server" class="form-control" data-placeholder="Material Group"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_Change">
                                    </asp:DropDownList><%----%>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="Ddlmaterial" runat="server" class="form-control" data-placeholder="Material Name"
                                        onchange="MaterialChange()">
                                    </asp:DropDownList>
                                </div>
                                
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
                                    <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Distributor Name">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select3" runat="server" class="form-control" data-placeholder="Month">
                                        <asp:ListItem Value="0">Select Month</asp:ListItem>
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                        ErrorMessage="Month Required..." ControlToValidate="auto_select3" Display="Dynamic"
                                        CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select6" runat="server" class="form-control" data-placeholder="Year">
                                        <asp:ListItem>Select To Year</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select To Year"
                                        ErrorMessage="Year Required..." ControlToValidate="auto_select6" Display="Dynamic"
                                        CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                         </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        OnClick="btnSearch_Criteria" Width="100px" />
                                </div>

                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="size" style="margin-top: 20px;">
                                <div class="table-responsive role">
                                    <div id="errorMsg" visible="false" runat="server" class="alert alert-warning" style="background-color: #d8dce3; color: #505b72;">
                                        <strong>Opps! No record found..</strong>
                                    </div>
                                    <div class="col-md-4 nopadding" runat="server" id="deletebtn" visible="false">
                                        <asp:Button ID="Button2" runat="server" Text="Delete Selected" CssClass="btn btn-danger"
                                            OnClick="btndeletetarget" Style="padding: 5px 10px;" />
                                        <%--<asp:Button ID="btnExel" runat="server" Text="Exel" CssClass="btn btn-info" style="padding:5px 10px;margin-left:10px" OnClick="btnExel_Click"/>--%>
                                        <a href="UploadedTargetExcel.aspx" target="_blank" id="btnExel" class="btn btn-primary" style="padding:5px 10px;margin-left:10px" >Exel</a>

                                    </div>
                                    <asp:GridView ID="grdReport1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="table nomargin table-primary grid" DataKeyNames="ID">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label99" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_CODE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Distributor">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSgst" runat="server" Font-Bold="false" Text='<%# Eval("DISTRIBUTOR")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Target">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTarget" runat="server" Font-Bold="false" Text='<%# Eval("TARGET")%>'></asp:Label>
                                                    <asp:TextBox ID="txtTarget" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="updateRecord" TextMode="Number" Visible="false" Text='<%# Eval("TARGET")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="For Month">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("MONTH", "{0:MMM}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("YEAR")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkedit" runat="server" CssClass="text-danger" OnClick="editclick"><i class="fa fa-pencil"></i> </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                } else {
                    $(this).removeAttr("checked");
                }
            });
        });

        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                chkHeader.removeAttr("checked");
            } else {
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });

    </script>
</asp:Content>
