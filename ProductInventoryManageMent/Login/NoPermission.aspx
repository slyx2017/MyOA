<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoPermission.aspx.cs" Inherits="ProductInventoryManagement.Login.NoPermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Please Login ...</title>
    <style type="text/css">
<!--
body 
{
	margin-top:0px;
	overflow:auto;
	font-family:Tahoma, Verdana, Arial;
	font-size:11px;
}
.mainfont {height:40px; vertical-align:middle; text-align:center; color:#669933; font-size:12px; font-weight:normal;}
a {color:#0000ff;}
a:hover {color:#FF0000;}
-->
    </style>
    <script type="text/javascript">
    function reLogin()
    {
        var url = "Login.aspx";
        self.top.location.replace(url);
        return false;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td style="height:200px">&nbsp;&nbsp;
        </td>
      </tr>
      <tr>
        <td class="mainfont">
            <asp:Literal ID="lit_Msg" runat="server" Text="非常抱歉, 由于闲置时间过长, 页面自动过期, 请重新登录后再继续操作!"></asp:Literal>
            <br /><asp:Literal ID="Literal1" runat="server" Text="(Sorry, Your login session has expired. Please re-login!)"></asp:Literal></td>
      </tr>
      <tr>
        <td align="center"><asp:LinkButton ID="lbt_gotoLogin" runat="server" OnClientClick="return reLogin();">重新登陆//re-login</asp:LinkButton></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
    </table>

    
    </div>
    </form>
    <script type="text/javascript">//window.top.scrollTo(0,0);</script>
</body>
</html>
