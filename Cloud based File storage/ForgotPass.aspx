<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="test111.WebForm1" %>

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
&nbsp;<asp:Label ID="lbluser" runat="server" Font-Bold="True" ForeColor="Red" Text="Incorrect User Name" Visible="False"></asp:Label>
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get" />
        </p>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="2px" Height="149px" Visible="False" Width="490px">
            Security Question: Enter the secret key provided to you<br />
            <br />
            Enter Security Answer:
            <asp:TextBox ID="txtsecanswer" runat="server" OnTextChanged="txtsecanswer_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Password" style="height: 29px" />
            <br />
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>

