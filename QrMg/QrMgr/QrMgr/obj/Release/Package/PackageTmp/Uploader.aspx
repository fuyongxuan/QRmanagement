<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploader.aspx.cs" Inherits="QrMgr.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:TextBox ID="TextBox_comment" runat="server" Height="52px" TextMode="MultiLine" Width="218px">内容备注</asp:TextBox>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="pic">图片</asp:ListItem>
            <asp:ListItem Value="video">视频</asp:ListItem>
            <asp:ListItem Value="html">网页</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" />
        <br />
        <br />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="uploadId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="uploadId" HeaderText="uploadId" InsertVisible="False" ReadOnly="True" SortExpression="uploadId" />
                <asp:BoundField DataField="类型" HeaderText="类型" SortExpression="类型" />
                <asp:BoundField DataField="路径" HeaderText="路径" SortExpression="路径" />
                <asp:BoundField DataField="上传时间" HeaderText="上传时间" SortExpression="上传时间" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                <asp:BoundField DataField="是否启用" HeaderText="是否启用" SortExpression="是否启用" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString3 %>" SelectCommand="SELECT [uploadId], [类型], [路径], [上传时间], [备注], [是否启用] FROM [upload]"></asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="height: 21px" Text="启用" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="禁用" />
        <br />
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="二维码管理页面" />
        </p>
    </form>
</body>
</html>
