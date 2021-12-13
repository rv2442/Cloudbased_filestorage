<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LoginPass.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Username
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lbluser" runat="server" Font-Bold="True" ForeColor="Red" Text="Incorrect User Name" Visible="False" style="z-index: 1; left: 313px; top: 22px; position: absolute"></asp:Label>
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get" style="z-index: 1; left: 10px; top: 64px; position: absolute" />
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="2px" Visible="False" style="z-index: 1; left: 10px; top: 112px; position: absolute; height: 196px; width: 384px">
            Security Question:
            <asp:Label ID="lblsecq" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            <br />
            <br />
            Enter Security Answer:
            <asp:TextBox ID="txtsecanswer" runat="server" OnTextChanged="txtsecanswer_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Password" style="height: 29px" />
            <br />
            <asp:Label ID="lblmsg" runat="server" Text="Label" ForeColor="Red" style="z-index: 1; left: 0px; top: 126px; position: absolute"></asp:Label>
        </asp:Panel>
        </p>
    </form>
</body>
</html>
