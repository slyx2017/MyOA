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
    public partial class AddAlbum : PageValidatePermiss
    {
        BLL.AlbumTypesBLL bll_pl = new BLL.AlbumTypesBLL();
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
                    this.ddl_AlbumTypeList.DataSource = GetAlbumTypeList();
                    this.ddl_AlbumTypeList.DataTextField = "AlbumTypeName";
                    this.ddl_AlbumTypeList.DataValueField = "ID";
                    this.ddl_AlbumTypeList.DataBind();
                    ddl_AlbumTypeList.Items.Insert(0, new ListItem("--请选择--", "-1"));
                }
                else
                {
                    return;
                }
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