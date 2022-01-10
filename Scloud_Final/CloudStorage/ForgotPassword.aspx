<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CloudStorage.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
        <link rel="stylesheet" href="CSS/style.css"/>

    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 0px;
            top: 126px;
            position: absolute;
        }
        .auto-style2 {
            z-index: 1;
            left: 321px;
            top: 44px;
            position: absolute;
        }
        .auto-style3 {
            z-index: 1;
            left: 14px;
            top: 81px;
            position: absolute;
        }
        .auto-style4 {
            position: absolute;
            top: 52px;
            left: 10px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div align="center" style="font-size: 26px; color:white ;background-color:black" class="auto-style11">
            Forgot Password
       </div>

    <div>

        <br />

        <asp:Label ID="Label1" runat="server"  Text="Enter your Username"></asp:Label>
&nbsp &nbsp;<asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        <asp:Label ID="lbluser" runat="server" Font-Bold="True" ForeColor="Red" Text="Incorrect User Name" Visible="False" ></asp:Label>
    <br />
    </div>
      <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get" />
         <br />
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="2px" Visible="False" >
            Security Question: Enter your secret key<br />
            <br />
            Enter Security Answer:
            <asp:TextBox ID="txtsecanswer" runat="server" OnTextChanged="txtsecanswer_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Password"/>
            <br />
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        
    </form>
</body>
</html>