<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ProductInventoryManagement.User.UserList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        function DelUser(uid, uisdel) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(uid, uisdel);
            });
        }

        function Delete(uid, uisdel) {
            $.post("../ashx/user.ashx", "param=del&&uId=" + uid + "&&uIsDel=" + uisdel + "",
            function (data) {
                $('#myModal').modal('hide');
                if (data == "ok") {
                    $("#alertMsg").html("删除成功！");
                    $('#alertDialog').modal('show');
                    $('#alertDialog').on('hidden.bs.modal', function (e) {
                        window.location.reload();
                    });
                } else {
                    $("#alertDialog").html("删除失败！");
                    $('#alertDialog').modal('show');
                    return false;
                }
            }, "text");
        }
        function FreezeUser(uid, state) {
            var msg = state == "1" ? "你要冻结这个账号吗？" : "你要启用这个账号吗？";
            $('#content-body').html(msg);
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Freeze(uid, state);
            });
        }
        function Freeze(uid, state) {
            $.post("../ashx/user.ashx",
                    "param=freeze&&uId=" + uid + "&&state=" + state + "",
                    function (data) {
                        $('#myModal').modal('hide');
                        if (data == "ok") {
                            if (state == "1") {
                                $("#alertMsg").html("已冻结成功！");
                                $('#alertDialog').modal('show');
                                $('#alertDialog').on('hidden.bs.modal', function (e) {
                                    window.location.reload();
                                });
                            }
                            else {
                                $("#alertMsg").html("已启用成功！");
                                $('#alertDialog').modal('show');
                                $('#alertDialog').on('hidden.bs.modal', function (e) {
                                    window.location.reload();
                                });
                            }
                        }
                        else {
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
                    <li>用户管理</li>
                    <li>用户列表</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">用户列表</span>
        </div>
        <div class="table-responsive">
            <table class="table table-hover table-bordered">
                <thead>
                    <tr style="background-color: #2669de; color: white; font-family: 'Microsoft YaHei'">
                        <th>
                            序号
                        </th>
                        <th>
                            账户名称
                        </th>
                        <th>
                            行政级别
                        </th>
                        <th>
                            所属部门
                        </th>
                        <th>
                            手机号码
                        </th>
                        <th>
                            性别
                        </th>
                        <th>
                            账号状态
                        </th>
                        <th>
                            所属角色
                        </th>
                        <th>
                            添加时间
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpt_UserList">
                        <ItemTemplate>
                            <tr>
                                <td style="display: none;">
                                    <%#Eval("uId")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("IndexNum")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("uLoginName")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("PowerName")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("Department")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("TelePhone")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("SexName")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("AccountStateName").ToString()=="正常"? "<b>正常</b>" : "<b style=\"color:red;\">冻结</b>"%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("RoleName")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("uAddTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td style="padding: 2px;">
                                    <a href="EditUser.aspx?uId=<%#Eval("uId")%>&&PowerName=<%#Eval("PowerName")%>&&RoleName=<%#Eval("RoleName")%>&&Department=<%#Eval("Department")%>"
                                        class="btn btn-primary btn-xs">修改</a>&nbsp;<input type="button" class="btn btn-primary btn-xs"
                                            onclick="DelUser(<%#Eval("uId")%>,<%#Eval("uIsDel").ToString()=="False"?"0":"1"%>)"
                                            value="删除" />&nbsp;<input type="button" class="<%# Eval("AccountState").ToString() == "1" ? "btn btn-primary btn-xs" : "btn btn-warning btn-xs"%>"
                                                onclick="FreezeUser(<%#Eval("uId")%>,<%#Eval("AccountState")%>)" value="<%# Eval("AccountState").ToString() == "1" ? "冻结" : "启用"%>" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
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
