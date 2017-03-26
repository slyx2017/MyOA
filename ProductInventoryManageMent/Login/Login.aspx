<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductInventoryManagement.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>OA快乐办公系统</title>
    <link rel="stylesheet" href="../css/bootstrap.css" />
    <script type="text/javascript" src="../js/jquery1.9.0.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <style type="text/css">
        body {
            background: #0066A8 url(../img/login_bg.png) no-repeat center 0px;
        }

        .tit {
            margin: auto;
            margin-top: 170px;
            text-align: center;
            width: 350px;
            padding-bottom: 20px;
        }

        .login-wrap {
            width: 220px;
            padding: 30px 50px 0 330px;
            height: 220px;
            background: #fff url(../img/20170325.jpg) no-repeat 30px 40px;
            margin: auto;
            overflow: hidden;
        }

        .login_input {
            display: block;
            width: 210px;
        }

        .login_user {
            background: url(../img/input_icon_1.png) no-repeat 200px center;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .login_password {
            background: url(../img/input_icon_2.png) no-repeat 200px center;
            font-family: "Courier New", Courier, monospace;
        }

        .btn-login {
            background: #40454B;
            box-shadow: none;
            text-shadow: none;
            color: #fff;
            border: none;
            height: 35px;
            line-height: 26px;
            font-size: 14px;
            font-family: "microsoft yahei";
        }

            .btn-login:hover {
                background: #333;
                color: #fff;
            }

        .copyright {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 370px;
            color: #CCC;
        }

        @media (max-height: 700px) {
            .tit {
                margin: auto;
                margin-top: 100px;
            }
        }

        @media (max-height: 500px) {
            .tit {
                margin: auto;
                margin-top: 50px;
            }
        }
    </style>
    <script type="text/javascript">
        function Login() {
            var isnull = isNull();
            if (isnull) {
                var username = $("#UserName").val();
                var pwd = $("#Password").val();
                $.ajax({
                    type: "post",
                    url: "../ashx/login.ashx",
                    data: "UserName=" + username + "&&Password=" + pwd,
                    dataType: "json",
                    success: function (data) {
                        if (data.success == "ok") {
                            window.location = "../Default.aspx";
                        }
                        if (data.error == "no") {
                            $("#msg_error").html("用户名密码错误！");
                            return false;
                        }
                        if (data.error == "freeze") {
                            $("#msg_error").html("此账号已被冻结！请联系管理员<br/>邮箱：208106500@qq.com ");
                            return false;
                        }
                    }
                })
            } else {
                return false;
            }
        }
        var isNull = function () {
            if (document.getElementById("UserName").value == "") {
                $("#msg_error").html("用户名不能为空");
                return false;
            }
            if (document.getElementById("Password").value == "") {
                $("#msg_error").html("密码不能为空");
                return false;
            }
            return true;
        }
    </script>
</head>

<body>
        <div class="tit">
            <img src="../img/tita.png" alt="" />
        </div>
        <div class="login-wrap">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="25" valign="bottom">用户名：</td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="UserName" name="UserName" class="login_input login_user" value="wangzy" /></td>
                </tr>
                <tr>
                    <td height="35" valign="bottom">密  码：</td>
                </tr>
                <tr>
                    <td>
                        <input type="password" id="Password" name="Password" class="login_input login_password" value="123" /></td>
                </tr>
                <tr>
                    <td height="60" valign="bottom">
                        <input type="button" class="btn btn-block btn-login" id="btnLogin" onclick="Login()" value="登录"/></td>
                </tr>
                <tr><td><span id="msg_error" style="color:red;"></span></td></tr>
            </table>
        </div>
        <div class="copyright">建议使用IE8以上版本或谷歌浏览器</div>
</body>
</html>
