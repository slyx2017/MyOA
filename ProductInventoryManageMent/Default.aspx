<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductInventoryManagement.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/css.css" rel="stylesheet" />
    <link href="css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.ztree.all.js" type="text/javascript"></script>
    <script src="js/Clock.js" type="text/javascript"></script>
    <script type="text/javascript">
        var zTreeObj;
        // zTree 的参数配置，深入使用请参考 API 文档（setting 配置详解）
        var setting = {
            view: {
                dblClickExpand: false,
                showLine: false
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onClick: onClick
            }
        };
        // zTree 的数据属性，深入使用请参考 API 文档（zTreeNode 节点数据详解）
        var zNodes;
        function onClick(e, treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            zTree.expandNode(treeNode);
        }
        function Exit() {
            $.post("ashx/exit.ashx", function (data) { if (data.status == "ok") window.location = "Login/Login.aspx"; top.location.reload(); }, "json");
        }
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: "ashx/menu.ashx?param=init",
                dataType: "text",
                success: function (data) {
                    //zNodes = eval('(' + data + ')');
                    zNodes = JSON.parse(data);
                    zTreeObj = $.fn.zTree.init($("#treeDemo"), setting, zNodes);
                }
            });
        });
    </script>
    <style type="text/css">
        .ztree li button.switch
        {
            visibility: hidden;
            width: 1px;
        }
        
        .ztree li button.switch.roots_docu
        {
            visibility: visible;
            width: 16px;
        }
        
        .ztree li button.switch.center_docu
        {
            visibility: visible;
            width: 16px;
        }
        
        .ztree li button.switch.bottom_docu
        {
            visibility: visible;
            width: 16px;
        }
    </style>
</head>
<body>
    <div class="header">
        <div class="logo">
            <img src="img/logo.png" />
        </div>
        <div class="header-right">
            <i class="icon-time icon-white"></i><a href="#" style=" text-decoration:none;" id="clock"></a><i class="icon-user icon-white">
            </i><a href="User/UserDetail.aspx" target="main">
                <%=Session["uLoginName"].ToString() %></a> <i class="icon-off icon-white"></i>
            <a id="modal-973558" href="#modal-container-973558" role="button" data-toggle="modal">
                注销</a> <i class="icon-envelope icon-white"></i><a href="#">发送短信</a><i class="icon-question-sign icon-white"></i><a
                    href="#">帮助</a>
            <div id="modal-container-973558" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true" style="width: 300px; margin-left: -150px; top: 30%">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h3 id="myModalLabel">
                        注销系统
                    </h3>
                </div>
                <div class="modal-body">
                    <p>
                        您确定要注销退出系统吗？
                    </p>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true">
                        关闭</button>
                    <button class="btn btn-primary" style="line-height: 20px;" onclick="Exit()">
                        确定退出</button>
                </div>
            </div>
        </div>
    </div>
    <div id="middle">
        <div class="left">
            <!-- 顶部 -->
            <div id="my_menu" class="sdmenu">
                <ul id="treeDemo" class="ztree">
                </ul>
            </div>
        </div>
        <div class="Switch">
        </div>
        <script type="text/javascript">
            $(document).ready(function (e) {
                $(".Switch").click(function () {
                    $(".left").toggle();

                });
            });
        </script>
        <div class="right" id="mainFrame">
            <iframe src="<%=homepage==""?"Inventory/Products.aspx":homepage %>" name="main" style="width: 100%;
                height: 98%;"></iframe>
        </div>
    </div>
    <script type="text/javascript">
        var clock = new Clock();
        clock.display(document.getElementById("clock"));
    </script>
</body>
</html>
