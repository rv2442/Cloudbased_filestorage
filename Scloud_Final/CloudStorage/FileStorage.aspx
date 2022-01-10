<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileStorage.aspx.cs" Inherits="CloudStorage.FileStorage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>  
  
<html>  
<head runat="server">  
    <title></title>  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="CSS/StyleSheet1.css">
    <style type="text/css">
           body {
    font-family: Arial, Helvetica, sans-serif;
    background :#dde5f4 
    
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
        #form1 {
            height: 74px;
            margin-top: 2px;
        }
        .auto-style1 {
            margin-bottom: 0px;
        }
        </style>
</head>  
<body>  
    <form id="form1" runat="server" style="margin-left: 0px;">
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
      <a href="Settings.aspx">Settings</a>
     <a href="javascript:if(confirm('Are you sure you want to log out?')) window.location.href = 'Login.aspx';">Sign Out</a>
 
 
    </div>
  </div> 
</div>
 
      <div style="background-color:#000091; margin-top: 0px" class="auto-style1">  
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>
      
                 &nbsp    <asp:Button ID="Back" runat="server"  OnClick="Back_Click" Text="Back" Height="28px" Width="50px" /> &nbsp 

            <%--ASP.NET control to upload a file--%>  
            <asp:FileUpload ID="FileUpload1" runat="server" Height="31px"  /> &nbsp 
            <%--Button to Upload the file--%>  
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File" Height="29px" Width="119px"  />  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
           
            
            <asp:Button ID="btnCreate" runat="server" Text="Create Folder" OnClick="btnCreate_Click" Height="28px" Width="154px"/> &nbsp 
            <asp:TextBox ID="txtFolderName" runat="server" Text="" Height="20px" Width="157px" ></asp:TextBox> &nbsp 
            <asp:Button ID="btnDelete" runat="server" Text="Delete " OnClick="btnDelete_Click" Height="27px" Width="68px"  /> &nbsp &nbsp &nbsp &nbsp 
                    &nbsp <asp:Button ID="Share_access" runat="server" OnClick="New_folder_Click" Text="Share Access" />&nbsp &nbsp

      </div> 
         <asp:Label ID="Label1" runat="server" ForeColor="red" ></asp:Label>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView2_RowCommand" style="z-index: 1; left: 606px; top: 146px; position: absolute; height: 172px; width: 426px">
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
         
        <!-- ModalPopupExtender -->
        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Share_access"
    CancelControlID="Button_access" BackgroundCssClass="Background">
</cc1:ModalPopupExtender>
    <asp:Button ID="btPopupLoad" runat="server" Text="Load" CssClass="button" onclick="btPopupLoad_Click" style="display:none;"/>  
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" style="position: absolute; top: 145px; left: 27px;" Width="513px">  
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

    </form>  
</body>  
</html>