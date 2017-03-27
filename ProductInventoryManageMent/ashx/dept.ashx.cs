using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ProductInventoryManageMent.ashx
{
    /// <summary>
    /// dept 的摘要说明
    /// </summary>
    public class dept : IHttpHandler, IRequiresSessionState
    {
        BLL.DeptTypeBLL bll = new BLL.DeptTypeBLL();
        Model.DeptType model = new Model.DeptType();
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "add":
                    AddDept(context);
                    break;
                case "modify":
                    ModifyDept(context);
                    break;
                case "del":
                    DelDept(context);
                    break;
                default:
                    break;
            }
        }

        private void AddDept(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string DeptTypeName = context.Request.Params["DeptTypeName"];
            int sortNum = int.Parse(context.Request.Params["orderNum"]);

            model.DeptName = DeptTypeName;
            model.SortNum = sortNum;
            int codeNum = bll.AddDeptType(model);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }
        private void ModifyDept(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string DeptTypeName = context.Request.Params["DeptTypeName"];
            int sortNum = int.Parse(context.Request.Params["orderNum"]);
            int Id = int.Parse(context.Request.Params["ID"]);
            model.ID = Id;
            model.DeptName = DeptTypeName;
            model.SortNum = sortNum;
            int codeNum = bll.ModifyDept(model);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }
        private void DelDept(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int Id = int.Parse(context.Request.Params["ID"]);
            int flag= bll.DeleteDept(Id);
            if (flag>0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
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