<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="ProductInventoryManagement.Album.ImageUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>照片上传</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/jquery.form.js" type="text/javascript"></script>
    <script type="text/javascript">
        function BtnSave() {
            var imgs = document.getElementById("fileAll").value;
            var imglength = document.getElementById("fileAll").files.length;
            var islarge = false;
            
            if (imgs == "") {
                $('#content-body').html("请选择图片！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (imglength >9) {
                $('#content-body').html("批量上传图片不能超过9张！");
                $('#myModal').modal('toggle');
                return false;
            }
            for (var i = 0; i < imglength; i++) {
                var imgsize = document.getElementById("fileAll").files[i].size;
                if (imgsize > 2097152) {
                    $('#content-body').html("第" + (i + 1) + "张图片过大, 图片大小不能超过2M！");
                    $('#myModal').modal('toggle');
                    islarge = true;
                    break;
                }
            }
            if (islarge) {
                return false;
            }
            else {
                $("#form1").ajaxSubmit({
                    type: "POST",
                    url: "../ashx/photo.ashx?param=upload&&AlbumId=<%=albumid%>&&AlbumName=<%=albumname%>&&AlbumPath=<%=albumpath%>",
                    success: function (data) {

                        if (data == "ok") {
                            $('#content-body').html("上传成功！");
                            $('#myModal').modal('toggle');
                            window.location = "AlbumPhotos.aspx?AlbumId=<%=albumid%>&&AlbumName=<%=albumname%>&&CoverPhotoPath=<%=coverphotopath%>";
                        }
                        if (data == "error") {
                            $('#content-body').html("错误，请检查图片格式，图片格式只能是jpeg,jpg,gif,png");
                            $('#myModal').modal('toggle');
                            return;
                        }
                        if (data == "more") {
                            $('#content-body').html("批量上传图片不能超过9张！");
                            $('#myModal').modal('toggle');
                            return;
                        }
                        if (data == "fail") {
                            $('#content-body').html("上传失败");
                            $('#myModal').modal('toggle');
                            return;
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" class="form-horizontal" role="form" runat="server" enctype="multipart/form-data">
        <div class="container" style="width: 100%;">
            <div class="row">
                <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                    <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                        <li>当前位置：</li>
                        <li><a href="AlbumPhotos.aspx?AlbumId=<%=albumid%>&&AlbumName=<%=albumname%>&&CoverPhotoPath=<%=coverphotopath%>"><%=albumname%></a></li>
                        <li>照片上传</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">照片上传</span>
            </div>
            <div class="form-group" style="text-align: center">
                <label class="col-sm-4 control-label">选择照片</label>
                <div class="col-sm-4">
                    <input id="fileAll" class="form-control" name="fileAll" type="file" multiple="multiple" />
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <label for="photoDesc" class="col-sm-4 control-label">照片描述</label>
                <div class="col-sm-4">
                    <input id="photoDesc" class="form-control" name="photoDesc" placeholder="照片描述" />
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <div class="col-sm-offset-4 col-sm-4">
                    <input type="button" class="btn btn-primary btn-sm" value="上传" onclick="BtnSave();" />
                    <button type="reset" class="btn btn-primary btn-sm">取消</button>
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
