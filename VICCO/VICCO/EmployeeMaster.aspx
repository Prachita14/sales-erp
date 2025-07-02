<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="EmployeeMaster.aspx.cs" Inherits="VICCO.EmployeeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">     

        function SuccessOk() {
            alertify.alert('Success', 'Employee added successfully...!', function () { alertify.success(window.location = "EmployeeMaster.aspx"); });
        }

        function UpdateOk() {
            alertify.alert('Success', 'Employee updated successfully...!', function () { alertify.success(window.location = "EmployeeMasterReport.aspx"); });
        }

        function WarningOk() {
            alertify.alert('Warning', 'Material already exists...!', function () { alertify.success('Ok'); });
        }

        function WarningCodeOk() {
            alertify.alert('Warning', 'Material code already exists...!', function () { alertify.success('Ok'); });
        }

    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="EmployeeMaster.aspx">Employee Master</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Employee Master</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide employee information.</p>
                            <hr style="border-color: #fc8414;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="designation" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Designation <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Designation" AutoPostBack="true" OnSelectedIndexChanged="DesignationChange">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="auto_select1"
                                            InitialValue="0" Display="Dynamic" CssClass="error" ErrorMessage="Designation required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Div1" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Parent </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="auto_select2" runat="server" class="form-control" data-placeholder="Designation">
                                        </asp:DropDownList>                                        
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <hr style="border-color: #CCCCCC;" />
                                <div id="materialcode" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Employee Code
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmployeeCode" runat="server" class="form-control" ReadOnly="true"
                                            placeholder="Type your Employee Code..."></asp:TextBox>
                                    </div>
                                </div>

                                <div id="name" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Employee Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control" placeholder="Type your Employee name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeName"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Employee name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                
                                <div id="email" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Email <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Type Email Id..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Email Id required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="Div2" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Joining Date <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtJoindate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtJoindate" Display="Dynamic"
                                            CssClass="error" ErrorMessage="Joining date required..." ValidationGroup="Save"></asp:RequiredFieldValidator>                                      
                                    </div>
                                </div>
                               
                                <div id="Password" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Password</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Type password..."
                                            Text="1234" ></asp:TextBox>
                                    </div>
                                </div>
                                <div id="Div3" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Deactivate Date </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDeactiveDate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>                                                                    
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #fc8414;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                     ValidationGroup="Save" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
                                    <a href="EmployeeMaster.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
