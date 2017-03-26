using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductInventoryManagement.comm;
using System.Data;

namespace ProductInventoryManageMent.Leaves
{
    public partial class AddHols : PageValidatePermiss
    {
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
                    ddl_LeaveType.DataSource = GetLeaveTypeList();
                    ddl_LeaveType.DataTextField = "LeaveName";
                    ddl_LeaveType.DataValueField = "ID";
                    ddl_LeaveType.DataBind();
                    ddl_LeaveType.Items.Insert(0, new ListItem("--请选择--", "-1"));
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " 1=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetLeaveTypeList()
        {
            BLL.LeaveTypesBLL bll = new BLL.LeaveTypesBLL();
            DataSet ds = bll.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}