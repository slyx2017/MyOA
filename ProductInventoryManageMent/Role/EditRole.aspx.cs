using ProductInventoryManagement.comm;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Role
{
    public partial class EditRole : PageValidatePermiss
    {
        BLL.Sys_Menu bll_m = new BLL.Sys_Menu();
        BLL.Sys_RoleInfo bll_ri = new BLL.Sys_RoleInfo();
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
                    DataBindRole();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获得所有大类菜单
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
            string menuname = "";
            string strWhere = "";
            
            foreach (RepeaterItem DataItem in rpt_RoleList.Items)
            {
                menuname = ((CheckBox)DataItem.FindControl("parentId")).Text;
                strWhere = " MenuName='" + menuname + "'";
                string pid = bll_m.GetList(strWhere).Tables[0].Rows[0]["ID"].ToString();
                string ppid = pid + ",";
                int i = 0;
                foreach (ListItem item in ((CheckBoxList)DataItem.FindControl("cbList")).Items)
                {
                    if (item.Selected == true)
                    {
                        returnValue += item.Value+",";
                        
                        if (i==0)
                        {
                            returnValue += ppid;
                            i += 1;
                        }
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 初始该角色的小类菜单
        /// </summary>
        private void DataBindRole()
        {

            if (Request.QueryString["RoleID"].ToString() == null || !Common.PositiveInt.IsPositiveInt(Request.QueryString["RoleID"].ToString()))
                return;
            int roleID = int.Parse(Request.QueryString["RoleID"]);
            Model.Sys_RoleInfo model_ri = new Model.Sys_RoleInfo();
            model_ri = bll_ri.GetModel(roleID);
            if (model_ri == null)
                return;

            this.txtRoleName.Text = model_ri.RoleName;
            int rid = -1;
            string strWhere = " RoleID=" + roleID + "";
            BLL.Sys_RoleMenuMapping bll_rmm = new BLL.Sys_RoleMenuMapping();
            DataSet ds = bll_rmm.GetRoleList(strWhere, rid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //初始化CheckBoxList选中项
                foreach (RepeaterItem DataItem in rpt_RoleList.Items)
                {
                    foreach (ListItem item in ((CheckBoxList)DataItem.FindControl("cbList")).Items)
                    {
                        DataRow[] dr = ds.Tables[0].Select("MenuID=" + item.Value + "");
                        if (dr.Length > 0)
                            item.Selected = true;
                    }
                }
            }
        }
        protected void rpt_RoleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataTable dt;
            int parentId = int.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strWhere = " RoleName='" + txtRoleName.Text + "'";
            string adduser = Session["uLoginName"].ToString();
            int rid = 0;
            DataSet ds = bll_ri.GetRoleList(strWhere, rid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Model.Sys_RoleInfo model_ri = new Model.Sys_RoleInfo();
                model_ri.RoleID = int.Parse(Request.QueryString["RoleID"].ToString());
                model_ri.RoleName = txtRoleName.Text;
                model_ri.RoleDesc = getCheckBoxListValue();
                if (bll_ri.EditRole(model_ri) > 0)
                {
                    lblMsg.InnerHtml = "<script type='text/javascript'>alert('修改成功!');window.location='RoleList.aspx'</script>";
                }
                else
                {
                    lblMsg.InnerHtml = "<script type='text/javascript'>alert('修改失败!');</script>";
                }
            }
            else
            {
                lblMsg.InnerHtml = "<script type='text/javascript'>alert('该角色名称不存在!');</script>";
            }
        }
    }
}