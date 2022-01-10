<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="CloudStorage.Settings" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="CSS/StyleSheet1.css"/> 
<%--    <link rel="stylesheet" href="CSS/style.css"/>--%>
    <title></title>
    <style type="text/css">
        /*#form1 {
            height: 976px;
            width: 1900px;
        }*/

        #myProgress {
          width: 79%;
          background-color: #ddd;
            height: 8px;
        }

        #myBar {
          width: 10%;
          height: 8px;
          background-color: #04AA6D;
          text-align: center;
          line-height: 30px;
          color: white;
        }
        .auto-style1 {
            z-index: 1;
            left: 75px;
            top: 408px;
            position: absolute;
            height: 92px;
            width: 159px;
        }
        .auto-style2 {
            z-index: 1;
            left: 281px;
            top: 415px;
            position: absolute;
            height: 39px;
            width: 184px;
        }
        .auto-style3 {
            z-index: 1;
            left: 280px;
            top: 415px;
            position: absolute;
            height: 39px;
            width: 184px;
        }
        .auto-style4 {
            width: 1927px;
            height: 904px;
            background: #dde5f4;
            position:absolute;
           
        }
        .auto-style5 {
            z-index: 1;
            left: 21px;
            top: 24px;
            position: absolute;
            height: 354px;
            width: 628px;
        }
        .auto-style6 {
            z-index: 1;
            left: 95px;
            top: 318px;
            position: absolute;
            height: 36px;
            width: 187px;
        }
        .auto-style7 {
            z-index: 1;
            left: 221px;
            top: 14px;
            position: absolute;
            height: 61px;
            width: 168px;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style8 {
            z-index: 1;
            left: 203px;
            top: 136px;
            position: absolute;
            height: 30px;
            width: 152px;
           
        }
        .auto-style9 {
            z-index: 1;
            left: 38px;
            top: 316px;
            position: absolute;
            text-align:center;
            height:40px;
            width:330px;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style10 {
            z-index: 1;
            left: 43px;
            top: 493px;
            position: absolute;
            height: 129px;
            width: 333px;
        }
        .auto-style11 {
            z-index: 1;
            left: 95px;
            top: 137px;
            position: absolute;
            height: 30px;
            width: 96px;
        }
        .auto-style12 {
            z-index: 1;
            left: 95px;
            top: 191px;
            position: absolute;
            height: 28px;
            width: 79px;
        }
        .auto-style13 {
            z-index: 1;
            left: 203px;
            top: 191px;
            position: absolute;
            height: 29px;
            width: 289px;
        }
        .auto-style14 {
            z-index: 1;
            left: 94px;
            top: 243px;
            position: absolute;
            height: 25px;
            width: 75px;
        }
        .auto-style15 {
            z-index: 1;
            left: 204px;
            top: 248px;
            position: absolute;
            height: 21px;
            width: 121px;
        }
    </style>
    
</head>
<body style="background-color:#dde5f4;">

    
    <form id="form1" runat="server" >
 <div class="navbar" style="font-family: Arial, Helvetica, sans-serif;">
 
    <a href="MainPage.aspx">Home</a>&nbsp;
    <a href="FileStorage.aspx">Cloud Storage</a>
    <a href="Contact.aspx">Contact Us</a>
    <a href="About.aspx">About</a>
  <div class="dropdown"  >
    <button class="dropbtn">Personalization
      <i class="fa fa-caret-down" style="width: 22px"></i>
    </button>
    <div class="dropdown-content" style="z-index:9999; position:absolute;">
      <a href="SharedFiles.aspx">Shared Files</a>
      <a href="Settings.aspx">Settings</a>
     <a href="javascript:if(confirm('Are you sure you want to log out?')) window.location.href = 'Login.aspx';">Sign Out</a>
 
 
    </div>
  </div> 
</div>
                 <script type="text/javascript">  
                     $(document).ready(function move() {
                         var elem = document.getElementById("myBar");
                         elem.style.width = <%=saze%> + "%";
                         elem.innerHTML = <%=saze%> + "%";
                         if (<%=saze%> >= 80) {
                             document.getElementById("myBar").style.backgroundColor = "red";
                         }
                     })
                 </script>

                  

        <asp:HiddenField ID="HiddenField1" runat="server"  />
        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Blue" BorderWidth="30px" ForeColor="Black" style="z-index: 1;border-radius: 45px; left: 511px; top: 153px; position: absolute; height: 629px; width: 600px; background-color:#dde5f4">
            
            
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Panel1" ForeColor="Black" style="margin-bottom: 0px" Text="Username : " CssClass="auto-style11"></asp:Label>
            <asp:Label ID="usernametxt" runat="server" CssClass="auto-style8"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Email Id : " CssClass="auto-style12"></asp:Label>
            <i class="fa fa-gear fa-spin" style="font-size:55px; position:absolute; left: 154px; top: 16px;"></i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" BorderColor="White" ForeColor="Black" Font-Size="40" Font-Bold="true" Text="Settings" CssClass="auto-style7"></asp:Label>
            <asp:Label ID="emailtxt" runat="server" CssClass="auto-style13"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Password :" CssClass="auto-style14"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="********" CssClass="auto-style15"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="auto-style6" PostBackUrl="~/ChangePassword.aspx">Change Password?</asp:LinkButton>
            <asp:Label ID="Label6" runat="server" Text="2 Factor Authentication :-  (Face Recognition)" CssClass="auto-style1"></asp:Label>
            <asp:Button ID="enable_auth" runat="server" Text="Enable Face Auth" OnClick="enable_auth_Click" CssClass="auto-style3" />
            <asp:Button ID="disable_button" runat="server" OnClick="disable_button_Click" Text="Disable Face Auth" CssClass="auto-style2" />
        </asp:Panel>
        <script></script>

        <asp:Panel ID="Panel2" runat="server" BackColor="#99CCFF" style="z-index: 1; left: 54px; top: 154px; position: absolute; border-radius: 35px;height: 692px; width: 419px;">
             <asp:Label ID="displayusernametxt" Font-Bold="true"  Font-Size="28" runat="server" CssClass="auto-style9"></asp:Label>
            <asp:Image ID="profimg" runat="server" style="z-index: 1; left: 34px; top: 20px; position: absolute; height: 305px; width: 346px;" ImageUrl="~/Images/user_icon.png" />                  
            <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 339px; top: 381px; position: absolute; height: 22px; width: 52px" Text="1 GB"></asp:Label>
        
                <div id="myProgress" style="position:absolute; border-radius: 5px; top: 413px; left: 45px;">
                    <div id="myBar" style="position:absolute; border-radius: 5px; top: 0px; left: 0px;">10%</div>        
                </div>
            
                <asp:Panel ID="Panel4" runat="server" BackColor="#F7F7F7" style="border-radius: 25px; " CssClass="auto-style10">
                    <asp:Label ID="Label8" runat="server" style="z-index: 1;  position: absolute; height: 36px; width: 166px; top: 24px; left: 85px;" Text="Running Low on Space ?"></asp:Label>
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/premium icon.png" style="z-index: 1;  position: absolute;border-radius: 25px; height: 24px; width: 40px; margin-bottom: 0px; top: 65px; left: 88px;" />
                <asp:LinkButton ID="LinkButton2" runat="server"  NavigateUrl="~/Contact.aspx" style="z-index: 1;  position: absolute; margin-bottom: 2px; top: 68px; left: 126px;" PostBackUrl="~/Contact.aspx">Upgrade to Tier 2</asp:LinkButton>

                </asp:Panel>

            </asp:Panel>
                

        <asp:Panel ID="Panel3" runat="server" BackColor="#99CCFF" BorderColor="#3399FF" style="z-index: 1; top: 156px; border-radius: 35px; position: absolute; height: 692px; width: 622px; left: 1194px; padding-left:50px; ">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cloud2images.jpg" style="border-radius: 25px; padding-left:1px" CssClass="auto-style5" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/cloud1images.jpg" style="z-index: 1; left: 18px; border-radius: 25px; top: 397px; position: absolute; height: 273px; width: 630px; padding-left:1px" />
            </asp:Panel>

                  <!-- PANEL 4 -->      
                
        <!-- PANEL 2 -->  
       
    </form>
</body>
</html>
