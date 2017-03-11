<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoDetail.aspx.cs" Inherits="ProductInventoryManagement.Album.PhotoDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    var widthScreen = window.innerWidth;
        //    var heightScrenn = window.innerHeight;
        //    $("img").width(widthScreen).height(heightScrenn);

        //});
    </script>
    <style type="text/css">
        /*body {
            padding: 50px;
        }*/
    </style>
</head>
<body>
        <div style="width: 100%;">
            <div style="margin-left: auto; margin-right: auto; width: 900px;">
                <img src="<%=imgurl %>" width="900" height="700" style="margin-top:50px;" alt="" />
            </div>
        </div>
</body>
</html>
