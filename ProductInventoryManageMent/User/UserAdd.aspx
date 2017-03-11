<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="ProductInventoryManagement.User.UserAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户添加</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/datestyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formSend() {
            var powerlevelID = $("#<%=ddl_PowerLevel.ClientID%>").val();
            var uLoginName = $("#uLoginName").val();
            var roleID = $("#<%=ddl_RoleList.ClientID%>").val();
            var telPhone = $("#telPhone").val();
            var password = $("#password").val();
            var password1 = $("#password1").val();
            var email = $("#email").val();
            var birthday = $("#<%=birthday.ClientID%>").val();
            var sex = $("input[type='radio']:checked").val();

            if (powerlevelID == "-1") {
                $('#content-body').html("行政级别不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }

            if (uLoginName == "") {
                $('#content-body').html("账户不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (roleID == "-1") {
                $('#content-body').html("角色类型不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (telPhone == "") {
                $('#content-body').html("手机号码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (password == "") {
                $('#content-body').html("密码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (password1 == "") {
                $('#content-body').html("密码不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (password != password1) {
                $('#content-body').html("密码不匹配！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (sex == undefined) {
                $('#content-body').html("选择性别！");
                $('#myModal').modal('toggle');
                return false;
            }
            $.ajax({
                type: "post",
                url: "../ashx/user.ashx?param=add",
                dataType: "text",
                data: "uLoginName=" + uLoginName + "&&telPhone=" + telPhone + "&&password=" + password + "&&email=" + email + "&&birthday=" + birthday + "&&sex=" + sex + "&&powerlevelID=" + powerlevelID + "&&RoleID=" + roleID + "",
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
                    <li>用户管理</li>
                    <li>用户添加</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">用户添加</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="selOptions" class="col-sm-4 control-label">
                行政级别</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_PowerLevel" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="uLoginName" class="col-sm-4 control-label">
                登录账户</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="uLoginName" id="uLoginName" required="required"
                    placeholder="登录账户" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="roleType" class="col-sm-4 control-label">
                角色类型</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_RoleList" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="telPhone" class="col-sm-4 control-label">
                手机号码</label>
            <div class="col-sm-4">
                <input type="tel" class="form-control" name="telPhone" id="telPhone" required="required"
                    placeholder="手机号码" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password" class="col-sm-4 control-label">
                登录密码</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" name="password" id="password" required="required"
                    placeholder="登录密码" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password1" class="col-sm-4 control-label">
                确认密码</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" name="password1" id="password1" required="required"
                    placeholder="确认密码" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password1" class="col-sm-4 control-label">
                Email地址</label>
            <div class="col-sm-4">
                <input type="email" class="form-control" name="email" id="email" placeholder="Email地址" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                出生日期</label>
            <div class="col-sm-4">
                <input runat="server" type="text" class="form-control input Wdate " id="birthday"
                    size="12" onclick="WdatePicker({dateFmt:'yyyy/MM/dd'})" />
                <%--<input type="date" class="form-control" name="birthday" id="birthday" placeholder="出生日期" />--%>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                性别</label>
            <div class="col-sm-4">
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioShow" value="1" />
                    男
                </label>
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioHidden" value="0" />
                    女
                </label>
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
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby=""
        aria-hidden="true">
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
