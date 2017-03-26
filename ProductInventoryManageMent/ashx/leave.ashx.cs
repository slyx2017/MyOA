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

        BLL.Sys_LeavesBLL bll = new BLL.Sys_LeavesBLL();
        Model.Sys_Leaves model = new Model.Sys_Leaves();
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "add":
                    AddLeave(context);
                    break;
                case "modify":
                    EditLeave(context);
                    break;
                case "del":
                    DelLeave(context);
                    break;
                case "dispose":
                    DisposeLeave(context);
                    break;
                default:
                    break;
            }

        }

        private void DisposeLeave(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int Id = int.Parse(context.Request.Params["Id"]);
            string DisposeResult = context.Request.Params["DisposeResult"];
            int leavetatus = int.Parse(context.Request.Params["LeaveStatus"]);
            int flag= bll.DisposeLeaves(Id, DisposeResult,leavetatus);
            if (flag > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }

        private void DelLeave(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int Id = int.Parse(context.Request.Params["Id"]);
            bool flag=bll.Delete(Id);
            if (flag)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }

        private void EditLeave(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int LeaveTypeID = int.Parse(context.Request.Params["LeaveType"].ToString());
            string LeaveReason = context.Request.Params["LeaveReason"];
            string ApprovalPerson = context.Request.Params["ApprovalPerson"];
            DateTime? BeginTime = DateTime.Parse(context.Request.Params["BeginTime"]);
            DateTime? EndTime = DateTime.Parse(context.Request.Params["EndTime"]);
            int Id = int.Parse(context.Request.Params["Id"]);
            int leavestatus = 0;
            model.ApplyPerson = context.Session["uLoginName"].ToString();
            model.LeaveReason = LeaveReason;
            model.LeaveStatus = leavestatus;
            model.LeaveTypeID = LeaveTypeID;
            model.ApplyTime = DateTime.Now;
            model.BeginTime = BeginTime;
            model.EndTime = EndTime;
            model.ApprovalPerson = ApprovalPerson;
            model.ID= Id;
            int flag = bll.Update(model);
            if (flag > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }

        private void AddLeave(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int LeaveTypeID = int.Parse(context.Request.Params["LeaveType"].ToString());
            string LeaveReason = context.Request.Params["LeaveReason"];
            string ApprovalPerson = context.Request.Params["ApprovalPerson"];
            DateTime? BeginTime = DateTime.Parse(context.Request.Params["BeginTime"]);
            DateTime? EndTime = DateTime.Parse(context.Request.Params["EndTime"]);
            int leavestatus = 0;
            bll = new BLL.Sys_LeavesBLL();
            model = new Model.Sys_Leaves();
            model.ApplyPerson = context.Session["uLoginName"].ToString();
            model.LeaveReason = LeaveReason;
            model.LeaveStatus = leavestatus;
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