<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup_vineet.aspx.cs" Inherits="Website_.NET.Signup_vineet" %>
<!DOCTYPE html>
<script runat="server">
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 954px;
            height: 433px;
            position: absolute;
            top: 69px;
            left: 395px;
            z-index: 1;
            text-align: left;
        }
        .auto-style4 {
            color: #FF0000;
        }
        .auto-style5 {
            width: 455px;
            height: 20px;
            position: absolute;
            top: 100px;
            left: 353px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 158px;
            left: 341px;
            z-index: 1;
            width: 461px;
        }
        .auto-style7 {
            position: absolute;
            top: 63px;
            left: 393px;
            z-index: 1;
            margin-bottom: 0px;
        }
        .auto-style8 {
            position: absolute;
            top: 43px;
            left: 317px;
            z-index: 1;
            width: 23px;
            height: 17px;
        }
        .auto-style9 {
            position: absolute;
            top: 91px;
            left: 319px;
            z-index: 1;
            width: 25px;
            height: 17px;
        }
        .auto-style10 {
            position: absolute;
            top: 166px;
            left: 320px;
            z-index: 1;
            width: 30px;
            height: 19px;
        }
    </style>
</head>
<body>
    <script type="text/javascript">
        function nextpage() {
            window.location.href = "gmail_otp.aspx";
        }

        function downloadFile(data = "<%=Session["scrkey"].ToString()%>", fileName = "<%=txtusername.Text%>",type = "text/plain") {
          
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

                nextpage();
            }
            else {
                //window.prompt(validation);
            }
            console.log(validation);
        }
        downloadFile(data = "<%=Session["scrkey"].ToString()%>", fileName = "<%=txtusername.Text%>", type = "text/plain");
    </script>
    <form id="form1" runat="server">
            <asp:Button ID="Button2" runat="server" Text="Button" style="visibility:hidden;" OnClick="Button2_Click"  />

    <div>
    
    </div>
        <p>
            &nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style3">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sign Up<br />
            <asp:Label ID="uname_label" runat="server" style="z-index: 1; left: 326px; top: 55px; position: absolute; height: 24px; width: 241px" ViewStateMode="Enabled"></asp:Label>
            <br />
            <br />
            Enter Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtusername" runat="server" Height="16px" OnTextChanged="txtusername_TextChanged" Width="181px" AutoPostBack="True"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regusername" runat="server" ControlToValidate="txtusername" CssClass="auto-style7" Display="Dynamic" ErrorMessage="Invalid Username" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9]+"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" CssClass="auto-style8" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            Enter Email :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="184px" style="z-index: 1; left: 128px; top: 138px; position: absolute"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" CssClass="auto-style9" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="Label1" runat="server" CssClass="auto-style6" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Enter Password :&nbsp;
            <asp:TextBox ID="txtconfpass" runat="server" TextMode="Password" Width="183px" style="z-index: 1; position: absolute; top: 176px; left: 129px;"></asp:TextBox>
            &nbsp;<asp:Label ID="lblmsg" runat="server" CssClass="auto-style5" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Confirm Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server" TextMode="Email" Width="184px" style="z-index: 1; left: 128px; top: 101px; position: absolute" AutoPostBack="True" OnTextChanged="txtemail_TextChanged"></asp:TextBox>
            <asp:Label ID="email_label" runat="server" AssociatedControlID="txtemail" style="z-index: 1; left: 327px; top: 104px; position: absolute; width: 170px" Text="Label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" CssClass="auto-style10" Display="Dynamic" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click"  onclientclick="downloadFile()" Text="Register" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpassword" ErrorMessage="*" ForeColor="Red" style="z-index: 1; left: 316px; top: 126px; position: absolute; height: 16px; width: 14px"></asp:RequiredFieldValidator>
        </asp:Panel>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style4">&nbsp;</span></p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>


