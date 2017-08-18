<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="point.aspx.cs" Inherits="QrMgr.point" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 60px;
        }
        .auto-style6 {
            height: 217px;
        }
        .auto-style7 {
            height: 80px;
        }
        .auto-style8 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder2">
                        <div style="height: 68px">
                        </div>
                    </asp:Content>
<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder3">
                        <div style="height: 451px">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="add" runat="server">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT [Book_Title], [Book_ISBN] FROM [book]"></asp:SqlDataSource>
                                    <table style="width: 100%; height: 382px;">
                                        <tr>
                                            <td class="auto-style6">选择教材</td>
                                            <td class="auto-style6">
                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="Book_ISBN" DataSourceID="SqlDataSource1" Height="16px" Width="536px">
                                                    <Columns>
                                                        <asp:BoundField DataField="Book_Title" HeaderText="书名" SortExpression="Book_Title" />
                                                        <asp:BoundField DataField="Book_ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="Book_ISBN" />
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#CCCCCC" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">选择二维码</td>
                                            <td class="auto-style7">
                                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="qrId" DataSourceID="SqlDataSource3" Width="532px">
                                                    <Columns>
                                                        <asp:BoundField DataField="qrId" HeaderText="二维码id" InsertVisible="False" ReadOnly="True" SortExpression="qrId" />
                                                        <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                                                        <asp:BoundField DataField="uploadId" HeaderText="资源id" SortExpression="uploadId" />
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#CCCCCC" />
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT [qrId], [备注], [uploadId] FROM [qrcode]"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">页码</td>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">名称</td>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="TextBox_position_name" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="Button1" runat="server" CssClass="center-block" Height="25px" OnClick="Button1_Click" Text="添加" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="list" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" DataKeyNames="Id" DataSourceID="SqlDataSource2" Width="772px" OnRowDeleting="GridView2_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="Book_ISBN" HeaderText="ISBN" SortExpression="Book_ISBN" />
                                            <asp:BoundField DataField="Pos" HeaderText="页码" SortExpression="Pos" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                            <asp:BoundField DataField="seq" HeaderText="页序号" SortExpression="seq" />
                                            <asp:BoundField DataField="qrid" HeaderText="二维码id" SortExpression="qrid" />
                                            <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#CCCCCC" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" DeleteCommand="DELETE FROM [position] WHERE [Id] = @Id" InsertCommand="INSERT INTO [position] ([Book_ISBN], [Pos], [seq]) VALUES (@Book_ISBN, @Pos, @seq)" SelectCommand="SELECT * FROM [position]" UpdateCommand="UPDATE [position] SET [Book_ISBN] = @Book_ISBN, [Pos] = @Pos, [seq] = @seq WHERE [Id] = @Id">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Id" Type="Int64" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Book_ISBN" Type="String" />
                                            <asp:Parameter Name="Pos" Type="String" />
                                            <asp:Parameter Name="seq" Type="Int32" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Book_ISBN" Type="String" />
                                            <asp:Parameter Name="Pos" Type="String" />
                                            <asp:Parameter Name="seq" Type="Int32" />
                                            <asp:Parameter Name="Id" Type="Int64" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <asp:Button ID="Button2" runat="server" CssClass="center-block" OnClick="Button2_Click" Text="编辑" />
                                </asp:View>
                                <asp:View ID="edit" runat="server">
                                    <table style="width:100%; height: 235px;">
                                        <tr>
                                            <td class="auto-style4">
                                                <asp:Label ID="Label1" runat="server" Text="ISBN"></asp:Label>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                选择二维码</td>
                                            <td>
                                                <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="qrId" DataSourceID="SqlDataSource3" Width="532px">
                                                    <Columns>
                                                        <asp:BoundField DataField="qrId" HeaderText="二维码id" InsertVisible="False" ReadOnly="True" SortExpression="qrId" />
                                                        <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                                                        <asp:BoundField DataField="uploadId" HeaderText="资源id" SortExpression="uploadId" />
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#CCCCCC" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label2" runat="server" Text="页码"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">名称</td>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="TextBox_edit_position_name" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="Button3" runat="server" CssClass="center-block" OnClick="Button3_Click" Text="保存更改" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </asp:Content>
<asp:Content ID="Content7" runat="server" contentplaceholderid="ContentPlaceHolder4">
                        <div style="height: 449px; width: 153px">
                            <asp:TreeView ID="TreeView1" runat="server">
    <Nodes>
        <asp:TreeNode Text="教材管理" Value="index" Expanded="False" NavigateUrl="book.aspx">
            <asp:TreeNode Text="添加教材" Value="add" NavigateUrl="book.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="编辑教材" Value="edit" NavigateUrl="book.aspx?action=edit"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="知识点管理" Value="新建节点" Expanded="True" NavigateUrl="point.aspx">
            <asp:TreeNode Text="添加知识点" Value="添加知识点" NavigateUrl="point.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="编辑知识点" Value="编辑知识点" NavigateUrl="point.aspx?action=edit"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="资源管理" Value="新建节点" Expanded="False" NavigateUrl="upload.aspx">
            <asp:TreeNode Text="添加资源" Value="添加资源" NavigateUrl="upload.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="编辑资源" Value="编辑资源" NavigateUrl="upload.aspx?action=edit"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="二维码管理" Value="新建节点" Expanded="False" NavigateUrl="qr.aspx">
            <asp:TreeNode Text="添加二维码" Value="添加二维码" NavigateUrl="qr.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="编辑资源" Value="编辑资源" NavigateUrl="qr.aspx?action=edit"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="用户管理" Value="用户管理" Expanded="False" NavigateUrl="useradmin.aspx">
            <asp:TreeNode Text="添加用户" Value="添加用户" NavigateUrl="useradmin.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="修改密码" Value="编辑用户" NavigateUrl="useradmin.aspx?action=edit&username=" ></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="向导" Value="向导" NavigateUrl="guide.aspx"></asp:TreeNode>
    </Nodes>
                                <SelectedNodeStyle BackColor="#CCCCCC" />
</asp:TreeView>
                        </div>
                    </asp:Content>

