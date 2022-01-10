<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="CloudStorage.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 129px;
            left: 597px;
            z-index: 1;
            width: 170px;
            height: 44px;
        }
        body {
  font-family: Arial, Helvetica, sans-serif;
overflow-y: hidden;
  background: #dde5f4;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="text-align:center; min-height: 100vh;align-items:center;font-size:26px">You have logged out succesfully</p>
        </div>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="Return to Login page" OnClick="Button1_Click" />
    </form>
</body>
</html>
