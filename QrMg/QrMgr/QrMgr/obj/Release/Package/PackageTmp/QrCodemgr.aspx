<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QrCodemgr.aspx.cs" Inherits="QrMgr.QrCodemgr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
    
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
            <asp:ListItem Value="customized">自定义地址</asp:ListItem>
            <asp:ListItem Value="generated">自动生成</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="TextBox_urlinput" runat="server">填写希望生成的地址</asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox_comment" runat="server" Height="59px" TextMode="MultiLine" Width="253px">内容 备注</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="取消选择" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="qrId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" ViewStateMode="Disabled" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="qrId" HeaderText="qrId" InsertVisible="False" ReadOnly="True" SortExpression="qrId" />
                <asp:BoundField DataField="uploadId" HeaderText="uploadId" SortExpression="uploadId" />
                <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
                <asp:BoundField DataField="生成时间" HeaderText="生成时间" SortExpression="生成时间" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                <asp:ImageField DataImageUrlField="Url" DataImageUrlFormatString="GenQr.aspx?url={0}" HeaderText="二维码" ReadOnly="True">
                </asp:ImageField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString %>" SelectCommand="SELECT [uploadId], [类型], [路径], [备注] FROM [upload]"></asp:SqlDataSource>
        <asp:Button ID="Button_associate" runat="server" OnClick="Button2_Click" Text="关联" />
        <asp:Button ID="Button_disassociate" runat="server" OnClick="Button_disassociate_Click" Text="解除关联" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qrmgrConnectionString2 %>" SelectCommand="SELECT [qrId], [uploadId], [Url], [生成时间], [备注] FROM [qrcode]"></asp:SqlDataSource>
    
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="uploadId" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" HorizontalAlign="Left">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="uploadId" HeaderText="uploadId" InsertVisible="False" ReadOnly="True" SortExpression="uploadId" />
                <asp:BoundField DataField="类型" HeaderText="类型" SortExpression="类型" />
                <asp:BoundField DataField="路径" HeaderText="路径" SortExpression="路径" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
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
        <br />
        <br />
    
    </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="资源管理界面" />
        </p>
    </form>
</body>
</html>
