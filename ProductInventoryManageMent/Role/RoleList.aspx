<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="ProductInventoryManagement.Role.RoleList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色列表</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../dist/js/bootstrap.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 100%;">
            <div class="row">
                <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                    <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                        <li>当前位置：</li>
                        <li>角色管理</li>
                        <li>角色列表</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center;padding:8px;font-size:16px; font-family:'Microsoft YaHei';color:gray">
                <span style="">角色列表</span>
            </div>
            <div class="table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr style="background-color:#2669de;color:white;font-family:'Microsoft YaHei'">
                            <th>序号</th>
                            <th>角色名称</th>
                            <th>添加时间</th>
                            <th>添加人</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpt_RoleList">
                            <ItemTemplate>
                                <tr>
                                    <td style="display: none;">
                                        <%#Eval("RoleID")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("IndexNum")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("RoleName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("AddTime")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("AddUser")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <a href="EditRole.aspx?RoleID=<%#Eval("RoleID")%>" class="btn btn-primary btn-xs">修改</a> &nbsp;<a href="#" class="btn btn-primary btn-xs">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

