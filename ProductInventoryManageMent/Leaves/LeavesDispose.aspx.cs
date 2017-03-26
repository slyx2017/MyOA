using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManageMent.Leaves
{
    public partial class LeavesDispose : BasePage
    {
        public string Id = "";
        public string BeginTime = "";
        public string EndTime = "";
        public string leaveTypeName = "";
        string strWhere = " 1=1 ";
        public Model.Sys_Leaves model_leave = new Model.Sys_Leaves();
        BLL.LeaveTypesBLL bll_type = new BLL.LeaveTypesBLL();
        BLL.Sys_LeavesBLL bll_leave = new BLL.Sys_LeavesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionNull = SessionIsNull();
            if (isSessionNull)
            {
                return;
            }
            if (!IsPostBack)
            {
                string currenPath = Request.FilePath.Substring(1);
                bool isValide = ValidateUserPemiss(currenPath);
                if (isValide)
                {
                    Id = Request.Params["Id"].ToString();
                    GetLeavesInfo();
                    GetLeaveTypeList();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 获取假期类型数据列表
        /// </summary>
        /// <returns></returns>
        public void GetLeaveTypeList()
        {
            strWhere = " Id=" + model_leave.LeaveTypeID + "";
            DataSet ds = bll_type.GetList(strWhere);
            leaveTypeName = ds.Tables[0].Rows[0]["LeaveName"].ToString();
        }
        /// <summary>
        /// 获取假期申请数据列表
        /// </summary>
        /// <returns></returns>
        public void GetLeavesInfo()
        {
            int leaveId = Convert.ToInt32(Id);
            model_leave = bll_leave.GetModel(leaveId);
            BeginTime = string.Format("{0:u}", model_leave.BeginTime).Split(' ')[0].Replace('-', '/');
            EndTime = string.Format("{0:u}", model_leave.EndTime).Split(' ')[0];
        }
    }
}