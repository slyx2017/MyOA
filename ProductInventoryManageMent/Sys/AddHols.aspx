<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHols.aspx.cs" Inherits="ProductInventoryManageMent.Sys.AddHols" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/datestyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formSend() {
            var LeaveReason = $("#LeaveReason").val();
            var BeginTime = $("#<%=BeginTime.ClientID%>").val();
            var EndTime = $("#<%=EndTime.ClientID%>").val();
            var LeaveType = $("#<%=ddl_LeaveType.ClientID%>").val();
            var ApprovalPerson = $("#ApprovalPerson").val();
            var data = "LeaveReason=" + LeaveReason + "&&BeginTime=" + BeginTime + "&&EndTime=" + EndTime + "&&LeaveType=" + LeaveType + "&&ApprovalPerson=" + ApprovalPerson + "";
            $.ajax({
                type: "post",
                url: "../ashx/leave.ashx?param=add",
                dataType: "text",
                data: data,
                contentType: "application/x-www-form-urlencoded",
                success: function (data) {
                    if (data == "ok") {
                        $('#content-body').html("操作成功！");
                        $('#myModal').modal('toggle');
                        window.location.href = "Hols.aspx";
                    }
                    else {
                        $('#content-body').html("操作失败！");
                        $('#myModal').modal('toggle');
                        return false;
                    }
                }
            });
        }

        function GetDays() {
            var BeginTime = $("#<%=BeginTime.ClientID%>").val();
            var EndTime = $("#<%=EndTime.ClientID%>").val();
            if (EndTime == "" || BeginTime == "") {
                document.getElementById("numdays").value = "";
            }
            else {
                var enddate = new Date("" + EndTime + "");
                var begindate = new Date("" + BeginTime + "");
                document.getElementById("numdays").value = "";
                document.getElementById("numdays").innerHTML = "共请" + ((enddate.getTime() - begindate.getTime()) / (24 * 60 * 60 * 1000) + 1) + "天假";
            }
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
                        <li>假期管理</li>
                        <li>请假申请</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">请假申请</span>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="LeaveReason" class="control-label">
                        请假原因</label>
                </div>
                <div class="col-sm-4">
                    <input type="text" class="form-control" name="LeaveReason" id="LeaveReason" required="required"
                        placeholder="请假原因" />
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label class="control-label text-right">
                        请假时间</label>
                </div>
                <div class="col-sm-2">
                    <input runat="server" type="text" class="form-control input Wdate " id="BeginTime"
                        size="12" onclick="var EndTime = $dp.$('EndTime'); WdatePicker({ dateFmt: 'yyyy/MM/dd', maxDate: '#F{$dp.$D(\'EndTime\')}', onpicked: GetDays })" />
                </div>
                <div class="col-sm-2">
                    <input runat="server" type="text" class="form-control input Wdate " id="EndTime"
                        size="12" onclick="var BeginTime = $dp.$('BeginTime'); WdatePicker({ dateFmt: 'yyyy/MM/dd', minDate: '#F{$dp.$D(\'BeginTime\')}', onpicked: GetDays })" />
                </div>
                <div class="col-sm-2">
                    <label id="numdays" class="control-label">
                        共0天
                    </label>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="ddl_LeaveType" class="control-label">
                        请假类型</label>
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_LeaveType" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="ApprovalPerson" class="control-label">
                        审批人</label>
                </div>
                <div class="col-sm-4">
                    <input type="text" class="form-control" name="ApprovalPerson" id="ApprovalPerson"
                        required="required" placeholder="审批人" />
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2 text-right">
                    <label for="msgtips" class="control-label">
                        事务提醒</label>
                </div>
                <div class="col-sm-4">
                    <input type="checkbox" id="msgtips" name="msgtips" /><label for="msgtips">发送事务提醒消息</label>
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="form-group" style="text-align: center">
                <div class="col-sm-offset-4 col-sm-4">
                    <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="请假" />
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
