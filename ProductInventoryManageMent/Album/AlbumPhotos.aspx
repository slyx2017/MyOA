<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumPhotos.aspx.cs" Inherits="ProductInventoryManagement.Album.AlbumPhotos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>照片列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckChange(obj) {
            $(obj).find('div').css("display", "block");
        }

        function aaa(obj) {
            $(obj).find('div').css("display", "none");
        }
        function DelPhoto(id, path, isface) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(id, path, isface);
            });
        }

        function Delete(id, path, isface) {
            $.post("../ashx/photo.ashx", "param=delete&&PhotoId=" + id + "&&PhotoPath=" + path + "&&IsAlbumFace=" + isface + "",
            function (data) {
                $('#myModal').modal('hide');
                if (data == "ok") {
                    $("#alertMsg").html("删除成功！");
                    $('#alertDialog').modal('show');
                    $('#alertDialog').on('hidden.bs.modal', function (e) {
                        window.location = "MyAlbum.aspx";
                    });
                } else {
                    $("#alertDialog").html("删除失败！");
                    $('#alertDialog').modal('show');
                    return false;
                }
            }, "text");
        }

        function SetAlbumFace(albumid, path, photoid) {
            $('#content-body').html("要设为封面吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                SetFace(albumid, path, photoid);
            });
        }
        function SetFace(albumid, path, photoid) {
            $.post("../ashx/album.ashx", "param=setface&&AlbumId=" + albumid + "&&CoverPhotoPath=" + path + "&&PhotoId=" + photoid + "",
                function (data) {
                    $('#myModal').modal('hide');
                    if (data == "ok") {
                        $("#alertMsg").html("设置成功！");
                        $('#alertDialog').modal('show');
                        $('#alertDialog').on('hidden.bs.modal', function (e) {
                            window.location = "MyAlbum.aspx";
                        });
                    } else {
                        $("#alertDialog").html("设置失败！");
                        $('#alertDialog').modal('show');
                        return false;
                    }
                }, "text");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="width: 100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                    <li>当前位置：</li>
                    <li>相册管理</li>
                    <li><a href="MyAlbum.aspx">相册列表</a></li>
                    <li>照片列表</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">照片列表</span>
        </div>
        <div class="row">
            <div class="col-lg-2" style="background-color: gainsboro; padding-top: 15px;">
                <div class="thumbnail">
                    <img src="<%=string.IsNullOrEmpty(coverphotopath)?"../img/coverphoto.jpg":coverphotopath%>"
                        alt="" />
                    <div class="caption">
                        <h5>
                            相册名称：<%=albumname%></h5>
                        <p>
                            简介：<%=albumdesc%></p>
                        <p>
                            <a href="ImageUpload.aspx?AlbumId=<%=albumid%>&&AlbumName=<%=albumname%>&&CoverPhotoPath=<%=coverphotopath%>"
                                class="btn btn-primary btn-xs" role="button">上传</a> <a href="BatchDownload.aspx?AlbumId=<%=albumid%>"
                                    class="btn btn-primary btn-xs" role="button">全部下载</a></p>
                    </div>
                </div>
            </div>
            <div class="col-lg-10">
                <div class="row">
                    <div class="table-responsive">
                        <asp:Repeater ID="rpt_AlbumPhotoList" runat="server" OnItemDataBound="rpt_AlbumPhotoList_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table table-bordered">
                                    <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td>
                                    <div onmouseover="CheckChange(this);" onmouseout="aaa(this);" style="position: relative;">
                                        <div style="display: none; position: absolute;
                                            background-color: rgba(255, 255, 255, 0.5); width: 100%;">
                                            <p style="padding-top: 5px;">
                                                <%-- <input type="button" class="btn btn-default btn-xs" onclick="DelPhoto(<%#Eval("PhotoId")+",'"+Eval("PhotoPath")+"',"+(Eval("IsAlbumFace").ToString()=="True"?"1":"0")+""%>)" value="删除" />
                                                <a href="DownPhoto.aspx?filename=<%#Eval("PhotoPath")%>" class="btn btn-default btn-xs"
                                                    role="button">下载</a>
                                                <input type="button" class="btn btn-default btn-xs" onclick="SetAlbumFace(<%#albumid+",'"+Eval("PhotoPath")+"',"+Eval("PhotoId")%>)"
                                                    value="设为封面" />--%>
                                                <a href="#">
                                                    <img src="../img/img_del.png" title="删除" onclick="DelPhoto(<%#Eval("PhotoId")+",'"+Eval("PhotoPath")+"',"+(Eval("IsAlbumFace").ToString()=="True"?"1":"0")+""%>)"
                                                        alt="" /></a>&nbsp;<a href="DownPhoto.aspx?filename=<%#Eval("PhotoPath")%>"><img
                                                            title="下载" src="../img/img_down.png" alt="" /></a> &nbsp;<a href="#"><img title="设置封面"
                                                                src="../img/img_face.png" onclick="SetAlbumFace(<%#albumid+",'"+Eval("PhotoPath")+"',"+Eval("PhotoId")%>)"
                                                                alt="" /></a>
                                            </p>
                                        </div>
                                        <a href="PhotoDetail.aspx?imgurl=<%#Eval("PhotoPath")%>" target="_blank" class="thumbnail"
                                            style="margin: 0px; padding: 0px;">
                                            <img src="<%#Eval("PhotoPath")%>" title="<%#Eval("PhotoName").ToString().Split('.')[0]%>"
                                                width="200" height="110" alt="<%#Eval("PhotoName").ToString().Split('.')[0]%>" />
                                        </a>
                                    </div>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="modal fade" id="myModal" role="dialog" aria-labelledby="" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button id="btnCloseX" type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">
                        提示信息</h4>
                </div>
                <div id="content-body" class="modal-body">
                    1111
                </div>
                <div id="content-footer" class="modal-footer">
                    <button id="btnClose" type="button" class="btn btn-default" data-dismiss="modal">
                        取消</button>
                    <button id="btnOk" type="button" class="btn btn-primary">
                        确定</button>
                </div>
            </div>
        </div>
    </div>
    <div id="alertDialog" class="modal bs-example-modal-sm" tabindex="-1" role="dialog"
        aria-labelledby="" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">
                        提示信息</h4>
                </div>
                <div id="alertMsg" class="modal-body">
                    ...
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <%--<script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

//        function CheckChange(obj) {
//            $(obj).find('div').css("display", "block");
//        }

//        function aaa(obj) {
//            $(obj).find('div').css("display", "none");
//        }
//        function DelPhoto(id, path, isface) {
//            if (confirm("你要删除吗？")) {
//                $.post("../ashx/photo.ashx", "param=delete&&PhotoId=" + id + "&&PhotoPath=" + path + "&&IsAlbumFace=" + isface + "", function (data) { if (data == "ok") { alert("删除成功！"); window.location = "MyAlbum.aspx"; } else { alert("删除失败！"); } }, "text");
//            }
//        }

//        function DelPhoto(id, path, isface) {
//            $('#content-body').html("你要删除吗？");
//            $('#myModal').modal('toggle');
//            $('#btnOk').bind("click",
//            function () {
//                Delete(id, path, isface);
//            });
//        }

//        function Delete(id) {
//            $.post("../ashx/photo.ashx", "param=delete&&PhotoId=" + id + "&&PhotoPath=" + path + "&&IsAlbumFace=" + isface + "",
//            function (data) {
//                $('#myModal').modal('hide');
//                if (data == "ok") {
//                    $("#alertMsg").html("删除成功！");
//                    $('#alertDialog').modal('show');
//                    $('#alertDialog').on('hidden.bs.modal', function (e) {
//                        window.location = "MyAlbum.aspx";
//                    });
//                } else {
//                    $("#alertDialog").html("删除失败！");
//                    $('#alertDialog').modal('show');
//                    return false;
//                }
//            }, "text");
//        }

//        function SetAlbumFace(albumid, path, photoid) {
//            $('#content-body').html("要设为封面吗？");
//            $('#myModal').modal('toggle');
//            $('#btnOk').bind("click",
//            function () {
//                SetFace(albumid, path, photoid);
//            });
//        }
//        function SetFace(albumid, path, photoid) {
//                $.post("../ashx/album.ashx", "param=setface&&AlbumId=" + albumid + "&&CoverPhotoPath=" + path + "&&PhotoId=" + photoid + "",
//                function (data) {
//                    if (data == "ok") {
//                        $("#alertMsg").html("设置成功！");
//                        $('#alertDialog').modal('show');
//                        $('#alertDialog').on('hidden.bs.modal', function (e) {
//                            window.location = "MyAlbum.aspx";
//                        });
//                    } else {
//                        $("#alertDialog").html("设置失败！");
//                        $('#alertDialog').modal('show');
//                        return false;
//                    }
//                }, "text");
//        }
    </script>
</body>
</html>
