<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginPass.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 493px;
            top: 385px;
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="txtusername" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; left: 596px; top: 177px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtpassword" runat="server" style="z-index: 1; left: 597px; top: 230px; position: absolute" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Login to CloudServer</p>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 493px; top: 178px; position: absolute; height: 20px; width: 49px; right: 890px" Text="Username"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 492px; top: 229px; position: absolute; height: 20px; width: 49px" Text="Password"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" Height="25px" OnClick="Button1_Click" style="z-index: 1; left: 670px; top: 325px; position: absolute; bottom: 217px; width: 95px" Text="Clear" />
            <asp:Button ID="Button2" runat="server" Height="25px" OnClick="Button1_Click" style="z-index: 1; left: 503px; top: 325px; position: absolute; bottom: 217px; width: 105px" Text="Login" />
        </p>
        <p>
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" style="z-index: 1; left: 496px; top: 273px; position: absolute; height: 20px; width: 273px" Text="Incorrect Username or password" Visible="False"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/SignUp.aspx" CssClass="auto-style1">New User Signup?</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/forgotpassword.aspx" style="z-index: 1; left: 494px; top: 415px; position: absolute; height: 24px">Forgot Password?</asp:HyperLink>
        </p>
    </form>
</body>
</html>
