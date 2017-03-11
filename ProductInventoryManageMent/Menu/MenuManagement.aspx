<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManagement.aspx.cs"
    Inherits="ProductInventoryManagement.Menu.MenuManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模块列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        //        function DelBlock(id) {
        //            if (confirm("你要删除吗？")) {
        //                $.post("../ashx/menu.ashx", "param=delblock&&ID="+id+"", function (data) { if (data == "ok") alert("删除成功！"); else alert("删除失败！"); }, "text");
        //            }
        //        }
        function DelBlock(id) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(id);
            });
        }

        function Delete(id) {
            $.post("../ashx/menu.ashx", "param=delblock&&ID=" + id + "",
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
       
        function loadAdd() {
            $('#myModal').modal({
                remote: "AddMenuBlock.aspx"
            })
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
                    <li>模块列表</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
       <%-- <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">模块列表</span>
        </div>--%>
        <div class="row" style=" padding:8px 8px 8px 15px;">
            <input type="button" class="btn btn-primary" onclick="loadAdd()" value="新建" />
        </div>
        <div class="table-responsive">
            <table class="table table-hover table-bordered">
                <thead>
                    <tr style="background-color: #2669de; color: white; font-family: 'Microsoft YaHei'">
                        <th>
                            序号
                        </th>
                        <th>
                            模块名称
                        </th>
                        <th>
                            模块描述
                        </th>
                        <th>
                            添加时间
                        </th>
                        <th>
                            添加人
                        </th>
                        <th>
                            是否显示
                        </th>
                        <th>
                            排序数值
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpt_MenuBlock" OnItemDataBound="rpt_MenuBlock_ItemDataBound">
                        <ItemTemplate>
                            <tr <%# Eval("IsInUse").ToString() == "1" ? "" : "style='color:#999;'"%>>
                                <td style="display: none;">
                                    <%#Eval("ID")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("IndexNum")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("MenuName")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("Description")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("AddTime")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("AddUser")%>
                                </td>
                                <td style="padding: 2px;">
                                    <%# Eval("IsInUse").ToString() == "1" ? "<b>是</b>" : "<b style=\"color:#999;\">否</b>"%>
                                </td>
                                <td style="padding: 2px;">
                                    <%#Eval("Sequence")%>
                                </td>
                                <td style="padding: 2px;">
                                    <a href="EditMenuBlock.aspx?ID=<%#Eval("ID")%>" class="btn btn-primary btn-xs">修改</a>&nbsp;<a
                                        href="MenuChild.aspx?pId=<%#Eval("ID")%>&&MenuName=<%#Eval("MenuName")%>" class="btn btn-primary btn-xs">查看子菜单</a>&nbsp;<input
                                            type="button" onclick="DelBlock(<%#Eval("ID")%>)" class="btn btn-primary btn-xs"
                                            value="删除" />
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
            <div class="modal-content" id="addContentID">
                <div class="modal-header">
                    <button id="btnCloseX" type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">
                        提示信息</h4>
                </div>
                <div id="content-body" class="modal-body">
                    
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
