<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Stockist.aspx.cs" Inherits="VICCO.Stockist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function SuccessOk() {
            alertify.alert('Success', 'Stockist added successfully...!', function () { alertify.success(window.location = "Stockist.aspx"); });
        }

        function UpdateOk() {
            alertify.alert('Success', 'Stockist updated successfully...!', function () { alertify.success(window.location = "Stockist.aspx"); });
        }

        function WarningOk() {
            alertify.alert('Warning', 'Stockist already exists...!', function () { alertify.success('Ok'); });
        }

        function WarningCode() {
            alertify.alert('Warning', 'Stockist Code already exists...!', function () { alertify.success('Ok'); });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="Stockist.aspx">Add Super Stockist</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">Add New Super Stockist</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Super Stockist details.
                            </p>
                            <hr style="border-color: #fc8414;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="Stockistcode" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Stockist Code <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtStockistCode" runat="server" class="form-control" placeholder="Type your Super Stockist Code..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStockistCode"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Code required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="name" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Stockist Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtStockistName" runat="server" class="form-control" placeholder="Type your Super Stockist name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStockistName"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Stockist name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="address" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Address <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Type Stockist Address..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Stockist address required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="district" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        District <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDistrict" runat="server" class="form-control" placeholder="Type District Address..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDistrict"
                                            Display="Dynamic" CssClass="error" ErrorMessage="District required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="City" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        City <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="Type your City..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCity"
                                            Display="Dynamic" CssClass="error" ErrorMessage="City required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="pincode" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Pin code <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPincode" runat="server" class="form-control" placeholder="Type your Pincode..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPincode"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Pincode required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="Div6" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Stockist Region <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlRegion" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlRegion"
                                            InitialValue="0" Display="Dynamic" CssClass="error" ErrorMessage="Region required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="region" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Assign Region <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <select id="select2" class="form-control" runat="server" data-placeholder="Select Region" autocomplete="off"
                                            autocorrect="off"
                                            autocapitalize="none" multiple>
                                        </select>
                                        <%-- <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" multiple>                                            
                                        </asp:DropDownList>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="select2"
                                            InitialValue="" Display="Dynamic" CssClass="error" ErrorMessage="Region required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="phoneNo" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Phone No <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" placeholder="Phone No..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhoneNo"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Phone no required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div id="mobileNo" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Mobile No <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Mobile No..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMobileNo"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Mobile no required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                            ControlToValidate="txtMobileNo" ValidationExpression="[0-9]{10}" ForeColor="Red"
                                            runat="server" ErrorMessage="Please Enter Valid Mobile No"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="email" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Email <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" Display="Dynamic"
                                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div id="Country" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Country <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCountry" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="Div1" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Contact Person <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" placeholder="Contact Person"></asp:TextBox>
                                    </div>
                                </div>

                                <div id="Div2" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Pan<span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPan" runat="server" class="form-control" placeholder="PAN" Style="text-transform: uppercase;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="Div3" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        LST<span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtLst" runat="server" class="form-control" placeholder="LST"></asp:TextBox>
                                    </div>
                                </div>

                                <div id="Div4" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        GSTIN<span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtGstIn" runat="server" class="form-control" placeholder="GSTIN"
                                            Style="text-transform: uppercase;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="Div5" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        TPT<span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTPT" runat="server" class="form-control" placeholder="TPT"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="Paaword" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Password <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Password required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="Deactivate" runat="server" visible="false" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">Deactivate Stockist</label>
                                    <div class="col-md-8">
                                        <asp:CheckBox ID="chkDeactivate" runat="server" Style="margin-top: 12px;" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #fc8414;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="Material.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
</asp:Content>
