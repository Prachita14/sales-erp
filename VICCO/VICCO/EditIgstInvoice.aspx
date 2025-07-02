<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditIgstInvoice.aspx.cs" Inherits="VICCO.EditIgstInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Vicco Laboratories</title>
    <link rel="icon" href="images/loggeduser.png" type="img/jpg" />
    <link rel="stylesheet" href="../lib/Hover/hover.css" />
    <link rel="stylesheet" href="../lib/fontawesome/css/font-awesome.css" />
    <link rel="stylesheet" href="../lib/weather-icons/css/weather-icons.css" />
    <link rel="stylesheet" href="../lib/jquery-toggles/toggles-full.css" />
    <link rel="stylesheet" href="../lib/select2/select2.css" />
    <link rel="stylesheet" href="../lib/morrisjs/morris.css" />
    <link rel="stylesheet" href="../css/quirk.css?v=09.07.2019" />
    <link rel="stylesheet" href="../lib/jquery-ui/jquery-ui.css" />
    <script src="alertifyjs/alertify.js" type="text/javascript"></script>
    <link href="alertifyjs/css/alertify.css" rel="stylesheet" type="text/css" />
    <link href="alertifyjs/css/themes/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .control-label {
            padding-top: 10px;
        }

        .grid a {
            color: #505b72;
            font-weight: bold;
            font-size: 12px;
            padding-left: 5px;
        }

            .grid a:hover {
                color: #257bab;
            }

        .grid tr td {
            padding: 10px 5px !important;
        }

        .content {
            height: 560px;
        }

        .table td th tr {
            border: 1px solid black;
        }

        .supplierheading {
            color: #ffffff;
            background-color: #2574ab;
            border-color: #2574ab;
            padding-top: 10px;
            padding-bottom: 10px;
            border-bottom: 0;
            font-size: 16px;
        }

        .nomargin td {
            padding: 2px;
            vertical-align: middle !important;
        }

        .error {
            background: rgb(251, 227, 228);
            border: 1px solid #fbc2c4;
            color: #8a1f11;
            margin: 0 !important;
        }

        .qty {
            width: 10%;
        }

        .select2 {
            width: 100% !important;
        }

        .select2-container--default .select2-selection--single .select2-selection__arrow {
            height: 26px;
        }

        .modal-update {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background-color: White;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

        .invoicetable div:first-child {
            width: 100%;
            overflow: auto;
        }
         .select2-container--disabled{
            width:100% !important;
        }
    </style>
    <script type="text/javascript">


       <%-- function getNextButton(btnid) {

            if (btnid.id == "Finish") {
                document.getElementById("<%=Button1.ClientID %>").click();
            }
        }--%>

        function WarningOk() {
            alertify.alert('Warning', 'Invoice No already exists...!', function () { alertify.success('Ok'); });
        }

        function SuccessOk() {
            alertify.alert('Success', 'Invoice Update Successfully...!', function () { alertify.success(window.location = "SupperInvoice.aspx"); });
        }

        function StockWarning() {
            alertify.alert('Warning', 'Stock not available for selected product..!', function () { alertify.success('Ok'); });
        }

    </script>
    <script type="text/javascript">
        function customOpen(url) {
            alertify.alert('Success', 'Invoice Update Successfully...!', function () { window.open(url, '_blank'); window.top.close(); });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section>
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Create Invoice</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div id="pono" class="form-group col-md-4">
                                    <label class="col-md-4 control-label">
                                        Invoice No</label>
                                    <div class="col-md-8">
                                            <asp:TextBox ID="txtPoNo" runat="server" CssClass="form-control" placeholder="Enter Invoice no" ></asp:TextBox>                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Invoice no Required..." ValidationGroup="check1"
                                            ControlToValidate="txtPoNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                          
                                            <asp:Label ID="lblPurchaseOederid" runat="server" Visible="false"></asp:Label>    
                                         <asp:Label ID="lblStockistid" runat="server" Visible="false"></asp:Label>  
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                                <div id="date" class="form-group col-md-4">
                                    <label class="col-md-4 control-label">
                                        Date
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCalender" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                      
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date Required..." ValidationGroup="check1"
                                            ControlToValidate="txtCalender" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>                               
                                <div id="Toname" class="form-group col-md-4">
                                    <label class="col-md-4 control-label">
                                        Client Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Client Name" >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Client Name Required..." ValidationGroup="check1"
                                            ControlToValidate="auto_select1" InitialValue="0" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <asp:HiddenField ID="hidHSNCode" runat="server" />
                            <div class="panel-body" style="padding-left:0; padding-right:0;" >
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                                        <ContentTemplate>
                                        <div class="invoicetable">
                                            <asp:GridView ID="grdProduct" runat="server" CssClass="table table-primary nomargin grid" AutoGenerateColumns="false" style="display:block;"
                                                Width="1500px" DataKeyNames="PURCHES_ORDER_PRODUCT_ID" BorderStyle="None" OnRowDataBound="grdProduct_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" ItemStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PARTICULAR" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'
                                                                Style="display: none;"></asp:Label>
                                                            <asp:Label ID="lblProduct_id" runat="server" Text='<%# Eval("MATERIAL_ID")%>' Style="display: none;"></asp:Label>
                                                            <asp:DropDownList ID="auto_selectProduct" runat="server" data-placeholder="Select Product"
                                                                AutoPostBack="true" OnSelectedIndexChanged="Product_SelectedIndexChange"  ValidationGroup="check">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="HSN CODE" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtHsnCode" runat="server" CssClass="form-control" Text='<%# Eval("UNIT")%>'
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="STOCK IN PCS" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAvailableQty" runat="server" CssClass="form-control" ReadOnly="true" Text='<%# Eval("AVAILABLE_QTY")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="QTY. IN PCS" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("QTY")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange" CausesValidation="true" ValidationGroup="check"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtQty" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"  ValidationGroup="check"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="9%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("RATE")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange" CausesValidation="true" ValidationGroup="check"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"  ValidationGroup="check"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SCHEME IN %" HeaderStyle-Width="9%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtScheme" runat="server" Text='<%# Eval("SCHEME")%>' CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="ProductContent_TextChange" CausesValidation="true" ValidationGroup="check"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtScheme" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"  ValidationGroup="check"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DIS. IN %" HeaderStyle-Width="9">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDiscount" runat="server" Text='<%# Eval("DISCOUNT")%>' CssClass="form-control"
                                                                CausesValidation="true" AutoPostBack="true" OnTextChanged="ProductContent_TextChange"  ValidationGroup="check"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtDiscount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"  ValidationGroup="check"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Invalid Disc."
                                                                ForeColor="Red" Type="Double" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtDiscount"  ValidationGroup="check"
                                                                MinimumValue="0.00" MaximumValue="99.00"></asp:RangeValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="9%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("AMOUNT")%>' CssClass="form-control"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IGST" HeaderStyle-Width="6%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtIGST" runat="server" Text='<%# Eval("IGST")%>' CssClass="form-control"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SUB TOTAL" HeaderStyle-Width="9%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSubtotal" runat="server" Text='<%# Eval("SUB_TOTAL")%>' CssClass="form-control"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="RemoveProduct" ForeColor="#FF5722"
                                                                CausesValidation="false">x</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                             <div class="clearfix"></div>
                                             <br />
                                            <div class="col-md-5">
                                                <br />
                                                <div id="Div3" class="form-group col-md-12">
                                                    <label class="col-md-3 control-label">
                                                        Sales Officer
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlSalesOfficer" runat="server" class="form-control"  data-placeholder="Sales Officer" >
                                                            <asp:ListItem Value="0">Sales Officer</asp:ListItem>
                                                        </asp:DropDownList>                                                        
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSalesOfficer" ValidationGroup="check1"
                                                            Display="Dynamic" ErrorMessage="Sales Officer required..." ForeColor="Red" InitialValue="0" ></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div id="deliveryPeriod" class="form-group col-md-12">
                                                    <label class="col-md-3 control-label">
                                                        Transporter
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtDelieveryPeriod" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="Div1" class="form-group col-md-12">
                                                    <label class="col-md-3 control-label">
                                                        Vehicle
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtVehicle" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                            <div class="col-md-3"></div>
                                            <div class="col-md-4">
                                             <div id="Div4" class="form-group col-md-12" style="font-weight:bold !important;" >
                                                    <label class="col-md-4 control-label">
                                                       <strong>Grand Total</strong>
                                                    </label>
                                                    <div class="col-md-8">
                                                          <asp:TextBox ID="txtGrandTotal" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="Div2" class="form-group col-md-12">
                                                    <label class="col-md-4 control-label">
                                                        No Of Cases
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtNoOfCases" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="note" class="form-group col-md-12">
                                                    <label class="col-md-4 control-label">
                                                        LR No
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtNote" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                                <div class="table-responsive">
                                                    <table class="table table-bordered nomargin" style="padding: 10px;font-weight:bold !important; background-color:white; ">
                                                        <tr>
                                                            <td>
                                                                Grand Total
                                                            </td>
                                                            <td colspan="2">
                                                              
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                         <ProgressTemplate>
                                            <div class="modal-update">
                                               <div class="center">
                                                 <center>
                                                     <img src="../images/loading.gif" />
                                                 </center>
                                               </div>
                                            </div>
                                         </ProgressTemplate>
                                     </asp:UpdateProgress>
                                     <div class="clearfix"></div>
                                    <hr />
                                    <div class="col-md-12">                                        
                                        <asp:HiddenField ID="HidWizardState" runat="server" />
                                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="btn btn-primary" OnClientClick="return Validate()" CausesValidation="true"
                                            Width="100px" />
                                        <!-- table-responsive -->
                                    </div>
                                </div>
                                <!-- table-responsive -->
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <!-- col-md-12 -->
        </div>   
    </section>
    </form>
    <script src="js/jquery-3.3.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/jquery-ui/jquery-ui.js"></script>
    <script type="text/javascript" src="../lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript" src="../lib/jquery-toggles/toggles.js"></script>
    <script type="text/javascript" src="../js/quirk.js"></script>
    <script type="text/javascript" src="../lib/jquery-autosize/autosize.js"></script>
    <script type="text/javascript" src="../lib/select2/select2.js"></script>
    <script type="text/javascript">
        $(function () {
            $("select").select2({ tags: false });
        });

        function auto() {
            $("select").select2({ tags: false });
        };
    </script>
    <script type="text/javascript">
        function Validate() {
            var isValid = false;
            if (Page_ClientValidate('check') == true && Page_ClientValidate('check1') == true) {
                isValid = true;
            }


            return isValid;
        }
    </script>
</body>
</html>
