<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="RCandJJ.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .value-title
        {
                line-height: normal;
                text-align:center
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
                                <asp:Label ID="lblLoginName" runat="server" Text="Admin"></asp:Label>
                                to <span class="text-success" style="color: #e6aa5b; line-height: normal;">Vicco Laboratories!.</span>
                            </h4>
                        </div>
                    </div>
                    <div class="panel panel-site-traffic padding10">
                        
                        <div class="row panel-quick-page">

                            <div class="col-xs-4 col-sm-5 col-md-4 page-user">
                                <div class="panel panel-primary-full">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            Products Added</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="page-icon">
                                                <i class="fa fa-shopping-cart"></i>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <h3 class="dash-value">
                                                <asp:Label ID="lblMaterial" runat="server"></asp:Label></h3>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xs-4 col-sm-4 col-md-4 page-products">
                                <div class="panel panel-primary-full">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            SUPER STOCKIST</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="page-icon">
                                                <i class="fa fa-user"></i>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <h3 class="dash-value">
                                                <asp:Label ID="lblStockist" runat="server"></asp:Label></h3>                                           
                                        </div>                                     
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-4 col-sm-3 col-md-4 page-events">
                                <div class="panel panel-primary-full">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            DISTRIBUTOR</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="page-icon">
                                                <i class="fa fa-users"></i>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <h3 class="dash-value">
                                                <asp:Label ID="lblDistributor" runat="server"></asp:Label></h3>                                            
                                        </div>                                        
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 page-support">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            MONTHLY SALE VALUE</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentmonthvalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-4 col-sm-5 col-md-2 page-reports">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            CUMULATIVE VALUE</h4>
                                    </div>
                                    <div class="panel-body" style="height:70px;">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentCimulativevalue" runat="server" Font-Size="20px" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-2 page-statistics">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            CUMULATIVE QTY</h4>
                                    </div>
                                    <div class="panel-body" style="height:70px;">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentcumulativeqtyvalue" runat="server" Font-Size="20px" CssClass="text-center"></asp:Label></h3>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 page-privacy">
                                <div class="panel">
                                    <br />
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">
                                            MONTHLY SALE QTY</h4>
                                    </div>
                                    <div class="panel-body">
                                        <h3 class="dash-value">
                                            <asp:Label ID="lblcurrentmonthqtyvalue" runat="server" CssClass="text-center"></asp:Label></h3>
                                        <br />
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
                                        <div id="bar-chart" style="height: 400px;">
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
                                        <div id="bar-chart_id" style="height: 400px;">
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
    <script type="text/javascript" src="../lib/echarts/echarts-all.js"></script>
    <script type="text/javascript" src="../lib/echarts/echarts-init.js?v=211.12.2019"></script>

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $.ajax({
            type: "POST",
            url: "Home.aspx/GetProductValueLinechart",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                alert(response.d[1]);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
    </script>--%>

</asp:Content>
