<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CloudStorage.MainPage" %>
<!DOCTYPE html>
    <html>
      <head runat="server">
            <title>SCloud</title>
           
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="CSS/StyleSheet1.css">
<style>
    body {
    font-family: Arial, Helvetica, sans-serif;
    background-image: url('Images/Main4.jpeg');
    background-repeat: no-repeat;
    background-size: cover;
}
    </style>
</head>
<body>
<form id="form1" runat="server">
        <div class="navbar">
 
    <a href="MainPage.aspx">Home</a>&nbsp;
    <a href="FileStorage.aspx">Cloud Storage</a>
    <a href="Contact.aspx">Contact Us</a>
    <a href="About.aspx">About</a>
  <div class="dropdown" >
    <button class="dropbtn">Personalization
      <i class="fa fa-caret-down" style="width: 22px"></i>
    </button>
    <div class="dropdown-content">
      <a href="SharedFiles.aspx">Shared Files</a>
      <a href="Settings.aspx">Settings</a>
     <a href="javascript:if(confirm('Are you sure you want to log out?')) window.location.href = 'Login.aspx';">Sign Out</a>
 
 
    </div>
  </div> 
</div>
 



</form>
  </body>
 </html>