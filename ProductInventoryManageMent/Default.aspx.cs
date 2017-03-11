using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductInventoryManagement.comm;
using System.Data;

namespace ProductInventoryManagement
{
    public partial class Default : PageValidatePermiss
    {
        BLL.Sys_Menu bll = new BLL.Sys_Menu();
        public string homepage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uLoginName"] == null && Session["uPwd"] == null)
            {
                Response.Redirect("Login/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int menucode = 1;
                DataSet dt= bll.GetPagePath(menucode);
                if (dt.Tables[0].Rows.Count>0)
                {
                    homepage = dt.Tables[0].Rows[0]["MenuUrl"].ToString();
                }
            }
        }
    }
}