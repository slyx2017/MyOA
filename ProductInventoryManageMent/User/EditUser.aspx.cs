﻿using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.User
{
    public partial class EditUser : PageValidatePermiss
    {
        public int uid = 0;
        public string powername = "";
        public string rolename = "";
        public string department = "";
        public string isck = "";
        public string isnock = "";
        string strWhere = " 1=1 ";
        public static Model.Users model_u = null;
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
                    uid = int.Parse(Request.Params["uId"].ToString());
                    powername = Request.Params["PowerName"].ToString();
                    this.ddl_PowerLevel.DataSource = GetPowerLevel();
                    this.ddl_PowerLevel.DataTextField = "PowerName";
                    this.ddl_PowerLevel.DataValueField = "PowerLevelID";
                    this.ddl_PowerLevel.DataBind();
                    ListItem item_power = ddl_PowerLevel.Items.FindByText(powername);
                    if (item_power != null)
                    {
                        item_power.Selected = true;
                    }
                    department = Request.Params["Department"].ToString();
                    this.ddl_Department.DataSource = GetDeptList();
                    this.ddl_Department.DataTextField = "DeptName";
                    this.ddl_Department.DataValueField = "DeptName";
                    this.ddl_Department.DataBind();
                    ListItem item_dept = ddl_Department.Items.FindByText(department);
                    if (item_dept != null)
                    {
                        item_dept.Selected = true;
                    }
                    rolename = Request.Params["RoleName"].ToString();
                    this.ddl_RoleList.DataSource = GetRoleList();
                    this.ddl_RoleList.DataTextField = "RoleName";
                    this.ddl_RoleList.DataValueField = "RoleID";
                    this.ddl_RoleList.DataBind();
                    ListItem item_role = ddl_RoleList.Items.FindByText(rolename);
                    if (item_role != null)
                    {
                        item_role.Selected = true;
                    }
                    GetUserModel();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetUserModel()
        {
            BLL.Users bll_u = new BLL.Users();
            model_u = new Model.Users();
            model_u = bll_u.GetModel(uid);
            birthday.Value = model_u.Birthday == null ? "" : model_u.Birthday.ToString().Split(' ')[0];
            isck = model_u.Sex == true ? "checked='true'" : "";
            isnock = model_u.Sex == true ? "" : "checked='true'";
        }
        
        /// <summary>
        /// 获取数据
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
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoleList()
        {
            BLL.Sys_RoleInfo bll_ri = new BLL.Sys_RoleInfo();
            int rid = 0; //0.查询角色表; -1.查询角色菜单映射表
            strWhere = "";
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