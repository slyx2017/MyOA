<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeConfig.aspx.cs" Inherits="ProductInventoryManageMent.Menu.HomeConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>主页配置</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formSend() {
            var homeUrl = $("#HomePageUrl").val();
            if (homeUrl == "") {
                $('#content-body').html("主页地址不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            
            $.ajax({
                type: "post",
                url: "../ashx/menu.ashx?param=home",
                dataType: "text",
                data: "MenuUrl=" + homeUrl + "",
                contentType: "application/x-www-form-urlencoded",
                success: function (data) {
                    if (data == "ok") {
                        $('#content-body').html("设置成功！");
                        $('#myModal').modal('toggle');
                    }
                    else {
                        $('#content-body').html("设置失败！");
                        $('#myModal').modal('toggle');
                        return false;
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" class="form-horizontal" role="form">
    <div class="container" style="width: 100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                    <li>当前位置：</li>
                    <li>菜单设置</li>
                    <li>主页设置</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">主页设置</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="HomePageUrl" class="col-sm-4 control-label">
                主页地址</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="HomePageUrl" id="HomePageUrl" placeholder="主页地址" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <div class="col-sm-offset-4 col-sm-4">
                <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="保存" />
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
