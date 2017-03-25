using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.User
{
    public partial class UserAdd : PageValidatePermiss
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
                    this.ddl_PowerLevel.DataSource = GetPowerLevel();
                    this.ddl_PowerLevel.DataTextField = "PowerName";
                    this.ddl_PowerLevel.DataValueField = "PowerLevelID";
                    this.ddl_PowerLevel.DataBind();
                    ddl_PowerLevel.Items.Insert(0, new ListItem("--请选择--", "-1"));
                    this.ddl_Department.DataSource = GetDeptList();
                    this.ddl_Department.DataTextField = "DeptName";
                    this.ddl_Department.DataValueField = "DeptName";
                    this.ddl_Department.DataBind();
                    ddl_Department.Items.Insert(0, new ListItem("--请选择--", "-1"));
                    this.ddl_RoleList.DataSource = GetRoleList();
                    this.ddl_RoleList.DataTextField = "RoleName";
                    this.ddl_RoleList.DataValueField = "RoleID";
                    this.ddl_RoleList.DataBind();
                    ddl_RoleList.Items.Insert(0, new ListItem("--请选择--", "-1"));

                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " 1=1 ";
        /// <summary>
        /// 获取级别数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetPowerLevel()
        {
            BLL.Sys_PowerLevel bll_pl = new BLL.Sys_PowerLevel();
            DataSet ds = bll_pl.GetPowerLevelList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDeptList()
        {
            BLL.DeptTypeBLL bll_dp = new BLL.DeptTypeBLL();
            DataSet ds = bll_dp.GetDeptList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        /// <summary>
        /// 获取角色数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoleList()
        {
            BLL.Sys_RoleInfo bll_ri = new BLL.Sys_RoleInfo();
            //int roleId = int.Parse(Session["RoleID"].ToString());
            //string strWhere = " RoleID=" + roleId + "";
            strWhere = "";
            int rid = 0;
            DataSet ds = bll_ri.GetRoleList(strWhere, rid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}