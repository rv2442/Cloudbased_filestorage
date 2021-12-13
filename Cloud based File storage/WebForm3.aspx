<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="LoginPass.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            z-index: 1;
            left: 10px;
            top: 56px;
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp; Full name</div>
        <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; left: 15px; top: 341px; position: absolute; height: 109px; width: 324px">
            <asp:ListItem>Sql </asp:ListItem>
            <asp:ListItem>Python</asp:ListItem>
            <asp:ListItem>Java</asp:ListItem>
            <asp:ListItem>C++</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; left: 26px; top: 50px; position: absolute"></asp:TextBox>
        <p>
            &nbsp;</p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="z-index: 1; left: 19px; top: 97px; position: absolute; height: 28px; width: 96px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <br />
        <p>
            <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; top: 204px; position: absolute; left: 124px"></asp:TextBox>
            Email Id</p>
        Password<asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; left: 123px; top: 235px; position: absolute"></asp:TextBox>
    </form>
</body>
</html>
