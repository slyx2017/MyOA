using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DBUtility;
namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// adduser 的摘要说明
    /// </summary>
    public class user : IHttpHandler,IRequiresSessionState
    {
        BLL.UsersBLL bll_u = new BLL.UsersBLL();
        Model.Users model_u = new Model.Users();
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "isExist":
                    IsExist(context);
                    break;
                case "add":
                    AddUser(context);
                    break;
                case "edit":
                    EditUser(context);
                    break;
                case "del":
                    DelUser(context);
                    break;
                case "freeze":
                    FreezeUser(context);
                    break;
                case "modifypwd":
                    ModifyPwd(context);
                    break;
                default:
                    break;
            }

        }

        private void IsExist(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string uLoginName = context.Request.Params["uLoginName"];
           bool flag= bll_u.Exists(uLoginName);
            if (flag)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
            context.Response.End();
        }

        private void ModifyPwd(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            string pwd = context.Request.Params["newPwd"];
            model_u = new Model.Users();
            model_u.uId = uid;
            model_u.uPwd =DESEncrypt.Encrypt(pwd);
            bll_u = new BLL.UsersBLL();
            bool isOk = bll_u.ModifyPwd(model_u);
            if (isOk)
            {
                context.Session.Remove("uPwd");
                context.Session.Add("uPwd", pwd);
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

        private void FreezeUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int state = int.Parse(context.Request.Params["state"].ToString());
            bll_u = new BLL.UsersBLL();
            int isdel = bll_u.FreezeUser(uid, state);
            if (isdel > 0)
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

        private void DelUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int uIsDel = int.Parse(context.Request.Params["uIsDel"].ToString());
            bll_u = new BLL.UsersBLL();
            int isdel = bll_u.DeleteUserByID(uid, uIsDel);
            if (isdel > 0)
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

        private void EditUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int powerlevelID = int.Parse(context.Request.Params["powerlevelID"].ToString());
            string uLoginName = context.Request.Params["uLoginName"];
            int roleId = int.Parse(context.Request.Params["RoleID"].ToString());
            string telPhone = context.Request.Params["telPhone"];
            string email = context.Request.Params["email"];
            DateTime? birthday = DateTime.Parse(context.Request.Params["birthday"]);
            string sex = context.Request.Params["sex"];
            string department = context.Request.Params["Department"];
            bll_u = new BLL.UsersBLL();
            model_u = new Model.Users();
            model_u.uId = uid;
            model_u.uLoginName = uLoginName;
            model_u.Telephone = telPhone;
            model_u.Sex = sex == "1" ? true : false;
            model_u.PowerLevelID = powerlevelID;
            model_u.Birthday = birthday;
            model_u.Email = email;
            model_u.uName = uLoginName;
            model_u.Department = department;
            int codeNum = bll_u.EditUser(model_u, roleId);
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

        private void AddUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int powerlevelID = int.Parse(context.Request.Params["powerlevelID"].ToString());
            string uLoginName = context.Request.Params["uLoginName"];
            int roleId = int.Parse(context.Request.Params["RoleID"].ToString());
            string telPhone = context.Request.Params["telPhone"];
            string password = context.Request.Params["password"];
            string email = context.Request.Params["email"];
            DateTime? birthday = DateTime.Parse(context.Request.Params["birthday"]);
            string department = context.Request.Params["Department"];
            string sex = context.Request.Params["sex"];
            bool uisdel = false;
            bll_u = new BLL.UsersBLL();
            model_u = new Model.Users();
            model_u.uLoginName = uLoginName;
            model_u.uPwd = DESEncrypt.Encrypt(password);
            model_u.Telephone = telPhone;
            model_u.Sex = sex == "1" ? true : false;
            model_u.PowerLevelID = powerlevelID;
            model_u.uAddtime = DateTime.Now;
            model_u.Birthday = birthday;
            model_u.Email = email;
            model_u.AccountState = 1;
            model_u.uName = uLoginName;
            model_u.uIsDel = uisdel;
            model_u.Department = department;
            int codeNum = bll_u.AddNewUser(model_u, roleId);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}