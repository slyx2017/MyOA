<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPageList.aspx.cs" Inherits="ProductInventoryManagement.Menu.MenuList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>页面列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
//        function DelChild(id) {
//            if (confirm("你要删除吗？")) {
//                $.post("../ashx/menu.ashx", "param=delchild&&ID="+id+"", function (data) { if (data == "ok") alert("删除成功！"); else alert("删除失败！"); }, "text");
//            }
//        }
        function DelChild(id) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(id);
            });
        }

        function Delete(id) {
            $.post("../ashx/menu.ashx", "param=delchild&&ID=" + id + "",
            function (data) {
                $('#myModal').modal('hide');
                if (data == "ok") {
                    $("#alertMsg").html("删除成功！");
                    $('#alertDialog').modal('show');
                    $('#alertDialog').on('hidden.bs.modal', function (e) {
                        top.location.reload();
                    });
                } else {
                    $("#alertDialog").html("删除失败！");
                    $('#alertDialog').modal('show');
                    return false;
                }
            }, "text");
        } 
        function SetHome(id) {
            $.post("../ashx/menu.ashx", "param=home&&ID=" + id + "",
            function (data) {
                if (data == "ok") {
                    $("#alertMsg").html("设置成功！");
                    $('#alertDialog').modal('show');
                    $('#alertDialog').on('hidden.bs.modal', function (e) {
                        top.location.reload();
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
                        <li>系统设置</li>
                        <li>页面列表</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center;padding:8px;font-size:16px; font-family:'Microsoft YaHei';color:gray">
                <span style="">页面列表</span>
            </div>
            <div class="table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr style="background-color:#2669de;color:white;font-family:'Microsoft YaHei'">
                            <th>序号</th>
                            <th>菜单名称</th>
                            <th>链接地址</th>
                            <th>模块描述</th>
                            <th>所属模块</th>
                            <th>添加时间</th>
                            <th>添加人</th>
                            <th>是否显示</th>
                            <th>排序数值</th>
                            <th>是否主页</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpt_MenuBlock">
                            <ItemTemplate>
                                <tr <%# Eval("IsInUse").ToString() == "1" ? "" : "style='color:#999;'"%>>
                                    <td style="display: none;">
                                        <%#Eval("ID")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("IndexNum")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("MenuName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("MenuUrl")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("Description")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("cMenuName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("AddTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("AddUser")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%# Eval("IsInUse").ToString() == "1" ? "<b>是</b>" : "<b style=\"color:#999;\">否</b>"%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("Sequence")%>
                                    </td>
                                    <td style="padding:2px;">
                                         <input type="button" onclick="SetHome(<%#Eval("ID")%>)" <%# Eval("IsInUse").ToString() == "1" ? "" : "disabled=\"disabled\""%>" class="<%# Eval("MenuCode").ToString() == "1" ? "btn btn-warning btn-xs" : "btn btn-primary btn-xs"%>" value="<%# Eval("MenuCode").ToString() == "1" ? "是" : "否"%>"/>
                                    </td>
                                    <td style="padding:2px;">
                                        <a href="ModifyChildMenu.aspx?pname=<%#Eval("cMenuName")%>&&ID=<%#Eval("ID")%>&&pId=<%#Eval("ParentID")%>" class="btn btn-primary btn-xs">修改</a> &nbsp;<input type="button" class="btn btn-primary btn-xs" onclick="DelChild(<%#Eval("ID")%>)" value="删除" />
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
