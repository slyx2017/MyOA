using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DBUtility;

namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler,IRequiresSessionState
    {
        BLL.Users bll = new BLL.Users();
        //string strWhere = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request.Params["UserName"];
            string pwd = context.Request.Params["Password"];
            //strWhere = " uLoginName='" + username + "' and uPwd='" + pwd + "'";
            DataSet ds = new DataSet();
            //ds = bll.GetList(strWhere);
            //ds = bll.GetUserByLoginName(username, pwd);
            ds = bll.GetUserByLoginName(username, DESEncrypt.Encrypt(pwd));
            if (ds.Tables[0].Rows.Count>0)
            {
                bool uIsDel = bool.Parse(ds.Tables[0].Rows[0]["uIsDel"].ToString());
                int accountState = int.Parse(ds.Tables[0].Rows[0]["AccountState"].ToString());
                if (uIsDel)
                {
                    context.Response.Write("{\"error\":\"no\"}");
                    context.Response.End();
                    return;
                }
                if (accountState==2)
                {
                    context.Response.Write("{\"error\":\"freeze\"}");
                    context.Response.End();
                    return;
                }
                if (uIsDel==false&& accountState==1)
                {
                    context.Session.Add("uLoginName", ds.Tables[0].Rows[0]["uLoginName"].ToString().Trim());
                    context.Session.Add("uPwd", ds.Tables[0].Rows[0]["uPwd"].ToString().Trim());
                    context.Session.Add("uName", ds.Tables[0].Rows[0]["uName"].ToString().Trim());
                    context.Session.Add("uId", ds.Tables[0].Rows[0]["uId"].ToString());
                    context.Session.Add("RoleID", ds.Tables[0].Rows[0]["RoleID"].ToString());
                    context.Session.Add("Department", ds.Tables[0].Rows[0]["Department"].ToString());
                    context.Response.Write("{\"success\":\"ok\"}");
                }
            }
            else
            {
                context.Response.Write("{\"error\":\"no\"}");
                context.Response.End();
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}