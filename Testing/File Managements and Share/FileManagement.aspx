<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManagement.aspx.cs" Inherits="Website_.NET.grid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>  
  
<html>  
<head runat="server">  
    <title></title>  
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 47px;
            left: 35px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 100px;
            left: 37px;
            z-index: 1;
            width: 453px;
            height: 36px;
        }
        .auto-style3 {
            position: absolute;
            top: 48px;
            left: 1074px;
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
        #form1 {
            height: 74px;
            margin-top: 2px;
        }
    </style>
</head>  
<body>  
    <form id="form1" runat="server" style="margin-left: 0px;">
        <asp:Button ID="Share_access" runat="server" CssClass="auto-style3" OnClick="New_folder_Click" Text="Share Acess" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>
        <div style="height: 82px; background-color:blueviolet; margin-top: 0px">
            <%--ASP.NET control to upload a file--%>  
            <asp:FileUpload ID="FileUpload1" runat="server"  style="position: absolute; top: 50px; left: 396px; right: 983px;"/>  
               
            <%--Button to Upload the file--%>  
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File" style="position: absolute; top: 49px; left: 260px;" />  
            <br />  
            <br />  
            <br />  
            <%--Gridview to Display the Available data with file Details--%><%--Generate the OnRowCommand Event Handler of the Gridview Control--%>  
                    <asp:Button ID="Back" runat="server" CssClass="auto-style1" OnClick="Back_Click" Text="Back" />
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" style="position: absolute;"></asp:Label>
        <asp:TextBox ID="txtFolderName" runat="server" Text="" style="position: absolute; top: 49px; left: 908px;"></asp:TextBox>
            <asp:Button ID="btnCreate" runat="server" Text="Create Folder" OnClick="btnCreate_Click" style="position: absolute; top: 49px; left: 640px;"/>
<asp:Button ID="btnDelete" runat="server" Text="Delete Folder" OnClick="btnDelete_Click" style="position: absolute; top: 48px; left: 780px;" />
            </div> 
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
