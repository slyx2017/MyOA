<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDept.aspx.cs" Inherits="ProductInventoryManageMent.Sys.AddDept" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门添加</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/css.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../dist/js/bootstrap.js"></script>
    <script type="text/javascript">
        function formSend() {
            var depttype = $("#DeptTypeName").val();
            var orderNum = $("#orderNum").val();

            if (depttype == "") {
                $('#content-body').html("部门类别不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (orderNum == "") {
                alert("排序值不能为空！");
                return false;
            }
            $.ajax({
                type: "post",
                url: "../ashx/dept.ashx?param=adddept",
                dataType: "text",
                data: "DeptTypeName=" + depttype + "&&orderNum=" + orderNum + "",
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
                    <li>部门管理</li>
                    <li>部门类别添加</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">部门添加</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="DeptTypeName" class="col-sm-4 control-label">
                部门类别</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="DeptTypeName" id="DeptTypeName" required="required"
                    placeholder="部门类别" />
            </div>
        </div>
         <div class="form-group" style="text-align: center">
            <label for="orderNum" class="col-sm-4 control-label">
                排序数值</label>
            <div class="col-sm-4">
                <input type="number" class="form-control" name="orderNum" id="orderNum" required="required"
                    placeholder="排序号" />
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
