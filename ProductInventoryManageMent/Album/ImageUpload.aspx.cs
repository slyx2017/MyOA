using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Album
{
    public partial class ImageUpload : PageValidatePermiss
    {
        BLL.AlbumsBLL bll_a = new BLL.AlbumsBLL();
        public int albumid = 0;
        public string albumname = "";
        public string coverphotopath = "";
        public string albumpath = "";
        string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //albumid = int.Parse(Request.Params["AlbumId"]);
            //albumname = Request.Params["AlbumName"];
            //coverphotopath = Request.Params["CoverPhotoPath"];
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
                    albumid = int.Parse(Request.Params["AlbumId"]);
                    GetAlbumDB();
                }
                else
                {
                    return;
                }
            }
           
        }
        public void GetAlbumDB()
        {
            strWhere = "AlbumId=" + albumid + "";
            DataSet ds = bll_a.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                albumname = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                coverphotopath = ds.Tables[0].Rows[0]["CoverPhotoPath"].ToString(); 
                albumpath = ds.Tables[0].Rows[0]["AlbumPath"].ToString();
            }
        }
    }
}