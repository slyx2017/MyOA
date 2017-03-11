<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAlbum.aspx.cs" Inherits="ProductInventoryManagement.Album.MyAlbum" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>相册列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        //        function DelAlbum(id, path) {
        //            if (confirm("你要删除吗？")) {
        //                $.post("../ashx/album.ashx", "param=delalbum&&AlbumId=" + id + "&&AlbumPath=" + path + "", function (data) { if (data == "ok") { alert("删除成功！"); window.location = "MyAlbum.aspx"; } else { alert("删除失败！"); } }, "text");
        //            }
        //        }
        function DelAlbum(id, path) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(id, path);
            });
        }

        function Delete(id, path) {
            $.post("../ashx/album.ashx", "param=delalbum&&AlbumId=" + id + "&&AlbumPath=" + path + "",
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
                    <li>相册列表</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">相册列表</span>
        </div>
        <div class="table-responsive">
            <asp:Repeater ID="rpt_AlbumList" runat="server" OnItemDataBound="rpt_AlbumList_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <td>
                        <div>
                            <a href="AlbumPhotos.aspx?AlbumId=<%#Eval("AlbumId")%>&&AlbumName=<%#Eval("AlbumName")%>&&CoverPhotoPath=<%#Eval("CoverPhotoPath")%>"
                                class="thumbnail">
                                <img src="<%#string.IsNullOrEmpty(Eval("CoverPhotoPath").ToString())?"../img/coverphoto.jpg":Eval("CoverPhotoPath")%>"
                                    width="200" height="110" />
                            </a>
                            <div class="caption">
                                <h3>
                                    <%#Eval("AlbumName")%></h3>
                                <p>
                                    <a href="ModifyAlbum.aspx?AlbumId=<%#Eval("AlbumId")%>" class="btn btn-primary btn-xs"
                                        role="button">修改</a>
                                    <input type="button" class="btn btn-primary btn-xs" onclick="DelAlbum(<%#Eval("AlbumId")+",'"+Eval("AlbumPath")+"'"%>)"
                                        value="删除" />
                                </p>
                            </div>
                        </div>
                    </td>
                </ItemTemplate>
                <FooterTemplate>
                    </tr> </table>
                </FooterTemplate>
            </asp:Repeater>
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
</body>
</html>
