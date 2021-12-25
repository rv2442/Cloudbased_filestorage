<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="test111.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
<link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap'/>
<link rel="stylesheet" href="CSS/style.css" />

</head>
<body>
    <form id="form1" runat="server">

          <div style="background-color:black";>
              <asp:Label ID="Label1"  runat="server" font-size="30px" Font-Bold="true" ForeColor="White" Text="Forgot your password?"></asp:Label>
          </div>
        <br />
          <br />


    <div>
        Enter Username
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lbluser" runat="server" Font-Bold="True" ForeColor="Red" Text="Incorrect User Name" Visible="False"></asp:Label>
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="149px" Visible="False" Width="490px">
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

