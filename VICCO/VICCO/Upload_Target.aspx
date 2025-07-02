<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Upload_Target.aspx.cs" Inherits="VICCO.Upload_Target" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <div class="panel panel-danger" >
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Upload Target</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-9 row" style="margin-bottom: 30px;">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-5">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <br /><br />
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary"
                                        OnClick="btnUploadTarget" Width="80px" />
                                </div>
                            </div>                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>