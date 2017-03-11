using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Album
{
    public partial class DownPhoto : PageValidatePermiss
    {
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
                    if (Request.Params["filename"] != null)
                    {
                        string imgurl = Request.QueryString["filename"];
                        string []arrfile = imgurl.Split('/');
                        string filefullname= arrfile[arrfile.Length-1];
                        object fileName = System.Web.HttpContext.Current.Server.MapPath(imgurl);
                        System.IO.FileInfo DownloadFile = new System.IO.FileInfo(fileName.ToString());
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.Buffer = false;
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filefullname);
                        Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
                        Response.WriteFile(DownloadFile.FullName);
                        Response.Flush();
                        Response.End();
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
    }
}