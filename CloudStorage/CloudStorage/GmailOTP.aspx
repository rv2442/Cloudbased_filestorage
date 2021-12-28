<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GmailOTP.aspx.cs" Inherits="CloudStorage.GmailOTP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OTP</title>
      <link rel="stylesheet" href="CSS/style.css"/>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tr>
                <td colspan="2" align="center" style="font-size: 26px ;color:white; background-color:black">
                    To confirm your account we will be sending an OTP to your gmail account   
                </td>
                
            </tr>
           
            <tr>
                <td>
                    <br />
                    Email ID :
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtTo" runat="server" Height="25px" Width="168px"></asp:TextBox><br /><br />
                </td>
            </tr>
            <tr>
           
                <td>
                    <asp:Button ID="btnSubmit" Text="Send" runat="server" OnClick="btnSubmit_Click" />
                    <br />
                </td>
            </tr>
        </table>
    </div>
        
    </form>
</body>
</html>