<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="UploadCsv.aspx.cs" Inherits="VICCO.UploadCsv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function WarningOk() {
            alertify.alert('Warning', 'selected file not in format, please check it and retry again...!', function () { alertify.success('Ok'); });
        }

        function WarningMsgOk(msg) {
            alertify.alert('Warning', msg, function () { alertify.success('Ok'); });
        }

        function SuccessOk() {
            alertify.error('CSV File uploaded...');
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
            text-transform:none !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="#">Upload CSV</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Upload CSV</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-2 form-group">
                                    <div class="fileUpload btn btn-default" style="color: #ffffff !important; background-color: #505b72 !important; border-color: #505b72 !important;">
                                        <span><i class="fa fa-upload"></i> Select Excel File</span>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-secondary" />
                                    </div>
                                </div>
                                <div class="col-md-1 form-group">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary"
                                        OnClick="btnUploadCSV" Width="100px" />
                                </div>
                            </div>
                            <h4 class="mt20" >
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
                                    code</a>, <a href="DistributorReport.aspx">Distributor code</a>, <a href="StockistReport.aspx">
                                        Supper Stockist code</a>
                            </p>
                            <br />
                            <br />
                            <asp:Panel ID="PanelDispatch" runat="server" Visible="false">
                                <div class="table-responsive">
                                    <table class="table nomargin table-bordered">
                                        <thead>
                                            <tr>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Id
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Super_Stockist_Code
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Super_Stockist_Name
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Tax_Invoice_no
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    LineItem
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Dispatch_Date
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Dispatch_Note_no
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Item_Code
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Item_Description
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Batch_Number
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Shipped_Quantity
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Billed_Quantity
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Rate
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Scheme
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Add_Disc
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Total
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Created_By
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
                            </asp:Panel>
                            <asp:Panel ID="PanelInitial" runat="server" Visible="false">
                                <div class="table-responsive">
                                    <table class="table nomargin table-bordered">
                                        <thead>
                                            <tr>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Id
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Super_Stockist_Code
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Super_Stockist_Name
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Tax_Invoice_no
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    LineItem
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Dispatch_Date
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Dispatch_Note_no
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Item_Code
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Item_Description
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Batch_Number
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Shipped_Quantity
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Billed_Quantity
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Rate
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Scheme
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Add_Disc
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Total
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    Created at
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
                            </asp:Panel>
                            <asp:Panel ID="PanelMaterial" runat="server" Visible="false">
                                <div class="table-responsive">
                                    <table class="table nomargin table-bordered">
                                        <thead>
                                            <tr>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MATERIAL_CODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MATERIAL_NAME
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MATERIAL_UOM_QTY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MATERIAL_UOM_UNIT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    ALTERNATIVE_UOM_QTY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    GROSS_WEIGHT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    NET_WEIGHT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    SGST
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    CGST
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    HSN_CODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MATERIAL_GROUP
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
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelStokist" runat="server" Visible="false">
                                <div class="table-responsive">
                                    <table class="table nomargin table-bordered">
                                        <thead>
                                            <tr>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    STOCKIST_CODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    STOCKIST_NAME
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    ADDRESS
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    DISTRICT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PINCODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    REGION
                                                </td>

                                                <td class="text-center" style="vertical-align: middle;">
                                                    PHONE_NUMBER
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MOBILE_NUMBER
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    COUNTRY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    CITY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    CONTACT_PERSON
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    EMAIL
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PASSWORD
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PAN
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    LST
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    GSTIN
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    TPT
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
                            </asp:Panel>
                            <asp:Panel ID="PanelDistributor" runat="server" Visible="false">
                                <div class="table-responsive">
                                    <table class="table nomargin table-bordered">
                                        <thead>
                                            <tr>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    DISTRIBUTOR_CODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    DISTRIBUTOR_NAME
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    STOCKIST_CODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    ADDRESS
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    DISTRICT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PINCODE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    REGION
                                                </td>
                                                 <td class="text-center" style="vertical-align: middle;">
                                                   STATE
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PHONE_NUMBER
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    MOBILE_NUMBER
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    COUNTRY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    CITY
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    CONTACT_PERSON
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    EMAIL
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    PAN
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    LST
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    GSTIN
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    TPT
                                                </td>
                                                <td class="text-center" style="vertical-align: middle;">
                                                    DISTRIBUTOR_TYPE
                                                </td>
                                                 <td class="text-center" style="vertical-align: middle;">
                                                    IS_ACTIVE
                                                </td>
                                                 <td class="text-center" style="vertical-align: middle;">
                                                    DEACTIVE_DATE
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
                                                    Retail Distributor,<br />
                                        Wholesale Distributor,<br />
                                        Modern Trade Distributor
                                                </td>
                                                <td>
                                                    True/False
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </asp:Panel>
                            <br />
                            <br />
                            <center>
                                <div class="col-md-12 row" style="margin-bottom: 30px;">
                                    <asp:HyperLink ID="HyperLink1" runat="server"><i class="fa fa-download"></i> Download CSV Format</asp:HyperLink>
                                </div>
                            </center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
