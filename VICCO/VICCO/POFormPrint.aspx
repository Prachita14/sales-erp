﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POFormPrint.aspx.cs" Inherits="NewStarCity.POFormPrint" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body:nth-of-type(1) img[src*="Blank.gif"]
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <center>
            <div id="dvReport">
                <asp:Label ID="lblPurchaseorder_id" runat="server"></asp:Label>
                <asp:Label ID="lbldistributor_id" runat="server"></asp:Label>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                    SizeToReportContent="true">
                </rsweb:ReportViewer>
            </div>
        </center>
    </div>
    </form>
</body>
</html>
