using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// menu 的摘要说明
    /// </summary>
    public class menu : IHttpHandler, IRequiresSessionState
    {
        Model.Sys_Menu model = null;
        BLL.Sys_MenuBLL bll = new BLL.Sys_MenuBLL();
        string strWhere = "";
        string parentJson = "";
        string childWhere = "";
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "init":
                    MenuInit(context);
                    break;
                case "home":
                    HomeSetting(context);
                    break;
                case "addblock":
                    AddMenuBlock(context);
                    break;
                case "editblock":
                    EditMenuBlock(context);
                    break;
                case "addchild":
                    AddMenuChild(context);
                    break;
                case "editchild":
                    EditMenuChild(context);
                    break;
                case "delblock":
                    DeleteBlockMenu(context);
                    break;
                case "delchild":
                    DeleteChildMenu(context);
                    break;
                default:
                    break;
            }
        }

        private void HomeSetting(HttpContext context)
        {
            int id = int.Parse(context.Request.Params["ID"].ToString());
            int menucode = 1;
           int ihome= bll.SetHomePage(id,menucode);
           if (ihome>0)
           {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        }

        #region 删除模块菜单 DeleteBlockMenu(HttpContext context)
        /// <summary>
        /// 删除模块菜单
        /// </summary>
        /// <param name="context"></param>
        private void DeleteBlockMenu(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request.Params["ID"].ToString());
            int ParentID = 0;
            int isdel = bll.DeleteMenuBlock(id,ParentID);
            if (isdel>0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        } 
        #endregion

        #region 删除子菜单 DeleteChildMenu(HttpContext context)
        /// <summary>
        /// 删除子菜单
        /// </summary>
        /// <param name="context"></param>
        private void DeleteChildMenu(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request.Params["ID"].ToString());
            int isdel = bll.DeleteMenuChild(id);
            if (isdel>0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        } 
        #endregion

        #region 修改子菜单项 EditMenuChild(HttpContext context)
        /// <summary>
        /// 修改子菜单项
        /// </summary>
        /// <param name="context"></param>
        private void EditMenuChild(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string menuName = context.Request.Params["menuName"];
            string menuUrl = context.Request.Params["menuUrl"];
            string description = context.Request.Params["Description"];
            int sequence = int.Parse(context.Request.Params["orderNum"].ToString());
            int parentid = int.Parse(context.Request.Params["ParentID"].ToString());
            int isInUse = int.Parse(context.Request.Params["isInUse"].ToString());
            int id = int.Parse(context.Request.Params["ID"].ToString());
            model = new Model.Sys_Menu();
            model.MenuName = menuName;
            model.MenuUrl = menuUrl;
            model.ParentID = parentid;
            model.Sequence = sequence;
            model.IsInUse = isInUse;
            model.ID = id;
            int codeNum = bll.EidtChildMenu(model);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        }
        #endregion

        #region 修改模块菜单项 EditMenuBlock(HttpContext context)
        /// <summary>
        /// 修改模块菜单项
        /// </summary>
        /// <param name="context"></param>
        private void EditMenuBlock(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request.Params["ID"].ToString());
            string menuName = context.Request.Params["menuBlock"];
            int isInUse = int.Parse(context.Request.Params["isInUse"].ToString());
            string description = context.Request.Params["Description"];
            int sequence = int.Parse(context.Request.Params["orderNum"].ToString());
            int roleId = int.Parse(context.Session["RoleID"].ToString());
            model = new Model.Sys_Menu();
            model.ID = id;
            model.MenuName = menuName;
            model.Sequence = sequence;
            model.IsInUse = isInUse;
            model.Description = description;
            int codeNum = bll.UpdateMenuBlock(model);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        }
        #endregion

        /* 注释部分
        private void MenuBlock(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            DataSet ds = new DataSet();
            strWhere = " ParentID=0";
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            parentJson = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string menuname = dt.Rows[i]["MenuName"].ToString();
                    int pid = int.Parse(dt.Rows[i]["ID"].ToString());
                    parentJson += "{\"name\": \"" + menuname + "\", \"open\": true, \"children\": [";
                    childWhere = " ParentID=" + pid + "";
                    DataTable dt_child = bll.GetList(childWhere).Tables[0];
                    if (dt_child.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_child.Rows.Count; j++)
                        {
                            string menuchildname = dt_child.Rows[j]["MenuName"].ToString();
                            string childurl = dt_child.Rows[j]["MenuUrl"].ToString();
                            parentJson += "{\"name\": \"" + menuchildname + "\"},";
                        }
                        if (parentJson.EndsWith(","))
                        {
                            parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                        }
                        parentJson += "]},";
                    }
                }
                if (parentJson.EndsWith(","))
                {
                    parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                }
                parentJson += "]";
            }

            string strJson = parentJson;
            context.Response.Write(parentJson);
            context.Response.End();
        }*/

        #region 子菜单页面添加 AddMenuChild(HttpContext context)
        /// <summary>
        /// 子菜单页面添加
        /// </summary>
        /// <param name="context"></param>
        private void AddMenuChild(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string menuName = context.Request.Params["menuName"];
            int isInUse = int.Parse(context.Request.Params["isInUse"].ToString());
            string description = context.Request.Params["Description"];
            string menuUrl = context.Request.Params["menuUrl"];
            int sequence = int.Parse(context.Request.Params["orderNum"].ToString());
            string adduser = context.Session["uLoginName"].ToString();
            int roleId = int.Parse(context.Session["RoleID"].ToString());
            int uId = int.Parse(context.Session["uId"].ToString());
            int parentid = int.Parse(context.Request.Params["ParentID"].ToString());
            model = new Model.Sys_Menu();
            model.MenuName = menuName;
            model.MenuUrl = menuUrl;
            model.ParentID = parentid;
            model.MenuCode = 0;
            model.Sequence = sequence;
            model.IsInUse = isInUse;
            model.AddTime = DateTime.Now;
            model.AddUser = adduser;
            model.AddUserID = uId;
            int codeNum = bll.AddMenuBlock(model,roleId);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                return;
            }
        }
        #endregion

        #region 初始化树形菜单 MenuInit(HttpContext context)
        /// <summary>
        /// 初始化树形菜单
        /// </summary>
        /// <param name="context"></param>
        private void MenuInit(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            DataSet ds = new DataSet();
            strWhere = " and ParentID=0 and IsInUse=1 ";
            int uid = int.Parse(context.Session["uId"].ToString());
            ds = bll.GetMenuListByUser(uid, strWhere);
            DataTable dt = ds.Tables[0];
            parentJson = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string menuname = dt.Rows[i]["MenuName"].ToString();
                    int pid = int.Parse(dt.Rows[i]["ID"].ToString());
                    parentJson += "{\"name\": \"" + menuname + "\", \"open\": false, \"children\": [";
                    childWhere = " and ParentID=" + pid + " and IsInUse=1 ";
                    DataTable dt_child = bll.GetMenuListByUser(uid, childWhere).Tables[0];
                    if (dt_child.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_child.Rows.Count; j++)
                        {
                            string menuchildname = dt_child.Rows[j]["MenuName"].ToString();
                            string childurl = dt_child.Rows[j]["MenuUrl"].ToString();
                            parentJson += "{\"name\": \"" + menuchildname + "\", \"url\": \"" + childurl + "\", \"target\": \"main\" },";
                        }
                        if (parentJson.EndsWith(","))
                        {
                            parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                        }
                    }
                    parentJson += "]},";
                }
                if (parentJson.EndsWith(","))
                {
                    parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                }

            }
            parentJson += "]";
            string strJson = parentJson;
            context.Response.Write(parentJson);
            context.Response.End();
        }
        #endregion

        #region 系统设置中菜单管理 MenuManagement(HttpContext context)
        /// <summary>
        /// 系统设置中菜单管理
        /// </summary>
        /// <param name="context"></param>
        /* 注释部分
        private void MenuManagement(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            DataSet ds = new DataSet();
            strWhere = " ParentID=0";
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            parentJson = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string menuname = dt.Rows[i]["MenuName"].ToString();
                    int pid = int.Parse(dt.Rows[i]["ID"].ToString());
                    parentJson += "{\"name\": \"" + menuname + "\", \"open\": true, \"children\": [";
                    childWhere = " ParentID=" + pid + "";
                    DataTable dt_child = bll.GetList(childWhere).Tables[0];
                    if (dt_child.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_child.Rows.Count; j++)
                        {
                            string menuchildname = dt_child.Rows[j]["MenuName"].ToString();
                            string childurl = dt_child.Rows[j]["MenuUrl"].ToString();
                            parentJson += "{\"name\": \"" + menuchildname + "\"},";
                        }
                        if (parentJson.EndsWith(","))
                        {
                            parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                        }
                        parentJson += "]},";
                    }
                }
                if (parentJson.EndsWith(","))
                {
                    parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                }
                parentJson += "]";
            }

            string strJson = parentJson;
            context.Response.Write(parentJson);
            context.Response.End();
        }*/
        #endregion

        #region  菜单模块添加 AddMenuBlock(HttpContext context)
        /// <summary>
        /// 菜单模块添加
        /// </summary>
        /// <param name="context"></param>
        private void AddMenuBlock(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string menuName = context.Request.Params["menuBlock"];
            int isInUse = int.Parse(context.Request.Params["isInUse"].ToString());
            string description = context.Request.Params["Description"];
            int sequence = int.Parse(context.Request.Params["orderNum"].ToString());
            string adduser = context.Session["uLoginName"].ToString();
            int roleId = int.Parse(context.Session["RoleID"].ToString());
            int uId = int.Parse(context.Session["uId"].ToString());
            int parentid = 0;
            string menuUrl = "";
            model = new Model.Sys_Menu();
            model.MenuName = menuName;
            model.MenuUrl = menuUrl;
            model.ParentID = parentid;
            model.MenuCode = 0;
            model.Sequence = sequence;
            model.IsInUse = isInUse;
            model.AddTime = DateTime.Now;
            model.AddUser = adduser;
            model.AddUserID = uId;
            int codeNum = bll.AddMenuBlock(model,roleId);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                return;
            }
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}