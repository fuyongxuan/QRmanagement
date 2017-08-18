<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="QrMgr.upload1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 297px;
        }
        .auto-style5 {
            height: 59px;
        }
        .auto-style6 {
            height: 88px;
        }
        .auto-style7 {
            width: 297px;
            height: 20px;
        }
    .auto-style8 {
        height: 222px;
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
                                    <asp:Label ID="Label4" runat="server" Width="40%"></asp:Label>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style5">
                                                <asp:Label ID="Label1" runat="server" Text="类型"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem Value="video">视频</asp:ListItem>
                                                    <asp:ListItem Value="pic">图片</asp:ListItem>
                                                    <asp:ListItem Value="html">网页</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label runat="server" Text="备注"></asp:Label>
                                            </td>
                                            <td class="auto-style6">
                                                <asp:TextBox ID="TextBox1" runat="server" Height="52px" TextMode="MultiLine" Width="167px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label2" runat="server" Text="选择文件"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="200px" Visible="False" Width="600px"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="Button1" runat="server" CssClass="center-block" OnClick="Button1_Click" Text="添加" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="list" runat="server">
                                    <asp:Label ID="Label_boot" runat="server" Width="40%"></asp:Label>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="uploadId" DataSourceID="SqlDataSource1" Height="169px" OnRowDataBound="GridView1_RowDataBound" Width="727px" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="uploadId" HeaderText="资源号" InsertVisible="False" ReadOnly="True" SortExpression="uploadId" />
                                            <asp:BoundField DataField="类型" HeaderText="类型" SortExpression="类型" />
                                            <asp:BoundField DataField="路径" HeaderText="路径" SortExpression="路径" />
                                            <asp:BoundField DataField="上传时间" HeaderText="上传时间" SortExpression="上传时间" />
                                            <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                                            <asp:BoundField DataField="是否启用" HeaderText="是否启用" SortExpression="是否启用" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#CCCCCC" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" DeleteCommand="DELETE FROM [upload] WHERE [uploadId] = @uploadId" InsertCommand="INSERT INTO [upload] ([类型], [路径], [上传时间], [备注], [是否启用]) VALUES (@类型, @路径, @上传时间, @备注, @是否启用)" SelectCommand="SELECT [uploadId], [类型], [路径], [上传时间], [备注], [是否启用] FROM [upload]" UpdateCommand="UPDATE [upload] SET [类型] = @类型, [路径] = @路径, [上传时间] = @上传时间, [备注] = @备注, [是否启用] = @是否启用 WHERE [uploadId] = @uploadId">
                                        <DeleteParameters>
                                            <asp:Parameter Name="uploadId" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="类型" Type="String" />
                                            <asp:Parameter Name="路径" Type="String" />
                                            <asp:Parameter Name="上传时间" Type="DateTime" />
                                            <asp:Parameter Name="备注" Type="String" />
                                            <asp:Parameter Name="是否启用" Type="Int32" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="类型" Type="String" />
                                            <asp:Parameter Name="路径" Type="String" />
                                            <asp:Parameter Name="上传时间" Type="DateTime" />
                                            <asp:Parameter Name="备注" Type="String" />
                                            <asp:Parameter Name="是否启用" Type="Int32" />
                                            <asp:Parameter Name="uploadId" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style7"></td>
                                            <td class="auto-style1"></td>
                                            <td class="auto-style1"></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style4">&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="禁用" />
                                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="启用" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style4">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
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
        <asp:TreeNode Text="知识点管理" Value="新建节点" Expanded="False" NavigateUrl="point.aspx">
            <asp:TreeNode Text="添加知识点" Value="添加知识点" NavigateUrl="point.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="编辑知识点" Value="编辑知识点" NavigateUrl="point.aspx?action=edit"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="资源管理" Value="新建节点" Expanded="True" NavigateUrl="upload.aspx">
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

