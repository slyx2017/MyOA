using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManageMent.Sys
{
    public partial class DeptList : PageValidatePermiss
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
                    this.rpt_DeptList.DataSource = GetInfoDS();
                    this.rpt_DeptList.DataBind();
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
            BLL.DeptTypeBLL bll = new BLL.DeptTypeBLL();

            DataSet ds = new DataSet();
            ds = bll.GetDeptList(strWhere);
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