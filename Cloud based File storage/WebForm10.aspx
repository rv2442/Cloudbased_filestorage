﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="LoginPass.WebForm10" %>

<html>
<head>
<title></title>
<!-- Apply styles to html elements -->
<style>
*{
margin:0; padding:0; boxsizing:border-box;
}
header{
width: 100%; height: 100vh;
background-color: white;
background-repeat: no-repeat;
background-size: cover;
}
nav{
width: 100%; height: 15vh;
background: black;
display: flex; justify-content: space-between;
align-items: center;
}
nav .mainmenu{
width: 40%;
display: flex; justify-content: space-around;
}
main{
width: 100%; height: 85vh;
display: flex; justify-content: center;
align-items: center;
text-align: center;
}
section h3{
letter-spacing: 3px; font-weight: 200;
}
section h1{
text-transform: uppercase;
}
section div{
animation:changeborder 10s infinite linear;
border: 7px solid red;
}
@keyframes changeborder{
0%
20%
40%
}
</style>
</head>
<body>
<!--Let us create a simple menu using the navigation tags-->
<!--Use header to indicate that manu will be a part of header -->
<header>
<nav>
<div class = "logo" <h3 style="color:white;">MYLOGO</h3></div>
<!--Lets define the menu items now-->
<div class = "mainmenu">
<a href="FileUpload.aspx">Profile</a>
<a href="Profile.aspx">Home</a>
<a href="FileUpload.aspx"> Upload Files</a>
<a href="ContactUs.aspx">Contact Us</a>
<a href="Settings.aspx">Settings</a>
<
</div>
</nav>
<!--Let us create the main section now, if you are not using html5, use div tags-->
<main>
<section>
<!--Check out the styling elements for this div class - change_text -->
<div class = "change_text"><b>WELCOME TO Cloud Storage</b></div>
<!--make text italic-->
<p><i>All yo</i></p><br>
<!--create a button, if there is a form, you can specify an action on click-->
<input type = button value = "view more">
</section>
</main>
</header>
</body>
</html>