using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Menu
{
    public partial class AddChildMenu : PageValidatePermiss
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
                    this.ddl_MenuBlock.DataSource = GetInfoDS();
                    this.ddl_MenuBlock.DataTextField = "MenuName";
                    this.ddl_MenuBlock.DataValueField = "ID";
                    this.ddl_MenuBlock.DataBind();
                    ddl_MenuBlock.Items.Insert(0, new ListItem("--请选择--", "-1"));
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
            BLL.Sys_Menu bll_menu = new BLL.Sys_Menu();
            strWhere = " and ParentID=0 ";
            int uid = int.Parse(Session["uId"].ToString());
            DataSet ds = bll_menu.GetMenuListByUser(uid, strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}