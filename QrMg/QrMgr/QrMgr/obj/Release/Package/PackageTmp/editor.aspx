<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editor.aspx.cs" Inherits="QrMgr.editor" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Editor</title>
  <script type="text/javascript" src="ckeditor/ckeditor.js"></script>
  <script type="text/javascript" src="ckfinder/ckfinder.js"></script>
</head>
<body>
  
    <form id="form1" runat="server">
         <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="350" Width="600">
  </CKEditor:CKEditorControl>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
         <br />
         <br />
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
  
</body>
</html>
