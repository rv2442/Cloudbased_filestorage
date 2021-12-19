<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Popup_andcall_CSfunc.aspx.cs" Inherits="Website_.NET.Popup_andcall_CSfunc" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <title></title>
    <style type="text/css">
        .Background
        {
            background-color: Black;
            /*filter: alpha(opacity=90);*/
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>
</head>
<body >
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnablePageMethods="true">
    <Services>
        <asp:ServiceReference Path="~/Default.aspx" />
    </Services>
</asp:ScriptManager>
<asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" OnClick="Button1_Click" />

<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
    CancelControlID="Button2" BackgroundCssClass="Background">
</cc1:ModalPopupExtender>
            <asp:Button ID="btPopupLoad" runat="server" Text="Load" CssClass="button" onclick="btPopupLoad_Click" style="display:none;"/>

    <script type="text/javascript">
        function abcd() {
            var a = document.getElementById('TextBox8').value;
            document.getElementById("usernames_shared").value = a;
            console.log(a);
            document.getElementById('<%= btPopupLoad.ClientID %>').click();

        }
    </script>
<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
    <asp:HiddenField ID="usernames_shared" runat="server" />
    <table>
    <tr>
    <td>
    <asp:Label runat="server" CssClass="lbl" Text="First Name"></asp:Label>
    </td>
    <td>
    <asp:TextBox runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Middle Name"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Last Name"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox2" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Gender"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox3" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Age"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox4" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="City"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox5" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="State"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox6" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Country"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox7" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Zip Code"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox8" runat="server" Font-Size="14px" ></asp:TextBox>
    </td>
    </tr>
    </table>
    <br />
    <asp:Button ID="Button2" OnClientClick="abcd()" runat="server" Text="Close" />
</asp:Panel>
<!-- ModalPopupExtender -->
</form>
</body>
</html>

