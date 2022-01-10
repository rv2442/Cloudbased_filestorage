<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CloudStorage.SignUp" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>SCloud - Sign Up</title>
  <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap'><link rel="stylesheet" href="./style.css">
<link rel="stylesheet" href="CSS/style.css" />
  
    <style type="text/css">
        .auto-style1 {
            position: relative;
            top: -8px;
            left: -7px;
            z-index: 9999;
            align-self:center;
        }
    </style>
  
</head>
<body>
        <form id="form1" runat="server">
<script type="text/javascript">
    function nextpage() {
        window.location.href = "CheckOTP.aspx";
    }
    function alert_first() {
        alert("A secret key has been given to you please store it securely as it can be used to change your password");
        nextpage();
    }

    function downloadFile(data = "<%=Session["scrkey"].ToString()%>", fileName = "<%=txtusername.Text%>", type = "text/plain") {

        var validation = "<%=Session["validity"].ToString()%>";
        //window.alert(validation);

            if (validation=="True") {
                // Create an invisible A element
                const a = document.createElement("a");
                a.style.display = "none";
                document.body.appendChild(a);

                // Set the HREF to a Blob representation of the data to be downloaded
                a.href = window.URL.createObjectURL(
                    new Blob([data], { type })
                );

                // Use download attribute to set set desired file name
                a.setAttribute("download", fileName);

                // Trigger the download by simulating click
                a.click();

                // Cleanup
                window.URL.revokeObjectURL(a.href);
                document.body.removeChild(a);

                alert_first();
            }
            else {
                //window.prompt(validation);
            }
            console.log(validation);
        }
        downloadFile(data = "<%=Session["scrkey"].ToString()%>", fileName = "<%=txtusername.Text%>", type = "text/plain");
</script>
<!-- partial:index.partial.html -->
<div class="screen-1">
    <asp:Image ID="Image1" runat="server" width="300" height="300" CssClass="auto-style1" BackColor="#F1F7FE" ImageUrl="~/Images/cloud2.png" />
    <br />
  <div class="email">
    <label for="email">Username</label>
    <div class="sec-2">
      <ion-icon name="person-circle-outline"></ion-icon>

       <asp:TextBox ID="txtusername" runat="server" AutoPostBack="True"  OnTextChanged="txtusername_TextChanged" placeholder="Enter Username" Height="20px" Width="445px"></asp:TextBox>
         <asp:Label ID="uname_label" runat="server" ViewStateMode="Enabled" ></asp:Label>    
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" CssClass="auto-style8" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </div>
  </div>
    <br />
    <div class="email">
    <label for="email">Email</label>
    <div class="sec-2">
     <ion-icon name="mail-outline"></ion-icon>
     
       <asp:TextBox ID="txtemail" runat="server" AutoPostBack="True"  OnTextChanged="txtemail_TextChanged" placeholder="User@gmail.com" Width="441px"  Height="23px" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:Label ID="email_label" runat="server" AssociatedControlID="txtemail" ></asp:Label>
        

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

  <div><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtusername" Display="Dynamic" style="position:relative; " ErrorMessage="cannot include spaces" ValidationExpression="^[a-zA-Z0-9](_(?!(\.|_))|\.(?!(_|\.))|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$" ForeColor="Red"></asp:RegularExpressionValidator>

  </div>
          <asp:HiddenField ID="HiddenField1" runat="server" />
           <asp:HiddenField ID="HiddenField2" runat="server" />
           <asp:HiddenField ID="HiddenField3" runat="server" />
    <script>
        AcccessCodeBehindValue();
    </script>
     <asp:Button ID="Button1" style="cursor: pointer" class="login" runat="server"  onclientclick="download()" OnClick="Button1_Click" Text="Sign Up" />

  <div class="footer"> 
    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
  </div>
</div>
<!-- partial -->
              
  </form>
</body>
</html>

