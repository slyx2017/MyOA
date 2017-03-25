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
    public partial class ModifyAlbum : PageValidatePermiss
    {
        public int albumid = 0;
        public string albumname = "";
        public string albumtypename = "";
        public static Model.Albums model_a = new Model.Albums();
        BLL.AlbumTypesBLL bll_pl = new BLL.AlbumTypesBLL();
        BLL.AlbumsBLL bll_a = new BLL.AlbumsBLL();
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
                    albumid = int.Parse(Request.Params["AlbumId"].ToString());
                    GetInfoDS();

                    this.ddl_AlbumTypeList.DataSource = GetAlbumTypeList();
                    this.ddl_AlbumTypeList.DataTextField = "AlbumTypeName";
                    this.ddl_AlbumTypeList.DataValueField = "ID";
                    this.ddl_AlbumTypeList.DataBind();
                    ListItem item = ddl_AlbumTypeList.Items.FindByText(albumtypename);

                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetInfoDS()
        {
            DataSet ds = bll_a.GetAlbumList("",albumid);
            if (ds.Tables[0].Rows.Count>0)
            {
                model_a.AlbumName = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                model_a.AlbumTypeId = int.Parse(ds.Tables[0].Rows[0]["AlbumTypeId"].ToString());
                model_a.AlbumDesc = ds.Tables[0].Rows[0]["AlbumDesc"].ToString();
                albumtypename = ds.Tables[0].Rows[0]["AlbumTypeName"].ToString();
            }
           
        }
        /// <summary>
        /// 获取相册类别列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAlbumTypeList()
        {
            DataSet ds = bll_pl.GetAlbumType();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}