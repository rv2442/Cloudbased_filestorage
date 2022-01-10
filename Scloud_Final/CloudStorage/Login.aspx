<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CloudStorage.Login" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>SCloud - Login</title>
  <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap'><link rel="stylesheet" href="./style.css">
<link rel="stylesheet" href="CSS/style.css" />

    <style type="text/css">
        .auto-style1 {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 60%;
            height: 210px;
            margin-top: 15px;
        }
    </style>

</head>
<body>
        <form id="form1" runat="server">
<!-- partial:index.partial.html -->
<div class="screen-1">
    <img class="auto-style1" src="Images/cloud2.png"  />   
    
   
  <div class="email">
    <label for="email">Username</label>
    <div class="sec-2">
      <ion-icon name="person-circle-outline"></ion-icon>
     
       <asp:TextBox ID="txtusername" runat="server"  placeholder="Enter Username"></asp:TextBox>
    </div>
  </div>
   
  <div class="password">
    <label for="password">Password</label>
    <div class="sec-2">
      <ion-icon name="lock-closed-outline"></ion-icon>
      <%--<input class="pas" type="password" name="password" placeholder="············"/>--%>
     <asp:TextBox ID="txtpassword" runat="server" CssClass="pas" type="password" TextMode="Password" placeholder="********" ></asp:TextBox>
      <ion-icon class="show-hide" name="eye-outline"></ion-icon> 
    </div>  </div>
  <div><asp:Label ID="lblmsg" runat="server" Text="Incorrect Username or password" Visible="False" ForeColor="Red"></asp:Label></div>
    <asp:Button ID="Button3" class="login" runat="server" style="cursor:pointer" OnClick="Button1_Click" Text="Login" />
  <div class="footer"> 
    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/SignUp.aspx">Signup</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="~/ForgotPassword.aspx" >Forgot Password?</asp:HyperLink>
  </div>
</div>
<!-- partial -->
  </form>
</body>
</html>
