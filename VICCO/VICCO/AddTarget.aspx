<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="AddTarget.aspx.cs" Inherits="VICCO.AddTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
     function WarningOk() {
         alertify.alert('Warning', 'selected file not in format, please check it and retry again...!', function () { alertify.success('Ok'); });
     }

     function WarningMsgOk(msg) {
         alertify.alert('Warning', msg, function () { alertify.success('Ok'); });
     }

     function SuccessOk() {
         alertify.error('File uploaded...');
     } 
    </script>

    <style type="text/css">
        .fileUpload input
        {
            position: absolute;
            top: 0;
            margin: 0;
            padding: 0;
            font-size: 20px;
            cursor: pointer;
            opacity: 0;
            filter: alpha(opacity=0);
        }
        .panel-body
        {
            text-transform: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="#">Upload Target</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Upload Target</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row">
                                <div class="col-md-2">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Year">
                                        <asp:ListItem>Select To Year</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select To Year"
                                        ErrorMessage="Year Required..." ControlToValidate="auto_select1" Display="Dynamic"
                                        CssClass="error" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-10">
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkJan" name="checkbox" runat="server" />
                                        <span>Jan</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkFeb" name="checkbox" runat="server" />
                                        <span>Feb</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkMar" name="checkbox" runat="server" />
                                        <span>Mar</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkApr" name="checkbox" runat="server" />
                                        <span>Apr</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkMay" name="checkbox" runat="server" />
                                        <span>May</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkJun" name="checkbox" runat="server" />
                                        <span>Jun</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkJuly" name="checkbox" runat="server" />
                                        <span>July</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkAug" name="checkbox" runat="server" />
                                        <span>Aug</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkSep" name="checkbox" runat="server" />
                                        <span>Sep</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkOct" name="checkbox" runat="server" />
                                        <span>Oct</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkNov" name="checkbox" runat="server" />
                                        <span>Nov</span>
                                    </label>
                                    <label class="ckbox">
                                        <input type="checkbox" id="chkDec" name="checkbox" runat="server" />
                                        <span>Dec</span>
                                    </label>
                                </div>
                                <div class="clearfix"></div>
                                <br />
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-2 form-group">
                                    <div class="fileUpload btn btn-default" style="color: #ffffff !important; background-color: #505b72 !important;
                                        border-color: #505b72 !important;">
                                        <span><i class="fa fa-upload"></i> Select Excel File</span>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-secondary" />
                                    </div>
                                </div>
                                <div class="col-md-1 form-group">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary"
                                        OnClick="btnUploadTarget" Width="80px" />
                                </div>
                            </div>
                            <h4 class="mt20">
                                Please make sure your file in below format</h4>
                            <hr />
                            <p class="nomargin nopadding">
                                1. Your EXCEL data should be in the format below. The first line of your EXCEL file
                                should be the column headers as in the table example. Also make sure that your file
                                is UTF-8 to avoid unnecessary encoding problems.</p>
                            <p class="nomargin nopadding">
                                2. If the column you are trying to import is date make sure that is formatted in
                                format Y-m-d (2019-06-06) or (6 Jun 2018).</p>
                            <p class="nomargin nopadding">
                                3. If the column is Numeric make sure value should be in numeric format.</p>
                            <p class="nomargin nopadding">
                                4. If the column value come from master table make sure that value should be match
                                with portal master table value.</p>
                            <p class="nomargin nopadding">
                                5. Master table value come from multiple places - <a href="MaterialReport.aspx">Material
                                    code</a>, <a href="DistributorReport.aspx">Distributor code</a>
                            </p>
                            <br />
                            <br />
                            <div class="table-responsive">
                                <table class="table nomargin table-bordered">
                                    <thead>
                                        <tr>
                                            <td class="text-center" style="vertical-align: middle;">
                                                Distributor_Code
                                            </td>
                                            <td class="text-center" style="vertical-align: middle;">
                                                DOM01200-20OFF
                                            </td>
                                            <td class="text-center" style="vertical-align: middle;">
                                                DOM01150-15OFF
                                            </td>
                                            <td class="text-center" style="vertical-align: middle;">
                                                ----------------------------------
                                            </td>
                                            <td class="text-center" style="vertical-align: middle;">
                                                DOM01020R
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
