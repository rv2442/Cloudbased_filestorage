<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SharedFiles.aspx.cs" Inherits="CloudStorage.SharedFiles" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
               

<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="CSS/StyleSheet1.css"/>
    <style type="text/css">
        body{
            font-family: Arial, Helvetica, sans-serif;
            overflow-y: hidden;
             background: #dde5f4;
        }
        .auto-style1 {
            position: absolute;
            top: 451px;
            left: 7px;
            z-index: 1;
        }
        .auto-style4 {
            z-index: 1;
            left: 676px;
            top: 151px;
            position: absolute;
            height: 193px;
            width: 295px;
        }
        </style>
</head>  
<body>  
    <form id="form1" runat="server">  
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
        <div>  
            <%--ASP.NET control to upload a file--%>  
               
            <%--Button to Upload the file--%>  
            <br />  
            <br />  
            <br />  
            <%--Gridview to Display the Available data with file Details--%><%--Generate the OnRowCommand Event Handler of the Gridview Control--%>  
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowCommand="GridView2_RowCommand" CssClass="auto-style4">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField  HeaderText="Folder Name">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("File") %>' Text='<%# Eval("File").ToString().Substring(Eval("File").ToString().LastIndexOf(@"\")+1) %>'></asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>
                    <asp:BoundField DataField="Owner" HeaderText="Owner" />
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
        <asp:Button ID="Back" runat="server" CssClass="auto-style1" OnClick="Back_Click" Text="Back" style="height: 29px" Visible="False" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"  Width="512px" Height="195px">  
                <AlternatingRowStyle BackColor="White" />  
                <Columns>  
                    <%--Item Template is used to Add a custom link button whose Eval Binding is "File"--%>  
                    <asp:TemplateField HeaderText="File Name">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("File") %>' Text='<%# Eval("File") %>'></asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                    <asp:BoundField DataField="Size" HeaderText="Size (KB)" />  
                    <asp:BoundField DataField="Type" HeaderText="File Type" />  
                    <asp:BoundField  DataField="Owner" HeaderText="Owner" />  
 
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
        <p>
            &nbsp;&nbsp;</p>
    </form>  
</body>  
</html>