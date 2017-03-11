<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="ProductInventoryManagement.Role.AddRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色添加</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../dist/js/bootstrap.js"></script>
</head>
<body>
    <form id="form1" class="form-horizontal" role="form" runat="server">
        <div class="container" style="width: 100%;">
            <div class="row">
                <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                    <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                        <li>当前位置：</li>
                        <li>角色管理</li>
                        <li>角色添加</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">角色添加</span>
            </div>
            <div class="form-group" style="text-align: center">
                <label for="roleName" class="col-sm-2 control-label">角色名称</label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="txtRoleName" CssClass="form-control" required="required" placeholder="角色名称"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <label class="col-sm-2 control-label">权限名称</label>
                <div class="col-sm-8">
                    <table style="width: 100%;" class="table table-bordered">
                        <asp:Repeater runat="server" ID="rpt_RoleList" OnItemDataBound="rpt_RoleList_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td align="right" style="width: 15%;">
                                        <asp:CheckBox runat="server" ID="parentId" Text='<%#Eval("MenuName") %>' onclick="CheckChange(this);" /></td>
                                    <td align="left" style="font-size: 12px;">
                                        <asp:CheckBoxList runat="server" ID="cbList" RepeatDirection="Horizontal" RepeatLayout="Flow" onclick="aaa(this);">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <div>
                    <label id="lblMsg" runat="server">
                    </label>
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <div class="col-sm-offset-4 col-sm-4">
                    <asp:Button ID="btnSave" runat="server" Text="添加" CssClass="btn btn-primary" OnClick="btnSave_Click" OnClientClick="return check();" />
                    <input type="button" id="btnCancel" class="btn btn-primary" value="返回" onclick="javascript: history.back(-1);" />
                </div>
            </div>
        </div>
    </form>
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //去掉字符串两边的空格        
        function ltrim(s) {//去掉左边空格
            return s.replace(/^\s*/, "");
        }
        function rtrim(s) {//去掉右边空格
            return s.replace(/\s*$/, "");
        }
        function trim(s) {
            return rtrim(ltrim(s));
        }
        //================================
        function check() {
            var role = trim(document.getElementById("txt_RoleName").value);
            if (role == "") {
                alert("角色名称不能为空!");
                return false;
            }
            if ($(":checkbox:checked").length < 1) {
                alert("至少选择一个");
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">

        function CheckChange(obj) {
            var _checked = obj.checked == true ? true : false;
            $(obj).parents('td').next().find('input').attr('checked', _checked);
        }

        function aaa(obj) {
            var _checked = true;
            $(obj).parent().parent().find('input:checked').length == $(obj).parent().parent().find('input').length ? true : false;

            $(obj).parents('td').prev().find('input').attr('checked', _checked);
        }
    </script>
</body>
</html>
