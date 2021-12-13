<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOTP.aspx.cs" Inherits="LoginPass.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            position: absolute;
            top: 151px;
            left: 564px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 255px;
            left: 536px;
            z-index: 1;
        }
        .auto-style4 {
            z-index: 1;
            left: 811px;
            top: 142px;
            position: absolute;
            width: 249px;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:TextBox ID="txtOTP" runat="server" CssClass="auto-style3"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style6" OnClick="Button1_Click" Text="Check OTP" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter OTP:<asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
