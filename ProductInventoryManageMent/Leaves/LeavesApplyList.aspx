﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeavesApplyList.aspx.cs" Inherits="ProductInventoryManageMent.Leaves.LeavesApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>假期申请列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        function DelLeaveApply(uid) {
            $('#content-body').html("你要删除吗？");
            $('#myModal').modal('toggle');
            $('#btnOk').bind("click",
            function () {
                Delete(uid);
            });
        }

        function Delete(uid) {
            $.post("../ashx/leave.ashx", "param=del&&Id=" + uid + "",
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
                        <li>假期管理</li>
                        <li>假期申请</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">假期申请列表</span>
            </div>
            <div class="table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr style="background-color: #2669de; color: white; font-family: 'Microsoft YaHei';">
                            <th>申请人
                            </th>
                            <th>开始时间
                            </th>
                            <th>结束时间
                            </th>
                            <th>请假原因
                            </th>
                            <th>请假类型
                            </th>
                            <th>占年休假
                            </th>
                            <th>申请时间
                            </th>
                            <th>申请销假时间
                            </th>
                            <th>状态
                            </th>
                            <th>审批结果
                            </th>
                            <th>审批人
                            </th>
                            <th>操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpt_LeaveList">
                            <ItemTemplate>
                                <tr style="font-size: 12px;">
                                    <td style="display: none;">
                                        <%#Eval("ID")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("ApplyPerson")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("BeginTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("LeaveReason")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("LeaveName")%>
                                    </td>
                                    <td style="padding: 2px;">1
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("ApplyTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("CancelLeaveTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("LeaveStatus").ToString() == "0" ? "<b>待审批</b>" : Eval("LeaveStatus").ToString() == "1" ?"<b style=\"color:green;\">已审批</b>":"<b style=\"color:red;\">已驳回</b>"%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("DisposeResult")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <%#Eval("ApprovalPerson")%>
                                    </td>
                                    <td style="padding: 2px;">
                                        <div style="<%#Eval("LeaveStatus").ToString() != "1" ? "display:block": "display:none"%>">
                                            <input type="button" class="btn btn-primary btn-xs"
                                                onclick="DelLeaveApply(<%#Eval("Id")%>)" value="删除" />&nbsp;<a href="LeavesApplyModify.aspx?Id=<%#Eval("ID")%>" class="btn btn-primary btn-xs">修改</a>
                                        </div>
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
