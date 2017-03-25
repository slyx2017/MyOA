using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProductInventoryManagement.comm;

namespace ProductInventoryManagement.Menu
{
    public partial class MenuList : PageValidatePermiss
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
                    this.rpt_MenuBlock.DataSource = GetInfoDS();
                    this.rpt_MenuBlock.DataBind();
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
        public DataTable GetInfoDS()
        {
            BLL.Sys_MenuBLL bll_m = new BLL.Sys_MenuBLL();
            int pid = 0;
            int roleId = int.Parse(Session["RoleID"].ToString());
            DataSet ds = bll_m.GetMenuListByParentID(pid,roleId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
                return null;
        }
    }
}