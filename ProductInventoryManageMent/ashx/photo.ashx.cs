using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace ProductInventoryManagement.ashx
{
    /// <summary>
    /// imageupload 的摘要说明
    /// </summary>
    public class photo : IHttpHandler,IRequiresSessionState
    {
        BLL.Photos bll = new BLL.Photos();
        Model.Photos listmodel =new Model.Photos();
        //string ExpImgDir = "/Images";
        public void ProcessRequest(HttpContext context)
        {
            string param = context.Request.Params["param"];
            switch (param)
            {
                case "upload":
                    UploadImages(context);
                    break;
                case "delete":
                    DeletePhoto(context);
                    break;
                default:
                    break;
            }
        }

        private void DeletePhoto(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request.Params["PhotoId"]);
            int isface = int.Parse(context.Request.Params["IsAlbumFace"]);
            string path = context.Request.Params["PhotoPath"];
            int isDel= bll.DeletePhoto(id, isface);
            if (isDel>0)
            {
                string ImageURL = context.Request.MapPath(path); //转换物理路径
                FileHelper.DeleteDiskImage(ImageURL);
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
        private void UploadImages(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Session["uLoginName"].ToString();
            string AlbumName = context.Request.Params["AlbumName"];
            string AlbumPath = context.Request.Params["AlbumPath"];
            int albumid = int.Parse(context.Request.Params["AlbumId"].ToString());
            HttpFileCollection files = context.Request.Files;
            int count = files.Count;
            if (count>9)
            {
                context.Response.Write("more");
                context.Response.End();
                return;
            }
            int issuccess = 0;
            for (int i = 0; i < count; i++)
            {
                HttpPostedFile images = files.Get(i);
                //后台也要校验。
                string filNoExtName = Path.GetFileNameWithoutExtension(images.FileName);
                string fileName = Path.GetFileName(images.FileName);
                string ext = Path.GetExtension(images.FileName);
                if (!(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif"))
                {
                    //不是图片的时候：
                    context.Response.Write("error");
                    context.Response.End();
                    break;
                }
                else
                {
                    Random rd = new Random();
                    string rnum = rd.Next(10, 100).ToString();

                    string imgtitle = Guid.NewGuid().ToString();//DateTime.Now.ToString("yyyyMMddHHmmss") + rnum;
                    string albumpath = AlbumPath; //ExpImgDir + "/" + AlbumName;
                    string dirurl = context.Request.MapPath(albumpath);
                    if (!Directory.Exists(dirurl))
                    {
                        Directory.CreateDirectory(dirurl);
                    }
                    string path = albumpath + "/" + imgtitle + ext;// +file.FileName;
                    string vpath = context.Request.MapPath(path);
                    images.SaveAs(vpath);
                    
                    listmodel.PhotoName = fileName;
                    listmodel.PhotoPath = path;
                    listmodel.AddUser = userName;
                    listmodel.AddTime= DateTime.Now;
                    listmodel.AlbumId = albumid;
                    listmodel.IsAlbumFace = false;
                    int isadd=  bll.Add(listmodel);
                    if (isadd > 0)
                    {
                        issuccess += 1;
                        continue;
                    }
                    else
                    {
                        context.Response.Write("fail");
                        context.Response.End();
                        break;
                    }
                }
            }
            if (issuccess==count)
            {
                context.Response.Write("ok");
                context.Response.End();
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