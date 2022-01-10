<%@ Page Title="About" Language="C#"  AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LoginPass.About" %>


<!DOCTYPE html>
    <html>
      <head runat="server">
            <title>SCloud</title>
           
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="CSS/StyleSheet1.css">
          <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet">
             <link rel="stylesheet" href="CSS/AboutContact.css">

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
  <h1>About</h1>
        <p>&nbsp;</p>
  <p>SCloud is a cloud storage systemwhere you can store data and share it to any user connected to it</p>
  <p>You can also have 2 factor authentication to protect your data by face recognition.</p>
</div>
    <h2 style="text-align:center">What is Cloud Storage?</h2>
<p style="text-align:center;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cloud storage is a model of computer data storage in which the digital data is stored in logical pools, said to be on "the cloud". The physical storage spans multiple servers (sometimes in multiple locations), and the physical environment is typically owned and managed by a hosting company. These cloud storage providers are responsible for keeping the data available and accessible, and the physical environment secured, protected, and running. People and organizations buy or lease storage capacity from the providers to store user, organization, or application data.

</p>
        <p style="justify-content:center; text-align:center; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cloud storage services may be accessed through a colocated cloud computing service, a web service application programming interface (API) or by applications that use the API, such as cloud desktop storage, a cloud storage gateway or Web-based content management systems.</p>
        




        <br />
        




</form>
  </body>
 </html>
