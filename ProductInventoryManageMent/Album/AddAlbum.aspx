<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.aspx.cs" Inherits="ProductInventoryManagement.Album.AddAlbum" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>创建相册</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/css.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formSend() {
            var albumname = $("#AlbumName").val();
            var albumtypeid = $("#<%=ddl_AlbumTypeList.ClientID%>").val();
            var albumdesc = $("#AlbumDesc").val();
            if (albumtypeid == "-1") {
                $('#content-body').html("相册类型不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (albumname == "") {
                $('#content-body').html("相册名称不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            $.ajax({
                type: "post",
                url: "../ashx/album.ashx?param=addalbum",
                dataType: "text",
                data: "AlbumName=" + albumname + "&&AlbumTypeID=" + albumtypeid + "&&AlbumDesc=" + albumdesc + "",
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
                    <li>创建相册</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">创建相册</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                相册类型</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_AlbumTypeList" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="AlbumName" class="col-sm-4 control-label">
                相册名称</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="AlbumName" id="AlbumName" required="required"
                    placeholder="相册名称" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="AlbumDesc" class="col-sm-4 control-label">
                相册描述</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="AlbumDesc" id="AlbumDesc" maxlength="200"
                    placeholder="相册描述" />
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
