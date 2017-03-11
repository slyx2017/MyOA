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
    public partial class EditChildMenu : PageValidatePermiss
    {
        public int id = 0;
        public int pid = 0;
        public string pname = "";
        public string isck = "";
        public string isnock = "";
        public static Model.Sys_Menu model_m = null;
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
                    id = int.Parse(Request.Params["ID"].ToString());
                    pid = int.Parse(Request.Params["pId"].ToString());
                    pname = Request.Params["pname"].ToString();
                    this.ddl_MenuBlock.DataSource = GetInfoDS();
                    this.ddl_MenuBlock.DataTextField = "MenuName";
                    this.ddl_MenuBlock.DataValueField = "ID";
                    this.ddl_MenuBlock.DataBind();
                    ListItem item = ddl_MenuBlock.Items.FindByText(pname);

                    if (item != null)
                    {
                        item.Selected = true;
                    }
                    GetChildMenu();
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
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetChildMenu()
        {
            BLL.Sys_Menu bll_m = new BLL.Sys_Menu();
            model_m = new Model.Sys_Menu();
            model_m = bll_m.GetModel(id);
            isck = model_m.IsInUse == 1 ? "checked='true'" : "";
            isnock = model_m.IsInUse == 1 ? "" : "checked='true'";
        }
    }
}