<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signcsssup.aspx.cs" Inherits="LoginPass.WebForm10" %>
<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Sign Up</title>
  <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap'><link rel="stylesheet" href="./style.css">
<link rel="stylesheet" href="CSS/style.css" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 39;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server">
           
<!-- partial:index.partial.html -->
<div class="screen-1">
    <img src="Images/favpng_cloud-computing-symbol-google-cloud-platform.png" width="200" height="200"  viewBox="0 0 6 480"/>        
    <br />
<%--  <svg class="logo" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" width="300" height="300" viewbox="0 0 640 480" xml:space="preserve">
    <g transform="matrix(3.31 0 0 3.31 320.4 240.4)">
      <circle style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(61,71,133); fill-rule: nonzero; opacity: 1;" cx="0" cy="0" r="40"></circle>
    </g>
    <g transform="matrix(0.98 0 0 0.98 268.7 213.7)">
      <circle style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(255,255,255); fill-rule: nonzero; opacity: 1;" cx="0" cy="0" r="40"></circle>
    </g>
    <g transform="matrix(1.01 0 0 1.01 362.9 210.9)">
      <circle style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(255,255,255); fill-rule: nonzero; opacity: 1;" cx="0" cy="0" r="40"></circle>
    </g>
    <g transform="matrix(0.92 0 0 0.92 318.5 286.5)">
      <circle style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(255,255,255); fill-rule: nonzero; opacity: 1;" cx="0" cy="0" r="40"></circle>
    </g>
    <g transform="matrix(0.16 -0.12 0.49 0.66 290.57 243.57)">
      <polygon style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(255,255,255); fill-rule: nonzero; opacity: 1;" points="-50,-50 -50,50 50,50 50,-50 "></polygon>
    </g>
    <g transform="matrix(0.16 0.1 -0.44 0.69 342.03 248.34)">
      <polygon style="stroke: rgb(0,0,0); stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(255,255,255); fill-rule: nonzero; opacity: 1;" vector-effect="non-scaling-stroke" points="-50,-50 -50,50 50,50 50,-50 "></polygon>
    </g>
  </svg>--%>
  <div class="email">
    <label for="email">Username</label>
    <div class="sec-2">
      <ion-icon name="person-circle-outline"></ion-icon>

       <asp:TextBox ID="txtusername" runat="server" OnTextChanged="txtusername_TextChanged" placeholder="Enter Username" Height="20px" Width="445px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regusername" runat="server"  ControlToValidate="txtusername"  Display="Dynamic" ErrorMessage="Invalid Username" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9]+"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtusername" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </div>
  </div>
    <br />
    <div class="email">
    <label for="email">Email</label>
    <div class="sec-2">
     <ion-icon name="mail-outline"></ion-icon>
     
       <asp:TextBox ID="txtemail" runat="server" OnTextChanged="txtemail_TextChanged" placeholder="User@gmail.com" Width="444px" CssClass="auto-style1" Height="23px" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
         <asp:Label ID="Label2" runat="server" CssClass="auto-style6" ForeColor="Red"></asp:Label>

    </div>
  </div>
    <br />
  <div class="email">
    <label for="email">Password</label>
    <div class="sec-2">
      <ion-icon name="lock-closed-outline"></ion-icon>
      <%--<input class="pas" type="password" name="password" placeholder="············"/>--%>
     <asp:TextBox ID="txtpassword" runat="server" CssClass="pas" type="password" TextMode="Password" placeholder="********" Height="23px" Width="444px" ></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"  ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        
      <%--<ion-icon class="show-hide" name="eye-outline"></ion-icon>--%> 
    </div>  </div>
  <div></div>

  <div class="email">
    <label for="email">Confirm Password</label>
    <div class="sec-2">
      <ion-icon name="lock-closed-outline"></ion-icon>
      <%--<input class="pas" type="password" name="password" placeholder="············"/>--%>
     <asp:TextBox ID="txtconfpass" runat="server" CssClass="pas" type="password" TextMode="Password" placeholder="********" Height="22px" Width="444px" ></asp:TextBox>
  <%--    <ion-icon class="show-hide" name="eye-outline"></ion-icon> --%>
    </div>  </div>

  <div><asp:Label ID="Label1" runat="server" Text="Incorrect Username or password" ForeColor="Red" Visible="False"></asp:Label></div>
     <asp:Button ID="Button1" style="cursor: pointer" class="login" runat="server" OnClick="Button1_Click" Text="Login" />

  <div class="footer"> 
    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/SignUp.aspx">Signup</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="~/forgotpassword.aspx" >Forgot Password?</asp:HyperLink>
  </div>
</div>
<!-- partial -->
  </form>
</body>
</html>
