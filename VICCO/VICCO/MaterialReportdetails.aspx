<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialReportdetails.aspx.cs" Inherits="VICCO.MaterialReportdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
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
    <link rel="stylesheet" href="../lib/jquery.steps/jquery.steps.css" />
    <link rel="stylesheet" href="../lib/jquery-ui/jquery-ui.css" />
    
   <link rel="stylesheet" href="../lib/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" />

    
</head>
<body>
    <form id="form1" runat="server">
    <section>
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="MaterialReport.aspx">Material Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Material Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMaterialCode" CssClass="form-control" runat="server" placeholder="Material Code"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Material Name">
                                    </asp:DropDownList>
                                </div>                                
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_material"
                                        Width="80px"/>
                                </div>                               
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="size">
                            <div class="table-responsive">
                             <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Opps! No record found..</strong>
                            </div>
                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="table nomargin table-primary grid" 
                                     DataKeyNames="MATERIAL_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material Group">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_GROUP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material UOM Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_UOM_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Material UOM Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_UOM_UNIT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Alt. UOM Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("ALTERNATIVE_UOM_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Alt. UOM Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("ALTERNATIVE_UOM_UNIT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Gross Weight">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("GROSS_WEIGHT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Net Weight">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("NET_WEIGHT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSgst" runat="server" Font-Bold="false" Text='<%# Eval("SGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCgst" runat="server" Font-Bold="false" Text='<%# Eval("CGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="MRP">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("MRP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="HSN Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("HSN_CODE")%>'></asp:Label>
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
    </section>
    </form>

    <script src="js/jquery-3.3.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/jquery-ui/jquery-ui.js"></script>
    <script type="text/javascript" src="../lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript" src="../lib/jquery-toggles/toggles.js"></script>
    <script type="text/javascript" src="../lib/datatables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../lib/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="../lib/morrisjs/morris.js"></script>
    <script type="text/javascript" src="../lib/raphael/raphael.js"></script>
    <script type="text/javascript" src="../lib/flot/jquery.flot.js"></script>
    <script type="text/javascript" src="../lib/flot/jquery.flot.resize.js"></script>
    <script type="text/javascript" src="../lib/flot-spline/jquery.flot.spline.js"></script>
    <script type="text/javascript" src="../lib/jquery-knob/jquery.knob.js"></script>
    <script type="text/javascript" src="../js/quirk.js"></script>
    <script type="text/javascript" src="../lib/jquery-autosize/autosize.js"></script>
    <script type="text/javascript" src="../lib/select2/select2.js"></script>

    
    <!-- start - This is for export functionality only -->
    <script type="text/JavaScript" src="../lib/datatables/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="../lib/datatables/buttons.flash.min.js"></script>
    <script type="text/JavaScript" src="../lib/datatables/jszip.min.js"></script>
    <script type="text/javascript" src="../lib/datatables/pdfmake.min.js"></script>
    <script type="text/JavaScript" src="../lib/datatables/vfs_fonts.js"></script>
    <script type="text/JavaScript" src="../lib/datatables/buttons.html5.min.js"></script>
    <script type="text/javascript" src="../lib/datatables/buttons.print.min.js"></script>    

    <!-- end - This is for export functionality only -->

    <script type="text/javascript">
        $(function () {
            $("select").select2({ tags: true });
        });

        function auto() {
            $("select").select2({ tags: true });
        };

        $(document).ready(function () {

            'use strict';

            $('#grdReport').DataTable({
                dom: 'Bfrtip',
                buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
            });
        });
       
    </script>
</body>
</html>
