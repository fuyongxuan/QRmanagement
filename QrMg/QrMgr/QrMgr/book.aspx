<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="QrMgr.book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style6 {
        width: 130px;
    }
    .auto-style7 {
        height: 20px;
        width: 130px;
    }
    .auto-style10 {
        height: 144px;
    }
    .auto-style11 {
        height: 17px;
    }
        .auto-style12 {
            height: 144px;
            width: 333px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <div style="height: 68px">
                        </div>
                    </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder4">
    <div style="height: 449px; width: 153px">
                            <asp:TreeView ID="TreeView1" runat="server">
    <Nodes>
        <asp:TreeNode Text="教材管理" Value="index" Expanded="True" NavigateUrl="book.aspx">
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
        <asp:TreeNode Text="用户管理" Value="用户管理" NavigateUrl="useradmin.aspx" Expanded="False">
            <asp:TreeNode Text="添加用户" Value="添加用户" NavigateUrl="useradmin.aspx?action=add"></asp:TreeNode>
            <asp:TreeNode Text="修改密码" Value="编辑用户" NavigateUrl="useradmin.aspx?action=edit&username=" ></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="向导" Value="向导" NavigateUrl="guide.aspx"></asp:TreeNode>
    </Nodes>
                                <SelectedNodeStyle BackColor="#CCCCCC" />
</asp:TreeView>
                        </div>
                    </asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <div style="height: 441px">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="add" runat="server">
                                    <table aria-atomic="False" class="table-bordered" style="width: 95%; margin-left: 16px;">
                                        <tr>
                                            <td class="auto-style7">
                                                <asp:Label ID="Label1" runat="server" Text="书名"></asp:Label>
                                            </td>
                                            <td class="auto-style1" colspan="2">
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label2" runat="server" Text="ISBN"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label3" runat="server" Text="作者"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label4" runat="server" Text="出版日期"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Calendar ID="Calendar1" runat="server">
                                                    <TodayDayStyle BackColor="#CCCCCC" />
                                                </asp:Calendar>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                <asp:Label ID="Label5" runat="server" Text="简介"></asp:Label>
                                            </td>
                                            <td class="auto-style12">
                                                <asp:TextBox ID="TextBox4" runat="server" Height="82px" TextMode="MultiLine" Width="335px"></asp:TextBox>
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style10">
                                                <br />
                                                请选择封面图片<asp:FileUpload ID="FileUpload1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style11" colspan="3">
                                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CssClass="center-block" OnClick="Button1_Click" Text="添加" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="list" runat="server">
                                    <asp:GridView ID="GridView1"   runat="server" AutoGenerateColumns="False" DataKeyNames="Book_ISBN" DataSourceID="SqlDataSource1" ShowHeaderWhenEmpty="True" AllowPaging="True" AutoGenerateDeleteButton="True" Height="414px" Width="704px" AutoGenerateSelectButton="True" OnRowDeleting="GridView1_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="Book_Title" HeaderText="书名" SortExpression="Book_Title" />
                                            <asp:BoundField DataField="Book_ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="Book_ISBN" />
                                            <asp:BoundField DataField="Book_Author" HeaderText="作者" SortExpression="Book_Author" />
                                            <asp:BoundField DataField="Book_Brief" HeaderText="简介" SortExpression="Book_Brief" />
                                            <asp:BoundField DataField="Book_Date" HeaderText="出版日期" SortExpression="Book_Date" DataFormatString="{0:yyyy-MM-dd}" />
                                        </Columns>
                                        <EditRowStyle Width="10%" />
                                        <EmptyDataRowStyle Wrap="True" />
                                        <HeaderStyle Height="50px" Width="15%" />
                                        <SelectedRowStyle BackColor="#CCCCCC" BorderStyle="None" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT * FROM [book]" DeleteCommand="DELETE FROM [book] WHERE [Book_ISBN] = @Book_ISBN" InsertCommand="INSERT INTO [book] ([Book_Title], [Book_ISBN], [Book_Author], [Book_Brief], [Book_Date]) VALUES (@Book_Title, @Book_ISBN, @Book_Author, @Book_Brief, @Book_Date)" UpdateCommand="UPDATE [book] SET [Book_Title] = @Book_Title, [Book_Author] = @Book_Author, [Book_Brief] = @Book_Brief, [Book_Date] = @Book_Date WHERE [Book_ISBN] = @Book_ISBN">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Book_ISBN" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Book_Title" Type="String" />
                                            <asp:Parameter Name="Book_ISBN" Type="String" />
                                            <asp:Parameter Name="Book_Author" Type="String" />
                                            <asp:Parameter Name="Book_Brief" Type="String" />
                                            <asp:Parameter DbType="Date" Name="Book_Date" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Book_Title" Type="String" />
                                            <asp:Parameter Name="Book_Author" Type="String" />
                                            <asp:Parameter Name="Book_Brief" Type="String" />
                                            <asp:Parameter DbType="Date" Name="Book_Date" />
                                            <asp:Parameter Name="Book_ISBN" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style1"></td>
                                            <td class="auto-style1"></td>
                                            <td class="auto-style1"></td>
                                            <td class="auto-style1"></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="导出" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" runat="server" CssClass="center-block" OnClick="Button2_Click" Text="编辑" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                </asp:View>
                                <asp:View ID="edit" runat="server">
                                    <table aria-atomic="False" class="table-bordered" style="width: 95%; margin-left: 16px;">
                                        <tr>
                                            <td class="auto-style7">
                                                <asp:Label ID="Label6" runat="server" Text="书名"></asp:Label>
                                            </td>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label7" runat="server" Text="ISBN"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label8" runat="server" Text="作者"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label9" runat="server" Text="出版日期"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                <asp:Label ID="Label10" runat="server" Text="简介"></asp:Label>
                                            </td>
                                            <td class="auto-style10">
                                                <asp:TextBox ID="TextBox_newbrief" runat="server" Height="82px" TextMode="MultiLine" Width="335px"></asp:TextBox>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style11" colspan="2">
                                                <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="center-block" OnClick="Button3_Click" Text="保存编辑" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </asp:Content>

