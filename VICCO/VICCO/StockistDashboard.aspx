<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="StockistDashboard.aspx.cs" Inherits="VICCO.StockistDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .stockist_details tr td
        {
            padding: 10px;
            color: Black;
            font-size: 14px;
            background: White;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="mainpanel">
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12 col-lg-12 dash-left">
                    <div class="panel panel-inverse">
                        <div class="panel-body">
                            <h4 class="text-white">                             
                                 Welcome 
                                    <span class="text-danger" style="color:#fc8414;">
                                    <asp:Label ID="lblLoginName" runat="server" Text="Admin"></asp:Label>
                                    </span>
                                to <span class="text-success" style="color: #e6aa5b;">Vicco Laboratories!.</span>
                            </h4>
                        </div>
                    </div>
                    <div class="panel panel-site-traffic padding10">
                        
                        <div class="row panel-quick-page">                        
                        <div class="col-md-6">
                        <div class="col-md-6 page-support padding5">
                                <div class="panel">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                           MONTHLY SALE VALUE</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value paddingtop15">
                                            <asp:Label ID="lblcurrentmonthvalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        <div class="col-md-6 page-reports padding5">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            CUMULATIVE VALUE</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentCimulativevalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                             <div class="col-md-6 page-privacy padding5">
                                <div class="panel">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            MONTHLY SALE QTY</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value paddingtop15">
                                            <asp:Label ID="lblcurrentmonthqtyvalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6 page-statistics padding5">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            CUMULATIVE QTY</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentcumulativeqtyvalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>                            
                       
                        </div>
                        <div class="col-md-6 page-events" style="padding:5px !important;">
                                <div class="panel panel-primary-full">                                    
                         <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()" scrolldelay="150"
                                style="height: 250px; width: 100%; color: white;">
                        <asp:Panel ID="pnlNotice" runat="server" 
                            Width="100%">
                           
                        </asp:Panel> </marquee>
                        <div class="panel-body">
                        </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                          <div class="col-md-12">
                            <div class="panel padding10">
                                <div class="card">
                                    <div class="card-body">
                                        <h4 class="card-title text-center p-t-20">
                                            MONTH WISE ALL PRODUCT VALUE</h4>
                                            <div class="col-md-3">
                                            <asp:DropDownList ID="ddlMaterialGroup" runat="server" class="form-control Group" onchange="MaterialChange()">
                                        </asp:DropDownList>
                                        </div>
                                        <div id="bar-chart" style="height: 300px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="panel padding10">
                                <div class="card">
                                    <div class="card-body">
                                        <h4 class="card-title text-center p-t-20">
                                            MONTH WISE ALL PRODUCT QTY</h4>
                                            <div class="col-md-3">
                                            <asp:DropDownList ID="ddlMaterial" runat="server" class="form-control Group1" onchange="MaterialGroupChange()">
                                        </asp:DropDownList>
                                        </div>
                                        <div id="bar-chart_id" style="height: 300px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

<script src="js/jquery-3.3.1.js" type="text/javascript"></script>
<script src="../lib/echarts/echarts-all.js"></script>
<script src="../lib/echarts/echarts-init.js"></script>

    

</asp:Content>
