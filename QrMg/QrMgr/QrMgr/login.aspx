<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="QrMgr.super_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 69px;
        }
        .auto-style4 {
            width: 79px;
        }
        .auto-style3 {
        }
        .auto-style5 {
            width: 69px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
    </style>
    <script>
        function RefreshCode(obj) {
            obj.src = obj.src + "?code=" + Math.random();
        }
    </script>
</head>
    
<body>
    <form id="form2" runat="server">
    <div>
        <table aria-checked="undefined" aria-sort="none" border="1" style="width: 42%; height: 96px;">
            <tr>
                <td class="auto-style1">用户名：</td>
                <td colspan="2">
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">密码：</td>
                <td colspan="2" class="auto-style6">
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">验证码：</td>
                <td class="auto-style4">
                    <img alt="" src="checkCode.aspx" style="height: 31px; width: 67px" onclick="RefreshCode(this)" /><br />
                </td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="enter" runat="server" OnClick="enter_Click" Text="登入" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="exit" runat="server" Text="退出" OnClick="exit_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>

</body>
</html>
