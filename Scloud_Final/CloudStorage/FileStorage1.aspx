<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileStorage.aspx.cs" Inherits="CloudStorage.FileStorage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>  
  
<html>  
<head runat="server">  
    <title></title>  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body {
  font-family: Arial, Helvetica, sans-serif;
overflow-y: hidden;
  background: #dde5f4;

  
}

.navbar {
  overflow: hidden;
  background-color: #333;
}

.navbar a {
  float: left;
  font-size: 16px;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

.dropdown {
  float: right;
  overflow: hidden;
}

.dropdown .dropbtn {
  font-size: 16px;  
  border: none;
  outline: none;
  color: white;
  padding: 14px 16px;
  background-color: inherit;
  font-family: inherit;
  margin: 0;
}

.navbar a:hover, .dropdown:hover .dropbtn {
  background-color: red;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  float: none;
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}

.dropdown-content a:hover {
  background-color: #ddd;
}

.dropdown:hover .dropdown-content {
  display: block;
}
        .auto-style2 {
            position: absolute;
            top: 405px;
            left: 111px;
            z-index: 1;
            width: 103px;
            height: 24px;
        }
        .auto-style3 {
            position: absolute;
            top: 123px;
            left: 413px;
            z-index: 1;
        }
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
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
    .auto-style4 {
        position: absolute;
        top: 545px;
        left: 9px;
        z-index: 1;
        width: 74px;
        height: 26px;
    }
    .auto-style5 {
        z-index: 1;
        left: 754px;
        top: 120px;
        position: absolute;
        height: 133px;
        width: 187px;
    }
    .auto-style6 {
        width: 1390px;
        height: 497px;
        position: absolute;
        top: 15px;
        left: 10px;
    }
    </style>
</head>  
<body>  
    <form id="form1" runat="server" class="auto-style6" style="z-index: 1">
         <div class="navbar">
 
    <a href="MainPage.aspx">Home</a>&nbsp;
    <a href="FileStorage.aspx">Cloud Storage</a>
    <a href="Contact.aspx">Contact Us</a>
    <a href="About.aspx">About</a>
  <div class="dropdown" >
    <button class="dropbtn">Personalization
      <i class="fa fa-caret-down" style="width: 22px"></i>
    </button>
    <div class="dropdown-content">
      <a href="SharedFiles.aspx">Shared Files</a>
      <a href="Profile.aspx">Profile</a>
     <a href="javascript:if(confirm('Are you sure you want to log out?')) window.location.href = 'Login.aspx';">Sign Out</a>
 
 
    </div>
  </div> 
</div>
        <div>
        <br />
        <asp:Button ID="Share_access" runat="server" CssClass="auto-style3" OnClick="New_folder_Click" Text="Share Access" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>
        <!-- ModalPopupExtender -->
        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Share_access"
    CancelControlID="Button_access" BackgroundCssClass="Background">
</cc1:ModalPopupExtender>
    <asp:Button ID="btPopupLoad" runat="server" Text="Load" CssClass="button" onclick="btPopupLoad_Click" style="display:none;"/>  
            </div>
            <script type="text/javascript">
                function abcd() {
                    var a = document.getElementById('TextBox_username').value;
                    document.getElementById("usernames_shared").value = a;
                    document.getElementById('<%= btPopupLoad.ClientID %>').click();
                }
            </script>
    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
    <asp:HiddenField ID="usernames_shared" runat="server" />
    <table>
    <tr>
    <td>
    <asp:Label ID="Label_username" runat="server" CssClass="lbl" Text="Username(s)"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TextBox_username" runat="server" Font-Size="14px" TextMode="MultiLine" ></asp:TextBox>
    </td>
    </tr>
        </table>
        <br/>
        <br />
    <asp:Button ID="Button_access" OnClientClick="abcd()" runat="server" Text="Grant Access" />
        </asp:Panel>
        <!-- ModalPopupExtender ends -->
        <div>
            <%--ASP.NET control to upload a file--%>  
            <asp:FileUpload ID="FileUpload1" runat="server" />  
               
            <%--Button to Upload the file--%>  
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File" Height="29px" />  
            <br />  
            <br />  
            <br />  
            <%--Gridview to Display the Available data with file Details--%><%--Generate the OnRowCommand Event Handler of the Gridview Control--%>  
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" Width="511px" Height="190px">  
                <AlternatingRowStyle BackColor="White" />  
                <Columns>  
                    <%--Item Template is used to Add a custom link button whose Eval Binding is "File"--%>  
                    <asp:TemplateField HeaderText="">  
                    <EditItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </ItemTemplate>  
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("File") %>' Text='<%# Eval("File") %>'></asp:LinkButton>  
                        </ItemTemplate> 
                    </asp:TemplateField>  
                    <asp:BoundField DataField="Size" HeaderText="Size (KB)" />  
                    <asp:BoundField DataField="Type" HeaderText="File Type with Extension" />  
                </Columns>  
                <EditRowStyle BackColor="#2461BF" />  
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
                <RowStyle BackColor="#EFF3FB" />  
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
                <SortedAscendingCellStyle BackColor="#F5F7FB" />  
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
                <SortedDescendingCellStyle BackColor="#E9EBEF" />  
                <SortedDescendingHeaderStyle BackColor="#4870BE" />  
            </asp:GridView>  
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView2_RowCommand" CssClass="auto-style5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="">  
                    <EditItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </ItemTemplate>  
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Folder Name">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("File") %>' Text='<%# Eval("File").ToString().Substring(Eval("File").ToString().LastIndexOf(@"\")+1) %>'></asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>  
        <asp:Button ID="Back" runat="server" CssClass="auto-style4" OnClick="Back_Click" Text="Back" />
        <asp:Label ID="Label1" runat="server" CssClass="auto-style2"></asp:Label>
        <asp:TextBox ID="txtFolderName" runat="server" Text=""></asp:TextBox>
<br />
<asp:Button ID="btnCreate" runat="server" Text="Create Folder" OnClick="btnCreate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete Folder" OnClick="btnDelete_Click" />
    </form>  
</body>  
</html>