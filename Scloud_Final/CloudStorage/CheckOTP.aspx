<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOTP.aspx.cs" Inherits="CloudStorage.WebForm3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <link rel="stylesheet" href="CSS/style.css"/>
    <title> OTP Verification</title>
    <style type="text/css">
        .auto-style8 {
            position: absolute;
            top: 152px;
            left: 522px;
            z-index: 1;
            height: 19px;
            width: 84px;
        }
        .auto-style9 {
            position: absolute;
            top: 151px;
            left: 666px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 226px;
            left: 667px;
            z-index: 1;
        }
        .auto-style11 {
      
            position: absolute;
            top: 44px;
            text-align:center;
            z-index: 1;
            left: 529px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
        <div>
  
       <div align="center" style="font-size: 26px; color:white ;background-color:black" class="auto-style11">
            OTP has been sent to your gmail account
       </div>
        <asp:TextBox ID="txtOTP" runat="server" CssClass="auto-style9" ></asp:TextBox>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check OTP" CssClass="auto-style10" />
        <asp:Label ID="status_otp" runat="server" CssClass="auto-style4" ForeColor="Red" style="z-index: 1; position: absolute; top: 152px; left: 882px; height: 22px;"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Enter OTP" CssClass="auto-style8"></asp:Label>
       </div>
       
 
    </form>
</body>
</html>