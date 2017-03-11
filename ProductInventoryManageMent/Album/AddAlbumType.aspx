<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAlbumType.aspx.cs" Inherits="ProductInventoryManagement.Album.AddAlbumType" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>相册类别添加</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/css.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        function formSend() {
            var albumtype = $("#AlbumTypeName").val();

            if (albumtype == "") {
                $('#content-body').html("相册类别不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            $.ajax({
                type: "post",
                url: "../ashx/album.ashx?param=addtype",
                dataType: "text",
                data: "AlbumTypeName=" + albumtype + "",
                contentType: "application/x-www-form-urlencoded",
                success: function (data) {
                    if (data == "ok") {
                        $('#content-body').html("添加成功！");
                        $('#myModal').modal('toggle');
                    }
                    else {
                        $('#content-body').html("添加失败！");
                        $('#myModal').modal('toggle');
                        return false;
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" class="form-horizontal" role="form" runat="server">
    <div class="container" style="width: 100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                    <li>当前位置：</li>
                    <li>相册管理</li>
                    <li>相册类别添加</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">相册类别添加</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="AlbumTypeName" class="col-sm-4 control-label">
                相册类别</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="AlbumTypeName" id="AlbumTypeName" required="required"
                    placeholder="相册类别" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <div class="col-sm-offset-4 col-sm-4">
                <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="添加" />
                <button type="reset" class="btn btn-primary">
                    取消</button>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">
                        提示信息</h4>
                </div>
                <div id="content-body" class="modal-body">
                    1111
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
