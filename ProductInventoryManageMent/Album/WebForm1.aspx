<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProductInventoryManagement.Album.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>创建相册</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../css/css.css" rel="stylesheet" />
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
                        <li>数据库管理</li>
                    </ol>
                </div>
            </div>
            <div class="row" style="height: 15px;">
            </div>
            <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei'; color: gray">
                <span style="">切换数据库</span>
            </div>
            <div class="form-group" style="text-align: center">
                <label class="col-sm-4 control-label">数据库名称</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_AlbumTypeList" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_AlbumTypeList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr style="background-color:#2669de;color:white;font-family:'Microsoft YaHei'">
                            <th>序号</th>
                            <th>账户名称</th>
                            <th>行政级别</th>
                            <th>手机号码</th>
                            <th>性别</th>
                            <th>账号状态</th>
                            <th>所属角色</th>
                            <th>添加时间</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpt_UserList">
                            <ItemTemplate>
                                <tr>
                                    <td style="display: none;">
                                        <%#Eval("uId")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("IndexNum")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("uLoginName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("PowerName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("TelePhone")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("SexName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("AccountStateName").ToString()=="正常"? "<b>正常</b>" : "<b style=\"color:red;\">冻结</b>"%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("RoleName")%>
                                    </td>
                                    <td style="padding:2px;">
                                        <%#Eval("uAddTime")%>
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
