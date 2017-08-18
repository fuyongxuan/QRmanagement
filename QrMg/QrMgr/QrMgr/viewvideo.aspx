<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewvideo.aspx.cs" Inherits="QrMgr.viewvideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="script/video-js.css" rel="stylesheet" />
    <script src="script/video.js"></script>
    <script src="script/videojs-ie8.min.js"></script>
    <style>
        .css{width:800px;height:600px;display:block;margin:auto;}
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <video class="css video-js vjs-default-skin vjs-big-play-centered" width="640" height="480" controls>
  <source src="<%=geturl() %>" type="video/mp4">
 
Your browser does not support the video tag.
</video>
    
    </form>
</body>
</html>
