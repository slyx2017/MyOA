using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// exit 的摘要说明
    /// </summary>
    public class exit : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["uLoginName"]!=null&&context.Session["uPwd"]!=null)
            {
                context.Session.Clear();
                context.Response.Write("{\"status\":\"ok\"}");
            }
            else
            {
                context.Session.Clear();
                context.Response.Write("{\"status\":\"ok\"}");
            }
            context.Response.End();
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