<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CloudStorage.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTP</title>
      <link rel="stylesheet" href="CSS/style.css"/>
    </head>
<body>
    <form id="form1" runat="server">
         <div align="center" style="font-size: 26px; color:white ;background-color:black" class="auto-style11">
            Change Password
       </div>
    
         <br />
    
        Enter Old Password:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtoldpwd" runat="server" Height="16px" Width="163px"></asp:TextBox>
   
            <br />
   
            <br />
   
            Enter New Password:&nbsp;&nbsp;
            <asp:TextBox ID="txtnewpwd" runat="server" Width="162px" Height="16px"></asp:TextBox>
     
            <br />
     
            <br />
        Confirm Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtconfirmpwd" runat="server" Height="16px" Width="165px"></asp:TextBox>
         <br />
         <br />
         Secret Key:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtscrkey" runat="server" Height="16px" Width="165px"></asp:TextBox>
         <br />
       <br />
               <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Visible="True"></asp:Label>
                <br />
                <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Change Password" />

     
     
    </form>
</body>
</html>