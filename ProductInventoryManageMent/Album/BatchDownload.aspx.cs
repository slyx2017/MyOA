using Common;
using ProductInventoryManagement.comm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
namespace ProductInventoryManagement.Album
{
    public partial class BatchDownload : PageValidatePermiss
    {
        BLL.AlbumsBLL bll_a = new BLL.AlbumsBLL();
        int albumid = 0;
        string albumpath = "";
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
                    if (Request.Params["AlbumId"] != null)
                    {
                        albumid = int.Parse(Request.QueryString["AlbumId"]);
                        GetAlbumDB();
                        string dirurl = Server.MapPath(albumpath);
                        string[] PhotosUrl = Directory.GetFiles(dirurl);
                        MemoryStream ms = new MemoryStream();
                        byte[] buffer = null;
                        if (PhotosUrl.Length > 0)
                        {
                            using (ZipFile file = ZipFile.Create(ms))
                            {
                                file.BeginUpdate();
                                file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。

                                for (int i = 0; i < PhotosUrl.Length; i++)
                                {
                                    file.Add(PhotosUrl[i]);
                                }

                                file.CommitUpdate();

                                buffer = new byte[ms.Length];
                                ms.Position = 0;
                                ms.Read(buffer, 0, buffer.Length);
                            }
                            string filename = DateTime.Now.ToString() + ".zip";
                            Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
                            Response.BinaryWrite(buffer);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Redirect("../Login/Login.aspx");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = "";
        public void GetAlbumDB()
        {
            strWhere = "AlbumId=" + albumid + "";
            DataSet ds = bll_a.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                albumpath = ds.Tables[0].Rows[0]["AlbumPath"].ToString();
            }
        }
    }
}