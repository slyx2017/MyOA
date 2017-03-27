<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptList.aspx.cs" Inherits="ProductInventoryManageMent.Sys.DeptList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        function DelDept(uid) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(uid);
            });
        }

        function Delete(uid) {
            $.post("../ashx/dept.ashx", "param=del&&ID=" + uid + "",
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
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 100%;">
            <div class="row">
                <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                    <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                        <li>当前位置：</li>
                        <li>部门管理</li>
                        <li>部门列表</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">部门列表</span>
            </div>
            <div class="table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr style="background-color: #2669de; color: white; font-family: 'Microsoft YaHei'">
                            <%--<th>序号</th>--%>
                            <th>部门名称</th>
                            <th>排序</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpt_DeptList">
                            <ItemTemplate>
                                <tr>
                                    <td style="display: none;">
                                        <%#Eval("Id")%>
                                    </td>
                                    <%--<td style="padding:2px;">
                                        <%#Eval("IndexNum")%>
                                    </td>--%>
                                    <td style="padding: 2px;">
                                        <%#Eval("DeptName")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("SortNum")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <a href="ModifyDept.aspx?ID=<%#Eval("Id")%>" class="btn btn-primary btn-xs">修改</a> &nbsp;
                                        <input type="button" class="btn btn-primary btn-xs" onclick="DelDept(<%#Eval("Id")%>)" value="删除" />
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
                        <h4 class="modal-title" id="myModalLabel">提示信息</h4>
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
                        <h4 class="modal-title">提示信息</h4>
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
