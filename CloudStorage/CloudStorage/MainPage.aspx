<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CloudStorage.MainPage" %>
<!DOCTYPE html>
    <html>
      <head runat="server">
            <title>Cloud Storage</title>
           
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="CSS/StyleSheet1.css">
<style>
    body {
    font-family: Arial, Helvetica, sans-serif;
    background-image: url('Images/CloudMianpage.jpg');
    background-repeat: no-repeat;
    background-size: cover;
}
    .auto-style2 {
        margin-left: 0px;
    }
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="navbar">
 
    <a href=MainPage.aspx>Home</a>&nbsp;
    <a href=FileStorage.aspx>Cloud Storage</a>
    <a href=Contact.aspx>Contact Us</a>
    <a href=About.aspx>About</a>
  <div class="dropdown" >
    <button class="dropbtn">Personalization
      <i class="fa fa-caret-down" style="width: 22px"></i>
    </button>
    <div class="dropdown-content">
      <a href=SharedFiles.aspx>Cloud Storage</a>
      <a href=Profile.aspx>Profile</a>
      <a href=FaceDetect.aspx>Face Authentication</a>
      <a href="javascript:if(confirm('Are you sure you want to log out?')) window.location.href = 'Logout.aspx';">Sign Out</a>
 
 
    </div>
  </div> 
</div>
 

    <div class="center">
        <h2 style="color:whitesmoke"><b>Welcome to the Cloud Storage  </b> </h2>
 
        </div>
      <div class="center-button">
          <asp:Button ID="Button1" runat="server" BackColor="#003366" BorderColor="Black" ForeColor="White" Text="Click here to upload files" OnClick="Button1_Click" CssClass="auto-style2" />


        </div>
  

</form>
  </body>
 </html>