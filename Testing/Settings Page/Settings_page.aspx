<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings_page.aspx.cs" Inherits="Website_.NET.Settings_page" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1035px;
            width: 2494px;
        }

        #myProgress {
          width: 79%;
          background-color: #ddd;
            height: 8px;
        }

        #myBar {
          width: 10%;
          height: 7px;
          background-color: #04AA6D;
          text-align: center;
          line-height: 30px;
          color: white;
        }
    </style>
    
</head>
<body>

    
    <form id="form1" runat="server">
                        <asp:Button ID="Button1" runat="server" Text="Button" onclientclick="move(); return false;" style="display:none "  />

                 <script type="text/javascript">  
                     $(document).ready(function move() {
                         //var i = 0;
                         //if (i == 0) {
                         //    i = 1;
                             var elem = document.getElementById("myBar");
                             let width = 0;
                             //var id = setInterval(frame, 10);
                             //function frame() {
                             //    if (width >= 100) {
                             //        clearInterval(id);
                             //        i = 0;
                                     
                             //    } else {
                             //        width++;
                             //        elem.style.width = width + "%";
                             //        elem.innerHTML = width + "%";
                             //    }
                             //}
                             //for (width = 0; width <= 60; width++) {
                                 elem.style.width = <%=saze%> + "%";
                         elem.innerHTML = <%=saze%> + "%";
                             //}
                         //}
                     })
            //document.getElementById("Button1").click();
                 </script>
        
        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Blue" BorderWidth="30px" ForeColor="Black" style="z-index: 1;border-radius: 45px; left: 612px; top: 54px; position: absolute; height: 864px; width: 936px">
            <asp:Panel ID="Panel2" runat="server" BackColor="#99CCFF" style="z-index: 1; left: -616px; top: -29px; position: absolute; border-radius: 35px; height: 923px; width: 559px">
                <div id="myProgress" style="position:absolute; border-radius: 5px; top: 529px; left: 47px;">
                    <div id="myBar" style="position:absolute; border-radius: 5px; top: -1px; left: 0px;">10%</div>        
                

                </div>
                <asp:Panel ID="Panel4" runat="server" BackColor="#F7F7F7" style="z-index: 1;  left: 73px; top: 667px; border-radius: 25px; position: absolute; height: 154px; width: 417px">
                </asp:Panel>
                <asp:Image ID="Image4" runat="server" ImageUrl="~/premium icon.png" style="z-index: 1; left: 179px; top: 760px; position: absolute;border-radius: 25px; height: 24px; width: 40px" />
            </asp:Panel>
            <asp:LinkButton ID="LinkButton2" runat="server" style="z-index: 1; left: -401px; top: 747px; position: absolute; margin-bottom: 2px">Upgrade to Tier 2</asp:LinkButton>
            <asp:Image ID="profimg" runat="server" style="z-index: 1; left: -572px; top: -3px; position: absolute; height: 407px; width: 462px;" ImageUrl="~/user_icon.png" />
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Panel1" ForeColor="Black" style="z-index: 1; left: 102px; top: 91px; position: absolute; height: 30px; width: 96px; margin-bottom: 0px" Text="Username : "></asp:Label>
            <asp:Label ID="usernametxt" runat="server" style="z-index: 1; left: 205px; top: 90px; position: absolute; height: 30px; width: 152px"></asp:Label>
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 100px; top: 164px; position: absolute; height: 28px; width: 79px" Text="Email Id : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" BorderColor="White" ForeColor="Black" Height="45px" style="z-index: 1; left: 299px; top: 7px; position: absolute; height: 68px; width: 343px" Text="Settings"></asp:Label>
            <asp:Label ID="emailtxt" runat="server" style="z-index: 1; left: 204px; top: 163px; position: absolute; height: 29px; width: 289px"></asp:Label>
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 100px; top: 225px; position: absolute; height: 25px; width: 74px" Text="Password :"></asp:Label>
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 205px; top: 229px; position: absolute; height: 21px; width: 121px" Text="********"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" style="z-index: 1; left: 98px; top: 288px; position: absolute; height: 36px; width: 187px">Change Password?</asp:LinkButton>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" style="z-index: 1; left: 287px; top: 536px; position: absolute; height: 92px; width: 221px">
                <asp:ListItem>On</asp:ListItem>
                <asp:ListItem>Off</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 90px; top: 541px; position: absolute; height: 83px; width: 156px" Text="2 Factor Authentication :-  (Face Recognition)"></asp:Label>
            <asp:Panel ID="Panel3" runat="server" BackColor="#99CCFF" BorderColor="#3399FF" style="z-index: 1; top: -30px; border-radius: 35px; position: absolute; height: 922px; width: 844px; left: 996px; padding-left:50px">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/cloud2images.jpg" style="z-index: 1; left: 24px; border-radius: 25px; top: 23px; position: absolute; height: 473px; width: 838px; padding-left:1px" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/cloud1images.jpg" style="z-index: 1; left: 21px; border-radius: 25px; top: 519px; position: absolute; height: 377px; width: 848px; padding-left:1px" />
            </asp:Panel>
            <asp:Label ID="Label7" runat="server" style="z-index: 1; left: -136px; top: 482px; position: absolute; height: 22px; width: 52px" Text="1 GB"></asp:Label>
            <asp:Label ID="Label8" runat="server" style="z-index: 1; left: -427px; top: 699px; position: absolute; height: 36px; width: 166px" Text="Running Low on Space ?"></asp:Label>
        </asp:Panel>
        
    </form>
</body>
</html>
