using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManageMent.Sys
{
    public partial class HolsModify : PageValidatePermiss
    {
        public string Id = "";
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
                    BeginTime.Value = string.Format("{0:u}", model_leave.BeginTime).Split(' ')[0].Replace('-','/');
                    EndTime.Value = string.Format("{0:u}", model_leave.EndTime).Split(' ')[0];
                    ddl_LeaveType.DataSource = GetLeaveTypeList();
                    ddl_LeaveType.DataTextField = "LeaveName";
                    ddl_LeaveType.DataValueField = "ID";
                    ddl_LeaveType.DataBind();
                    ListItem item_jq = ddl_LeaveType.Items.FindByValue(model_leave.LeaveTypeID.ToString());
                    if (item_jq != null)
                    {
                        item_jq.Selected = true;
                    }
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
        public DataSet GetLeaveTypeList()
        {
            DataSet ds = bll_type.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        /// <summary>
        /// 获取假期申请数据列表
        /// </summary>
        /// <returns></returns>
        public void GetLeavesInfo()
        {
            int leaveId = Convert.ToInt32(Id);
            model_leave = bll_leave.GetModel(leaveId);
        }
    }
}