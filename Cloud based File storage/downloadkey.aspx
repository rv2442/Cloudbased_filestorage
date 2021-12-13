<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadkey.aspx.cs" Inherits="LoginPass.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var data = "abc";
        function AcccessCodeBehindValue() {
            var data = document.getElementById('<%=HiddenField1.ClientID%>').value;
            var txt = document.getElementById('<%=HiddenField2.ClientID%>').value;

                alert(data);
        }
        function download() {
          
            var data = document.getElementById('<%=HiddenField1.ClientID%>').value;
            var txt = document.getElementById('<%=HiddenField2.ClientID%>').value;
            var element = document.createElement('a');
            element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(txt));
            element.setAttribute('download', data);

            element.style.display = 'none';
            document.body.appendChild(element);

            element.click();

            document.body.removeChild(element);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click"  onclientclick="download()" Text="Register" />
        </div>
        <script>
            AcccessCodeBehindValue();
            
        </script>
    </form>
</body>
</html>



