﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenuBlock.aspx.cs"
    Inherits="ProductInventoryManagement.Menu.EditMenuBlock" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模块修改</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formSend() {
            var menuBlock = $("#menuBlock").val();
            var orderNum = $("#orderNum").val();
            var description = $("#Description").val();
            var radioOptions = $("input[type='radio']:checked").val();
            
            if (menuBlock == "") {
                $('#content-body').html("名称不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (orderNum == "") {
                $('#content-body').html("排序值不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (radioOptions == undefined) {
                $('#content-body').html("选择是否显示！");
                $('#myModal').modal('toggle');
                return false;
            }
            $.ajax({
                type: "post",
                url: "../ashx/menu.ashx?param=editblock",
                dataType: "text",
                data: "ID=" + <%=id%> + "&&menuBlock=" + menuBlock + "&&orderNum=" + orderNum + "&&Description=" + description + "&&isInUse=" + radioOptions + "",
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
    <form id="form1" class="form-horizontal" role="form">
    <div class="container" style="width: 100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                    <li>当前位置：</li>
                    <li>系统设置</li>
                    <li><a href="MenuManagement.aspx">模块列表</a></li>
                    <li>模块修改</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">模块修改</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="menuBlock" class="col-sm-4 control-label">
                模块名称</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="menuBlock" id="menuBlock" value="<%= model_m.MenuName %>"
                    required="required" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="orderNum" class="col-sm-4 control-label">
                排序数值</label>
            <div class="col-sm-4">
                <input type="number" class="form-control" name="orderNum" id="orderNum" value="<%=model_m.Sequence %>"
                    required="required" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="Description" class="col-sm-4 control-label">
                模块描述</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="Description" id="Description" value="<%=model_m.Description %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center;">
            <label class="col-sm-4 control-label">
                是否显示</label>
            <div class="col-sm-4">
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioShow" value="1" <%=isck %> />
                    是
                </label>
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioHidden" value="0" <%=isnock %> />
                    否
                </label>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <div class="col-sm-offset-4 col-sm-4">
                <input type="button" id="btnSend" class="btn btn-primary" onclick="formSend()" value="提交" />
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
