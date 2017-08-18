<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="guide.aspx.cs" Inherits="QrMgr.guide" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 20px;
            width: 437px;
        }
        .auto-style5 {
            width: 437px;
        }
        .auto-style6 {
            width: 439px;
        }
        .auto-style7 {
            width: 441px;
        }
        .auto-style8 {
            width: 446px;
        }
        .auto-style9 {
            width: 469px;
        }
        .auto-style10 {
            width: 432px;
        }
        .auto-style11 {
            width: 422px;
        }
        .auto-style12 {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder2">
                        <div style="height: 68px">
                        </div>
                    </asp:Content>
<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder3">
                        <div style="height: 451px">
                            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" Height="411px" Width="750px" OnFinishButtonClick="Wizard1_FinishButtonClick" OnNextButtonClick="Wizard1_NextButtonClick">
                                <SideBarStyle Width="10%" />
                                <WizardSteps>
                                    <asp:WizardStep runat="server" title="教材">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                            <asp:ListItem>新建教材</asp:ListItem>
                                            <asp:ListItem>选择已有教材</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="add" runat="server">
                                                <table aria-atomic="False" class="table-bordered" style="width: 95%; margin-left: 16px;">
                                                    <tr>
                                                        <td class="auto-style7">
                                                            <asp:Label ID="Label1" runat="server" Text="书名"></asp:Label>
                                                        </td>
                                                        <td class="auto-style4" colspan="2">
                                                            <asp:TextBox ID="TextBox_title" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">
                                                            <asp:Label ID="Label2" runat="server" Text="ISBN"></asp:Label>
                                                        </td>
                                                        <td class="auto-style5" colspan="2">
                                                            <asp:TextBox ID="TextBox_isbn" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">
                                                            <asp:Label ID="Label3" runat="server" Text="作者"></asp:Label>
                                                        </td>
                                                        <td class="auto-style5" colspan="2">
                                                            <asp:TextBox ID="TextBox_author" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">
                                                            <asp:Label ID="Label4" runat="server" Text="出版日期"></asp:Label>
                                                        </td>
                                                        <td class="auto-style5" colspan="2">
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
                                                            <asp:TextBox ID="TextBox_brief" runat="server" Height="82px" TextMode="MultiLine" Width="263px"></asp:TextBox>
                                                            <br />
                                                            <br />
                                                        </td>
                                                        <td class="auto-style5">上传封面图片<asp:FileUpload ID="FileUpload2" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style11" colspan="3">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View1" runat="server">
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT [Book_ISBN] FROM [book]"></asp:SqlDataSource>
                                                &nbsp;选择教材ISBN号<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Book_ISBN" DataValueField="Book_ISBN">
                                                </asp:DropDownList>
                                            </asp:View>
                                        </asp:MultiView>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" title="知识点">
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                            <asp:ListItem>添加知识点</asp:ListItem>
                                            <asp:ListItem>选择已有知识点</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:MultiView ID="MultiView2" runat="server">
                                            <asp:View ID="View3" runat="server">
                                                <asp:Label ID="Label6" runat="server" Text="请输入知识点页码"></asp:Label>
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                <br />
                                                请输入知识点名称<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource4" Height="150px" Width="373px" AllowPaging="True">
                                                    <Columns>
                                                        <asp:CommandField ShowSelectButton="True" />
                                                        <asp:BoundField DataField="Book_ISBN" HeaderText="ISBN" SortExpression="Book_ISBN" />
                                                        <asp:BoundField DataField="Pos" HeaderText="页码" SortExpression="Pos" />
                                                        <asp:BoundField DataField="seq" HeaderText="页序号" SortExpression="seq" />
                                                        <asp:BoundField DataField="qrid" HeaderText="二维码id" SortExpression="qrid" />
                                                        <asp:BoundField DataField="name" HeaderText="知识点名称" SortExpression="name" />
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#CCCCCC" />
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT * FROM [position]"></asp:SqlDataSource>
                                            </asp:View>
                                        </asp:MultiView>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="资源">
                                        <asp:MultiView ID="MultiView3" runat="server">
                                            <asp:View ID="add0" runat="server">
                                                <asp:Label ID="Label7" runat="server" Width="40%"></asp:Label>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="auto-style9">
                                                            <asp:Label ID="Label8" runat="server" Text="类型"></asp:Label>
                                                        </td>
                                                        <td class="auto-style5">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                <asp:ListItem Value="video">视频</asp:ListItem>
                                                                <asp:ListItem Value="pic">图片</asp:ListItem>
                                                                <asp:ListItem Value="html">网页</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style9">&nbsp;<asp:Label runat="server" Text="备注" Width="20px"></asp:Label>
                                                        </td>
                                                        <td class="auto-style6">
                                                            <asp:TextBox ID="TextBox1" runat="server" Height="52px" TextMode="MultiLine" Width="167px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style9">
                                                            <asp:Label ID="Label9" runat="server" Text="选择文件"></asp:Label>
                                                        </td>
                                                        <td class="auto-style8">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                            <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Visible="False" Width="600px"></CKEditor:CKEditorControl>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="二维码">
                                        <asp:Image ID="Image1" runat="server" />
                                    </asp:WizardStep>
                                </WizardSteps>
                            </asp:Wizard>
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
        <asp:TreeNode Text="向导" Value="向导" NavigateUrl="guide.aspx" Checked="True"></asp:TreeNode>
    </Nodes>
                                <SelectedNodeStyle BackColor="#CCCCCC" />
</asp:TreeView>
                        </div>
                    </asp:Content>

