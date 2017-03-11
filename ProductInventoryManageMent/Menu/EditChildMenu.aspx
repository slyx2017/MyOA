<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditChildMenu.aspx.cs"
    Inherits="ProductInventoryManagement.Menu.EditChildMenu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>页面修改</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">

        function formSend() {
            var menuName = $("#menuName").val();
            var orderNum = $("#orderNum").val();
            var menuUrl = $("#menuUrl").val();
            var description = $("#Description").val();
            var radioOptions = $("input[type='radio']:checked").val();
            var parentid = $("#<%=ddl_MenuBlock.ClientID%>").val();

            if (menuName == "") {
                $('#content-body').html("页面名称不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (orderNum == "") {
                $('#content-body').html("排序值不能为空！");
                $('#myModal').modal('toggle');
                return false;
            }
            if (menuUrl == "") {
                $('#content-body').html("页面地址不能为空！");
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
                url: "../ashx/menu.ashx?param=editchild",
                dataType: "text",
                data: "ID=" + <%=id%> +"&&menuName=" + menuName + "&&orderNum=" + orderNum + "&&ParentID=" + parentid + "&&menuUrl=" + menuUrl + "&&Description=" + description + "&&isInUse=" + radioOptions + "",
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
                    <li>系统设置</li>
                    <li><a href="MenuManagement.aspx">模块列表</a></li>
                    <li><a href="MenuChild.aspx?pId=<%=pid%>&&MenuName=<%=pname %>">页面列表</a></li>
                    <li>页面修改</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">修改页面</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="selOptions" class="col-sm-4 control-label">
                所属父级</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_MenuBlock" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="menuName" class="col-sm-4 control-label">
                页面名称</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="menuName" id="menuName" required="required"
                    value="<%=model_m.MenuName %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="orderNum" class="col-sm-4 control-label">
                排序数值</label>
            <div class="col-sm-4">
                <input type="number" class="form-control" name="orderNum" id="orderNum" required="required"
                    value="<%=model_m.Sequence %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="menuUrl" class="col-sm-4 control-label">
                页面地址</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="menuUrl" id="menuUrl" value="<%=model_m.MenuUrl %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="Description" class="col-sm-4 control-label">
                页面描述</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="Description" id="Description" value="<%=model_m.Description %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
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
