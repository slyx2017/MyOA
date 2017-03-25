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
            var Department = $("#<%=ddl_Department.ClientID%>").val();
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
            else {
                var flag = "";
                $.ajax({
                    url: "../ashx/user.ashx?param=isExist",
                    async: false,
                    data: { "uLoginName": "" + uLoginName + "" },
                    success: function (data, status) {
                        if (data == "ok") {
                            flag = "ok";
                        }
                    }
                });
                if (flag == "ok") {
                    $('#content-body').html("用户名已存在！");
                    $('#myModal').modal('toggle');
                    return false;
                }
            }
            if (roleID == "-1") {
                $('#content-body').html("角色类型不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (Department == "-1") {
                $('#content-body').html("所属部门不能为空！");
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
                data: "uLoginName=" + uLoginName + "&&telPhone=" + telPhone + "&&password=" + password + "&&email=" + email + "&&birthday=" + birthday + "&&sex=" + sex + "&&powerlevelID=" + powerlevelID + "&&Department=" + Department + "&&RoleID=" + roleID + "",
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
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">用户添加</span>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="selOptions" class="control-label">
                        所属职位</label>
                </div>
                <div class="col-sm-2 text-left">
                    <asp:DropDownList ID="ddl_PowerLevel" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2 text-right">
                    <label for="ddl_Department" class="control-label">
                        所属部门</label>
                </div>
                <div class="col-sm-2 text-left">
                    <asp:DropDownList ID="ddl_Department" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="uTrueName" class="control-label">
                        员工姓名</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="text" class="form-control" name="uTrueName" id="uTrueName" required="required" placeholder="员工姓名" />
                </div>
                <div class="col-sm-2 text-right">
                    <label for="uLeadorName" class="control-label">
                        直属上级</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="text" class="form-control" name="uLeadorName" id="uLeadorName" required="required" placeholder="直属上级" />
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="uLoginName" class="control-label">
                        登录账户</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="text" class="form-control" name="uLoginName" id="uLoginName" required="required"
                        placeholder="登录账户" />
                </div>
                <div class="col-sm-2 text-right">
                    <label for="roleType" class="control-label">
                        权限类型</label>
                </div>
                <div class="col-sm-2 text-left">
                    <asp:DropDownList ID="ddl_RoleList" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="password" class="control-label">
                        登录密码</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="password" class="form-control" name="password" id="password" required="required"
                        placeholder="登录密码" />
                </div>
                <div class="col-sm-2 text-right">
                    <label for="password1" class="control-label">
                        确认密码</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="password" class="form-control" name="password1" id="password1" required="required"
                        placeholder="确认密码" />
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="telPhone" class="control-label">
                        手机号码</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="tel" class="form-control" name="telPhone" id="telPhone" required="required"
                        placeholder="手机号码" />
                </div>
                <div class="col-sm-2 text-right">
                    <label for="password1" class="control-label">
                        Email</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input type="email" class="form-control" name="email" id="email" placeholder="Email地址" />
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label class="control-label">
                        出生日期</label>
                </div>
                <div class="col-sm-2 text-left">
                    <input runat="server" type="text" class="form-control input Wdate " id="birthday"
                        size="12" onclick="WdatePicker({ dateFmt: 'yyyy/MM/dd' })" />
                </div>
                <div class="col-sm-2 text-right">
                    <label class="control-label">
                        性别</label>
                </div>
                <div class="col-sm-2 text-left">
                    <label class="radio-inline">
                        <input type="radio" name="RadioOptions" id="radioShow" value="1" />
                        男
                    </label>
                    <label class="radio-inline">
                        <input type="radio" name="RadioOptions" id="radioHidden" value="0" />
                        女
                    </label>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
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
                        <h4 class="modal-title" id="myModalLabel">提示信息</h4>
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
