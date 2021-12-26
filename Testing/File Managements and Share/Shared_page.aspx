<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shared_page.aspx.cs" Inherits="Website_.NET.Shared_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 451px;
            left: 7px;
            z-index: 1;
        }
        .auto-style4 {
            z-index: 1;
            left: 643px;
            top: 110px;
            position: absolute;
            height: 291px;
            width: 306px;
        }
        </style>
</head>  
<body>  
    <form id="form1" runat="server">  
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"  Width="530px" Height="295px">  
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
