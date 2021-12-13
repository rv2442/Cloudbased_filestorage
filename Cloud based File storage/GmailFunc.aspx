<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GmailFunc.aspx.cs" Inherits="LoginPass.WebForm7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            z-index: 1;
            left: 656px;
            top: 317px;
            position: absolute;
        }
        .auto-style3 {
            position: absolute;
            top: 384px;
            left: 611px;
            z-index: 1;
        }
        .auto-style4 {
            z-index: 1;
            left: 834px;
            top: 386px;
            position: absolute;
        }
        .auto-style5 {
            margin-left: 480px;
        }
        .auto-style6 {
            position: absolute;
            top: 450px;
            left: 628px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border: 1px solid" align="center">
            <tr>
                <td colspan="2" align="center">
                    To confirm your account we will be sending an OTP<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
<td class="auto-style1">
</td>
            </tr>
            <tr>
                <td>
                    Email ID :
                </td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" Height="25px" Width="168px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Attach a file :
                </td>
                <td>
                    <asp:FileUpload ID="fileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" Text="Send" runat="server" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style2" Visible="False"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>