<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LoginPass.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Old Password:
        <asp:TextBox ID="txtoldpwd" runat="server"></asp:TextBox>
    
    </div>
        <p>
            Enter New Password:
            <asp:TextBox ID="txtnewpwd" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter Confirm Password
            <asp:TextBox ID="txtconfirmpwd" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Change Password" />
        <input id="Reset1" type="reset" value="reset" /><p>
            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
