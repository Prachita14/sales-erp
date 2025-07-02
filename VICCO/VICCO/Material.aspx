<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Material.aspx.cs" Inherits="RCandJJ.Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function SuccessOk() {
        alertify.alert('Success', 'Material added successfully...!', function () { alertify.success(window.location = "Material.aspx"); });
    }

    function UpdateOk() {
        alertify.alert('Success', 'Material updated successfully...!', function () { alertify.success(window.location = "Material.aspx"); });
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
                <li><a href="Material.aspx">Add Material</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Material</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Material information.</p>
                            <hr style="border-color: #fc8414;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="materialcode" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Material Code <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMaterialCode" runat="server" class="form-control" placeholder="Type your Material Code..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMaterialCode"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Material code required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="name" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Material Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMaterialName" runat="server" class="form-control" placeholder="Type your Material name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaterialName"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Material name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Div1" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Short Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtshortname" runat="server" class="form-control" placeholder="Type your Short name ..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtshortname"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Short name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Div3" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Material Group <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtgroupname" runat="server" class="form-control" placeholder="Type your Group name .."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtgroupname"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Group name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="material_qty" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Material UOM QTY <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtUOMQty" runat="server" class="form-control" placeholder="Type your Material UOM QTY..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUOMQty"
                                            Display="Dynamic" CssClass="error" ErrorMessage="UMO Qty required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Qty."
                                            SetFocusOnError="true" ControlToValidate="txtUOMQty" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="Div2" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        UOM Unit <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlUomUnit" runat="server" class="form-control">
                                            <asp:ListItem Value="Unit of Measurement">Unit of Measurement</asp:ListItem>
                                            <asp:ListItem Value=" BAG">BAG</asp:ListItem>
                                            <asp:ListItem Value=" CS">CS</asp:ListItem>
                                            <asp:ListItem Value=" EA">EA</asp:ListItem>
                                            <asp:ListItem Value=" EE">EE</asp:ListItem>
                                            <asp:ListItem Value=" EML">EML</asp:ListItem>
                                            <asp:ListItem Value=" FT">FT</asp:ListItem>
                                            <asp:ListItem Value=" IN2">IN2</asp:ListItem>
                                            <asp:ListItem Value=" IN3">IN3</asp:ListItem>
                                            <asp:ListItem Value=" KMN">KMN</asp:ListItem>
                                            <asp:ListItem Value=" KMS">KMS</asp:ListItem>
                                            <asp:ListItem Value=" LPH">LPH</asp:ListItem>
                                            <asp:ListItem Value=" MHZ">MHZ</asp:ListItem>
                                            <asp:ListItem Value=" MEJ">MEJ</asp:ListItem>
                                            <asp:ListItem Value=" MON">MON</asp:ListItem>
                                            <asp:ListItem Value=" N">N</asp:ListItem>
                                            <asp:ListItem Value=" NM">NM</asp:ListItem>
                                            <asp:ListItem Value=" PAK">PAK</asp:ListItem>
                                            <asp:ListItem Value=" ACR">ACR</asp:ListItem>
                                            <asp:ListItem Value=" BAR">BAR</asp:ListItem>
                                            <asp:ListItem Value=" CM">CM</asp:ListItem>
                                            <asp:ListItem Value=" CMH">CMH</asp:ListItem>
                                            <asp:ListItem Value=" DEG">DEG</asp:ListItem>
                                            <asp:ListItem Value=" DM">DM</asp:ListItem>
                                            <asp:ListItem Value=" CDM">CDM</asp:ListItem>
                                            <asp:ListItem Value=" DZ">DZ</asp:ListItem>
                                            <asp:ListItem Value=" OZA">OZA</asp:ListItem>
                                            <asp:ListItem Value=" FT2">FT2</asp:ListItem>
                                            <asp:ListItem Value=" FT3">FT3</asp:ListItem>
                                            <asp:ListItem Value=" G">G</asp:ListItem>
                                            <asp:ListItem Value=" GM">GM</asp:ListItem>
                                            <asp:ListItem Value=" GLL">GLL</asp:ListItem>
                                            <asp:ListItem Value=" GRO">GRO</asp:ListItem>
                                            <asp:ListItem Value=" H">H</asp:ListItem>
                                            <asp:ListItem Value=" HPA">HPA</asp:ListItem>
                                            <asp:ListItem Value=" HL">HL</asp:ListItem>
                                            <asp:ListItem Value=" STD">STD</asp:ListItem>
                                            <asp:ListItem Value=" ST">ST</asp:ListItem>
                                            <asp:ListItem Value=" KHZ">KHZ</asp:ListItem>
                                            <asp:ListItem Value=" KJ">KJ</asp:ListItem>
                                            <asp:ListItem Value=" KG">KG</asp:ListItem>
                                            <asp:ListItem Value=" KGM">KGM</asp:ListItem>
                                            <asp:ListItem Value=" KGS">KGS</asp:ListItem>
                                            <asp:ListItem Value=" KM">KM</asp:ListItem>
                                            <asp:ListItem Value=" KMH">KMH</asp:ListItem>
                                            <asp:ListItem Value=" KT">KT</asp:ListItem>
                                            <asp:ListItem Value=" KWH">KWH</asp:ListItem>
                                            <asp:ListItem Value=" LB">LB</asp:ListItem>
                                            <asp:ListItem Value=" M">M</asp:ListItem>
                                            <asp:ListItem Value=" MTS">MTS</asp:ListItem>
                                            <asp:ListItem Value=" M/S">M/S</asp:ListItem>
                                            <asp:ListItem Value=" MG">MG</asp:ListItem>
                                            <asp:ListItem Value=" MI">MI</asp:ListItem>
                                            <asp:ListItem Value=" MIN">MIN</asp:ListItem>
                                            <asp:ListItem Value=" ML">ML</asp:ListItem>
                                            <asp:ListItem Value=" MM">MM</asp:ListItem>
                                            <asp:ListItem Value=" MS">MS</asp:ListItem>
                                            <asp:ListItem Value=" TON">TON</asp:ListItem>
                                            <asp:ListItem Value=" VAL">VAL</asp:ListItem>
                                            <asp:ListItem Value=" YD">YD</asp:ListItem>
                                            <asp:ListItem Value=" GC">GC</asp:ListItem>
                                            <asp:ListItem Value=" FA">FA</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlUomUnit"
                                            InitialValue="Unit of Measurement" Display="Dynamic" CssClass="error" ErrorMessage="Material unit required..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="alternative_qty" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Alt. UOM QTY <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAlternativeUOMQty" runat="server" class="form-control" placeholder="Type your Alternative Material UOM QTY..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAlternativeUOMQty"
                                            Display="Dynamic" CssClass="error" ErrorMessage="UMO Qty required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Qty."
                                            SetFocusOnError="true" ControlToValidate="txtAlternativeUOMQty" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="alternative_unit" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Alt. UOM Unit <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAlternativeUomUnit" runat="server" class="form-control" placeholder="Alternative UOM Unit"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAlternativeUomUnit"
                                            Display="Dynamic" CssClass="error" ErrorMessage="UOM Unit required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="sgst" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        SGST <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSGST" runat="server" class="form-control" placeholder="SGST"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSGST"
                                            Display="Dynamic" CssClass="error" ErrorMessage="SGST required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid SGST."
                                            SetFocusOnError="true" ControlToValidate="txtSGST" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="cgst" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        CGST <span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCgst" runat="server" class="form-control" placeholder="CGST"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCgst"
                                            Display="Dynamic" CssClass="error" ErrorMessage="CGST required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid CGST."
                                            SetFocusOnError="true" ControlToValidate="txtCgst" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div id="gross_weight" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Gross Weight <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtGrossWeight" runat="server" class="form-control" placeholder="Gross Weight"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGrossWeight"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Gross weight required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Weight."
                                            SetFocusOnError="true" ControlToValidate="txtGrossWeight" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="Net_weight" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Net Weight <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtNetWeight" runat="server" class="form-control" placeholder="Net Weight"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNetWeight"
                                            Display="Dynamic" CssClass="error" ErrorMessage="Net weight required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Weight."
                                            SetFocusOnError="true" ControlToValidate="txtNetWeight" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="hsn_code" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        HSN Code <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtHsnCode" runat="server" class="form-control" placeholder="HSN Code"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHsnCode"
                                            Display="Dynamic" CssClass="error" ErrorMessage="HSN required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="Div4" class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        MRP <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMrp" runat="server" class="form-control" placeholder="MRP"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Mrp Rate."
                                            SetFocusOnError="true" ControlToValidate="txtMrp" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
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
