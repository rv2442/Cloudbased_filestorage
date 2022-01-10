<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LoginPass.WebForm14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 1002px;
            height: 456px;
            position: absolute;
            top: 27px;
            left: 359px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 79px;
            left: 72px;
            z-index: 1;
            width: 46px;
            height: 23px;
        }
        .auto-style8 {
            position: absolute;
            top: 137px;
            left: 71px;
            z-index: 1;
            height: 24px;
        }
        .auto-style7 {
            position: absolute;
            top: 191px;
            left: 75px;
            z-index: 1;
            height: 25px;
            width: 41px;
        }
        .auto-style5 {
            position: absolute;
            top: 305px;
            left: 71px;
            z-index: 1;
            width: 59px;
            height: 22px;
        }
        .auto-style9 {
            position: absolute;
            top: 404px;
            left: 395px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 78px;
            left: 174px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 78px;
            left: 660px;
            z-index: 1;
            width: 268px;
            height: 121px;
        }
        .auto-style12 {
            position: absolute;
            top: 185px;
            left: 166px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 309px;
            left: 168px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            top: 252px;
            left: 70px;
            z-index: 1;
            width: 59px;
        }
        .auto-style15 {
            position: absolute;
            top: 245px;
            left: 165px;
            z-index: 1;
        }
        .auto-style16 {
            position: absolute;
            top: 41px;
            left: 36px;
            z-index: 1;
            width: 153px;
            height: 140px;
        }
        .auto-style17 {
            position: absolute;
            top: 138px;
            left: 168px;
            z-index: 1;
        }
        .auto-style18 {
            position: absolute;
            top: 78px;
            left: 525px;
            z-index: 1;
            width: 105px;
            height: 23px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div>
            &nbsp;</div>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style2">
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Username" runat="server" CssClass="auto-style6" Text="Username"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" CssClass="auto-style8" Text="Email ID"></asp:Label>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style7" Text="DOB"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style14" Text="Country"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style9" OnClick="Button1_Click" Text="Button" />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style10"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style17"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style12" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style15"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style5" Text="City"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style13"></asp:TextBox>

            <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style11" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="AboutMe" runat="server" CssClass="auto-style18" Text="About Me"></asp:Label>

        </asp:Panel>
        <asp:Image src="Images/avatar-2.png" ID="Image1" runat="server" CssClass="auto-style16" />
    </form>
</body>
</html>
