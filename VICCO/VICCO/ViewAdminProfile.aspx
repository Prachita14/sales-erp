<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAdminProfile.aspx.cs" Inherits="VICCO.ViewAdminProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.list-group-item {
    position: relative;
    display: block;
    padding: 15px 15px;
    margin-bottom: -1px;
    background-color: #ffffff;
    border: 1px solid #dddddd;
}
.col-md-4
{
    font-weight:bold;
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
                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                      EMAIL
                                        </label>
                                    <div class="col-md-8">
                                       <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                       MOBILE NUMBER
                                        </label>
                                    <div class="col-md-8">
                                       <asp:Label ID="lblmobnumber" runat="server"></asp:Label>
                                    </div>
                                </div>

                                  <div class="form-group col-md-6">
                                    <label class="col-md-4">
                                       PASSWORD
                                        </label>
                                    <div class="col-md-8">
                                      <asp:Label ID="lblpassword" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <hr style="border-color: #03A9F4;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
