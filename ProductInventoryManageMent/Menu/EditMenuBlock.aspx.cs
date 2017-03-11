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
    public partial class EditMenuBlock : PageValidatePermiss
    {
        public int id = 0;
        public string isck="";
        public string isnock="";
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
                    if (Request.Params["ID"] == null)
                    {
                        Response.Write("这个菜单不能显示到左边菜单列表!");
                        Response.End();
                        return;
                    }
                    id = int.Parse(Request.Params["ID"].ToString());
                    GetInfoDS();
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
        public void GetInfoDS()
        {
            BLL.Sys_Menu bll_m = new BLL.Sys_Menu();
            model_m = new Model.Sys_Menu();
            model_m = bll_m.GetModel(id);
            isck = model_m.IsInUse == 1 ? "checked='true'" : "";
            isnock = model_m.IsInUse == 1 ? "" : "checked='true'";
        }
    }
}