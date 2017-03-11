using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Role
{
    public partial class RoleList : PageValidatePermiss
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
                    this.rpt_RoleList.DataSource = GetInfoDS();
                    this.rpt_RoleList.DataBind();
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = "";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetInfoDS()
        {
            BLL.Sys_RoleInfo bll_ri = new BLL.Sys_RoleInfo();
            int roleId = int.Parse(Session["RoleID"].ToString());
            //strWhere = " RoleID="+roleId+"";
            DataSet ds = new DataSet();

            ds = bll_ri.GetRoleList(strWhere, roleId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
    }
}