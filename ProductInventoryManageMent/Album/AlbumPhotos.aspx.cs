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
    

    public partial class AlbumPhotos : PageValidatePermiss
    {
        BLL.PhotosBLL bll_p = new BLL.PhotosBLL();
        BLL.AlbumsBLL bll_a = new BLL.AlbumsBLL();
        public int albumid = 0;
        public string albumname = "";
        public string coverphotopath = "";
        public string albumdesc = "";
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
                    albumid = int.Parse(Request.Params["AlbumId"]);
                    GetAlbumDB();
                    this.rpt_AlbumPhotoList.DataSource = GetInfoDS();
                    this.rpt_AlbumPhotoList.DataBind();
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " 1=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetInfoDS()
        {
            strWhere = "AlbumId=" + albumid + "";
            DataSet ds = bll_p.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        public void GetAlbumDB()
        {
            strWhere = "AlbumId=" + albumid + "";
            DataSet ds = bll_a.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                albumname = ds.Tables[0].Rows[0]["AlbumName"].ToString();//Request.Params["AlbumName"];
                coverphotopath = ds.Tables[0].Rows[0]["CoverPhotoPath"].ToString(); // Request.Params["CoverPhotoPath"];
                albumdesc= ds.Tables[0].Rows[0]["AlbumDesc"].ToString();
            }
        }
        int i = 0;
        protected void rpt_AlbumPhotoList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (i % 8 == 0)
            {
                e.Item.Controls.Add(new LiteralControl("<tr></tr>"));
            }
            i++;
        }
    }
}