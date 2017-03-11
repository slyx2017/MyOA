<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="ProductInventoryManageMent.User.ModifyPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>密码修改</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
     function formSend() {
            var password = $("#password").val();
            var newpwd = $("#newpwd").val();
            var renewpwd = $("#renewpwd").val();
            var pwd=""+<%=upwd %>+"";
            if (password == "") {
                 $('#content-body').html("原密码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
             if (password != pwd) {
                 $('#content-body').html("原密码输入错误！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (newpwd == "") {
                $('#content-body').html("新密码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (renewpwd == "") {
                $('#content-body').html("确认密码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (renewpwd != "" && newpwd != "") {
                if (renewpwd != newpwd) {
                    $('#content-body').html("新密码和确认密码不匹配！");
                    $('#myModal').modal('toggle');
                    return false;
                }
            }
           
            $.ajax({
                type: "post",
                url: "../ashx/user.ashx?param=modifypwd",
                dataType: "text",
                data: "uId=" + <%=uid%> + "&&newPwd=" + newpwd + "",
                contentType: "application/x-www-form-urlencoded",
                success: function (data) {
                    if (data == "ok") {
                        $('#content-body').html("修改成功！");
                        $('#myModal').modal('toggle');
                    }
                    else {
                        $('#content-body').html("修改失败！");
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
                    <li>用户管理</li>
                    <li>密码修改</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">密码修改</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="uLoginName" class="col-sm-4 control-label">
                账号</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="uLoginName" id="uLoginName" readonly="readonly"
                    value="<%= model_u.uLoginName %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password" class="col-sm-4 control-label">
                原密码</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" name="password" id="password" required="required"
                    placeholder="原密码" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="newpwd" class="col-sm-4 control-label">
                新密码</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" name="newpwd" id="newpwd" required="required"
                    placeholder="新密码" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="renewpwd" class="col-sm-4 control-label">
                确认密码</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" name="renewpwd" id="renewpwd" required="required"
                    placeholder="确认密码" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4">
                <p style="color: red; font-size:12px;">
                    1、如果忘记原密码，请联系管理员;（邮箱：208106500@qq.com）<br />
                    2、如果第一次使用账号，请修改密码。
                </p>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <div class="col-sm-offset-4 col-sm-4">
                <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="修改" />
                <button type="reset" class="btn btn-primary">
                    重置</button>
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
