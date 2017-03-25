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
    public partial class UserList : PageValidatePermiss
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
                bool isValide= ValidateUserPemiss(currenPath);
                if (isValide)
                {
                    this.rpt_UserList.DataSource = GetInfoDS();
                    this.rpt_UserList.DataBind();
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " uIsDel!=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetInfoDS()
        {
            BLL.UsersBLL bll_u = new BLL.UsersBLL();
            DataSet ds = bll_u.GetUserList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}