<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="QrMgr.admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder4">
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
                        <div style="height: 68px">
                            </div>
                    </asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">
                        <div style="height: 451px">
                            <asp:Label ID="Label1" runat="server" Text="欢迎使用系统"></asp:Label>
                        
                            <asp:Label ID="Label_username" runat="server" Text="用户名" CssClass="pull-right"></asp:Label>
                        
                            <br />
                            <br />
                            <asp:Panel ID="Panel1" runat="server" Height="379px">
                                <table style="width:100%; height: 378px;">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="130px" Width="100px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton2" runat="server" Height="108px" Width="79px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton3" runat="server" Height="108px" Width="79px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="ImageButton4" runat="server" Height="108px" Width="79px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton5" runat="server" Height="108px" Width="79px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton6" runat="server" Height="108px" Width="79px" CssClass="center-block" ImageUrl="~/upload/notfound.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        
                        </div>
                    </asp:Content>

