<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="SelectionCriteriaStockiest.aspx.cs" Inherits="VICCO.SelectionCriteriaStockiest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function Saveclick() {

            if ($("#ContentPlaceHolder1_txtDistrict").val() == '') {
                $("#District").addClass("has-error");
            }
            else {
                $("#District").removeClass("has-error");
            }

            if ($("#ContentPlaceHolder1_txtTown").val() == '') {
                $("#Town").addClass("has-error");
            }
            else {
                $("#Town").removeClass("has-error");
            }

            if ($("#ContentPlaceHolder1_txtSales").val() == '') {
                $("#Sales").addClass("has-error");
            }
            else {
                $("#Sales").removeClass("has-error");
            }

            if ($("#ContentPlaceHolder1_txtdatefromto").val() == '') {
                $("#Date").addClass("has-error");
            }
            else {
                $("#Date").removeClass("has-error");
            }
        }

        function SuccessOk() {
            alertify.alert('Success', 'Criteria added successfully...!', function () { alertify.success(window.location = "SelectionCriteriaStockiest.aspx"); });
        }

        function UpdateOk() {
            alertify.alert('Success', 'Criteria updated successfully...!', function () { alertify.success(window.location = "SelectionCriteriaStockiest.aspx"); });
        }    

    </script>
    <style type="text/css">
        .control-label
        {
            padding-top: 10px;
        }
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="SelectionCriteriaAdmin.aspx">Selection Criteria </a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Selection Criteria</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Criteria Details.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="District" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        District <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDistrict" runat="server" class="form-control" placeholder="District Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDistrict"
                                            Display="None" CssClass="error" ErrorMessage="District required..." ValidationGroup="Save1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Town" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Town <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTown" runat="server" class="form-control" placeholder="Town Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDistrict"
                                            Display="None" CssClass="error" ErrorMessage="Town required..." ValidationGroup="Save1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Distributor" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Distributor <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Distributor Name"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="auto_select1"
                                            Display="Dynamic" InitialValue="0" CssClass="error" ErrorMessage="Distributor Name required..."
                                            ValidationGroup="Save1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Sales" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Sales Officer <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSales" runat="server" class="form-control" placeholder="Sales Officer Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDistrict"
                                            Display="None" CssClass="error" ErrorMessage="Sales Officer required..." ValidationGroup="Save1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Date" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        From To Date<span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdatefromto" runat="server" class="form-control" placeholder="From To Date" TextMode="Date"></asp:TextBox>
                                        <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd MMM yyyy"
                                            TargetControlID="txtdatefromto">
                                        </asp:CalendarExtender>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDistrict"
                                            Display="None" CssClass="error" ErrorMessage=" Date From To required..." ValidationGroup="Save1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick()" ValidationGroup="Save1" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
                                    <a href="SelectionCriteriaStockiest.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
                                </div>
                            </div>
                        </div>
                        <!-- panel-body -->
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <!-- panel -->
                <!-- col-md-6 -->
            </div>
        </div>
        <!-- contentpanel -->
    </div>
</asp:Content>
