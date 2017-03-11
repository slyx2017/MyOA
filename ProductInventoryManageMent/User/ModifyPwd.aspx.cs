using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductInventoryManagement.comm;

namespace ProductInventoryManageMent.User
{
    public partial class ModifyPwd : PageValidatePermiss
    {
        public int uid = 0;
        public static Model.Users model_u = null;
        public string upwd = string.Empty;
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
                    uid = int.Parse(Session["uId"].ToString());
                    GetUserModel();
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
        public void GetUserModel()
        {
            BLL.Users bll_u = new BLL.Users();
            model_u = new Model.Users();
            model_u = bll_u.GetModel(uid);
            upwd = DBUtility.DESEncrypt.Decrypt(model_u.uPwd.Trim());
            
        }
    }
}