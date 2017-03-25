using System.Data;
using System.Web;

namespace ProductInventoryManagement.comm
{
    public class PageValidatePermiss:System.Web.UI.Page
    {
        public static bool ValidateUserPemiss(string currentPath)
        {
            BLL.Sys_RoleMenuMappingBLL bll_ur = new BLL.Sys_RoleMenuMappingBLL();
            int roleId = int.Parse(HttpContext.Current.Session["RoleId"].ToString());
            DataSet ds = bll_ur.GetPagePath(roleId);
            int count = ds.Tables[0].Select(" MenuUrl='" + currentPath + "'").Length;
            if (count > 0)
            {
                return true;
            }
            else
            {
                //HttpContext.Current.Response.Redirect("../Login/Login.aspx");
                HttpContext.Current.Response.Write("<script>alert('你没有访问的权限！');</script>");
                HttpContext.Current.Response.End();
                return false;
            }
        }
        public static bool SessionIsNull()
        {
            if (HttpContext.Current.Session["uLoginName"] == null && HttpContext.Current.Session["uPwd"] == null)
            {
                HttpContext.Current.Response.Redirect("../Login/NoPermission.aspx");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}