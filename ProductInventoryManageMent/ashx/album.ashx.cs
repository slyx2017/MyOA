using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// album 的摘要说明
    /// </summary>
    public class album : IHttpHandler,IRequiresSessionState
    {
        BLL.AlbumTypes bll_at = new BLL.AlbumTypes();
        BLL.Albums bll_a = new BLL.Albums();

        Model.AlbumTypes model_at = new Model.AlbumTypes();
        Model.Albums model_a = new Model.Albums();
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "addtype":
                    AddAlbumType(context);
                    break;
                case "edittype":
                    EditAlbumType(context);
                    break;
                case "addalbum":
                    AddAlbum(context);
                    break;
                case "editalbum":
                    EditAlbum(context);
                    break;
                case "delalbum":
                    DelAlbum(context);
                    break;
                case "setface":
                    SetAlbumFace(context);
                    break;
                default:
                    break;
            }
        }

        private void SetAlbumFace(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string path = context.Request.Params["CoverPhotoPath"];
            int AlbumID = int.Parse(context.Request.Params["AlbumId"].ToString());
            int photoid = int.Parse(context.Request.Params["PhotoId"].ToString());
            int codeNum = bll_a.SetAlbumFace(AlbumID, path, photoid);
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

        private void DelAlbum(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request.Params["AlbumId"]);
            string albumpath = context.Request.Params["AlbumPath"];
            int isDel = bll_a.DeleteAlbum(id);
            if (isDel>0)
            {
                string albumurl = context.Server.MapPath(albumpath);
                Directory.Delete(albumurl, true);
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("error");
                context.Response.End();
                return;
            }
        }

        private void EditAlbum(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string AlbumName = context.Request.Params["AlbumName"];
            string AlbumDesc = context.Request.Params["AlbumDesc"];
            int AlbumID = int.Parse(context.Request.Params["AlbumId"].ToString());
            int AlbumTypeID = int.Parse(context.Request.Params["AlbumTypeID"].ToString());
            model_a.AlbumName = AlbumName;
            model_a.AlbumTypeId = AlbumTypeID;
            model_a.AlbumDesc = AlbumDesc;
            model_a.AlbumId = AlbumID;
            int codeNum = bll_a.ModifyAlbum(model_a);
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

        private void AddAlbum(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string AlbumName = context.Request.Params["AlbumName"];
            string AlbumDesc = context.Request.Params["AlbumDesc"];
            int AlbumTypeID =int.Parse( context.Request.Params["AlbumTypeID"].ToString());
            string adduser = context.Session["uLoginName"].ToString();
            DateTime addtime= DateTime.Now;
            string albumfacepath = "";
            string albumdirpath = "/Images/"+ Guid.NewGuid().ToString();
            string dirurl = context.Request.MapPath(albumdirpath);
            if (!Directory.Exists(dirurl))
            {
                Directory.CreateDirectory(dirurl);
            }
            model_a.AlbumName = AlbumName;
            model_a.AddUser = adduser;
            model_a.AddTime = addtime;
            model_a.AlbumTypeId = AlbumTypeID;
            model_a.CoverPhotoPath = albumfacepath;
            model_a.AlbumDesc = AlbumDesc;
            model_a.AlbumPath = albumdirpath;
            int codeNum = bll_a.AddAlbum(model_a);
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

        private void EditAlbumType(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void AddAlbumType(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string AlbumTypeName = context.Request.Params["AlbumTypeName"];
            string adduser = context.Session["uLoginName"].ToString();
            model_at.AlbumTypeName = AlbumTypeName;
            model_at.AddTime = DateTime.Now;
            model_at.AddUser = adduser;
            int codeNum = bll_at.AddAlbumType(model_at);
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