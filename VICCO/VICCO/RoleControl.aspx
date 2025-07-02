<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="RoleControl.aspx.cs" Inherits="VICCO.RoleControlaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function SuccessOk() {
            alertify.alert('Success', 'Role added successfully...!', function () { alertify.success(window.location = "RoleControl.aspx"); });
        }

        function UpdateOk() {
            alertify.alert('Success', 'Role updated successfully...!', function () { alertify.success(window.location = "RoleControl.aspx"); });
        }

        function Clearsearch() {
            $("input").val();
            $("input").val();
            $("input").val();
        }

    </script>

    <style>
        .scroll-panel
        {
            height: 200px;
            overflow: auto;
            background-color: #f0f1f4;
        }
        .scroll-panel table
        {
            width: 100%;
            border: none;
        }
        
        .scroll-panel table tr td
        {
            padding: 5px;
            padding-left: 10px;
            border: none;
        }
        
        .role table thead th
        {
           background-color: #f0f1f4;
           padding: 5px 10px;
           color:Black;
           border:none;
        }
        
        .search-box
        {
            position: absolute;
            top: -42px;
            width: 100%;
        }
        
        .search-box lable
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="RoleControl.aspx">Role Control</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Role Control</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide following information.</p>
                            <hr style="border-color: #fc8414;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="employeeList" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Employee List
                                    </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Employee List"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChange">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="auto_select1"
                                            InitialValue="0" Display="Dynamic" CssClass="error" ErrorMessage="Required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div id="Div1" class="form-group col-md-12">
                                    <label class="col-md-4 control-label">
                                        State Assignment <span class="text-danger">*</span></label>
                                    <label class="col-md-4 control-label">
                                        Stockiest Assignment <span class="text-danger">*</span></label>
                                    <label class="col-md-4 control-label">
                                        Distributor Assignment <span class="text-danger">*</span></label>
                                </div>
                                <div class="clearfix">
                                </div>
                                <br />
                                <div class="form-group col-md-12 role">
                                    <div class="col-md-4">
                                    <div>
                                        </div>
                                        <div class="scroll-panel">
                                        
                                            <asp:GridView ID="grdRoleRegion" runat="server" AutoGenerateColumns="false" DataKeyNames="REGION_ID">
                                                <Columns>
                                                    <asp:BoundField DataField="REGION_NAME" HeaderText="Select All" />
                                                    <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="" onclick="javascript:SelectAllCheckboxes(this);" />
                                                    </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" name="reg"  />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("EMPLOYEE_ID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <a href="#" Class="btn btn-primary btn-quirk mr5" onclick="Clearsearch()">Save</a>
                                         <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary btn-quirk mr5" style="display:none;"
                                            OnClick="btnSaveRegion" ValidationGroup="Save" />
                                    </div>
                                    <div class="col-md-4">
                                        <div class="scroll-panel">
                                            <asp:GridView ID="grdRoleStockist" runat="server" AutoGenerateColumns="false" DataKeyNames="STOCKIST_ID">
                                                <Columns>
                                                    <asp:BoundField DataField="STOCKIST_NAME" HeaderText="Select All" />
                                                    <asp:TemplateField>
                                                     <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="" onclick="javascript:SelectAllCheckboxesStockist(this);" />
                                                    </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("EMPLOYEE_ID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <asp:Button ID="Button2" runat="server" Text="Save" Class="btn btn-primary btn-quirk mr5" style="display:none;"
                                            OnClick="btnSaveStockist" ValidationGroup="Save" />
                                            <a href="#" Class="btn btn-primary btn-quirk mr5" onclick="Clearsearch1()">Save</a>
                                       <%-- <asp:Button ID="btnStockist" runat="server" Text="Save" CssClass="btn btn-primary btn-quirk mr5" OnClientClick="Clearsearch1()"
                                           ValidationGroup="Save" />--%>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="scroll-panel">
                                            <asp:GridView ID="grdRoleDistributor" runat="server" AutoGenerateColumns="false"
                                                DataKeyNames="DISTRIBUTOR_ID">
                                                <Columns>
                                                    <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Select All" />
                                                    <asp:TemplateField>
                                                     <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="" onclick="javascript:SelectAllCheckboxesDist(this);" />
                                                    </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                           <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("EMPLOYEE_ID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <asp:Button ID="Button3" runat="server" Text="Save" CssClass="btn btn-primary btn-quirk mr5" style="display:none;"
                                            OnClick="btnSaveDistributor" ValidationGroup="Save" />
                                            <a href="#" Class="btn btn-primary btn-quirk mr5" onclick="Clearsearch2()">Save</a>
                                        <%--<asp:Button ID="btnDistributor" runat="server" Text="Save" CssClass="btn btn-primary btn-quirk mr5" OnClientClick="Clearsearch2()"
                                           ValidationGroup="Save" />--%>
                                    </div>
                                </div>
                            </div>
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
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
<script type="text/javascript">

    function SelectAllCheckboxes(chk) {
        $('#<%=grdRoleRegion.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }

    function SelectAllCheckboxesStockist(chk) {
        $('#<%=grdRoleStockist.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }

    function SelectAllCheckboxesDist(chk) {
        $('#<%=grdRoleDistributor.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }

    function callbtn() {
        document.getElementById("<%=Button1.ClientID %>").click();
    }

    function callbtn1() {
        document.getElementById("<%=Button2.ClientID %>").click();
    }

    function callbtn2() {
        document.getElementById("<%=Button3.ClientID %>").click();
    }

</script>

</asp:Content>
