<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="LoginPass.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Enter Old Password
            <asp:TextBox ID="OldPass" runat="server" style="z-index: 1; left: 188px; top: 51px; position: absolute"></asp:TextBox>
        </p>
        <p>
            Enter New Password<asp:TextBox ID="NewPass" runat="server" style="z-index: 1; left: 187px; top: 97px; position: absolute"></asp:TextBox>
        </p>
        <p>
            Confirm Password<asp:TextBox ID="ConfPass" runat="server" style="z-index: 1; left: 187px; top: 142px; position: absolute"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="ChangePassBut" runat="server" OnClick="ChangePassBut_Click" style="z-index: 1; left: 81px; top: 195px; position: absolute; width: 155px" Text="Change Password" />
        </p>
        <p>
            <asp:Label ID="Color" runat="server" style="z-index: 1; left: 20px; top: 235px; position: absolute" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
