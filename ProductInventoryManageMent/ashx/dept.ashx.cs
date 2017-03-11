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
                case "adddept":
                    AddDept(context);
                    break;
                case "editdept":
                    EditDept(context);
                    break;
                case "deldept":
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
            string sortNum = context.Request.Params["orderNum"];

            model.DeptName = DeptTypeName;
            model.SortNum = sortNum;
            int codeNum = bll.AddDeptType(model);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                return;
            }
        }
        private void DelDept(HttpContext context)
        {
            throw new NotImplementedException();
        }
        
        private void EditDept(HttpContext context)
        {
            throw new NotImplementedException();
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