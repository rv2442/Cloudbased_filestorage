<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLREADER.aspx.cs" Inherits="LoginPass.WebForm8" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 954px;
            height: 433px;
            position: absolute;
            top: 69px;
            left: 395px;
            z-index: 1;
            text-align: left;
        }
        .auto-style4 {
            color: #FF0000;
        }
        .auto-style5 {
            width: 455px;
            height: 20px;
            position: absolute;
            top: 167px;
            left: 394px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 120px;
            left: 389px;
            z-index: 1;
            width: 461px;
        }
        .auto-style7 {
            position: absolute;
            top: 63px;
            left: 393px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 68px;
            left: 370px;
            z-index: 1;
            width: 9px;
        }
        .auto-style9 {
            position: absolute;
            top: 116px;
            left: 369px;
            z-index: 1;
            width: 9px;
            height: 22px;
        }
        .auto-style10 {
            position: absolute;
            top: 220px;
            left: 368px;
            z-index: 1;
            width: 30px;
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            &nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style3">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sign Up<br />
            <br />
            <br />
            Enter Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtusername" runat="server" Height="16px" OnTextChanged="txtusername_TextChanged" Width="181px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regusername" runat="server" ControlToValidate="txtusername" CssClass="auto-style7" Display="Dynamic" ErrorMessage="Invalid Username" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9._]+"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" CssClass="auto-style8" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            Enter Password :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="184px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" CssClass="auto-style9" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="Label1" runat="server" CssClass="auto-style6" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Confirm Password :&nbsp;
            <asp:TextBox ID="txtconfpass" runat="server" TextMode="Password" Width="183px"></asp:TextBox>
            &nbsp;<asp:Label ID="lblmsg" runat="server" CssClass="auto-style5" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Email ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server" TextMode="Email" Width="184px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" CssClass="auto-style10" Display="Dynamic" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Register" />
        </asp:Panel>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style4">&nbsp;</span></p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
