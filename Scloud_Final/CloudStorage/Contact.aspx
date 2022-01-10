<%@ Page Title="Contact" Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LoginPass.Contact" %>
<!DOCTYPE html>
    <html>
      <head runat="server">
            <title>SCloud - Contact Us</title>
       
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="CSS/StyleSheet1.css">
<link rel="stylesheet" href="CSS/AboutContact.css">
<style>
    body {
    font-family: Arial, Helvetica, sans-serif;  
     background: #dde5f4;
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
    <div class="about-section">
  <h1>Get in touch</h1>
        <p>&nbsp;</p>
  <p>Have any questions you want to ask us? Email or call us by using information given below</p>
  <p>You can also upgrade your account to Tier 2 by contacting us .</p>
</div>
 <div style="text-align:center; font-size:18px;">
    
     <br />
    
  <br />
     <address>
         <i class="fa fa-map-marker" style="font-size:18px;color:red"></i>
        <b>Location</b><br />
        SCloud,Cloud Street,<br />
        Cloud, MH 400-0xx</address>

        <br />
        <i class="fa fa-phone" style="font-size:22px;color:green"></i>
        <b>Phone</b><br />

        111-111-111-xxxx<br />
        222-222-222-xxxx<br />

    <br />
    <address>
        <i class="fa fa-envelope" style="font-size:18px;color:black"></i>
        <strong>Email:</strong> <br />  <a href="mailto:cloudstorage636@gmail.com">cloudstorage636@gmail.com</a><br />

    </address>
        

</div>
</form>
  </body>
 </html>

