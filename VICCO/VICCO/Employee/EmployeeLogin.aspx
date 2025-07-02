﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeLogin.aspx.cs" Inherits="VICCO.Employee.EmployeeLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
     <title>Login</title>
    <link rel="stylesheet" href="../lib/fontawesome/css/font-awesome.css"/>
    <link rel="stylesheet" href="../css/quirk.css?v=09.07.2019" />

    <script type="text/javascript">

        function Loginclick() {

            if (document.getElementById("txtEmail").value == '') {
                document.getElementById("email").style.border = "solid 2px #FF5722";
            }
            else {
                document.getElementById("email").style.border = "none";
            }

            if (document.getElementById("txtPass").value == '') {
                document.getElementById("password").style.border = "solid 2px #FF5722";
            }
            else {
                document.getElementById("password").style.border = "none";
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="sign-overlay">
    </div>
    <div class="signpanel">
    </div>
    <div class="panel signin">
        <div class="panel-heading signwrapper">
            <h1>
                <img src="../images/vicco_logo.png" /> </h1>
            <h4 class="panel-title">
                Welcome! Please signin.</h4>
        </div>
        <div class="panel-body">
            <div id="email">
                <div class="form-group mb10">
                    <div class="input-group">
                        <span class="input-group-addon" style="border-right: none;"><i class="fa fa-user"></i>
                        </span>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Username" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="login"
                            Display="None" ForeColor="#FF5722" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div id="password">
                    <div class="input-group">
                        <span class="input-group-addon" style="border-right: none;"><i class="fa fa-lock"></i>
                        </span>
                        <asp:TextBox ID="txtPass" runat="server" class="form-control" placeholder="Enter Password"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="login"
                            Display="None" ForeColor="#FF5722" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>           
            <div>
               
                <asp:Label ID="lblError" runat="server" ForeColor="#FF5722"></asp:Label>
                <br />
                <br />
                <%-- <a href="" class="forgot">Forgot password?</a></div>--%>
                <div class="form-group">               
                    <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-success btn-quirk btn-block" OnClick="btnLogin_Click"
                        OnClientClick="Loginclick()" ValidationGroup="login" />
                </div>
            </div>
        </div>
    <!-- panel -->
    </div>
    </form>
</body>
</html>
