using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManageMent.Sys
{
    public partial class ModifyDept : BasePage
    {
        public string Id = "";
        BLL.DeptTypeBLL bll = new BLL.DeptTypeBLL();
        public Model.DeptType model = new Model.DeptType();
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
                    Id = Request.Params["Id"].ToString();
                    GetDeptList();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <returns></returns>
        public void GetDeptList()
        {
            int deptId = Convert.ToInt32(Id);
            model = bll.GetModel(deptId);
        }
    }
}