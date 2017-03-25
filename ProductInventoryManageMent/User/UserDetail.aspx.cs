using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductInventoryManagement.comm;
using System.Data;

namespace ProductInventoryManageMent.User
{
    public partial class UserDetail : PageValidatePermiss
    {
        public int uid = 0;
        public string powername = "";
        public string rolename = "";
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
                    uid = int.Parse(Session["uId"].ToString());

                    GetUserModel();
                    GetPowerLevel();
                    GetRoleList();
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
            BLL.UsersBLL bll_u = new BLL.UsersBLL();
            model_u = new Model.Users();
            model_u = bll_u.GetModel(uid);
            powername = model_u.PowerLevelID.ToString();
            birthday.Value = model_u.Birthday == null ? "" : model_u.Birthday.ToString().Split(' ')[0];
            isck = model_u.Sex == true ? "checked='true'" : "";
            isnock = model_u.Sex == true ? "" : "checked='true'";
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetPowerLevel()
        {
            BLL.Sys_PowerLevelBLL bll_pl = new BLL.Sys_PowerLevelBLL();
            DataSet ds = bll_pl.GetPowerLevelList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.ddl_PowerLevel.DataSource =ds;
                this.ddl_PowerLevel.DataTextField = "PowerName";
                this.ddl_PowerLevel.DataValueField = "PowerLevelID";
                this.ddl_PowerLevel.DataBind();
                ListItem item_power = ddl_PowerLevel.Items.FindByValue(powername);
                if (item_power != null)
                {
                    item_power.Selected = true;
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetRoleList()
        {
            BLL.Sys_RoleInfoBLL bll_ri = new BLL.Sys_RoleInfoBLL();
            int rid = 0; //0.查询角色表; -1.查询角色菜单映射表
            strWhere = "";
            DataSet ds = bll_ri.GetRoleList(strWhere, rid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rolename = Session["RoleID"].ToString();
                this.ddl_RoleList.DataSource = ds;
                this.ddl_RoleList.DataTextField = "RoleName";
                this.ddl_RoleList.DataValueField = "RoleID";
                this.ddl_RoleList.DataBind();
                ListItem item_role = ddl_RoleList.Items.FindByValue(rolename);
                if (item_role != null)
                {
                    item_role.Selected = true;
                }
            }
        }
    }
}