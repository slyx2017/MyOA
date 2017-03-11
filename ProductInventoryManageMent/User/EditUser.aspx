<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="ProductInventoryManagement.User.EditUser" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户修改</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/datestyle.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript" src="../js/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function formSend() {
            var powerlevelID = $("#<%=ddl_PowerLevel.ClientID%>").val();
            var uLoginName = $("#uLoginName").val();
            var roleID = $("#<%=ddl_RoleList.ClientID%>").val();
            var telPhone = $("#telPhone").val();
            var email = $("#email").val();
            var birthday = $("#<%=birthday.ClientID%>").val();
            var sex = $("input[type='radio']:checked").val();

            if (uLoginName == "") {
                 $('#content-body').html("账户不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (telPhone == "") {
                $('#content-body').html("手机号码不能为空！");
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
                url: "../ashx/user.ashx?param=edit",
                dataType: "text",
                data: "uId=" + <%=uid%> + "&&uLoginName=" + uLoginName + "&&telPhone=" + telPhone + "&&email=" + email + "&&birthday=" + birthday + "&&sex=" + sex + "&&powerlevelID=" + powerlevelID + "&&RoleID=" + roleID + "",
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
                    <li><a href="UserList.aspx">用户列表</a></li>
                    <li>用户修改</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">用户修改</span>
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
                    value="<%= model_u.uLoginName %>" />
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
                    value="<%= model_u.Telephone %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password1" class="col-sm-4 control-label">
                Email地址</label>
            <div class="col-sm-4">
                <input type="email" class="form-control" name="email" id="email" value="<%= model_u.Email %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                出生日期</label>
            <div class="col-sm-4">
                <input runat="server" type="text" class="form-control input Wdate" id="birthday"
                    size="12" onclick="WdatePicker({dateFmt:'yyyy/MM/dd'})" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                性别</label>
            <div class="col-sm-4">
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioShow" value="1" <%=isck %> />
                    男
                </label>
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioHidden" value="0" <%=isnock %> />
                    女
                </label>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <div class="col-sm-offset-4 col-sm-4">
                <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="修改" />
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
