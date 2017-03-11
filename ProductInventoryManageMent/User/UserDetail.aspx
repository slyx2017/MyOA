<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="ProductInventoryManageMent.User.UserDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息</title>
    <link href="../dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" role="form">
    <div class="container" style="width: 100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px;">
                <ol class="breadcrumb" style="margin: 0px; padding-left: 15px;">
                    <li>当前位置：</li>
                    <li>个人信息</li>
                </ol>
            </div>
        </div>
        <div class="row" style="height: 15px;">
        </div>
        <div class="row" style="text-align: center; padding: 8px; font-size: 16px; font-family: 'Microsoft YaHei';
            color: gray">
            <span style="">个人信息</span>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="selOptions" class="col-sm-4 control-label">
                行政级别</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_PowerLevel" class="form-control" Enabled="false" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="uLoginName" class="col-sm-4 control-label">
                登录账户</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" name="uLoginName" id="uLoginName" readonly="readonly"
                    value="<%= model_u.uLoginName %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="roleType" class="col-sm-4 control-label">
                角色类型</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddl_RoleList" class="form-control" Enabled="false" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="telPhone" class="col-sm-4 control-label">
                手机号码</label>
            <div class="col-sm-4">
                <input type="tel" class="form-control" name="telPhone" id="telPhone" disabled="disabled"
                    value="<%= model_u.Telephone %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label for="password1" class="col-sm-4 control-label">
                Email地址</label>
            <div class="col-sm-4">
                <input type="email" class="form-control" name="email" id="email" disabled="disabled" value="<%= model_u.Email %>" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                出生日期</label>
            <div class="col-sm-4">
                <input runat="server" type="text" class="form-control input Wdate" id="birthday" disabled="disabled" 
                    size="12" onclick="WdatePicker({dateFmt:'yyyy/MM/dd'})" />
            </div>
        </div>
        <div class="form-group" style="text-align: center">
            <label class="col-sm-4 control-label">
                性别</label>
            <div class="col-sm-4">
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioShow" value="1" <%=isck %>  disabled="disabled"/>
                    男
                </label>
                <label class="radio-inline">
                    <input type="radio" name="RadioOptions" id="radioHidden" value="0" <%=isnock %>  disabled="disabled"/>
                    女
                </label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
