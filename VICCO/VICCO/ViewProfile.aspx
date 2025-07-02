<%@ Page Title="" Language="C#" MasterPageFile="~/Stockist.Master" AutoEventWireup="true"
    CodeBehind="ViewProfile.aspx.cs" Inherits="VICCO.ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .list-group-item
        {
            position: relative;
            display: block;
            padding: 15px 15px;
            margin-bottom: -1px;
            background-color: #ffffff;
            border: 1px solid #dddddd;
        }
        .col-md-4
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="Home.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="ViewProfile.aspx">View Profile</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                View Your Profile</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        NAME
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblname" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        EMAIL
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        MOBILE NUMBER
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        PAN
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblPan" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        ADDRESS
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        CITY
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        REGION
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblregion" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        CST
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblGst" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        TPT
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lbltpt" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                        LST
                                    </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblLst" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
