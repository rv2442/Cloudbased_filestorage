<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addrotatorexample.aspx.cs" Inherits="Website_.NET.Files.Addrotatorexample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:AdRotator ID="AdRotator" runat="server" AdvertisementFile="~/advertise.xml" OnAdCreated="AdRotator1_AdCreated" style="z-index: 1; left: 22px; top: 74px; position: absolute; height: 200px; width: 200px" Target="_blank" />
    </form>
</body>
</html>
