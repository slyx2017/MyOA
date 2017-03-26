using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductInventoryManagement.comm;
using System.Data;

namespace ProductInventoryManageMent.Leaves
{
    public partial class LeavesApplyList : BasePage
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
                    this.rpt_LeaveList.DataSource = GetInfoDS();
                    this.rpt_LeaveList.DataBind();
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " 1=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetInfoDS()
        {
            BLL.Sys_LeavesBLL bll = new BLL.Sys_LeavesBLL();
            string userName =Session["uLoginName"].ToString();
            strWhere = " ApplyPerson='"+ userName + "'";
            DataSet ds = bll.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}