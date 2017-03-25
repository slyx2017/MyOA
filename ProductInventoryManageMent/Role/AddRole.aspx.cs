using ProductInventoryManagement.comm;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Role
{
    public partial class AddRole : PageValidatePermiss
    {
        BLL.Sys_MenuBLL bll_m = new BLL.Sys_MenuBLL();
        BLL.Sys_RoleInfoBLL bll_ri = new BLL.Sys_RoleInfoBLL();
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
                    GetRoleList();
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
        public void GetRoleList()
        {
            int parentid = 0;
            int roleId = 0;
            DataTable dt = bll_m.GetMenuListByParentID(parentid,roleId).Tables[0];
            rpt_RoleList.DataSource = dt.DefaultView;
            rpt_RoleList.DataBind();
        }
        /// <summary>
        /// 获取选中的小类Id
        /// </summary>
        /// <returns></returns>
        private string getCheckBoxListValue()
        {
            //取得CheckBoxList选中项的值
            string returnValue = "";
            foreach (RepeaterItem DataItem in rpt_RoleList.Items)
            {
                foreach (ListItem item in ((CheckBoxList)DataItem.FindControl("cbList")).Items)
                {
                    if (item.Selected == true)
                    {
                        if (returnValue == "")
                            returnValue = item.Value;
                        else
                            returnValue += "," + item.Value;
                    }
                }
            }

            return returnValue+",";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strWhere = " RoleName='"+txtRoleName.Text+"'";
            string adduser = Session["uLoginName"].ToString();
            int roleId = 0;
            DataSet ds= bll_ri.GetRoleList(strWhere, roleId);

            if (ds.Tables[0].Rows.Count>0)
            {
                lblMsg.InnerHtml = "<script type='text/javascript'>alert('该角色名称已经存在!');</script>";
            }
            else
            {
                Model.Sys_RoleInfo model_ri = new Model.Sys_RoleInfo();

                model_ri.RoleName = txtRoleName.Text;
                model_ri.RoleDesc = getCheckBoxListValue();
                model_ri.WriteRight = "1";
                model_ri.AddTime = DateTime.Now;
                model_ri.AddUser = adduser;
                if (bll_ri.AddNewRole(model_ri) > 0)
                    lblMsg.InnerHtml = "<script type='text/javascript'>alert('添加成功!');window.location='Manage_Role.aspx'</script>";
            }
        }

        protected void rpt_RoleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataTable dt;
            int parentId =int.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
            int roleId = 0;
            CheckBoxList childRen = (CheckBoxList)e.Item.FindControl("cbList");
            if (childRen != null)
            {
                dt = bll_m.GetMenuListByParentID(parentId,roleId).Tables[0];
                childRen.DataSource = dt.DefaultView;
                childRen.DataTextField = "MenuName";
                childRen.DataValueField = "ID";
                childRen.DataBind();
            }
        }
    }
}