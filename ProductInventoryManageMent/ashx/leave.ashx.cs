using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ProductInventoryManageMent.ashx
{
    /// <summary>
    /// leave 的摘要说明
    /// </summary>
    public class leave : IHttpHandler, IRequiresSessionState
    {

        BLL.Sys_LeavesBLL bll = null;
        Model.Sys_Leaves model = null;
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "add":
                    AddLeave(context);
                    break;
                case "edit":
                    EditLeave(context);
                    break;
                case "del":
                    DelLeave(context);
                    break;
                default:
                    break;
            }

        }

        private void DelLeave(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void EditLeave(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void AddLeave(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int LeaveTypeID = int.Parse(context.Request.Params["LeaveType"].ToString());
            string LeaveReason = context.Request.Params["LeaveReason"];
            string ApprovalPerson = context.Request.Params["ApprovalPerson"];
            DateTime? BeginTime = DateTime.Parse(context.Request.Params["BeginTime"]);
            DateTime? EndTime = DateTime.Parse(context.Request.Params["EndTime"]);

            bll = new BLL.Sys_LeavesBLL();
            model = new Model.Sys_Leaves();
            model.ApplyPerson = context.Session["uLoginName"].ToString();
            model.LeaveReason = LeaveReason;
            model.LeaveStatus =false;
            model.LeaveTypeID = LeaveTypeID;
            model.ApplyTime = DateTime.Now;
            model.BeginTime = BeginTime;
            model.EndTime = EndTime;
            model.ApprovalPerson = ApprovalPerson;
            int codeNum = bll.Add(model);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}